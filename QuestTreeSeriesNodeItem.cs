using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020026C0 RID: 9920
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class QuestTreeSeriesNodeItem : QuestTreeNodeItemBase<QuestTreeNodeData>
{
	// Token: 0x170018BC RID: 6332
	// (get) Token: 0x060138FD RID: 80125 RVA: 0x00574781 File Offset: 0x00572981
	public override EQuestTreeNodeType Type
	{
		get
		{
			return EQuestTreeNodeType.Series;
		}
	}

	// Token: 0x060138FE RID: 80126 RVA: 0x00574784 File Offset: 0x00572984
	protected unsafe override void OnRegisterComponent()
	{
		int num = 15;
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
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUISizeControlByOther));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060138FF RID: 80127 RVA: 0x005749E0 File Offset: 0x00572BE0
	protected override void OnStart()
	{
		this.LayoutChildren = new GenericLayout<QuestTreeNodeItemBase<QuestTreeNodeData>, QuestTreeNodeData>(base.GetVerticalLayout(12), () => base.Loader.CreateLogicalNodeItem<QuestTreeNodeData>(EQuestTreeNodeType.Text), null, false, true);
		this.UiSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		this.InterpDelegate = global::DelegateUtils.ToManualReleaseDelegate<FLTweenFloatSetterDynamic>(new Action<float>(this.OnInterpUpdate));
		this.OriginalAdditionalHeight = base.GetUiSizeControlByOther(14).GetAdditionalHeight();
		base.GetExtendToggle(0).bLockStateOnSelect = false;
		ModelBase<QuestTreeModel>.Instance.ViewModelChapter.AddOnLocatingNode(new Action<QuestTreeNodeData, bool>(this.OnLocateToNode));
		ModelBase<QuestTreeModel>.Instance.ViewModelChapter.AddOnUpdateNode(new Action(this.OnUpdateNode));
		Singleton<EventSystem>.Instance.Add(EEventName.QuestTreeNodeDataUpdate, new Action<QuestTreeNodeData>(this.OnNodeUpdate));
	}

	// Token: 0x06013900 RID: 80128 RVA: 0x00574AAC File Offset: 0x00572CAC
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.QuestTreeNodeDataUpdate, new Action<QuestTreeNodeData>(this.OnNodeUpdate));
		this.UiSequencePlayer.Clear();
		ModelBase<QuestTreeModel>.Instance.ViewModelChapter.RemoveOnUpdateNode(new Action(this.OnUpdateNode));
		ModelBase<QuestTreeModel>.Instance.ViewModelChapter.RemoveOnLocatingNode(new Action<QuestTreeNodeData, bool>(this.OnLocateToNode));
		if (this.InterpDelegate != null)
		{
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<float>(this.OnInterpUpdate));
			this.InterpDelegate = null;
		}
	}

	// Token: 0x06013901 RID: 80129 RVA: 0x00574B36 File Offset: 0x00572D36
	public override UniTask CreateSelf(UUIItem parent)
	{
		return base.CreateThenShowByResourceIdAsync("UiItem_TaskTreeBranchTab", parent, false);
	}

	// Token: 0x06013902 RID: 80130 RVA: 0x00574B48 File Offset: 0x00572D48
	public override void UpdateData(QuestTreeNodeData data)
	{
		this.Data = data;
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
		this.RefreshInfo(data);
		this.RefreshChildren(data.GetIncludeNodes(true));
		base.GetItem(10).SetUIActive(flag2);
		base.GetItem(9).SetUIActive(!flag2);
		this.SetSizeItemActive(true);
	}

	// Token: 0x06013903 RID: 80131 RVA: 0x00574BCA File Offset: 0x00572DCA
	public override float GetAdditionalHeight()
	{
		return base.GetRootItem().GetHeight();
	}

	// Token: 0x06013904 RID: 80132 RVA: 0x00574BD8 File Offset: 0x00572DD8
	private void RefreshInfo(QuestTreeNodeData data)
	{
		base.GetItem(4).SetUIActive(!data.IsTracking && data.State == EQuestTreeNodeState.Locked);
		base.GetItem(1).SetUIActive(!data.IsTracking && data.State == EQuestTreeNodeState.Finished);
		base.GetItem(2).SetUIActive(!data.IsTracking && data.State == EQuestTreeNodeState.Available);
		base.GetItem(3).SetUIActive(data.IsTracking);
		base.GetItem(5).SetUIActive(!data.IsTracking && data.State == EQuestTreeNodeState.InProgress);
		this.SetSpriteByPath(data.TypeIconPath, base.GetSprite(6), false, null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), data.Config.Name, Array.Empty<object>());
		ValueTuple<int, int> includeNodesProgress = data.GetIncludeNodesProgress();
		int item = includeNodesProgress.Item1;
		int item2 = includeNodesProgress.Item2;
		UUIText text = base.GetText(8);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(item);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(item2);
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
	}

	// Token: 0x06013905 RID: 80133 RVA: 0x00574D05 File Offset: 0x00572F05
	private void RefreshChildren(List<QuestTreeNodeData> data)
	{
		this.LayoutChildren.RefreshByData(data, null, true);
	}

	// Token: 0x06013906 RID: 80134 RVA: 0x00574D15 File Offset: 0x00572F15
	private void OnToggleClick(EToggleState _)
	{
		this.HidingLayout = !this.HidingLayout;
		this.ShowHideChildren(this.HidingLayout).Forget();
	}

	// Token: 0x06013907 RID: 80135 RVA: 0x00574D38 File Offset: 0x00572F38
	private void OnLocateToNode(QuestTreeNodeData data, bool tween)
	{
		if (data != this.Data && ((data != null) ? data.BelongedNode : null) != this.Data)
		{
			return;
		}
		this.LocateSelf(tween);
		ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(this.RootItem, true, false, false);
		if (data.IsTracking)
		{
			this.UiSequencePlayer.PlayLevelSequenceByName("Jumpy", false, null, false);
		}
	}

	// Token: 0x06013908 RID: 80136 RVA: 0x00574DA4 File Offset: 0x00572FA4
	private UniTask ShowHideChildren(bool hide)
	{
		QuestTreeSeriesNodeItem.<ShowHideChildren>d__19 <ShowHideChildren>d__;
		<ShowHideChildren>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ShowHideChildren>d__.<>4__this = this;
		<ShowHideChildren>d__.hide = hide;
		<ShowHideChildren>d__.<>1__state = -1;
		<ShowHideChildren>d__.<>t__builder.Start<QuestTreeSeriesNodeItem.<ShowHideChildren>d__19>(ref <ShowHideChildren>d__);
		return <ShowHideChildren>d__.<>t__builder.Task;
	}

	// Token: 0x06013909 RID: 80137 RVA: 0x00574DEF File Offset: 0x00572FEF
	private void SetSizeItemActive(bool active)
	{
		if (this.Data.IsLastNodeOfMainQuestChildren())
		{
			base.GetUiSizeControlByOther(14).GetRootComponent().SetUIActive(false);
			return;
		}
		base.GetUiSizeControlByOther(14).GetRootComponent().SetUIActive(active);
	}

	// Token: 0x0601390A RID: 80138 RVA: 0x00574E25 File Offset: 0x00573025
	private void OnNodeUpdate(QuestTreeNodeData node)
	{
		if (node != this.Data && ((node != null) ? node.BelongedNode : null) != this.Data)
		{
			return;
		}
		this.RefreshInfo(this.Data);
	}

	// Token: 0x0601390B RID: 80139 RVA: 0x00574E51 File Offset: 0x00573051
	private void OnUpdateNode()
	{
		if (this.Data != null)
		{
			this.RefreshInfo(this.Data);
		}
	}

	// Token: 0x0601390C RID: 80140 RVA: 0x00574E68 File Offset: 0x00573068
	private void StartExpandHeightInterpolation()
	{
		UUISizeControlByOther uiSizeControlByOther = base.GetUiSizeControlByOther(14);
		float num = -(base.GetVerticalLayout(12).GetRootComponent().GetHeight() + this.OriginalAdditionalHeight);
		float originalAdditionalHeight = this.OriginalAdditionalHeight;
		uiSizeControlByOther.SetAdditionalHeight(num);
		ULTweenBPLibrary.FloatTo(GlobalData.World, this.InterpDelegate, num, originalAdditionalHeight, 0.3f, 0f, LTweenEase.OutCubic);
	}

	// Token: 0x0601390D RID: 80141 RVA: 0x00574EC4 File Offset: 0x005730C4
	private void StartShrinkHeightInterpolation()
	{
		float originalAdditionalHeight = this.OriginalAdditionalHeight;
		float endValue = -base.GetVerticalLayout(12).GetRootComponent().GetHeight();
		ULTweenBPLibrary.FloatTo(GlobalData.World, this.InterpDelegate, originalAdditionalHeight, endValue, 0.3f, 0f, LTweenEase.OutCubic);
	}

	// Token: 0x0601390E RID: 80142 RVA: 0x00574F0A File Offset: 0x0057310A
	private void OnInterpUpdate(float value)
	{
		base.GetUiSizeControlByOther(14).SetAdditionalHeight(value);
	}

	// Token: 0x0400985D RID: 39005
	private QuestTreeNodeData Data;

	// Token: 0x0400985E RID: 39006
	private GenericLayout<QuestTreeNodeItemBase<QuestTreeNodeData>, QuestTreeNodeData> LayoutChildren;

	// Token: 0x0400985F RID: 39007
	private bool HidingLayout;

	// Token: 0x04009860 RID: 39008
	private LevelSequencePlayer UiSequencePlayer;

	// Token: 0x04009861 RID: 39009
	[Nullable(2)]
	private FLTweenFloatSetterDynamic InterpDelegate;

	// Token: 0x04009862 RID: 39010
	private float OriginalAdditionalHeight;

	// Token: 0x02008A64 RID: 35428
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402EAB4 RID: 191156
		public const int Toggle = 0;

		// Token: 0x0402EAB5 RID: 191157
		public const int ItemFinish = 1;

		// Token: 0x0402EAB6 RID: 191158
		public const int ItemAvailable = 2;

		// Token: 0x0402EAB7 RID: 191159
		public const int ItemTracking = 3;

		// Token: 0x0402EAB8 RID: 191160
		public const int ItemLock = 4;

		// Token: 0x0402EAB9 RID: 191161
		public const int ItemInProgress = 5;

		// Token: 0x0402EABA RID: 191162
		public const int SpriteTypeIcon = 6;

		// Token: 0x0402EABB RID: 191163
		public const int TextName = 7;

		// Token: 0x0402EABC RID: 191164
		public const int TextProgress = 8;

		// Token: 0x0402EABD RID: 191165
		public const int ItemLeftLineParallel = 9;

		// Token: 0x0402EABE RID: 191166
		public const int ItemLeftLineUp = 10;

		// Token: 0x0402EABF RID: 191167
		public const int ItemChildren = 11;

		// Token: 0x0402EAC0 RID: 191168
		public const int LayoutChildren = 12;

		// Token: 0x0402EAC1 RID: 191169
		public const int ItemChild = 13;

		// Token: 0x0402EAC2 RID: 191170
		public const int ItemSize = 14;
	}
}
