using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C62 RID: 27746
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemHonamiShopView : OpenSystemBase
	{
		// Token: 0x06044277 RID: 279159 RVA: 0x011B1F87 File Offset: 0x011B0187
		public OpenSystemHonamiShopView(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044278 RID: 279160 RVA: 0x011B1F90 File Offset: 0x011B0190
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemHonamiShopView.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.context = context;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemHonamiShopView.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044279 RID: 279161 RVA: 0x011B1FD3 File Offset: 0x011B01D3
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.HonamiStoryShopView);
		}
	}
}
