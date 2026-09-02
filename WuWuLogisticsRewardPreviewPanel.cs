using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200171F RID: 5919
[NullableContext(2)]
[Nullable(0)]
public class WuWuLogisticsRewardPreviewPanel : UiPanelBase
{
	// Token: 0x0600A489 RID: 42121 RVA: 0x002B8340 File Offset: 0x002B6540
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUISprite))
		};
	}

	// Token: 0x0600A48A RID: 42122 RVA: 0x002B83F4 File Offset: 0x002B65F4
	protected override void OnStart()
	{
		this.RewardScrollView = new GenericLayout<CommonItemSmallItemGrid, TItem>(base.GetHorizontalLayout(0), new Func<CommonItemSmallItemGrid>(this.InitGridItem), null, false, true);
		this.ConfirmQuick = new ButtonItem(base.GetButton(4).RootUIComp);
		this.ConfirmQuick.SetFunction(new Action<int>(this.OnClickConfirm));
	}

	// Token: 0x0600A48B RID: 42123 RVA: 0x002B8455 File Offset: 0x002B6655
	public void SetPackConfigId(int packConfigId, WuWuLogisticsActivityData activityData)
	{
		this.PackConfigId = packConfigId;
		this.ActivityData = activityData;
		this.RefreshContent();
		this.RefreshConfirmButtonRedPoint();
	}

	// Token: 0x0600A48C RID: 42124 RVA: 0x002B8474 File Offset: 0x002B6674
	private void RefreshContent()
	{
		if (this.PackConfigId == 0)
		{
			return;
		}
		WuWuTaskPackage? taskPackageById = ConfigBase<WuWuLogisticsConfig>.Instance.GetTaskPackageById(this.PackConfigId);
		if (taskPackageById == null)
		{
			return;
		}
		int activityId = ControllerBase<WuWuLogisticsActivityController>.Instance.ActivityId;
		if (!(ModelBase<ActivityModel>.Instance.GetActivityById(activityId) is WuWuLogisticsActivityData))
		{
			return;
		}
		List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(taskPackageById.Value.DropId);
		GenericLayout<CommonItemSmallItemGrid, TItem> rewardScrollView = this.RewardScrollView;
		if (rewardScrollView != null)
		{
			rewardScrollView.RefreshByData(dropPackagePreviewItemList, null, false);
		}
		this.RefreshState();
	}

	// Token: 0x0600A48D RID: 42125 RVA: 0x002B84F8 File Offset: 0x002B66F8
	private void RefreshState()
	{
		if (this.ActivityData == null)
		{
			return;
		}
		bool flag = this.ActivityData.TargetPackIsAllCompleted(this.PackConfigId);
		WuWuTaskPackData taskPackById = this.ActivityData.GetTaskPackById(this.PackConfigId);
		if (taskPackById == null)
		{
			return;
		}
		bool hadReward = taskPackById.HadReward;
		UUIItem item = base.GetItem(5);
		if (item != null)
		{
			item.SetUIActive(hadReward);
		}
		UUISprite sprite = base.GetSprite(6);
		if (sprite != null)
		{
			sprite.SetUIActive(flag || hadReward);
		}
		UUIItem item2 = base.GetItem(3);
		if (item2 != null)
		{
			item2.SetUIActive(flag && !hadReward);
		}
		UUIItem item3 = base.GetItem(2);
		if (item3 == null)
		{
			return;
		}
		item3.SetUIActive(!flag);
	}

	// Token: 0x0600A48E RID: 42126 RVA: 0x002B8596 File Offset: 0x002B6796
	[NullableContext(1)]
	private CommonItemSmallItemGrid InitGridItem()
	{
		return new CommonItemSmallItemGrid
		{
			ShowReceivedCallBack = delegate(TItem _)
			{
				WuWuTaskPackData taskPackById = this.ActivityData.GetTaskPackById(this.PackConfigId);
				return taskPackById != null && taskPackById.HadReward;
			}
		};
	}

	// Token: 0x0600A48F RID: 42127 RVA: 0x002B85AF File Offset: 0x002B67AF
	private void OnClickConfirm(int data)
	{
		if (this.ActivityData == null)
		{
			return;
		}
		if (this.ActivityData.TargetPackHasReceiveReward(this.PackConfigId))
		{
			ControllerBase<WuWuLogisticsActivityController>.Instance.RequestTaskPackageReward(this.PackConfigId);
		}
	}

	// Token: 0x0600A490 RID: 42128 RVA: 0x002B85E0 File Offset: 0x002B67E0
	public void RefreshConfirmButtonRedPoint()
	{
		WuWuLogisticsActivityData activityData = this.ActivityData;
		bool redDotVisible = activityData != null && activityData.TargetPackHasReceiveReward(this.PackConfigId);
		ButtonItem confirmQuick = this.ConfirmQuick;
		if (confirmQuick == null)
		{
			return;
		}
		confirmQuick.SetRedDotVisible(redDotVisible);
	}

	// Token: 0x04004E37 RID: 20023
	private int PackConfigId;

	// Token: 0x04004E38 RID: 20024
	private WuWuLogisticsActivityData ActivityData;

	// Token: 0x04004E39 RID: 20025
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<CommonItemSmallItemGrid, TItem> RewardScrollView;

	// Token: 0x04004E3A RID: 20026
	protected ButtonItem ConfirmQuick;
}
