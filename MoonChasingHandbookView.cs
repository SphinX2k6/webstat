using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020013EE RID: 5102
[NullableContext(1)]
[Nullable(0)]
public class MoonChasingHandbookView : UiViewBase
{
	// Token: 0x06008D6E RID: 36206 RVA: 0x00253196 File Offset: 0x00251396
	public MoonChasingHandbookView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06008D6F RID: 36207 RVA: 0x002531A0 File Offset: 0x002513A0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
	}

	// Token: 0x06008D70 RID: 36208 RVA: 0x00253228 File Offset: 0x00251428
	protected override UniTask OnBeforeStartAsync()
	{
		MoonChasingHandbookView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MoonChasingHandbookView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008D71 RID: 36209 RVA: 0x0025326B File Offset: 0x0025146B
	protected override void OnBeforeShow()
	{
		this.RefreshLayout();
		this.RefreshCount();
		this.RewardPanel.RefreshLayout();
		ControllerBase<ActivityMoonChasingController>.Instance.CheckIsActivityClose();
	}

	// Token: 0x06008D72 RID: 36210 RVA: 0x0025328E File Offset: 0x0025148E
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RefreshRewardPopUp, new Action<RewardPopupData>(this.OnRefreshRewardPopUp));
		Singleton<EventSystem>.Instance.Add(EEventName.TrackMoonHandbookUpdate, new Action(this.OnTrackMoonHandbookUpdate));
	}

	// Token: 0x06008D73 RID: 36211 RVA: 0x002532C8 File Offset: 0x002514C8
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshRewardPopUp, new Action<RewardPopupData>(this.OnRefreshRewardPopUp));
		Singleton<EventSystem>.Instance.Remove(EEventName.TrackMoonHandbookUpdate, new Action(this.OnTrackMoonHandbookUpdate));
	}

	// Token: 0x06008D74 RID: 36212 RVA: 0x00253302 File Offset: 0x00251502
	private HandbookDisplayGrid OnCreateDisplayGrid()
	{
		return new HandbookDisplayGrid();
	}

	// Token: 0x06008D75 RID: 36213 RVA: 0x0025330C File Offset: 0x0025150C
	private void RefreshCount()
	{
		int handbookUnlockCount = ModelBase<MoonChasingModel>.Instance.GetHandbookUnlockCount();
		base.GetText(3).SetText(handbookUnlockCount.ToString(), true);
	}

	// Token: 0x06008D76 RID: 36214 RVA: 0x00253338 File Offset: 0x00251538
	private void RefreshLayout()
	{
		List<IHandbookGridData> handbookGridList = ModelBase<MoonChasingModel>.Instance.GetHandbookGridList();
		this.DisplayGridLayout.RefreshByData(handbookGridList, false, null, true);
	}

	// Token: 0x06008D77 RID: 36215 RVA: 0x0025335F File Offset: 0x0025155F
	private void OnRefreshRewardPopUp(RewardPopupData data)
	{
		this.RewardPopup.Refresh(data);
	}

	// Token: 0x06008D78 RID: 36216 RVA: 0x0025336D File Offset: 0x0025156D
	private void OnTrackMoonHandbookUpdate()
	{
		this.RewardPopup.SetActive(false);
		this.RewardPanel.RefreshLayout();
	}

	// Token: 0x040041E3 RID: 16867
	private PopupCaptionItem CaptionItem;

	// Token: 0x040041E4 RID: 16868
	private LoopScrollView<HandbookDisplayGrid, IHandbookGridData> DisplayGridLayout;

	// Token: 0x040041E5 RID: 16869
	private HandbookRewardPanel RewardPanel;

	// Token: 0x040041E6 RID: 16870
	private CommonRewardPopup RewardPopup;

	// Token: 0x020077E4 RID: 30692
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04029418 RID: 168984
		public const int Caption = 0;

		// Token: 0x04029419 RID: 168985
		public const int DisplayLayout = 1;

		// Token: 0x0402941A RID: 168986
		public const int DisplayItem = 2;

		// Token: 0x0402941B RID: 168987
		public const int TxtUnlock = 3;

		// Token: 0x0402941C RID: 168988
		public const int PanelReward = 4;
	}
}
