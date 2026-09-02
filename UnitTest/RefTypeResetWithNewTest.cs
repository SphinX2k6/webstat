using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.UnitTest
{
	// Token: 0x0200445B RID: 17499
	[StaticVariableRuleIgnore]
	public class RefTypeResetWithNewTest : IStaticVariableResetter
	{
		// Token: 0x0602E3DC RID: 189404 RVA: 0x00ADC8D8 File Offset: 0x00ADAAD8
		static RefTypeResetWithNewTest()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(RefTypeResetWithNewTest.CreateStaticDefaultValue), new Action(RefTypeResetWithNewTest.ResetStaticDefaultValue));
		}

		// Token: 0x0602E3DD RID: 189405 RVA: 0x00ADC8F7 File Offset: 0x00ADAAF7
		public static void CreateStaticDefaultValue()
		{
			RefTypeResetWithNewTest.Obj = new TestClass();
		}

		// Token: 0x0602E3DE RID: 189406 RVA: 0x00ADC903 File Offset: 0x00ADAB03
		public static void ResetStaticDefaultValue()
		{
			RefTypeResetWithNewTest.Obj = new TestClass();
		}

		// Token: 0x0401A428 RID: 107560
		[Nullable(2)]
		public static TestClass Obj;
	}
}
