using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C60 RID: 27744
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemHonamiMainView : OpenSystemBase
	{
		// Token: 0x06044271 RID: 279153 RVA: 0x011B1ECF File Offset: 0x011B00CF
		public OpenSystemHonamiMainView(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044272 RID: 279154 RVA: 0x011B1ED8 File Offset: 0x011B00D8
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.HonamiStorySmallLoadingView);
		}

		// Token: 0x06044273 RID: 279155 RVA: 0x011B1EE4 File Offset: 0x011B00E4
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemHonamiMainView.<ExecuteOpenView>d__2 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.context = context;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemHonamiMainView.<ExecuteOpenView>d__2>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}
	}
}
