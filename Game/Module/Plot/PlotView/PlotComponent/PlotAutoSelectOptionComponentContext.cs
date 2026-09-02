using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView.PlotComponent
{
	// Token: 0x020053DF RID: 21471
	[NullableContext(2)]
	[Nullable(0)]
	public class PlotAutoSelectOptionComponentContext : IPlotAutoSelectOptionComponentContext
	{
		// Token: 0x17008DD9 RID: 36313
		// (get) Token: 0x06036CFB RID: 224507 RVA: 0x00DE6D3F File Offset: 0x00DE4F3F
		// (set) Token: 0x06036CFC RID: 224508 RVA: 0x00DE6D47 File Offset: 0x00DE4F47
		public UUISliderComponent OptionLimitBar { get; set; }

		// Token: 0x17008DDA RID: 36314
		// (get) Token: 0x06036CFD RID: 224509 RVA: 0x00DE6D50 File Offset: 0x00DE4F50
		// (set) Token: 0x06036CFE RID: 224510 RVA: 0x00DE6D58 File Offset: 0x00DE4F58
		public UUISliderComponent AutoSelectTimeBar { get; set; }

		// Token: 0x17008DDB RID: 36315
		// (get) Token: 0x06036CFF RID: 224511 RVA: 0x00DE6D61 File Offset: 0x00DE4F61
		// (set) Token: 0x06036D00 RID: 224512 RVA: 0x00DE6D69 File Offset: 0x00DE4F69
		public UUIItem ImportantList { get; set; }

		// Token: 0x17008DDC RID: 36316
		// (get) Token: 0x06036D01 RID: 224513 RVA: 0x00DE6D72 File Offset: 0x00DE4F72
		// (set) Token: 0x06036D02 RID: 224514 RVA: 0x00DE6D7A File Offset: 0x00DE4F7A
		public UUITexture ImportantOptionTipsIcon { get; set; }

		// Token: 0x17008DDD RID: 36317
		// (get) Token: 0x06036D03 RID: 224515 RVA: 0x00DE6D83 File Offset: 0x00DE4F83
		// (set) Token: 0x06036D04 RID: 224516 RVA: 0x00DE6D8B File Offset: 0x00DE4F8B
		public UUIText ImportantOptionTipsText { get; set; }

		// Token: 0x17008DDE RID: 36318
		// (get) Token: 0x06036D05 RID: 224517 RVA: 0x00DE6D94 File Offset: 0x00DE4F94
		// (set) Token: 0x06036D06 RID: 224518 RVA: 0x00DE6D9C File Offset: 0x00DE4F9C
		public Func<ITalkItem> GetCurrentContentDelegate { get; set; }

		// Token: 0x17008DDF RID: 36319
		// (get) Token: 0x06036D07 RID: 224519 RVA: 0x00DE6DA5 File Offset: 0x00DE4FA5
		// (set) Token: 0x06036D08 RID: 224520 RVA: 0x00DE6DAD File Offset: 0x00DE4FAD
		public Func<PlotOptionItem> GetSelectedOptionDelegate { get; set; }

		// Token: 0x17008DE0 RID: 36320
		// (get) Token: 0x06036D09 RID: 224521 RVA: 0x00DE6DB6 File Offset: 0x00DE4FB6
		// (set) Token: 0x06036D0A RID: 224522 RVA: 0x00DE6DBE File Offset: 0x00DE4FBE
		[Nullable(new byte[]
		{
			2,
			2,
			1
		})]
		public Func<PlotOptionItem[]> GetOptionItemsDelegate { [return: Nullable(new byte[]
		{
			2,
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			2,
			1
		})] set; }

		// Token: 0x17008DE1 RID: 36321
		// (get) Token: 0x06036D0B RID: 224523 RVA: 0x00DE6DC7 File Offset: 0x00DE4FC7
		// (set) Token: 0x06036D0C RID: 224524 RVA: 0x00DE6DCF File Offset: 0x00DE4FCF
		public Func<float> GetAudioRemainingTimeDelegate { get; set; }

		// Token: 0x17008DE2 RID: 36322
		// (get) Token: 0x06036D0D RID: 224525 RVA: 0x00DE6DD8 File Offset: 0x00DE4FD8
		// (set) Token: 0x06036D0E RID: 224526 RVA: 0x00DE6DE0 File Offset: 0x00DE4FE0
		public Func<float> GetAutoSelectExtraWaitTimeDelegate { get; set; }

		// Token: 0x17008DE3 RID: 36323
		// (get) Token: 0x06036D0F RID: 224527 RVA: 0x00DE6DE9 File Offset: 0x00DE4FE9
		// (set) Token: 0x06036D10 RID: 224528 RVA: 0x00DE6DF1 File Offset: 0x00DE4FF1
		public Action<int> SelectOptionByIndexDelegate { get; set; }

		// Token: 0x17008DE4 RID: 36324
		// (get) Token: 0x06036D11 RID: 224529 RVA: 0x00DE6DFA File Offset: 0x00DE4FFA
		// (set) Token: 0x06036D12 RID: 224530 RVA: 0x00DE6E02 File Offset: 0x00DE5002
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Action<string, UUITexture> SetTextureByPathDelegate { [return: Nullable(new byte[]
		{
			2,
			1,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1,
			1
		})] set; }

		// Token: 0x17008DE5 RID: 36325
		// (get) Token: 0x06036D13 RID: 224531 RVA: 0x00DE6E0B File Offset: 0x00DE500B
		// (set) Token: 0x06036D14 RID: 224532 RVA: 0x00DE6E13 File Offset: 0x00DE5013
		public Action RefreshAutoPlayButtonDelegate { get; set; }
	}
}
