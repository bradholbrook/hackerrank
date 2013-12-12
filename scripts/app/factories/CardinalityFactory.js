define(['angular', 'CardinalityModule', 'factories/CardinalityFactory'],
    function (angular, CardinalityModule) {
        'use strict';

        CardinalityModule.factory('CardinalityFactory', function ($rootScope) {
            return {

                // Test this factory by calling this method:
                testFactory: function (item) {
                    return "You're inside the CardinalityFactory. Optional Item was: " + item;
                },

            }
        });

    });