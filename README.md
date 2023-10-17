## Azure Functions - Magic Ball

This project is one azure function app to get a response according the question passed by user. For study purposes only.

The resource names of the commands below were the names I adopted, but it is possible to use other names.


In this example of implementing a serverless application, 3 types of templates were created:

1- Http Trigger GET where it returns an answer to any question asked via querystring;
2- Same application, but by appointment, providing a response every 30 seconds;
3- HTTP Trigger GET to integrate with a blob storage where a configuration file in json will be retrieved.

The reference for these examples was the following Microsoft Learn link:

[Lab 02: Implement task processing logic by using Azure Functions](https://microsoftlearning.github.io/AZ-204-DevelopingSolutionsforMicrosoftAzure/Instructions/Labs/AZ-204_lab_02.html)

##### Install the Azure Functions Core Tools

If you have not installed it on your computer. See how to install the Azure Functions Core Tools by [clicking here](https://learn.microsoft.com/en-us/azure/azure-functions/functions-run-local?tabs=windows%2Cisolated-process%2Cnode-v4%2Cpython-v2%2Chttp-trigger%2Ccontainer-apps&pivots=programming-language-csharp#install-the-azure-functions-core-tools).

##### Created a local project

A local project was created to include the functions apps using the following command:

`func init func-magicballapp --worker-runtime dotnet`

##### Created the GetResponse function

The GetResponse app function was created using the following command:

`func new --template "HTTP trigger" --name "GetResponse"`

##### Run & test

To test the application, run using the command below and use the get-response.http file with the [VS Code Rest Client](https://marketplace.visualstudio.com/items?itemName=humao.rest-client) extension to test:

`func start --build`

##### Start Azurite

`azurite -s -l c:\azurite -d c:\azurite\debug.log`

##### Publish function to Azure

Login in Azure

`az login`

Create a resource group

`az group create -n az-204 -l eastus`

Create a Storage Account

`az storage account create -n stfunctionlabeastus001 -l eastus -g az-204 --sku Standard_LRS`

Create a Function App

`az functionapp create --resource-group az-204 --name func-magicball-lab-eastus-001 --storage-account stfunctionlabeastus001 --os Linux --runtime dotnet-isolated --runtime-version 6 --functions-version 4 --consumption-plan-location eastus`

Publish your Function App's code

`func azure functionapp publish func-magicball-lab-eastus-001`

Deleting the resource group

`az group delete -n az-204 --no-wait --yes`
