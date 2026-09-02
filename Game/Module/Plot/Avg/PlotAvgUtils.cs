using System;
using Aki.Config;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Plot.Avg
{
	// Token: 0x0200544C RID: 21580
	public class PlotAvgUtils
	{
		// Token: 0x06037009 RID: 225289 RVA: 0x00DF60D2 File Offset: 0x00DF42D2
		public static EPlotAvgCharacterSpineDirection GetSpineDirectionByPosition(EAvgRolePosition position)
		{
			if (position <= EAvgRolePosition.Left2)
			{
				return EPlotAvgCharacterSpineDirection.Right;
			}
			if (position - EAvgRolePosition.Right1 > 1)
			{
				return EPlotAvgCharacterSpineDirection.Left;
			}
			return EPlotAvgCharacterSpineDirection.Left;
		}

		// Token: 0x0603700A RID: 225290 RVA: 0x00DF60E8 File Offset: 0x00DF42E8
		public static AvgTalkerConfig? GetAvgTalkerConfigByTalkerId(int talkerId)
		{
			if (talkerId == 750088)
			{
				LoginDefine.ELoginSex sex = (LoginDefine.ELoginSex)ModelBase<WorldLevelModel>.Instance.Sex;
				if (sex == LoginDefine.ELoginSex.Girl)
				{
					return ConfigAvgTalkerConfigById.GetConfig(850002, true);
				}
				if (sex == LoginDefine.ELoginSex.Boy)
				{
					return ConfigAvgTalkerConfigById.GetConfig(850001, true);
				}
			}
			Speaker? config = ConfigSpeakerById.GetConfig(talkerId, true);
			if (config == null)
			{
				return null;
			}
			int avgTalkerConfig = config.Value.AvgTalkerConfig;
			if (avgTalkerConfig == 0)
			{
				return null;
			}
			return ConfigAvgTalkerConfigById.GetConfig(avgTalkerConfig, true);
		}

		// Token: 0x0603700B RID: 225291 RVA: 0x00DF616C File Offset: 0x00DF436C
		public static int GetAvgTalkerIdBySpeakerId(int speakerId)
		{
			Speaker? config = ConfigSpeakerById.GetConfig(speakerId, true);
			if (config == null)
			{
				return 0;
			}
			return config.Value.AvgTalkerConfig;
		}
	}
}
