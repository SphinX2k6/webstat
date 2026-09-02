using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item.ItemComponent
{
	// Token: 0x0200661D RID: 26141
	internal class BdComponent : UiPanelBase
	{
		// Token: 0x06041528 RID: 267560 RVA: 0x010C11D0 File Offset: 0x010BF3D0
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

		// Token: 0x06041529 RID: 267561 RVA: 0x010C123C File Offset: 0x010BF43C
		public void RefreshItem(int bdId)
		{
			PinballBdConfig? pinballBdConfigById = ConfigBase<PinballConfig>.Instance.GetPinballBdConfigById(bdId);
			if (pinballBdConfigById == null)
			{
				return;
			}
			base.SetTextureByPath(pinballBdConfigById.Value.Icon, base.GetTexture(1), null, null);
			base.GetSprite(0).SetColor(FColor.FromHex(pinballBdConfigById.Value.BgColor));
		}

		// Token: 0x0200C649 RID: 50761
		private enum EBdComponent
		{
			// Token: 0x0403D09A RID: 250010
			BgSprite,
			// Token: 0x0403D09B RID: 250011
			BdTexture
		}
	}
}
