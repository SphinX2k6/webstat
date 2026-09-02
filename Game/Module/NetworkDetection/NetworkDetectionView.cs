using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.LogUpload;
using CSharpScript.Launcher.NetworkDetection;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.NetworkDetection
{
	// Token: 0x020056CA RID: 22218
	[NullableContext(1)]
	[Nullable(0)]
	public class NetworkDetectionView : UiViewBase
	{
		// Token: 0x060388C5 RID: 231621 RVA: 0x00E5311A File Offset: 0x00E5131A
		public NetworkDetectionView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x060388C6 RID: 231622 RVA: 0x00E53144 File Offset: 0x00E51344
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnSelectServerBtnClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnLeftBtnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060388C7 RID: 231623 RVA: 0x00E532F8 File Offset: 0x00E514F8
		protected override UniTask OnBeforeStartAsync()
		{
			NetworkDetectionView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<NetworkDetectionView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060388C8 RID: 231624 RVA: 0x00E5333C File Offset: 0x00E5153C
		protected override void OnStart()
		{
			IUiPopFrameInterface childPopView = this.ChildPopView;
			if (childPopView != null)
			{
				childPopView.PopItem.OverrideBackBtnCallBack(new Action(this.OnLeftBtnClick));
			}
			IUiPopFrameInterface childPopView2 = this.ChildPopView;
			if (childPopView2 != null)
			{
				childPopView2.PopItem.SetMaskResponsibleState(false);
			}
			this.RightButtonItem = new ButtonItem(base.GetItem(6));
			this.RightButtonItem.SetFunction(new Action<int>(this.OnRightBtnClick));
			this.ContentLayout = new GenericLayout<NetworkDetectionItem, INetworkDetectionItemData>(base.GetVerticalLayout(7), new Func<NetworkDetectionItem>(this.InitContentLayoutItem), null, false, true);
			List<INetworkDetectionItemData> networkDetectionLayoutItemData = this.GetNetworkDetectionLayoutItemData();
			this.ContentLayout.RefreshByData(networkDetectionLayoutItemData, null, false);
			this.NetworkDetectionLogUploadHandle = new NetworkDetectionLogUploadHandle();
			this.NetworkDetectionLogUploadHandle.LogUploadFinishCallBack = new TNetworkDetectionLogUploadFinishCallBack(this.OnLogUploadFinish);
		}

		// Token: 0x060388C9 RID: 231625 RVA: 0x00E53403 File Offset: 0x00E51603
		protected override void OnBeforeShow()
		{
			this.DetectionViewState = EDetectionViewState.Idle;
			this.CheckAndInitServerSelection();
			this.UpdateSelectServer();
			Singleton<EventSystem>.Instance.Add(EEventName.OnConfirmNetworkDetectionItem, new Action(this.OnConfirmSelectServer));
		}

		// Token: 0x060388CA RID: 231626 RVA: 0x00E53431 File Offset: 0x00E51631
		protected override void OnAfterHide()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnConfirmNetworkDetectionItem, new Action(this.OnConfirmSelectServer));
		}

		// Token: 0x060388CB RID: 231627 RVA: 0x00E5344C File Offset: 0x00E5164C
		private unsafe void CheckAndInitServerSelection()
		{
			bool flag = Singleton<LauncherNetworkDetectionController>.Instance.IsGlobalPlayer();
			bool isPlayInEditor = Singleton<Info>.Instance.IsPlayInEditor;
			bool flag2 = flag || isPlayInEditor;
			base.GetItem(0).SetUIActive(flag2);
			this.RightButtonItem.SetEnableClick(!flag2);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Login;
			ELogAuthor author = ELogAuthor.LRX;
			string message = "网络检测->Login阶段初始化";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("isGlobalPlayer", flag);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("needSelectServer", flag2);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			if (!flag2)
			{
				List<ILoginServersData> loginServersByClientRegion = ModelBase<LoginServerModel>.Instance.GetLoginServersByClientRegion();
				if (loginServersByClientRegion != null && loginServersByClientRegion.Count > 0)
				{
					ModelBase<NetworkDetectionModel>.Instance.CurrentSelectServerData = loginServersByClientRegion[0];
					this.OnConfirmSelectServer();
					return;
				}
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Login;
				ELogAuthor author2 = ELogAuthor.LRX;
				string message2 = "网络检测->初始化服务器数据失败，服务器列表为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("serverList", loginServersByClientRegion);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}

		// Token: 0x060388CC RID: 231628 RVA: 0x00E5354C File Offset: 0x00E5174C
		private NetworkDetectionItem InitContentLayoutItem()
		{
			NetworkDetectionItem networkDetectionItem = new NetworkDetectionItem();
			this.ContentLayoutItemList.Add(networkDetectionItem);
			return networkDetectionItem;
		}

		// Token: 0x060388CD RID: 231629 RVA: 0x00E5356C File Offset: 0x00E5176C
		protected override void OnBeforeHide()
		{
			ModelBase<NetworkDetectionModel>.Instance.ResetInterruptDetectionCheckTime();
		}

		// Token: 0x060388CE RID: 231630 RVA: 0x00E53578 File Offset: 0x00E51778
		protected override void OnBeforeDestroy()
		{
			NetworkDetectionTips networkDetectionUploadLogTips = this.NetworkDetectionUploadLogTips;
			if (networkDetectionUploadLogTips != null)
			{
				networkDetectionUploadLogTips.Destroy(null);
			}
			NetworkDetectionTips networkDetectionTips = this.NetworkDetectionTips;
			if (networkDetectionTips != null)
			{
				networkDetectionTips.Destroy(null);
			}
			this.RightButtonItem.Destroy(null);
			if (this.ContentLayout != null)
			{
				this.ContentLayout.ClearChildren();
				this.ContentLayout = null;
			}
			this.NetworkDetectionLogUploadHandle.InterruptUploadLog();
			Singleton<LauncherNetworkDetectionController>.Instance.ForceStopDomainDetect();
		}

		// Token: 0x060388CF RID: 231631 RVA: 0x00E535E8 File Offset: 0x00E517E8
		public List<INetworkDetectionItemData> GetNetworkDetectionLayoutItemData()
		{
			List<INetworkDetectionItemData> list = new List<INetworkDetectionItemData>();
			foreach (INetworkDetectionEntry entryData in LauncherNetworkDetectionModel.GetDetectionDataList())
			{
				NetworkDetectionItemData item = new NetworkDetectionItemData
				{
					EntryData = entryData,
					Proceed = false
				};
				list.Add(item);
			}
			return list;
		}

		// Token: 0x060388D0 RID: 231632 RVA: 0x00E53658 File Offset: 0x00E51858
		private void OnSelectServerBtnClick()
		{
			if (this.DetectionViewState == EDetectionViewState.Detecting || this.DetectionViewState == EDetectionViewState.Uploading)
			{
				this.NetworkDetectionTips.ShowTip("NetworkDetection_Ing");
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.NetworkDetectionSelectServerView, null, null);
		}

		// Token: 0x060388D1 RID: 231633 RVA: 0x00E53690 File Offset: 0x00E51890
		private void UpdateSelectServer()
		{
			ILoginServersData currentSelectServerData = ModelBase<NetworkDetectionModel>.Instance.CurrentSelectServerData;
			if (currentSelectServerData == null)
			{
				base.GetText(1).SetText("", true);
			}
			else
			{
				base.GetText(1).SetText(currentSelectServerData.name, true);
			}
			this.UpdateButtonState();
		}

		// Token: 0x060388D2 RID: 231634 RVA: 0x00E536D8 File Offset: 0x00E518D8
		private void OnConfirmSelectServer()
		{
			ILoginServersData currentSelectServerData = ModelBase<NetworkDetectionModel>.Instance.CurrentSelectServerData;
			if (currentSelectServerData != null)
			{
				if (Singleton<LauncherNetworkDetectionController>.Instance.SetDetectionConfig(currentSelectServerData))
				{
					this.UpdateSelectServer();
					return;
				}
				ModelBase<NetworkDetectionModel>.Instance.CurrentSelectServerData = null;
				this.NetworkDetectionTips.ShowTip("NetworkDetection_Error");
			}
		}

		// Token: 0x060388D3 RID: 231635 RVA: 0x00E53724 File Offset: 0x00E51924
		private void UpdateButtonState()
		{
			ILoginServersData currentSelectServerData = ModelBase<NetworkDetectionModel>.Instance.CurrentSelectServerData;
			this.RightButtonItem.SetEnableClick(currentSelectServerData != null && this.DetectionViewState != EDetectionViewState.Detecting);
			switch (this.DetectionViewState)
			{
			case EDetectionViewState.Idle:
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "NetworkDetection_Start_Tips", Array.Empty<object>());
				this.RightButtonItem.SetLocalTextNew("NetworkDetection_Start", Array.Empty<object>());
				return;
			case EDetectionViewState.Detecting:
				base.GetText(8).SetText("", true);
				this.RightButtonItem.SetLocalTextNew("NetworkDetection_Ing", Array.Empty<object>());
				return;
			case EDetectionViewState.DetectComplete:
			{
				string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey("NetworkDetection_Trace_Id");
				string text = LauncherNetworkDetectionModel.GenerateTraceCode();
				this.TraceId = text;
				this.DetectionTraceText = multiTextByKey + " " + text;
				base.GetText(8).SetText(this.DetectionTraceText, true);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Login;
				ELogAuthor author = ELogAuthor.LRX;
				string message = "网络检测->开始检测";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("检测编码:(traceId)", text);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.RightButtonItem.SetLocalTextNew("NetworkDetection_Submit", Array.Empty<object>());
				return;
			}
			default:
				this.RightButtonItem.SetLocalTextNew("NetworkDetection_Start", Array.Empty<object>());
				return;
			}
		}

		// Token: 0x060388D4 RID: 231636 RVA: 0x00E53868 File Offset: 0x00E51A68
		private void OnLeftBtnClick()
		{
			if ((this.DetectionViewState == EDetectionViewState.Detecting || this.DetectionViewState == EDetectionViewState.Uploading) && ModelBase<NetworkDetectionModel>.Instance.NeedInterruptDetectionDoubleCheckTips())
			{
				this.NetworkDetectionTips.ShowTip("NetworkDetection_tips");
				ModelBase<NetworkDetectionModel>.Instance.ConfirmInterruptDetection();
				return;
			}
			base.CloseMe(null);
		}

		// Token: 0x060388D5 RID: 231637 RVA: 0x00E538B8 File Offset: 0x00E51AB8
		private void OnRightBtnClick(int _)
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
				IReadOnlyList<INetworkDetectionItemData> datas = this.ContentLayout.GetDatas();
				string finalErrorCodeString = ModelBase<NetworkDetectionModel>.Instance.GetFinalErrorCodeString(datas);
				ULGUIBPLibrary.ClipBoardCopy(this.DetectionTraceText + "\n" + finalErrorCodeString);
				this.NetworkDetectionUploadLogTips.Show(null);
				this.NetworkDetectionUploadLogTips.SetTipsLocalText("NetworkDetection_Submiting");
				this.NetworkDetectionLogUploadHandle.UploadLog();
				this.DetectionViewState = EDetectionViewState.Uploading;
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x060388D6 RID: 231638 RVA: 0x00E53948 File Offset: 0x00E51B48
		private void OnLogUploadFinish()
		{
			this.DetectionViewState = EDetectionViewState.UpLoadComplete;
			ControllerBase<global::KuroSdkController>.Instance.OpenCustomerService(EKuroSdkOpenCustomerServerType.Login);
			this.NetworkDetectionUploadLogTips.Hide(null);
			base.CloseMe(null);
		}

		// Token: 0x060388D7 RID: 231639 RVA: 0x00E53970 File Offset: 0x00E51B70
		private UniTask ProceedDetection()
		{
			NetworkDetectionView.<ProceedDetection>d__28 <ProceedDetection>d__;
			<ProceedDetection>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ProceedDetection>d__.<>4__this = this;
			<ProceedDetection>d__.<>1__state = -1;
			<ProceedDetection>d__.<>t__builder.Start<NetworkDetectionView.<ProceedDetection>d__28>(ref <ProceedDetection>d__);
			return <ProceedDetection>d__.<>t__builder.Task;
		}

		// Token: 0x0402044E RID: 132174
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<NetworkDetectionItem, INetworkDetectionItemData> ContentLayout;

		// Token: 0x0402044F RID: 132175
		private readonly List<NetworkDetectionItem> ContentLayoutItemList = new List<NetworkDetectionItem>();

		// Token: 0x04020450 RID: 132176
		[Nullable(2)]
		private NetworkDetectionLogUploadHandle NetworkDetectionLogUploadHandle;

		// Token: 0x04020451 RID: 132177
		private EDetectionViewState DetectionViewState;

		// Token: 0x04020452 RID: 132178
		[Nullable(2)]
		private ButtonItem RightButtonItem;

		// Token: 0x04020453 RID: 132179
		[Nullable(2)]
		private NetworkDetectionTips NetworkDetectionUploadLogTips;

		// Token: 0x04020454 RID: 132180
		[Nullable(2)]
		private NetworkDetectionTips NetworkDetectionTips;

		// Token: 0x04020455 RID: 132181
		private string DetectionTraceText = "";

		// Token: 0x04020456 RID: 132182
		private string TraceId = "";

		// Token: 0x0200B73A RID: 46906
		[NullableContext(0)]
		private enum EComponents
		{
			// Token: 0x04038ACB RID: 232139
			PnlServer,
			// Token: 0x04038ACC RID: 232140
			TxtServer,
			// Token: 0x04038ACD RID: 232141
			BtnFunctionD,
			// Token: 0x04038ACE RID: 232142
			ScrollView,
			// Token: 0x04038ACF RID: 232143
			NetInfoItem,
			// Token: 0x04038AD0 RID: 232144
			BtnLeft,
			// Token: 0x04038AD1 RID: 232145
			BtnRight,
			// Token: 0x04038AD2 RID: 232146
			NetInfoContent,
			// Token: 0x04038AD3 RID: 232147
			TexTips
		}
	}
}
