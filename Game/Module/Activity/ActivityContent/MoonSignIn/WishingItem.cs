using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MoonSignIn
{
	// Token: 0x0200672A RID: 26410
	internal class WishingItem : UiPanelBase
	{
		// Token: 0x06041E15 RID: 269845 RVA: 0x010E72C8 File Offset: 0x010E54C8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041E16 RID: 269846 RVA: 0x010E7374 File Offset: 0x010E5574
		public void RefreshItem(int moonId)
		{
			PhaseOfMoon? phaseOfMoonById = ConfigBase<MoonSignInConfig>.Instance.GetPhaseOfMoonById(moonId);
			if (phaseOfMoonById == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), phaseOfMoonById.Value.Talk(0), Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), phaseOfMoonById.Value.Talk(1), Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), phaseOfMoonById.Value.Talk(2), Array.Empty<object>());
			base.SetTextureByPath(phaseOfMoonById.Value.Texture, base.GetTexture(5), null, null);
		}

		// Token: 0x0200C75E RID: 51038
		private class EWishingItemDefine
		{
			// Token: 0x0403D600 RID: 251392
			public const int DesText1 = 0;

			// Token: 0x0403D601 RID: 251393
			public const int DesText2 = 1;

			// Token: 0x0403D602 RID: 251394
			public const int DesText3 = 2;

			// Token: 0x0403D603 RID: 251395
			public const int MoonTexture = 5;
		}
	}
}
