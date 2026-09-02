using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.RoleLangCustomModel;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.Update;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.SubViews
{
	// Token: 0x0200579A RID: 22426
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class VoiceLanguageSelectView : LanguageSettingViewBase<VoiceLanguageSelectToggle>
	{
		// Token: 0x0603908D RID: 233613 RVA: 0x00E7424B File Offset: 0x00E7244B
		public VoiceLanguageSelectView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603908E RID: 233614 RVA: 0x00E74254 File Offset: 0x00E72454
		protected override void OnStart()
		{
			base.OnStart();
			bool? boolConfig = ConfigCommonParamById.GetBoolConfig("NeedShowRoleLangCustom");
			Singleton<LguiUtil>.Instance.SetLocalTextNew(this.CoverRoleTxt, "Override_VoiceDIY_CustomTip", Array.Empty<object>());
			if (boolConfig != null && boolConfig.Value)
			{
				if (!Singleton<GameSettingsManager>.Instance.IsGameSettingsAppliedOnOpenLoading)
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(this.RoleLangDeleteHintTxt, "Notice_VoiceDIY_LanguageChange", Array.Empty<object>());
					return;
				}
				if (ModelBase<RoleLangCustomModel>.Instance != null)
				{
					ModelBase<RoleLangCustomModel>.Instance.NeedCoverAllPlayer = false;
					return;
				}
			}
			else
			{
				this.RoleLangDeleteHint.SetUIActive(false);
				this.CoverRoleLangToggle.RootUIComp.Get().SetUIActive(false);
			}
		}

		// Token: 0x0603908F RID: 233615 RVA: 0x00E74300 File Offset: 0x00E72500
		protected override void InitScrollViewData()
		{
			List<int> allLanguageTypeForAudio = Singleton<LanguageUpdateManager>.Instance.GetAllLanguageTypeForAudio();
			allLanguageTypeForAudio.Sort((int a, int b) => a - b);
			this.ScrollView.RefreshByData<int>(allLanguageTypeForAudio, null);
			this.CancelButton.SetFunction(new Action<int>(this.DoCloseBtn));
			this.ConfirmButton.SetFunction(new Action<int>(this.DoConfirmBtn));
			this.ConfirmButton.SetLocalText("PowerConfirm", Array.Empty<object>());
		}

		// Token: 0x06039090 RID: 233616 RVA: 0x00E74395 File Offset: 0x00E72595
		[return: Nullable(2)]
		protected override VoiceLanguageSelectToggle CreateToggle(UUIItem uiItem, int index, bool isToggled)
		{
			VoiceLanguageSelectToggle voiceLanguageSelectToggle = new VoiceLanguageSelectToggle();
			voiceLanguageSelectToggle.Initialize(uiItem, index, isToggled);
			return voiceLanguageSelectToggle;
		}

		// Token: 0x06039091 RID: 233617 RVA: 0x00E743A8 File Offset: 0x00E725A8
		protected override void OnRefreshView(VoiceLanguageSelectToggle newToggle)
		{
			base.OnRefreshView(newToggle);
			string mainText = this.MenuDataIns.OptionsNameList[newToggle.GetIndex()];
			newToggle.SetMainText(mainText);
			if (this.SelectedToggle != null)
			{
				this.RefreshCoverRoleLangToggleVisible(this.SelectedToggle);
				this.RefreshRoleCoverHint(this.SelectedToggle);
			}
		}

		// Token: 0x06039092 RID: 233618 RVA: 0x00E743FC File Offset: 0x00E725FC
		protected override void OnSelected(VoiceLanguageSelectToggle newToggle, EToggleState newToggleState)
		{
			if (newToggle.Updater.Status == ELanguageDownloadStatus.Done)
			{
				this.ConfirmButton.SetLocalText("PowerConfirm", Array.Empty<object>());
			}
			else
			{
				this.ConfirmButton.SetLocalText("GoToDownload", Array.Empty<object>());
			}
			this.RefreshCoverRoleLangToggleVisible(newToggle);
			this.RefreshRoleCoverHint(newToggle);
		}

		// Token: 0x06039093 RID: 233619 RVA: 0x00E74454 File Offset: 0x00E72654
		private void RefreshCoverRoleLangToggleVisible(VoiceLanguageSelectToggle newToggle)
		{
			bool? boolConfig = ConfigCommonParamById.GetBoolConfig("NeedShowRoleLangCustom");
			if (boolConfig == null || !boolConfig.Value)
			{
				this.CoverRoleLangToggle.RootUIComp.Get().SetUIActive(false);
				return;
			}
			if (!Singleton<GameSettingsManager>.Instance.IsGameSettingsAppliedOnOpenLoading)
			{
				this.CoverRoleLangToggle.RootUIComp.Get().SetUIActive(false);
				return;
			}
			if ((LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.RoleLangCustomRecord, null) ?? new HashSet<int>()).Count == 0)
			{
				this.CoverRoleLangToggle.RootUIComp.Get().SetUIActive(false);
				return;
			}
			bool uiactive = newToggle.Updater.Status == ELanguageDownloadStatus.Done;
			if (Singleton<GameSettingsManager>.Instance.GetAudioCodeById(newToggle.GetIndex()) == Singleton<LanguageSystem>.Instance.PackageAudio)
			{
				this.CoverRoleLangToggle.RootUIComp.Get().SetUIActive(false);
				return;
			}
			this.CoverRoleLangToggle.RootUIComp.Get().SetUIActive(uiactive);
		}

		// Token: 0x06039094 RID: 233620 RVA: 0x00E7455C File Offset: 0x00E7275C
		private void RefreshRoleCoverHint(VoiceLanguageSelectToggle newToggle)
		{
			if (Singleton<GameSettingsManager>.Instance.IsGameSettingsAppliedOnOpenLoading)
			{
				this.RoleLangDeleteHint.SetUIActive(false);
				return;
			}
			if (Singleton<GameSettingsManager>.Instance.GetAudioCodeById(newToggle.GetIndex()) == Singleton<LanguageSystem>.Instance.PackageAudio)
			{
				this.RoleLangDeleteHint.SetUIActive(false);
				return;
			}
			bool uiactive = newToggle.Updater.Status == ELanguageDownloadStatus.Done;
			this.RoleLangDeleteHint.SetUIActive(uiactive);
		}

		// Token: 0x06039095 RID: 233621 RVA: 0x00E745CE File Offset: 0x00E727CE
		private void DoCloseBtn(int _)
		{
			base.CloseMe(null);
		}

		// Token: 0x06039096 RID: 233622 RVA: 0x00E745D8 File Offset: 0x00E727D8
		private void DoConfirmBtn(int _)
		{
			if (this.SelectedToggle == null)
			{
				this.DoCloseBtn(0);
				return;
			}
			bool flag = !Singleton<GameSettingsManager>.Instance.IsGameSettingsAppliedOnOpenLoading;
			ELanguageDownloadStatus status = this.SelectedToggle.Updater.Status;
			if (status > ELanguageDownloadStatus.Half)
			{
				if (status == ELanguageDownloadStatus.Done)
				{
					bool flag2 = Singleton<GameSettingsManager>.Instance.GetAudioCodeById(this.SelectedToggle.GetIndex()) != Singleton<LanguageSystem>.Instance.PackageAudio;
					if (flag)
					{
						if (flag2)
						{
							LocalStorage.SetGlobal<bool>(ELocalStorageGlobalKey.RoleLangCustomNeedCover, true);
						}
					}
					else
					{
						bool flag3 = this.CoverRoleLangToggle.GetToggleState() == EToggleState.ETT_Checked;
						if (ModelBase<RoleLangCustomModel>.Instance != null && flag2)
						{
							ModelBase<RoleLangCustomModel>.Instance.NeedCoverAllPlayer = !flag3;
						}
					}
					this.IsConfirm = true;
					this.DoCloseBtn(0);
					return;
				}
			}
			else
			{
				LanguageSettingViewBase.BackToPrevLangSettingViewName = new EUiViewName?(EUiViewName.VoiceLanguageSelectView);
				UiManager instance = Singleton<UiManager>.Instance;
				EUiViewName voiceLanguageDownloadView = EUiViewName.VoiceLanguageDownloadView;
				object[] array = new object[2];
				array[0] = ModelBase<MenuModel>.Instance.GetMenuDataByFunctionId(53);
				instance.OpenView(voiceLanguageDownloadView, array, null);
				this.DoCloseBtn(0);
			}
		}
	}
}
