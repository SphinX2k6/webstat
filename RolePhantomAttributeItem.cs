using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020028E4 RID: 10468
public class RolePhantomAttributeItem : UiPanelBase
{
	// Token: 0x06014CA4 RID: 85156 RVA: 0x005C217B File Offset: 0x005C037B
	[NullableContext(1)]
	public RolePhantomAttributeItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x06014CA5 RID: 85157 RVA: 0x005C2190 File Offset: 0x005C0390
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUITexture))
		};
	}

	// Token: 0x06014CA6 RID: 85158 RVA: 0x005C21EC File Offset: 0x005C03EC
	public void ShowTemp(ConfigPropValue attrData)
	{
		PropertyIndex? propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(attrData.Id);
		if (propertyIndexInfo == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Role, ELogAuthor.BB, "属性表中找不到对应的属性ID配置数据", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		base.GetText(0).ShowTextNew(propertyIndexInfo.Value.Name);
		base.SetTextureByPath(propertyIndexInfo.Value.Icon, base.GetTexture(2), null, null);
		base.GetText(1).SetText(ModelBase<AttributeModel>.Instance.GetFormatAttributeValueString(attrData.Id, (double)attrData.Value, false), true);
	}

	// Token: 0x02008C37 RID: 35895
	private enum EPhantomAttributeItemDefine
	{
		// Token: 0x0402F3AB RID: 193451
		AttrNameText,
		// Token: 0x0402F3AC RID: 193452
		AttrAddValue,
		// Token: 0x0402F3AD RID: 193453
		AttrIconTexture
	}
}
