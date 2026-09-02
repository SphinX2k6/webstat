using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.LevelGamePlay.DigitalScreen;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C49 RID: 27721
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemDigitalScreen : OpenSystemBase
	{
		// Token: 0x0604422D RID: 279085 RVA: 0x011B15EF File Offset: 0x011AF7EF
		public OpenSystemDigitalScreen(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x0604422E RID: 279086 RVA: 0x011B15F8 File Offset: 0x011AF7F8
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemDigitalScreen.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.context = context;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemDigitalScreen.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x0604422F RID: 279087 RVA: 0x011B1644 File Offset: 0x011AF844
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			if (inParams == null)
			{
				return new EUiViewName?(EUiViewName.DigitalScreenaView);
			}
			DigitalScreen? dataConfig = ModelBase<DigitalScreenModel>.Instance.GetDataConfig(inParams.BoardId);
			if (dataConfig != null && dataConfig.GetValueOrDefault().Prefab == 0)
			{
				return new EUiViewName?(EUiViewName.DigitalScreenaView);
			}
			if (dataConfig != null && dataConfig.GetValueOrDefault().Prefab == 1)
			{
				return new EUiViewName?(EUiViewName.DigitalScreenbView);
			}
			return new EUiViewName?(EUiViewName.DigitalScreenaView);
		}
	}
}
