using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Guide.GroupInfo
{
	// Token: 0x02004A7B RID: 19067
	public class GuideGroupInfoConstants : IStaticVariableResetter
	{
		// Token: 0x06031C44 RID: 203844 RVA: 0x00C7665B File Offset: 0x00C7485B
		static GuideGroupInfoConstants()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(GuideGroupInfoConstants.CreateStaticDefaultValue), new Action(GuideGroupInfoConstants.ResetStaticDefaultValue));
		}

		// Token: 0x06031C45 RID: 203845 RVA: 0x00C7667A File Offset: 0x00C7487A
		public static void CreateStaticDefaultValue()
		{
			GuideGroupInfoConstants.stateDesc = new string[]
			{
				"Init",
				"Opening",
				"Executing",
				"Pending",
				"Finishing"
			};
		}

		// Token: 0x06031C46 RID: 203846 RVA: 0x00C766AF File Offset: 0x00C748AF
		public static void ResetStaticDefaultValue()
		{
			GuideGroupInfoConstants.stateDesc = null;
		}

		// Token: 0x0401D242 RID: 119362
		[Nullable(1)]
		public static string[] stateDesc;
	}
}
