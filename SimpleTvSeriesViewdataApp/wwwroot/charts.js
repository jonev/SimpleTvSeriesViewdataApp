// source http://www.chartjs.org/docs/latest/getting-started/?q=
function getChartAllSeriesIdAndViews() {
    var ctx = $("#chartAllSeriesIdAndViews");
    getAllSeriesIdAndViews((data) => {
        var arrLabels = [];
        var arrViews = [];
        for (var i = 0; i < data.length; i++) { // todo a better  way must exist
            arrLabels.push(data[i].seriesId);
            arrViews.push(data[i].views);
        }
        var chart = new Chart(ctx, {
            // The type of chart we want to create
            type: 'line',
            // The data for our dataset
            data: {
                labels: arrLabels,
                datasets: [{
                    label: "All time views",
                    backgroundColor: 'rgb(255, 99, 132)',
                    borderColor: 'rgb(255, 99, 132)',
                    data: arrViews,
                }]
            },
            // Configuration options go here
            options: {}
        });
    }, (err) => {
        console.log(err);
        // todo errorhandling
    });
}

function getChartAllSeriesIdAndViewsSortedOnDate() {
    var ctx = $("#chartAllSeriesIdAndViewsSortedOnDate");
    getAllSeriesIdAndViewsSortedOnDate((data) => {
        var arrLabels = [];
        var arrViews = [];
        for (var i = 0; i < data.length; i++) { // todo a better  way must exist
            arrLabels.push(data[i].seriesId + " " + data[i].date);
            arrViews.push(data[i].views);
        }
        var chart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: arrLabels,
                datasets: [{
                    label: "All time views grouped on date",
                    backgroundColor: 'rgb(255, 99, 132)',
                    borderColor: 'rgb(255, 99, 132)',
                    data: arrViews,
                }]
            },
            options: {}
        });
    }, (err) => {
        console.log(err);
        // todo errorhandling
    });
}

function getChartAllSeriesIdViewdOnTv() {
    var ctx = $("#chartAllSeriesIdViewdOnTv");
    getAllSeriesIdViewdOnTv((data) => {
        var arrLabels = [];
        var arrViews = [];
        for (var i = 0; i < data.length; i++) { // todo a better  way must exist
            arrLabels.push(data[i].seriesId + " " + data[i].date);
            arrViews.push(data[i].views);
        }
        var chart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: arrLabels,
                datasets: [{
                    label: "All time views on TV",
                    backgroundColor: 'rgb(255, 99, 132)',
                    borderColor: 'rgb(255, 99, 132)',
                    data: arrViews,
                }]
            },
            options: {}
        });
    }, (err) => {
        console.log(err);
        // todo errorhandling
    });
}

function getChartTheMostPopularInYear2018() { // todo chart with screen as labels
    var ctx = $("#chartTheMostPopularInYear2018");
    getTheMostPopularInYear2018((data) => {
        var arrLabels = [];
        var arrViews = [];
        for (var i = 0; i < data.length; i++) { // todo a better  way must exist
            arrLabels.push(data[i].screen);
            arrViews.push(data[i].views);
        }
        var chart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: arrLabels,
                datasets: [{
                    label: "The most popular in 2018: " + data[0].seriesId,
                    backgroundColor: 'rgb(255, 99, 132)',
                    borderColor: 'rgb(255, 99, 132)',
                    data: arrViews
                }]
            },
            options: {}
        });
    }, (err) => {
        // todo errorhandling
        console.log(err);
    });
}

function getChartAllDataOnOneSeriesIdAtDate(seriesId, date) { // todo chart with screen as labels
    var ctx = $("#chartAllDataOnOneSeriesIdAtDate");
    getAllDataOnOneSeriesIdAtDate(seriesId, date, (data) => {
        var arrLabels = [];
        var arrViews = [];
        for (var i = 0; i < data.length; i++) { // todo a better  way must exist
            arrLabels.push(data[i].screen);
            arrViews.push(data[i].views);
        }
        var chart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: arrLabels,
                datasets: [{
                    label: seriesId + " at " + date,
                    backgroundColor: 'rgb(255, 99, 132)',
                    borderColor: 'rgb(255, 99, 132)',
                    data: arrViews
                }]
            },
            options: {}
        });
    }, (err) => {
        // todo errorhandling
        console.log(err);
    });
}