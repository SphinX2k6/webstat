using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200207B RID: 8315
public class PhantomTipsAttributeItem : UiPanelBase
{
	// Token: 0x0600FD5A RID: 64858 RVA: 0x004579CC File Offset: 0x00455BCC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x0600FD5B RID: 64859 RVA: 0x00457A28 File Offset: 0x00455C28
	[NullableContext(1)]
	public void RefreshUi(AttrListScrollData attributeData)
	{
		PropertyIndex? propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(attributeData.Id);
		base.GetText(1).ShowTextNew(propertyIndexInfo.Value.Name);
		base.SetTextureShowUntilLoaded(propertyIndexInfo.Value.Icon, base.GetTexture(0), null);
		string formatAttributeValueString = ModelBase<AttributeModel>.Instance.GetFormatAttributeValueString(attributeData.Id, attributeData.BaseValue, attributeData.IsRatio);
		base.GetText(2).SetText(formatAttributeValueString, true);
	}

	// Token: 0x02008404 RID: 33796
	private enum EComponent
	{
		// Token: 0x0402CBF0 RID: 183280
		AttributeIcon,
		// Token: 0x0402CBF1 RID: 183281
		AttributeName,
		// Token: 0x0402CBF2 RID: 183282
		AttributeValue
	}
}
