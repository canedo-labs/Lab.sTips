# AppSettingsValidators

### This Tip will help you to validate the AppSettings.json file in your .NET Core application. 

### This is a very common requirement in any application to validate the configuration file before the application starts. 

### This will help you to avoid any runtime exceptions due to missing or incorrect configuration values.

You can use the following code to validate the AppSettings.json file in your .NET Core application on `Startup` class.

If you using `IOptions` to bind the configuration values, you can use the following code to validate the configuration values.

```csharp

services.AddOptionsWithValidation<PoCoOptionsSettings>("PoCoOptionsSettings");

```
> Note: The `PoCoOptionsSettings` class is a POCO class configuration.

Case you not declaring the configuration values in the `appsettings.json` file, the application will throw an exception when call `app.Run()` method.

Will produce the following exception:

> OptionsValidationException: <br> <pre>DataAnnotation validation failed for 'PoCoOptionsSettings' members: <br>'FieldOne' with the error: 'The FieldOne field is required.'.;</pre><br><pre>DataAnnotation validation failed for 'PoCoOptionsSettings' members:<br>'FieldTwo' with the error: 'The FieldTwo field is required.'.</pre>

If you are not using `IOptions` as default to bind the configuration values, you can use the following code to validate the configuration values.

```csharp

services.AddSettingsWithValidation<PoCoSettings>("PoCoSettings");

```
> Note: The `PoCoSettings` class is a POCO class configuration.

Case you not declaring the configuration values in the `appsettings.json` file, the application will throw an exception when call `app.Run()` method.

Will produce the following exception:

> OptionsValidationException: <br> <pre>DataAnnotation validation failed for 'PoCoSettings' members: <br>'FieldOne' with the error: 'The FieldOne field is required.'.;</pre><br><pre>DataAnnotation validation failed for 'PoCoSettings' members:<br>'FieldTwo' with the error: 'The FieldTwo field is required.'.</pre>

#### Its possible to user both methods to validate the configuration values in your .NET Core application.