$(document).ready(function() {
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
				500: function() {
  				$("loading-tags-danger");
				},
				200: function() {
					location.reload();
				} 
			} 
		});
	});
});
