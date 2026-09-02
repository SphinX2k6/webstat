using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.NetworkDetection;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.Ui.HotFix.NetWorkDetection
{
	// Token: 0x02004523 RID: 17699
	public class HotFixNetworkDetectionEntryItem : LaunchComponentsAction, IHotFixLayoutItem
	{
		// Token: 0x0602E9F7 RID: 190967 RVA: 0x00B0B361 File Offset: 0x00B09561
		[NullableContext(1)]
		public void SetRootActor(AActor actor)
		{
			base.SetRootActorLaunchComponentsAction(actor);
		}

		// Token: 0x0602E9F8 RID: 190968 RVA: 0x00B0B36A File Offset: 0x00B0956A
		protected override void OnShow()
		{
			this.UpdateView();
		}

		// Token: 0x0602E9F9 RID: 190969 RVA: 0x00B0B374 File Offset: 0x00B09574
		private void UpdateView()
		{
			INetworkDetectionEntry entryData = this.Data.EntryData;
			INetworkDetectionResult result = this.Data.Result;
			HotFixManager.SetLocalText(base.GetText(0), entryData.NameLocalKey, Array.Empty<string>());
			base.GetTexture(1).SetUIActive(result != null && (result == null || !result.Success));
			base.GetTexture(2).SetUIActive(result != null && result != null && result.Success);
			base.GetTexture(3).SetUIActive(this.Data.Proceed);
			bool flag = result != null && !result.Success && result != null && result.Code != null;
			if (flag)
			{
				string genericErrorCodeTips = LauncherNetworkDetectionModel.GetGenericErrorCodeTips(entryData.Type, result.Code.Value, result);
				base.GetText(5).SetText(genericErrorCodeTips, true);
				this.Data.ErrorCodeText = genericErrorCodeTips;
			}
			base.GetItem(4).SetUIActive(flag);
		}

		// Token: 0x0602E9FA RID: 190970 RVA: 0x00B0B468 File Offset: 0x00B09668
		[NullableContext(1)]
		public void Refresh(IHotFixLayoutData data)
		{
			this.Data = (IHotFixNetworkDetectionLayoutItemData)data;
		}

		// Token: 0x0602E9FB RID: 190971 RVA: 0x00B0B478 File Offset: 0x00B09678
		protected override void OnBeforeDestroy()
		{
			if (this.Data.EntryData.Type == ENetworkDetectionType.UdpPort)
			{
				if (Singleton<LauncherNetworkDetectionController>.Instance.GetGateWayUdpCheckState())
				{
					UKuroNetworkDetection.AbortGatewayUdpReachable();
					return;
				}
				INetworkDetectionResult result = this.Data.Result;
				UKuroNetworkDetection.DetectionFinish(result != null && result.Success);
			}
		}

		// Token: 0x0602E9FC RID: 190972 RVA: 0x00B0B4C8 File Offset: 0x00B096C8
		public UniTask Proceed()
		{
			HotFixNetworkDetectionEntryItem.<Proceed>d__8 <Proceed>d__;
			<Proceed>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Proceed>d__.<>4__this = this;
			<Proceed>d__.<>1__state = -1;
			<Proceed>d__.<>t__builder.Start<HotFixNetworkDetectionEntryItem.<Proceed>d__8>(ref <Proceed>d__);
			return <Proceed>d__.<>t__builder.Task;
		}

		// Token: 0x0401A7A2 RID: 108450
		[Nullable(2)]
		public THotFixLayoutItemClickCallBack ItemClickCallBack;

		// Token: 0x0401A7A3 RID: 108451
		[Nullable(2)]
		private IHotFixNetworkDetectionLayoutItemData Data;

		// Token: 0x0200A73C RID: 42812
		private static class EComponents
		{
			// Token: 0x04033E73 RID: 212595
			public const int TxtName = 0;

			// Token: 0x04033E74 RID: 212596
			public const int ErrorIcon = 1;

			// Token: 0x04033E75 RID: 212597
			public const int CorrectIcon = 2;

			// Token: 0x04033E76 RID: 212598
			public const int ProceedIcon = 3;

			// Token: 0x04033E77 RID: 212599
			public const int PnlError = 4;

			// Token: 0x04033E78 RID: 212600
			public const int TxtError = 5;
		}
	}
}
