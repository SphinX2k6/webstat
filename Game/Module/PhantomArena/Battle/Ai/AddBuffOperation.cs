using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Ai
{
	// Token: 0x02005638 RID: 22072
	[NullableContext(1)]
	[Nullable(0)]
	public class AddBuffOperation : NpcAiOperation
	{
		// Token: 0x17009074 RID: 36980
		// (get) Token: 0x0603848D RID: 230541 RVA: 0x00E40512 File Offset: 0x00E3E712
		// (set) Token: 0x0603848E RID: 230542 RVA: 0x00E4051A File Offset: 0x00E3E71A
		public PhantomBattleBuffTriggerInfo Info { get; private set; }

		// Token: 0x0603848F RID: 230543 RVA: 0x00E40523 File Offset: 0x00E3E723
		public AddBuffOperation(PhantomBattleBuffTriggerInfo info)
		{
			this.Info = info;
		}

		// Token: 0x06038490 RID: 230544 RVA: 0x00E40532 File Offset: 0x00E3E732
		public override UniTask ExecuteAiOperation(PhantomArenaBattleProxy proxy)
		{
			return UniTask.CompletedTask;
		}
	}
}
