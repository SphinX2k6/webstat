using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020034D6 RID: 13526
[NullableContext(1)]
[Nullable(0)]
public class TaskGraphVisualizer
{
	// Token: 0x0601C929 RID: 117033 RVA: 0x00890224 File Offset: 0x0088E424
	public TaskGraphVisualizer([Nullable(new byte[]
	{
		1,
		0,
		1,
		1
	})] List<ValueTuple<string, string>> dependencies)
	{
		this.Dependencies = dependencies;
		if (this.Dependencies.Count == 0)
		{
			throw new Exception("依赖列表不能为空");
		}
	}

	// Token: 0x0601C92A RID: 117034 RVA: 0x00890278 File Offset: 0x0088E478
	private void BuildGraph()
	{
		foreach (ValueTuple<string, string> valueTuple in this.Dependencies)
		{
			string item = valueTuple.Item1;
			string item2 = valueTuple.Item2;
			if (!this.Graph.ContainsKey(item))
			{
				this.Graph[item] = new GraphNodeInfo();
			}
			if (!this.Graph.ContainsKey(item2))
			{
				this.Graph[item2] = new GraphNodeInfo();
			}
			GraphNodeInfo graphNodeInfo = this.Graph[item];
			if (!graphNodeInfo.Children.Contains(item2))
			{
				graphNodeInfo.Children.Add(item2);
			}
			GraphNodeInfo graphNodeInfo2 = this.Graph[item2];
			if (!graphNodeInfo2.Parents.Contains(item))
			{
				graphNodeInfo2.Parents.Add(item);
			}
		}
	}

	// Token: 0x0601C92B RID: 117035 RVA: 0x00890368 File Offset: 0x0088E568
	private void CalculateLevels()
	{
		TaskGraphVisualizer.<>c__DisplayClass6_0 CS$<>8__locals1;
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.nodeLevels = new Dictionary<string, int>();
		foreach (KeyValuePair<string, GraphNodeInfo> keyValuePair in this.Graph)
		{
			if (!CS$<>8__locals1.nodeLevels.ContainsKey(keyValuePair.Key))
			{
				this.<CalculateLevels>g__Dfs|6_0(keyValuePair.Key, ref CS$<>8__locals1);
			}
		}
		int num = -1;
		foreach (int num2 in CS$<>8__locals1.nodeLevels.Values)
		{
			if (num2 > num)
			{
				num = num2;
			}
		}
		this.Levels = new List<List<string>>();
		for (int i = 0; i <= num; i++)
		{
			this.Levels.Add(new List<string>());
		}
		foreach (KeyValuePair<string, int> keyValuePair2 in CS$<>8__locals1.nodeLevels)
		{
			this.Levels[keyValuePair2.Value].Add(keyValuePair2.Key);
		}
		List<List<string>> list = new List<List<string>>();
		for (int j = this.Levels.Count - 1; j >= 0; j--)
		{
			if (this.Levels[j].Count > 0)
			{
				list.Add(this.Levels[j]);
			}
		}
		this.Levels = list;
	}

	// Token: 0x0601C92C RID: 117036 RVA: 0x00890510 File Offset: 0x0088E710
	private void CalculateLayout()
	{
		List<int> list = new List<int>();
		foreach (List<string> list2 in this.Levels)
		{
			int num = 0;
			foreach (string text in list2)
			{
				num += text.Length + 4;
			}
			list.Add(num);
		}
		int num2 = 10;
		foreach (int num3 in list)
		{
			if (num3 > num2)
			{
				num2 = num3;
			}
		}
		for (int i = 0; i < this.Levels.Count; i++)
		{
			List<string> list3 = this.Levels[i];
			int num4 = 0;
			foreach (string text2 in list3)
			{
				num4 += text2.Length + 4;
			}
			int num5 = (num2 - num4) / 2;
			num5 = Math.Max(num5, 0);
			foreach (string text3 in list3)
			{
				int length = text3.Length;
				this.NodePositions[text3] = new NodePosition
				{
					X = num5 + (int)Math.Ceiling((double)length / 2.0),
					Y = i * 3,
					Width = length
				};
				num5 += length + 4;
			}
		}
	}

	// Token: 0x0601C92D RID: 117037 RVA: 0x00890708 File Offset: 0x0088E908
	private string[][] GenerateGrid()
	{
		int num = this.Levels.Count * 3 + 2;
		int num2 = 10;
		foreach (List<string> list in this.Levels)
		{
			foreach (string text in list)
			{
				int num3 = this.NodePositions[text].X + (int)Math.Ceiling((double)text.Length / 2.0) + 2;
				if (num3 > num2)
				{
					num2 = num3;
				}
			}
		}
		string[][] array = new string[num][];
		for (int i = 0; i < num; i++)
		{
			array[i] = new string[num2];
			for (int j = 0; j < num2; j++)
			{
				array[i][j] = " ";
			}
		}
		return array;
	}

