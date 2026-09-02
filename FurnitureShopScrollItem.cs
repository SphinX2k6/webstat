using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020010A5 RID: 4261
[NullableContext(1)]
[Nullable(0)]
public class FurnitureShopScrollItem : UiPanelBase
{
	// Token: 0x06006F13 RID: 28435 RVA: 0x001CE602 File Offset: 0x001CC802
	public FurnitureShopScrollItem(UUILoopScrollViewComponent scroller, UUIItem item)
	{
		this.Scroller = scroller;
		this.Item = item;
	}

	// Token: 0x06006F14 RID: 28436 RVA: 0x001CE618 File Offset: 0x001CC818
	protected override void OnStart()
	{
		this.LoopScrollView = new LoopScrollView<FurnitureShopGridItem, FurnitureShopGridItemProxy>(this.Scroller, this.Item.GetOwner() as AUIBaseActor, new Func<FurnitureShopGridItem>(this.InitItem), false);
	}

	// Token: 0x06006F15 RID: 28437 RVA: 0x001CE648 File Offset: 0x001CC848
	private FurnitureShopGridItem InitItem()
	{
		return new FurnitureShopGridItem();
	}

	// Token: 0x06006F16 RID: 28438 RVA: 0x001CE650 File Offset: 0x001CC850
	private List<PayShopGoods> GetDataList(int shopId, FurnitureFilterConfig filterConfig)
	{
		List<PayShopGoods> payShopTabData = ModelBase<PayShopModel>.Instance.GetPayShopTabData((PayShopDefine.EPayShopTabType)shopId, 1, true);
		int[] source = filterConfig.TagList();
		List<PayShopGoods> list = new List<PayShopGoods>();
		foreach (PayShopGoods payShopGoods in payShopTabData)
		{
			if (source.Contains(ModelBase<FurnitureModel>.Instance.GetFurnitureConfigByGoodsData(payShopGoods).TagId))
			{
				list.Add(payShopGoods);
			}
		}
		return list;
	}

	// Token: 0x06006F17 RID: 28439 RVA: 0x001CE6D8 File Offset: 0x001CC8D8
	public UniTask Refresh(int shopId, FurnitureFilterConfig filterConfig)
	{
		FurnitureShopScrollItem.<Refresh>d__7 <Refresh>d__;
		<Refresh>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Refresh>d__.<>4__this = this;
		<Refresh>d__.shopId = shopId;
		<Refresh>d__.filterConfig = filterConfig;
		<Refresh>d__.<>1__state = -1;
		<Refresh>d__.<>t__builder.Start<FurnitureShopScrollItem.<Refresh>d__7>(ref <Refresh>d__);
		return <Refresh>d__.<>t__builder.Task;
	}

	// Token: 0x0400351E RID: 13598
	protected LoopScrollView<FurnitureShopGridItem, FurnitureShopGridItemProxy> LoopScrollView;

	// Token: 0x0400351F RID: 13599
	[Nullable(2)]
	private readonly UUILoopScrollViewComponent Scroller;

	// Token: 0x04003520 RID: 13600
	[Nullable(2)]
	private readonly UUIItem Item;
}
