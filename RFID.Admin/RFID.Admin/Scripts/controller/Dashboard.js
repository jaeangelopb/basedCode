(function () {

    var DashboardController = function ($q, $rootScope, $scope, $mdDateRangePicker, commonRequest) {

 
        var controller = "Dashboard"
        var PAGE_SIZE = 12; //-- size of the page
        //--  var ACCOUNT_ID; size of the page
        var PAGE_START = 1; //-- base 1
        var onError = function (response) {
            swal(response, "", "error");
            console.log(response)
        }
        var Search = function () {
            $scope.list.PageIndex = PAGE_START;

            $scope.list.data = [];
            List();
        };
        var List = function () {
             

            $scope.loading = true;
            var onSuccessful = function (response) {
                
                $scope.summary = response.SummaryTotal;
                $scope.data = response.data;
                $scope.attendance = response.RecentLogs;

 
                $scope.loading = false;
              
            }

            var param = $.param({
                "Search": $scope.filter.Search,
                "AccountID": $scope.filter.AccountID,
                "startdate": ($scope.dateRange.dateStart) ? moment($scope.dateRange.dateStart).format("YYYY-MM-DD") : "",
                "enddate": ($scope.dateRange.dateEnd) ? moment($scope.dateRange.dateEnd).format("YYYY-MM-DD") : "",
                "PageIndex": $scope.filter.PageIndex,
                "PageSize": $scope.filter.PageSize
            })


           
            commonRequest.GetData(controller, "GetAllStudentLogs", param)
                .then(onSuccessful, onError);

        }

        /*
        var GetCompany = function () {
            var onSuccessful = function (response) {
                $scope.companylist = response.data;
                var hasAll = ($scope.companylist.filter(c => c.CompanyID === "-").length > 0);
                if (!hasAll) {
                    $scope.filter.CompanyID = $scope.companylist[0].CompanyID;
                }
               

            }

            var param = $.param({
                "Search": '',
                "PageIndex": 1,
                "PageSize": 100000
            });
            commonRequest.Post("Dashboard", "GetAllStudentLogs", param)
                       .then(onSuccessful, onError)

        }*/



        $scope.selectDateRange = function () {
            $mdDateRangePicker.show({
                model: $scope.dateRange,
            }).then(function (result) {
                $scope.dateRange = result;
                console.log(result)
                List()
            }).catch(function () {
                $scope.dateRange = {}; 
                List()
            })
        }

        $scope.resetDateRange = function () {
            $scope.dateRange = {};
            List($scope.attendance)
        }

      

       


        var Init = function () {
            
            $scope.loading = false;
            $scope.data = [];

            $scope.filter = [],
            $scope.filter.Search = "-";
            $scope.filter.StartDate = "";
            $scope.filter.EndDate = "";
            $scope.filter.PageIndex = 1;
            $scope.filter.PageSize = PAGE_SIZE
            $scope.companylist = []

            $scope.dateRange = {};


            List();
        //    GetCompany();
        }


        $scope.onError = onError;
        $scope.List = List;
        $scope.Init = Init;




        (function () {
            Init();
        }());
    }

    angular.module("mainApp")
        .controller("DashboardController", ['$q', '$rootScope', '$scope', '$mdDateRangePicker', 'commonRequest', DashboardController]);

}());