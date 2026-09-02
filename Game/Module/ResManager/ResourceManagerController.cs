using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.ResManager.Model;
using CSharpScript.Game.Render;
using CSharpScript.Launcher.DiffPatch.Data;
using CSharpScript.Launcher.DiffPatch.Update;
using CSharpScript.Launcher.Update.ResourceDiffUpdate;
using CSharpScript.Launcher.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.ResManager
{
	// Token: 0x02005289 RID: 21129
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[TickController(0)]
	public class ResourceManagerController : ControllerBase<ResourceManagerController>
	{
		// Token: 0x06036077 RID: 221303 RVA: 0x00D99266 File Offset: 0x00D97466
		protected override bool OnInit()
		{
			this.InitBlockDownloadState();
			this.AddEvents();
			return true;
		}

		// Token: 0x06036078 RID: 221304 RVA: 0x00D99275 File Offset: 0x00D97475
		protected override bool OnClear()
		{
			this.RemoveEvents();
			return true;
		}

		// Token: 0x06036079 RID: 221305 RVA: 0x00D9927E File Offset: 0x00D9747E
		private void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnQuestFinishListNotify, new Action(this.OnQuestFinishListNotify));
			Singleton<EventSystem>.Instance.Add<int, QuestState, EQuestStatusUpdateReason>(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChange));
		}

		// Token: 0x0603607A RID: 221306 RVA: 0x00D992B8 File Offset: 0x00D974B8
		private void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnQuestFinishListNotify, new Action(this.OnQuestFinishListNotify));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChange));
		}

		// Token: 0x0603607B RID: 221307 RVA: 0x00D992F4 File Offset: 0x00D974F4
		[NullableContext(0)]
		[return: TupleElementNames(new string[]
		{
			"downloaded",
			"needReOpenMap"
		})]
		public ValueTuple<bool, bool> IsBlockResourceDownloaded(int mapId, [Nullable(1)] global::Vector position)
		{
			if (!Singleton<ResourceDiffUpdaterManager>.Instance.IsGrayBoxHit())
			{
				return new ValueTuple<bool, bool>(true, false);
			}
			int mapBlockFromPosition = this.GetMapBlockFromPosition(mapId, position);
			if (mapBlockFromPosition == -1)
			{
				return new ValueTuple<bool, bool>(true, false);
			}
			ResourceManagerModel instance = ModelBase<ResourceManagerModel>.Instance;
			return new ValueTuple<bool, bool>(instance.GetBlockDownloadState(mapBlockFromPosition), instance.BlockNeedReOpenMap.Contains(mapBlockFromPosition));
		}

		// Token: 0x0603607C RID: 221308 RVA: 0x00D99348 File Offset: 0x00D97548
		public List<ResPackageInfo> GetMapBlockResPackageInfos(IReadOnlyList<int> blockIds)
		{
			ResourceManagerModel instance = ModelBase<ResourceManagerModel>.Instance;
			List<ResPackageInfo> list = new List<ResPackageInfo>();
			Dictionary<string, ResPackageInfo> optionalDownLoadInfo = ResPackageInfo.OptionalDownLoadInfo;
			HashSet<string> hashSet = new HashSet<string>();
			foreach (int num in blockIds)
			{
				string valueOrDefault = instance.MapBlockIdToPackName.GetValueOrDefault(num);
				if (valueOrDefault != null)
				{
					hashSet.Add(valueOrDefault);
				}
				else
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module = ELogModule.QuestResource;
					ELogAuthor author = ELogAuthor.HWK;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
					defaultInterpolatedStringHandler.AppendLiteral("地块");
					defaultInterpolatedStringHandler.AppendFormatted<int>(num);
					defaultInterpolatedStringHandler.AppendLiteral("没有配置资源包");
					instance2.Warn(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				}
			}
			foreach (string text in hashSet)
			{
				ResPackageInfo valueOrDefault2 = optionalDownLoadInfo.GetValueOrDefault(text);
				if (valueOrDefault2 != null)
				{
					list.Add(valueOrDefault2);
				}
				else
				{
					Singleton<Log>.Instance.Warn(ELogModule.QuestResource, ELogAuthor.HWK, "资源包" + text + "不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
			}
			return list;
		}

		// Token: 0x0603607D RID: 221309 RVA: 0x00D9948C File Offset: 0x00D9768C
		public UniTask InitSubPackageDownloader()
		{
			ResourceManagerController.<InitSubPackageDownloader>d__8 <InitSubPackageDownloader>d__;
			<InitSubPackageDownloader>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitSubPackageDownloader>d__.<>4__this = this;
			<InitSubPackageDownloader>d__.<>1__state = -1;
			<InitSubPackageDownloader>d__.<>t__builder.Start<ResourceManagerController.<InitSubPackageDownloader>d__8>(ref <InitSubPackageDownloader>d__);
			return <InitSubPackageDownloader>d__.<>t__builder.Task;
		}

		// Token: 0x0603607E RID: 221310 RVA: 0x00D994CF File Offset: 0x00D976CF
		protected override void OnTick(float deltaTime)
		{
			this.TickPushCurBlock(deltaTime);
		}

		// Token: 0x0603607F RID: 221311 RVA: 0x00D994D8 File Offset: 0x00D976D8
		private unsafe void TickPushCurBlock(float deltaTime)
		{
			this.PushCurBlockTimer += deltaTime;
			if (this.PushCurBlockTimer >= 3000f)
			{
				this.PushCurBlockTimer = 0f;
				EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
				CharacterActorComponent characterActorComponent;
				if (getCurrentEntity == null)
				{
					characterActorComponent = null;
				}
				else
				{
					WorldEntity entity = getCurrentEntity.Entity;
					characterActorComponent = ((entity != null) ? entity.GetComponent<CharacterActorComponent>() : null);
				}
				CharacterActorComponent characterActorComponent2 = characterActorComponent;
				if (characterActorComponent2 != null)
				{
					int mapBlockFromPosition = this.GetMapBlockFromPosition(ModelBase<GameModeModel>.Instance.MapId, characterActorComponent2.ActorLocationProxy);
					if (mapBlockFromPosition >= 0 && mapBlockFromPosition != this.CurBlockId)
					{
						this.CurBlockId = mapBlockFromPosition;
						this.PushCurBlock(new <>z__ReadOnlySingleElementList<int>(mapBlockFromPosition), "地块改变定时推送");
						ResourceDiffUpdaterManager instance = Singleton<ResourceDiffUpdaterManager>.Instance;
						int num = 1;
						List<int> list = new List<int>(num);
						CollectionsMarshal.SetCount<int>(list, num);
						Span<int> span = CollectionsMarshal.AsSpan<int>(list);
						int index = 0;
						*span[index] = mapBlockFromPosition;
						instance.UpdateCurrentBlockIds(list);
					}
					global::Vector actorLocationProxy = characterActorComponent2.ActorLocationProxy;
					Singleton<ResourceDiffUpdaterManager>.Instance.UpdatePositions(ModelBase<GameModeModel>.Instance.MapId, actorLocationProxy.X, actorLocationProxy.Y, actorLocationProxy.Z);
				}
			}
		}

		// Token: 0x06036080 RID: 221312 RVA: 0x00D995D0 File Offset: 0x00D977D0
		public void PushCurBlock(IReadOnlyList<int> blockIds, [Nullable(2)] string reason)
		{
			Singleton<Log>.Instance.Info(ELogModule.QuestResource, ELogAuthor.HWK, "推送当前地块:" + string.Join<int>(",", blockIds) + " 原因:" + reason, default(ReadOnlySpan<ValueTuple<string, object>>));
			SceneBlockSplitPlayerNeedBlockPush sceneBlockSplitPlayerNeedBlockPush = SceneBlockSplitPlayerNeedBlockPush.Create();
			sceneBlockSplitPlayerNeedBlockPush.PlayerNeedBlockId.AddRange(blockIds);
			Singleton<Net>.Instance.Send(EPushMessageId.SceneBlockSplitPlayerNeedBlockPush, sceneBlockSplitPlayerNeedBlockPush);
		}

		// Token: 0x06036081 RID: 221313 RVA: 0x00D99631 File Offset: 0x00D97831
		public int GetMapBlockFromPosition(int mapId, global::Vector position)
		{
			return Singleton<ResourceDiffUpdaterManager>.Instance.BlockModule.GetMapBlockFromPosition(mapId, position.X, position.Y);
		}

		// Token: 0x06036082 RID: 221314 RVA: 0x00D99650 File Offset: 0x00D97850
		[NullableContext(0)]
		public ValueTuple<bool, long, long> GetResourceDownloadStatus([Nullable(1)] string packName)
		{
			ResPackageInfo valueOrDefault = ResPackageInfo.OptionalDownLoadInfo.GetValueOrDefault(packName);
			if (valueOrDefault != null)
			{
				ValueTuple<List<RequireFileInfo>, long, long, long, long, long, long, ValueTuple<long, int>> valueTuple = valueOrDefault.AnalyzeRequireFiles(false);
				long item = valueTuple.Item7;
				long item2 = valueTuple.Rest.Item1;
				return new ValueTuple<bool, long, long>(valueOrDefault.IsCompleteUpdate(), item2, item);
			}
			Singleton<Log>.Instance.Error(ELogModule.QuestResource, ELogAuthor.HWK, "资源包" + packName + "不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
			return new ValueTuple<bool, long, long>(true, 0L, 0L);
		}

		// Token: 0x06036083 RID: 221315 RVA: 0x00D996C4 File Offset: 0x00D978C4
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public ValueTuple<long, HashSet<int>> GetUnneededResourceSize(List<int> questIds)
		{
			HashSet<int> unusedVideos = Singleton<ResourceDiffUpdaterManager>.Instance.VideoModule.GetUnusedVideos(new HashSet<int>(questIds));
			return new ValueTuple<long, HashSet<int>>(Singleton<ResourceDiffUpdaterManager>.Instance.VideoModule.GetLocalSizeByVideoIds(unusedVideos), unusedVideos);
		}

		// Token: 0x06036084 RID: 221316 RVA: 0x00D99700 File Offset: 0x00D97900
		public void DeleteUnneededResource(List<int> curQuestIds)
		{
			ValueTuple<long, HashSet<int>> unneededResourceSize = this.GetUnneededResourceSize(curQuestIds);
			long item = unneededResourceSize.Item1;
			HashSet<int> item2 = unneededResourceSize.Item2;
			if (item > 0L)
			{
				Singleton<ResourceDiffUpdaterManager>.Instance.VideoModule.DeleteByVideoIds(item2);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.QuestResource;
				ELogAuthor author = ELogAuthor.HWK;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 1);
				defaultInterpolatedStringHandler.AppendLiteral("删除不需要的视频资源,释放空间:");
				defaultInterpolatedStringHandler.AppendFormatted<long>(item);
				instance.Info(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		}

		// Token: 0x06036085 RID: 221317 RVA: 0x00D99774 File Offset: 0x00D97974
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public ValueTuple<int[], int[]> GetQuestRefRes(int questId)
		{
			int[] valueOrDefault = ModelBase<ResourceManagerModel>.Instance.QuestsRefBlocks.GetValueOrDefault(questId);
			int[] questRefCgIds = ModelBase<QuestResourceModel>.Instance.GetQuestRefCgIds(questId);
			return new ValueTuple<int[], int[]>(valueOrDefault ?? Array.Empty<int>(), questRefCgIds);
		}

		// Token: 0x06036086 RID: 221318 RVA: 0x00D997AC File Offset: 0x00D979AC
		[NullableContext(0)]
		public ValueTuple<bool, long, long> GetMp4ResourceDownloadStatus(int videoId)
		{
			List<string> videoResPakByVideoIds = Singleton<VideoResUpdate>.Instance.GetVideoResPakByVideoIds(new List<int>
			{
				videoId
			});
			if (videoResPakByVideoIds.Count <= 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.QuestResource;
				ELogAuthor author = ELogAuthor.HWK;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 1);
				defaultInterpolatedStringHandler.AppendLiteral("视频资源");
				defaultInterpolatedStringHandler.AppendFormatted<int>(videoId);
				defaultInterpolatedStringHandler.AppendLiteral("没有配置资源包");
				instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return new ValueTuple<bool, long, long>(true, 0L, 0L);
			}
			ValueTuple<List<RequireFileInfo>, long, long, List<LocalFileInfo>> valueTuple = Singleton<VideoResUpdate>.Instance.AnalyzeRequireFilesByNames(videoResPakByVideoIds);
			long item = valueTuple.Item2;
			long item2 = valueTuple.Item3;
			return new ValueTuple<bool, long, long>(item == item2, item, item2);
		}

		// Token: 0x06036087 RID: 221319 RVA: 0x00D99850 File Offset: 0x00D97A50
		private void OnQuestFinishListNotify()
		{
			this.SaveFinishedVideoList();
			List<int> finishQuestList = ModelBase<QuestNewModel>.Instance.GetFinishQuestList();
			Singleton<ResourceDiffUpdaterManager>.Instance.UpdateFinishedQuests(finishQuestList);
			if (Singleton<ResourceDiffUpdaterManager>.Instance.IsGrayBoxHit())
			{
				ModelBase<SubPackageDownLoadModel>.Instance.UpdaterDownLoadSize();
				this.UpdateToServerResState();
				this.UpdateServerQuestState();
			}
		}

		// Token: 0x06036088 RID: 221320 RVA: 0x00D9989B File Offset: 0x00D97A9B
		private void OnQuestStateChange(int questId, QuestState state, EQuestStatusUpdateReason arg3)
		{
			if (state == QuestState.Finish)
			{
				this.SaveFinishedVideoList();
				Singleton<ResourceDiffUpdaterManager>.Instance.AddFinishedQuest(questId);
				return;
			}
			if (state == QuestState.Progress)
			{
				Singleton<ResourceDiffUpdaterManager>.Instance.AddCurQuest(questId);
			}
		}

		// Token: 0x06036089 RID: 221321 RVA: 0x00D998C4 File Offset: 0x00D97AC4
		private unsafe void SaveFinishedVideoList()
		{
			if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
			{
				string uid = ControllerBase<KuroSdkController>.Instance.GetCurrentLoginInfo().Uid;
				List<int> finishQuestList = ModelBase<QuestNewModel>.Instance.GetFinishQuestList();
				Dictionary<string, HashSet<int>> dictionary = Singleton<LauncherStorageLib>.Instance.GetGlobal<Dictionary<string, HashSet<int>>>(ELauncherStorageGlobalKey.UserFinishedQuests, null) ?? new Dictionary<string, HashSet<int>>();
				dictionary[uid] = new HashSet<int>(finishQuestList);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SubPackageDownLoad;
				ELogAuthor author = ELogAuthor.HWK;
				string message = "保存已完成任务列表到本地存储";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("sdkId", uid);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("finishedQuests", finishQuestList);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				Singleton<LauncherStorageLib>.Instance.SetGlobal<Dictionary<string, HashSet<int>>>(ELauncherStorageGlobalKey.UserFinishedQuests, dictionary);
			}
		}

		// Token: 0x0603608A RID: 221322 RVA: 0x00D99984 File Offset: 0x00D97B84
		protected void UpdateToServerResState()
		{
			QuestResourceModel instance = ModelBase<QuestResourceModel>.Instance;
			instance.RefreshCachePrepareResourceSize();
			instance.CalcPrepareResource();
			long videoResSize = Singleton<VideoResUpdate>.Instance.GetVideoResSize(EVideoResSizeType.MalePrepare);
			long videoResSavedSize = Singleton<VideoResUpdate>.Instance.GetVideoResSavedSize(EVideoResSizeType.MalePrepare);
			long videoResSize2 = Singleton<VideoResUpdate>.Instance.GetVideoResSize(EVideoResSizeType.FemalePrepare);
			long videoResSavedSize2 = Singleton<VideoResUpdate>.Instance.GetVideoResSavedSize(EVideoResSizeType.FemalePrepare);
			bool flag = Singleton<ResourceDiffUpdaterManager>.Instance.BlockModule.IsAllBlockResourceDownloaded();
			EVideoResSizeType newResState = EVideoResSizeType.StartMinNeed;
			if (flag)
			{
				if (Singleton<VideoResUpdate>.Instance.VideoDownloadState == EVideoResSizeType.StartMaxNeed)
				{
					newResState = EVideoResSizeType.StartMaxNeed;
				}
				else if (videoResSize == videoResSavedSize)
				{
					newResState = EVideoResSizeType.MalePrepare;
				}
				else if (videoResSize2 == videoResSavedSize2)
				{
					newResState = EVideoResSizeType.FemalePrepare;
				}
			}
			Singleton<LauncherStorageLib>.Instance.SetDeviceSaved<EVideoResSizeType>(ELauncherStorageDeviceKey.UserSelectedVideoUpdate, newResState);
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.QuestResource;
			ELogAuthor author = ELogAuthor.ZWY;
			string message = "登录后上报服务器本地资源状态";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ResState", newResState);
			instance2.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (newResState != EVideoResSizeType.StartMinNeed)
			{
				SetQuestResourceStateRequest setQuestResourceStateRequest = SetQuestResourceStateRequest.Create();
				setQuestResourceStateRequest.QuestResourceState = (int)newResState;
				Singleton<Net>.Instance.Call<SetQuestResourceStateResponse>(ERequestMessageId.SetQuestResourceStateRequest, setQuestResourceStateRequest, delegate(SetQuestResourceStateResponse response, Net.CallbackStatus _)
				{
					if (response != null)
					{
						Log instance4 = Singleton<Log>.Instance;
						ELogModule module3 = ELogModule.QuestResource;
						ELogAuthor author3 = ELogAuthor.ZWY;
						string message3 = "计算出新状态后通知服务器任务资源状态改变";
						ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("新状态", newResState);
						instance4.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
					}
				}, 0);
			}
			ESceneBlockSwithState esceneBlockSwithState = ESceneBlockSwithState.BstateAll;
			if (Singleton<ResourceDiffUpdaterManager>.Instance.IsGrayBoxHit())
			{
				esceneBlockSwithState = (flag ? ESceneBlockSwithState.BstateComplete : ESceneBlockSwithState.BstateSimple);
			}
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.QuestResource;
			ELogAuthor author2 = ELogAuthor.ZWY;
			string message2 = "登录后上报服务器地块资源状态";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("BlockState", esceneBlockSwithState);
			instance3.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			SceneBlockSplitSwitchStatePush sceneBlockSplitSwitchStatePush = SceneBlockSplitSwitchStatePush.Create();
			sceneBlockSplitSwitchStatePush.SwitchState = esceneBlockSwithState;
			Singleton<Net>.Instance.Send(EPushMessageId.SceneBlockSplitSwitchStatePush, sceneBlockSplitSwitchStatePush);
		}

		// Token: 0x0603608B RID: 221323 RVA: 0x00D99B0C File Offset: 0x00D97D0C
		public void UpdateBlockDownloadState(int blockId, bool downloaded)
		{
			ResourceManagerModel instance = ModelBase<ResourceManagerModel>.Instance;
			if (instance.GetBlockDownloadState(blockId) == downloaded)
			{
				return;
			}
			MapBlockInfo? config = ConfigMapBlockInfoById.GetConfig(blockId, true);
			if (config != null)
			{
				instance.SetBlockDownloadState(blockId, downloaded);
				if (config.Value.MapId == ModelBase<GameModeModel>.Instance.MapId)
				{
					instance.BlockNeedReOpenMap.Add(blockId);
					return;
				}
				ControllerBase<RenderModuleController>.Instance.SetWorldPartitionDataLayerState(config.Value.BlockDatalayer, !downloaded, false);
			}
		}

		// Token: 0x0603608C RID: 221324 RVA: 0x00D99B8A File Offset: 0x00D97D8A
		public bool IsNeedReOpenMap(int blockId)
		{
			return ModelBase<ResourceManagerModel>.Instance.BlockNeedReOpenMap.Contains(blockId);
		}

		// Token: 0x0603608D RID: 221325 RVA: 0x00D99B9C File Offset: 0x00D97D9C
		public void UpdateServerQuestState()
		{
			if (!Singleton<ResourceDiffUpdaterManager>.Instance.IsGrayBoxHit())
			{
				return;
			}
			QuestResourceModel instance = ModelBase<QuestResourceModel>.Instance;
			HashSet<int> hashSet = new HashSet<int>();
			EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
			HashSet<int> hashSet2 = new HashSet<int>();
			if (playerGender == EPlayerGender.Female)
			{
				using (Dictionary<int, List<string>>.Enumerator enumerator = instance.FemaleQuestIdToPack.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						KeyValuePair<int, List<string>> keyValuePair = enumerator.Current;
						int key = keyValuePair.Key;
						hashSet2.Add(key);
						if (!ModelBase<QuestNewModel>.Instance.CheckQuestFinished(key) && this.IsQuestResourceDownloaded(key, playerGender))
						{
							hashSet.Add(key);
						}
					}
					goto IL_FB;
				}
			}
			if (playerGender == EPlayerGender.Male)
			{
				foreach (KeyValuePair<int, List<string>> keyValuePair2 in instance.MaleQuestIdToPack)
				{
					int key2 = keyValuePair2.Key;
					hashSet2.Add(key2);
					if (!ModelBase<QuestNewModel>.Instance.CheckQuestFinished(key2) && this.IsQuestResourceDownloaded(key2, playerGender))
					{
						hashSet.Add(key2);
					}
				}
			}
			IL_FB:
			foreach (KeyValuePair<int, int[]> keyValuePair3 in ModelBase<ResourceManagerModel>.Instance.QuestsRefBlocks)
			{
				int key3 = keyValuePair3.Key;
				if (!hashSet2.Contains(key3) && !ModelBase<QuestNewModel>.Instance.CheckQuestFinished(key3) && this.IsQuestResourceDownloaded(key3, playerGender))
				{
					hashSet.Add(key3);
				}
			}
			FinishDownloadQuestResourceRequest finishDownloadQuestResourceRequest = FinishDownloadQuestResourceRequest.Create();
			finishDownloadQuestResourceRequest.QuestIds.AddRange(hashSet);
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.QuestResource;
			ELogAuthor author = ELogAuthor.ZWY;
			string message = "通知服务器登录任务下载完成";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("LoginQuests", hashSet);
			instance2.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Singleton<Net>.Instance.Call<FinishDownloadQuestResourceResponse>(ERequestMessageId.FinishDownloadQuestResourceRequest, finishDownloadQuestResourceRequest, delegate(FinishDownloadQuestResourceResponse response, Net.CallbackStatus _)
			{
				if (response != null && response.ErrorId != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorId, EResponseMessageId.FinishDownloadQuestResourceResponse, null, true, true);
				}
			}, 0);
		}

		// Token: 0x0603608E RID: 221326 RVA: 0x00D99DA4 File Offset: 0x00D97FA4
		public List<int> GetDownloadedQuestListBeforeLogin(EPlayerGender gender = EPlayerGender.None)
		{
			List<int> list = new List<int>();
			QuestResourceModel instance = ModelBase<QuestResourceModel>.Instance;
			ResourceManagerModel instance2 = ModelBase<ResourceManagerModel>.Instance;
			HashSet<int> hashSet = new HashSet<int>();
			IEnumerable<QuestResourceWhite> enumerable = ConfigQuestResourceWhiteAll.GetConfigList(true) ?? Array.Empty<QuestResourceWhite>();
			HashSet<int> hashSet2 = new HashSet<int>();
			foreach (QuestResourceWhite questResourceWhite in enumerable)
			{
				hashSet2.Add(questResourceWhite.QuestId);
			}
			foreach (KeyValuePair<int, HashSet<int>> keyValuePair in instance.QuestIdToCgIds)
			{
				if (!hashSet2.Contains(keyValuePair.Key))
				{
					hashSet.Add(keyValuePair.Key);
				}
			}
			foreach (KeyValuePair<int, int[]> keyValuePair2 in instance2.QuestsRefBlocks)
			{
				if (!hashSet2.Contains(keyValuePair2.Key))
				{
					hashSet.Add(keyValuePair2.Key);
				}
			}
			foreach (int num in hashSet)
			{
				if (ModelBase<QuestNewModel>.Instance.GetQuestConfig(num) != null && this.IsQuestResourceDownloaded(num, gender))
				{
					list.Add(num);
				}
			}
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.QuestResource;
			ELogAuthor author = ELogAuthor.HWK;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 2);
			defaultInterpolatedStringHandler.AppendLiteral("登录前已完成资源下载的任务列表:");
			defaultInterpolatedStringHandler.AppendFormatted(string.Join<int>(",", list));
			defaultInterpolatedStringHandler.AppendLiteral(", 性别:");
			defaultInterpolatedStringHandler.AppendFormatted<EPlayerGender>(gender);
			instance3.Info(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return list;
		}

		// Token: 0x0603608F RID: 221327 RVA: 0x00D99F94 File Offset: 0x00D98194
		public bool IsQuestResourceDownloaded(int questId, EPlayerGender gender)
		{
			ResourceManagerModel instance = ModelBase<ResourceManagerModel>.Instance;
			int[] valueOrDefault = instance.QuestsRefBlocks.GetValueOrDefault(questId);
			if (valueOrDefault != null)
			{
				foreach (int num in valueOrDefault)
				{
					string valueOrDefault2 = instance.MapBlockIdToPackName.GetValueOrDefault(num);
					if (valueOrDefault2 != null)
					{
						ResPackageInfo valueOrDefault3 = ResPackageInfo.OptionalDownLoadInfo.GetValueOrDefault(valueOrDefault2);
						if (valueOrDefault3 != null && !valueOrDefault3.IsCompleteDownload())
						{
							Log instance2 = Singleton<Log>.Instance;
							ELogModule module = ELogModule.QuestResource;
							ELogAuthor author = ELogAuthor.HWK;
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 2);
							defaultInterpolatedStringHandler.AppendLiteral("任务");
							defaultInterpolatedStringHandler.AppendFormatted<int>(questId);
							defaultInterpolatedStringHandler.AppendLiteral("依赖地块");
							defaultInterpolatedStringHandler.AppendFormatted<int>(num);
							defaultInterpolatedStringHandler.AppendLiteral("资源未下载完成");
							instance2.Info(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
							return false;
						}
					}
				}
			}
			List<string> questRefPakNames = ModelBase<QuestResourceModel>.Instance.GetQuestRefPakNames(questId, gender);
			ValueTuple<List<RequireFileInfo>, long, long, List<LocalFileInfo>> valueTuple = Singleton<VideoResUpdate>.Instance.AnalyzeRequireFilesByNames(questRefPakNames);
			long item = valueTuple.Item2;
			long item2 = valueTuple.Item3;
			bool flag = item == item2;
			if (!flag)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.QuestResource;
				ELogAuthor author2 = ELogAuthor.HWK;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 1);
				defaultInterpolatedStringHandler.AppendLiteral("任务");
				defaultInterpolatedStringHandler.AppendFormatted<int>(questId);
				defaultInterpolatedStringHandler.AppendLiteral("依赖视频资源未下载完成");
				instance3.Info(module2, author2, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return flag;
		}

		// Token: 0x06036090 RID: 221328 RVA: 0x00D9A0E4 File Offset: 0x00D982E4
		public void InitBlockDownloadState()
		{
			ResourceManagerModel instance = ModelBase<ResourceManagerModel>.Instance;
			foreach (KeyValuePair<int, string> keyValuePair in instance.MapBlockIdToPackName)
			{
				int key = keyValuePair.Key;
				string value = keyValuePair.Value;
				ResPackageInfo valueOrDefault = ResPackageInfo.OptionalDownLoadInfo.GetValueOrDefault(value);
				if (valueOrDefault != null)
				{
					bool flag = valueOrDefault.IsCompleteDownload();
					instance.SetBlockDownloadState(key, flag);
					MapBlockInfo? config = ConfigMapBlockInfoById.GetConfig(key, true);
					if (config != null)
					{
						ControllerBase<RenderModuleController>.Instance.SetWorldPartitionDataLayerState(config.Value.BlockDatalayer, !flag, false);
					}
				}
				else
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module = ELogModule.QuestResource;
					ELogAuthor author = ELogAuthor.HWK;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(32, 2);
					defaultInterpolatedStringHandler.AppendLiteral("地块");
					defaultInterpolatedStringHandler.AppendFormatted<int>(key);
					defaultInterpolatedStringHandler.AppendLiteral(",packName:");
					defaultInterpolatedStringHandler.AppendFormatted(value);
					defaultInterpolatedStringHandler.AppendLiteral("对应的ResPackageInfo不存在");
					instance2.Warn(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				}
			}
		}

		// Token: 0x06036091 RID: 221329 RVA: 0x00D9A208 File Offset: 0x00D98408
		public UniTask TestDownload()
		{
			ResourceManagerController.<TestDownload>d__30 <TestDownload>d__;
			<TestDownload>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TestDownload>d__.<>4__this = this;
			<TestDownload>d__.<>1__state = -1;
			<TestDownload>d__.<>t__builder.Start<ResourceManagerController.<TestDownload>d__30>(ref <TestDownload>d__);
			return <TestDownload>d__.<>t__builder.Task;
		}

		// Token: 0x06036092 RID: 221330 RVA: 0x00D9A24C File Offset: 0x00D9844C
		public void ChangeHttpTickFrequency()
		{
			Singleton<Log>.Instance.Info(ELogModule.SubPackageDownLoad, ELogAuthor.HWK, "ChangeHttpTickFrequency: set http tick to max", default(ReadOnlySpan<ValueTuple<string, object>>));
			Http.SetHttpThreadActiveMinimumSleepTimeInSeconds(0f);
			Http.SetHttpThreadIdleMinimumSleepTimeInSeconds(0f);
		}

		// Token: 0x06036093 RID: 221331 RVA: 0x00D9A28C File Offset: 0x00D9848C
		public void RestoreHttpTickFrequency()
		{
			Singleton<Log>.Instance.Info(ELogModule.SubPackageDownLoad, ELogAuthor.HWK, "RestoreHttpTickFrequency: restore http tick to game default", default(ReadOnlySpan<ValueTuple<string, object>>));
			Http.SetHttpThreadActiveMinimumSleepTimeInSeconds(0.005f);
			Http.SetHttpThreadIdleMinimumSleepTimeInSeconds(0.033f);
		}

		// Token: 0x0401F0E5 RID: 127205
		private const int CUE_BLOCK_PUSH_TIME = 3000;

		// Token: 0x0401F0E6 RID: 127206
		[Nullable(2)]
		public CustomPromise LoginPrepareResCheckPromise;

		// Token: 0x0401F0E7 RID: 127207
		private float PushCurBlockTimer;

		// Token: 0x0401F0E8 RID: 127208
		private int CurBlockId = -1;
	}
}
