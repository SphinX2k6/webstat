using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.KuroSimpleCombat;
using CSharpScript.Game.LevelGamePlay.Common;
using UnrealEngine;

// Token: 0x02000F57 RID: 3927
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleArrowGenerate
{
	// Token: 0x060062AB RID: 25259 RVA: 0x00189C7C File Offset: 0x00187E7C
	public void SetBornRotation(float pitch, float yaw, float roll)
	{
		this.BornRotation.Set(pitch, yaw, roll);
		this.BornRotation.Quaternion(null).RotateVector(global::Vector.ForwardVectorProxy, this.ForwardDirection);
		this.BornRotation.Quaternion(null).RotateVector(global::Vector.RightVectorProxy, this.RightDirection);
	}

	// Token: 0x060062AC RID: 25260 RVA: 0x00189CCF File Offset: 0x00187ECF
	public int GetSpawnUid()
	{
		this.Uid += 2;
		return this.Uid;
	}

	// Token: 0x060062AD RID: 25261 RVA: 0x00189CE8 File Offset: 0x00187EE8
	public void Clear()
	{
		this.GenerateGroupList.Clear();
		this.CurGenerateGroupIndex = 0;
		this.EntityMap.Clear();
		this.BuffGateDescInfoMap.Clear();
		this.DropBuffGateMap.Clear();
		this.EntityDeadLocationMap.Clear();
		this.WaitCollectionSelect.Clear();
		this.WaitToNextSubLevel = false;
		this.BuffGateBornGroup.Clear();
		UKSC_World kscWorld = Singleton<KscEnv>.Instance.KscWorld;
		if (kscWorld != null)
		{
			UKSC_SceneMovement sceneMovement = kscWorld.SceneMovement;
			if (sceneMovement != null)
			{
				sceneMovement.OnSceneMoveThreshold.Unbind();
			}
		}
		this.StopGenerate();
	}

	// Token: 0x060062AE RID: 25262 RVA: 0x00189D7B File Offset: 0x00187F7B
	public bool IsGenerateFinish()
	{
		return this.CurGenerateGroupIndex >= this.GenerateGroupList.Count;
	}

	// Token: 0x060062AF RID: 25263 RVA: 0x00189D93 File Offset: 0x00187F93
	public bool IsFinish()
	{
		return this.IsGenerateFinish() && this.EntityMap.Count == 0;
	}

	// Token: 0x060062B0 RID: 25264 RVA: 0x00189DAD File Offset: 0x00187FAD
	[NullableContext(2)]
	public GenerateGroup GetLastGenerateGroup()
	{
		if (this.GenerateGroupList.Count <= 0)
		{
			return null;
		}
		return this.GenerateGroupList[this.GenerateGroupList.Count - 1];
	}

	// Token: 0x060062B1 RID: 25265 RVA: 0x00189DD8 File Offset: 0x00187FD8
	public float? GetStartDistance()
	{
		if (this.GenerateGroupList.Count <= 0)
		{
			return null;
		}
		return new float?(this.GenerateGroupList[0].GroupStartDistance);
	}

	// Token: 0x060062B2 RID: 25266 RVA: 0x00189E14 File Offset: 0x00188014
	public GenerateGroup CreateGenerateGroup()
	{
		GenerateGroup generateGroup = new GenerateGroup();
		this.GenerateGroupList.Add(generateGroup);
		return generateGroup;
	}

	// Token: 0x17000763 RID: 1891
	// (get) Token: 0x060062B3 RID: 25267 RVA: 0x00189E34 File Offset: 0x00188034
	public MotorcycleArrowSubController SubController
	{
		get
		{
			return (MotorcycleArrowSubController)ControllerBase<KuroSimpleCombatController>.Instance.CurSubController;
		}
	}

	// Token: 0x17000764 RID: 1892
	// (get) Token: 0x060062B4 RID: 25268 RVA: 0x00189E45 File Offset: 0x00188045
	public MotorcycleArrowSubModel SubModel
	{
		get
		{
			return this.SubController.GetModel();
		}
	}

	// Token: 0x060062B5 RID: 25269 RVA: 0x00189E54 File Offset: 0x00188054
	private void UpdateNextGenerateDistance(UKSC_SceneMovement sceneMovement)
	{
		GenerateGroup generateGroup = this.GenerateGroupList[this.CurGenerateGroupIndex];
		float moveDistanceThreshold = generateGroup.GenerateList[generateGroup.CurGenerateIndex].BornDistance + generateGroup.GroupStartDistance;
		sceneMovement.MoveDistanceThreshold = moveDistanceThreshold;
	}

	// Token: 0x060062B6 RID: 25270 RVA: 0x00189E98 File Offset: 0x00188098
	public void StartGenerate()
	{
		if (this.IsStartGenerate || this.IsGenerateFinish())
		{
			return;
		}
		this.IsStartGenerate = true;
		UKSC_World kscWorld = Singleton<KscEnv>.Instance.KscWorld;
		UKSC_SceneMovement uksc_SceneMovement = (kscWorld != null) ? kscWorld.SceneMovement : null;
		if (uksc_SceneMovement == null)
		{
			KscLog.Error(KscLog.EModule.Common, ELogAuthor.TZQ, Singleton<KscEnv>.Instance.KscWorld, "[摩托战斗]场景移动组件为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		uksc_SceneMovement.OnSceneMoveThreshold.Bind(new Action(this.OnSceneMoveThreshold));
		this.UpdateNextGenerateDistance(uksc_SceneMovement);
		this.NotifyFightRefreshNextWaveGroup();
	}

	// Token: 0x060062B7 RID: 25271 RVA: 0x00189F1C File Offset: 0x0018811C
	public void StopGenerate()
	{
		if (!this.IsStartGenerate)
		{
			return;
		}
		this.IsStartGenerate = false;
		UKSC_World kscWorld = Singleton<KscEnv>.Instance.KscWorld;
		if (kscWorld == null)
		{
			return;
		}
		UKSC_SceneMovement sceneMovement = kscWorld.SceneMovement;
		if (sceneMovement == null)
		{
			return;
		}
		sceneMovement.OnSceneMoveThreshold.Unbind();
	}

	// Token: 0x060062B8 RID: 25272 RVA: 0x00189F54 File Offset: 0x00188154
	public void OnSceneMoveThreshold()
	{
		UKSC_SceneMovement sceneMovement = Singleton<KscEnv>.Instance.KscWorld.SceneMovement;
		float moveDistance = sceneMovement.MoveDistance;
		this.GenerateByDistance(moveDistance);
		if (this.IsGenerateFinish())
		{
			this.StopGenerate();
			return;
		}
		this.UpdateNextGenerateDistance(sceneMovement);
	}

	// Token: 0x060062B9 RID: 25273 RVA: 0x00189F98 File Offset: 0x00188198
	public unsafe void GenerateByDistance(float distance)
	{
		if (this.IsGenerateFinish())
		{
			return;
		}
		GenerateGroup generateGroup = this.GenerateGroupList[this.CurGenerateGroupIndex];
		for (int i = generateGroup.CurGenerateIndex; i < generateGroup.GenerateList.Count; i++)
		{
			IGenerate generate = generateGroup.GenerateList[i];
			float num = generate.BornDistance + generateGroup.GroupStartDistance;
			if (num > distance)
			{
				break;
			}
			int num2 = 0;
			global::Vector commonTempVector = Singleton<MathUtils>.Instance.CommonTempVector;
			this.ForwardDirection.Multiply((double)(distance - num), commonTempVector);
			int num3 = (generate.BornTrack == 2) ? 0 : ((generate.BornTrack == 1) ? -1 : 1);
			this.RightDirection.Multiply((double)(num3 * 500), Singleton<MathUtils>.Instance.CommonTempVector2);
			if (generate.GenerateType == EGenerateType.Boss)
			{
				commonTempVector.FromUeVector(this.SubController.GetModel().PlayerDirect);
				MotorFightWaveGroup? motorFightWaveGroupById = ConfigBase<MotorcycleArrowConfig>.Instance.GetMotorFightWaveGroupById(generateGroup.WaveGroupId);
				commonTempVector.MultiplyEqual((double)((motorFightWaveGroupById != null) ? motorFightWaveGroupById.GetValueOrDefault().BossFightDistance : 0));
				commonTempVector.AdditionEqual(this.SubController.GetModel().PlayerBornPos);
				FRotator frotator = this.BornRotation.ToUeRotator();
				FVectorDouble fvectorDouble = commonTempVector.ToUeVector(false);
				FVector fvector = global::Vector.OneVectorDouble;
				FTransformDouble transform = new FTransformDouble(ref frotator, ref fvectorDouble, ref fvector);
				num2 = this.SpawnMonsterBoss(generate, transform, generateGroup);
			}
			else
			{
				commonTempVector.AdditionEqual(Singleton<MathUtils>.Instance.CommonTempVector2).AdditionEqual(this.BornPos);
				FRotator frotator = this.BornRotation.ToUeRotator();
				FVectorDouble fvectorDouble = commonTempVector.ToUeVector(false);
				FVector fvector = global::Vector.OneVectorDouble;
				FTransformDouble transform2 = new FTransformDouble(ref frotator, ref fvectorDouble, ref fvector);
				if (generate.GenerateType == EGenerateType.Monster)
				{
					num2 = this.SpawnMonster(generate, transform2, generateGroup, false);
				}
				else if (generate.GenerateType == EGenerateType.Elite)
				{
					num2 = this.SpawnMonster(generate, transform2, generateGroup, true);
				}
				else if (generate.GenerateType == EGenerateType.Buff)
				{
					num2 = this.SpawnBuffGate(generate.RefreshId, transform2, new int?(generateGroup.WaveGroupId));
				}
			}
			this.EntityMap[(long)num2] = generateGroup;
			generateGroup.AliveEntityMap[(long)num2] = i;
			generateGroup.CurGenerateIndex++;
			KscLog.EModule flag = KscLog.EModule.Common;
			ELogAuthor author = ELogAuthor.TZQ;
			UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
			string log = "[摩托战斗]生成实体";
			<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CurGroup", this.CurGenerateGroupIndex);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("GenerateIndex", generateGroup.CurGenerateIndex);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("creatureId", num2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("GenerateType", generate.GenerateType);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("Id", generate.RefreshId);
			KscLog.Debug(flag, author, kscWorld, log, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
			this.SendBossBornNotify(generate);
		}
		if (generateGroup.IsGenerateFinish())
		{
			this.CurGenerateGroupIndex++;
			this.NotifyFightRefreshNextWaveGroup();
		}
	}

	// Token: 0x060062BA RID: 25274 RVA: 0x0018A2D4 File Offset: 0x001884D4
	public unsafe int SpawnMonster(IGenerate curGenerate, FTransformDouble transform, GenerateGroup curGroup, bool isElite = false)
	{
		int spawnUid = this.GetSpawnUid();
		MotorFightBossRefresh? motorFightBossRefresh = null;
		MotorFightMonsterRefresh? motorFightMonsterRefresh = null;
		if (isElite)
		{
			motorFightBossRefresh = ConfigBase<MotorcycleArrowConfig>.Instance.GetBossRefreshById(curGenerate.RefreshId);
		}
		else
		{
			motorFightMonsterRefresh = ConfigBase<MotorcycleArrowConfig>.Instance.GetMonsterRefreshById(curGenerate.RefreshId);
		}
		if (isElite && motorFightBossRefresh == null)
		{
			KscLog.EModule flag = KscLog.EModule.Common;
			ELogAuthor author = ELogAuthor.TZQ;
			UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
			string log = "[摩托战斗]怪物刷新配置不存在";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", curGenerate.RefreshId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("isElite", isElite);
			KscLog.Error(flag, author, kscWorld, log, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return 0;
		}
		if (!isElite && motorFightMonsterRefresh == null)
		{
			KscLog.EModule flag2 = KscLog.EModule.Common;
			ELogAuthor author2 = ELogAuthor.TZQ;
			UObject kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
			string log2 = "[摩托战斗]怪物刷新配置不存在";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Id", curGenerate.RefreshId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("isElite", isElite);
			KscLog.Error(flag2, author2, kscWorld2, log2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return 0;
		}
		int monsterId = isElite ? motorFightBossRefresh.Value.MonsterId : motorFightMonsterRefresh.Value.MonsterId;
		if (!this.SpawnMonsterByMonsterId(spawnUid, monsterId, transform, curGroup))
		{
			return 0;
		}
		return spawnUid;
	}

	// Token: 0x060062BB RID: 25275 RVA: 0x0018A444 File Offset: 0x00188644
	public bool SpawnMonsterByMonsterId(int creatureId, int monsterId, FTransformDouble transform, GenerateGroup curGroup)
	{
		MotorMonster? monsterConfigById = ConfigBase<MotorcycleArrowConfig>.Instance.GetMonsterConfigById(monsterId);
		if (monsterConfigById == null)
		{
			KscLog.EModule flag = KscLog.EModule.Common;
			ELogAuthor author = ELogAuthor.TZQ;
			UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
			string log = "[摩托战斗]怪物配置不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("monsterId", monsterId);
			KscLog.Error(flag, author, kscWorld, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		MotorMonster value = monsterConfigById.Value;
		int monsterTemptId = value.MonsterTemptId;
		int attrConfig = value.AttrConfig;
		string entityPathById = ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel.GetEntityPathById(monsterTemptId);
		if (entityPathById == null)
		{
			KscLog.EModule flag2 = KscLog.EModule.Common;
			ELogAuthor author2 = ELogAuthor.TZQ;
			UObject kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
			string log2 = "[摩托战斗]实体资产路径不存在";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("simpleCombatId", monsterTemptId);
			KscLog.Error(flag2, author2, kscWorld2, log2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return false;
		}
		global::Vector commonTempVector = Singleton<MathUtils>.Instance.CommonTempVector;
		commonTempVector.Set(0.0, 0.0, (double)value.Height);
		FVectorDouble fvectorDouble = commonTempVector.ToUeVector(false);
		transform.AddToTranslation(fvectorDouble);
		HashSet<int> monsterExtraBuffs = this.SubController.GetMonsterExtraBuffs();
		ControllerBase<KuroSimpleCombatController>.Instance.AsyncAddEntity(new KscEntityParam
		{
			CreatureId = (long)creatureId,
			SimpleCombatId = monsterTemptId,
			AssetPath = entityPathById,
			PropertyId = attrConfig,
			Transform = transform,
			Buffs = KscUtil.ToBuffParam(value.GetBornBuffArray(), monsterExtraBuffs),
			AttributeMap = this.SubController.GetOverrideAttrs(curGroup, attrConfig)
		});
		return true;
	}

	// Token: 0x060062BC RID: 25276 RVA: 0x0018A5A4 File Offset: 0x001887A4
	public int SpawnMonsterBoss(IGenerate curGenerate, FTransformDouble transform, GenerateGroup curGroup)
	{
		int spawnUid = this.GetSpawnUid();
		MotorFightBossRefresh? bossRefreshById = ConfigBase<MotorcycleArrowConfig>.Instance.GetBossRefreshById(curGenerate.RefreshId);
		if (bossRefreshById == null)
		{
			KscLog.EModule flag = KscLog.EModule.Common;
			ELogAuthor author = ELogAuthor.TZQ;
			UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
			string log = "[摩托战斗]Boss刷新配置不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", curGenerate.RefreshId);
			KscLog.Error(flag, author, kscWorld, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return 0;
		}
		MotorMonster? monsterConfigById = ConfigBase<MotorcycleArrowConfig>.Instance.GetMonsterConfigById(bossRefreshById.Value.MonsterId);
		if (monsterConfigById == null)
		{
			KscLog.EModule flag2 = KscLog.EModule.Common;
			ELogAuthor author2 = ELogAuthor.TZQ;
			UObject kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
			string log2 = "[摩托战斗]Boss配置不存在";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("monsterId", bossRefreshById.Value.MonsterId);
			KscLog.Error(flag2, author2, kscWorld2, log2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return 0;
		}
		MotorMonster value = monsterConfigById.Value;
		int monsterTemptId = value.MonsterTemptId;
		int attrConfig = value.AttrConfig;
		string entityPathById = ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel.GetEntityPathById(monsterTemptId);
		if (entityPathById == null)
		{
			KscLog.EModule flag3 = KscLog.EModule.Common;
			ELogAuthor author3 = ELogAuthor.TZQ;
			UObject kscWorld3 = Singleton<KscEnv>.Instance.KscWorld;
			string log3 = "[摩托战斗]实体资产路径不存在";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("simpleCombatId", monsterTemptId);
			KscLog.Error(flag3, author3, kscWorld3, log3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			return 0;
		}
		USplineComponent usplineComponent = null;
		if (value.SplineId != 0)
		{
			usplineComponent = ModelBase<GameSplineModel>.Instance.LoadAndGetSplineComponent(value.SplineId, spawnUid, EIdType.SimpleCombatId);
			if (usplineComponent != null && usplineComponent.IsValid())
			{
				this.CreatureIdToSplineId[(long)spawnUid] = value.SplineId;
			}
		}
		global::Vector commonTempVector = Singleton<MathUtils>.Instance.CommonTempVector;
		commonTempVector.Set(0.0, 0.0, (double)value.Height);
		FVectorDouble fvectorDouble = commonTempVector.ToUeVector(false);
		transform.AddToTranslation(fvectorDouble);
		HashSet<int> monsterExtraBuffs = this.SubController.GetMonsterExtraBuffs();
		ControllerBase<KuroSimpleCombatController>.Instance.AsyncAddEntity(new KscEntityParam
		{
			CreatureId = (long)spawnUid,
			SimpleCombatId = monsterTemptId,
			AssetPath = entityPathById,
			PropertyId = attrConfig,
			Transform = transform,
			Buffs = KscUtil.ToBuffParam(value.GetBornBuffArray(), monsterExtraBuffs),
			AttributeMap = this.SubController.GetOverrideAttrs(curGroup, attrConfig),
			Spline = usplineComponent,
			FinishCallback = delegate(AKSC_Entity kscEntity)
			{
				UKSC_Move moveComponent = kscEntity.GetMoveComponent();
				KscSubModelBase model = this.SubController.Model;
				if (((model != null) ? model.KscPlayerEntity : null) == null)
				{
					KscLog.Error(KscLog.EModule.Load, ELogAuthor.HCW, kscEntity, "Boss设置玩家为目标时玩家还未创建???", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				UKSC_Move_MultiStage uksc_Move_MultiStage = moveComponent as UKSC_Move_MultiStage;
				if (uksc_Move_MultiStage != null)
				{
					uksc_Move_MultiStage.SetTargetEntity(this.SubController.Model.KscPlayerEntity);
					return;
				}
				KscLog.Error(KscLog.EModule.Load, ELogAuthor.HCW, kscEntity, "Boss移动组件不是MultiStage", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		});
		this.SubController.OnBossCreate(spawnUid, curGroup.BossFightTime, value.Desc);
		return spawnUid;
	}

	// Token: 0x060062BD RID: 25277 RVA: 0x0018A7F4 File Offset: 0x001889F4
	public int SpawnBuffGate(int buffGateRefreshId, FTransformDouble transform, int? waveGroupId = null)
	{
		MotorcycleArrowGenerate.<>c__DisplayClass39_0 CS$<>8__locals1 = new MotorcycleArrowGenerate.<>c__DisplayClass39_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.transform = transform;
		int spawnUid = this.GetSpawnUid();
		MotorFightBuffGateRefresh? buffRefreshByRefreshId = ConfigBase<MotorcycleArrowConfig>.Instance.GetBuffRefreshByRefreshId(buffGateRefreshId);
		if (buffRefreshByRefreshId == null)
		{
			KscLog.EModule flag = KscLog.EModule.Common;
			ELogAuthor author = ELogAuthor.TZQ;
			UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
			string log = "[摩托战斗]buff门刷新配置不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", buffGateRefreshId);
			KscLog.Error(flag, author, kscWorld, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return 0;
		}
		MotorFightBuffGate? buffGateConfigById = ConfigBase<MotorcycleArrowConfig>.Instance.GetBuffGateConfigById(buffRefreshByRefreshId.Value.BuffGateId);
		if (buffGateConfigById == null)
		{
			KscLog.EModule flag2 = KscLog.EModule.Common;
			ELogAuthor author2 = ELogAuthor.TZQ;
			UObject kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
			string log2 = "[摩托战斗]buff门配置不存在";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("BuffGateId", buffRefreshByRefreshId.Value.BuffGateId);
			KscLog.Error(flag2, author2, kscWorld2, log2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return 0;
		}
		MotorFightBuffGate value = buffGateConfigById.Value;
		int gateTemptId = value.GateTemptId;
		string entityPathById = ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel.GetEntityPathById(gateTemptId);
		if (entityPathById == null)
		{
			KscLog.EModule flag3 = KscLog.EModule.Common;
			ELogAuthor author3 = ELogAuthor.TZQ;
			UObject kscWorld3 = Singleton<KscEnv>.Instance.KscWorld;
			string log3 = "[摩托战斗]实体资产路径不存在";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("simpleCombatId", gateTemptId);
			KscLog.Error(flag3, author3, kscWorld3, log3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			return 0;
		}
		global::Vector commonTempVector = Singleton<MathUtils>.Instance.CommonTempVector;
		commonTempVector.Set(0.0, 0.0, (double)value.Height);
		MotorcycleArrowGenerate.<>c__DisplayClass39_0 CS$<>8__locals2 = CS$<>8__locals1;
		FVectorDouble fvectorDouble = commonTempVector.ToUeVector(false);
		CS$<>8__locals2.transform.AddToTranslation(fvectorDouble);
		CS$<>8__locals1.sceneMove = Singleton<KscEnv>.Instance.KscWorld.SceneMovement;
		CS$<>8__locals1.startDistance = CS$<>8__locals1.sceneMove.MoveDistance;
		ControllerBase<KuroSimpleCombatController>.Instance.AsyncAddEntity(new KscEntityParam
		{
			CreatureId = (long)spawnUid,
			SimpleCombatId = gateTemptId,
			AssetPath = entityPathById,
			PropertyId = 0,
			Transform = CS$<>8__locals1.transform,
			Buffs = KscUtil.ToBuffParam(value.GetBornBuffArray(), null),
			FinishCallback = delegate(AKSC_Entity kscEntity)
			{
				UKSC_Move_Approach uksc_Move_Approach = kscEntity.GetMoveComponent() as UKSC_Move_Approach;
				if (uksc_Move_Approach != null)
				{
					KscSubModelBase model = CS$<>8__locals1.<>4__this.SubController.Model;
					AKSC_Entity aksc_Entity = (model != null) ? model.KscPlayerEntity : null;
					if (aksc_Entity != null)
					{
						uksc_Move_Approach.SetTargetEntity(aksc_Entity);
					}
				}
				if (CS$<>8__locals1.sceneMove.IsValid())
				{
					float moveDistance = CS$<>8__locals1.sceneMove.MoveDistance;
					if (moveDistance - CS$<>8__locals1.startDistance <= 0f)
					{
						return;
					}
					global::Vector commonTempVector2 = Singleton<MathUtils>.Instance.CommonTempVector;
					CS$<>8__locals1.<>4__this.ForwardDirection.Multiply((double)(moveDistance - CS$<>8__locals1.startDistance), commonTempVector2);
					KscLog.EModule flag4 = KscLog.EModule.Common;
					ELogAuthor author4 = ELogAuthor.TZQ;
					UObject kscWorld4 = Singleton<KscEnv>.Instance.KscWorld;
					string log4 = "[摩托战斗]buff门修正位置";
					ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("fixBornPos", commonTempVector2);
					KscLog.Debug(flag4, author4, kscWorld4, log4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
					FVectorDouble fvectorDouble2 = commonTempVector2.ToUeVector(false);
					CS$<>8__locals1.transform.AddToTranslation(fvectorDouble2);
					kscEntity.SetTransformByWorld(CS$<>8__locals1.transform);
				}
			}
		});
		if (value.AffectedByRate != 0 && waveGroupId != null)
		{
			MotorFightWaveGroup? motorFightWaveGroupById = ConfigBase<MotorcycleArrowConfig>.Instance.GetMotorFightWaveGroupById(waveGroupId.Value);
			List<string> item = this.MultiplyStringValues(value.DescArgs().ToList<string>(), (motorFightWaveGroupById != null) ? motorFightWaveGroupById.GetValueOrDefault().Amplify : 0);
			this.BuffGateDescInfoMap[(long)spawnUid] = new BuffGateDesc
			{
				Desc = new ValueTuple<string, List<string>>(value.Desc, item),
				BuffGateId = value.Id,
				IsDropBuffGate = (waveGroupId == null)
			};
		}
		else
		{
			this.BuffGateDescInfoMap[(long)spawnUid] = new BuffGateDesc
			{
				Desc = new ValueTuple<string, List<string>>(value.Desc, value.DescArgs().ToList<string>()),
				BuffGateId = value.Id,
				IsDropBuffGate = (waveGroupId == null)
			};
		}
		return spawnUid;
	}

	// Token: 0x060062BE RID: 25278 RVA: 0x0018AADC File Offset: 0x00188CDC
	public void SendBossBornNotify(IGenerate curGenerate)
	{
		if (curGenerate.GenerateType == EGenerateType.Boss || curGenerate.GenerateType == EGenerateType.Elite)
		{
			MotorFightRefreshBossPush motorFightRefreshBossPush = MotorFightRefreshBossPush.Create();
			motorFightRefreshBossPush.WaveGroupIndex = this.CurGenerateGroupIndex;
			motorFightRefreshBossPush.RefreshId = curGenerate.RefreshId;
			motorFightRefreshBossPush.SubLevelIndex = this.SubController.GetModel().SubLevelIndex;
			Singleton<Net>.Instance.Send(EPushMessageId.MotorFightRefreshBossPush, motorFightRefreshBossPush);
		}
	}

	// Token: 0x060062BF RID: 25279 RVA: 0x0018AB40 File Offset: 0x00188D40
	public List<string> MultiplyStringValues(List<string> strings, int multiplier)
	{
		float num = (float)multiplier * 0.0001f;
		if ((double)Math.Abs(num - 1f) < 1E-06)
		{
			return strings;
		}
		List<string> list = new List<string>();
		foreach (string text in strings)
		{
			bool flag = text.Contains("%");
			int value = (int)Math.Ceiling((double)((float)int.Parse(flag ? text.Split('%', StringSplitOptions.None)[0] : text) * num));
			List<string> list2 = list;
			string item;
			if (!flag)
			{
				item = value.ToString();
			}
			else
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(value);
				defaultInterpolatedStringHandler.AppendLiteral("%");
				item = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			list2.Add(item);
		}
		return list;
	}

	// Token: 0x060062C0 RID: 25280 RVA: 0x0018AC1C File Offset: 0x00188E1C
	public unsafe void NotifyFightRefreshNextWaveGroup()
	{
		if (this.IsGenerateFinish())
		{
			return;
		}
		MotorFightRefreshNextWaveGroupRequest request = MotorFightRefreshNextWaveGroupRequest.Create();
		request.WaveGroupIndex = this.CurGenerateGroupIndex;
		Singleton<Net>.Instance.Call<MotorFightRefreshNextWaveGroupResponse>(ERequestMessageId.MotorFightRefreshNextWaveGroupRequest, request, delegate(MotorFightRefreshNextWaveGroupResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrCode != Aki.Protocol.ErrorCode.Success)
			{
				KscLog.EModule flag = KscLog.EModule.Common;
				ELogAuthor author = ELogAuthor.TZQ;
				UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
				string log = "[摩托战斗]通知服务端刷新下一波次组失败";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ErrCode", response.ErrCode);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("GroupIndex", request.WaveGroupIndex);
				KscLog.Error(flag, author, kscWorld, log, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}, 0);
	}

	// Token: 0x060062C1 RID: 25281 RVA: 0x0018AC78 File Offset: 0x00188E78
	public unsafe void OnEntityRemove(long creatureId, FName reasonName, global::Vector location)
	{
		KscLog.EModule flag = KscLog.EModule.Common;
		ELogAuthor author = ELogAuthor.TZQ;
		UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
		string log = "[摩托战斗]监听实体移除";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("creatureId", creatureId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("reasonName", reasonName);
		KscLog.Debug(flag, author, kscWorld, log, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		this.OnBuffDropGateRemove(creatureId);
		GenerateGroup generateGroup;
		if (!this.EntityMap.TryGetValue(creatureId, out generateGroup))
		{
			return;
		}
		this.EntityMap.Remove(creatureId);
		ValueTuple<EGenerateType, int, int> valueTuple = generateGroup.OnEntityRemove(creatureId);
		EGenerateType item = valueTuple.Item1;
		int item2 = valueTuple.Item2;
		int item3 = valueTuple.Item3;
		this.UpdateCurrentGroupWaveIndex(generateGroup);
		if (item == EGenerateType.Boss)
		{
			this.SubController.OnBossRemove();
			this.RequestMotorFightKill(generateGroup, item2, true, reasonName != KscEntityRemoveReason.Destroy, location);
			int splineId;
			if (this.CreatureIdToSplineId.TryGetValue(creatureId, out splineId))
			{
				ModelBase<GameSplineModel>.Instance.ReleaseSpline(splineId, creatureId, EIdType.SimpleCombatId);
				this.CreatureIdToSplineId.Remove(creatureId);
			}
		}
		else if (item == EGenerateType.Elite)
		{
			this.RequestMotorFightKill(generateGroup, item2, true, reasonName != KscEntityRemoveReason.Destroy, location);
		}
		else if (item == EGenerateType.Monster)
		{
			this.RequestMotorFightKill(generateGroup, item2, false, reasonName == KscEntityRemoveReason.Dead, location);
		}
		else if (item == EGenerateType.Buff)
		{
			this.SubController.EffectManager.UpdateWaveDamageAmplify(generateGroup.WaveGroupId);
			this.AddBuffByBuffGate(this.BuffGateDescInfoMap[creatureId], generateGroup.WaveGroupIndex, item2, reasonName, this.SubController.GetModel().SubLevelIndex, item3);
		}
		else if (item == EGenerateType.None)
		{
			return;
		}
		this.BuffGateDescInfoMap.Remove(creatureId);
		if (this.IsFinish() && !this.SubController.GetModel().IsGameOver)
		{
			UKSC_SceneMovement sceneMovement = Singleton<KscEnv>.Instance.KscWorld.SceneMovement;
			sceneMovement.OnSceneMoveThreshold.Bind(new Action(this.OnSceneMoveEnd));
			this.WaitToNextSubLevel = true;
			sceneMovement.MoveDistance += this.EndDistance;
		}
	}

	// Token: 0x060062C2 RID: 25282 RVA: 0x0018AE6C File Offset: 0x0018906C
	public unsafe void RequestMotorFightKill(GenerateGroup group, int refreshId, bool isBoss, bool isKill, global::Vector location)
	{
		MotorFightKillRequest motorFightKillRequest = MotorFightKillRequest.Create();
		motorFightKillRequest.EntityId = refreshId;
		motorFightKillRequest.WaveGroupIndex = group.WaveGroupIndex;
		motorFightKillRequest.IsBoss = isBoss;
		motorFightKillRequest.IsKilled = isKill;
		KscLog.EModule flag = KscLog.EModule.Common;
		ELogAuthor author = ELogAuthor.TZQ;
		UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
		string log = "[摩托战斗]通知服务端怪物死亡";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("GroupIndex", group.WaveGroupIndex);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("RefreshId", refreshId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("IsBoss", isBoss);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("IsKill", isKill);
		KscLog.Debug(flag, author, kscWorld, log, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		int subLevelIndex = this.SubController.GetModel().SubLevelIndex;
		int num = this.GenerateUniqueId(subLevelIndex, group.WaveGroupIndex, refreshId);
		this.EntityDeadLocationMap[num] = global::Vector.Create(location.X, location.Y, location.Z);
		if (isBoss)
		{
			this.WaitCollectionSelect.Add(num);
		}
		Singleton<Net>.Instance.Call<MotorFightKillResponse>(ERequestMessageId.MotorFightKillRequest, motorFightKillRequest, delegate(MotorFightKillResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrCode != Aki.Protocol.ErrorCode.Success)
			{
				KscLog.EModule flag2 = KscLog.EModule.Common;
				ELogAuthor author2 = ELogAuthor.TZQ;
				UObject kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
				string log2 = "[摩托战斗]通知服务端怪物死亡失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ErrCode", response.ErrCode);
				KscLog.Error(flag2, author2, kscWorld2, log2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}, 0);
	}

	// Token: 0x060062C3 RID: 25283 RVA: 0x0018AFC8 File Offset: 0x001891C8
	public unsafe void AddBuffByBuffGate(IBuffGateDesc descInfo, int waveGroupIndex, int buffGateId, FName reasonName, int subLevelIndex, int buffGateBornGroup = 0)
	{
		if (reasonName != KscEntityRemoveReason.Dead)
		{
			return;
		}
		int worldAttr = Singleton<KscEnv>.Instance.KscWorld.GetWorldAttr(EKSC_WorldAttrType.WorldSpeedChange);
		if (buffGateBornGroup != 0 && worldAttr <= 0)
		{
			if (this.BuffGateBornGroup.Contains(buffGateBornGroup))
			{
				return;
			}
			this.BuffGateBornGroup.Add(buffGateBornGroup);
		}
		MotorFightBuffGate? buffGateByRefreshId = ConfigBase<MotorcycleArrowConfig>.Instance.GetBuffGateByRefreshId(buffGateId);
		if (buffGateByRefreshId == null)
		{
			KscLog.EModule flag = KscLog.EModule.Common;
			ELogAuthor author = ELogAuthor.TZQ;
			UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
			string log = "[摩托战斗]buff门刷新配置不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("BuffGateId", buffGateId);
			KscLog.Error(flag, author, kscWorld, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		MotorFightBuffGate value = buffGateByRefreshId.Value;
		KscLog.EModule flag2 = KscLog.EModule.Common;
		ELogAuthor author2 = ELogAuthor.TZQ;
		UObject kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
		string log2 = "[摩托战斗]请求选择buff门";
		ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("buffGateId", buffGateId);
		KscLog.Info(flag2, author2, kscWorld2, log2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		int[] buffEffectArray = value.GetBuffEffectArray();
		MotorFightSelectBuffGateRequest motorFightSelectBuffGateRequest = MotorFightSelectBuffGateRequest.Create();
		motorFightSelectBuffGateRequest.WaveGroupIndex = waveGroupIndex;
		motorFightSelectBuffGateRequest.BuffIds.Add(buffEffectArray);
		motorFightSelectBuffGateRequest.BuffGateId = buffGateId;
		motorFightSelectBuffGateRequest.SubLevelIndex = subLevelIndex;
		Singleton<Net>.Instance.Call<MotorFightSelectBuffGateResponse>(ERequestMessageId.MotorFightSelectBuffGateRequest, motorFightSelectBuffGateRequest, delegate(MotorFightSelectBuffGateResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrCode != Aki.Protocol.ErrorCode.Success)
			{
				KscLog.EModule flag3 = KscLog.EModule.Common;
				ELogAuthor author3 = ELogAuthor.TZQ;
				UObject kscWorld3 = Singleton<KscEnv>.Instance.KscWorld;
				string log3 = "[摩托战斗]请求选择buff门失败";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ErrCode", response.ErrCode);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("buffGateId", buffGateId);
				KscLog.Error(flag3, author3, kscWorld3, log3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			KscLog.EModule flag4 = KscLog.EModule.Common;
			ELogAuthor author4 = ELogAuthor.TZQ;
			UObject kscWorld4 = Singleton<KscEnv>.Instance.KscWorld;
			string log4 = "[摩托战斗]请求选择buff门成功";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("buffGateId", buffGateId);
			KscLog.Info(flag4, author4, kscWorld4, log4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			MotorcycleArrowSubModel subModel = this.SubModel;
			if (subModel == null)
			{
				return;
			}
			subModel.HeadStateManager.CreateMotorcycleBuffItem(descInfo);
		}, 0);
	}

	// Token: 0x060062C4 RID: 25284 RVA: 0x0018B11D File Offset: 0x0018931D
	public void UpdateCurrentGroupWaveIndex(GenerateGroup group)
	{
		if (!group.IsFinish())
		{
			return;
		}
		if (this.GetLastGenerateGroup() == group)
		{
			return;
		}
		this.SubController.GetModel().CurrentGroupWaveIndex = group.WaveGroupIndex + 1;
		this.SubController.EffectManager.OnEnterNextWaveGroup();
	}

	// Token: 0x060062C5 RID: 25285 RVA: 0x0018B15C File Offset: 0x0018935C
	public void OnSceneMoveEnd()
	{
		UKSC_World kscWorld = Singleton<KscEnv>.Instance.KscWorld;
		if (kscWorld != null)
		{
			UKSC_SceneMovement sceneMovement = kscWorld.SceneMovement;
			if (sceneMovement != null)
			{
				sceneMovement.OnSceneMoveThreshold.Unbind();
			}
		}
		this.WaitToNextSubLevel = false;
		if (this.WaitCollectionSelect.Count != 0)
		{
			KscLog.EModule flag = KscLog.EModule.Common;
			ELogAuthor author = ELogAuthor.TZQ;
			UObject kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
			string log = "[摩托战斗]等待藏品选择完毕再进入下一个子关卡";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Wait", this.WaitCollectionSelect);
			KscLog.Info(flag, author, kscWorld2, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.SubController.EnterNextSubLevel();
	}

	// Token: 0x060062C6 RID: 25286 RVA: 0x0018B1DE File Offset: 0x001893DE
	public int GenerateUniqueId(int subLevelIndex, int waveGroupIndex, int monsterId)
	{
		return monsterId * 1000000 + subLevelIndex * 1000 + waveGroupIndex;
	}

	// Token: 0x060062C7 RID: 25287 RVA: 0x0018B1F4 File Offset: 0x001893F4
	public unsafe void CreateBuffDropGate(int subLevelIndex, int waveGroupIndex, int monsterId, int buffGateIdRefreshId)
	{
		int num = this.GenerateUniqueId(subLevelIndex, waveGroupIndex, monsterId);
		global::Vector vector;
		if (!this.EntityDeadLocationMap.TryGetValue(num, out vector))
		{
			KscLog.EModule flag = KscLog.EModule.Common;
			ELogAuthor author = ELogAuthor.TZQ;
			UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
			string log = "[摩托战斗]buff门位置不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("RecordId", num);
			KscLog.Error(flag, author, kscWorld, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		MotorcycleArrowSubModel model = this.SubController.GetModel();
		global::Vector playerBornPos = model.PlayerBornPos;
		global::Vector playerDirect = this.SubController.GetModel().PlayerDirect;
		global::Vector commonTempVector = Singleton<MathUtils>.Instance.CommonTempVector;
		commonTempVector.Set(vector.X - playerBornPos.X, vector.Y - playerBornPos.Y, vector.Z - playerBornPos.Z);
		double num2 = Singleton<MathUtils>.Instance.DotProduct(playerDirect, commonTempVector);
		global::Vector vector2;
		if (num2 < (double)model.MotorArrowDropThreshold)
		{
			playerDirect.Multiply((double)model.MotorArrowDropThreshold - num2, Singleton<MathUtils>.Instance.CommonTempVector2);
			vector2 = Singleton<MathUtils>.Instance.CommonTempVector2;
			vector2.AdditionEqual(vector);
		}
		else
		{
			vector2 = global::Vector.Create(vector.X, vector.Y, vector.Z);
		}
		vector2.Z = playerBornPos.Z;
		FRotator frotator = this.BornRotation.ToUeRotator();
		FVectorDouble fvectorDouble = vector2.ToUeVector(false);
		FVector fvector = global::Vector.OneVectorDouble;
		FTransformDouble transform = new FTransformDouble(ref frotator, ref fvectorDouble, ref fvector);
		int num3 = this.SpawnBuffGate(buffGateIdRefreshId, transform, null);
		this.DropBuffGateMap[(long)num3] = new DropData
		{
			SubLevelIndex = subLevelIndex,
			WaveGroupIndex = waveGroupIndex,
			MonsterId = monsterId,
			BuffGateId = buffGateIdRefreshId
		};
		KscLog.EModule flag2 = KscLog.EModule.Common;
		ELogAuthor author2 = ELogAuthor.TZQ;
		UObject kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
		string log2 = "[摩托战斗]创建小怪掉落";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("recordId", num);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("creatureDataId", num3);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("BuffGateId", buffGateIdRefreshId);
		KscLog.Debug(flag2, author2, kscWorld2, log2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
	}

	// Token: 0x060062C8 RID: 25288 RVA: 0x0018B418 File Offset: 0x00189618
	public void OnBuffDropGateRemove(long creatureId)
	{
		IDropData dropData;
		if (!this.DropBuffGateMap.TryGetValue(creatureId, out dropData))
		{
			return;
		}
		this.AddBuffByBuffGate(this.BuffGateDescInfoMap[creatureId], dropData.WaveGroupIndex, dropData.BuffGateId, KscEntityRemoveReason.Dead, dropData.SubLevelIndex, 0);
		this.DropBuffGateMap.Remove(creatureId);
	}

	// Token: 0x060062C9 RID: 25289 RVA: 0x0018B46D File Offset: 0x0018966D
	[NullableContext(2)]
	public GenerateGroup GetCurGenerateGroup()
	{
		if (this.CurGenerateGroupIndex >= this.GenerateGroupList.Count)
		{
			return null;
		}
		return this.GenerateGroupList[this.CurGenerateGroupIndex];
	}

	// Token: 0x04002F34 RID: 12084
	private const float DIVIDED_TEN_THOUSAND = 0.0001f;

	// Token: 0x04002F35 RID: 12085
	public List<GenerateGroup> GenerateGroupList = new List<GenerateGroup>();

	// Token: 0x04002F36 RID: 12086
	public int CurGenerateGroupIndex;

	// Token: 0x04002F37 RID: 12087
	public global::Vector BornPos = global::Vector.Create(0.0, 0.0, 0.0);

	// Token: 0x04002F38 RID: 12088
	public global::Rotator BornRotation = global::Rotator.Create(0f, 0f, 0f);

	// Token: 0x04002F39 RID: 12089
	public global::Vector RightDirection = global::Vector.Create(0.0, 0.0, 0.0);

	// Token: 0x04002F3A RID: 12090
	public global::Vector ForwardDirection = global::Vector.Create(0.0, 0.0, 0.0);

	// Token: 0x04002F3B RID: 12091
	public Dictionary<long, GenerateGroup> EntityMap = new Dictionary<long, GenerateGroup>();

	// Token: 0x04002F3C RID: 12092
	public bool IsStartGenerate;

	// Token: 0x04002F3D RID: 12093
	public float EndDistance;

	// Token: 0x04002F3E RID: 12094
	public Dictionary<int, global::Vector> EntityDeadLocationMap = new Dictionary<int, global::Vector>();

	// Token: 0x04002F3F RID: 12095
	public Dictionary<long, IDropData> DropBuffGateMap = new Dictionary<long, IDropData>();

	// Token: 0x04002F40 RID: 12096
	public readonly Dictionary<long, int> CreatureIdToSplineId = new Dictionary<long, int>();

	// Token: 0x04002F41 RID: 12097
	public Dictionary<long, IBuffGateDesc> BuffGateDescInfoMap = new Dictionary<long, IBuffGateDesc>();

	// Token: 0x04002F42 RID: 12098
	public HashSet<int> WaitCollectionSelect = new HashSet<int>();

	// Token: 0x04002F43 RID: 12099
	public bool WaitToNextSubLevel;

	// Token: 0x04002F44 RID: 12100
	public HashSet<int> BuffGateBornGroup = new HashSet<int>();

	// Token: 0x04002F45 RID: 12101
	private int Uid = 1;

	// Token: 0x0200735D RID: 29533
	[NullableContext(0)]
	private enum EBornTrack
	{
		// Token: 0x04027F76 RID: 163702
		Left,
		// Token: 0x04027F77 RID: 163703
		Right,
		// Token: 0x04027F78 RID: 163704
		Middle
	}
}
