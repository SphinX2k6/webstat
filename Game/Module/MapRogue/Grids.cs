using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005927 RID: 22823
	[NullableContext(1)]
	[Nullable(0)]
	public class Grids
	{
		// Token: 0x06039EB1 RID: 237233 RVA: 0x00EA9490 File Offset: 0x00EA7690
		public Grids(IGridsConstructor gridsData)
		{
			this.Width = gridsData.Width;
			this.Height = gridsData.Height;
			this.GridNodes = new List<List<Node>>();
			int num = 0;
			for (int i = 0; i < this.Height; i++)
			{
				List<Node> list = new List<Node>();
				for (int j = 0; j < this.Width; j++)
				{
					IPathNode pathNode = gridsData.Matrix[num];
					Node item = new Node(new NodeConstructor
					{
						GridId = num,
						Position = new Pos
						{
							X = j,
							Y = i
						},
						Cost = pathNode.Cost,
						Walkable = pathNode.Walkable
					});
					list.Add(item);
					num++;
				}
				this.GridNodes.Add(list);
			}
		}

		// Token: 0x06039EB2 RID: 237234 RVA: 0x00EA956D File Offset: 0x00EA776D
		public Node GetNodeAt(IPos position)
		{
			return this.GridNodes[position.Y][position.X];
		}

		// Token: 0x06039EB3 RID: 237235 RVA: 0x00EA958C File Offset: 0x00EA778C
		public Node GetNodeByIndex(int index)
		{
			int width = this.Width;
			int index2 = index % width;
			int index3 = (int)Math.Floor((double)index / (double)width);
			return this.GridNodes[index3][index2];
		}

		// Token: 0x06039EB4 RID: 237236 RVA: 0x00EA95C2 File Offset: 0x00EA77C2
		public bool IsWalkableAt(IPos position)
		{
			return this.GridNodes[position.Y][position.X].IsWalkable;
		}

		// Token: 0x06039EB5 RID: 237237 RVA: 0x00EA95E5 File Offset: 0x00EA77E5
		private bool IsOnTheGrid(IPos position)
		{
			return position.X >= 0 && position.X < this.Width && position.Y >= 0 && position.Y < this.Height;
		}

		// Token: 0x06039EB6 RID: 237238 RVA: 0x00EA9618 File Offset: 0x00EA7818
		public List<Node> GetSurroundingNodes(IPos currentPosition)
		{
			List<Node> list = new List<Node>();
			Pos pos = new Pos
			{
				X = currentPosition.X,
				Y = currentPosition.Y + 1
			};
			Pos pos2 = new Pos
			{
				X = currentPosition.X + 1,
				Y = currentPosition.Y
			};
			Pos pos3 = new Pos
			{
				X = currentPosition.X,
				Y = currentPosition.Y - 1
			};
			Pos pos4 = new Pos
			{
				X = currentPosition.X - 1,
				Y = currentPosition.Y
			};
			foreach (IPos position in new IPos[]
			{
				pos,
				pos2,
				pos3,
				pos4
			})
			{
				if (this.IsOnTheGrid(position) && this.IsWalkableAt(position))
				{
					list.Add(this.GetNodeAt(position));
				}
			}
			return list;
		}

		// Token: 0x06039EB7 RID: 237239 RVA: 0x00EA9704 File Offset: 0x00EA7904
		public void ResetGrids()
		{
			foreach (List<Node> list in this.GridNodes)
			{
				foreach (Node node in list)
				{
					node.IsOnClosedList = false;
					node.IsOnOpenList = false;
					node.ParentNode = null;
					node.SetValueToZero();
				}
			}
		}

		// Token: 0x04020CFF RID: 134399
		public int Width;

		// Token: 0x04020D00 RID: 134400
		public int Height;

		// Token: 0x04020D01 RID: 134401
		public List<List<Node>> GridNodes = new List<List<Node>>();
	}
}
