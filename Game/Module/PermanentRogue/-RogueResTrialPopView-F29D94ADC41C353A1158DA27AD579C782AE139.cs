using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x0200569B RID: 22171
	internal static class <RogueResTrialPopView>F29D94ADC41C353A1158DA27AD579C782AE139604B34515B9B14F4E1C6539BDC6__TabColorMap
	{
		// Token: 0x06038753 RID: 231251 RVA: 0x00E4DA9B File Offset: 0x00E4BC9B
		[NullableContext(1)]
		public static string GetColor(ERogueResTrialType type)
		{
			if (type == ERogueResTrialType.Static)
			{
				return "#323232";
			}
			if (type == ERogueResTrialType.Dynamic)
			{
				return "#ab9664";
			}
			return "#323232";
		}
	}
}
