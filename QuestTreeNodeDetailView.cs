using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020026C4 RID: 9924
[NullableContext(1)]
[Nullable(0)]
public class QuestTreeNodeDetailView : UiViewBase, IPopViewWithCustomUiBlurItem
{
	// Token: 0x06013935 RID: 80181 RVA: 0x00575E33 File Offset: 0x00574033
	public QuestTreeNodeDetailView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06013936 RID: 80182 RVA: 0x00575E3C File Offset: 0x0057403C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 25;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIScrollViewWithScrollbarComponent));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06013937 RID: 80183 RVA: 0x005761B0 File Offset: 0x005743B0
	protected override UniTask OnBeforeStartAsync()
	{
		QuestTreeNodeDetailView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<QuestTreeNodeDetailView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013938 RID: 80184 RVA: 0x005761F4 File Offset: 0x005743F4
	protected override void OnStart()
	{
		base.GetRootItem().SetStretchTop(0f);
		base.GetRootItem().SetStretchBottom(0f);
		base.GetRootItem().SetStretchLeft(0f);
		base.GetRootItem().SetStretchRight(0f);
	}

	// Token: 0x06013939 RID: 80185 RVA: 0x00576241 File Offset: 0x00574441
	protected override void OnBeforeShow()
	{
		ModelBase<QuestTreeModel>.Instance.ViewModelChapter.SelectData(this.Data);
	}

	// Token: 0x0601393A RID: 80186 RVA: 0x00576258 File Offset: 0x00574458
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.QuestTreeNodeDataUpdate, new Action<QuestTreeNodeData>(this.OnDataUpdate));
	}

	// Token: 0x0601393B RID: 80187 RVA: 0x00576276 File Offset: 0x00574476
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.QuestTreeNodeDataUpdate, new Action<QuestTreeNodeData>(this.OnDataUpdate));
	}

	// Token: 0x0601393C RID: 80188 RVA: 0x00576294 File Offset: 0x00574494
	protected override void OnBeforeDestroy()
	{
		ModelBase<QuestTreeModel>.Instance.ViewModelChapter.SelectData(null);
	}

	// Token: 0x0601393D RID: 80189 RVA: 0x005762A6 File Offset: 0x005744A6
	public void ChangeData(QuestTreeNodeData data)
	{
		this.Data = data;
		this.RefreshInfos();
	}

	// Token: 0x0601393E RID: 80190 RVA: 0x005762B6 File Offset: 0x005744B6
	public UUIItem GetOverrideRootItem()
	{
		return base.GetRootItem();
	}

	// Token: 0x0601393F RID: 80191 RVA: 0x005762C0 File Offset: 0x005744C0
	private UniTask RefreshInfos()
	{
		QuestTreeNodeDetailView.<RefreshInfos>d__20 <RefreshInfos>d__;
		<RefreshInfos>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshInfos>d__.<>4__this = this;
		<RefreshInfos>d__.<>1__state = -1;
		<RefreshInfos>d__.<>t__builder.Start<QuestTreeNodeDetailView.<RefreshInfos>d__20>(ref <RefreshInfos>d__);
		return <RefreshInfos>d__.<>t__builder.Task;
	}

	// Token: 0x06013940 RID: 80192 RVA: 0x00576304 File Offset: 0x00574504
	[NullableContext(2)]
	private TsUiBlur GetUiBlurComponent()
	{
		UUIItem rootItem = base.GetRootItem();
		if (rootItem == null)
		{
			return null;
		}
		return rootItem.GetOwner().GetComponentByClass(TsUiBlur.StaticClass()) as TsUiBlur;
	}

	// Token: 0x06013941 RID: 80193 RVA: 0x00576338 File Offset: 0x00574538
	private void SetUiBlurOverrideItem()
	{
		TsUiBlur uiBlurComponent = this.GetUiBlurComponent();
		if (uiBlurComponent == null)
		{
			return;
		}
		QuestTreeChapterView view = ModelBase<QuestTreeModel>.Instance.ViewModelChapter.View;
		UUIItem uuiitem = (view != null) ? view.GetOverrideBlurItem() : null;
		if (uuiitem == null || !uuiitem.IsValid())
		{
			return;
		}
		uiBlurComponent.OverrideItem = uuiitem.GetOwner();
	}

	// Token: 0x06013942 RID: 80194 RVA: 0x00576384 File Offset: 0x00574584
	private bool ShouldShowGotoBtn()
	{
		if (this.Data.IsTracking)
		{
			return false;
		}
		if (this.Data.State == EQuestTreeNodeState.Available)
		{
			return true;
		}
		Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(this.Data.QuestId);
		if (quest == null)
		{
			return false;
		}
		if (quest.IsSuspend() && quest.GetSuspendType() == EBehaviorTreeSuspendType.Online)
		{
			return false;
		}
		EQuestSpecialState questSpecialState = ModelBase<QuestNewModel>.Instance.GetQuestSpecialState(quest);
		bool flag = questSpecialState - EQuestSpecialState.LockByLackResource <= 1 || questSpecialState == EQuestSpecialState.NotInFocusModeButLock;
		if (flag)
		{
			this.IsRefreshedFromSuspended = true;
			return true;
		}
		return this.Data.State == EQuestTreeNodeState.InProgress;
	}

	// Token: 0x06013943 RID: 80195 RVA: 0x00576418 File Offset: 0x00574618
	private void RefreshGotoBtnText()
	{
		if (this.Data.State == EQuestTreeNodeState.Available)
		{
			this.BtnGoto.SetLocalTextNew("QuestTree_Status_Acceptable_Go", Array.Empty<object>());
			return;
		}
		Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(this.Data.QuestId);
		if (quest == null)
		{
			return;
		}
		EQuestSpecialState questSpecialState = ModelBase<QuestNewModel>.Instance.GetQuestSpecialState(quest);
		if (questSpecialState == EQuestSpecialState.LockByLackResource)
		{
			this.BtnGoto.SetLocalTextNew("GoToDownload", Array.Empty<object>());
			return;
		}
		if (questSpecialState == EQuestSpecialState.ResourceReadyButLock)
		{
			this.BtnGoto.SetLocalTextNew("GoOnTask", Array.Empty<object>());
			return;
		}
		if (questSpecialState != EQuestSpecialState.NotInFocusModeButLock)
		{
			this.BtnGoto.SetLocalTextNew("QuestTree_Status_Ongoing_Go", Array.Empty<object>());
			return;
		}
		this.BtnGoto.SetLocalTextNew("Task_Focus_Tips02", Array.Empty<object>());
	}

	// Token: 0x06013944 RID: 80196 RVA: 0x005764D8 File Offset: 0x005746D8
	private void RefreshLockText()
	{
		Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(this.Data.QuestId);
		if (quest == null)
		{
			return;
		}
		if (ModelBase<QuestNewModel>.Instance.GetQuestSpecialState(quest) == EQuestSpecialState.LockByFocusMode)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(23), "QuestTree_FocusModeTips", Array.Empty<object>());
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(23), "QuestTree_Status_Locked", Array.Empty<object>());
	}

	// Token: 0x06013945 RID: 80197 RVA: 0x00576546 File Offset: 0x00574746
	private void OnBtnCancelClick(int _)
	{
		ControllerBase<QuestTreeController>.Instance.ReportJump(this.Data, EQuestTreeLogReportJumpMotion.UnTrack);
		ControllerBase<QuestTreeController>.Instance.CancelTrackNode(this.Data);
	}

	// Token: 0x06013946 RID: 80198 RVA: 0x0057656C File Offset: 0x0057476C
	private void OnBtnGotoClick(int _)
	{
		Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(this.Data.QuestId);
		EQuestSpecialState equestSpecialState = (quest != null) ? ModelBase<QuestNewModel>.Instance.GetQuestSpecialState(quest) : EQuestSpecialState.None;
		if (this.Data.State == EQuestTreeNodeState.Available && equestSpecialState != EQuestSpecialState.LockByLackResource)
		{
			Func<bool> onAcceptGoto = this.Data.GetOnAcceptGoto();
			if (onAcceptGoto != null && onAcceptGoto())
			{
				base.CloseMe(null);
			}
			ControllerBase<QuestTreeController>.Instance.ReportJump(this.Data, EQuestTreeLogReportJumpMotion.Acceptable);
			return;
		}
		ControllerBase<QuestTreeController>.Instance.ReportJump(this.Data, EQuestTreeLogReportJumpMotion.Goto);
		ControllerBase<QuestTreeController>.Instance.TrackOrGotoNode(this.Data);
	}

	// Token: 0x06013947 RID: 80199 RVA: 0x00576604 File Offset: 0x00574804
	private void OnDataUpdate(QuestTreeNodeData data)
	{
		if (data == this.Data)
		{
			this.OnDataUpdateImp();
		}
	}

	// Token: 0x06013948 RID: 80200 RVA: 0x00576618 File Offset: 0x00574818
	private UniTask OnDataUpdateImp()
	{
		QuestTreeNodeDetailView.<OnDataUpdateImp>d__29 <OnDataUpdateImp>d__;
		<OnDataUpdateImp>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnDataUpdateImp>d__.<>4__this = this;
		<OnDataUpdateImp>d__.<>1__state = -1;
		<OnDataUpdateImp>d__.<>t__builder.Start<QuestTreeNodeDetailView.<OnDataUpdateImp>d__29>(ref <OnDataUpdateImp>d__);
		return <OnDataUpdateImp>d__.<>t__builder.Task;
	}

	// Token: 0x0400986A RID: 39018
	private QuestTreeNodeData Data;

	// Token: 0x0400986B RID: 39019
	private QuestTreeDetailImageItem ImageItem;

	// Token: 0x0400986C RID: 39020
	private GenericLayout<QuestTreeNodeTargetItem, IQuestTreeNodeTarget> LayoutTargets;

	// Token: 0x0400986D RID: 39021
	private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> ScrollRewards;

	// Token: 0x0400986E RID: 39022
	private ButtonItem BtnCancel;

	// Token: 0x0400986F RID: 39023
	private ButtonItem BtnGoto;

	// Token: 0x04009870 RID: 39024
	private ButtonItem BtnGotoHalf;

	// Token: 0x04009871 RID: 39025
	private QuestTreeNodeDetailTipsItem TipsItem;

	// Token: 0x04009872 RID: 39026
	private bool IsRefreshedFromSuspended;

	// Token: 0x02008A6F RID: 35439
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402EB08 RID: 191240
		public const int SpriteTypeIcon = 0;

		// Token: 0x0402EB09 RID: 191241
		public const int TextName = 1;

		// Token: 0x0402EB0A RID: 191242
		public const int TextRegion = 2;

		// Token: 0x0402EB0B RID: 191243
		public const int ItemMultiPics = 3;

		// Token: 0x0402EB0C RID: 191244
		public const int ItemPic = 4;

		// Token: 0x0402EB0D RID: 191245
		public const int ItemInUse = 5;

		// Token: 0x0402EB0E RID: 191246
		public const int ItemTargetParent = 6;

		// Token: 0x0402EB0F RID: 191247
		public const int ItemTargetTitleParent = 7;

		// Token: 0x0402EB10 RID: 191248
		public const int TextTargetTitle = 8;

		// Token: 0x0402EB11 RID: 191249
		public const int LayoutTargets = 9;

		// Token: 0x0402EB12 RID: 191250
		public const int ItemTarget = 10;

		// Token: 0x0402EB13 RID: 191251
		public const int TextDesc = 11;

		// Token: 0x0402EB14 RID: 191252
		public const int ItemRewardParent = 12;

		// Token: 0x0402EB15 RID: 191253
		public const int ItemRewardContent = 13;

		// Token: 0x0402EB16 RID: 191254
		public const int ItemReward = 14;

		// Token: 0x0402EB17 RID: 191255
		public const int ItemBtnParent = 15;

		// Token: 0x0402EB18 RID: 191256
		public const int ItemBtnCancelTrack = 16;

		// Token: 0x0402EB19 RID: 191257
		public const int ItemBtnGotoHalf = 17;

		// Token: 0x0402EB1A RID: 191258
		public const int ItemBtnGoto = 18;

		// Token: 0x0402EB1B RID: 191259
		public const int ItemFinished = 19;

		// Token: 0x0402EB1C RID: 191260
		public const int ItemLock = 20;

		// Token: 0x0402EB1D RID: 191261
		public const int ItemInUseBottom = 21;

		// Token: 0x0402EB1E RID: 191262
		public const int ScrollRewards = 22;

		// Token: 0x0402EB1F RID: 191263
		public const int TextLock = 23;

		// Token: 0x0402EB20 RID: 191264
		public const int ScrollText = 24;
	}
}
