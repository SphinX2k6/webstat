using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Functional;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001470 RID: 5232
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ActivityNewPlayerSupportTaskItem : GridProxyAbstract<IActivityNewPlayerSupportTaskItemData>
{
	// Token: 0x0600925C RID: 37468 RVA: 0x00269910 File Offset: 0x00267B10
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUITexture)),
			new ValueTuple<int, Type>(5, typeof(UUISprite)),
			new ValueTuple<int, Type>(6, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIItem)),
			new ValueTuple<int, Type>(17, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(9, new Action(this.OnFunctionClick)),
			new ValueTuple<int, Delegate>(8, new Action(this.OnReceiveClick)),
			new ValueTuple<int, Delegate>(11, new Action(this.OnRoleClick))
		};
	}

	// Token: 0x0600925D RID: 37469 RVA: 0x00269B12 File Offset: 0x00267D12
	protected override void OnStart()
	{
		this.RewardLayout = new GenericLayout<CommonItemSmallItemGrid, TItem>(base.GetVerticalLayout(6), new Func<CommonItemSmallItemGrid>(this.CreateLayoutItem), null, false, true);
	}

	// Token: 0x0600925E RID: 37470 RVA: 0x00269B35 File Offset: 0x00267D35
	public override void Refresh(IActivityNewPlayerSupportTaskItemData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		this.RefreshRewardView();
		this.RefreshTrialRoleView();
	}

	// Token: 0x0600925F RID: 37471 RVA: 0x00269B4C File Offset: 0x00267D4C
	private void RefreshRewardView()
	{
		ActivityNewPlayerSupportTaskData taskData = this.Data.TaskData;
		bool isReceived = taskData.IsTaskReceived();
		bool flag = taskData.CanReceiveReward();
		base.GetButton(9).RootUIComp.Get().SetUIActive(taskData.IsTaskRunning());
		base.GetButton(8).RootUIComp.Get().SetUIActive(taskData.CanReceiveReward());
		base.GetItem(10).SetUIActive(isReceived);
		base.GetItem(2).SetUIActive(flag);
		base.GetItem(1).SetUIActive(!flag);
		List<TItem> rewardList = taskData.GetRewardList();
		GenericLayout<CommonItemSmallItemGrid, TItem> rewardLayout = this.RewardLayout;
		if (rewardLayout == null)
		{
			return;
		}
		rewardLayout.RefreshByData(rewardList, delegate
		{
			foreach (CommonItemSmallItemGrid commonItemSmallItemGrid in this.RewardLayout.GetLayoutItemList())
			{
				commonItemSmallItemGrid.SetReceivedVisible(isReceived);
			}
		}, false);
	}

	// Token: 0x06009260 RID: 37472 RVA: 0x00269C1C File Offset: 0x00267E1C
	private void RefreshTrialRoleView()
	{
		ActivityNewPlayerSupportTaskData taskData = this.Data.TaskData;
		bool flag = taskData.IsTaskReceived();
		bool flag2 = taskData.CanReceiveReward();
		int taskTarget = taskData.GetTaskTarget();
		UUIText text = base.GetText(3);
		text.SetText(taskTarget.ToString(), true);
		FColor color = flag2 ? ActivityNewPlayerSupportDefine.FinishTaskTextColor : ActivityNewPlayerSupportDefine.NormalTaskTextColor;
		text.SetColor(color);
		bool showDecoration = this.Data.ShowDecoration;
		base.GetItem(12).SetUIActive(!flag);
		base.GetItem(13).SetUIActive(flag);
		base.GetItem(14).SetUIActive(!flag && showDecoration);
		base.GetItem(15).SetUIActive(flag && showDecoration);
		base.GetItem(16).SetUIActive(!flag2);
		base.GetItem(17).SetUIActive(flag2);
		int trialRoleGroupId = taskData.TaskConfig.TrialRoleGroupId;
		IReadOnlyList<TrialRoleInfo> trialRoleConfigsByGroupId = ConfigBase<TrialRoleConfig>.Instance.GetTrialRoleConfigsByGroupId(trialRoleGroupId);
		if (trialRoleConfigsByGroupId != null)
		{
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(trialRoleConfigsByGroupId[0].ParentId);
			if (roleConfig != null)
			{
				base.SetRoleIcon(roleConfig.Value.RoleHeadIconCircle, base.GetTexture(4), roleConfig.Value.Id, null, null);
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(RoleUtils.GetTrialRoleLabelIconByType(ETrialRoleType.NewbieSupportTrial));
				this.SetSpriteByPath(resourcePath, base.GetSprite(5), false, null, null);
			}
		}
	}

	// Token: 0x06009261 RID: 37473 RVA: 0x00269D94 File Offset: 0x00267F94
	private void OnFunctionClick()
	{
		if (ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.AdventureGuide))
		{
			ControllerBase<FunctionController>.Instance.OpenFunctionRelateView(EFunctionType.AdventureGuide);
			return;
		}
		ActivityNewPlayerSupportData activityData = ControllerBase<ActivityNewPlayerSupportController>.Instance.ActivityData;
		int? num = (activityData != null) ? activityData.GetFirstUnFinishMainQuestId() : null;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, num.Value, null);
	}

	// Token: 0x06009262 RID: 37474 RVA: 0x00269E00 File Offset: 0x00268000
	private void OnReceiveClick()
	{
		ActivityNewPlayerSupportTaskData taskData = this.Data.TaskData;
		if (!taskData.CanReceiveReward())
		{
			return;
		}
		ActivityNewPlayerSupportController instance = ControllerBase<ActivityNewPlayerSupportController>.Instance;
		if (instance == null)
		{
			return;
		}
		instance.RequestRewardTask(taskData.Id, true);
	}

	// Token: 0x06009263 RID: 37475 RVA: 0x00269E38 File Offset: 0x00268038
	private void OnRoleClick()
	{
		int trialRoleGroupId = this.Data.TaskData.TaskConfig.TrialRoleGroupId;
		ControllerBase<ActivityNewPlayerSupportController>.Instance.OpenTrialRoleView(new int?(trialRoleGroupId));
	}

	// Token: 0x06009264 RID: 37476 RVA: 0x00269E6E File Offset: 0x0026806E
	private CommonItemSmallItemGrid CreateLayoutItem()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x06009265 RID: 37477 RVA: 0x00269E78 File Offset: 0x00268078
	[NullableContext(2)]
	public UUIItem GetReceiveBtn()
	{
		UUIButtonComponent button = base.GetButton(8);
		if (button == null)
		{
			return null;
		}
		return button.RootUIComp.Get();
	}

	// Token: 0x040043C6 RID: 17350
	[Nullable(2)]
	private IActivityNewPlayerSupportTaskItemData Data;

	// Token: 0x040043C7 RID: 17351
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<CommonItemSmallItemGrid, TItem> RewardLayout;

	// Token: 0x02007870 RID: 30832
	[NullableContext(0)]
	private static class EComponentType
	{
		// Token: 0x040296B8 RID: 169656
		public const int TaskItem = 0;

		// Token: 0x040296B9 RID: 169657
		public const int LockItem = 1;

		// Token: 0x040296BA RID: 169658
		public const int ReceiveItem = 2;

		// Token: 0x040296BB RID: 169659
		public const int TaskTxt = 3;

		// Token: 0x040296BC RID: 169660
		public const int TrialRoleTex = 4;

		// Token: 0x040296BD RID: 169661
		public const int TrialRoleMarkImg = 5;

		// Token: 0x040296BE RID: 169662
		public const int RewardLayout = 6;

		// Token: 0x040296BF RID: 169663
		public const int RewardItem = 7;

		// Token: 0x040296C0 RID: 169664
		public const int ReceiveBtn = 8;

		// Token: 0x040296C1 RID: 169665
		public const int FunctionBtn = 9;

		// Token: 0x040296C2 RID: 169666
		public const int ReceivedItem = 10;

		// Token: 0x040296C3 RID: 169667
		public const int TrialRoleBtn = 11;

		// Token: 0x040296C4 RID: 169668
		public const int DotItem1 = 12;

		// Token: 0x040296C5 RID: 169669
		public const int DotItem2 = 13;

		// Token: 0x040296C6 RID: 169670
		public const int LineItem1 = 14;

		// Token: 0x040296C7 RID: 169671
		public const int LineItem2 = 15;

		// Token: 0x040296C8 RID: 169672
		public const int TrialRoleNormalItem = 16;

		// Token: 0x040296C9 RID: 169673
		public const int TrialRoleReceiveItem = 17;
	}
}
