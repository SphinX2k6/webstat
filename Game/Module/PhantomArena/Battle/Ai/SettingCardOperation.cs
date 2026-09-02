using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Ai
{
	// Token: 0x02005649 RID: 22089
	[NullableContext(1)]
	[Nullable(0)]
	public class SettingCardOperation : NpcAiOperation
	{
		// Token: 0x17009082 RID: 36994
		// (get) Token: 0x060384CD RID: 230605 RVA: 0x00E40D97 File Offset: 0x00E3EF97
		// (set) Token: 0x060384CE RID: 230606 RVA: 0x00E40D9F File Offset: 0x00E3EF9F
		public NpcPhantomBattleEnterSlotInfo Info { get; private set; }

		// Token: 0x060384CF RID: 230607 RVA: 0x00E40DA8 File Offset: 0x00E3EFA8
		public SettingCardOperation(NpcPhantomBattleEnterSlotInfo info)
		{
			this.Info = info;
		}

		// Token: 0x060384D0 RID: 230608 RVA: 0x00E40DB8 File Offset: 0x00E3EFB8
		public override UniTask ExecuteAiOperation(PhantomArenaBattleProxy proxy)
		{
			SettingCardOperation.<ExecuteAiOperation>d__5 <ExecuteAiOperation>d__;
			<ExecuteAiOperation>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteAiOperation>d__.<>4__this = this;
			<ExecuteAiOperation>d__.proxy = proxy;
			<ExecuteAiOperation>d__.<>1__state = -1;
			<ExecuteAiOperation>d__.<>t__builder.Start<SettingCardOperation.<ExecuteAiOperation>d__5>(ref <ExecuteAiOperation>d__);
			return <ExecuteAiOperation>d__.<>t__builder.Task;
		}
	}
}
