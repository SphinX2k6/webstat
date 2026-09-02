using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Ai
{
	// Token: 0x02005644 RID: 22084
	[NullableContext(1)]
	[Nullable(0)]
	public class NpcCardUpdateOperation : NpcAiOperation
	{
		// Token: 0x1700907F RID: 36991
		// (get) Token: 0x060384BB RID: 230587 RVA: 0x00E4097F File Offset: 0x00E3EB7F
		// (set) Token: 0x060384BC RID: 230588 RVA: 0x00E40987 File Offset: 0x00E3EB87
		public PhantomBattleNpcCardUpdateInfo Info { get; private set; }

		// Token: 0x060384BD RID: 230589 RVA: 0x00E40990 File Offset: 0x00E3EB90
		public NpcCardUpdateOperation(PhantomBattleNpcCardUpdateInfo info)
		{
			this.Info = info;
		}

		// Token: 0x060384BE RID: 230590 RVA: 0x00E409A0 File Offset: 0x00E3EBA0
		public override UniTask ExecuteAiOperation(PhantomArenaBattleProxy proxy)
		{
			PhantomCardData cardDataByFightId = ModelBase<PhantomArenaBattleModel>.Instance.OpponentData.GetCardDataByFightId(this.Info.CardUId);
			if (cardDataByFightId == null)
			{
				return UniTask.CompletedTask;
			}
			cardDataByFightId.NotifyRefreshCardData(this.Info.Factors.ToDictionary<int, int>(), this.Info.LockFactor.ToList<int>(), this.Info.CanUnlimitedEvolve);
			return UniTask.CompletedTask;
		}
	}
}
