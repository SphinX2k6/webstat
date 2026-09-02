using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.UnitTest
{
	// Token: 0x02004460 RID: 17504
	[StaticVariableRuleIgnore]
	public class IgnoredMemberTest : IStaticVariableResetter
	{
		// Token: 0x0602E3EE RID: 189422 RVA: 0x00ADCAF2 File Offset: 0x00ADACF2
		static IgnoredMemberTest()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(IgnoredMemberTest.CreateStaticDefaultValue), new Action(IgnoredMemberTest.ResetStaticDefaultValue));
		}

		// Token: 0x0602E3EF RID: 189423 RVA: 0x00ADCB1B File Offset: 0x00ADAD1B
		public static void CreateStaticDefaultValue()
		{
			IgnoredMemberTest.ManagedObj = new TestClass();
		}

		// Token: 0x0602E3F0 RID: 189424 RVA: 0x00ADCB27 File Offset: 0x00ADAD27
		public static void ResetStaticDefaultValue()
		{
			IgnoredMemberTest.ManagedObj = null;
		}

		// Token: 0x0401A439 RID: 107577
		[Nullable(2)]
		[StaticVariableRuleIgnore]
		public static TestClass IgnoredObj = new TestClass();

		// Token: 0x0401A43A RID: 107578
		[Nullable(2)]
		public static TestClass ManagedObj;
	}
}
