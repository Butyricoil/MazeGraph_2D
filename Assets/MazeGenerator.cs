using System;
using UnityEngine;
using System.Collections.Generic;


public class MazeGenerator
{
    public int Width { get; private set; }
    public int Height { get; private set; }

    public MazeGenerator(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public MazeGeneratorCell[,] GenerateMaze()
    {
        var maze = InitializeMaze();
        GenerateMazeWithBinaryTree(maze);
        SetExit(maze);
        return maze;
    }

    private MazeGeneratorCell[,] InitializeMaze()
    {
        var maze = new MazeGeneratorCell[Width, Height];

        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                maze[x, y] = new MazeGeneratorCell
                {
                    X = x,
                    Y = y
                };
            }
        }
        return maze;
    }

    private void SetExit(MazeGeneratorCell[,] maze)
    {
        maze[Width - 1, Height - 1].IsExit = true;
    }

    private void GenerateMazeWithBinaryTree(MazeGeneratorCell[,] maze)
    {
        var random = new System.Random();

        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                var current = maze[x, y];
                var directions = new List<string>();

                if (x < Width - 1) {directions.Add("Right");}
                if (y < Height - 1) {directions.Add("Down");}

                if (directions.Count > 0)
                {
                    string direction = directions[random.Next(directions.Count)];
                    RemoveWall(current, direction, maze);
                }
            }
        }
    }

    private void RemoveWall(MazeGeneratorCell current, string direction, MazeGeneratorCell[,] maze)
    {
        switch (direction)
        {
            case "Right":
                current.WallRight = false;
                maze[current.X + 1, current.Y].WallLeft = false;
                break;

            case "Down":
                current.WallBottom = false;
                maze[current.X, current.Y + 1].WallTop = false;
                break;
        }
    }
}

public class MazeGeneratorCell
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool WallRight { get; set; } = true;
    public bool WallBottom { get; set; } = true;
    public bool WallLeft { get; set; } = true;
    public bool WallTop { get; set; } = true;
    public bool IsExit { get; set; } = false;
}
