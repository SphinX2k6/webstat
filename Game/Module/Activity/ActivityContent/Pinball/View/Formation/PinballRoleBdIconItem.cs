using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Formation
{
	// Token: 0x02006635 RID: 26165
	public class PinballRoleBdIconItem : UiPanelBase
	{
		// Token: 0x060415B9 RID: 267705 RVA: 0x010C3798 File Offset: 0x010C1998
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

		// Token: 0x060415BA RID: 267706 RVA: 0x010C3804 File Offset: 0x010C1A04
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

		// Token: 0x0200C65B RID: 50779
		private enum EComponent
		{
			// Token: 0x0403D100 RID: 250112
			BgSprite,
			// Token: 0x0403D101 RID: 250113
			BdTexture
		}
	}
}
