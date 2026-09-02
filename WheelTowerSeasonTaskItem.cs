using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200168F RID: 5775
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class WheelTowerSeasonTaskItem : SyncGridProxyAbstract<ActivityTaskData>
{
	// Token: 0x0600A11C RID: 41244 RVA: 0x002A45F4 File Offset: 0x002A27F4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 12;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnGetBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A11D RID: 41245 RVA: 0x002A47E8 File Offset: 0x002A29E8
	protected override void OnStart()
	{
		this.RewardLayout = new GenericLayout<CommonItemSmallItemGrid, TItem>(base.GetHorizontalLayout(6), new Func<CommonItemSmallItemGrid>(this.CreateRewardItem), null, false, true);
	}

	// Token: 0x0600A11E RID: 41246 RVA: 0x002A480B File Offset: 0x002A2A0B
	private CommonItemSmallItemGrid CreateRewardItem()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x0600A11F RID: 41247 RVA: 0x002A4814 File Offset: 0x002A2A14
	public override void Refresh(ActivityTaskData data)
	{
		NewTowerSeasonAward? seasonTaskRewardConfig = ConfigBase<WheelTowerConfig>.Instance.GetSeasonTaskRewardConfig(data.Id);
		if (seasonTaskRewardConfig == null)
		{
			return;
		}
		List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(seasonTaskRewardConfig.Value.DropId);
		GenericLayout<CommonItemSmallItemGrid, TItem> rewardLayout = this.RewardLayout;
		if (rewardLayout != null)
		{
			rewardLayout.RefreshByData(dropPackagePreviewItemList, null, false);
		}
		string newText = StringUtils.Format("({0}/{1})", new string[]
		{
			data.Current.ToString(),
			data.Target.ToString()
		});
		this.SetSpriteByPath(seasonTaskRewardConfig.Value.ShineIcon, base.GetSprite(3), false, null, null);
		base.SetTextureByPath(seasonTaskRewardConfig.Value.Icon, base.GetTexture(4), null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), seasonTaskRewardConfig.Value.Name, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), seasonTaskRewardConfig.Value.Desc, Array.Empty<object>());
		UUIText text = base.GetText(2);
		if (text != null)
		{
			text.SetText(newText, true);
		}
		UUIText text2 = base.GetText(9);
		if (text2 != null)
		{
			text2.SetUIActive(data.Status == EActivityTaskState.Active);
		}
		UUIButtonComponent button = base.GetButton(8);
		if (button != null)
		{
			UUIItem uuiitem = button.RootUIComp.Get();
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(data.Status == EActivityTaskState.FinishedAndUnclaimed);
			}
		}
		UUIItem item = base.GetItem(10);
		if (item != null)
		{
			item.SetUIActive(data.Status == EActivityTaskState.FinishedAndClaimed);
		}
		this.CycleId = seasonTaskRewardConfig.Value.CycleId;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), "WheelTower_SeasonTask_Doing", Array.Empty<object>());
		if (this.CycleId > 0)
		{
			UUITexture texture = base.GetTexture(5);
			if (texture != null)
			{
				texture.SetUIActive(true);
			}
			string cycleEndRemainTime = ModelBase<WheelTowerModel>.Instance.GetCycleEndRemainTime();
			if (!string.IsNullOrEmpty(cycleEndRemainTime))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), "WheelTower_SeasonTask_ResetTime", new <>z__ReadOnlySingleElementList<object>(cycleEndRemainTime));
				return;
			}
		}
		else
		{
			UUITexture texture2 = base.GetTexture(5);
			if (texture2 == null)
			{
				return;
			}
			texture2.SetUIActive(false);
		}
	}

	// Token: 0x0600A120 RID: 41248 RVA: 0x002A4A40 File Offset: 0x002A2C40
	public void OnTick()
	{
		if (this.CycleId <= 0)
		{
			return;
		}
		string cycleEndRemainTime = ModelBase<WheelTowerModel>.Instance.GetCycleEndRemainTime();
		if (string.IsNullOrEmpty(cycleEndRemainTime))
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), "WheelTower_SeasonTask_Doing", Array.Empty<object>());
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), "WheelTower_SeasonTask_ResetTime", new <>z__ReadOnlySingleElementList<object>(cycleEndRemainTime));
	}

	// Token: 0x0600A121 RID: 41249 RVA: 0x002A4AA4 File Offset: 0x002A2CA4
	private void OnGetBtnClick()
	{
		Action onClickToGet = this.OnClickToGet;
		if (onClickToGet == null)
		{
			return;
		}
		onClickToGet();
	}

	// Token: 0x04004B04 RID: 19204
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<CommonItemSmallItemGrid, TItem> RewardLayout;

	// Token: 0x04004B05 RID: 19205
	private int CycleId;

	// Token: 0x04004B06 RID: 19206
	[Nullable(2)]
	public Action OnClickToGet;
}
