using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;

// Token: 0x02001C18 RID: 7192
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchShopTask : FloroRanchDailyTaskBase
{
	// Token: 0x0600D137 RID: 53559 RVA: 0x00378A9E File Offset: 0x00376C9E
	public FloroRanchShopTask(FloroRanchShop data)
	{
		this.ShopData = data;
	}

	// Token: 0x0600D138 RID: 53560 RVA: 0x00378AB0 File Offset: 0x00376CB0
	protected override void OnExecute()
	{
		FloroRanchShopViewParam floroRanchShopViewParam = new FloroRanchShopViewParam
		{
			ShopData = this.ShopData,
			CloseCallback = delegate()
			{
				base.Complete(null);
			}
		};
		ModelBase<FloroRanchGamePlayModel>.Instance.OpenAndRecordView(EUiViewName.FloroRanchShopView, floroRanchShopViewParam, null);
	}

	// Token: 0x040063E8 RID: 25576
	private readonly FloroRanchShop ShopData;
}
