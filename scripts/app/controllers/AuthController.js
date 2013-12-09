define(['angular', 'CardinalityModule', 'Q'], function (angular, CardinalityModule, Q) {
    function AuthController($scope, $location, angularFireAuth) {

        var chatRef = new Firebase(CardinalityModule.FIREPATH);

        angularFireAuth.initialize(chatRef, { scope: $scope, name: "user" });

        $scope.login = function () {
            angularFireAuth.login('facebook');
        };

        $scope.logout = function () {
            angularFireAuth.logout();
        };


        //$scope.$on("angularFireAuth:login", function (evt, user) {
        //    // User logged in.
        //});
        //$scope.$on("angularFireAuth:logout", function (evt) {
        //    // User logged out.
        //});
        //$scope.$on("angularFireAuth:error", function (evt, err) {
        //    // There was an error during authentication.
        //});
    }

    return AuthController;
});