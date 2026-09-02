using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.KuroSimpleCombat;
using CSharpScript.Game.Module.GameMainView.TrapDefense;
using CSharpScript.Game.Module.TowerDefenseEvent.Model;
using CSharpScript.Game.Module.TrapDefense;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefenseEvent
{
	// Token: 0x02004E82 RID: 20098
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[TickController(0)]
	public class TowerDefenseEventController : ControllerBase<TowerDefenseEventController>
	{
		// Token: 0x170088E5 RID: 35045
		// (get) Token: 0x06033ED0 RID: 212688 RVA: 0x00CFED3B File Offset: 0x00CFCF3B
		public ETowerDefenseEventProcessStatus ProcessStatus
		{
			get
			{
				return this.ProcessStatusInternal;
			}
		}

		// Token: 0x06033ED1 RID: 212689 RVA: 0x00CFED43 File Offset: 0x00CFCF43
		public bool IsInPreview()
		{
			return this.ProcessStatusInternal == ETowerDefenseEventProcessStatus.Ready;
		}

		// Token: 0x06033ED2 RID: 212690 RVA: 0x00CFED4E File Offset: 0x00CFCF4E
		public bool IsFighting()
		{
			return this.ProcessStatusInternal == ETowerDefenseEventProcessStatus.Fighting;
		}

		// Token: 0x06033ED3 RID: 212691 RVA: 0x00CFED59 File Offset: 0x00CFCF59
		public void ResetWorldAttr()
		{
			this.GoldNum = 0L;
			this.BattleWave = 0;
		}

		// Token: 0x06033ED4 RID: 212692 RVA: 0x00CFED6C File Offset: 0x00CFCF6C
		public bool IsTowerDefenseEventInstance()
		{
			return ControllerBase<GameModeController>.Instance.IsInInstance() && ModelBase<GameModeModel>.Instance.InstanceDungeon != null && ModelBase<GameModeModel>.Instance.InstanceDungeon.Value.InstSubType == 37;
		}

		// Token: 0x06033ED5 RID: 212693 RVA: 0x00CFEDBB File Offset: 0x00CFCFBB
		public void InitMap()
		{
			this.InitTowerDefenseEventInstance();
			Singleton<Net>.Instance.Register<TrapDefenseStepUpdateNotify>(ENotifyMessageId.TrapDefenseStepUpdateNotify, new Action<TrapDefenseStepUpdateNotify, Net.CallbackStatus>(this.OnStepUpdateNotify));
			Singleton<Net>.Instance.Register<TrapDefenseEntityDataChangeNotify>(ENotifyMessageId.TrapDefenseEntityDataChangeNotify, new Action<TrapDefenseEntityDataChangeNotify, Net.CallbackStatus>(this.OnEntityDataChanged));
		}

		// Token: 0x06033ED6 RID: 212694 RVA: 0x00CFEDFB File Offset: 0x00CFCFFB
		public void OnWorldDone()
		{
			this.IsWorldInit = true;
			this.ResetWorldAttr();
		}

		// Token: 0x06033ED7 RID: 212695 RVA: 0x00CFEE0A File Offset: 0x00CFD00A
		public void OnWorldReset()
		{
			if (!this.IsWorldInit)
			{
				return;
			}
			this.IsWorldInit = false;
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TrapDefenseStepUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TrapDefenseEntityDataChangeNotify);
			this.ResetTowerDefenseEventInstance();
		}

		// Token: 0x06033ED8 RID: 212696 RVA: 0x00CFEE42 File Offset: 0x00CFD042
		[NullableContext(2)]
		private void OnEntityDataChanged(TrapDefenseEntityDataChangeNotify data, Net.CallbackStatus _)
		{
			if (data != null)
			{
				this.EntityRedirectFilter.UpdateEntity(data);
			}
		}

		// Token: 0x06033ED9 RID: 212697 RVA: 0x00CFEE54 File Offset: 0x00CFD054
		public unsafe void OnEntityRemoved(KscRemoveContext context, Dictionary<long, SimpleCombatEntityDieContext> protoContexts)
		{
			if (context.IsPreview)
			{
				this.PreviewMonsterSpawner.RemovePreviewMonster(context.CreatureDataId);
				return;
			}
			ITowerDefenseEventCombatInfo entity = ModelBase<TowerDefenseEventModel>.Instance.GetEntity(context.CreatureDataId);
			if (entity == null)
			{
				return;
			}
			if (context.ReasonName != KscEntityRemoveReason.LandFire)
			{
				entity.Position.DeepCopy(context.Location);
			}
			SimpleCombatEntityDieContext simpleCombatEntityDieContext = SimpleCombatEntityDieContext.Create();
			Aki.Protocol.Vector vector = Aki.Protocol.Vector.Create();
			vector.X = (float)entity.Position.X;
			vector.Y = (float)entity.Position.Y;
			vector.Z = (float)entity.Position.Z;
			simpleCombatEntityDieContext.DiePos = vector;
			FName? dynamicFName = FNameUtil.GetDynamicFName(context.ReasonName.ToString());
			if (dynamicFName == KscEntityRemoveReason.Dead)
			{
				TrapDefenseMonsterKilledCtxPb trapDefenseMonsterKilledCtxPb = TrapDefenseMonsterKilledCtxPb.Create();
				trapDefenseMonsterKilledCtxPb.EntityId = context.KillerId;
				trapDefenseMonsterKilledCtxPb.PollutedGridCells.AddRange(this.DoDeathRattle(entity));
				simpleCombatEntityDieContext.TrapDefenseMonsterKilledCtx = trapDefenseMonsterKilledCtxPb;
			}
			else if (dynamicFName == KscEntityRemoveReason.WorldKill)
			{
				TrapDefenseEnvironmentalKillCtxPb trapDefenseEnvironmentalKillCtxPb = TrapDefenseEnvironmentalKillCtxPb.Create();
				trapDefenseEnvironmentalKillCtxPb.TrapId = context.KillerId;
				simpleCombatEntityDieContext.TrapDefenseEnvironmentalKillCtx = trapDefenseEnvironmentalKillCtxPb;
			}
			else if (dynamicFName == KscEntityRemoveReason.Arrival)
			{
				TrapDefenseReachInstEndpointCtxPb trapDefenseReachInstEndpointCtx = TrapDefenseReachInstEndpointCtxPb.Create();
				simpleCombatEntityDieContext.TrapDefenseReachInstEndpointCtx = trapDefenseReachInstEndpointCtx;
			}
			else if (dynamicFName == KscEntityRemoveReason.Coin)
			{
				TrapDefenseGoldenCoinAbosorbedCtxPb trapDefenseGoldenCoinAbosorbedCtx = TrapDefenseGoldenCoinAbosorbedCtxPb.Create();
				simpleCombatEntityDieContext.TrapDefenseGoldenCoinAbosorbedCtx = trapDefenseGoldenCoinAbosorbedCtx;
			}
			else
			{
				if (!(dynamicFName == KscEntityRemoveReason.LandFire))
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.TowerDefenseEvent;
					ELogAuthor author = ELogAuthor.XY;
					string message = "移除塔防实体失败: 未处理移除原因";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("creatureDataId", context.CreatureDataId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("reasonName", context.ReasonName);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					return;
				}
				TrapDefenseTrapSelfDestructCtxPb trapDefenseTrapSelfDestructCtxPb = TrapDefenseTrapSelfDestructCtxPb.Create();
				List<GridPlacementPbInfo> gridCells = new List<GridPlacementPbInfo>();
				ControllerBase<BuildingGridController>.Instance.LandFireGrids(entity.Position, context.EffectRange, context.ClearCell, delegate(string gridId, FKuroBuildingGridCellVector coords)
				{
					GridPlacementPbInfo gridPlacementPbInfo = GridPlacementPbInfo.Create();
					gridPlacementPbInfo.ActorGuid = gridId;
					gridPlacementPbInfo.X = coords.X;
					gridPlacementPbInfo.Y = coords.Y;
					gridPlacementPbInfo.Direction = GridPbDirection.GridForward;
					gridCells.Add(gridPlacementPbInfo);
				});
				this.DoLandFire(entity, context.Params);
				trapDefenseTrapSelfDestructCtxPb.DamagedGridCells.AddRange(gridCells);
				trapDefenseTrapSelfDestructCtxPb.FireCount = context.FireNum;
				simpleCombatEntityDieContext.TrapDefenseTrapSelfDestructCtx = trapDefenseTrapSelfDestructCtxPb;
			}
			if (entity is ITowerDefenseEventSpecialCellBaseInfo)
			{
				TrapDefenseSpcecialCellDestructCtxPb trapDefenseSpcecialCellDestructCtx = TrapDefenseSpcecialCellDestructCtxPb.Create();
				simpleCombatEntityDieContext.TrapDefenseSpcecialCellDestructCtx = trapDefenseSpcecialCellDestructCtx;
			}
			protoContexts[context.CreatureDataId] = simpleCombatEntityDieContext;
		}

		// Token: 0x06033EDA RID: 212698 RVA: 0x00CFF160 File Offset: 0x00CFD360
		private void DoLandFire(ITowerDefenseEventCombatInfo model, [Nullable(2)] TMap<EKSC_AttrType, int> @params)
		{
			if (@params == null || @params.Num() <= 0)
			{
				return;
			}
			TMap<EKSC_AttrType, int> tmap = new TMap<EKSC_AttrType, int>();
			foreach (KeyValuePair<EKSC_AttrType, int> keyValuePair in @params)
			{
				EKSC_AttrType eksc_AttrType;
				int num;
				keyValuePair.Deconstruct(out eksc_AttrType, out num);
				EKSC_AttrType key = eksc_AttrType;
				int value = num;
				tmap[key] = value;
			}
			Dictionary<ETowerDefenseEventCombatExtraInfoType, CombatExtraInfoBase> dictionary = new Dictionary<ETowerDefenseEventCombatExtraInfoType, CombatExtraInfoBase>();
			dictionary[ETowerDefenseEventCombatExtraInfoType.LandFire] = new LandFireExtraInfo
			{
				Params = tmap
			};
			model.ExtraInfo = dictionary;
		}

		// Token: 0x06033EDB RID: 212699 RVA: 0x00CFF1EC File Offset: 0x00CFD3EC
		private List<GridPlacementPbInfo> DoDeathRattle(ITowerDefenseEventCombatInfo model)
		{
			ITowerDefenseEventMonsterInfo towerDefenseEventMonsterInfo = model as ITowerDefenseEventMonsterInfo;
			if (towerDefenseEventMonsterInfo == null)
			{
				return new List<GridPlacementPbInfo>();
			}
			if (towerDefenseEventMonsterInfo.DeathType == ETowerDefenseEventMonsterDeathType.Pollute)
			{
				return ControllerBase<BuildingGridController>.Instance.PolluteGrids(towerDefenseEventMonsterInfo.Position, towerDefenseEventMonsterInfo.PolluteRadius);
			}
			return new List<GridPlacementPbInfo>();
		}

		// Token: 0x06033EDC RID: 212700 RVA: 0x00CFF230 File Offset: 0x00CFD430
		private void InitTowerDefenseEventInstance()
		{
			TrapDefenseActivity? config = ConfigTrapDefenseActivityByInstId.GetConfig(ModelBase<GameModeModel>.Instance.InstanceDungeon.Value.Id, true);
			ModelBase<TowerDefenseEventModel>.Instance.InitInstance(config);
		}

		// Token: 0x06033EDD RID: 212701 RVA: 0x00CFF26C File Offset: 0x00CFD46C
		private void ResetTowerDefenseEventInstance()
		{
			this.ProcessStatusInternal = ETowerDefenseEventProcessStatus.None;
			this.RaycastResult.Reset();
			this.DestroyPreviewTrapActor("TowerDefenseEventController.ResetTowerDefenseEventInstance");
			this.TrapTemplateInfo.Reset();
			this.PrepareRemoveTrapActor = null;
			this.BuildTipsTypeInternal = ETrapDefenseBuildTipsType.None;
			this.PreviewMonsterSpawner.Clear();
		}

		// Token: 0x06033EDE RID: 212702 RVA: 0x00CFF2BC File Offset: 0x00CFD4BC
		[NullableContext(2)]
		private void OnStepUpdateNotify(TrapDefenseStepUpdateNotify data, Net.CallbackStatus _)
		{
			if (data == null)
			{
				return;
			}
			string a = data.StepPbDataCase.ToString();
			if (!(a == "PreviewStepPbData"))
			{
				if (!(a == "MonsterStepPbData"))
				{
					if (a == "RewardStepPbData")
					{
						this.ProcessStatusInternal = ETowerDefenseEventProcessStatus.Reward;
					}
				}
				else
				{
					this.ProcessStatusInternal = ETowerDefenseEventProcessStatus.Fighting;
					TrapDefenseSpawnMonsterStepPbData monsterStepPbData = data.MonsterStepPbData;
					if (monsterStepPbData != null)
					{
						this.OnFightingStepUpdate(monsterStepPbData);
					}
					else
					{
						Singleton<Log>.Instance.Error(ELogModule.TowerDefenseEvent, ELogAuthor.XY, "战斗阶段数据为空", default(ReadOnlySpan<ValueTuple<string, object>>));
					}
					Singleton<AudioSystem>.Instance.SetState("tower_defence_music_2_6", "battle", true);
				}
			}
			else
			{
				this.ProcessStatusInternal = ETowerDefenseEventProcessStatus.Ready;
				TrapDefensePreviewStepPbData previewStepPbData = data.PreviewStepPbData;
				if (previewStepPbData != null)
				{
					this.OnPreviewStepUpdate(previewStepPbData);
				}
				else
				{
					Singleton<Log>.Instance.Error(ELogModule.TowerDefenseEvent, ELogAuthor.XY, "预览阶段数据为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				if (!ModelBase<TrapDefenseModel>.Instance.BattleData.HasStartAkEvent)
				{
					ModelBase<TrapDefenseModel>.Instance.BattleData.SetHasStartAkEvent(true);
					Singleton<AudioSystem>.Instance.PostEvent("play_2_6_tower_defence_music_ingame");
				}
				else
				{
					Singleton<AudioSystem>.Instance.SetState("tower_defence_music_2_6", "none", true);
				}
			}
			TsTowerDefenseEventActor.UpdateTrapRangeState();
			Singleton<EventSystem>.Instance.Emit<ETowerDefenseEventProcessStatus>(EEventName.TowerDefenseEventStepUpdate, this.ProcessStatusInternal);
		}

		// Token: 0x06033EDF RID: 212703 RVA: 0x00CFF40C File Offset: 0x00CFD60C
		private void OnPreviewStepUpdate(TrapDefensePreviewStepPbData data)
		{
			this.PreviewMonsterSpawner.Init(data.MonsterRoutesPreviewInfo.ToDictionary<int, TrapDefenseMonsterPbGroup>());
			if (data.ShopInfo != null)
			{
				ModelBase<TrapDefenseModel>.Instance.BattleData.SetShopOpen(data.ShopInfo.ShopProductPbInfos.Count > 0);
			}
			else
			{
				ModelBase<TrapDefenseModel>.Instance.BattleData.SetShopOpen(false);
			}
			Singleton<Log>.Instance.Info(ELogModule.TowerDefenseEvent, ELogAuthor.XXJ, "塔防进入准备阶段", default(ReadOnlySpan<ValueTuple<string, object>>));
			if (data.ShopInfo != null)
			{
				ModelBase<TrapDefenseModel>.Instance.ProtoShopInitNotify(data.ShopInfo);
			}
		}

		// Token: 0x06033EE0 RID: 212704 RVA: 0x00CFF4A4 File Offset: 0x00CFD6A4
		private void OnFightingStepUpdate(TrapDefenseSpawnMonsterStepPbData data)
		{
			this.PreviewMonsterSpawner.Reset();
			ModelBase<TrapDefenseModel>.Instance.BattleData.SetPreviewCountDown((float)data.EndCountdownSecond);
			ModelBase<TrapDefenseModel>.Instance.BattleData.SetSpecialShow(data.IsWarningPrepareStyle);
			Singleton<Log>.Instance.Info(ELogModule.TowerDefenseEvent, ELogAuthor.XXJ, "塔防进入战斗阶段", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x06033EE1 RID: 212705 RVA: 0x00CFF506 File Offset: 0x00CFD706
		public void ControllerTick(float delta)
		{
			this.OnTick(delta);
		}

		// Token: 0x06033EE2 RID: 212706 RVA: 0x00CFF510 File Offset: 0x00CFD710
		protected override void OnTick(float delta)
		{
			if (this.IsInPreview())
			{
				this.PreviewMonsterSpawner.OnTick(delta);
			}
			if (this.IsFighting())
			{
				int batch = ModelBase<TrapDefenseModel>.Instance.BattleData.GetBatch();
				if (batch != this.BattleWave)
				{
					UKSC_World kscWorld = Singleton<KscEnv>.Instance.KscWorld;
					if (kscWorld != null)
					{
						kscWorld.SetWorldAttr(EKSC_WorldAttrType.Wave, batch);
					}
					this.BattleWave = batch;
				}
				long goldNum = ModelBase<TrapDefenseModel>.Instance.BattleData.GetGoldNum();
				if (goldNum != this.GoldNum)
				{
					UKSC_World kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
					if (kscWorld2 != null)
					{
						kscWorld2.SetWorldAttr(EKSC_WorldAttrType.Gold, (int)goldNum);
					}
					this.GoldNum = goldNum;
				}
			}
			bool flag = (this.IsInPreview() && ModelBase<TowerDefenseEventModel>.Instance.CurrentTrapCount > 0) || this.TrapTemplateInfo.IsInPreview();
			if (flag)
			{
				if (this.RaycastResult.Raycast(this.PreviewTrapActor, this.TrapTemplateInfo.PlacementType, (float)this.TrapTemplateInfo.Degree, !this.IsFighting()))
				{
					this.TrapTemplateInfo.Position.DeepCopy(this.RaycastResult.Location);
					this.TrapTemplateInfo.Rotation.DeepCopy(this.RaycastResult.Rotation);
					this.TrapTemplateInfo.Degree = (int)this.RaycastResult.Degree;
				}
			}
			else if (this.IsRaycast)
			{
				this.RaycastResult.Reset();
			}
			this.IsRaycast = flag;
			if (!this.RaycastResult.IsCanPlace)
			{
				this.HidePreviewTrap();
			}
			if (this.RaycastResult.IsCanRecycle)
			{
				if (this.PrepareRemoveTrapActor != this.RaycastResult.RaycastTarget)
				{
					TsTowerDefenseEventActor prepareRemoveTrapActor = this.PrepareRemoveTrapActor;
					if (prepareRemoveTrapActor != null)
					{
						prepareRemoveTrapActor.ResetRemove();
					}
					this.PrepareRemoveTrapActor = this.RaycastResult.RaycastTarget;
					this.PrepareRemoveTrapActor.PrepareRemove();
				}
			}
			else if (this.PrepareRemoveTrapActor != null)
			{
				this.PrepareRemoveTrapActor.ResetRemove();
				this.PrepareRemoveTrapActor = null;
			}
			this.CheckRaycastOnOrgan();
			if (this.TrapTemplateInfo.GetConfigDirtyAndReset() || this.RaycastResult.IsStateDirty)
			{
				this.UpdateRaycastState();
			}
		}

		// Token: 0x06033EE3 RID: 212707 RVA: 0x00CFF710 File Offset: 0x00CFD910
		private void HidePreviewTrap()
		{
			if (!this.TrapTemplateInfo.IsInPreview())
			{
				return;
			}
			if (this.PreviewTrapActor != null && this.PreviewTrapActor.IsValid())
			{
				this.PreviewTrapActor.Hide();
			}
		}

		// Token: 0x170088E6 RID: 35046
		// (get) Token: 0x06033EE4 RID: 212708 RVA: 0x00CFF740 File Offset: 0x00CFD940
		public ETrapDefenseBuildTipsType BuildTipsType
		{
			get
			{
				return this.BuildTipsTypeInternal;
			}
		}

		// Token: 0x06033EE5 RID: 212709 RVA: 0x00CFF748 File Offset: 0x00CFD948
		private void UpdateRaycastState()
		{
			ETrapDefenseBuildTipsType etrapDefenseBuildTipsType = ETrapDefenseBuildTipsType.None;
			if (this.RaycastResult.IsCanBuild)
			{
				etrapDefenseBuildTipsType |= ETrapDefenseBuildTipsType.Build;
			}
			else if (this.TrapTemplateInfo.IsInPreview())
			{
				etrapDefenseBuildTipsType |= ETrapDefenseBuildTipsType.Disable;
			}
			if (this.RaycastResult.IsCanRecycle)
			{
				etrapDefenseBuildTipsType |= ETrapDefenseBuildTipsType.Recycle;
			}
			if (this.RaycastResult.IsPolluted)
			{
				etrapDefenseBuildTipsType |= ETrapDefenseBuildTipsType.Pollute;
			}
			if (this.TrapTemplateInfo.IsInPreview() && this.TrapTemplateInfo.CanRotate)
			{
				etrapDefenseBuildTipsType |= ETrapDefenseBuildTipsType.Rotate;
			}
			if (this.BuildTipsTypeInternal != etrapDefenseBuildTipsType)
			{
				this.BuildTipsTypeInternal = etrapDefenseBuildTipsType;
				Singleton<EventSystem>.Instance.Emit<ETrapDefenseBuildTipsType>(EEventName.TowerDefenseEventNotifyType, this.BuildTipsTypeInternal);
			}
		}

		// Token: 0x06033EE6 RID: 212710 RVA: 0x00CFF7E4 File Offset: 0x00CFD9E4
		[NullableContext(0)]
		private UniTask<bool> StartFighting()
		{
			TowerDefenseEventController.<StartFighting>d__40 <StartFighting>d__;
			<StartFighting>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<StartFighting>d__.<>4__this = this;
			<StartFighting>d__.<>1__state = -1;
			<StartFighting>d__.<>t__builder.Start<TowerDefenseEventController.<StartFighting>d__40>(ref <StartFighting>d__);
			return <StartFighting>d__.<>t__builder.Task;
		}

		// Token: 0x06033EE7 RID: 212711 RVA: 0x00CFF828 File Offset: 0x00CFDA28
		private void DoSelectAction(int index)
		{
			int? machineIdByIndex = ModelBase<TowerDefenseEventModel>.Instance.GetMachineIdByIndex(index);
			if (machineIdByIndex == null || machineIdByIndex.Value == 0)
			{
				return;
			}
			if (this.TrapTemplateInfo.IsTargetLevel(machineIdByIndex.Value))
			{
				return;
			}
			this.PreviewTrap(machineIdByIndex.Value);
		}

		// Token: 0x06033EE8 RID: 212712 RVA: 0x00CFF877 File Offset: 0x00CFDA77
		public void HandleTowerDefenseSelect(int index)
		{
			TowerDefensePlayerController.EnablePlayerFollower(false);
			this.DoSelectAction(index);
		}

		// Token: 0x06033EE9 RID: 212713 RVA: 0x00CFF888 File Offset: 0x00CFDA88
		public void CancelCurrentPreviewTrap()
		{
			if (this.PreviewTrapActor == null)
			{
				return;
			}
			ITowerDefenseEventTrapBaseInfo tapModel = this.PreviewTrapActor.GetTapModel();
			if (tapModel == null)
			{
				return;
			}
			if (this.TrapTemplateInfo.IsTargetLevel(tapModel.ConfigId))
			{
				this.TrapTemplateInfo.Reset();
				this.DestroyPreviewTrapActor("TowerDefenseEventController.CancelCurrentPreviewTrap");
			}
		}

		// Token: 0x06033EEA RID: 212714 RVA: 0x00CFF8D8 File Offset: 0x00CFDAD8
		[NullableContext(0)]
		public UniTask<bool> ExecuteStartFighting()
		{
			TowerDefenseEventController.<ExecuteStartFighting>d__44 <ExecuteStartFighting>d__;
			<ExecuteStartFighting>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteStartFighting>d__.<>4__this = this;
			<ExecuteStartFighting>d__.<>1__state = -1;
			<ExecuteStartFighting>d__.<>t__builder.Start<TowerDefenseEventController.<ExecuteStartFighting>d__44>(ref <ExecuteStartFighting>d__);
			return <ExecuteStartFighting>d__.<>t__builder.Task;
		}

		// Token: 0x06033EEB RID: 212715 RVA: 0x00CFF91C File Offset: 0x00CFDB1C
		[NullableContext(0)]
		public UniTask<bool> ExecuteOccupyTrap()
		{
			TowerDefenseEventController.<ExecuteOccupyTrap>d__45 <ExecuteOccupyTrap>d__;
			<ExecuteOccupyTrap>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOccupyTrap>d__.<>4__this = this;
			<ExecuteOccupyTrap>d__.<>1__state = -1;
			<ExecuteOccupyTrap>d__.<>t__builder.Start<TowerDefenseEventController.<ExecuteOccupyTrap>d__45>(ref <ExecuteOccupyTrap>d__);
			return <ExecuteOccupyTrap>d__.<>t__builder.Task;
		}

		// Token: 0x06033EEC RID: 212716 RVA: 0x00CFF960 File Offset: 0x00CFDB60
		[NullableContext(0)]
		public UniTask<bool> ExecuteUnOccupyTrap()
		{
			TowerDefenseEventController.<ExecuteUnOccupyTrap>d__46 <ExecuteUnOccupyTrap>d__;
			<ExecuteUnOccupyTrap>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteUnOccupyTrap>d__.<>4__this = this;
			<ExecuteUnOccupyTrap>d__.<>1__state = -1;
			<ExecuteUnOccupyTrap>d__.<>t__builder.Start<TowerDefenseEventController.<ExecuteUnOccupyTrap>d__46>(ref <ExecuteUnOccupyTrap>d__);
			return <ExecuteUnOccupyTrap>d__.<>t__builder.Task;
		}

		// Token: 0x06033EED RID: 212717 RVA: 0x00CFF9A3 File Offset: 0x00CFDBA3
		public void ExecuteRotateTrap()
		{
			this.RotateTrap();
		}

		// Token: 0x06033EEE RID: 212718 RVA: 0x00CFF9AC File Offset: 0x00CFDBAC
		public unsafe bool PreviewTrap(int configId)
		{
			this.RaycastResult.Reset();
			this.TrapTemplateInfo.BeginInit(configId);
			string text = TowerDefenseEventConfig.FillUpModelInfo(this.TrapTemplateInfo, false);
			this.TrapTemplateInfo.EndInit();
			if (text != null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.TowerDefenseEvent;
				ELogAuthor author = ELogAuthor.XY;
				string message = "预览陷阱失败: " + text;
				<>y__InlineArray8<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray8<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("configId", configId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("trapId", this.TrapTemplateInfo.TrapId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("level", this.TrapTemplateInfo.Level);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("branchId", this.TrapTemplateInfo.BranchId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("templateId", this.TrapTemplateInfo.TemplateId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("subTypeId", this.TrapTemplateInfo.SubTypeId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 6) = new ValueTuple<string, object>("combatId", this.TrapTemplateInfo.CombatId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 7) = new ValueTuple<string, object>("prefabPath", this.TrapTemplateInfo.PrefabPath);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 8));
				return false;
			}
			this.InitPreviewTrapActor();
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.TrapDefensePreviewMachine, configId);
			return true;
		}

		// Token: 0x06033EEF RID: 212719 RVA: 0x00CFFB60 File Offset: 0x00CFDD60
		private void InitPreviewTrapActor()
		{
			if (this.PreviewTrapActor == null)
			{
				this.PreviewTrapActor = (Singleton<ActorSystem>.Instance.Get(TsTowerDefenseEventActor.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null, true) as TsTowerDefenseEventActor);
			}
			this.PreviewTrapActor.Init(this.TrapTemplateInfo, null);
		}

		// Token: 0x06033EF0 RID: 212720 RVA: 0x00CFFBAE File Offset: 0x00CFDDAE
		private void DestroyPreviewTrapActor(string reason)
		{
			if (this.PreviewTrapActor != null && this.PreviewTrapActor.IsValid())
			{
				this.PreviewTrapActor.Destroy(reason);
			}
			this.PreviewTrapActor = null;
		}

		// Token: 0x06033EF1 RID: 212721 RVA: 0x00CFFBD8 File Offset: 0x00CFDDD8
		public void RotateTrap()
		{
			this.TrapTemplateInfo.Rotate();
		}

		// Token: 0x06033EF2 RID: 212722 RVA: 0x00CFFBE5 File Offset: 0x00CFDDE5
		public bool IsEnoughGoldToBuildTrap()
		{
			return ModelBase<TowerDefenseEventModel>.Instance.IsEnoughGoldToBuildTrap(this.TrapTemplateInfo);
		}

		// Token: 0x06033EF3 RID: 212723 RVA: 0x00CFFBF8 File Offset: 0x00CFDDF8
		[NullableContext(0)]
		public UniTask<bool> OccupyTrap()
		{
			TowerDefenseEventController.<OccupyTrap>d__53 <OccupyTrap>d__;
			<OccupyTrap>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OccupyTrap>d__.<>4__this = this;
			<OccupyTrap>d__.<>1__state = -1;
			<OccupyTrap>d__.<>t__builder.Start<TowerDefenseEventController.<OccupyTrap>d__53>(ref <OccupyTrap>d__);
			return <OccupyTrap>d__.<>t__builder.Task;
		}

		// Token: 0x06033EF4 RID: 212724 RVA: 0x00CFFC3C File Offset: 0x00CFDE3C
		[NullableContext(0)]
		private UniTask<Aki.Protocol.ErrorCode?> RequestOccupyTrap([Nullable(1)] ITowerDefenseEventTrapInfo trapInfo)
		{
			TowerDefenseEventController.<RequestOccupyTrap>d__54 <RequestOccupyTrap>d__;
			<RequestOccupyTrap>d__.<>t__builder = AsyncUniTaskMethodBuilder<Aki.Protocol.ErrorCode?>.Create();
			<RequestOccupyTrap>d__.trapInfo = trapInfo;
			<RequestOccupyTrap>d__.<>1__state = -1;
			<RequestOccupyTrap>d__.<>t__builder.Start<TowerDefenseEventController.<RequestOccupyTrap>d__54>(ref <RequestOccupyTrap>d__);
			return <RequestOccupyTrap>d__.<>t__builder.Task;
		}

		// Token: 0x06033EF5 RID: 212725 RVA: 0x00CFFC80 File Offset: 0x00CFDE80
		[NullableContext(0)]
		public UniTask<bool> UnOccupyTrap()
		{
			TowerDefenseEventController.<UnOccupyTrap>d__55 <UnOccupyTrap>d__;
			<UnOccupyTrap>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<UnOccupyTrap>d__.<>4__this = this;
			<UnOccupyTrap>d__.<>1__state = -1;
			<UnOccupyTrap>d__.<>t__builder.Start<TowerDefenseEventController.<UnOccupyTrap>d__55>(ref <UnOccupyTrap>d__);
			return <UnOccupyTrap>d__.<>t__builder.Task;
		}

		// Token: 0x06033EF6 RID: 212726 RVA: 0x00CFFCC4 File Offset: 0x00CFDEC4
		[NullableContext(0)]
		private UniTask<Aki.Protocol.ErrorCode?> RequestUnoccupyTrap([Nullable(1)] ITowerDefenseEventTrapInfo trapInfo)
		{
			TowerDefenseEventController.<RequestUnoccupyTrap>d__56 <RequestUnoccupyTrap>d__;
			<RequestUnoccupyTrap>d__.<>t__builder = AsyncUniTaskMethodBuilder<Aki.Protocol.ErrorCode?>.Create();
			<RequestUnoccupyTrap>d__.trapInfo = trapInfo;
			<RequestUnoccupyTrap>d__.<>1__state = -1;
			<RequestUnoccupyTrap>d__.<>t__builder.Start<TowerDefenseEventController.<RequestUnoccupyTrap>d__56>(ref <RequestUnoccupyTrap>d__);
			return <RequestUnoccupyTrap>d__.<>t__builder.Task;
		}

		// Token: 0x06033EF7 RID: 212727 RVA: 0x00CFFD08 File Offset: 0x00CFDF08
		private void CheckRaycastOnOrgan()
		{
			TsTowerDefenseEventActor raycastTarget = this.RaycastResult.RaycastTarget;
			ITowerDefenseEventTrapInfo towerDefenseEventTrapInfo = ((raycastTarget != null) ? raycastTarget.GetTapModel() : null) as ITowerDefenseEventTrapInfo;
			long? num = (towerDefenseEventTrapInfo != null) ? new long?(towerDefenseEventTrapInfo.Uid) : null;
			long? curRaycastOrgan = this.CurRaycastOrgan;
			long? num2 = num;
			if (!(curRaycastOrgan.GetValueOrDefault() == num2.GetValueOrDefault() & curRaycastOrgan != null == (num2 != null)))
			{
				this.CurRaycastOrgan = num;
				if (num != null && num.Value != 0L)
				{
					Singleton<EventSystem>.Instance.Emit<int?>(EEventName.TowerDefenseRecycleRaycastNotify, (towerDefenseEventTrapInfo != null) ? new int?(towerDefenseEventTrapInfo.DeconstructReturn) : null);
				}
			}
		}

		// Token: 0x0401E07C RID: 123004
		private readonly Stat StepUpdateNotifyStat = Stat.Create("TowerDefenseEventController.StepUpdateNotify", "", "");

		// Token: 0x0401E07D RID: 123005
		private readonly Stat RaycastStateChangedStat = Stat.Create("TowerDefenseEventController.RaycastStateChanged", "", "");

		// Token: 0x0401E07E RID: 123006
		private long? CurRaycastOrgan;

		// Token: 0x0401E07F RID: 123007
		protected bool IsWorldInit;

		// Token: 0x0401E080 RID: 123008
		public bool TestBpUsing;

		// Token: 0x0401E081 RID: 123009
		private ETowerDefenseEventProcessStatus ProcessStatusInternal;

		// Token: 0x0401E082 RID: 123010
		private ETrapDefenseBuildTipsType BuildTipsTypeInternal;

		// Token: 0x0401E083 RID: 123011
		public readonly TowerDefenseEventEntityRedirectFilter EntityRedirectFilter = new TowerDefenseEventEntityRedirectFilter();

		// Token: 0x0401E084 RID: 123012
		private readonly TowerDefenseTrapTemplateInfo TrapTemplateInfo = new TowerDefenseTrapTemplateInfo();

		// Token: 0x0401E085 RID: 123013
		[Nullable(2)]
		private TsTowerDefenseEventActor PreviewTrapActor;

		// Token: 0x0401E086 RID: 123014
		[Nullable(2)]
		private TsTowerDefenseEventActor PrepareRemoveTrapActor;

		// Token: 0x0401E087 RID: 123015
		public readonly TowerDefenseEventRaycastResult RaycastResult = new TowerDefenseEventRaycastResult();

		// Token: 0x0401E088 RID: 123016
		private bool IsRaycast;

		// Token: 0x0401E089 RID: 123017
		private readonly TowerDefenseEventPreviewMonsterSpawner PreviewMonsterSpawner = new TowerDefenseEventPreviewMonsterSpawner();

		// Token: 0x0401E08A RID: 123018
		private long GoldNum;

		// Token: 0x0401E08B RID: 123019
		private int BattleWave;
	}
}
