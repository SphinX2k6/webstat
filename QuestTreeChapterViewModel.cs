using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020026B0 RID: 9904
[NullableContext(1)]
[Nullable(0)]
public class QuestTreeChapterViewModel
{
	// Token: 0x170018B1 RID: 6321
	// (get) Token: 0x06013853 RID: 79955 RVA: 0x0057130B File Offset: 0x0056F50B
	public bool OverrideLockReasonGoto
	{
		get
		{
			return this.View != null && this.InternalOverrideLockReasonGoto;
		}
	}

	// Token: 0x06013854 RID: 79956 RVA: 0x0057131D File Offset: 0x0056F51D
	public void SetOverrideLockReasonGoto(bool value)
	{
		this.InternalOverrideLockReasonGoto = value;
	}

	// Token: 0x06013855 RID: 79957 RVA: 0x00571326 File Offset: 0x0056F526
	protected QuestTreeChapterViewModel()
	{
	}

	// Token: 0x170018B2 RID: 6322
	// (get) Token: 0x06013856 RID: 79958 RVA: 0x0057135C File Offset: 0x0056F55C
	public float MaxTopHeight
	{
		get
		{
			float num = 0f;
			foreach (ValueTuple<float, float> valueTuple in this.NodeHeightDeltaMap.Values)
			{
				if (valueTuple.Item1 > num)
				{
					num = valueTuple.Item1;
				}
			}
			return num;
		}
	}

	// Token: 0x170018B3 RID: 6323
	// (get) Token: 0x06013857 RID: 79959 RVA: 0x005713C4 File Offset: 0x0056F5C4
	public float MaxBottomHeight
	{
		get
		{
			float num = 0f;
			foreach (ValueTuple<float, float> valueTuple in this.NodeHeightDeltaMap.Values)
			{
				if (valueTuple.Item2 > num)
				{
					num = valueTuple.Item2;
				}
			}
			return num;
		}
	}

	// Token: 0x06013858 RID: 79960 RVA: 0x0057142C File Offset: 0x0056F62C
	public static QuestTreeChapterViewModel Create()
	{
		return new QuestTreeChapterViewModel();
	}

	// Token: 0x06013859 RID: 79961 RVA: 0x00571433 File Offset: 0x0056F633
	public void InitLocatingHelper(UUIScrollViewComponent scroll)
	{
		if (this.LocatingHelper == null)
		{
			this.LocatingHelper = new QuestTreeNodeLocatingHelper(scroll);
		}
	}

	// Token: 0x0601385A RID: 79962 RVA: 0x00571449 File Offset: 0x0056F649
	public void OnViewOpen(QuestTreeChapterView view)
	{
		this.View = view;
	}

	// Token: 0x0601385B RID: 79963 RVA: 0x00571452 File Offset: 0x0056F652
	public void OnViewClose()
	{
		this.Clear();
		this.View = null;
	}

	// Token: 0x0601385C RID: 79964 RVA: 0x00571464 File Offset: 0x0056F664
	public void Clear()
	{
		this.DelegatesOnSelectedDataChange.Clear();
		this.DelegatesOnLocatingNode.Clear();
		this.DelegatesOnUpdateNode.Clear();
		this.SelectedData = null;
		this.LastSelectedDataCache = null;
		if (this.LocatingHelper != null)
		{
			this.LocatingHelper.Clear();
			this.LocatingHelper = null;
		}
	}

	// Token: 0x0601385D RID: 79965 RVA: 0x005714BA File Offset: 0x0056F6BA
	public void AddOnSelectedDataChange([Nullable(new byte[]
	{
		1,
		2
	})] Action<QuestTreeNodeData> del)
	{
		this.DelegatesOnSelectedDataChange.Add(del);
	}

	// Token: 0x0601385E RID: 79966 RVA: 0x005714C8 File Offset: 0x0056F6C8
	public void RemoveOnSelectedDataChange([Nullable(new byte[]
	{
		1,
		2
	})] Action<QuestTreeNodeData> del)
	{
		int num = this.DelegatesOnSelectedDataChange.IndexOf(del);
		if (num != -1)
		{
			this.DelegatesOnSelectedDataChange.RemoveAt(num);
		}
	}

	// Token: 0x0601385F RID: 79967 RVA: 0x005714F2 File Offset: 0x0056F6F2
	[NullableContext(2)]
	public void SelectData(QuestTreeNodeData data)
	{
		this.SelectedData = data;
		if (data != null)
		{
			this.LastSelectedDataCache = data;
		}
		this.NotifySelectedDataChange();
	}

	// Token: 0x06013860 RID: 79968 RVA: 0x0057150B File Offset: 0x0056F70B
	public void AddOnLocatingNode([Nullable(new byte[]
	{
		1,
		2
	})] Action<QuestTreeNodeData, bool> del)
	{
		this.DelegatesOnLocatingNode.Add(del);
	}

