/**
 *
 * Controller to update attributes anjularJS to Teacher Pages
 * and Request data by SignalR
 *
 */

import app from "./app.js"
import { generateBody } from "./../js/generateTable.js"


/**
 * Controller to Index Teachers Page
 * Begin when load page
 */
app.controller('TeachersController', ['$scope', 'signalRService', '$sce', function ($scope, signalRService, $sce) {
    $scope.drop = false;
    signalRService.connect($scope, "/teachersHub", "responseTeachers");
    $scope.$on('responseService', (response, data) => callBackSignalRResponseIndex($scope, $sce, data[0]));
    signalRService.request("Index");
    actionDeleteTeacherBtn($scope, signalRService);
}]);


/**
 * Controller to Create and Update Teacher Page
 * Begin when load page
 */
app.controller('TeachersCreate', ['$scope', 'signalRService', function ($scope, signalRService) {
    signalRService.connect($scope, "/teachersHub", "responseTeachers");
    $scope.$on('responseService', (response, data) => callBacksignalRResponseCreate(data[0]));
    actionCreateTeacherBtn(signalRService);
}]);

/**
 * Clear Attributes
 * @param {TeachersController} $scope
 */
function clearAttributes($scope) {
    $scope.table = "";
    $scope.$apply();
}

/**
 * Callback SignalR
 * Update Attributes
 * @param {TeachersController} $scope
 * @param {scope} $sce
 * @param {object} data
 */
function callBackSignalRResponseIndex($scope, $sce, data) {
    if ($scope.drop) {
        if (data)
            alertSuccess('Teacher was deleted')
        else
            alertError('Teacher was not delete')
    }

    $scope.drop = false;

    clearAttributes($scope);
    $scope.table = $sce.trustAsHtml(generateBody(data));
    $scope.$apply();
}

/**
 * Callback SignalR
 * Redirect Page
 * @param {bool} success
 */
function callBacksignalRResponseCreate(success) {
    if (success)
        alertSuccess(),
        setTimeout(() => location = '/teachers', 3000)
    else
        alertError()
}

/**
 * Delete Teacher
 * @param {TeachersController} $scope
 * @param {signalR} signalRService
 */
function actionDeleteTeacherBtn($scope, signalRService ) {
    $('#confirmModel').on('click', function () {
        const id = $(this).data('id');
        $scope.drop = true;
        signalRService.request("Destroy");
    })
}

/**
 * Action Button Save Teacher
 * @param {signalR} signalRService
 */
function actionCreateTeacherBtn(signalRService) {
    $("#btnSaveTeacher").on('click', () => {
        const name = $("#nameTeacher").val(),
            salary = $("#salaryTeacher").val(),
            birthday = $("#birthTeacher").val()

        if (name && salary && birthday)
            signalRService.request("Store", [name, birthday, salary].toString());
    })
}