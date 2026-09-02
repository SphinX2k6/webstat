using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.UnitTest
{
	// Token: 0x0200445D RID: 17501
	[StaticVariableRuleIgnore]
	public class ValueTypeResetTest : IStaticVariableResetter
	{
		// Token: 0x0602E3E4 RID: 189412 RVA: 0x00ADC959 File Offset: 0x00ADAB59
		static ValueTypeResetTest()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(ValueTypeResetTest.CreateStaticDefaultValue), new Action(ValueTypeResetTest.ResetStaticDefaultValue));
		}

		// Token: 0x0602E3E5 RID: 189413 RVA: 0x00ADC999 File Offset: 0x00ADAB99
		public static void CreateStaticDefaultValue()
		{
			ValueTypeResetTest.IntValue = 100;
			ValueTypeResetTest.BoolValue = true;
			ValueTypeResetTest.StringValue = "active";
			ValueTypeResetTest.NullableInt = new int?(42);
		}

		// Token: 0x0602E3E6 RID: 189414 RVA: 0x00ADC9BE File Offset: 0x00ADABBE
		public static void ResetStaticDefaultValue()
		{
			ValueTypeResetTest.IntValue = 0;
			ValueTypeResetTest.BoolValue = false;
			ValueTypeResetTest.StringValue = string.Empty;
			ValueTypeResetTest.NullableInt = null;
		}

		// Token: 0x0401A42B RID: 107563
		public static int IntValue = 0;

		// Token: 0x0401A42C RID: 107564
		public static bool BoolValue = false;

		// Token: 0x0401A42D RID: 107565
		[Nullable(1)]
		public static string StringValue = string.Empty;

		// Token: 0x0401A42E RID: 107566
		public static int? NullableInt = null;
	}
}
