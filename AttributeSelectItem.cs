using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001815 RID: 6165
public class AttributeSelectItem : UiPanelBase
{
	// Token: 0x0600AF7D RID: 44925 RVA: 0x002EC200 File Offset: 0x002EA400
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
	}

	// Token: 0x0600AF7E RID: 44926 RVA: 0x002EC288 File Offset: 0x002EA488
	[NullableContext(1)]
	private void RefreshByData(IRefineAttrItemData data)
	{
		base.GetItem(3).SetUIActive(false);
		base.GetItem(4).SetUIActive(true);
		PropertyIndex? propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(data.PropIndexId);
		base.GetText(1).ShowTextNew(propertyIndexInfo.Value.Name);
		base.SetTextureShowUntilLoaded(propertyIndexInfo.Value.Icon, base.GetTexture(0), null);
		PhantomMainPropItem phantomMainPropertyItemId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomMainPropertyItemId(data.PropItemId);
		bool isRatio = phantomMainPropertyItemId.AddType == 2;
		double propRatioValue = TipsDataTool.GetPropRatioValue((double)phantomMainPropertyItemId.StandardProperty, isRatio);
		string formatAttributeValueString = ModelBase<AttributeModel>.Instance.GetFormatAttributeValueString(data.PropIndexId, propRatioValue, isRatio);
		base.GetText(2).SetText(formatAttributeValueString, true);
	}

	// Token: 0x0600AF7F RID: 44927 RVA: 0x002EC348 File Offset: 0x002EA548
	[NullableContext(2)]
	public void RefreshUi(IRefineAttrItemData data)
	{
		if (data != null)
		{
			this.RefreshByData(data);
			return;
		}
		base.GetItem(3).SetUIActive(true);
		base.GetItem(4).SetUIActive(false);
	}

	// Token: 0x02007B98 RID: 31640
	private enum EToggleComponent
	{
		// Token: 0x0402A3E3 RID: 173027
		IconAttribute,
		// Token: 0x0402A3E4 RID: 173028
		TextName,
		// Token: 0x0402A3E5 RID: 173029
		TextValue,
		// Token: 0x0402A3E6 RID: 173030
		PanelSelect,
		// Token: 0x0402A3E7 RID: 173031
		PanelConfirm
	}
}
