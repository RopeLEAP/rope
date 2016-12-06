(function () {
    'use strict';

    angular
        .module('app', [])
        .controller('Main', Main);

    Main.$inject = ['$http']

    function Main($http) {
        var vm = this;
        vm.message = 'pizza';
        vm.getStringBuilderFillTestResults = getStringBuilderFillTestResults;
        vm.iterations = null;

        function getStringBuilderFillTestResults() {
            var url = '/api/StringBuilderApi/GetStringBuilderFillTestResults?iterations=';
            url += vm.iterations;

            $http.get(url).then(function (results) {
                vm.stringBuilderFillTestData = results.data;
            });
        };
    }

})();