using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Guide.StepInfo
{
	// Token: 0x02004A72 RID: 19058
	public class GuideStepInfoConstants
	{
		// Token: 0x0401D229 RID: 119337
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		public static string[] StateDesc = new string[]
		{
			"Init",
			"Executing",
			"Pending",
			"Break",
			"Finish",
			"End"
		};

		// Token: 0x0401D22A RID: 119338
		public const int GUARANTEED_TIME = 30000;

		// Token: 0x0401D22B RID: 119339
		public const int OFFSET_TIME = 2000;
	}
}
