var categoryPageApp = angular.module('categoryPageApp', []);

		categoryPageApp.controller('categoryController', function($scope) {
			$scope.products = data;
			const queryString = window.location.search;
			const urlParams = new URLSearchParams(queryString);
			$scope.type = urlParams.get('type');
			$scope.id = urlParams.get('id');

		});