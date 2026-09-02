using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.ResManager;
using CSharpScript.Game.Module.RoleLangCustomModel;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.Update;
using CSharpScript.Launcher.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.SubViews
{
	// Token: 0x02005797 RID: 22423
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class VoiceLanguageDownloadView : LanguageSettingViewBase<VoiceLanguageToggle>
	{
		// Token: 0x0603906C RID: 233580 RVA: 0x00E7343E File Offset: 0x00E7163E
		public VoiceLanguageDownloadView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603906D RID: 233581 RVA: 0x00E73447 File Offset: 0x00E71647
		protected override void OnRegisterComponent()
		{
			base.OnRegisterComponent();
		}

		// Token: 0x0603906E RID: 233582 RVA: 0x00E73450 File Offset: 0x00E71650
		protected override void OnStart()
		{
			base.OnStart();
			this.CoverRoleLangToggle.RootUIComp.Get().SetUIActive(false);
			ControllerBase<ResourceManagerController>.Instance.ChangeHttpTickFrequency();
			this.CancelButton.SetFunction(delegate(int _)
			{
				this.DoCloseBtn();
			});
			this.ConfirmButton.SetFunction(new Action<int>(this.DoConfirmBtn));
			if (Singleton<CloudGameManager>.Instance.IsCloudGame)
			{
				this.ConfirmButton.SetUiActive(false);
			}
			IUiPopFrameInterface childPopView = this.ChildPopView;
			if (childPopView != null)
			{
				CommonPopViewBase popItem = childPopView.PopItem;
				if (popItem != null)
				{
					popItem.OverrideBackBtnCallBack(new Action(this.DoCloseBtn));
				}
			}
			this.RoleLangDeleteHint.SetUIActive(false);
			string textStringId = (!Singleton<GameSettingsManager>.Instance.IsGameSettingsAppliedOnOpenLoading) ? "VoiceDIY_DeleteResource_Login" : "DeleteResource_VoiceDIY_Tip";
			Singleton<LguiUtil>.Instance.SetLocalTextNew(this.RoleLangDeleteHintTxt, textStringId, Array.Empty<object>());
		}

		// Token: 0x0603906F RID: 233583 RVA: 0x00E73532 File Offset: 0x00E71732
		protected override void OnBeforeDestroy()
		{
			this.IsDestroyed = true;
			ControllerBase<ResourceManagerController>.Instance.RestoreHttpTickFrequency();
		}

		// Token: 0x06039070 RID: 233584 RVA: 0x00E73545 File Offset: 0x00E71745
		[return: Nullable(2)]
		protected override VoiceLanguageToggle CreateToggle(UUIItem uiItem, int index, bool isToggled)
		{
			VoiceLanguageToggle voiceLanguageToggle = new VoiceLanguageToggle();
			voiceLanguageToggle.Initialize(uiItem, index, isToggled);
			return voiceLanguageToggle;
		}

		// Token: 0x06039071 RID: 233585 RVA: 0x00E73558 File Offset: 0x00E71758
		protected override void OnRefreshView(VoiceLanguageToggle newToggle)
		{
			base.OnRefreshView(newToggle);
			string mainText = this.MenuDataIns.OptionsNameList[newToggle.GetIndex()];
			newToggle.SetMainText(mainText);
			newToggle.SetDownloadStatusCallback(new Action(this.OnDownloadStatusCallback));
		}

		// Token: 0x06039072 RID: 233586 RVA: 0x00E7359C File Offset: 0x00E7179C
		protected override void InitScrollViewData()
		{
			List<int> allLanguageTypeForAudio = Singleton<LanguageUpdateManager>.Instance.GetAllLanguageTypeForAudio();
			allLanguageTypeForAudio.Sort((int a, int b) => a - b);
			this.ScrollView.RefreshByData<int>(allLanguageTypeForAudio, null);
		}

		// Token: 0x06039073 RID: 233587 RVA: 0x00E735EE File Offset: 0x00E717EE
		protected override void OnAfterShow()
		{
			if (this.SelectedToggle != null)
			{
				this.ChangeButtonByToggleState(this.SelectedToggle);
			}
		}

		// Token: 0x06039074 RID: 233588 RVA: 0x00E73604 File Offset: 0x00E71804
		private unsafe void ChangeButtonByToggleState(VoiceLanguageToggle toggle)
		{
			LanguageUpdater updater = toggle.GetUpdater();
			if (updater == null)
			{
				return;
			}
			int targetConfig = ControllerBase<MenuController>.Instance.GetTargetConfig(EFunction.VOICELANGUAGE);
			bool flag = updater.Status == ELanguageDownloadStatus.Done && toggle.GetIndex() == targetConfig;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GameSettings;
			ELogAuthor author = ELogAuthor.TZJ;
			string message = "[语音下载] ChangeButtonByToggleState";
			<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("toggleIndex", toggle.GetIndex());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("targetIndex", targetConfig);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("updaterStatus", updater.Status);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("isDownloading", updater.IsDownloading);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("isInUse", flag);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
			if (updater.IsDownloading)
			{
				this.ConfirmButton.SetLocalText("PauseDownload", Array.Empty<object>());
			}
			else if (updater.Status != ELanguageDownloadStatus.Done)
			{
				this.ConfirmButton.SetLocalText("DownloadLanguage", Array.Empty<object>());
			}
			if (updater.Status == ELanguageDownloadStatus.Done)
			{
				this.ConfirmButton.SetLocalText("DeleteLanguage", Array.Empty<object>());
			}
			if (flag)
			{
				this.ConfirmButton.SetFunction(new Action<int>(this.DoDisBtn));
				return;
			}
			this.ConfirmButton.SetFunction(new Action<int>(this.DoConfirmBtn));
		}

		// Token: 0x06039075 RID: 233589 RVA: 0x00E73792 File Offset: 0x00E71992
		protected override void OnSelected(VoiceLanguageToggle newToggle, EToggleState newToggleState)
		{
			this.RefreshRoleHint(newToggle);
			this.RefreshUiBySelect(newToggle);
		}

		// Token: 0x06039076 RID: 233590 RVA: 0x00E737A2 File Offset: 0x00E719A2
		private void OnDownloadStatusCallback()
		{
			this.RefreshUiBySelect(this.SelectedToggle);
		}

		// Token: 0x06039077 RID: 233591 RVA: 0x00E737B0 File Offset: 0x00E719B0
		protected void RefreshRoleHint(VoiceLanguageToggle selectedToggle)
		{
			if (!this.CheckRoleLangCustom())
			{
				this.RoleLangDeleteHint.SetUIActive(false);
				return;
			}
			int index = selectedToggle.GetIndex();
			int languageTypeByAudioCode = Singleton<LanguageSystem>.Instance.GetLanguageTypeByAudioCode(Singleton<LanguageSystem>.Instance.PackageAudio);
			if (index == languageTypeByAudioCode)
			{
				this.RoleLangDeleteHint.SetUIActive(false);
				return;
			}
			if (Singleton<GameSettingsManager>.Instance.IsGameSettingsAppliedOnOpenLoading)
			{
				Dictionary<int, int> dictionary = LocalStorage.GetPlayer<Dictionary<int, int>>(ELocalStoragePlayerKey.RoleVoiceMap, null) ?? new Dictionary<int, int>();
				bool uiactive = false;
				using (Dictionary<int, int>.ValueCollection.Enumerator enumerator = dictionary.Values.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current == index)
						{
							uiactive = true;
							break;
						}
					}
				}
				this.RoleLangDeleteHint.SetUIActive(uiactive);
				return;
			}
			this.RoleLangDeleteHint.SetUIActive(true);
		}

		// Token: 0x06039078 RID: 233592 RVA: 0x00E73884 File Offset: 0x00E71A84
		protected void RefreshUiBySelect(VoiceLanguageToggle selectedToggle)
		{
			if (this.IsDestroyed)
			{
				return;
			}
			this.ChangeButtonByToggleState(selectedToggle);
			selectedToggle.RefreshUi();
		}

		// Token: 0x06039079 RID: 233593 RVA: 0x00E7389C File Offset: 0x00E71A9C
		protected bool CheckRoleLangCustom()
		{
			if (Singleton<CloudGameManager>.Instance.IsCloudGame)
			{
				return false;
			}
			VoiceLanguageToggle selectedToggle = this.SelectedToggle;
			if (((selectedToggle != null) ? selectedToggle.Updater.Status : ELanguageDownloadStatus.None) != ELanguageDownloadStatus.Done)
			{
				return false;
			}
			bool? boolConfig = ConfigCommonParamById.GetBoolConfig("NeedShowRoleLangCustom");
			return boolConfig != null && boolConfig.Value && (!Singleton<GameSettingsManager>.Instance.IsGameSettingsAppliedOnOpenLoading || (LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.RoleLangCustomRecord, null) ?? new HashSet<int>()).Count > 0);
		}

		// Token: 0x0603907A RID: 233594 RVA: 0x00E73920 File Offset: 0x00E71B20
		private void DoCloseBtn()
		{
			EUiViewName? backToPrevLangSettingViewName = LanguageSettingViewBase.BackToPrevLangSettingViewName;
			if (backToPrevLangSettingViewName != null)
			{
				base.CloseMe(delegate(bool success)
				{
					if (success)
					{
						UiManager instance = Singleton<UiManager>.Instance;
						EUiViewName value = backToPrevLangSettingViewName.Value;
						object[] array = new object[2];
						array[0] = ModelBase<MenuModel>.Instance.GetMenuDataByFunctionId(52);
						instance.OpenView(value, array, null);
						LanguageSettingViewBase.BackToPrevLangSettingViewName = null;
					}
				});
				return;
			}
			base.CloseMe(null);
		}

		// Token: 0x0603907B RID: 233595 RVA: 0x00E73965 File Offset: 0x00E71B65
		private void DoDisBtn(int _)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("InUseCanNotDelete", Array.Empty<object>());
		}

		// Token: 0x0603907C RID: 233596 RVA: 0x00E7397C File Offset: 0x00E71B7C
		private void DoConfirmBtn(int _)
		{
			ConfirmBoxDataNew confirmBoxDataNew = null;
			if (this.SelectedToggle == null)
			{
				return;
			}
			ELanguageDownloadStatus status = this.SelectedToggle.Updater.Status;
			if (status > ELanguageDownloadStatus.Half)
			{
				if (status == ELanguageDownloadStatus.Done)
				{
					confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.VoiceDelete);
					bool flag = this.RoleLangDeleteHint.IsUIActiveSelf();
					if (this.CheckRoleLangCustom() && flag)
					{
						string key = (!Singleton<GameSettingsManager>.Instance.IsGameSettingsAppliedOnOpenLoading) ? "VoiceDIY_DeleteResourceResetDefault_Login" : "VoiceDIY_DeleteResourceResetDefaultTip";
						confirmBoxDataNew.Tip = Singleton<PublicUtil>.Instance.GetConfigTextByKey(key);
						confirmBoxDataNew.SetTipsBgRed = true;
					}
					Action value = delegate()
					{
						this.SelectedToggle.Updater.Delete(GlobalData.World);
						this.RefreshUiBySelect(this.SelectedToggle);
						ModelBase<RoleLangCustomModel>.Instance.CheckAndApplyPlayerVoiceAll();
						this.RefreshRoleHint(this.SelectedToggle);
					};
					confirmBoxDataNew.SetTextArgs(new string[]
					{
						this.SelectedToggle.GetMainText()
					});
					confirmBoxDataNew.FunctionMap[2] = value;
				}
			}
			else if (this.SelectedToggle.Updater.IsDownloading)
			{
				this.SelectedToggle.Updater.Pause();
				this.RefreshUiBySelect(this.SelectedToggle);
			}
			else
			{
				VoiceLanguageDownloadView.<>c__DisplayClass17_0 CS$<>8__locals1 = new VoiceLanguageDownloadView.<>c__DisplayClass17_0();
				CS$<>8__locals1.<>4__this = this;
				CS$<>8__locals1.isInLogin = !Singleton<GameSettingsManager>.Instance.IsGameSettingsAppliedOnOpenLoading;
				bool flag2 = UKuroLauncherLibrary.GetNetworkConnectionType() == 3;
				EConfirmBoxConfigId configId;
				if (CS$<>8__locals1.isInLogin)
				{
					configId = (flag2 ? EConfirmBoxConfigId.VoiceDownloadLoginConfirmCell : EConfirmBoxConfigId.VoiceDownloadLoginConfirm);
				}
				else
				{
					configId = (flag2 ? EConfirmBoxConfigId.VoiceDownloadCell : EConfirmBoxConfigId.VoiceDownload);
				}
				confirmBoxDataNew = new ConfirmBoxDataNew(configId);
				string text = LauncherTextLib.SpaceSizeFormat(this.SelectedToggle.Updater.TotalDiskSize - this.SelectedToggle.Updater.LocalDiskSize);
				confirmBoxDataNew.SetTextArgs(new string[]
				{
					this.SelectedToggle.GetMainText(),
					text
				});
				confirmBoxDataNew.FunctionMap[2] = new Action(CS$<>8__locals1.<DoConfirmBtn>g__ConfirmCallback|1);
			}
			if (confirmBoxDataNew != null)
			{
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			}
		}

		// Token: 0x04020786 RID: 132998
		private bool IsDestroyed;
	}
}
