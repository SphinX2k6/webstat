using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.Define;
using CSharpScript.Launcher.LogUpload;
using CSharpScript.Launcher.NetworkDetection;
using CSharpScript.Launcher.PlayerInput;
using CSharpScript.Launcher.Ui.HotFix.NetWorkDetection.SelectServer;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.Ui.HotFix.NetWorkDetection
{
	// Token: 0x02004526 RID: 17702
	[NullableContext(1)]
	[Nullable(0)]
	public class HotFixNetworkDetectionView : LaunchComponentsAction
	{
		// Token: 0x0602EA10 RID: 190992 RVA: 0x00B0B98C File Offset: 0x00B09B8C
		public UniTask LoadAsync(UObject worldContext)
		{
			HotFixNetworkDetectionView.<LoadAsync>d__10 <LoadAsync>d__;
			<LoadAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadAsync>d__.<>4__this = this;
			<LoadAsync>d__.worldContext = worldContext;
			<LoadAsync>d__.<>1__state = -1;
			<LoadAsync>d__.<>t__builder.Start<HotFixNetworkDetectionView.<LoadAsync>d__10>(ref <LoadAsync>d__);
			return <LoadAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0602EA11 RID: 190993 RVA: 0x00B0B9D8 File Offset: 0x00B09BD8
		protected override void OnStart()
		{
			base.GetButton(1).OnClickCallBack.Bind(new Action(this.OnBackBtnClick));
			base.GetButton(5).OnClickCallBack.Bind(new Action(this.OnSelectServerBtnClick));
			HotFixManager.SetLocalText(base.GetText(2), "NetworkDetection_Title", Array.Empty<string>());
			this.RightButtonItem = base.AttachElement<HotFixButtonItem>(9);
			this.RightButtonItem.BindClickCallback(new Action(this.OnRightBtnClick));
			HotFixButtonItem hotFixButtonItem = base.AttachElement<HotFixButtonItem>(8);
			hotFixButtonItem.SetLocalText("NetworkDetection_Cancel");
			hotFixButtonItem.BindClickCallback(new Action(this.OnLeftBtnClick));
			UUILayoutBase layout = base.GetLayout(10);
			AUIBaseActor gridActor = base.GetItem(7).GetOwner() as AUIBaseActor;
			this.DetectionLayout = new HotFixLayout<HotFixNetworkDetectionEntryItem, IHotFixNetworkDetectionLayoutItemData>(layout, new Func<HotFixNetworkDetectionEntryItem>(this.CreateDetectionLayoutEntryItem), gridActor);
			Singleton<HotPatchInputManager>.Instance.RegisterInputAxis("手柄右摇杆垂直方向", new TInputAxis(this.InputAxis));
		}

		// Token: 0x0602EA12 RID: 190994 RVA: 0x00B0BACC File Offset: 0x00B09CCC
		private HotFixNetworkDetectionEntryItem CreateDetectionLayoutEntryItem()
		{
			HotFixNetworkDetectionEntryItem hotFixNetworkDetectionEntryItem = new HotFixNetworkDetectionEntryItem();
			this.DetectionLayoutItemList.Add(hotFixNetworkDetectionEntryItem);
			return hotFixNetworkDetectionEntryItem;
		}

		// Token: 0x0602EA13 RID: 190995 RVA: 0x00B0BAEC File Offset: 0x00B09CEC
		protected override void OnShow()
		{
			this.DetectionViewState = EDetectionViewState.Idle;
			List<IHotFixNetworkDetectionLayoutItemData> networkDetectionLayoutItemData = Singleton<HotFixNetworkDetectionModel>.Instance.GetNetworkDetectionLayoutItemData();
			this.DetectionLayout.RefreshByData(networkDetectionLayoutItemData);
			this.NetworkDetectionLogUploadHandle = new NetworkDetectionLogUploadHandle();
			this.NetworkDetectionLogUploadHandle.LogUploadFinishCallBack = new TNetworkDetectionLogUploadFinishCallBack(this.OnLogUploadFinish);
			this.CheckAndInitServerSelection();
			this.UpdateSelectServer();
		}

		// Token: 0x0602EA14 RID: 190996 RVA: 0x00B0BB45 File Offset: 0x00B09D45
		protected override void OnHide()
		{
			Singleton<HotFixNetworkDetectionModel>.Instance.ResetInterruptDetectionCheckTime();
		}

		// Token: 0x0602EA15 RID: 190997 RVA: 0x00B0BB51 File Offset: 0x00B09D51
		protected override void OnBeforeDestroy()
		{
			NetworkDetectionLogUploadHandle networkDetectionLogUploadHandle = this.NetworkDetectionLogUploadHandle;
			if (networkDetectionLogUploadHandle != null)
			{
				networkDetectionLogUploadHandle.InterruptUploadLog();
			}
			Singleton<HotPatchInputManager>.Instance.UnRegisterInputAxis("手柄右摇杆垂直方向", new TInputAxis(this.InputAxis));
		}

		// Token: 0x0602EA16 RID: 190998 RVA: 0x00B0BB80 File Offset: 0x00B09D80
		private unsafe void CheckAndInitServerSelection()
		{
			bool flag = Singleton<LauncherNetworkDetectionController>.Instance.IsGlobalPlayer();
			bool flag2 = flag;
			base.GetItem(3).SetUIActive(flag2);
			this.RightButtonItem.SetEnableClick(!flag2);
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "网络检测->Launcher阶段初始化";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("isGlobalPlayer", flag);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("needSelectServer", flag2);
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			if (!flag2)
			{
				List<ILoginServersData> loginServersByClientRegion = Singleton<HotFixNetworkDetectionModel>.Instance.GetLoginServersByClientRegion();
				if (loginServersByClientRegion != null && loginServersByClientRegion.Count > 0)
				{
					Singleton<HotFixNetworkDetectionModel>.Instance.CurrentSelectServerData = loginServersByClientRegion[0];
					return;
				}
				LauncherLog instance2 = Singleton<LauncherLog>.Instance;
				string message2 = "网络检测->初始化服务器数据失败，服务器列表为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("serverList", loginServersByClientRegion);
				instance2.Error(message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}

		// Token: 0x0602EA17 RID: 190999 RVA: 0x00B0BC63 File Offset: 0x00B09E63
		protected void OnBackBtnClick()
		{
			if (this.DetectionViewState == EDetectionViewState.Detecting)
			{
				this.HotFixNetworkDetectionTips.ShowTip("NetworkDetection_Ing");
				return;
			}
			this.CloseMe();
		}

		// Token: 0x0602EA18 RID: 191000 RVA: 0x00B0BC85 File Offset: 0x00B09E85
		private void SetServerSelectItemActive(bool value)
		{
			base.GetElement<HotFixNetworkDetectSelectView>(101).SetActive(value);
		}

		// Token: 0x0602EA19 RID: 191001 RVA: 0x00B0BC95 File Offset: 0x00B09E95
		private void SetUploadLogTipsItemActive(bool value)
		{
			base.GetElement<HotFixNetworkDetectionTips>(102).SetActive(value);
		}

		// Token: 0x0602EA1A RID: 191002 RVA: 0x00B0BCA5 File Offset: 0x00B09EA5
		private void OnSelectServerBtnClick()
		{
			if (this.DetectionViewState == EDetectionViewState.Detecting || this.DetectionViewState == EDetectionViewState.Uploading)
			{
				this.HotFixNetworkDetectionTips.ShowTip("NetworkDetection_Ing");
				return;
			}
			this.SetServerSelectItemActive(true);
		}

		// Token: 0x0602EA1B RID: 191003 RVA: 0x00B0BCD4 File Offset: 0x00B09ED4
		private void UpdateSelectServer()
		{
			ILoginServersData currentSelectServerData = Singleton<HotFixNetworkDetectionModel>.Instance.CurrentSelectServerData;
			if (currentSelectServerData == null)
			{
				base.GetText(4).SetText("", true);
			}
			else
			{
				base.GetText(4).SetText(currentSelectServerData.name, true);
				Singleton<LauncherNetworkDetectionController>.Instance.SetDetectionConfig(currentSelectServerData);
			}
			this.UpdateButtonState();
		}

		// Token: 0x0602EA1C RID: 191004 RVA: 0x00B0BD28 File Offset: 0x00B09F28
		private void UpdateButtonState()
		{
			ILoginServersData currentSelectServerData = Singleton<HotFixNetworkDetectionModel>.Instance.CurrentSelectServerData;
			base.GetButton(9).SetSelfInteractive(currentSelectServerData != null && this.DetectionViewState != EDetectionViewState.Detecting);
			switch (this.DetectionViewState)
			{
			case EDetectionViewState.Idle:
				HotFixManager.SetLocalText(base.GetText(11), "NetworkDetection_Start_Tips", Array.Empty<string>());
				this.RightButtonItem.SetLocalText("NetworkDetection_Start");
				return;
			case EDetectionViewState.Detecting:
				base.GetText(11).SetText("", true);
				this.RightButtonItem.SetLocalText("NetworkDetection_Ing");
				return;
			case EDetectionViewState.DetectComplete:
			{
				string hotPatchText = Singleton<LauncherConfigLib>.Instance.GetHotPatchText("NetworkDetection_Trace_Id");
				string text = LauncherNetworkDetectionModel.GenerateTraceCode();
				this.TraceId = text;
				this.DetectionTraceText = hotPatchText + " " + text;
				base.GetText(11).SetText(this.DetectionTraceText, true);
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "网络检测->检测完成";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("检测编码:(traceId)", text);
				instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.RightButtonItem.SetLocalText("NetworkDetection_Hotfix_Submit");
				return;
			}
			default:
				this.RightButtonItem.SetLocalText("NetworkDetection_Start");
				return;
			}
		}

		// Token: 0x0602EA1D RID: 191005 RVA: 0x00B0BE54 File Offset: 0x00B0A054
		protected void OnLeftBtnClick()
		{
			if (this.DetectionViewState == EDetectionViewState.Detecting)
			{
				this.HotFixNetworkDetectionTips.ShowTip("NetworkDetection_Ing");
				return;
			}
			this.CloseMe();
		}

		// Token: 0x0602EA1E RID: 191006 RVA: 0x00B0BE76 File Offset: 0x00B0A076
		private void CloseMe()
		{
			base.SetActive(false);
			this.SetUploadLogTipsItemActive(false);
			this.HotFixNetworkDetectionTips.SetActive(false);
			this.NetworkDetectionLogUploadHandle.InterruptUploadLog();
			Singleton<LauncherNetworkDetectionController>.Instance.ForceStopDomainDetect();
		}

		// Token: 0x0602EA1F RID: 191007 RVA: 0x00B0BEA8 File Offset: 0x00B0A0A8
		private void OnRightBtnClick()
		{
			switch (this.DetectionViewState)
			{
			case EDetectionViewState.Idle:
				this.ProceedDetection().Forget();
				return;
			case EDetectionViewState.Detecting:
				return;
			case EDetectionViewState.DetectComplete:
			{
				IReadOnlyList<IHotFixNetworkDetectionLayoutItemData> dataList = this.DetectionLayout.GetDataList();
				string finalErrorCodeString = Singleton<HotFixNetworkDetectionModel>.Instance.GetFinalErrorCodeString(dataList);
				ULGUIBPLibrary.ClipBoardCopy(this.DetectionTraceText + "\n" + finalErrorCodeString);
				this.HotFixNetworkDetectionTips.SetTipsLocalText("NetworkDetection_Submiting");
				this.SetUploadLogTipsItemActive(true);
				this.NetworkDetectionLogUploadHandle.UploadLog();
				this.DetectionViewState = EDetectionViewState.Uploading;
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x0602EA20 RID: 191008 RVA: 0x00B0BF34 File Offset: 0x00B0A134
		private UniTask ProceedDetection()
		{
			HotFixNetworkDetectionView.<ProceedDetection>d__26 <ProceedDetection>d__;
			<ProceedDetection>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ProceedDetection>d__.<>4__this = this;
			<ProceedDetection>d__.<>1__state = -1;
			<ProceedDetection>d__.<>t__builder.Start<HotFixNetworkDetectionView.<ProceedDetection>d__26>(ref <ProceedDetection>d__);
			return <ProceedDetection>d__.<>t__builder.Task;
		}

		// Token: 0x0602EA21 RID: 191009 RVA: 0x00B0BF78 File Offset: 0x00B0A178
		private void OnLogUploadFinish()
		{
			this.DetectionViewState = EDetectionViewState.UpLoadComplete;
			this.SetUploadLogTipsItemActive(false);
			Singleton<LauncherLog>.Instance.Debug("网络检测->上传日志完成，热更阶段不打开客服界面", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.CloseMe();
		}

		// Token: 0x0602EA22 RID: 191010 RVA: 0x00B0BFB4 File Offset: 0x00B0A1B4
		private void OnSelectServerCallBack()
		{
			ILoginServersData currentUiSelectSeverData = Singleton<HotFixNetworkDetectionModel>.Instance.CurrentUiSelectSeverData;
			if (currentUiSelectSeverData != null)
			{
				if (Singleton<LauncherNetworkDetectionController>.Instance.SetDetectionConfig(currentUiSelectSeverData))
				{
					Singleton<HotFixNetworkDetectionModel>.Instance.CurrentSelectServerData = currentUiSelectSeverData;
					this.UpdateSelectServer();
					return;
				}
				Singleton<HotFixNetworkDetectionModel>.Instance.CurrentSelectServerData = null;
				this.HotFixNetworkDetectionTips.ShowTip("NetworkDetection_Error");
			}
		}

		// Token: 0x0602EA23 RID: 191011 RVA: 0x00B0C009 File Offset: 0x00B0A209
		private void InputAxis(float value, string axisName)
		{
			if (value == 0f)
			{
				return;
			}
			if ("手柄右摇杆垂直方向" == axisName)
			{
				base.GetUiScrollViewWithScrollBar(6).SetVelocity(value * 800f);
			}
		}

		// Token: 0x0401A7AC RID: 108460
		private HotFixLayout<HotFixNetworkDetectionEntryItem, IHotFixNetworkDetectionLayoutItemData> DetectionLayout;

		// Token: 0x0401A7AD RID: 108461
		private readonly List<HotFixNetworkDetectionEntryItem> DetectionLayoutItemList = new List<HotFixNetworkDetectionEntryItem>();

		// Token: 0x0401A7AE RID: 108462
		[Nullable(2)]
		private NetworkDetectionLogUploadHandle NetworkDetectionLogUploadHandle;

		// Token: 0x0401A7AF RID: 108463
		private EDetectionViewState DetectionViewState;

		// Token: 0x0401A7B0 RID: 108464
		[Nullable(2)]
		private HotFixButtonItem RightButtonItem;

		// Token: 0x0401A7B1 RID: 108465
		private string DetectionTraceText = "";

		// Token: 0x0401A7B2 RID: 108466
		private string TraceId = "";

		// Token: 0x0401A7B3 RID: 108467
		[Nullable(2)]
		private HotFixNetworkDetectionTips HotFixNetworkDetectionUploadLogTips;

		// Token: 0x0401A7B4 RID: 108468
		[Nullable(2)]
		private HotFixNetworkDetectionTips HotFixNetworkDetectionTips;

		// Token: 0x0200A73F RID: 42815
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04033E82 RID: 212610
			public const int BtnMask = 0;

			// Token: 0x04033E83 RID: 212611
			public const int BtnBack = 1;

			// Token: 0x04033E84 RID: 212612
			public const int TxtTitle = 2;

			// Token: 0x04033E85 RID: 212613
			public const int PnlServer = 3;

			// Token: 0x04033E86 RID: 212614
			public const int TxtServer = 4;

			// Token: 0x04033E87 RID: 212615
			public const int BtnFunctionD = 5;

			// Token: 0x04033E88 RID: 212616
			public const int ScrollView = 6;

			// Token: 0x04033E89 RID: 212617
			public const int NetInfoItem = 7;

			// Token: 0x04033E8A RID: 212618
			public const int BtnLeft = 8;

			// Token: 0x04033E8B RID: 212619
			public const int BtnRight = 9;

			// Token: 0x04033E8C RID: 212620
			public const int NetInfoContent = 10;

			// Token: 0x04033E8D RID: 212621
			public const int TextTips = 11;

			// Token: 0x04033E8E RID: 212622
			public const int SelServerPop = 101;

			// Token: 0x04033E8F RID: 212623
			public const int UploadLogTips = 102;

			// Token: 0x04033E90 RID: 212624
			public const int Tips = 103;
		}
	}
}
