using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Ai
{
	// Token: 0x0200563B RID: 22075
	[NullableContext(1)]
	[Nullable(0)]
	public class CardAttrOperation : NpcAiOperation
	{
		// Token: 0x17009077 RID: 36983
		// (get) Token: 0x06038499 RID: 230553 RVA: 0x00E40613 File Offset: 0x00E3E813
		// (set) Token: 0x0603849A RID: 230554 RVA: 0x00E4061B File Offset: 0x00E3E81B
		public NpcPhantomBattleCardAttrInfo Info { get; private set; }

		// Token: 0x0603849B RID: 230555 RVA: 0x00E40624 File Offset: 0x00E3E824
		public CardAttrOperation(NpcPhantomBattleCardAttrInfo info)
		{
			this.Info = info;
		}

		// Token: 0x0603849C RID: 230556 RVA: 0x00E40633 File Offset: 0x00E3E833
		public override UniTask ExecuteAiOperation(PhantomArenaBattleProxy proxy)
		{
			ModelBase<PhantomArenaBattleModel>.Instance.RefreshFighterAttr(this.Info.CardFighterUId, this.Info.BattleStatus.ToDictionary<int, int>());
			return UniTask.CompletedTask;
		}
	}
}
