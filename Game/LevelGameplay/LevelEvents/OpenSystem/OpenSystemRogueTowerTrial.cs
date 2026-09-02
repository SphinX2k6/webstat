using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C87 RID: 27783
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemRogueTowerTrial : OpenSystemBase
	{
		// Token: 0x060442E6 RID: 279270 RVA: 0x011B2F9F File Offset: 0x011B119F
		public OpenSystemRogueTowerTrial(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x060442E7 RID: 279271 RVA: 0x011B2FA8 File Offset: 0x011B11A8
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemRogueTowerTrial.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemRogueTowerTrial.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x060442E8 RID: 279272 RVA: 0x011B2FE4 File Offset: 0x011B11E4
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return null;
		}
	}
}
