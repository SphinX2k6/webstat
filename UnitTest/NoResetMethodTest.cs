using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.UnitTest
{
	// Token: 0x0200445A RID: 17498
	[StaticVariableRuleIgnore]
	public class NoResetMethodTest : IStaticVariableResetter
	{
		// Token: 0x0602E3D8 RID: 189400 RVA: 0x00ADC8A3 File Offset: 0x00ADAAA3
		static NoResetMethodTest()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(NoResetMethodTest.CreateStaticDefaultValue), new Action(NoResetMethodTest.ResetStaticDefaultValue));
		}

		// Token: 0x0602E3D9 RID: 189401 RVA: 0x00ADC8C2 File Offset: 0x00ADAAC2
		public static void CreateStaticDefaultValue()
		{
			NoResetMethodTest.Obj = new TestClass();
		}

		// Token: 0x0602E3DA RID: 189402 RVA: 0x00ADC8CE File Offset: 0x00ADAACE
		public static void ResetStaticDefaultValue()
		{
		}

		// Token: 0x0401A427 RID: 107559
		[Nullable(2)]
		public static TestClass Obj;
	}
}
