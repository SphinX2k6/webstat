using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.SoPatch
{
	// Token: 0x02004532 RID: 17714
	public static class SoPatchDefine
	{
		// Token: 0x0602EA59 RID: 191065 RVA: 0x00B0CD4B File Offset: 0x00B0AF4B
		[NullableContext(1)]
		public static void CheckCondition(string expect, string value, CheckConditions condition, int num)
		{
			condition.ExpectChange(num);
			if (string.IsNullOrEmpty(expect) || expect == value)
			{
				condition.ValueChange(num);
			}
		}
	}
}
