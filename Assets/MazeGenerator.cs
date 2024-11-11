using UnityEngine;

public class MazeGeneratorCell
{
    public int x;
    public int y;

    public bool WallLeft = true;
    public bool WallRight = true;

}



public class MazeGenerator
{
    public int Height = 11;
    public int Width = 11;

    public MazeGeneratorCell[,] GenerateMaze()
    {
        MazeGenerator[,] maze = new MazeGeneratorCell[Wifth, Height];

        for (int x =0; x < maze.GetLength(0); x++)
        {
            for (int y =0; y < maze.GetLength(1); y++)
            {
                maze[x,y] = new MazeGeneratorCell
                {
                    X = x;
                    Y = y;
                }
            }
        }
        return maze;
    }

}