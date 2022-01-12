using UI;
using Models;
using Serilog;

Log.Logger = new LoggerConfiguration()
.WriteTo.File(@"..\StoreDL\logger.txt")
.CreateLogger();

MenuFactory.GetMenu("main").Start();
