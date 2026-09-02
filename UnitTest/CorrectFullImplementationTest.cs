using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.UnitTest
{
	// Token: 0x0200445E RID: 17502
	[NullableContext(1)]
	[Nullable(0)]
	[StaticVariableRuleIgnore]
	public class CorrectFullImplementationTest : IStaticVariableResetter
	{
		// Token: 0x0602E3E8 RID: 189416 RVA: 0x00ADC9EC File Offset: 0x00ADABEC
		static CorrectFullImplementationTest()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(CorrectFullImplementationTest.CreateStaticDefaultValue), new Action(CorrectFullImplementationTest.ResetStaticDefaultValue));
		}

		// Token: 0x0602E3E9 RID: 189417 RVA: 0x00ADCA74 File Offset: 0x00ADAC74
		public static void CreateStaticDefaultValue()
		{
			CorrectFullImplementationTest.Obj = new TestClass();
			CorrectFullImplementationTest.IntValue = 42;
			CorrectFullImplementationTest.BoolValue = true;
			CorrectFullImplementationTest.StringValue = "hello";
			CorrectFullImplementationTest.NullableInt = new int?(10);
		}

		// Token: 0x0602E3EA RID: 189418 RVA: 0x00ADCAA3 File Offset: 0x00ADACA3
		public static void ResetStaticDefaultValue()
		{
			CorrectFullImplementationTest.Obj = null;
			CorrectFullImplementationTest.IntValue = 0;
			CorrectFullImplementationTest.BoolValue = false;
			CorrectFullImplementationTest.StringValue = string.Empty;
			CorrectFullImplementationTest.NullableInt = null;
		}

		// Token: 0x0401A42F RID: 107567
		[Nullable(2)]
		public static TestClass Obj;

		// Token: 0x0401A430 RID: 107568
		public static int IntValue = 0;

		// Token: 0x0401A431 RID: 107569
		public static bool BoolValue = false;

		// Token: 0x0401A432 RID: 107570
		public static string StringValue = string.Empty;

		// Token: 0x0401A433 RID: 107571
		public static int? NullableInt = null;

		// Token: 0x0401A434 RID: 107572
		public static readonly int TagId = GameplayTagDefine.EGameplayTagId["关卡.Common.表现.蓄力斩.上升"];

		// Token: 0x0401A435 RID: 107573
		public static readonly IReadOnlyList<int> IntList = new List<int>
		{
			1,
			2,
			3
		};

		// Token: 0x0401A436 RID: 107574
		public static readonly IReadOnlyList<FName> FNameList = new List<FName>();
	}
}
