using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x0200682E RID: 26670
	public class FishingTechCostItem : UiPanelBase
	{
		// Token: 0x060427EE RID: 272366 RVA: 0x01111324 File Offset: 0x0110F524
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060427EF RID: 272367 RVA: 0x01111390 File Offset: 0x0110F590
		public void RefreshCost(int itemId, int costNum, bool setColor = true)
		{
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId);
			if (itemConfigData == null)
			{
				return;
			}
			base.SetTextureByPath(itemConfigData.IconSmall, base.GetTexture(2), null, null);
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(itemId, 0);
			string newText;
			if (setColor)
			{
				if (itemCountByConfigId < costNum)
				{
					newText = StringUtils.Format("<color=#c25757>{0}</color>", new string[]
					{
						costNum.ToString()
					});
				}
				else
				{
					newText = StringUtils.Format("<color=#81764c>{0}</color>", new string[]
					{
						costNum.ToString()
					});
				}
			}
			else
			{
				newText = costNum.ToString();
			}
			base.GetText(1).SetText(newText, true);
		}

		// Token: 0x0200C86E RID: 51310
		private class EComponentDefine
		{
			// Token: 0x0403DB15 RID: 252693
			public const int TipsText = 0;

			// Token: 0x0403DB16 RID: 252694
			public const int CostText = 1;

			// Token: 0x0403DB17 RID: 252695
			public const int Texture = 2;
		}
	}
}
