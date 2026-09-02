using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Ai
{
	// Token: 0x0200563F RID: 22079
	[NullableContext(1)]
	[Nullable(0)]
	public class EvolveCardOperation : NpcAiOperation
	{
		// Token: 0x1700907B RID: 36987
		// (get) Token: 0x060384A9 RID: 230569 RVA: 0x00E407A3 File Offset: 0x00E3E9A3
		// (set) Token: 0x060384AA RID: 230570 RVA: 0x00E407AB File Offset: 0x00E3E9AB
		public NpcPhantomBattleEvolveInfo Info { get; private set; }

		// Token: 0x060384AB RID: 230571 RVA: 0x00E407B4 File Offset: 0x00E3E9B4
		public EvolveCardOperation(NpcPhantomBattleEvolveInfo info)
		{
			this.Info = info;
		}

		// Token: 0x060384AC RID: 230572 RVA: 0x00E407C4 File Offset: 0x00E3E9C4
		public override UniTask ExecuteAiOperation(PhantomArenaBattleProxy proxy)
		{
			EvolveCardOperation.<ExecuteAiOperation>d__5 <ExecuteAiOperation>d__;
			<ExecuteAiOperation>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteAiOperation>d__.<>4__this = this;
			<ExecuteAiOperation>d__.proxy = proxy;
			<ExecuteAiOperation>d__.<>1__state = -1;
			<ExecuteAiOperation>d__.<>t__builder.Start<EvolveCardOperation.<ExecuteAiOperation>d__5>(ref <ExecuteAiOperation>d__);
			return <ExecuteAiOperation>d__.<>t__builder.Task;
		}
	}
}
