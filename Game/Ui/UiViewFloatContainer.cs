using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.BattleUi;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049D3 RID: 18899
	[NullableContext(1)]
	[Nullable(0)]
	public class UiViewFloatContainer : UiViewContainer
	{
		// Token: 0x0603170F RID: 202511 RVA: 0x00C4C990 File Offset: 0x00C4AB90
		public UiViewFloatContainer(Dictionary<string, FloatViewQueue> floatQueueMap, Dictionary<string, UiViewBase> showViewMap, Dictionary<string, UiViewBase> hideViewMap)
		{
			this.FloatQueueMap = floatQueueMap;
			this.ShowViewMap = showViewMap;
			this.HideViewMap = hideViewMap;
		}

		// Token: 0x06031710 RID: 202512 RVA: 0x00C4C9D0 File Offset: 0x00C4ABD0
		[NullableContext(0)]
		public override UniTask<bool> OpenViewAsync([Nullable(1)] UiViewBase view)
		{
			UiViewFloatContainer.<OpenViewAsync>d__4 <OpenViewAsync>d__;
			<OpenViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenViewAsync>d__.<>4__this = this;
			<OpenViewAsync>d__.view = view;
			<OpenViewAsync>d__.<>1__state = -1;
			<OpenViewAsync>d__.<>t__builder.Start<UiViewFloatContainer.<OpenViewAsync>d__4>(ref <OpenViewAsync>d__);
			return <OpenViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031711 RID: 202513 RVA: 0x00C4CA1C File Offset: 0x00C4AC1C
		public override UniTask CloseViewAsync(UiViewBase view)
		{
			UiViewFloatContainer.<CloseViewAsync>d__5 <CloseViewAsync>d__;
			<CloseViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CloseViewAsync>d__.<>4__this = this;
			<CloseViewAsync>d__.view = view;
			<CloseViewAsync>d__.<>1__state = -1;
			<CloseViewAsync>d__.<>t__builder.Start<UiViewFloatContainer.<CloseViewAsync>d__5>(ref <CloseViewAsync>d__);
			return <CloseViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031712 RID: 202514 RVA: 0x00C4CA68 File Offset: 0x00C4AC68
		[NullableContext(0)]
		private UniTask<bool> CheckInHandle([Nullable(1)] string area, bool onlyShowInMain, EUiViewName name, int? viewId)
		{
			UiViewFloatContainer.<CheckInHandle>d__6 <CheckInHandle>d__;
			<CheckInHandle>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<CheckInHandle>d__.<>4__this = this;
			<CheckInHandle>d__.area = area;
			<CheckInHandle>d__.onlyShowInMain = onlyShowInMain;
			<CheckInHandle>d__.name = name;
			<CheckInHandle>d__.viewId = viewId;
			<CheckInHandle>d__.<>1__state = -1;
			<CheckInHandle>d__.<>t__builder.Start<UiViewFloatContainer.<CheckInHandle>d__6>(ref <CheckInHandle>d__);
			return <CheckInHandle>d__.<>t__builder.Task;
		}

		// Token: 0x06031713 RID: 202515 RVA: 0x00C4CACC File Offset: 0x00C4ACCC
		private unsafe bool CheckInHide(string area, EUiViewName name, int? viewId)
		{
			UiViewBase uiViewBase;
			this.HideViewMap.TryGetValue(area, out uiViewBase);
			if (uiViewBase == null)
			{
				return false;
			}
			if (!this.CheckView(uiViewBase, name, viewId))
			{
				return false;
			}
			uiViewBase.Destroy(null);
			this.HideViewMap.Remove(area);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiFloatContainer;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "界面关闭成功,隐藏中关闭";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("区域", area);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("当前界面", name);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return true;
		}

		// Token: 0x06031714 RID: 202516 RVA: 0x00C4CB6C File Offset: 0x00C4AD6C
		private unsafe bool CheckView(UiViewBase view, EUiViewName name, int? viewId)
		{
			if (view.ViewInfo.Name != name || (viewId != null && view.GetViewId() != viewId.Value))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiFloatContainer;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "界面检查失败";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("view.Info.Name", view.ViewInfo.Name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("name", name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("view.GetViewId()", view.GetViewId());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("viewId", viewId);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
				return false;
			}
			return true;
		}

		// Token: 0x06031715 RID: 202517 RVA: 0x00C4CC58 File Offset: 0x00C4AE58
		[return: Nullable(0)]
		private UniTask<bool> CloseView(string area, UiViewBase view)
		{
			UiViewFloatContainer.<CloseView>d__9 <CloseView>d__;
			<CloseView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<CloseView>d__.<>4__this = this;
			<CloseView>d__.area = area;
			<CloseView>d__.view = view;
			<CloseView>d__.<>1__state = -1;
			<CloseView>d__.<>t__builder.Start<UiViewFloatContainer.<CloseView>d__9>(ref <CloseView>d__);
			return <CloseView>d__.<>t__builder.Task;
		}

		// Token: 0x06031716 RID: 202518 RVA: 0x00C4CCAB File Offset: 0x00C4AEAB
		private bool InStaggeredState(bool onlyShowInMain)
		{
			return onlyShowInMain && !Singleton<UiModel>.Instance.IsInMainView;
		}

		// Token: 0x06031717 RID: 202519 RVA: 0x00C4CCBF File Offset: 0x00C4AEBF
		private bool NeedWaitNormalQueue(UiFloatConfig config)
		{
			return config.IsWaitNormal && Singleton<UiModel>.Instance.InNormalQueue;
		}

		// Token: 0x06031718 RID: 202520 RVA: 0x00C4CCDC File Offset: 0x00C4AEDC
		private unsafe void HandleNextViewFromQueue(string areaType)
		{
			UiViewBase nextViewFromQueue = this.GetNextViewFromQueue(areaType);
			if (nextViewFromQueue != null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiFloatContainer;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "从队列中获取要显示的界面";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("区域", areaType);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("界面", nextViewFromQueue.ViewInfo.Name);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				this.RefreshParentUiItem(nextViewFromQueue);
				base.OpenViewImplementAsync(nextViewFromQueue);
			}
		}

		// Token: 0x06031719 RID: 202521 RVA: 0x00C4CD68 File Offset: 0x00C4AF68
		private UiViewBase GetNextViewFromQueue(string areaType)
		{
			FloatViewQueue floatViewQueue;
			if (!this.FloatQueueMap.TryGetValue(areaType, out floatViewQueue))
			{
				this.ShowViewMap.Remove(areaType);
				return null;
			}
			IUiViewBase uiViewBase = floatViewQueue.Pop(Singleton<UiModel>.Instance.IsInMainView);
			if (uiViewBase == null)
			{
				this.ShowViewMap.Remove(areaType);
				return null;
			}
			if (floatViewQueue.Size <= 0)
			{
				this.FloatQueueMap.Remove(areaType);
			}
			this.ShowViewMap[areaType] = uiViewBase.ViewBase;
			return uiViewBase.ViewBase;
		}

		// Token: 0x0603171A RID: 202522 RVA: 0x00C4CDE8 File Offset: 0x00C4AFE8
		private unsafe bool PushToFloatQueue(UiFloatConfig config, UiViewBase view)
		{
			string text = StringUtils.IsEmpty(config.Area) ? view.ViewInfo.Name.ToString() : config.Area;
			if (this.ShowViewMap.ContainsKey(text) || this.InStaggeredState(config.OnlyShowInMain) || this.NeedWaitNormalQueue(config))
			{
				FloatViewQueue floatViewQueue;
				if (!this.FloatQueueMap.TryGetValue(text, out floatViewQueue))
				{
					floatViewQueue = new FloatViewQueue();
					this.FloatQueueMap[text] = floatViewQueue;
				}
				floatViewQueue.Push(view, config.Priority, config.OnlyShowInMain);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiFloatContainer;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "界面添加到区域队列中";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("区域", text);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("界面", view.ViewInfo.Name);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return true;
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.UiFloatContainer;
			ELogAuthor author2 = ELogAuthor.XXJ;
			string message2 = "界面直接在区域中显示";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("区域", text);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("界面", view.ViewInfo.Name);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			this.ShowViewMap[text] = view;
			return false;
		}

		// Token: 0x0603171B RID: 202523 RVA: 0x00C4CF64 File Offset: 0x00C4B164
		public override void ClearContainer(bool clearPermanent = false)
		{
			foreach (FloatViewQueue floatViewQueue in this.FloatQueueMap.Values)
			{
				floatViewQueue.Clear();
			}
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, UiViewBase> keyValuePair in this.ShowViewMap)
			{
				UiViewBase value = keyValuePair.Value;
				value.IsExistInLeaveLevel = true;
				if (!value.ViewInfo.IsPermanent)
				{
					base.TryCatchViewDestroyCompatible(value);
					list.Add(keyValuePair.Key);
				}
			}
			foreach (string key in list)
			{
				this.ShowViewMap.Remove(key);
			}
			list.Clear();
			foreach (KeyValuePair<string, UiViewBase> keyValuePair2 in this.HideViewMap)
			{
				UiViewBase value2 = keyValuePair2.Value;
				value2.IsExistInLeaveLevel = true;
				if (!value2.ViewInfo.IsPermanent)
				{
					base.TryCatchViewDestroyCompatible(value2);
					list.Add(keyValuePair2.Key);
				}
			}
			foreach (string key2 in list)
			{
				this.HideViewMap.Remove(key2);
			}
		}

		// Token: 0x0603171C RID: 202524 RVA: 0x00C4D130 File Offset: 0x00C4B330
		public void ShowFloatTips()
		{
			Singleton<Log>.Instance.Info(ELogModule.UiFloatContainer, ELogAuthor.XXJ, "主界面显示", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.RevertHideToShow();
			this.RevertFloatQueueToShow();
		}

		// Token: 0x0603171D RID: 202525 RVA: 0x00C4D168 File Offset: 0x00C4B368
		public void HideFloatTips()
		{
			Singleton<Log>.Instance.Info(ELogModule.UiFloatContainer, ELogAuthor.XXJ, "主界面隐藏", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.RevertShowToHide();
		}

		// Token: 0x0603171E RID: 202526 RVA: 0x00C4D19C File Offset: 0x00C4B39C
		public void StartWaitingNormalView()
		{
			foreach (string text in new List<string>(this.FloatQueueMap.Keys))
			{
				if (!this.ShowViewMap.ContainsKey(text))
				{
					this.HandleNextViewFromQueue(text);
				}
			}
		}

		// Token: 0x0603171F RID: 202527 RVA: 0x00C4D208 File Offset: 0x00C4B408
		private void RevertHideToShow()
		{
			foreach (string text in new List<string>(this.HideViewMap.Keys))
			{
				UiViewBase uiViewBase;
				this.HideViewMap.TryGetValue(text, out uiViewBase);
				this.HideViewMap.Remove(text);
				UiViewBase uiViewBase2;
				this.ShowViewMap.TryGetValue(text, out uiViewBase2);
				this.ShowViewMap[text] = uiViewBase;
				this.SetViewActive(uiViewBase, true);
				if (uiViewBase2 != null)
				{
					this.CloseView(text, uiViewBase2);
				}
			}
		}

		// Token: 0x06031720 RID: 202528 RVA: 0x00C4D2AC File Offset: 0x00C4B4AC
		private void RevertFloatQueueToShow()
		{
			foreach (string text in new List<string>(this.FloatQueueMap.Keys))
			{
				UiViewBase uiViewBase;
				this.ShowViewMap.TryGetValue(text, out uiViewBase);
				if (uiViewBase == null)
				{
					this.HandleNextViewFromQueue(text);
				}
			}
		}

		// Token: 0x06031721 RID: 202529 RVA: 0x00C4D31C File Offset: 0x00C4B51C
		private void RevertShowToHide()
		{
			foreach (string text in new List<string>(this.ShowViewMap.Keys))
			{
				UiViewBase uiViewBase;
				this.ShowViewMap.TryGetValue(text, out uiViewBase);
				if (this.InStaggeredState(ConfigBase<UiViewConfig>.Instance.GetUiFloatConfig(uiViewBase.ViewInfo.Name).Value.OnlyShowInMain))
				{
					this.HideViewMap[text] = uiViewBase;
					this.ShowViewMap.Remove(text);
					this.HandleNextViewFromQueue(text);
					this.SetViewActive(uiViewBase, false);
				}
			}
		}

		// Token: 0x06031722 RID: 202530 RVA: 0x00C4D3D8 File Offset: 0x00C4B5D8
		private unsafe void SetViewActive(UiViewBase view, bool bActive)
		{
			if (view.OpenPromise != null && view.OpenPromise.IsPending)
			{
				view.SetLoadingFinishOperation(delegate
				{
					this.HandleAsyncViewSequence(view, bActive);
				});
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiFloatContainer;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "界面在打开中";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("view", view.ViewInfo.Name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("bActive", bActive);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			this.HandleAsyncViewSequence(view, bActive);
		}

		// Token: 0x06031723 RID: 202531 RVA: 0x00C4D4C4 File Offset: 0x00C4B6C4
		private unsafe void HandleAsyncViewSequence(UiViewBase view, bool bActive)
		{
			if (bActive)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiFloatContainer;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "界面唤醒界面动画";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("view", view.ViewInfo.Name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("bActive", bActive);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				view.SetActive(true);
				return;
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.UiFloatContainer;
			ELogAuthor author2 = ELogAuthor.XXJ;
			string message2 = "界面暂停界面动画";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("view", view.ViewInfo.Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("bActive", bActive);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			view.SetActive(false);
		}

		// Token: 0x06031724 RID: 202532 RVA: 0x00C4D5B8 File Offset: 0x00C4B7B8
		public override UniTask PreOpenViewAsync(UiViewBase view)
		{
			UiViewFloatContainer.<PreOpenViewAsync>d__24 <PreOpenViewAsync>d__;
			<PreOpenViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PreOpenViewAsync>d__.view = view;
			<PreOpenViewAsync>d__.<>1__state = -1;
			<PreOpenViewAsync>d__.<>t__builder.Start<UiViewFloatContainer.<PreOpenViewAsync>d__24>(ref <PreOpenViewAsync>d__);
			return <PreOpenViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031725 RID: 202533 RVA: 0x00C4D5FC File Offset: 0x00C4B7FC
		public override UniTask OpenViewAfterPreOpenedAsync(UiViewBase view)
		{
			UiViewFloatContainer.<OpenViewAfterPreOpenedAsync>d__25 <OpenViewAfterPreOpenedAsync>d__;
			<OpenViewAfterPreOpenedAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenViewAfterPreOpenedAsync>d__.view = view;
			<OpenViewAfterPreOpenedAsync>d__.<>1__state = -1;
			<OpenViewAfterPreOpenedAsync>d__.<>t__builder.Start<UiViewFloatContainer.<OpenViewAfterPreOpenedAsync>d__25>(ref <OpenViewAfterPreOpenedAsync>d__);
			return <OpenViewAfterPreOpenedAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031726 RID: 202534 RVA: 0x00C4D640 File Offset: 0x00C4B840
		public void RefreshByPureModeChanged()
		{
			foreach (UiViewBase view in this.ShowViewMap.Values)
			{
				this.RefreshParentUiItem(view);
			}
			foreach (UiViewBase view2 in this.HideViewMap.Values)
			{
				this.RefreshParentUiItem(view2);
			}
		}

		// Token: 0x06031727 RID: 202535 RVA: 0x00C4D6E0 File Offset: 0x00C4B8E0
		public void RefreshParentUiItem(UiViewBase view)
		{
			UiFloatConfig? uiFloatConfig = ConfigBase<UiViewConfig>.Instance.GetUiFloatConfig(view.ViewInfo.Name);
			if (uiFloatConfig == null)
			{
				return;
			}
			if (uiFloatConfig.Value.OnlyShowInMain)
			{
				UUIItem uuiitem;
				if (uiFloatConfig.Value.HideInPureMode && ModelBase<BattleUiModel>.Instance.PureModeData != null && ModelBase<BattleUiModel>.Instance.PureModeData.IsOpen)
				{
					uuiitem = Singleton<UiLayer>.Instance.GetPureModeFloatUnit(ELayerType.BattleFloat);
				}
				else
				{
					uuiitem = Singleton<UiLayer>.Instance.GetFloatUnit(ELayerType.BattleFloat, uiFloatConfig.Value.RootItemIndex);
				}
				if (uuiitem != null)
				{
					view.SetParentUiItem(uuiitem);
				}
			}
		}

		// Token: 0x0401C605 RID: 116229
		private readonly Dictionary<string, FloatViewQueue> FloatQueueMap = new Dictionary<string, FloatViewQueue>();

		// Token: 0x0401C606 RID: 116230
		private readonly Dictionary<string, UiViewBase> ShowViewMap = new Dictionary<string, UiViewBase>();

		// Token: 0x0401C607 RID: 116231
		private readonly Dictionary<string, UiViewBase> HideViewMap = new Dictionary<string, UiViewBase>();
	}
}
