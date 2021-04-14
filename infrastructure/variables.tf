variable "environment" {
  description = "Name tag or environment"
  type        = string
  default     = "robc" 
}

locals {
  json_data = jsondecode(file("${path.module}/settings.json"))
}