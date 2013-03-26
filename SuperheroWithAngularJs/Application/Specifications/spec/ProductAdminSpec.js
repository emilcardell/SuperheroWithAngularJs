describe("given_a_ProductListController", function() {

    var fakeScope = {};
    var ctrl = ListAllProductsController(fakeScope);
    
    it("should contain two products", function () {
        expect(fakeScope.ListOfProducts.length).toBe(2);
    });

}); 