using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Teleport
{
	// Token: 0x02004EF1 RID: 20209
	[NullableContext(1)]
	[Nullable(0)]
	public class TeleportStreamingHelper : TeleportContextHolder
	{
		// Token: 0x06034387 RID: 213895 RVA: 0x00D0F1F2 File Offset: 0x00D0D3F2
		public TeleportStreamingHelper(TeleportContext context) : base(context)
		{
		}

		// Token: 0x06034388 RID: 213896 RVA: 0x00D0F1FC File Offset: 0x00D0D3FC
		public void FlushWorldPartitionUnloadingStreamingCells()
		{
			if (!UKuroStaticLibrary.IsLowMemoryDevice())
			{
				return;
			}
			UWorldPartitionSubsystem uworldPartitionSubsystem = UKuroRenderingRuntimeBPPluginBPLibrary.GetSubsystem(GlobalData.World, UWorldPartitionSubsystem.StaticClass()) as UWorldPartitionSubsystem;
			if (uworldPartitionSubsystem != null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Teleport;
				ELogAuthor author = ELogAuthor.XY;
				string message = "清理卸载流送单元(开始)";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PhysicalMemory", Singleton<GameSettingsDeviceRender>.Instance.PhysicalGBRam);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				uworldPartitionSubsystem.FlushUnloadingStreamingCells();
				Singleton<Log>.Instance.Info(ELogModule.Teleport, ELogAuthor.XY, "清理卸载流送单元(结束)", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		}

		// Token: 0x06034389 RID: 213897 RVA: 0x00D0F28C File Offset: 0x00D0D48C
		public UniTask CheckLiveLocationStreamingCompleted(bool isVoxel = false)
		{
			TeleportStreamingHelper.<CheckLiveLocationStreamingCompleted>d__3 <CheckLiveLocationStreamingCompleted>d__;
			<CheckLiveLocationStreamingCompleted>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CheckLiveLocationStreamingCompleted>d__.<>4__this = this;
			<CheckLiveLocationStreamingCompleted>d__.isVoxel = isVoxel;
			<CheckLiveLocationStreamingCompleted>d__.<>1__state = -1;
			<CheckLiveLocationStreamingCompleted>d__.<>t__builder.Start<TeleportStreamingHelper.<CheckLiveLocationStreamingCompleted>d__3>(ref <CheckLiveLocationStreamingCompleted>d__);
			return <CheckLiveLocationStreamingCompleted>d__.<>t__builder.Task;
		}

		// Token: 0x0603438A RID: 213898 RVA: 0x00D0F2D8 File Offset: 0x00D0D4D8
		private TimerHandle CheckTargetLiveLocationStreamingCompleted(UWorldPartitionStreamingSourceComponent streamingSourceComponent, GameModePromise completedPromise)
		{
			UWorldPartitionSubsystem worldPartitionSubsystem = UKuroRenderingRuntimeBPPluginBPLibrary.GetSubsystem(GlobalData.World, UWorldPartitionSubsystem.StaticClass()) as UWorldPartitionSubsystem;
			UWorldPartitionSubsystem worldPartitionSubsystem2 = worldPartitionSubsystem;
			if (worldPartitionSubsystem2 != null)
			{
				worldPartitionSubsystem2.SetStreamingEnable(true, "");
			}
			this.StreamingStuckLogInterval = 0f;
			TimerHandle timerId = null;
			timerId = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
			{
				AActor streamingSource = ModelBase<GameModeModel>.Instance.StreamingSource;
				if (streamingSource == null || !streamingSource.IsValid())
				{
					return;
				}
				float num = 0f;
				if (worldPartitionSubsystem == null || !streamingSourceComponent.IsStreamingCompletedForLayers2(new TArray<FName>(), false, 7000f, false, ref num, false))
				{
					this.TimerStreamingStuckLog(streamingSourceComponent, 100f, false);
					return;
				}
				TimerSystem.GameplayTimeInstance.Remove(timerId);
				completedPromise.SetResult(true);
			}, 100f, 1f, null, null, true);
			return timerId;
		}

		// Token: 0x0603438B RID: 213899 RVA: 0x00D0F378 File Offset: 0x00D0D578
		public UniTask CheckStreamingCompleted(bool isVoxel = false)
		{
			TeleportStreamingHelper.<CheckStreamingCompleted>d__5 <CheckStreamingCompleted>d__;
			<CheckStreamingCompleted>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CheckStreamingCompleted>d__.<>4__this = this;
			<CheckStreamingCompleted>d__.isVoxel = isVoxel;
			<CheckStreamingCompleted>d__.<>1__state = -1;
			<CheckStreamingCompleted>d__.<>t__builder.Start<TeleportStreamingHelper.<CheckStreamingCompleted>d__5>(ref <CheckStreamingCompleted>d__);
			return <CheckStreamingCompleted>d__.<>t__builder.Task;
		}

		// Token: 0x0603438C RID: 213900 RVA: 0x00D0F3C4 File Offset: 0x00D0D5C4
		private unsafe TimerHandle CheckTargetStreamingCompleted(UWorldPartitionStreamingSourceComponent streamingSourceComponent, GameModePromise completed, [Nullable(2)] TArray<FName> dataLayerLabels, bool checkPhysics = false)
		{
			TArray<FName> targetGrids = streamingSourceComponent.TargetGrids;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Teleport;
			ELogAuthor author = ELogAuthor.XY;
			string message = "传送:检测参数";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("dataLayers", (dataLayerLabels != null && dataLayerLabels.Num() > 0) ? dataLayerLabels.Get(0).ToString() : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("targetGrids", (targetGrids != null && targetGrids.Num() > 0) ? targetGrids.Get(0).ToString() : null);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			UWorldPartitionSubsystem worldPartitionSubsystem = UKuroRenderingRuntimeBPPluginBPLibrary.GetSubsystem(GlobalData.World, UWorldPartitionSubsystem.StaticClass()) as UWorldPartitionSubsystem;
			UWorldPartitionSubsystem worldPartitionSubsystem2 = worldPartitionSubsystem;
			if (worldPartitionSubsystem2 != null)
			{
				worldPartitionSubsystem2.SetStreamingEnable(true, "");
			}
			bool isCheckingPhysics = false;
			this.StreamingStuckLogInterval = 0f;
			TArray<FName> notNullDataLayers = dataLayerLabels ?? new TArray<FName>();
			TimerHandle timerId = null;
			timerId = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
			{
				if (!streamingSourceComponent.IsValid())
				{
					return;
				}
				if (worldPartitionSubsystem == null)
				{
					base.<CheckTargetStreamingCompleted>g__checkingCall|1();
					return;
				}
				if (!isCheckingPhysics)
				{
					float num = 0f;
					if (!streamingSourceComponent.IsStreamingCompletedForLayers2(notNullDataLayers, false, 7000f, false, ref num, false))
					{
						base.<CheckTargetStreamingCompleted>g__checkingCall|1();
						return;
					}
					isCheckingPhysics = checkPhysics;
					if (isCheckingPhysics)
					{
						Singleton<Log>.Instance.Info(ELogModule.Teleport, ELogAuthor.XY, "传送:检测场景物理体(开始)", default(ReadOnlySpan<ValueTuple<string, object>>));
					}
				}
				if (isCheckingPhysics)
				{
					float num2 = 0f;
					if (!streamingSourceComponent.IsStreamingCompletedForLayers2(notNullDataLayers, false, 7000f, false, ref num2, true))
					{
						base.<CheckTargetStreamingCompleted>g__checkingCall|1();
						return;
					}
					Singleton<Log>.Instance.Info(ELogModule.Teleport, ELogAuthor.XY, "传送:检测场景物理体(完成)", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				TimerSystem.GameplayTimeInstance.Remove(timerId);
				completed.SetResult(true);
			}, 100f, 1f, null, null, true);
			return timerId;
		}

		// Token: 0x0603438D RID: 213901 RVA: 0x00D0F52A File Offset: 0x00D0D72A
		private void TimerStreamingStuckLog(UWorldPartitionStreamingSourceComponent streamingSourceComponent, float interval, bool bRequestPhysics = false)
		{
			this.StreamingStuckLogInterval += interval;
			if (this.StreamingStuckLogInterval > 60000f)
			{
				ControllerBase<GameModeController>.Instance.PrintWorldPartitionDebugInfo(streamingSourceComponent, null, false, 7000f, bRequestPhysics);
				this.StreamingStuckLogInterval = 0f;
			}
		}

		// Token: 0x0401E238 RID: 123448
		private float StreamingStuckLogInterval;
	}
}
