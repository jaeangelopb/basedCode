
$.each(response, function(i, item) {
    $('<tr class="contnt">').html(


        "<td><center><input type=\"checkbox\" id=\"basic_checkbox_" + i + "\" class=\"filled-in\" /><label for=\"basic_checkbox_" + i + "\"></label></center></td><td>" + response[i].EmployeeNo + "</td><td>" + response[i].FirstName + "</td><td>" + response[i].MiddleName + "</td><td>" + response[i].LastName + "</td><td>" + response[i].LogType + "</td><td>" + response[i].TimeInOut + "</td><td style=\"width:30%;\">" + response[i].Task + "</td>").appendTo('#records_table');
});

