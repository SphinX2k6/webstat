using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.Define.SimpleTabel;
using CSharpScript.Launcher.DiffPatch.Update;
using CSharpScript.Launcher.Platform;
using CSharpScript.Launcher.Ui.HotFix;
using CSharpScript.Launcher.Update.ResourceDiffUpdate.Config;
using CSharpScript.Launcher.Update.ResourceDiffUpdate.Module;
using CSharpScript.Launcher.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.Update.ResourceDiffUpdate
{
	// Token: 0x020044D9 RID: 17625
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ResourceDiffUpdaterManager : Singleton<ResourceDiffUpdaterManager>
	{
		// Token: 0x0602E7C2 RID: 190402 RVA: 0x00B01C48 File Offset: 0x00AFFE48
		[NullableContext(2)]
		public void UpdatePlayerInfoFromHttpData(SubPackageHttpData httpData = null, string uid = null)
		{
			if (httpData == null)
			{
				httpData = HotFixManager.LaunchSubPackageHttpData;
			}
			if (uid == null)
			{
				FLoginStruct loginData = HotFixManager.LoginData;
				uid = ((loginData != null) ? loginData.Uid : null);
			}
			this.Context.ActiveQuestIds = (((httpData != null) ? httpData.NeedConfirmQuestIdSet : null) ?? new List<int>());
			this.Context.CurrentBlockIds = (((httpData != null) ? httpData.CurrentBlockIdSet : null) ?? new List<int>());
			this.Context.Gender = ((httpData != null) ? httpData.Sex : -1);
			this.Context.Positions = (((httpData != null) ? httpData.Positions : null) ?? new List<ResourcePackagePositionData>());
			this.InitFinishedQuests(uid, (httpData != null) ? httpData.Mp4FinishQuestFlag : null);
		}

		// Token: 0x0602E7C3 RID: 190403 RVA: 0x00B01D00 File Offset: 0x00AFFF00
		[NullableContext(2)]
		public void InitFinishedQuests(string sdkUid, List<uint> mp4FinishQuestFlag)
		{
			this.Context.FinishedQuests.Clear();
			if (sdkUid == null)
			{
				Singleton<LauncherLog>.Instance.Warn("Optional package 用户SDK Uid未定义, 无法初始化已完成任务列表", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (mp4FinishQuestFlag != null)
			{
				HashSet<int> hashSet = ResourceUpdateUtils.ParseMp4FinishQuestFlagToSet(mp4FinishQuestFlag);
				Singleton<LauncherLog>.Instance.Info("Optional package 解析Mp4FinishQuestFlag: " + string.Join<uint>(",", mp4FinishQuestFlag) + ", QuestBitIds: " + string.Join<int>(",", hashSet), default(ReadOnlySpan<ValueTuple<string, object>>));
				foreach (int value in hashSet)
				{
					RefResourceQuestListRow byId = PackSelectionTables.RefResourceQuestListTableInstance.GetById(value);
					if (byId != null && byId.HasRefResource == 1)
					{
						this.Context.FinishedQuests.Add(byId.QuestId);
					}
				}
				Singleton<LauncherLog>.Instance.Info("Optional package 用户已完成任务列表(From Mp4FinishQuestFlag): " + string.Join<int>(",", this.Context.FinishedQuests), default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			Dictionary<string, HashSet<int>> global = Singleton<LauncherStorageLib>.Instance.GetGlobal<Dictionary<string, HashSet<int>>>(ELauncherStorageGlobalKey.UserFinishedQuests, null);
			if (global != null && global.ContainsKey(sdkUid))
			{
				foreach (int item in global[sdkUid])
				{
					this.Context.FinishedQuests.Add(item);
				}
				Singleton<LauncherLog>.Instance.Info("Optional package 用户已完成任务列表: " + string.Join<int>(",", this.Context.FinishedQuests), default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		}

		// Token: 0x0602E7C4 RID: 190404 RVA: 0x00B01EC4 File Offset: 0x00B000C4
		public void AddCurQuest(int questId)
		{
			if (!this.Context.ActiveQuestIds.Contains(questId))
			{
				this.Context.ActiveQuestIds.Add(questId);
			}
		}

		// Token: 0x0602E7C5 RID: 190405 RVA: 0x00B01EEC File Offset: 0x00B000EC
		public void UpdateFinishedQuests(List<int> quests)
		{
			Singleton<LauncherLog>.Instance.Info("Optional package 更新已完成任务列表: " + string.Join<int>(",", quests), default(ReadOnlySpan<ValueTuple<string, object>>));
			this.Context.FinishedQuests.Clear();
			foreach (int item in quests)
			{
				this.Context.FinishedQuests.Add(item);
			}
		}

		// Token: 0x0602E7C6 RID: 190406 RVA: 0x00B01F80 File Offset: 0x00B00180
		public void AddFinishedQuest(int questId)
		{
			this.Context.FinishedQuests.Add(questId);
		}

		// Token: 0x0602E7C7 RID: 190407 RVA: 0x00B01F94 File Offset: 0x00B00194
		public void UpdateCurrentBlockIds(List<int> blockIds)
		{
			Singleton<LauncherLog>.Instance.Info("Optional package 更新当前地块列表: " + string.Join<int>(",", blockIds), default(ReadOnlySpan<ValueTuple<string, object>>));
			this.Context.CurrentBlockIds = blockIds;
		}

		// Token: 0x0602E7C8 RID: 190408 RVA: 0x00B01FD8 File Offset: 0x00B001D8
		public void UpdatePositions(int instanceId, double x, double y, double z)
		{
			ResourcePackagePositionData resourcePackagePositionData = new ResourcePackagePositionData();
			resourcePackagePositionData.instanceId = instanceId;
			resourcePackagePositionData.x = x;
			resourcePackagePositionData.y = y;
			resourcePackagePositionData.z = z;
			this.Context.Positions = new List<ResourcePackagePositionData>
			{
				resourcePackagePositionData
			};
		}

		// Token: 0x0602E7C9 RID: 190409 RVA: 0x00B02020 File Offset: 0x00B00220
		public UniTask Init()
		{
			ResourceDiffUpdaterManager.<Init>d__20 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<ResourceDiffUpdaterManager.<Init>d__20>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0602E7CA RID: 190410 RVA: 0x00B02064 File Offset: 0x00B00264
		public UniTask CheckOptionalPacks(DiffUpdate diffUpdate, HotFixManager viewMgr)
		{
			ResourceDiffUpdaterManager.<CheckOptionalPacks>d__21 <CheckOptionalPacks>d__;
			<CheckOptionalPacks>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CheckOptionalPacks>d__.<>4__this = this;
			<CheckOptionalPacks>d__.diffUpdate = diffUpdate;
			<CheckOptionalPacks>d__.viewMgr = viewMgr;
			<CheckOptionalPacks>d__.<>1__state = -1;
			<CheckOptionalPacks>d__.<>t__builder.Start<ResourceDiffUpdaterManager.<CheckOptionalPacks>d__21>(ref <CheckOptionalPacks>d__);
			return <CheckOptionalPacks>d__.<>t__builder.Task;
		}

		// Token: 0x0602E7CB RID: 190411 RVA: 0x00B020B8 File Offset: 0x00B002B8
		private UniTask ApplyDecision(DiffUpdate diffUpdate, HotFixManager viewMgr)
		{
			ResourceDiffUpdaterManager.<ApplyDecision>d__22 <ApplyDecision>d__;
			<ApplyDecision>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ApplyDecision>d__.<>4__this = this;
			<ApplyDecision>d__.diffUpdate = diffUpdate;
			<ApplyDecision>d__.viewMgr = viewMgr;
			<ApplyDecision>d__.<>1__state = -1;
			<ApplyDecision>d__.<>t__builder.Start<ResourceDiffUpdaterManager.<ApplyDecision>d__22>(ref <ApplyDecision>d__);
			return <ApplyDecision>d__.<>t__builder.Task;
		}

		// Token: 0x0602E7CC RID: 190412 RVA: 0x00B0210C File Offset: 0x00B0030C
		public void UpdateDecision()
		{
			SelectionDecision selectionDecision = OptionalPackSelector.Select(new IResourceTypeModule[]
			{
				this.BlockModule,
				this.VideoModule,
				this.VoiceModule
			}, this.Context);
			this.CurrentDecision = selectionDecision;
			long num = selectionDecision.MinSize + this.BaseReqFileSize;
			long num2 = selectionDecision.MaxSize + this.BaseReqFileSize;
			this.SetResSize(EResUpdateType.Max, num2);
			this.SetResSize(EResUpdateType.Min, num);
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(47, 2);
			defaultInterpolatedStringHandler.AppendLiteral("Optional package 分包计算完成: 全量包大小: ");
			defaultInterpolatedStringHandler.AppendFormatted<double>((double)(num2 / 1048576L), "F2");
			defaultInterpolatedStringHandler.AppendLiteral(" MB, 精简包大小: ");
			defaultInterpolatedStringHandler.AppendFormatted<double>((double)(num / 1048576L), "F2");
			defaultInterpolatedStringHandler.AppendLiteral(" MB");
			instance.Info(defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x0602E7CD RID: 190413 RVA: 0x00B021EC File Offset: 0x00B003EC
		private EResUpdateType? ResolveAutoChoice(long minSize, long maxSize)
		{
			double num = (double)(maxSize / 1048576L);
			double num2 = (double)(minSize / 1048576L);
			int intFromCommonConfig = TableReaderUtil.GetIntFromCommonConfig("DownloadDifference1", 2048);
			int intFromCommonConfig2 = TableReaderUtil.GetIntFromCommonConfig("DownloadDifference2", 2048);
			if (num - num2 < (double)intFromCommonConfig2)
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(46, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Optional package 选择下载全量包, 全量包与精简包大小差值小于阈值: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(intFromCommonConfig2);
				defaultInterpolatedStringHandler.AppendLiteral(" MB");
				instance.Info(defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return new EResUpdateType?(EResUpdateType.Max);
			}
			if (num2 < (double)intFromCommonConfig)
			{
				LauncherLog instance2 = Singleton<LauncherLog>.Instance;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(40, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Optional package 选择下载精简包, 精简包大小小于阈值: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(intFromCommonConfig);
				defaultInterpolatedStringHandler.AppendLiteral(" MB");
				instance2.Info(defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return new EResUpdateType?(EResUpdateType.Min);
			}
			return null;
		}

		// Token: 0x0602E7CE RID: 190414 RVA: 0x00B022DC File Offset: 0x00B004DC
		public bool IsGrayBoxHit()
		{
			if (Singleton<Platform>.Instance.IsCloudGame())
			{
				Singleton<LauncherLog>.Instance.Info("云游戏不开启分包", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			if (!UKuroLauncherLibrary.NeedHotPatch())
			{
				Singleton<LauncherLog>.Instance.Info("Hot patch not needed, skipping optional package gray box check", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			bool flag = UKuroLauncherLibrary.IsEnableOptionalPackage();
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(40, 2);
			defaultInterpolatedStringHandler.AppendLiteral("PlatformType : ");
			defaultInterpolatedStringHandler.AppendFormatted<EPlatformType>(Singleton<Platform>.Instance.Type);
			defaultInterpolatedStringHandler.AppendLiteral(", EnableOptionalPackage: ");
			defaultInterpolatedStringHandler.AppendFormatted<bool>(flag);
			instance.Info(defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			if (!flag)
			{
				Singleton<LauncherLog>.Instance.Info("Optional package not enabled, skipping gray box check", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			if (UKuroStaticLibrary.IsModuleLoaded("KuroSDK") && Singleton<BaseConfigController>.Instance.GetPublicValue("UseSDK") == "1")
			{
				return Singleton<BaseConfigController>.Instance.CheckGrayBoxHitByDeviceId("OptionalResourceDownloadGrayBox", UKuroSDKManager.GetBasicInfo().DeviceId);
			}
			Singleton<LauncherLog>.Instance.Info("Optional package 灰度检查: SDK未启用, 灰度命中", default(ReadOnlySpan<ValueTuple<string, object>>));
			return true;
		}

		// Token: 0x0602E7CF RID: 190415 RVA: 0x00B02402 File Offset: 0x00B00602
		public void SetResSize(EResUpdateType resType, long size)
		{
			this.ResourceSizeMap[resType] = size;
		}

		// Token: 0x0602E7D0 RID: 190416 RVA: 0x00B02414 File Offset: 0x00B00614
		public long GetResSize(EResUpdateType resType)
		{
			long result;
			if (!this.ResourceSizeMap.TryGetValue(resType, out result))
			{
				return 0L;
			}
			return result;
		}

		// Token: 0x0602E7D1 RID: 190417 RVA: 0x00B02438 File Offset: 0x00B00638
		public double GetSpendTime()
		{
			return (double)((long)DateTime.UtcNow.Subtract(DateTime.UnixEpoch).TotalMilliseconds - this.StartTime) * 0.001;
		}

		// Token: 0x0602E7D2 RID: 190418 RVA: 0x00B02474 File Offset: 0x00B00674
		public void ReportInitialResDownloadState(bool successDownload, bool bStart = false)
		{
			if (successDownload && this.ResUpdateState != EResUpdateType.NotSet)
			{
				Singleton<LauncherStorageLib>.Instance.SetDeviceSaved<EResUpdateType>(ELauncherStorageDeviceKey.SelectedMaxOrMinPackType, this.ResUpdateState);
			}
			if (!ProcedureUtil.IsFirstTimeUpdateForPackage())
			{
				return;
			}
			int resUpdateState = (int)this.ResUpdateState;
			int downloadTime = (int)this.GetSpendTime();
			int downloadStatus = bStart ? 1 : (successDownload ? 0 : 2);
			FLoginStruct loginData = HotFixManager.LoginData;
			string uniqueId = ((loginData != null) ? loginData.Uid : null) ?? "";
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.TraceId);
			new InitialResDownloadStateLog(resUpdateState, downloadTime, downloadStatus, uniqueId, defaultInterpolatedStringHandler.ToStringAndClear(), this.UserChoose, (int)(HotFixManager.GetAllCanClearSpace() / 1048576L), (int)(this.GetResSize(this.ResUpdateState) / 1048576L), null).Report();
		}

		// Token: 0x0602E7D3 RID: 190419 RVA: 0x00B0252C File Offset: 0x00B0072C
		public void ReportResDownloadDeviceStorageState(long needSize, long freeSize, bool isRetry)
		{
			int resUpdateState = (int)this.ResUpdateState;
			bool ifStorageAlert = !isRetry;
			int requiredSpace = (int)(needSize / 1048576L);
			int remainingSpace = (int)(freeSize / 1048576L);
			FLoginStruct loginData = HotFixManager.LoginData;
			string uniqueId = ((loginData != null) ? loginData.Uid : null) ?? "";
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.TraceId);
			new ResDownloadDeviceStorageState(resUpdateState, ifStorageAlert, requiredSpace, remainingSpace, uniqueId, defaultInterpolatedStringHandler.ToStringAndClear(), this.UserChoose, null).Report();
		}

		// Token: 0x0401A699 RID: 108185
		private const string OPTIONAL_RESOURCE_DOWNLOAD_GRAY_BOX = "OptionalResourceDownloadGrayBox";

		// Token: 0x0401A69A RID: 108186
		private const long MB_SIZE = 1048576L;

		// Token: 0x0401A69B RID: 108187
		public readonly BlockResourceModule BlockModule = new BlockResourceModule();

		// Token: 0x0401A69C RID: 108188
		public readonly VideoResourceModule VideoModule = new VideoResourceModule();

		// Token: 0x0401A69D RID: 108189
		public readonly VoiceResourceModule VoiceModule = new VoiceResourceModule();

		// Token: 0x0401A69E RID: 108190
		private readonly Dictionary<EResUpdateType, long> ResourceSizeMap = new Dictionary<EResUpdateType, long>();

		// Token: 0x0401A69F RID: 108191
		[Nullable(2)]
		private SelectionDecision CurrentDecision;

		// Token: 0x0401A6A0 RID: 108192
		private long BaseReqFileSize;

		// Token: 0x0401A6A1 RID: 108193
		public EResUpdateType ResUpdateState;

		// Token: 0x0401A6A2 RID: 108194
		public int TraceId = -1;

		// Token: 0x0401A6A3 RID: 108195
		public long StartTime = -1L;

		// Token: 0x0401A6A4 RID: 108196
		private int UserChoose = 2;

		// Token: 0x0401A6A5 RID: 108197
		public readonly ResourceSelectionContext Context = new ResourceSelectionContext();
	}
}
