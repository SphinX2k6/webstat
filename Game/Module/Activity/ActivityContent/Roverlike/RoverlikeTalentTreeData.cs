using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063A8 RID: 25512
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeTalentTreeData
	{
		// Token: 0x06040104 RID: 262404 RVA: 0x0106B748 File Offset: 0x01069948
		public static bool IsSameNode(RoverRogueTalentTree a, RoverRogueTalentTree b)
		{
			return a.Row == b.Row && a.Column == b.Column;
		}

		// Token: 0x06040105 RID: 262405 RVA: 0x0106B76C File Offset: 0x0106996C
		private static int GetNodeKey(RoverRogueTalentTree config)
		{
			return config.Column * 10000 + config.Row;
		}

		// Token: 0x06040106 RID: 262406 RVA: 0x0106B784 File Offset: 0x01069984
		public void PhraseEx(int activityId, int talentPointItemId, RoverRogueActivityData roverData)
		{
			this.ActivityId = activityId;
			this.TalentPointItemId = talentPointItemId;
			if (!this.IsStructureBuilt)
			{
				this.BuildStructure();
				this.IsStructureBuilt = true;
			}
			List<int> activeIds = (roverData.ActiveTalentIdList != null) ? roverData.ActiveTalentIdList.ToList<int>() : new List<int>();
			List<int> unlockIds = (roverData.UnlockTalentIdList != null) ? roverData.UnlockTalentIdList.ToList<int>() : new List<int>();
			this.UpdateTalentStateByServer(activeIds, unlockIds, true);
		}

		// Token: 0x06040107 RID: 262407 RVA: 0x0106B7F4 File Offset: 0x010699F4
		private void BuildStructure()
		{
			this.NodeIdMap.Clear();
			this.NodeList.Clear();
			this.NodeColumnList = new List<List<RoverlikeTalentNodeData>>();
			this.ColumnIndexMap.Clear();
			this.LevelIdToHeadIdMap.Clear();
			this.CurSelectNode = null;
			this.OnClickNode = null;
			IReadOnlyList<RoverRogueTalentTree> talentTreeConfigList = ConfigBase<RoverlikeConfig>.Instance.GetTalentTreeConfigList();
			if (talentTreeConfigList.Count == 0)
			{
				return;
			}
			Dictionary<int, List<RoverRogueTalentTree>> dictionary = new Dictionary<int, List<RoverRogueTalentTree>>();
			List<int> list = new List<int>();
			foreach (RoverRogueTalentTree roverRogueTalentTree in talentTreeConfigList)
			{
				int nodeKey = RoverlikeTalentTreeData.GetNodeKey(roverRogueTalentTree);
				List<RoverRogueTalentTree> list2;
				if (!dictionary.TryGetValue(nodeKey, out list2))
				{
					list2 = new List<RoverRogueTalentTree>();
					dictionary[nodeKey] = list2;
					list.Add(nodeKey);
				}
				list2.Add(roverRogueTalentTree);
			}
			Dictionary<int, List<RoverlikeTalentNodeData>> columnGroupMap = new Dictionary<int, List<RoverlikeTalentNodeData>>();
			foreach (int key in list)
			{
				List<RoverRogueTalentTree> list3 = dictionary[key];
				list3.Sort(delegate(RoverRogueTalentTree a, RoverRogueTalentTree b)
				{
					if (a.Consule != b.Consule)
					{
						return a.Consule - b.Consule;
					}
					return a.Id - b.Id;
				});
				RoverlikeTalentNodeData roverlikeTalentNodeData = new RoverlikeTalentNodeData(list3);
				this.NodeIdMap[roverlikeTalentNodeData.HeadConfig.Id] = roverlikeTalentNodeData;
				this.NodeList.Add(roverlikeTalentNodeData);
				foreach (RoverRogueTalentTree roverRogueTalentTree2 in list3)
				{
					this.LevelIdToHeadIdMap[roverRogueTalentTree2.Id] = roverlikeTalentNodeData.HeadConfig.Id;
				}
				List<RoverlikeTalentNodeData> list4;
				if (!columnGroupMap.TryGetValue(roverlikeTalentNodeData.HeadConfig.Column, out list4))
				{
					list4 = new List<RoverlikeTalentNodeData>();
					columnGroupMap[roverlikeTalentNodeData.HeadConfig.Column] = list4;
				}
				list4.Add(roverlikeTalentNodeData);
			}
			List<int> list5 = columnGroupMap.Keys.ToList<int>();
			list5.Sort((int a, int b) => a - b);
			this.NodeColumnList = list5.Select(delegate(int col, int index)
			{
				this.ColumnIndexMap[col] = index;
				List<RoverlikeTalentNodeData> list6 = columnGroupMap[col];
				list6.Sort((RoverlikeTalentNodeData a, RoverlikeTalentNodeData b) => a.HeadConfig.Row - b.HeadConfig.Row);
				return list6;
			}).ToList<List<RoverlikeTalentNodeData>>();
			this.NodeList.Sort(delegate(RoverlikeTalentNodeData a, RoverlikeTalentNodeData b)
			{
				if (a.HeadConfig.Column != b.HeadConfig.Column)
				{
					return a.HeadConfig.Column - b.HeadConfig.Column;
				}
				return a.HeadConfig.Row - b.HeadConfig.Row;
			});
			this.BuildRowStructure();
			this.RefreshLineActiveMap();
		}

		// Token: 0x06040108 RID: 262408 RVA: 0x0106BAE4 File Offset: 0x01069CE4
		private void BuildRowStructure()
		{
			this.NodeRowMap.Clear();
			this.RowDataList.Clear();
			this.MaxRow = 0;
			foreach (RoverlikeTalentNodeData roverlikeTalentNodeData in this.NodeList)
			{
				List<RoverlikeTalentNodeData> list;
				if (!this.NodeRowMap.TryGetValue(roverlikeTalentNodeData.Row, out list))
				{
					list = new List<RoverlikeTalentNodeData>();
					this.NodeRowMap[roverlikeTalentNodeData.Row] = list;
				}
				list.Add(roverlikeTalentNodeData);
				this.MaxRow = Math.Max(this.MaxRow, roverlikeTalentNodeData.Row);
			}
			foreach (KeyValuePair<int, List<RoverlikeTalentNodeData>> keyValuePair in this.NodeRowMap)
			{
				int key = keyValuePair.Key;
				List<RoverlikeTalentNodeData> value = keyValuePair.Value;
				value.Sort((RoverlikeTalentNodeData a, RoverlikeTalentNodeData b) => a.Index - b.Index);
				this.RowDataList.Add(new RoverlikeTalentTreeNodeRowData(key, value));
			}
			this.RowDataList.Sort((RoverlikeTalentTreeNodeRowData a, RoverlikeTalentTreeNodeRowData b) => a.Row - b.Row);
		}

		// Token: 0x06040109 RID: 262409 RVA: 0x0106BC4C File Offset: 0x01069E4C
		public void Reset()
		{
			this.CurSelectNode = null;
			this.OnClickNode = null;
		}

		// Token: 0x0604010A RID: 262410 RVA: 0x0106BC5C File Offset: 0x01069E5C
		public int GetColumnIndex(int column)
		{
			int result;
			if (!this.ColumnIndexMap.TryGetValue(column, out result))
			{
				return -1;
			}
			return result;
		}

		// Token: 0x0604010B RID: 262411 RVA: 0x0106BC7C File Offset: 0x01069E7C
		[NullableContext(2)]
		public RoverlikeTalentNodeData GetNodeData(int id)
		{
			RoverlikeTalentNodeData result;
			if (!this.NodeIdMap.TryGetValue(id, out result))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Activity;
				ELogAuthor author = ELogAuthor.SWC;
				string message = "获取RoverlikeTalentNodeData失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return result;
		}

		// Token: 0x0604010C RID: 262412 RVA: 0x0106BCCC File Offset: 0x01069ECC
		[NullableContext(2)]
		public RoverlikeTalentNodeData GetDefaultSelectNode()
		{
			RoverlikeTalentNodeData roverlikeTalentNodeData = null;
			RoverlikeTalentNodeData roverlikeTalentNodeData2 = null;
			RoverlikeTalentNodeData roverlikeTalentNodeData3 = null;
			foreach (RoverlikeTalentNodeData roverlikeTalentNodeData4 in this.NodeList)
			{
				if (!roverlikeTalentNodeData4.IsMaxLevel)
				{
					if (!roverlikeTalentNodeData4.IsServerUnlocked)
					{
						if (this.IsCloserToTop(roverlikeTalentNodeData3, roverlikeTalentNodeData4))
						{
							roverlikeTalentNodeData3 = roverlikeTalentNodeData4;
						}
					}
					else
					{
						if (this.IsDeeper(roverlikeTalentNodeData2, roverlikeTalentNodeData4))
						{
							roverlikeTalentNodeData2 = roverlikeTalentNodeData4;
						}
						if (this.IsTalentCanUnlock(roverlikeTalentNodeData4) && this.IsDeeper(roverlikeTalentNodeData, roverlikeTalentNodeData4))
						{
							roverlikeTalentNodeData = roverlikeTalentNodeData4;
						}
					}
				}
			}
			RoverlikeTalentNodeData result;
			if ((result = roverlikeTalentNodeData) == null && (result = roverlikeTalentNodeData2) == null && (result = roverlikeTalentNodeData3) == null)
			{
				if (this.NodeList.Count <= 0)
				{
					return null;
				}
				result = this.NodeList[this.NodeList.Count - 1];
			}
			return result;
		}

		// Token: 0x0604010D RID: 262413 RVA: 0x0106BDA0 File Offset: 0x01069FA0
		private bool IsDeeper([Nullable(2)] RoverlikeTalentNodeData current, RoverlikeTalentNodeData candidate)
		{
			if (current == null)
			{
				return true;
			}
			if (candidate.Row == current.Row)
			{
				return candidate.Index < current.Index;
			}
			return candidate.Row > current.Row;
		}

		// Token: 0x0604010E RID: 262414 RVA: 0x0106BDD2 File Offset: 0x01069FD2
		private bool IsCloserToTop([Nullable(2)] RoverlikeTalentNodeData current, RoverlikeTalentNodeData candidate)
		{
			if (current == null)
			{
				return true;
			}
			if (candidate.Row == current.Row)
			{
				return candidate.Index < current.Index;
			}
			return candidate.Row < current.Row;
		}

		// Token: 0x0604010F RID: 262415 RVA: 0x0106BE04 File Offset: 0x0106A004
		public void SelectNode(RoverlikeTalentNodeData node)
		{
			if (node == null || (this.CurSelectNode != null && this.CurSelectNode.HeadConfig.Id == node.HeadConfig.Id))
			{
				return;
			}
			this.CurSelectNode = node;
		}

		// Token: 0x06040110 RID: 262416 RVA: 0x0106BE47 File Offset: 0x0106A047
		public int GetTalentCoinNum()
		{
			return ModelBase<RoverlikeModel>.Instance.GetCurrency(this.TalentPointItemId);
		}

		// Token: 0x06040111 RID: 262417 RVA: 0x0106BE59 File Offset: 0x0106A059
		public void UpdateTalentStateByServer(IReadOnlyList<int> activeIds, IReadOnlyList<int> unlockIds, bool needEmit = false)
		{
			this.MergeTalentIds(activeIds, unlockIds);
			this.RecomputeNodeStateFromCache();
			this.RefreshLineActiveMap();
			if (needEmit)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityId);
			}
		}

		// Token: 0x06040112 RID: 262418 RVA: 0x0106BE88 File Offset: 0x0106A088
		public void UpdateUnlockTalentIds(IReadOnlyList<int> unlockIds, bool needEmit = true)
		{
			this.MergeTalentIds(new List<int>(), unlockIds);
			this.RecomputeNodeStateFromCache();
			if (needEmit)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityId);
			}
		}

		// Token: 0x06040113 RID: 262419 RVA: 0x0106BEB8 File Offset: 0x0106A0B8
		private void MergeTalentIds(IReadOnlyList<int> activeIds, IReadOnlyList<int> unlockIds)
		{
			foreach (int item in activeIds)
			{
				this.ActivatedTalentIdSet.Add(item);
				this.UnlockedTalentIdSet.Add(item);
			}
			foreach (int item2 in unlockIds)
			{
				this.UnlockedTalentIdSet.Add(item2);
			}
		}

		// Token: 0x06040114 RID: 262420 RVA: 0x0106BF50 File Offset: 0x0106A150
		private void RecomputeNodeStateFromCache()
		{
			foreach (RoverlikeTalentNodeData roverlikeTalentNodeData in this.NodeIdMap.Values)
			{
				int num = 0;
				bool flag = false;
				foreach (RoverRogueTalentTree roverRogueTalentTree in roverlikeTalentNodeData.LevelConfigs)
				{
					if (this.ActivatedTalentIdSet.Contains(roverRogueTalentTree.Id))
					{
						num++;
					}
					if (this.UnlockedTalentIdSet.Contains(roverRogueTalentTree.Id))
					{
						flag = true;
					}
				}
				roverlikeTalentNodeData.CurLevel = num;
				roverlikeTalentNodeData.ActiveLevel = num;
				roverlikeTalentNodeData.IsServerUnlocked = flag;
				roverlikeTalentNodeData.IsFinishPreCondition = flag;
			}
		}

		// Token: 0x06040115 RID: 262421 RVA: 0x0106C030 File Offset: 0x0106A230
		public string GetTalentProgress()
		{
			int num = 0;
			using (List<RoverlikeTalentNodeData>.Enumerator enumerator = this.NodeList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsMaxLevel)
					{
						num++;
					}
				}
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(num);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.NodeList.Count);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06040116 RID: 262422 RVA: 0x0106C0C0 File Offset: 0x0106A2C0
		public bool IsPreNodeAllUnlock(RoverlikeTalentNodeData node)
		{
			RoverRogueTalentTree headConfig = node.HeadConfig;
			for (int i = 0; i < headConfig.PostIdLength; i++)
			{
				int key = headConfig.PostId(i);
				RoverlikeTalentNodeData roverlikeTalentNodeData;
				if (this.NodeIdMap.TryGetValue(key, out roverlikeTalentNodeData) && !roverlikeTalentNodeData.IsMaxLevel)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06040117 RID: 262423 RVA: 0x0106C10A File Offset: 0x0106A30A
		public bool IsTalentCanUnlock(RoverlikeTalentNodeData node)
		{
			return !node.IsMaxLevel && node.IsServerUnlocked && this.GetTalentCoinNum() >= node.NextLevelCost;
		}

		// Token: 0x06040118 RID: 262424 RVA: 0x0106C134 File Offset: 0x0106A334
		public bool IsTalentTreeHasRedDot()
		{
			foreach (RoverlikeTalentNodeData node in this.NodeList)
			{
				if (this.IsTalentCanUnlock(node))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06040119 RID: 262425 RVA: 0x0106C190 File Offset: 0x0106A390
		public void UpdateTalentLevelByActivatedIds(IReadOnlyList<int> activatedLevelIds, bool needEmit = false)
		{
			foreach (RoverlikeTalentNodeData roverlikeTalentNodeData in this.NodeIdMap.Values)
			{
				roverlikeTalentNodeData.CurLevel = 0;
			}
			HashSet<int> hashSet = new HashSet<int>(activatedLevelIds);
			foreach (RoverlikeTalentNodeData roverlikeTalentNodeData2 in this.NodeIdMap.Values)
			{
				int num = 0;
				foreach (RoverRogueTalentTree roverRogueTalentTree in roverlikeTalentNodeData2.LevelConfigs)
				{
					if (hashSet.Contains(roverRogueTalentTree.Id))
					{
						num++;
					}
				}
				roverlikeTalentNodeData2.CurLevel = num;
			}
			if (needEmit)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityId);
			}
		}

		// Token: 0x0604011A RID: 262426 RVA: 0x0106C2A0 File Offset: 0x0106A4A0
		public bool LocalUnlockNextTalentLevel(int headTalentId)
		{
			RoverlikeTalentNodeData roverlikeTalentNodeData;
			if (!this.NodeIdMap.TryGetValue(headTalentId, out roverlikeTalentNodeData) || roverlikeTalentNodeData.IsMaxLevel)
			{
				return false;
			}
			int nextLevelId = roverlikeTalentNodeData.NextLevelId;
			if (nextLevelId > 0)
			{
				this.ActivatedTalentIdSet.Add(nextLevelId);
				this.UnlockedTalentIdSet.Add(nextLevelId);
			}
			roverlikeTalentNodeData.CurLevel++;
			roverlikeTalentNodeData.IsServerUnlocked = true;
			this.RefreshLineActiveMap();
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityId);
			return true;
		}

		// Token: 0x0604011B RID: 262427 RVA: 0x0106C320 File Offset: 0x0106A520
		private List<RoverlikeTalentNodeData> GetPreNodes(RoverlikeTalentNodeData node)
		{
			List<RoverlikeTalentNodeData> list = new List<RoverlikeTalentNodeData>();
			RoverRogueTalentTree headConfig = node.HeadConfig;
			for (int i = 0; i < headConfig.PostIdLength; i++)
			{
				int num = headConfig.PostId(i);
				int num2;
				int key = this.LevelIdToHeadIdMap.TryGetValue(num, out num2) ? num2 : num;
				RoverlikeTalentNodeData item;
				if (this.NodeIdMap.TryGetValue(key, out item))
				{
					list.Add(item);
				}
			}
			return list;
		}

		// Token: 0x0604011C RID: 262428 RVA: 0x0106C388 File Offset: 0x0106A588
		[return: TupleElementNames(new string[]
		{
			"Row",
			"Index"
		})]
		[return: Nullable(new byte[]
		{
			1,
			0
		})]
		private List<ValueTuple<int, int>> GetPath(RoverlikeTalentNodeData from, RoverlikeTalentNodeData to)
		{
			List<ValueTuple<int, int>> list = new List<ValueTuple<int, int>>();
			for (int i = from.Row + 1; i < to.Row; i++)
			{
				list.Add(new ValueTuple<int, int>(i, to.Index + 6));
			}
			list.Add(new ValueTuple<int, int>(from.Row, from.Index + 12));
			list.Add(new ValueTuple<int, int>(to.Row, to.Index));
			int num = Math.Max(from.Index, to.Index);
			for (int j = Math.Min(from.Index, to.Index); j < num; j++)
			{
				list.Add(new ValueTuple<int, int>(from.Row, j + 18));
			}
			return list;
		}

		// Token: 0x0604011D RID: 262429 RVA: 0x0106C43C File Offset: 0x0106A63C
		private bool GetPathActive(RoverlikeTalentNodeData a, RoverlikeTalentNodeData b)
		{
			return a.IsMaxLevel && b.IsMaxLevel;
		}

		// Token: 0x0604011E RID: 262430 RVA: 0x0106C450 File Offset: 0x0106A650
		public void RefreshLineActiveMap()
		{
			foreach (Dictionary<int, bool> dictionary in this.LineActiveMap)
			{
				if (dictionary != null)
				{
					dictionary.Clear();
				}
			}
			foreach (RoverlikeTalentNodeData roverlikeTalentNodeData in this.NodeList)
			{
				foreach (RoverlikeTalentNodeData roverlikeTalentNodeData2 in this.GetPreNodes(roverlikeTalentNodeData))
				{
					RoverlikeTalentNodeData roverlikeTalentNodeData3 = (roverlikeTalentNodeData2.Row <= roverlikeTalentNodeData.Row) ? roverlikeTalentNodeData2 : roverlikeTalentNodeData;
					RoverlikeTalentNodeData roverlikeTalentNodeData4 = (roverlikeTalentNodeData2.Row <= roverlikeTalentNodeData.Row) ? roverlikeTalentNodeData : roverlikeTalentNodeData2;
					List<ValueTuple<int, int>> path = this.GetPath(roverlikeTalentNodeData3, roverlikeTalentNodeData4);
					bool pathActive = this.GetPathActive(roverlikeTalentNodeData3, roverlikeTalentNodeData4);
					foreach (ValueTuple<int, int> valueTuple in path)
					{
						int item = valueTuple.Item1;
						int item2 = valueTuple.Item2;
						this.EnsureLineActiveMapSize(item);
						List<Dictionary<int, bool>> lineActiveMap = this.LineActiveMap;
						int index = item;
						if (lineActiveMap[index] == null)
						{
							lineActiveMap[index] = new Dictionary<int, bool>();
						}
						bool flag;
						if (!this.LineActiveMap[item].TryGetValue(item2, out flag) || !flag)
						{
							this.LineActiveMap[item][item2] = pathActive;
						}
					}
				}
			}
		}

		// Token: 0x0604011F RID: 262431 RVA: 0x0106C644 File Offset: 0x0106A844
		private void EnsureLineActiveMapSize(int row)
		{
			while (this.LineActiveMap.Count <= row)
			{
				this.LineActiveMap.Add(null);
			}
		}

		// Token: 0x06040120 RID: 262432 RVA: 0x0106C664 File Offset: 0x0106A864
		public bool IsDotVisible(int row, int index)
		{
			List<RoverlikeTalentNodeData> list;
			if (this.NodeRowMap.TryGetValue(row, out list))
			{
				using (List<RoverlikeTalentNodeData>.Enumerator enumerator = list.GetEnumerator())
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
			List<RoverlikeTalentNodeData> list2;
			if (this.NodeRowMap.TryGetValue(row + 1, out list2))
			{
				using (List<RoverlikeTalentNodeData>.Enumerator enumerator = list2.GetEnumerator())
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

		// Token: 0x04023F72 RID: 147314
		public int ActivityId;

		// Token: 0x04023F73 RID: 147315
		public int TalentPointItemId;

		// Token: 0x04023F74 RID: 147316
		public readonly Dictionary<int, RoverlikeTalentNodeData> NodeIdMap = new Dictionary<int, RoverlikeTalentNodeData>();

		// Token: 0x04023F75 RID: 147317
		public readonly List<RoverlikeTalentNodeData> NodeList = new List<RoverlikeTalentNodeData>();

		// Token: 0x04023F76 RID: 147318
		public List<List<RoverlikeTalentNodeData>> NodeColumnList = new List<List<RoverlikeTalentNodeData>>();

		// Token: 0x04023F77 RID: 147319
		public readonly Dictionary<int, int> ColumnIndexMap = new Dictionary<int, int>();

		// Token: 0x04023F78 RID: 147320
		public readonly Dictionary<int, int> LevelIdToHeadIdMap = new Dictionary<int, int>();

		// Token: 0x04023F79 RID: 147321
		[Nullable(2)]
		public RoverlikeTalentNodeData CurSelectNode;

		// Token: 0x04023F7A RID: 147322
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<bool, RoverlikeTalentNodeData> OnClickNode;

		// Token: 0x04023F7B RID: 147323
		public int MaxRow;

		// Token: 0x04023F7C RID: 147324
		public readonly Dictionary<int, List<RoverlikeTalentNodeData>> NodeRowMap = new Dictionary<int, List<RoverlikeTalentNodeData>>();

		// Token: 0x04023F7D RID: 147325
		public readonly List<RoverlikeTalentTreeNodeRowData> RowDataList = new List<RoverlikeTalentTreeNodeRowData>();

		// Token: 0x04023F7E RID: 147326
		[Nullable(new byte[]
		{
			1,
			2
		})]
		public List<Dictionary<int, bool>> LineActiveMap = new List<Dictionary<int, bool>>();

		// Token: 0x04023F7F RID: 147327
		private readonly HashSet<int> ActivatedTalentIdSet = new HashSet<int>();

		// Token: 0x04023F80 RID: 147328
		private readonly HashSet<int> UnlockedTalentIdSet = new HashSet<int>();

		// Token: 0x04023F81 RID: 147329
		private bool IsStructureBuilt;
	}
}
