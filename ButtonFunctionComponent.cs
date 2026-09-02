using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001CE2 RID: 7394
public class ButtonFunctionComponent : UiPanelBase
{
	// Token: 0x0600D8F0 RID: 55536 RVA: 0x003A167C File Offset: 0x0039F87C
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
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnButtonClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D8F1 RID: 55537 RVA: 0x003A1701 File Offset: 0x0039F901
	[NullableContext(1)]
	public void SetFunction(Action callback)
	{
		this.CallBack = callback;
	}

	// Token: 0x0600D8F2 RID: 55538 RVA: 0x003A170A File Offset: 0x0039F90A
	private void OnButtonClick()
	{
		this.CallBack();
	}

	// Token: 0x04006798 RID: 26520
	[Nullable(1)]
	private Action CallBack = delegate()
	{
	};

	// Token: 0x02008031 RID: 32817
	private enum EComponent
	{
		// Token: 0x0402B9C2 RID: 178626
		JumpBtn
	}
}
