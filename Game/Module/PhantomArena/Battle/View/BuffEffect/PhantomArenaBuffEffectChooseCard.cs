using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.BuffEffect
{
	// Token: 0x020055E1 RID: 21985
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaBuffEffectChooseCard
	{
		// Token: 0x06038065 RID: 229477 RVA: 0x00E31658 File Offset: 0x00E2F858
		public PhantomArenaBuffEffectChooseCard(IBuffEffectData data, PhantomArenaBuffEffectManager manager)
		{
			this.Data = data;
			this.Manager = manager;
		}

		// Token: 0x06038066 RID: 229478 RVA: 0x00E31670 File Offset: 0x00E2F870
		public void ShowChooseCard()
		{
			PhantomBattleCardSelectEffectCtx phantomBattleCardSelectEffectCtx = this.Data.Effect.PhantomBattleCardSelectEffectCtx;
			this.Manager.Proxy.ServerActionQueue.PushChooseCardAction(phantomBattleCardSelectEffectCtx);
		}

		// Token: 0x0402008A RID: 131210
		protected IBuffEffectData Data;

		// Token: 0x0402008B RID: 131211
		protected PhantomArenaBuffEffectManager Manager;
	}
}
