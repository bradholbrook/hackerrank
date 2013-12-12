define(['angular'], function (angular) {
    function CardinalityController($scope, $timeout) {

        $scope.grid = [];
        $scope.isPlaying = false;

        $scope.players = [
            { name: 'Eric', type: 'Human', score: 0 },
            { name: 'Ada', type: 'Computer', score: 0 }
        ]; // TODO: Refactor into GameSetupController

        //$scope.player1Score = 0;
        //$scope.player2Score = 0;

        // 1 or 2 for which player has the current turn.
        $scope.currentPlayer = 1;
        $scope.currentTurn = 1;

        $scope.sizes = [
            { size: 5, description: '5x5' },
            { size: 7, description: '7x7' },
            { size: 9, description: '9x9' },
        ];

        $scope.selectedSize = $scope.sizes[0].size;

        $scope.difficulties = ['Easy', 'Medium', 'Hard'];
        $scope.selectedDifficulty = 1;

        $scope.changeDifficulty = function (newDiff) {
            $scope.selectedDifficulty = newDiff;
        };

        $scope.restartGame = function () {
            $scope.player1Score = 0;
            $scope.player2Score = 0;
            $scope.currentPlayer = 1;
            $scope.currentTurn = 1;
            $scope.isPlaying = false;
            $scope.grid = [];
        };

        $scope.runComputerTurn = function (difficulty) {
            var cells = $('.cell:not(.player-1):not(.player-2)');

            var rndIndex = ~~(Math.random() * cells.length);

            var selectedCell = cells[rndIndex];

            selectedCell.click();
        };

        $scope.changePlayerTurn = function () {
            $scope.currentTurn++;
            $scope.currentPlayer = $scope.getOppositePlayer();

            $scope.$apply();

            if ($scope.player1Score + $scope.player2Score == $scope.grid[0].length * $scope.grid.length) {
                if ($scope.player1Score > $scope.player2Score) {
                    alert('Player 1 won');
                } else {
                    alert('The Computer Won');
                }
            }

            else {
                if ($scope.currentPlayer === 2) {
                    $scope.runComputerTurn($scope.difficulties[$scope.selectedDifficulty]);
                }
            }
        }

        $scope.getOppositePlayer = function () {
            if ($scope.currentPlayer == 1)
                return 2;

            return 1;
        }

        $scope.initializeGame = function () {
            $scope.player1Score = 0;
            $scope.player2Score = 0;
            $scope.currentPlayer = 1; // TODO: Randomize current player @ start
            $scope.currentTurn = 1;
            $scope.isPlaying = true;
            updateGrid($scope.selectedSize, $scope.selectedSize);
        };

        function updateGrid(width, height) {
            $scope.grid = [];

            for (var i = 0; i < height; i++) {
                $scope.grid[i] = new Array(width);
            }

            // Use timeout to make sure the grid is rendered before we modify their sizes
            $timeout(makeGridResponsive, 0);
        }

        window.onresize = makeGridResponsive;

        function styleGrid() {
            // todo...
        }

        function makeGridResponsive() {
            var cells = $('.cell');

            var height = $('#grid').parent().width();

            var min = Math.min(height, height) / ($scope.selectedSize + 1);
            var max = $scope.selectedSize

            cells.each(function (index, cell) {
                cell.style.height = min + 'px';
                cell.style.width = min + 'px';
            });

            $('#grid').mouseleave(function () {
                $('.cell').removeClass('active');
            });

            $('.cell').click(function (cell) {
                // TODO: After the grid has been recreated or modified in any way,
                // the html will reset from Angular, so we have to make sure any styling on it is preserved...
                //$scope.grid[0][0] = "";
                //$scope.grid[0][1] = "";
                //$scope.grid[0][2] = "";
                //$scope.grid[0][3] = "";
                //$scope.grid[0][4] = "";

                //console.log($scope.grid);

                if (!$(cell.target).hasClass('player-1') && !$(cell.target).hasClass('player-2')) {
                    var row = $(cell.target).data('row');
                    var column = $(cell.target).data('column');

                    $('.cell').removeClass('player-' + $scope.currentPlayer + '-active');
                    var touchedCells = $('.row-' + (row - 1) + '.column-' + column + ', .row-' + (row + 1) + '.column-' + column + ', .row-' + row + '.column-' + (column - 1) + ', .row-' + row + '.column-' + (column + 1) + ', .row-' + row + '.column-' + column);

                    touchedCells.each(function () {
                        $(this).addClass('player-' + $scope.currentPlayer);
                        $(this).removeClass('player-' + $scope.getOppositePlayer());
                    });

                    $scope.player1Score = $('.player-1').length;
                    $scope.player2Score = $('.player-2').length;
                    $scope.$apply();

                    $scope.changePlayerTurn();
                }

                //makeGridResponsive();
            });

            $('.cell').mouseenter(function (cell) {
                $('.cell').removeClass('player-' + $scope.currentPlayer + '-active');

                if (!$(cell.target).hasClass('player-1') && !$(cell.target).hasClass('player-2')) {
                    var row = $(cell.target).data('row');
                    var column = $(cell.target).data('column');

                    var touchedCells = $('.row-' + (row - 1) + '.column-' + column + ', .row-' + (row + 1) + '.column-' + column + ', .row-' + row + '.column-' + (column - 1) + ', .row-' + row + '.column-' + (column + 1) + ', .row-' + row + '.column-' + column);

                    touchedCells.each(function () {
                        $(this).addClass('player-' + $scope.currentPlayer + '-active');
                    });
                }
            });
        }


    }


    return CardinalityController;
});