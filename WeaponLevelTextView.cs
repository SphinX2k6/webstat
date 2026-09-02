using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002D13 RID: 11539
public class WeaponLevelTextView : UiPanelBase
{
	// Token: 0x0601748D RID: 95373 RVA: 0x006740E4 File Offset: 0x006722E4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0601748E RID: 95374 RVA: 0x0067414D File Offset: 0x0067234D
	protected override void OnStart()
	{
		base.GetText(0).SetUIActive(true);
		base.GetText(1).SetUIActive(true);
	}

	// Token: 0x0601748F RID: 95375 RVA: 0x00674169 File Offset: 0x00672369
	public void SetCurrentLevelText(int level)
	{
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), "WeaponLevelUpLevelText", new <>z__ReadOnlySingleElementList<object>(level));
	}

	// Token: 0x06017490 RID: 95376 RVA: 0x0067418C File Offset: 0x0067238C
	public void SetMaxLevelText(int maxLevel)
	{
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "WeaponMaxLevelText", new <>z__ReadOnlySingleElementList<object>(maxLevel));
	}

	// Token: 0x02008FD8 RID: 36824
	private enum ELevelTextComponent
	{
		// Token: 0x0403046D RID: 197741
		CurrentLevelText,
		// Token: 0x0403046E RID: 197742
		MaxLevelText
	}
}
