using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Ai
{
	// Token: 0x02005648 RID: 22088
	[NullableContext(1)]
	[Nullable(0)]
	public class ReserveCardOperation : NpcAiOperation
	{
		// Token: 0x17009081 RID: 36993
		// (get) Token: 0x060384C9 RID: 230601 RVA: 0x00E40D2A File Offset: 0x00E3EF2A
		// (set) Token: 0x060384CA RID: 230602 RVA: 0x00E40D32 File Offset: 0x00E3EF32
		public NpcPhantomBattleReserveCardInfo Info { get; private set; }

		// Token: 0x060384CB RID: 230603 RVA: 0x00E40D3B File Offset: 0x00E3EF3B
		public ReserveCardOperation(NpcPhantomBattleReserveCardInfo info)
		{
			this.Info = info;
		}

		// Token: 0x060384CC RID: 230604 RVA: 0x00E40D4C File Offset: 0x00E3EF4C
		public override UniTask ExecuteAiOperation(PhantomArenaBattleProxy proxy)
		{
			ReserveCardOperation.<ExecuteAiOperation>d__5 <ExecuteAiOperation>d__;
			<ExecuteAiOperation>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteAiOperation>d__.<>4__this = this;
			<ExecuteAiOperation>d__.proxy = proxy;
			<ExecuteAiOperation>d__.<>1__state = -1;
			<ExecuteAiOperation>d__.<>t__builder.Start<ReserveCardOperation.<ExecuteAiOperation>d__5>(ref <ExecuteAiOperation>d__);
			return <ExecuteAiOperation>d__.<>t__builder.Task;
		}
	}
}
