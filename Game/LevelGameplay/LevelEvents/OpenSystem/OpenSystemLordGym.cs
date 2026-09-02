using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C6B RID: 27755
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemLordGym : OpenSystemBase
	{
		// Token: 0x06044292 RID: 279186 RVA: 0x011B242F File Offset: 0x011B062F
		public OpenSystemLordGym(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044293 RID: 279187 RVA: 0x011B2438 File Offset: 0x011B0638
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemLordGym.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.context = context;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemLordGym.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044294 RID: 279188 RVA: 0x011B2483 File Offset: 0x011B0683
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.LordGymEntranceView);
		}
	}
}
