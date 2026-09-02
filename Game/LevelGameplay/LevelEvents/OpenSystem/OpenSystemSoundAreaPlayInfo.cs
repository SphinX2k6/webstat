using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C91 RID: 27793
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemSoundAreaPlayInfo : OpenSystemBase
	{
		// Token: 0x06044305 RID: 279301 RVA: 0x011B331B File Offset: 0x011B151B
		public OpenSystemSoundAreaPlayInfo(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044306 RID: 279302 RVA: 0x011B3324 File Offset: 0x011B1524
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemSoundAreaPlayInfo.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemSoundAreaPlayInfo.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044307 RID: 279303 RVA: 0x011B3367 File Offset: 0x011B1567
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.SoundAreaPlayTips);
		}
	}
}
