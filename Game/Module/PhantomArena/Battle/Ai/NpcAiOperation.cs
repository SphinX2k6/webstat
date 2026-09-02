using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Ai
{
	// Token: 0x02005643 RID: 22083
	public abstract class NpcAiOperation
	{
		// Token: 0x060384B9 RID: 230585
		[NullableContext(1)]
		public abstract UniTask ExecuteAiOperation(PhantomArenaBattleProxy proxy);
	}
}
