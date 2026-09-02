using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.Update;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleLangCustomModel.View
{
	// Token: 0x020050F6 RID: 20726
	public class RoleLangNetConfirmPop : UiTickViewBase
	{
		// Token: 0x060356C8 RID: 218824 RVA: 0x00D6755C File Offset: 0x00D6575C
		[NullableContext(1)]
		public RoleLangNetConfirmPop(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x060356C9 RID: 218825 RVA: 0x00D6757C File Offset: 0x00D6577C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 13;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 4;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickedBtnVersionDel));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickedBtnVersionPause));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickedBtnVersionStar));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickedBtnVersionDownload));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060356CA RID: 218826 RVA: 0x00D677FC File Offset: 0x00D659FC
		protected override void OnStart()
		{
			this.FromSettingAll = (bool)this.OpenParam;
			IUiPopFrameInterface childPopView = this.ChildPopView;
			if (childPopView != null)
			{
				childPopView.PopItem.OverrideBackBtnCallBack(new Action(this.OnClickedClose));
			}
			IUiPopFrameInterface childPopView2 = this.ChildPopView;
			if (childPopView2 != null)
			{
				childPopView2.PopItem.SetMaskResponsibleState(false);
			}
			this.CancelBtn = new ButtonItem(base.GetItem(10));
			this.CancelBtn.SetFunction(new Action<int>(this.OnClickedBtnCancel));
			this.CancelBtn.SetShowText("VoiceDIY_Button_KeepCurrent");
			this.ConfirmBtn = new ButtonItem(base.GetItem(11));
			this.ConfirmBtn.SetFunction(new Action<int>(this.OnClickedBtnConfirm));
			this.InitData();
			this.InitBtnState();
		}

		// Token: 0x060356CB RID: 218827 RVA: 0x00D678C3 File Offset: 0x00D65AC3
		protected override void OnTick(float deltaTime)
		{
			if (!this.NeedTick)
			{
				return;
			}
			if (this.DownloadState == RoleLangNetConfirmPop.EDownloadState.NoSpace)
			{
				this.RefreshState(true);
				return;
			}
			this.RefreshState(true);
			this.RefreshDownloadProgress();
		}

		// Token: 0x060356CC RID: 218828 RVA: 0x00D678EC File Offset: 0x00D65AEC
		private void InitData()
		{
			this.NoResourceInfo = ModelBase<RoleLangCustomModel>.Instance.CheckNoResourceInfo();
			if (this.NoResourceInfo.Count > 0)
			{
				UUIItem item = base.GetItem(12);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				this.GetPackageSize();
				return;
			}
			UUIItem item2 = base.GetItem(12);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			UUIItem item3 = base.GetItem(8);
			if (item3 == null)
			{
				return;
			}
			item3.SetUIActive(false);
		}

		// Token: 0x060356CD RID: 218829 RVA: 0x00D67958 File Offset: 0x00D65B58
		private void InitBtnState()
		{
			bool flag = this.NoResourceInfo.Count > 0;
			bool flag2 = this.CheckSpaceEnough();
			if (!flag)
			{
				this.ConfirmBtn.SetShowText("VoiceDIY_Button_ApplySyncPlan");
				this.ConfirmBtn.SetEnableClick(true);
				return;
			}
			if (!flag2)
			{
				this.RefreshState(false);
			}
			this.RefreshButtonState(true);
		}

		// Token: 0x060356CE RID: 218830 RVA: 0x00D679AC File Offset: 0x00D65BAC
		private void RefreshButtonState(bool isInit = false)
		{
			bool flag = this.DownloadState == RoleLangNetConfirmPop.EDownloadState.None;
			bool uiactive = this.DownloadState == RoleLangNetConfirmPop.EDownloadState.Downloading;
			bool flag2 = this.DownloadState == RoleLangNetConfirmPop.EDownloadState.Pause;
			bool uiactive2 = this.DownloadState == RoleLangNetConfirmPop.EDownloadState.Done;
			bool flag3 = this.DownloadState == RoleLangNetConfirmPop.EDownloadState.NoSpace;
			UUIItem item = base.GetItem(7);
			if (item != null)
			{
				item.SetUIActive(uiactive2);
			}
			UUIItem item2 = base.GetItem(8);
			if (item2 != null)
			{
				item2.SetUIActive(flag3);
			}
			UUIButtonComponent button = base.GetButton(3);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(!flag);
			}
			UUIButtonComponent button2 = base.GetButton(4);
			if (button2 != null)
			{
				button2.RootUIComp.Get().SetUIActive(uiactive);
			}
			UUIButtonComponent button3 = base.GetButton(5);
			if (button3 != null)
			{
				button3.RootUIComp.Get().SetUIActive(flag3 ? (!isInit) : flag2);
			}
			UUIButtonComponent button4 = base.GetButton(6);
			if (button4 != null)
			{
				button4.RootUIComp.Get().SetUIActive(flag3 ? isInit : flag);
			}
			this.RefreshConfirm();
		}

		// Token: 0x060356CF RID: 218831 RVA: 0x00D67AB4 File Offset: 0x00D65CB4
		private void RefreshConfirm()
		{
			switch (this.DownloadState)
			{
			case RoleLangNetConfirmPop.EDownloadState.None:
				this.ConfirmBtn.SetEnableClick(true);
				this.ConfirmBtn.SetShowText("VoiceDIY_Button_DownloadResources");
				return;
			case RoleLangNetConfirmPop.EDownloadState.Downloading:
				this.ConfirmBtn.SetEnableClick(false);
				this.ConfirmBtn.SetShowText("VoiceDIY_Button_Downloading");
				return;
			case RoleLangNetConfirmPop.EDownloadState.Pause:
				this.ConfirmBtn.SetEnableClick(false);
				this.ConfirmBtn.SetShowText("VoiceDIY_Button_Downloading");
				return;
			case RoleLangNetConfirmPop.EDownloadState.Done:
				this.ConfirmBtn.SetEnableClick(true);
				this.ConfirmBtn.SetShowText("VoiceDIY_Button_ApplySyncPlan");
				return;
			case RoleLangNetConfirmPop.EDownloadState.NoSpace:
			{
				this.ConfirmBtn.SetEnableClick(true);
				string showText = this.HaveStarted ? "VoiceDIY_Button_Downloading" : "VoiceDIY_Button_DownloadResources";
				this.ConfirmBtn.SetShowText(showText);
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x060356D0 RID: 218832 RVA: 0x00D67B84 File Offset: 0x00D65D84
		private void GetPackageSize()
		{
			long num = 0L;
			RoleLangCustomUpdateManager updateManager = ModelBase<RoleLangCustomModel>.Instance.GetUpdateManager();
			foreach (IRoleLangCustomLangPackageInfo info in this.NoResourceInfo)
			{
				ResPackageInfo roleVoiceInfo = ResPackageInfo.GetRoleVoiceInfo(updateManager.GetPackageName(info));
				if (roleVoiceInfo != null)
				{
					long item = roleVoiceInfo.CalculateSavedSizeAndTotalSize().Item2;
					num += item;
				}
			}
			this.TotalSize = num;
			this.TotalSizeTxt = ((float)this.TotalSize / 1048576f).ToString("F2");
			UUIText text = base.GetText(2);
			if (text == null)
			{
				return;
			}
			text.SetText(this.TotalSizeTxt + "MB", true);
		}

		// Token: 0x060356D1 RID: 218833 RVA: 0x00D67C50 File Offset: 0x00D65E50
		private void RefreshDownloadProgress()
		{
			long num = 0L;
			RoleLangCustomUpdateManager updateManager = ModelBase<RoleLangCustomModel>.Instance.GetUpdateManager();
			foreach (IRoleLangCustomLangPackageInfo info in this.NoResourceInfo)
			{
				ResPackageInfo roleVoiceInfo = ResPackageInfo.GetRoleVoiceInfo(updateManager.GetPackageName(info));
				if (roleVoiceInfo != null)
				{
					long item = roleVoiceInfo.CalculateSavedSizeAndTotalSize().Item1;
					num += item;
				}
			}
			string str = ((float)num / 1048576f).ToString("F2");
			if (this.DownloadState == RoleLangNetConfirmPop.EDownloadState.Downloading || this.DownloadState == RoleLangNetConfirmPop.EDownloadState.Pause)
			{
				UUIText text = base.GetText(2);
				if (text == null)
				{
					return;
				}
				text.SetText(str + "MB/" + this.TotalSizeTxt + "MB", true);
				return;
			}
			else
			{
				UUIText text2 = base.GetText(2);
				if (text2 == null)
				{
					return;
				}
				text2.SetText(this.TotalSizeTxt + "MB", true);
				return;
			}
		}

		// Token: 0x060356D2 RID: 218834 RVA: 0x00D67D48 File Offset: 0x00D65F48
		private void RefreshState(bool needButtonRefresh = true)
		{
			if (this.NoResourceInfo.Count == 0)
			{
				return;
			}
			RoleLangNetConfirmPop.EDownloadState downloadState = this.DownloadState;
			RoleLangCustomUpdateManager updateManager = ModelBase<RoleLangCustomModel>.Instance.GetUpdateManager();
			if (!this.CheckSpaceEnough())
			{
				this.DownloadState = RoleLangNetConfirmPop.EDownloadState.NoSpace;
			}
			else if (downloadState == RoleLangNetConfirmPop.EDownloadState.NoSpace)
			{
				this.DownloadState = (this.HaveStarted ? RoleLangNetConfirmPop.EDownloadState.Pause : RoleLangNetConfirmPop.EDownloadState.None);
			}
			else
			{
				bool flag = true;
				foreach (IRoleLangCustomLangPackageInfo info in this.NoResourceInfo)
				{
					if (updateManager.GetDownloadStatus(info) != ELanguageDownloadStatus.Done)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					this.DownloadState = RoleLangNetConfirmPop.EDownloadState.Done;
				}
				else if (ModelBase<RoleLangCustomModel>.Instance.IsListDownloading())
				{
					this.DownloadState = RoleLangNetConfirmPop.EDownloadState.Downloading;
				}
				else if (this.HaveStarted)
				{
					this.DownloadState = RoleLangNetConfirmPop.EDownloadState.Pause;
				}
			}
			if (this.DownloadState != downloadState)
			{
				if (this.DownloadState == RoleLangNetConfirmPop.EDownloadState.NoSpace)
				{
					if (ModelBase<RoleLangCustomModel>.Instance.IsListDownloading())
					{
						ModelBase<RoleLangCustomModel>.Instance.PauseDownloadingList();
					}
					this.NeedTick = true;
				}
				else
				{
					this.NeedTick = (this.DownloadState != RoleLangNetConfirmPop.EDownloadState.Done);
				}
				if (needButtonRefresh)
				{
					this.RefreshButtonState(false);
				}
			}
		}

		// Token: 0x060356D3 RID: 218835 RVA: 0x00D67E70 File Offset: 0x00D66070
		private bool CheckSpaceEnough()
		{
			long num = 0L;
			RoleLangCustomUpdateManager updateManager = ModelBase<RoleLangCustomModel>.Instance.GetUpdateManager();
			foreach (IRoleLangCustomLangPackageInfo info in this.NoResourceInfo)
			{
				ResPackageInfo roleVoiceInfo = ResPackageInfo.GetRoleVoiceInfo(updateManager.GetPackageName(info));
				if (roleVoiceInfo != null)
				{
					ValueTuple<long, long> valueTuple = roleVoiceInfo.CalculateSavedSizeAndTotalSize();
					long item = valueTuple.Item1;
					long item2 = valueTuple.Item2;
					num += item2 - item;
				}
			}
			string checkPath = UKuroLauncherLibrary.GameSavedDir();
			long num2 = 0L;
			UKuroLauncherLibrary.GetTotalAndFreeSpace(checkPath, ref num2);
			return num2 >= num + 10485760L;
		}

		// Token: 0x060356D4 RID: 218836 RVA: 0x00D67F1C File Offset: 0x00D6611C
		protected void BeforeCloseConfirmBox()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RoleLangCustomConfirm);
			string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey("VoiceDIY_Tips_ExitInterface");
			confirmBoxDataNew.SetTextArgs(new string[]
			{
				configTextByKey
			});
			string configTextByKey2 = Singleton<PublicUtil>.Instance.GetConfigTextByKey("VoiceDIY_Button_Cancel");
			string configTextByKey3 = Singleton<PublicUtil>.Instance.GetConfigTextByKey("VoiceDIY_Button_Confirm");
			confirmBoxDataNew.SetBtnText(0, configTextByKey2);
			confirmBoxDataNew.SetBtnText(1, configTextByKey3);
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				base.CloseMe(null);
				if (this.FromSettingAll)
				{
					UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.RoleLangCustomView);
					Singleton<UiManager>.Instance.CloseViewById(viewByName.GetViewId(), null);
				}
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x060356D5 RID: 218837 RVA: 0x00D67FA8 File Offset: 0x00D661A8
		protected void FinishedCloseConfirmBox()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RoleLangCustomConfirm);
			string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey("VoiceDIY_Tips_ExitInterface");
			confirmBoxDataNew.SetTextArgs(new string[]
			{
				configTextByKey
			});
			string configTextByKey2 = Singleton<PublicUtil>.Instance.GetConfigTextByKey("VoiceDIY_Button_Cancel");
			string configTextByKey3 = Singleton<PublicUtil>.Instance.GetConfigTextByKey("VoiceDIY_Button_Confirm");
			confirmBoxDataNew.SetBtnText(0, configTextByKey2);
			confirmBoxDataNew.SetBtnText(1, configTextByKey3);
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				base.CloseMe(null);
				if (this.FromSettingAll)
				{
					UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.RoleLangCustomView);
					Singleton<UiManager>.Instance.CloseViewById(viewByName.GetViewId(), null);
				}
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x060356D6 RID: 218838 RVA: 0x00D68034 File Offset: 0x00D66234
		protected void DownloadingConfirmBox()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RoleLangCustomConfirm);
			string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey("VoiceDIY_Tips_ExitWhileDownload");
			confirmBoxDataNew.SetTextArgs(new string[]
			{
				configTextByKey
			});
			string configTextByKey2 = Singleton<PublicUtil>.Instance.GetConfigTextByKey("VoiceDIY_Button_Cancel");
			string configTextByKey3 = Singleton<PublicUtil>.Instance.GetConfigTextByKey("VoiceDIY_Button_Confirm");
			confirmBoxDataNew.SetBtnText(0, configTextByKey2);
			confirmBoxDataNew.SetBtnText(1, configTextByKey3);
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				if (this.FromSettingAll)
				{
					UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.RoleLangCustomView);
					Singleton<UiManager>.Instance.CloseViewById(viewByName.GetViewId(), null);
				}
				ModelBase<RoleLangCustomModel>.Instance.DeletePackageList(this.NoResourceInfo);
				base.CloseMe(null);
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x060356D7 RID: 218839 RVA: 0x00D680C0 File Offset: 0x00D662C0
		protected void DeleteConfirmBox()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RoleLangCustomConfirm);
			string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey("VoiceDIY_Tips_DeleteResources");
			confirmBoxDataNew.SetTextArgs(new string[]
			{
				configTextByKey
			});
			string configTextByKey2 = Singleton<PublicUtil>.Instance.GetConfigTextByKey("VoiceDIY_Button_Cancel");
			string configTextByKey3 = Singleton<PublicUtil>.Instance.GetConfigTextByKey("VoiceDIY_Button_Confirm");
			confirmBoxDataNew.SetBtnText(0, configTextByKey2);
			confirmBoxDataNew.SetBtnText(1, configTextByKey3);
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				ModelBase<RoleLangCustomModel>.Instance.DeletePackageList(this.NoResourceInfo);
				this.HaveStarted = false;
				this.NeedTick = false;
				if (this.CheckSpaceEnough())
				{
					this.DownloadState = RoleLangNetConfirmPop.EDownloadState.None;
					this.RefreshButtonState(false);
				}
				else
				{
					this.RefreshState(true);
				}
				this.RefreshDownloadProgress();
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x060356D8 RID: 218840 RVA: 0x00D6814C File Offset: 0x00D6634C
		protected void AfterDownloadKeepLocalConfirmBox()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RoleLangCustomConfirm);
			string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey("VoiceDIY_Tips_KeepCurrentWhileDownloadCompleted");
			confirmBoxDataNew.SetTextArgs(new string[]
			{
				configTextByKey
			});
			string configTextByKey2 = Singleton<PublicUtil>.Instance.GetConfigTextByKey("VoiceDIY_Button_Cancel");
			string configTextByKey3 = Singleton<PublicUtil>.Instance.GetConfigTextByKey("VoiceDIY_Button_Confirm");
			confirmBoxDataNew.SetBtnText(0, configTextByKey2);
			confirmBoxDataNew.SetBtnText(1, configTextByKey3);
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				ModelBase<RoleLangCustomModel>.Instance.OnClickedConfirmClose();
				base.CloseMe(null);
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x060356D9 RID: 218841 RVA: 0x00D681D8 File Offset: 0x00D663D8
		protected void ApplyLocalWhileDownloadingConfirmBox()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RoleLangCustomConfirm);
			string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey("VoiceDIY_Tips_KeepCurrentWhileDownload");
			confirmBoxDataNew.SetTextArgs(new string[]
			{
				configTextByKey
			});
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			string configTextByKey2 = Singleton<PublicUtil>.Instance.GetConfigTextByKey("VoiceDIY_Button_ContinueDownloading");
			string configTextByKey3 = Singleton<PublicUtil>.Instance.GetConfigTextByKey("VoiceDIY_Button_Confirm");
			confirmBoxDataNew.SetBtnText(0, configTextByKey2);
			confirmBoxDataNew.SetBtnText(1, configTextByKey3);
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				ModelBase<RoleLangCustomModel>.Instance.DeletePackageList(this.NoResourceInfo);
				ModelBase<RoleLangCustomModel>.Instance.OnClickedConfirmClose();
				base.CloseMe(null);
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x060356DA RID: 218842 RVA: 0x00D6826B File Offset: 0x00D6646B
		private void OnClickedClose()
		{
			if (!this.HaveStarted)
			{
				this.BeforeCloseConfirmBox();
				return;
			}
			if (this.DownloadState == RoleLangNetConfirmPop.EDownloadState.Done)
			{
				this.FinishedCloseConfirmBox();
				return;
			}
			this.DownloadingConfirmBox();
		}

		// Token: 0x060356DB RID: 218843 RVA: 0x00D68292 File Offset: 0x00D66492
		private void OnClickedBtnVersionDel()
		{
			if (this.DownloadState == RoleLangNetConfirmPop.EDownloadState.Downloading)
			{
				this.OnClickedBtnVersionPause();
			}
			this.DeleteConfirmBox();
		}

		// Token: 0x060356DC RID: 218844 RVA: 0x00D682A9 File Offset: 0x00D664A9
		private void OnClickedBtnVersionPause()
		{
			ModelBase<RoleLangCustomModel>.Instance.PauseDownloadingList();
			this.RefreshState(true);
		}

		// Token: 0x060356DD RID: 218845 RVA: 0x00D682BC File Offset: 0x00D664BC
		private void OnClickedBtnVersionStar()
		{
			if (!this.CheckSpaceEnough())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("VoiceDIY_Tips_OutOfMemory", Array.Empty<object>());
				return;
			}
			ModelBase<RoleLangCustomModel>.Instance.StartDownloadingList(this.NoResourceInfo);
			this.DownloadState = RoleLangNetConfirmPop.EDownloadState.Downloading;
			this.NeedTick = true;
			this.RefreshButtonState(false);
		}

		// Token: 0x060356DE RID: 218846 RVA: 0x00D6830C File Offset: 0x00D6650C
		private void OnClickedBtnVersionDownload()
		{
			if (!this.CheckSpaceEnough())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("VoiceDIY_Tips_OutOfMemory", Array.Empty<object>());
				return;
			}
			ModelBase<RoleLangCustomModel>.Instance.StartDownloadingList(this.NoResourceInfo);
			this.DownloadState = RoleLangNetConfirmPop.EDownloadState.Downloading;
			this.NeedTick = true;
			this.HaveStarted = true;
			this.RefreshButtonState(false);
		}

		// Token: 0x060356DF RID: 218847 RVA: 0x00D68362 File Offset: 0x00D66562
		private void OnClickedBtnCancel(int data)
		{
			if (!this.HaveStarted)
			{
				ModelBase<RoleLangCustomModel>.Instance.OnClickedConfirmClose();
				base.CloseMe(null);
				return;
			}
			if (this.DownloadState == RoleLangNetConfirmPop.EDownloadState.Done)
			{
				this.AfterDownloadKeepLocalConfirmBox();
				return;
			}
			this.ApplyLocalWhileDownloadingConfirmBox();
		}

		// Token: 0x060356E0 RID: 218848 RVA: 0x00D68394 File Offset: 0x00D66594
		private void OnClickedBtnConfirm(int data)
		{
			if (this.NoResourceInfo.Count == 0)
			{
				ModelBase<RoleLangCustomModel>.Instance.OnClickedConfirmConfirm();
				base.CloseMe(null);
				return;
			}
			if (this.DownloadState == RoleLangNetConfirmPop.EDownloadState.Done)
			{
				ModelBase<RoleLangCustomModel>.Instance.OnClickedConfirmConfirm();
				base.CloseMe(null);
				return;
			}
			if (!this.CheckSpaceEnough())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("VoiceDIY_Tips_OutOfMemory", Array.Empty<object>());
				return;
			}
			this.OnClickedBtnVersionDownload();
		}

		// Token: 0x0401EAFC RID: 125692
		[Nullable(2)]
		protected ButtonItem CancelBtn;

		// Token: 0x0401EAFD RID: 125693
		[Nullable(2)]
		protected ButtonItem ConfirmBtn;

		// Token: 0x0401EAFE RID: 125694
		protected bool FromSettingAll;

		// Token: 0x0401EAFF RID: 125695
		[Nullable(1)]
		protected List<IRoleLangCustomLangPackageInfo> NoResourceInfo = new List<IRoleLangCustomLangPackageInfo>();

		// Token: 0x0401EB00 RID: 125696
		protected long TotalSize;

		// Token: 0x0401EB01 RID: 125697
		[Nullable(1)]
		protected string TotalSizeTxt = "";

		// Token: 0x0401EB02 RID: 125698
		protected bool NeedTick;

		// Token: 0x0401EB03 RID: 125699
		protected RoleLangNetConfirmPop.EDownloadState DownloadState;

		// Token: 0x0401EB04 RID: 125700
		protected bool HaveStarted;

		// Token: 0x0200B092 RID: 45202
		private enum EDefine
		{
			// Token: 0x04036C8C RID: 224396
			SpriteInfoBg,
			// Token: 0x04036C8D RID: 224397
			TxtDesc,
			// Token: 0x04036C8E RID: 224398
			TxtValue,
			// Token: 0x04036C8F RID: 224399
			BtnVersionDel,
			// Token: 0x04036C90 RID: 224400
			BtnVersionPause,
			// Token: 0x04036C91 RID: 224401
			BtnVersionStar,
			// Token: 0x04036C92 RID: 224402
			BtnVersionDownload,
			// Token: 0x04036C93 RID: 224403
			PanelDone,
			// Token: 0x04036C94 RID: 224404
			PanelActiveB,
			// Token: 0x04036C95 RID: 224405
			TxtActivated,
			// Token: 0x04036C96 RID: 224406
			BtnCancel,
			// Token: 0x04036C97 RID: 224407
			BtnConfirm,
			// Token: 0x04036C98 RID: 224408
			PanelAssetInfo
		}

		// Token: 0x0200B093 RID: 45203
		protected enum EDownloadState
		{
			// Token: 0x04036C9A RID: 224410
			None,
			// Token: 0x04036C9B RID: 224411
			Downloading,
			// Token: 0x04036C9C RID: 224412
			Pause,
			// Token: 0x04036C9D RID: 224413
			Done,
			// Token: 0x04036C9E RID: 224414
			NoSpace
		}
	}
}
