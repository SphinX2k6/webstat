using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;

// Token: 0x02002683 RID: 9859
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class QuestReviewModel : ModelBase<QuestReviewModel>
{
	// Token: 0x06013713 RID: 79635 RVA: 0x0056A6C0 File Offset: 0x005688C0
	protected override bool OnInit()
	{
		IReadOnlyList<QuestReviewEntry> configList = ConfigQuestReviewEntryAll.GetConfigList(true);
		if (configList != null)
		{
			foreach (QuestReviewEntry questReviewEntry in configList)
			{
				foreach (int key in questReviewEntry.RelatedQuest())
				{
					this.QuestEntryMap[key] = questReviewEntry.Id;
				}
			}
		}
		return true;
	}

	// Token: 0x06013714 RID: 79636 RVA: 0x0056A740 File Offset: 0x00568940
	protected override bool OnClear()
	{
		foreach (Dictionary<int, object> dictionary in this.DataMap.Values)
		{
			dictionary.Clear();
		}
		this.DataMap.Clear();
		return true;
	}

	// Token: 0x06013715 RID: 79637 RVA: 0x0056A7A4 File Offset: 0x005689A4
	[NullableContext(0)]
	[return: Nullable(2)]
	private TData GetOrCreateData<[Nullable(1)] TData, TConfig>(int id, [Nullable(new byte[]
	{
		1,
		0,
		1
	})] Func<TConfig, TData> ctor, TConfig? config) where TData : class where TConfig : struct
	{
		if (id == 0)
		{
			return default(TData);
		}
		string name = typeof(TData).Name;
		if (!this.DataMap.ContainsKey(name))
		{
			this.DataMap[name] = new Dictionary<int, object>();
		}
		if (config == null)
		{
			return default(TData);
		}
		Dictionary<int, object> dictionary = this.DataMap[name];
		if (!dictionary.ContainsKey(id))
		{
			dictionary[id] = ctor(config.Value);
		}
		return dictionary[id] as TData;
	}

	// Token: 0x06013716 RID: 79638 RVA: 0x0056A840 File Offset: 0x00568A40
	public QuestReviewNodeData GetQuestReviewNodeDataById(int id)
	{
		if (id == 0)
		{
			return null;
		}
		QuestReviewNode? config2 = ConfigQuestReviewNodeById.GetConfig(id, true);
		return this.GetOrCreateData<QuestReviewNodeData, QuestReviewNode>(id, (QuestReviewNode config) => new QuestReviewNodeData(config), config2);
	}

	// Token: 0x06013717 RID: 79639 RVA: 0x0056A884 File Offset: 0x00568A84
	public QuestReviewTabData GetQuestReviewTabDataById(int id)
	{
		if (id == 0)
		{
			return null;
		}
		QuestReviewTab? config2 = ConfigQuestReviewTabById.GetConfig(id, true);
		return this.GetOrCreateData<QuestReviewTabData, QuestReviewTab>(id, (QuestReviewTab config) => new QuestReviewTabData(config), config2);
	}

	// Token: 0x06013718 RID: 79640 RVA: 0x0056A8C8 File Offset: 0x00568AC8
	public QuestReviewTreeData GetQuestReviewTreeDataById(int id)
	{
		if (id == 0)
		{
			return null;
		}
		QuestReviewTree? config2 = ConfigQuestReviewTreeById.GetConfig(id, true);
		return this.GetOrCreateData<QuestReviewTreeData, QuestReviewTree>(id, (QuestReviewTree config) => new QuestReviewTreeData(config), config2);
	}

	// Token: 0x06013719 RID: 79641 RVA: 0x0056A90C File Offset: 0x00568B0C
	public QuestReviewEntryData GetQuestReviewEntryDataById(int id)
	{
		if (id == 0)
		{
			return null;
		}
		QuestReviewEntry? config2 = ConfigQuestReviewEntryById.GetConfig(id, true);
		return this.GetOrCreateData<QuestReviewEntryData, QuestReviewEntry>(id, (QuestReviewEntry config) => new QuestReviewEntryData(config), config2);
	}

	// Token: 0x0601371A RID: 79642 RVA: 0x0056A950 File Offset: 0x00568B50
	public QuestReviewLineData GetQuestReviewLineDataById(int id)
	{
		if (id == 0)
		{
			return null;
		}
		QuestReviewLine? config2 = ConfigQuestReviewLineById.GetConfig(id, true);
		return this.GetOrCreateData<QuestReviewLineData, QuestReviewLine>(id, (QuestReviewLine config) => new QuestReviewLineData(config), config2);
	}

	// Token: 0x0601371B RID: 79643 RVA: 0x0056A994 File Offset: 0x00568B94
	public List<int> GetNodeIdListByQuestLineId(int questLineId)
	{
		QuestReviewLineData questReviewLineDataById = this.GetQuestReviewLineDataById(questLineId);
		if (questReviewLineDataById == null)
		{
			return null;
		}
		QuestReviewNodeData questReviewNodeDataById = this.GetQuestReviewNodeDataById(questReviewLineDataById.StartNode);
		if (questReviewNodeDataById == null)
		{
			return null;
		}
		List<int> list = new List<int>();
		for (int i = 0; i < 5; i++)
		{
			list.Add(0);
		}
		QuestReviewNodeData questReviewNodeDataById2;
		for (QuestReviewNodeData questReviewNodeData = questReviewNodeDataById; questReviewNodeData != null; questReviewNodeData = questReviewNodeDataById2)
		{
			list[questReviewNodeData.PosIndex] = questReviewNodeData.Id;
			questReviewNodeDataById2 = this.GetQuestReviewNodeDataById(questReviewNodeData.Successor);
			if (questReviewNodeDataById2 != null)
			{
				questReviewNodeDataById2.Predecessor = questReviewNodeData.Id;
			}
			if (questReviewNodeData.IsBranching)
			{
				break;
			}
		}
		return list;
	}

	// Token: 0x0601371C RID: 79644 RVA: 0x0056AA24 File Offset: 0x00568C24
	public bool IsQuestLineHasAnyVisibleNode(int questLineId)
	{
		if (this.GetQuestReviewLineDataById(questLineId) == null)
		{
			return false;
		}
		List<int> nodeIdListByQuestLineId = this.GetNodeIdListByQuestLineId(questLineId);
		if (nodeIdListByQuestLineId == null)
		{
			return false;
		}
		foreach (int nodeId in nodeIdListByQuestLineId)
		{
			if (this.IsNodeVisible(nodeId))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0601371D RID: 79645 RVA: 0x0056AA94 File Offset: 0x00568C94
	public QuestReviewNodeData GetSuccessorNodeByNodeId(int nodeId)
	{
		QuestReviewNodeData questReviewNodeDataById = this.GetQuestReviewNodeDataById(nodeId);
		if (questReviewNodeDataById == null)
		{
			return null;
		}
		return this.GetQuestReviewNodeDataById(questReviewNodeDataById.Successor);
	}

	// Token: 0x0601371E RID: 79646 RVA: 0x0056AABC File Offset: 0x00568CBC
	public QuestReviewNodeData GetPredecessorNodeByNodeId(int nodeId)
	{
		QuestReviewNodeData questReviewNodeDataById = this.GetQuestReviewNodeDataById(nodeId);
		if (questReviewNodeDataById == null)
		{
			return null;
		}
		return this.GetQuestReviewNodeDataById(questReviewNodeDataById.Predecessor);
	}

	// Token: 0x0601371F RID: 79647 RVA: 0x0056AAE4 File Offset: 0x00568CE4
	public QuestReviewEntryData GetQuestEntryDataByQuestId(int questId)
	{
		int id;
		if (this.QuestEntryMap.TryGetValue(questId, out id))
		{
			return this.GetQuestReviewEntryDataById(id);
		}
		return null;
	}

	// Token: 0x06013720 RID: 79648 RVA: 0x0056AB0C File Offset: 0x00568D0C
	public bool TabHasRedDot(int tabId)
	{
		QuestReviewTabData questReviewTabDataById = this.GetQuestReviewTabDataById(tabId);
		if (questReviewTabDataById == null)
		{
			return false;
		}
		QuestReviewTreeData questReviewTreeDataById = this.GetQuestReviewTreeDataById(questReviewTabDataById.QuestTree);
		if (questReviewTreeDataById == null)
		{
			return false;
		}
		foreach (int num in questReviewTreeDataById.QuestLines)
		{
			QuestReviewLineData questReviewLineDataById = this.GetQuestReviewLineDataById(num);
			if (questReviewLineDataById != null && questReviewLineDataById.State == EQuestReviewLineState.Show)
			{
				List<int> nodeIdListByQuestLineId = this.GetNodeIdListByQuestLineId(num);
				if (nodeIdListByQuestLineId != null)
				{
					foreach (int num2 in nodeIdListByQuestLineId)
					{
						QuestReviewNodeData questReviewNodeDataById = this.GetQuestReviewNodeDataById(num2);
						bool flag = this.IsNodeVisible(num2);
						if (questReviewNodeDataById != null && questReviewNodeDataById.HasRedDot && flag)
						{
							return true;
						}
					}
				}
			}
		}
		return false;
	}

	// Token: 0x06013721 RID: 79649 RVA: 0x0056AC0C File Offset: 0x00568E0C
	public QuestReviewLineData GetTempLineData()
	{
		QuestReviewLine? config = ConfigQuestReviewLineById.GetConfig(1100, true);
		if (config == null)
		{
			return null;
		}
		return new QuestReviewLineData(config.Value)
		{
			IsTempLine = true
		};
	}

	// Token: 0x06013722 RID: 79650 RVA: 0x0056AC44 File Offset: 0x00568E44
	public bool IsNodeVisible(int nodeId)
	{
		QuestReviewNodeData questReviewNodeDataById = this.GetQuestReviewNodeDataById(nodeId);
		if (questReviewNodeDataById == null || questReviewNodeDataById.State == EQuestReviewNodeState.Locked)
		{
			return false;
		}
		if (questReviewNodeDataById.ShowOnceUnlock)
		{
			return true;
		}
		QuestReviewNodeData predecessorNodeByNodeId = this.GetPredecessorNodeByNodeId(nodeId);
		return predecessorNodeByNodeId == null || predecessorNodeByNodeId.State == EQuestReviewNodeState.Finished;
	}

	// Token: 0x06013723 RID: 79651 RVA: 0x0056AC87 File Offset: 0x00568E87
	public bool HasQuestLineFused()
	{
		return LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.QuestReviewHasFused, false);
	}

	// Token: 0x06013724 RID: 79652 RVA: 0x0056AC94 File Offset: 0x00568E94
	public void SetQuestLineFused()
	{
		LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.QuestReviewHasFused, true);
	}

	// Token: 0x06013725 RID: 79653 RVA: 0x0056ACA4 File Offset: 0x00568EA4
	public bool IsFirstEntry()
	{
		return LocalStorage.GetPlayer<bool?>(ELocalStoragePlayerKey.QuestReviewMainViewEntryAnim, null).GetValueOrDefault(true);
	}

	// Token: 0x06013726 RID: 79654 RVA: 0x0056ACD0 File Offset: 0x00568ED0
	[NullableContext(1)]
	public void UpdateAllQuestReviewEntryData(List<QuestReviewEntryInfo> dataList)
	{
		foreach (QuestReviewEntryInfo questReviewEntryInfo in dataList)
		{
			QuestReviewEntryData questReviewEntryDataById = this.GetQuestReviewEntryDataById(questReviewEntryInfo.EntryId);
			if (questReviewEntryDataById != null)
			{
				questReviewEntryDataById.UpdateByServerData(questReviewEntryInfo);
			}
		}
	}

	// Token: 0x06013727 RID: 79655 RVA: 0x0056AD30 File Offset: 0x00568F30
	[NullableContext(1)]
	public void UpdateAllQuestReviewLineData(List<QuestReviewLineInfo> dataList)
	{
		foreach (QuestReviewLineInfo questReviewLineInfo in dataList)
		{
			QuestReviewLineData questReviewLineDataById = this.GetQuestReviewLineDataById(questReviewLineInfo.LineId);
			if (questReviewLineDataById != null)
			{
				questReviewLineDataById.UpdateByServerData(questReviewLineInfo);
			}
		}
	}

	// Token: 0x06013728 RID: 79656 RVA: 0x0056AD90 File Offset: 0x00568F90
	[NullableContext(1)]
	public void UpdateAllQuestReviewNodeData(List<QuestReviewNodeInfo> dataList)
	{
		foreach (QuestReviewNodeInfo questReviewNodeInfo in dataList)
		{
			QuestReviewNodeData questReviewNodeDataById = this.GetQuestReviewNodeDataById(questReviewNodeInfo.NodeId);
			if (questReviewNodeDataById != null)
			{
				questReviewNodeDataById.UpdateByServerData(questReviewNodeInfo);
			}
		}
	}

	// Token: 0x06013729 RID: 79657 RVA: 0x0056ADF0 File Offset: 0x00568FF0
	[NullableContext(1)]
	public void UpdateAllQuestReviewTabData(List<QuestReviewTabInfo> dataList)
	{
		foreach (QuestReviewTabInfo questReviewTabInfo in dataList)
		{
			QuestReviewTabData questReviewTabDataById = this.GetQuestReviewTabDataById(questReviewTabInfo.TabId);
			if (questReviewTabDataById != null)
			{
				questReviewTabDataById.UpdateByServerData(questReviewTabInfo);
			}
		}
	}

	// Token: 0x0400979A RID: 38810
	[Nullable(1)]
	private readonly Dictionary<string, Dictionary<int, object>> DataMap = new Dictionary<string, Dictionary<int, object>>();

	// Token: 0x0400979B RID: 38811
	[Nullable(1)]
	private readonly Dictionary<int, int> QuestEntryMap = new Dictionary<int, int>();
}
