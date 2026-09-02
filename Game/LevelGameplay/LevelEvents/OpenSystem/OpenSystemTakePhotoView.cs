using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C95 RID: 27797
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemTakePhotoView : OpenSystemBase
	{
		// Token: 0x06044311 RID: 279313 RVA: 0x011B346B File Offset: 0x011B166B
		public OpenSystemTakePhotoView(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044312 RID: 279314 RVA: 0x011B3474 File Offset: 0x011B1674
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemTakePhotoView.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemTakePhotoView.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044313 RID: 279315 RVA: 0x011B34AF File Offset: 0x011B16AF
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.PhotographView);
		}
	}
}
