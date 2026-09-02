using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x0200569D RID: 22173
	internal static class <RogueResTrialPopView>F29D94ADC41C353A1158DA27AD579C782AE139604B34515B9B14F4E1C6539BDC6__TabTextMap
	{
		// Token: 0x06038755 RID: 231253 RVA: 0x00E4DACF File Offset: 0x00E4BCCF
		[NullableContext(1)]
		public static string GetText(ERogueResTrialType type)
		{
			if (type == ERogueResTrialType.Static)
			{
				return "Rogue_Trial_Role_Resident";
			}
			if (type == ERogueResTrialType.Dynamic)
			{
				return "Rogue_Trial_Role_Limit";
			}
			return "";
		}
	}
}
