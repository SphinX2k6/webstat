using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C3E RID: 27710
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemChangePhantomExhibitView : OpenSystemBase
	{
		// Token: 0x0604420C RID: 279052 RVA: 0x011B1183 File Offset: 0x011AF383
		public OpenSystemChangePhantomExhibitView(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x0604420D RID: 279053 RVA: 0x011B118C File Offset: 0x011AF38C
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemChangePhantomExhibitView.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.context = context;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemChangePhantomExhibitView.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x0604420E RID: 279054 RVA: 0x011B11CF File Offset: 0x011AF3CF
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.SpringManorPhantomExhibitView);
		}
	}
}
