using System;


namespace Chess3
{
    class GameController
    {
        private bool gameOver;
        private Board board;
        private Player player1;
        private Player player2;

        public void start()
        {
            const bool topPlayer = true;
            gameOver = false;
            board = new Board();
            player1 = new Player(!topPlayer, board);
            player2 = new Player(topPlayer, board);
          
            run();
        }


        private void run()
        {
            Player currentPlayer = player1;
            
            Console.WriteLine("Enter moves by entering 0 - 7 for x index and 0 - 7 for y index seperated by a space, with position from to position seperated by a -");
            Console.WriteLine("For example, 0 1 - 0 2, would move white pawn from position 0 1 to position 0 2");
            Console.WriteLine("Enter d , at any time to draw board");
            board.printSelf();

            while (!gameOver)
            {
                var gotUserMove = false;

                while (!gotUserMove)
                {
                    Console.Write(currentPlayer.getColor() + " turn enter move: ");
                    var input = Console.ReadLine();

                    if (input.Equals("d"))
                    {
                        board.printSelf();
                    }
                    else
                    {
                        Tuple<int, int, int, int> userMove = translatePlayerMove(sanitizePlayerInput(input));

                        if (userMove == null || !currentPlayer.move(userMove))
                        {
                            Console.WriteLine("Bad Move!");
                        }
                        else
                        {
                            board.printSelf();

                            if (currentPlayer == player1)
                            {
                                currentPlayer = player2;
                            }
                            else
                            {
                                currentPlayer = player1;
                            }

                            gameOver = board.isGameOver();
                            gotUserMove = true;
                        }


                    }

                 
                }
             
            }



        }

        private Tuple<int, int, int, int> sanitizePlayerInput(string i)
        {
            //0 1 - 0 2
            try
            {
                string[] inputSplit = i.Split(" ");
                string x1 = inputSplit[0];
                string y1 = inputSplit[1];
                string x2 = inputSplit[3];
                string y2 = inputSplit[4];

                return new Tuple<int, int, int, int>(Int32.Parse(x1), Int32.Parse(y1), Int32.Parse(x2), Int32.Parse(y2));
            }
            catch 
            {
                Console.WriteLine("Invalid ars!");
                return null;
            }



        }

        //to the eye of the player the 0,0 pos starts at the lower left hand of the board, but to the computer it starts at the upper left hand
        private Tuple<int, int, int, int> translatePlayerMove(Tuple<int, int, int, int> move)
        {
            //the X should not change
            int fromX = move.Item1;

            //the Y should be pushed up by the height of the board - 1
            int fromY = (Board.HEIGHT - 1) - move.Item2;

            int toX = move.Item3;
            int toY = (Board.HEIGHT - 1) - move.Item4;

            return new Tuple<int, int, int, int>(fromX, fromY, toX, toY);
        }
    }
}
