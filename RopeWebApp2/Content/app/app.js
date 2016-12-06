﻿(function () {
    'use strict';

    angular
        .module('app', [])
        .controller('Main', Main);

    Main.$inject = ['$http']

    function Main($http) {
        var vm = this;
        vm.message = 'pizza';
        vm.getStringBuilder = getStringBuilder;

        function getStringBuilder() {
            $http.get('/api/RopeApi').then(function (results) {
                vm.stringBuilderData = results.data;
            });
        };
    }

})();