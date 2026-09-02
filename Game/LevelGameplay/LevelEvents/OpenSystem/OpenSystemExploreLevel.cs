using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C4F RID: 27727
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemExploreLevel : OpenSystemBase
	{
		// Token: 0x0604423F RID: 279103 RVA: 0x011B190E File Offset: 0x011AFB0E
		public OpenSystemExploreLevel(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044240 RID: 279104 RVA: 0x011B1918 File Offset: 0x011AFB18
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemExploreLevel.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemExploreLevel.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044241 RID: 279105 RVA: 0x011B1953 File Offset: 0x011AFB53
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.ExploreLevelView);
		}
	}
}
