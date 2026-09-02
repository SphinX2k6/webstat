using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelAi.BehaviorTree
{
	// Token: 0x02006E40 RID: 28224
	public class IBTNodeParseEntry
	{
		// Token: 0x040261E5 RID: 156133
		[Nullable(1)]
		public string classPath;

		// Token: 0x040261E6 RID: 156134
		public EBTNodeType nodeType;

		// Token: 0x040261E7 RID: 156135
		[Nullable(new byte[]
		{
			1,
			1,
			1,
			2,
			2,
			1,
			2
		})]
		public Func<object, IParserContext, IMontageConfigProvider, Dictionary<string, object>> parse;
	}
}
