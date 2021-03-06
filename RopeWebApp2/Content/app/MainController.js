﻿(function () {
    'use strict';

    angular
        .module('app')
        .controller('Main', Main);

    Main.$inject = ['$http'];

    function Main($http) {
        var vm = this;

        vm.iterations = null;
        vm.showErrorMessage = false;
        vm.graphTitle = null;

        vm.getFillTestResults = getFillTestResults;
        vm.getPrependTestResults = getPrependTestResults;
        vm.getMidInsertTestResults = getMidInsertTestResults;
        vm.getAppendTestResults = getAppendTestResults;



        vm.clearChart = clearChart;

        vm.timeLabels = [];
        vm.timeSeries = [];
        vm.timeData = [];

        vm.memoryLabels = [];
        vm.memorySeries = [];
        vm.memoryData = [];

        function clearChart() {
            vm.timeLabels.length = 0;
            vm.timeSeries.length = 0;
            vm.timeData.length = 0;

            vm.memoryLabels.length = 0;
            vm.memorySeries.length = 0;
            vm.memoryData.length = 0;
        };

        // Append Tests
        function getAppendTestResults() {
            vm.graphTitle = "Append Test";
            clearChart();
            getBigListAppendTestResults();
            getRopeAppendTestResults();
            getStringBuilderAppendTestResults();
            makeChartLabels();
        };

        function getBigListAppendTestResults() {
            var url = '/api/BigListApi/getBigListAppendTestResults?iterations=';
            url += vm.iterations;
            $http.get(url).then(function (results) {
                vm.bigListAppendTestData = results.data;
                makeChartSeries(vm.bigListAppendTestData.title);
                makeChartData(vm.bigListAppendTestData.data);
                console.log("Big List Append", vm.bigListAppendTestData);
            });
        };

        function getRopeAppendTestResults() {
            var url = '/api/RopeApi/getRopeAppendTestResults?iterations=';
            url += vm.iterations;
            $http.get(url).then(function (results) {
                vm.ropeAppendTestData = results.data;
                makeChartSeries(vm.ropeAppendTestData.title);
                makeChartData(vm.ropeAppendTestData.data);
                console.log("Rope Append", vm.ropeAppendTestData);
            });
        };

        function getStringBuilderAppendTestResults() {
            var url = '/api/StringBuilderApi/getStringBuilderAppendTestResults?iterations=';
            url += vm.iterations;
            $http.get(url).then(function (results) {
                vm.stringBuilderAppendTestData = results.data;
                makeChartSeries(vm.stringBuilderAppendTestData.title);
                makeChartData(vm.stringBuilderAppendTestData.data);
                console.log("String Builder Append", vm.stringBuilderAppendTestData);
            });
        };

        // Fill Tests
        function getFillTestResults() {
            vm.graphTitle = "Fill Test";
            clearChart();
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
            vm.graphTitle = "Prepend Test";
            clearChart();
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

        // Mid Insert Tests
        function getMidInsertTestResults() {
            vm.graphTitle = "Mid Insert";
            clearChart();
            getBigListMidInsertTestResults();// Will cause a stack overflow infinite loop exception
            getRopeMidInsertTestResults();
            getStringBuilderMidInsertTestResults();
            makeChartLabels();
        };

        function getBigListMidInsertTestResults() {
            var url = '/api/BigListApi/GetBigListMidInsertTestResults?iterations=';
            url += vm.iterations;
            $http.get(url).then(function (results) {
                vm.bigListMidInsertTestData = results.data;
                makeChartSeries(vm.bigListMidInsertTestData.title);
                makeChartData(vm.bigListMidInsertTestData.data);
                console.log("Big List Mid Insert", vm.bigListMidInsertTestData);
            });
        };

        function getRopeMidInsertTestResults() {
            var url = '/api/RopeApi/GetRopeMidInsertTestResults?iterations=';
            url += vm.iterations;
            $http.get(url).then(function (results) {
                vm.ropeMidInsertTestData = results.data;
                makeChartSeries(vm.ropeMidInsertTestData.title);
                makeChartData(vm.ropeMidInsertTestData.data);
                console.log("Rope Mid Insert", vm.ropeMidInsertTestData);
            });
        };

        function getStringBuilderMidInsertTestResults() {
            var url = '/api/StringBuilderApi/GetStringBuilderMidInsertTestResults?iterations=';
            url += vm.iterations;
            $http.get(url).then(function (results) {
                vm.stringBuilderMidInsertTestData = results.data;
                makeChartSeries(vm.stringBuilderMidInsertTestData.title);
                makeChartData(vm.stringBuilderMidInsertTestData.data);
                console.log("String Builder Mid Insert", vm.stringBuilderMidInsertTestData);
            });
        };

        function makeChartLabels() {
            vm.timeLabels.length = 0;
            vm.memoryLabels.length = 0;
            for(var i = 0; i < vm.iterations; i++){
                vm.timeLabels[i] = i + 1;
                vm.memoryLabels[i] = i + 1;
            };

        };

        function makeChartSeries(title) {
            vm.timeSeries.push(title);
            vm.memorySeries.push(title);
        };

        function makeChartData(data) {
            var timeDataArray = [];
            var memoryDataArray = [];
            for (var i = 0; i < data.length; i++) {
                timeDataArray.push(data[i].time);
                memoryDataArray.push(data[i].memory);
            };
            vm.timeData.push(timeDataArray);
            vm.memoryData.push(memoryDataArray);
        };

    };


})();