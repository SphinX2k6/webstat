using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x0200569C RID: 22172
	internal static class <RogueResTrialPopView>F29D94ADC41C353A1158DA27AD579C782AE139604B34515B9B14F4E1C6539BDC6__TxtColorMap
	{
		// Token: 0x06038754 RID: 231252 RVA: 0x00E4DAB5 File Offset: 0x00E4BCB5
		[NullableContext(1)]
		public static string GetColor(ERogueResTrialType type)
		{
			if (type == ERogueResTrialType.Static)
			{
				return "#f4f0e5";
			}
			if (type == ERogueResTrialType.Dynamic)
			{
				return "#FFFFFF";
			}
			return "#f4f0e5";
		}
	}
}
