using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.MovieMode;

namespace CSharpScript.Game.Ui.Common.HudOnlyPopup
{
	// Token: 0x02004A63 RID: 19043
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class HudOnlyPopupController : UiControllerBase<HudOnlyPopupController>
	{
		// Token: 0x06031BA8 RID: 203688 RVA: 0x00C739EA File Offset: 0x00C71BEA
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnAnyViewClose));
			Singleton<EventSystem>.Instance.Add(EEventName.ActiveBattleView, new Action(this.OnActiveBattleView));
		}

		// Token: 0x06031BA9 RID: 203689 RVA: 0x00C73A24 File Offset: 0x00C71C24
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnAnyViewClose));
			Singleton<EventSystem>.Instance.Remove(EEventName.ActiveBattleView, new Action(this.OnActiveBattleView));
			this.Queue.Clear();
		}

		// Token: 0x06031BAA RID: 203690 RVA: 0x00C73A74 File Offset: 0x00C71C74
		public unsafe void Push(HudOnlyPopupTask task)
		{
			this.Queue.Push(task);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiCommon;
			ELogAuthor author = ELogAuthor.SYB;
			string message = "[HudOnlyPopup] 任务入队";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ViewName", task.ViewName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("DedupKey", task.DedupKey ?? string.Empty);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("QueueLen", this.Queue.Length);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			this.TryFlush();
		}

		// Token: 0x06031BAB RID: 203691 RVA: 0x00C73B25 File Offset: 0x00C71D25
		public bool Cancel(string dedupKey)
		{
			return this.Queue.RemoveByKey(dedupKey);
		}

		// Token: 0x06031BAC RID: 203692 RVA: 0x00C73B33 File Offset: 0x00C71D33
		public void ClearAll()
		{
			this.Queue.Clear();
		}

		// Token: 0x06031BAD RID: 203693 RVA: 0x00C73B40 File Offset: 0x00C71D40
		public bool CanShowNow()
		{
			UiViewBase uiViewBase = Singleton<UiModel>.Instance.NormalStack.Peek();
			return uiViewBase != null && uiViewBase.ViewInfo.Name.Equals(Singleton<UiModel>.Instance.MainViewName) && Singleton<UiModel>.Instance.PopList.Count <= 0 && !ControllerBase<MovieModeController>.Instance.IsInMovieMode() && !Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.GuideFocusView);
		}

		// Token: 0x06031BAE RID: 203694 RVA: 0x00C73BB7 File Offset: 0x00C71DB7
		private void OnAnyViewClose(EUiViewName viewName, int viewId)
		{
			if (this.Queue.IsEmpty)
			{
				return;
			}
			this.TryFlush();
		}

		// Token: 0x06031BAF RID: 203695 RVA: 0x00C73BCD File Offset: 0x00C71DCD
		private void OnActiveBattleView()
		{
			if (this.Queue.IsEmpty)
			{
				return;
			}
			this.TryFlush();
		}

		// Token: 0x06031BB0 RID: 203696 RVA: 0x00C73BE4 File Offset: 0x00C71DE4
		private unsafe void TryFlush()
		{
			int length = this.Queue.Length;
			while (length-- > 0 && !this.Queue.IsEmpty && this.CanShowNow())
			{
				HudOnlyPopupTask hudOnlyPopupTask = this.Queue.Shift();
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiCommon;
				ELogAuthor author = ELogAuthor.SYB;
				string message = "[HudOnlyPopup] 任务出队播放";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ViewName", hudOnlyPopupTask.ViewName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("DedupKey", hudOnlyPopupTask.DedupKey ?? string.Empty);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				Singleton<UiManager>.Instance.OpenView(hudOnlyPopupTask.ViewName, hudOnlyPopupTask.ViewParam, null);
			}
		}

		// Token: 0x0401D1CB RID: 119243
		private readonly HudOnlyPopupQueue Queue = new HudOnlyPopupQueue();
	}
}
