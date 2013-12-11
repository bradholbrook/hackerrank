define(['angular'], function (angular) {
    function CardinalityController($scope, $timeout) {

        $scope.grid = [];
        $scope.playing = false;
        $scope.player1Score = 0;
        $scope.player2Score = 0;

        // 1 or 2 for which player has the current turn.
        $scope.currentPlayer = 1;

        $scope.currentTurn = 1;

        $scope.sizes = [
            { size: 5, description: '5x5' },
            { size: 7, description: '7x7' },
            { size: 9, description: '9x9' },
        ];

        $scope.difficulties = ['Medium', 'Hard'];
        $scope.selectedDifficulty = 0;

        $scope.changeDifficulty = function (newDiff) {
            $scope.selectedDifficulty = newDiff;
        }

        $scope.restartGame = function () {
            $scope.player1Score = 0;
            $scope.player2Score = 0;
            $scope.currentPlayer = 1;
            $scope.currentTurn = 1;
            $scope.playing = false;
            $scope.grid = [];
        }

        $scope.changePlayerTurn = function () {
            if ($scope.currentPlayer == 1) {
                $scope.currentPlayer = 2;
                // TODO: Run CPU algorithm
            } else {
                // Human
            }

            $scope.currentTurn++;
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
            $scope.playing = true;
            updateGrid($scope.selectedSize, $scope.selectedSize);
        }

        $scope.selectedSize = $scope.sizes[0].size;

        function updateGrid(width, height) {
            $scope.grid = [];

            for (var i = 0; i < height; i++) {
                $scope.grid[i] = new Array(width);
            }

            // Use timeout to make sure the grid is rendered before we modify their sizes
            $timeout(makeGridResponsive, 0);
        }

        window.onresize = makeGridResponsive;

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
                if (!$(cell.target).hasClass('player-1') && !$(cell.target).hasClass('player-2')) {
                    var row = $(cell.target).data('row');
                    var column = $(cell.target).data('column');

                    $('.cell').removeClass('player-' + $scope.currentPlayer + '-active');
                    var touchedCells = $('.row-' + (row - 1) + '.column-' + column + ', .row-' + (row + 1) + '.column-' + column + ', .row-' + row + '.column-' + (column - 1) + ', .row-' + row + '.column-' + (column + 1) + ', .row-' + row + '.column-' + column);

                    touchedCells.each(function () {
                        $(this).addClass('player-' + $scope.currentPlayer);
                        $(this).removeClass('player-' + $scope.getOppositePlayer());
                    });

                    $scope.currentPlayer = $scope.getOppositePlayer();
                    // Calculate new scores

                    $scope.player1Score = $('.player-1').length;
                    $scope.player2Score = $('.player-2').length;
                    $scope.$apply();
                }
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