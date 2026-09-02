using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C50 RID: 27728
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemExpostulation : OpenSystemBase
	{
		// Token: 0x06044242 RID: 279106 RVA: 0x011B195F File Offset: 0x011AFB5F
		public OpenSystemExpostulation(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044243 RID: 279107 RVA: 0x011B1968 File Offset: 0x011AFB68
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemExpostulation.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.context = context;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemExpostulation.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044244 RID: 279108 RVA: 0x011B19AC File Offset: 0x011AFBAC
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			if (context != null && context.Type.GetValueOrDefault() == EGeneralContextType.Entity)
			{
				return new EUiViewName?(EUiViewName.AdviceInfoView);
			}
			return null;
		}
	}
}
