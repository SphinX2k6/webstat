using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x02001A22 RID: 6690
public class SmallItemGridElementComponent : SmallItemGridComponent
{
	// Token: 0x0600BFF2 RID: 49138 RVA: 0x0032C2C0 File Offset: 0x0032A4C0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BFF3 RID: 49139 RVA: 0x0032C308 File Offset: 0x0032A508
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemElement";
	}

	// Token: 0x0600BFF4 RID: 49140 RVA: 0x0032C310 File Offset: 0x0032A510
	[NullableContext(2)]
	protected override void OnRefresh(object tempData)
	{
		if (tempData == null)
		{
			this.SetActive(false);
			return;
		}
		int elementId = (int)tempData;
		ElementInfo? elementConfig = ConfigBase<CommonConfig>.Instance.GetElementConfig(elementId);
		if (elementConfig == null)
		{
			this.SetActive(false);
			return;
		}
		string icon = elementConfig.Value.Icon5;
		if (icon == "" || icon.Length == 0)
		{
			this.SetActive(false);
			return;
		}
		UUITexture texture = base.GetTexture(0);
		base.SetElementIcon(icon, texture, elementId, null);
		texture.SetColor(FColor.FromHex(elementConfig.Value.ElementColor));
		this.SetActive(true);
	}

	// Token: 0x02007CFA RID: 31994
	private enum EChildType
	{
		// Token: 0x0402AA11 RID: 174609
		ElementTexture
	}
}
