using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x020026CD RID: 9933
[NullableContext(1)]
[Nullable(0)]
public static class DangoDungeonCommandFactory
{
	// Token: 0x060139AA RID: 80298 RVA: 0x00578885 File Offset: 0x00576A85
	public static RacingBetsCommandBase CreateRacingBetsInitDungeonCommand(List<RacingBetsDungeonDangoInfo> dangoInfoList, IReadOnlyList<RacingBetMapPoint> mapPointList, int seasonId)
	{
		RacingBetsInitDungeonCommand racingBetsInitDungeonCommand = new RacingBetsInitDungeonCommand();
		racingBetsInitDungeonCommand.Init(dangoInfoList, mapPointList, seasonId);
		return racingBetsInitDungeonCommand;
	}

	// Token: 0x060139AB RID: 80299 RVA: 0x00578895 File Offset: 0x00576A95
	public static RacingBetsCommandBase CreateOpenRacingBetsGameplayView()
	{
		return new OpenRacingBetsGamePlayViewCommand();
	}

	// Token: 0x060139AC RID: 80300 RVA: 0x0057889C File Offset: 0x00576A9C
	public static RacingBetsCommandBase CreateOpenRacingBetsGamePlayPreviewView(bool canCameraInput = false)
	{
		OpenRacingBetsGamePlayPreviewViewCommand openRacingBetsGamePlayPreviewViewCommand = new OpenRacingBetsGamePlayPreviewViewCommand();
		openRacingBetsGamePlayPreviewViewCommand.Init(canCameraInput);
		return openRacingBetsGamePlayPreviewViewCommand;
	}

	// Token: 0x060139AD RID: 80301 RVA: 0x005788AA File Offset: 0x00576AAA
	public static RacingBetsCommandBase CreateRacingBetsDungeonBeginCommand()
	{
		return new RacingBetsDungeonBeginCommand();
	}

	// Token: 0x060139AE RID: 80302 RVA: 0x005788B1 File Offset: 0x00576AB1
	public static RacingBetsCommandBase CreateRacingBetsRoundStartCommand()
	{
		return new RacingBetsRoundStartCommand();
	}

	// Token: 0x060139AF RID: 80303 RVA: 0x005788B8 File Offset: 0x00576AB8
	public static RacingBetsDangoRoundStartCommand CreateRacingBetsDangoRoundStartCommand(int dangoId)
	{
		RacingBetsDangoRoundStartCommand racingBetsDangoRoundStartCommand = new RacingBetsDangoRoundStartCommand();
		racingBetsDangoRoundStartCommand.Init(dangoId);
		return racingBetsDangoRoundStartCommand;
	}

	// Token: 0x060139B0 RID: 80304 RVA: 0x005788C6 File Offset: 0x00576AC6
	public static RacingBetsCommandBase CreateRacingBetsDiceCommand(int round, List<DangoIdToDiceNum> dangoDiceList)
	{
		RacingBetsDiceCommand racingBetsDiceCommand = new RacingBetsDiceCommand();
		racingBetsDiceCommand.Init(round, dangoDiceList);
		return racingBetsDiceCommand;
	}

	// Token: 0x060139B1 RID: 80305 RVA: 0x005788D5 File Offset: 0x00576AD5
	public static RacingBetsCommandBase CreateRacingBetsSkillCommand(RacingBetsDangoActionSkill skillAction)
	{
		RacingBetsSkillCommand racingBetsSkillCommand = new RacingBetsSkillCommand();
		racingBetsSkillCommand.Init(skillAction);
		return racingBetsSkillCommand;
	}

	// Token: 0x060139B2 RID: 80306 RVA: 0x005788E3 File Offset: 0x00576AE3
	public static RacingBetsCommandBase CreateRacingBetsDangoMoveCommand(RacingBetsDangoActionMove moveAction)
	{
		RacingBetsDangoMoveCommand racingBetsDangoMoveCommand = new RacingBetsDangoMoveCommand();
		racingBetsDangoMoveCommand.Init(moveAction);
		return racingBetsDangoMoveCommand;
	}

	// Token: 0x060139B3 RID: 80307 RVA: 0x005788F1 File Offset: 0x00576AF1
	public static RacingBetsCommandBase CreateRacingBetsDangoChangeHighCommand(RacingBetsDangoActionChangeHigh changeHighAction)
	{
		RacingBetsDangoChangeHighCommand racingBetsDangoChangeHighCommand = new RacingBetsDangoChangeHighCommand();
		racingBetsDangoChangeHighCommand.Init(changeHighAction);
		return racingBetsDangoChangeHighCommand;
	}

