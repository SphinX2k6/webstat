using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x020016FA RID: 5882
public class WheelTowerSeasonTaskCategoryItem : SyncGridProxyAbstract<ETaskCategory>
{
	// Token: 0x0600A302 RID: 41730 RVA: 0x002B0AA0 File Offset: 0x002AECA0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A303 RID: 41731 RVA: 0x002B0B2C File Offset: 0x002AED2C
	public override void Refresh(ETaskCategory data)
	{
		this.Category = data;
		string textStringId = (data == ETaskCategory.Cycle) ? "NewTower_LoopTask" : "NewTower_ChallengeTask";
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textStringId, Array.Empty<object>());
		bool flag = data == ETaskCategory.Cycle;
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(flag);
		}
		if (flag)
		{
			this.RefreshCycleTime();
		}
	}

	// Token: 0x0600A304 RID: 41732 RVA: 0x002B0B88 File Offset: 0x002AED88
	public void OnTick()
	{
		if (this.Category != ETaskCategory.Cycle)
		{
			return;
		}
		this.RefreshCycleTime();
	}

	// Token: 0x0600A305 RID: 41733 RVA: 0x002B0B9C File Offset: 0x002AED9C
	private void RefreshCycleTime()
	{
		string cycleEndRemainTime = ModelBase<WheelTowerModel>.Instance.GetCycleEndRemainTime();
		if (string.IsNullOrEmpty(cycleEndRemainTime))
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "WheelTower_SeasonTask_Doing", Array.Empty<object>());
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "WheelTower_SeasonTask_ResetTime", new <>z__ReadOnlySingleElementList<object>(cycleEndRemainTime));
	}

	// Token: 0x04004D7F RID: 19839
	private ETaskCategory Category;
}
