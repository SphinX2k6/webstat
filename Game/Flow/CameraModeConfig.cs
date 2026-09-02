using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Flow
{
	// Token: 0x02007033 RID: 28723
	public class CameraModeConfig
	{
		// Token: 0x04026D3A RID: 159034
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<string, string> Config = new Dictionary<string, string>
		{
			{
				"Drama",
				"剧情相机"
			},
			{
				"Follow",
				"跟随"
			},
			{
				"FollowDrama",
				"跟随相机剧情模式"
			}
		};
	}
}
