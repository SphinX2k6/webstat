using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001FEF RID: 8175
public class ReputationTips : UiViewBase
{
	// Token: 0x0600F6CB RID: 63179 RVA: 0x00439249 File Offset: 0x00437449
	[NullableContext(1)]
	public ReputationTips(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600F6CC RID: 63180 RVA: 0x00439254 File Offset: 0x00437454
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F6CD RID: 63181 RVA: 0x004392BD File Offset: 0x004374BD
	protected override void OnBeforeCreate()
	{
		this.ItemList = (IntPair[])this.OpenParam;
	}

	// Token: 0x0600F6CE RID: 63182 RVA: 0x004392D0 File Offset: 0x004374D0
	protected override void OnStart()
	{
		this.DailyTask = new ReputationTipsItem(base.GetItem(0));
		base.GetItem(1).SetUIActive(false);
	}

	// Token: 0x0600F6CF RID: 63183 RVA: 0x004392F1 File Offset: 0x004374F1
	protected override void OnAfterShow()
	{
		this.DailyTask.UpdateItem(this.ItemList[0].Item1, this.ItemList[0].Item2);
	}

	// Token: 0x0600F6D0 RID: 63184 RVA: 0x00439320 File Offset: 0x00437520
	protected override void OnBeforeDestroy()
	{
		this.DailyTask.Destroy(null);
		this.DailyTask = null;
	}

	// Token: 0x04007737 RID: 30519
	[Nullable(2)]
	private ReputationTipsItem DailyTask;

	// Token: 0x04007738 RID: 30520
	[Nullable(2)]
	private IntPair[] ItemList;

	// Token: 0x0200836D RID: 33645
	private enum EReputationTips
	{
		// Token: 0x0402C940 RID: 182592
		DailyTask,
		// Token: 0x0402C941 RID: 182593
		WorldEvent
	}
}
