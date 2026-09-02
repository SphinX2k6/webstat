using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.UnitTest
{
	// Token: 0x02004452 RID: 17490
	[NullableContext(1)]
	[Nullable(0)]
	[StaticVariableRuleIgnore]
	public static class ValueTypeMemberWithoutResetterTest
	{
		// Token: 0x0401A416 RID: 107542
		private static int IntNonDefault = 1;

		// Token: 0x0401A417 RID: 107543
		private static bool BoolNonDefault = true;

		// Token: 0x0401A418 RID: 107544
		private static string StringNonDefault = "hello";

		// Token: 0x0401A419 RID: 107545
		private static int IntConfig = GameplayTagDefine.EGameplayTagId["test"];

		// Token: 0x0401A41A RID: 107546
		private static int IntDefault = 0;

		// Token: 0x0401A41B RID: 107547
		private static bool BoolNoInit;

		// Token: 0x0401A41C RID: 107548
		private static string StringEmpty = string.Empty;

		// Token: 0x0401A41D RID: 107549
		private static int? NullableIntNull = null;
	}
}
