using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020023CA RID: 9162
public class RoleShopSkinTabView : UiTabViewBase, IUiTabViewRefresh
{
	// Token: 0x06011B5F RID: 72543 RVA: 0x004DCDA2 File Offset: 0x004DAFA2
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x06011B60 RID: 72544 RVA: 0x004DCDDC File Offset: 0x004DAFDC
	protected override void OnStart()
	{
		this.CurrentShopId = (int)(this.ExtraParams ?? 0);
		this.TabId = (int)(this.Params ?? 0);
		this.Layout = new GenericLayout<SkinItemContent, SkinItemContentData>(base.GetHorizontalLayout(0), new Func<SkinItemContent>(this.OnCreateItem), null, false, true);
	}

	// Token: 0x06011B61 RID: 72545 RVA: 0x004DCE40 File Offset: 0x004DB040
	[NullableContext(1)]
	private SkinItemContent OnCreateItem()
	{
		return new SkinItemContent();
	}

	// Token: 0x06011B62 RID: 72546 RVA: 0x004DCE47 File Offset: 0x004DB047
	protected override void OnBeforeShow()
	{
		this.RefreshLayout();
	}

	// Token: 0x06011B63 RID: 72547 RVA: 0x004DCE50 File Offset: 0x004DB050
	private void RefreshLayout()
	{
		List<PayShopGoods> payShopTabData = ModelBase<PayShopModel>.Instance.GetPayShopTabData((PayShopDefine.EPayShopTabType)this.CurrentShopId, this.TabId, true);
		List<SkinItemContentData> list = new List<SkinItemContentData>();
		int count = payShopTabData.Count;
		for (int i = 0; i < count; i++)
		{
			PayShopGoods data = payShopTabData[i];
			SkinItemContentData skinItemContentData = new SkinItemContentData();
			ShopSkinData shopSkinData = ShopSkinData.Create(data);
			skinItemContentData.ShopSkinData = shopSkinData;
			skinItemContentData.AllData = payShopTabData;
			list.Add(skinItemContentData);
		}
		this.Layout.RefreshByData(list, null, true);
	}

	// Token: 0x06011B64 RID: 72548 RVA: 0x004DCECA File Offset: 0x004DB0CA
	[NullableContext(2)]
	public void RefreshView(object @params)
	{
	}

	// Token: 0x04008AB6 RID: 35510
	private int CurrentShopId;

	// Token: 0x04008AB7 RID: 35511
	private int TabId;

	// Token: 0x04008AB8 RID: 35512
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<SkinItemContent, SkinItemContentData> Layout;

	// Token: 0x02008700 RID: 34560
	private enum EComponent
	{
		// Token: 0x0402DA63 RID: 186979
		HorizontalLayout,
		// Token: 0x0402DA64 RID: 186980
		Item
	}
}
