using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.WuwaGo.Controller;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WuwaGo.View
{
	// Token: 0x02004ABF RID: 19135
	public class WuWaGoPauseView : UiViewBase
	{
		// Token: 0x06031E2D RID: 204333 RVA: 0x00C7BB41 File Offset: 0x00C79D41
		[NullableContext(1)]
		public WuWaGoPauseView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06031E2E RID: 204334 RVA: 0x00C7BB4C File Offset: 0x00C79D4C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 4;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnMaskButtonClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnReturnButtonClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnExitButtonClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnGotoButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06031E2F RID: 204335 RVA: 0x00C7BCA0 File Offset: 0x00C79EA0
		protected override UniTask OnBeforeStartAsync()
		{
			WuWaGoPauseView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<WuWaGoPauseView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031E30 RID: 204336 RVA: 0x00C7BCE3 File Offset: 0x00C79EE3
		protected override void OnAddEventListener()
		{
			this.TimeStopToken = new int?(WuWaGoTimeStop.Begin("PauseView"));
			ControllerBase<WuWaGoController>.Instance.SetMainControlInputAccepting(false);
		}

		// Token: 0x06031E31 RID: 204337 RVA: 0x00C7BD05 File Offset: 0x00C79F05
		protected override void OnRemoveEventListener()
		{
			if (this.TimeStopToken != null)
			{
				WuWaGoTimeStop.End(this.TimeStopToken.Value);
				this.TimeStopToken = null;
			}
			ControllerBase<WuWaGoController>.Instance.SetMainControlInputAccepting(true);
		}

		// Token: 0x06031E32 RID: 204338 RVA: 0x00C7BD3B File Offset: 0x00C79F3B
		private void OnMaskButtonClick()
		{
		}

		// Token: 0x06031E33 RID: 204339 RVA: 0x00C7BD3D File Offset: 0x00C79F3D
		private void OnReturnButtonClick()
		{
			this.CloseMeAsync().ContinueWith(delegate(bool _)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.OnWuWaGoUserRequestRollbackToSavePoint);
			}).Forget();
		}

		// Token: 0x06031E34 RID: 204340 RVA: 0x00C7BD70 File Offset: 0x00C79F70
		private void OnExitButtonClick()
		{
			Singleton<Log>.Instance.Info(ELogModule.WuWaGo, ELogAuthor.YSQ, "玩家主动退出玩法", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.CloseMeAsync().ContinueWith(delegate(bool _)
			{
				ControllerBase<WuWaGoController>.Instance.EndGameplay(false);
			}).Forget();
		}

		// Token: 0x06031E35 RID: 204341 RVA: 0x00C7BDCB File Offset: 0x00C79FCB
		private void OnGotoButtonClick()
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.WuWaGoPauseView, null);
		}

		// Token: 0x0401D31F RID: 119583
		private int? TimeStopToken;

		// Token: 0x0200AB1E RID: 43806
		private enum EViewComponent
		{
			// Token: 0x04035401 RID: 218113
			BtnMask,
			// Token: 0x04035402 RID: 218114
			BtnReturn,
			// Token: 0x04035403 RID: 218115
			BtnExit,
			// Token: 0x04035404 RID: 218116
			BtnGoto
		}
	}
}
