using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.KuroSimpleCombat;
using CSharpScript.Game.Module.Gamepad;
using CSharpScript.Game.Module.Kurotato;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;
using UnrealEngine.Extension;

// Token: 0x02000F76 RID: 3958
[NullableContext(1)]
[Nullable(0)]
public class PotatoSubController : KscSubControllerBase
{
	// Token: 0x0600643E RID: 25662 RVA: 0x00191541 File Offset: 0x0018F741
	protected override void CreateModel()
	{
		this.SubModel = new PotatoSubModel();
	}

	// Token: 0x0600643F RID: 25663 RVA: 0x0019154E File Offset: 0x0018F74E
	public PotatoSubModel GetModel()
	{
		return (PotatoSubModel)this.SubModel;
	}

	// Token: 0x06006440 RID: 25664 RVA: 0x0019155B File Offset: 0x0018F75B
	public override bool IsTargetMap(int instSubType)
	{
		return instSubType == 51;
	}

	// Token: 0x06006441 RID: 25665 RVA: 0x00191564 File Offset: 0x0018F764
	protected override void InitConstVar()
	{
		base.InitConstVar();
		int activityId = ModelBase<KurotatoModel>.Instance.GetActivityId();
		KurotatoActivityConfig? kurotatoActivityConfig;
		float? num = (ConfigBase<KurotatoConfig>.Instance.GetActivityConfig(activityId) != null) ? new float?(kurotatoActivityConfig.GetValueOrDefault().DamageDefenseConst) : null;
		string command = StringUtils.Format("ksc.damage.defense.const {0}", new string[]
		{
			((num != null) ? num.GetValueOrDefault().ToString() : null) ?? "20"
		});
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, command, null);
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "fx.Niagara.SystemSimulation.AllowASync 0", null);
	}

	// Token: 0x06006442 RID: 25666 RVA: 0x00191610 File Offset: 0x0018F810
	protected override void OnInitMap()
	{
		FDamageConfig fdamageConfig = new FDamageConfig();
		fdamageConfig.PcFontSizeScale = 0.6f;
		fdamageConfig.MobileFontSizeScale = 0.9f;
		fdamageConfig.MaxDamagePerFrame = 1;
		ControllerBase<DamageUiController>.Instance.SetUeDamageConfig(fdamageConfig, true);
	}

	// Token: 0x06006443 RID: 25667 RVA: 0x0019164C File Offset: 0x0018F84C
	protected override void OnMapLoaded()
	{
		this.PreloadDodgeBuffAsync().Forget();
		this.InitBulletWorld();
		UBulletWorld kuroBulletWorld = ModelBase<BulletModel>.Instance.GetKuroBulletWorld();
		if (kuroBulletWorld != null)
		{
			KurotatoActivityConfig? activityConfig = ModelBase<KurotatoModel>.Instance.GetActivityConfig();
			if (activityConfig != null)
			{
				for (int i = 0; i < activityConfig.Value.BulletCountMaxLength; i++)
				{
					DicIntInt? dicIntInt = activityConfig.Value.BulletCountMax(i);
					if (dicIntInt != null)
					{
						kuroBulletWorld.SetBulletGroupMaxCountSingle(dicIntInt.Value.Key, dicIntInt.Value.Value);
					}
				}
				for (int j = 0; j < activityConfig.Value.CameraShakeLength; j++)
				{
					DicIntString? dicIntString = activityConfig.Value.CameraShake(j);
					if (dicIntString != null)
					{
						kuroBulletWorld.RegisterCameraShakeConfig(dicIntString.Value.Key, dicIntString.Value.Value);
					}
				}
				kuroBulletWorld.SetCameraShakeCooldown((double)activityConfig.Value.CameraShakeCd);
			}
			kuroBulletWorld.RegisterBulletActionClassByTag(GameplayTagUtils.GetGameplayTagById(GameplayTagDefine.EGameplayTagId["系统.活动.土豆.爆炸子弹"]).Value, UActionInitExplosionBulletPTT.StaticClass());
		}
		UDataTable udataTable = Singleton<ResourceSystem>.Instance.Load<UDataTable>(PotatoSubModel.BulletDtPath, "js_undefined");
		if (udataTable != null && udataTable.IsValid())
		{
			this.GetModel().BulletDataTable = udataTable;
		}
		else
		{
			Singleton<Log>.Instance.Error(ELogModule.SurvivorsRogue, ELogAuthor.HCW, "加载子弹DT失败", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		UBulletWorld kuroBulletWorld2 = ModelBase<BulletModel>.Instance.GetKuroBulletWorld();
		if (kuroBulletWorld2 != null && udataTable != null)
		{
			kuroBulletWorld2.AddCommonBulletDataTable(udataTable);
		}
		UKSC_World kscWorld = Singleton<KscEnv>.Instance.KscWorld;
		UDataAsset udataAsset = Singleton<ResourceSystem>.Instance.Load<UDataAsset>(PotatoSubModel.HitContextTextDaPath, "js_undefined");
		if (kscWorld != null && udataAsset != null)
		{
			kscWorld.SetHitContextTextData(udataAsset as UKSC_DA_HitContextText);
		}
	}

	// Token: 0x06006444 RID: 25668 RVA: 0x00191838 File Offset: 0x0018FA38
	protected override void OnWorldDone()
	{
		UBulletWorld kuroBulletWorld = ModelBase<BulletModel>.Instance.GetKuroBulletWorld();
		SceneTeamModel instance = ModelBase<SceneTeamModel>.Instance;
		EntityHandle entityHandle = (instance != null) ? instance.GetCurrentEntity : null;
		if (entityHandle != null && entityHandle.Valid)
		{
			FVectorDouble actorLocation = entityHandle.Entity.GetComponent<CharacterActorComponent>().ActorLocation;
			if (kuroBulletWorld != null)
			{
				kuroBulletWorld.EnableFlatGroundByAbovePoint(actorLocation);
			}
			this.PlayerEntityHandle = entityHandle;
			this.SkillCdComp = entityHandle.Entity.GetComponent<CharacterSkillCdComponent>();
			this.SkillComp = entityHandle.Entity.GetComponent<CharacterSkillComponent>();
		}
		else
		{
			KscLog.Warn(KscLog.EModule.Common, ELogAuthor.CFT, Singleton<KscEnv>.Instance.KscWorld, "Ksc找不到玩家角色,未设置地面坐标", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		this.Timer = TimerSystem.Instance.Forever(delegate(float delta)
		{
			this.SyncWeaponDamage();
			this.SyncGoldGrowth();
		}, 1000f, 1f, null, null, true);
	}

	// Token: 0x06006445 RID: 25669 RVA: 0x001918FC File Offset: 0x0018FAFC
	protected override void OnWorldReset()
	{
		if (this.Timer != null)
		{
			TimerSystem.Instance.Remove(this.Timer);
			this.Timer = null;
		}
		this.ClearBulletWorld();
		this.DodgeBuffDa = null;
		this.PlayerEntityHandle = null;
		this.SkillCdComp = null;
		this.SkillComp = null;
		this.WaveNum = 0;
	}

	// Token: 0x06006446 RID: 25670 RVA: 0x00191952 File Offset: 0x0018FB52
	protected override void OnClearMap()
	{
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "ksc.damage.defense.const 1520.0", null);
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "fx.Niagara.SystemSimulation.AllowASync 1", null);
	}

	// Token: 0x06006447 RID: 25671 RVA: 0x00191974 File Offset: 0x0018FB74
	protected override void AddEvents()
	{
		base.AddEvents();
		Singleton<EventSystem>.Instance.Add(EEventName.KurotatoOnWeaponUpdate, new Action(this.OnUpdateWeapon));
		Singleton<EventSystem>.Instance.Add<EKurotatoStep>(EEventName.KurotatoOnStepChanged, new Action<EKurotatoStep>(this.OnStepChanged));
	}

	// Token: 0x06006448 RID: 25672 RVA: 0x001919B4 File Offset: 0x0018FBB4
	protected override void RemoveEvents()
	{
		base.RemoveEvents();
		Singleton<EventSystem>.Instance.Remove(EEventName.KurotatoOnWeaponUpdate, new Action(this.OnUpdateWeapon));
		Singleton<EventSystem>.Instance.Remove<EKurotatoStep>(EEventName.KurotatoOnStepChanged, new Action<EKurotatoStep>(this.OnStepChanged));
	}

	// Token: 0x06006449 RID: 25673 RVA: 0x001919F4 File Offset: 0x0018FBF4
	public override void OnSystemInfoNotify()
	{
		KurotatoLevel? levelConfig = ConfigBase<KurotatoConfig>.Instance.GetLevelConfig(ModelBase<KurotatoModel>.Instance.GetCurLevelId());
		if (levelConfig != null)
		{
			UKSC_DA_WorldBoundsRound uksc_DA_WorldBoundsRound = UE.NewObject<UKSC_DA_WorldBoundsRound>(GlobalData.World, null, EObjectFlags.RF_NoFlags);
			uksc_DA_WorldBoundsRound.WorldRadius = levelConfig.Value.BoundRadius;
			float num = levelConfig.Value.BoundCenter(2);
			uksc_DA_WorldBoundsRound.WorldCenterOffset = new FVectorDouble((double)levelConfig.Value.BoundCenter(0), (double)levelConfig.Value.BoundCenter(1), (double)num);
			uksc_DA_WorldBoundsRound.GroundPositionZ = num;
			UKSC_World kscWorld = Singleton<KscEnv>.Instance.KscWorld;
			if (kscWorld == null)
			{
				return;
			}
			kscWorld.SetWorldBounds(uksc_DA_WorldBoundsRound);
		}
	}

	// Token: 0x0600644A RID: 25674 RVA: 0x00191A9D File Offset: 0x0018FC9D
	private void OnUpdateWeapon()
	{
		this.RefreshWeaponIndexInfo();
	}

	// Token: 0x0600644B RID: 25675 RVA: 0x00191AA8 File Offset: 0x0018FCA8
	private void OnStepChanged(EKurotatoStep step)
	{
		if (step == EKurotatoStep.WaveUpdate)
		{
			this.WaveNum++;
			UKSC_World kscWorld = Singleton<KscEnv>.Instance.KscWorld;
			if (kscWorld != null)
			{
				kscWorld.SetWorldAttr(EKSC_WorldAttrType.Wave, this.WaveNum);
			}
			this.ClearWeaponDamage();
			this.NeedBroadcastPlayerOneHp = ModelBase<KurotatoModel>.Instance.GetIsSpecialWave();
			if (this.NeedBroadcastPlayerOneHp)
			{
				KscLog.Debug(KscLog.EModule.Common, ELogAuthor.CFT, Singleton<KscEnv>.Instance.KscWorld, "Potato 进入隐藏Boss关", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		}
	}

	// Token: 0x0600644C RID: 25676 RVA: 0x00191B24 File Offset: 0x0018FD24
	public unsafe override void OnEntityRemoved(KscRemoveContext context, Dictionary<long, SimpleCombatEntityDieContext> protoContexts)
	{
		int? logicProxy = base.Model.GetLogicProxy(context.CreatureDataId);
		foreach (KeyValuePair<int, AKSC_Entity> keyValuePair in this.GetModel().WeaponKscEntityMap)
		{
			int entityId_ = keyValuePair.Value.EntityId_;
			int? num = logicProxy;
			if (entityId_ == num.GetValueOrDefault() & num != null)
			{
				this.GetModel().WeaponKscEntityMap.Remove(keyValuePair.Key);
				break;
			}
		}
		this.GetModel().DamageMap.Remove(context.CreatureDataId);
		IPotatoCombatInfo entity = this.GetModel().GetEntity(context.CreatureDataId);
		if (entity == null)
		{
			return;
		}
		if (entity.EntityType == EPotatoEntityType.Monster)
		{
			IPotatoActivityEntityInfo potatoActivityEntityInfo = (IPotatoActivityEntityInfo)entity;
			this.NotifyMonsterUpdate(potatoActivityEntityInfo.ConfigId, logicProxy.Value, false);
		}
		else if (entity.EntityType == EPotatoEntityType.Structure)
		{
			IPotatoActivityEntityInfo potatoActivityEntityInfo2 = (IPotatoActivityEntityInfo)entity;
			this.NotifyStructureUpdate(potatoActivityEntityInfo2.ConfigId, logicProxy.Value, false);
		}
		SimpleCombatEntityDieContext simpleCombatEntityDieContext = SimpleCombatEntityDieContext.Create();
		Aki.Protocol.Vector vector = Aki.Protocol.Vector.Create();
		vector.X = (float)context.Location.X;
		vector.Y = (float)context.Location.Y;
		vector.Z = (float)context.Location.Z;
		simpleCombatEntityDieContext.DiePos = vector;
		FName? dynamicFName = FNameUtil.GetDynamicFName(context.ReasonName.ToString());
		if (dynamicFName == KscEntityRemoveReason.Dead)
		{
			if (entity.EntityType == EPotatoEntityType.PlayerCharacter)
			{
				KurotatoRoleKilledCtxPb kurotatoRoleKilledCtxPb = KurotatoRoleKilledCtxPb.Create();
				simpleCombatEntityDieContext.KurotatoRoleKilledCtxPb = kurotatoRoleKilledCtxPb;
				this.PlayPlayerDeathForceFeedback();
				this.RemoveAllMonsterNextFrame();
			}
			else if (entity.EntityType == EPotatoEntityType.Structure)
			{
				KurotatoStructureKilledCtxPb kurotatoStructureKilledCtxPb = KurotatoStructureKilledCtxPb.Create();
				simpleCombatEntityDieContext.KurotatoStructureKilledCtxPb = kurotatoStructureKilledCtxPb;
			}
			else
			{
				KurotatoMonsterKilledCtxPb kurotatoMonsterKilledCtxPb = KurotatoMonsterKilledCtxPb.Create();
				kurotatoMonsterKilledCtxPb.EntityId = context.KillerId;
				simpleCombatEntityDieContext.KurotatoMonsterKilledCtxPb = kurotatoMonsterKilledCtxPb;
			}
		}
		else
		{
			if (!(dynamicFName == KscEntityRemoveReason.Coin))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.TowerDefenseEvent;
				ELogAuthor author = ELogAuthor.HCW;
				string message = "移除Potato实体失败: 未处理移除原因";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("creatureDataId", context.CreatureDataId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("reasonName", context.ReasonName);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			KurotatoDropAbsorbedCtxPb kurotatoDropAbsorbedCtxPb = KurotatoDropAbsorbedCtxPb.Create();
			simpleCombatEntityDieContext.KurotatoDropAbsorbedCtxPb = kurotatoDropAbsorbedCtxPb;
		}
		protoContexts[context.CreatureDataId] = simpleCombatEntityDieContext;
	}

	// Token: 0x0600644D RID: 25677 RVA: 0x00191DE0 File Offset: 0x0018FFE0
	private void RemoveAllMonsterNextFrame()
	{
		TimerSystem.Instance.Next(delegate(float _)
		{
			KscLog.Debug(KscLog.EModule.Common, ELogAuthor.HCW, Singleton<KscEnv>.Instance.KscWorld, "角色死亡清理所有实体", default(ReadOnlySpan<ValueTuple<string, object>>));
			List<IPotatoCombatInfo> list = new List<IPotatoCombatInfo>();
			this.GetModel().GetAllEntities(list);
			foreach (IPotatoCombatInfo potatoCombatInfo in list)
			{
				if (potatoCombatInfo.EntityType == EPotatoEntityType.Monster)
				{
					ControllerBase<KuroSimpleCombatController>.Instance.RemoveEntityByReasonType((long)potatoCombatInfo.Uid, EKscEntityRemoveReasonType.Dead);
				}
				else if (potatoCombatInfo.EntityType == EPotatoEntityType.GoldenCoin || potatoCombatInfo.EntityType == EPotatoEntityType.Weapon || potatoCombatInfo.EntityType == EPotatoEntityType.Structure)
				{
					ControllerBase<KuroSimpleCombatController>.Instance.RemoveEntityByReasonType((long)potatoCombatInfo.Uid, EKscEntityRemoveReasonType.Destroy);
				}
			}
		}, null, null);
	}

	// Token: 0x0600644E RID: 25678 RVA: 0x00191DFC File Offset: 0x0018FFFC
	private void PlayPlayerDeathForceFeedback()
	{
		if (!Singleton<Info>.Instance.IsInGamepad())
		{
			return;
		}
		Singleton<ResourceSystem>.Instance.LoadAsync<UKuroForceFeedbackEffect>("/Game/Aki/Data/SimpleCombat/3_4Potato/Player/PlayerDeath_ForceFeedback.PlayerDeath_ForceFeedback", delegate([Nullable(2)] UKuroForceFeedbackEffect effect, string loadPath)
		{
			if (effect != null)
			{
				ControllerBase<GamepadController>.Instance.PlayKuroForceFeedback(effect, null, false, false, false, "PotatoPlayerDeath");
			}
		}, 100, "js_undefined");
	}

	// Token: 0x0600644F RID: 25679 RVA: 0x00191E4C File Offset: 0x0019004C
	protected override void CreateEntityFilter()
	{
		this.RedirectFilter = this.EntityRedirectFilter;
	}

	// Token: 0x06006450 RID: 25680 RVA: 0x00191E5A File Offset: 0x0019005A
	[NullableContext(2)]
	protected override EntityHandle GetPossessedPlayerEntity()
	{
		return this.PlayerEntityHandle;
	}

	// Token: 0x06006451 RID: 25681 RVA: 0x00191E64 File Offset: 0x00190064
	protected override bool AddInputLayer()
	{
		PotatoInputLayer potatoInputLayer = this.GetInputLayer();
		if (potatoInputLayer != null)
		{
			this.RemoveInputLayer();
		}
		potatoInputLayer = (ControllerBase<InputController>.Instance.CreateInputLayer(EInputLayer.Potato) as PotatoInputLayer);
		if (potatoInputLayer != null)
		{
			EntityHandle possessedPlayerEntity = this.GetPossessedPlayerEntity();
			if (possessedPlayerEntity != null)
			{
				ControllerBase<InputController>.Instance.AddInputLayer(possessedPlayerEntity.Id, potatoInputLayer);
			}
			else
			{
				KscLog.Error(KscLog.EModule.Input, ELogAuthor.HCW, Singleton<KscEnv>.Instance.KscWorld, "Potato输入层加入异常,无法绑定实体", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return true;
		}
		KscLog.Error(KscLog.EModule.Input, ELogAuthor.HCW, Singleton<KscEnv>.Instance.KscWorld, "Potato输入层加入异常", default(ReadOnlySpan<ValueTuple<string, object>>));
		return false;
	}

	// Token: 0x06006452 RID: 25682 RVA: 0x00191EF8 File Offset: 0x001900F8
	protected override bool RemoveInputLayer()
	{
		PotatoInputLayer inputLayer = this.GetInputLayer();
		if (inputLayer != null)
		{
			ControllerBase<InputController>.Instance.RemoveInputLayer(inputLayer);
			inputLayer.Clear();
			return true;
		}
		KscLog.Error(KscLog.EModule.Input, ELogAuthor.HCW, Singleton<KscEnv>.Instance.KscWorld, "Potato输入层移除异常", default(ReadOnlySpan<ValueTuple<string, object>>));
		return false;
	}

	// Token: 0x06006453 RID: 25683 RVA: 0x00191F44 File Offset: 0x00190144
	[NullableContext(2)]
	private PotatoInputLayer GetInputLayer()
	{
		EntityHandle possessedPlayerEntity = this.GetPossessedPlayerEntity();
		if (possessedPlayerEntity != null)
		{
			return ControllerBase<InputController>.Instance.GetInputLayer(possessedPlayerEntity.Id, EInputLayer.Potato) as PotatoInputLayer;
		}
		return null;
	}

	// Token: 0x06006454 RID: 25684 RVA: 0x00191F74 File Offset: 0x00190174
	protected override void AddKscPlayerEntity()
	{
		this.AddInputLayer();
	}

	// Token: 0x06006455 RID: 25685 RVA: 0x00191F7D File Offset: 0x0019017D
	public override void OnPlayerEntityCreated()
	{
		base.OnPlayerEntityCreated();
		PotatoSubModel model = this.GetModel();
		AKSC_Entity kscPlayerEntity = model.KscPlayerEntity;
		model.KscPlayerEntityId = ((kscPlayerEntity != null) ? kscPlayerEntity.EntityId_ : 0);
	}

	// Token: 0x06006456 RID: 25686 RVA: 0x00191FA4 File Offset: 0x001901A4
	protected override void SyncPlayerTransform()
	{
		if (this.GetModel().KscPlayerEntity == null)
		{
			return;
		}
		EntityHandle playerEntityHandle = this.PlayerEntityHandle;
		if (playerEntityHandle == null || !playerEntityHandle.Valid)
		{
			return;
		}
		FTransformDouble ftransformDouble = this.PlayerEntityHandle.Entity.GetComponent<CharacterActorComponent>().Actor.D_GetTransform();
		AKSC_Entity kscPlayerEntity = this.GetModel().KscPlayerEntity;
		if (kscPlayerEntity == null)
		{
			return;
		}
		kscPlayerEntity.SetTransformByWorld(ftransformDouble);
	}

	// Token: 0x06006457 RID: 25687 RVA: 0x00192009 File Offset: 0x00190209
	public void OnWeaponCreated(AKSC_Entity kscEntity, int incId)
	{
		this.GetModel().WeaponKscEntityMap[incId] = kscEntity;
		this.OnSummonedCreated(kscEntity, true);
	}

	// Token: 0x06006458 RID: 25688 RVA: 0x00192028 File Offset: 0x00190228
	public void OnSummonedCreated(AKSC_Entity kscEntity, bool isWeapon = false)
	{
		PotatoSubModel model = this.GetModel();
		if (model.KscPlayerEntity == null)
		{
			KscLog.Error(KscLog.EModule.Load, ELogAuthor.CFT, kscEntity, "设置武器主人时玩家还未创建", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		UKSC_Move_Around uksc_Move_Around = kscEntity.GetMoveComponent() as UKSC_Move_Around;
		if (uksc_Move_Around != null)
		{
			uksc_Move_Around.SetAroundTarget(model.KscPlayerEntity);
		}
		if (isWeapon)
		{
			this.RefreshWeaponIndexInfo();
		}
	}

	// Token: 0x06006459 RID: 25689 RVA: 0x00192080 File Offset: 0x00190280
	private void RefreshWeaponIndexInfo()
	{
		PotatoSubModel model = this.GetModel();
		List<IKurotatoWeaponData> holdWeaponData = ModelBase<KurotatoModel>.Instance.GetHoldWeaponData();
		List<AKSC_Entity> list = new List<AKSC_Entity>();
		foreach (IKurotatoWeaponData kurotatoWeaponData in holdWeaponData)
		{
			AKSC_Entity item;
			if (model.WeaponKscEntityMap.TryGetValue(kurotatoWeaponData.IncId, out item))
			{
				list.Add(item);
			}
		}
		int count = list.Count;
		if (count <= 0)
		{
			return;
		}
		for (int i = 0; i < count; i++)
		{
			UKSC_Move_Around uksc_Move_Around = list[i].GetMoveComponent() as UKSC_Move_Around;
			if (uksc_Move_Around != null)
			{
				uksc_Move_Around.SetIndexInfo(count, i);
			}
		}
	}

	// Token: 0x0600645A RID: 25690 RVA: 0x0019213C File Offset: 0x0019033C
	protected override void OnHandlePlayerHeadHpInfo(KscHeadStateData kscPlayerHeadStateData, FKSC_HeadHpContext headInfo)
	{
		base.OnHandlePlayerHeadHpInfo(kscPlayerHeadStateData, headInfo);
		if (this.NeedBroadcastPlayerOneHp && kscPlayerHeadStateData.Hp <= 1)
		{
			this.NeedBroadcastPlayerOneHp = false;
			KscLog.Debug(KscLog.EModule.Common, ELogAuthor.CFT, Singleton<KscEnv>.Instance.KscWorld, "Potato 广播玩家剩1血事件", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<EventSystem>.Instance.Emit(EEventName.KurotatoPlayerOneHpLeft);
		}
	}

	// Token: 0x0600645B RID: 25691 RVA: 0x0019219C File Offset: 0x0019039C
	public override void GmPrintInfo()
	{
		PotatoSubModel model = this.GetModel();
		List<string> list = new List<string>
		{
			"[ksc]Potato玩法"
		};
		List<string> list2 = list;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 2);
		defaultInterpolatedStringHandler.AppendLiteral("玩家 EntityId:");
		defaultInterpolatedStringHandler.AppendFormatted<int>(model.KscPlayerEntityId);
		defaultInterpolatedStringHandler.AppendLiteral(", 服务端Id:");
		defaultInterpolatedStringHandler.AppendFormatted<long>(model.KscPlayerCreatureDataId);
		list2.Add(defaultInterpolatedStringHandler.ToStringAndClear());
		foreach (AKSC_Entity aksc_Entity in model.WeaponKscEntityMap.Values)
		{
			int entityId_ = aksc_Entity.EntityId_;
			List<string> list3 = list;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 2);
			defaultInterpolatedStringHandler.AppendLiteral("武器 EntityId:");
			defaultInterpolatedStringHandler.AppendFormatted<int>(entityId_);
			defaultInterpolatedStringHandler.AppendLiteral(", 服务端Id:");
			defaultInterpolatedStringHandler.AppendFormatted<long>(model.GetEntityCreatureId(entityId_));
			list3.Add(defaultInterpolatedStringHandler.ToStringAndClear());
		}
		list.Add("-------------------");
		string text = string.Join("\n", list);
		KscLog.Debug(KscLog.EModule.Common, ELogAuthor.HCW, null, text, default(ReadOnlySpan<ValueTuple<string, object>>));
		if (!UKuroStaticLibrary.IsEditor(GlobalData.World))
		{
			return;
		}
		UWorld world = GlobalData.World.GetWorld();
		if (world != null)
		{
			UKismetSystemLibrary.PrintString(world, text, true, false, new FLinearColor?(new FLinearColor(0f, 0.66f, 1f, 1f)), 10f);
		}
	}

	// Token: 0x0600645C RID: 25692 RVA: 0x00192310 File Offset: 0x00190510
	public override void InitDamageConfigs()
	{
		UKSC_World kscWorld = Singleton<KscEnv>.Instance.KscWorld;
		if (kscWorld == null)
		{
			KscLog.Error(KscLog.EModule.Load, ELogAuthor.HCW, Singleton<KscEnv>.Instance.KscWorld, "Potato InitDamageIdConfig failed", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		UKSC_DamageId damageData = kscWorld.DamageData;
		if (damageData == null || !damageData.IsValid())
		{
			KscLog.Error(KscLog.EModule.Load, ELogAuthor.HCW, Singleton<KscEnv>.Instance.KscWorld, "Potato InitDamageIdConfig failed", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		KscLog.Debug(KscLog.EModule.Load, ELogAuthor.HCW, Singleton<KscEnv>.Instance.KscWorld, "Potato InitDamageIdConfig", default(ReadOnlySpan<ValueTuple<string, object>>));
		IReadOnlyList<KSCDamage> configList = ConfigKSCDamageByKscGameplayType.GetConfigList((int)base.Model.GameplayType, true);
		if (configList == null)
		{
			return;
		}
		foreach (KSCDamage kscdamage in configList)
		{
			if (kscdamage.CalculateType == 6)
			{
				FKSCDamage fkscdamage = new FKSCDamage();
				fkscdamage.DamageID = (int)kscdamage.Id;
				fkscdamage.Knocked = kscdamage.Knocked;
				fkscdamage.CalculateType = (EKSC_CalculateType)kscdamage.CalculateType;
				fkscdamage.Element = (EKSC_Element)kscdamage.Element;
				fkscdamage.CritAttrType = (EKSC_AttrType)kscdamage.CritAttrType;
				if (kscdamage.Amplify > 0)
				{
					fkscdamage.RelatedInfos.Add(new FKSCDamageRelated((float)kscdamage.Amplify * 0.0001f, (EKSC_AttrType)kscdamage.RelatedProperty, (EKSC_AttrType)kscdamage.MainDamageType, (EKSC_AttrType)kscdamage.SubDamageType));
				}
				if (kscdamage.Amplify1 > 0)
				{
					fkscdamage.RelatedInfos.Add(new FKSCDamageRelated((float)kscdamage.Amplify1 * 0.0001f, (EKSC_AttrType)kscdamage.RelatedProperty1, (EKSC_AttrType)kscdamage.MainDamageType1, (EKSC_AttrType)kscdamage.SubDamageType1));
				}
				if (kscdamage.Amplify2 > 0)
				{
					fkscdamage.RelatedInfos.Add(new FKSCDamageRelated((float)kscdamage.Amplify2 * 0.0001f, (EKSC_AttrType)kscdamage.RelatedProperty2, (EKSC_AttrType)kscdamage.MainDamageType2, (EKSC_AttrType)kscdamage.SubDamageType2));
				}
				if (kscdamage.Amplify3 > 0)
				{
					fkscdamage.RelatedInfos.Add(new FKSCDamageRelated((float)kscdamage.Amplify3 * 0.0001f, (EKSC_AttrType)kscdamage.RelatedProperty3, (EKSC_AttrType)kscdamage.MainDamageType3, (EKSC_AttrType)kscdamage.SubDamageType3));
				}
				damageData.AddDamageData((int)kscdamage.Id, fkscdamage);
			}
			else
			{
				FKSCDamage fkscdamage2 = new FKSCDamage();
				fkscdamage2.DamageID = (int)kscdamage.Id;
				fkscdamage2.CalculateType = (EKSC_CalculateType)kscdamage.CalculateType;
				fkscdamage2.Element = (EKSC_Element)kscdamage.Element;
				fkscdamage2.Amplify = (float)kscdamage.Amplify * 0.0001f;
				fkscdamage2.RelatedProperty = (EKSC_AttrType)kscdamage.RelatedProperty;
				if (kscdamage.CalculateType == 8)
				{
					fkscdamage2.RelatedInfos.Add(new FKSCDamageRelated(0f, EKSC_AttrType.EAttributeType_None, (EKSC_AttrType)kscdamage.MainDamageType, EKSC_AttrType.EAttributeType_None));
				}
				fkscdamage2.CritAttrType = (EKSC_AttrType)kscdamage.CritAttrType;
				damageData.AddDamageData((int)kscdamage.Id, fkscdamage2);
			}
		}
	}

	// Token: 0x0600645D RID: 25693 RVA: 0x0019261C File Offset: 0x0019081C
	public unsafe override void SetAttrs(AKSC_Entity entity, int propertyId, [Nullable(2)] Dictionary<int, int> attributeMap = null)
	{
		if (entity == null)
		{
			KscLog.EModule flag = KscLog.EModule.Attr;
			ELogAuthor author = ELogAuthor.CFT;
			UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
			string log = "Potato属性设置失败:异常Entity";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("propertyId", propertyId);
			KscLog.Warn(flag, author, kscWorld, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		if (Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
		{
			KscLog.EModule flag2 = KscLog.EModule.Attr;
			ELogAuthor author2 = ELogAuthor.HCW;
			UObject kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
			string log2 = "Potato 属性设置成功";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("entityId", entity.EntityId_);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("propertyId", propertyId);
			KscLog.Debug(flag2, author2, kscWorld2, log2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		KscSubModelBase subModel = this.SubModel;
		KscEntityHandle kscEntityHandle2;
		KscEntityHandle kscEntityHandle = (subModel != null && subModel.KscEntities.TryGetValue(entity.EntityId_, out kscEntityHandle2)) ? kscEntityHandle2 : null;
		if (attributeMap == null || kscEntityHandle == null)
		{
			KscLog.EModule flag3 = KscLog.EModule.Attr;
			ELogAuthor author3 = ELogAuthor.HCW;
			UObject kscWorld3 = Singleton<KscEnv>.Instance.KscWorld;
			string log3 = "属性没有下发";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("entityId", entity.EntityId_);
			KscLog.Error(flag3, author3, kscWorld3, log3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return;
		}
		int num2;
		int num = Math.Max(1, attributeMap.TryGetValue(2, out num2) ? num2 : 0);
		UKSC_SkillComp skillComp = entity.GetSkillComp();
		if (skillComp != null)
		{
			UKSC_AttrSet attrSet_ = skillComp.AttrSet_;
			if (attrSet_ != null)
			{
				TMap<EKSC_AttrType, int> attrs_ = attrSet_.Attrs_;
				if (attrs_ != null)
				{
					attrs_.Empty(0);
				}
			}
		}
		foreach (KeyValuePair<int, int> keyValuePair in attributeMap)
		{
			EKSC_AttrType eksc_AttrType = (EKSC_AttrType)keyValuePair.Key;
			int num3 = keyValuePair.Value;
			if (eksc_AttrType == EKSC_AttrType.LifeMax)
			{
				num3 = num;
				kscEntityHandle.SetAttr(eksc_AttrType, num3);
			}
			else if (eksc_AttrType == EKSC_AttrType.Life)
			{
				num3 = Math.Min(num, num3);
			}
			else
			{
				kscEntityHandle.SetAttr(eksc_AttrType, num3);
			}
			entity.SetAttr(eksc_AttrType, num3);
		}
	}

	// Token: 0x0600645E RID: 25694 RVA: 0x001927F8 File Offset: 0x001909F8
	private void ClearWeaponDamage()
	{
		foreach (AKSC_Entity aksc_Entity in this.GetModel().WeaponKscEntityMap.Values)
		{
			aksc_Entity.SetAttr(EKSC_AttrType.AccumulatedDamage, 0);
		}
	}

	// Token: 0x0600645F RID: 25695 RVA: 0x00192858 File Offset: 0x00190A58
	private void SyncWeaponDamage()
	{
		Dictionary<long, int> dictionary = new Dictionary<long, int>();
		bool flag = false;
		foreach (KeyValuePair<long, int> keyValuePair in this.GetModel().DamageMap)
		{
			long key = keyValuePair.Key;
			int value = keyValuePair.Value;
			KscEntityHandle kscEntityHandle = this.GetModel().GetKscEntityHandle(key);
			if (kscEntityHandle != null && kscEntityHandle.Valid)
			{
				AKSC_Entity kscEntity = kscEntityHandle.KscEntity;
				TMap<EKSC_AttrType, int> tmap;
				if (kscEntity == null)
				{
					tmap = null;
				}
				else
				{
					UKSC_SkillComp skillComp = kscEntity.GetSkillComp();
					if (skillComp == null)
					{
						tmap = null;
					}
					else
					{
						UKSC_AttrSet attrSet_ = skillComp.AttrSet_;
						tmap = ((attrSet_ != null) ? attrSet_.Attrs_ : null);
					}
				}
				TMap<EKSC_AttrType, int> tmap2 = tmap;
				if (tmap2 != null)
				{
					int valueOrDefault = tmap2.GetValueOrDefault(EKSC_AttrType.AccumulatedDamage, 0);
					if (valueOrDefault != value)
					{
						this.GetModel().DamageMap[key] = valueOrDefault;
						dictionary[key] = valueOrDefault;
						flag = true;
					}
				}
			}
		}
		if (flag)
		{
			KurotatoSyncEntityDealDamagePush kurotatoSyncEntityDealDamagePush = KurotatoSyncEntityDealDamagePush.Create();
			foreach (KeyValuePair<long, int> keyValuePair2 in dictionary)
			{
				kurotatoSyncEntityDealDamagePush.EntityDealDamages.Add(keyValuePair2.Key, keyValuePair2.Value);
			}
			Singleton<Net>.Instance.Send(EPushMessageId.KurotatoSyncEntityDealDamagePush, kurotatoSyncEntityDealDamagePush);
		}
	}

	// Token: 0x06006460 RID: 25696 RVA: 0x001929C0 File Offset: 0x00190BC0
	private void SyncGoldGrowth()
	{
		UKSC_World kscWorld = Singleton<KscEnv>.Instance.KscWorld;
		int num = (kscWorld != null) ? kscWorld.GetWorldAttr(EKSC_WorldAttrType.GoldGrowth) : 0;
		if (num > 0)
		{
			UKSC_World kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
			if (kscWorld2 != null)
			{
				kscWorld2.SetWorldAttr(EKSC_WorldAttrType.GoldGrowth, 0);
			}
			ControllerBase<KurotatoController>.Instance.RequestKurotatoGoldAdd(num).Forget<bool>();
		}
	}

	// Token: 0x06006461 RID: 25697 RVA: 0x00192A12 File Offset: 0x00190C12
	protected override void PushPlayerHp()
	{
	}

	// Token: 0x06006462 RID: 25698 RVA: 0x00192A14 File Offset: 0x00190C14
	public void NotifyMonsterUpdate(int configId, int kscEntityId, bool isAdd)
	{
		if (ConfigBase<KurotatoConfig>.Instance.GetMonsterRiskType(configId) == 3)
		{
			Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.KurotatoBossTrackedMarkerUpdate, kscEntityId, isAdd);
		}
	}

	// Token: 0x06006463 RID: 25699 RVA: 0x00192A38 File Offset: 0x00190C38
	public void NotifyStructureUpdate(int configId, int kscEntityId, bool isAdd)
	{
		KurotatoStructure? structureConfigById = ConfigBase<KurotatoConfig>.Instance.GetStructureConfigById(configId);
		if (structureConfigById == null)
		{
			return;
		}
		if (structureConfigById.Value.Type == "Tree")
		{
			Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.KurotatoTreasureBoxTrackedMarkerUpdate, kscEntityId, isAdd);
		}
	}

	// Token: 0x06006464 RID: 25700 RVA: 0x00192A88 File Offset: 0x00190C88
	public void ExecSkillDodge()
	{
		AKSC_Entity kscPlayerEntity = this.SubModel.KscPlayerEntity;
		if (kscPlayerEntity == null)
		{
			return;
		}
		if (this.SkillCdComp == null || this.SkillComp == null)
		{
			return;
		}
		if (this.DodgeBuffDa == null)
		{
			KscLog.Error(KscLog.EModule.Common, ELogAuthor.HCW, null, "ExecSkillDodge: DodgeBuffDa未预加载", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		int skillId = 700105;
		if (this.SkillCdComp.IsSkillInCd(skillId, true))
		{
			return;
		}
		this.SkillComp.BeginSkillAsync(skillId, null).Forget<bool>();
		kscPlayerEntity.ApplyBuffSelf(this.DodgeBuffDa);
	}

	// Token: 0x06006465 RID: 25701 RVA: 0x00192B0C File Offset: 0x00190D0C
	private UniTask PreloadDodgeBuffAsync()
	{
		PotatoSubController.<PreloadDodgeBuffAsync>d__50 <PreloadDodgeBuffAsync>d__;
		<PreloadDodgeBuffAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PreloadDodgeBuffAsync>d__.<>4__this = this;
		<PreloadDodgeBuffAsync>d__.<>1__state = -1;
		<PreloadDodgeBuffAsync>d__.<>t__builder.Start<PotatoSubController.<PreloadDodgeBuffAsync>d__50>(ref <PreloadDodgeBuffAsync>d__);
		return <PreloadDodgeBuffAsync>d__.<>t__builder.Task;
	}

	// Token: 0x04002FE0 RID: 12256
	public const int MULTI_RELATED_DAMAGE = 6;

	// Token: 0x04002FE1 RID: 12257
	public const int ITEM_HEAL = 8;

	// Token: 0x04002FE2 RID: 12258
	private const string PLAYER_DEATH_FORCE_FEEDBACK_PATH = "/Game/Aki/Data/SimpleCombat/3_4Potato/Player/PlayerDeath_ForceFeedback.PlayerDeath_ForceFeedback";

	// Token: 0x04002FE3 RID: 12259
	[Nullable(2)]
	private EntityHandle PlayerEntityHandle;

	// Token: 0x04002FE4 RID: 12260
	private int WaveNum;

	// Token: 0x04002FE5 RID: 12261
	private readonly PotatoEntityRedirectFilter EntityRedirectFilter = new PotatoEntityRedirectFilter();

	// Token: 0x04002FE6 RID: 12262
	[Nullable(2)]
	private TimerHandle Timer;

	// Token: 0x04002FE7 RID: 12263
	private bool NeedBroadcastPlayerOneHp;

	// Token: 0x04002FE8 RID: 12264
	[Nullable(2)]
	private CharacterSkillCdComponent SkillCdComp;

	// Token: 0x04002FE9 RID: 12265
	[Nullable(2)]
	private CharacterSkillComponent SkillComp;

	// Token: 0x04002FEA RID: 12266
	[Nullable(2)]
	private UKSC_DA_Buff DodgeBuffDa;
}
