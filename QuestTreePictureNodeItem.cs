using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020026BF RID: 9919
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class QuestTreePictureNodeItem : QuestTreeNodeItemBase<QuestTreeNodeData>
{
	// Token: 0x170018BB RID: 6331
	// (get) Token: 0x060138E3 RID: 80099 RVA: 0x0057395A File Offset: 0x00571B5A
	public override EQuestTreeNodeType Type
	{
		get
		{
			return EQuestTreeNodeType.Picture;
		}
	}

	// Token: 0x060138E4 RID: 80100 RVA: 0x00573960 File Offset: 0x00571B60
	protected unsafe override void OnRegisterComponent()
	{
		int num = 35;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(31, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(30, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(33, typeof(UUISizeControlByOther));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(32, typeof(UUISizeControlByOther));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(25, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(26, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(27, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(28, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(29, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(34, typeof(UUISizeControlByOther));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060138E5 RID: 80101 RVA: 0x00573E64 File Offset: 0x00572064
	protected override void OnStart()
	{
		this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
		UUIVerticalLayout verticalLayout = base.GetVerticalLayout(18);
		UUIVerticalLayout verticalLayout2 = base.GetVerticalLayout(16);
		if (verticalLayout == null || verticalLayout2 == null)
		{
			return;
		}
		this.LayoutChildrenGroup = new GenericLayout<QuestTreeNodeItemBase<List<QuestTreeNodeData>>, List<QuestTreeNodeData>>(verticalLayout, () => base.Loader.CreateLogicalNodeItem<List<QuestTreeNodeData>>(EQuestTreeNodeType.Container), null, true, true);
		this.LayoutChildrenGroupUp = new GenericLayout<QuestTreeNodeItemBase<List<QuestTreeNodeData>>, List<QuestTreeNodeData>>(verticalLayout2, () => base.Loader.CreateLogicalNodeItem<List<QuestTreeNodeData>>(EQuestTreeNodeType.Container), null, true, true);
		this.OriginalTopHeight = base.GetUiSizeControlByOther(32).GetAdditionalHeight();
		this.OriginalBottomHeight = base.GetUiSizeControlByOther(33).GetAdditionalHeight();
		base.GetItem(9).SetUIActive(false);
		this.OriginalAdditionalHeight = base.GetUiSizeControlByOther(34).GetAdditionalHeight();
		Ticker ticker = Singleton<TickSystem>.Instance.Add(new Action<float>(this.OnTick), "QuestTreePictureNodeItem", ETickingGroup.TG_PrePhysics, true, 0, true);
		this.TickId = ((ticker != null) ? ticker.Id : -1);
		ModelBase<QuestTreeModel>.Instance.ViewModelChapter.AddOnSelectedDataChange(new Action<QuestTreeNodeData>(this.OnSelectedDataChange));
		ModelBase<QuestTreeModel>.Instance.ViewModelChapter.AddOnLocatingNode(new Action<QuestTreeNodeData, bool>(this.OnLocateToNode));
		ModelBase<QuestTreeModel>.Instance.ViewModelChapter.AddOnUpdateNode(new Action(this.OnUpdateNode));
		Singleton<EventSystem>.Instance.Add(EEventName.QuestTreeNodeDataUpdate, new Action<QuestTreeNodeData>(this.OnDataUpdate));
	}

	// Token: 0x060138E6 RID: 80102 RVA: 0x00573FB8 File Offset: 0x005721B8
	protected override void OnBeforeDestroy()
	{
		if (this.TickId != -1)
		{
			Singleton<TickSystem>.Instance.Remove(this.TickId);
			this.TickId = -1;
		}
		Singleton<EventSystem>.Instance.Remove(EEventName.QuestTreeNodeDataUpdate, new Action<QuestTreeNodeData>(this.OnDataUpdate));
		ModelBase<QuestTreeModel>.Instance.ViewModelChapter.RemoveOnUpdateNode(new Action(this.OnUpdateNode));
		ModelBase<QuestTreeModel>.Instance.ViewModelChapter.RemoveOnLocatingNode(new Action<QuestTreeNodeData, bool>(this.OnLocateToNode));
		ModelBase<QuestTreeModel>.Instance.ViewModelChapter.RemoveOnSelectedDataChange(new Action<QuestTreeNodeData>(this.OnSelectedDataChange));
		ModelBase<QuestTreeModel>.Instance.ViewModelChapter.RemoveHeightBalanceValue(this.Data.Id);
	}

	// Token: 0x060138E7 RID: 80103 RVA: 0x00574070 File Offset: 0x00572270
	public override UniTask CreateSelf(UUIItem parent)
	{
		QuestTreePictureNodeItem.<CreateSelf>d__16 <CreateSelf>d__;
		<CreateSelf>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateSelf>d__.<>4__this = this;
		<CreateSelf>d__.parent = parent;
		<CreateSelf>d__.<>1__state = -1;
		<CreateSelf>d__.<>t__builder.Start<QuestTreePictureNodeItem.<CreateSelf>d__16>(ref <CreateSelf>d__);
		return <CreateSelf>d__.<>t__builder.Task;
	}

	// Token: 0x060138E8 RID: 80104 RVA: 0x005740BB File Offset: 0x005722BB
	public override void UpdateData(QuestTreeNodeData data)
	{
		this.UpdateDataAsync(data);
	}

	// Token: 0x060138E9 RID: 80105 RVA: 0x005740C8 File Offset: 0x005722C8
	public UniTask UpdateDataAsync(QuestTreeNodeData data)
	{
		QuestTreePictureNodeItem.<UpdateDataAsync>d__18 <UpdateDataAsync>d__;
		<UpdateDataAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<UpdateDataAsync>d__.<>4__this = this;
		<UpdateDataAsync>d__.data = data;
		<UpdateDataAsync>d__.<>1__state = -1;
		<UpdateDataAsync>d__.<>t__builder.Start<QuestTreePictureNodeItem.<UpdateDataAsync>d__18>(ref <UpdateDataAsync>d__);
		return <UpdateDataAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060138EA RID: 80106 RVA: 0x00574113 File Offset: 0x00572313
	public override void Refresh(QuestTreeNodeData data, bool isSelected, int gridIndex)
	{
		this.UpdateData(data);
	}

	// Token: 0x060138EB RID: 80107 RVA: 0x0057411C File Offset: 0x0057231C
	public override UniTask RefreshAsync(QuestTreeNodeData data, bool isSelected, int gridIndex)
	{
		QuestTreePictureNodeItem.<RefreshAsync>d__20 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.data = data;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<QuestTreePictureNodeItem.<RefreshAsync>d__20>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060138EC RID: 80108 RVA: 0x00574168 File Offset: 0x00572368
	public override float GetAdditionalHeight()
	{
		QuestTreeNodeData nextQuestNode = this.Data.NextQuestNode;
		if (nextQuestNode != null && nextQuestNode.Config.NodeType == 3 && this.Child != null)
		{
			return (this.Child as QuestTreeNodeItemBase<QuestTreeNodeData>).GetAdditionalHeight() + base.GetExtendToggle(0).GetRootComponent().GetHeight();
		}
		return 0f;
	}

	// Token: 0x060138ED RID: 80109 RVA: 0x005741CC File Offset: 0x005723CC
	protected override void LocateSelf(bool tween = true)
	{
		UUIItem rootComponent = base.GetExtendToggle(0).GetRootComponent();
		QuestTreeNodeLocatingHelper locatingHelper = ModelBase<QuestTreeModel>.Instance.ViewModelChapter.LocatingHelper;
		if (locatingHelper != null)
		{
			locatingHelper.LocateToNode(rootComponent, tween, false);
		}
		this.SeqPlayer.PlayLevelSequenceByName("Jumpy", false, null, false);
	}

	// Token: 0x060138EE RID: 80110 RVA: 0x00574220 File Offset: 0x00572420
	private void RefreshInfo(QuestTreeNodeData data)
	{
		base.SetTextureByPath(data.ImageSmall, base.GetTexture(1), null, null);
		base.GetItem(2).SetUIActive(!data.IsTracking && data.State == EQuestTreeNodeState.Locked);
		base.GetItem(3).SetUIActive(false);
		base.GetItem(4).SetUIActive(!data.IsTracking && data.State == EQuestTreeNodeState.Available);
		base.GetItem(5).SetUIActive(data.IsTracking);
		base.GetItem(6).SetUIActive(data.State == EQuestTreeNodeState.InProgress);
		this.SetSpriteByPath(data.TypeIconPath, base.GetSprite(7), false, null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), data.Name, Array.Empty<object>());
		float height = base.GetExtendToggle(0).GetRootComponent().GetHeight();
		ModelBase<QuestTreeModel>.Instance.ViewModelChapter.RecordToggleHeight(height);
	}

	// Token: 0x060138EF RID: 80111 RVA: 0x0057431C File Offset: 0x0057251C
	private UniTask RefreshChildNode(QuestTreeNodeData data)
	{
		QuestTreePictureNodeItem.<RefreshChildNode>d__24 <RefreshChildNode>d__;
		<RefreshChildNode>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshChildNode>d__.<>4__this = this;
		<RefreshChildNode>d__.data = data;
		<RefreshChildNode>d__.<>1__state = -1;
		<RefreshChildNode>d__.<>t__builder.Start<QuestTreePictureNodeItem.<RefreshChildNode>d__24>(ref <RefreshChildNode>d__);
		return <RefreshChildNode>d__.<>t__builder.Task;
	}

	// Token: 0x060138F0 RID: 80112 RVA: 0x00574368 File Offset: 0x00572568
	private UniTask AttachNextNodeParallel(QuestTreeNodeData nextNode)
	{
		QuestTreePictureNodeItem.<AttachNextNodeParallel>d__25 <AttachNextNodeParallel>d__;
		<AttachNextNodeParallel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<AttachNextNodeParallel>d__.<>4__this = this;
		<AttachNextNodeParallel>d__.nextNode = nextNode;
		<AttachNextNodeParallel>d__.<>1__state = -1;
		<AttachNextNodeParallel>d__.<>t__builder.Start<QuestTreePictureNodeItem.<AttachNextNodeParallel>d__25>(ref <AttachNextNodeParallel>d__);
		return <AttachNextNodeParallel>d__.<>t__builder.Task;
	}

	// Token: 0x060138F1 RID: 80113 RVA: 0x005743B4 File Offset: 0x005725B4
	private UniTask AttachNextNodeDown(QuestTreeNodeData nextNode)
	{
		QuestTreePictureNodeItem.<AttachNextNodeDown>d__26 <AttachNextNodeDown>d__;
		<AttachNextNodeDown>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<AttachNextNodeDown>d__.<>4__this = this;
		<AttachNextNodeDown>d__.nextNode = nextNode;
		<AttachNextNodeDown>d__.<>1__state = -1;
		<AttachNextNodeDown>d__.<>t__builder.Start<QuestTreePictureNodeItem.<AttachNextNodeDown>d__26>(ref <AttachNextNodeDown>d__);
		return <AttachNextNodeDown>d__.<>t__builder.Task;
	}

	// Token: 0x060138F2 RID: 80114 RVA: 0x00574400 File Offset: 0x00572600
	private void FixSize()
	{
		if (this.Data.Config.QuestType != 1)
		{
			return;
		}
		UUISizeControlByOther uiSizeControlByOther = base.GetUiSizeControlByOther(33);
		UUISizeControlByOther uiSizeControlByOther2 = base.GetUiSizeControlByOther(32);
		float num = uiSizeControlByOther2.GetRootComponent().GetHeight() - uiSizeControlByOther2.GetAdditionalHeight();
		float num2 = uiSizeControlByOther.GetRootComponent().GetHeight() - uiSizeControlByOther.GetAdditionalHeight();
		float num3 = num2 - num;
		ModelBase<QuestTreeModel>.Instance.ViewModelChapter.RecordHeightBalanceValue(this.Data.Id, num, num2);
		if (Math.Abs(num3) <= 1f)
		{
			return;
		}
		if (num3 > 0f)
		{
			uiSizeControlByOther2.SetAdditionalHeight(this.OriginalTopHeight + num + num3);
			return;
		}
		uiSizeControlByOther.SetAdditionalHeight(this.OriginalBottomHeight + num2 - num3);
	}

	// Token: 0x060138F3 RID: 80115 RVA: 0x005744BC File Offset: 0x005726BC
	private void HideAllChildArea()
	{
		base.GetItem(10).SetUIActive(false);
		base.GetItem(11).SetUIActive(false);
		base.GetItem(12).SetUIActive(false);
		base.GetItem(13).SetUIActive(false);
		base.GetVerticalLayout(16).GetRootComponent().SetUIActive(false);
		base.GetItem(17).SetUIActive(false);
		base.GetVerticalLayout(18).GetRootComponent().SetUIActive(false);
		base.GetItem(19).SetUIActive(false);
		base.GetItem(14).SetUIActive(false);
		base.GetItem(15).SetUIActive(false);
		base.GetItem(31).SetUIActive(false);
		base.GetItem(30).SetUIActive(false);
		base.GetItem(20).SetUIActive(false);
		base.GetItem(21).SetUIActive(false);
		base.GetItem(22).SetUIActive(false);
		base.GetItem(23).SetUIActive(false);
		base.GetItem(24).SetUIActive(false);
		base.GetItem(25).SetUIActive(false);
		base.GetItem(26).SetUIActive(false);
		base.GetItem(27).SetUIActive(false);
		base.GetItem(28).SetUIActive(false);
		base.GetItem(29).SetUIActive(false);
	}

	// Token: 0x060138F4 RID: 80116 RVA: 0x00574608 File Offset: 0x00572808
	private void OnTick(float deltaTime)
	{
		this.FixSize();
		UUISizeControlByOther uiSizeControlByOther = base.GetUiSizeControlByOther(34);
		QuestTreeNodeItemBase<List<QuestTreeNodeData>> layoutItemByIndex = this.LayoutChildrenGroup.GetLayoutItemByIndex(this.LayoutChildrenGroup.GetDatas().Count - 1);
		if (layoutItemByIndex == null)
		{
			return;
		}
		uiSizeControlByOther.SetAdditionalHeight(this.OriginalAdditionalHeight - layoutItemByIndex.GetAdditionalHeight());
	}

	// Token: 0x060138F5 RID: 80117 RVA: 0x0057465C File Offset: 0x0057285C
	private void OnClick(EToggleState _)
	{
		ModelBase<QuestTreeModel>.Instance.ViewModelChapter.SelectData(this.Data);
		ControllerBase<QuestTreeController>.Instance.ReportClickNode(this.Data);
		if (this.Data.IsDummy)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("QuestTree_ToBeContinued", Array.Empty<object>());
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			return;
		}
		ControllerBase<QuestTreeController>.Instance.OpenNodeDetailView(this.Data);
	}

	// Token: 0x060138F6 RID: 80118 RVA: 0x005746D1 File Offset: 0x005728D1
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

	// Token: 0x060138F7 RID: 80119 RVA: 0x00574706 File Offset: 0x00572906
	private void OnDataUpdate(QuestTreeNodeData data)
	{
		if (data != this.Data)
		{
			return;
		}
		this.RefreshInfo(data);
	}

	// Token: 0x060138F8 RID: 80120 RVA: 0x00574719 File Offset: 0x00572919
	[NullableContext(2)]
	private void OnLocateToNode(QuestTreeNodeData data, bool tween)
	{
		if (data != this.Data)
		{
			return;
		}
		this.LocateSelf(tween);
		ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(this.RootItem, true, false, false);
	}

	// Token: 0x060138F9 RID: 80121 RVA: 0x00574740 File Offset: 0x00572940
	private void OnUpdateNode()
	{
		if (this.Data != null)
		{
			this.RefreshInfo(this.Data);
		}
	}

	// Token: 0x04009853 RID: 38995
	private const float EPS = 1f;

	// Token: 0x04009854 RID: 38996
	private QuestTreeNodeData Data;

	// Token: 0x04009855 RID: 38997
	private GenericLayout<QuestTreeNodeItemBase<List<QuestTreeNodeData>>, List<QuestTreeNodeData>> LayoutChildrenGroup;

	// Token: 0x04009856 RID: 38998
	private GenericLayout<QuestTreeNodeItemBase<List<QuestTreeNodeData>>, List<QuestTreeNodeData>> LayoutChildrenGroupUp;

	// Token: 0x04009857 RID: 38999
	private LevelSequencePlayer SeqPlayer;

	// Token: 0x04009858 RID: 39000
	[Nullable(2)]
	private IQuestTreeNodeItem Child;

	// Token: 0x04009859 RID: 39001
	public float OriginalTopHeight;

	// Token: 0x0400985A RID: 39002
	public float OriginalBottomHeight;

	// Token: 0x0400985B RID: 39003
	private float OriginalAdditionalHeight;

	// Token: 0x0400985C RID: 39004
	private int TickId = -1;

	// Token: 0x02008A5D RID: 35421
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402EA70 RID: 191088
		public const int ToggleQuest = 0;

		// Token: 0x0402EA71 RID: 191089
		public const int TextureQuest = 1;

		// Token: 0x0402EA72 RID: 191090
		public const int ItemLock = 2;

		// Token: 0x0402EA73 RID: 191091
		public const int ItemFinish = 3;

		// Token: 0x0402EA74 RID: 191092
		public const int ItemAvailable = 4;

		// Token: 0x0402EA75 RID: 191093
		public const int ItemTrack = 5;

		// Token: 0x0402EA76 RID: 191094
		public const int ItemInProgress = 6;

		// Token: 0x0402EA77 RID: 191095
		public const int SpriteType = 7;

		// Token: 0x0402EA78 RID: 191096
		public const int TextName = 8;

		// Token: 0x0402EA79 RID: 191097
		public const int ItemNew = 9;

		// Token: 0x0402EA7A RID: 191098
		public const int ItemLeftLineDown = 10;

		// Token: 0x0402EA7B RID: 191099
		public const int ItemLeftLineUp = 11;

		// Token: 0x0402EA7C RID: 191100
		public const int ItemMainLine = 12;

		// Token: 0x0402EA7D RID: 191101
		public const int ItemChildNodeAreaUp = 13;

		// Token: 0x0402EA7E RID: 191102
		public const int SprintTopLineTypeA = 14;

		// Token: 0x0402EA7F RID: 191103
		public const int SprintTopLineTypeB = 15;

		// Token: 0x0402EA80 RID: 191104
		public const int ItemChildNodeParentUp = 16;

		// Token: 0x0402EA81 RID: 191105
		public const int ItemChildNodeAreaDown = 17;

		// Token: 0x0402EA82 RID: 191106
		public const int LayoutChildNodeParentDown = 18;

		// Token: 0x0402EA83 RID: 191107
		public const int ItemChildNodeGroupTemplate = 19;

		// Token: 0x0402EA84 RID: 191108
		public const int ItemNextNodeAreaDownForSeries = 20;

		// Token: 0x0402EA85 RID: 191109
		public const int ItemNextNodeParentDownForSeries = 21;

		// Token: 0x0402EA86 RID: 191110
		public const int ItemNextNodeAreaDownForPicture = 22;

		// Token: 0x0402EA87 RID: 191111
		public const int ItemNextNodeParentDownForPicture = 23;

		// Token: 0x0402EA88 RID: 191112
		public const int ItemNextNodeAreaDownForText = 24;

		// Token: 0x0402EA89 RID: 191113
		public const int ItemNextNodeParentDownForText = 25;

		// Token: 0x0402EA8A RID: 191114
		public const int ItemNextNodeAreaParallelForPicture = 26;

		// Token: 0x0402EA8B RID: 191115
		public const int ItemNextNodeParentParallelForPicture = 27;

		// Token: 0x0402EA8C RID: 191116
		public const int ItemNextNodeAreaParallelForOther = 28;

		// Token: 0x0402EA8D RID: 191117
		public const int ItemNextNodeParentParallelForOther = 29;

		// Token: 0x0402EA8E RID: 191118
		public const int ItemRightLineShort = 30;

		// Token: 0x0402EA8F RID: 191119
		public const int ItemRightLineUp = 31;

		// Token: 0x0402EA90 RID: 191120
		public const int ItemSizeControlTop = 32;

		// Token: 0x0402EA91 RID: 191121
		public const int ItemSizeControlBottom = 33;

		// Token: 0x0402EA92 RID: 191122
		public const int SizeLine = 34;
	}
}
