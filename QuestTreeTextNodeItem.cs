using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020026C1 RID: 9921
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class QuestTreeTextNodeItem : QuestTreeNodeItemBase<QuestTreeNodeData>
{
	// Token: 0x170018BD RID: 6333
	// (get) Token: 0x06013911 RID: 80145 RVA: 0x00574F30 File Offset: 0x00573130
	public override EQuestTreeNodeType Type
	{
		get
		{
			return EQuestTreeNodeType.Text;
		}
	}

	// Token: 0x06013912 RID: 80146 RVA: 0x00574F34 File Offset: 0x00573134
	protected unsafe override void OnRegisterComponent()
	{
		int num = 25;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06013913 RID: 80147 RVA: 0x005752E4 File Offset: 0x005734E4
	protected override void OnStart()
	{
		this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
		base.GetItem(8).SetUIActive(false);
		ModelBase<QuestTreeModel>.Instance.ViewModelChapter.AddOnSelectedDataChange(new Action<QuestTreeNodeData>(this.OnSelectedDataChange));
		ModelBase<QuestTreeModel>.Instance.ViewModelChapter.AddOnLocatingNode(new Action<QuestTreeNodeData, bool>(this.OnLocateToNode));
		ModelBase<QuestTreeModel>.Instance.ViewModelChapter.AddOnUpdateNode(new Action(this.OnUpdateNode));
		Singleton<EventSystem>.Instance.Add(EEventName.QuestTreeNodeDataUpdate, new Action<QuestTreeNodeData>(this.OnDataUpdate));
	}

	// Token: 0x06013914 RID: 80148 RVA: 0x0057537C File Offset: 0x0057357C
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.QuestTreeNodeDataUpdate, new Action<QuestTreeNodeData>(this.OnDataUpdate));
		ModelBase<QuestTreeModel>.Instance.ViewModelChapter.RemoveOnUpdateNode(new Action(this.OnUpdateNode));
		ModelBase<QuestTreeModel>.Instance.ViewModelChapter.RemoveOnLocatingNode(new Action<QuestTreeNodeData, bool>(this.OnLocateToNode));
		ModelBase<QuestTreeModel>.Instance.ViewModelChapter.RemoveOnSelectedDataChange(new Action<QuestTreeNodeData>(this.OnSelectedDataChange));
	}

	// Token: 0x06013915 RID: 80149 RVA: 0x005753F8 File Offset: 0x005735F8
	public override UniTask CreateSelf(UUIItem parent)
	{
		QuestTreeTextNodeItem.<CreateSelf>d__9 <CreateSelf>d__;
		<CreateSelf>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateSelf>d__.<>4__this = this;
		<CreateSelf>d__.parent = parent;
		<CreateSelf>d__.<>1__state = -1;
		<CreateSelf>d__.<>t__builder.Start<QuestTreeTextNodeItem.<CreateSelf>d__9>(ref <CreateSelf>d__);
		return <CreateSelf>d__.<>t__builder.Task;
	}

	// Token: 0x06013916 RID: 80150 RVA: 0x00575443 File Offset: 0x00573643
	public override void UpdateData(QuestTreeNodeData data)
	{
		this.Data = data;
		this.RefreshInfo(data);
		this.RefreshLines(data);
		this.RefreshChildren(data);
	}

	// Token: 0x06013917 RID: 80151 RVA: 0x00575462 File Offset: 0x00573662
	public override void Refresh(QuestTreeNodeData data, bool isSelected, int gridIndex)
	{
		this.UpdateData(data);
	}

	// Token: 0x06013918 RID: 80152 RVA: 0x0057546C File Offset: 0x0057366C
	public override float GetAdditionalHeight()
	{
		QuestTreeNodeData nextQuestNode = this.Data.NextQuestNode;
		if (nextQuestNode != null && nextQuestNode.Config.NodeType == 3 && this.Child != null)
		{
			return (this.Child as QuestTreeNodeItemBase<QuestTreeNodeData>).GetAdditionalHeight() + base.GetExtendToggle(0).GetRootComponent().GetHeight();
		}
		return 0f;
	}

	// Token: 0x06013919 RID: 80153 RVA: 0x005754D0 File Offset: 0x005736D0
	protected override void LocateSelf(bool tween = true)
	{
		UUIItem rootComponent = base.GetExtendToggle(0).GetRootComponent();
		QuestTreeNodeLocatingHelper locatingHelper = ModelBase<QuestTreeModel>.Instance.ViewModelChapter.LocatingHelper;
		if (locatingHelper != null)
		{
			locatingHelper.LocateToNode(rootComponent, tween, false);
		}
		if (this.Data.IsTracking || this.Data.State == EQuestTreeNodeState.Available)
		{
			this.SeqPlayer.PlayLevelSequenceByName("Jumpy", false, null, false);
		}
	}

	// Token: 0x0601391A RID: 80154 RVA: 0x00575540 File Offset: 0x00573740
	private void RefreshInfo(QuestTreeNodeData data)
	{
		base.GetItem(4).SetUIActive(!data.IsTracking && data.State == EQuestTreeNodeState.Locked);
		base.GetItem(1).SetUIActive(!data.IsTracking && data.State == EQuestTreeNodeState.Finished);
		base.GetItem(2).SetUIActive(!data.IsTracking && data.State == EQuestTreeNodeState.Available);
		base.GetItem(3).SetUIActive(data.IsTracking);
		base.GetItem(5).SetUIActive(!data.IsTracking && data.State == EQuestTreeNodeState.InProgress);
		this.SetSpriteByPath(data.TypeIconPath, base.GetSprite(6), false, null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), data.Config.Name, Array.Empty<object>());
	}

	// Token: 0x0601391B RID: 80155 RVA: 0x00575624 File Offset: 0x00573824
	private UniTask RefreshChildren(QuestTreeNodeData data)
	{
		QuestTreeTextNodeItem.<RefreshChildren>d__15 <RefreshChildren>d__;
		<RefreshChildren>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshChildren>d__.<>4__this = this;
		<RefreshChildren>d__.data = data;
		<RefreshChildren>d__.<>1__state = -1;
		<RefreshChildren>d__.<>t__builder.Start<QuestTreeTextNodeItem.<RefreshChildren>d__15>(ref <RefreshChildren>d__);
		return <RefreshChildren>d__.<>t__builder.Task;
	}

	// Token: 0x0601391C RID: 80156 RVA: 0x00575670 File Offset: 0x00573870
	private void RefreshLines(QuestTreeNodeData data)
	{
		this.HideAllLines();
		bool flag;
		if (data.PreQuestNodes.Count != 0)
		{
			QuestTreeNodeData questTreeNodeData = data.PreQuestNodes[0];
			flag = (questTreeNodeData != null && questTreeNodeData.Config.QuestType == 1);
		}
		else
		{
			flag = true;
		}
		bool flag2 = flag;
		base.GetItem(9).SetUIActive(true);
		base.GetItem(10).SetUIActive(data.Config.SortOrder < 0);
		base.GetItem(11).SetUIActive(data.Config.SortOrder > 0 && flag2 && data.BelongedNode == null);
		base.GetItem(12).SetUIActive(data.BelongedNode != null);
		UUIItem item = base.GetItem(24);
		bool uiactive;
		if (data.IsInPredecessorUnion() && data.IsLastNodeOfPredecessorUnion())
		{
			QuestTreeNodeData nextQuestNode = data.NextQuestNode;
			if (nextQuestNode == null || nextQuestNode.State > EQuestTreeNodeState.None)
			{
				uiactive = (data.State == EQuestTreeNodeState.Finished);
				goto IL_E5;
			}
		}
		uiactive = false;
		IL_E5:
		item.SetUIActive(uiactive);
		UUIItem item2 = base.GetItem(23);
		bool uiactive2;
		if (data.IsInPredecessorUnion() && !data.IsFirstNodeOfPredecessorUnion() && !data.IsLastNodeOfPredecessorUnion())
		{
			QuestTreeNodeData nextQuestNode2 = data.NextQuestNode;
			if (nextQuestNode2 == null || nextQuestNode2.State > EQuestTreeNodeState.None)
			{
				uiactive2 = (data.State == EQuestTreeNodeState.Finished);
				goto IL_12D;
			}
		}
		uiactive2 = false;
		IL_12D:
		item2.SetUIActive(uiactive2);
	}

	// Token: 0x0601391D RID: 80157 RVA: 0x005757B0 File Offset: 0x005739B0
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	private UniTask<IQuestTreeNodeItem> AttachNextNodeParallel(QuestTreeNodeData nextNode)
	{
		QuestTreeTextNodeItem.<AttachNextNodeParallel>d__17 <AttachNextNodeParallel>d__;
		<AttachNextNodeParallel>d__.<>t__builder = AsyncUniTaskMethodBuilder<IQuestTreeNodeItem>.Create();
		<AttachNextNodeParallel>d__.<>4__this = this;
		<AttachNextNodeParallel>d__.nextNode = nextNode;
		<AttachNextNodeParallel>d__.<>1__state = -1;
		<AttachNextNodeParallel>d__.<>t__builder.Start<QuestTreeTextNodeItem.<AttachNextNodeParallel>d__17>(ref <AttachNextNodeParallel>d__);
		return <AttachNextNodeParallel>d__.<>t__builder.Task;
	}

	// Token: 0x0601391E RID: 80158 RVA: 0x005757FC File Offset: 0x005739FC
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	private UniTask<IQuestTreeNodeItem> AttachNextNodeDown(QuestTreeNodeData nextNode)
	{
		QuestTreeTextNodeItem.<AttachNextNodeDown>d__18 <AttachNextNodeDown>d__;
		<AttachNextNodeDown>d__.<>t__builder = AsyncUniTaskMethodBuilder<IQuestTreeNodeItem>.Create();
		<AttachNextNodeDown>d__.<>4__this = this;
		<AttachNextNodeDown>d__.nextNode = nextNode;
		<AttachNextNodeDown>d__.<>1__state = -1;
		<AttachNextNodeDown>d__.<>t__builder.Start<QuestTreeTextNodeItem.<AttachNextNodeDown>d__18>(ref <AttachNextNodeDown>d__);
		return <AttachNextNodeDown>d__.<>t__builder.Task;
	}

	// Token: 0x0601391F RID: 80159 RVA: 0x00575848 File Offset: 0x00573A48
	private void HideAllLines()
	{
		base.GetItem(10).SetUIActive(false);
		base.GetItem(11).SetUIActive(false);
		base.GetItem(12).SetUIActive(false);
		base.GetItem(24).SetUIActive(false);
		base.GetItem(23).SetUIActive(false);
		base.GetItem(15).SetUIActive(false);
		base.GetItem(16).SetUIActive(false);
		base.GetItem(17).SetUIActive(false);
		base.GetItem(18).SetUIActive(false);
		base.GetItem(13).SetUIActive(false);
		base.GetItem(14).SetUIActive(false);
		base.GetItem(19).SetUIActive(false);
		base.GetItem(20).SetUIActive(false);
		base.GetItem(21).SetUIActive(false);
		base.GetItem(22).SetUIActive(false);
	}

	// Token: 0x06013920 RID: 80160 RVA: 0x00575927 File Offset: 0x00573B27
	private void OnClickToggle(EToggleState _)
	{
		ModelBase<QuestTreeModel>.Instance.ViewModelChapter.SelectData(this.Data);
		ControllerBase<QuestTreeController>.Instance.ReportClickNode(this.Data);
		ControllerBase<QuestTreeController>.Instance.OpenNodeDetailView(this.Data);
	}

	// Token: 0x06013921 RID: 80161 RVA: 0x0057595E File Offset: 0x00573B5E
	[NullableContext(2)]
	private void OnSelectedDataChange(QuestTreeNodeData data)
	{
		if (data != this.Data)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			return;
		}
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, false, false, false);
		this.LocateSelf(true);
	}

	// Token: 0x06013922 RID: 80162 RVA: 0x00575993 File Offset: 0x00573B93
	private void OnDataUpdate(QuestTreeNodeData data)
	{
		if (data != this.Data)
		{
			return;
		}
		this.RefreshInfo(data);
	}

	// Token: 0x06013923 RID: 80163 RVA: 0x005759A6 File Offset: 0x00573BA6
	[NullableContext(2)]
	private void OnLocateToNode(QuestTreeNodeData data, bool tween)
	{
		if (data != this.Data)
		{
			return;
		}
		if (this.Data.BelongedNode != null)
		{
			return;
		}
		this.LocateSelf(tween);
		ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(this.RootItem, true, false, false);
	}

	// Token: 0x06013924 RID: 80164 RVA: 0x005759DB File Offset: 0x00573BDB
	private void OnUpdateNode()
	{
		if (this.Data != null)
		{
			this.RefreshInfo(this.Data);
		}
	}

	// Token: 0x04009863 RID: 39011
	private QuestTreeNodeData Data;

	// Token: 0x04009864 RID: 39012
	[Nullable(2)]
	private IQuestTreeNodeItem Child;

	// Token: 0x04009865 RID: 39013
	private LevelSequencePlayer SeqPlayer;

	// Token: 0x02008A66 RID: 35430
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402EAC9 RID: 191177
		public const int Toggle = 0;

		// Token: 0x0402EACA RID: 191178
		public const int ItemFinish = 1;

		// Token: 0x0402EACB RID: 191179
		public const int ItemAvailable = 2;

		// Token: 0x0402EACC RID: 191180
		public const int ItemTracking = 3;

		// Token: 0x0402EACD RID: 191181
		public const int ItemLock = 4;

		// Token: 0x0402EACE RID: 191182
		public const int ItemInProgress = 5;

		// Token: 0x0402EACF RID: 191183
		public const int SpriteTypeIcon = 6;

		// Token: 0x0402EAD0 RID: 191184
		public const int TextName = 7;

		// Token: 0x0402EAD1 RID: 191185
		public const int ItemNew = 8;

		// Token: 0x0402EAD2 RID: 191186
		public const int ItemLeftLineRoot = 9;

		// Token: 0x0402EAD3 RID: 191187
		public const int ItemLeftLineDown = 10;

		// Token: 0x0402EAD4 RID: 191188
		public const int ItemLeftLineUpLong = 11;

		// Token: 0x0402EAD5 RID: 191189
		public const int ItemLeftLineUpShort = 12;

		// Token: 0x0402EAD6 RID: 191190
		public const int ItemNextNodeAreaDownForSeries = 13;

		// Token: 0x0402EAD7 RID: 191191
		public const int ItemNextNodeParentDownForSeries = 14;

		// Token: 0x0402EAD8 RID: 191192
		public const int ItemNextNodeAreaDownForPicture = 15;

		// Token: 0x0402EAD9 RID: 191193
		public const int ItemNextNodeParentDownForPicture = 16;

		// Token: 0x0402EADA RID: 191194
		public const int ItemNextNodeAreaDownForText = 17;

		// Token: 0x0402EADB RID: 191195
		public const int ItemNextNodeParentDownForText = 18;

		// Token: 0x0402EADC RID: 191196
		public const int ItemNextNodeAreaParallelForPicture = 19;

		// Token: 0x0402EADD RID: 191197
		public const int ItemNextNodeParentParallelForPicture = 20;

		// Token: 0x0402EADE RID: 191198
		public const int ItemNextNodeAreaParallelForNonPicture = 21;

		// Token: 0x0402EADF RID: 191199
		public const int ItemNextNodeParentParallelForNonPicture = 22;

		// Token: 0x0402EAE0 RID: 191200
		public const int ItemRightLineInGroup = 23;

		// Token: 0x0402EAE1 RID: 191201
		public const int ItemRightLineUpLast = 24;
	}
}
