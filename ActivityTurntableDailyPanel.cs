using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020015F6 RID: 5622
[NullableContext(1)]
[Nullable(0)]
public class ActivityTurntableDailyPanel : UiPanelBase
{
	// Token: 0x06009E7C RID: 40572 RVA: 0x002979A4 File Offset: 0x00295BA4
	public ActivityTurntableDailyPanel(ActivityTurntableData activityBaseData)
	{
		this.ActivityBaseData = activityBaseData;
	}

	// Token: 0x06009E7D RID: 40573 RVA: 0x002979B4 File Offset: 0x00295BB4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06009E7E RID: 40574 RVA: 0x00297A1D File Offset: 0x00295C1D
	protected override void OnStart()
	{
		this.DailyItemLayout = new GenericLayout<ActivityTurntableDailyItem, ActivityTaskData>(base.GetVerticalLayout(0), new Func<ActivityTurntableDailyItem>(this.CreateDailyItem), null, false, true);
	}

	// Token: 0x06009E7F RID: 40575 RVA: 0x00297A40 File Offset: 0x00295C40
	public void Refresh()
	{
		this.DailyItemLayout.RefreshByData(this.ActivityBaseData.GetAllTurntableDailyQuestData(), null, false);
	}

	// Token: 0x06009E80 RID: 40576 RVA: 0x00297A5A File Offset: 0x00295C5A
	private ActivityTurntableDailyItem CreateDailyItem()
	{
		return new ActivityTurntableDailyItem();
	}

	// Token: 0x040048E7 RID: 18663
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<ActivityTurntableDailyItem, ActivityTaskData> DailyItemLayout;

	// Token: 0x040048E8 RID: 18664
	protected ActivityTurntableData ActivityBaseData;

	// Token: 0x020079B7 RID: 31159
	[NullableContext(0)]
	private class EDailyComponents
	{
		// Token: 0x04029CBC RID: 171196
		public const int Layout = 0;

		// Token: 0x04029CBD RID: 171197
		public const int Item = 1;
	}
}
