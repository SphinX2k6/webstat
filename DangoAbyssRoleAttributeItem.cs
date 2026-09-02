using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001B00 RID: 6912
[Nullable(new byte[]
{
	0,
	1
})]
public class DangoAbyssRoleAttributeItem : GridProxyAbstract<AttrListScrollData>
{
	// Token: 0x0600C710 RID: 50960 RVA: 0x0034A7C0 File Offset: 0x003489C0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600C711 RID: 50961 RVA: 0x0034A8B0 File Offset: 0x00348AB0
	[NullableContext(1)]
	public override void Refresh(AttrListScrollData data, bool isSelected, int gridIndex)
	{
		PropertyIndex value = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(data.Id).Value;
		base.SetTextureByPath(value.Icon, base.GetTexture(4), null, null);
		base.GetText(0).ShowTextNew(value.Name);
		base.GetItem(2).SetUIActive(false);
		base.GetText(3).SetUIActive(false);
		string formatAttributeValueString = ModelBase<AttributeModel>.Instance.GetFormatAttributeValueString(data.Id, data.BaseValue + data.AddValue, data.IsRatio);
		base.GetText(1).SetText(formatAttributeValueString, true);
	}

	// Token: 0x02007DD7 RID: 32215
	private class EChildType
	{
		// Token: 0x0402ADD6 RID: 175574
		public const int AttributeText = 0;

		// Token: 0x0402ADD7 RID: 175575
		public const int AttributeNumText = 1;

		// Token: 0x0402ADD8 RID: 175576
		public const int ArrowItem = 2;

		// Token: 0x0402ADD9 RID: 175577
		public const int AttributeAddText = 3;

		// Token: 0x0402ADDA RID: 175578
		public const int AttributeIcon = 4;

		// Token: 0x0402ADDB RID: 175579
		public const int Bg = 5;
	}
}
