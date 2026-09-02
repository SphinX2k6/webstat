using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Flow
{
	// Token: 0x02007024 RID: 28708
	public class LogLevelConfig
	{
		// Token: 0x04026D38 RID: 159032
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<string, string> Config = new Dictionary<string, string>
		{
			{
				"Info",
				"提示"
			},
			{
				"Warn",
				"警告"
			},
			{
				"Error",
				"错误"
			}
		};
	}
}
