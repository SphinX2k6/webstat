using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Flow
{
	// Token: 0x02007035 RID: 28725
	public class PlotModeConfig
	{
		// Token: 0x04026D3B RID: 159035
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<string, string> Config = new Dictionary<string, string>
		{
			{
				"LevelA",
				"A级演出"
			},
			{
				"LevelB",
				"B级演出"
			},
			{
				"LevelC",
				"C级演出"
			},
			{
				"LevelD",
				"D级演出"
			}
		};
	}
}
