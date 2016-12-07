(function () {
    'use strict';

    angular
        .module('app')
        .controller('Main', Main);

    Main.$inject = ['$http'];

    function Main($http) {
        var vm = this;
        vm.iterations = null;
        vm.getFillTestResults = getFillTestResults;
        //vm.getStringBuilderTestResults = getStringBuilderTestResults;

        vm.labels = ["January", "February", "March", "April", "May", "June", "July"];
        vm.series = ['Series A', 'Series B'];
        vm.data = [
          [65, 59, 80, 81, 56, 55, 40],
          [28, 48, 40, 19, 86, 27, 90]
        ];

        // Fill Tests
        function getFillTestResults() {
            getBigListFillTestResults();
            getRopeFillTestResults();
            getStringBuilderFillTestResults();
        };

        function getBigListFillTestResults() {
            var url = '/api/BigListApi/GetBigListFillTestResults?iterations=';
            url += vm.iterations;
            $http.get(url).then(function (results) {
                vm.bigListFillTestData = results.data;
            });
        };

        function getRopeFillTestResults() {
            var url = '/api/RopeApi/GetRopeFillTestResults?iterations=';
            url += vm.iterations;
            $http.get(url).then(function (results) {
                vm.ropeFillTestData = results.data;
            });
        };

        function getStringBuilderFillTestResults() {
            var url = '/api/StringBuilderApi/GetStringBuilderFillTestResults?iterations=';
            url += vm.iterations;
            $http.get(url).then(function (results) {
                vm.stringBuilderFillTestData = results.data;
            });
        };

    };


})();