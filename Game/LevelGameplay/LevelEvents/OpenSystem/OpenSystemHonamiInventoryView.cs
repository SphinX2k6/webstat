using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C5F RID: 27743
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemHonamiInventoryView : OpenSystemBase
	{
		// Token: 0x0604426E RID: 279150 RVA: 0x011B1E7F File Offset: 0x011B007F
		public OpenSystemHonamiInventoryView(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x0604426F RID: 279151 RVA: 0x011B1E88 File Offset: 0x011B0088
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemHonamiInventoryView.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemHonamiInventoryView.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044270 RID: 279152 RVA: 0x011B1EC3 File Offset: 0x011B00C3
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.HonamiStoryBackpackView);
		}
	}
}
