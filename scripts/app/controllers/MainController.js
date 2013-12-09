require(['CardinalityModule', 'controllers/AuthController', 'controllers/CardinalityController'],
	function (CardinalityModule, AuthController, CardinalityController) {
	    CardinalityModule.controller('AuthController', AuthController);
	    CardinalityModule.controller('CardinalityController', CardinalityController);
	});