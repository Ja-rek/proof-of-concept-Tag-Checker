// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(function(){
	$("#reset-tags").click(function () {
	$("#loading-tags").css("display", "block");
		$.ajax({
			url: "http://localhost:5000/tags/DownloadMostPopulateTags",
			type: "GET",
			context: document.body,
			statusCode: {
				429: function() {
  				$("loading-tags-warning");
				},
				200: function() {
					location.reload();
				} 
			} 
		});
	});
});

