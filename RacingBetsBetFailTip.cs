using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.RacingBets;
using CSharpScript.Game.Module.RacingBets.Data;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200272F RID: 10031
public class RacingBetsBetFailTip : UiViewBase
{
	// Token: 0x06013C96 RID: 81046 RVA: 0x00581A36 File Offset: 0x0057FC36
	[NullableContext(1)]
	public RacingBetsBetFailTip(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06013C97 RID: 81047 RVA: 0x00581A40 File Offset: 0x0057FC40
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIArtText)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUITexture)),
			new ValueTuple<int, Type>(8, typeof(UUIArtText)),
			new ValueTuple<int, Type>(9, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickConfirmButton)),
			new ValueTuple<int, Delegate>(6, new Action(this.OnClickReplayButton))
		};
	}

	// Token: 0x06013C98 RID: 81048 RVA: 0x00581B70 File Offset: 0x0057FD70
	protected override UniTask OnBeforeStartAsync()
	{
		RacingBetsBetFailTip.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RacingBetsBetFailTip.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013C99 RID: 81049 RVA: 0x00581BB4 File Offset: 0x0057FDB4
	protected override void OnBeforeShow()
	{
		RacingBetLegMatchResultNotify racingBetLegMatchResultNotify = this.OpenParam as RacingBetLegMatchResultNotify;
		if (racingBetLegMatchResultNotify == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.RacingBets, ELogAuthor.BB, "RacingBetsFailTip OnBeforeShow matchResult is undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		RacingBetsSeasonData racingBetsSeasonData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData();
		if (racingBetsSeasonData == null)
		{
			return;
		}
		RacingBetsLegMatchData legMatchData = racingBetsSeasonData.GetLegMatchData(racingBetLegMatchResultNotify.LegMatchId);
		this.LegMatchId = racingBetLegMatchResultNotify.LegMatchId;
		UUIArtText artText = base.GetArtText(0);
		if (artText != null)
		{
			artText.SetText(racingBetLegMatchResultNotify.BetDangoRank.ToString());
		}
		int racingBetConversionRate = ConfigBase<RacingBetsConfig>.Instance.GetRacingBetConversionRate(racingBetLegMatchResultNotify.BetDangoRank);
		int currencyItemId = racingBetsSeasonData.GetCurrencyItemId();
		InventoryConfig instance = ConfigBase<InventoryConfig>.Instance;
		ItemConfig itemConfig = (instance != null) ? instance.GetItemConfigData(currencyItemId) : null;
		if (itemConfig != null)
		{
			base.SetTextureShowUntilLoaded(itemConfig.Icon, base.GetTexture(3), null);
		}
		UUIText text = base.GetText(2);
		if (text != null)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(racingBetLegMatchResultNotify.BetCount);
			defaultInterpolatedStringHandler.AppendLiteral(" x ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(racingBetConversionRate / 100);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}
		RacingBetsCostItem betRewardItem = this.BetRewardItem;
		if (betRewardItem != null)
		{
			betRewardItem.RefreshUi(currencyItemId, racingBetLegMatchResultNotify.Reward);
		}
		DangoData dangoData = Singleton<DangoManager>.Instance.GetDangoData(racingBetLegMatchResultNotify.BetDangoId);
		DangoData dangoData2 = Singleton<DangoManager>.Instance.GetDangoData(racingBetLegMatchResultNotify.WinnerDangoId);
		base.SetTextureShowUntilLoaded(dangoData2.IconAttack, base.GetTexture(7), null);
		base.SetTextureShowUntilLoaded(dangoData.IconDamageLarge, base.GetTexture(1), null);
		UUIText text2 = base.GetText(9);
		if (text2 == null)
		{
			return;
		}
		text2.ShowTextNew(((legMatchData != null) ? legMatchData.Name : null) ?? "");
	}

	// Token: 0x06013C9A RID: 81050 RVA: 0x00581D56 File Offset: 0x0057FF56
	private void OnClickConfirmButton()
	{
		base.CloseMe(null);
	}

	// Token: 0x06013C9B RID: 81051 RVA: 0x00581D60 File Offset: 0x0057FF60
	private void OnClickReplayButton()
	{
		RacingBetsSeasonData racingBetsSeasonData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData();
		if (racingBetsSeasonData == null)
		{
			return;
		}
		if (racingBetsSeasonData.GetLegMatchData(this.LegMatchId) == null)
		{
			return;
		}
		ControllerBase<RacingBetsController>.Instance.RacingBetMatchActionRequest(racingBetsSeasonData.Id, this.LegMatchId);
		base.CloseMe(null);
	}

	// Token: 0x04009A07 RID: 39431
	private int LegMatchId;

	// Token: 0x04009A08 RID: 39432
	[Nullable(2)]
	private RacingBetsCostItem BetRewardItem;

	// Token: 0x02008AD9 RID: 35545
	private enum EComponent
	{
		// Token: 0x0402ED05 RID: 191749
		RankText,
		// Token: 0x0402ED06 RID: 191750
		DangoIcon,
		// Token: 0x0402ED07 RID: 191751
		CostResultText,
		// Token: 0x0402ED08 RID: 191752
		CurrencyIcon,
		// Token: 0x0402ED09 RID: 191753
		BetRewardItem,
		// Token: 0x0402ED0A RID: 191754
		ConfirmButton,
		// Token: 0x0402ED0B RID: 191755
		ReplayButton,
		// Token: 0x0402ED0C RID: 191756
		WinnerDangoIcon,
		// Token: 0x0402ED0D RID: 191757
		WinnerDangoText,
		// Token: 0x0402ED0E RID: 191758
		MatchNameText
	}
}
