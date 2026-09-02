using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002BF3 RID: 11251
public class TowerElementItem : GridProxyAbstract<int>
{
	// Token: 0x06016731 RID: 91953 RVA: 0x0063C2EC File Offset: 0x0063A4EC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06016732 RID: 91954 RVA: 0x0063C355 File Offset: 0x0063A555
	protected override void OnStart()
	{
	}

	// Token: 0x06016733 RID: 91955 RVA: 0x0063C358 File Offset: 0x0063A558
	public override void Refresh(int elementId, bool isSelected, int gridIndex)
	{
		ElementInfo? elementInfo = ConfigBase<ElementInfoConfig>.Instance.GetElementInfo(elementId);
		base.SetTextureByPath(elementInfo.Value.Icon, base.GetTexture(1), null, null);
		UUIItem item = base.GetItem(0);
		if (item == null)
		{
			return;
		}
		item.SetColor(FColor.FromHex(elementInfo.Value.ElementColor));
	}

	// Token: 0x02008EE8 RID: 36584
	private enum EChildType
	{
		// Token: 0x04030010 RID: 196624
		ElementColorBg,
		// Token: 0x04030011 RID: 196625
		ElementText
	}
}
