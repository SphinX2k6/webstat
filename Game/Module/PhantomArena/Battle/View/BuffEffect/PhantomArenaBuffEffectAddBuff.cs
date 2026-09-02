using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.PhantomArena.Battle.SkillInteract;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.BuffEffect
{
	// Token: 0x020055E0 RID: 21984
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaBuffEffectAddBuff
	{
		// Token: 0x06038063 RID: 229475 RVA: 0x00E315B5 File Offset: 0x00E2F7B5
		public PhantomArenaBuffEffectAddBuff(IBuffEffectData data, PhantomArenaBuffEffectManager manager)
		{
			this.Data = data;
			this.Manager = manager;
		}

		// Token: 0x06038064 RID: 229476 RVA: 0x00E315CC File Offset: 0x00E2F7CC
		public void ShowBuffEffect()
		{
			foreach (int buffConfigId in this.Data.Effect.PhantomBattleAddBuffEffectCtx.PhantomBattleBuffId)
			{
				PhantomBattleBuff phantomBattleBuffConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleBuffConfig(buffConfigId);
				if (phantomBattleBuffConfig.BuffShowType != 0)
				{
					this.Manager.Proxy.ShowAddBuffEffect((EBuffShowType)phantomBattleBuffConfig.BuffShowType, this.Data.SelectFightIdList);
				}
			}
		}

		// Token: 0x04020088 RID: 131208
		protected IBuffEffectData Data;

		// Token: 0x04020089 RID: 131209
		protected PhantomArenaBuffEffectManager Manager;
	}
}
