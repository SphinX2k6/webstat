using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001B0A RID: 6922
[Nullable(new byte[]
{
	0,
	1
})]
public class DangoAbyssTipsAttributeItem : GridProxyAbstract<AttrListScrollData>
{
	// Token: 0x0600C772 RID: 51058 RVA: 0x0034C1E0 File Offset: 0x0034A3E0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600C773 RID: 51059 RVA: 0x0034C26C File Offset: 0x0034A46C
	[NullableContext(1)]
	public override void Refresh(AttrListScrollData attributeData, bool isSelected, int gridIndex)
	{
		PropertyIndex value = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(attributeData.Id).Value;
		base.GetText(1).ShowTextNew(value.Name);
		base.SetTextureShowUntilLoaded(value.Icon, base.GetTexture(0), null);
		double propRatioValue = TipsDataTool.GetPropRatioValue(attributeData.BaseValue, attributeData.IsRatio);
		string formatAttributeValueString = ModelBase<AttributeModel>.Instance.GetFormatAttributeValueString(attributeData.Id, propRatioValue, attributeData.IsRatio);
		base.GetText(2).SetText(formatAttributeValueString, true);
	}

	// Token: 0x02007DE5 RID: 32229
	private enum EComponent
	{
		// Token: 0x0402AE1C RID: 175644
		AttributeIcon,
		// Token: 0x0402AE1D RID: 175645
		AttributeName,
		// Token: 0x0402AE1E RID: 175646
		AttributeValue
	}
}