	// Token: 0x060139B4 RID: 80308 RVA: 0x005788FF File Offset: 0x00576AFF
	public static RacingBetsCommandBase CreateRacingBetsChangeDangoCameraBlendCommand(int dangoId)
	{
		RacingBetsChangeDangoCameraBlendCommand racingBetsChangeDangoCameraBlendCommand = new RacingBetsChangeDangoCameraBlendCommand();
		racingBetsChangeDangoCameraBlendCommand.SetDangoId(dangoId);
		return racingBetsChangeDangoCameraBlendCommand;
	}

	// Token: 0x060139B5 RID: 80309 RVA: 0x0057890D File Offset: 0x00576B0D
	public static RacingBetsNextRoundRequestCommand CreateRacingBetsNextRoundRequestCommand(int activityId, int legMatchId, int roundId)
	{
		RacingBetsNextRoundRequestCommand racingBetsNextRoundRequestCommand = new RacingBetsNextRoundRequestCommand();
		racingBetsNextRoundRequestCommand.Init(activityId, legMatchId, roundId);
		return racingBetsNextRoundRequestCommand;
	}

	// Token: 0x060139B6 RID: 80310 RVA: 0x0057891D File Offset: 0x00576B1D
	public static OpenRacingBetsDungeonResultViewCommand CreateOpenRacingBetsDungeonResultView(RacingBetsLegMatchData legMatchData)
	{
		OpenRacingBetsDungeonResultViewCommand openRacingBetsDungeonResultViewCommand = new OpenRacingBetsDungeonResultViewCommand();
		openRacingBetsDungeonResultViewCommand.Init(legMatchData);
		return openRacingBetsDungeonResultViewCommand;
	}

	// Token: 0x060139B7 RID: 80311 RVA: 0x0057892B File Offset: 0x00576B2B
	public static RacingBetsDangoDestinationCommand CreateRacingBetsDangoDestinationCommand(int dangoId)
	{
		RacingBetsDangoDestinationCommand racingBetsDangoDestinationCommand = new RacingBetsDangoDestinationCommand();
		racingBetsDangoDestinationCommand.Init(dangoId);
		return racingBetsDangoDestinationCommand;
	}

	// Token: 0x060139B8 RID: 80312 RVA: 0x00578939 File Offset: 0x00576B39
	public static RacingBetsDangoRankChangeCommand CreateRacingBetsDangoRankChangeCommand(List<int> rankList)
	{
		RacingBetsDangoRankChangeCommand racingBetsDangoRankChangeCommand = new RacingBetsDangoRankChangeCommand();
		racingBetsDangoRankChangeCommand.Init(rankList);
		return racingBetsDangoRankChangeCommand;
	}

	// Token: 0x060139B9 RID: 80313 RVA: 0x00578947 File Offset: 0x00576B47
	public static RacingBetsCommandBase CreateRacingBetsDangoTransmitCommand(RacingBetsDangoActionTransmit transmitAction)
	{
		RacingBetsDangoTransmitCommand racingBetsDangoTransmitCommand = new RacingBetsDangoTransmitCommand();
		racingBetsDangoTransmitCommand.Init(transmitAction);
		return racingBetsDangoTransmitCommand;
	}

	// Token: 0x060139BA RID: 80314 RVA: 0x00578955 File Offset: 0x00576B55
	public static RacingBetsCommandBase CreateRacingBetsBlackHoleTransmitCommand(RacingBetsDangoActionBlackHoleTransmit transmitAction)
	{
		RacingBetsBlackHoleTransmitCommand racingBetsBlackHoleTransmitCommand = new RacingBetsBlackHoleTransmitCommand();
		racingBetsBlackHoleTransmitCommand.Init(transmitAction);
		return racingBetsBlackHoleTransmitCommand;
	}

	// Token: 0x060139BB RID: 80315 RVA: 0x00578963 File Offset: 0x00576B63
	public static RacingBetsCommandBase CreateRacingBetsOrganEffectCommand(RacingBetsOrganEffect organEffectAction)
	{
		RacingBetsOrganEffectCommand racingBetsOrganEffectCommand = new RacingBetsOrganEffectCommand();
		racingBetsOrganEffectCommand.Init(organEffectAction);
		return racingBetsOrganEffectCommand;
	}
}
