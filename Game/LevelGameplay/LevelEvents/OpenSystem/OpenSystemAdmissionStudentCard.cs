using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C3B RID: 27707
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemAdmissionStudentCard : OpenSystemBase
	{
		// Token: 0x06044203 RID: 279043 RVA: 0x011B108F File Offset: 0x011AF28F
		public OpenSystemAdmissionStudentCard(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044204 RID: 279044 RVA: 0x011B1098 File Offset: 0x011AF298
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemAdmissionStudentCard.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemAdmissionStudentCard.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044205 RID: 279045 RVA: 0x011B10D3 File Offset: 0x011AF2D3
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.AdmissionStudentCardView);
		}
	}
}
