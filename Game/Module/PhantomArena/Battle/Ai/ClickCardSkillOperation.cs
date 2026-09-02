using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Ai
{
	// Token: 0x0200563D RID: 22077
	[NullableContext(1)]
	[Nullable(0)]
	public class ClickCardSkillOperation : NpcAiOperation
	{
		// Token: 0x17009079 RID: 36985
		// (get) Token: 0x060384A1 RID: 230561 RVA: 0x00E406CB File Offset: 0x00E3E8CB
		// (set) Token: 0x060384A2 RID: 230562 RVA: 0x00E406D3 File Offset: 0x00E3E8D3
		public NpcPhantomBattleCardDurableSkillInfo Info { get; private set; }

		// Token: 0x060384A3 RID: 230563 RVA: 0x00E406DC File Offset: 0x00E3E8DC
		public ClickCardSkillOperation(NpcPhantomBattleCardDurableSkillInfo info)
		{
			this.Info = info;
		}

		// Token: 0x060384A4 RID: 230564 RVA: 0x00E406EC File Offset: 0x00E3E8EC
		public override UniTask ExecuteAiOperation(PhantomArenaBattleProxy proxy)
		{
			ClickCardSkillOperation.<ExecuteAiOperation>d__5 <ExecuteAiOperation>d__;
			<ExecuteAiOperation>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteAiOperation>d__.<>4__this = this;
			<ExecuteAiOperation>d__.proxy = proxy;
			<ExecuteAiOperation>d__.<>1__state = -1;
			<ExecuteAiOperation>d__.<>t__builder.Start<ClickCardSkillOperation.<ExecuteAiOperation>d__5>(ref <ExecuteAiOperation>d__);
			return <ExecuteAiOperation>d__.<>t__builder.Task;
		}
	}
}
