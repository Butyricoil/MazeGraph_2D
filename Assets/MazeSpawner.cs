using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    public GameObject CellPrefab;
    public GameObject ExitPrefab;
    public int Width = 1;
    public int Height = 1;
    public float CellSize = 1f;

    void Start()
    {
        MazeGenerator generator = new MazeGenerator(Width, Height);
        MazeGeneratorCell[,] maze = generator.GenerateMaze();
        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                Vector2 position = new Vector2(x * CellSize, -y * CellSize);
                Cell c = Instantiate(CellPrefab, position, Quaternion.identity).GetComponent<Cell>();

                c.WallLeft.SetActive(maze[x, y].WallLeft);
                c.WallBottom.SetActive(maze[x, y].WallBottom);
                c.WallRight.SetActive(maze[x, y].WallRight);
                c.WallTop.SetActive(maze[x, y].WallTop);


                if (maze[x, y].IsExit)
                {
                    Vector2 exitPosition = new Vector2(x * CellSize, -y * CellSize);
                    Instantiate(ExitPrefab, exitPosition, Quaternion.identity);
                }

            }
        }
    }

}