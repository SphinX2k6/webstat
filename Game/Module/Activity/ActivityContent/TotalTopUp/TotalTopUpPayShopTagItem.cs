using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.PayShop;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp
{
	// Token: 0x02006285 RID: 25221
	public class TotalTopUpPayShopTagItem : PayShopExtraTagItem
	{
		// Token: 0x0603F802 RID: 260098 RVA: 0x01047E94 File Offset: 0x01046094
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603F803 RID: 260099 RVA: 0x01047F00 File Offset: 0x01046100
		protected override void OnStart()
		{
			TotalTopUpController instance = ControllerBase<TotalTopUpController>.Instance;
			string text = (instance != null) ? instance.GetCurrentScoreIconPath() : null;
			if (!string.IsNullOrEmpty(text))
			{
				UUITexture texture = base.GetTexture(1);
				base.SetTextureByPath(text, texture, null, null);
			}
		}

		// Token: 0x0603F804 RID: 260100 RVA: 0x01047F44 File Offset: 0x01046144
		[NullableContext(1)]
		public override void Refresh(IPayShopUnionData data)
		{
			TotalTopUpController instance = ControllerBase<TotalTopUpController>.Instance;
			if (instance == null)
			{
				return;
			}
			int num = 0;
			PayShopGoods payShopGoods = data as PayShopGoods;
			if (payShopGoods != null)
			{
				num = instance.GetGoodsScore(payShopGoods.GetGoodsId());
			}
			else
			{
				PayItemData payItemData = data as PayItemData;
				if (payItemData != null)
				{
					num = instance.GetRechargeItemScore(payItemData.PayItemId);
				}
			}
			if (num <= 0)
			{
				base.SetUiActive(false);
				return;
			}
			base.SetUiActive(true);
			UUIText text = base.GetText(0);
			if (text == null)
			{
				return;
			}
			text.SetText(num.ToString(), true);
		}

		// Token: 0x0200C36A RID: 50026
		private class ENode
		{
			// Token: 0x0403C383 RID: 246659
			public const int Text = 0;

			// Token: 0x0403C384 RID: 246660
			public const int TextureIcon = 1;
		}
	}
}
