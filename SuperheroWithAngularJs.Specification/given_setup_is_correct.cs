using Machine.Specifications;
using Nancy;
using Nancy.Testing;

namespace SuperheroWithAngularJs.Specification
{
    public class given_setup_is_correct_and_base_route_is_visited
    {
        private static HttpStatusCode BaseRouteStatusCode;

        Establish context = () =>
        {
            var bootstrapper = new SpecificationBootstrapper();
            var browser = new Browser(bootstrapper);

            var response = browser.Get("/");

            BaseRouteStatusCode = response.StatusCode;

        };

        private It should_give_us_status_code_ok = () => BaseRouteStatusCode.ShouldEqual(HttpStatusCode.OK);
    }
}
