using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C61 RID: 27745
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemHonamiMascotView : OpenSystemBase
	{
		// Token: 0x06044274 RID: 279156 RVA: 0x011B1F2F File Offset: 0x011B012F
		public OpenSystemHonamiMascotView(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044275 RID: 279157 RVA: 0x011B1F38 File Offset: 0x011B0138
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemHonamiMascotView.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.context = context;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemHonamiMascotView.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044276 RID: 279158 RVA: 0x011B1F7B File Offset: 0x011B017B
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.HonamiStoryMascotCollectBookView);
		}
	}
}
