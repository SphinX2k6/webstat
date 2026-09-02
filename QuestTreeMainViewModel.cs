using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020026B1 RID: 9905
[NullableContext(1)]
[Nullable(0)]
public class QuestTreeMainViewModel
{
	// Token: 0x0601386B RID: 79979 RVA: 0x005716EF File Offset: 0x0056F8EF
	protected QuestTreeMainViewModel()
	{
	}

	// Token: 0x0601386C RID: 79980 RVA: 0x00571709 File Offset: 0x0056F909
	public static QuestTreeMainViewModel Create()
	{
		return new QuestTreeMainViewModel();
	}

	// Token: 0x0601386D RID: 79981 RVA: 0x00571710 File Offset: 0x0056F910
	public void InitLocatingHelper(UUIScrollViewComponent scroll)
	{
		if (this.LocatingHelper == null)
		{
			this.LocatingHelper = new QuestTreeNodeLocatingHelper(scroll);
		}
	}

	// Token: 0x0601386E RID: 79982 RVA: 0x00571726 File Offset: 0x0056F926
	public void OnViewClose()
	{
		this.Clear();
	}

	// Token: 0x0601386F RID: 79983 RVA: 0x0057172E File Offset: 0x0056F92E
	public void Clear()
	{
		this.DelegatesOnLocatingNode.Clear();
		if (this.LocatingHelper != null)
		{
			this.LocatingHelper.Clear();
			this.LocatingHelper = null;
		}
	}

	// Token: 0x06013870 RID: 79984 RVA: 0x00571758 File Offset: 0x0056F958
	public List<List<QuestTreeChapterData>> GetViewDataList()
	{
		List<List<QuestTreeChapterData>> list = new List<List<QuestTreeChapterData>>();
		List<QuestTreeChapterData> visibleChapterDataList = ModelBase<QuestTreeModel>.Instance.GetVisibleChapterDataList();
		for (int i = 0; i < visibleChapterDataList.Count; i += 5)
		{
			int count = Math.Min(5, visibleChapterDataList.Count - i);
			List<QuestTreeChapterData> range = visibleChapterDataList.GetRange(i, count);
			list.Add(range);
		}
		return list;
	}

	// Token: 0x06013871 RID: 79985 RVA: 0x005717A9 File Offset: 0x0056F9A9
	public void AddOnLocatingNode([Nullable(new byte[]
	{
		1,
		2
	})] Action<QuestTreeChapterData, bool> action)
	{
		this.DelegatesOnLocatingNode.Add(action);
	}

	// Token: 0x06013872 RID: 79986 RVA: 0x005717B7 File Offset: 0x0056F9B7
	public void RemoveOnLocatingNode([Nullable(new byte[]
	{
		1,
		2
	})] Action<QuestTreeChapterData, bool> action)
	{
		this.DelegatesOnLocatingNode.Remove(action);
	}

	// Token: 0x06013873 RID: 79987 RVA: 0x005717C8 File Offset: 0x0056F9C8
	[NullableContext(2)]
	public void LocateNode(QuestTreeChapterData data, bool tween = true)
	{
		foreach (Action<QuestTreeChapterData, bool> action in this.DelegatesOnLocatingNode)
		{
			action(data, tween);
		}
	}

	// Token: 0x06013874 RID: 79988 RVA: 0x0057181C File Offset: 0x0056FA1C
	[NullableContext(2)]
	public QuestTreeChapterData GetDefaultLocatingNode()
	{
		List<QuestTreeChapterData> visibleChapterDataList = ModelBase<QuestTreeModel>.Instance.GetVisibleChapterDataList();
		QuestTreeChapterData questTreeChapterData = null;
		foreach (QuestTreeChapterData questTreeChapterData2 in visibleChapterDataList)
		{
			if (questTreeChapterData2.IsTracking)
			{
				return questTreeChapterData2;
			}
			if (questTreeChapterData2.IsUnlock)
			{
				questTreeChapterData = questTreeChapterData2;
			}
		}
		QuestTreeChapterData result;
		if ((result = questTreeChapterData) == null)
		{
			if (visibleChapterDataList.Count <= 0)
			{
				return null;
			}
			List<QuestTreeChapterData> list = visibleChapterDataList;
			result = list[list.Count - 1];
		}
		return result;
	}

	// Token: 0x06013875 RID: 79989 RVA: 0x005718A8 File Offset: 0x0056FAA8
	public void SetShouldLocateToDefaultNode(bool should)
	{
		this.ShouldLocateToDefaultNode = should;
	}

	// Token: 0x04009821 RID: 38945
	[Nullable(2)]
	public QuestTreeNodeLocatingHelper LocatingHelper;

	// Token: 0x04009822 RID: 38946
	public bool ShouldLocateToDefaultNode = true;

	// Token: 0x04009823 RID: 38947
	[Nullable(new byte[]
	{
		1,
		1,
		2
	})]
	private List<Action<QuestTreeChapterData, bool>> DelegatesOnLocatingNode = new List<Action<QuestTreeChapterData, bool>>();
}
