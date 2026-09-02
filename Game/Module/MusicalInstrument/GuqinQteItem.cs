using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.MusicalInstrument
{
	// Token: 0x020056D1 RID: 22225
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class GuqinQteItem : GridProxyAbstract<MusicalInstrumentQteItemData>
	{
		// Token: 0x06038938 RID: 231736 RVA: 0x00E55758 File Offset: 0x00E53958
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06038939 RID: 231737 RVA: 0x00E557E4 File Offset: 0x00E539E4
		[NullableContext(1)]
		public override void Refresh(MusicalInstrumentQteItemData data, bool isSelected, int gridIndex)
		{
			UUISprite sprite = base.GetSprite(1);
			if (sprite != null)
			{
				sprite.SetUIActive(data.Finished);
			}
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(!data.Finished);
			}
			UUISprite sprite2 = base.GetSprite(0);
			if (sprite2 == null)
			{
				return;
			}
			sprite2.SetUIActive(false);
		}

		// Token: 0x04020474 RID: 132212
		[Nullable(2)]
		public Func<int, int, GuqinKeyConfig> GetKeyConfigCallback;

		// Token: 0x0200B754 RID: 46932
		private enum EGuqinQteItemComponent
		{
			// Token: 0x04038B46 RID: 232262
			SprIcon,
			// Token: 0x04038B47 RID: 232263
			SprFinished,
			// Token: 0x04038B48 RID: 232264
			PnlKey
		}
	}
}
