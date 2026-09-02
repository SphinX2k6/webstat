using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView.PlotComponent
{
	// Token: 0x020053DE RID: 21470
	[NullableContext(2)]
	public interface IPlotAutoSelectOptionComponentContext
	{
		// Token: 0x17008DCC RID: 36300
		// (get) Token: 0x06036CE1 RID: 224481
		// (set) Token: 0x06036CE2 RID: 224482
		UUISliderComponent OptionLimitBar { get; set; }

		// Token: 0x17008DCD RID: 36301
		// (get) Token: 0x06036CE3 RID: 224483
		// (set) Token: 0x06036CE4 RID: 224484
		UUISliderComponent AutoSelectTimeBar { get; set; }

		// Token: 0x17008DCE RID: 36302
		// (get) Token: 0x06036CE5 RID: 224485
		// (set) Token: 0x06036CE6 RID: 224486
		UUIItem ImportantList { get; set; }

		// Token: 0x17008DCF RID: 36303
		// (get) Token: 0x06036CE7 RID: 224487
		// (set) Token: 0x06036CE8 RID: 224488
		UUITexture ImportantOptionTipsIcon { get; set; }

		// Token: 0x17008DD0 RID: 36304
		// (get) Token: 0x06036CE9 RID: 224489
		// (set) Token: 0x06036CEA RID: 224490
		UUIText ImportantOptionTipsText { get; set; }

		// Token: 0x17008DD1 RID: 36305
		// (get) Token: 0x06036CEB RID: 224491
		// (set) Token: 0x06036CEC RID: 224492
		Func<ITalkItem> GetCurrentContentDelegate { get; set; }

		// Token: 0x17008DD2 RID: 36306
		// (get) Token: 0x06036CED RID: 224493
		// (set) Token: 0x06036CEE RID: 224494
		Func<PlotOptionItem> GetSelectedOptionDelegate { get; set; }

		// Token: 0x17008DD3 RID: 36307
		// (get) Token: 0x06036CEF RID: 224495
		// (set) Token: 0x06036CF0 RID: 224496
		[Nullable(new byte[]
		{
			2,
			2,
			1
		})]
		Func<PlotOptionItem[]> GetOptionItemsDelegate { [return: Nullable(new byte[]
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

		// Token: 0x17008DD4 RID: 36308
		// (get) Token: 0x06036CF1 RID: 224497
		// (set) Token: 0x06036CF2 RID: 224498
		Func<float> GetAudioRemainingTimeDelegate { get; set; }

		// Token: 0x17008DD5 RID: 36309
		// (get) Token: 0x06036CF3 RID: 224499
		// (set) Token: 0x06036CF4 RID: 224500
		Func<float> GetAutoSelectExtraWaitTimeDelegate { get; set; }

		// Token: 0x17008DD6 RID: 36310
		// (get) Token: 0x06036CF5 RID: 224501
		// (set) Token: 0x06036CF6 RID: 224502
		Action<int> SelectOptionByIndexDelegate { get; set; }

		// Token: 0x17008DD7 RID: 36311
		// (get) Token: 0x06036CF7 RID: 224503
		// (set) Token: 0x06036CF8 RID: 224504
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		Action<string, UUITexture> SetTextureByPathDelegate { [return: Nullable(new byte[]
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

		// Token: 0x17008DD8 RID: 36312
		// (get) Token: 0x06036CF9 RID: 224505
		// (set) Token: 0x06036CFA RID: 224506
		Action RefreshAutoPlayButtonDelegate { get; set; }
	}
}
