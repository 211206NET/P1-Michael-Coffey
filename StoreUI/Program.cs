using UI;
using Models;
using Serilog;

long.Logger = new LoggerConfiguration()
.WriteTo.File(@"..\StoreDL\logger.txt")
.CreateLogger();

MenuFactory.GetMenu("main").Start();
