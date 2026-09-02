using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp
{
	// Token: 0x02006284 RID: 25220
	public class TotalTopUpPayAdditiveTagItem : UiPanelBase
	{
		// Token: 0x0603F7FE RID: 260094 RVA: 0x01047D8C File Offset: 0x01045F8C
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

		// Token: 0x0603F7FF RID: 260095 RVA: 0x01047DF8 File Offset: 0x01045FF8
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

		// Token: 0x0603F800 RID: 260096 RVA: 0x01047E3C File Offset: 0x0104603C
		public void RefreshByGoodsId(int goodsId)
		{
			TotalTopUpController instance = ControllerBase<TotalTopUpController>.Instance;
			if (instance == null)
			{
				return;
			}
			int goodsScore = instance.GetGoodsScore(goodsId);
			if (goodsScore <= 0)
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
			text.SetText(goodsScore.ToString(), true);
		}

		// Token: 0x0200C369 RID: 50025
		private enum ENode
		{
			// Token: 0x0403C381 RID: 246657
			Text,
			// Token: 0x0403C382 RID: 246658
			TextureIcon
		}
	}
}
