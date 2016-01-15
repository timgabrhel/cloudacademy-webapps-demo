#Login-AzureRmAccount -TenantId "{Your TenantId Here}"
New-AzureRmResourceGroup -Name CloudAcademyWebApps -Location 'North Central US'
New-AzureRmResourceGroupDeployment -ResourceGroupName CloudAcademyWebApps -Mode Incremental -TemplateFile azuredeploy.json -TemplateParameterFile azuredeploy.parameters.json