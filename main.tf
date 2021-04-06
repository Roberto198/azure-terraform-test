
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