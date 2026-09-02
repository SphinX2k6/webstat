using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Manufacture.Common
{
	// Token: 0x020059F1 RID: 23025
	public class IconItem : UiPanelBase
	{
		// Token: 0x0603A562 RID: 238946 RVA: 0x00ECA74F File Offset: 0x00EC894F
		[NullableContext(1)]
		public IconItem(UUIItem uiItem)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603A563 RID: 238947 RVA: 0x00ECA764 File Offset: 0x00EC8964
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603A564 RID: 238948 RVA: 0x00ECA7D0 File Offset: 0x00EC89D0
		public void SetIcon(int itemId)
		{
			base.SetItemIcon(base.GetTexture(3), itemId, null, null);
		}

		// Token: 0x0603A565 RID: 238949 RVA: 0x00ECA7F8 File Offset: 0x00EC89F8
		public void SetQuality(int itemId)
		{
			base.SetItemQualityIcon(base.GetSprite(4), itemId, null, CommonDefine.EQualityIconType.BackgroundSprite, null);
		}

		// Token: 0x0200B9C1 RID: 47553
		private class EIconItemDefine
		{
			// Token: 0x0403965E RID: 235102
			public const int IconTexture = 3;

			// Token: 0x0403965F RID: 235103
			public const int QualitySprite = 4;
		}
	}
}
