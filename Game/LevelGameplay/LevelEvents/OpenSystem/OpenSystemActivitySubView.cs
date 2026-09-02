using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C3A RID: 27706
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemActivitySubView : OpenSystemBase
	{
		// Token: 0x06044200 RID: 279040 RVA: 0x011B0FEF File Offset: 0x011AF1EF
		public OpenSystemActivitySubView(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044201 RID: 279041 RVA: 0x011B0FF8 File Offset: 0x011AF1F8
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemActivitySubView.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemActivitySubView.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044202 RID: 279042 RVA: 0x011B103C File Offset: 0x011AF23C
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			if (inParams == null)
			{
				return null;
			}
			ActivityViewName? config = ConfigActivityViewNameById.GetConfig(inParams.BoardId, true);
			if (config != null)
			{
				return new EUiViewName?((EUiViewName)config.Value.ViewName);
			}
			return null;
		}
	}
}
