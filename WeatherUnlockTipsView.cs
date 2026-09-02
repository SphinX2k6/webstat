using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002D21 RID: 11553
public class WeatherUnlockTipsView : UiViewBase
{
	// Token: 0x0601751D RID: 95517 RVA: 0x00677449 File Offset: 0x00675649
	[NullableContext(1)]
	public WeatherUnlockTipsView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601751E RID: 95518 RVA: 0x00677454 File Offset: 0x00675654
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
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
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickClose));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0601751F RID: 95519 RVA: 0x0067753C File Offset: 0x0067573C
	private void OnClickClose()
	{
		base.CloseMe(null);
	}
}
