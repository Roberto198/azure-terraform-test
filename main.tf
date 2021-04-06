resource "azurerm_resource_group" "rg" {
  name     = "${var.environment}-vehicle-rg"
  location = "West Europe"
}