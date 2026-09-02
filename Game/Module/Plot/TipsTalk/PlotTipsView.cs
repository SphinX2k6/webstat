using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.TipsTalk
{
	// Token: 0x02005382 RID: 21378
	public class PlotTipsView : PlotTipsViewBase
	{
		// Token: 0x06036845 RID: 223301 RVA: 0x00DC72D7 File Offset: 0x00DC54D7
		public PlotTipsView()
		{
			this.ResourceId = "UiView_MascotTips";
		}

		// Token: 0x06036846 RID: 223302 RVA: 0x00DC72EC File Offset: 0x00DC54EC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06036847 RID: 223303 RVA: 0x00DC7355 File Offset: 0x00DC5555
		protected override void OnInit()
		{
			this.IconItem = base.GetTexture(0);
			this.SubtitleItem = base.GetText(1);
		}

		// Token: 0x0200B2CD RID: 45773
		private static class EChildCom
		{
			// Token: 0x040376BC RID: 227004
			public const int Icon = 0;

			// Token: 0x040376BD RID: 227005
			public const int Text = 1;
		}
	}
}
