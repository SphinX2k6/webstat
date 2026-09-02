using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006CA2 RID: 27810
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenVillageInfrMainView : OpenSystemBase
	{
		// Token: 0x0604433C RID: 279356 RVA: 0x011B3AE7 File Offset: 0x011B1CE7
		public OpenVillageInfrMainView(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x0604433D RID: 279357 RVA: 0x011B3AF0 File Offset: 0x011B1CF0
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenVillageInfrMainView.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenVillageInfrMainView.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x0604433E RID: 279358 RVA: 0x011B3B2B File Offset: 0x011B1D2B
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.VillageInfrMainView);
		}
	}
}
