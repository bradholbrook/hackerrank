define(['angular'], function (angular) {
    angular.module('grid', []).directive('resize', function ($window) {
        return {
            restrict: 'A',
            link: function (scope, iterStartElement, attr) {

                var w = angular.element($window);

                scope.stuff = attr.stuff;
                console.log(scope.stuff);

                scope.getWindowDimensions = function () {
                    return { 'h': w[0].innerHeight, 'w': w[0].innerWidth };
                };

                scope.$watch(scope.getWindowDimensions, function (newValue, oldValue) {
                    scope.windowHeight = newValue.h;
                    scope.windowWidth = newValue.w;

                    scope.style = function () {
                        console.log(newValue.h);
                        console.log(newValue.w);
                        return {
                            'height': (newValue.h - 200) + 'px',
                            'width': (newValue.w - 200) + 'px'
                        };
                    };


                }, true);

                //w.onresize = $scope.$apply()

                w.bind('resize', function () {
                    scope.$apply();
                });
            }
        };
    });
});