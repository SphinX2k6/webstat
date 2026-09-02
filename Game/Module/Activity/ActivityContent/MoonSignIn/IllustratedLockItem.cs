using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MoonSignIn
{
	// Token: 0x02006729 RID: 26409
	internal class IllustratedLockItem : UiPanelBase
	{
		// Token: 0x06041E12 RID: 269842 RVA: 0x010E71E4 File Offset: 0x010E53E4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041E13 RID: 269843 RVA: 0x010E7250 File Offset: 0x010E5450
		public void RefreshItem(int moonId)
		{
			PhaseOfMoon? phaseOfMoonById = ConfigBase<MoonSignInConfig>.Instance.GetPhaseOfMoonById(moonId);
			if (phaseOfMoonById == null)
			{
				return;
			}
			base.SetTextureByPath(phaseOfMoonById.Value.Texture, base.GetTexture(0), null, null);
			base.SetTextureByPath(phaseOfMoonById.Value.Texture, base.GetTexture(1), null, null);
		}

		// Token: 0x0200C75D RID: 51037
		private class EIllustratedLockItemDefine
		{
			// Token: 0x0403D5FE RID: 251390
			public const int MoonTexture = 0;

			// Token: 0x0403D5FF RID: 251391
			public const int MoonMaskTexture = 1;
		}
	}
}
