define(['angular', 'factories/GameFactory'], function (angular, GameFactory) {
    function GameSetupController($scope, GameFactory) {
        $scope.grid = [];
        $scope.isPlaying = false;
        $scope.selectedGame = "";
        loadPlayerSelectGrid();

        function loadPlayerSelectGrid() {
            var cells = $('.playerSelectPanel');

            console.log(window.innerHeight);
            console.log(window.innerWidth);

            var min = Math.min(window.innerWidth, window.innerHeight) / 3;

            cells.each(function (index, cell) {
                cell.style.height = min + 'px';
                cell.style.width = min + 'px';
            });
        };
        window.onresize = loadPlayerSelectGrid;
        $scope.players = [
            { name: 'Eric', type: 'Human', score: 0 },
            { name: 'Ada', type: 'Computer', score: 0 }
        ];

        $scope.gridSizes = [
            { size: 5, description: '5x5' },
            { size: 7, description: '7x7' },
            { size: 9, description: '9x9' },
        ];

        $scope.selectedGridSize = $scope.gridSizes[0].size;

        $scope.restartGame = function () {
            $scope.grid = [];
            $scope.isPlaying = false;
        };

        $scope.initializeGame = function (game, width, height) {
            $scope.createGrid(width, height);
            $scope.isPlaying = true;
            
            // TODO: Create Game Factory based off name...
            console.log('Trying to load game: ' + game);
            var cardFact = GameFactory.getGame(game);
            GameFactory.testFactory('ITEM1');

            console.log(cardFact.testFactory('ITEM2'));
        };

        $scope.createGrid = function (width, height) {
            $scope.grid = [];

            for (var i = 0; i < height; i++) {
                $scope.grid[i] = new Array(width);
            }
        };

    }


    return GameSetupController;
});