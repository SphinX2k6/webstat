using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066E1 RID: 26337
	public class MotorFightTalentLine : UiPanelBase
	{
		// Token: 0x06041C0F RID: 269327 RVA: 0x010DDA30 File Offset: 0x010DBC30
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041C10 RID: 269328 RVA: 0x010DDA99 File Offset: 0x010DBC99
		public void Refresh(bool isUnlock)
		{
			UUISprite sprite = base.GetSprite(0);
			if (sprite != null)
			{
				sprite.SetUIActive(isUnlock);
			}
			UUISprite sprite2 = base.GetSprite(1);
			if (sprite2 == null)
			{
				return;
			}
			sprite2.SetUIActive(!isUnlock);
		}

		// Token: 0x0200C717 RID: 50967
		private class EMotorFightTalentLineDefine
		{
			// Token: 0x0403D4BD RID: 251069
			public const int SpriteLine = 0;

			// Token: 0x0403D4BE RID: 251070
			public const int SpriteDotLine = 1;
		}
	}
}
