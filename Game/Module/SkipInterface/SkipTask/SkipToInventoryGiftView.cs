using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Item.Data;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F2C RID: 20268
	public class SkipToInventoryGiftView : SkipTask
	{
		// Token: 0x060345B7 RID: 214455 RVA: 0x00D1A664 File Offset: 0x00D18864
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			string text = (string)data[0];
			string text2 = (string)data[1];
			string text3 = (string)data[2];
			int num = (data.Length > 3 && data[3] != null) ? ((int)data[3]) : 0;
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.InventoryGiftView))
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("IsInView", Array.Empty<object>());
				return;
			}
			if (ConfigItemAccessedPathById.GetConfig(num, true) == null)
			{
				base.Finish();
				return;
			}
			bool flag = false;
			List<int> giftItemGroupById = ConfigBase<ItemAccessedFromGiftPathConfig>.Instance.GetGiftItemGroupById(num, false);
			int? itemNeedCount = ModelBase<InventoryModel>.Instance.GetItemNeedCount();
			foreach (int num2 in giftItemGroupById)
			{
				int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(num2, 0);
				if (itemCountByConfigId > 0)
				{
					int giftInnerCount = this.GetGiftInnerCount(num2, num);
					int num3 = 1;
					if (itemNeedCount != null && itemNeedCount.Value > 0 && giftInnerCount > 0)
					{
						num3 = (int)Math.Ceiling((double)itemNeedCount.Value / (double)giftInnerCount);
					}
					num3 = Math.Min(num3, itemCountByConfigId);
					if (ControllerBase<InventoryController>.Instance.TryUseGiftItemWithSelectedItem(num2, num, num3))
					{
						flag = true;
						if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.ItemTipsView))
						{
							Singleton<UiManager>.Instance.CloseView(EUiViewName.ItemTipsView, null);
							break;
						}
						break;
					}
				}
			}
			if (!flag)
			{
				this.ShowUnMatchTips();
			}
			ModelBase<InventoryModel>.Instance.SetItemNeedCount(null);
			base.Finish();
		}

		// Token: 0x060345B8 RID: 214456 RVA: 0x00D1A7F0 File Offset: 0x00D189F0
		private void ShowUnMatchTips()
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("InventoryToGift_GiftNotFound", Array.Empty<object>());
		}

		// Token: 0x060345B9 RID: 214457 RVA: 0x00D1A808 File Offset: 0x00D18A08
		private int GetGiftInnerCount(int giftItemId, int targetItemId)
		{
			ItemInfo? config = ConfigBase<ItemConfig>.Instance.GetConfig(giftItemId);
			if (config == null)
			{
				return 0;
			}
			Dictionary<int, int> dictionary = config.Value.Parameters();
			if (dictionary == null || dictionary.Count == 0)
			{
				return 0;
			}
			int id = dictionary.Values.First<int>();
			GiftPackage? giftPackageConfig = ConfigBase<GiftPackageConfig>.Instance.GetGiftPackageConfig(id);
			if (giftPackageConfig == null || giftPackageConfig.Value.Content() == null)
			{
				return 0;
			}
			int result;
			if (giftPackageConfig.Value.Content().TryGetValue(targetItemId, out result))
			{
				return result;
			}
			return 0;
		}
	}
}
