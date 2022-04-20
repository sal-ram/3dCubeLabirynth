using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGeneratorCell
{
    public int X;
    public int Y;

    public bool WallLeft = true;
    public bool WallBottom = true;

    public bool isVisited = false;
}

public class MazeGenerator
{
    private int Width = 10;
    private int Height = 10;

    public MazeGeneratorCell[,] GenerateMaze()
    {
        MazeGeneratorCell[,,] mazeCube = new MazeGeneratorCell[Width, Height, 10];

        MazeGeneratorCell[,] maze = new MazeGeneratorCell[Width, Height];

        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                maze[x, y] = new MazeGeneratorCell { X = x, Y = y };
            }
        }

        RemoveWallsWithTracker(maze);

        for (int x = 0; x < Width; x++)
        {
            maze[x, Height - 1].WallLeft = false;
        }

        for (int y = 0; y < Height; y++)
        {
            maze[Width - 1, y].WallBottom = false;
        }

        return maze;
    }

    void RemoveWallsWithTracker(MazeGeneratorCell[,] maze)
    {
        Stack<MazeGeneratorCell> stack = new Stack<MazeGeneratorCell>();

        MazeGeneratorCell current = maze[0, 0];

        current.isVisited = true;

        do
        {
            List<MazeGeneratorCell> UnvisitedNeighbors = new List<MazeGeneratorCell>();
            int x = current.X;
            int y = current.Y;

            if (x > 0 && !maze[x - 1, y].isVisited) UnvisitedNeighbors.Add(maze[x - 1, y]);
            if (x < Width - 2 && !maze[x + 1, y].isVisited) UnvisitedNeighbors.Add(maze[x + 1, y]);
            if (y > 0 && !maze[x, y - 1].isVisited) UnvisitedNeighbors.Add(maze[x, y - 1]);
            if (y< Height - 2 && !maze[x, y+ 1].isVisited) UnvisitedNeighbors.Add(maze[x, y + 1]);

            if (UnvisitedNeighbors.Count > 0)
            {
                MazeGeneratorCell chosen = UnvisitedNeighbors[Random.Range(0, UnvisitedNeighbors.Count)];
                RemoveWall(current, chosen);

                chosen.isVisited = true;
                current = chosen;
                stack.Push(chosen);
            }
            else 
            {
                current = stack.Pop();
            }
        }
        while (stack.Count > 0);
    }

    private void RemoveWall(MazeGeneratorCell current, MazeGeneratorCell chosen)
    {
        if (current.X == chosen.X)
        {
            if (current.Y > chosen.Y)
            {
                current.WallBottom = false;
            }
            else
            {
                chosen.WallBottom = false;
            }
        }
        else
        {
            if (current.X > chosen.X)
            {
                current.WallLeft = false;
            }
            else
            {
                chosen.WallLeft= false;
            }
        }
    }
}
