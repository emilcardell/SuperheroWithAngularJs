var MyApp = angular.module('ProductAdmin', []).config(['$routeProvider', '$locationProvider',
    function ($routeProvider, $locationProvider) {

        $routeProvider.when('/', {
            templateUrl: '/Application/templates/ProductListing.html',
            controller: 'ListAllProductsController'
        }).
            when('/createProduct',
                {
                    templateUrl: '/Application/templates/CreateProduct.html',
                    controller: 'CreateProductController'
                });

    }]);

var CreateProductController = function ($scope, $http) {

    $scope.product = {};

    $scope.CreateProduct = function (product) {
        product.Id = Math.floor(Math.random() * 1000) + 1;
        listOfProducts.push(product);
        location.href = "#/";
        //$http.post('/Product', product).
        //    success(function (data) {
        //        alert('Your product was saved!');
        //    });
    };
};

var listOfProducts = [];

var ListAllProductsController = function ($scope, $http) {
    
 
    //$http.get('/AllProducts').
    //       success(function (data, status, headers, config) {
    //           $scope.ListOfProducts = data;
    //       });

    $scope.ListHeader = "List of cool products";
    $scope.ListOfProducts = listOfProducts;
    $scope.DeleteProduct = function (productId) {
        listOfProducts.remove(function (prodInList) {
            console.log(prodInList.Id + "===" + productId);
            return prodInList.Id === productId;
        });

        $scope.ListOfProducts = listOfProducts;
    };
    

};