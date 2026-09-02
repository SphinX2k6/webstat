using System;
using System.Diagnostics;
using System.Reflection;

namespace CSharpScript.Launcher
{
	// Token: 0x0200447C RID: 17532
	public static class CSharpScriptBuildInfo
	{
		// Token: 0x0602E4DA RID: 189658 RVA: 0x00ADD97C File Offset: 0x00ADBB7C
		private static bool DetectOptimized()
		{
			DebuggableAttribute customAttribute = typeof(CSharpScriptBuildInfo).Assembly.GetCustomAttribute<DebuggableAttribute>();
			return customAttribute == null || !customAttribute.IsJITOptimizerDisabled;
		}

		// Token: 0x0401A443 RID: 107587
		[StaticVariableRuleIgnore]
		public static readonly bool Optimized = CSharpScriptBuildInfo.DetectOptimized();
	}
}
