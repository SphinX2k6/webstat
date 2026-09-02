using System;

namespace CSharpScript.UnitTest
{
	// Token: 0x02004461 RID: 17505
	[StaticVariableRuleIgnore]
	public class PropertyTest : IStaticVariableResetter
	{
		// Token: 0x0602E3F2 RID: 189426 RVA: 0x00ADCB37 File Offset: 0x00ADAD37
		static PropertyTest()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(PropertyTest.CreateStaticDefaultValue), new Action(PropertyTest.ResetStaticDefaultValue));
		}

		// Token: 0x17007FB7 RID: 32695
		// (get) Token: 0x0602E3F3 RID: 189427 RVA: 0x00ADCB63 File Offset: 0x00ADAD63
		// (set) Token: 0x0602E3F4 RID: 189428 RVA: 0x00ADCB6A File Offset: 0x00ADAD6A
		public static int IntProp { get; set; } = 0;

		// Token: 0x17007FB8 RID: 32696
		// (get) Token: 0x0602E3F5 RID: 189429 RVA: 0x00ADCB72 File Offset: 0x00ADAD72
		// (set) Token: 0x0602E3F6 RID: 189430 RVA: 0x00ADCB79 File Offset: 0x00ADAD79
		public static int IntPropNonDefault { get; set; } = 99;

		// Token: 0x0602E3F7 RID: 189431 RVA: 0x00ADCB81 File Offset: 0x00ADAD81
		public static void CreateStaticDefaultValue()
		{
			PropertyTest.IntProp = 10;
		}

		// Token: 0x0602E3F8 RID: 189432 RVA: 0x00ADCB8A File Offset: 0x00ADAD8A
		public static void ResetStaticDefaultValue()
		{
			PropertyTest.IntProp = 0;
		}
	}
}
