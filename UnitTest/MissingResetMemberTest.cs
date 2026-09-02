using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.UnitTest
{
	// Token: 0x0200445C RID: 17500
	[StaticVariableRuleIgnore]
	public class MissingResetMemberTest : IStaticVariableResetter
	{
		// Token: 0x0602E3E0 RID: 189408 RVA: 0x00ADC917 File Offset: 0x00ADAB17
		static MissingResetMemberTest()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(MissingResetMemberTest.CreateStaticDefaultValue), new Action(MissingResetMemberTest.ResetStaticDefaultValue));
		}

		// Token: 0x0602E3E1 RID: 189409 RVA: 0x00ADC936 File Offset: 0x00ADAB36
		public static void CreateStaticDefaultValue()
		{
			MissingResetMemberTest.Obj = new TestClass();
			MissingResetMemberTest.IntValue = 100;
		}

		// Token: 0x0602E3E2 RID: 189410 RVA: 0x00ADC949 File Offset: 0x00ADAB49
		public static void ResetStaticDefaultValue()
		{
			MissingResetMemberTest.Obj = null;
		}

		// Token: 0x0401A429 RID: 107561
		[Nullable(2)]
		public static TestClass Obj;

		// Token: 0x0401A42A RID: 107562
		public static int IntValue;
	}
}
