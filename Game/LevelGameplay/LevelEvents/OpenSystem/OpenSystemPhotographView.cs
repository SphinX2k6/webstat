using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C77 RID: 27767
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemPhotographView : OpenSystemBase
	{
		// Token: 0x060442B6 RID: 279222 RVA: 0x011B291A File Offset: 0x011B0B1A
		public OpenSystemPhotographView(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x060442B7 RID: 279223 RVA: 0x011B2924 File Offset: 0x011B0B24
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemPhotographView.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemPhotographView.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x060442B8 RID: 279224 RVA: 0x011B2967 File Offset: 0x011B0B67
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.PhotographView);
		}
	}
}
