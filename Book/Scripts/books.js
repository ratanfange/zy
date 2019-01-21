function GetBookList() {
    $.ajax({
        type: 'POST',
        url: '/api/BooksAPi/GetBookList',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: null
    }).done(function (result) {
        var jsonObject = JSON.parse(result);
        var htmlContent = "";
        if (jsonObject !== null && jsonObject.length > 0) {
            for (var i = 0; i < jsonObject.length; i++) {
                 htmlContent +=
                    "<tr>"
                    + "<td>"
                    + jsonObject[i].BookName
                    + "</td>"
                    + "<td>"
                    + jsonObject[i].BookType
                    + "</td>"
                    + " <td>"
                    + jsonObject[i].BookPrice
                    + "</td>"
                    + "<td>"
                    + jsonObject[i].Created
                    + "</td>"
                    + " <td>"
                    + "<a href = 'books/Edit?id='" + jsonObject[i].ID + ">編集します</a> |"
                    + "<a href = 'books/Details?id='" + jsonObject[i].ID + ">見ます</a> |"
                    + "<a href = 'books/Delete?id='" + jsonObject[i].ID + ">消えろ</a> |"
                    + "</td>"
                    + "</tr>";

            }
            $("#table").append(htmlContent);
        }
            //alert("BooksAPi sucess");
        }).fail(function (res) {
            alert("BooksAPi fail.");
        });
}