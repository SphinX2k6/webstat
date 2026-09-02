using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Core.Common;

namespace CSharpScript.Game.Module.MusicalInstrument
{
	// Token: 0x020056CD RID: 22221
	[NullableContext(1)]
	[Nullable(0)]
	public class GuqinSubModel : MusicalInstrumentSubModel
	{
		// Token: 0x0603890F RID: 231695 RVA: 0x00E54B4C File Offset: 0x00E52D4C
		public override EInstrumentType GetType()
		{
			return EInstrumentType.ChineseZither;
		}

		// Token: 0x06038910 RID: 231696 RVA: 0x00E54B50 File Offset: 0x00E52D50
		public override void OnRegister()
		{
			MusicalInstrumentConfig? config = ConfigMusicalInstrumentConfigById.GetConfig(800001, true);
			if (config != null)
			{
				GuqinSubModel.KeyConfigsJson keyConfigsJson = Json.Parse<GuqinSubModel.KeyConfigsJson>(config.GetValueOrDefault().KeyConfigs, null);
				List<GuqinSubModel.GridJson> grids = keyConfigsJson.Grids;
				GuqinSubModel.BoardSizeJson boardSize = keyConfigsJson.BoardSize;
				for (int i = 0; i < boardSize.Y; i++)
				{
					List<GuqinKeyConfig> list = new List<GuqinKeyConfig>();
					for (int j = 0; j < boardSize.X; j++)
					{
						GuqinSubModel.GridJson gridJson = grids[i * boardSize.X + j];
						list.Add(new GuqinKeyConfig
						{
							FundamentalToneAudioEvent = Singleton<AudioSystem>.Instance.parseAudioEventPath(gridJson.FundamentalToneAssetPath),
							OverToneAudioEvent = Singleton<AudioSystem>.Instance.parseAudioEventPath(gridJson.OverToneAssetPath),
							KeyIconPath = gridJson.TextureAssetPath
						});
					}
					this.Configs.Add(list);
				}
				return;
			}
			Singleton<global::Log>.Instance.Error(ELogModule.MusicalInstrument, ELogAuthor.CB, "古琴玩法:获取古琴配置失败", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x06038911 RID: 231697 RVA: 0x00E54C58 File Offset: 0x00E52E58
		[NullableContext(2)]
		public unsafe GuqinKeyConfig GetKeyConfig(int rowIndex, int columnIndex)
		{
			if (rowIndex < 0 || rowIndex >= this.Configs.Count || columnIndex < 0 || columnIndex >= this.Configs[rowIndex].Count)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.MusicalInstrument;
				ELogAuthor author = ELogAuthor.CB;
				string message = "古琴玩法:获取古琴按键配置数组越界";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("rowIndex", rowIndex);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("columnIndex", columnIndex);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return null;
			}
			return this.Configs[rowIndex][columnIndex];
		}

		// Token: 0x06038912 RID: 231698 RVA: 0x00E54D03 File Offset: 0x00E52F03
		public override void OnClear()
		{
			this.Configs.Clear();
		}

		// Token: 0x04020468 RID: 132200
		private const int GUQIN_CONFIG_ID = 800001;

		// Token: 0x04020469 RID: 132201
		private readonly List<List<GuqinKeyConfig>> Configs = new List<List<GuqinKeyConfig>>();

		// Token: 0x0200B74C RID: 46924
		[Nullable(0)]
		private class KeyConfigsJson
		{
			// Token: 0x1700A986 RID: 43398
			// (get) Token: 0x0604D1C4 RID: 315844 RVA: 0x0154000A File Offset: 0x0153E20A
			// (set) Token: 0x0604D1C5 RID: 315845 RVA: 0x01540012 File Offset: 0x0153E212
			public List<GuqinSubModel.GridJson> Grids { get; set; } = new List<GuqinSubModel.GridJson>();

			// Token: 0x1700A987 RID: 43399
			// (get) Token: 0x0604D1C6 RID: 315846 RVA: 0x0154001B File Offset: 0x0153E21B
			// (set) Token: 0x0604D1C7 RID: 315847 RVA: 0x01540023 File Offset: 0x0153E223
			public GuqinSubModel.BoardSizeJson BoardSize { get; set; } = new GuqinSubModel.BoardSizeJson();
		}

		// Token: 0x0200B74D RID: 46925
		[Nullable(0)]
		private class GridJson
		{
			// Token: 0x1700A988 RID: 43400
			// (get) Token: 0x0604D1C9 RID: 315849 RVA: 0x0154004A File Offset: 0x0153E24A
			// (set) Token: 0x0604D1CA RID: 315850 RVA: 0x01540052 File Offset: 0x0153E252
			public string FundamentalToneAssetPath { get; set; } = "";

			// Token: 0x1700A989 RID: 43401
			// (get) Token: 0x0604D1CB RID: 315851 RVA: 0x0154005B File Offset: 0x0153E25B
			// (set) Token: 0x0604D1CC RID: 315852 RVA: 0x01540063 File Offset: 0x0153E263
			public string OverToneAssetPath { get; set; } = "";

			// Token: 0x1700A98A RID: 43402
			// (get) Token: 0x0604D1CD RID: 315853 RVA: 0x0154006C File Offset: 0x0153E26C
			// (set) Token: 0x0604D1CE RID: 315854 RVA: 0x01540074 File Offset: 0x0153E274
			public string TextureAssetPath { get; set; } = "";
		}

		// Token: 0x0200B74E RID: 46926
		[NullableContext(0)]
		private class BoardSizeJson
		{
			// Token: 0x1700A98B RID: 43403
			// (get) Token: 0x0604D1D0 RID: 315856 RVA: 0x015400A6 File Offset: 0x0153E2A6
			// (set) Token: 0x0604D1D1 RID: 315857 RVA: 0x015400AE File Offset: 0x0153E2AE
			public int X { get; set; }

			// Token: 0x1700A98C RID: 43404
			// (get) Token: 0x0604D1D2 RID: 315858 RVA: 0x015400B7 File Offset: 0x0153E2B7
			// (set) Token: 0x0604D1D3 RID: 315859 RVA: 0x015400BF File Offset: 0x0153E2BF
			public int Y { get; set; }
		}
	}
}
