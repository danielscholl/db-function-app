# db-function-app

This repository contains a sample Function App for calling Azure SQL.

## Getting Started

This is built following the instructions in Visual Studio Code

https://code.visualstudio.com/tutorials/functions-extension/getting-started

Requires a local.settings.json file
```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "<storage_connection_string>",
    "AzureWebJobsDashboard": ""
  },
  "ConnectionStrings": {
    "MyDbConnStr": "<sql_connection_string>"
  }
}

```