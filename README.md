MassTransit.LibLog
==================

This integration library adds support for [LibLog][0] to [MassTransit][1]. LibLog enables dependency free logging. It contains transparent builtin support for NLog, Log4Net, EntLib Logging and SeriLog or allows the user to define a custom provider. Works with .NET 4 and higher.

### Usage
To hookup LibLog to MassTransit, just one line of code is needed when configuring MassTransit
```csharp
var serviceBus = ServiceBusFactory.New(configurator =>
{
	/* The usual stuff... */
	
	configurator.UseLibLog();	
})
```
[0]: https://github.com/damianh/LibLog
[1]: https://github.com/MassTransit/MassTransit
