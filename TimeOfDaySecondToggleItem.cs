using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002BC3 RID: 11203
public class TimeOfDaySecondToggleItem : GridProxyAbstract<DaySelectPreset>
{
	// Token: 0x0601651B RID: 91419 RVA: 0x0062EE90 File Offset: 0x0062D090
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0601651C RID: 91420 RVA: 0x0062EF36 File Offset: 0x0062D136
	private void OnClickToggle(EToggleState state)
	{
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnSelectTimePreset, base.GridIndex);
	}

	// Token: 0x0601651D RID: 91421 RVA: 0x0062EF4E File Offset: 0x0062D14E
	public override void Refresh(DaySelectPreset data, bool isSelected, int gridIndex)
	{
		base.GetExtendToggle(0).SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.Title, Array.Empty<object>());
	}

	// Token: 0x0601651E RID: 91422 RVA: 0x0062EF84 File Offset: 0x0062D184
	public override void OnSelected(bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, false, false, false);
		if (fireEvent)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnSelectTimePreset, base.GridIndex);
		}
	}

	// Token: 0x0601651F RID: 91423 RVA: 0x0062EFB0 File Offset: 0x0062D1B0
	public override void OnDeselected(bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}
}
