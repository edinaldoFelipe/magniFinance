/**
 *
 * Controller to update attributes anjularJS to Course Pages
 * and Request data by SignalR
 *
 */

import app from "./app.js"
import { generateBody } from "./../js/generateTable.js"


/**
 * Controller to Index Courses Page
 * Begin when load page
 */
app.controller('CoursesController', ['$scope', 'signalRService', '$sce', function ($scope, signalRService, $sce) {
    $scope.drop = false;
    signalRService.connect($scope, "/coursesHub", "responseCourses");
    $scope.$on('responseService', (response, data) => callBackSignalRResponseIndex($scope, $sce, data[0]));
    signalRService.request("Index");
    actionDeleteCourseBtn($scope, signalRService);
}]);


/**
 * Controller to Create and Update Course Page
 * Begin when load page
 */
app.controller('CoursesCreate', ['$scope', 'signalRService', function ($scope, signalRService) {
    signalRService.connect($scope, "/coursesHub", "responseCourses");
    $scope.$on('responseService', (response, data) => callBacksignalRResponseCreate(data[0]));
    actionCreateCourseBtn(signalRService);
}]);

/**
 * Clear Attributes
 * @param {CoursesController} $scope
 */
function clearAttributes($scope) {
    $scope.table = "";
    $scope.$apply();
}

/**
 * Callback SignalR
 * Update Attributes
 * @param {CoursesController} $scope
 * @param {scope} $sce
 * @param {object} data
 */
function callBackSignalRResponseIndex($scope, $sce, data) {
    if ($scope.drop) {
        if (data)
            alertSuccess('Course was deleted')
        else
            alertError('Course was not delete')
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
        setTimeout(() => location = '/courses', 3000)
    else
        alertError()
}

/**
 * Delete Course
 * @param {CoursesController} $scope
 * @param {signalR} signalRService
 */
function actionDeleteCourseBtn($scope, signalRService ) {
    $('#confirmModel').on('click', function () {
        const id = $(this).data('id');
        $scope.drop = true;
        signalRService.request("Destroy");
    })
}

/**
 * Action Button Save Course
 * @param {signalR} signalRService
 */
function actionCreateCourseBtn(signalRService) {
    $("#btnSaveCourse").on('click', () => {
        const name = $("#nameCourse").val();
        if (name)
            signalRService.request("Store", name);
    })
}