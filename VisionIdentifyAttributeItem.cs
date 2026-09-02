using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200251E RID: 9502
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class VisionIdentifyAttributeItem : GridProxyAbstract<AttrListScrollData>
{
	// Token: 0x06012758 RID: 75608 RVA: 0x00514BCC File Offset: 0x00512DCC
	public override void Refresh(AttrListScrollData data, bool isSelected, int gridIndex)
	{
		this.Update(data);
	}

	// Token: 0x06012759 RID: 75609 RVA: 0x00514BD8 File Offset: 0x00512DD8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUITexture))
		};
	}

	// Token: 0x0601275A RID: 75610 RVA: 0x00514C60 File Offset: 0x00512E60
	public void Update(AttrListScrollData data)
	{
		PropertyIndex? propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(data.Id);
		if (propertyIndexInfo == null)
		{
			return;
		}
		base.SetTextureByPath(propertyIndexInfo.Value.Icon, base.GetTexture(4), null, null);
		base.GetText(0).ShowTextNew(propertyIndexInfo.Value.Name);
		base.GetText(1).SetText(ModelBase<AttributeModel>.Instance.GetFormatAttributeValueString(data.Id, data.BaseValue, data.IsRatio), true);
		base.GetText(3).SetText(ModelBase<AttributeModel>.Instance.GetFormatAttributeValueString(data.Id, data.AddValue, data.IsRatio), true);
		base.GetItem(2).SetUIActive(data.AddValue - data.BaseValue > 0.0);
		base.GetText(3).SetUIActive(data.AddValue - data.BaseValue > 0.0);
	}

	// Token: 0x02008837 RID: 34871
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402E01F RID: 188447
		AttributeText,
		// Token: 0x0402E020 RID: 188448
		BeforeText,
		// Token: 0x0402E021 RID: 188449
		ArrowItem,
		// Token: 0x0402E022 RID: 188450
		AfterText,
		// Token: 0x0402E023 RID: 188451
		AttributeTexture
	}
}
