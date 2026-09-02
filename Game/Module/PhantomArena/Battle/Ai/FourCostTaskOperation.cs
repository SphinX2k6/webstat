using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Ai
{
	// Token: 0x02005640 RID: 22080
	[NullableContext(1)]
	[Nullable(0)]
	public class FourCostTaskOperation : NpcAiOperation
	{
		// Token: 0x1700907C RID: 36988
		// (get) Token: 0x060384AD RID: 230573 RVA: 0x00E4080F File Offset: 0x00E3EA0F
		// (set) Token: 0x060384AE RID: 230574 RVA: 0x00E40817 File Offset: 0x00E3EA17
		public NpcPhantomFourCTaskDealCardInfo Info { get; private set; }

		// Token: 0x060384AF RID: 230575 RVA: 0x00E40820 File Offset: 0x00E3EA20
		public FourCostTaskOperation(NpcPhantomFourCTaskDealCardInfo info)
		{
			this.Info = info;
		}

		// Token: 0x060384B0 RID: 230576 RVA: 0x00E40830 File Offset: 0x00E3EA30
		public override UniTask ExecuteAiOperation(PhantomArenaBattleProxy proxy)
		{
			FourCostTaskOperation.<ExecuteAiOperation>d__5 <ExecuteAiOperation>d__;
			<ExecuteAiOperation>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteAiOperation>d__.<>4__this = this;
			<ExecuteAiOperation>d__.proxy = proxy;
			<ExecuteAiOperation>d__.<>1__state = -1;
			<ExecuteAiOperation>d__.<>t__builder.Start<FourCostTaskOperation.<ExecuteAiOperation>d__5>(ref <ExecuteAiOperation>d__);
			return <ExecuteAiOperation>d__.<>t__builder.Task;
		}
	}
}
