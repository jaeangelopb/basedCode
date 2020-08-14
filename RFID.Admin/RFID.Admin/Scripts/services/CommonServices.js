(function () {

    var commonRequest = function ($http) {


        var GetData = function (ctrl, method, formData) {

            return $http({
                method: 'POST',
                url: "/" + ctrl + "/" + method,
                data: formData,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            })
            .then(function (response) {
                //-- returns a promise and the data.
                return response.data;
            });
        };


        var Post = function (ctrl, method, formData) {

            return $http({
                method: 'POST',
                url: "/" + ctrl + "/" + method,
                data: formData,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            })
            .then(function (response) {
                //-- returns a promise and the data.
                return response.data;
            });
        };


        var SubmitForm = function (ctrl, method, formData) {

            return $http({
                method: 'POST',
                url: "/" + ctrl + "/" + method,
                data: formData,
                headers: { 'Content-Type': undefined }
            })
            .then(function (response) {
                //-- returns a promise and the data.
                return response.data;
            });
        };


        return {
            GetData: GetData,
            Post: Post,
            SubmitForm: SubmitForm,
        };




    };

    var mainApp = angular.module("mainApp");
    mainApp.factory("commonRequest", commonRequest);

}());