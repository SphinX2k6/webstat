using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BossPiling.View.Item
{
	// Token: 0x02005F0F RID: 24335
	public class BossPilingFetterItem : UiPanelBase
	{
		// Token: 0x0603D1D5 RID: 250325 RVA: 0x00F86974 File Offset: 0x00F84B74
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D1D6 RID: 250326 RVA: 0x00F869E0 File Offset: 0x00F84BE0
		public void Refresh(int id)
		{
			ElementInfo? elementConfig = ConfigBase<CommonConfig>.Instance.GetElementConfig(id);
			if (elementConfig == null)
			{
				return;
			}
			FColor color = FColor.FromHex(elementConfig.Value.ElementColor);
			base.GetSprite(0).SetColor(color);
			base.SetTextureByPath(elementConfig.Value.Icon5, base.GetTexture(1), null, null);
		}

		// Token: 0x0200BF0F RID: 48911
		private enum EFetter
		{
			// Token: 0x0403ACF2 RID: 240882
			Sprite,
			// Token: 0x0403ACF3 RID: 240883
			Tex
		}
	}
}
