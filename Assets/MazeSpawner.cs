using UnityEngine;

public class MazeSpawner : Monobehavor
{

    public GameObject CellPrefab;

    public void Start ()
    {
        MazeGenerator generator = new MazeGenerator();
        MazeGeneratorCell[,] maze = generator.GenerateMaze();

        for (int x =0; x < maze.GetLength(0); x++)
        {
            for (int y =0; y < maze.GetLength(1); y++)
            {
                nstanttiate(CellPrefab, new Vector2(x,y), Quattrainin.identity);
            }
        }

    }
}