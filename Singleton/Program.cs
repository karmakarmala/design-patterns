using Singleton;

// Implementations

var logger=Logger.Instance;
Logger.LogMessage("Hello, Singleton!");

var dbConnection=DatabaseConnection.Instance;
var connection=dbConnection.GetConnection();

var config=Configuration.Instance;
var setting=config.GetSetting("Setting1");

