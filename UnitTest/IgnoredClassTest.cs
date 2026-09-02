using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.UnitTest
{
	// Token: 0x0200445F RID: 17503
	[StaticVariableRuleIgnore]
	public class IgnoredClassTest
	{
		// Token: 0x0401A437 RID: 107575
		[Nullable(2)]
		public static TestClass Obj = new TestClass();

		// Token: 0x0401A438 RID: 107576
		public static int IntNonDefault = 999;
	}
}
