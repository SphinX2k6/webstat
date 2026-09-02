using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.ResManager;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher;
using CSharpScript.Launcher.DiffPatch.Update;
using CSharpScript.Launcher.Ui.HotFix;
using CSharpScript.Launcher.Update;
using CSharpScript.Launcher.Update.ResourceDiffUpdate;
using CSharpScript.Launcher.Update.ResourceDiffUpdate.Updater;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02002A99 RID: 10905
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class SubPackageController : UiControllerBase<SubPackageController>, IStaticVariableResetter
{
	// Token: 0x06015D20 RID: 89376 RVA: 0x0060CFEC File Offset: 0x0060B1EC
	public void DeleteUnneededResourceOnInit()
	{
		if (this.HaveDeleteUnneededResourceOnInit.GetValueOrDefault())
		{
			return;
		}
		if (!Singleton<VideoResUpdate>.Instance.IsVideoClearGrayBoxHit())
		{
			return;
		}
		this.HaveDeleteUnneededResourceOnInit = new bool?(true);
		int valueOrDefault = ModelBase<PlayerInfoModel>.Instance.GetId().GetValueOrDefault();
		if (LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.SubDownLoadClearOnLogin, false))
		{
			int global = LocalStorage.GetGlobal<int>(ELocalStorageGlobalKey.SubDownLoadClearLastWorldDoneUid, 0);
			if (global != 0 && global != valueOrDefault)
			{
				LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.SubDownLoadClearOnLogin, false);
			}
			else
			{
				this.DeleteUnneededResource(false);
			}
		}
		if (valueOrDefault != 0)
		{
			LocalStorage.SetGlobal<int>(ELocalStorageGlobalKey.SubDownLoadClearLastWorldDoneUid, valueOrDefault);
		}
	}

	// Token: 0x06015D21 RID: 89377 RVA: 0x0060D074 File Offset: 0x0060B274
	private unsafe void DownLoadPackage()
	{
		ModelBase<SubPackageDownLoadModel>.Instance.PauseSubPackageId = 0;
		if (ModelBase<SubPackageDownLoadModel>.Instance.DownLoadingSubPackageId != 0)
		{
			return;
		}
		if (ModelBase<SubPackageDownLoadModel>.Instance.SubPackageDownLoadList.Count == 0)
		{
			return;
		}
		int num = ModelBase<SubPackageDownLoadModel>.Instance.SubPackageDownLoadList[0];
		ModelBase<SubPackageDownLoadModel>.Instance.SubPackageDownLoadList.RemoveAt(0);
		if (num == 0)
		{
			return;
		}
		if (ModelBase<SubPackageDownLoadModel>.Instance.IsKeyPackageDownLoadingPause() && num != 1)
		{
			ModelBase<SubPackageDownLoadModel>.Instance.SubPackageDownLoadList.Insert(0, num);
			return;
		}
		if (ModelBase<SubPackageDownLoadModel>.Instance.HaveNotEnoughSpace(num))
		{
			ModelBase<SubPackageDownLoadModel>.Instance.SetSubPackageDownLoadItemStateMap(num, ESubPackageDownLoadState.Pause);
			if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.SubPackageDownLoadFreeSpaceTipsView))
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.SubPackageDownLoadFreeSpaceTipsView, num, null);
			}
			return;
		}
		ModelBase<SubPackageDownLoadModel>.Instance.SetSubPackageDownLoadItemStateMap(num, ESubPackageDownLoadState.DownLoading);
		List<ResourceDiffUpdater> list = ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageDownLoadItemUpdater(num) ?? new List<ResourceDiffUpdater>();
		foreach (ResourceDiffUpdater resourceDiffUpdater in list)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.SubPackageDownLoad;
			ELogAuthor author = ELogAuthor.LJQ;
			string message = "update.UpdateResourceProcedure()";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("id", num);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("TotalProgress", resourceDiffUpdater.ViewInfo.TotalSize);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("CurProgress", resourceDiffUpdater.ViewInfo.SavedSize);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("updater", resourceDiffUpdater.Name);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			resourceDiffUpdater.UpdateResourceProcedure().Forget();
		}
		foreach (ResourceDiffUpdater update in list)
		{
			this.ReportSubPackageDownLoadLogEvent(num, 1, update);
		}
		if (num == 1)
		{
			this.ClearLocalDownLoadList();
			this.ReportSubPackageKeySubPackageLogEvent(0, 1);
			return;
		}
		this.SaveLocalDownLoadList();
	}

	// Token: 0x06015D22 RID: 89378 RVA: 0x0060D2AC File Offset: 0x0060B4AC
	public UniTask PushSubPackageDownLoading(List<int> idList, [Nullable(2)] Action callBack = null)
	{
		SubPackageController.<PushSubPackageDownLoading>d__6 <PushSubPackageDownLoading>d__;
		<PushSubPackageDownLoading>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PushSubPackageDownLoading>d__.<>4__this = this;
		<PushSubPackageDownLoading>d__.idList = idList;
		<PushSubPackageDownLoading>d__.callBack = callBack;
		<PushSubPackageDownLoading>d__.<>1__state = -1;
		<PushSubPackageDownLoading>d__.<>t__builder.Start<SubPackageController.<PushSubPackageDownLoading>d__6>(ref <PushSubPackageDownLoading>d__);
		return <PushSubPackageDownLoading>d__.<>t__builder.Task;
	}

	// Token: 0x06015D23 RID: 89379 RVA: 0x0060D300 File Offset: 0x0060B500
	[NullableContext(2)]
	public UniTask RestartSubPackageDownLoading(int id, Action callBack = null)
	{
		SubPackageController.<RestartSubPackageDownLoading>d__7 <RestartSubPackageDownLoading>d__;
		<RestartSubPackageDownLoading>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RestartSubPackageDownLoading>d__.<>4__this = this;
		<RestartSubPackageDownLoading>d__.callBack = callBack;
		<RestartSubPackageDownLoading>d__.<>1__state = -1;
		<RestartSubPackageDownLoading>d__.<>t__builder.Start<SubPackageController.<RestartSubPackageDownLoading>d__7>(ref <RestartSubPackageDownLoading>d__);
		return <RestartSubPackageDownLoading>d__.<>t__builder.Task;
	}

	// Token: 0x06015D24 RID: 89380 RVA: 0x0060D34C File Offset: 0x0060B54C
	public UniTask PrioritySubPackageDownLoading(List<int> idList, [Nullable(2)] Action callBack = null)
	{
		SubPackageController.<PrioritySubPackageDownLoading>d__8 <PrioritySubPackageDownLoading>d__;
		<PrioritySubPackageDownLoading>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PrioritySubPackageDownLoading>d__.<>4__this = this;
		<PrioritySubPackageDownLoading>d__.idList = idList;
		<PrioritySubPackageDownLoading>d__.callBack = callBack;
		<PrioritySubPackageDownLoading>d__.<>1__state = -1;
		<PrioritySubPackageDownLoading>d__.<>t__builder.Start<SubPackageController.<PrioritySubPackageDownLoading>d__8>(ref <PrioritySubPackageDownLoading>d__);
		return <PrioritySubPackageDownLoading>d__.<>t__builder.Task;
	}

	// Token: 0x06015D25 RID: 89381 RVA: 0x0060D3A0 File Offset: 0x0060B5A0
	[NullableContext(2)]
	public void StopSubPackageDownLoading(int id, Action callBack = null)
	{
		if (ModelBase<SubPackageDownLoadModel>.Instance.DownLoadingSubPackageId != id || id == 0)
		{
			return;
		}
		ModelBase<SubPackageDownLoadModel>.Instance.SetSubPackageDownLoadItemStateMap(id, ESubPackageDownLoadState.Pause);
		foreach (ResourceDiffUpdater resourceDiffUpdater in (ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageDownLoadItemUpdater(id) ?? new List<ResourceDiffUpdater>()))
		{
			resourceDiffUpdater.Stop();
		}
		ModelBase<SubPackageDownLoadModel>.Instance.DownLoadingSubPackageId = 0;
		if (callBack != null)
		{
			callBack();
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshSubPackageDownLoadByPriority);
		this.SaveLocalDownLoadList();
	}

	// Token: 0x06015D26 RID: 89382 RVA: 0x0060D448 File Offset: 0x0060B648
	public void CancelSubPackageDownLoading(int id)
	{
		if (ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageDownLoadItemStateById(id) == ESubPackageDownLoadState.Finish)
		{
			return;
		}
		ModelBase<SubPackageDownLoadModel>.Instance.SubPackageDownLoadList = (from value in ModelBase<SubPackageDownLoadModel>.Instance.SubPackageDownLoadList
		where value != id
		select value).ToList<int>();
		ModelBase<SubPackageDownLoadModel>.Instance.SetSubPackageDownLoadItemStateMap(id, ESubPackageDownLoadState.None);
		if (id == ModelBase<SubPackageDownLoadModel>.Instance.PauseSubPackageId)
		{
			ModelBase<SubPackageDownLoadModel>.Instance.PauseSubPackageId = 0;
			this.DownLoadPackage();
		}
		if (id == ModelBase<SubPackageDownLoadModel>.Instance.DownLoadingSubPackageId)
		{
			ModelBase<SubPackageDownLoadModel>.Instance.DownLoadingSubPackageId = 0;
			this.DownLoadPackage();
		}
		foreach (ResourceDiffUpdater resourceDiffUpdater in (ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageDownLoadItemUpdater(id) ?? new List<ResourceDiffUpdater>()))
		{
			resourceDiffUpdater.Stop();
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshSubPackageDownLoadByPriority);
		this.SaveLocalDownLoadList();
	}

	// Token: 0x06015D27 RID: 89383 RVA: 0x0060D564 File Offset: 0x0060B764
	public void CancelSubPackageDownLoadingList(List<int> idList)
	{
		List<int> list = new List<int>();
		foreach (int num in ModelBase<SubPackageDownLoadModel>.Instance.SubPackageDownLoadList)
		{
			if (!idList.Contains(num) && ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageDownLoadItemStateById(num) != ESubPackageDownLoadState.Finish)
			{
				list.Add(num);
			}
		}
		ModelBase<SubPackageDownLoadModel>.Instance.SubPackageDownLoadList = list;
		foreach (int num2 in idList)
		{
			if (ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageDownLoadItemStateById(num2) != ESubPackageDownLoadState.Finish)
			{
				ModelBase<SubPackageDownLoadModel>.Instance.SetSubPackageDownLoadItemStateMap(num2, ESubPackageDownLoadState.None);
				if (num2 == ModelBase<SubPackageDownLoadModel>.Instance.PauseSubPackageId)
				{
					ModelBase<SubPackageDownLoadModel>.Instance.PauseSubPackageId = 0;
					this.DownLoadPackage();
				}
				if (num2 == ModelBase<SubPackageDownLoadModel>.Instance.DownLoadingSubPackageId)
				{
					ModelBase<SubPackageDownLoadModel>.Instance.DownLoadingSubPackageId = 0;
					this.DownLoadPackage();
				}
				foreach (ResourceDiffUpdater resourceDiffUpdater in (ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageDownLoadItemUpdater(num2) ?? new List<ResourceDiffUpdater>()))
				{
					resourceDiffUpdater.Stop();
				}
			}
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshSubPackageDownLoadByPriority);
		this.SaveLocalDownLoadList();
	}

	// Token: 0x06015D28 RID: 89384 RVA: 0x0060D6DC File Offset: 0x0060B8DC
	public void DeleteUnneededResource(bool needTips)
	{
		this.ReportSubPackageClearSpaceLogEvent();
		List<int> finishQuestList = ModelBase<QuestNewModel>.Instance.GetFinishQuestList();
		ControllerBase<ResourceManagerController>.Instance.DeleteUnneededResource(finishQuestList);
		if (needTips)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("SubPackageDownLoad_Clear_Tips", Array.Empty<object>());
		}
		this.ReportSubPackageClearSpaceFinishLogEvent(!needTips);
	}

	// Token: 0x06015D29 RID: 89385 RVA: 0x0060D728 File Offset: 0x0060B928
	[NullableContext(0)]
	private UniTask<bool> IsNotUseCellData()
	{
		SubPackageController.<IsNotUseCellData>d__13 <IsNotUseCellData>d__;
		<IsNotUseCellData>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<IsNotUseCellData>d__.<>4__this = this;
		<IsNotUseCellData>d__.<>1__state = -1;
		<IsNotUseCellData>d__.<>t__builder.Start<SubPackageController.<IsNotUseCellData>d__13>(ref <IsNotUseCellData>d__);
		return <IsNotUseCellData>d__.<>t__builder.Task;
	}

	// Token: 0x06015D2A RID: 89386 RVA: 0x0060D76C File Offset: 0x0060B96C
	private unsafe void OnNetworkTypeChange(byte newType)
	{
		int downLoadingId = ModelBase<SubPackageDownLoadModel>.Instance.DownLoadingSubPackageId;
		if (ModelBase<PlayerInfoModel>.Instance.GetId().GetValueOrDefault() > 0)
		{
			bool player = LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.SubDownLoadAgreeUseCellData, false);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.SubPackageDownLoad;
			ELogAuthor author = ELogAuthor.LJQ;
			string message = "OnNetworkTypeChange";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("newType", newType);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("downLoadingId", downLoadingId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("isAgreeUseCell", player);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			if (newType != 4 && downLoadingId != 0 && !player)
			{
				this.StopSubPackageDownLoading(downLoadingId, null);
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.SubPackageDownloadCellNetworkConfirm);
				confirmBoxDataNew.FunctionMap.Add(1, delegate
				{
					ControllerBase<ConfirmBoxController>.Instance.CloseConfirmBoxView();
				});
				confirmBoxDataNew.FunctionMap.Add(2, delegate
				{
					LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.SubDownLoadAgreeUseCellData, true);
					Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshSubPackUseCellData);
					this.RestartSubPackageDownLoading(downLoadingId, null).Forget();
				});
				ControllerBase<ConfirmBoxController>.Instance.ShowNetWorkConfirmBoxView(confirmBoxDataNew, null);
			}
			return;
		}
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.SubPackageDownLoad;
		ELogAuthor author2 = ELogAuthor.LJQ;
		string message2 = "OnNetworkTypeChange,playerId未设置";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("newType", newType);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("downLoadingId", downLoadingId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("AgreeUseCell", this.AgreeUseCell);
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
		if (newType == 3 && downLoadingId != 0 && !this.AgreeUseCell.GetValueOrDefault())
		{
			this.StopSubPackageDownLoading(downLoadingId, null);
			ConfirmBoxDataNew confirmBoxDataNew2 = new ConfirmBoxDataNew(EConfirmBoxConfigId.SubPackageDownloadCellNetworkConfirm);
			confirmBoxDataNew2.FunctionMap.Add(1, delegate
			{
				AppUtil.QuitGame("DownloadSubPackageNotAllowedInCellNetwork");
			});
			confirmBoxDataNew2.FunctionMap.Add(2, delegate
			{
				this.AgreeUseCell = new bool?(true);
				this.RestartSubPackageDownLoading(downLoadingId, null).Forget();
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowNetWorkConfirmBoxView(confirmBoxDataNew2, null);
			return;
		}
		if ((newType == 0 || newType == 1 || newType == 2) && downLoadingId != 0)
		{
			this.StopSubPackageDownLoading(downLoadingId, null);
			this.ShowDownloadSubPackageNetFailedConfirm(downLoadingId);
		}
	}

	// Token: 0x06015D2B RID: 89387 RVA: 0x0060D9F4 File Offset: 0x0060BBF4
	public void ShowDownloadSubPackageNetFailedConfirm(int downLoadingId)
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.LoginResDownLoadFailedConfirm);
		confirmBoxDataNew.FunctionMap.Add(1, delegate
		{
			AppUtil.QuitGame("DownloadSubPackageNetFailed");
		});
		confirmBoxDataNew.FunctionMap.Add(2, delegate
		{
			ENetworkType networkType = (ENetworkType)ModelBase<SubPackageDownLoadModel>.Instance.NetworkListener.GetNetworkType();
			if (networkType == ENetworkType.Unknown || networkType == ENetworkType.None || networkType == ENetworkType.AirplaneMode)
			{
				this.ShowDownloadSubPackageNetFailedConfirm(downLoadingId);
				return;
			}
			this.RestartSubPackageDownLoading(downLoadingId, null).Forget();
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowNetWorkConfirmBoxView(confirmBoxDataNew, null);
	}

	// Token: 0x06015D2C RID: 89388 RVA: 0x0060DA70 File Offset: 0x0060BC70
	public void AutoDownLoadKeySubPackage()
	{
		this.PrioritySubPackageDownLoading(new List<int>
		{
			1
		}, null).Forget();
		if (ModelBase<PlayerInfoModel>.Instance.GetId().GetValueOrDefault() <= 0)
		{
			return;
		}
		if (!LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.SubDownLoadAgreeUseCellData, false) && ModelBase<SubPackageDownLoadModel>.Instance.NetworkListener.GetNetworkType() == 3)
		{
			ModelBase<SubPackageDownLoadModel>.Instance.SetSubPackageDownLoadItemStateMap(1, ESubPackageDownLoadState.Pause);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshSubPackageDownLoadByPriority);
		}
	}

	// Token: 0x06015D2D RID: 89389 RVA: 0x0060DAEC File Offset: 0x0060BCEC
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<SceneBlockSplitHumanChangleNotify>(ENotifyMessageId.SceneBlockSplitHumanChangleNotify, new Action<SceneBlockSplitHumanChangleNotify, Net.CallbackStatus>(this.SceneBlockSplitHumanChangleNotify));
		Singleton<Net>.Instance.Register<SceneBlockSplitHumanFullNotify>(ENotifyMessageId.SceneBlockSplitHumanFullNotify, new Action<SceneBlockSplitHumanFullNotify, Net.CallbackStatus>(this.SceneBlockSplitHumanFullNotify));
		Singleton<Net>.Instance.Register<SceneBlockSplitHumanSwitchStateNotify>(ENotifyMessageId.SceneBlockSplitHumanSwitchStateNotify, new Action<SceneBlockSplitHumanSwitchStateNotify, Net.CallbackStatus>(this.SceneBlockSplitHumanSwitchStateNotify));
		Singleton<Net>.Instance.Register<SceneBlockSplitPopWindowNotify>(ENotifyMessageId.SceneBlockSplitPopWindowNotify, new Action<SceneBlockSplitPopWindowNotify, Net.CallbackStatus>(this.SceneBlockSplitPopWindowNotify));
	}

	// Token: 0x06015D2E RID: 89390 RVA: 0x0060DB6C File Offset: 0x0060BD6C
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SceneBlockSplitHumanChangleNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SceneBlockSplitHumanFullNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SceneBlockSplitHumanSwitchStateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SceneBlockSplitPopWindowNotify);
	}

	// Token: 0x06015D2F RID: 89391 RVA: 0x0060DBBC File Offset: 0x0060BDBC
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.EnterAreaNotify, new Action<int>(this.EnterAreaNotify));
		Singleton<EventSystem>.Instance.Add(EEventName.OnRoleChangeEnd, new Action(this.OnRoleChangeEnd));
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.WorldDoneAndCloseLoading));
		ModelBase<SubPackageDownLoadModel>.Instance.NetworkListener.NetworkChangeDelegate.Add(new Action<byte>(this.OnNetworkTypeChange));
	}

	// Token: 0x06015D30 RID: 89392 RVA: 0x0060DC40 File Offset: 0x0060BE40
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.EnterAreaNotify, new Action<int>(this.EnterAreaNotify));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRoleChangeEnd, new Action(this.OnRoleChangeEnd));
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.WorldDoneAndCloseLoading));
		ModelBase<SubPackageDownLoadModel>.Instance.NetworkListener.NetworkChangeDelegate.Clear();
	}

	// Token: 0x06015D31 RID: 89393 RVA: 0x0060DCB5 File Offset: 0x0060BEB5
	private void SceneBlockSplitHumanChangleNotify(SceneBlockSplitHumanChangleNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
	}

	// Token: 0x06015D32 RID: 89394 RVA: 0x0060DCB7 File Offset: 0x0060BEB7
	private void SceneBlockSplitHumanFullNotify(SceneBlockSplitHumanFullNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
	}

	// Token: 0x06015D33 RID: 89395 RVA: 0x0060DCB9 File Offset: 0x0060BEB9
	private void SceneBlockSplitHumanSwitchStateNotify(SceneBlockSplitHumanSwitchStateNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
	}

	// Token: 0x06015D34 RID: 89396 RVA: 0x0060DCBC File Offset: 0x0060BEBC
	private void SceneBlockSplitPopWindowNotify(SceneBlockSplitPopWindowNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		int blockId = notify.BlockId;
		if (ControllerBase<ResourceManagerController>.Instance.IsNeedReOpenMap(blockId))
		{
			ModelBase<SubPackageDownLoadModel>.Instance.OpenBlockNeedReLoginConfirm();
			return;
		}
		ModelBase<SubPackageDownLoadModel>.Instance.OpenSubPackageDownLoadConfirm("SubPackageDownLoad_CommonLock_Confirm", new List<int>
		{
			notify.BlockId
		}, null, null);
	}

	// Token: 0x06015D35 RID: 89397 RVA: 0x0060DD1C File Offset: 0x0060BF1C
	public void SceneBlockChangePush(List<int> downloadBlockIdList, [Nullable(2)] List<int> deleteBlockIdList = null)
	{
		SceneBlockChangePush sceneBlockChangePush = Aki.Protocol.SceneBlockChangePush.Create();
		sceneBlockChangePush.DownloadBlockId.AddRange(downloadBlockIdList);
		if (deleteBlockIdList != null)
		{
			sceneBlockChangePush.DeleteBlockId.AddRange(deleteBlockIdList);
		}
		Singleton<Net>.Instance.Send(EPushMessageId.SceneBlockChangePush, sceneBlockChangePush);
	}

	// Token: 0x06015D36 RID: 89398 RVA: 0x0060DD5C File Offset: 0x0060BF5C
	public void SceneBlockSplitClientLoginPush(List<int> downloadBlockIdList)
	{
		SceneBlockSplitClientLoginPush sceneBlockSplitClientLoginPush = Aki.Protocol.SceneBlockSplitClientLoginPush.Create();
		sceneBlockSplitClientLoginPush.DownloadBlockId.AddRange(downloadBlockIdList);
		Singleton<Net>.Instance.Send(EPushMessageId.SceneBlockSplitClientLoginPush, sceneBlockSplitClientLoginPush);
	}

	// Token: 0x06015D37 RID: 89399 RVA: 0x0060DD8C File Offset: 0x0060BF8C
	public void DownLoadFinish()
	{
		int subPackage = ModelBase<SubPackageDownLoadModel>.Instance.DownLoadingSubPackageId;
		if (subPackage == 0)
		{
			return;
		}
		using (List<ResourceDiffUpdater>.Enumerator enumerator = (ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageDownLoadItemUpdater(subPackage) ?? new List<ResourceDiffUpdater>()).GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (!enumerator.Current.IsCompleteDownloaded())
				{
					return;
				}
			}
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.SubPackageDownLoad;
		ELogAuthor author = ELogAuthor.LJQ;
		string message = "DownLoadFinish";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", subPackage);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (subPackage == 1 && ModelBase<GameModeModel>.Instance.WorldDone)
		{
			ModelBase<SubPackageDownLoadModel>.Instance.UpdaterDownLoadSize();
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.SubPackageDownloadListFinishConfirm);
			confirmBoxDataNew.FunctionMap.Add(1, delegate
			{
				ControllerBase<ConfirmBoxController>.Instance.CloseConfirmBoxView();
			});
			confirmBoxDataNew.FunctionMap.Add(2, delegate
			{
				if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.SubPackageDownLoadView))
				{
					Singleton<UiManager>.Instance.CloseView(EUiViewName.SubPackageDownLoadView, null);
				}
				CustomPromise loginPrepareResCheckPromise = ControllerBase<ResourceManagerController>.Instance.LoginPrepareResCheckPromise;
				if (loginPrepareResCheckPromise == null)
				{
					return;
				}
				loginPrepareResCheckPromise.SetResult();
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowNetWorkConfirmBoxView(confirmBoxDataNew, null);
		}
		ModelBase<SubPackageDownLoadModel>.Instance.SetSubPackageDownLoadItemStateMap(subPackage, ESubPackageDownLoadState.Finish);
		ModelBase<SubPackageDownLoadModel>.Instance.SubPackageDownLoadList = (from value in ModelBase<SubPackageDownLoadModel>.Instance.SubPackageDownLoadList
		where value != subPackage
		select value).ToList<int>();
		DownLoadSubPackage value2 = ConfigBase<SubPackageConfig>.Instance.GetDownLoadSubPackageById(subPackage).Value;
		if (value2.Type == 4)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("SubPackageDownLoad_Gender_Tips", Array.Empty<object>());
		}
		else
		{
			bool flag = false;
			if (value2.Type == 2)
			{
				List<int> list = new List<int>();
				foreach (int num in value2.Area())
				{
					if (!ControllerBase<ResourceManagerController>.Instance.IsNeedReOpenMap(num))
					{
						list.Add(num);
						flag = true;
					}
				}
				this.SceneBlockChangePush(list, null);
			}
			if (ModelBase<GameModeModel>.Instance.WorldDone)
			{
				string localTextNew = ConfigMultiTextLang.GetLocalTextNew(value2.Title, null);
				if (!flag)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("SubPackageDownLoad_Finish_Tips", new object[]
					{
						localTextNew
					});
				}
				else
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("SubPackageDownLoad_Finish_Restart_Tips", new object[]
					{
						localTextNew
					});
				}
			}
		}
		ControllerBase<ResourceManagerController>.Instance.UpdateServerQuestState();
		ModelBase<SubPackageDownLoadModel>.Instance.DownLoadingSubPackageId = 0;
		this.DownLoadPackage();
		Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshSubPackageDownLoadByPriority);
		this.SaveLocalDownLoadList();
	}

	// Token: 0x06015D38 RID: 89400 RVA: 0x0060E034 File Offset: 0x0060C234
	private void EnterAreaNotify(int areaId)
	{
		if (ControllerBase<ConfirmBoxController>.Instance.CheckIsConfirmBoxOpen())
		{
			return;
		}
		int blockBelongToSubPackage = ModelBase<SubPackageDownLoadModel>.Instance.GetBlockBelongToSubPackage(areaId);
		if (ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageDownLoadItemStateById(blockBelongToSubPackage) != ESubPackageDownLoadState.DownLoading)
		{
			if (!this.CheckBlockHaveDownLoad(areaId))
			{
				ModelBase<SubPackageDownLoadModel>.Instance.OpenSubPackageDownLoadConfirm("SubPackageDownLoad_CommonLock_Confirm", new List<int>
				{
					areaId
				}, null, new double?((double)this.ENTER_AREA_CD));
			}
			if (ControllerBase<ResourceManagerController>.Instance.IsNeedReOpenMap(areaId))
			{
				ModelBase<SubPackageDownLoadModel>.Instance.OpenBlockNeedReLoginConfirm();
			}
			return;
		}
		float? nextCanShowTipsTime = this.NextCanShowTipsTime;
		double? num = (nextCanShowTipsTime != null) ? new double?((double)nextCanShowTipsTime.GetValueOrDefault()) : null;
		double serverTimeStamp = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
		if (num.GetValueOrDefault() > serverTimeStamp & num != null)
		{
			return;
		}
		this.NextCanShowTipsTime = new float?((float)Singleton<TimeUtil>.Instance.GetServerTimeStamp() + this.ENTER_AREA_CD);
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("SubPackageDownLoad_Downloading", Array.Empty<object>());
	}

	// Token: 0x06015D39 RID: 89401 RVA: 0x0060E135 File Offset: 0x0060C335
	private void OnRoleChangeEnd()
	{
		if (!Singleton<ResourceDiffUpdaterManager>.Instance.IsGrayBoxHit())
		{
			return;
		}
		ControllerBase<ResourceManagerController>.Instance.UpdateServerQuestState();
	}

	// Token: 0x06015D3A RID: 89402 RVA: 0x0060E150 File Offset: 0x0060C350
	private void WorldDoneAndCloseLoading()
	{
		this.DeleteUnneededResourceOnInit();
		if (!Singleton<ResourceDiffUpdaterManager>.Instance.IsGrayBoxHit())
		{
			return;
		}
		if (HotFixManager.HandleAutoClear)
		{
			LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.SubDownLoadClearOnLogin, true);
			HotFixManager.HandleAutoClear = false;
		}
		List<int> player = LocalStorage.GetPlayer<List<int>>(ELocalStoragePlayerKey.SubDownLoadLastDownLoadList, null);
		if (player == null || player.Count <= 0)
		{
			return;
		}
		foreach (int num in player)
		{
			if (ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageDownLoadItemStateById(num) != ESubPackageDownLoadState.Finish && num != ModelBase<SubPackageDownLoadModel>.Instance.DownLoadingSubPackageId && num != ModelBase<SubPackageDownLoadModel>.Instance.PauseSubPackageId && !ModelBase<SubPackageDownLoadModel>.Instance.SubPackageDownLoadList.Contains(num))
			{
				ModelBase<SubPackageDownLoadModel>.Instance.SubPackageDownLoadList.Add(num);
				ModelBase<SubPackageDownLoadModel>.Instance.SetSubPackageDownLoadItemStateMap(num, ESubPackageDownLoadState.Waiting);
			}
		}
		if (ModelBase<SubPackageDownLoadModel>.Instance.PauseSubPackageId == 0)
		{
			this.DownLoadPackage();
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshSubPackageDownLoadByPriority);
		this.SaveLocalDownLoadList();
	}

	// Token: 0x06015D3B RID: 89403 RVA: 0x0060E25C File Offset: 0x0060C45C
	public bool CheckBlockHaveDownLoad(int blockId)
	{
		if (!Singleton<ResourceDiffUpdaterManager>.Instance.IsGrayBoxHit())
		{
			return true;
		}
		int blockBelongToSubPackage = ModelBase<SubPackageDownLoadModel>.Instance.GetBlockBelongToSubPackage(blockId);
		return ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageDownLoadItemStateById(blockBelongToSubPackage) == ESubPackageDownLoadState.Finish;
	}

	// Token: 0x06015D3C RID: 89404 RVA: 0x0060E294 File Offset: 0x0060C494
	public void SaveLocalDownLoadList()
	{
		if (ModelBase<PlayerInfoModel>.Instance.GetId().GetValueOrDefault() <= 0)
		{
			Singleton<Log>.Instance.Info(ELogModule.SubPackageDownLoad, ELogAuthor.LJQ, "SaveLocalDownLoadList,尚未登录直接返回", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		List<int> list = new List<int>();
		list.AddRange(ModelBase<SubPackageDownLoadModel>.Instance.SubPackageDownLoadList);
		int downLoadingSubPackageId = ModelBase<SubPackageDownLoadModel>.Instance.DownLoadingSubPackageId;
		if (downLoadingSubPackageId != 0)
		{
			list.Insert(0, downLoadingSubPackageId);
		}
		LocalStorage.SetPlayer<List<int>>(ELocalStoragePlayerKey.SubDownLoadLastDownLoadList, list);
	}

	// Token: 0x06015D3D RID: 89405 RVA: 0x0060E310 File Offset: 0x0060C510
	public void ClearLocalDownLoadList()
	{
		if (ModelBase<PlayerInfoModel>.Instance.GetId().GetValueOrDefault() <= 0)
		{
			Singleton<Log>.Instance.Info(ELogModule.SubPackageDownLoad, ELogAuthor.LJQ, "ClearLocalDownLoadList,尚未登录直接返回", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		LocalStorage.SetPlayer<List<int>>(ELocalStoragePlayerKey.SubDownLoadLastDownLoadList, new List<int>());
	}

	// Token: 0x06015D3E RID: 89406 RVA: 0x0060E364 File Offset: 0x0060C564
	public void ReportSubPackageKeySubPackageLogEvent(int time, int state)
	{
		SubPackageKeySubPackageLogEvent subPackageKeySubPackageLogEvent = new SubPackageKeySubPackageLogEvent();
		subPackageKeySubPackageLogEvent.i_download_time = time;
		subPackageKeySubPackageLogEvent.i_download_status = state;
		subPackageKeySubPackageLogEvent.o_phantoms = ModelBase<SubPackageDownLoadModel>.Instance.KeyIncludeSubPackageList;
		ControllerBase<LogReportController>.Instance.LogReport(subPackageKeySubPackageLogEvent);
	}

	// Token: 0x06015D3F RID: 89407 RVA: 0x0060E3A0 File Offset: 0x0060C5A0
	public void ReportSubPackageDownLoadLogEvent(int subPackageId, int state, ResourceDiffUpdater update)
	{
		SubPackageDownLoadLogEvent subPackageDownLoadLogEvent = new SubPackageDownLoadLogEvent();
		subPackageDownLoadLogEvent.s_suit_name = update.Name;
		subPackageDownLoadLogEvent.b_if_storage_alert = ModelBase<SubPackageDownLoadModel>.Instance.HaveTipsOutOfSpaceList.Contains(subPackageId);
		subPackageDownLoadLogEvent.i_peak_speed = (int)((double)update.ViewInfo.DownloadSpeedMax / 1048576.0);
		subPackageDownLoadLogEvent.i_download_time = 0;
		subPackageDownLoadLogEvent.i_download_status = state;
		subPackageDownLoadLogEvent.i_resource_type = ConfigBase<SubPackageConfig>.Instance.GetDownLoadSubPackageById(subPackageId).Value.Type;
		subPackageDownLoadLogEvent.i_resource_size = (int)((double)update.ViewInfo.TotalSize / 1048576.0);
		subPackageDownLoadLogEvent.i_state = (ModelBase<GameModeModel>.Instance.WorldDone ? 2 : 1);
		subPackageDownLoadLogEvent.i_role_id = ((ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Male) ? 1 : 2);
		ControllerBase<LogReportController>.Instance.LogReport(subPackageDownLoadLogEvent);
	}

	// Token: 0x06015D40 RID: 89408 RVA: 0x0060E478 File Offset: 0x0060C678
	public void ReportSubPackageOutOfSpaceLogEvent(int subPackageId, long requiredSpace, long remainingSpace)
	{
		SubPackageOutOfSpaceLogEvent subPackageOutOfSpaceLogEvent = new SubPackageOutOfSpaceLogEvent();
		subPackageOutOfSpaceLogEvent.s_suit_name = subPackageId.ToString();
		subPackageOutOfSpaceLogEvent.b_if_storage_alert = ModelBase<SubPackageDownLoadModel>.Instance.HaveTipsOutOfSpaceList.Contains(subPackageId);
		subPackageOutOfSpaceLogEvent.i_resource_type = ConfigBase<SubPackageConfig>.Instance.GetDownLoadSubPackageById(subPackageId).Value.Type;
		subPackageOutOfSpaceLogEvent.i_required_space = (int)((double)requiredSpace / 1048576.0);
		subPackageOutOfSpaceLogEvent.i_remaining_space = (int)((double)remainingSpace / 1048576.0);
		subPackageOutOfSpaceLogEvent.i_role_id = ((ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Male) ? 1 : 2);
		ControllerBase<LogReportController>.Instance.LogReport(subPackageOutOfSpaceLogEvent);
	}

	// Token: 0x06015D41 RID: 89409 RVA: 0x0060E518 File Offset: 0x0060C718
	public void ReportSubPackageClearSpaceLogEvent()
	{
		SubPackageClearSpaceLogEvent subPackageClearSpaceLogEvent = new SubPackageClearSpaceLogEvent();
		bool player = LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.SubDownLoadClearOnLogin, false);
		subPackageClearSpaceLogEvent.b_if_storage_alert = player;
		subPackageClearSpaceLogEvent.i_required_space = (int)((double)ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageCanClearSpace() / 1048576.0);
		ControllerBase<LogReportController>.Instance.LogReport(subPackageClearSpaceLogEvent);
	}

	// Token: 0x06015D42 RID: 89410 RVA: 0x0060E568 File Offset: 0x0060C768
	public void ReportSubPackageClearSpaceFinishLogEvent(bool isAuto)
	{
		SubPackageClearSpaceFinishLogEvent subPackageClearSpaceFinishLogEvent = new SubPackageClearSpaceFinishLogEvent();
		subPackageClearSpaceFinishLogEvent.b_if_storage_alert = isAuto;
		subPackageClearSpaceFinishLogEvent.i_required_space = (int)((double)ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageCanClearSpace() / 1048576.0);
		subPackageClearSpaceFinishLogEvent.i_remaining_space = (int)((double)Singleton<VideoResUpdate>.Instance.GetFreeSpace() / 1048576.0);
		ControllerBase<LogReportController>.Instance.LogReport(subPackageClearSpaceFinishLogEvent);
	}

	// Token: 0x06015D43 RID: 89411 RVA: 0x0060E5C8 File Offset: 0x0060C7C8
	public void ReportInitialMobileResCleanUpViewLogEvent(int canCleanSpace, int type)
	{
		InitialMobileResCleanUpViewLogEvent initialMobileResCleanUpViewLogEvent = new InitialMobileResCleanUpViewLogEvent();
		initialMobileResCleanUpViewLogEvent.i_remaining_space = canCleanSpace;
		initialMobileResCleanUpViewLogEvent.i_type = type;
		initialMobileResCleanUpViewLogEvent.s_trace_id = this.MobileResCleanUpTraceId.ToString();
		initialMobileResCleanUpViewLogEvent.unique_id = ModelBase<LoginModel>.Instance.GetLoginUid();
		int? num;
		initialMobileResCleanUpViewLogEvent.player_id = (((ModelBase<PlayerInfoModel>.Instance.GetId() != null) ? num.GetValueOrDefault().ToString() : null) ?? "");
		ControllerBase<LogReportController>.Instance.LogReport(initialMobileResCleanUpViewLogEvent);
	}

	// Token: 0x06015D44 RID: 89412 RVA: 0x0060E64C File Offset: 0x0060C84C
	public void ReportMobileResCleanUpLogEvent(int selectSpace, List<MobileResCleanUpLogEventContentData> content, int type)
	{
		MobileResCleanUpLogEvent mobileResCleanUpLogEvent = new MobileResCleanUpLogEvent();
		mobileResCleanUpLogEvent.i_required_space = selectSpace;
		mobileResCleanUpLogEvent.o_content = content;
		mobileResCleanUpLogEvent.i_type = type;
		mobileResCleanUpLogEvent.s_trace_id = this.MobileResCleanUpTraceId.ToString();
		mobileResCleanUpLogEvent.unique_id = ModelBase<LoginModel>.Instance.GetLoginUid();
		int? num;
		mobileResCleanUpLogEvent.player_id = (((ModelBase<PlayerInfoModel>.Instance.GetId() != null) ? num.GetValueOrDefault().ToString() : null) ?? "");
		ControllerBase<LogReportController>.Instance.LogReport(mobileResCleanUpLogEvent);
	}

	// Token: 0x06015D45 RID: 89413 RVA: 0x0060E6D8 File Offset: 0x0060C8D8
	public void ReportMobileResCleanUpFinishLogEvent()
	{
		MobileResCleanUpFinishLogEvent mobileResCleanUpFinishLogEvent = new MobileResCleanUpFinishLogEvent();
		mobileResCleanUpFinishLogEvent.s_trace_id = this.MobileResCleanUpTraceId.ToString();
		mobileResCleanUpFinishLogEvent.unique_id = ModelBase<LoginModel>.Instance.GetLoginUid();
		int? num;
		mobileResCleanUpFinishLogEvent.player_id = (((ModelBase<PlayerInfoModel>.Instance.GetId() != null) ? num.GetValueOrDefault().ToString() : null) ?? "");
		ControllerBase<LogReportController>.Instance.LogReport(mobileResCleanUpFinishLogEvent);
	}

	// Token: 0x06015D46 RID: 89414 RVA: 0x0060E74C File Offset: 0x0060C94C
	public void ClearSubPackage(List<int> sceneIdList, bool clearVideo)
	{
		int num = clearVideo ? ((int)ModelBase<SubPackageDownLoadModel>.Instance.GetCanCleanVideoSpace()) : 0;
		foreach (int id in sceneIdList)
		{
			num += (int)ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageHaveDownLoadSpace(id);
		}
		List<MobileResCleanUpLogEventContentData> list = new List<MobileResCleanUpLogEventContentData>();
		HashSet<string> hashSet = new HashSet<string>();
		foreach (int id2 in sceneIdList)
		{
			this.CancelSubPackageDownLoading(id2);
			foreach (int num2 in ConfigBase<SubPackageConfig>.Instance.GetDownLoadSubPackageById(id2).Value.AreaIter())
			{
				string blockPackName = Singleton<ResourceDiffUpdaterManager>.Instance.BlockModule.GetBlockPackName(num2);
				if (blockPackName != null)
				{
					hashSet.Add(blockPackName);
					list.Add(new MobileResCleanUpLogEventContentData
					{
						Type = 1,
						Id = num2
					});
				}
			}
		}
		Singleton<ResourceDiffUpdaterManager>.Instance.BlockModule.Delete(hashSet.ToList<string>());
		if (clearVideo)
		{
			List<int> finishQuestList = ModelBase<QuestNewModel>.Instance.GetFinishQuestList();
			HashSet<int> unusedVideos = Singleton<ResourceDiffUpdaterManager>.Instance.VideoModule.GetUnusedVideos(new HashSet<int>(finishQuestList));
			foreach (int id3 in unusedVideos)
			{
				list.Add(new MobileResCleanUpLogEventContentData
				{
					Type = 2,
					Id = id3
				});
			}
			Singleton<ResourceDiffUpdaterManager>.Instance.VideoModule.DeleteByVideoIds(unusedVideos);
		}
		this.ReportMobileResCleanUpLogEvent(num, list, 2);
		this.ReportMobileResCleanUpFinishLogEvent();
		Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshSubPackClearData);
	}

	// Token: 0x0400A775 RID: 42869
	public float ENTER_AREA_CD = 10000f;

	// Token: 0x0400A776 RID: 42870
	private bool? HaveDeleteUnneededResourceOnInit = new bool?(false);

	// Token: 0x0400A777 RID: 42871
	private bool? AgreeUseCell = new bool?(false);

	// Token: 0x0400A778 RID: 42872
	private float? NextCanShowTipsTime = new float?(0f);

	// Token: 0x0400A779 RID: 42873
	public int MobileResCleanUpTraceId = -1;
}
