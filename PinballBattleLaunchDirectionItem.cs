using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001D51 RID: 7505
public class PinballBattleLaunchDirectionItem : UiPanelBase
{
	// Token: 0x0600DD26 RID: 56614 RVA: 0x003B6E48 File Offset: 0x003B5048
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600DD27 RID: 56615 RVA: 0x003B6EB1 File Offset: 0x003B50B1
	protected override void OnStart()
	{
		UUITexture texture = base.GetTexture(0);
		if (texture == null)
		{
			return;
		}
		texture.SetUIActive(false);
	}
}
