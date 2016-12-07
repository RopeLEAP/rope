﻿(function () {
    'use strict';

    angular
        .module('app')
        .controller('Main', Main);

    Main.$inject = ['$http'];

    function Main($http) {
        var vm = this;

        vm.iterations = null;
        vm.getFillTestResults = getFillTestResults;
        vm.getPrependTestResults = getPrependTestResults;
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

        // Prepend Tests
        function getPrependTestResults() {
            getBigListPrependTestResults();
            getRopePrependTestResults();
            getStringBuilderPrependTestResults();
            makeChartLabels();
        };

        function getBigListPrependTestResults() {
            var url = '/api/BigListApi/GetBigListPrependTestResults?iterations=';
            url += vm.iterations;
            $http.get(url).then(function (results) {
                vm.bigListPrependTestData = results.data;
                makeChartSeries(vm.bigListPrependTestData.title);
                makeChartData(vm.bigListPrependTestData.data);
                console.log("Big List Pre-pend", vm.bigListPrependTestData);
            });
        };

        function getRopePrependTestResults() {
            var url = '/api/RopeApi/GetRopePrependTestResults?iterations=';
            url += vm.iterations;
            $http.get(url).then(function (results) {
                vm.ropePrependTestData = results.data;
                makeChartSeries(vm.ropePrependTestData.title);
                makeChartData(vm.ropePrependTestData.data);
                console.log("Rope Pre-pend", vm.ropePrependTestData);
            });
        };

        function getStringBuilderPrependTestResults() {
            var url = '/api/StringBuilderApi/GetStringBuilderPrependTestResults?iterations=';
            url += vm.iterations;
            $http.get(url).then(function (results) {
                vm.stringBuilderPrependTestData = results.data;
                makeChartSeries(vm.stringBuilderPrependTestData.title);
                makeChartData(vm.stringBuilderPrependTestData.data);
                console.log("String Builder Pre-pend", vm.stringBuilderPrependTestData);
            });
        };

        // MidInsert Tests
        function getMidInsertTestResults() {
            getBigListMidInsertTestResults();
            getRopeFillMidInsertResults();
            getStringBuilderMidInsertTestResults();
        };

        function getBigListMidInsertTestResults() {
            var url = '/api/BigListApi/GetBigListMidInsertTestResults?iterations=';
            url += vm.iterations;
            $http.get(url).then(function (results) {
                vm.bigListMidInsertTestData = results.data;
            });
        };

        function getRopeMidInsertTestResults() {
            var url = '/api/RopeApi/GetRopeMidInsertTestResults?iterations=';
            url += vm.iterations;
            $http.get(url).then(function (results) {
                vm.ropeMidInsertTestData = results.data;
            });
        };

        function getStringBuilderMidInsertTestResults() {
            var url = '/api/StringBuilderApi/GetStringBuilderMidInsertTestResults?iterations=';
            url += vm.iterations;
            $http.get(url).then(function (results) {
                vm.stringBuilderMidInsertTestData = results.data;
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