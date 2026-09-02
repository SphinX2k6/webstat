using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Ai
{
	// Token: 0x0200564B RID: 22091
	[NullableContext(1)]
	[Nullable(0)]
	public class UseCardSkillOperation : NpcAiOperation
	{
		// Token: 0x17009084 RID: 36996
		// (get) Token: 0x060384D5 RID: 230613 RVA: 0x00E40E6F File Offset: 0x00E3F06F
		// (set) Token: 0x060384D6 RID: 230614 RVA: 0x00E40E77 File Offset: 0x00E3F077
		public NpcPhantomBattleCardSkillInfo Info { get; private set; }

		// Token: 0x060384D7 RID: 230615 RVA: 0x00E40E80 File Offset: 0x00E3F080
		public UseCardSkillOperation(NpcPhantomBattleCardSkillInfo info)
		{
			this.Info = info;
		}

		// Token: 0x060384D8 RID: 230616 RVA: 0x00E40E90 File Offset: 0x00E3F090
		public override UniTask ExecuteAiOperation(PhantomArenaBattleProxy proxy)
		{
			UseCardSkillOperation.<ExecuteAiOperation>d__5 <ExecuteAiOperation>d__;
			<ExecuteAiOperation>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteAiOperation>d__.<>4__this = this;
			<ExecuteAiOperation>d__.proxy = proxy;
			<ExecuteAiOperation>d__.<>1__state = -1;
			<ExecuteAiOperation>d__.<>t__builder.Start<UseCardSkillOperation.<ExecuteAiOperation>d__5>(ref <ExecuteAiOperation>d__);
			return <ExecuteAiOperation>d__.<>t__builder.Task;
		}
	}
}
