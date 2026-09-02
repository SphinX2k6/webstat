using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.TipsTalk
{
	// Token: 0x02005381 RID: 21377
	public class PlotPhotoTipsView : PlotTipsViewBase
	{
		// Token: 0x06036841 RID: 223297 RVA: 0x00DC722F File Offset: 0x00DC542F
		public PlotPhotoTipsView()
		{
			this.ResourceId = "UiView_PhotoTips_Prefab";
		}

		// Token: 0x06036842 RID: 223298 RVA: 0x00DC7244 File Offset: 0x00DC5444
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

		// Token: 0x06036843 RID: 223299 RVA: 0x00DC72AD File Offset: 0x00DC54AD
		protected override void OnInit()
		{
			this.IconItem = base.GetTexture(0);
			this.SubtitleItem = base.GetText(1);
		}

		// Token: 0x06036844 RID: 223300 RVA: 0x00DC72C9 File Offset: 0x00DC54C9
		[NullableContext(2)]
		protected override UUIItem GetParentItem()
		{
			return Singleton<UiLayer>.Instance.GetLayerRootUiItem(ELayerType.BattleFloat);
		}

		// Token: 0x0200B2CC RID: 45772
		private static class EChildCom
		{
			// Token: 0x040376BA RID: 227002
			public const int Icon = 0;

			// Token: 0x040376BB RID: 227003
			public const int Text = 1;
		}
	}
}
