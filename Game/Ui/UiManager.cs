using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A4B RID: 19019
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class UiManager : Singleton<UiManager>, ITickable
	{
		// Token: 0x17008485 RID: 33925
		// (get) Token: 0x06031B09 RID: 203529 RVA: 0x00C61836 File Offset: 0x00C5FA36
		public bool IsInited
		{
			get
			{
				return this.InitState == EInitState.Inited;
			}
		}

		// Token: 0x06031B0A RID: 203530 RVA: 0x00C61841 File Offset: 0x00C5FA41
		public IReadOnlyDictionary<EUiViewName, HashSet<UiViewBase>> GetNameToViewSetMap()
		{
			return this.NameToViewSetMap;
		}

		// Token: 0x06031B0B RID: 203531 RVA: 0x00C6184C File Offset: 0x00C5FA4C
		[NullableContext(2)]
		private unsafe void OpenViewPrivate(EUiViewName name, object param = null, ELayerType? layerType = null, TOpenViewCallBack finishCallback = null)
		{
			Singleton<EventSystem>.Instance.Emit<EUiViewName>(EEventName.OpenViewBegined, name);
			this.OpenViewAsync(name, param, layerType).ContinueWith(delegate(int? viewId)
			{
				if (viewId != null)
				{
					TOpenViewCallBack finishCallback2 = finishCallback;
					if (finishCallback2 != null)
					{
						finishCallback2(true, viewId.Value);
					}
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.UiManager;
					ELogAuthor author = ELogAuthor.TL;
					string message = "[OpenView]流程执行成功";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ViewName", name);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ViewId", viewId);
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					return;
				}
				TOpenViewCallBack finishCallback3 = finishCallback;
				if (finishCallback3 != null)
				{
					finishCallback3(false, 0);
				}
				Singleton<EventSystem>.Instance.Emit<EUiViewName>(EEventName.OpenViewFail, name);
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.UiManager;
				ELogAuthor author2 = ELogAuthor.TL;
				string message2 = "[OpenView]流程执行失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", name);
				instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}).Forget(delegate(Exception exception)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiManager;
				ELogAuthor author = ELogAuthor.TL;
				string message = "[OpenView]流程执行异常";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", name);
				instance.ErrorWithStack(module, author, message, exception, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				TOpenViewCallBack finishCallback2 = finishCallback;
				if (finishCallback2 != null)
				{
					finishCallback2(false, 0);
				}
				Singleton<EventSystem>.Instance.Emit<EUiViewName>(EEventName.OpenViewFail, name);
			}, true);
		}

		// Token: 0x06031B0C RID: 203532 RVA: 0x00C618B4 File Offset: 0x00C5FAB4
		[NullableContext(2)]
		public void OpenView(EUiViewName name, object param = null, TOpenViewCallBack finishCallback = null)
		{
			this.OpenViewPrivate(name, param, null, finishCallback);
		}

		// Token: 0x06031B0D RID: 203533 RVA: 0x00C618D3 File Offset: 0x00C5FAD3
		[NullableContext(2)]
		public void OpenViewWithLayer(EUiViewName name, ELayerType layerType, object param = null, TOpenViewCallBack finishCallback = null)
		{
			this.OpenViewPrivate(name, param, new ELayerType?(layerType), finishCallback);
		}

		// Token: 0x06031B0E RID: 203534 RVA: 0x00C618E5 File Offset: 0x00C5FAE5
		[NullableContext(2)]
		public void OpenViewByPlot(EUiViewName name, object param = null, TOpenViewCallBack finishCallback = null)
		{
			if ((Singleton<UiConfig>.Instance.TryGetViewInfo(name).Type & (ELayerType.Normal | ELayerType.Plot | ELayerType.CG)) > (ELayerType)0)
			{
				this.OpenViewWithLayer(name, ELayerType.Plot, param, finishCallback);
				return;
			}
			this.OpenView(name, param, finishCallback);
		}

		// Token: 0x06031B0F RID: 203535 RVA: 0x00C61914 File Offset: 0x00C5FB14
		[NullableContext(0)]
		public UniTask<int?> OpenViewAsync(EUiViewName name, [Nullable(2)] object param = null, ELayerType? layerType = null)
		{
			UiManager.<OpenViewAsync>d__21 <OpenViewAsync>d__;
			<OpenViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<int?>.Create();
			<OpenViewAsync>d__.<>4__this = this;
			<OpenViewAsync>d__.name = name;
			<OpenViewAsync>d__.param = param;
			<OpenViewAsync>d__.layerType = layerType;
			<OpenViewAsync>d__.<>1__state = -1;
			<OpenViewAsync>d__.<>t__builder.Start<UiManager.<OpenViewAsync>d__21>(ref <OpenViewAsync>d__);
			return <OpenViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031B10 RID: 203536 RVA: 0x00C61970 File Offset: 0x00C5FB70
		[NullableContext(2)]
		public void CloseView(EUiViewName name, Action<bool> callback = null)
		{
			this.CloseViewAsync(name).ContinueWith(delegate(bool result)
			{
				if (result)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.UiManager;
					ELogAuthor author = ELogAuthor.TL;
					string message = "[CloseView]流程执行成功";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", name);
					instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.UiManager;
					ELogAuthor author2 = ELogAuthor.TL;
					string message2 = "[CloseView]流程执行异常";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("ViewName", name);
					instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				}
				Action<bool> callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2(result);
			}).Forget(delegate(Exception exception)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiManager;
				ELogAuthor author = ELogAuthor.TL;
				string message = "[CloseView]流程执行异常";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", name);
				instance.ErrorWithStack(module, author, message, exception, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				Action<bool> callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2(false);
			}, true);
		}

		// Token: 0x06031B11 RID: 203537 RVA: 0x00C619C0 File Offset: 0x00C5FBC0
		[NullableContext(0)]
		public UniTask<bool> CloseViewAsync(EUiViewName name)
		{
			UiManager.<CloseViewAsync>d__23 <CloseViewAsync>d__;
			<CloseViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<CloseViewAsync>d__.<>4__this = this;
			<CloseViewAsync>d__.name = name;
			<CloseViewAsync>d__.<>1__state = -1;
			<CloseViewAsync>d__.<>t__builder.Start<UiManager.<CloseViewAsync>d__23>(ref <CloseViewAsync>d__);
			return <CloseViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031B12 RID: 203538 RVA: 0x00C61A0C File Offset: 0x00C5FC0C
		[NullableContext(2)]
		public void CloseViewById(int viewId, Action<bool> callback = null)
		{
			this.CloseViewByIdAsync(viewId).ContinueWith(delegate(bool task)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiManager;
				ELogAuthor author = ELogAuthor.TL;
				string message = "[CloseViewById]流程执行成功";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("viewId", viewId);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				Action<bool> callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2(true);
			}).Forget(delegate(Exception exception)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiManager;
				ELogAuthor author = ELogAuthor.TL;
				string message = "[CloseViewById]流程执行异常";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("viewId", viewId);
				instance.ErrorWithStack(module, author, message, exception, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				Action<bool> callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2(false);
			}, true);
		}

		// Token: 0x06031B13 RID: 203539 RVA: 0x00C61A5C File Offset: 0x00C5FC5C
		[NullableContext(0)]
		public UniTask<bool> CloseViewByIdAsync(int viewId)
		{
			UiManager.<CloseViewByIdAsync>d__25 <CloseViewByIdAsync>d__;
			<CloseViewByIdAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<CloseViewByIdAsync>d__.<>4__this = this;
			<CloseViewByIdAsync>d__.viewId = viewId;
			<CloseViewByIdAsync>d__.<>1__state = -1;
			<CloseViewByIdAsync>d__.<>t__builder.Start<UiManager.<CloseViewByIdAsync>d__25>(ref <CloseViewByIdAsync>d__);
			return <CloseViewByIdAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031B14 RID: 203540 RVA: 0x00C61AA8 File Offset: 0x00C5FCA8
		[NullableContext(0)]
		public UniTask<bool> CloseViewImplementAsync([Nullable(1)] UiViewBase view, bool fromCloseMe = false)
		{
			UiManager.<CloseViewImplementAsync>d__26 <CloseViewImplementAsync>d__;
			<CloseViewImplementAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<CloseViewImplementAsync>d__.<>4__this = this;
			<CloseViewImplementAsync>d__.view = view;
			<CloseViewImplementAsync>d__.<>1__state = -1;
			<CloseViewImplementAsync>d__.<>t__builder.Start<UiManager.<CloseViewImplementAsync>d__26>(ref <CloseViewImplementAsync>d__);
			return <CloseViewImplementAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031B15 RID: 203541 RVA: 0x00C61AF4 File Offset: 0x00C5FCF4
		[NullableContext(2)]
		public unsafe void CloseAndOpenView(EUiViewName closeViewName, EUiViewName openViewName, object param = null, Action<bool> finishCallback = null, bool callJs = true)
		{
			this.CloseAndOpenViewAsync(closeViewName, openViewName, param, callJs).ContinueWith(delegate(bool task)
			{
				Action<bool> finishCallback2 = finishCallback;
				if (finishCallback2 == null)
				{
					return;
				}
				finishCallback2(true);
			}).Forget(delegate(Exception exception)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiManager;
				ELogAuthor author = ELogAuthor.TL;
				string message = "[CloseAndOpenView]流程执行异常";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("closeViewName", closeViewName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("openViewName", openViewName);
				instance.ErrorWithStack(module, author, message, exception, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				Action<bool> finishCallback2 = finishCallback;
				if (finishCallback2 == null)
				{
					return;
				}
				finishCallback2(false);
			}, true);
		}

		// Token: 0x06031B16 RID: 203542 RVA: 0x00C61B58 File Offset: 0x00C5FD58
		[NullableContext(0)]
		public UniTask<bool> CloseAndOpenViewAsync(EUiViewName closeViewName, EUiViewName openViewName, [Nullable(2)] object param, bool callJs = true)
		{
			UiManager.<CloseAndOpenViewAsync>d__28 <CloseAndOpenViewAsync>d__;
			<CloseAndOpenViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<CloseAndOpenViewAsync>d__.<>4__this = this;
			<CloseAndOpenViewAsync>d__.closeViewName = closeViewName;
			<CloseAndOpenViewAsync>d__.openViewName = openViewName;
			<CloseAndOpenViewAsync>d__.param = param;
			<CloseAndOpenViewAsync>d__.callJs = callJs;
			<CloseAndOpenViewAsync>d__.<>1__state = -1;
			<CloseAndOpenViewAsync>d__.<>t__builder.Start<UiManager.<CloseAndOpenViewAsync>d__28>(ref <CloseAndOpenViewAsync>d__);
			return <CloseAndOpenViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031B17 RID: 203543 RVA: 0x00C61BBC File Offset: 0x00C5FDBC
		[NullableContext(0)]
		public UniTask<int?> PreOpenViewAsync(EUiViewName name, bool callJs = false)
		{
			UiManager.<PreOpenViewAsync>d__29 <PreOpenViewAsync>d__;
			<PreOpenViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<int?>.Create();
			<PreOpenViewAsync>d__.<>4__this = this;
			<PreOpenViewAsync>d__.name = name;
			<PreOpenViewAsync>d__.callJs = callJs;
			<PreOpenViewAsync>d__.<>1__state = -1;
			<PreOpenViewAsync>d__.<>t__builder.Start<UiManager.<PreOpenViewAsync>d__29>(ref <PreOpenViewAsync>d__);
			return <PreOpenViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031B18 RID: 203544 RVA: 0x00C61C10 File Offset: 0x00C5FE10
		[NullableContext(0)]
		public UniTask<bool> OpenViewAfterPreOpenedAsync(int viewId, [Nullable(2)] object param = null, bool callJs = true)
		{
			UiManager.<OpenViewAfterPreOpenedAsync>d__30 <OpenViewAfterPreOpenedAsync>d__;
			<OpenViewAfterPreOpenedAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenViewAfterPreOpenedAsync>d__.<>4__this = this;
			<OpenViewAfterPreOpenedAsync>d__.viewId = viewId;
			<OpenViewAfterPreOpenedAsync>d__.param = param;
			<OpenViewAfterPreOpenedAsync>d__.callJs = callJs;
			<OpenViewAfterPreOpenedAsync>d__.<>1__state = -1;
			<OpenViewAfterPreOpenedAsync>d__.<>t__builder.Start<UiManager.<OpenViewAfterPreOpenedAsync>d__30>(ref <OpenViewAfterPreOpenedAsync>d__);
			return <OpenViewAfterPreOpenedAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031B19 RID: 203545 RVA: 0x00C61C6B File Offset: 0x00C5FE6B
		public void RemovePreOpenView(int viewId)
		{
			this.PreOpeningViewMap.Remove(viewId);
		}

		// Token: 0x06031B1A RID: 203546 RVA: 0x00C61C7C File Offset: 0x00C5FE7C
		private unsafe void ClearPreOpenView()
		{
			foreach (UiViewBase uiViewBase in this.PreOpeningViewMap.Values)
			{
				try
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.UiManager;
					ELogAuthor author = ELogAuthor.XXJ;
					string message = "[Clear] 尝试执行销毁的界面";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Name", uiViewBase.GetType().Name);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ComponentId", uiViewBase.ComponentId);
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					uiViewBase.OnOpenAfterPreOpened();
					uiViewBase.ClearAsync();
				}
				catch (Exception item)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.UiManager;
					ELogAuthor author2 = ELogAuthor.XXJ;
					string message2 = "界面同步关闭异常,业务变量可能未初始化完成,需要关注";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Exception", item);
					instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
			}
			this.PreOpeningViewMap.Clear();
		}

		// Token: 0x06031B1B RID: 203547 RVA: 0x00C61D94 File Offset: 0x00C5FF94
		public bool IsViewShow(EUiViewName name)
		{
			HashSet<UiViewBase> valueOrDefault = this.NameToViewSetMap.GetValueOrDefault(name);
			if (valueOrDefault == null)
			{
				return false;
			}
			foreach (UiViewBase uiViewBase in valueOrDefault)
			{
				if (uiViewBase.IsPreOpening)
				{
					return false;
				}
				if (uiViewBase.IsShowOrShowing)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06031B1C RID: 203548 RVA: 0x00C61E08 File Offset: 0x00C60008
		public bool IsViewOpen(EUiViewName viewName)
		{
			HashSet<UiViewBase> valueOrDefault = this.NameToViewSetMap.GetValueOrDefault(viewName);
			if (valueOrDefault == null)
			{
				return false;
			}
			foreach (UiViewBase uiViewBase in valueOrDefault)
			{
				if (uiViewBase.IsPreOpening)
				{
					return false;
				}
				if (uiViewBase.WaitToDestroy)
				{
					return false;
				}
				if (!uiViewBase.IsDestroyOrDestroying && !uiViewBase.IsHideOrHiding)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06031B1D RID: 203549 RVA: 0x00C61E90 File Offset: 0x00C60090
		public bool IsViewCreating(EUiViewName name)
		{
			HashSet<UiViewBase> valueOrDefault = this.NameToViewSetMap.GetValueOrDefault(name);
			if (valueOrDefault == null)
			{
				return false;
			}
			using (HashSet<UiViewBase>.Enumerator enumerator = valueOrDefault.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsCreating)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06031B1E RID: 203550 RVA: 0x00C61EF8 File Offset: 0x00C600F8
		public bool IsViewDestroying(EUiViewName name)
		{
			HashSet<UiViewBase> valueOrDefault = this.NameToViewSetMap.GetValueOrDefault(name);
			if (valueOrDefault == null)
			{
				return false;
			}
			using (HashSet<UiViewBase>.Enumerator enumerator = valueOrDefault.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsDestroying)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06031B1F RID: 203551 RVA: 0x00C61F60 File Offset: 0x00C60160
		public bool IsViewHide(EUiViewName name)
		{
			HashSet<UiViewBase> valueOrDefault = this.NameToViewSetMap.GetValueOrDefault(name);
			if (valueOrDefault == null)
			{
				return false;
			}
			using (HashSet<UiViewBase>.Enumerator enumerator = valueOrDefault.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsHideOrHiding)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06031B20 RID: 203552 RVA: 0x00C61FC8 File Offset: 0x00C601C8
		private void InitContainer()
		{
			this.Containers.Clear();
			this.Containers[ELayerType.HUD] = new UiViewSetContainer(Singleton<UiModel>.Instance.HudMap);
			UiViewStackContainer value = new UiViewStackContainer(Singleton<UiModel>.Instance.NormalStack);
			this.Containers[ELayerType.Normal] = value;
			this.Containers[ELayerType.CG] = value;
			this.Containers[ELayerType.Plot] = new UiViewPlotContainer(Singleton<UiModel>.Instance.PlotNormalStack);
			this.Containers[ELayerType.Pop] = new UiViewListContainer(Singleton<UiModel>.Instance.PopList);
			this.Containers[ELayerType.Float] = new UiViewFloatContainer(Singleton<UiModel>.Instance.FloatQueueMap, Singleton<UiModel>.Instance.ShowViewMap, Singleton<UiModel>.Instance.HideViewMap);
			this.Containers[ELayerType.Guide] = new UiViewListContainer(Singleton<UiModel>.Instance.GuideList);
			this.Containers[ELayerType.Loading] = new UiViewSetContainer(Singleton<UiModel>.Instance.LoadingMap);
			this.Containers[ELayerType.NetWork] = new UiViewListContainer(Singleton<UiModel>.Instance.NetWorkList);
			if (!Singleton<Info>.Instance.IsBuildShipping)
			{
				this.Containers[ELayerType.Debug] = new UiViewSetContainer(Singleton<UiModel>.Instance.DebugMap);
			}
		}

		// Token: 0x06031B21 RID: 203553 RVA: 0x00C6211C File Offset: 0x00C6031C
		private void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.ExitNormalQueueState, new Action(this.ExitNormalQueueState));
			Singleton<EventSystem>.Instance.Add(EEventName.ActiveBattleView, new Action(this.ShowFloatTips));
			Singleton<EventSystem>.Instance.Add(EEventName.DisActiveBattleView, new Action(this.HideFloatTips));
			Singleton<EventSystem>.Instance.Add(EEventName.StackOpenView, new Action<int, UiViewInfo>(this.OnStackOpenView));
			Singleton<EventSystem>.Instance.Add(EEventName.StackCloseView, new Action<int, EUiViewName, UiViewInfo>(this.OnStackCloseView));
		}

		// Token: 0x06031B22 RID: 203554 RVA: 0x00C621AE File Offset: 0x00C603AE
		[NullableContext(2)]
		private void OnStackOpenView(int viewId, UiViewInfo lastView)
		{
			this.CheckAndEmitNormalTopViewChange();
		}

		// Token: 0x06031B23 RID: 203555 RVA: 0x00C621B6 File Offset: 0x00C603B6
		[NullableContext(2)]
		private void OnStackCloseView(int viewId, EUiViewName viewName, UiViewInfo stackTopInfo)
		{
			this.CheckAndEmitNormalTopViewChange();
		}

		// Token: 0x06031B24 RID: 203556 RVA: 0x00C621C0 File Offset: 0x00C603C0
		private void CheckAndEmitNormalTopViewChange()
		{
			UiViewBase topView = Singleton<UiModel>.Instance.GetTopView(ELayerType.Normal);
			EUiViewName? euiViewName;
			if (topView == null)
			{
				euiViewName = null;
			}
			else
			{
				UiViewInfo viewInfo = topView.ViewInfo;
				euiViewName = ((viewInfo != null) ? new EUiViewName?(viewInfo.Name) : null);
			}
			EUiViewName? euiViewName2 = euiViewName;
			if (euiViewName2 == null)
			{
				return;
			}
			if (this.LastNormalTopViewName == euiViewName2)
			{
				return;
			}
			this.LastNormalTopViewName = euiViewName2;
			Singleton<EventSystem>.Instance.Emit<EUiViewName>(EEventName.OnNormalTopViewChange, euiViewName2.Value);
		}

		// Token: 0x06031B25 RID: 203557 RVA: 0x00C6226C File Offset: 0x00C6046C
		private void ResetToBattleViewForEvent()
		{
			Singleton<Log>.Instance.Info(ELogModule.UiManager, ELogAuthor.TL, "重置回到主界面", default(ReadOnlySpan<ValueTuple<string, object>>));
			((UiViewListContainer)this.Containers[ELayerType.Pop]).CloseAllView();
			this.NormalResetToView(EUiViewName.BattleView, null, true);
		}

		// Token: 0x06031B26 RID: 203558 RVA: 0x00C622BC File Offset: 0x00C604BC
		private void ExitNormalQueueState()
		{
			Singleton<Log>.Instance.Info(ELogModule.UiManager, ELogAuthor.TL, "退出队列状态,重置回到主界面", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.StartFloatWaitingNormalView();
		}

		// Token: 0x06031B27 RID: 203559 RVA: 0x00C622F0 File Offset: 0x00C604F0
		[NullableContext(2)]
		public void ResetToBattleView(Action<bool> callback = null)
		{
			Singleton<Log>.Instance.Info(ELogModule.UiManager, ELogAuthor.TL, "重置回到主界面", default(ReadOnlySpan<ValueTuple<string, object>>));
			((UiViewListContainer)this.Containers[ELayerType.Pop]).CloseAllView();
			this.NormalResetToView(Singleton<UiModel>.Instance.MainViewName, callback, true);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnResetToBattleView);
		}

		// Token: 0x06031B28 RID: 203560 RVA: 0x00C62358 File Offset: 0x00C60558
		[NullableContext(2)]
		public void NormalResetToView(EUiViewName viewName, Action<bool> callback = null, bool callJs = true)
		{
			this.NormalResetToViewAsync(viewName, callJs).ContinueWith(delegate()
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiManager;
				ELogAuthor author = ELogAuthor.TL;
				string message = "[NormalResetToView]流程执行成功";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", viewName);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				Action<bool> callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2(true);
			}).Forget(delegate(Exception exception)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiManager;
				ELogAuthor author = ELogAuthor.TL;
				string message = "[NormalResetToView]流程执行异常";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", viewName);
				instance.ErrorWithStack(module, author, message, exception, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				Action<bool> callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2(false);
			}, true);
		}

		// Token: 0x06031B29 RID: 203561 RVA: 0x00C623AC File Offset: 0x00C605AC
		public UniTask NormalResetToViewAsync(EUiViewName viewName, bool callJs = true)
		{
			UiManager.<NormalResetToViewAsync>d__47 <NormalResetToViewAsync>d__;
			<NormalResetToViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NormalResetToViewAsync>d__.<>4__this = this;
			<NormalResetToViewAsync>d__.viewName = viewName;
			<NormalResetToViewAsync>d__.callJs = callJs;
			<NormalResetToViewAsync>d__.<>1__state = -1;
			<NormalResetToViewAsync>d__.<>t__builder.Start<UiManager.<NormalResetToViewAsync>d__47>(ref <NormalResetToViewAsync>d__);
			return <NormalResetToViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031B2A RID: 203562 RVA: 0x00C62400 File Offset: 0x00C60600
		[NullableContext(2)]
		public void CloseHistoryRingView(EUiViewName viewName, Action<bool> callback = null)
		{
			this.CloseHistoryRingViewAsync(viewName).ContinueWith(delegate()
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiManager;
				ELogAuthor author = ELogAuthor.TL;
				string message = "[CloseHistoryRingView]流程执行成功";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", viewName);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				Action<bool> callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2(true);
			}).Forget(delegate(Exception exception)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiManager;
				ELogAuthor author = ELogAuthor.TL;
				string message = "[CloseHistoryRingView]流程执行异常";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", viewName);
				instance.ErrorWithStack(module, author, message, exception, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				Action<bool> callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2(false);
			}, true);
		}

		// Token: 0x06031B2B RID: 203563 RVA: 0x00C62450 File Offset: 0x00C60650
		public UniTask CloseHistoryRingViewAsync(EUiViewName viewName)
		{
			UiManager.<CloseHistoryRingViewAsync>d__49 <CloseHistoryRingViewAsync>d__;
			<CloseHistoryRingViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CloseHistoryRingViewAsync>d__.<>4__this = this;
			<CloseHistoryRingViewAsync>d__.viewName = viewName;
			<CloseHistoryRingViewAsync>d__.<>1__state = -1;
			<CloseHistoryRingViewAsync>d__.<>t__builder.Start<UiManager.<CloseHistoryRingViewAsync>d__49>(ref <CloseHistoryRingViewAsync>d__);
			return <CloseHistoryRingViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031B2C RID: 203564 RVA: 0x00C6249B File Offset: 0x00C6069B
		private void ShowFloatTips()
		{
			Singleton<UiModel>.Instance.IsInMainView = true;
			((UiViewFloatContainer)this.Containers[ELayerType.Float]).ShowFloatTips();
			Singleton<EventSystem>.Instance.Emit(EEventName.ShowFloatTips);
		}

		// Token: 0x06031B2D RID: 203565 RVA: 0x00C624D2 File Offset: 0x00C606D2
		private void HideFloatTips()
		{
			Singleton<UiModel>.Instance.IsInMainView = false;
			((UiViewFloatContainer)this.Containers[ELayerType.Float]).HideFloatTips();
		}

		// Token: 0x06031B2E RID: 203566 RVA: 0x00C624FC File Offset: 0x00C606FC
		public void AddTickView(IPanelTickInterface view)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiManager;
			ELogAuthor author = ELogAuthor.TL;
			string message = "[AddTickView] 添加界面Tick";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("name", view.GetType().Name);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.TickViewSet.Add(view);
		}

		// Token: 0x06031B2F RID: 203567 RVA: 0x00C6254C File Offset: 0x00C6074C
		public void RemoveTickView(IPanelTickInterface view)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiManager;
			ELogAuthor author = ELogAuthor.TL;
			string message = "[RemoveTickView] 移除界面Tick";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("name", view.GetType().Name);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.TickViewSet.Remove(view);
		}

		// Token: 0x06031B30 RID: 203568 RVA: 0x00C6259C File Offset: 0x00C6079C
		[NullableContext(2)]
		private UiViewBase RegisterView(EUiViewName name, object param = null, ELayerType? layer = null)
		{
			UiViewInfo uiViewInfo = Singleton<UiConfig>.Instance.TryGetViewInfo(name);
			if (uiViewInfo == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiManager;
				ELogAuthor author = ELogAuthor.TL;
				string message = "界面信息viewInfo获取失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("name", name);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			if (uiViewInfo != null)
			{
				uiViewInfo.SetContainerLayerType(layer);
			}
			UiViewBase uiViewBase = uiViewInfo.Ctor(uiViewInfo);
			if (uiViewBase is IUiViewResource)
			{
				Singleton<UiConfig>.Instance.RewritePath(uiViewInfo, uiViewBase as IUiViewResource, param);
			}
			if (uiViewBase is IExtraUiPopFrameType)
			{
				Singleton<UiConfig>.Instance.RewritePopFrameType(uiViewInfo, uiViewBase as IExtraUiPopFrameType, param);
			}
			uiViewBase.InitRootActorLoadInfo();
			if (uiViewInfo.CommonPopBg > (EUiBehaviourPopType)0)
			{
				UiPopFrameView uiPopFrameView = new UiPopFrameView(uiViewInfo);
				uiViewBase.ChildPopView = uiPopFrameView;
				uiViewBase.AddChild(uiPopFrameView);
			}
			this.AddView(uiViewBase);
			Singleton<EventSystem>.Instance.Emit<UiViewBase>(EEventName.CreateViewInstance, uiViewBase);
			return uiViewBase;
		}

		// Token: 0x06031B31 RID: 203569 RVA: 0x00C62670 File Offset: 0x00C60870
		[NullableContext(2)]
		private UiViewBase PickViewByName(EUiViewName viewName)
		{
			HashSet<UiViewBase> valueOrDefault = this.NameToViewSetMap.GetValueOrDefault(viewName);
			if (valueOrDefault == null)
			{
				return null;
			}
			UiViewBase uiViewBase = null;
			foreach (UiViewBase uiViewBase2 in valueOrDefault)
			{
				if (uiViewBase == null || uiViewBase2.GetViewId() > uiViewBase.GetViewId())
				{
					uiViewBase = uiViewBase2;
				}
			}
			return uiViewBase;
		}

		// Token: 0x06031B32 RID: 203570 RVA: 0x00C626E0 File Offset: 0x00C608E0
		private void StartFloatWaitingNormalView()
		{
			((UiViewFloatContainer)this.Containers[ELayerType.Float]).StartWaitingNormalView();
		}

		// Token: 0x06031B33 RID: 203571 RVA: 0x00C626FC File Offset: 0x00C608FC
		public UniTask Initialize()
		{
			UiManager.<Initialize>d__57 <Initialize>d__;
			<Initialize>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Initialize>d__.<>4__this = this;
			<Initialize>d__.<>1__state = -1;
			<Initialize>d__.<>t__builder.Start<UiManager.<Initialize>d__57>(ref <Initialize>d__);
			return <Initialize>d__.<>t__builder.Task;
		}

		// Token: 0x06031B34 RID: 203572 RVA: 0x00C62740 File Offset: 0x00C60940
		public void LockOpen()
		{
			Singleton<LguiUtil>.Instance.SetActorIsPermanent(Singleton<UiLayer>.Instance.UiRoot, true, true);
			this.OpenLock = true;
			Singleton<Log>.Instance.Info(ELogModule.UiManager, ELogAuthor.TL, "[UIManager.UnLockOpen] 禁止打开界面", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x06031B35 RID: 203573 RVA: 0x00C6278C File Offset: 0x00C6098C
		public void UnLockOpen()
		{
			this.OpenLock = false;
			Singleton<Log>.Instance.Info(ELogModule.UiManager, ELogAuthor.TL, "[UIManager.UnLockOpen] 恢复打开界面", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x17008486 RID: 33926
		// (get) Token: 0x06031B36 RID: 203574 RVA: 0x00C627BF File Offset: 0x00C609BF
		public bool IsLockOpen
		{
			get
			{
				return this.OpenLock;
			}
		}

		// Token: 0x06031B37 RID: 203575 RVA: 0x00C627C8 File Offset: 0x00C609C8
		[NullableContext(2)]
		private unsafe bool CanOpenView(EUiViewName viewName, bool isMultipleView = false, object param = null)
		{
			if (GlobalData.IsSceneClearing && !Singleton<UiConfig>.Instance.CanOpenWhileClearSceneViewNameSet.Contains(viewName))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiManager;
				ELogAuthor author = ELogAuthor.TL;
				string message = "[CanOpenView] 退出场景清理时不允许打开UI界面";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", viewName);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			if (this.OpenLock)
			{
				Singleton<Log>.Instance.Warn(ELogModule.UiManager, ELogAuthor.TL, "全局锁定了界面打开!", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			UiViewInfo uiViewInfo = Singleton<UiConfig>.Instance.TryGetViewInfo(viewName);
			if (uiViewInfo == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.UiManager;
				ELogAuthor author2 = ELogAuthor.TL;
				string message2 = "界面信息viewInfo获取失败";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("name", viewName);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return false;
			}
			if (!isMultipleView && (uiViewInfo.Type & ELayerType.Float) == (ELayerType)0)
			{
				if (this.IsViewOpen(viewName))
				{
					string item = "同名界面已经打开";
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module3 = ELogModule.UiManager;
					ELogAuthor author3 = ELogAuthor.TL;
					string message3 = "[多开界面检查]打开界面失败";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("name", viewName);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("reason", item);
					instance3.Warn(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					return false;
				}
				if (this.IsViewCreating(viewName))
				{
					string item2 = "同名界面正在创建中";
					Log instance4 = Singleton<Log>.Instance;
					ELogModule module4 = ELogModule.UiManager;
					ELogAuthor author4 = ELogAuthor.TL;
					string message4 = "[多开界面检查]打开界面失败";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("name", viewName);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("reason", item2);
					instance4.Warn(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
					return false;
				}
			}
			return this.CheckOpenViewCheckFunctions(viewName, false, param) && this.CheckOpenViewCheckFunctions(viewName, true, param);
		}

		// Token: 0x06031B38 RID: 203576 RVA: 0x00C62998 File Offset: 0x00C60B98
		public void AddOpenViewCheckFunction(EUiViewName viewName, Func<EUiViewName, object, bool> func, string reason)
		{
			Dictionary<Func<EUiViewName, object, bool>, string> dictionary;
			if (!this.OpenViewCheckFunctionsMap.TryGetValue(viewName, out dictionary))
			{
				dictionary = new Dictionary<Func<EUiViewName, object, bool>, string>();
				this.OpenViewCheckFunctionsMap[viewName] = dictionary;
			}
			dictionary[func] = reason;
		}

		// Token: 0x06031B39 RID: 203577 RVA: 0x00C629D0 File Offset: 0x00C60BD0
		public void RemoveOpenViewCheckFunction(EUiViewName viewName, Func<EUiViewName, object, bool> func)
		{
			Dictionary<Func<EUiViewName, object, bool>, string> dictionary;
			if (!this.OpenViewCheckFunctionsMap.TryGetValue(viewName, out dictionary))
			{
				return;
			}
			dictionary.Remove(func);
		}

		// Token: 0x06031B3A RID: 203578 RVA: 0x00C629F8 File Offset: 0x00C60BF8
		[NullableContext(2)]
		private unsafe bool CheckOpenViewCheckFunctions(EUiViewName viewName, bool isAll = false, object param = null)
		{
			Dictionary<Func<EUiViewName, object, bool>, string> dictionary;
			if (!this.OpenViewCheckFunctionsMap.TryGetValue(isAll ? EUiViewName.All : viewName, out dictionary) || dictionary.Count == 0)
			{
				return true;
			}
			foreach (KeyValuePair<Func<EUiViewName, object, bool>, string> keyValuePair in dictionary)
			{
				Func<EUiViewName, object, bool> key = keyValuePair.Key;
				string value = keyValuePair.Value;
				try
				{
					if (!key(viewName, param))
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.UiManager;
						ELogAuthor author = ELogAuthor.TL;
						string message = "[自定义检查]打开界面失败";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("name", viewName);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("reason", value);
						instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
						return false;
					}
				}
				catch (Exception item)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.UiManager;
					ELogAuthor author2 = ELogAuthor.TL;
					string message2 = "[自定义检查]检查函数抛出异常";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Exception", item);
					instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					if (!isAll)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06031B3B RID: 203579 RVA: 0x00C62B30 File Offset: 0x00C60D30
		[NullableContext(2)]
		public UiViewBase GetViewByName(EUiViewName viewName)
		{
			return this.PickViewByName(viewName);
		}

		// Token: 0x06031B3C RID: 203580 RVA: 0x00C62B3C File Offset: 0x00C60D3C
		[NullableContext(2)]
		public UiViewBase GetView(int viewId)
		{
			UiViewBase result;
			this.IdToViewMap.TryGetValue(viewId, out result);
			return result;
		}

		// Token: 0x06031B3D RID: 203581 RVA: 0x00C62B5C File Offset: 0x00C60D5C
		private void AddView(UiViewBase view)
		{
			int viewId = view.GetViewId();
			this.IdToViewMap[viewId] = view;
			EUiViewName name = view.ViewInfo.Name;
			this.NameToViewSetMap.TryAdd(name, new HashSet<UiViewBase>());
			HashSet<UiViewBase> hashSet;
			if (this.NameToViewSetMap.TryGetValue(name, out hashSet))
			{
				hashSet.Add(view);
			}
		}

		// Token: 0x06031B3E RID: 203582 RVA: 0x00C62BB4 File Offset: 0x00C60DB4
		public void RemoveView(int viewId)
		{
			UiViewBase uiViewBase;
			if (!this.IdToViewMap.TryGetValue(viewId, out uiViewBase))
			{
				return;
			}
			EUiViewName name = uiViewBase.ViewInfo.Name;
			this.IdToViewMap.Remove(viewId);
			HashSet<UiViewBase> hashSet;
			if (this.NameToViewSetMap.TryGetValue(name, out hashSet))
			{
				hashSet.Remove(uiViewBase);
				if (hashSet.Count == 0)
				{
					this.NameToViewSetMap.Remove(name);
				}
			}
		}

		// Token: 0x06031B3F RID: 203583 RVA: 0x00C62C18 File Offset: 0x00C60E18
		public void RefreshByPureModeChanged()
		{
			UiViewContainer uiViewContainer;
			this.Containers.TryGetValue(ELayerType.Float, out uiViewContainer);
			UiViewFloatContainer uiViewFloatContainer = uiViewContainer as UiViewFloatContainer;
			if (uiViewFloatContainer != null)
			{
				uiViewFloatContainer.RefreshByPureModeChanged();
			}
		}

		// Token: 0x06031B40 RID: 203584 RVA: 0x00C62C48 File Offset: 0x00C60E48
		public void GmClearFloatContainer()
		{
			(this.Containers[ELayerType.Float] as UiViewFloatContainer).ClearContainer(false);
		}

		// Token: 0x06031B41 RID: 203585 RVA: 0x00C62C68 File Offset: 0x00C60E68
		public void Tick(float delta)
		{
			this.TempTickView.Clear();
			this.TempTickView.AddRange(this.TickViewSet);
			foreach (IPanelTickInterface panelTickInterface in this.TempTickView)
			{
				panelTickInterface.Tick(delta);
			}
			Singleton<UiActorPool>.Instance.Tick(delta);
		}

		// Token: 0x06031B42 RID: 203586 RVA: 0x00C62CE0 File Offset: 0x00C60EE0
		public void AfterTick(float delta)
		{
			foreach (IPanelTickInterface panelTickInterface in this.TickViewSet)
			{
				panelTickInterface.AfterTick(delta);
			}
		}

		// Token: 0x06031B43 RID: 203587 RVA: 0x00C62D34 File Offset: 0x00C60F34
		public UniTask PauseNormalContainer(Func<UniTask> createPlotView, Func<UniTask> showPlotView)
		{
			UiManager.<PauseNormalContainer>d__76 <PauseNormalContainer>d__;
			<PauseNormalContainer>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PauseNormalContainer>d__.<>4__this = this;
			<PauseNormalContainer>d__.createPlotView = createPlotView;
			<PauseNormalContainer>d__.showPlotView = showPlotView;
			<PauseNormalContainer>d__.<>1__state = -1;
			<PauseNormalContainer>d__.<>t__builder.Start<UiManager.<PauseNormalContainer>d__76>(ref <PauseNormalContainer>d__);
			return <PauseNormalContainer>d__.<>t__builder.Task;
		}

		// Token: 0x06031B44 RID: 203588 RVA: 0x00C62D88 File Offset: 0x00C60F88
		public UniTask ResumeNormalContainer(Func<UniTask> destroyOtherView = null)
		{
			UiManager.<ResumeNormalContainer>d__77 <ResumeNormalContainer>d__;
			<ResumeNormalContainer>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ResumeNormalContainer>d__.<>4__this = this;
			<ResumeNormalContainer>d__.destroyOtherView = destroyOtherView;
			<ResumeNormalContainer>d__.<>1__state = -1;
			<ResumeNormalContainer>d__.<>t__builder.Start<UiManager.<ResumeNormalContainer>d__77>(ref <ResumeNormalContainer>d__);
			return <ResumeNormalContainer>d__.<>t__builder.Task;
		}

		// Token: 0x06031B45 RID: 203589 RVA: 0x00C62DD4 File Offset: 0x00C60FD4
		public void ResumeNormalContainerInClear()
		{
			Singleton<Log>.Instance.Info(ELogModule.UiManager, ELogAuthor.XXJ, "[UIManager.ClearAsync]ResumeNormalContainerInClear", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<UiTimeDilation>.Instance.RestoreSaveData();
			Singleton<UiLayer>.Instance.SetLayerActive(ELayerType.Normal, true);
			((UiViewStackContainer)this.Containers[ELayerType.Normal]).TryUnlock();
		}

		// Token: 0x06031B46 RID: 203590 RVA: 0x00C62E2C File Offset: 0x00C6102C
		public bool CheckIfCanShowPlotView()
		{
			UiViewBase topView = Singleton<UiModel>.Instance.GetTopView(ELayerType.Normal);
			if (topView != null)
			{
				EUiViewName name = topView.ViewInfo.Name;
				return Singleton<UiModel>.Instance.CanShowPlotViewWhiteList.Contains(name) && this.IsViewShow(name);
			}
			return false;
		}

		// Token: 0x06031B47 RID: 203591 RVA: 0x00C62E71 File Offset: 0x00C61071
		public bool IsNormalContainerEmpty()
		{
			return ((UiViewStackContainer)this.Containers[ELayerType.Normal]).IsViewPendingListEmpty();
		}

		// Token: 0x06031B48 RID: 203592 RVA: 0x00C62E89 File Offset: 0x00C61089
		public void CloseAllPopView()
		{
			((UiViewListContainer)this.Containers[ELayerType.Pop]).CloseAllView();
		}

		// Token: 0x06031B49 RID: 203593 RVA: 0x00C62EA2 File Offset: 0x00C610A2
		public UniTask ContinueNormalContainer(Func<UniTask> destroyOtherView = null)
		{
			return this.ResumeNormalContainer(destroyOtherView);
		}

		// Token: 0x06031B4A RID: 203594 RVA: 0x00C62EAC File Offset: 0x00C610AC
		private UniTask ClearNonNormalAndPlotContainerView(bool isSeamlessTravel)
		{
			UiManager.<ClearNonNormalAndPlotContainerView>d__83 <ClearNonNormalAndPlotContainerView>d__;
			<ClearNonNormalAndPlotContainerView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ClearNonNormalAndPlotContainerView>d__.<>4__this = this;
			<ClearNonNormalAndPlotContainerView>d__.isSeamlessTravel = isSeamlessTravel;
			<ClearNonNormalAndPlotContainerView>d__.<>1__state = -1;
			<ClearNonNormalAndPlotContainerView>d__.<>t__builder.Start<UiManager.<ClearNonNormalAndPlotContainerView>d__83>(ref <ClearNonNormalAndPlotContainerView>d__);
			return <ClearNonNormalAndPlotContainerView>d__.<>t__builder.Task;
		}

		// Token: 0x06031B4B RID: 203595 RVA: 0x00C62EF8 File Offset: 0x00C610F8
		private UniTask ClearNormalAndPlotContainerView(bool isSeamlessTravel)
		{
			UiManager.<ClearNormalAndPlotContainerView>d__84 <ClearNormalAndPlotContainerView>d__;
			<ClearNormalAndPlotContainerView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ClearNormalAndPlotContainerView>d__.<>4__this = this;
			<ClearNormalAndPlotContainerView>d__.isSeamlessTravel = isSeamlessTravel;
			<ClearNormalAndPlotContainerView>d__.<>1__state = -1;
			<ClearNormalAndPlotContainerView>d__.<>t__builder.Start<UiManager.<ClearNormalAndPlotContainerView>d__84>(ref <ClearNormalAndPlotContainerView>d__);
			return <ClearNormalAndPlotContainerView>d__.<>t__builder.Task;
		}

		// Token: 0x06031B4C RID: 203596 RVA: 0x00C62F44 File Offset: 0x00C61144
		private UniTask ResumeNormalViewInClear(bool isSeamlessTravel)
		{
			UiManager.<ResumeNormalViewInClear>d__85 <ResumeNormalViewInClear>d__;
			<ResumeNormalViewInClear>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ResumeNormalViewInClear>d__.<>4__this = this;
			<ResumeNormalViewInClear>d__.isSeamlessTravel = isSeamlessTravel;
			<ResumeNormalViewInClear>d__.<>1__state = -1;
			<ResumeNormalViewInClear>d__.<>t__builder.Start<UiManager.<ResumeNormalViewInClear>d__85>(ref <ResumeNormalViewInClear>d__);
			return <ResumeNormalViewInClear>d__.<>t__builder.Task;
		}

		// Token: 0x06031B4D RID: 203597 RVA: 0x00C62F90 File Offset: 0x00C61190
		private void ClearUiCameraAnimation()
		{
			Singleton<Log>.Instance.Info(ELogModule.UiManager, ELogAuthor.XXJ, "[UIManager.ClearAsync] ClearUiCameraAnimation", default(ReadOnlySpan<ValueTuple<string, object>>));
			try
			{
				Singleton<UiCameraAnimationManager>.Instance.ClearDisplay();
			}
			catch (Exception item)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Game;
				ELogAuthor author = ELogAuthor.LFJW;
				string message = "[Game.LeaveLevel] 调用UiCameraAnimationManager.ResetUiCameraAnimationManager异常。";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Exception", item);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}

		// Token: 0x06031B4E RID: 203598 RVA: 0x00C63004 File Offset: 0x00C61204
		public UniTask ClearAsync(bool isSeamlessTravel)
		{
			UiManager.<ClearAsync>d__87 <ClearAsync>d__;
			<ClearAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ClearAsync>d__.<>4__this = this;
			<ClearAsync>d__.isSeamlessTravel = isSeamlessTravel;
			<ClearAsync>d__.<>1__state = -1;
			<ClearAsync>d__.<>t__builder.Start<UiManager.<ClearAsync>d__87>(ref <ClearAsync>d__);
			return <ClearAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031B4F RID: 203599 RVA: 0x00C63050 File Offset: 0x00C61250
		public unsafe void CheckUiPanelBindValid()
		{
			List<Type> list = (from t in Assembly.GetExecutingAssembly().GetTypes()
			where t.IsSubclassOf(typeof(UiPanelBase))
			where !t.IsAbstract
			where !t.ContainsGenericParameters
			select t).ToList<Type>();
			MethodInfo method = typeof(UiPanelBase).GetMethod("OnRegisterComponent", BindingFlags.Instance | BindingFlags.NonPublic);
			FieldInfo field = typeof(UiPanelBase).GetField("ComponentRegisterInfos", BindingFlags.Instance | BindingFlags.NonPublic);
			FieldInfo field2 = typeof(UiPanelBase).GetField("BtnBindInfo", BindingFlags.Instance | BindingFlags.NonPublic);
			UiViewInfo uiViewInfo = Singleton<UiConfig>.Instance.TryGetViewInfo(EUiViewName.AdviceView);
			if (method == null || field == null || field2 == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.UiManager, ELogAuthor.BB, "[UIManager.CheckUiPanelBindValid] 检查UI面板绑定是否有效失败，未找到OnRegisterComponent方法或ComponentRegisterInfos字段或BtnBindInfo字段", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			foreach (Type type in list)
			{
				try
				{
					UiPanelBase uiPanelBase = null;
					if (type.IsSubclassOf(typeof(UiViewBase)))
					{
						uiPanelBase = (UiPanelBase)Activator.CreateInstance(type, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new object[]
						{
							uiViewInfo
						}, null);
					}
					else
					{
						ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
						if (constructors.Length == 0)
						{
							Singleton<Log>.Instance.Error(ELogModule.UiManager, ELogAuthor.BB, "[UIManager.CheckUiPanelBindValid] 检查UI面板绑定是否有效失败，类型" + type.Name + "未找到无参构造函数", default(ReadOnlySpan<ValueTuple<string, object>>));
						}
						ConstructorInfo[] array = constructors;
						for (int i = 0; i < array.Length; i++)
						{
							ParameterInfo[] parameters = array[i].GetParameters();
							if (parameters.Length == 0)
							{
								uiPanelBase = (UiPanelBase)Activator.CreateInstance(type, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, null, null);
								break;
							}
							if (parameters.Length == 1)
							{
								if (parameters[0].ParameterType == typeof(int))
								{
									uiPanelBase = (UiPanelBase)Activator.CreateInstance(type, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new object[]
									{
										0
									}, null);
									break;
								}
								if (parameters[0].ParameterType == typeof(UUIItem))
								{
									uiPanelBase = (UiPanelBase)Activator.CreateInstance(type, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new object[]
									{
										Singleton<UiLayer>.Instance.UiRootItem
									}, null);
									break;
								}
								if (parameters[0].ParameterType == typeof(AActor))
								{
									uiPanelBase = (UiPanelBase)Activator.CreateInstance(type, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new object[]
									{
										Singleton<UiLayer>.Instance.UiRoot
									}, null);
									break;
								}
							}
							else
							{
								string value = string.Join(", ", from p in parameters
								select p.ParameterType.Name + " " + p.Name);
								Log instance = Singleton<Log>.Instance;
								ELogModule module = ELogModule.UiManager;
								ELogAuthor author = ELogAuthor.BB;
								DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(46, 2);
								defaultInterpolatedStringHandler.AppendLiteral("[CheckUiPanelBindValidLog] 构造函数参数不匹配，类型");
								defaultInterpolatedStringHandler.AppendFormatted(type.Name);
								defaultInterpolatedStringHandler.AppendLiteral(" 构造函数(");
								defaultInterpolatedStringHandler.AppendFormatted(value);
								defaultInterpolatedStringHandler.AppendLiteral(")");
								instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
							}
						}
					}
					if (uiPanelBase != null)
					{
						method.Invoke(uiPanelBase, null);
						List<ValueTuple<int, Type>> list2 = (List<ValueTuple<int, Type>>)field.GetValue(uiPanelBase);
						foreach (ValueTuple<int, Delegate> valueTuple in ((List<ValueTuple<int, Delegate>>)field2.GetValue(uiPanelBase)))
						{
							int item = valueTuple.Item1;
							Delegate item2 = valueTuple.Item2;
							Type left = typeof(UUIButtonComponent);
							foreach (ValueTuple<int, Type> valueTuple2 in list2)
							{
								if (valueTuple2.Item1 == item)
								{
									left = valueTuple2.Item2;
									break;
								}
							}
							if (left == typeof(UUIButtonComponent))
							{
								this.CheckUiButtonBindValid(item2, item, typeof(void), uiPanelBase);
							}
							else if (left == typeof(UUIToggleComponent))
							{
								this.CheckOneParamDelegateBindValid(item2, item, typeof(bool), uiPanelBase);
							}
							else if (left == typeof(UUIExtendToggle))
							{
								this.CheckOneParamDelegateBindValid(item2, item, typeof(EToggleState), uiPanelBase);
							}
							else if (left == typeof(UUISliderComponent))
							{
								this.CheckOneParamDelegateBindValid(item2, item, typeof(float), uiPanelBase);
							}
							else if (left == typeof(UUITextInputComponent))
							{
								this.CheckOneParamDelegateBindValid(item2, item, typeof(bool), uiPanelBase);
							}
						}
					}
				}
				catch (Exception item3)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.UiManager;
					ELogAuthor author2 = ELogAuthor.BB;
					string message = "[CheckUiPanelBindValidLog] Exception";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PanelType", type.Name);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Exception", item3);
					instance2.Error(module2, author2, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
			}
		}

		// Token: 0x06031B50 RID: 203600 RVA: 0x00C63620 File Offset: 0x00C61820
		private unsafe void CheckUiButtonBindValid(Delegate delegateType, int componentId, Type paramType, UiPanelBase panel)
		{
			Type type = delegateType.GetType();
			if (type == typeof(Action))
			{
				return;
			}
			MethodInfo method = type.GetMethod("Invoke");
			if (method == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiManager;
				ELogAuthor author = ELogAuthor.BB;
				string message = "[CheckUiPanelBindValidLog] 未找到Invoke方法";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PanelType", panel.GetType().Name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ComponentId", componentId);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			if (method.GetParameters().Length != 0)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.UiManager;
				ELogAuthor author2 = ELogAuthor.BB;
				string message2 = "[CheckUiPanelBindValidLog] Invoke方法参数数量不为0";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("PanelType", panel.GetType().Name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("ComponentId", componentId);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			}
		}

		// Token: 0x06031B51 RID: 203601 RVA: 0x00C63734 File Offset: 0x00C61934
		private unsafe void CheckOneParamDelegateBindValid(Delegate delegateType, int componentId, Type paramType, UiPanelBase panel)
		{
			MethodInfo method = delegateType.GetType().GetMethod("Invoke");
			if (method == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiManager;
				ELogAuthor author = ELogAuthor.BB;
				string message = "[CheckUiPanelBindValidLog] 未找到Invoke方法";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PanelType", panel.GetType().Name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ComponentId", componentId);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			ParameterInfo[] parameters = method.GetParameters();
			if (parameters.Length != 1)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.UiManager;
				ELogAuthor author2 = ELogAuthor.BB;
				string message2 = "[CheckUiPanelBindValidLog] Invoke方法参数数量不为1";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("PanelType", panel.GetType().Name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("ComponentId", componentId);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				return;
			}
			if (parameters[0].ParameterType != paramType)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.UiManager;
				ELogAuthor author3 = ELogAuthor.BB;
				string message3 = "[CheckUiPanelBindValidLog] Invoke方法参数类型不为指定类型";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("PanelType", panel.GetType().Name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("ParamType", paramType.Name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("ComponentId", componentId);
				instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
			}
		}

		// Token: 0x0401CE98 RID: 118424
		private EInitState InitState;

		// Token: 0x0401CE99 RID: 118425
		public bool IsClear;

		// Token: 0x0401CE9A RID: 118426
		private readonly Dictionary<ELayerType, UiViewContainer> Containers = new Dictionary<ELayerType, UiViewContainer>();

		// Token: 0x0401CE9B RID: 118427
		[Nullable(new byte[]
		{
			1,
			1,
			1,
			2,
			1
		})]
		private readonly Dictionary<EUiViewName, Dictionary<Func<EUiViewName, object, bool>, string>> OpenViewCheckFunctionsMap = new Dictionary<EUiViewName, Dictionary<Func<EUiViewName, object, bool>, string>>();

		// Token: 0x0401CE9C RID: 118428
		private readonly Stat StatsObject = Stat.Create("UiManger", "", "");

		// Token: 0x0401CE9D RID: 118429
		private readonly Dictionary<int, UiViewBase> IdToViewMap = new Dictionary<int, UiViewBase>();

		// Token: 0x0401CE9E RID: 118430
		private readonly Dictionary<EUiViewName, HashSet<UiViewBase>> NameToViewSetMap = new Dictionary<EUiViewName, HashSet<UiViewBase>>();

		// Token: 0x0401CE9F RID: 118431
		private readonly HashSet<IPanelTickInterface> TickViewSet = new HashSet<IPanelTickInterface>();

		// Token: 0x0401CEA0 RID: 118432
		private readonly Dictionary<int, UiViewBase> PreOpeningViewMap = new Dictionary<int, UiViewBase>();

		// Token: 0x0401CEA1 RID: 118433
		private EUiViewName? LastNormalTopViewName;

		// Token: 0x0401CEA2 RID: 118434
		private int CsRequestId;

		// Token: 0x0401CEA3 RID: 118435
		[Nullable(new byte[]
		{
			1,
			2
		})]
		private Dictionary<int, object> CsRequestParamMap = new Dictionary<int, object>();

		// Token: 0x0401CEA4 RID: 118436
		[Nullable(new byte[]
		{
			1,
			2
		})]
		private Dictionary<int, TOpenViewCallBack> CsRequestCallbackMap = new Dictionary<int, TOpenViewCallBack>();

		// Token: 0x0401CEA5 RID: 118437
		private Dictionary<int, bool> CsRequestNeedOpenInSharpMap = new Dictionary<int, bool>();

		// Token: 0x0401CEA6 RID: 118438
		private bool OpenLock;

		// Token: 0x0401CEA7 RID: 118439
		private List<IPanelTickInterface> TempTickView = new List<IPanelTickInterface>();
	}
}
