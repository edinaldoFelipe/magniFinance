/**
 *
 * Controller to update attributes anjularJS to Student Pages
 * and Request data by SignalR
 *
 */

import app from "./app.js"
import { generateBody } from "./../js/generateTable.js"


/**
 * Controller to Index Students Page
 * Begin when load page
 */
app.controller('StudentsController', ['$scope', 'signalRService', '$sce', function ($scope, signalRService, $sce) {
    $scope.drop = false;
    signalRService.connect($scope, "/studentsHub", "responseStudents");
    $scope.$on('responseService', (response, data) => callBackSignalRResponseIndex($scope, $sce, data[0]));
    signalRService.request("Index");
    actionDeleteStudentBtn($scope, signalRService);
}]);


/**
 * Controller to Create and Update Student Page
 * Begin when load page
 */
app.controller('StudentsCreate', ['$scope', 'signalRService', function ($scope, signalRService) {
    signalRService.connect($scope, "/studentsHub", "responseStudents");
    $scope.$on('responseService', (response, data) => callBacksignalRResponseCreate(data[0]));
    actionCreateStudentBtn(signalRService);
}]);

/**
 * Clear Attributes
 * @param {StudentsController} $scope
 */
function clearAttributes($scope) {
    $scope.table = "";
    $scope.$apply();
}

/**
 * Callback SignalR
 * Update Attributes
 * @param {StudentsController} $scope
 * @param {scope} $sce
 * @param {object} data
 */
function callBackSignalRResponseIndex($scope, $sce, data) {
    if ($scope.drop) {
        if (data)
            alertSuccess('Student was deleted')
        else
            alertError('Student was not delete')
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
        setTimeout(() => location = '/students', 3000)
    else
        alertError()
}

/**
 * Delete Student
 * @param {StudentsController} $scope
 * @param {signalR} signalRService
 */
function actionDeleteStudentBtn($scope, signalRService ) {
    $('#confirmModel').on('click', function () {
        const id = $(this).data('id');
        $scope.drop = true;
        signalRService.request("Destroy");
    })
}

/**
 * Action Button Save Student
 * @param {signalR} signalRService
 */
function actionCreateStudentBtn(signalRService) {
    $("#btnSaveStudent").on('click', () => {
        const name = $("#nameStudent").val(),
            birthday = $("#birthStudent").val(),
            register = $("#registerNumber").val()

        if (name && birthday && register)
            signalRService.request("Store", [name, birthday, register].toString());
    })
}