using System.Collections.Generic;
using Machine.Specifications;
using Nancy;
using Nancy.Testing;
using SuperheroWithAngularJs.Server;

namespace SuperheroWithAngularJs.Specification
{
    public class given_all_products_are_reqested_and_there_is_two_products
    {
        private static HttpStatusCode BaseRouteStatusCode;
        private static int NumberOfProductsInList = 0;

        Establish context = () =>
        {
            var bootstrapper = new SpecificationBootstrapper();
            var browser = new Browser(bootstrapper);

            var newProduct = new ProductModel() {Name = "Super Product", Description = "Super duper Product"};

            browser.Post("/product", c => c.JsonBody(newProduct));

            var response = browser.Get("/products");

            var products = response.Body.DeserializeJson<List<ProductModel>>();
            NumberOfProductsInList = products.Count;

        };

        private It should_give_us_two_products = () => NumberOfProductsInList.ShouldEqual(1);
    }
}
