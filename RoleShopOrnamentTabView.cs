using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Ornament;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020023D0 RID: 9168
public class RoleShopOrnamentTabView : UiTabViewBase, IUiTabViewRefresh
{
	// Token: 0x06011B97 RID: 72599 RVA: 0x004DE1FD File Offset: 0x004DC3FD
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x06011B98 RID: 72600 RVA: 0x004DE238 File Offset: 0x004DC438
	protected override void OnStart()
	{
		this.CurrentShopId = (int)(this.ExtraParams ?? 0);
		this.TabId = (int)(this.Params ?? 0);
		this.Layout = new GenericLayout<OrnamentItemContent, OrnamentItemContentData>(base.GetHorizontalLayout(0), new Func<OrnamentItemContent>(this.OnCreateItem), null, false, true);
	}

	// Token: 0x06011B99 RID: 72601 RVA: 0x004DE29C File Offset: 0x004DC49C
	[NullableContext(1)]
	private OrnamentItemContent OnCreateItem()
	{
		return new OrnamentItemContent();
	}

	// Token: 0x06011B9A RID: 72602 RVA: 0x004DE2A3 File Offset: 0x004DC4A3
	protected override void OnBeforeShow()
	{
		this.RefreshLayout();
	}

	// Token: 0x06011B9B RID: 72603 RVA: 0x004DE2AC File Offset: 0x004DC4AC
	private void RefreshLayout()
	{
		List<PayShopGoods> payShopTabData = ModelBase<PayShopModel>.Instance.GetPayShopTabData((PayShopDefine.EPayShopTabType)this.CurrentShopId, this.TabId, true);
		List<OrnamentItemContentData> list = new List<OrnamentItemContentData>();
		int count = payShopTabData.Count;
		for (int i = 0; i < count; i++)
		{
			PayShopGoods data = payShopTabData[i];
			list.Add(new OrnamentItemContentData
			{
				ShopRoleOrnamentData = ShopRoleOrnamentData.Create(data),
				AllData = payShopTabData
			});
		}
		this.Layout.RefreshByData(list, null, true);
	}

	// Token: 0x06011B9C RID: 72604 RVA: 0x004DE326 File Offset: 0x004DC526
	[NullableContext(2)]
	public void RefreshView(object @params)
	{
	}

	// Token: 0x04008AC4 RID: 35524
	private int CurrentShopId;

	// Token: 0x04008AC5 RID: 35525
	private int TabId;

	// Token: 0x04008AC6 RID: 35526
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<OrnamentItemContent, OrnamentItemContentData> Layout;

	// Token: 0x02008704 RID: 34564
	private enum EComponent
	{
		// Token: 0x0402DA99 RID: 187033
		HorizontalLayout,
		// Token: 0x0402DA9A RID: 187034
		Item
	}
}
