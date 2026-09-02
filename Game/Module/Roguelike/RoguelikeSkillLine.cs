using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x020051A6 RID: 20902
	public class RoguelikeSkillLine : UiPanelBase
	{
		// Token: 0x06035C0A RID: 220170 RVA: 0x00D842B4 File Offset: 0x00D824B4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035C0B RID: 220171 RVA: 0x00D84380 File Offset: 0x00D82580
		public void Refresh(bool isUnlock, int offset, int pos)
		{
			if (isUnlock)
			{
				base.GetSprite(4).SetColor(FColor.FromHex("AA9B6AFF"));
			}
			else
			{
				base.GetSprite(4).SetColor(FColor.FromHex("43434380"));
			}
			base.GetItem(0).SetUIActive(offset == 0);
			base.GetItem(3).SetUIActive(pos == 1 && offset == 1);
			base.GetItem(2).SetUIActive(pos == 1 && offset == -1);
		}

		// Token: 0x0200B17D RID: 45437
		public static class ERoguelikeSkillLineDefine
		{
			// Token: 0x040370AD RID: 225453
			public const int RightItem = 0;

			// Token: 0x040370AE RID: 225454
			public const int LeftItem = 1;

			// Token: 0x040370AF RID: 225455
			public const int UpItem = 2;

			// Token: 0x040370B0 RID: 225456
			public const int DownItem = 3;

			// Token: 0x040370B1 RID: 225457
			public const int SpriteLine = 4;
		}
	}
}
