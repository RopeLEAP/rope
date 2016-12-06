(function () {
    'use strict';

    angular
        .module('app', [])
        .controller('Main', Main);

    Main.$inject = ['$http']

    function Main($http) {
        var vm = this;
        vm.message = 'pizza';
        vm.getStringBuilder = GetStringBuilderFillTestResults;

        function getStringBuilder() {
            $http.get('/api/StringBuilderApi/GetStringBuilderFillTestResults').then(function (results) {
                vm.stringBuilderData = results.data;
            });
        };
    }

})();