(function () {
    'use strict';

    angular
        .module('app', [])
        .controller('Main', Main);

    Main.$inject = ['$http']

    // Stringbuilder Tests
    function Main($http) {
        var vm = this;
        vm.iterations = null;
        vm.message = 'pizza';
        vm.getStringBuilderTestResults = getStringBuilderTestResults;
        
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
    }

})();