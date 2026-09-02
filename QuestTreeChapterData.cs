using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002692 RID: 9874
[NullableContext(1)]
[Nullable(0)]
public class QuestTreeChapterData
{
	// Token: 0x06013793 RID: 79763 RVA: 0x0056D872 File Offset: 0x0056BA72
	protected QuestTreeChapterData()
	{
	}

	// Token: 0x1700186A RID: 6250
	// (get) Token: 0x06013794 RID: 79764 RVA: 0x0056D888 File Offset: 0x0056BA88
	public bool IsUnlock
	{
		get
		{
			using (Dictionary<int, QuestTreeNodeData>.ValueCollection.Enumerator enumerator = this.NodeMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.State > EQuestTreeNodeState.Locked)
					{
						return true;
					}
				}
			}
			return false;
		}
	}

	// Token: 0x1700186B RID: 6251
	// (get) Token: 0x06013795 RID: 79765 RVA: 0x0056D8E8 File Offset: 0x0056BAE8
	public bool IsTracking
	{
		get
		{
			using (Dictionary<int, QuestTreeNodeData>.ValueCollection.Enumerator enumerator = this.NodeMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsTracking)
					{
						return true;
					}
				}
			}
			return false;
		}
	}

	// Token: 0x1700186C RID: 6252
	// (get) Token: 0x06013796 RID: 79766 RVA: 0x0056D948 File Offset: 0x0056BB48
	public bool HasAvailableQuest
	{
		get
		{
			using (Dictionary<int, QuestTreeNodeData>.ValueCollection.Enumerator enumerator = this.NodeMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.State == EQuestTreeNodeState.Available)
					{
						return true;
					}
				}
			}
			return false;
		}
	}

	// Token: 0x1700186D RID: 6253
	// (get) Token: 0x06013797 RID: 79767 RVA: 0x0056D9A8 File Offset: 0x0056BBA8
	[Nullable(0)]
	public ValueTuple<int, int> Progress
	{
		[NullableContext(0)]
		get
		{
			int num = 0;
			int num2 = this.NodeMap.Count;
			foreach (QuestTreeNodeData questTreeNodeData in this.NodeMap.Values)
			{
				if (questTreeNodeData.State == EQuestTreeNodeState.Finished && questTreeNodeData.Config.NodeType != 3)
				{
					num++;
				}
				if (questTreeNodeData.Config.NodeType == 3 || (questTreeNodeData.IsMoonChasingQuest() && questTreeNodeData.State == EQuestTreeNodeState.None))
				{
					num2--;
				}
			}
			return new ValueTuple<int, int>(num, num2);
		}
	}

	// Token: 0x1700186E RID: 6254
	// (get) Token: 0x06013798 RID: 79768 RVA: 0x0056DA5C File Offset: 0x0056BC5C
	public string Image
	{
		get
		{
			if (this.IsUnlock)
			{
				return this.Config.Value.Image;
			}
			bool playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() != EPlayerGender.Female;
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_QuestTree_Chapter_Nv_Small");
			string resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_QuestTree_Chapter_Nan_Small");
			if (playerGender)
			{
				return resourcePath2;
			}
			return resourcePath;
		}
	}

	// Token: 0x06013799 RID: 79769 RVA: 0x0056DAB4 File Offset: 0x0056BCB4
	public unsafe static QuestTreeChapterData Create(QuestTreeChapter config)
	{
		QuestTreeChapterData questTreeChapterData = new QuestTreeChapterData();
		questTreeChapterData.Config = new QuestTreeChapter?(config);
		questTreeChapterData.Id = config.Id;
		foreach (QuestTreeNode config2 in ConfigBase<QuestTreeConfig>.Instance.GetNodeListByChapterId(config.Id))
		{
			QuestTreeNodeData questTreeNodeData = QuestTreeNodeData.Create(config2);
			questTreeChapterData.NodeMap[questTreeNodeData.Id] = questTreeNodeData;
		}
		foreach (QuestTreeNodeData questTreeNodeData2 in questTreeChapterData.NodeMap.Values)
		{
			Span<int> includeNodesBytes = questTreeNodeData2.Config.GetIncludeNodesBytes();
			for (int i = 0; i < includeNodesBytes.Length; i++)
			{
				int key = *includeNodesBytes[i];
				QuestTreeNodeData valueOrDefault = questTreeChapterData.NodeMap.GetValueOrDefault(key);
				if (valueOrDefault != null)
				{
					valueOrDefault.SetBelongedNode(questTreeNodeData2);
				}
			}
		}
		return questTreeChapterData;
	}

	// Token: 0x0601379A RID: 79770 RVA: 0x0056DBCC File Offset: 0x0056BDCC
	public void Clear()
	{
		foreach (QuestTreeNodeData questTreeNodeData in this.NodeMap.Values)
		{
			questTreeNodeData.Clear();
		}
		this.NodeMap.Clear();
	}

	// Token: 0x0601379B RID: 79771 RVA: 0x0056DC2C File Offset: 0x0056BE2C
	public List<QuestTreeNodeData> GetAvailableNodeList()
	{
		List<QuestTreeNodeData> list = new List<QuestTreeNodeData>();
		foreach (QuestTreeNodeData questTreeNodeData in this.NodeMap.Values)
		{
			if (questTreeNodeData.State == EQuestTreeNodeState.Available)
			{
				list.Add(questTreeNodeData);
			}
		}
		return list;
	}

	// Token: 0x0601379C RID: 79772 RVA: 0x0056DC94 File Offset: 0x0056BE94
	public List<QuestTreeNodeData> GetMainNodeList()
	{
		List<QuestTreeNodeData> list = new List<QuestTreeNodeData>();
		QuestTreeNodeData questTreeNodeData = null;
		foreach (QuestTreeNodeData questTreeNodeData2 in this.NodeMap.Values)
		{
			if (questTreeNodeData2.Config.QuestType == 1 && questTreeNodeData2.State != EQuestTreeNodeState.None && questTreeNodeData2.PreQuestNodes.Count == 0)
			{
				questTreeNodeData = questTreeNodeData2;
				break;
			}
		}
		if (questTreeNodeData == null)
		{
			return list;
		}
		list.Add(questTreeNodeData);
		QuestTreeNodeData nextQuestNode = questTreeNodeData.NextQuestNode;
		while (nextQuestNode != null && nextQuestNode.State != EQuestTreeNodeState.None)
		{
			list.Add(nextQuestNode);
			nextQuestNode = nextQuestNode.NextQuestNode;
		}
		List<QuestTreeNodeData> list2 = list;
		QuestTreeNodeData questTreeNodeData3 = list2[list2.Count - 1];
		if (!questTreeNodeData3.Config.IsChapterEnding && questTreeNodeData3.State == EQuestTreeNodeState.Finished)
		{
			list.Add(ModelBase<QuestTreeModel>.Instance.GetOrCreateDummyQuestTreeNodeData(questTreeNodeData3.Config));
		}
		return list;
	}

	// Token: 0x0601379D RID: 79773 RVA: 0x0056DD8C File Offset: 0x0056BF8C
	public List<List<QuestTreeNodeData>> GetNoParentNodeGroupList()
	{
		Dictionary<int, List<QuestTreeNodeData>> dictionary = new Dictionary<int, List<QuestTreeNodeData>>();
		foreach (QuestTreeNodeData questTreeNodeData in this.NodeMap.Values)
		{
			if (questTreeNodeData.Config.QuestType != 1 && questTreeNodeData.BelongedNode == null && questTreeNodeData.PreQuestNodes.Count <= 0 && questTreeNodeData.Config.SortOrder > 0)
			{
				int nextNode = questTreeNodeData.Config.NextNode;
				if (!dictionary.ContainsKey(nextNode))
				{
					dictionary.Add(nextNode, new List<QuestTreeNodeData>());
				}
				dictionary.GetValueOrDefault(nextNode).Add(questTreeNodeData);
			}
		}
		using (Dictionary<int, List<QuestTreeNodeData>>.ValueCollection.Enumerator enumerator2 = dictionary.Values.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				enumerator2.Current.Sort((QuestTreeNodeData a, QuestTreeNodeData b) => a.Config.SortOrder - b.Config.SortOrder);
			}
		}
		List<int> list = new List<int>(dictionary.Keys);
		list.Sort(delegate(int a, int b)
		{
			QuestTreeNodeData valueOrDefault = this.NodeMap.GetValueOrDefault(a);
			int num = (valueOrDefault != null) ? valueOrDefault.Config.SortOrder : 0;
			QuestTreeNodeData valueOrDefault2 = this.NodeMap.GetValueOrDefault(b);
			return num - ((valueOrDefault2 != null) ? valueOrDefault2.Config.SortOrder : 0);
		});
		List<List<QuestTreeNodeData>> list2 = new List<List<QuestTreeNodeData>>();
		foreach (int key in list)
		{
			list2.Add(dictionary[key]);
		}
		return list2;
	}

	// Token: 0x0601379E RID: 79774 RVA: 0x0056DF20 File Offset: 0x0056C120
	[NullableContext(2)]
	public QuestTreeNodeData GetDefaultLocatingNode()
	{
		foreach (QuestTreeNodeData questTreeNodeData in this.NodeMap.Values)
		{
			if (questTreeNodeData.IsTracking)
			{
				return questTreeNodeData;
			}
		}
		List<QuestTreeNodeData> mainNodeList = this.GetMainNodeList();
		if (mainNodeList.Count <= 0)
		{
			return null;
		}
		List<QuestTreeNodeData> list = mainNodeList;
		return list[list.Count - 1];
	}

	// Token: 0x0601379F RID: 79775 RVA: 0x0056DFA0 File Offset: 0x0056C1A0
	public List<QuestTreeNodeData> GetAcceptableNodeList()
	{
		List<QuestTreeNodeData> list = new List<QuestTreeNodeData>();
		foreach (QuestTreeNodeData questTreeNodeData in this.NodeMap.Values)
		{
			if (questTreeNodeData.State == EQuestTreeNodeState.Available)
			{
				list.Add(questTreeNodeData);
			}
		}
		return list;
	}

	// Token: 0x060137A0 RID: 79776 RVA: 0x0056E008 File Offset: 0x0056C208
	[NullableContext(2)]
	public QuestTreeNodeData GetCurTrackingNode()
	{
		foreach (QuestTreeNodeData questTreeNodeData in this.NodeMap.Values)
		{
			if (questTreeNodeData.IsTracking)
			{
				return questTreeNodeData;
			}
		}
		return null;
	}

	// Token: 0x040097BE RID: 38846
	public int Id;

	// Token: 0x040097BF RID: 38847
	public QuestTreeChapter? Config;

	// Token: 0x040097C0 RID: 38848
	public Dictionary<int, QuestTreeNodeData> NodeMap = new Dictionary<int, QuestTreeNodeData>();
}
