using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C41 RID: 27713
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemCiacconaChapterEntry : OpenSystemBase
	{
		// Token: 0x06044215 RID: 279061 RVA: 0x011B1283 File Offset: 0x011AF483
		public OpenSystemCiacconaChapterEntry(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044216 RID: 279062 RVA: 0x011B128C File Offset: 0x011AF48C
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.CiacconaGalChapterEntryView);
		}

		// Token: 0x06044217 RID: 279063 RVA: 0x011B1298 File Offset: 0x011AF498
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemCiacconaChapterEntry.<ExecuteOpenView>d__2 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemCiacconaChapterEntry.<ExecuteOpenView>d__2>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}
	}
}
