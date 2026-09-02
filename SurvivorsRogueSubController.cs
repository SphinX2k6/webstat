using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.KuroSimpleCombat;
using UnrealEngine;
using UnrealEngine.Extension;

// Token: 0x02000F89 RID: 3977
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsRogueSubController : KscSubControllerBase
{
	// Token: 0x0600650A RID: 25866 RVA: 0x001942AD File Offset: 0x001924AD
	protected override void CreateModel()
	{
		this.SubModel = new SurvivorsRogueSubModel();
	}

	// Token: 0x0600650B RID: 25867 RVA: 0x001942BA File Offset: 0x001924BA
	public SurvivorsRogueSubModel GetModel()
	{
		return (SurvivorsRogueSubModel)this.SubModel;
	}

	// Token: 0x0600650C RID: 25868 RVA: 0x001942C7 File Offset: 0x001924C7
	public override bool IsTargetMap(int instSubType)
	{
		return instSubType == 41;
	}

	// Token: 0x0600650D RID: 25869 RVA: 0x001942D0 File Offset: 0x001924D0
	protected override void OnInitMap()
	{
		FDamageConfig fdamageConfig = new FDamageConfig();
		fdamageConfig.PcFontSizeScale = 0.6f;
		fdamageConfig.MobileFontSizeScale = 0.9f;
		fdamageConfig.MaxDamagePerFrame = 1;
		ControllerBase<DamageUiController>.Instance.SetUeDamageConfig(fdamageConfig, true);
	}

	// Token: 0x0600650E RID: 25870 RVA: 0x0019430C File Offset: 0x0019250C
	protected override void OnMapLoaded()
	{
		this.InitBulletWorld();
		UDataTable udataTable = Singleton<ResourceSystem>.Instance.Load<UDataTable>(SurvivorsRogueSubModel.BulletDtPath, "js_undefined");
		if (udataTable != null && udataTable.IsValid())
		{
			this.GetModel().BulletDataTable = udataTable;
		}
		else
		{
			Singleton<Log>.Instance.Error(ELogModule.SurvivorsRogue, ELogAuthor.CFT, "加载子弹DT失败", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		UBulletWorld kuroBulletWorld = ModelBase<BulletModel>.Instance.GetKuroBulletWorld();
		if (kuroBulletWorld != null && udataTable != null)
		{
			kuroBulletWorld.AddCommonBulletDataTable(udataTable);
		}
		this.AddTreeListener();
	}

	// Token: 0x0600650F RID: 25871 RVA: 0x0019438C File Offset: 0x0019258C
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
		this.PlayerHpHandle.Init(null, null, null, null);
		KscHeadStateData kscPlayerHeadStateData = this.GetModel().KscPlayerHeadStateData;
		if (kscPlayerHeadStateData != null)
		{
			this.PlayerHpHandle.OnPlayerHpChange(kscPlayerHeadStateData);
		}
	}

	// Token: 0x06006510 RID: 25872 RVA: 0x00194476 File Offset: 0x00192676
	protected override void OnWorldReset()
	{
		this.ClearBulletWorld();
		this.PlayerEntityHandle = null;
		this.SkillCdComp = null;
		this.RemoveTreeListener();
		this.PlayerHpHandle.Clear();
	}

	// Token: 0x06006511 RID: 25873 RVA: 0x001944A0 File Offset: 0x001926A0
	public unsafe override void OnEntityRemoved(KscRemoveContext context, Dictionary<long, SimpleCombatEntityDieContext> protoContexts)
	{
		int? logicProxy = base.Model.GetLogicProxy(context.CreatureDataId);
		List<AKSC_Entity> weaponKscEntities = this.GetModel().WeaponKscEntities;
		for (int i = 0; i < weaponKscEntities.Count; i++)
		{
			int entityId_ = weaponKscEntities[i].EntityId_;
			int? num = logicProxy;
			if (entityId_ == num.GetValueOrDefault() & num != null)
			{
				weaponKscEntities.RemoveAt(i);
				break;
			}
		}
		ISurvivorsRogueCombatInfo entity = this.GetModel().GetEntity(context.CreatureDataId);
		if (entity == null)
		{
			return;
		}
		if (entity.EntityType == ESurvivorsRogueEntityType.Monster && ConfigBase<SurvivorsRogueConfig>.Instance.IsBoss(entity.TemplateId))
		{
			Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.SurvivorsRogueBossTrackedMarkerUpdate, logicProxy.Value, false);
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
			if (entity.EntityType == ESurvivorsRogueEntityType.PlayerCharacter)
			{
				SurvivorsRoleKilledCtxPb survivorsRoleKilledCtx = SurvivorsRoleKilledCtxPb.Create();
				simpleCombatEntityDieContext.SurvivorsRoleKilledCtx = survivorsRoleKilledCtx;
				this.RemoveAllMonsterNextFrame();
			}
			else
			{
				SurvivorsMonsterKilledCtxPb survivorsMonsterKilledCtxPb = SurvivorsMonsterKilledCtxPb.Create();
				survivorsMonsterKilledCtxPb.EntityId = context.KillerId;
				simpleCombatEntityDieContext.SurvivorsMonsterKilledCtx = survivorsMonsterKilledCtxPb;
			}
		}
		else
		{
			if (!(dynamicFName == KscEntityRemoveReason.Coin))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.TowerDefenseEvent;
				ELogAuthor author = ELogAuthor.XY;
				string message = "移除幸存者实体失败: 未处理移除原因";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("creatureDataId", context.CreatureDataId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("reasonName", context.ReasonName);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			SurvivorsGoldenCoinAbosorbedCtxPb survivorsGoldenCoinAbosorbedCtx = SurvivorsGoldenCoinAbosorbedCtxPb.Create();
			simpleCombatEntityDieContext.SurvivorsGoldenCoinAbosorbedCtx = survivorsGoldenCoinAbosorbedCtx;
		}
		protoContexts[context.CreatureDataId] = simpleCombatEntityDieContext;
	}

	// Token: 0x06006512 RID: 25874 RVA: 0x001946D7 File Offset: 0x001928D7
	private void RemoveAllMonsterNextFrame()
	{
		TimerSystem.Instance.Next(delegate(float _)
		{
			KscLog.Debug(KscLog.EModule.Common, ELogAuthor.CFT, Singleton<KscEnv>.Instance.KscWorld, "角色死亡清理所有实体", default(ReadOnlySpan<ValueTuple<string, object>>));
			List<ISurvivorsRogueCombatInfo> list = new List<ISurvivorsRogueCombatInfo>();
			this.GetModel().GetAllEntities(list);
			foreach (ISurvivorsRogueCombatInfo survivorsRogueCombatInfo in list)
			{
				if (survivorsRogueCombatInfo.EntityType == ESurvivorsRogueEntityType.Monster)
				{
					ControllerBase<KuroSimpleCombatController>.Instance.RemoveEntityByReasonType((long)survivorsRogueCombatInfo.Uid, EKscEntityRemoveReasonType.Dead);
				}
				else if (survivorsRogueCombatInfo.EntityType == ESurvivorsRogueEntityType.GoldenCoin)
				{
					ControllerBase<KuroSimpleCombatController>.Instance.RemoveEntityByReasonType((long)survivorsRogueCombatInfo.Uid, EKscEntityRemoveReasonType.Destroy);
				}
				else if (survivorsRogueCombatInfo.EntityType == ESurvivorsRogueEntityType.Weapon)
				{
					ControllerBase<KuroSimpleCombatController>.Instance.RemoveEntityByReasonType((long)survivorsRogueCombatInfo.Uid, EKscEntityRemoveReasonType.Destroy);
				}
			}
		}, null, null);
	}

	// Token: 0x06006513 RID: 25875 RVA: 0x001946F2 File Offset: 0x001928F2
	protected override void CreateEntityFilter()
	{
		this.RedirectFilter = this.EntityRedirectFilter;
	}

	// Token: 0x06006514 RID: 25876 RVA: 0x00194700 File Offset: 0x00192900
	[NullableContext(2)]
	protected override EntityHandle GetPossessedPlayerEntity()
	{
		return this.PlayerEntityHandle;
	}

	// Token: 0x06006515 RID: 25877 RVA: 0x00194708 File Offset: 0x00192908
	protected override bool AddInputLayer()
	{
		SurvivorsRogueInputLayer survivorsRogueInputLayer = this.GetInputLayer();
		if (survivorsRogueInputLayer != null)
		{
			this.RemoveInputLayer();
		}
		survivorsRogueInputLayer = (ControllerBase<InputController>.Instance.CreateInputLayer(EInputLayer.SurvivorsRogue) as SurvivorsRogueInputLayer);
		if (survivorsRogueInputLayer != null)
		{
			EntityHandle possessedPlayerEntity = this.GetPossessedPlayerEntity();
			if (possessedPlayerEntity != null)
			{
				ControllerBase<InputController>.Instance.AddInputLayer(possessedPlayerEntity.Id, survivorsRogueInputLayer);
			}
			else
			{
				KscLog.Error(KscLog.EModule.Input, ELogAuthor.HXY, Singleton<KscEnv>.Instance.KscWorld, "幸存者肉鸽输入层加入异常,无法绑定实体", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return true;
		}
		KscLog.Error(KscLog.EModule.Input, ELogAuthor.HXY, Singleton<KscEnv>.Instance.KscWorld, "幸存者肉鸽输入层加入异常", default(ReadOnlySpan<ValueTuple<string, object>>));
		return false;
	}

	// Token: 0x06006516 RID: 25878 RVA: 0x0019479C File Offset: 0x0019299C
	protected override bool RemoveInputLayer()
	{
		SurvivorsRogueInputLayer inputLayer = this.GetInputLayer();
		if (inputLayer != null)
		{
			ControllerBase<InputController>.Instance.RemoveInputLayer(inputLayer);
			inputLayer.Clear();
			return true;
		}
		KscLog.Error(KscLog.EModule.Input, ELogAuthor.HXY, Singleton<KscEnv>.Instance.KscWorld, "幸存者肉鸽输入层移除异常", default(ReadOnlySpan<ValueTuple<string, object>>));
		return false;
	}

	// Token: 0x06006517 RID: 25879 RVA: 0x001947E8 File Offset: 0x001929E8
	[NullableContext(2)]
	private SurvivorsRogueInputLayer GetInputLayer()
	{
		EntityHandle possessedPlayerEntity = this.GetPossessedPlayerEntity();
		if (possessedPlayerEntity != null)
		{
			return ControllerBase<InputController>.Instance.GetInputLayer(possessedPlayerEntity.Id, EInputLayer.SurvivorsRogue) as SurvivorsRogueInputLayer;
		}
		return null;
	}

	// Token: 0x06006518 RID: 25880 RVA: 0x00194818 File Offset: 0x00192A18
	protected override void AddKscPlayerEntity()
	{
		this.AddInputLayer();
	}

	// Token: 0x06006519 RID: 25881 RVA: 0x00194824 File Offset: 0x00192A24
	public override void OnPlayerEntityCreated()
	{
		base.OnPlayerEntityCreated();
		SurvivorsRogueSubModel model = this.GetModel();
		KscSubModelBase kscSubModelBase = model;
		AKSC_Entity kscPlayerEntity = model.KscPlayerEntity;
		kscSubModelBase.KscPlayerEntityId = ((kscPlayerEntity != null) ? kscPlayerEntity.EntityId_ : 0);
		int killComboStage = model.KillComboStage;
		if (killComboStage <= 0)
		{
			return;
		}
		SurvivorsCombo? curComboConfig = ModelBase<SurvivorsRogueModel>.Instance.CurComboConfig;
		if (curComboConfig == null)
		{
			return;
		}
		int num = curComboConfig.Value.GetPlayerBuffIdsArray()[killComboStage - 1];
		if (num != 0 && model.KscPlayerEntity != null)
		{
			ControllerBase<KuroSimpleCombatController>.Instance.ModifyBuffAsync(model.KscPlayerEntity.EntityId_, true, num);
		}
	}

	// Token: 0x0600651A RID: 25882 RVA: 0x001948B0 File Offset: 0x00192AB0
	protected override void SyncPlayerTransform()
	{
		if (this.GetModel().KscPlayerEntity == null && this.GetModel().WeaponKscEntities.Count <= 0)
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
		if (kscPlayerEntity != null)
		{
			kscPlayerEntity.SetTransformByWorld(ftransformDouble);
		}
		foreach (AKSC_Entity aksc_Entity in this.GetModel().WeaponKscEntities)
		{
			aksc_Entity.SetTransformByWorld(ftransformDouble);
		}
	}

	// Token: 0x0600651B RID: 25883 RVA: 0x00194974 File Offset: 0x00192B74
	public void OnWeaponCreated(AKSC_Entity kscEntity)
	{
		SurvivorsRogueSubModel model = this.GetModel();
		model.WeaponKscEntities.Add(kscEntity);
		int killComboStage = model.KillComboStage;
		if (killComboStage <= 0)
		{
			return;
		}
		SurvivorsCombo? curComboConfig = ModelBase<SurvivorsRogueModel>.Instance.CurComboConfig;
		if (curComboConfig == null)
		{
			return;
		}
		int num = curComboConfig.Value.GetWeaponBuffIdsArray()[killComboStage - 1];
		if (num != 0)
		{
			ControllerBase<KuroSimpleCombatController>.Instance.ModifyBuffAsync(kscEntity.EntityId_, true, num);
		}
	}

	// Token: 0x0600651C RID: 25884 RVA: 0x001949DC File Offset: 0x00192BDC
	public void ExecSkillAction()
	{
		AKSC_Entity kscPlayerEntity = this.SubModel.KscPlayerEntity;
		if (kscPlayerEntity == null)
		{
			return;
		}
		int num = 0;
		UKSC_SkillComp skillComp = kscPlayerEntity.GetSkillComp();
		TArray<UKSC_Skill> tarray = (skillComp != null) ? skillComp.Skills_ : null;
		if (tarray == null)
		{
			return;
		}
		if (tarray.Num() <= num)
		{
			return;
		}
		if (this.SkillCdComp == null)
		{
			return;
		}
		int skillId = 220003;
		if (this.SkillCdComp.IsSkillInCd(skillId, true))
		{
			return;
		}
		UKSC_Skill uksc_Skill = tarray.Get(num);
		if (uksc_Skill.GetSkillCoolDownRemain() > 0f)
		{
			return;
		}
		kscPlayerEntity.TryActiveSKill(num);
		float skillCoolDownMax = uksc_Skill.GetSkillCoolDownMax();
		this.SkillCdComp.ModifyCdInfo(skillId, skillCoolDownMax);
		this.SkillCdComp.StartCd(skillId, 13);
		if (this.SkillComp != null)
		{
			SurvivorsRoleGainData roleGainData = ModelBase<SurvivorsRogueModel>.Instance.GainData.GetRoleGainData();
			int? num2 = (roleGainData != null) ? new int?(roleGainData.GetCurrentEvolveId()) : null;
			if (num2 != null)
			{
				Aki.Config.SurvivorsRoleEvolve? survivorsRoleEvolve;
				int? num3 = (ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsRoleEvolve(num2.Value) != null) ? new int?(survivorsRoleEvolve.GetValueOrDefault().SkillId) : null;
				if (num3 != null)
				{
					this.SkillComp.BeginSkillAsync(num3.Value, null);
				}
			}
		}
	}

	// Token: 0x0600651D RID: 25885 RVA: 0x00194B1C File Offset: 0x00192D1C
	private void AddTreeListener()
	{
		BehaviorTreeUpdateDelegateProxy behaviorDelegate = ModelBase<SurvivorsRogueModel>.Instance.BattleData.BehaviorDelegate;
		this.AddTreeVarUpdateDelegate(behaviorDelegate, ESurvivorsRougeSystemVarType.Gold.ToEnumString(), new TTreeVarUpdateDelegate(this.OnSurvivorsCurrencyUpdate));
		this.AddTreeVarUpdateDelegate(behaviorDelegate, ESurvivorsRougeSystemVarType.ConsecutiveKillCount.ToEnumString(), new TTreeVarUpdateDelegate(this.OnSurvivorsComboUpdate));
	}

	// Token: 0x0600651E RID: 25886 RVA: 0x00194B6C File Offset: 0x00192D6C
	private void AddTreeVarUpdateDelegate(BehaviorTreeUpdateDelegateProxy behaviorDelegate, string key, TTreeVarUpdateDelegate delegate_)
	{
		behaviorDelegate.AddTreeVarUpdateDelegate(key, delegate_);
		VarDefinePb behaviorTreeVar = behaviorDelegate.GetBehaviorTreeVar(key);
		if (behaviorTreeVar != null)
		{
			delegate_(null, behaviorTreeVar);
		}
	}

	// Token: 0x0600651F RID: 25887 RVA: 0x00194B94 File Offset: 0x00192D94
	private void RemoveTreeListener()
	{
		BehaviorTreeUpdateDelegateProxy behaviorDelegate = ModelBase<SurvivorsRogueModel>.Instance.BattleData.BehaviorDelegate;
		behaviorDelegate.RemoveTreeVarUpdateDelegate(ESurvivorsRougeSystemVarType.Gold.ToEnumString(), new TTreeVarUpdateDelegate(this.OnSurvivorsCurrencyUpdate));
		behaviorDelegate.RemoveTreeVarUpdateDelegate(ESurvivorsRougeSystemVarType.ConsecutiveKillCount.ToEnumString(), new TTreeVarUpdateDelegate(this.OnSurvivorsComboUpdate));
	}

	// Token: 0x06006520 RID: 25888 RVA: 0x00194BD4 File Offset: 0x00192DD4
	private void OnSurvivorsCurrencyUpdate([Nullable(2)] VarDefinePb lastVarDefine, VarDefinePb newVarDefine)
	{
		int num = (int)Singleton<MathUtils>.Instance.LongToNumber(newVarDefine.Int);
		if (this.GetModel().GoldNum != num)
		{
			this.GetModel().GoldNum = num;
			UKSC_World kscWorld = Singleton<KscEnv>.Instance.KscWorld;
			if (kscWorld == null)
			{
				return;
			}
			kscWorld.SetWorldAttr(EKSC_WorldAttrType.Gold, num);
		}
	}

	// Token: 0x06006521 RID: 25889 RVA: 0x00194C24 File Offset: 0x00192E24
	private void OnSurvivorsComboUpdate([Nullable(2)] VarDefinePb lastVarDefine, VarDefinePb newVarDefine)
	{
		int newCombo = (int)Singleton<MathUtils>.Instance.LongToNumber(newVarDefine.Int);
		this.RefreshCombo(newCombo);
	}

	// Token: 0x06006522 RID: 25890 RVA: 0x00194C4C File Offset: 0x00192E4C
	private void RefreshCombo(int newCombo)
	{
		SurvivorsCombo? curComboConfig = ModelBase<SurvivorsRogueModel>.Instance.CurComboConfig;
		if (curComboConfig == null)
		{
			KscLog.Error(KscLog.EModule.Common, ELogAuthor.CFT, Singleton<KscEnv>.Instance.KscWorld, "幸存者获取连杀配置失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		int num = 0;
		int[] comboNumArray = curComboConfig.Value.GetComboNumArray();
		if (comboNumArray != null)
		{
			for (int i = 0; i <= comboNumArray.Length; i++)
			{
				if (newCombo < comboNumArray[i])
				{
					num = i;
					break;
				}
			}
		}
		SurvivorsRogueSubModel model = this.GetModel();
		int killComboStage = model.KillComboStage;
		if (killComboStage == num)
		{
			return;
		}
		if (killComboStage > 0)
		{
			int num2 = curComboConfig.Value.GetPlayerBuffIdsArray()[killComboStage - 1];
			if (num2 != 0 && model.KscPlayerEntity != null)
			{
				ControllerBase<KuroSimpleCombatController>.Instance.ModifyBuffAsync(model.KscPlayerEntity.EntityId_, false, num2);
			}
			int num3 = curComboConfig.Value.GetWeaponBuffIdsArray()[killComboStage - 1];
			if (num3 != 0)
			{
				foreach (AKSC_Entity aksc_Entity in model.WeaponKscEntities)
				{
					ControllerBase<KuroSimpleCombatController>.Instance.ModifyBuffAsync(aksc_Entity.EntityId_, false, num3);
				}
			}
		}
		if (num > 0)
		{
			int num4 = curComboConfig.Value.GetPlayerBuffIdsArray()[num - 1];
			if (num4 != 0 && model.KscPlayerEntity != null)
			{
				ControllerBase<KuroSimpleCombatController>.Instance.ModifyBuffAsync(model.KscPlayerEntity.EntityId_, true, num4);
			}
			int num5 = curComboConfig.Value.GetWeaponBuffIdsArray()[num - 1];
			if (num5 != 0)
			{
				foreach (AKSC_Entity aksc_Entity2 in model.WeaponKscEntities)
				{
					ControllerBase<KuroSimpleCombatController>.Instance.ModifyBuffAsync(aksc_Entity2.EntityId_, true, num5);
				}
			}
		}
		model.KillComboStage = num;
	}

	// Token: 0x06006523 RID: 25891 RVA: 0x00194E40 File Offset: 0x00193040
	protected override void OnHandlePlayerHeadHpInfo(KscHeadStateData kscPlayerHeadStateData, FKSC_HeadHpContext headInfo)
	{
		base.OnHandlePlayerHeadHpInfo(kscPlayerHeadStateData, headInfo);
		this.PlayerHpHandle.OnPlayerHpChange(kscPlayerHeadStateData);
	}

	// Token: 0x06006524 RID: 25892 RVA: 0x00194E58 File Offset: 0x00193058
	public override void GmPrintInfo()
	{
		SurvivorsRogueSubModel model = this.GetModel();
		List<string> list = new List<string>
		{
			"[ksc]幸存者玩法"
		};
		List<string> list2 = list;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 2);
		defaultInterpolatedStringHandler.AppendLiteral("玩家 EntityId:");
		defaultInterpolatedStringHandler.AppendFormatted<int>(model.KscPlayerEntityId);
		defaultInterpolatedStringHandler.AppendLiteral(", 服务端Id:");
		defaultInterpolatedStringHandler.AppendFormatted<long>(model.KscPlayerCreatureDataId);
		list2.Add(defaultInterpolatedStringHandler.ToStringAndClear());
		foreach (AKSC_Entity aksc_Entity in model.WeaponKscEntities)
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
		KscLog.Debug(KscLog.EModule.Common, ELogAuthor.CFT, null, text, default(ReadOnlySpan<ValueTuple<string, object>>));
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

	// Token: 0x0400302B RID: 12331
	[Nullable(2)]
	private EntityHandle PlayerEntityHandle;

	// Token: 0x0400302C RID: 12332
	[Nullable(2)]
	private CharacterSkillCdComponent SkillCdComp;

	// Token: 0x0400302D RID: 12333
	[Nullable(2)]
	private CharacterSkillComponent SkillComp;

	// Token: 0x0400302E RID: 12334
	private readonly SurvivorsRogueEntityRedirectFilter EntityRedirectFilter = new SurvivorsRogueEntityRedirectFilter();

	// Token: 0x0400302F RID: 12335
	private readonly ActivityPlayerHpHandle PlayerHpHandle = new ActivityPlayerHpHandle();
}
