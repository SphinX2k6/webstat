using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Launcher.DiffPatch.Data;
using CSharpScript.Launcher.DiffPatch.Update;
using CSharpScript.Launcher.Update;
using CSharpScript.Launcher.Update.ResourceDiffUpdate;
using CSharpScript.Launcher.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02002674 RID: 9844
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class QuestResourceModel : ModelBase<QuestResourceModel>
{
	// Token: 0x17001816 RID: 6166
	// (get) Token: 0x06013660 RID: 79456 RVA: 0x00568755 File Offset: 0x00566955
	public bool IsSeparateVideo
	{
		get
		{
			return Singleton<VideoResUpdate>.Instance.GetIsSeparateVideo();
		}
	}

	// Token: 0x06013661 RID: 79457 RVA: 0x00568764 File Offset: 0x00566964
	protected override bool OnInit()
	{
		if (!Singleton<VideoResUpdate>.Instance.GetIsSeparateVideo())
		{
			return true;
		}
		IReadOnlyList<QuestRefVideoConfig> configList = ConfigQuestRefVideoConfigAll.GetConfigList(true);
		if (configList == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.QuestResource, ELogAuthor.ZWY, "找不到任务视频对照配置", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		HashSet<string> hashSet = new HashSet<string>();
		HashSet<string> hashSet2 = new HashSet<string>();
		foreach (QuestRefVideoConfig questRefVideoConfig in configList)
		{
			if (questRefVideoConfig.GirlOrBoy == 0)
			{
				if (this.FemaleQuestRef.ContainsKey(questRefVideoConfig.QuestId))
				{
					this.FemaleQuestRef[questRefVideoConfig.QuestId].Add(questRefVideoConfig.PakName);
				}
				else
				{
					List<string> list = new List<string>();
					list.Add(questRefVideoConfig.PakName);
					this.FemaleQuestRef[questRefVideoConfig.QuestId] = list;
				}
				if (!questRefVideoConfig.PakName.EndsWith("2"))
				{
					hashSet2.Add(questRefVideoConfig.PakName);
				}
			}
			else if (questRefVideoConfig.GirlOrBoy == 1)
			{
				if (this.MaleQuestRef.ContainsKey(questRefVideoConfig.QuestId))
				{
					this.MaleQuestRef[questRefVideoConfig.QuestId].Add(questRefVideoConfig.PakName);
				}
				else
				{
					List<string> list2 = new List<string>();
					list2.Add(questRefVideoConfig.PakName);
					this.MaleQuestRef[questRefVideoConfig.QuestId] = list2;
				}
				if (!questRefVideoConfig.PakName.EndsWith("2"))
				{
					hashSet.Add(questRefVideoConfig.PakName);
				}
			}
			string[] array = questRefVideoConfig.PakName.Split('_', StringSplitOptions.None);
			int item;
			if (array.Length != 0 && int.TryParse(array[0], out item))
			{
				if (this.QuestRefCgIds.ContainsKey(questRefVideoConfig.QuestId))
				{
					this.QuestRefCgIds[questRefVideoConfig.QuestId].Add(item);
				}
				else
				{
					HashSet<int> hashSet3 = new HashSet<int>();
					hashSet3.Add(item);
					this.QuestRefCgIds[questRefVideoConfig.QuestId] = hashSet3;
				}
			}
		}
		Singleton<VideoResUpdate>.Instance.SetAllSpecialVideoResPak(EVideoResSizeType.FemalePrepare, hashSet2.ToList<string>());
		Singleton<VideoResUpdate>.Instance.SetAllSpecialVideoResPak(EVideoResSizeType.MalePrepare, hashSet.ToList<string>());
		Singleton<VideoResUpdate>.Instance.CheckVideoManifestsData();
		this.UserFirstSelectedVideoUpdate = Singleton<LauncherStorageLib>.Instance.GetDeviceSaved<int>(ELauncherStorageDeviceKey.UserFirstSelectedVideoUpdate, 0);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.QuestResource;
		ELogAuthor author = ELogAuthor.ZWY;
		string message = "用户最初选择任务资源状态";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("state", this.UserFirstSelectedVideoUpdate);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return true;
	}

	// Token: 0x17001817 RID: 6167
	// (get) Token: 0x06013662 RID: 79458 RVA: 0x00568A04 File Offset: 0x00566C04
	public Dictionary<int, List<string>> FemaleQuestIdToPack
	{
		get
		{
			return this.FemaleQuestRef;
		}
	}

	// Token: 0x17001818 RID: 6168
	// (get) Token: 0x06013663 RID: 79459 RVA: 0x00568A0C File Offset: 0x00566C0C
	public Dictionary<int, List<string>> MaleQuestIdToPack
	{
		get
		{
			return this.MaleQuestRef;
		}
	}

	// Token: 0x17001819 RID: 6169
	// (get) Token: 0x06013664 RID: 79460 RVA: 0x00568A14 File Offset: 0x00566C14
	public Dictionary<int, HashSet<int>> QuestIdToCgIds
	{
		get
		{
			return this.QuestRefCgIds;
		}
	}

	// Token: 0x06013665 RID: 79461 RVA: 0x00568A1C File Offset: 0x00566C1C
	protected override bool OnClear()
	{
		Singleton<VideoResUpdate>.Instance.GetIsSeparateVideo();
		return true;
	}

	// Token: 0x06013666 RID: 79462 RVA: 0x00568A2A File Offset: 0x00566C2A
	public void ClearCheckQuests()
	{
		this.LoginQuests.Clear();
	}

	// Token: 0x06013667 RID: 79463 RVA: 0x00568A38 File Offset: 0x00566C38
	public void FillCheckQuests(int[] quests)
	{
		this.LoginQuests.Clear();
		foreach (int item in quests)
		{
			this.LoginQuests.Add(item);
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.QuestResource;
		ELogAuthor author = ELogAuthor.ZWY;
		string message = "收到登录任务通知，填充任务视频检查数据";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("questIds", this.LoginQuests);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.LoginQuestsInitialed = true;
	}

	// Token: 0x06013668 RID: 79464 RVA: 0x00568AA4 File Offset: 0x00566CA4
	public void FillFinishedQuests(int[] quests)
	{
		this.LoginFinishedQuests.Clear();
		foreach (int item in quests)
		{
			this.LoginFinishedQuests.Add(item);
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.QuestResource;
		ELogAuthor author = ELogAuthor.HWK;
		string message = "收到登录任务通知，填充已完成任务视频检查数据";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("questIds", this.LoginFinishedQuests);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.LoginFinishedQuestsInitialed = true;
	}

	// Token: 0x06013669 RID: 79465 RVA: 0x00568B10 File Offset: 0x00566D10
	private List<string> GetLoginPakNamesWithoutFinishedQuests(EPlayerGender gender = EPlayerGender.None)
	{
		HashSet<string> hashSet = new HashSet<string>();
		if (gender == EPlayerGender.Female || gender == EPlayerGender.None)
		{
			foreach (KeyValuePair<int, List<string>> keyValuePair in this.FemaleQuestRef)
			{
				if (!this.LoginFinishedQuests.Contains(keyValuePair.Key))
				{
					foreach (string item in keyValuePair.Value)
					{
						hashSet.Add(item);
					}
				}
			}
		}
		if (gender == EPlayerGender.Male || gender == EPlayerGender.None)
		{
			foreach (KeyValuePair<int, List<string>> keyValuePair2 in this.MaleQuestRef)
			{
				if (!this.LoginFinishedQuests.Contains(keyValuePair2.Key))
				{
					foreach (string item2 in keyValuePair2.Value)
					{
						hashSet.Add(item2);
					}
				}
			}
		}
		if (hashSet.Count > 0)
		{
			return hashSet.ToList<string>();
		}
		return new List<string>();
	}

	// Token: 0x0601366A RID: 79466 RVA: 0x00568C78 File Offset: 0x00566E78
	private List<string> GetLoginQuestsPakNames()
	{
		if (this.LoginQuests.Count == 0)
		{
			return new List<string>();
		}
		HashSet<string> hashSet = new HashSet<string>();
		EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
		if (playerGender == EPlayerGender.Female)
		{
			using (HashSet<int>.Enumerator enumerator = this.LoginQuests.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int key = enumerator.Current;
					List<string> list;
					if (this.FemaleQuestRef.TryGetValue(key, out list))
					{
						foreach (string item in list)
						{
							hashSet.Add(item);
						}
					}
				}
				goto IL_11A;
			}
		}
		if (playerGender == EPlayerGender.Male)
		{
			foreach (int key2 in this.LoginQuests)
			{
				List<string> list2;
				if (this.MaleQuestRef.TryGetValue(key2, out list2))
				{
					foreach (string item2 in list2)
					{
						hashSet.Add(item2);
					}
				}
			}
		}
		IL_11A:
		if (hashSet.Count > 0)
		{
			return hashSet.ToList<string>();
		}
		return new List<string>();
	}

	// Token: 0x0601366B RID: 79467 RVA: 0x00568DE8 File Offset: 0x00566FE8
	public bool NeedCheckQuestResource()
	{
		List<string> loginNeedDownloadPakNames = this.GetLoginNeedDownloadPakNames();
		ValueTuple<List<RequireFileInfo>, long, long, List<LocalFileInfo>> valueTuple = Singleton<VideoResUpdate>.Instance.AnalyzeRequireFilesByNames(loginNeedDownloadPakNames);
		return valueTuple.Item2 != valueTuple.Item3;
	}

	// Token: 0x0601366C RID: 79468 RVA: 0x00568E19 File Offset: 0x00567019
	public List<string> GetLoginNeedDownloadPakNames()
	{
		if (Singleton<ResourceDiffUpdaterManager>.Instance.IsGrayBoxHit())
		{
			return this.GetLoginQuestsPakNames();
		}
		return this.GetLoginPakNamesWithoutFinishedQuests(EPlayerGender.None);
	}

	// Token: 0x0601366D RID: 79469 RVA: 0x00568E38 File Offset: 0x00567038
	public void UserClicked()
	{
		if (this.UserClickPromise != null)
		{
			this.UserClickPromise.SetResult();
			return;
		}
		Singleton<Log>.Instance.Error(ELogModule.QuestResource, ELogAuthor.ZWY, "检查任务数据点击回调错误", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x0601366E RID: 79470 RVA: 0x00568E78 File Offset: 0x00567078
	public void UserDownloadSuc()
	{
		if (this.UserDownloadSucPromise != null)
		{
			this.UserDownloadSucPromise.SetResult();
			return;
		}
		Singleton<Log>.Instance.Error(ELogModule.QuestResource, ELogAuthor.ZWY, "检查任务下载回调错误", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x0601366F RID: 79471 RVA: 0x00568EB8 File Offset: 0x005670B8
	public void UserClickOutOfMemoryView(bool result)
	{
		if (this.UserClickOutOfMemoryViewPromise != null)
		{
			this.UserClickOutOfMemoryViewPromise.SetResult(result);
			return;
		}
		Singleton<Log>.Instance.Error(ELogModule.QuestResource, ELogAuthor.ZWY, "检查任务硬盘不足回调错误", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x06013670 RID: 79472 RVA: 0x00568EF8 File Offset: 0x005670F8
	public void UserClickNetWorkError(bool result)
	{
		if (this.UserClickNetWorkErrorPromise != null)
		{
			this.UserClickNetWorkErrorPromise.SetResult(result);
			return;
		}
		Singleton<Log>.Instance.Error(ELogModule.QuestResource, ELogAuthor.ZWY, "检查任务网络异常回调错误", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x06013671 RID: 79473 RVA: 0x00568F36 File Offset: 0x00567136
	public void SetIsDownloadNotEnoughSpaceError(bool result)
	{
		this.IsDownloadNotEnoughSpaceError = result;
	}

	// Token: 0x06013672 RID: 79474 RVA: 0x00568F3F File Offset: 0x0056713F
	public void SetIsReportDownloadNotEnoughSpace(bool result)
	{
		this.IsReportDownloadNotEnoughSpace = new bool?(result);
	}

	// Token: 0x06013673 RID: 79475 RVA: 0x00568F50 File Offset: 0x00567150
	public UniTask CheckQuestResource()
	{
		QuestResourceModel.<CheckQuestResource>d__41 <CheckQuestResource>d__;
		<CheckQuestResource>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CheckQuestResource>d__.<>4__this = this;
		<CheckQuestResource>d__.<>1__state = -1;
		<CheckQuestResource>d__.<>t__builder.Start<QuestResourceModel.<CheckQuestResource>d__41>(ref <CheckQuestResource>d__);
		return <CheckQuestResource>d__.<>t__builder.Task;
	}

	// Token: 0x06013674 RID: 79476 RVA: 0x00568F94 File Offset: 0x00567194
	private void OpenWaitNetworkTypeUserConfirm()
	{
		Singleton<Log>.Instance.Info(ELogModule.QuestResource, ELogAuthor.ZYL, "检查网络: 打开蜂窝网络下载同意弹窗", default(ReadOnlySpan<ValueTuple<string, object>>));
		CustomPromise<bool> waitUserConfirmNetworkTypePromise = this.WaitUserConfirmNetworkTypePromise;
		if (waitUserConfirmNetworkTypePromise != null && waitUserConfirmNetworkTypePromise.IsPending)
		{
			Singleton<Log>.Instance.Warn(ELogModule.QuestResource, ELogAuthor.ZYL, "检查网络: 已存在蜂窝网络下载同意弹窗的Promise, 不重复打开", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.WaitUserConfirmNetworkTypePromise = new CustomPromise<bool>();
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.QuestResDownloadCellNetworkConfirm);
		confirmBoxDataNew.FunctionMap.Add(0, new Action(this.<OpenWaitNetworkTypeUserConfirm>g__OnCancelOrClose|42_1));
		confirmBoxDataNew.FunctionMap.Add(1, new Action(this.<OpenWaitNetworkTypeUserConfirm>g__OnCancelOrClose|42_1));
		confirmBoxDataNew.FunctionMap.Add(2, new Action(this.<OpenWaitNetworkTypeUserConfirm>g__OnConfirm|42_0));
		ControllerBase<ConfirmBoxController>.Instance.ShowNetWorkConfirmBoxView(confirmBoxDataNew, delegate(bool success, int viewId)
		{
			if (!success)
			{
				Singleton<Log>.Instance.Error(ELogModule.QuestResource, ELogAuthor.ZYL, "检查网络: 蜂窝网络下载同意弹窗打开失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.<OpenWaitNetworkTypeUserConfirm>g__OnCancelOrClose|42_1();
				return;
			}
			CustomPromise<bool> waitUserConfirmNetworkTypePromise2 = this.WaitUserConfirmNetworkTypePromise;
			if (waitUserConfirmNetworkTypePromise2 == null || !waitUserConfirmNetworkTypePromise2.IsPending)
			{
				ControllerBase<ConfirmBoxController>.Instance.CloseNetWorkConfirmBoxView(viewId, null);
				return;
			}
			this.WaitUserConfirmNetworkTypeViewId = viewId;
		});
	}

	// Token: 0x06013675 RID: 79477 RVA: 0x00569064 File Offset: 0x00567264
	private void CloseWaitNetworkTypeUserConfirm(bool bConfirm)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.QuestResource;
		ELogAuthor author = ELogAuthor.ZYL;
		string message = "检查网络: 程序主动关闭蜂窝网络下载同意弹窗";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("bConfirm", bConfirm);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		CustomPromise<bool> waitUserConfirmNetworkTypePromise = this.WaitUserConfirmNetworkTypePromise;
		this.WaitUserConfirmNetworkTypePromise = null;
		ControllerBase<ConfirmBoxController>.Instance.CloseNetWorkConfirmBoxView(this.WaitUserConfirmNetworkTypeViewId, null);
		if (waitUserConfirmNetworkTypePromise == null)
		{
			return;
		}
		waitUserConfirmNetworkTypePromise.SetResult(bConfirm);
	}

	// Token: 0x06013676 RID: 79478 RVA: 0x005690C8 File Offset: 0x005672C8
	[NullableContext(0)]
	private UniTask<bool> WaitNetworkTypeUserConfirmResult()
	{
		QuestResourceModel.<WaitNetworkTypeUserConfirmResult>d__44 <WaitNetworkTypeUserConfirmResult>d__;
		<WaitNetworkTypeUserConfirmResult>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<WaitNetworkTypeUserConfirmResult>d__.<>4__this = this;
		<WaitNetworkTypeUserConfirmResult>d__.<>1__state = -1;
		<WaitNetworkTypeUserConfirmResult>d__.<>t__builder.Start<QuestResourceModel.<WaitNetworkTypeUserConfirmResult>d__44>(ref <WaitNetworkTypeUserConfirmResult>d__);
		return <WaitNetworkTypeUserConfirmResult>d__.<>t__builder.Task;
	}

	// Token: 0x06013677 RID: 79479 RVA: 0x0056910C File Offset: 0x0056730C
	public UniTask TryCheckQuestResource()
	{
		QuestResourceModel.<TryCheckQuestResource>d__45 <TryCheckQuestResource>d__;
		<TryCheckQuestResource>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<TryCheckQuestResource>d__.<>4__this = this;
		<TryCheckQuestResource>d__.<>1__state = -1;
		<TryCheckQuestResource>d__.<>t__builder.Start<QuestResourceModel.<TryCheckQuestResource>d__45>(ref <TryCheckQuestResource>d__);
		return <TryCheckQuestResource>d__.<>t__builder.Task;
	}

	// Token: 0x06013678 RID: 79480 RVA: 0x00569150 File Offset: 0x00567350
	[NullableContext(0)]
	public UniTask<bool> CheckQuestData()
	{
		QuestResourceModel.<CheckQuestData>d__46 <CheckQuestData>d__;
		<CheckQuestData>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<CheckQuestData>d__.<>4__this = this;
		<CheckQuestData>d__.<>1__state = -1;
		<CheckQuestData>d__.<>t__builder.Start<QuestResourceModel.<CheckQuestData>d__46>(ref <CheckQuestData>d__);
		return <CheckQuestData>d__.<>t__builder.Task;
	}

	// Token: 0x06013679 RID: 79481 RVA: 0x00569194 File Offset: 0x00567394
	[NullableContext(2)]
	private bool HandlePullResourcePackageResponse(ClientPullResourcePackageResponse response)
	{
		if (response == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.QuestResource, ELogAuthor.HWK, "检查任务数据，拉取登录任务数据失败，response为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		if (response.ErrorId != Aki.Protocol.ErrorCode.Success)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.QuestResource;
			ELogAuthor author = ELogAuthor.HWK;
			string message = "检查任务数据，拉取登录任务数据失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("errCode", response.ErrorId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		this.FillCheckQuests(response.NeedConfirmQuestIds.ToArray<int>());
		this.FillFinishedQuests(response.FinishMp4QuestIds.ToArray<int>());
		return true;
	}

	// Token: 0x0601367A RID: 79482 RVA: 0x00569220 File Offset: 0x00567420
	public unsafe void CalcPrepareResource()
	{
		if (!Singleton<VideoResUpdate>.Instance.GetIsSeparateVideo())
		{
			return;
		}
		EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
		if (this.UseCachePrepareResourceSize)
		{
			return;
		}
		HashSet<string> hashSet = new HashSet<string>();
		foreach (KeyValuePair<int, List<string>> keyValuePair in this.FemaleQuestRef)
		{
			bool flag = ModelBase<QuestNewModel>.Instance.CheckQuestFinished(keyValuePair.Key);
			bool flag2 = playerGender == EPlayerGender.Female && this.LoginQuests.Contains(keyValuePair.Key);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.QuestResource;
			ELogAuthor author = ELogAuthor.HWK;
			string message = "CalcPrepareResource Female";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("questId", keyValuePair.Key);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("isQuestFinished", flag);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("isLoginFinished", flag2);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			if (!flag && !flag2)
			{
				foreach (string item in keyValuePair.Value)
				{
					hashSet.Add(item);
				}
			}
		}
		ValueTuple<List<RequireFileInfo>, long, long, List<LocalFileInfo>> valueTuple = Singleton<VideoResUpdate>.Instance.AnalyzeRequireFilesByNames(hashSet.ToList<string>());
		long item2 = valueTuple.Item2;
		long item3 = valueTuple.Item3;
		Singleton<VideoResUpdate>.Instance.SetVideoResSize(EVideoResSizeType.FemalePrepare, item2);
		Singleton<VideoResUpdate>.Instance.SetVideoResSavedSize(EVideoResSizeType.FemalePrepare, item3);
		Singleton<VideoResUpdate>.Instance.SetVideoResPak(EVideoResSizeType.FemalePrepare, hashSet.ToList<string>());
		if (Singleton<VideoUpdateManager>.Instance.GetVideoUpdater(EVideoResSizeType.FemalePrepare).GetDownLoadState() == EVideoDownloadStatus.None)
		{
			Singleton<VideoUpdateManager>.Instance.GetVideoUpdater(EVideoResSizeType.FemalePrepare).SetDownLoadProgress(item3, item2);
		}
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.QuestResource;
		ELogAuthor author2 = ELogAuthor.ZWY;
		string message2 = "VideoDown CalcPrepareRes Female";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("needSize", item2);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("savedSize", item3);
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
		HashSet<string> hashSet2 = new HashSet<string>();
		foreach (KeyValuePair<int, List<string>> keyValuePair2 in this.MaleQuestRef)
		{
			bool flag3 = ModelBase<QuestNewModel>.Instance.CheckQuestFinished(keyValuePair2.Key);
			bool flag4 = playerGender == EPlayerGender.Male && this.LoginQuests.Contains(keyValuePair2.Key);
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.QuestResource;
			ELogAuthor author3 = ELogAuthor.HWK;
			string message3 = "CalcPrepareResource Male";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("questId", keyValuePair2.Key);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("isQuestFinished", flag3);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("isLoginFinished", flag4);
			instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
			if (!flag3 && !flag4)
			{
				foreach (string item4 in keyValuePair2.Value)
				{
					hashSet2.Add(item4);
				}
			}
		}
		ValueTuple<List<RequireFileInfo>, long, long, List<LocalFileInfo>> valueTuple2 = Singleton<VideoResUpdate>.Instance.AnalyzeRequireFilesByNames(hashSet2.ToList<string>());
		long item5 = valueTuple2.Item2;
		long item6 = valueTuple2.Item3;
		Singleton<VideoResUpdate>.Instance.SetVideoResSize(EVideoResSizeType.MalePrepare, item5);
		Singleton<VideoResUpdate>.Instance.SetVideoResSavedSize(EVideoResSizeType.MalePrepare, item6);
		Singleton<VideoResUpdate>.Instance.SetVideoResPak(EVideoResSizeType.MalePrepare, hashSet2.ToList<string>());
		if (Singleton<VideoUpdateManager>.Instance.GetVideoUpdater(EVideoResSizeType.MalePrepare).GetDownLoadState() == EVideoDownloadStatus.None)
		{
			Singleton<VideoUpdateManager>.Instance.GetVideoUpdater(EVideoResSizeType.MalePrepare).SetDownLoadProgress(item6, item5);
		}
		Log instance4 = Singleton<Log>.Instance;
		ELogModule module4 = ELogModule.QuestResource;
		ELogAuthor author4 = ELogAuthor.ZWY;
		string message4 = "VideoDown CalcPrepareRes Male";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("needSize", item5);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("savedSize", item6);
		instance4.Info(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 2));
		this.UseCachePrepareResourceSize = true;
	}

	// Token: 0x0601367B RID: 79483 RVA: 0x005696C0 File Offset: 0x005678C0
	public void RefreshCachePrepareResourceSize()
	{
		this.UseCachePrepareResourceSize = false;
	}

	// Token: 0x0601367C RID: 79484 RVA: 0x005696CC File Offset: 0x005678CC
	public List<string> GetQuestRefPakNames(int questId, EPlayerGender gender)
	{
		List<string> list = new List<string>();
		List<string> list2;
		if (gender == EPlayerGender.Female && this.FemaleQuestRef.TryGetValue(questId, out list2))
		{
			list = list2;
		}
		List<string> list3;
		if (gender == EPlayerGender.Male && this.MaleQuestRef.TryGetValue(questId, out list3))
		{
			list = list3;
		}
		if (gender == EPlayerGender.None)
		{
			List<string> list4;
			if (this.MaleQuestRef.TryGetValue(questId, out list4))
			{
				list = list4;
			}
			List<string> second;
			if (this.FemaleQuestRef.TryGetValue(questId, out second))
			{
				list = list.Concat(second).ToList<string>();
			}
		}
		return list.Distinct<string>().ToList<string>();
	}

	// Token: 0x0601367D RID: 79485 RVA: 0x0056974C File Offset: 0x0056794C
	public int[] GetQuestRefCgIds(int questId)
	{
		HashSet<int> source;
		if (this.QuestRefCgIds.TryGetValue(questId, out source))
		{
			return source.ToArray<int>();
		}
		return Array.Empty<int>();
	}

	// Token: 0x0601367E RID: 79486 RVA: 0x00569778 File Offset: 0x00567978
	public unsafe List<int> FilterVideoByFinishedQuest(IReadOnlyList<int> videoIds)
	{
		List<int> list = new List<int>();
		HashSet<int> hashSet = new HashSet<int>();
		foreach (KeyValuePair<int, HashSet<int>> keyValuePair in this.QuestRefCgIds)
		{
			if (ModelBase<QuestNewModel>.Instance.CheckQuestFinished(keyValuePair.Key))
			{
				foreach (int item in keyValuePair.Value)
				{
					hashSet.Add(item);
				}
			}
		}
		foreach (int item2 in videoIds)
		{
			if (!hashSet.Contains(item2))
			{
				list.Add(item2);
			}
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.QuestResource;
		ELogAuthor author = ELogAuthor.HWK;
		string message = "过滤已完成任务视频";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("inputVideos", videoIds);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("outputVideos", list);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		return list;
	}

	// Token: 0x06013680 RID: 79488 RVA: 0x00569907 File Offset: 0x00567B07
	[CompilerGenerated]
	private void <OpenWaitNetworkTypeUserConfirm>g__OnConfirm|42_0()
	{
		this.WaitUserConfirmNetworkTypeViewId = 0;
		CustomPromise<bool> waitUserConfirmNetworkTypePromise = this.WaitUserConfirmNetworkTypePromise;
		if (waitUserConfirmNetworkTypePromise != null && waitUserConfirmNetworkTypePromise.IsPending)
		{
			Singleton<VideoResUpdate>.Instance.SetIsAllowCellDownload(true);
			CustomPromise<bool> waitUserConfirmNetworkTypePromise2 = this.WaitUserConfirmNetworkTypePromise;
			this.WaitUserConfirmNetworkTypePromise = null;
			waitUserConfirmNetworkTypePromise2.SetResult(true);
		}
	}

	// Token: 0x06013681 RID: 79489 RVA: 0x00569942 File Offset: 0x00567B42
	[CompilerGenerated]
	private void <OpenWaitNetworkTypeUserConfirm>g__OnCancelOrClose|42_1()
	{
		this.WaitUserConfirmNetworkTypeViewId = 0;
		CustomPromise<bool> waitUserConfirmNetworkTypePromise = this.WaitUserConfirmNetworkTypePromise;
		if (waitUserConfirmNetworkTypePromise != null && waitUserConfirmNetworkTypePromise.IsPending)
		{
			CustomPromise<bool> waitUserConfirmNetworkTypePromise2 = this.WaitUserConfirmNetworkTypePromise;
			this.WaitUserConfirmNetworkTypePromise = null;
			waitUserConfirmNetworkTypePromise2.SetResult(false);
		}
	}

	// Token: 0x04009756 RID: 38742
	private readonly Dictionary<int, List<string>> MaleQuestRef = new Dictionary<int, List<string>>();

	// Token: 0x04009757 RID: 38743
	private readonly Dictionary<int, List<string>> FemaleQuestRef = new Dictionary<int, List<string>>();

	// Token: 0x04009758 RID: 38744
	private readonly Dictionary<int, HashSet<int>> QuestRefCgIds = new Dictionary<int, HashSet<int>>();

	// Token: 0x04009759 RID: 38745
	private bool UseCachePrepareResourceSize;

	// Token: 0x0400975A RID: 38746
	private int UserFirstSelectedVideoUpdate;

	// Token: 0x0400975B RID: 38747
	[Nullable(2)]
	protected CustomPromise UserClickPromise;

	// Token: 0x0400975C RID: 38748
	[Nullable(2)]
	protected CustomPromise UserDownloadSucPromise;

	// Token: 0x0400975D RID: 38749
	[Nullable(2)]
	protected CustomPromise<bool> UserClickOutOfMemoryViewPromise;

	// Token: 0x0400975E RID: 38750
	[Nullable(2)]
	protected CustomPromise<bool> UserClickNetWorkErrorPromise;

	// Token: 0x0400975F RID: 38751
	public readonly HashSet<int> LoginQuests = new HashSet<int>();

	// Token: 0x04009760 RID: 38752
	public readonly HashSet<int> LoginFinishedQuests = new HashSet<int>();

	// Token: 0x04009761 RID: 38753
	private bool LoginQuestsInitialed;

	// Token: 0x04009762 RID: 38754
	private bool LoginFinishedQuestsInitialed;

	// Token: 0x04009763 RID: 38755
	private QuestResourceUpdateProxy UpdateProxy;

	// Token: 0x04009764 RID: 38756
	private int WaitUserConfirmNetworkTypeViewId;

	// Token: 0x04009765 RID: 38757
	private CustomPromise<bool> WaitUserConfirmNetworkTypePromise;

	// Token: 0x04009766 RID: 38758
	private bool IsDownloadNotEnoughSpaceError;

	// Token: 0x04009767 RID: 38759
	private bool? IsReportDownloadNotEnoughSpace;
}
