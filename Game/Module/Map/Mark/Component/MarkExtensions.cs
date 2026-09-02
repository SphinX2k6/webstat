using System;
using Aki.Config;

namespace CSharpScript.Game.Module.Map.Mark.Component
{
	// Token: 0x02005829 RID: 22569
	public static class MarkExtensions
	{
		// Token: 0x060395EC RID: 234988 RVA: 0x00E908A0 File Offset: 0x00E8EAA0
		public static int? TrackHudEnable(this OneOf<MapMark, DynamicMapMark, TreasureBoxDetectorMark> Config)
		{
			if (!Config.HasValue)
			{
				return null;
			}
			if (Config.IsT1)
			{
				return new int?(Config.AsT1.TrackHudEnable);
			}
			if (Config.IsT2)
			{
				return new int?(Config.AsT2.TrackHudEnable);
			}
			if (Config.IsT3)
			{
				return new int?(Config.AsT3.TrackHudEnable);
			}
			return null;
		}

		// Token: 0x060395ED RID: 234989 RVA: 0x00E90924 File Offset: 0x00E8EB24
		public static float? TrackAutoCancelDistance(this OneOf<MapMark, DynamicMapMark, TreasureBoxDetectorMark> Config)
		{
			if (!Config.HasValue)
			{
				return null;
			}
			if (Config.IsT1)
			{
				return new float?(Config.AsT1.TrackAutoCancelDistance);
			}
			if (Config.IsT2)
			{
				return new float?(Config.AsT2.TrackAutoCancelDistance);
			}
			if (Config.IsT3)
			{
				return new float?(Config.AsT3.TrackAutoCancelDistance);
			}
			return null;
		}
	}
}
