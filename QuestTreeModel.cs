using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020026A3 RID: 9891
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class QuestTreeModel : ModelBase<QuestTreeModel>
{
	// Token: 0x0601381C RID: 79900 RVA: 0x00570508 File Offset: 0x0056E708
	protected override bool OnInit()
	{
		foreach (QuestTreeChapter config in ConfigBase<QuestTreeConfig>.Instance.GetAllChapters())
		{
			QuestTreeChapterData questTreeChapterData = QuestTreeChapterData.Create(config);
			this.ChapterDataMap[questTreeChapterData.Id] = questTreeChapterData;
		}
		return true;
	}

	// Token: 0x0601381D RID: 79901 RVA: 0x0057056C File Offset: 0x0056E76C
	protected override bool OnClear()
	{
		foreach (QuestTreeChapterData questTreeChapterData in this.ChapterDataMap.Values)
		{
			questTreeChapterData.Clear();
		}
		this.ChapterDataMap.Clear();
		this.ViewModelMain.Clear();
		return true;
	}

	// Token: 0x0601381E RID: 79902 RVA: 0x005705D8 File Offset: 0x0056E7D8
	[NullableContext(2)]
	public QuestTreeChapterData GetChapterDataById(int id)
	{
		return this.ChapterDataMap.GetValueOrDefault(id);
	}

	// Token: 0x0601381F RID: 79903 RVA: 0x005705E6 File Offset: 0x0056E7E6
	public List<QuestTreeChapterData> GetAllChapterData()
	{
		return new List<QuestTreeChapterData>(this.ChapterDataMap.Values);
	}

	// Token: 0x06013820 RID: 79904 RVA: 0x005705F8 File Offset: 0x0056E7F8
	public List<QuestTreeChapterData> GetVisibleChapterDataList()
	{
		List<QuestTreeChapterData> list = new List<QuestTreeChapterData>();
		List<QuestTreeChapterData> allChapterData = this.GetAllChapterData();
		int num = 0;
		for (int i = allChapterData.Count - 1; i >= 0; i--)
		{
			if (allChapterData[i].IsUnlock)
			{
				IL_47:
				while (num < allChapterData.Count && num <= i + 1)
				{
					QuestTreeChapterData item = allChapterData[num];
					list.Add(item);
					num++;
				}
				return list;
			}
		}
		goto IL_47;
	}

	// Token: 0x06013821 RID: 79905 RVA: 0x0057065C File Offset: 0x0056E85C
	public List<QuestTreeNodeData> GetAllAcceptableNodeList()
	{
		List<QuestTreeNodeData> list = new List<QuestTreeNodeData>();
		foreach (QuestTreeChapterData questTreeChapterData in this.ChapterDataMap.Values)
		{
			foreach (QuestTreeNodeData item in questTreeChapterData.GetAcceptableNodeList())
			{
				list.Add(item);
			}
		}
		return list;
	}

	// Token: 0x06013822 RID: 79906 RVA: 0x005706F4 File Offset: 0x0056E8F4
	[NullableContext(2)]
	public QuestTreeChapterData GetCurTrackingChapterData()
	{
		foreach (QuestTreeChapterData questTreeChapterData in this.ChapterDataMap.Values)
		{
			if (questTreeChapterData.IsTracking)
			{
				return questTreeChapterData;
			}
		}
		return null;
	}

	// Token: 0x06013823 RID: 79907 RVA: 0x00570754 File Offset: 0x0056E954
	public QuestTreeNodeData GetOrCreateDummyQuestTreeNodeData(QuestTreeNode dummyConfig)
	{
		if (this.DummyQuestTreeNodeData == null)
		{
			this.DummyQuestTreeNodeData = QuestTreeNodeData.CreateDummyNode(dummyConfig);
		}
		return this.DummyQuestTreeNodeData;
	}

	// Token: 0x06013824 RID: 79908 RVA: 0x00570770 File Offset: 0x0056E970
	[NullableContext(2)]
	public QuestTreeNodeData GetNodeDataFromQuestId(int questId)
	{
		foreach (QuestTreeChapterData questTreeChapterData in this.ChapterDataMap.Values)
		{
			foreach (QuestTreeNodeData questTreeNodeData in questTreeChapterData.NodeMap.Values)
			{
				if (questTreeNodeData.Config.NodeType != 3 && questTreeNodeData.Config.GetQuestArrayBytes().Contains(questId))
				{
					return questTreeNodeData;
				}
			}
		}
		return null;
	}

	// Token: 0x06013825 RID: 79909 RVA: 0x00570830 File Offset: 0x0056EA30
	[NullableContext(2)]
	public QuestTreeNodeData GetNodeDataFromNodeId(int nodeId)
	{
		foreach (QuestTreeChapterData questTreeChapterData in this.ChapterDataMap.Values)
		{
			QuestTreeNodeData valueOrDefault = questTreeChapterData.NodeMap.GetValueOrDefault(nodeId);
			if (valueOrDefault != null)
			{
				return valueOrDefault;
			}
		}
		return null;
	}

	// Token: 0x0400980B RID: 38923
	private readonly Dictionary<int, QuestTreeChapterData> ChapterDataMap = new Dictionary<int, QuestTreeChapterData>();

	// Token: 0x0400980C RID: 38924
	public QuestTreeMainViewModel ViewModelMain = QuestTreeMainViewModel.Create();

	// Token: 0x0400980D RID: 38925
	public QuestTreeChapterViewModel ViewModelChapter = QuestTreeChapterViewModel.Create();

	// Token: 0x0400980E RID: 38926
	[Nullable(2)]
	private QuestTreeNodeData DummyQuestTreeNodeData;
}
