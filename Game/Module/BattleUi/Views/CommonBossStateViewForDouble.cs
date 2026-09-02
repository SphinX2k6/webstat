using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FED RID: 24557
	internal class CommonBossStateViewForDouble : CommonBossStateView
	{
		// Token: 0x0603DD13 RID: 253203 RVA: 0x00FC1308 File Offset: 0x00FBF508
		[NullableContext(2)]
		protected override UniTask InitializeAsync(object param = null)
		{
			CommonBossStateViewForDouble.<InitializeAsync>d__0 <InitializeAsync>d__;
			<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitializeAsync>d__.<>4__this = this;
			<InitializeAsync>d__.param = param;
			<InitializeAsync>d__.<>1__state = -1;
			<InitializeAsync>d__.<>t__builder.Start<CommonBossStateViewForDouble.<InitializeAsync>d__0>(ref <InitializeAsync>d__);
			return <InitializeAsync>d__.<>t__builder.Task;
		}
	}
}
