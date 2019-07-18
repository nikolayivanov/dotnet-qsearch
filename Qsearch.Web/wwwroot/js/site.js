// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function postQuestionsViaAjax() {

    $.ajax({
        type: 'GET',
        url: SearchApiUrl + '/api/v1/qsearch/search',
        contentType: "application/json",
        data: { "query": $('#query').val() },
        success: function (data) {            
            var items = [];
            $.each(data, function (indx, quest) {
                items.push('<a href="' + quest.link + '">' + quest.title + '</a><br>');
            });

            $('#div-questions').html(items.join(' '));
        }
    });
}

//Binds to the global ajax scope
$(document).ajaxStart(function () {
    $("#spinner").show();
});

$(document).ajaxComplete(function () {
    $("#spinner").hide();
});