using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Flow
{
	// Token: 0x0200703A RID: 28730
	public class CameraBindModeConfig
	{
		// Token: 0x04026D3C RID: 159036
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<string, string> Config = new Dictionary<string, string>
		{
			{
				"One",
				"1角色"
			},
			{
				"Two",
				"2角色"
			},
			{
				"Three",
				"3角色"
			},
			{
				"None",
				"无"
			}
		};
	}
}
