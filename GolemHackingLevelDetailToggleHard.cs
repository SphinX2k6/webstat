using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Protocol;
using UnrealEngine;

// Token: 0x020010C8 RID: 4296
public class GolemHackingLevelDetailToggleHard : GolemHackingLevelDetailToggle
{
	// Token: 0x06006FCE RID: 28622 RVA: 0x001D1EE2 File Offset: 0x001D00E2
	public GolemHackingLevelDetailToggleHard(int levelId) : base(levelId)
	{
		this.IsHard = true;
	}

	// Token: 0x06006FCF RID: 28623 RVA: 0x001D1EF4 File Offset: 0x001D00F4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
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
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06006FD0 RID: 28624 RVA: 0x001D1FA0 File Offset: 0x001D01A0
	public override bool RefreshState(bool needAnim = false)
	{
		GolemHackingActivityData activityData = ControllerBase<GolemHackingController>.Instance.GetActivityData();
		UUIItem item = base.GetItem(3);
		if (item != null)
		{
			item.SetUIActive(activityData.CheckLevelRedDot(this.LevelId));
		}
		GolemHackingLevelInfo levelInfo = activityData.GetLevelInfo(this.LevelId);
		bool flag = levelInfo.State == GolemCrackState.GolemCrackFinished;
		bool uiactive = levelInfo.State == GolemCrackState.GolemCrackLocked;
		UUIItem item2 = base.GetItem(1);
		if (item2 != null)
		{
			item2.SetUIActive(flag);
		}
		UUIItem item3 = base.GetItem(2);
		if (item3 != null)
		{
			item3.SetUIActive(uiactive);
		}
		return flag;
	}
}
