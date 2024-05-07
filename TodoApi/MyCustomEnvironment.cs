using Microsoft.Extensions.FileProviders;

namespace TodoApi
{
    public class MyCustomEnvironment : IWebHostEnvironment
    {
        public string EnvironmentName { get; set; }
        public string ApplicationName { get; set; }
        public string WebRootPath { get; set; }
        public IFileProvider WebRootFileProvider { get; set; }
        public IFileProvider ContentRootFileProvider { get; set; }
        public string ContentRootPath { get; set; }

        public void SetEnvironmentName(string envName)
        {
            EnvironmentName = envName;
        }
    }
}
