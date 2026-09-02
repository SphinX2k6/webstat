using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Launcher.NetworkDetection;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.NetworkDetection
{
	// Token: 0x020056C4 RID: 22212
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class NetworkDetectionItem : GridProxyAbstract<INetworkDetectionItemData>
	{
		// Token: 0x0603888F RID: 231567 RVA: 0x00E52674 File Offset: 0x00E50874
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06038890 RID: 231568 RVA: 0x00E52761 File Offset: 0x00E50961
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x06038891 RID: 231569 RVA: 0x00E52774 File Offset: 0x00E50974
		[NullableContext(1)]
		public override void Refresh(INetworkDetectionItemData data, bool isSelected, int gridIndex)
		{
			this.NetworkDetectionItemData = data;
			this.UpdateView();
		}

		// Token: 0x06038892 RID: 231570 RVA: 0x00E52784 File Offset: 0x00E50984
		private void UpdateView()
		{
			INetworkDetectionEntry entryData = this.NetworkDetectionItemData.EntryData;
			INetworkDetectionResult result = this.NetworkDetectionItemData.Result;
			base.GetText(0).ShowTextNew(entryData.NameLocalKey);
			base.GetSprite(1).SetUIActive(result != null && !result.Success);
			base.GetSprite(2).SetUIActive(result != null && result.Success);
			base.GetSprite(3).SetUIActive(this.NetworkDetectionItemData.Proceed);
			bool flag = result != null && !result.Success && result != null && result.Code != null;
			if (flag)
			{
				string genericErrorCodeTips = LauncherNetworkDetectionModel.GetGenericErrorCodeTips(entryData.Type, result.Code.Value, result);
				base.GetText(5).SetText(genericErrorCodeTips, true);
				this.NetworkDetectionItemData.ErrorCodeText = genericErrorCodeTips;
			}
			base.GetItem(4).SetUIActive(flag);
		}

		// Token: 0x06038893 RID: 231571 RVA: 0x00E52868 File Offset: 0x00E50A68
		protected override void OnBeforeDestroy()
		{
			if (this.NetworkDetectionItemData.EntryData.Type == ENetworkDetectionType.UdpPort)
			{
				if (Singleton<LauncherNetworkDetectionController>.Instance.GetGateWayUdpCheckState())
				{
					UKuroNetworkDetection.AbortGatewayUdpReachable();
					return;
				}
				INetworkDetectionResult result = this.NetworkDetectionItemData.Result;
				UKuroNetworkDetection.DetectionFinish(result != null && result.Success);
			}
		}

		// Token: 0x06038894 RID: 231572 RVA: 0x00E528B8 File Offset: 0x00E50AB8
		public UniTask<bool> Proceed()
		{
			NetworkDetectionItem.<Proceed>d__8 <Proceed>d__;
			<Proceed>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<Proceed>d__.<>4__this = this;
			<Proceed>d__.<>1__state = -1;
			<Proceed>d__.<>t__builder.Start<NetworkDetectionItem.<Proceed>d__8>(ref <Proceed>d__);
			return <Proceed>d__.<>t__builder.Task;
		}

		// Token: 0x06038895 RID: 231573 RVA: 0x00E528FB File Offset: 0x00E50AFB
		[NullableContext(1)]
		public override object GetKey(INetworkDetectionItemData data, int displayIndex)
		{
			return displayIndex;
		}

		// Token: 0x04020444 RID: 132164
		[Nullable(2)]
		private INetworkDetectionItemData NetworkDetectionItemData;

		// Token: 0x04020445 RID: 132165
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200B730 RID: 46896
		private enum EComponents
		{
			// Token: 0x04038A98 RID: 232088
			TxtName,
			// Token: 0x04038A99 RID: 232089
			ErrorIcon,
			// Token: 0x04038A9A RID: 232090
			CorrectIcon,
			// Token: 0x04038A9B RID: 232091
			ProceedIcon,
			// Token: 0x04038A9C RID: 232092
			PnlError,
			// Token: 0x04038A9D RID: 232093
			TxtError
		}
	}
}
