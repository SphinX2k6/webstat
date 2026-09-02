using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Ai
{
	// Token: 0x02005641 RID: 22081
	[NullableContext(1)]
	[Nullable(0)]
	public class GamerStatusOperation : NpcAiOperation
	{
		// Token: 0x1700907D RID: 36989
		// (get) Token: 0x060384B1 RID: 230577 RVA: 0x00E4087B File Offset: 0x00E3EA7B
		// (set) Token: 0x060384B2 RID: 230578 RVA: 0x00E40883 File Offset: 0x00E3EA83
		public NpcPhantomBattleGamerStatusInfo Info { get; private set; }

		// Token: 0x060384B3 RID: 230579 RVA: 0x00E4088C File Offset: 0x00E3EA8C
		public GamerStatusOperation(NpcPhantomBattleGamerStatusInfo info)
		{
			this.Info = info;
		}

		// Token: 0x060384B4 RID: 230580 RVA: 0x00E4089C File Offset: 0x00E3EA9C
		public override UniTask ExecuteAiOperation(PhantomArenaBattleProxy proxy)
		{
			if (this.Info.GamerIndex == 0)
			{
				ModelBase<PhantomArenaBattleModel>.Instance.OpponentData.RefreshBattleStatus(this.Info.BattleStatus.ToDictionary<int, int>());
			}
			else if (this.Info.GamerIndex == 1)
			{
				ModelBase<PhantomArenaBattleModel>.Instance.OwnData.RefreshBattleStatus(this.Info.BattleStatus.ToDictionary<int, int>());
			}
			return UniTask.CompletedTask;
		}
	}
}
