requirejs.config({
    baseUrl: 'Scripts',
    paths: {
        angular: 'lib/angular',
        angularFire: 'lib/angularFire',
        CardinalityModule: 'app/modules/CardinalityModule',
        services: 'app/services',
        controllers: 'app/controllers',
        directives: 'app/directives',
        factories: 'app/factories',
        Q: 'lib/q',
        jquery: 'lib/jquery'
    },
    shim: {
        'angular': { exports: 'angular', deps: ['jquery'] },
        'angularFire': { deps: ['angular'] }
    },
    priority: ['jquery', 'angular']
});

define('modernizr', [], Modernizr);

require(['jquery', 'angular', 'modernizr', 'CardinalityModule', 'controllers/MainController'],
    function (jquery, angular, modernizr, CardinalityModule, MainController) {
        'use strict';
        CardinalityModule.FIREPATH = 'https://hot.firebaseio.com';

        // http://angularfire.com/documentation.html#overview
    });