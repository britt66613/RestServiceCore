/// <reference path="../angular.js" />

var app = angular.module("myModule", [])
    .controller("myController", function ($scope, $http) {
        $http.post('http://localhost:53399/api/restaurant/GetAll?includes=Location&includes=Action')
            .then(function (response){
                $scope.restaurants = response.data;
        });               
    }); 