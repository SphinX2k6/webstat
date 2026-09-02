using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A0B RID: 27147
	public class LevelGameplayActionsDefine
	{
		// Token: 0x060433DB RID: 275419 RVA: 0x01149D9F File Offset: 0x01147F9F
		// Note: this type is marked as 'beforefieldinit'.
		static LevelGameplayActionsDefine()
		{
			Dictionary<EOptionType, string> dictionary = new Dictionary<EOptionType, string>();
			dictionary[EOptionType.Normal] = "基础交互";
			dictionary[EOptionType.Dynamic] = "动态交互";
			dictionary[EOptionType.Random] = "随机交互";
			LevelGameplayActionsDefine.optionTypeLogString = dictionary;
		}

		// Token: 0x040257C4 RID: 153540
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<EOptionType, string> optionTypeLogString;
	}
}
