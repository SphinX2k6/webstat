using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001AE0 RID: 6880
[NullableContext(2)]
[Nullable(0)]
public class DangoAbyssInfoView : UiViewBase
{
	// Token: 0x0600C5FA RID: 50682 RVA: 0x00344B36 File Offset: 0x00342D36
	[NullableContext(1)]
	public DangoAbyssInfoView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600C5FB RID: 50683 RVA: 0x00344B40 File Offset: 0x00342D40
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
	}

	// Token: 0x0600C5FC RID: 50684 RVA: 0x00344BF2 File Offset: 0x00342DF2
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnAbyssRoomInfoUpdate, new Action(this.OnAbyssRoomInfoUpdate));
	}

	// Token: 0x0600C5FD RID: 50685 RVA: 0x00344C10 File Offset: 0x00342E10
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAbyssRoomInfoUpdate, new Action(this.OnAbyssRoomInfoUpdate));
	}

	// Token: 0x0600C5FE RID: 50686 RVA: 0x00344C30 File Offset: 0x00342E30
	protected override UniTask OnBeforeStartAsync()
	{
		DangoAbyssInfoView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DangoAbyssInfoView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C5FF RID: 50687 RVA: 0x00344C73 File Offset: 0x00342E73
	private void OnAbyssRoomInfoUpdate()
	{
		this.RefreshProgressElements();
	}

	// Token: 0x0600C600 RID: 50688 RVA: 0x00344C7B File Offset: 0x00342E7B
	private void OnRefreshTime(float _)
	{
		this.RefreshTimeText();
	}

	// Token: 0x0600C601 RID: 50689 RVA: 0x00344C84 File Offset: 0x00342E84
	private void RefreshProgressElements()
	{
		float instanceProgress = ModelBase<DangoAbyssModel>.Instance.GetInstanceProgress();
		this.RefreshRewardItem(instanceProgress);
	}

	// Token: 0x0600C602 RID: 50690 RVA: 0x00344CA3 File Offset: 0x00342EA3
	private void OnCloseBtnClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600C603 RID: 50691 RVA: 0x00344CAC File Offset: 0x00342EAC
	protected override void OnBeforeShow()
	{
		this.RefreshDeadText();
		this.RefreshFloorText();
		this.RefreshTimeText();
		this.RefreshProgressElements();
		this.RefreshTitleText();
		this.RefreshDescText();
	}

	// Token: 0x0600C604 RID: 50692 RVA: 0x00344CD4 File Offset: 0x00342ED4
	private void RefreshDeadText()
	{
		string instanceReviveTipTips = ModelBase<DangoAbyssModel>.Instance.GetInstanceReviveTipTips();
		SpriteTextItem deadInfoItem = this.DeadInfoItem;
		if (deadInfoItem == null)
		{
			return;
		}
		deadInfoItem.SetDesc(instanceReviveTipTips);
	}

	// Token: 0x0600C605 RID: 50693 RVA: 0x00344D00 File Offset: 0x00342F00
	private void RefreshFloorText()
	{
		string instanceFloorDetailProgressText = ModelBase<DangoAbyssModel>.Instance.GetInstanceFloorDetailProgressText();
		SpriteTextItem roomInfoItem = this.RoomInfoItem;
		if (roomInfoItem == null)
		{
			return;
		}
		roomInfoItem.SetDesc(instanceFloorDetailProgressText);
	}

	// Token: 0x0600C606 RID: 50694 RVA: 0x00344D2C File Offset: 0x00342F2C
	private void RefreshTimeText()
	{
		string instanceRemainTimeText = ModelBase<DangoAbyssModel>.Instance.GetInstanceRemainTimeText();
		SpriteTextItem timeItem = this.TimeItem;
		if (timeItem == null)
		{
			return;
		}
		timeItem.SetDesc(instanceRemainTimeText);
	}

	// Token: 0x0600C607 RID: 50695 RVA: 0x00344D58 File Offset: 0x00342F58
	private void RefreshTitleText()
	{
		string currentAbyssName = ModelBase<DangoAbyssModel>.Instance.GetCurrentAbyssName();
		if (currentAbyssName != "")
		{
			SpriteTextItem currentLevelTitleItem = this.CurrentLevelTitleItem;
			if (currentLevelTitleItem == null)
			{
				return;
			}
			currentLevelTitleItem.SetDesc(currentAbyssName);
		}
	}

	// Token: 0x0600C608 RID: 50696 RVA: 0x00344D90 File Offset: 0x00342F90
	private void RefreshDescText()
	{
		string currentRouteDesc = ModelBase<DangoAbyssModel>.Instance.GetCurrentRouteDesc();
		DescItem descItem = this.DescItem;
		if (descItem == null)
		{
			return;
		}
		descItem.SetDesc(currentRouteDesc);
	}

	// Token: 0x0600C609 RID: 50697 RVA: 0x00344DB9 File Offset: 0x00342FB9
	private void RefreshRewardItem(float progress)
	{
		RewardInfoItem rewardItem = this.RewardItem;
		if (rewardItem == null)
		{
			return;
		}
		rewardItem.RefreshByProgress(progress);
	}

	// Token: 0x0600C60A RID: 50698 RVA: 0x00344DCC File Offset: 0x00342FCC
	protected override void OnBeforeDestroy()
	{
		if (this.RefreshTimer != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.RefreshTimer);
			this.RefreshTimer = null;
		}
	}

	// Token: 0x04005EDF RID: 24287
	private PopupCaptionItem CaptionItem;

	// Token: 0x04005EE0 RID: 24288
	private SpriteTextItem CurrentLevelTitleItem;

	// Token: 0x04005EE1 RID: 24289
	private SpriteTextItem DeadInfoItem;

	// Token: 0x04005EE2 RID: 24290
	private SpriteTextItem TimeItem;

	// Token: 0x04005EE3 RID: 24291
	private SpriteTextItem RoomInfoItem;

	// Token: 0x04005EE4 RID: 24292
	private RewardInfoItem RewardItem;

	// Token: 0x04005EE5 RID: 24293
	private DescItem DescItem;

	// Token: 0x04005EE6 RID: 24294
	private TimerHandle RefreshTimer;

	// Token: 0x02007DB6 RID: 32182
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402AD00 RID: 175360
		CaptionItem,
		// Token: 0x0402AD01 RID: 175361
		CurrentLevelTitleItem,
		// Token: 0x0402AD02 RID: 175362
		DeadInfoItem,
		// Token: 0x0402AD03 RID: 175363
		RewardItem,
		// Token: 0x0402AD04 RID: 175364
		TimeItem,
		// Token: 0x0402AD05 RID: 175365
		RoomInfoItem,
		// Token: 0x0402AD06 RID: 175366
		DescItem
	}
}
