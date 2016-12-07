(function () {
    'use strict';

    angular
        .module('app', [])
        .controller('Main', Main);

    Main.$inject = ['$http']


    function Main($http) {
        var vm = this;
        vm.iterations = null;
        vm.message = 'pizza';
        vm.getFillTestResults = getFillTestResults;

        // Fill Tests
        function getFillTestResults() {
            getBigListFillTestResults();
            getRopeFillTestResults();
            getStringBuilderFillTestResults();
        };
        function getBigListFillTestResults() {
            var url = '/api/StringBuilderApi/GetBigListFillTestResults?iterations=';
            url += vm.iterations;
            $http.get(url).then(function (results) {
                vm.bigListFillTestData = results.data;
                vm.stringBuilderFillTestData = results.data;
            });
        };
        function getRopeFillTestResults() {
            var url = '/api/StringBuilderApi/GetRopeFillTestResults?iterations=';
            url += vm.iterations;
            $http.get(url).then(function (results) {
                vm.bigListFillTestData = results.data;
                vm.stringBuilderFillTestData = results.data;
            });
        };
        function getStringBuilderFillTestResults() {
            var url = '/api/StringBuilderApi/GetStringBuilderFillTestResults?iterations=';
            url += vm.iterations;
            $http.get(url).then(function (results) {
                vm.bigListFillTestData = results.data;
                vm.stringBuilderFillTestData = results.data;
            });
        };
    };
})();