	// Token: 0x06013861 RID: 79969 RVA: 0x0057151C File Offset: 0x0056F71C
	public void RemoveOnLocatingNode([Nullable(new byte[]
	{
		1,
		2
	})] Action<QuestTreeNodeData, bool> del)
	{
		int num = this.DelegatesOnLocatingNode.IndexOf(del);
		if (num != -1)
		{
			this.DelegatesOnLocatingNode.RemoveAt(num);
		}
	}

	// Token: 0x06013862 RID: 79970 RVA: 0x00571548 File Offset: 0x0056F748
	[NullableContext(2)]
	public void LocateToNode(QuestTreeNodeData data, bool tween = true)
	{
		foreach (Action<QuestTreeNodeData, bool> action in this.DelegatesOnLocatingNode)
		{
			action(data, tween);
		}
	}

	// Token: 0x06013863 RID: 79971 RVA: 0x0057159C File Offset: 0x0056F79C
	public void RecordHeightBalanceValue(int id, float valueTop, float valueBottom)
	{
		this.NodeHeightDeltaMap[id] = new ValueTuple<float, float>(valueTop, valueBottom);
	}

	// Token: 0x06013864 RID: 79972 RVA: 0x005715B1 File Offset: 0x0056F7B1
	public void RemoveHeightBalanceValue(int id)
	{
		this.NodeHeightDeltaMap.Remove(id);
	}

	// Token: 0x06013865 RID: 79973 RVA: 0x005715C0 File Offset: 0x0056F7C0
	public void RecordToggleHeight(float value)
	{
		if (value > this.MaxToggleHeight)
		{
			this.MaxToggleHeight = value;
		}
	}

	// Token: 0x06013866 RID: 79974 RVA: 0x005715D4 File Offset: 0x0056F7D4
	private void NotifySelectedDataChange()
	{
		foreach (Action<QuestTreeNodeData> action in this.DelegatesOnSelectedDataChange)
		{
			action(this.SelectedData);
		}
	}

	// Token: 0x06013867 RID: 79975 RVA: 0x0057162C File Offset: 0x0056F82C
	public void AddOnUpdateNode(Action del)
	{
		this.DelegatesOnUpdateNode.Add(del);
	}

	// Token: 0x06013868 RID: 79976 RVA: 0x0057163A File Offset: 0x0056F83A
	public void RemoveOnUpdateNode(Action del)
	{
		this.DelegatesOnUpdateNode.Remove(del);
	}

	// Token: 0x06013869 RID: 79977 RVA: 0x0057164C File Offset: 0x0056F84C
	public void NotifyUpdateNode()
	{
		foreach (Action action in this.DelegatesOnUpdateNode)
		{
			action();
		}
	}

	// Token: 0x0601386A RID: 79978 RVA: 0x0057169C File Offset: 0x0056F89C
	public UniTask RefreshViewByData(QuestTreeChapterData data, bool useBlackScreen = true)
	{
		QuestTreeChapterViewModel.<RefreshViewByData>d__36 <RefreshViewByData>d__;
		<RefreshViewByData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshViewByData>d__.<>4__this = this;
		<RefreshViewByData>d__.data = data;
		<RefreshViewByData>d__.useBlackScreen = useBlackScreen;
		<RefreshViewByData>d__.<>1__state = -1;
		<RefreshViewByData>d__.<>t__builder.Start<QuestTreeChapterViewModel.<RefreshViewByData>d__36>(ref <RefreshViewByData>d__);
		return <RefreshViewByData>d__.<>t__builder.Task;
	}

	// Token: 0x04009817 RID: 38935
	private bool InternalOverrideLockReasonGoto;

	// Token: 0x04009818 RID: 38936
	[Nullable(new byte[]
	{
		1,
		1,
		2
	})]
	private readonly List<Action<QuestTreeNodeData>> DelegatesOnSelectedDataChange = new List<Action<QuestTreeNodeData>>();

	// Token: 0x04009819 RID: 38937
	[Nullable(new byte[]
	{
		1,
		1,
		2
	})]
	private readonly List<Action<QuestTreeNodeData, bool>> DelegatesOnLocatingNode = new List<Action<QuestTreeNodeData, bool>>();

	// Token: 0x0400981A RID: 38938
	private readonly List<Action> DelegatesOnUpdateNode = new List<Action>();

	// Token: 0x0400981B RID: 38939
	public float MaxToggleHeight;

	// Token: 0x0400981C RID: 38940
	[Nullable(2)]
	public QuestTreeNodeData SelectedData;

	// Token: 0x0400981D RID: 38941
	[Nullable(2)]
	public QuestTreeNodeLocatingHelper LocatingHelper;

	// Token: 0x0400981E RID: 38942
	[Nullable(new byte[]
	{
		1,
		0
	})]
	public Dictionary<int, ValueTuple<float, float>> NodeHeightDeltaMap = new Dictionary<int, ValueTuple<float, float>>();

	// Token: 0x0400981F RID: 38943
	[Nullable(2)]
	public QuestTreeChapterView View;

	// Token: 0x04009820 RID: 38944
	[Nullable(2)]
	public QuestTreeNodeData LastSelectedDataCache;
}
