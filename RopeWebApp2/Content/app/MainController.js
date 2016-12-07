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
        vm.clearChart = clearChart;

        vm.labels = [];
        vm.series = [];
        vm.data = [];

        function clearChart() {
            vm.labels.length = 0;
            vm.series.length = 0;
            vm.data.length = 0;
        };

        // Fill Tests
        function getFillTestResults() {
            getBigListFillTestResults();
            getRopeFillTestResults();
            getStringBuilderFillTestResults();
            makeChartLabels();
        };

        function getBigListFillTestResults() {
            var url = '/api/BigListApi/GetBigListFillTestResults?iterations=';
            url += vm.iterations;
            $http.get(url).then(function (results) {
                vm.bigListFillTestData = results.data;
                makeChartSeries(vm.bigListFillTestData.title);
                makeChartData(vm.bigListFillTestData.data);
                console.log("Big List Fill", vm.bigListFillTestData);
            });
        };

        function getRopeFillTestResults() {
            var url = '/api/RopeApi/GetRopeFillTestResults?iterations=';
            url += vm.iterations;
            $http.get(url).then(function (results) {
                vm.ropeFillTestData = results.data;
                makeChartSeries(vm.ropeFillTestData.title);
                makeChartData(vm.ropeFillTestData.data);
                console.log("Rope Fill:", vm.ropeFillTestData);
            });
        };

        function getStringBuilderFillTestResults() {
            var url = '/api/StringBuilderApi/GetStringBuilderFillTestResults?iterations=';
            url += vm.iterations;
            $http.get(url).then(function (results) {
                vm.stringBuilderFillTestData = results.data;
                makeChartSeries(vm.stringBuilderFillTestData.title);
                makeChartData(vm.stringBuilderFillTestData.data);
                console.log("String Builder Fill", vm.stringBuilderFillTestData);
            });
        };

        function makeChartLabels() {
            vm.labels.length = 0;
            for(var i = 0; i < vm.iterations; i++){
                vm.labels[i] = i + 1; 
            };

        };

        function makeChartSeries(title) {
            vm.series.push(title);
        };

        function makeChartData(data) {
            var dataArray = [];
            for (var i = 0; i < data.length; i++) {
                dataArray.push(data[i].time);
            };
            vm.data.push(dataArray);
        };

    };


})();