using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.UnitTest
{
	// Token: 0x02004459 RID: 17497
	[StaticVariableRuleIgnore]
	public class MultipleRegisterTest : IStaticVariableResetter
	{
		// Token: 0x0602E3D4 RID: 189396 RVA: 0x00ADC84B File Offset: 0x00ADAA4B
		static MultipleRegisterTest()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(MultipleRegisterTest.CreateStaticDefaultValue), new Action(MultipleRegisterTest.ResetStaticDefaultValue));
			StaticVariableRegister.RegisterAndExecute(new Action(MultipleRegisterTest.CreateStaticDefaultValue), new Action(MultipleRegisterTest.ResetStaticDefaultValue));
		}

		// Token: 0x0602E3D5 RID: 189397 RVA: 0x00ADC887 File Offset: 0x00ADAA87
		public static void CreateStaticDefaultValue()
		{
			MultipleRegisterTest.Obj = new TestClass();
		}

		// Token: 0x0602E3D6 RID: 189398 RVA: 0x00ADC893 File Offset: 0x00ADAA93
		public static void ResetStaticDefaultValue()
		{
			MultipleRegisterTest.Obj = null;
		}

		// Token: 0x0401A426 RID: 107558
		[Nullable(2)]
		public static TestClass Obj;
	}
}
