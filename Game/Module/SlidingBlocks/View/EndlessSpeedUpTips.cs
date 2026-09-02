using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.SlidingBlocks.View
{
	// Token: 0x02004F0F RID: 20239
	public class EndlessSpeedUpTips : UiPanelBase
	{
		// Token: 0x060344F3 RID: 214259 RVA: 0x00D16BC0 File Offset: 0x00D14DC0
		protected override void OnStart()
		{
			this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x060344F4 RID: 214260 RVA: 0x00D16BD4 File Offset: 0x00D14DD4
		protected override UniTask OnShowAsyncImplementImplement()
		{
			EndlessSpeedUpTips.<OnShowAsyncImplementImplement>d__2 <OnShowAsyncImplementImplement>d__;
			<OnShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnShowAsyncImplementImplement>d__.<>4__this = this;
			<OnShowAsyncImplementImplement>d__.<>1__state = -1;
			<OnShowAsyncImplementImplement>d__.<>t__builder.Start<EndlessSpeedUpTips.<OnShowAsyncImplementImplement>d__2>(ref <OnShowAsyncImplementImplement>d__);
			return <OnShowAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x060344F5 RID: 214261 RVA: 0x00D16C18 File Offset: 0x00D14E18
		protected override UniTask OnHideAsyncImplementImplement()
		{
			EndlessSpeedUpTips.<OnHideAsyncImplementImplement>d__3 <OnHideAsyncImplementImplement>d__;
			<OnHideAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnHideAsyncImplementImplement>d__.<>4__this = this;
			<OnHideAsyncImplementImplement>d__.<>1__state = -1;
			<OnHideAsyncImplementImplement>d__.<>t__builder.Start<EndlessSpeedUpTips.<OnHideAsyncImplementImplement>d__3>(ref <OnHideAsyncImplementImplement>d__);
			return <OnHideAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x0401E2D0 RID: 123600
		[Nullable(2)]
		private LevelSequencePlayer SequencePlayer;
	}
}
