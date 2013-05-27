using Nancy;

namespace SuperheroWithAngularJs.Server
{
    public class StaticRoutingModule : NancyModule
    {
        public StaticRoutingModule()
        {
            Get["/"] = _ => View["Client/application.html"];
            Get["/specs"] = _ => View["Client/Specifications/SpecRunner.html"];
        }
    }
}