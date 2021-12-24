/**
 *
 * Controller to update attributes anjularJS to Subject Pages
 * and Request data by SignalR
 *
 */

import app from "./app.js"
import { generateBody } from "./../js/generateTable.js"


/**
 * Controller to Index Subjects Page
 * Begin when load page
 */
app.controller('SubjectsController', ['$scope', 'signalRService', '$sce', function ($scope, signalRService, $sce) {
    $scope.drop = false;
    signalRService.connect($scope, "/subjectsHub", "responseSubjects");
    $scope.$on('responseService', (response, data) => callBackSignalRResponseIndex($scope, $sce, data[0]));
    signalRService.request("Index");
    actionDeleteSubjectBtn($scope, signalRService);
}]);


/**
 * Controller to Create and Update Subject Page
 * Begin when load page
 */
app.controller('SubjectsCreate', ['$scope', 'signalRService', function ($scope, signalRService) {
    signalRService.connect($scope, "/subjectsHub", "responseSubjects");
    $scope.$on('responseService', (response, data) => callBacksignalRResponseCreate(data[0]));
    actionCreateSubjectBtn(signalRService);
}]);

/**
 * Clear Attributes
 * @param {SubjectsController} $scope
 */
function clearAttributes($scope) {
    $scope.table = "";
    $scope.$apply();
}

/**
 * Callback SignalR
 * Update Attributes
 * @param {SubjectsController} $scope
 * @param {scope} $sce
 * @param {object} data
 */
function callBackSignalRResponseIndex($scope, $sce, data) {
    if ($scope.drop) {
        if (data)
            alertSuccess('Subject was deleted')
        else
            alertError('Subject was not delete')
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
        setTimeout(() => location = '/subjects', 3000)
    else
        alertError()
}

/**
 * Delete Subject
 * @param {SubjectsController} $scope
 * @param {signalR} signalRService
 */
function actionDeleteSubjectBtn($scope, signalRService ) {
    $('#confirmModel').on('click', function () {
        const id = $(this).data('id');
        $scope.drop = true;
        signalRService.request("Destroy");
    })
}

/**
 * Action Button Save Subject
 * @param {signalR} signalRService
 */
function actionCreateSubjectBtn(signalRService) {
    $("#btnSaveSubject").on('click', () => {
        const name = $("#nameSubject").val(),
            course = $("#selectCourse").val(),
            teacher = $("#selectTeacher").val()

        if (name && course && teacher)
            signalRService.request("Store", [name, course, teacher].toString());
    })
}