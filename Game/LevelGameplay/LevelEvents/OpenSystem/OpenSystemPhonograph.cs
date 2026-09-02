using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C76 RID: 27766
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemPhonograph : OpenSystemBase
	{
		// Token: 0x060442B3 RID: 279219 RVA: 0x011B2897 File Offset: 0x011B0A97
		public OpenSystemPhonograph(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x060442B4 RID: 279220 RVA: 0x011B28A0 File Offset: 0x011B0AA0
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemPhonograph.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemPhonograph.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x060442B5 RID: 279221 RVA: 0x011B28E3 File Offset: 0x011B0AE3
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			if (inParams == null)
			{
				return new EUiViewName?(EUiViewName.PhonographView);
			}
			if (ModelBase<PhonographModel>.Instance.GetUnlockItemIds().Count > 0)
			{
				return new EUiViewName?(EUiViewName.PhonographNewMusicView);
			}
			return new EUiViewName?(EUiViewName.PhonographView);
		}
	}
}
