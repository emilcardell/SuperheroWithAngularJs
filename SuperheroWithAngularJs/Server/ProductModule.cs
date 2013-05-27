using System;
using System.Linq;
using Nancy;
using Nancy.ModelBinding;
using Raven.Client;

namespace SuperheroWithAngularJs.Server
{
    public class ProductModule : NancyModule     
    {
        public ProductModule(IDocumentSession documentSession)
        {
            Get["/AllProducts"] = _ =>
            {
                var allProducts  = documentSession.Query<ProductModel>().Take(100).ToList();
                return Response.AsJson(allProducts);
            };


            Delete["/Product/{Id}"] = _ =>
            {
                string id = _.Id;
                var productToDelete = documentSession.Load<ProductModel>(id);
                documentSession.Delete(productToDelete);

                return HttpStatusCode.OK;
            };

            Post["/Product/"] = _ =>
            {
                var newProduct = this.Bind<ProductModel>();
                newProduct.Id = Guid.NewGuid().ToString();

                documentSession.Store(newProduct);

                return HttpStatusCode.OK;
            };

            //Get["/Product/{Id}"] = _ =>
            //{
            //    var product = documentSession.Load<ProductModel>(_.Id);
            //    if (product == null)
            //        return HttpStatusCode.NotFound;

            //    return Response.AsJson(product);
            //};
        }
    }
}