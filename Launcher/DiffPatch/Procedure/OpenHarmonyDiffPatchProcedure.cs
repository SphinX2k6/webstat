using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.DiffPatch.OH;
using CSharpScript.Launcher.DiffPatch.Update;
using CSharpScript.Launcher.Ui.HotFix;
using CSharpScript.Launcher.Update;
using CSharpScript.Launcher.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.DiffPatch.Procedure
{
	// Token: 0x0200463B RID: 17979
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenHarmonyDiffPatchProcedure : MobileDiffPatchProcedure
	{
		// Token: 0x0602EF47 RID: 192327 RVA: 0x00B1FF90 File Offset: 0x00B1E190
		public OpenHarmonyDiffPatchProcedure(AppPathMisc pathMisc, HotFixManager viewMgr) : base(pathMisc, viewMgr)
		{
			Singleton<LauncherLog>.Instance.Info("Create OpenHarmony DiffPatchProcedure", default(ReadOnlySpan<ValueTuple<string, object>>));
			NearbyQuitGate.SetPresenter(delegate
			{
				OpenHarmonyDiffPatchProcedure.<<-ctor>b__8_0>d <<-ctor>b__8_0>d;
				<<-ctor>b__8_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<-ctor>b__8_0>d.<>4__this = this;
				<<-ctor>b__8_0>d.<>1__state = -1;
				<<-ctor>b__8_0>d.<>t__builder.Start<OpenHarmonyDiffPatchProcedure.<<-ctor>b__8_0>d>(ref <<-ctor>b__8_0>d);
				return <<-ctor>b__8_0>d.<>t__builder.Task;
			});
			this.NearbyNotify = UOHNearbyNotifyLib.GetNotify();
			this.TransferCb = delegate(int state)
			{
				if (state == 6)
				{
					this.OnNearbyReceiveFinish();
				}
			};
			if (this.NearbyNotify != null)
			{
				this.TransferEvent = this.NearbyNotify.OnTransferEvent;
				this.TransferEvent.Add(this.TransferCb);
				if (this.NearbyNotify.GetLastTransferState() == 6)
				{
					this.OnNearbyReceiveFinish();
				}
			}
		}

		// Token: 0x0602EF48 RID: 192328 RVA: 0x00B20034 File Offset: 0x00B1E234
		private void OnNearbyReceiveFinish()
		{
			if (this.bFinishHandled)
			{
				return;
			}
			this.bFinishHandled = true;
			Singleton<LauncherLog>.Instance.Info("NotifyNearbyReceiveComplete", default(ReadOnlySpan<ValueTuple<string, object>>));
			NearbyQuitGate.Trip();
			DiffUpdate activeUpdate = this.ActiveUpdate;
			if (activeUpdate == null)
			{
				return;
			}
			activeUpdate.Stop();
		}

		// Token: 0x0602EF49 RID: 192329 RVA: 0x00B20080 File Offset: 0x00B1E280
		[NullableContext(0)]
		public override UniTask<bool> UpdateResource(bool bUseBgDownload, [Nullable(1)] DiffUpdate update, bool bIsLauncher)
		{
			OpenHarmonyDiffPatchProcedure.<UpdateResource>d__10 <UpdateResource>d__;
			<UpdateResource>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<UpdateResource>d__.<>4__this = this;
			<UpdateResource>d__.bUseBgDownload = bUseBgDownload;
			<UpdateResource>d__.update = update;
			<UpdateResource>d__.bIsLauncher = bIsLauncher;
			<UpdateResource>d__.<>1__state = -1;
			<UpdateResource>d__.<>t__builder.Start<OpenHarmonyDiffPatchProcedure.<UpdateResource>d__10>(ref <UpdateResource>d__);
			return <UpdateResource>d__.<>t__builder.Task;
		}

		// Token: 0x0602EF4A RID: 192330 RVA: 0x00B200DC File Offset: 0x00B1E2DC
		protected override UniTask OnAfterResolveManifests(DiffUpdate update)
		{
			OpenHarmonyDiffPatchProcedure.<OnAfterResolveManifests>d__11 <OnAfterResolveManifests>d__;
			<OnAfterResolveManifests>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnAfterResolveManifests>d__.<>4__this = this;
			<OnAfterResolveManifests>d__.update = update;
			<OnAfterResolveManifests>d__.<>1__state = -1;
			<OnAfterResolveManifests>d__.<>t__builder.Start<OpenHarmonyDiffPatchProcedure.<OnAfterResolveManifests>d__11>(ref <OnAfterResolveManifests>d__);
			return <OnAfterResolveManifests>d__.<>t__builder.Task;
		}

		// Token: 0x0602EF4B RID: 192331 RVA: 0x00B20128 File Offset: 0x00B1E328
		public void CleanupPresetResources()
		{
			Singleton<LauncherLog>.Instance.Info("OpenHarmony CleanupPresetResources", default(ReadOnlySpan<ValueTuple<string, object>>));
			if (this.NearbyNotify != null)
			{
				FKuroNearbyTransferEvent transferEvent = this.TransferEvent;
				if (transferEvent != null)
				{
					transferEvent.Remove(this.TransferCb);
				}
				this.TransferEvent = null;
				this.NearbyNotify = null;
			}
			this.PresetConsumer.Cleanup();
		}

		// Token: 0x0602EF4C RID: 192332 RVA: 0x00B20188 File Offset: 0x00B1E388
		public override void PreComplete()
		{
			base.PreComplete();
			RemoteInfo instance = Singleton<RemoteInfo>.Instance;
			VersionItem versionItem;
			if (instance == null)
			{
				versionItem = null;
			}
			else
			{
				RemoteVersionConfig newConfig = instance.NewConfig;
				versionItem = ((newConfig != null) ? newConfig.ResVersions.GetValueOrDefault("resource") : null);
			}
			VersionItem versionItem2 = versionItem;
			if (versionItem2 != null)
			{
				Singleton<LauncherStorageLib>.Instance.SetDeviceSaved<string>(ELauncherStorageDeviceKey.OH_Preset_Version, versionItem2.Version);
			}
		}

		// Token: 0x0401AB84 RID: 109444
		private const int NearbyStateReceiveFinish = 6;

		// Token: 0x0401AB85 RID: 109445
		private readonly OHPresetResourceConsumer PresetConsumer = new OHPresetResourceConsumer();

		// Token: 0x0401AB86 RID: 109446
		private readonly Action<int> TransferCb;

		// Token: 0x0401AB87 RID: 109447
		private UOHNearbyNotify NearbyNotify;

		// Token: 0x0401AB88 RID: 109448
		private FKuroNearbyTransferEvent TransferEvent;

		// Token: 0x0401AB89 RID: 109449
		private DiffUpdate ActiveUpdate;

		// Token: 0x0401AB8A RID: 109450
		private bool bActiveIsLauncher;

		// Token: 0x0401AB8B RID: 109451
		private bool bFinishHandled;
	}
}
