var productController = function () {
    this.initialize = function () {
        loadData();
        registerEvents();
    }

    function registerEvents() {
        $('#ddlShowPage').on('change', function () {
            bungbungconfig.configs.pageSize = $(this).val();
            bungbungconfig.configs.pageIndex = 1;
            loadData(true);
        })
    }

    function loadData(isPageChanged) {
        var template = $('#table-template').html();
        var render = "";
        $.ajax({
            type: 'GET',
            data: {
                categoryId: null,
                keyword: $('#txtSearchKeyword').val(),
                page: bungbungconfig.configs.pageIndex,
                pageSize: bungbungconfig.configs.pageSize
            },
            url: '/admin/product/getallpaging',
            dataType: 'json',
            success: function (response) {
                $.each(response.Results, function (i, item) {
                    render += Mustache.render(template, {
                        Id: item.Id,
                        Name: item.Name,
                        Image: item.Image == null ? '<img src="/admin-side/images/user.png" width=25' : '<img src="' + item.Image + '" width=25',
                        CategoryName: item.ProductCategory.Name,
                        Price: bungbungconfig.formatNumber(item.Price, 0),
                        CreatedDate: bungbungconfig.dateTimeFormatJson(item.DateCreated),
                        Status: bungbungconfig.getStatus(item.Status)
                    });
                    $('#lblTotalRecords').text(response.RowCount)
                    if (render != '') {
                        $('#tbl-content').html(render);
                    }
                    wrapPaging(response.RowCount, function () {
                        loadData();
                    },isPageChanged)
                });
            },
            error: function (status) {
                bungbungconfig.notify("Cannot loading data", "error");
            }
        });
    }

    function wrapPaging(recordCount, callBack, changePageSize) {
        var totalsize = Math.ceil(recordCount / bungbungconfig.configs.pageSize);
        //Unbind pagination if it existed or click change pagesize
        if ($('#paginationUL a').length === 0 || changePageSize === true) {
            $('#paginationUL').empty();
            $('#paginationUL').removeData("twbs-pagination");
            $('#paginationUL').unbind("page");
        }
        //Bind Pagination Event
        $('#paginationUL').twbsPagination({
            totalPages: totalsize,
            visiblePages: 7,
            first: 'First',
            prev: 'Previous',
            next: 'Next',
            last: 'Last',
            onPageClick: function (event, p) {
                bungbungconfig.configs.pageIndex = p;
                setTimeout(callBack(),200);
            }
        });
    }
}