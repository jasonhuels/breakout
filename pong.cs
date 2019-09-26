using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static char[,] screen = new char[30, 50];
    const char ball = (char)9673;//12295;
    const char brick = (char)9608;
    const char paddle = (char)9600;
    const char leftWall = (char)9612;
     const char rightWall = (char)9616;
    const char background = (char)65532;
    static int[] ballPosition = {15, 25};
    static int[] paddlePosition = {24, 25, 26};
    static int[] BallSpeed = {1,0};
    static void Main()
    {
        bool playing = true;
        InitBoard();
        DrawBoard();
        ConsoleKeyInfo cki = Console.ReadKey(true);
        while(playing)
        {
            Thread.Sleep(120);
            MoveBall(ballPosition, BallSpeed);
            DrawBoard();                 
            
            if(Console.KeyAvailable)
            {  
                if(cki.KeyChar == 'q')
                {
                    playing = false;
                }
                if((int)cki.Key == 37)
                {
                    MovePaddle(-1);
                        
                }
                if((int)cki.Key == 39)
                {
                    MovePaddle(1);
                }
                cki = Console.ReadKey(true);                            
            } 
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
        screen[15, 25] = ball;
    }

    static void DrawBoard()
    {
        Console.Clear();
        screen[29, paddlePosition[0]] = paddle;
        screen[29, paddlePosition[1]] = paddle;
        screen[29, paddlePosition[2]] = paddle;
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
                if(newPos[1] == paddlePosition[0])
                {
                    BallSpeed[0] = -1;
                    BallSpeed[1] = -1;
                    MoveBall(ballPosition, BallSpeed); 
                } 
                else if(newPos[1] == paddlePosition[1])
                {
                    BallSpeed[0] = -1;
                    BallSpeed[1] = 0;
                    MoveBall(ballPosition, BallSpeed); 
                }
                else if(newPos[1] == paddlePosition[2])
                {
                    BallSpeed[0] = -1;
                    BallSpeed[1] = 1;
                    MoveBall(ballPosition, BallSpeed); 
                } else {
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
        if(newPos[1] == 1)
        {
            BallSpeed[1] = 1;
        } else if(newPos[1] == screen.GetLength(1)-2)
        {
            BallSpeed[1] = -1;
        }
    }

    static void MovePaddle(int direction)
    {
        if(paddlePosition[0]+direction >0 && paddlePosition[2]+direction < screen.GetLength(1)-1)
        {
            screen[29, paddlePosition[0]] = background;
            screen[29, paddlePosition[1]] = background;
            screen[29, paddlePosition[2]] = background;
            paddlePosition[0] += direction;
            paddlePosition[1] += direction;
            paddlePosition[2] += direction;
            screen[29, paddlePosition[0]] = paddle;
            screen[29, paddlePosition[1]] = paddle;
            screen[29, paddlePosition[2]] = paddle;
        }
    }
}