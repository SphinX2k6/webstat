using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001899 RID: 6297
public class CommonDynamicBtnItem : UiPanelBase
{
	// Token: 0x0600B4C5 RID: 46277 RVA: 0x0030245C File Offset: 0x0030065C
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

	// Token: 0x0600B4C6 RID: 46278 RVA: 0x003024E1 File Offset: 0x003006E1
	[NullableContext(1)]
	public void SetFunction(Action callback)
	{
		this._callBack = callback;
	}

	// Token: 0x0600B4C7 RID: 46279 RVA: 0x003024EA File Offset: 0x003006EA
	private void OnButtonClick()
	{
		if (this._callBack != null)
		{
			this._callBack();
		}
	}

	// Token: 0x0400555B RID: 21851
	[Nullable(2)]
	private Action _callBack;

	// Token: 0x02007C15 RID: 31765
	private class EComponent
	{
		// Token: 0x0402A637 RID: 173623
		public const int Btn = 0;
	}
}
