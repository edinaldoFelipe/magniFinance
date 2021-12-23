/**
 *
 *  Main Module AnjularJS
 *  SignalR Hub Connection
 *  
 * */

//function newCourse() {
//    angular.element(document.getElementById("CoursesController")).scope().update();
//}

const app = angular.module('app', []);

app.factory('signalRService', function () {
    let connection;

    return {
        connect: function ($controllerScope, $hub, $route) {
            connection = new signalR.HubConnectionBuilder().withUrl($hub).build();

            connection.on($route, (...data) => $controllerScope.$broadcast('responseService', data));

            connection.start()
                .catch(error => console.log('Error Connection SignalR', error.toString()))
        },
        request: function (method, data = null) {
            if (this.isConnected())
                connection.invoke(method, data);
            else
                setTimeout(() => this.request(method, data), 500);
        },
        isConnected: () => connection.state === 'Connected',
        connectionState: () => connection.state
    }
});

export default app;