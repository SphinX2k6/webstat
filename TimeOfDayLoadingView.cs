using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002BBE RID: 11198
public class TimeOfDayLoadingView : UiViewBase
{
	// Token: 0x060164F9 RID: 91385 RVA: 0x0062E240 File Offset: 0x0062C440
	[NullableContext(1)]
	public TimeOfDayLoadingView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060164FA RID: 91386 RVA: 0x0062E24C File Offset: 0x0062C44C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060164FB RID: 91387 RVA: 0x0062E294 File Offset: 0x0062C494
	protected override void OnAfterShow()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.TimeOfDayLoadingView, null);
	}
}
