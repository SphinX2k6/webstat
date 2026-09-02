using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C42 RID: 27714
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemCiacconaChapterView : OpenSystemBase
	{
		// Token: 0x06044218 RID: 279064 RVA: 0x011B12DB File Offset: 0x011AF4DB
		public OpenSystemCiacconaChapterView(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044219 RID: 279065 RVA: 0x011B12E4 File Offset: 0x011AF4E4
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.CiacconaGalChapterView);
		}

		// Token: 0x0604421A RID: 279066 RVA: 0x011B12F0 File Offset: 0x011AF4F0
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemCiacconaChapterView.<ExecuteOpenView>d__2 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemCiacconaChapterView.<ExecuteOpenView>d__2>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}
	}
}
