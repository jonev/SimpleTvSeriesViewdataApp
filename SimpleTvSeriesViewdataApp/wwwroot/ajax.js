const uri = 'api/';

function getAllSeriesIdAndViews(onSuccess, onError) {
    $.ajax({
        type: 'GET',
        url: uri + "getAllSeriesIdAndViews",
        success: function (data) {
            onSuccess(data);
        },
        error: function (err) {
            onError(err);
        }
    });
}

function getAllSeriesIdAndViewsSortedOnDate(onSuccess, onError) {
    $.ajax({
        type: 'GET',
        url: uri + "getAllSeriesIdAndViewsSortedOnDate",
        success: function (data) {
            onSuccess(data);
        },
        error: function (err) {
            onError(err);
        }
    });
}

function getAllSeriesIdViewdOnTv(onSuccess, onError) {
    $.ajax({
        type: 'GET',
        url: uri + "getAllSeriesIdViewdOnTv",
        success: function (data) {
            onSuccess(data);
        },
        error: function (err) {
            onError(err);
        }
    });
}

function getTheMostPopularInYear2018(onSuccess, onError) {
    $.ajax({
        type: 'GET',
        url: uri + "getTheMostPopularInYear2018",
        success: function (data) {
            onSuccess(data);
        },
        error: function (err) {
            onError(err);
        }
    });
}

function getAllData(seriesId, date, onSuccess, onError) {
    $.ajax({
        type: 'GET',
        url: uri + "getAllData/" + seriesId + "/" + date,
        success: function (data) {
            onSuccess(data);
        },
        error: function (err) {
            onError(err);
        }
    });
}