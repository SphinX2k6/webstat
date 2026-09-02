using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle.SkillInteract
{
	// Token: 0x020055E3 RID: 21987
	public class PhantomArenaChooseCardSkillInteract : PhantomArenaSkillInteractBase
	{
		// Token: 0x06038079 RID: 229497 RVA: 0x00E31C60 File Offset: 0x00E2FE60
		protected override UniTask<EPhantomArenaSkillInteractExecuteResult> OnExecute([Nullable(1)] PhantomArenaBattleProxy proxy)
		{
			PhantomArenaChooseCardSkillInteract.<OnExecute>d__0 <OnExecute>d__;
			<OnExecute>d__.<>t__builder = AsyncUniTaskMethodBuilder<EPhantomArenaSkillInteractExecuteResult>.Create();
			<OnExecute>d__.<>4__this = this;
			<OnExecute>d__.<>1__state = -1;
			<OnExecute>d__.<>t__builder.Start<PhantomArenaChooseCardSkillInteract.<OnExecute>d__0>(ref <OnExecute>d__);
			return <OnExecute>d__.<>t__builder.Task;
		}
	}
}
