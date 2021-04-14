
# Apadmi POC Vehicle Management System

## Tools:

[Terraform](https://learn.hashicorp.com/tutorials/terraform/install-cli)  
[dotnet core 3.1](https://dotnet.microsoft.com/download)  
[Azure Functions Core Tools](https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local?tabs=windows%2Ccsharp%2Cbash#v2)  
[Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli)  
[dotnet EF Core tools] (https://docs.microsoft.com/en-us/ef/core/cli/dotnet)

## Deployment

### Log into correct azure account  

Run these commands:

> az login  

### Initialise terraform, deploy resources  

Run these commands:


> terraform init  
> terraform plan  
> terraform apply

### Create a function-app (This has already been done, creates the 'Client' function app)

> func init Client --dotnet

### Create a c# / dotnet function inside the client folder

> func new --name ${function name here} --template "Http trigger" --authlevel "anonymous"  

Note: --authlevel currently anonymous, subject to change 

#### To deploy the function-app as a whole, in the client or admin  
> cd ./Client
> func azure functionapp publish ${environment}-functionApp-VMS