using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Season
{
	// Token: 0x02004FF7 RID: 20471
	[NullableContext(1)]
	[Nullable(0)]
	public static class SeasonDefine
	{
		// Token: 0x06034C51 RID: 216145 RVA: 0x00D3E584 File Offset: 0x00D3C784
		public static double GetSeasonTimelineValue(ESeason season)
		{
			switch (season)
			{
			case ESeason.Spring:
				return 0.25;
			case ESeason.Summer:
				return 0.5;
			case ESeason.Autumn:
				return 0.75;
			case ESeason.Winter:
				return 0.0;
			default:
				return 0.0;
			}
		}

		// Token: 0x06034C52 RID: 216146 RVA: 0x00D3E5DA File Offset: 0x00D3C7DA
		public static ESeason GetNextSeasonInLoop(ESeason season)
		{
			switch (season)
			{
			case ESeason.Spring:
				return ESeason.Summer;
			case ESeason.Summer:
				return ESeason.Autumn;
			case ESeason.Autumn:
				return ESeason.Winter;
			case ESeason.Winter:
				return ESeason.Spring;
			default:
				return ESeason.Spring;
			}
		}

		// Token: 0x06034C53 RID: 216147 RVA: 0x00D3E600 File Offset: 0x00D3C800
		public static string FormatSeason(ESeason season)
		{
			switch (season)
			{
			case ESeason.Spring:
				return "春";
			case ESeason.Summer:
				return "夏";
			case ESeason.Autumn:
				return "秋";
			case ESeason.Winter:
				return "冬";
			default:
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
				defaultInterpolatedStringHandler.AppendLiteral("未知(");
				defaultInterpolatedStringHandler.AppendFormatted<ESeason>(season);
				defaultInterpolatedStringHandler.AppendLiteral(")");
				return defaultInterpolatedStringHandler.ToStringAndClear();
			}
			}
		}

		// Token: 0x06034C54 RID: 216148 RVA: 0x00D3E66D File Offset: 0x00D3C86D
		public static string GetSeasonAudioName(ESeason season)
		{
			switch (season)
			{
			case ESeason.Spring:
				return "spring";
			case ESeason.Summer:
				return "summer";
			case ESeason.Autumn:
				return "autumn";
			case ESeason.Winter:
				return "winter";
			default:
				return "winter";
			}
		}

		// Token: 0x06034C55 RID: 216149 RVA: 0x00D3E6A4 File Offset: 0x00D3C8A4
		public static string FormatLoopPhase(ESeasonLoopPhase phase)
		{
			if (phase == ESeasonLoopPhase.Hold)
			{
				return "Hold";
			}
			if (phase != ESeasonLoopPhase.Transition)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
				defaultInterpolatedStringHandler.AppendLiteral("未知(");
				defaultInterpolatedStringHandler.AppendFormatted<ESeasonLoopPhase>(phase);
				defaultInterpolatedStringHandler.AppendLiteral(")");
				return defaultInterpolatedStringHandler.ToStringAndClear();
			}
			return "Transition";
		}

		// Token: 0x06034C56 RID: 216150 RVA: 0x00D3E6F8 File Offset: 0x00D3C8F8
		public static string FormatDriverPhase(ESeasonDriverPhase phase)
		{
			switch (phase)
			{
			case ESeasonDriverPhase.Idle:
				return "Idle";
			case ESeasonDriverPhase.Looping:
				return "Looping";
			case ESeasonDriverPhase.Switching:
				return "Switching";
			default:
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
				defaultInterpolatedStringHandler.AppendLiteral("未知(");
				defaultInterpolatedStringHandler.AppendFormatted<ESeasonDriverPhase>(phase);
				defaultInterpolatedStringHandler.AppendLiteral(")");
				return defaultInterpolatedStringHandler.ToStringAndClear();
			}
			}
		}

		// Token: 0x0401E66D RID: 124525
		public const string SeasonMpcPath = "/Game/Aki/Render/Shaders/Scene/Interaction/MPC_SceneInteraction.MPC_SceneInteraction";

		// Token: 0x0401E66E RID: 124526
		public const string SeasonTimelineParamName = "SeasonTransitionTimeLine";

		// Token: 0x0401E66F RID: 124527
		public const string SeasonAudioStateGroup = "game_scene_season";

		// Token: 0x0401E670 RID: 124528
		public const string SeasonAudioRtpc = "season_mpc_value";
	}
}
