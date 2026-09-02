using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C6C RID: 27756
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemLordGymLordEntranceSelectView : OpenSystemBase
	{
		// Token: 0x06044295 RID: 279189 RVA: 0x011B248F File Offset: 0x011B068F
		public OpenSystemLordGymLordEntranceSelectView(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044296 RID: 279190 RVA: 0x011B2498 File Offset: 0x011B0698
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemLordGymLordEntranceSelectView.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.context = context;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemLordGymLordEntranceSelectView.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044297 RID: 279191 RVA: 0x011B24E3 File Offset: 0x011B06E3
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.LordGymLordEntranceSelectView);
		}
	}
}
