(function () {

    var CompanyController = function ($q, $scope, commonRequest) {

        var PAGE_SIZE = 8;
        var PAGE_START = 1;
        var controller = "Company";

        var onError = function (response) {
            swal(response, "", "error");
            console.log(response);
        };

        //LIST
        var Search = function () {
            $scope.list.PageIndex = PAGE_START;
            $scope.list.data = [];
            List();
        };

        var PageIndexChange = function (increment) {
            if (increment < 0 && $scope.list.PageIndex === 1) return;

            if (increment > 0 && ($scope.list.PageIndex + 1) > $scope.list.totalPage) return;

            $scope.list.PageIndex += increment;
            List();
        };

        var List = function () {
            $scope.list.loading = true;
            var onSuccessful = function (response) {
                $scope.list.data = response.data;
                $scope.list.total = response.total;
                $scope.list.totalPage = Math.ceil($scope.list.total / $scope.list.PageSize);
                $scope.list.loading = false;
            };

            var param = $.param({
                "search": $scope.list.Search,
                "pageindex": $scope.list.PageIndex,
                "pagesize": $scope.list.PageSize
            });


            commonRequest.GetData(controller, "List", param)
                .then(onSuccessful, onError);

        };
        $scope.ToAccountForm = function (data) {
            $scope.mode = "ToAccountForm";
            $scope.Employee = angular.copy(data)
        }

        $scope.ToAdd = function () {
            $scope.mode = "ToAdd";
            $scope.Employee = [];

        }

        $scope.ToGateTerminal = function (data) {
          location.href('GateTerminal')
        }
        

        // CRUD POST
        var SaveAccount = function () {

            var onSuccessful = function (response) {
                if (response.data !== null) {
                    if ($scope.mode === "add")
                        swal("New Company has been added", "", "success");
                    else
                        swal("Changes has been saved.", "", "success");

                    List();
                    $scope.mode = "list";
                }

                else
                    swal("Error in saving.", response.Description, "error");
            };

            var formdata = new FormData(document.getElementById("form"));

            commonRequest.SubmitForm(controller, "SaveAccount", formdata)
                .then(onSuccessful, onError);

        };
        var Delete = function () {
            var checked = $scope.checklistary;
            var queueRequest = [];

            var peronSuccessful = function (response) {
                $scope.checkindex++;
            };

            var onSuccessful = function (response) {
                $scope.checklist = [];
                $scope.checklistary = [];
                $scope.checkindex = 0;
                $scope.checkAll = false;
                $scope.processing.enable = false;
                $scope.processing.label = "";
                List();
                swal("Successfully deleted", "", "success");
            };


            for (x in checked) {
                var param = $.param({
                    "id": checked[x]
                });
                queueRequest.push(
                    commonRequest.Post(controller, "Delete", param)
                        .then(peronSuccessful, onError)
                );
            }

            $q.all(queueRequest)
                .then(onSuccessful, onError);

        };

        // CRUD ACTION
        $scope.Account = function (data) {

            $scope.list.loading = true;
            var onSuccessful = function (response) {
                $scope.list.data = response.data;
                $scope.list.total = response.total;
                $scope.list.totalPage = Math.ceil($scope.list.total / $scope.list.PageSize);
                $scope.list.loading = false;
            };

            var param = $.param({
                "search": $scope.list.Search,
                "pageindex": $scope.list.PageIndex,
                "pagesize": $scope.list.PageSize
            });


            commonRequest.GetData(controller, "List", param)
                .then(onSuccessful, onError);
            $scope.Company = angular.copy($scope.list.data);
            $scope.mode = "Account";

        };
        $scope.Affilation = function () {
            $scope.Company = [];

            $scope.mode = "Affilation";
        };
        $scope.Department = function () {
            $scope.Company = [];

            $scope.mode = "Department";
        };

        $scope.GateTerminal = function () {
            $scope.Company = [];
           
            $scope.mode = "GateTerminal";
        };
        $scope.ToView = function (data) {
            $scope.mode = "edit";
            $scope.Company = angular.copy(data);
        };

        $scope.ToCancel = function () {
            $scope.mode = "list";
        };

        $scope.ConfirmDelete = function () {
            if ($scope.checklistary.length === 0){ 
                swal("No selected to deleted.");
                return;
            }

            swal({
                title: "Delete Company?",
                text: "You are about to delete this selected Company. Are you sure that you want to proceed?",
                icon: "warning",
                buttons: true,
                dangerMode: true
            })
            .then((confirm) => {
                if (confirm) {
                    $scope.processing.enable = true;
                    $scope.processing.label = "delete";
                    Delete();
                }
            });

        };

        $scope.ConfirmSave = function () {

            swal({
                title: "Save Company?",
                text: "You are about to save this Company. Are you sure that you want to proceed?",
                icon: "warning",
                buttons: true,
                dangerMode: true
            })
            .then((confirm) => {
                if (confirm) {
                    SaveAccount();
                }
            });

        };

        // OTHER EVENTS
        $scope.browseImage = function () {
            angular.element("#fileimage").click();
        };

        $scope.UploadImage = function (file) {
            var reader = new FileReader();
            // Read file into memory as UTF-8   
            reader.onload = function (event) {
                var image = new Image();
                image.onload = function () {
                    var canvas2 = document.createElement("canvas");

                    var MAX_WIDTH = 220;
                    var MAX_HEIGHT = 200;
                    var width = image.width;
                    var height = image.height;

                    if (width > height) {
                        if (width > MAX_WIDTH) {
                            height *= MAX_WIDTH / width;
                            width = MAX_WIDTH;
                        }
                    } else {
                        if (height > MAX_HEIGHT) {
                            width *= MAX_HEIGHT / height;
                            height = MAX_HEIGHT;
                        }
                    }
                    canvas2.width = width;
                    canvas2.height = height;
                    var context = canvas2.getContext("2d");
                    context.drawImage(image, 0, 0, width, height);

                    document.getElementById("imagevalue").value = canvas2.toDataURL();

                };
                image.src = event.target.result;
                $scope.$apply(function () {
                    $scope.Company.CompanyLogo = event.target.result;
                });

            };

            reader.onerror = errorHandler;

            var errorHandler = function (evt) {
                if (evt.target.error.name === "NotReadableError") {
                    swal("Canno't read file !", "", "error");
                }
            };

            reader.readAsDataURL(file[0]);
        };

        $scope.checkchanged = function (e) {
            var chk = [];
            for (x in $scope.checklist) {
                if (typeof $scope.checklist[x] !== 'undefined') {
                    var param = new Object();
                    chk.push($scope.checklist[x]);
                }
            }
            $scope.checklistary = chk;

        };


        // INITIALIZING FUNCTIONS / EVENTS / VARIABLE
        var Init = function () {

            // CONFIGURATION FOR LIST
            $scope.mode = "list";
            $scope.list = [];
            $scope.list.data = [];
            $scope.list.Search = "";
            $scope.list.PageIndex = 1;
            $scope.list.PageSize = PAGE_SIZE;
            $scope.list.total = 0;
            $scope.list.totalPage = 0;
            $scope.list.loading = false;


            // FOR DATA HOLDER
            $scope.Company = [];

            // FOR CHECK BOX HOLDER
            $scope.checklist = [];
            $scope.checklistary = [];
            $scope.checkAll = false;
            $scope.checkindex = 0;

            // FOR PROCESSING CONTROL
            $scope.processing = [];
            $scope.processing.enable = false;
            $scope.processing.label = "";

            // CALL LIST() TO BIND DATA TO TABLE
            SaveAccount;
            List();
        };


        $scope.onError = onError;
        $scope.Search = Search;
        $scope.PageIndexChange = PageIndexChange;
        $scope.List = List;
        $scope.Init = Init;
        $scope.SaveAccount = SaveAccount;


        (function () {
            Init();
        }());
    };

    angular.module("mainApp")
        .controller("CompanyController", ['$q', '$scope', 'commonRequest', CompanyController]);

}());