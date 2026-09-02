using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001683 RID: 5763
public class WheelTowerLimitRewardItem : GridProxyAbstract<int>
{
	// Token: 0x0600A0F5 RID: 41205 RVA: 0x002A357C File Offset: 0x002A177C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickReceive));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A0F6 RID: 41206 RVA: 0x002A36C7 File Offset: 0x002A18C7
	protected override void OnStart()
	{
		this.RewardLayout = new GenericLayout<CommonItemSmallItemGrid, TItem>(base.GetHorizontalLayout(2), () => new CommonItemSmallItemGrid(), null, false, true);
	}

	// Token: 0x0600A0F7 RID: 41207 RVA: 0x002A3700 File Offset: 0x002A1900
	public override void Refresh(int rewardId, bool isSelected, int gridIndex)
	{
		NewTowerScoreReward? rewardConfigById = ConfigBase<WheelTowerConfig>.Instance.GetRewardConfigById(rewardId);
		if (rewardConfigById == null)
		{
			return;
		}
		UUIText text = base.GetText(0);
		if (text != null)
		{
			text.ShowTextNew(rewardConfigById.Value.Desc);
		}
		GenericLayout<CommonItemSmallItemGrid, TItem> rewardLayout = this.RewardLayout;
		if (rewardLayout != null)
		{
			rewardLayout.RefreshByData(ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(rewardConfigById.Value.DropId), null, false);
		}
		WheelTowerData activityData = ModelBase<WheelTowerModel>.Instance.ActivityData;
		bool flag = activityData.IsRewardCanReceive(rewardId);
		bool flag2 = activityData.IsRewardCompleted(rewardId);
		UUIButtonComponent button = base.GetButton(4);
		if (button != null)
		{
			UUIItem uuiitem = button.RootUIComp.Get();
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(flag);
			}
		}
		UUIItem item = base.GetItem(6);
		if (item != null)
		{
			item.SetUIActive(flag2);
		}
		UUIItem item2 = base.GetItem(5);
		if (item2 != null)
		{
			item2.SetUIActive(!flag && !flag2);
		}
		ActivityTaskData task = activityData.GetTask(rewardId);
		UUIText text2 = base.GetText(1);
		if (text2 == null)
		{
			return;
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(task.Current);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(task.Target);
		text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
	}

	// Token: 0x0600A0F8 RID: 41208 RVA: 0x002A3831 File Offset: 0x002A1A31
	[NullableContext(1)]
	public void SetOnClickReceiveCallback(Action callback)
	{
		this.OnClickReceiveCallback = callback;
	}

	// Token: 0x0600A0F9 RID: 41209 RVA: 0x002A383A File Offset: 0x002A1A3A
	private void OnClickReceive()
	{
		Action onClickReceiveCallback = this.OnClickReceiveCallback;
		if (onClickReceiveCallback == null)
		{
			return;
		}
		onClickReceiveCallback();
	}

	// Token: 0x04004ACD RID: 19149
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<CommonItemSmallItemGrid, TItem> RewardLayout;

	// Token: 0x04004ACE RID: 19150
	[Nullable(2)]
	private Action OnClickReceiveCallback;
}
