const uri = 'api/';

function getAllSeriesIdAndViews() {
    $.ajax({
        type: 'GET',
        url: uri + "getAllSeriesIdAndViews",
        success: function (data) {
            console.log(data);
        }
        // todo error handling
    });
}