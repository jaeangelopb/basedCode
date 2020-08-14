(function () {

    var GateTerminalController = function ($q, $rootScope, $scope, $mdToast, commonRequest) {

        var PAGE_SIZE = 8;
        var PAGE_START = 1;
        var AccountID = document.getElementById("AccountID").value;
        var controller = "GateTerminal";
        var loadingStatus = false;

        var onError = function (response) {
            swal(response, "", "error");
            console.log(response);
        };

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

        var CSVPageIndexChange = function (increment) {
            if (increment < 0 && $scope.uploadlist.PageIndex === 1) return;

            if (increment > 0 && ($scope.uploadlist.PageIndex + 1) > $scope.uploadlist.totalPage) return;

            $scope.uploadlist.PageIndex += increment;
            //CSVList();
        };

        var List = function () {
            $scope.GateTerminal.loading = true;
            var onSuccessful = function (response) {
                $scope.GateTerminal.data = response.data;
                $scope.GateTerminal.total = response.total;
                $scope.GateTerminal.totalPage = Math.ceil($scope.GateTerminal.total / $scope.GateTerminal.PageSize);
                $scope.GateTerminal.loading = false;
                if ($scope.checkAll) {
                    var list = $scope.GateTerminal.data.map(a => a.EmployeeID);
                    $scope.checklistary.push(list);
                }
            };

            var param = $.param({
                "AccountID": AccountID,
                "search": $scope.GateTerminal.Search,
                "pageindex": PAGE_START,
                "pagesize": PAGE_SIZE
            });


            commonRequest.GetData(controller, "List", param)
                .then(onSuccessful, onError);

        };


        
        var Post = function () {

            var onSuccessful = function (response) {
                if (response.GateTerminalID !== "00000000-0000-0000-0000-000000000000") {
                    if ($scope.mode === "add")
                        swal("New Employee has been added", "", "success");
                    else
                        swal("Changes has been saved.", "", "success");

                    List();
                    angular.element("#smallModal").modal("hide")
                    $scope.mode = "list";
                }

                else
                    swal("Error in saving.", response.Description, "error");
            };

            var formdata = new FormData(document.getElementById("form"));

            commonRequest.SubmitForm(controller, "SaveGateTerminal", formdata)
                .then(onSuccessful, onError);

        };

        var UploadPost = function () {
            $scope.uploadlist.submitIndex = 0;
            var request = [];
            var response = [];
            var hasSuccess = false;
            var hasError = false;
            var emp = $scope.uploadlist.data;

            $scope.uploadlist.submitting = true;

            var onSuccessful = function (response) {

                if (response.Code === "200") {
                    hasSuccess = true;
                    $scope.uploadlist.data[$scope.uploadlist.submitIndex].SubmitStatus = 1
                    $scope.uploadlist.data[$scope.uploadlist.submitIndex].SubmitStatusErrorMsg = ""
                }
                else {
                    $scope.uploadlist.data[$scope.uploadlist.submitIndex].SubmitStatus = 2
                    $scope.uploadlist.data[$scope.uploadlist.submitIndex].SubmitStatusErrorMsg = response.Description
                    hasError = true;
                }
                $scope.uploadlist.submitIndex++;

                if ($scope.uploadlist.submitIndex >= $scope.uploadlist.total) {
                    $scope.uploadlist.submitting = false;
                    $scope.processing.enable = false;
                    $scope.processing.label = "";
                    if (hasError && hasSuccess) {
                        var employee = angular.copy($scope.uploadlist.data)
                        var filtered = employee.filter(a => a.SubmitStatus !== 1)
                        $scope.uploadlist.data = filtered
                        $scope.uploadlist.total = filtered.length
                        swal("New employees have been partially imported.", "See the Submit status to see the error", "warning");
                    }
                    else if (hasError && !hasSuccess) {


                        $scope.uploadlist.data = filtered
                        swal("Importing failed.", "See the Submit status to see the error", "warning");
                    }
                    else {

                        swal("New employees have been imported", "", "success");
                        $scope.mode = "list"
                        $scope.uploadlist.data = []
                        $scope.uploadlist.total = 0

                        List();
                    }

                    return;
                }

                commonRequest.SubmitForm(controller, "SaveEmployee", request[$scope.uploadlist.submitIndex])
                    .then(onSuccessful, onError)
            }

            var onUploadError = function (response) {
                $scope.uploadlist.data[$scope.uploadlist.submitIndex].SubmitStatus = 2
                $scope.uploadlist.submitIndex++;
                hasError = true;

            }

            for (x in emp) {
                var formdata = new FormData()
                formdata.append("Employee.EmployeeNo", emp[x].EmployeeNo)
                formdata.append("Employee.FirstName", emp[x].FirstName)
                formdata.append("Employee.LastName", emp[x].LastName)
                formdata.append("Employee.MiddleName", emp[x].MiddleName)
                formdata.append("Employee.EmailAddress", emp[x].EmailAddress)
                formdata.append("Employee.MobileNumber", emp[x].MobileNumber)
                formdata.append("Employee.RoleID", 5)
                formdata.append("Employee.CompanyID", $scope.uploadlist.CompanyID)

                request.push(formdata);
                response.push(onSuccessful);

            }


            commonRequest.SubmitForm(controller, "SaveEmployee", request[0])
                 .then(onSuccessful, onUploadError)


        }


        var SetEmployeeStatus = function (status) {
            var checked = $scope.checklistary
            var queueRequest = [];

            var statuslbl = ""
            if (status === 0)
                statuslbl = "Delete"
            else if (status === 1)
                statuslbl = "Active"
            else if (status === 2)
                statuslbl = "Deactive"

            var peronSuccessful = function (response) {
                console.log(response)
                $scope.checkindex++;
            }

            var onSuccessful = function (response) {
                $scope.checklist = [];
                $scope.checklistary = [];
                $scope.checkindex = 0;
                $scope.checkAll = false;
                $scope.processing.enable = false;
                $scope.processing.label = "";

                List();
       
                swal("Successfully " + statuslbl.toLowerCase() + "d.", "", "success");
            }


            for (x in checked) {
                var param = $.param({
                    "id": checked[x],
                    "status": status,
                })
                queueRequest.push(
                    commonRequest.Post(controller, "SetEmployeeStatus", param)
                        .then(peronSuccessful, onError)
                );
            }

            $q.all(queueRequest)
                .then(onSuccessful, onError)

        }




        var GetGateType = function () {
            $scope.GateTypes.loading = true;
            var onSuccessful = function (response) {
                $scope.GateTypes = response.data.GateTypeList;

                $scope.GateTypes.total = response.GateTypes;
                //   var hasAll = ($scope.GateType.filter(c => c.CompanyID === "-").length > 0);
                //   if (!hasAll) {
                //       $scope.list.CompanyID = $scope.GateType[0].CompanyID;
                //  }
            };
            var param = $.param({
            });

            commonRequest.Post(controller, "GetAllGateType", param)
                       .then(onSuccessful, onError)

        }

        $scope.ToAdd = function () {
            $scope.Employee = [];
            $scope.Employee.CompanyDC = [];
            $scope.Employee.CompanyDC.CompanyID = $scope.list.CompanyID === "-" ? "" : $scope.list.CompanyID;

            $scope.mode = "add";
        }

        $scope.ToUpload = function () {
            angular.element("#uploadcsv").click();
            $scope.uploadlist.data = [];
            $scope.uploadlist.total = 0;
            $scope.uploadlist.submitting = false;
            $scope.uploadlist.submitIndex = 0;
            $scope.uploadlist.CompanyID = "";
            //$scope.mode = "upload";
        }

        $scope.UploadCSV = function (file) {
            var errorHandler = function (evt) {
                if (evt.target.error.name === "NotReadableError") {
                    showError("Canno't read file !");
                    swal("Canno't read file !", "", "error");
                }
            }

            var reader = new FileReader();

            reader.onload = (function (file) {
                return function (evt) {
                    var csv = evt.target.result;
                    document.getElementById("uploadcsv").value = "";
                    try {
                        var fields = ["EmployeeNo", "LastName", "FirstName", "MiddleName", "EmailAddress", "MobileNumber", "Role"];
                        var csvdata = csvJSON(csv, fields)
                        $scope.$apply(function () {
                            $scope.uploadlist.data = JSON.parse(csvdata)
                            $scope.uploadlist.total = $scope.uploadlist.data.length
                            $scope.mode = "upload"
                            swal("Successfully uploaded to import", "Select Company for these employees.", "success");
                        })
                    }
                    catch (err) {
                        swal("CSV uploading failed", "Invalid csv. Download template for importing employee", "error");

                    }

                };
            })(file);

            reader.onerror = errorHandler;

            reader.onloadend = (function (file) {
                $scope.$apply(function () {

                })
            })

            reader.readAsText(file[0]);


        }


        $scope.ToView = function (data) {
        //    $scope.mode = "edit";
            $scope.GateTerminals = angular.copy(data);
            GetGateType();
        }

        $scope.ToCancel = function () {
            if ($scope.mode === "upload" && $scope.uploadlist.data.length > 0) {
                swal({
                    title: "Discard uploaded employee?",
                    text: "You are about to discard these employees. Are you sure that you want to proceed?",
                    icon: "warning",
                    buttons: true,
                    dangerMode: true
                })
                 .then((confirm) => {
                     if (confirm) {
                         $scope.$apply(function () {
                             $scope.mode = "list";
                         })
                     }
                 });
            }
            else {
                $scope.mode = "list";

            }
        }

        $scope.ConfirmEmployeeStatus = function (status) {
            var statuslbl = ""
            if (status === 0)
                statuslbl = "Delete"
            else if (status === 1)
                statuslbl = "Active"
            else if (status === 2)
                statuslbl = "Deactive"


            if ($scope.checklistary.length === 0) {
                swal("No employee/s selected to " + statuslbl)
                return;
            }

            swal({
                title: ((statuslbl === "Delete") ? statuslbl : "Set " + statuslbl) + " employee?",
                text: "You are about to " + statuslbl.toLowerCase() + " this selected employee. Are you sure that you want to proceed?",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            })
            .then((confirm) => {
                if (confirm) {
                    $scope.processing.enable = true;
                    $scope.processing.label = statuslbl.toLowerCase();

                    SetEmployeeStatus(status)
                }
            });

        }

        $scope.browseImage = function () {
            angular.element("#fileimage").click()
        }

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

                }
                image.src = event.target.result;
                $scope.$apply(function () {
                    $scope.Employee.ProfilePhoto = event.target.result;
                })

            }

            reader.onerror = errorHandler;

            var errorHandler = function (evt) {
                if (evt.target.error.name === "NotReadableError") {
                    swal("Canno't read file !", "", "error");
                }
            }

            reader.readAsDataURL(file[0]);
        };

        $scope.downloadTemplate = function () {

            var data = 'EmployeeNo,LastName,FirstName,MiddleName,EmailAddress,MobileNumber';

            var aLink = document.createElement('a');
            var evt = document.createEvent("HTMLEvents");
            evt.initEvent("click");
            aLink.download = "upload_employee.csv";
            aLink.href = 'data:text/csv;charset=UTF-8,' + encodeURIComponent(data);
            aLink.dispatchEvent(evt);
            aLink.click();

        }

        $scope.ConfirmSave = function () {

            swal({
                title: "Save employee?",
                text: "You are about to save this employee. Are you sure that you want to proceed?",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            })
            .then((confirm) => {
                if (confirm) {
                    Post()
                }
            });

        }

        $scope.ConfirmUpload = function () {

            swal({
                title: "Import employee list?",
                text: "You are about to import these employees. Are you sure that you want to proceed?",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            })
            .then((confirm) => {
                if (confirm) {

                    $scope.processing.enable = true;
                    $scope.processing.label = "upload"
                    UploadPost()
                }
            });

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
            $scope.GateTerminal = [];
            $scope.GateTerminal.data = [];
            $scope.GateTerminal.Search = "";
            $scope.GateTerminal.CompanyID = "-";
            $scope.GateTerminal.Status = "-";
            $scope.GateTerminal.PageIndex = 1;
            $scope.GateTerminal.PageSize = PAGE_SIZE
            $scope.GateTerminal.total = 0;
            $scope.GateTerminal.totalPage = 0;
            $scope.GateTerminal.loading = false;

      //     $scope.mode = "edddit";
            $scope.GateTypes = [];
            $scope.GateTerminal = [];

            $scope.GateTerminal.data = [];
            $scope.GateTypes.loading = false;
            $scope.GateTerminal.loading = false;

            $scope.uploadlist = [];
            $scope.uploadlist.data = [];
            $scope.uploadlist.Search = "";
            $scope.uploadlist.PageIndex = 1;
            $scope.uploadlist.PageSize = PAGE_SIZE
            $scope.uploadlist.CompanyID = "";
            $scope.uploadlist.total = 0;
            $scope.uploadlist.totalPage = 0;
            $scope.uploadlist.submitting = false;
            $scope.uploadlist.submitIndex = 0;

            //   $scope.companylist = []

            $scope.Employee = [];

            $scope.checklist = [];
            $scope.checklistary = [];
            $scope.checkAll = false;


            $scope.checkindex = 0;

            $scope.processing = [];
            $scope.processing.enable = false;
            $scope.processing.label = "";

            GetGateType();
            List();
            //   GateType();
        }


        $scope.onError = onError;
        $scope.Search = Search;
        $scope.PageIndexChange = PageIndexChange;
        $scope.List = List;
        $scope.GetGateType = GetGateType;
        $scope.Init = Init;




        (function () {
            Init();
        }());
    }

    angular.module("mainApp")
        .controller("GateTerminalController", ['$q', '$rootScope', '$scope', '$mdToast', 'commonRequest', GateTerminalController]);

}());