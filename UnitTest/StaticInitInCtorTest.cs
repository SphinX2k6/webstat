using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.UnitTest
{
	// Token: 0x02004454 RID: 17492
	[StaticVariableRuleIgnore]
	public class StaticInitInCtorTest : IStaticVariableResetter
	{
		// Token: 0x0602E3C0 RID: 189376 RVA: 0x00ADC786 File Offset: 0x00ADA986
		public StaticInitInCtorTest()
		{
			StaticInitInCtorTest.Obj = new TestClass();
		}

		// Token: 0x0602E3C1 RID: 189377 RVA: 0x00ADC798 File Offset: 0x00ADA998
		public static void CreateStaticDefaultValue()
		{
		}

		// Token: 0x0602E3C2 RID: 189378 RVA: 0x00ADC79A File Offset: 0x00ADA99A
		public static void ResetStaticDefaultValue()
		{
			StaticInitInCtorTest.Obj = null;
		}

		// Token: 0x0401A41F RID: 107551
		[Nullable(2)]
		public static TestClass Obj;
	}
}
