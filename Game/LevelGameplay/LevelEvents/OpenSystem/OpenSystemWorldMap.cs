using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006CA0 RID: 27808
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemWorldMap : OpenSystemBase
	{
		// Token: 0x06044336 RID: 279350 RVA: 0x011B3A2E File Offset: 0x011B1C2E
		public OpenSystemWorldMap(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044337 RID: 279351 RVA: 0x011B3A38 File Offset: 0x011B1C38
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemWorldMap.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemWorldMap.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044338 RID: 279352 RVA: 0x011B3A7B File Offset: 0x011B1C7B
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.WorldMapView);
		}
	}
}
