using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.SimpleGameplay
{
	// Token: 0x02006C31 RID: 27697
	public interface ISimpleGameplayOpenHandler<in TConfig> : ISimpleGameplayOpenHandler, ISimpleGameplayHandlerBase where TConfig : IUiGame
	{
		// Token: 0x060441E4 RID: 279012
		[NullableContext(1)]
		void Open(TConfig config, OpenSimpleGameplay parameters, ISimpleGameplayOpenHost host);

		// Token: 0x060441E5 RID: 279013 RVA: 0x011B0B1B File Offset: 0x011AED1B
		[NullableContext(1)]
		void Open(IUiGame config, OpenSimpleGameplay parameters, ISimpleGameplayOpenHost host)
		{
			this.Open((TConfig)((object)config), parameters, host);
		}
	}
}
