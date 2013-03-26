using Nancy;

namespace SuperheroWithAngularJs.Server
{
    public class StaticRoutingModule : NancyModule
    {
        public StaticRoutingModule()
        {
            Get["/"] = _ => View["Application/application.html"];
            Get["/specs"] = _ => View["Application/Specifications/SpecRunner.html"];
        }
    }
}