using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.WuwaGo.Controller.GameMode;
using CSharpScript.Game.Module.WuwaGo.Model;
using CSharpScript.Game.Module.WuwaGo.Model.Role;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo.Controller.Role
{
	// Token: 0x02004AF7 RID: 19191
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class StaticMonsterController : WuWaGoMonsterControllerBase<WuWaGoStaticMonster>
	{
		// Token: 0x060320CC RID: 205004 RVA: 0x00C86499 File Offset: 0x00C84699
		public StaticMonsterController(WuWaGoStaticMonster role, WuWaGoGameData gameData, WuWaGoGameModeBase gameMode) : base(role, gameData, gameMode)
		{
		}

		// Token: 0x060320CD RID: 205005 RVA: 0x00C864A4 File Offset: 0x00C846A4
		protected override UniTask OnExecuteAction()
		{
			StaticMonsterController.<OnExecuteAction>d__1 <OnExecuteAction>d__;
			<OnExecuteAction>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnExecuteAction>d__.<>4__this = this;
			<OnExecuteAction>d__.<>1__state = -1;
			<OnExecuteAction>d__.<>t__builder.Start<StaticMonsterController.<OnExecuteAction>d__1>(ref <OnExecuteAction>d__);
			return <OnExecuteAction>d__.<>t__builder.Task;
		}
	}
}
