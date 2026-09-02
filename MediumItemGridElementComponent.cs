using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x020019C0 RID: 6592
public class MediumItemGridElementComponent : MediumItemGridComponent
{
	// Token: 0x0600BD40 RID: 48448 RVA: 0x00323B18 File Offset: 0x00321D18
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

	// Token: 0x0600BD41 RID: 48449 RVA: 0x00323B60 File Offset: 0x00321D60
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemElement";
	}

	// Token: 0x0600BD42 RID: 48450 RVA: 0x00323B68 File Offset: 0x00321D68
	[NullableContext(2)]
	protected override void OnRefresh(object data)
	{
		if (!(data is int))
		{
			this.SetActive(false);
			return;
		}
		int elementId = (int)data;
		ElementInfo? elementConfig = ConfigBase<CommonConfig>.Instance.GetElementConfig(elementId);
		if (elementConfig == null)
		{
			this.SetActive(false);
			return;
		}
		string icon = elementConfig.Value.Icon5;
		if (string.IsNullOrEmpty(icon))
		{
			this.SetActive(false);
			return;
		}
		UUITexture texture = base.GetTexture(0);
		base.SetElementIcon(icon, texture, elementId, null);
		if (texture != null)
		{
			texture.SetColor(FColor.FromHex(elementConfig.Value.ElementColor));
		}
		this.SetActive(true);
	}

	// Token: 0x02007CC1 RID: 31937
	private class EChildType
	{
		// Token: 0x0402A96C RID: 174444
		public const int ElementTexture = 0;
	}
}
