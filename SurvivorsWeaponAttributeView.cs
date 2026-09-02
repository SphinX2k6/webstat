using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002B13 RID: 11027
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsWeaponAttributeView : UiViewBase
{
	// Token: 0x0601607E RID: 90238 RVA: 0x0061CEEC File Offset: 0x0061B0EC
	public SurvivorsWeaponAttributeView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0601607F RID: 90239 RVA: 0x0061CEF8 File Offset: 0x0061B0F8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x06016080 RID: 90240 RVA: 0x0061CF54 File Offset: 0x0061B154
	protected override void OnStart()
	{
		SurvivorsWeaponGainData survivorsWeaponGainData = this.OpenParam as SurvivorsWeaponGainData;
		if (survivorsWeaponGainData == null)
		{
			return;
		}
		this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
		this.CaptionItem.SetCloseCallBack(delegate
		{
			base.CloseMe(null);
		});
		this.CaptionItem.SetHelpBtnActive(false);
		this.WeaponAttributeItemLayout = new GenericLayout<SurvivorsWeaponAttributeItem, ISurvivorsWeaponAttributeData>(base.GetVerticalLayout(2), new Func<SurvivorsWeaponAttributeItem>(this.CreateAttributeItem), null, false, true);
		this.WeaponAttributeItemLayout.RefreshByData(survivorsWeaponGainData.GetWeaponSpecialAttributeList(), null, false);
	}

	// Token: 0x06016081 RID: 90241 RVA: 0x0061CFDA File Offset: 0x0061B1DA
	private SurvivorsWeaponAttributeItem CreateAttributeItem()
	{
		return new SurvivorsWeaponAttributeItem();
	}

	// Token: 0x0400A94B RID: 43339
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x0400A94C RID: 43340
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<SurvivorsWeaponAttributeItem, ISurvivorsWeaponAttributeData> WeaponAttributeItemLayout;
}
