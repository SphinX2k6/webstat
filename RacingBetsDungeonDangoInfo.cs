using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Dango.DangoLogic;
using CSharpScript.Game.Module.RacingBets;
using CSharpScript.Game.Module.RacingBets.Data;

// Token: 0x020026E5 RID: 9957
[NullableContext(1)]
[Nullable(0)]
public class RacingBetsDungeonDangoInfo
{
	// Token: 0x06013A50 RID: 80464 RVA: 0x00579FAC File Offset: 0x005781AC
	public RacingBetsDungeonDangoInfo(RacingBetsInstanceDangoInfo message)
	{
		this.DangoId = message.DangoId;
		this.CurPoint = message.CurPoint;
		this.DiceId = message.DiceId;
		this.High = message.High;
		this.EntityId = Singleton<MathUtils>.Instance.LongToNumber(message.EntityId);
		this.BpId = message.BpId;
	}

	// Token: 0x06013A51 RID: 80465 RVA: 0x0057A014 File Offset: 0x00578214
	public int RealPoint()
	{
		RacingBetsSeasonData racingBetsSeasonData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData();
		int? num = (racingBetsSeasonData != null) ? new int?(racingBetsSeasonData.Id) : null;
		if (num == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.RacingBets, ELogAuthor.LRC, "无法获取当前赛季ID", default(ReadOnlySpan<ValueTuple<string, object>>));
			return 0;
		}
		RacingBetsConfig instance = ConfigBase<RacingBetsConfig>.Instance;
		int num2 = (instance != null) ? instance.GetPointTotal(num.Value) : 0;
		return ((this.CurPoint - 1) % num2 + num2) % num2 + 1;
	}

	// Token: 0x06013A52 RID: 80466 RVA: 0x0057A098 File Offset: 0x00578298
	public Dice? GetDiceConfig()
	{
		DangoConfig instance = ConfigBase<DangoConfig>.Instance;
		if (instance == null)
		{
			return null;
		}
		return instance.GetDiceById(this.DiceId);
	}

	// Token: 0x06013A53 RID: 80467 RVA: 0x0057A0C4 File Offset: 0x005782C4
	public string GetDiceIcon(int diceNum)
	{
		Dice? diceConfig = this.GetDiceConfig();
		if (diceConfig == null)
		{
			return "";
		}
		switch (diceNum)
		{
		case 1:
			return diceConfig.Value.DicePointOneIcon;
		case 2:
			return diceConfig.Value.DicePointTwoIcon;
		case 3:
			return diceConfig.Value.DicePointThreeIcon;
		case 4:
			return diceConfig.Value.DicePointFourIcon;
		case 5:
			return diceConfig.Value.DicePointFiveIcon;
		case 6:
			return diceConfig.Value.DicePointSixIcon;
		default:
			return "";
		}
	}

	// Token: 0x06013A54 RID: 80468 RVA: 0x0057A170 File Offset: 0x00578370
	public bool IsHalfPass()
	{
		RacingBetsSeasonData racingBetsSeasonData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData();
		int? num = (racingBetsSeasonData != null) ? new int?(racingBetsSeasonData.Id) : null;
		if (num == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.RacingBets, ELogAuthor.LRC, "无法获取当前赛季ID", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		RacingBetsConfig instance = ConfigBase<RacingBetsConfig>.Instance;
		int num2 = (instance != null) ? instance.GetPointTotal(num.Value) : 0;
		return this.CurPoint >= num2 / 2;
	}

	// Token: 0x06013A55 RID: 80469 RVA: 0x0057A1F4 File Offset: 0x005783F4
	public bool IsAbuDango()
	{
		DangoConfig instance = ConfigBase<DangoConfig>.Instance;
		Dango? dango = (instance != null) ? instance.GetDangoById(this.DangoId) : null;
		return dango != null && dango.GetValueOrDefault().Type == 1;
	}

	// Token: 0x040098CB RID: 39115
	public readonly int DangoId;

	// Token: 0x040098CC RID: 39116
	public readonly int DiceId;

	// Token: 0x040098CD RID: 39117
	public readonly long EntityId;

	// Token: 0x040098CE RID: 39118
	public readonly int BpId;

	// Token: 0x040098CF RID: 39119
	public int CurPoint;

	// Token: 0x040098D0 RID: 39120
	public int High;

	// Token: 0x040098D1 RID: 39121
	public int Rank;

	// Token: 0x040098D2 RID: 39122
	public int LastRank;
}
