using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Ai
{
	// Token: 0x0200564C RID: 22092
	[NullableContext(1)]
	[Nullable(0)]
	public class UseRoleSkillOperation : NpcAiOperation
	{
		// Token: 0x17009085 RID: 36997
		// (get) Token: 0x060384D9 RID: 230617 RVA: 0x00E40EDB File Offset: 0x00E3F0DB
		// (set) Token: 0x060384DA RID: 230618 RVA: 0x00E40EE3 File Offset: 0x00E3F0E3
		public NpcPhantomBattleCardRoleSkillInfo Info { get; private set; }

		// Token: 0x060384DB RID: 230619 RVA: 0x00E40EEC File Offset: 0x00E3F0EC
		public UseRoleSkillOperation(NpcPhantomBattleCardRoleSkillInfo info)
		{
			this.Info = info;
		}

		// Token: 0x060384DC RID: 230620 RVA: 0x00E40EFB File Offset: 0x00E3F0FB
		public override UniTask ExecuteAiOperation(PhantomArenaBattleProxy proxy)
		{
			return UniTask.CompletedTask;
		}
	}
}
