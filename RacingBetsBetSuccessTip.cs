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

// Token: 0x02002730 RID: 10032
public class RacingBetsBetSuccessTip : UiViewBase
{
	// Token: 0x06013C9D RID: 81053 RVA: 0x00581DB0 File Offset: 0x0057FFB0
	[NullableContext(1)]
	public RacingBetsBetSuccessTip(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06013C9E RID: 81054 RVA: 0x00581DBC File Offset: 0x0057FFBC
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
			new ValueTuple<int, Type>(7, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickConfirmButton)),
			new ValueTuple<int, Delegate>(6, new Action(this.OnClickReplayButton))
		};
	}

	// Token: 0x06013C9F RID: 81055 RVA: 0x00581EC0 File Offset: 0x005800C0
	protected override UniTask OnBeforeStartAsync()
	{
		RacingBetsBetSuccessTip.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RacingBetsBetSuccessTip.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013CA0 RID: 81056 RVA: 0x00581F04 File Offset: 0x00580104
	protected override void OnBeforeShow()
	{
		RacingBetLegMatchResultNotify racingBetLegMatchResultNotify = this.OpenParam as RacingBetLegMatchResultNotify;
		if (racingBetLegMatchResultNotify == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.RacingBets, ELogAuthor.BB, "RacingBetsSuccessTip OnBeforeShow matchResult is undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
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
		DangoData dangoData = Singleton<DangoManager>.Instance.GetDangoData(racingBetLegMatchResultNotify.BetDangoId);
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
			defaultInterpolatedStringHandler.AppendFormatted<int>(racingBetLegMatchResultNotify.Odds / 100);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}
		RacingBetsCostItem betRewardItem = this.BetRewardItem;
		if (betRewardItem != null)
		{
			betRewardItem.RefreshUi(currencyItemId, racingBetLegMatchResultNotify.Reward);
		}
		base.SetTextureShowUntilLoaded(dangoData.IconAttackLarge, base.GetTexture(1), null);
		UUIText text2 = base.GetText(7);
		if (text2 == null)
		{
			return;
		}
		text2.ShowTextNew(((legMatchData != null) ? legMatchData.Name : null) ?? "");
	}

	// Token: 0x06013CA1 RID: 81057 RVA: 0x00582070 File Offset: 0x00580270
	private void OnClickConfirmButton()
	{
		base.CloseMe(null);
	}

	// Token: 0x06013CA2 RID: 81058 RVA: 0x0058207C File Offset: 0x0058027C
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

	// Token: 0x04009A09 RID: 39433
	private int LegMatchId;

	// Token: 0x04009A0A RID: 39434
	[Nullable(2)]
	private RacingBetsCostItem BetRewardItem;

	// Token: 0x02008ADB RID: 35547
	private enum EComponent
	{
		// Token: 0x0402ED14 RID: 191764
		RankText,
		// Token: 0x0402ED15 RID: 191765
		DangoIcon,
		// Token: 0x0402ED16 RID: 191766
		CostResultText,
		// Token: 0x0402ED17 RID: 191767
		CurrencyIcon,
		// Token: 0x0402ED18 RID: 191768
		BetRewardItem,
		// Token: 0x0402ED19 RID: 191769
		ConfirmButton,
		// Token: 0x0402ED1A RID: 191770
		ReplayButton,
		// Token: 0x0402ED1B RID: 191771
		MatchNameText
	}
}
