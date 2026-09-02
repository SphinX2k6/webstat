using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200239F RID: 9119
[NullableContext(1)]
[Nullable(0)]
public class GameplayShopUtil
{
	// Token: 0x06011914 RID: 71956 RVA: 0x004D124F File Offset: 0x004CF44F
	public static void SetText(UUIText text, GameplayShopTextData textData)
	{
		if (text == null || textData == null)
		{
			return;
		}
		if (!string.IsNullOrEmpty(textData.Content))
		{
			text.SetText(textData.Content, true);
			return;
		}
		if (textData.Data != null)
		{
			GameplayShopUtil.SetTextByData(text, textData.Data);
		}
	}

	// Token: 0x06011915 RID: 71957 RVA: 0x004D1288 File Offset: 0x004CF488
	public static void SetTextByData(UUIText text, TableTextArgNew data)
	{
		if (text == null)
		{
			return;
		}
		string textKey = data.TextKey;
		if (string.IsNullOrEmpty(textKey))
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, textKey, data.Params);
	}

	// Token: 0x06011916 RID: 71958 RVA: 0x004D12BC File Offset: 0x004CF4BC
	public static void OpenExchangePopView(PayShopGoods goodsData)
	{
		CommonGameplayShopExchangePopViewProxy commonGameplayShopExchangePopViewProxy = new CommonGameplayShopExchangePopViewProxy();
		commonGameplayShopExchangePopViewProxy.UpdateFromPayShopGoods(goodsData);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.GameplayExchangePopView, commonGameplayShopExchangePopViewProxy, null);
	}
}
