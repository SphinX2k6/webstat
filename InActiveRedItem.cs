using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001959 RID: 6489
[NullableContext(1)]
[Nullable(0)]
public class InActiveRedItem : UiPanelBase
{
	// Token: 0x0600BA17 RID: 47639 RVA: 0x00318E08 File Offset: 0x00317008
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnDetailButtonClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600BA18 RID: 47640 RVA: 0x00318ECF File Offset: 0x003170CF
	private void OnDetailButtonClick()
	{
		this.OnClickDetailButtonCall();
	}

	// Token: 0x0600BA19 RID: 47641 RVA: 0x00318EDC File Offset: 0x003170DC
	public void BindDetailButtonCall(Action call)
	{
		this.OnClickDetailButtonCall = call;
	}

	// Token: 0x0600BA1A RID: 47642 RVA: 0x00318EE8 File Offset: 0x003170E8
	public void SetDetailButtonVisible(bool visible)
	{
		base.GetButton(2).RootUIComp.Get().SetUIActive(visible);
	}

	// Token: 0x0600BA1B RID: 47643 RVA: 0x00318F0F File Offset: 0x0031710F
	public void SetLockItemVisible(bool visible)
	{
		base.GetItem(0).SetUIActive(visible);
	}

	// Token: 0x0600BA1C RID: 47644 RVA: 0x00318F20 File Offset: 0x00317120
	public void SetText([Nullable(2)] string textStringId, params object[] args)
	{
		UUIText text = base.GetText(1);
		Singleton<LguiUtil>.Instance.TrySetLocalTextNew(text, textStringId, args);
	}

	// Token: 0x040057EE RID: 22510
	private Action OnClickDetailButtonCall = delegate()
	{
	};

	// Token: 0x02007C76 RID: 31862
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402A819 RID: 174105
		LockItem,
		// Token: 0x0402A81A RID: 174106
		TextInActive,
		// Token: 0x0402A81B RID: 174107
		DetailButton
	}
}
