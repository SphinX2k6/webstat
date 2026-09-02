using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Flow
{
	// Token: 0x02007031 RID: 28721
	public class FlowBoolOptionConfig
	{
		// Token: 0x04026D39 RID: 159033
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<string, string> Config = new Dictionary<string, string>
		{
			{
				"DisableInput",
				"是否禁止输入"
			},
			{
				"DisableViewControl",
				"是否禁止视角控制"
			},
			{
				"HideUi",
				"是否隐藏其它UI"
			},
			{
				"CanSkip",
				"是否可以跳过"
			},
			{
				"CanInteractive",
				"是否可以交互"
			}
		};
	}
}
