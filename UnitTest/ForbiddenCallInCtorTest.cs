using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.UnitTest
{
	// Token: 0x02004455 RID: 17493
	[StaticVariableRuleIgnore]
	public class ForbiddenCallInCtorTest : IStaticVariableResetter
	{
		// Token: 0x0602E3C3 RID: 189379 RVA: 0x00ADC7A2 File Offset: 0x00ADA9A2
		public ForbiddenCallInCtorTest()
		{
			ForbiddenCallInCtorTest.CreateStaticDefaultValue();
		}

		// Token: 0x0602E3C4 RID: 189380 RVA: 0x00ADC7AF File Offset: 0x00ADA9AF
		public static void CreateStaticDefaultValue()
		{
			ForbiddenCallInCtorTest.Obj = new TestClass();
		}

		// Token: 0x0602E3C5 RID: 189381 RVA: 0x00ADC7BB File Offset: 0x00ADA9BB
		public static void ResetStaticDefaultValue()
		{
			ForbiddenCallInCtorTest.Obj = null;
		}

		// Token: 0x0401A420 RID: 107552
		[Nullable(2)]
		public static TestClass Obj;
	}
}
