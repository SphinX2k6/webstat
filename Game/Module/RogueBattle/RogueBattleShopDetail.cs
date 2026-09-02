using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x0200521A RID: 21018
	public class RogueBattleShopDetail : UiPanelBase
	{
		// Token: 0x06035DFF RID: 220671 RVA: 0x00D8F32C File Offset: 0x00D8D52C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(8, typeof(UUITexture)),
				new ValueTuple<int, Type>(9, typeof(UUIText)),
				new ValueTuple<int, Type>(10, typeof(UUIText)),
				new ValueTuple<int, Type>(11, typeof(UUIHorizontalLayout))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(7, new Action(this.OnBtnConfirm))
			};
		}

		// Token: 0x06035E00 RID: 220672 RVA: 0x00D8F474 File Offset: 0x00D8D674
		[NullableContext(1)]
		public void Refresh(RogueResGainData data)
		{
			RogueResBuffPool? rogueResBuffPoolById = ConfigBase<RogueBattleConfig>.Instance.GetRogueResBuffPoolById(data.RogueResShopToken.ConfigId);
			if (rogueResBuffPoolById == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), rogueResBuffPoolById.Value.BuffName, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), rogueResBuffPoolById.Value.BuffDesc, rogueResBuffPoolById.Value.BuffDescParam());
			RogueResShopToken rogueResShopToken = data.RogueResShopToken;
			bool flag = rogueResShopToken.CurPrice != rogueResShopToken.SourcePrice;
			int num = flag ? rogueResShopToken.CurPrice : rogueResShopToken.SourcePrice;
			RogueCurrency? rogueCurrencyConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueCurrencyConfig(80100000);
			int roguelikeCurrency = ModelBase<RoguelikeModel>.Instance.GetRoguelikeCurrency(80100000);
			if (flag)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), "RogueShopOriginPriceDiscount", new <>z__ReadOnlySingleElementList<object>(rogueResShopToken.SourcePrice.ToString()));
			}
			else
			{
				UUIText text = base.GetText(10);
				if (text != null)
				{
					text.SetText(string.Empty, true);
				}
			}
			UUIText text2 = base.GetText(9);
			if (text2 != null)
			{
				text2.SetText(num.ToString(), true);
			}
			base.GetText(9).useChangeColor = (roguelikeCurrency < num);
			base.SetTextureByPath(((rogueCurrencyConfig != null) ? rogueCurrencyConfig.GetValueOrDefault().IconSmall : null) ?? string.Empty, base.GetTexture(8), null, null);
			UUIItem item = base.GetItem(6);
			if (item != null)
			{
				item.SetUIActive(!rogueResShopToken.IsSell);
			}
			UUIButtonComponent button = base.GetButton(7);
			if (button != null)
			{
				button.SetSelfInteractive(true);
			}
			UUIButtonComponent button2 = base.GetButton(7);
			if (button2 != null)
			{
				button2.RootUIComp.Get().SetUIActive(!rogueResShopToken.IsSell);
			}
			UUIHorizontalLayout horizontalLayout = base.GetHorizontalLayout(11);
			if (horizontalLayout == null)
			{
				return;
			}
			horizontalLayout.RootUIComp.Get().SetUIActive(false);
		}

		// Token: 0x06035E01 RID: 220673 RVA: 0x00D8F670 File Offset: 0x00D8D870
		private void OnBtnConfirm()
		{
			UUIButtonComponent button = base.GetButton(7);
			if (button != null)
			{
				button.SetSelfInteractive(false);
			}
			RogueResGainData selectGainData = ModelBase<RogueBattleModel>.Instance.SelectGainData;
			if (selectGainData == null)
			{
				return;
			}
			ControllerBase<RogueBattleController>.Instance.SelectTokenRequest(selectGainData.RogueResShopToken.Index).Forget();
		}
	}
}
