using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.LogUpload;
using CSharpScript.Launcher.NetworkDetection;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.SubViews
{
	// Token: 0x02005784 RID: 22404
	[NullableContext(2)]
	[Nullable(0)]
	public class LogUploadView : UiViewBase
	{
		// Token: 0x06039014 RID: 233492 RVA: 0x00E71BB0 File Offset: 0x00E6FDB0
		[NullableContext(1)]
		public LogUploadView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06039015 RID: 233493 RVA: 0x00E71BC0 File Offset: 0x00E6FDC0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUISprite)),
				new ValueTuple<int, Type>(6, typeof(UUIExtendToggle))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(6, new Action<EToggleState>(this.OnUploadConfirmToggleClick))
			};
		}

		// Token: 0x06039016 RID: 233494 RVA: 0x00E71C95 File Offset: 0x00E6FE95
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.SdkCustomerRedPointRefresh, new Action(this.RefreshRedDot));
		}

		// Token: 0x06039017 RID: 233495 RVA: 0x00E71CB3 File Offset: 0x00E6FEB3
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.SdkCustomerRedPointRefresh, new Action(this.RefreshRedDot));
		}

		// Token: 0x06039018 RID: 233496 RVA: 0x00E71CD4 File Offset: 0x00E6FED4
		protected void RefreshRedDot()
		{
			bool customerServiceRedPointState = ControllerBase<global::KuroSdkController>.Instance.GetCustomerServiceRedPointState();
			ButtonItem contactButton = this.ContactButton;
			if (contactButton == null)
			{
				return;
			}
			contactButton.SetRedDotVisible(customerServiceRedPointState);
		}

		// Token: 0x06039019 RID: 233497 RVA: 0x00E71D00 File Offset: 0x00E6FF00
		protected override void OnStart()
		{
			if (this.OpenParam != null)
			{
				this.OpenSourceType = (EKuroSdkOpenCustomerServerType)this.OpenParam;
			}
			this.TextDescription = base.GetText(0);
			this.SpriteProgress = base.GetSprite(2);
			this.ContactButton = new ButtonItem(base.GetItem(3));
			this.ContactButton.SetFunction(new Action<int>(this.OnOpenCustomerService));
			this.ContactButton.SetShowText("Text_LogUploadService_Text");
			this.ContactButton.SetActive(false);
			this.RefreshRedDot();
			this.ConfirmButton = new ButtonItem(base.GetItem(4));
			this.ConfirmButton.SetFunction(new Action<int>(this.OnConfirm));
			this.UploadState = EUploadState.Wait;
			IUiPopFrameInterface childPopView = this.ChildPopView;
			if (childPopView == null)
			{
				return;
			}
			childPopView.PopItem.OverrideBackBtnCallBack(new Action(this.OnClose));
		}

		// Token: 0x0603901A RID: 233498 RVA: 0x00E71DDC File Offset: 0x00E6FFDC
		protected override void OnBeforeDestroy()
		{
			this.ClearDelegate();
			this.TextDescription = null;
			this.SpriteProgress = null;
			ButtonItem contactButton = this.ContactButton;
			if (contactButton == null)
			{
				return;
			}
			contactButton.Destroy(null);
		}

		// Token: 0x0603901B RID: 233499 RVA: 0x00E71E03 File Offset: 0x00E70003
		private void OnUploadConfirmToggleClick(EToggleState state)
		{
			this.IsConfirmUpload = (state == EToggleState.ETT_Checked);
		}

		// Token: 0x0603901C RID: 233500 RVA: 0x00E71E0F File Offset: 0x00E7000F
		private void OnOpenCustomerService(int _)
		{
			if (this.OpenSourceType == EKuroSdkOpenCustomerServerType.Setting)
			{
				ControllerBase<LogController>.Instance.RequestOutputDebugInfo();
			}
			ControllerBase<global::KuroSdkController>.Instance.OpenCustomerService(this.OpenSourceType);
		}

		// Token: 0x0603901D RID: 233501 RVA: 0x00E71E34 File Offset: 0x00E70034
		private void OnConfirm(int _)
		{
			switch (this.UploadState)
			{
			case EUploadState.Wait:
				if (!this.IsConfirmUpload)
				{
					ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("LogUploadConfirmTip", Array.Empty<object>());
					return;
				}
				if (!this.CheckTimeIntervalLegal())
				{
					ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("LogUploadLimited", Array.Empty<object>());
					return;
				}
				this.UploadState = EUploadState.Uploading;
				this.StartUploadLog();
				return;
			case EUploadState.Uploading:
				if (this.InterruptUploadLog())
				{
					this.UploadState = EUploadState.Wait;
					return;
				}
				break;
			case EUploadState.FinishAndSuccess:
				this.OnClose();
				return;
			case EUploadState.FinishAndFailed:
				this.UploadState = EUploadState.Uploading;
				this.StartUploadLog();
				break;
			default:
				return;
			}
		}

		// Token: 0x0603901E RID: 233502 RVA: 0x00E71ECB File Offset: 0x00E700CB
		private void OnClose()
		{
			if (this.UploadState == EUploadState.Uploading && !this.InterruptUploadLog())
			{
				return;
			}
			base.CloseMe(null);
		}

		// Token: 0x0603901F RID: 233503 RVA: 0x00E71EE6 File Offset: 0x00E700E6
		private void TrySetContactButtonVisible(bool bVisible)
		{
			if (!bVisible)
			{
				this.ContactButton.SetActive(false);
				return;
			}
			if (!ControllerBase<global::KuroSdkController>.Instance.NeedShowCustomerService())
			{
				this.ContactButton.SetActive(false);
				return;
			}
			this.ContactButton.SetActive(true);
		}

		// Token: 0x06039020 RID: 233504 RVA: 0x00E71F1D File Offset: 0x00E7011D
		private void ClearDelegate()
		{
			UKuroTencentCOSLibrary.ClearAllProgressCallback();
			if (this.UploadDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<ESendState, float>(this.UploadEventCallBack));
				this.UploadDelegate = null;
			}
		}

		// Token: 0x1700919B RID: 37275
		// (get) Token: 0x06039021 RID: 233505 RVA: 0x00E71F44 File Offset: 0x00E70144
		// (set) Token: 0x06039022 RID: 233506 RVA: 0x00E71F4C File Offset: 0x00E7014C
		private EUploadState UploadState
		{
			get
			{
				return this.InnerUploadState;
			}
			set
			{
				this.InnerUploadState = value;
				UUIExtendToggle extendToggle = base.GetExtendToggle(6);
				UUIItem item = base.GetItem(1);
				UUISprite sprite = base.GetSprite(5);
				switch (this.InnerUploadState)
				{
				case EUploadState.Wait:
				{
					this.TrySetContactButtonVisible(true);
					this.ConfirmButton.SetShowText("Text_LogUpload_Text");
					this.TextDescription.ShowTextNew("Text_LogUploadConfirm_Text");
					this.TextDescription.SetUIActive(true);
					string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_UploadState1");
					this.SetSpriteByPath(resourcePath, sprite, false, null, null);
					extendToggle.RootUIComp.Get().SetUIActive(true);
					item.SetUIActive(false);
					return;
				}
				case EUploadState.Uploading:
				{
					this.TrySetContactButtonVisible(false);
					this.ConfirmButton.SetShowText("Text_LogUploadCancel_Text");
					this.TextDescription.SetText("", true);
					string resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_UploadState2");
					this.SetSpriteByPath(resourcePath2, sprite, false, null, null);
					extendToggle.RootUIComp.Get().SetUIActive(false);
					item.SetUIActive(true);
					return;
				}
				case EUploadState.FinishAndSuccess:
				{
					this.TrySetContactButtonVisible(true);
					this.ConfirmButton.SetShowText("Text_LogUploadYes_Text");
					this.TextDescription.ShowTextNew("Text_LogUploadSuccess_Text");
					string resourcePath3 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_UploadState3");
					this.SetSpriteByPath(resourcePath3, sprite, false, null, null);
					extendToggle.RootUIComp.Get().SetUIActive(false);
					item.SetUIActive(false);
					return;
				}
				case EUploadState.FinishAndFailed:
				{
					this.TrySetContactButtonVisible(true);
					this.ConfirmButton.SetShowText("Text_LogUploadRetry_Text");
					int allFileNumNeedToSend = UKuroTencentCOSLibrary.GetAllFileNumNeedToSend();
					int sendedFileNum = UKuroTencentCOSLibrary.GetSendedFileNum();
					int num = allFileNumNeedToSend - sendedFileNum;
					Singleton<LguiUtil>.Instance.SetLocalTextNew(this.TextDescription, "Text_LogUploadFail_Text", new <>z__ReadOnlyArray<object>(new object[]
					{
						num,
						allFileNumNeedToSend
					}));
					string resourcePath4 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_UploadState1");
					this.SetSpriteByPath(resourcePath4, sprite, false, null, null);
					extendToggle.RootUIComp.Get().SetUIActive(false);
					item.SetUIActive(false);
					return;
				}
				default:
					return;
				}
			}
		}

		// Token: 0x06039023 RID: 233507 RVA: 0x00E72184 File Offset: 0x00E70384
		private unsafe bool CheckTimeIntervalLegal()
		{
			int? intConfig = ConfigCommonParamById.GetIntConfig("LogUploadTimeInterval");
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			int? num = null;
			if (Singleton<global::Net>.Instance.IsServerConnected())
			{
				num = new int?(CSharpScript.Game.Common.LocalStorage.GetPlayer<int>(ELocalStoragePlayerKey.LastTimeUploadStamp, 0));
			}
			else
			{
				num = new int?(CSharpScript.Game.Common.LocalStorage.GetGlobal<int>(ELocalStorageGlobalKey.LastTimeUploadStamp, 0));
			}
			if (num == null)
			{
				return true;
			}
			double num2 = serverTime - (double)num.Value;
			int? num3 = intConfig;
			double? num4 = (num3 != null) ? new double?((double)num3.GetValueOrDefault()) : null;
			if (num2 > num4.GetValueOrDefault() & num4 != null)
			{
				return true;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Log;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "[LogUpload] 上传时间不合法";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("LastTimeStamp", num.Value);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CurrentTimeStamp", serverTime);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}

		// Token: 0x06039024 RID: 233508 RVA: 0x00E72294 File Offset: 0x00E70494
		private void StartUploadLog()
		{
			this.Rate = 0f;
			this.SpriteProgress.SetFillAmount(0f);
			this.ClearDelegate();
			if (this.UploadDelegate == null)
			{
				this.UploadDelegate = global::DelegateUtils.ToManualReleaseDelegate<FOnProgress>(new Action<ESendState, float>(this.UploadEventCallBack));
			}
			if (this.OpenSourceType == EKuroSdkOpenCustomerServerType.Setting)
			{
				ControllerBase<LogController>.Instance.RequestOutputDebugInfo();
			}
			Singleton<LauncherLogUpload>.Instance.SendLog(this.UploadDelegate);
		}

		// Token: 0x06039025 RID: 233509 RVA: 0x00E72304 File Offset: 0x00E70504
		private bool InterruptUploadLog()
		{
			if (this.UploadSendState.GetValueOrDefault() == ESendState.ESS_Compressing)
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("LogUploadCompressingTip", Array.Empty<object>());
				return false;
			}
			if (UKuroTencentCOSLibrary.IsSending())
			{
				UKuroTencentCOSLibrary.InterruptSending();
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("LogUploadCancelTip", Array.Empty<object>());
				return true;
			}
			return false;
		}

		// Token: 0x06039026 RID: 233510 RVA: 0x00E72358 File Offset: 0x00E70558
		private unsafe void FinishUploadLog()
		{
			this.ClearDelegate();
			bool flag = this.UploadSendState.GetValueOrDefault() == ESendState.ESS_Done;
			this.UploadState = (flag ? EUploadState.FinishAndSuccess : EUploadState.FinishAndFailed);
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			bool flag2 = Singleton<global::Net>.Instance.IsServerConnected();
			if (flag)
			{
				if (flag2)
				{
					CSharpScript.Game.Common.LocalStorage.SetPlayer<double>(ELocalStoragePlayerKey.LastTimeUploadStamp, serverTime);
				}
				else
				{
					CSharpScript.Game.Common.LocalStorage.SetGlobal<double>(ELocalStorageGlobalKey.LastTimeUploadStamp, serverTime);
				}
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Log;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "[LogUpload] 上传结束";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("IsLogin", flag2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Success", flag);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("TimeStamp", serverTime);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}

		// Token: 0x06039027 RID: 233511 RVA: 0x00E72430 File Offset: 0x00E70630
		protected void UploadEventCallBack(ESendState state, float rate)
		{
			if (this.UploadState != EUploadState.Uploading)
			{
				return;
			}
			this.UploadSendState = new ESendState?(state);
			if (this.UploadSendState.GetValueOrDefault() == ESendState.ESS_Done || this.UploadSendState.GetValueOrDefault() == ESendState.ESS_Fail)
			{
				this.FinishUploadLog();
				return;
			}
			if (this.Rate == rate)
			{
				return;
			}
			if (this.UploadSendState.GetValueOrDefault() != ESendState.ESS_Compressing && this.UploadSendState.GetValueOrDefault() != ESendState.ESS_Sending)
			{
				return;
			}
			string item = Math.Round((double)(rate * 100f)).ToString() + "%";
			string textStringId = (this.UploadSendState.GetValueOrDefault() == ESendState.ESS_Compressing) ? "Text_LogCompressing_Text" : "Text_LogUploading_Text";
			Singleton<LguiUtil>.Instance.SetLocalTextNew(this.TextDescription, textStringId, new <>z__ReadOnlySingleElementList<object>(item));
			this.SpriteProgress.SetFillAmount(rate);
			this.Rate = rate;
		}

		// Token: 0x04020749 RID: 132937
		private bool IsConfirmUpload;

		// Token: 0x0402074A RID: 132938
		private EUploadState InnerUploadState;

		// Token: 0x0402074B RID: 132939
		private float Rate;

		// Token: 0x0402074C RID: 132940
		private UUIText TextDescription;

		// Token: 0x0402074D RID: 132941
		private UUISprite SpriteProgress;

		// Token: 0x0402074E RID: 132942
		private ButtonItem ContactButton;

		// Token: 0x0402074F RID: 132943
		private ButtonItem ConfirmButton;

		// Token: 0x04020750 RID: 132944
		protected FOnProgress UploadDelegate;

		// Token: 0x04020751 RID: 132945
		private ESendState? UploadSendState;

		// Token: 0x04020752 RID: 132946
		private EKuroSdkOpenCustomerServerType OpenSourceType = EKuroSdkOpenCustomerServerType.Login;
	}
}
