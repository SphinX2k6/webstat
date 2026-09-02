using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Dango.DangoLogic;
using CSharpScript.Game.Module.RacingBets;
using CSharpScript.Game.Module.RacingBets.Data;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200273E RID: 10046
[Nullable(new byte[]
{
	0,
	1
})]
public class RacingBetsHistoryItem : GridProxyAbstract<RacingBetsLegMatchData>
{
	// Token: 0x06013D3B RID: 81211 RVA: 0x00585768 File Offset: 0x00583968
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(6, new Action(this.OnClickReplayBtn))
		};
	}

	// Token: 0x06013D3C RID: 81212 RVA: 0x0058583D File Offset: 0x00583A3D
	[NullableContext(1)]
	public override void Refresh(RacingBetsLegMatchData data, bool isSelected, int gridIndex)
	{
		this.LegMatchData = data;
		this.UpdateItem();
	}

	// Token: 0x06013D3D RID: 81213 RVA: 0x0058584C File Offset: 0x00583A4C
	private void UpdateItem()
	{
		if (this.LegMatchData == null)
		{
			return;
		}
		bool flag = this.LegMatchData.IsLegMatchFinished();
		int betDangoId = this.LegMatchData.BetDangoId;
		bool flag2 = betDangoId != 0;
		if (flag2)
		{
			DangoConfig instance = ConfigBase<DangoConfig>.Instance;
			Dango? dango = (instance != null) ? instance.GetDangoById(betDangoId) : null;
			string path = ((dango != null) ? dango.GetValueOrDefault().Icon : null) ?? "";
			base.SetTextureByPath(path, base.GetTexture(2), null, null);
			UUITexture texture = base.GetTexture(2);
			if (texture != null)
			{
				texture.SetUIActive(true);
			}
			base.GetText(3).ShowTextNew(((dango != null) ? dango.GetValueOrDefault().Name : null) ?? "");
		}
		else
		{
			UUITexture texture2 = base.GetTexture(2);
			if (texture2 != null)
			{
				texture2.SetUIActive(false);
			}
			base.GetText(3).SetText("-", true);
		}
		base.GetText(0).SetText(Singleton<TimeUtil>.Instance.DateFormat6String(this.LegMatchData.MatchStartTime), true);
		base.GetText(1).ShowTextNew(this.LegMatchData.Name);
		if (flag && flag2)
		{
			UUIText text = base.GetText(4);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.LegMatchData.GetBetDangoRank());
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			UUIText text2 = base.GetText(5);
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.LegMatchData.OddsReward);
			text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}
		else
		{
			base.GetText(4).SetText("-", true);
			base.GetText(5).SetText("-", true);
		}
		base.GetButton(6).RootUIComp.Get().SetUIActive(flag);
	}

	// Token: 0x06013D3E RID: 81214 RVA: 0x00585A2C File Offset: 0x00583C2C
	private void OnClickReplayBtn()
	{
		if (this.LegMatchData == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.RacingBets, ELogAuthor.LRC, "投注历史界面 item LegMatchData undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		RacingBetsSeasonData racingBetsSeasonData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData();
		if (racingBetsSeasonData == null)
		{
			return;
		}
		ControllerBase<RacingBetsController>.Instance.RacingBetMatchActionRequest(racingBetsSeasonData.Id, this.LegMatchData.Id);
	}

	// Token: 0x04009A3C RID: 39484
	[Nullable(2)]
	private RacingBetsLegMatchData LegMatchData;

	// Token: 0x02008AF8 RID: 35576
	private class EItemComponents
	{
		// Token: 0x0402EDDB RID: 191963
		public const int DateText = 0;

		// Token: 0x0402EDDC RID: 191964
		public const int LegNameText = 1;

		// Token: 0x0402EDDD RID: 191965
		public const int DangoTexture = 2;

		// Token: 0x0402EDDE RID: 191966
		public const int DangoName = 3;

		// Token: 0x0402EDDF RID: 191967
		public const int RankText = 4;

		// Token: 0x0402EDE0 RID: 191968
		public const int EarnText = 5;

		// Token: 0x0402EDE1 RID: 191969
		public const int ReplayButton = 6;
	}
}
