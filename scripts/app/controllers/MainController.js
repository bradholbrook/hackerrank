require(['CardinalityModule', 'controllers/AuthController', 'controllers/GameSetupController', 'controllers/CardinalityController'],
	function (CardinalityModule, AuthController, GameSetupController, CardinalityController) {
	    CardinalityModule.controller('AuthController', AuthController);
	    CardinalityModule.controller('GameSetupController', GameSetupController);
	    CardinalityModule.controller('CardinalityController', CardinalityController);
	});