	// Token: 0x0601C92E RID: 117038 RVA: 0x00890814 File Offset: 0x0088EA14
	private void DrawNodes(string[][] grid)
	{
		foreach (KeyValuePair<string, NodePosition> keyValuePair in this.NodePositions)
		{
			string key = keyValuePair.Key;
			NodePosition value = keyValuePair.Value;
			int num = value.X - value.Width / 2;
			for (int i = 0; i < key.Length; i++)
			{
				int num2 = num + i;
				if (num2 >= 0 && num2 < grid[0].Length)
				{
					grid[value.Y][num2] = key[i].ToString();
				}
			}
		}
	}

	// Token: 0x0601C92F RID: 117039 RVA: 0x008908C8 File Offset: 0x0088EAC8
	private void DrawEdges(string[][] grid)
	{
		foreach (ValueTuple<string, string> valueTuple in this.Dependencies)
		{
			string item = valueTuple.Item1;
			string item2 = valueTuple.Item2;
			NodePosition nodePosition = this.NodePositions[item];
			NodePosition nodePosition2 = this.NodePositions[item2];
			int num = Math.Min(nodePosition.Y + 1, grid.Length - 1);
			int num2 = Math.Min(nodePosition2.Y - 1, grid.Length - 1);
			for (int i = num; i <= num2; i++)
			{
				if (nodePosition.X >= 0 && nodePosition.X < grid[0].Length)
				{
					grid[i][nodePosition.X] = ((grid[i][nodePosition.X] == " ") ? "│" : "║");
				}
			}
			int num3 = nodePosition.Y + 1;
			if (num3 < grid.Length)
			{
				int num4 = Math.Min(nodePosition.X, nodePosition2.X);
				int num5 = Math.Max(nodePosition.X, nodePosition2.X);
				for (int j = num4; j <= num5; j++)
				{
					if (j >= 0 && j < grid[0].Length)
					{
						grid[num3][j] = ((j == nodePosition.X) ? "┬" : ((j == nodePosition2.X) ? "┐" : "─"));
					}
				}
			}
			if (nodePosition2.Y - 1 >= 0 && nodePosition2.X < grid[0].Length)
			{
				grid[nodePosition2.Y - 1][nodePosition2.X] = "┘";
			}
		}
	}

	// Token: 0x0601C930 RID: 117040 RVA: 0x00890A80 File Offset: 0x0088EC80
	public string Visualize()
	{
		this.BuildGraph();
		this.CalculateLevels();
		this.CalculateLayout();
		string[][] array = this.GenerateGrid();
		this.DrawEdges(array);
		this.DrawNodes(array);
		string text = "\n";
		foreach (string[] value in array)
		{
			string text2 = string.Join("", value);
			text2 = text2.Replace("┬─┐", "┬─┬");
			text2 = text2.Replace("┘", " ");
			text2 = text2.TrimEnd();
			text = text + text2 + "\n";
		}
		return text;
	}

	// Token: 0x0601C931 RID: 117041 RVA: 0x00890B1C File Offset: 0x0088ED1C
	[CompilerGenerated]
	private int <CalculateLevels>g__Dfs|6_0(string node, ref TaskGraphVisualizer.<>c__DisplayClass6_0 A_2)
	{
		if (A_2.nodeLevels.ContainsKey(node))
		{
			return A_2.nodeLevels[node];
		}
		int num = -1;
		foreach (string node2 in this.Graph[node].Parents)
		{
			num = Math.Max(num, this.<CalculateLevels>g__Dfs|6_0(node2, ref A_2));
		}
		int num2 = num + 1;
		A_2.nodeLevels[node] = num2;
		return num2;
	}

	// Token: 0x0400E625 RID: 58917
	private readonly Dictionary<string, GraphNodeInfo> Graph = new Dictionary<string, GraphNodeInfo>();

	// Token: 0x0400E626 RID: 58918
	private List<List<string>> Levels = new List<List<string>>();

	// Token: 0x0400E627 RID: 58919
	private readonly Dictionary<string, NodePosition> NodePositions = new Dictionary<string, NodePosition>();

	// Token: 0x0400E628 RID: 58920
	[Nullable(new byte[]
	{
		1,
		0,
		1,
		1
	})]
	private readonly List<ValueTuple<string, string>> Dependencies;
}
