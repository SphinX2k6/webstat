using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020023CD RID: 9165
public class ShopFlySkinTabView : UiTabViewBase, IUiTabViewRefresh
{
	// Token: 0x06011B7B RID: 72571 RVA: 0x004DD782 File Offset: 0x004DB982
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x06011B7C RID: 72572 RVA: 0x004DD7BC File Offset: 0x004DB9BC
	protected override void OnStart()
	{
		this.CurrentShopId = (int)(this.ExtraParams ?? 0);
		this.TabId = (int)(this.Params ?? 0);
		this.Layout = new GenericLayout<FlySkinItemContent, FlySkinItemContentData>(base.GetHorizontalLayout(0), new Func<FlySkinItemContent>(this.OnCreateItem), null, false, true);
	}

	// Token: 0x06011B7D RID: 72573 RVA: 0x004DD820 File Offset: 0x004DBA20
	[NullableContext(1)]
	private FlySkinItemContent OnCreateItem()
	{
		return new FlySkinItemContent();
	}

	// Token: 0x06011B7E RID: 72574 RVA: 0x004DD827 File Offset: 0x004DBA27
	protected override void OnBeforeShow()
	{
		this.RefreshLayout();
	}

	// Token: 0x06011B7F RID: 72575 RVA: 0x004DD830 File Offset: 0x004DBA30
	private void RefreshLayout()
	{
		List<PayShopGoods> payShopTabData = ModelBase<PayShopModel>.Instance.GetPayShopTabData((PayShopDefine.EPayShopTabType)this.CurrentShopId, this.TabId, true);
		List<FlySkinItemContentData> list = new List<FlySkinItemContentData>();
		int count = payShopTabData.Count;
		for (int i = 0; i < count; i++)
		{
			PayShopGoods data = payShopTabData[i];
			FlySkinItemContentData flySkinItemContentData = new FlySkinItemContentData();
			ShopFlySkinData shopFlySkinData = ShopFlySkinData.Create(data);
			flySkinItemContentData.ShopFlySkinData = shopFlySkinData;
			flySkinItemContentData.AllData = payShopTabData;
			list.Add(flySkinItemContentData);
		}
		this.Layout.RefreshByData(list, null, true);
	}

	// Token: 0x06011B80 RID: 72576 RVA: 0x004DD8AA File Offset: 0x004DBAAA
	[NullableContext(2)]
	public void RefreshView(object @params)
	{
	}

	// Token: 0x04008ABD RID: 35517
	private int CurrentShopId;

	// Token: 0x04008ABE RID: 35518
	private int TabId;

	// Token: 0x04008ABF RID: 35519
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<FlySkinItemContent, FlySkinItemContentData> Layout;

	// Token: 0x02008702 RID: 34562
	private enum EComponent
	{
		// Token: 0x0402DA7D RID: 187005
		HorizontalLayout,
		// Token: 0x0402DA7E RID: 187006
		Item
	}
}
