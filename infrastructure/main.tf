
# creaate a resource group
resource "azurerm_resource_group" "rg" {
  name     = "${var.environment}-VMS-rg"
  location = "West Europe"
}

# create a storaage account
resource "azurerm_storage_account" "functionsStorageAccount" {
  name                     = "${var.environment}functionstoragevms"
  resource_group_name      = azurerm_resource_group.rg.name
  location                 = azurerm_resource_group.rg.location
  account_tier             = "Standard"
  account_replication_type = "LRS"
}

# create an app service plan
resource "azurerm_app_service_plan" "consumptionServicePlan" {
  name                = "${var.environment}-functionplan-01"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  kind                = "FunctionApp"
  reserved            = true

  sku {
    tier = "Dynamic"
    size = "Y1"
  }
}

resource "azurerm_application_insights" "appInsights" {
  name                = "${var.environment}-VMS"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  application_type    = "web"
}

resource "azurerm_function_app" "client" {
  name                          = "${var.environment}-functionApp1-VMS"
  location                      = azurerm_resource_group.rg.location
  resource_group_name           = azurerm_resource_group.rg.name
  app_service_plan_id           = azurerm_app_service_plan.consumptionServicePlan.id
  storage_account_name          = azurerm_storage_account.functionsStorageAccount.name
  storage_account_access_key    = azurerm_storage_account.functionsStorageAccount.primary_access_key
  os_type                       = "linux"



  //TODO: remove passwords and usernames
  app_settings = {
    "APPINSIGHTS_INSTRUMENTATIONKEY" = azurerm_application_insights.appInsights.instrumentation_key
    "sqldb_connection": "Server=tcp:robc-sqlserver-vms1.database.windows.net,1433;Initial Catalog=robc-serverles-db-vms;Persist Security Info=False;User ID=robc;Password=password-123456789;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
  }
}

resource "azurerm_sql_server" "sqlserver" {
    name                        = "${var.environment}-sqlserver-vms1"
    location                      = azurerm_resource_group.rg.location
    resource_group_name           = azurerm_resource_group.rg.name
    version                     = "12.0"

    administrator_login         = var.environment
    administrator_login_password = "password-123456789"
}

resource "azurerm_mssql_database" "serverless_db" {
    name                        = "${var.environment}-serverles-db-vms"
    server_id                   = azurerm_sql_server.sqlserver.id
    collation                   = "SQL_Latin1_General_CP1_CI_AS"

    auto_pause_delay_in_minutes = 60
    max_size_gb                 = 32
    min_capacity                = 0.5
    read_replica_count          = 0
    read_scale                  = false
    sku_name                    = "GP_S_Gen5_1"
    zone_redundant              = false

    threat_detection_policy {
        disabled_alerts      = []
        email_account_admins = "Disabled"
        email_addresses      = []
        retention_days       = 0
        state                = "Disabled"
        use_server_default   = "Disabled"
    }
}

resource "azurerm_mssql_firewall_rule" "vms-dev-firewall-rule" {
  name             = "vms-${var.environment}-firewall-rule"
  server_id        = azurerm_sql_server.sqlserver.id
  start_ip_address = "0.0.0.0"
  end_ip_address   = "0.0.0.0"
}
resource "azurerm_mssql_firewall_rule" "vms-dev-firewall-rule-development" {
  name             = "vms-${var.environment}-firewall-rule"
  server_id        = azurerm_sql_server.sqlserver.id
  start_ip_address = local.json_data.ipAddress
  end_ip_address   = local.json_data.ipAddress
}