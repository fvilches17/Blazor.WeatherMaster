using System.Reflection;

namespace WeatherMaster
{
    public class AssemblyHelper
    {
        private readonly string _assemblyVersion;

        public AssemblyHelper()
        {
            _assemblyVersion ??= typeof(Program).Assembly.GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description ?? "n/a";
        }

        public string GetAssemblyVersion() => _assemblyVersion;
    }
}