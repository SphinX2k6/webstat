using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x020051BF RID: 20927
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeTalentTreeViewModel
	{
		// Token: 0x06035CDA RID: 220378 RVA: 0x00D88BB0 File Offset: 0x00D86DB0
		public void Init(int seasonId)
		{
			this.SeasonId = seasonId;
			List<RogueTalentTree> list = ConfigCommon.ToList<RogueTalentTree>(ConfigBase<RoguelikeConfig>.Instance.GetRogueTalentTreeConfig());
			if (list == null)
			{
				return;
			}
			List<RogueTalentTree> list2 = new List<RogueTalentTree>();
			foreach (RogueTalentTree item in list)
			{
				if (item.SeasonId == seasonId)
				{
					list2.Add(item);
				}
			}
			list = list2;
			foreach (RogueTalentTree rogueTalentTree in list)
			{
				RoguelikeTalentTreeNodeData roguelikeTalentTreeNodeData = new RoguelikeTalentTreeNodeData(rogueTalentTree.Id);
				List<RoguelikeTalentTreeNodeData> list3;
				if (!this.NodeRowMap.TryGetValue(roguelikeTalentTreeNodeData.Row, out list3))
				{
					list3 = new List<RoguelikeTalentTreeNodeData>();
				}
				list3.Add(roguelikeTalentTreeNodeData);
				this.NodeRowMap[roguelikeTalentTreeNodeData.Row] = list3;
				this.NodeIdMap[roguelikeTalentTreeNodeData.Id] = roguelikeTalentTreeNodeData;
				this.MaxRow = Math.Max(this.MaxRow, roguelikeTalentTreeNodeData.Row);
			}
			this.RefreshLineTypeMap();
			foreach (KeyValuePair<int, List<RoguelikeTalentTreeNodeData>> keyValuePair in this.NodeRowMap)
			{
				int num;
				List<RoguelikeTalentTreeNodeData> list4;
				keyValuePair.Deconstruct(out num, out list4);
				int row = num;
				List<RoguelikeTalentTreeNodeData> list5 = list4;
				list5.Sort((RoguelikeTalentTreeNodeData a, RoguelikeTalentTreeNodeData b) => a.Index - b.Index);
				this.RowDataList.Add(new RoguelikeTalentTreeNodeRowData(row, list5));
			}
			this.RowDataList.Sort((RoguelikeTalentTreeNodeRowData a, RoguelikeTalentTreeNodeRowData b) => a.Row - b.Row);
		}

		// Token: 0x06035CDB RID: 220379 RVA: 0x00D88D94 File Offset: 0x00D86F94
		private List<RoguelikeTalentTreeNodeData> GetPostNodesByNodeData(RoguelikeTalentTreeNodeData node)
		{
			List<RoguelikeTalentTreeNodeData> list = new List<RoguelikeTalentTreeNodeData>();
			foreach (int key in node.Config.PostIdIter())
			{
				RoguelikeTalentTreeNodeData item;
				if (this.NodeIdMap.TryGetValue(key, out item))
				{
					list.Add(item);
				}
			}
			return list;
		}

		// Token: 0x06035CDC RID: 220380 RVA: 0x00D88E04 File Offset: 0x00D87004
		public RoguelikeTalentTreeNodeData GetDefaultSelectNode()
		{
			RoguelikeTalentTreeNodeData roguelikeTalentTreeNodeData = null;
			RoguelikeTalentTreeNodeData roguelikeTalentTreeNodeData2 = null;
			List<RoguelikeTalentTreeNodeData> list = this.NodeRowMap[this.MaxRow];
			RoguelikeTalentTreeNodeData roguelikeTalentTreeNodeData3 = list[list.Count - 1];
			for (int i = 1; i <= this.MaxRow; i++)
			{
				List<RoguelikeTalentTreeNodeData> list2;
				if (!this.NodeRowMap.TryGetValue(i, out list2))
				{
					list2 = new List<RoguelikeTalentTreeNodeData>();
				}
				foreach (RoguelikeTalentTreeNodeData roguelikeTalentTreeNodeData4 in list2)
				{
					if (roguelikeTalentTreeNodeData4.State != ETalentTreeNodeState.Active)
					{
						if (roguelikeTalentTreeNodeData4.CanAfford() && roguelikeTalentTreeNodeData4.State == ETalentTreeNodeState.Unlock)
						{
							roguelikeTalentTreeNodeData = roguelikeTalentTreeNodeData4;
						}
						if ((roguelikeTalentTreeNodeData4.State == ETalentTreeNodeState.Lock || !roguelikeTalentTreeNodeData4.CanAfford()) && roguelikeTalentTreeNodeData2 == null)
						{
							roguelikeTalentTreeNodeData2 = roguelikeTalentTreeNodeData4;
						}
					}
				}
			}
			RoguelikeTalentTreeNodeData result;
			if ((result = roguelikeTalentTreeNodeData) == null)
			{
				result = (roguelikeTalentTreeNodeData2 ?? roguelikeTalentTreeNodeData3);
			}
			return result;
		}

		// Token: 0x06035CDD RID: 220381 RVA: 0x00D88EE4 File Offset: 0x00D870E4
		public bool IsDotVisible(int row, int index)
		{
			List<RoguelikeTalentTreeNodeData> list;
			if (this.NodeRowMap.TryGetValue(row, out list))
			{
				using (List<RoguelikeTalentTreeNodeData>.Enumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.Index == index)
						{
							return true;
						}
					}
				}
			}
			List<RoguelikeTalentTreeNodeData> list2;
			if (this.NodeRowMap.TryGetValue(row + 1, out list2))
			{
				using (List<RoguelikeTalentTreeNodeData>.Enumerator enumerator = list2.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.Index == index)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06035CDE RID: 220382 RVA: 0x00D88F9C File Offset: 0x00D8719C
		private List<Tuple<int, int>> GetPath(RoguelikeTalentTreeNodeData from, RoguelikeTalentTreeNodeData to)
		{
			List<Tuple<int, int>> list = new List<Tuple<int, int>>();
			for (int i = from.Row + 1; i < to.Row; i++)
			{
				list.Add(Tuple.Create<int, int>(i, to.Index + 6));
			}
			list.Add(Tuple.Create<int, int>(from.Row, from.Index + 12));
			list.Add(Tuple.Create<int, int>(to.Row, to.Index));
			int num = Math.Max(from.Index, to.Index);
			for (int j = Math.Min(from.Index, to.Index); j < num; j++)
			{
				list.Add(Tuple.Create<int, int>(from.Row, j + 18));
			}
			return list;
		}

		// Token: 0x06035CDF RID: 220383 RVA: 0x00D89050 File Offset: 0x00D87250
		private bool GetPathActive(RoguelikeTalentTreeNodeData from, RoguelikeTalentTreeNodeData to)
		{
			return from.State == ETalentTreeNodeState.Active && to.State == ETalentTreeNodeState.Active;
		}

		// Token: 0x06035CE0 RID: 220384 RVA: 0x00D89068 File Offset: 0x00D87268
		public void RefreshLineTypeMap()
		{
			foreach (Dictionary<int, bool> dictionary in this.LineActiveMap)
			{
				dictionary.Clear();
			}
			foreach (int key in this.NodeRowMap.Keys)
			{
				List<RoguelikeTalentTreeNodeData> list;
				if (this.NodeRowMap.TryGetValue(key, out list))
				{
					foreach (RoguelikeTalentTreeNodeData roguelikeTalentTreeNodeData in list)
					{
						foreach (RoguelikeTalentTreeNodeData to in this.GetPostNodesByNodeData(roguelikeTalentTreeNodeData))
						{
							List<Tuple<int, int>> path = this.GetPath(roguelikeTalentTreeNodeData, to);
							bool pathActive = this.GetPathActive(roguelikeTalentTreeNodeData, to);
							foreach (Tuple<int, int> tuple in path)
							{
								while (this.LineActiveMap.Count <= tuple.Item1)
								{
									this.LineActiveMap.Add(new Dictionary<int, bool>());
								}
								Dictionary<int, bool> dictionary2 = this.LineActiveMap[tuple.Item1];
								if (!dictionary2.ContainsKey(tuple.Item2) || !dictionary2[tuple.Item2])
								{
									dictionary2[tuple.Item2] = pathActive;
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06035CE1 RID: 220385 RVA: 0x00D89288 File Offset: 0x00D87488
		public void SelectNode(RoguelikeTalentTreeNodeData node)
		{
			if (node == null || (this.CurSelectNode != null && this.CurSelectNode.Id == node.Id))
			{
				return;
			}
			this.CurSelectNode = node;
		}

		// Token: 0x0401EDC9 RID: 126409
		public int SeasonId;

		// Token: 0x0401EDCA RID: 126410
		public int MaxRow;

		// Token: 0x0401EDCB RID: 126411
		public Dictionary<int, List<RoguelikeTalentTreeNodeData>> NodeRowMap = new Dictionary<int, List<RoguelikeTalentTreeNodeData>>();

		// Token: 0x0401EDCC RID: 126412
		public Dictionary<int, RoguelikeTalentTreeNodeData> NodeIdMap = new Dictionary<int, RoguelikeTalentTreeNodeData>();

		// Token: 0x0401EDCD RID: 126413
		public List<RoguelikeTalentTreeNodeRowData> RowDataList = new List<RoguelikeTalentTreeNodeRowData>();

		// Token: 0x0401EDCE RID: 126414
		public Dictionary<int, RoguelikeTalentTreeNodeRowData> RowDataMap = new Dictionary<int, RoguelikeTalentTreeNodeRowData>();

		// Token: 0x0401EDCF RID: 126415
		public List<Dictionary<int, bool>> LineActiveMap = new List<Dictionary<int, bool>>();

		// Token: 0x0401EDD0 RID: 126416
		[Nullable(2)]
		public RoguelikeTalentTreeNodeData CurSelectNode;

		// Token: 0x0401EDD1 RID: 126417
		public Action<bool, RoguelikeTalentTreeNodeData> OnClickNode;
	}
}
