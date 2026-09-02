using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049A3 RID: 18851
	public class UiBehaviorBaseProxy : ComponentAction
	{
		// Token: 0x0603138F RID: 201615 RVA: 0x00C41C94 File Offset: 0x00C3FE94
		[NullableContext(1)]
		public UiBehaviorBaseProxy(IUiBehavior uiBehaviorBase)
		{
			this.UiBehavior = uiBehaviorBase;
		}

		// Token: 0x06031390 RID: 201616 RVA: 0x00C41CA4 File Offset: 0x00C3FEA4
		protected override UniTask<bool> OnCreateAsyncImplement()
		{
			UiBehaviorBaseProxy.<OnCreateAsyncImplement>d__2 <OnCreateAsyncImplement>d__;
			<OnCreateAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OnCreateAsyncImplement>d__.<>4__this = this;
			<OnCreateAsyncImplement>d__.<>1__state = -1;
			<OnCreateAsyncImplement>d__.<>t__builder.Start<UiBehaviorBaseProxy.<OnCreateAsyncImplement>d__2>(ref <OnCreateAsyncImplement>d__);
			return <OnCreateAsyncImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06031391 RID: 201617 RVA: 0x00C41CE8 File Offset: 0x00C3FEE8
		protected override UniTask OnStartAsyncImplement()
		{
			UiBehaviorBaseProxy.<OnStartAsyncImplement>d__3 <OnStartAsyncImplement>d__;
			<OnStartAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnStartAsyncImplement>d__.<>4__this = this;
			<OnStartAsyncImplement>d__.<>1__state = -1;
			<OnStartAsyncImplement>d__.<>t__builder.Start<UiBehaviorBaseProxy.<OnStartAsyncImplement>d__3>(ref <OnStartAsyncImplement>d__);
			return <OnStartAsyncImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06031392 RID: 201618 RVA: 0x00C41D2C File Offset: 0x00C3FF2C
		protected override UniTask OnShowAsyncImplement()
		{
			UiBehaviorBaseProxy.<OnShowAsyncImplement>d__4 <OnShowAsyncImplement>d__;
			<OnShowAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnShowAsyncImplement>d__.<>4__this = this;
			<OnShowAsyncImplement>d__.<>1__state = -1;
			<OnShowAsyncImplement>d__.<>t__builder.Start<UiBehaviorBaseProxy.<OnShowAsyncImplement>d__4>(ref <OnShowAsyncImplement>d__);
			return <OnShowAsyncImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06031393 RID: 201619 RVA: 0x00C41D70 File Offset: 0x00C3FF70
		protected override UniTask OnHideAsyncImplement()
		{
			UiBehaviorBaseProxy.<OnHideAsyncImplement>d__5 <OnHideAsyncImplement>d__;
			<OnHideAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnHideAsyncImplement>d__.<>4__this = this;
			<OnHideAsyncImplement>d__.<>1__state = -1;
			<OnHideAsyncImplement>d__.<>t__builder.Start<UiBehaviorBaseProxy.<OnHideAsyncImplement>d__5>(ref <OnHideAsyncImplement>d__);
			return <OnHideAsyncImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06031394 RID: 201620 RVA: 0x00C41DB4 File Offset: 0x00C3FFB4
		protected override UniTask OnDestroyAsyncImplement()
		{
			UiBehaviorBaseProxy.<OnDestroyAsyncImplement>d__6 <OnDestroyAsyncImplement>d__;
			<OnDestroyAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnDestroyAsyncImplement>d__.<>4__this = this;
			<OnDestroyAsyncImplement>d__.<>1__state = -1;
			<OnDestroyAsyncImplement>d__.<>t__builder.Start<UiBehaviorBaseProxy.<OnDestroyAsyncImplement>d__6>(ref <OnDestroyAsyncImplement>d__);
			return <OnDestroyAsyncImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06031395 RID: 201621 RVA: 0x00C41DF7 File Offset: 0x00C3FFF7
		protected override void OnDestroyImplementCompatible()
		{
			if (this.UiBehavior == null)
			{
				return;
			}
			this.UiBehavior.OnBeforeDestroy();
			this.UiBehavior = null;
		}

		// Token: 0x0401C526 RID: 116006
		[Nullable(1)]
		private IUiBehavior UiBehavior;
	}
}
