using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004D9A RID: 19866
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseTalentTreeData
	{
		// Token: 0x0603372A RID: 210730 RVA: 0x00CDE0CC File Offset: 0x00CDC2CC
		public static TrapDefenseTalentTreeData Create(int activityId)
		{
			TrapDefenseTalentTreeData trapDefenseTalentTreeData = new TrapDefenseTalentTreeData();
			trapDefenseTalentTreeData.ActivityId = activityId;
			trapDefenseTalentTreeData.Init();
			return trapDefenseTalentTreeData;
		}

		// Token: 0x0603372B RID: 210731 RVA: 0x00CDE0E0 File Offset: 0x00CDC2E0
		public void SetRemainPoints(int points)
		{
			this.RemainPoints = points;
		}

		// Token: 0x0603372C RID: 210732 RVA: 0x00CDE0E9 File Offset: 0x00CDC2E9
		public void SetMaxPoints(int points)
		{
			this.MaxPoints = points;
		}

		// Token: 0x0603372D RID: 210733 RVA: 0x00CDE0F4 File Offset: 0x00CDC2F4
		private void Init()
		{
			this.RowDataList = new List<TrapDefenseTalentTreeRowData>();
			IReadOnlyList<TrapDefenseTech> trapDefenseTalentTreeConfigByActivityId = ConfigBase<TrapDefenseConfig>.Instance.GetTrapDefenseTalentTreeConfigByActivityId(this.ActivityId);
			if (trapDefenseTalentTreeConfigByActivityId == null)
			{
				return;
			}
			foreach (TrapDefenseTech config in trapDefenseTalentTreeConfigByActivityId)
			{
				TrapDefenseTalentTreeNodeData trapDefenseTalentTreeNodeData = TrapDefenseTalentTreeNodeData.Create(config);
				if (!this.NodeRowMap.ContainsKey(trapDefenseTalentTreeNodeData.Row))
				{
					this.NodeRowMap[trapDefenseTalentTreeNodeData.Row] = new List<TrapDefenseTalentTreeNodeData>();
				}
				this.NodeRowMap[trapDefenseTalentTreeNodeData.Row].Add(trapDefenseTalentTreeNodeData);
				this.NodeIdMap[trapDefenseTalentTreeNodeData.Id] = trapDefenseTalentTreeNodeData;
				this.MaxRow = Math.Max(this.MaxRow, trapDefenseTalentTreeNodeData.Row);
			}
			this.RefreshLineTypeMap();
			foreach (KeyValuePair<int, List<TrapDefenseTalentTreeNodeData>> keyValuePair in this.NodeRowMap)
			{
				int key = keyValuePair.Key;
				List<TrapDefenseTalentTreeNodeData> value = keyValuePair.Value;
				value.Sort((TrapDefenseTalentTreeNodeData a, TrapDefenseTalentTreeNodeData b) => a.Index.CompareTo(b.Index));
				this.RowDataList.Add(TrapDefenseTalentTreeRowData.Create(key, value));
			}
			this.RowDataList.Sort((TrapDefenseTalentTreeRowData a, TrapDefenseTalentTreeRowData b) => a.Row.CompareTo(b.Row));
		}

		// Token: 0x0603372E RID: 210734 RVA: 0x00CDE27C File Offset: 0x00CDC47C
		public List<TrapDefenseTalentTreeNodeData> GetNodeDataListByRow(int row)
		{
			if (this.NodeRowMap.ContainsKey(row))
			{
				return this.NodeRowMap[row];
			}
			return new List<TrapDefenseTalentTreeNodeData>();
		}

		// Token: 0x0603372F RID: 210735 RVA: 0x00CDE2A0 File Offset: 0x00CDC4A0
		public bool CanNodeUnlock(TrapDefenseTalentTreeNodeData node)
		{
			if (node.IsUnlock)
			{
				return false;
			}
			List<TrapDefenseTalentTreeNodeData> preNodesByNodeData = this.GetPreNodesByNodeData(node);
			if (preNodesByNodeData.Count == 0)
			{
				return true;
			}
			using (List<TrapDefenseTalentTreeNodeData>.Enumerator enumerator = preNodesByNodeData.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (!enumerator.Current.IsUnlock)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06033730 RID: 210736 RVA: 0x00CDE310 File Offset: 0x00CDC510
		public bool CanNodeAfford(TrapDefenseTalentTreeNodeData node)
		{
			List<ICostData> costData = node.GetCostData();
			return costData.Count == 0 || costData[0].Count >= costData[0].Cost;
		}

		// Token: 0x06033731 RID: 210737 RVA: 0x00CDE34C File Offset: 0x00CDC54C
		public bool HasAnyNodeCanUnlockAndAfford()
		{
			foreach (List<TrapDefenseTalentTreeNodeData> list in this.NodeRowMap.Values)
			{
				foreach (TrapDefenseTalentTreeNodeData node in list)
				{
					if (this.CanNodeUnlock(node) && this.CanNodeAfford(node))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06033732 RID: 210738 RVA: 0x00CDE3EC File Offset: 0x00CDC5EC
		public List<TrapDefenseTalentTreeNodeData> GetPreNodesByNodeData(TrapDefenseTalentTreeNodeData node)
		{
			List<TrapDefenseTalentTreeNodeData> list = new List<TrapDefenseTalentTreeNodeData>();
			foreach (int key in node.Config.PreNodeIter())
			{
				if (this.NodeIdMap.ContainsKey(key))
				{
					list.Add(this.NodeIdMap[key]);
				}
			}
			return list;
		}

		// Token: 0x06033733 RID: 210739 RVA: 0x00CDE460 File Offset: 0x00CDC660
		public TrapDefenseTalentTreeNodeData GetDefaultSelectNode()
		{
			TrapDefenseTalentTreeNodeData trapDefenseTalentTreeNodeData = null;
			TrapDefenseTalentTreeNodeData trapDefenseTalentTreeNodeData2 = null;
			List<TrapDefenseTalentTreeNodeData> list = this.NodeRowMap[this.MaxRow];
			TrapDefenseTalentTreeNodeData trapDefenseTalentTreeNodeData3 = list[list.Count - 1];
			for (int i = 1; i <= this.MaxRow; i++)
			{
				foreach (TrapDefenseTalentTreeNodeData trapDefenseTalentTreeNodeData4 in this.GetNodeDataListByRow(i))
				{
					if (this.CanNodeUnlock(trapDefenseTalentTreeNodeData4) && this.CanNodeAfford(trapDefenseTalentTreeNodeData4) && trapDefenseTalentTreeNodeData == null)
					{
						trapDefenseTalentTreeNodeData = trapDefenseTalentTreeNodeData4;
					}
					if ((!this.CanNodeUnlock(trapDefenseTalentTreeNodeData4) || !this.CanNodeAfford(trapDefenseTalentTreeNodeData4)) && trapDefenseTalentTreeNodeData2 == null && !trapDefenseTalentTreeNodeData4.IsUnlock)
					{
						trapDefenseTalentTreeNodeData2 = trapDefenseTalentTreeNodeData4;
					}
				}
			}
			TrapDefenseTalentTreeNodeData result;
			if ((result = trapDefenseTalentTreeNodeData) == null)
			{
				result = (trapDefenseTalentTreeNodeData2 ?? trapDefenseTalentTreeNodeData3);
			}
			return result;
		}

		// Token: 0x06033734 RID: 210740 RVA: 0x00CDE52C File Offset: 0x00CDC72C
		[NullableContext(2)]
		public TrapDefenseTalentTreeNodeData GetDefaultSelectNodeByFuncType(ETrapDefenseTalentFuncType funcType)
		{
			TrapDefenseTalentTreeNodeData trapDefenseTalentTreeNodeData = null;
			TrapDefenseTalentTreeNodeData trapDefenseTalentTreeNodeData2 = null;
			TrapDefenseTalentTreeNodeData trapDefenseTalentTreeNodeData3 = null;
			for (int i = 1; i <= this.MaxRow; i++)
			{
				foreach (TrapDefenseTalentTreeNodeData trapDefenseTalentTreeNodeData4 in this.GetNodeDataListByRow(i))
				{
					if (trapDefenseTalentTreeNodeData4.Config.FuncType == (int)funcType)
					{
						if (trapDefenseTalentTreeNodeData == null)
						{
							trapDefenseTalentTreeNodeData = trapDefenseTalentTreeNodeData4;
						}
						if (this.CanNodeUnlock(trapDefenseTalentTreeNodeData4) && this.CanNodeAfford(trapDefenseTalentTreeNodeData4) && trapDefenseTalentTreeNodeData2 == null)
						{
							trapDefenseTalentTreeNodeData2 = trapDefenseTalentTreeNodeData4;
						}
						if ((!this.CanNodeUnlock(trapDefenseTalentTreeNodeData4) || !this.CanNodeAfford(trapDefenseTalentTreeNodeData4)) && !trapDefenseTalentTreeNodeData4.IsUnlock && trapDefenseTalentTreeNodeData3 == null)
						{
							trapDefenseTalentTreeNodeData3 = trapDefenseTalentTreeNodeData4;
						}
					}
				}
			}
			TrapDefenseTalentTreeNodeData result;
			if ((result = trapDefenseTalentTreeNodeData2) == null)
			{
				result = (trapDefenseTalentTreeNodeData3 ?? trapDefenseTalentTreeNodeData);
			}
			return result;
		}

		// Token: 0x06033735 RID: 210741 RVA: 0x00CDE5F8 File Offset: 0x00CDC7F8
		public bool IsDotVisible(int row, int index)
		{
			using (List<TrapDefenseTalentTreeNodeData>.Enumerator enumerator = this.GetNodeDataListByRow(row).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Index == index)
					{
						return true;
					}
				}
			}
			using (List<TrapDefenseTalentTreeNodeData>.Enumerator enumerator = this.GetNodeDataListByRow(row + 1).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Index == index)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06033736 RID: 210742 RVA: 0x00CDE69C File Offset: 0x00CDC89C
		private List<Tuple<int, int>> GetPath(TrapDefenseTalentTreeNodeData from, TrapDefenseTalentTreeNodeData to)
		{
			List<Tuple<int, int>> list = new List<Tuple<int, int>>();
			for (int i = from.Row + 1; i < to.Row; i++)
			{
				list.Add(new Tuple<int, int>(i, to.Index + 6));
			}
			list.Add(new Tuple<int, int>(from.Row, from.Index + 12));
			list.Add(new Tuple<int, int>(to.Row, to.Index));
			int num = Math.Max(from.Index, to.Index);
			for (int j = Math.Min(from.Index, to.Index); j < num; j++)
			{
				list.Add(new Tuple<int, int>(from.Row, j + 18));
			}
			return list;
		}

		// Token: 0x06033737 RID: 210743 RVA: 0x00CDE750 File Offset: 0x00CDC950
		private ETrapDefenseTalentTreePathType GetPathType(TrapDefenseTalentTreeNodeData from, TrapDefenseTalentTreeNodeData to)
		{
			if (from.IsUnlock && to.IsUnlock)
			{
				return ETrapDefenseTalentTreePathType.Solid;
			}
			return ETrapDefenseTalentTreePathType.Dashed;
		}

		// Token: 0x06033738 RID: 210744 RVA: 0x00CDE768 File Offset: 0x00CDC968
		public void RefreshLineTypeMap()
		{
			foreach (Dictionary<int, ETrapDefenseTalentTreePathType> dictionary in this.LineTypeMap)
			{
				dictionary.Clear();
			}
			foreach (int row in this.NodeRowMap.Keys)
			{
				foreach (TrapDefenseTalentTreeNodeData trapDefenseTalentTreeNodeData in this.GetNodeDataListByRow(row))
				{
					foreach (TrapDefenseTalentTreeNodeData from in this.GetPreNodesByNodeData(trapDefenseTalentTreeNodeData))
					{
						List<Tuple<int, int>> path = this.GetPath(from, trapDefenseTalentTreeNodeData);
						ETrapDefenseTalentTreePathType pathType = this.GetPathType(from, trapDefenseTalentTreeNodeData);
						foreach (Tuple<int, int> tuple in path)
						{
							while (this.LineTypeMap.Count <= tuple.Item1)
							{
								this.LineTypeMap.Add(new Dictionary<int, ETrapDefenseTalentTreePathType>());
							}
							if (!this.LineTypeMap[tuple.Item1].ContainsKey(tuple.Item2) || this.LineTypeMap[tuple.Item1][tuple.Item2] != ETrapDefenseTalentTreePathType.Solid)
							{
								this.LineTypeMap[tuple.Item1][tuple.Item2] = pathType;
							}
						}
					}
				}
			}
		}

		// Token: 0x0401DCE7 RID: 122087
		private int ActivityId;

		// Token: 0x0401DCE8 RID: 122088
		public int MaxRow;

		// Token: 0x0401DCE9 RID: 122089
		public int RemainPoints;

		// Token: 0x0401DCEA RID: 122090
		public int MaxPoints;

		// Token: 0x0401DCEB RID: 122091
		public Dictionary<int, List<TrapDefenseTalentTreeNodeData>> NodeRowMap = new Dictionary<int, List<TrapDefenseTalentTreeNodeData>>();

		// Token: 0x0401DCEC RID: 122092
		public Dictionary<int, TrapDefenseTalentTreeNodeData> NodeIdMap = new Dictionary<int, TrapDefenseTalentTreeNodeData>();

		// Token: 0x0401DCED RID: 122093
		public List<TrapDefenseTalentTreeRowData> RowDataList = new List<TrapDefenseTalentTreeRowData>();

		// Token: 0x0401DCEE RID: 122094
		public List<Dictionary<int, ETrapDefenseTalentTreePathType>> LineTypeMap = new List<Dictionary<int, ETrapDefenseTalentTreePathType>>();
	}
}
