using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.BigStuffedDoll.View
{
	// Token: 0x02006F69 RID: 28521
	public class BigStuffedRingSubItem<T> : UiPanelBase where T : Enum
	{
		// Token: 0x06045076 RID: 282742 RVA: 0x011F95D5 File Offset: 0x011F77D5
		public BigStuffedRingSubItem(int RingId, [Nullable(new byte[]
		{
			0,
			1
		})] OneOf<BrokenRockRing, BrokenRockRingConfig> RingConfig)
		{
			this.RingId = RingId;
			this.RingConfig = RingConfig;
		}

		// Token: 0x06045077 RID: 282743 RVA: 0x011F95EC File Offset: 0x011F77EC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06045078 RID: 282744 RVA: 0x011F9655 File Offset: 0x011F7855
		protected override void OnStart()
		{
			this.TextureRing = base.GetTexture(1);
		}

		// Token: 0x06045079 RID: 282745 RVA: 0x011F9664 File Offset: 0x011F7864
		protected override void OnBeforeDestroy()
		{
			this.TextureRing = null;
		}

		// Token: 0x0402681C RID: 157724
		[Nullable(2)]
		protected T Type;

		// Token: 0x0402681D RID: 157725
		[Nullable(2)]
		protected UUITexture TextureRing;

		// Token: 0x0402681E RID: 157726
		protected int RingId;

		// Token: 0x0402681F RID: 157727
		[Nullable(new byte[]
		{
			0,
			1
		})]
		protected OneOf<BrokenRockRing, BrokenRockRingConfig> RingConfig;
	}
}
