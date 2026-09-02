using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x0200669D RID: 26269
	public class MowingBuffLevelPanel : UiPanelBase
	{
		// Token: 0x0604199E RID: 268702 RVA: 0x010D1DC4 File Offset: 0x010CFFC4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0604199F RID: 268703 RVA: 0x010D1EB1 File Offset: 0x010D00B1
		protected override void OnStart()
		{
			UUISprite sprite = base.GetSprite(0);
			if (sprite != null)
			{
				sprite.SetUIActive(false);
			}
			UUISprite sprite2 = base.GetSprite(5);
			if (sprite2 != null)
			{
				sprite2.SetUIActive(false);
			}
			UUIItem item = base.GetItem(3);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x060419A0 RID: 268704 RVA: 0x010D1EEC File Offset: 0x010D00EC
		[NullableContext(2)]
		public void RefreshByLevelContent(string content)
		{
			UUIItem item = base.GetItem(1);
			if (content == null)
			{
				if (item != null)
				{
					item.SetUIActive(false);
				}
				return;
			}
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIText text = base.GetText(2);
			if (text == null)
			{
				return;
			}
			text.SetText(content, true);
		}

		// Token: 0x0200C6A8 RID: 50856
		private class ELevelComponent
		{
			// Token: 0x0403D2B2 RID: 250546
			public const int LockSprite = 0;

			// Token: 0x0403D2B3 RID: 250547
			public const int LevelItem = 1;

			// Token: 0x0403D2B4 RID: 250548
			public const int LevelText = 2;

			// Token: 0x0403D2B5 RID: 250549
			public const int VisionLevelItem = 3;

			// Token: 0x0403D2B6 RID: 250550
			public const int VisionLevelText = 4;

			// Token: 0x0403D2B7 RID: 250551
			public const int DeprecateSprite = 5;
		}
	}
}
