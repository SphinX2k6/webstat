using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C4B RID: 27723
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemDreamLinkLevel : OpenSystemBase
	{
		// Token: 0x06044233 RID: 279091 RVA: 0x011B172B File Offset: 0x011AF92B
		public OpenSystemDreamLinkLevel(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044234 RID: 279092 RVA: 0x011B1734 File Offset: 0x011AF934
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemDreamLinkLevel.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>4__this = this;
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemDreamLinkLevel.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044235 RID: 279093 RVA: 0x011B1780 File Offset: 0x011AF980
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			if (inParams == null)
			{
				return new EUiViewName?(EUiViewName.DreamLinkMainView);
			}
			switch (inParams.BoardId)
			{
			case 0:
				return new EUiViewName?(EUiViewName.DreamLinkMainView);
			case 1:
				return new EUiViewName?(EUiViewName.DreamLinkDungeonView);
			case 2:
				return new EUiViewName?(EUiViewName.DreamLinkWhiteCatView);
			case 3:
				return new EUiViewName?(EUiViewName.DreamLinkWorldRunView);
			default:
				return new EUiViewName?(EUiViewName.DreamLinkMainView);
			}
		}
	}
}
