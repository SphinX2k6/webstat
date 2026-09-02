using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200519F RID: 20895
	public class RoguelikeSettleCurrencyItem : UiPanelBase
	{
		// Token: 0x06035BD2 RID: 220114 RVA: 0x00D82974 File Offset: 0x00D80B74
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035BD3 RID: 220115 RVA: 0x00D82A84 File Offset: 0x00D80C84
		protected override UniTask OnBeforeStartAsync()
		{
			RoguelikeSettleCurrencyItem.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoguelikeSettleCurrencyItem.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035BD4 RID: 220116 RVA: 0x00D82AC7 File Offset: 0x00D80CC7
		protected override void OnBeforeDestroy()
		{
			if (this.ScrollingNumberTool != null)
			{
				this.ScrollingNumberTool.Clear();
				this.ScrollingNumberTool = null;
			}
		}

		// Token: 0x06035BD5 RID: 220117 RVA: 0x00D82AE4 File Offset: 0x00D80CE4
		public void Refresh(int currencyId, int count, int rate)
		{
			this.CurrencyId = currencyId;
			this.Count = count;
			RogueCurrency? rogueCurrencyConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueCurrencyConfig(this.CurrencyId);
			base.SetTextureByPath(rogueCurrencyConfig.Value.Icon, base.GetTexture(0), null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), rogueCurrencyConfig.Value.Title, Array.Empty<object>());
			this.InitCount = (int)Math.Floor((double)((float)count / ((float)rate / 10000f) + 0.5f));
			base.GetText(2).SetText(this.InitCount.ToString(), true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), "Rogue_Result_Bonus", new <>z__ReadOnlySingleElementList<object>((float)rate / 100f));
			UUIItem rootItem = this.RootItem;
			if (rootItem == null)
			{
				return;
			}
			rootItem.SetUIActive(count > 0);
		}

		// Token: 0x06035BD6 RID: 220118 RVA: 0x00D82BD0 File Offset: 0x00D80DD0
		public UniTask StartAnim()
		{
			RoguelikeSettleCurrencyItem.<StartAnim>d__10 <StartAnim>d__;
			<StartAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<StartAnim>d__.<>4__this = this;
			<StartAnim>d__.<>1__state = -1;
			<StartAnim>d__.<>t__builder.Start<RoguelikeSettleCurrencyItem.<StartAnim>d__10>(ref <StartAnim>d__);
			return <StartAnim>d__.<>t__builder.Task;
		}

		// Token: 0x0401ED6F RID: 126319
		public int CurrencyId;

		// Token: 0x0401ED70 RID: 126320
		public int InitCount;

		// Token: 0x0401ED71 RID: 126321
		public int Count;

		// Token: 0x0401ED72 RID: 126322
		[Nullable(2)]
		private ScrollingNumberTool ScrollingNumberTool;

		// Token: 0x0401ED73 RID: 126323
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200B16E RID: 45422
		public static class ERoguelikeSettleCurrencyItemDefine
		{
			// Token: 0x04037061 RID: 225377
			public const int TexIcon = 0;

			// Token: 0x04037062 RID: 225378
			public const int TxtTitle = 1;

			// Token: 0x04037063 RID: 225379
			public const int TxtNum = 2;

			// Token: 0x04037064 RID: 225380
			public const int RateItem = 3;

			// Token: 0x04037065 RID: 225381
			public const int RateSpriteBg = 4;

			// Token: 0x04037066 RID: 225382
			public const int RateText = 5;

			// Token: 0x04037067 RID: 225383
			public const int TxtAddNum = 6;
		}
	}
}
