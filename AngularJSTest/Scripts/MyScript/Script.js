/// <reference path="../angular-route.js" />


var app = angular.module("myModule", ["ngRoute"])
    .controller("myController", function ($scope, $route, $http, $log) {

        $scope.partialView1 = 'Views/Partial/AddRestaurantForm.html';
        $scope.partialView2 = 'Views/Partial/AllRestaurantsView.html';

        $scope.partialView = $scope.partialView2;

        $scope.ShowTable = function () {
            $scope.partialView = $scope.partialView2;
        }

        $scope.ShowForm = function () {
            $scope.partialView = $scope.partialView1;
        }

        $scope.Refresh = function () {
            $http({
                method: 'POST',
                url: 'http://localhost:53399/api/restaurant/GetAll',
                data: { includes: ["Location", "Action"] }
            }).then(function (response) {
                $scope.restaurants = response.data;
            });
        }

        var successCallBack = function (response) {
            $scope.Refresh();
            $scope.restaurants = response.data;
        }

        var errorCallBack = function (response) {
            $scope.error = response.data;
        }

        $scope.Delete = function (Guid) {            
            $http({
                method: 'POST',
                url: 'http://localhost:53399/api/restaurant/Delete',
                data: '\"' + Guid + '\"'
            });

            var index = -1;
            var comArr = eval($scope.restaurants);
            for (var i = 0; i < comArr.length; i++) {
                if (comArr[i].id === Guid) {
                    index = i;
                    break;
                }
            }
            if (index === -1) {
                alert("Something gone wrong");
            }
            $scope.restaurants.splice(index, 1);
        };

        $scope.addRow = function () {

            $http({
                method: 'POST',
                url: 'http://localhost:53399/api/AddRestaurant',
                data: {
                    Name: "Sushiya20",
                    Status: "Open",
                    Location: {
                        Address: "Prospekt pobedy 154a"
                    },
                    Menu: {
                        Time: "2017-09-08T16:08:19.290Z",
                        FoodMenus: [{
                            Name: "Yami yami",
                            Price: "284.369",
                            Description: "Some description"
                        }]
                    },
                    Action: [{
                        Description: "Buy 1 get 2",
                        Time: "2017-09-08T16:08:19.290Z"
                    }]
                }
            }) 
            $log.info($scope.restaurants);
            $log.info(this.idF);
            $log.info(this.nameF);
            $log.info(this.statusF);
            
            $scope.restaurants.push({ 'id': this.idF, 'name': this.nameF, 'status': this.statusF});
            $scope.idF = '';
            $scope.nameF = '';
            $scope.statusF = '';        

            $scope.ShowTable();
        };

        $http({
            method: 'POST',
            url: 'http://localhost:53399/api/restaurant/GetAll',
            data: { includes: ["Location", "Action"] }
        }).then(successCallBack, errorCallBack) 
        
    }); 