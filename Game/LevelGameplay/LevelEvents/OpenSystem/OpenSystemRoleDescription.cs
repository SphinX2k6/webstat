using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C88 RID: 27784
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemRoleDescription : OpenSystemBase
	{
		// Token: 0x060442E9 RID: 279273 RVA: 0x011B2FFA File Offset: 0x011B11FA
		public OpenSystemRoleDescription(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x060442EA RID: 279274 RVA: 0x011B3004 File Offset: 0x011B1204
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemRoleDescription.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemRoleDescription.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x060442EB RID: 279275 RVA: 0x011B3047 File Offset: 0x011B1247
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.RoleNewJoinTipView);
		}
	}
}
