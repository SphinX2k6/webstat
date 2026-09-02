using System;
using Aki.Config;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EB1 RID: 24241
	public class CiacconaGalUtils
	{
		// Token: 0x0603CECD RID: 249549 RVA: 0x00F7A180 File Offset: 0x00F78380
		public static float GetAvgSkippingTime()
		{
			return ConfigCommonParamById.GetFloatConfig("CiacconaAvgSkippingTime").GetValueOrDefault(1f);
		}

		// Token: 0x0603CECE RID: 249550 RVA: 0x00F7A1A4 File Offset: 0x00F783A4
		public static float GetAvgCoolDownTime()
		{
			return ConfigCommonParamById.GetFloatConfig("CiacconaAvgCoolDownTime").GetValueOrDefault(1f);
		}

		// Token: 0x0603CECF RID: 249551 RVA: 0x00F7A1C8 File Offset: 0x00F783C8
		public static float GetAvgTextAnimShortenTime()
		{
			return ConfigCommonParamById.GetFloatConfig("CiacconaAvgTextAnimShortenTime").GetValueOrDefault(1f);
		}

		// Token: 0x0603CED0 RID: 249552 RVA: 0x00F7A1EC File Offset: 0x00F783EC
		public static float GetAvgSubEndingDelayTime()
		{
			return ConfigCommonParamById.GetFloatConfig("CiacconaAvgSubEndingDelay").GetValueOrDefault(1f);
		}

		// Token: 0x0603CED1 RID: 249553 RVA: 0x00F7A210 File Offset: 0x00F78410
		public static float GetAvgChoiceProtectingTime()
		{
			return ConfigCommonParamById.GetFloatConfig("CiacconaAvgChoiceProtectingTime").GetValueOrDefault(1f);
		}
	}
}
