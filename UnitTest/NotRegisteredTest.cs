using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.UnitTest
{
	// Token: 0x02004457 RID: 17495
	[StaticVariableRuleIgnore]
	public class NotRegisteredTest : IStaticVariableResetter
	{
		// Token: 0x0602E3C7 RID: 189383 RVA: 0x00ADC7CB File Offset: 0x00ADA9CB
		public static void CreateStaticDefaultValue()
		{
			NotRegisteredTest.Obj = new TestClass();
		}

		// Token: 0x0602E3C8 RID: 189384 RVA: 0x00ADC7D7 File Offset: 0x00ADA9D7
		public static void ResetStaticDefaultValue()
		{
			NotRegisteredTest.Obj = null;
		}

		// Token: 0x0401A422 RID: 107554
		[Nullable(2)]
		public static TestClass Obj;
	}
}
