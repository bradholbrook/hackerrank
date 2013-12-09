define(['angular'], function (angular) {
    function CardinalityController($scope, $timeout) {
        
        $scope.grid = [];
        $scope.playing = false;
        $scope.sizes = [
            { size: 5, description: '5x5' },
            { size: 7, description: '7x7' },
            { size: 9, description: '9x9' },
        ];

        $scope.difficulties = ['Easy', 'Medium', 'Hard'];

        // Index-based
        $scope.selectedDifficulty = 1;

        $scope.changeDifficulty = function (newDiff) {
            $scope.selectedDifficulty = newDiff;
        }

        $scope.initializeGame = function () {
            console.log('Initializing the game...');
            updateGrid($scope.selectedSize, $scope.selectedSize);
            $scope.playing = true;
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
            var cells = angular.element($('.cell'));

            var min = Math.min(window.innerWidth, window.innerHeight) / ($scope.selectedSize + 1);
            var max = $scope.selectedSize


            cells.each(function (index, cell) {
                cell.style.width = 100.0 / max + "%";
                cell.style.height = 100.0 / max + "%";
                //cell.style.height = min + 'px';
                //cell.style.width = min + 'px';
            });
        }


    }


    return CardinalityController;
});