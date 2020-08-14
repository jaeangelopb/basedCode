
table = $('#records_table').DataTable({
    paging: false,
    info: false
});

// Extend dataTables search
$.fn.dataTable.ext.search.push(
  function (settings, data, dataIndex) {
      var min = $('#min-date').val();
      var max = $('#max-date').val();
      var createdAt = data[2] || 0; // Our date column in the table

      if (
        (min === "" || max === "") ||
        (moment(createdAt).isSameOrAfter(min) && moment(createdAt).isSameOrBefore(max))
      ) {
          return true;
      }
      return false;
  }
);

// Re-draw the table when the a date range filter changes
$('.date-range-filter').change(function () {
    table.draw();
});

$('#my-table_filter').hide();