using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002CF8 RID: 11512
public class WeaponResonanceSuccessView : UiViewBase
{
	// Token: 0x060173AF RID: 95151 RVA: 0x006707B3 File Offset: 0x0066E9B3
	[NullableContext(1)]
	public WeaponResonanceSuccessView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060173B0 RID: 95152 RVA: 0x006707BC File Offset: 0x0066E9BC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.ConfirmClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060173B1 RID: 95153 RVA: 0x00670884 File Offset: 0x0066EA84
	protected override void OnBeforeShow()
	{
		IWeaponResonanceSuccessViewParam weaponResonanceSuccessViewParam = this.OpenParam as IWeaponResonanceSuccessViewParam;
		int weaponIncId = weaponResonanceSuccessViewParam.WeaponIncId;
		int lastLevel = weaponResonanceSuccessViewParam.LastLevel;
		int resonanceLevel = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(weaponIncId).GetResonanceLevel();
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "WeaponResonanceLevelText", new <>z__ReadOnlySingleElementList<object>(lastLevel));
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(2), "WeaponResonanceLevelText", new <>z__ReadOnlySingleElementList<object>(resonanceLevel));
	}

	// Token: 0x060173B2 RID: 95154 RVA: 0x006708FC File Offset: 0x0066EAFC
	private void ConfirmClick()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.WeaponResonanceSuccessView, null);
	}

	// Token: 0x02008FC4 RID: 36804
	private enum EComponent
	{
		// Token: 0x0403040D RID: 197645
		ConfirmButton,
		// Token: 0x0403040E RID: 197646
		LastLevelText,
		// Token: 0x0403040F RID: 197647
		CurLevelText
	}
}
