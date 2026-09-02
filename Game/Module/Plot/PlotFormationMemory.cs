using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.LevelLoading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x0200536A RID: 21354
	[NullableContext(1)]
	[Nullable(0)]
	public class PlotFormationMemory : IStaticVariableResetter
	{
		// Token: 0x0603672D RID: 223021 RVA: 0x00DBBC3B File Offset: 0x00DB9E3B
		static PlotFormationMemory()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(PlotFormationMemory.CreateStaticDefaultValue), new Action(PlotFormationMemory.ResetStaticDefaultValue));
		}

		// Token: 0x0603672E RID: 223022 RVA: 0x00DBBC5C File Offset: 0x00DB9E5C
		public unsafe void Enter(PlotInfo plotInfo)
		{
			if (!PlotFormationMemory.ForceEnableForGm)
			{
				IStateProgramSpecialProcessChangeTeamOptimization programSpecialProcess = plotInfo.ProgramSpecialProcess;
				if (programSpecialProcess == null || programSpecialProcess.Type > ELogicProgramSpecialProcess.ChangeTeamOptimization)
				{
					return;
				}
			}
			if (!PlotFormationMemory.ForceEnableForGm && !PlotFormationMemory.IgnoreLowMemoryForGm && !Singleton<Info>.Instance.IsLowMemoryDevice)
			{
				return;
			}
			if (ModelBase<PlotModel>.Instance.IsFormationMemoryOptimized)
			{
				return;
			}
			if (ModelBase<GameModeModel>.Instance.IsMulti)
			{
				Singleton<global::Log>.Instance.Info(ELogModule.Plot, ELogAuthor.YZH, "[编队内存优化] 跳过：联机下不启用", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (ModelBase<AutoRunModel>.Instance.IsInLogicTreeGmMode())
			{
				return;
			}
			if (plotInfo.IsBackground || plotInfo.IsAsync)
			{
				return;
			}
			bool flag = this.NeedBlackScreen(plotInfo);
			ModelBase<PlotModel>.Instance.FormationMemoryNeedMask = flag;
			this.TryOpenMask(flag, "PlotFormationMemory.Enter");
			SceneTeamItem sceneTeamItem = ControllerBase<PlotController>.Instance.FindMainRoleTeamItemForFormationMemory();
			if (sceneTeamItem == null)
			{
				sceneTeamItem = ModelBase<SceneTeamModel>.Instance.GetCurrentTeamItem;
				if (sceneTeamItem != null)
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.Plot;
					ELogAuthor author = ELogAuthor.YZH;
					string message = "[编队内存优化] 编队中无主角，降级保留当前控制角色";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("keepCreatureDataId", sceneTeamItem.GetCreatureDataId());
					instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
			}
			if (sceneTeamItem == null)
			{
				Singleton<global::Log>.Instance.Warn(ELogModule.Plot, ELogAuthor.YZH, "[编队内存优化] 无主角且无当前控制角色，放弃优化", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.TryCloseMask("PlotFormationMemory.Enter");
				return;
			}
			if (sceneTeamItem.EntityHandle != null)
			{
				this.ExecuteShrink(sceneTeamItem);
				this.TryCloseMask("PlotFormationMemory.Enter");
				return;
			}
			long waitCreatureDataId = sceneTeamItem.GetCreatureDataId();
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.Plot;
			ELogAuthor author2 = ELogAuthor.YZH;
			string message2 = "[编队内存优化] 保留角色实体未就绪，等待加载后收缩";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("keepCreatureDataId", waitCreatureDataId);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			this.EnterWaitTask = WaitEntityTask.Create("PlotFormationMemory.Enter", new List<long>
			{
				waitCreatureDataId
			}, delegate(bool? result)
			{
				this.EnterWaitTask = null;
				if (!ModelBase<PlotModel>.Instance.IsInPlot)
				{
					Singleton<global::Log>.Instance.Warn(ELogModule.Plot, ELogAuthor.YZH, "[编队内存优化] 等待保留角色实体期间剧情已结束，放弃收缩", default(ReadOnlySpan<ValueTuple<string, object>>));
					this.TryCloseMask("PlotFormationMemory.Enter");
					return;
				}
				SceneTeamItem teamItem = ModelBase<SceneTeamModel>.Instance.GetTeamItem(waitCreatureDataId, new GetTeamItemOptions
				{
					ParamType = ETeamParamType.CreatureDataId
				});
				if (!result.GetValueOrDefault() || ((teamItem != null) ? teamItem.EntityHandle : null) == null)
				{
					global::Log instance3 = Singleton<global::Log>.Instance;
					ELogModule module3 = ELogModule.Plot;
					ELogAuthor author3 = ELogAuthor.YZH;
					string message3 = "[编队内存优化] 保留角色实体加载失败/超时，放弃优化";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("keepCreatureDataId", waitCreatureDataId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("result", result);
					instance3.Warn(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					this.TryCloseMask("PlotFormationMemory.Enter");
					return;
				}
				this.ExecuteShrink(teamItem);
				this.TryCloseMask("PlotFormationMemory.Enter");
			}, 15000, true, false);
		}

		// Token: 0x0603672F RID: 223023 RVA: 0x00DBBE28 File Offset: 0x00DBA028
		private unsafe void ExecuteShrink(SceneTeamItem keepItem)
		{
			long creatureDataId = keepItem.GetCreatureDataId();
			int getConfigId = keepItem.GetConfigId;
			ControllerBase<SceneTeamController>.Instance.RequestChangeRole(creatureDataId, new RequestChangeRoleParams
			{
				GoBattleInvincible = new bool?(true),
				CanUseGoBattleSkill = new bool?(false)
			});
			SceneTeamItem getCurrentTeamItem = ModelBase<SceneTeamModel>.Instance.GetCurrentTeamItem;
			if (getCurrentTeamItem == null || getCurrentTeamItem.GetCreatureDataId() != creatureDataId)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.YZH;
				string message = "[编队内存优化] 切换保留角色失败，放弃优化";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("keepCreatureDataId", creatureDataId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("currentCreatureDataId", (getCurrentTeamItem != null) ? new long?(getCurrentTeamItem.GetCreatureDataId()) : null);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			List<long> list = new List<long>();
			foreach (SceneTeamItem sceneTeamItem in ModelBase<SceneTeamModel>.Instance.GetTeamItems(true))
			{
				long creatureDataId2 = sceneTeamItem.GetCreatureDataId();
				if (creatureDataId2 != creatureDataId)
				{
					list.Add(creatureDataId2);
				}
			}
			SceneTeamRole sceneTeamRole = new SceneTeamRole();
			sceneTeamRole.CreatureDataId = creatureDataId;
			sceneTeamRole.RoleId = getConfigId;
			UpdateGroupParams @params = new UpdateGroupParams
			{
				GroupType = ETeamGroupType.Battle,
				GroupRoleList = new List<SceneTeamRole>
				{
					sceneTeamRole
				},
				CurrentRoleId = getConfigId
			};
			ModelBase<SceneTeamModel>.Instance.UpdateGroupData(ModelBase<CreatureModel>.Instance.GetPlayerId(), @params);
			foreach (long creatureDataId3 in list)
			{
				ControllerBase<CreatureController>.Instance.RemoveEntity(creatureDataId3, "PlotFormationMemory", ERemoveEntityType.RemoveTypeForce);
			}
			ControllerBase<WorldController>.Instance.ManuallyGarbageCollection(EGarbageCollectionReason.InPlotTransition);
			ControllerBase<WorldController>.Instance.ForceGarbageCollection(true);
			ModelBase<PlotModel>.Instance.IsFormationMemoryOptimized = true;
			ModelBase<PlotModel>.Instance.IsFormationMemoryShrunk = true;
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.Plot;
			ELogAuthor author2 = ELogAuthor.YZH;
			string message2 = "[编队内存优化] 进入完成";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("keepCreatureDataId", creatureDataId);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x06036730 RID: 223024 RVA: 0x00DBC058 File Offset: 0x00DBA258
		public void EnsureMaskBeforePlotEnd()
		{
			if (!ModelBase<PlotModel>.Instance.IsFormationMemoryOptimized || !ModelBase<PlotModel>.Instance.FormationMemoryNeedMask)
			{
				return;
			}
			this.TryOpenMask(true, "PlotFormationMemory.BeforePlotEnd");
		}

		// Token: 0x06036731 RID: 223025 RVA: 0x00DBC080 File Offset: 0x00DBA280
		public void Restore()
		{
			if (this.EnterWaitTask != null)
			{
				this.EnterWaitTask.Cancel();
				this.EnterWaitTask = null;
				Singleton<global::Log>.Instance.Info(ELogModule.Plot, ELogAuthor.YZH, "[编队内存优化] 剧情结束时仍在等待保留角色实体，取消等待并收幕", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.TryCloseMask("PlotFormationMemory.Restore.EnterWaitCancel");
				ModelBase<PlotModel>.Instance.FormationMemoryNeedMask = false;
				return;
			}
			if (!ModelBase<PlotModel>.Instance.IsFormationMemoryOptimized)
			{
				return;
			}
			Singleton<global::Log>.Instance.Info(ELogModule.Plot, ELogAuthor.YZH, "[编队内存优化] Restore 开始：请求服务端编队快照", default(ReadOnlySpan<ValueTuple<string, object>>));
			ModelBase<PlotModel>.Instance.IsFormationMemoryOptimized = false;
			this.TryOpenMask(ModelBase<PlotModel>.Instance.FormationMemoryNeedMask, "PlotFormationMemory.Restore");
			SceneGroupDataAndCurFormationEntityRequest message = SceneGroupDataAndCurFormationEntityRequest.Create();
			Singleton<Net>.Instance.Call<SceneGroupDataAndCurFormationEntityResponse>(ERequestMessageId.SceneGroupDataAndCurFormationEntityRequest, message, delegate(SceneGroupDataAndCurFormationEntityResponse response, Net.CallbackStatus _)
			{
				this.OnRestoreResponse(response);
			}, 0);
		}

		// Token: 0x06036732 RID: 223026 RVA: 0x00DBC144 File Offset: 0x00DBA344
		[NullableContext(2)]
		private unsafe void OnRestoreResponse(SceneGroupDataAndCurFormationEntityResponse response)
		{
			this.RestoreFinished = false;
			if (response == null || response.ErrorCode != ErrorCode.Success)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.YZH;
				string message = "[编队内存优化] 还原编队请求失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("errorCode", (response != null) ? new ErrorCode?(response.ErrorCode) : null);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.FinishRestore("PlotFormationMemory.Restore");
				ModelBase<PlotModel>.Instance.IsFormationMemoryShrunk = false;
				return;
			}
			foreach (EntityPb entityPb in response.CurFormationRoleEntitys)
			{
				long id = entityPb.Id;
				if (!ModelBase<CreatureModel>.Instance.ExistEntity(id))
				{
					EntityHandle entityHandle = ControllerBase<CreatureController>.Instance.CreateEntity(entityPb, "PlotFormationMemory.Restore");
					if (entityHandle == null)
					{
						global::Log instance2 = Singleton<global::Log>.Instance;
						ELogModule module2 = ELogModule.Plot;
						ELogAuthor author2 = ELogAuthor.YZH;
						string message2 = "[编队内存优化] 还原时实体创建失败，跳过该角色";
						ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("creatureDataId", id);
						instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					}
					else
					{
						ControllerBase<CreatureController>.Instance.LoadEntityAsync(entityHandle, null, false);
					}
				}
			}
			List<IUpdatePlayerParams> list = this.ConvertToUpdatePlayerParams(response.PlayerSceneGroupDataList);
			ModelBase<SceneTeamModel>.Instance.UpdateAllPlayerData(list);
			ModelBase<PlotModel>.Instance.IsFormationMemoryShrunk = false;
			global::Log instance3 = Singleton<global::Log>.Instance;
			ELogModule module3 = ELogModule.Plot;
			ELogAuthor author3 = ELogAuthor.YZH;
			string message3 = "[编队内存优化] Restore 服务端快照已应用";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("entityCount", response.CurFormationRoleEntitys.Count);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("playerCount", list.Count);
			instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			GameModePromise loadTeamPromise = ModelBase<SceneTeamModel>.Instance.LoadTeamPromise;
			UniTask<bool>? uniTask = (loadTeamPromise != null) ? new UniTask<bool>?(loadTeamPromise.Promise) : null;
			if (uniTask != null)
			{
				this.RestoreTimeoutHandle = TimerSystem.RealTimeInstance.Delay(delegate(float _)
				{
					Singleton<global::Log>.Instance.Error(ELogModule.Plot, ELogAuthor.YZH, "[编队内存优化] 等待编队加载超时，强制收幕", default(ReadOnlySpan<ValueTuple<string, object>>));
					this.FinishRestore("PlotFormationMemory.Restore.Timeout");
				}, 15000f, null, "PlotFormationMemory.Restore", true, 1f);
				this.WaitTeamLoadedThenCloseMask(uniTask.Value).Forget();
			}
			else
			{
				this.FinishRestore("PlotFormationMemory.Restore");
			}
			Singleton<global::Log>.Instance.Info(ELogModule.Plot, ELogAuthor.YZH, "[编队内存优化] 还原编队完成", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x06036733 RID: 223027 RVA: 0x00DBC38C File Offset: 0x00DBA58C
		private void FinishRestore(string reason)
		{
			if (this.RestoreFinished)
			{
				return;
			}
			this.RestoreFinished = true;
			TimerHandle restoreTimeoutHandle = this.RestoreTimeoutHandle;
			if (restoreTimeoutHandle != null)
			{
				restoreTimeoutHandle.Remove();
			}
			this.RestoreTimeoutHandle = null;
			this.TryCloseMask(reason);
			ModelBase<PlotModel>.Instance.FormationMemoryNeedMask = false;
		}

		// Token: 0x06036734 RID: 223028 RVA: 0x00DBC3CC File Offset: 0x00DBA5CC
		[NullableContext(0)]
		private UniTask WaitTeamLoadedThenCloseMask(UniTask<bool> loadPromise)
		{
			PlotFormationMemory.<WaitTeamLoadedThenCloseMask>d__15 <WaitTeamLoadedThenCloseMask>d__;
			<WaitTeamLoadedThenCloseMask>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<WaitTeamLoadedThenCloseMask>d__.<>4__this = this;
			<WaitTeamLoadedThenCloseMask>d__.loadPromise = loadPromise;
			<WaitTeamLoadedThenCloseMask>d__.<>1__state = -1;
			<WaitTeamLoadedThenCloseMask>d__.<>t__builder.Start<PlotFormationMemory.<WaitTeamLoadedThenCloseMask>d__15>(ref <WaitTeamLoadedThenCloseMask>d__);
			return <WaitTeamLoadedThenCloseMask>d__.<>t__builder.Task;
		}

		// Token: 0x06036735 RID: 223029 RVA: 0x00DBC418 File Offset: 0x00DBA618
		private List<IUpdatePlayerParams> ConvertToUpdatePlayerParams(IList<PlayerSceneGroupDataList> dataList)
		{
			List<IUpdatePlayerParams> list = new List<IUpdatePlayerParams>();
			foreach (PlayerSceneGroupDataList playerSceneGroupDataList in dataList)
			{
				List<IUpdateGroupParams> list2 = new List<IUpdateGroupParams>();
				foreach (PlayerSceneGroupData playerSceneGroupData in playerSceneGroupDataList.PlayerSceneGroupData)
				{
					List<SceneTeamRole> list3 = new List<SceneTeamRole>();
					foreach (SceneRoleInformation sceneRoleInformation in playerSceneGroupData.FightRoleInfos)
					{
						list3.Add(new SceneTeamRole
						{
							CreatureDataId = sceneRoleInformation.EntityId,
							RoleId = sceneRoleInformation.RoleId,
							OnStageWithoutControl = sceneRoleInformation.OnStageOutOfControl
						});
					}
					list2.Add(new UpdateGroupParams
					{
						GroupType = (ETeamGroupType)playerSceneGroupData.Group,
						GroupRoleList = list3,
						CurrentRoleId = playerSceneGroupData.CurRole,
						LivingState = new ETeamLivingState?(ControllerBase<SceneTeamController>.Instance.GetLivingSate(playerSceneGroupData.LivingStatus))
					});
				}
				list.Add(new UpdatePlayerParams
				{
					PlayerId = playerSceneGroupDataList.PlayerId,
					CurrentGroupType = (ETeamGroupType)playerSceneGroupDataList.CurrentGroup,
					Groups = list2
				});
			}
			return list;
		}

		// Token: 0x06036736 RID: 223030 RVA: 0x00DBC5C4 File Offset: 0x00DBA7C4
		private bool NeedBlackScreen(PlotInfo plotInfo)
		{
			if (PlotFormationMemory.ForceEnableForGm)
			{
				return true;
			}
			IStateProgramSpecialProcessChangeTeamOptimization programSpecialProcess = plotInfo.ProgramSpecialProcess;
			return programSpecialProcess != null && programSpecialProcess.IsOpenBlackScreen.GetValueOrDefault();
		}

		// Token: 0x06036737 RID: 223031 RVA: 0x00DBC5F4 File Offset: 0x00DBA7F4
		private void TryOpenMask(bool needMask, string context)
		{
			if (!needMask || this.MaskOpened)
			{
				return;
			}
			ControllerBase<LevelLoadingController>.Instance.OpenLoading<ELoadingPerform>(ELoadingReason.PlotFormationMemory, ELoadingPerform.CameraFade, context, null, new object[]
			{
				0
			});
			this.MaskOpened = true;
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.YZH;
			string message = "[编队内存优化] 开幕（CameraFade 计数+1）";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("context", context);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x06036738 RID: 223032 RVA: 0x00DBC658 File Offset: 0x00DBA858
		private void TryCloseMask(string context)
		{
			if (!this.MaskOpened)
			{
				return;
			}
			ControllerBase<LevelLoadingController>.Instance.CloseLoading(ELoadingReason.PlotFormationMemory, context, null, null);
			this.MaskOpened = false;
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.YZH;
			string message = "[编队内存优化] 收幕（CameraFade 计数-1）";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("context", context);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x06036739 RID: 223033 RVA: 0x00DBC6B2 File Offset: 0x00DBA8B2
		public static void CreateStaticDefaultValue()
		{
			PlotFormationMemory.ForceEnableForGm = false;
			PlotFormationMemory.IgnoreLowMemoryForGm = false;
		}

		// Token: 0x0603673A RID: 223034 RVA: 0x00DBC6C0 File Offset: 0x00DBA8C0
		public static void ResetStaticDefaultValue()
		{
			PlotFormationMemory.ForceEnableForGm = false;
			PlotFormationMemory.IgnoreLowMemoryForGm = false;
		}

		// Token: 0x0401F521 RID: 128289
		public static bool ForceEnableForGm;

		// Token: 0x0401F522 RID: 128290
		public static bool IgnoreLowMemoryForGm;

		// Token: 0x0401F523 RID: 128291
		private const float RESTORE_MASK_TIMEOUT_MS = 15000f;

		// Token: 0x0401F524 RID: 128292
		private const int ENTER_WAIT_ENTITY_TIMEOUT_MS = 15000;

		// Token: 0x0401F525 RID: 128293
		private bool MaskOpened;

		// Token: 0x0401F526 RID: 128294
		[Nullable(2)]
		private TimerHandle RestoreTimeoutHandle;

		// Token: 0x0401F527 RID: 128295
		[Nullable(2)]
		private WaitEntityTask EnterWaitTask;

		// Token: 0x0401F528 RID: 128296
		private bool RestoreFinished;
	}
}
