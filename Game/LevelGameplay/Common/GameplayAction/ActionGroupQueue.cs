using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.Common.GameplayAction
{
	// Token: 0x02006F31 RID: 28465
	public class ActionGroupQueue
	{
		// Token: 0x040266D9 RID: 157401
		[Nullable(1)]
		public Queue<GameplayActionGroup> Queue = new Queue<GameplayActionGroup>(4);

		// Token: 0x040266DA RID: 157402
		[Nullable(2)]
		public Action OnFinish;
	}
}
