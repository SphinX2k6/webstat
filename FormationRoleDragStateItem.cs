using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001B58 RID: 7000
public class FormationRoleDragStateItem : UiPanelBase
{
	// Token: 0x0600CA83 RID: 51843 RVA: 0x0035E72C File Offset: 0x0035C92C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600CA84 RID: 51844 RVA: 0x0035E7B6 File Offset: 0x0035C9B6
	public float GetCanChangeAlpha()
	{
		return base.GetItem(2).GetAlpha();
	}

	// Token: 0x0600CA85 RID: 51845 RVA: 0x0035E7C4 File Offset: 0x0035C9C4
	public void SetBarFill(float value)
	{
		base.GetItem(3).SetUIActive(value > 0f);
		base.GetSprite(4).SetFillAmount(value);
	}

	// Token: 0x02007E3E RID: 32318
	private enum EChildType
	{
		// Token: 0x0402B004 RID: 176132
		CanChangeItem = 2,
		// Token: 0x0402B005 RID: 176133
		BarItem,
		// Token: 0x0402B006 RID: 176134
		BarSprite
	}
}
