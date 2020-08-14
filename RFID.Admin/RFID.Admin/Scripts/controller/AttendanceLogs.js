(function () {

    var AttendanceController = function ($q, $rootScope, $scope, $mdDateRangePicker, commonRequest) {

        var PAGE_SIZE = 8; 
        var PAGE_START = 1; 
        var controller = "AttendanceLogs"
        var loadingStatus = false;

        var onError = function (response) {
            swal(response, "", "error");
            console.log(response)
        }

        var Search = function (table) {
            table.PageIndex = PAGE_START;
            table.data = [];
            List(table);
        };

        var PageIndexChange = function (table, increment) {
            if (increment < 0 && table.PageIndex === 1) return;

            if (increment > 0 && (table.PageIndex + 1) > table.totalPage) return;

            table.PageIndex += increment;
            List(table);
        };

     
        var List = function (table) {

            var action = "List"

            table.loading = true;
            var onSuccessful = function (response) {
                table.data = response.data
                table.total = response.total;
                table.totalPage = Math.ceil(table.total / table.PageSize)
                table.loading = false;
                if ($scope.checkAll) {
                    var list = table.data.map(a => a.EmployeeID)
                    $scope.checklistary.push(list)
                }
            }

            var param = $.param({
                "search": table.Search,
                "pageindex": table.PageIndex,
                "pagesize": table.PageSize
            })


            if (table.name === "employee") {
                action = "EmployeeList"
                param += "&CompanyID=" + table.CompanyID
            }

            if (table.name === "attendance") {
                param += "&EmployeeID=" + table.EmployeeID
                if ($scope.dateRange.dateStart)
                    param += "&StartDate=" + moment($scope.dateRange.dateStart).format("YYYY-MM-DD")
                if ($scope.dateRange.dateEnd)
                    param += "&EndDate=" + moment($scope.dateRange.dateEnd).format("YYYY-MM-DD")
            }

            commonRequest.GetData(controller, action, param)
                .then(onSuccessful, onError)

        }


        var GetCompany = function () {
            var onSuccessful = function (response) {
                $scope.companylist = response.data;
                var hasAll = ($scope.companylist.filter(c => c.CompanyID === "-").length > 0);
                if (!hasAll) {
                    $scope.employee.CompanyID = $scope.companylist[0].CompanyID;
                }

            }

            var param = $.param({
                "Search": '',
                "PageIndex": 1,
                "PageSize" : 100000
            })
            commonRequest.Post("Company", "List", param)
                       .then(onSuccessful, onError)

        }

      
        $scope.ToView = function (data) {
            $scope.mode = "view";
            $scope.Employee = angular.copy(data)
            $scope.attendance.EmployeeID = data.EmployeeID
            $scope.attendance.loading = false;
            List($scope.attendance)
        }

        $scope.ToCancel = function (table) {
         
            $scope.mode = "list";
            List(table)
        }


        $scope.selectDateRange = function () {
            $mdDateRangePicker.show({
                model: $scope.dateRange,
            }).then(function (result) {
                $scope.dateRange = result;
                console.log(result)
                List($scope.attendance)
            }).catch(function () {
                $scope.dateRange = {}; 
                List($scope.attendance)
            })
        }

        $scope.resetDateRange = function () {
            $scope.dateRange = {};
            List($scope.attendance)
        }

        $scope.viewImage = function (data) {
            $scope.AttendanceLog = angular.copy(data)
        }
    
        
        $scope.checkchanged = function (e) {
            var chk = []
            for (x in $scope.checklist) {
                if (typeof $scope.checklist[x] !== 'undefined') {
                    var param = new Object()
                    chk.push($scope.checklist[x])
                }
            }
            $scope.checklistary = chk

        }

       


        var Init = function () {
            
            $scope.mode = "list";
            $scope.attendance = [];
            $scope.attendance.data = [];
            $scope.attendance.Search = "";
            $scope.attendance.EmployeeID = "-"; 
            $scope.attendance.PageIndex = 1;
            $scope.attendance.PageSize = PAGE_SIZE
            $scope.attendance.total = 0;
            $scope.attendance.totalPage = 0;
            $scope.attendance.loading = false;
            $scope.attendance.name = "attendance";


            $scope.employee = [];
            $scope.employee.data = [];
            $scope.employee.Search = "";
            $scope.employee.CompanyID = "-";
            $scope.employee.PageIndex = 1;
            $scope.employee.PageSize = PAGE_SIZE
            $scope.employee.total = 0;
            $scope.employee.totalPage = 0;
            $scope.employee.loading = false;
            $scope.employee.name = "employee";

            $scope.companylist = []

            $scope.Employee = [];
            $scope.AttendanceLog = [];
           
            $scope.checklist = [];
            $scope.checklistary = [];
            $scope.checkAll = false;


            $scope.checkindex = 0;

            $scope.processing = [];
            $scope.processing.enable = false;
            $scope.processing.label = "";

            $scope.dateRange = {};


            GetCompany();
            List($scope.employee);
        }


        $scope.onError = onError;
        $scope.List = List;
        $scope.PageIndexChange = PageIndexChange;
        $scope.Search = Search;
        $scope.Init = Init;




        (function () {
            Init();
        }());
    }

    angular.module("mainApp")
        .controller("AttendanceController", ['$q', '$rootScope', '$scope', '$mdDateRangePicker', 'commonRequest', AttendanceController]);

}());