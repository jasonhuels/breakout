using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static char[,] screen = new char[30, 50];
    const char ball = (char)79;//9673;//12295;
    const char brick = (char)9608;
    const char paddle = (char)9600;
    const char leftWall = (char)9612;
     const char rightWall = (char)9616;
    const char background = (char)183;//65532;
    static int[] ballPosition = {15, 25};
    static int[] paddlePosition = {23, 24, 25, 26, 27};
    static int[] BallSpeed = {1,0};
    static bool playing = true;
    static void Main()
    {
        
        InitBoard();
        DrawBoard();
        while(playing)
        {
            if(Console.KeyAvailable)
            {
                GameLoop();
            }
        }

    }

    static void FlushKeyboard()
{
    while (Console.In.Peek() != -1)
        Console.In.Read();
}
    
    static void GameLoop()
    {
        ConsoleKeyInfo cki = Console.ReadKey(true);
        bool move = true;
        while(!Console.KeyAvailable)
        { 
            if(!Console.KeyAvailable)
            {  
                if(cki.KeyChar == 'q')
                {
                    playing = false;
                }
                else if(move && cki.Key.ToString() == "LeftArrow")
                {
                    MovePaddle(-2); 
                    move = false;    
                }
                 else if(move && cki.Key.ToString() == "RightArrow")
                {
                    MovePaddle(2);
                    move = false;
                }                        
            } 
            Thread.Sleep(100);
            MoveBall(ballPosition, BallSpeed);
            DrawBoard();                 
            
            
        } 
    }

    static void InitBoard()
    {
        for(int i=0; i<screen.GetLength(0); i++) 
        {
            for(int j=0; j<screen.GetLength(1); j++)
            {
                if(j == 0)
                {
                    screen[i, j] = rightWall;
                }
                else if(j == screen.GetLength(1)-1)
                {
                    screen[i, j] = leftWall;
                }
                else
                {
                    screen[i, j] = background;
                }          
            }
        }
        screen[29, paddlePosition[0]] = paddle;
        screen[29, paddlePosition[1]] = paddle;
        screen[29, paddlePosition[2]] = paddle;
        screen[29, paddlePosition[3]] = paddle;
        screen[29, paddlePosition[4]] = paddle;
        screen[15, 25] = ball;

                screen[4, 15] = brick;
        screen[4, 16] = brick;
        screen[4, 18] = brick;
        screen[4, 19] = brick;
        screen[4, 21] = brick;
        screen[4, 22] = brick;
        screen[4, 24] = brick;
        screen[4, 25] = brick;
        screen[4, 27] = brick;
        screen[4, 28] = brick;
        screen[4, 30] = brick;
        screen[4, 31] = brick;
        screen[4, 33] = brick;
        screen[4, 34] = brick;

        screen[6, 15] = brick;
        screen[6, 16] = brick;
        screen[6, 18] = brick;
        screen[6, 19] = brick;
        screen[6, 21] = brick;
        screen[6, 22] = brick;
        screen[6, 24] = brick;
        screen[6, 25] = brick;
        screen[6, 27] = brick;
        screen[6, 28] = brick;
        screen[6, 30] = brick;
        screen[6, 31] = brick;
        screen[6, 33] = brick;
        screen[6, 34] = brick;

        screen[8, 15] = brick;
        screen[8, 16] = brick;
        screen[8, 18] = brick;
        screen[8, 19] = brick;
        screen[8, 21] = brick;
        screen[8, 22] = brick;
        screen[8, 24] = brick;
        screen[8, 25] = brick;
        screen[8, 27] = brick;
        screen[8, 28] = brick;
        screen[8, 30] = brick;
        screen[8, 31] = brick;
        screen[8, 33] = brick;
        screen[8, 34] = brick;

        screen[10, 15] = brick;
        screen[10, 16] = brick;
        screen[10, 18] = brick;
        screen[10, 19] = brick;
        screen[10, 21] = brick;
        screen[10, 22] = brick;
        screen[10, 24] = brick;
        screen[10, 25] = brick;
        screen[10, 27] = brick;
        screen[10, 28] = brick;
        screen[10, 30] = brick;
        screen[10, 31] = brick;
        screen[10, 33] = brick;
        screen[10, 34] = brick;
    }

    static void DrawBoard()
    {
        Console.Clear();
        screen[29, paddlePosition[0]] = paddle;
        screen[29, paddlePosition[1]] = paddle;
        screen[29, paddlePosition[2]] = paddle;
        screen[29, paddlePosition[3]] = paddle;
        screen[29, paddlePosition[4]] = paddle;

        string boardString = "\r";
        for(int i=0; i<screen.GetLength(0); i++) 
        {
            for(int j=0; j<screen.GetLength(1); j++)
            {
                boardString += screen[i,j];
            }
            boardString += "\n";
        }
        Console.WriteLine(boardString);
    }

    static void MoveBall(int[] currentLocation, int[] speed)
    {
        int[] newPos = {currentLocation[0] + speed[0], currentLocation[1] + speed[1]};
        if(newPos[0] >= 0 && newPos[0] < screen.GetLength(0))
        {
            if(newPos[0] == screen.GetLength(0)-1)
            {
                if(newPos[1] == paddlePosition[0]-1)
                {
                    BallSpeed[0] = -1;
                    BallSpeed[1] = -4;
                    MoveBall(ballPosition, BallSpeed); 
                }
                else if(newPos[1] == paddlePosition[0])
                {
                    BallSpeed[0] = -1;
                    BallSpeed[1] = -2;
                    MoveBall(ballPosition, BallSpeed); 
                }
                else if(newPos[1] == paddlePosition[1])
                {
                    BallSpeed[0] = -1;
                    BallSpeed[1] = -1;
                    MoveBall(ballPosition, BallSpeed); 
                } 
                else if(newPos[1] == paddlePosition[2])
                {
                    BallSpeed[0] = -1;
                    BallSpeed[1] = 0;
                    MoveBall(ballPosition, BallSpeed); 
                }
                else if(newPos[1] == paddlePosition[3])
                {
                    BallSpeed[0] = -1;
                    BallSpeed[1] = 1;
                    MoveBall(ballPosition, BallSpeed); 
                } 
                else if(newPos[1] == paddlePosition[4])
                {
                    BallSpeed[0] = -1;
                    BallSpeed[1] = 2;
                    MoveBall(ballPosition, BallSpeed); 
                } 
                else if(newPos[1] == paddlePosition[4]+1)
                {
                    BallSpeed[0] = -1;
                    BallSpeed[1] = 4;
                    MoveBall(ballPosition, BallSpeed); 
                } 
                else {
                    // Destroy ball
                }
            }
            else if(newPos[0] == 0)
            {
                BallSpeed[0] = 1;

                MoveBall(ballPosition, BallSpeed); 
            }
            else 
            {
                screen[newPos[0], newPos[1]] = ball;
                screen[currentLocation[0], currentLocation[1]] = background;
                ballPosition = newPos;
            }
            
        } 
        if(newPos[1] <= Math.Abs(BallSpeed[1]))
        {
            BallSpeed[1] = BallSpeed[1]*-1;
        } else if(newPos[1] >= screen.GetLength(1)-Math.Abs(BallSpeed[1]+1))
        {
            BallSpeed[1] = BallSpeed[1]*-1;
        }
    }

    static void MovePaddle(int direction)
    {
        if(paddlePosition[0]+direction >0 && paddlePosition[4]+direction < screen.GetLength(1)-1)
        {
            screen[29, paddlePosition[0]] = background;
            screen[29, paddlePosition[1]] = background;
            screen[29, paddlePosition[2]] = background;
            screen[29, paddlePosition[3]] = background;
            screen[29, paddlePosition[4]] = background;
            
            paddlePosition[0] += direction;
            paddlePosition[1] += direction;
            paddlePosition[2] += direction;
            paddlePosition[3] += direction;
            paddlePosition[4] += direction;
            screen[29, paddlePosition[0]] = paddle;
            screen[29, paddlePosition[1]] = paddle;
            screen[29, paddlePosition[2]] = paddle;
            screen[29, paddlePosition[3]] = paddle;
            screen[29, paddlePosition[4]] = paddle;
        }
    }
}