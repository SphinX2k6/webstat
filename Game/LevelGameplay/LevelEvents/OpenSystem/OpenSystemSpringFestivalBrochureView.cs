using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C92 RID: 27794
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemSpringFestivalBrochureView : OpenSystemBase
	{
		// Token: 0x06044308 RID: 279304 RVA: 0x011B3373 File Offset: 0x011B1573
		public OpenSystemSpringFestivalBrochureView(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044309 RID: 279305 RVA: 0x011B337C File Offset: 0x011B157C
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemSpringFestivalBrochureView.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemSpringFestivalBrochureView.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x0604430A RID: 279306 RVA: 0x011B33B7 File Offset: 0x011B15B7
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.SpringManorBrochureView);
		}
	}
}
