using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.SimpleGameplay
{
	// Token: 0x02006C30 RID: 27696
	public interface ISimpleGameplayOpenHandler : ISimpleGameplayHandlerBase
	{
		// Token: 0x060441E3 RID: 279011
		[NullableContext(1)]
		void Open(IUiGame config, OpenSimpleGameplay parameters, ISimpleGameplayOpenHost host);
	}
}
