(function () {
    'use strict';

    angular
        .module('app')
        .controller('Main', Main);

    Main.$inject = ['$http']

    function Main($http) {
        var vm = this;
        vm.iterations = null;
        vm.getStringBuilderTestResults = getStringBuilderTestResults;

        vm.labels = ["January", "February", "March", "April", "May", "June", "July"];
        vm.series = ['Series A', 'Series B'];
        vm.data = [
          [65, 59, 80, 81, 56, 55, 40],
          [28, 48, 40, 19, 86, 27, 90]
        ];

        function getStringBuilderTestResults() {
            var url = '/api/StringBuilderApi/GetStringBuilderFillTestResults?iterations=';
            url += vm.iterations;
            $http.get(url).then(function (results) {
                vm.stringBuilderFillTestData = results.data;
            });

            var url = '/api/StringBuilderApi/GetStringBuilderPrependTestResults?iterations=';
            url += vm.iterations;
            $http.get(url).then(function (results) {
                vm.stringBuilderPrependTestData = results.data;
            });

            var url = '/api/StringBuilderApi/GetStringBuilderMidInsertTestResults?iterations=';
            url += vm.iterations;
            $http.get(url).then(function (results) {
                vm.stringBuilderMidInsertTestData = results.data;
            });
        };

    };


})();