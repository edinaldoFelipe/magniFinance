/**
 *
 * Controller to update attributes anjularJS to Dashboard Page
 * and Request data by SignalR
 *
 */

import app from "./app.js"
import { generateActivities } from "./../js/generateTable.js"

/**
 * Controller to Dashboard Page
 * Begin when load page
 */
app.controller('HomeController', ['$scope', 'signalRService', '$sce', function ($scope, signalRService, $sce) {
    signalRService.connect($scope, "/dashboardHub", "responseDashboard");
    clearAttributes($scope);
    $scope.$on('responseService', (response, data) => callBackSignalRResponseIndex($scope, $sce, data[0]))
    signalRService.request("Index");
}]);

/**
 * Callback SignalR
 * @param {HomeController} $scope
 * @param {scope} $sce
 * @param {object} data
 */
function callBackSignalRResponseIndex($scope, $sce, data) {
    const { amount, activities, rating } = data;

    updateAmounts($scope, amount);
    updateRating($scope, rating);
    $scope.table = $sce.trustAsHtml(generateActivities(activities));
    $scope.$apply();
};

/**
 * Clear Attributes Controller
 * @param {HomeController} $scope
 */
function clearAttributes($scope) {
    $scope.amount = {};
    $scope.rating = {
        b5: 0,
        b4: 0,
        b3: 0,
        b2: 0,
        b1: 0
    };
}

/**
 * Update total courses, sujects, teacher, students
 * @param {HomeController} $scope
 * @param {object} amount
 */
function updateAmounts($scope, amount) {
    $scope.amount = {
        courses: amount.courses,
        subjects: amount.subjects,
        teachers: amount.teacher,
        students: amount.students
    };
}

/**
 * Update Rating data
 * @param {HomeController} $scope
 * @param {object} rating
 */
function updateRating($scope, rating) {
    const $total = rating.r1 + rating.r2 + rating.r3 + rating.r4 + rating.r5;
    $scope.rating = {
        r1: rating.r1,
        r2: rating.r2,
        r3: rating.r3,
        r4: rating.r4,
        r5: rating.r5,
        b1: rating.r1 / $total * 100,
        b2: rating.r2 / $total * 100,
        b3: rating.r3 / $total * 100,
        b4: rating.r4 / $total * 100,
        b5: rating.r5 / $total * 100,
        diff: rating.diff,
        avg: rating.avg
    }
}