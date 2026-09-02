using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020023D6 RID: 9174
[NullableContext(2)]
[Nullable(0)]
public class PayShopCheckBtnItem : UiPanelBase
{
	// Token: 0x1700166D RID: 5741
	// (get) Token: 0x06011BE2 RID: 72674 RVA: 0x004E037D File Offset: 0x004DE57D
	// (set) Token: 0x06011BE3 RID: 72675 RVA: 0x004E0385 File Offset: 0x004DE585
	public Action Callback { get; set; }

	// Token: 0x06011BE4 RID: 72676 RVA: 0x004E038E File Offset: 0x004DE58E
	[NullableContext(1)]
	public void SetCallback(Action callback)
	{
		this.Callback = callback;
	}

	// Token: 0x06011BE5 RID: 72677 RVA: 0x004E0398 File Offset: 0x004DE598
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickCheck));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06011BE6 RID: 72678 RVA: 0x004E041D File Offset: 0x004DE61D
	private void OnClickCheck()
	{
		Action callback = this.Callback;
		if (callback == null)
		{
			return;
		}
		callback();
	}

	// Token: 0x02008710 RID: 34576
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x0402DAE6 RID: 187110
		BtnCheck
	}
}
