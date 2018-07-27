using System;
using Nancy;

namespace NancyFXKestrel
{
    public class HomeModule : NancyModule
    {
        public HomeModule(IAppConfiguration appConfig)
        {
            Get("/", args => "Hello World Again 9");
        }
    }
}
