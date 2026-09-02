using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.TipsTalk
{
	// Token: 0x0200537F RID: 21375
	public class PlotBattleTipsView : PlotTipsViewBase
	{
		// Token: 0x06036835 RID: 223285 RVA: 0x00DC6E42 File Offset: 0x00DC5042
		public PlotBattleTipsView()
		{
			this.ResourceId = "UiView_BattleTips_Prefab";
			this.OverrideAudioEventName = "play_external_vo_subtitle_assist";
			this.OverrideAudioSrcName = "external_plot_voice_assist";
		}

		// Token: 0x06036836 RID: 223286 RVA: 0x00DC6E6C File Offset: 0x00DC506C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06036837 RID: 223287 RVA: 0x00DC6F17 File Offset: 0x00DC5117
		protected override void OnInit()
		{
			this.IconItem = base.GetTexture(1);
			this.SubtitleItem = base.GetText(3);
			this.NameItem = base.GetText(2);
		}

		// Token: 0x06036838 RID: 223288 RVA: 0x00DC6F40 File Offset: 0x00DC5140
		[NullableContext(2)]
		protected override UUIItem GetParentItem()
		{
			return Singleton<UiLayer>.Instance.GetBattleViewUnit(3);
		}

		// Token: 0x0200B2CA RID: 45770
		private static class EChildCom
		{
			// Token: 0x040376B2 RID: 226994
			public const int Prefab = 0;

			// Token: 0x040376B3 RID: 226995
			public const int Icon = 1;

			// Token: 0x040376B4 RID: 226996
			public const int Name = 2;

			// Token: 0x040376B5 RID: 226997
			public const int Text = 3;
		}
	}
}
