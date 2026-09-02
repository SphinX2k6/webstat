using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.RoleLangCustomModel;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.Update;
using CSharpScript.Launcher.Update.ResourceDiffUpdate;
using CSharpScript.Launcher.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002AB2 RID: 10930
[NullableContext(1)]
[Nullable(0)]
public class SubPackageDownLoadMobileClearPopView : UiViewBase
{
	// Token: 0x06015DE9 RID: 89577 RVA: 0x00612029 File Offset: 0x00610229
	public SubPackageDownLoadMobileClearPopView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06015DEA RID: 89578 RVA: 0x00612048 File Offset: 0x00610248
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickConfirmBtn)),
			new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnClickAutoClearToggle))
		};
	}

	// Token: 0x06015DEB RID: 89579 RVA: 0x006120F4 File Offset: 0x006102F4
	protected override UniTask OnBeforeStartAsync()
	{
		SubPackageDownLoadMobileClearPopView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SubPackageDownLoadMobileClearPopView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015DEC RID: 89580 RVA: 0x00612138 File Offset: 0x00610338
	protected override void OnStart()
	{
		this.SubPackageScrollView = new GenericScrollViewNew<SubPackageDownLoadMobileClearItem, ISubPackageDownLoadMobileClearData>(base.GetScrollViewWithScrollbar(2), new Func<SubPackageDownLoadMobileClearItem>(this.InitSubPackageDownLoadMobileClearItem), null, false, null);
		this.SubPackageScrollView.RefreshByData(this.GetScrollViewDataList(), new Action(this.RefreshButton), false);
		bool player = LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.SubDownLoadClearOnLogin, false);
		UUIExtendToggle extendToggle = base.GetExtendToggle(1);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(player ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, true, false, false);
		}
		ControllerBase<SubPackageController>.Instance.MobileResCleanUpTraceId = new Random().Next(0, 1000000);
		ControllerBase<SubPackageController>.Instance.ReportInitialMobileResCleanUpViewLogEvent((int)(this.AllCanClearSpace / 1048576L), 3);
	}

	// Token: 0x06015DED RID: 89581 RVA: 0x006121E0 File Offset: 0x006103E0
	private List<ISubPackageDownLoadMobileClearData> GetScrollViewDataList()
	{
		List<ISubPackageDownLoadMobileClearData> list = new List<ISubPackageDownLoadMobileClearData>();
		ISubPackageDownLoadMobileClearData subPackageDownLoadMobileClearData = new SubPackageDownLoadMobileClearData
		{
			TitleId = 3
		};
		subPackageDownLoadMobileClearData.HaveVideoCanClear = new bool?(this.GetPlotData());
		list.Add(subPackageDownLoadMobileClearData);
		ISubPackageDownLoadMobileClearData subPackageDownLoadMobileClearData2 = new SubPackageDownLoadMobileClearData
		{
			TitleId = 2
		};
		subPackageDownLoadMobileClearData2.SceneIdList = this.GetSceneData();
		list.Add(subPackageDownLoadMobileClearData2);
		ISubPackageDownLoadMobileClearData subPackageDownLoadMobileClearData3 = new SubPackageDownLoadMobileClearData
		{
			TitleId = 5
		};
		subPackageDownLoadMobileClearData3.VoiceLanguageCodeList = this.GetVoiceData();
		list.Add(subPackageDownLoadMobileClearData3);
		return list;
	}

	// Token: 0x06015DEE RID: 89582 RVA: 0x00612258 File Offset: 0x00610458
	private List<int> GetSceneData()
	{
		List<int> list = new List<int>();
		foreach (int num in ModelBase<SubPackageDownLoadModel>.Instance.GetCanCleanSceneIdList())
		{
			long subPackageHaveDownLoadSpace = ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageHaveDownLoadSpace(num);
			if (subPackageHaveDownLoadSpace > 0L)
			{
				list.Add(num);
				this.AllCanClearSpace += subPackageHaveDownLoadSpace;
			}
		}
		if (list.Count <= 0)
		{
			list.Add(-1);
		}
		return list;
	}

	// Token: 0x06015DEF RID: 89583 RVA: 0x006122E8 File Offset: 0x006104E8
	private bool GetPlotData()
	{
		long canCleanVideoSpace = ModelBase<SubPackageDownLoadModel>.Instance.GetCanCleanVideoSpace();
		this.AllCanClearSpace += canCleanVideoSpace;
		return canCleanVideoSpace > 0L;
	}

	// Token: 0x06015DF0 RID: 89584 RVA: 0x00612314 File Offset: 0x00610514
	private List<string> GetVoiceData()
	{
		List<string> list = new List<string>();
		string packageAudio = Singleton<LanguageSystem>.Instance.PackageAudio;
		IEnumerable<LaunchLangDefine> allLanguageDefines = Singleton<LauncherLanguageLib>.Instance.GetAllLanguageDefines();
		HashSet<string> hashSet = new HashSet<string>();
		foreach (LaunchLangDefine launchLangDefine in allLanguageDefines)
		{
			string audioCode = launchLangDefine.AudioCode;
			if (!hashSet.Contains(audioCode))
			{
				hashSet.Add(audioCode);
				if (!(audioCode == packageAudio))
				{
					LanguageUpdater updater = Singleton<LanguageUpdateManager>.Instance.GetUpdater(audioCode);
					if (updater != null)
					{
						updater.CalculateDownloadStatus("SubPackageDownLoadMobileClearPopView GetVoiceData");
						if (updater.Status == ELanguageDownloadStatus.Done && Singleton<ResourceDiffUpdaterManager>.Instance.VoiceModule.GetLocalSizeByAudioCode(audioCode) > 0L)
						{
							list.Add(audioCode);
							this.AllCanClearSpace += updater.TotalDiskSize;
						}
					}
				}
			}
		}
		if (list.Count <= 0)
		{
			list.Add("");
		}
		return list;
	}

	// Token: 0x06015DF1 RID: 89585 RVA: 0x0061240C File Offset: 0x0061060C
	private void DealRoleLangCustom()
	{
		if (!LocalStorage.HasPlayerId())
		{
			return;
		}
		RoleLangCustomModel instance = ModelBase<RoleLangCustomModel>.Instance;
		if (instance == null)
		{
			return;
		}
		instance.CheckAndApplyPlayerVoiceAll();
	}

	// Token: 0x06015DF2 RID: 89586 RVA: 0x00612425 File Offset: 0x00610625
	private SubPackageDownLoadMobileClearItem InitSubPackageDownLoadMobileClearItem()
	{
		return new SubPackageDownLoadMobileClearItem
		{
			OnClickToggleCallBack = new Action<int?, bool, EToggleState, string>(this.OnSelectSubItem),
			OnClickHelpBtnCallBack = new Action<int, UUIItem>(this.OnClickHelpBtn)
		};
	}

	// Token: 0x06015DF3 RID: 89587 RVA: 0x00612450 File Offset: 0x00610650
	private void OnClickAutoClearToggle(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.SubDownLoadClearOnLogin, true);
			return;
		}
		if (state == EToggleState.ETT_UnChecked)
		{
			LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.SubDownLoadClearOnLogin, false);
		}
	}

	// Token: 0x06015DF4 RID: 89588 RVA: 0x00612474 File Offset: 0x00610674
	private void OnClickConfirmBtn()
	{
		if (this.CurrentSelectInfoIdSet.Count <= 0)
		{
			if (this.HaveSelectVideo)
			{
				ControllerBase<SubPackageController>.Instance.ClearSubPackage(new List<int>(), this.HaveSelectVideo);
			}
			if (this.SelectVoiceCodeSet.Count > 0)
			{
				foreach (string audioCode in this.SelectVoiceCodeSet)
				{
					Singleton<ResourceDiffUpdaterManager>.Instance.VoiceModule.DeleteByAudioCode(audioCode);
				}
				this.DealRoleLangCustom();
			}
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ClearBlockFinishTips", Array.Empty<object>());
			base.CloseMe(null);
			return;
		}
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ConnectBanCleanResource", Array.Empty<object>());
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ClearBlockSubPackageConfirm);
		confirmBoxDataNew.IsEscViewTriggerCallBack = false;
		confirmBoxDataNew.FunctionMap.Add(2, delegate
		{
			ControllerBase<SubPackageController>.Instance.ClearSubPackage(new List<int>(this.CurrentSelectInfoIdSet), this.HaveSelectVideo);
			if (this.SelectVoiceCodeSet.Count > 0)
			{
				foreach (string audioCode2 in this.SelectVoiceCodeSet)
				{
					Singleton<ResourceDiffUpdaterManager>.Instance.VoiceModule.DeleteByAudioCode(audioCode2);
				}
				this.DealRoleLangCustom();
			}
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ClearBlockFinishTips", Array.Empty<object>());
			ControllerBase<ReConnectController>.Instance.Logout(ELogoutReason.ClearBlockReLogin);
			base.CloseMe(null);
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.SubPackageDownLoadFreeSpaceTipsView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.SubPackageDownLoadFreeSpaceTipsView, null);
			}
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.SubPackageDownLoadView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.SubPackageDownLoadView, null);
			}
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowNetWorkConfirmBoxView(confirmBoxDataNew, null);
	}

	// Token: 0x06015DF5 RID: 89589 RVA: 0x00612584 File Offset: 0x00610784
	[NullableContext(2)]
	private void OnSelectSubItem(int? sceneId, bool isVideo, EToggleState state, string voiceCode)
	{
		if (state == EToggleState.ETT_Checked)
		{
			if (sceneId != null && sceneId.Value != 0)
			{
				this.CurrentSelectInfoIdSet.Add(sceneId.Value);
			}
			else if (isVideo)
			{
				this.HaveSelectVideo = true;
			}
			else if (!string.IsNullOrEmpty(voiceCode))
			{
				this.SelectVoiceCodeSet.Add(voiceCode);
			}
		}
		else if (sceneId != null && sceneId.Value != 0)
		{
			this.CurrentSelectInfoIdSet.Remove(sceneId.Value);
		}
		else if (isVideo)
		{
			this.HaveSelectVideo = false;
		}
		else if (!string.IsNullOrEmpty(voiceCode))
		{
			this.SelectVoiceCodeSet.Remove(voiceCode);
		}
		this.RefreshButton();
	}

	// Token: 0x06015DF6 RID: 89590 RVA: 0x00612634 File Offset: 0x00610834
	private void RefreshButton()
	{
		base.GetButton(0).SetSelfInteractive(this.CurrentSelectInfoIdSet.Count > 0 || this.HaveSelectVideo || this.SelectVoiceCodeSet.Count > 0);
		long num = this.HaveSelectVideo ? ModelBase<SubPackageDownLoadModel>.Instance.GetCanCleanVideoSpace() : 0L;
		foreach (int id in this.CurrentSelectInfoIdSet)
		{
			num += ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageHaveDownLoadSpace(id);
		}
		foreach (string audioCode in this.SelectVoiceCodeSet)
		{
			long localSizeByAudioCode = Singleton<ResourceDiffUpdaterManager>.Instance.VoiceModule.GetLocalSizeByAudioCode(audioCode);
			num += localSizeByAudioCode;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "SubPackageClearButton", new <>z__ReadOnlyArray<object>(new object[]
		{
			ModelBase<SubPackageDownLoadModel>.Instance.ByteConverter(num),
			ModelBase<SubPackageDownLoadModel>.Instance.ByteConverter(this.AllCanClearSpace)
		}));
	}

	// Token: 0x06015DF7 RID: 89591 RVA: 0x00612770 File Offset: 0x00610970
	private void OnClickHelpBtn(int type, UUIItem item)
	{
		SubPackageDownLoadVersionTipsView versionTipsView = this.VersionTipsView;
		if (versionTipsView != null)
		{
			versionTipsView.RefreshItemByClearType((ESubPackageDownLoadPackageType)type, item.D_K2_GetComponentLocation());
		}
		SubPackageDownLoadVersionTipsView versionTipsView2 = this.VersionTipsView;
		if (versionTipsView2 == null)
		{
			return;
		}
		versionTipsView2.SetUiActive(true);
	}

	// Token: 0x0400A7E3 RID: 42979
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<SubPackageDownLoadMobileClearItem, ISubPackageDownLoadMobileClearData> SubPackageScrollView;

	// Token: 0x0400A7E4 RID: 42980
	private readonly HashSet<int> CurrentSelectInfoIdSet = new HashSet<int>();

	// Token: 0x0400A7E5 RID: 42981
	private bool HaveSelectVideo;

	// Token: 0x0400A7E6 RID: 42982
	private readonly HashSet<string> SelectVoiceCodeSet = new HashSet<string>();

	// Token: 0x0400A7E7 RID: 42983
	[Nullable(2)]
	private SubPackageDownLoadVersionTipsView VersionTipsView;

	// Token: 0x0400A7E8 RID: 42984
	private long AllCanClearSpace;

	// Token: 0x0400A7E9 RID: 42985
	private const long MB_SIZE = 1048576L;

	// Token: 0x02008E1E RID: 36382
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402FCFD RID: 195837
		public const int ConfirmBtn = 0;

		// Token: 0x0402FCFE RID: 195838
		public const int AutoClearToggle = 1;

		// Token: 0x0402FCFF RID: 195839
		public const int ScrollView = 2;

		// Token: 0x0402FD00 RID: 195840
		public const int ConfirmBoxText = 5;
	}
}
