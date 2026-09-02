using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C57 RID: 27735
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemFurnitureShopView : OpenSystemBase
	{
		// Token: 0x06044257 RID: 279127 RVA: 0x011B1BFF File Offset: 0x011AFDFF
		public OpenSystemFurnitureShopView(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044258 RID: 279128 RVA: 0x011B1C08 File Offset: 0x011AFE08
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemFurnitureShopView.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemFurnitureShopView.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044259 RID: 279129 RVA: 0x011B1C43 File Offset: 0x011AFE43
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.FurnitureShopView);
		}
	}
}
