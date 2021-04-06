
# creaate a resource group
resource "azurerm_resource_group" "rg" {
  name     = "${var.environment}-VMS-rg"
  location = "West Europe"
}

# create a storaage account
resource "azurerm_storage_account" "functionsStorageAccount" {
  name                     = "${var.environment}vms"
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

  sku {
    tier = "Dynamic"
    size = "Y1"
  }
}

resource "azurerm_application_insights" "appInsights" {
  name                = "${var.environment}-VMS"
  location            = "${azurerm_resource_group.rg.location}"
  resource_group_name = "${azurerm_resource_group.rg.name}"
  application_type    = "Web"
}