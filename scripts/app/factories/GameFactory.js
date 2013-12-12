define(['angular', 'CardinalityModule', 'factories/CardinalityFactory'],
    function (angular, CardinalityModule, CardinalityFactory) {
        'use strict';

        CardinalityModule.factory('GameFactory', function ($rootScope, CardinalityFactory) {
            return {

                // Test this factory by calling this method:
                testFactory: function (item) {
                    return "You're inside the GameFactory. Optional Item was: " + item;
                },

                getGame: function (gameName) {
                    switch (gameName) {
                        case "Cardinality":
                            console.log('Inside case');
                            console.log(CardinalityFactory);
                            return CardinalityFactory;
                            break;

                        default:
                            console.log("Ain't nobody got access to that factory (GameName was: " + gameName + ")");
                            break;
                    }
                }
            }
        });

    });