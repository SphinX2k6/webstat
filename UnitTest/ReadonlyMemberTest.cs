using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.UnitTest
{
	// Token: 0x02004451 RID: 17489
	[NullableContext(1)]
	[Nullable(0)]
	[StaticVariableRuleIgnore]
	public class ReadonlyMemberTest
	{
		// Token: 0x0602E3BB RID: 189371 RVA: 0x00ADC687 File Offset: 0x00ADA887
		public static int GenId()
		{
			return 1;
		}

		// Token: 0x0401A40D RID: 107533
		public static readonly int TagIdByIndexer = GameplayTagDefine.EGameplayTagId["关卡.Common.表现.蓄力斩.上升"];

		// Token: 0x0401A40E RID: 107534
		public static readonly int LiteralInt = 42;

		// Token: 0x0401A40F RID: 107535
		public static readonly int CallInitInt = ReadonlyMemberTest.GenId();

		// Token: 0x0401A410 RID: 107536
		public static readonly TestClass ReadonlyRefObj = new TestClass();

		// Token: 0x0401A411 RID: 107537
		public static readonly IReadOnlyList<int> ReadonlyIntList = new List<int>
		{
			1,
			2,
			3
		};

		// Token: 0x0401A412 RID: 107538
		public static readonly IReadOnlyList<FName> ReadonlyFNameList = new List<FName>();

		// Token: 0x0401A413 RID: 107539
		public static readonly IReadOnlyDictionary<FName, string> ReadonlyFNameDict = new Dictionary<FName, string>();

		// Token: 0x0401A414 RID: 107540
		public static readonly IReadOnlyList<TestClass> ReadonlyRefList = new List<TestClass>();

		// Token: 0x0401A415 RID: 107541
		public static readonly List<int> MutableList = new List<int>
		{
			1,
			2,
			3
		};
	}
}
