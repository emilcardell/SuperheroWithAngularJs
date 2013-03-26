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

    $scope.CreateProduct = function(product) {
        $http.post('/Product', product).
            success(function (data, status, headers, config) {
                alert('Your product was saved!');
            });
    };
};


var ListAllProductsController = function ($scope, $http) {
    
    

    $http.get('/AllProducts').
           success(function (data, status, headers, config) {
               $scope.ListOfProducts = data;
           });

    $scope.ListHeader = "List of cool products";

    $scope.DeleteProduct = function(product) {
        $http.delete('/product/' + product.Id).
        success(function (data, status, headers, config) {

            
        });
    };
    

};