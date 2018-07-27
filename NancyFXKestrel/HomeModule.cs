using System;
using Nancy;

namespace NancyFXKestrel
{
    public class HomeModule : NancyModule
    {
        public HomeModule(IAppConfiguration appConfig)
        {
            Get("/", args => "Hello from Nancy running on CoreCLR. Testing an edit..");
        }
    }
}
