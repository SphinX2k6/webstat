using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200643F RID: 25663
	public class RoverlikeRoleSelectElementTogglePanel : UiPanelBase
	{
		// Token: 0x060406CA RID: 263882 RVA: 0x01083FEC File Offset: 0x010821EC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060406CB RID: 263883 RVA: 0x010840DC File Offset: 0x010822DC
		public void SetLocked(bool locked)
		{
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				item.SetUIActive(locked);
			}
			UUITexture texture = base.GetTexture(1);
			if (texture != null)
			{
				texture.useChangeColor = locked;
			}
			UUITexture texture2 = base.GetTexture(2);
			if (texture2 != null)
			{
				texture2.useChangeColor = locked;
			}
			UUITexture texture3 = base.GetTexture(3);
			if (texture3 != null)
			{
				texture3.useChangeColor = locked;
			}
			UUITexture texture4 = base.GetTexture(4);
			if (texture4 != null)
			{
				texture4.useChangeColor = locked;
			}
			UUISprite sprite = base.GetSprite(5);
			if (sprite != null)
			{
				sprite.useChangeColor = locked;
			}
		}

		// Token: 0x0200C4B4 RID: 50356
		private class EComponents
		{
			// Token: 0x0403C8B2 RID: 247986
			public const int PnlLock = 0;

			// Token: 0x0403C8B3 RID: 247987
			public const int TexBgColor = 1;

			// Token: 0x0403C8B4 RID: 247988
			public const int TexFeatherBg = 2;

			// Token: 0x0403C8B5 RID: 247989
			public const int TexFeatherShadowUp = 3;

			// Token: 0x0403C8B6 RID: 247990
			public const int TexFeatherShadowDown = 4;

			// Token: 0x0403C8B7 RID: 247991
			public const int SprIconBg = 5;
		}
	}
}
