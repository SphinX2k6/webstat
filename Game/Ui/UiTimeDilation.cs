using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049B7 RID: 18871
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class UiTimeDilation : Singleton<UiTimeDilation>
	{
		// Token: 0x17008412 RID: 33810
		// (get) Token: 0x06031523 RID: 202019 RVA: 0x00C46374 File Offset: 0x00C44574
		// (set) Token: 0x06031524 RID: 202020 RVA: 0x00C4637C File Offset: 0x00C4457C
		public bool GmSwitch
		{
			get
			{
				return this.GmSwitchInternal;
			}
			set
			{
				this.GmSwitchInternal = value;
			}
		}

		// Token: 0x17008413 RID: 33811
		// (get) Token: 0x06031525 RID: 202021 RVA: 0x00C46385 File Offset: 0x00C44585
		private float TimeDilation
		{
			get
			{
				if (this.TimeDilationData == null)
				{
					return 1f;
				}
				return this.TimeDilationData.TimeDilation;
			}
		}

		// Token: 0x17008414 RID: 33812
		// (get) Token: 0x06031526 RID: 202022 RVA: 0x00C463A0 File Offset: 0x00C445A0
		private int ViewId
		{
			get
			{
				if (this.TimeDilationData == null)
				{
					return 0;
				}
				return this.TimeDilationData.ViewId;
			}
		}

		// Token: 0x17008415 RID: 33813
		// (get) Token: 0x06031527 RID: 202023 RVA: 0x00C463B8 File Offset: 0x00C445B8
		private EUiViewName? DebugName
		{
			get
			{
				UiViewInfoForTimeDilation timeDilationData = this.TimeDilationData;
				if (timeDilationData == null)
				{
					return null;
				}
				return timeDilationData.DebugName;
			}
		}

		// Token: 0x17008416 RID: 33814
		// (get) Token: 0x06031528 RID: 202024 RVA: 0x00C463DE File Offset: 0x00C445DE
		private string Reason
		{
			get
			{
				if (this.TimeDilationData == null)
				{
					return "UiTimeDilation";
				}
				return this.TimeDilationData.Reason;
			}
		}

		// Token: 0x06031529 RID: 202025 RVA: 0x00C463FC File Offset: 0x00C445FC
		[NullableContext(2)]
		public IUiViewInfoForTimeDilation GetTimeDilationDataCopy()
		{
			if (this.TimeDilationData != null)
			{
				UiViewInfoForTimeDilation uiViewInfoForTimeDilation = new UiViewInfoForTimeDilation();
				uiViewInfoForTimeDilation.TimeDilation = this.TimeDilationData.TimeDilation;
				uiViewInfoForTimeDilation.ViewId = this.TimeDilationData.ViewId;
				uiViewInfoForTimeDilation.DebugName = this.TimeDilationData.DebugName;
				uiViewInfoForTimeDilation.Reason = this.TimeDilationData.Reason;
			}
			return null;
		}

		// Token: 0x0603152A RID: 202026 RVA: 0x00C4645C File Offset: 0x00C4465C
		public void Init()
		{
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.SetTimeFlowView));
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.ResetTimeFlowView));
			Singleton<EventSystem>.Instance.Add(EEventName.ResetModuleAfterResetToBattleView, new Action(this.ResetTimeDilation));
			Singleton<EventSystem>.Instance.Add(EEventName.ClearWorld, new Action(this.ResetTimeDilation));
			Singleton<EventSystem>.Instance.Add(EEventName.ChangeMode, new Action(this.ForceResetTimeDilation));
			Singleton<EventSystem>.Instance.Add(EEventName.UpdatePanelQteWorldTimeDilation, new Action<float>(this.UpdatePanelQteTimeDilation));
			Singleton<EventSystem>.Instance.Add(EEventName.ReConnectSuccess, new Action(this.DeleteServerConnectTag));
			Singleton<EventSystem>.Instance.Add<bool, string>(EEventName.OnSequenceCameraStatus, new Action<bool, string>(this.HandleCameraSequenceTag));
			Singleton<EventSystem>.Instance.Add(EEventName.EnterGameSuccess, new Action(this.DeleteServerConnectTag));
			Singleton<EventSystem>.Instance.Add(EEventName.OnStartLoadingState, new Action(this.AddLoadingTag));
			Singleton<EventSystem>.Instance.Add(EEventName.OnFinishLoadingState, new Action(this.RemoveLoadingTag));
			Singleton<EventSystem>.Instance.Add(EEventName.AddLevelLoadingTimeDilationTag, new Action(this.AddLevelLoadingTag));
			Singleton<EventSystem>.Instance.Add(EEventName.RemoveLevelLoadingTimeDilationTag, new Action(this.RemoveLevelLoadingTag));
			Singleton<EventSystem>.Instance.Add(EEventName.RogueLevelLoadingLockTimeDilation, new Action(this.AddRogueLevelLoadingTag));
			Singleton<EventSystem>.Instance.Add(EEventName.RogueLevelLoadingUnlockTimeDilation, new Action(this.RemoveRogueLevelLoadingTag));
		}

		// Token: 0x0603152B RID: 202027 RVA: 0x00C46604 File Offset: 0x00C44804
		public void Destroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OpenView, new Action<EUiViewName, int>(this.SetTimeFlowView));
			Singleton<EventSystem>.Instance.Remove(EEventName.CloseView, new Action<EUiViewName, int>(this.ResetTimeFlowView));
			Singleton<EventSystem>.Instance.Remove(EEventName.ResetModuleAfterResetToBattleView, new Action(this.ResetTimeDilation));
			Singleton<EventSystem>.Instance.Remove(EEventName.ClearWorld, new Action(this.ResetTimeDilation));
			Singleton<EventSystem>.Instance.Remove(EEventName.ChangeMode, new Action(this.ForceResetTimeDilation));
			Singleton<EventSystem>.Instance.Remove(EEventName.UpdatePanelQteWorldTimeDilation, new Action<float>(this.UpdatePanelQteTimeDilation));
			Singleton<EventSystem>.Instance.Remove(EEventName.ReConnectSuccess, new Action(this.DeleteServerConnectTag));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSequenceCameraStatus, new Action<bool, string>(this.HandleCameraSequenceTag));
			Singleton<EventSystem>.Instance.Remove(EEventName.EnterGameSuccess, new Action(this.DeleteServerConnectTag));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnStartLoadingState, new Action(this.AddLoadingTag));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnFinishLoadingState, new Action(this.RemoveLoadingTag));
			Singleton<EventSystem>.Instance.Remove(EEventName.AddLevelLoadingTimeDilationTag, new Action(this.AddLevelLoadingTag));
			Singleton<EventSystem>.Instance.Remove(EEventName.RemoveLevelLoadingTimeDilationTag, new Action(this.RemoveLevelLoadingTag));
			Singleton<EventSystem>.Instance.Remove(EEventName.RogueLevelLoadingLockTimeDilation, new Action(this.AddRogueLevelLoadingTag));
			Singleton<EventSystem>.Instance.Remove(EEventName.RogueLevelLoadingUnlockTimeDilation, new Action(this.RemoveRogueLevelLoadingTag));
		}

		// Token: 0x0603152C RID: 202028 RVA: 0x00C467AC File Offset: 0x00C449AC
		private unsafe void PrintDebugReason(float dilation, string debugReason)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiTimeDilation;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "输出外部调用时停原因";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("原因", debugReason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("是否触发真时停", (double)dilation < 0.0001);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x0603152D RID: 202029 RVA: 0x00C46820 File Offset: 0x00C44A20
		private unsafe void SaveCacheTimeDilationData(UiViewInfoForTimeDilation viewInfo)
		{
			if (this.CacheTimeDilationData == null || this.CacheTimeDilationData.TimeDilation == 1f)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiTimeDilation;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "缓存数据添加";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("触发界面", viewInfo.DebugName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("界面Id", viewInfo.ViewId);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				this.CacheTimeDilationData = viewInfo;
			}
		}

		// Token: 0x0603152E RID: 202030 RVA: 0x00C468B8 File Offset: 0x00C44AB8
		private unsafe bool SetGameTimeDilationPrivate(UiViewInfoForTimeDilation viewInfo)
		{
			if (ModelBase<GameModeModel>.Instance == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiTimeDilation;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "GameModeModel不存在,不允许设置界面时停";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("触发界面", viewInfo.DebugName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("界面Id", viewInfo.ViewId);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			if (this.InMultiplayerWorld())
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.UiTimeDilation;
				ELogAuthor author2 = ELogAuthor.XXJ;
				string message2 = "联机状态,不允许设置界面时停";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("触发界面", viewInfo.DebugName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("界面Id", viewInfo.ViewId);
				instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				return false;
			}
			this.TrySetTimeDilation(viewInfo);
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.UiTimeDilation;
			ELogAuthor author3 = ELogAuthor.XXJ;
			string message3 = "界面时停设置";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("触发界面", viewInfo.DebugName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("设置流速", viewInfo.TimeDilation);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("界面Id", viewInfo.ViewId);
			instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
			return true;
		}

		// Token: 0x0603152F RID: 202031 RVA: 0x00C46A38 File Offset: 0x00C44C38
		private void TrySetTimeDilation(UiViewInfoForTimeDilation viewInfo)
		{
			float timeDilation = viewInfo.TimeDilation;
			this.TimeDilationData = ((timeDilation != 1f) ? viewInfo : null);
			this.PrintDebugReason(timeDilation, viewInfo.Reason);
			if (this.IsHookInHighLevel)
			{
				Singleton<Log>.Instance.Info(ELogModule.UiTimeDilation, ELogAuthor.XXJ, "界面时停被更高级别时停影响，实际未生效", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (this.GmSwitch)
			{
				ControllerBase<GameModeController>.Instance.SetTimeDilation(timeDilation * this.PanelQteTimeScale, ETimeDilationType.Default);
				return;
			}
			if ((double)timeDilation < 0.0001)
			{
				ControllerBase<GameModeController>.Instance.SetGamePaused(true, "UiTimeDilation", 1f);
				return;
			}
			ControllerBase<GameModeController>.Instance.SetGamePaused(false, "UiTimeDilation", timeDilation * this.PanelQteTimeScale);
		}

		// Token: 0x06031530 RID: 202032 RVA: 0x00C46AEC File Offset: 0x00C44CEC
		private void SetTimeFlowView(EUiViewName viewName, int viewId)
		{
			UiViewBase view = Singleton<UiManager>.Instance.GetView(viewId);
			if (view == null)
			{
				return;
			}
			float timeDilation = view.GetTimeDilation();
			this.AddViewData(viewName, viewId, timeDilation);
			if (this.InTimeFlowViewId != null)
			{
				return;
			}
			if (Math.Abs(timeDilation - 1f) < 1E-06f)
			{
				return;
			}
			if (this.SetGameTimeDilation(new UiViewInfoForTimeDilation
			{
				ViewId = viewId,
				TimeDilation = timeDilation,
				DebugName = new EUiViewName?(viewName),
				Reason = "UiTimeDilation"
			}))
			{
				this.InTimeFlowViewId = new int?(viewId);
			}
		}

		// Token: 0x06031531 RID: 202033 RVA: 0x00C46B7C File Offset: 0x00C44D7C
		public unsafe bool SetGameTimeDilation(UiViewInfoForTimeDilation viewInfo)
		{
			if (!Singleton<Net>.Instance.IsServerConnected())
			{
				this.AddWaitSetTimeDilationTag("ServerConnect");
			}
			if (this.InSnapShotWaitTimeDilation())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiTimeDilation;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "指定Plot层级,有需要等待设置时停的tag,不允许设置界面时停";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("触发界面", viewInfo.DebugName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("界面Id", viewInfo.ViewId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Tag", this.WaitSetTimeDilationTagSet);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				this.SnapShotSaveCacheTimeDilationData(viewInfo);
				return false;
			}
			if (this.InWaitTimeDilation())
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.UiTimeDilation;
				ELogAuthor author2 = ELogAuthor.XXJ;
				string message2 = "有需要等待设置时停的tag,不允许设置界面时停";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("触发界面", viewInfo.DebugName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("界面Id", viewInfo.ViewId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("Tag", this.WaitSetTimeDilationTagSet);
				instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				this.SaveCacheTimeDilationData(viewInfo);
				return false;
			}
			return this.SetGameTimeDilationPrivate(viewInfo);
		}

		// Token: 0x06031532 RID: 202034 RVA: 0x00C46CD8 File Offset: 0x00C44ED8
		private unsafe void ResetTimeFlowView(EUiViewName name, int viewId)
		{
			this.RemoveSnapShopViewData(viewId);
			this.RemoveViewData(viewId);
			int? inTimeFlowViewId;
			if (this.CacheTimeDilationData != null && this.CacheTimeDilationData.ViewId == viewId)
			{
				this.CacheTimeDilationData = null;
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiTimeDilation;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "缓存的数据清除";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("恢复界面", name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("界面Id", viewId);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				inTimeFlowViewId = this.InTimeFlowViewId;
				if (inTimeFlowViewId.GetValueOrDefault() == viewId & inTimeFlowViewId != null)
				{
					this.InTimeFlowViewId = null;
				}
				return;
			}
			inTimeFlowViewId = this.InTimeFlowViewId;
			if (!(viewId == inTimeFlowViewId.GetValueOrDefault() & inTimeFlowViewId != null))
			{
				return;
			}
			if (this.SetGameTimeDilation(new UiViewInfoForTimeDilation
			{
				ViewId = viewId,
				TimeDilation = 1f,
				DebugName = new EUiViewName?(name),
				Reason = "UiTimeDilation"
			}))
			{
				this.InTimeFlowViewId = null;
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.UiTimeDilation;
				ELogAuthor author2 = ELogAuthor.XXJ;
				string message2 = "界面时停恢复";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("恢复界面", name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("界面Id", viewId);
				instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				this.SetNextViewTimeDilation();
			}
		}

		// Token: 0x06031533 RID: 202035 RVA: 0x00C46E5E File Offset: 0x00C4505E
		private void ResetTimeDilation()
		{
			if (ModelBase<GameModeModel>.Instance == null)
			{
				return;
			}
			if (this.InMultiplayerWorld())
			{
				return;
			}
			if (!Singleton<Net>.Instance.IsServerConnected())
			{
				return;
			}
			this.ForceResetTimeDilation();
		}

		// Token: 0x06031534 RID: 202036 RVA: 0x00C46E84 File Offset: 0x00C45084
		private void ForceResetTimeDilation()
		{
			this.TimeDilationData = null;
			Singleton<Log>.Instance.Info(ELogModule.UiTimeDilation, ELogAuthor.XXJ, "时停强制重置为1", default(ReadOnlySpan<ValueTuple<string, object>>));
			if (!this.GmSwitch)
			{
				ControllerBase<GameModeController>.Instance.SetGamePaused(false, "UiTimeDilation", 1f);
			}
			else
			{
				ControllerBase<GameModeController>.Instance.SetTimeDilation(1f, ETimeDilationType.Default);
			}
			this.CacheTimeDilationData = null;
			this.InTimeFlowViewId = null;
			this.SnapShotData = null;
		}

		// Token: 0x06031535 RID: 202037 RVA: 0x00C46EFE File Offset: 0x00C450FE
		private bool InMultiplayerWorld()
		{
			return ModelBase<GameModeModel>.Instance != null && ModelBase<GameModeModel>.Instance.IsMulti;
		}

		// Token: 0x06031536 RID: 202038 RVA: 0x00C46F14 File Offset: 0x00C45114
		public unsafe void SetTimeDilationHighLevel(float timeDilation, string reason)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiTimeDilation;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "设置高级别时停";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("时停参数", timeDilation);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Reason", reason);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.IsHookInHighLevel = true;
			if (this.GmSwitch)
			{
				ControllerBase<GameModeController>.Instance.SetTimeDilation(timeDilation, ETimeDilationType.Default);
				return;
			}
			if ((double)timeDilation < 0.0001)
			{
				ControllerBase<GameModeController>.Instance.SetGamePaused(true, reason, 1f);
				return;
			}
			ControllerBase<GameModeController>.Instance.SetGamePaused(false, "UiTimeDilation", timeDilation);
		}

		// Token: 0x17008417 RID: 33815
		// (get) Token: 0x06031537 RID: 202039 RVA: 0x00C46FC7 File Offset: 0x00C451C7
		private bool IsUiTimeDilationGamePause
		{
			get
			{
				return this.TimeDilationData != null && (double)this.TimeDilationData.TimeDilation < 0.0001;
			}
		}

		// Token: 0x17008418 RID: 33816
		// (get) Token: 0x06031538 RID: 202040 RVA: 0x00C46FEA File Offset: 0x00C451EA
		public bool IsUiTimeDilated
		{
			get
			{
				return this.TimeDilationData != null && this.TimeDilationData.TimeDilation < 1f;
			}
		}

		// Token: 0x06031539 RID: 202041 RVA: 0x00C47008 File Offset: 0x00C45208
		public void ResetTimeDilationHighLevel(string reason)
		{
			Singleton<Log>.Instance.Info(ELogModule.UiTimeDilation, ELogAuthor.XXJ, "恢复高级别时停", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.IsHookInHighLevel = false;
			ControllerBase<GameModeController>.Instance.SetGamePaused(this.IsUiTimeDilationGamePause, "UiTimeDilation", 1f);
			float timeDilation = this.TimeDilation;
			if (this.GmSwitch)
			{
				ControllerBase<GameModeController>.Instance.SetTimeDilation(timeDilation, ETimeDilationType.Default);
				return;
			}
			if ((double)timeDilation < 0.0001)
			{
				ControllerBase<GameModeController>.Instance.SetGamePaused(false, reason, 1f);
				return;
			}
			ControllerBase<GameModeController>.Instance.SetGamePaused(false, reason, timeDilation);
		}

		// Token: 0x0603153A RID: 202042 RVA: 0x00C470A0 File Offset: 0x00C452A0
		private void UpdatePanelQteTimeDilation(float scale)
		{
			if (this.PanelQteTimeScale == scale)
			{
				return;
			}
			this.PanelQteTimeScale = scale;
			if (this.TimeDilation != 0f)
			{
				UiViewInfoForTimeDilation uiViewInfoForTimeDilation;
				if ((uiViewInfoForTimeDilation = this.TimeDilationData) == null)
				{
					UiViewInfoForTimeDilation uiViewInfoForTimeDilation2 = new UiViewInfoForTimeDilation();
					uiViewInfoForTimeDilation2.ViewId = this.ViewId;
					uiViewInfoForTimeDilation2.TimeDilation = this.TimeDilation;
					uiViewInfoForTimeDilation2.DebugName = this.DebugName;
					uiViewInfoForTimeDilation = uiViewInfoForTimeDilation2;
					uiViewInfoForTimeDilation2.Reason = this.Reason;
				}
				UiViewInfoForTimeDilation viewInfo = uiViewInfoForTimeDilation;
				this.TrySetTimeDilation(viewInfo);
			}
		}

		// Token: 0x0603153B RID: 202043 RVA: 0x00C47112 File Offset: 0x00C45312
		private void DeleteServerConnectTag()
		{
			this.DeleteWaitSetTimeDilationTag("ServerConnect");
		}

		// Token: 0x0603153C RID: 202044 RVA: 0x00C4711F File Offset: 0x00C4531F
		private void HandleCameraSequenceTag(bool bInCameraSequence, string cameraName)
		{
			if (cameraName != "MainCamera")
			{
				return;
			}
			if (bInCameraSequence)
			{
				this.AddWaitSetTimeDilationTag("CameraSequence");
				return;
			}
			this.DeleteWaitSetTimeDilationTag("CameraSequence");
		}

		// Token: 0x0603153D RID: 202045 RVA: 0x00C47149 File Offset: 0x00C45349
		private void AddLoadingTag()
		{
			this.AddWaitSetTimeDilationTag("Loading");
		}

		// Token: 0x0603153E RID: 202046 RVA: 0x00C47156 File Offset: 0x00C45356
		private void RemoveLoadingTag()
		{
			this.DeleteWaitSetTimeDilationTag("Loading");
		}

		// Token: 0x0603153F RID: 202047 RVA: 0x00C47163 File Offset: 0x00C45363
		private void AddLevelLoadingTag()
		{
			this.AddWaitSetTimeDilationTag("LevelLoading");
		}

		// Token: 0x06031540 RID: 202048 RVA: 0x00C47170 File Offset: 0x00C45370
		private void RemoveLevelLoadingTag()
		{
			this.DeleteWaitSetTimeDilationTag("LevelLoading");
		}

		// Token: 0x06031541 RID: 202049 RVA: 0x00C4717D File Offset: 0x00C4537D
		private void AddRogueLevelLoadingTag()
		{
			this.AddWaitSetTimeDilationTag("RogueLevelLoading");
		}

		// Token: 0x06031542 RID: 202050 RVA: 0x00C4718A File Offset: 0x00C4538A
		private void RemoveRogueLevelLoadingTag()
		{
			this.DeleteWaitSetTimeDilationTag("RogueLevelLoading");
		}

		// Token: 0x06031543 RID: 202051 RVA: 0x00C47198 File Offset: 0x00C45398
		public void AddViewData(EUiViewName name, int viewId, float timeDilation)
		{
			if (timeDilation < 1f)
			{
				this.ViewIdList.Add(viewId);
				this.TimeDilationMap[viewId] = new UiViewInfoForTimeDilation
				{
					ViewId = viewId,
					TimeDilation = timeDilation,
					DebugName = new EUiViewName?(name),
					Reason = "UiTimeDilation"
				};
			}
		}

		// Token: 0x06031544 RID: 202052 RVA: 0x00C471F0 File Offset: 0x00C453F0
		public void RemoveViewData(int viewId)
		{
			if (this.TimeDilationMap.Remove(viewId))
			{
				int num = this.ViewIdList.IndexOf(viewId);
				if (num >= 0)
				{
					this.ViewIdList.RemoveAt(num);
				}
			}
		}

		// Token: 0x06031545 RID: 202053 RVA: 0x00C47228 File Offset: 0x00C45428
		public unsafe void SetNextViewTimeDilation()
		{
			if (this.ViewIdList.Count == 0)
			{
				return;
			}
			int num = this.ViewIdList[0];
			this.ViewIdList.RemoveAt(0);
			if (num == 0)
			{
				return;
			}
			UiViewInfoForTimeDilation uiViewInfoForTimeDilation = null;
			this.TimeDilationMap.TryGetValue(num, out uiViewInfoForTimeDilation);
			if (uiViewInfoForTimeDilation != null && this.SetGameTimeDilation(uiViewInfoForTimeDilation))
			{
				this.InTimeFlowViewId = new int?(num);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiTimeDilation;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "界面时停设置下个数据";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("界面", uiViewInfoForTimeDilation.DebugName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("界面Id", num);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}

		// Token: 0x06031546 RID: 202054 RVA: 0x00C472EC File Offset: 0x00C454EC
		public void AddWaitSetTimeDilationTag(string tag)
		{
			if (this.SnapShotData != null)
			{
				this.SnapShotData.WaitSetTimeDilationTagSet.Add(tag);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiTimeDilation;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "指定Plot层级,添加等待设置时停的tag";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Tag", tag);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			else
			{
				this.WaitSetTimeDilationTagSet.Add(tag);
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.UiTimeDilation;
				ELogAuthor author2 = ELogAuthor.XXJ;
				string message2 = "添加等待设置时停的tag";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Tag", tag);
				instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}
			if (this.TimeDilationData == null)
			{
				return;
			}
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.UiTimeDilation;
			ELogAuthor author3 = ELogAuthor.XXJ;
			string message3 = "目前存在界面正在时停中,缓存并且临时恢复";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("Tag", tag);
			instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			this.SaveCacheTimeDilationData(this.TimeDilationData);
			this.SetGameTimeDilationPrivate(new UiViewInfoForTimeDilation
			{
				ViewId = this.TimeDilationData.ViewId,
				TimeDilation = 1f,
				DebugName = this.TimeDilationData.DebugName,
				Reason = this.TimeDilationData.Reason
			});
		}

		// Token: 0x06031547 RID: 202055 RVA: 0x00C473F8 File Offset: 0x00C455F8
		public void DeleteWaitSetTimeDilationTag(string tag)
		{
			if (this.SnapShotData != null)
			{
				if (this.SnapShotData.CacheTimeDilationTagSet.Contains(tag))
				{
					if (this.SnapShotData.CacheTimeDilationTagSet.Remove(tag))
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.UiTimeDilation;
						ELogAuthor author = ELogAuthor.XXJ;
						string message = "指定Plot层级,缓存数据中删除等待设置时停的tag";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Tag", tag);
						instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					}
				}
				else if (this.SnapShotData.WaitSetTimeDilationTagSet.Remove(tag))
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.UiTimeDilation;
					ELogAuthor author2 = ELogAuthor.XXJ;
					string message2 = "指定Plot层级,删除等待设置时停的tag";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Tag", tag);
					instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				}
				this.SnapShotData.WaitSetTimeDilationTagSet.Remove(tag);
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.UiTimeDilation;
				ELogAuthor author3 = ELogAuthor.XXJ;
				string message3 = "指定Plot层级,删除等待设置时停的tag";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("Tag", tag);
				instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			}
			else if (this.WaitSetTimeDilationTagSet.Remove(tag))
			{
				Log instance4 = Singleton<Log>.Instance;
				ELogModule module4 = ELogModule.UiTimeDilation;
				ELogAuthor author4 = ELogAuthor.XXJ;
				string message4 = "删除等待设置时停的tag";
				ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("Tag", tag);
				instance4.Info(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
			}
			this.TriggerCacheTimeDilationData();
		}

		// Token: 0x06031548 RID: 202056 RVA: 0x00C4750F File Offset: 0x00C4570F
		private bool InWaitTimeDilation()
		{
			return this.WaitSetTimeDilationTagSet.Count > 0;
		}

		// Token: 0x06031549 RID: 202057 RVA: 0x00C47520 File Offset: 0x00C45720
		private unsafe void TriggerCacheTimeDilationData()
		{
			if (this.CacheTimeDilationData == null)
			{
				return;
			}
			if (this.InTimeFlowViewId != null)
			{
				int? inTimeFlowViewId = this.InTimeFlowViewId;
				int viewId = this.CacheTimeDilationData.ViewId;
				if (!(inTimeFlowViewId.GetValueOrDefault() == viewId & inTimeFlowViewId != null))
				{
					this.CacheTimeDilationData = null;
					return;
				}
			}
			if (this.SetGameTimeDilation(this.CacheTimeDilationData))
			{
				this.InTimeFlowViewId = new int?(this.CacheTimeDilationData.ViewId);
				EUiViewName? debugName = this.CacheTimeDilationData.DebugName;
				this.CacheTimeDilationData = null;
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiTimeDilation;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "缓存数据设置成功";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("界面", debugName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("界面Id", this.InTimeFlowViewId);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}

		// Token: 0x0603154A RID: 202058 RVA: 0x00C4760E File Offset: 0x00C4580E
		private void ClearCurrentData()
		{
			this.InTimeFlowViewId = null;
			this.CacheTimeDilationData = null;
			this.TimeDilationData = null;
			this.TimeDilationMap = new Dictionary<int, UiViewInfoForTimeDilation>();
			this.ViewIdList = new List<int>();
			this.WaitSetTimeDilationTagSet = new HashSet<string>();
		}

		// Token: 0x0603154B RID: 202059 RVA: 0x00C4764C File Offset: 0x00C4584C
		private void CreateSnapShotData()
		{
			if (this.SnapShotData != null)
			{
				return;
			}
			this.SnapShotData = new SnapshotData();
			this.SnapShotData.InTimeFlowViewId = this.InTimeFlowViewId;
			this.SnapShotData.CacheTimeDilationData = this.CacheTimeDilationData;
			this.SnapShotData.TimeDilationData = this.TimeDilationData;
			this.SnapShotData.TimeDilationMap = this.TimeDilationMap;
			this.SnapShotData.ViewIdList = this.ViewIdList;
			this.SnapShotData.CacheTimeDilationTagSet = this.WaitSetTimeDilationTagSet;
		}

		// Token: 0x0603154C RID: 202060 RVA: 0x00C476D4 File Offset: 0x00C458D4
		private void RestoreSnapShotData()
		{
			if (this.SnapShotData != null)
			{
				if (this.SnapShotData.InTimeFlowViewId != null)
				{
					this.InTimeFlowViewId = this.SnapShotData.InTimeFlowViewId;
				}
				this.CacheTimeDilationData = this.SnapShotData.CacheTimeDilationData;
				this.TimeDilationData = this.SnapShotData.TimeDilationData;
				this.TimeDilationMap = this.SnapShotData.TimeDilationMap;
				this.ViewIdList = this.SnapShotData.ViewIdList;
				this.WaitSetTimeDilationTagSet = this.SnapShotData.CacheTimeDilationTagSet;
				this.SnapShotData = null;
			}
		}

		// Token: 0x0603154D RID: 202061 RVA: 0x00C47768 File Offset: 0x00C45968
		private void RemoveSnapShopViewData(int viewId)
		{
			if (this.SnapShotData == null)
			{
				return;
			}
			if (this.SnapShotData.TimeDilationMap.Remove(viewId))
			{
				int num = this.SnapShotData.ViewIdList.IndexOf(viewId);
				if (num >= 0)
				{
					this.SnapShotData.ViewIdList.RemoveAt(num);
					Singleton<Log>.Instance.Info(ELogModule.UiTimeDilation, ELogAuthor.XXJ, "时停数据快照期间时停集合数据被删除", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
			}
			if (this.SnapShotData.CacheTimeDilationData != null && this.SnapShotData.CacheTimeDilationData.ViewId == viewId)
			{
				Singleton<Log>.Instance.Info(ELogModule.UiTimeDilation, ELogAuthor.XXJ, "时停数据快照期间时停缓存时停数据被删除", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.SnapShotData.CacheTimeDilationData = null;
			}
			int? inTimeFlowViewId = this.SnapShotData.InTimeFlowViewId;
			if (inTimeFlowViewId.GetValueOrDefault() == viewId & inTimeFlowViewId != null)
			{
				Singleton<Log>.Instance.Info(ELogModule.UiTimeDilation, ELogAuthor.XXJ, "时停数据快照期间第一个触发时停界面数据被删除", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.SnapShotData.TimeDilationData = null;
				this.SnapShotData.InTimeFlowViewId = null;
			}
		}

		// Token: 0x0603154E RID: 202062 RVA: 0x00C47878 File Offset: 0x00C45A78
		public void TemporarySaveData()
		{
			Singleton<Log>.Instance.Info(ELogModule.UiTimeDilation, ELogAuthor.XXJ, "[OpenView]指定Plot层级打开界面,临时进行数据快照,重置时停表现", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.CreateSnapShotData();
			this.ClearCurrentData();
			ControllerBase<GameModeController>.Instance.SetGamePaused(false, "UiTimeDilation", 1f);
		}

		// Token: 0x0603154F RID: 202063 RVA: 0x00C478C4 File Offset: 0x00C45AC4
		public void RestoreSaveData()
		{
			Singleton<Log>.Instance.Info(ELogModule.UiTimeDilation, ELogAuthor.XXJ, "[CloseView]指定Plot层级关闭界面,还原数据快照,设置时停表现", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.RestoreSnapShotData();
			if (this.TimeDilationData != null)
			{
				this.SetGameTimeDilation(this.TimeDilationData);
			}
		}

		// Token: 0x06031550 RID: 202064 RVA: 0x00C47908 File Offset: 0x00C45B08
		private bool InSnapShotWaitTimeDilation()
		{
			return this.SnapShotData != null && this.SnapShotData.WaitSetTimeDilationTagSet.Count > 0;
		}

		// Token: 0x06031551 RID: 202065 RVA: 0x00C47928 File Offset: 0x00C45B28
		private unsafe void SnapShotSaveCacheTimeDilationData(UiViewInfoForTimeDilation viewInfo)
		{
			if (this.SnapShotData == null)
			{
				return;
			}
			if (this.SnapShotData.CacheTimeDilationData == null || this.SnapShotData.CacheTimeDilationData.TimeDilation == 1f)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiTimeDilation;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "指定Plot层级,缓存数据添加";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("触发界面", viewInfo.DebugName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("界面Id", viewInfo.ViewId);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				this.CacheTimeDilationData = viewInfo;
			}
		}

		// Token: 0x0401C57A RID: 116090
		public bool Enable = true;

		// Token: 0x0401C57B RID: 116091
		private bool GmSwitchInternal;

		// Token: 0x0401C57C RID: 116092
		private int? InTimeFlowViewId;

		// Token: 0x0401C57D RID: 116093
		private bool IsHookInHighLevel;

		// Token: 0x0401C57E RID: 116094
		[Nullable(2)]
		private UiViewInfoForTimeDilation CacheTimeDilationData;

		// Token: 0x0401C57F RID: 116095
		[Nullable(2)]
		private UiViewInfoForTimeDilation TimeDilationData;

		// Token: 0x0401C580 RID: 116096
		private float PanelQteTimeScale = 1f;

		// Token: 0x0401C581 RID: 116097
		[Nullable(2)]
		private SnapshotData SnapShotData;

		// Token: 0x0401C582 RID: 116098
		private List<int> ViewIdList = new List<int>();

		// Token: 0x0401C583 RID: 116099
		private Dictionary<int, UiViewInfoForTimeDilation> TimeDilationMap = new Dictionary<int, UiViewInfoForTimeDilation>();

		// Token: 0x0401C584 RID: 116100
		private HashSet<string> WaitSetTimeDilationTagSet = new HashSet<string>();
	}
}
