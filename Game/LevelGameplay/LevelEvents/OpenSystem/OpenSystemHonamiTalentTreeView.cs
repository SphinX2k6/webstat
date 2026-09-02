using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C63 RID: 27747
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemHonamiTalentTreeView : OpenSystemBase
	{
		// Token: 0x0604427A RID: 279162 RVA: 0x011B1FDF File Offset: 0x011B01DF
		public OpenSystemHonamiTalentTreeView(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x0604427B RID: 279163 RVA: 0x011B1FE8 File Offset: 0x011B01E8
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemHonamiTalentTreeView.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemHonamiTalentTreeView.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x0604427C RID: 279164 RVA: 0x011B2023 File Offset: 0x011B0223
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.HonamiStoryTechnologyView);
		}
	}
}
