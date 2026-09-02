using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Core.Fight;
using AkiClient.Game.Aki.Core.Fight.Bullet;
using AkiClient.Game.Aki.Data.Fight;
using CSharpScript.Core.Common;
using CSharpScript.Game;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Module.CombatMessage;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Typing;
using UnrealEngine;

// Token: 0x02002E08 RID: 11784
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class BulletModel : ModelBase<BulletModel>
{
	// Token: 0x06017CD0 RID: 97488 RVA: 0x006A261C File Offset: 0x006A081C
	public OrderedDictionary<int, BulletEntity> GetBulletEntityMap()
	{
		return this.BulletEntityMap;
	}

	// Token: 0x06017CD1 RID: 97489 RVA: 0x006A2624 File Offset: 0x006A0824
	[NullableContext(2)]
	public BulletEntity GetBulletEntityById(int id)
	{
		BulletEntity result;
		this.BulletEntityMap.TryGetValue(id, out result);
		return result;
	}

	// Token: 0x06017CD2 RID: 97490 RVA: 0x006A2644 File Offset: 0x006A0844
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public IReadOnlyCollection<BulletEntity> GetBulletSetByAttacker(int attackerEntityId)
	{
		OrderedSet<BulletEntity> result;
		this.AttackerBullet.TryGetValue(attackerEntityId, out result);
		return result;
	}

	// Token: 0x06017CD3 RID: 97491 RVA: 0x006A2661 File Offset: 0x006A0861
	public IEnumerable<OrderedSet<BulletEntity>> GetAttackerBulletIterator()
	{
		return this.AttackerBullet.Values;
	}

	// Token: 0x06017CD4 RID: 97492 RVA: 0x006A266E File Offset: 0x006A086E
	public IEnumerable<int> GetAttackers()
	{
		return this.AttackerBullet.Keys;
	}

	// Token: 0x1700204B RID: 8267
	// (get) Token: 0x06017CD5 RID: 97493 RVA: 0x006A267B File Offset: 0x006A087B
	public int OnHitMaterialMsDelay
	{
		get
		{
			return this.OnHitMaterialDelayMsInternal;
		}
	}

	// Token: 0x1700204C RID: 8268
	// (get) Token: 0x06017CD6 RID: 97494 RVA: 0x006A2683 File Offset: 0x006A0883
	// (set) Token: 0x06017CD7 RID: 97495 RVA: 0x006A268C File Offset: 0x006A088C
	public bool OpenHitMaterial
	{
		get
		{
			return this.OpenHitMaterialInternal;
		}
		set
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Bullet;
			ELogAuthor author = ELogAuthor.HCW;
			string message = "Set Bullet Func OpenHitMaterial";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("val", value);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.OpenHitMaterialInternal = value;
		}
	}

	// Token: 0x06017CD8 RID: 97496 RVA: 0x006A26CC File Offset: 0x006A08CC
	protected override bool OnInit()
	{
		Singleton<ResourceSystem>.Instance.LoadAsync<BulletCommonDataAsset_C>("/Game/Aki/Data/Fight/BulletDataAsset/DA_CommonBullet.DA_CommonBullet", delegate([Nullable(2)] BulletCommonDataAsset_C result, string path)
		{
			this.CommonConfig = result;
			this.OnHitMaterialDelayMsInternal = (int)(result.OnHitMaterialDelay * 1000f);
		}, 100, "js_undefined");
		for (int i = 0; i < BulletModel.MaxBulletEntitySetCacheCount; i++)
		{
			this.BulletEntitySets.Add(new OrderedSet<BulletEntity>());
		}
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Add<PlotInfo>(EEventName.PlotNetworkStart, new Action<PlotInfo>(this.OnPlotStart));
		Singleton<EventSystem>.Instance.Add<PlotResultInfo>(EEventName.PlotNetworkEnd, new Action<PlotResultInfo>(this.OnPlotEnd));
		Singleton<EventSystem>.Instance.Add<ERemoveEntityType, EntityHandle>(EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
		if (Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
		{
			Singleton<EventSystem>.Instance.Add<global::HitInformation, IAttributeSet>(EEventName.BulletHit, new Action<global::HitInformation, IAttributeSet>(this.OnBulletHit));
		}
		this.InitBulletVictimPerformData();
		this.SummonerSummonedCreatureDataIds = new Dictionary<int, HashSet<long>>();
		this.SummonedCreatureDataIdToSummoner = new Dictionary<long, int>();
		return true;
	}

	// Token: 0x06017CD9 RID: 97497 RVA: 0x006A27D1 File Offset: 0x006A09D1
	private void OnWorldDone()
	{
		ConfigBase<BulletConfig>.Instance.PreloadCommonBulletData();
		BulletActorPool.Preload();
	}

	// Token: 0x06017CDA RID: 97498 RVA: 0x006A27E4 File Offset: 0x006A09E4
	public bool IsBulletHit(int entityId)
	{
		bool flag;
		return this.MapBulletHit.TryGetValue(entityId, out flag) && flag;
	}

	// Token: 0x06017CDB RID: 97499 RVA: 0x006A2801 File Offset: 0x006A0A01
	private void OnBulletHit(global::HitInformation hitData, [Nullable(2)] IAttributeSet attackerAttribute)
	{
		this.MapBulletHit[hitData.BulletEntityId] = true;
	}

	// Token: 0x06017CDC RID: 97500 RVA: 0x006A2818 File Offset: 0x006A0A18
	private void ClearBulletEntities()
	{
		foreach (BulletEntity obj in this.BulletEntityMap.Values)
		{
			BulletPool.RecycleBulletEntity(obj);
		}
		this.BulletEntityMap.Clear();
		foreach (OrderedSet<BulletEntity> orderedSet in this.AttackerBullet.Values)
		{
			orderedSet.Clear();
			this.BulletEntitySets.Add(orderedSet);
		}
		this.AttackerBullet.Clear();
		this.HandleToEntityIdDict.Clear();
		this.EntityIdToHandleDict.Clear();
	}

	// Token: 0x06017CDD RID: 97501 RVA: 0x006A28EC File Offset: 0x006A0AEC
	protected override bool OnLeaveLevel()
	{
		this.ClearBulletEntities();
		BulletActorPool.Clear();
		BulletTraceElementPool.Clear();
		BulletMoveInfo.StickGroundLineTrace = null;
		BulletMoveInfo.StickWaterLineTrace = null;
		BulletMoveInfo.StickWaterSphereTrace = null;
		this.ClearPersistentTimeScale();
		this.SceneBulletOwnerId = 0L;
		this.ClearWaitSceneBulletOwnerTask();
		this.ForceDestroyKuroBulletWorld();
		this.StopKscBullet();
		return true;
	}

	// Token: 0x06017CDE RID: 97502 RVA: 0x006A293C File Offset: 0x006A0B3C
	protected override bool OnChangeMode()
	{
		this.ClearBulletEntities();
		return true;
	}

	// Token: 0x06017CDF RID: 97503 RVA: 0x006A2948 File Offset: 0x006A0B48
	protected override bool OnClear()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Remove(EEventName.PlotNetworkStart, new Action<PlotInfo>(this.OnPlotStart));
		Singleton<EventSystem>.Instance.Remove(EEventName.PlotNetworkEnd, new Action<PlotResultInfo>(this.OnPlotEnd));
		Singleton<EventSystem>.Instance.Remove(EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
		if (Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.BulletHit, new Action<global::HitInformation, IAttributeSet>(this.OnBulletHit));
		}
		this.DefaultBulletSceneInteraction = null;
		this.CommonConfig = null;
		BulletActorPool.Clear();
		BulletTraceElementPool.Clear();
		this.MapCustomKey.Clear();
		this.CustomBulletAttacker.Clear();
		this.PatternOwnerEntityIds.Clear();
		this.BulletEntitySets.Clear();
		this.ClearBulletVictimPerformData();
		this.SceneBulletOwnerId = 0L;
		this.ClearWaitSceneBulletOwnerTask();
		Dictionary<int, HashSet<long>> summonerSummonedCreatureDataIds = this.SummonerSummonedCreatureDataIds;
		if (summonerSummonedCreatureDataIds != null)
		{
			summonerSummonedCreatureDataIds.Clear();
		}
		this.SummonerSummonedCreatureDataIds = null;
		Dictionary<long, int> summonedCreatureDataIdToSummoner = this.SummonedCreatureDataIdToSummoner;
		if (summonedCreatureDataIdToSummoner != null)
		{
			summonedCreatureDataIdToSummoner.Clear();
		}
		this.SummonedCreatureDataIdToSummoner = null;
		this.PatternHandleIdGen = 0;
		this.ForceDestroyKuroBulletWorld();
		this.StopKscBullet();
		return true;
	}

	// Token: 0x06017CE0 RID: 97504 RVA: 0x006A2A8C File Offset: 0x006A0C8C
	[NullableContext(2)]
	public unsafe BulletEntity CreateBullet([Nullable(1)] Entity owner, [Nullable(1)] string bulletRowName, FTransformDouble? initialTransform, FVectorDouble? initTargetLocation, int skillId = 0, int? parentId = null, bool fromRemote = false, int targetId = 0, int? baseTransformId = null, int? baseVelocityId = null, global::Vector size = null, BulletDataMain bulletData = null, global::EBulletSyncType syncType = global::EBulletSyncType.Local, long? contextId = null, long? skillContextId = null, Aki.Protocol.EBulletCreateSource source = Aki.Protocol.EBulletCreateSource.NormalSource, FVector? locationOffset = null, FRotator? beginRotatorOffset = null, IVector randomPosOffset = null, IVector randomInitSpeedOffset = null, ISkillBattleContext battleContext = null, [Nullable(new byte[]
	{
		2,
		1
	})] HashSet<string> parentIds = null, global::EBulletCreateSource createSource = global::EBulletCreateSource.Others)
	{
		bool flag = this.IsBulletDestroyWhenPlot(bulletRowName);
		if (this.PlotPlaying && flag)
		{
			return null;
		}
		if (owner == null || !owner.Valid)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Bullet;
			ELogAuthor author = ELogAuthor.LJQ;
			string message = "BulletModel.InitBullet 中止，攻击者已不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("子弹名称:", bulletRowName);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		BulletDataMain bulletDataMain = bulletData ?? ConfigBase<BulletConfig>.Instance.GetBulletData(owner, bulletRowName, true);
		if (bulletDataMain == null)
		{
			return null;
		}
		if (!fromRemote)
		{
			BaseTagComponent component = owner.GetComponent<BaseTagComponent>();
			int[] bornForbidTagIds = bulletDataMain.Base.BornForbidTagIds;
			if (bornForbidTagIds != null)
			{
				foreach (int tagId in bornForbidTagIds)
				{
					if (component.HasTag(tagId))
					{
						bool gasDebug = true;
						ELogAuthor author2 = ELogAuthor.HCW;
						string message2 = "BulletModel.InitBullet中止 攻击者存在该子弹禁止生成Tag ";
						BulletInfo bulletInfo = null;
						ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("子弹名称:", bulletRowName);
						BulletLog.Debug(gasDebug, author2, owner, message2, bulletInfo, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
						return null;
					}
				}
			}
			int[] bornRequireTagIds = bulletDataMain.Base.BornRequireTagIds;
			if (bornRequireTagIds != null)
			{
				foreach (int tagId2 in bornRequireTagIds)
				{
					if (!component.HasTag(tagId2))
					{
						bool gasDebug2 = true;
						ELogAuthor author3 = ELogAuthor.HCW;
						string message3 = "BulletModel.InitBullet中止 攻击者不存在该子弹生成所需Tag";
						BulletInfo bulletInfo2 = null;
						ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("子弹名称:", bulletRowName);
						BulletLog.Debug(gasDebug2, author3, owner, message3, bulletInfo2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
						return null;
					}
				}
			}
		}
		BulletInitParams initParams = new BulletInitParams(owner, bulletRowName, initialTransform, initTargetLocation, skillId, parentId.GetValueOrDefault(), targetId, (bulletDataMain.Base.BornPositionStandard != EPositionStandard.父子弹或外部位置 && bulletDataMain.Base.BornPositionStandard != EPositionStandard.世界位置) ? baseTransformId.GetValueOrDefault() : 0, baseVelocityId.GetValueOrDefault(), size, fromRemote, syncType, contextId, skillContextId, source, locationOffset, beginRotatorOffset, battleContext, createSource);
		BulletEntity bulletEntity = BulletPool.CreateBulletEntity();
		if (bulletEntity == null || !bulletEntity.Valid)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Bullet;
			ELogAuthor author4 = ELogAuthor.LJQ;
			string message4 = "BulletModel.InitBullet error, 子弹创建 失败!";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "子弹创建者:";
			BaseActorComponent component2 = owner.GetComponent<BaseActorComponent>();
			ptr = new ValueTuple<string, object>(item, (component2 != null) ? component2.Owner : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("子弹名称:", bulletRowName);
			instance2.Error(module2, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return null;
		}
		BulletInfo bulletInfo3 = bulletEntity.GetBulletInfo();
		if (parentIds != null)
		{
			if (parentIds.Contains(bulletRowName))
			{
				CombatLog instance3 = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.Bullet;
				string message5 = "父子弹链中存在当前子弹ID";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("父子弹链", string.Join(",", parentIds));
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("当前子弹", bulletRowName);
				instance3.Error(flag2, owner, message5, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				return null;
			}
			if (bulletInfo3.ParentIds != null)
			{
				using (HashSet<string>.Enumerator enumerator = parentIds.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						string item2 = enumerator.Current;
						bulletInfo3.ParentIds.Add(item2);
					}
					goto IL_2CC;
				}
			}
			bulletInfo3.ParentIds = parentIds;
		}
		IL_2CC:
		if (fromRemote)
		{
			if (randomPosOffset != null)
			{
				bulletInfo3.RandomPosOffset.FromUeVector(randomPosOffset);
			}
			if (randomInitSpeedOffset != null)
			{
				bulletInfo3.RandomInitSpeedOffset.FromUeVector(randomInitSpeedOffset);
			}
		}
		bulletInfo3.Init(initParams, bulletDataMain);
		bulletInfo3.InitEntity(bulletEntity);
		this.BulletEntityMap[bulletEntity.Id] = bulletEntity;
		if (Singleton<BulletConstant>.Instance.OpenCreateLog)
		{
			BulletLog.Debug(false, ELogAuthor.CFT, null, "创建子弹", bulletInfo3, default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		int attackerId = bulletInfo3.AttackerId;
		OrderedSet<BulletEntity> orderedSet;
		if (this.AttackerBullet.TryGetValue(attackerId, out orderedSet))
		{
			orderedSet.Add(bulletEntity);
		}
		else
		{
			OrderedSet<BulletEntity> orderedSet2 = (this.BulletEntitySets.Count > 0) ? this.BulletEntitySets[this.BulletEntitySets.Count - 1] : new OrderedSet<BulletEntity>();
			if (this.BulletEntitySets.Count > 0)
			{
				this.BulletEntitySets.RemoveAt(this.BulletEntitySets.Count - 1);
			}
			this.AttackerBullet[attackerId] = orderedSet2;
			orderedSet2.Add(bulletEntity);
		}
		this.InitAddition(owner, bulletRowName, bulletInfo3);
		Singleton<EntitySystem>.Instance.Start(bulletEntity);
		Singleton<EntitySystem>.Instance.Activate(bulletEntity);
		Singleton<EntitySystem>.Instance.PostActive(bulletEntity);
		ControllerBase<BulletController>.Instance.AddSimpleAction(bulletInfo3, EBulletAction.InitBullet);
		if (flag)
		{
			this.BulletEntityDestroyWhenPlot.Add(bulletEntity.Id);
		}
		return bulletEntity;
	}

	// Token: 0x06017CE1 RID: 97505 RVA: 0x006A2EC8 File Offset: 0x006A10C8
	private void InitAddition(Entity owner, string bulletRowName, BulletInfo bulletInfo)
	{
		CharacterBuffComponent component = owner.GetComponent<CharacterBuffComponent>();
		ExtraEffectManager extraEffectManager = (component != null) ? component.BuffEffectManager : null;
		if (extraEffectManager != null)
		{
			IEnumerable<AdditionBulletSize> enumerable = extraEffectManager.FilterById<AdditionBulletSize>(EExtraEffectId.AdditionBulletSize, null);
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			foreach (AdditionBulletSize additionBulletSize in enumerable)
			{
				ValueTuple<float, float, float>? bulletSizeScale = additionBulletSize.GetBulletSizeScale(bulletRowName);
				if (bulletSizeScale != null)
				{
					num += bulletSizeScale.Value.Item1;
					num2 += bulletSizeScale.Value.Item2;
					num3 += bulletSizeScale.Value.Item3;
				}
			}
			IEnumerable<AdditionBulletDuration> enumerable2 = extraEffectManager.FilterById<AdditionBulletDuration>(EExtraEffectId.AdditionBulletDuration, null);
			float num4 = 0f;
			foreach (AdditionBulletDuration additionBulletDuration in enumerable2)
			{
				num4 += additionBulletDuration.GetBulletDuration(bulletRowName);
			}
			IEnumerable<AdditionBulletInterval> enumerable3 = extraEffectManager.FilterById<AdditionBulletInterval>(EExtraEffectId.AdditionBulletInterval, null);
			float num5 = 0f;
			foreach (AdditionBulletInterval additionBulletInterval in enumerable3)
			{
				num5 += additionBulletInterval.GetBulletInterval(bulletRowName);
			}
			bool flag = num == 0f && num2 == 0f && num3 == 0f;
			if (!flag || num4 != 0f || num5 != 0f)
			{
				BulletAdditionInfo bulletAdditionInfo = new BulletAdditionInfo();
				bulletAdditionInfo.Init();
				if (!flag)
				{
					bulletAdditionInfo.SizeScale.Set((double)num, (double)num2, (double)num3);
					bulletAdditionInfo.SizeScale.AdditionEqual(global::Vector.OneVectorProxy);
				}
				bulletAdditionInfo.DurationAddition = num4;
				bulletAdditionInfo.IntervalScale = 1f + num5;
				bulletInfo.AdditionInfo = bulletAdditionInfo;
			}
		}
	}

	// Token: 0x06017CE2 RID: 97506 RVA: 0x006A30AC File Offset: 0x006A12AC
	public void DestroyBullet(int id, bool summonChild, EBulletDestroyReason destroyReason = EBulletDestroyReason.Normal, bool destroyEffectImmediately = false)
	{
		BulletEntity bulletEntity;
		if (!this.BulletEntityMap.TryGetValue(id, out bulletEntity))
		{
			return;
		}
		BulletInfo bulletInfo = bulletEntity.GetBulletInfo();
		ModelBase<CombatMessageModel>.Instance.OnBulletRemoved(bulletInfo.BulletInitParams.SkillContextId, bulletInfo.ContextIdRaw);
		if (bulletInfo.NeedDestroy)
		{
			return;
		}
		bulletInfo.NeedDestroy = true;
		if (Singleton<BulletConstant>.Instance.OpenDestroyLog)
		{
			BulletLog.Error(true, ELogAuthor.HCW, bulletInfo.Attacker, "销毁子弹开始", bulletInfo, default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		else if (Singleton<BulletConstant>.Instance.OpenCreateLog)
		{
			BulletLog.Debug(true, ELogAuthor.HCW, bulletInfo.Attacker, "销毁子弹开始", bulletInfo, default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		string bulletRowName = bulletInfo.BulletRowName;
		BulletActionInfoDestroyBullet bulletActionInfoDestroyBullet = ControllerBase<BulletController>.Instance.GetActionCenter().CreateBulletActionInfo(EBulletAction.DestroyBullet) as BulletActionInfoDestroyBullet;
		bulletActionInfoDestroyBullet.SummonChild = summonChild;
		bulletActionInfoDestroyBullet.DestroyReason = new EBulletDestroyReason?(destroyReason);
		bulletActionInfoDestroyBullet.DestroyEffectImmediately = destroyEffectImmediately;
		this.NeedDestroyBullets.Add(id);
		ControllerBase<BulletController>.Instance.GetActionRunner().AddAction(bulletInfo, bulletActionInfoDestroyBullet);
	}

	// Token: 0x06017CE3 RID: 97507 RVA: 0x006A31A8 File Offset: 0x006A13A8
	public void DestroyAllBullet(bool summonChild = false)
	{
		foreach (int id in this.BulletEntityMap.Keys)
		{
			this.DestroyBullet(id, summonChild, EBulletDestroyReason.Normal, false);
		}
	}

	// Token: 0x06017CE4 RID: 97508 RVA: 0x006A3204 File Offset: 0x006A1404
	public unsafe void ClearDestroyedBullets()
	{
		foreach (int num in this.NeedDestroyBullets)
		{
			BulletEntity bulletEntity;
			if (this.BulletEntityMap.TryGetValue(num, out bulletEntity))
			{
				BulletInfo bulletInfo = bulletEntity.GetBulletInfo();
				int attackerId = bulletInfo.AttackerId;
				OrderedSet<BulletEntity> orderedSet;
				if (!this.AttackerBullet.TryGetValue(attackerId, out orderedSet))
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Bullet;
					ELogAuthor author = ELogAuthor.LJQ;
					string message = "BulletModel.DestroyBullet Warn, 获取被销毁子弹所在集合 失败！ ";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("子弹创建者Id:", attackerId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("子弹:", bulletEntity);
					instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
				else
				{
					orderedSet.Remove(bulletEntity);
					if (orderedSet.Count == 0)
					{
						this.AttackerBullet.Remove(attackerId);
						this.BulletEntitySets.Add(orderedSet);
					}
				}
				ActiveBulletHandle bulletHandleById = this.GetBulletHandleById(num);
				if (bulletHandleById != null)
				{
					DestroyBulletPush destroyBulletPush = DestroyBulletPush.Create();
					destroyBulletPush.Handle = bulletHandleById;
					Singleton<CombatNet>.Instance.Send(EPushMessageId.DestroyBulletPush, bulletInfo.Attacker, destroyBulletPush, null, null, null);
					if (Singleton<BulletConstant>.Instance.OpenCreateLog)
					{
						BulletLog.Debug(false, ELogAuthor.HCW, null, "销毁子弹 发送协议", bulletInfo, default(ReadOnlySpan<ValueTuple<string, object>>));
					}
					this.DeregisterBullet(bulletHandleById);
				}
				if (Singleton<BulletConstant>.Instance.OpenCreateLog)
				{
					bool gasDebug = true;
					ELogAuthor author2 = ELogAuthor.HCW;
					Entity attacker = bulletInfo.Attacker;
					string message2 = "销毁子弹完成";
					BulletInfo bulletInfo2 = null;
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("BulletId", bulletInfo.BulletRowName);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("EntityId", bulletInfo.BulletEntityId);
					BulletLog.Debug(gasDebug, author2, attacker, message2, bulletInfo2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				}
				this.BulletEntityMap.Remove(num);
				BulletPool.RecycleBulletEntity(bulletEntity);
			}
		}
		this.NeedDestroyBullets.Clear();
	}

	// Token: 0x06017CE5 RID: 97509 RVA: 0x006A3434 File Offset: 0x006A1634
	[return: Nullable(new byte[]
	{
		2,
		0
	})]
	public unsafe TArray<TEnumAsByte<EObjectTypeQuery>> GetFastMoveTrace(string profileName, string bulletRowName)
	{
		if (profileName == "Bullet_Type1")
		{
			return this.CommonConfig.FastMoveTraceBullet_Type1;
		}
		if (!(profileName == "Bullet_Type2"))
		{
			if (!(profileName == "Bullet_Type3"))
			{
				if (!(profileName == "Bullet_Type1_Special"))
				{
					if (!(profileName == "Bullet_Type2_Special"))
					{
						if (!(profileName == "Bullet_OnlyBullet"))
						{
							Log instance = Singleton<Log>.Instance;
							ELogModule module = ELogModule.Bullet;
							ELogAuthor author = ELogAuthor.HCW;
							string message = "找不到快速移动对应的检测类型配置";
							<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("bulletRowName", bulletRowName);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("profileName", profileName);
							instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
							return null;
						}
						BulletCommonDataAsset_C commonConfig = this.CommonConfig;
						if (commonConfig == null)
						{
							return null;
						}
						return commonConfig.FastMoveTraceBullet_Only_Bullet;
					}
					else
					{
						BulletCommonDataAsset_C commonConfig2 = this.CommonConfig;
						if (commonConfig2 == null)
						{
							return null;
						}
						return commonConfig2.FastMoveTraceBullet_Type2_Special;
					}
				}
				else
				{
					BulletCommonDataAsset_C commonConfig3 = this.CommonConfig;
					if (commonConfig3 == null)
					{
						return null;
					}
					return commonConfig3.FastMoveTraceBullet_Type1_Special;
				}
			}
			else
			{
				BulletCommonDataAsset_C commonConfig4 = this.CommonConfig;
				if (commonConfig4 == null)
				{
					return null;
				}
				return commonConfig4.FastMoveTraceBullet_Type3;
			}
		}
		else
		{
			BulletCommonDataAsset_C commonConfig5 = this.CommonConfig;
			if (commonConfig5 == null)
			{
				return null;
			}
			return commonConfig5.FastMoveTraceBullet_Type2;
		}
	}

	// Token: 0x1700204D RID: 8269
	// (get) Token: 0x06017CE6 RID: 97510 RVA: 0x006A354B File Offset: 0x006A174B
	[Nullable(new byte[]
	{
		1,
		0
	})]
	public TArray<TEnumAsByte<EObjectTypeQuery>> ObjectTypeTakeAim
	{
		[return: Nullable(new byte[]
		{
			1,
			0
		})]
		get
		{
			return this.CommonConfig.TakeAim;
		}
	}

	// Token: 0x1700204E RID: 8270
	// (get) Token: 0x06017CE7 RID: 97511 RVA: 0x006A3558 File Offset: 0x006A1758
	[Nullable(new byte[]
	{
		1,
		0
	})]
	public TArray<TEnumAsByte<EObjectTypeQuery>> ObjectTypeObstacles
	{
		[return: Nullable(new byte[]
		{
			1,
			0
		})]
		get
		{
			return this.CommonConfig.Obstacles;
		}
	}

	// Token: 0x1700204F RID: 8271
	// (get) Token: 0x06017CE8 RID: 97512 RVA: 0x006A3565 File Offset: 0x006A1765
	[Nullable(new byte[]
	{
		1,
		0
	})]
	public TArray<TEnumAsByte<EObjectTypeQuery>> ObjectTypeHitPoint
	{
		[return: Nullable(new byte[]
		{
			1,
			0
		})]
		get
		{
			return this.CommonConfig.HitPoint;
		}
	}

	// Token: 0x06017CE9 RID: 97513 RVA: 0x006A3574 File Offset: 0x006A1774
	[NullableContext(2)]
	public void RegisterBullet(ActiveBulletHandle handle, int bulletEntityId)
	{
		if (handle == null)
		{
			return;
		}
		int playerId = handle.PlayerId;
		int handleId = handle.HandleId;
		this.EntityIdToHandleDict[bulletEntityId] = handle;
		if (!this.HandleToEntityIdDict.ContainsKey(playerId))
		{
			this.HandleToEntityIdDict[playerId] = new Dictionary<int, int>();
		}
		this.HandleToEntityIdDict[playerId][handleId] = bulletEntityId;
	}

	// Token: 0x06017CEA RID: 97514 RVA: 0x006A35D4 File Offset: 0x006A17D4
	[NullableContext(2)]
	public void DeregisterBullet(ActiveBulletHandle handle)
	{
		if (handle == null)
		{
			return;
		}
		int idByBulletHandle = this.GetIdByBulletHandle(handle);
		if (this.EntityIdToHandleDict.ContainsKey(idByBulletHandle))
		{
			this.EntityIdToHandleDict.Remove(idByBulletHandle);
		}
		if (this.HandleToEntityIdDict.ContainsKey(handle.PlayerId))
		{
			int playerId = handle.PlayerId;
			int handleId = handle.HandleId;
			Dictionary<int, int> dictionary = this.HandleToEntityIdDict[playerId];
			dictionary.Remove(handleId);
			if (dictionary.Count <= 0)
			{
				this.HandleToEntityIdDict.Remove(playerId);
			}
		}
	}

	// Token: 0x06017CEB RID: 97515 RVA: 0x006A3654 File Offset: 0x006A1854
	[NullableContext(2)]
	public int GetIdByBulletHandle(ActiveBulletHandle handle)
	{
		if (handle == null)
		{
			return 0;
		}
		int playerId = handle.PlayerId;
		int handleId = handle.HandleId;
		Dictionary<int, int> dictionary;
		int result;
		if (this.HandleToEntityIdDict.TryGetValue(playerId, out dictionary) && dictionary.TryGetValue(handleId, out result))
		{
			return result;
		}
		return 0;
	}

	// Token: 0x06017CEC RID: 97516 RVA: 0x006A3694 File Offset: 0x006A1894
	[NullableContext(2)]
	public ActiveBulletHandle GetBulletHandleById(int bulletEntityId)
	{
		ActiveBulletHandle result;
		this.EntityIdToHandleDict.TryGetValue(bulletEntityId, out result);
		return result;
	}

	// Token: 0x06017CED RID: 97517 RVA: 0x006A36B4 File Offset: 0x006A18B4
	public void SendDodgeInfoPush(Entity dodgeEntity, long bulletOwnerCreatureDataId, long bulletId, long? preMessageId = null)
	{
		if (!dodgeEntity.Valid || bulletOwnerCreatureDataId <= 0L)
		{
			return;
		}
		DodgeInfoPush dodgeInfoPush = DodgeInfoPush.Create();
		dodgeInfoPush.BulletOwnerId = Singleton<MathUtils>.Instance.NumberToLong(bulletOwnerCreatureDataId);
		dodgeInfoPush.BulletId = bulletId;
		Singleton<CombatNet>.Instance.Send(EPushMessageId.DodgeInfoPush, dodgeEntity, dodgeInfoPush, preMessageId, null, null);
	}

	// Token: 0x06017CEE RID: 97518 RVA: 0x006A3714 File Offset: 0x006A1914
	[NullableContext(2)]
	public void DestroyBulletRemote(ActiveBulletHandle handle, bool summonChild)
	{
		if (handle == null || !this.HandleToEntityIdDict.ContainsKey(handle.PlayerId))
		{
			return;
		}
		int idByBulletHandle = this.GetIdByBulletHandle(handle);
		if (idByBulletHandle != 0)
		{
			this.DeregisterBullet(handle);
			this.DestroyBullet(idByBulletHandle, summonChild, EBulletDestroyReason.FromRemote, false);
		}
	}

	// Token: 0x06017CEF RID: 97519 RVA: 0x006A3754 File Offset: 0x006A1954
	public T NewTraceElement<[Nullable(0)] T>([Nullable(new byte[]
	{
		1,
		0
	})] TArray<TEnumAsByte<EObjectTypeQuery>> traceObjectType, [Nullable(2)] HashSet<EObjectTypeQuery> ignoreObjectType = null, bool bIsSingle = false) where T : UTraceBaseElement, new()
	{
		T t = Activator.CreateInstance<T>();
		t.WorldContextObject = GlobalData.World;
		if (traceObjectType != null)
		{
			for (int i = 0; i < traceObjectType.Num(); i++)
			{
				TEnumAsByte<EObjectTypeQuery> value = traceObjectType.Get(i);
				if (ignoreObjectType == null || !ignoreObjectType.Contains(value))
				{
					t.AddObjectTypeQuery(value);
				}
			}
		}
		t.bTraceComplex = false;
		t.bIgnoreSelf = true;
		return t;
	}

	// Token: 0x06017CF0 RID: 97520 RVA: 0x006A37D0 File Offset: 0x006A19D0
	public unsafe int GetEntityIdByCustomKey(int attackerId, string key, string bulletRowName)
	{
		string text = key + attackerId.ToString();
		int num;
		if (!this.MapCustomKey.TryGetValue(text, out num))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Bullet;
			ELogAuthor author = ELogAuthor.HCW;
			string message = "获取自定义目标失败";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Bullet", bulletRowName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Key", text);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Entity", num);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return 0;
		}
		return num;
	}

	// Token: 0x06017CF1 RID: 97521 RVA: 0x006A3870 File Offset: 0x006A1A70
	public unsafe void SetEntityIdByCustomKey(int attackerId, string customKey, int targetId)
	{
		string text = customKey + attackerId.ToString();
		this.MapCustomKey[text] = targetId;
		if (targetId == 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Bullet;
			ELogAuthor author = ELogAuthor.HCW;
			string message = "设置自定义目标失败";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Key", text);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Entity", targetId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
	}

	// Token: 0x06017CF2 RID: 97522 RVA: 0x006A38F4 File Offset: 0x006A1AF4
	public int? GetCustomBulletAttacker(string customKey)
	{
		int value;
		if (this.CustomBulletAttacker.TryGetValue(customKey, out value))
		{
			return new int?(value);
		}
		return null;
	}

	// Token: 0x06017CF3 RID: 97523 RVA: 0x006A3921 File Offset: 0x006A1B21
	public void SetCustomBulletAttacker(string customKey, int attackerId)
	{
		this.CustomBulletAttacker[customKey] = attackerId;
	}

	// Token: 0x06017CF4 RID: 97524 RVA: 0x006A3930 File Offset: 0x006A1B30
	public bool RemoveCustomBulletAttacker(string customKey)
	{
		return this.CustomBulletAttacker.Remove(customKey);
	}

	// Token: 0x06017CF5 RID: 97525 RVA: 0x006A3940 File Offset: 0x006A1B40
	public bool ShowBulletCollision(int entityId = 0)
	{
		bool flag;
		return this.MapAttackerDrawCollision.ContainsKey(entityId) && (this.MapAttackerDrawCollision.TryGetValue(entityId, out flag) && flag);
	}

	// Token: 0x06017CF6 RID: 97526 RVA: 0x006A3970 File Offset: 0x006A1B70
	public bool ShowBulletTrace(int entityId = 0)
	{
		bool flag;
		return this.MapAttackerDrawTrace.ContainsKey(entityId) && (this.MapAttackerDrawTrace.TryGetValue(entityId, out flag) && flag);
	}

	// Token: 0x06017CF7 RID: 97527 RVA: 0x006A399D File Offset: 0x006A1B9D
	public void SetBulletCollisionDraw(int entityId, bool enable)
	{
		this.MapAttackerDrawCollision[entityId] = enable;
	}

	// Token: 0x06017CF8 RID: 97528 RVA: 0x006A39AC File Offset: 0x006A1BAC
	public void SetBulletTraceDraw(int entityId, bool enable)
	{
		this.MapAttackerDrawTrace[entityId] = enable;
	}

	// Token: 0x06017CF9 RID: 97529 RVA: 0x006A39BC File Offset: 0x006A1BBC
	private void InitBulletVictimPerformData()
	{
		this.SelfAdaptBeHitAnim = new HashSet<EHitAnim>
		{
			EHitAnim.轻左,
			EHitAnim.轻右,
			EHitAnim.重左,
			EHitAnim.重右,
			EHitAnim.轻前,
			EHitAnim.轻后,
			EHitAnim.重前,
			EHitAnim.重后
		};
		this.HeavyHitAnim = new HashSet<EHitAnim>
		{
			EHitAnim.重左,
			EHitAnim.重右,
			EHitAnim.重前,
			EHitAnim.重后
		};
		this.Index2LightHitAnimMap = new EHitAnim[]
		{
			EHitAnim.轻前,
			EHitAnim.轻右,
			EHitAnim.轻后,
			EHitAnim.轻左
		};
		this.Index2HeavyHitAnimMap = new EHitAnim[]
		{
			EHitAnim.重前,
			EHitAnim.重右,
			EHitAnim.重后,
			EHitAnim.重左
		};
	}

	// Token: 0x06017CFA RID: 97530 RVA: 0x006A3A72 File Offset: 0x006A1C72
	private void ClearBulletVictimPerformData()
	{
		this.SelfAdaptBeHitAnim = null;
		this.HeavyHitAnim = null;
		this.Index2LightHitAnimMap = null;
		this.Index2HeavyHitAnimMap = null;
	}

	// Token: 0x06017CFB RID: 97531 RVA: 0x006A3A90 File Offset: 0x006A1C90
	private bool IsBulletDestroyWhenPlot(string bulletRowName)
	{
		return bulletRowName == "310000001";
	}

	// Token: 0x06017CFC RID: 97532 RVA: 0x006A3AA0 File Offset: 0x006A1CA0
	private void OnPlotStart(PlotInfo plotInfo)
	{
		if (plotInfo.PlotLevel != EPlotLevel.LevelA && plotInfo.PlotLevel != EPlotLevel.LevelB && plotInfo.PlotLevel != EPlotLevel.LevelC)
		{
			return;
		}
		this.PlotPlaying = true;
		foreach (int id in this.BulletEntityDestroyWhenPlot)
		{
			this.DestroyBullet(id, false, EBulletDestroyReason.Normal, false);
		}
		this.BulletEntityDestroyWhenPlot.Clear();
		this.SetAllBulletEffectHidden(true);
	}

	// Token: 0x06017CFD RID: 97533 RVA: 0x006A3B2C File Offset: 0x006A1D2C
	private void OnPlotEnd(PlotResultInfo plotResultInfo)
	{
		if (!this.PlotPlaying)
		{
			return;
		}
		this.SetAllBulletEffectHidden(false);
		this.PlotPlaying = false;
	}

	// Token: 0x06017CFE RID: 97534 RVA: 0x006A3B48 File Offset: 0x006A1D48
	[NullableContext(2)]
	public int SetAllBulletTimeScale(global::Vector centerLocation, float radius, int priority, float timeDilation, UCurveFloat curve, float duration, bool isPersistent)
	{
		this.PersistentTimeScaleId--;
		int persistentTimeScaleId = this.PersistentTimeScaleId;
		foreach (BulletEntity bulletEntity in this.GetBulletEntityMap().Values)
		{
			BulletInfo bulletInfo = bulletEntity.GetBulletInfo();
			if (bulletInfo.IsInit && !bulletInfo.NeedDestroy && !bulletInfo.BulletDataMain.TimeScale.TimeScaleWithAttacker)
			{
				if (centerLocation != null)
				{
					global::Vector lastFramePosition = bulletInfo.CollisionInfo.LastFramePosition;
					if (lastFramePosition == null || MathF.Abs((float)(lastFramePosition.X - centerLocation.X)) > radius || MathF.Abs((float)(lastFramePosition.Y - centerLocation.Y)) > radius || MathF.Abs((float)(lastFramePosition.Z - centerLocation.Z)) > radius)
					{
						continue;
					}
				}
				BulletUtil.SetTimeScale(bulletInfo, priority, timeDilation, curve, duration, ETimeScaleSourceType.BattleSettlement, 0.0, persistentTimeScaleId);
			}
		}
		if (isPersistent)
		{
			this.PersistentTimeScaleMap[persistentTimeScaleId] = new BulletPersistentTimeScale(centerLocation, radius, (float)Singleton<Time>.Instance.WorldTimeSeconds, priority, timeDilation, curve, duration, ETimeScaleSourceType.BattleSettlement, persistentTimeScaleId);
		}
		return persistentTimeScaleId;
	}

	// Token: 0x06017CFF RID: 97535 RVA: 0x006A3C78 File Offset: 0x006A1E78
	public void RemoveAllBulletTimeScale(int timeScaleId, bool isPersistent)
	{
		foreach (BulletEntity bulletEntity in this.GetBulletEntityMap().Values)
		{
			BulletInfo bulletInfo = bulletEntity.GetBulletInfo();
			if (bulletInfo.IsInit)
			{
				BulletUtil.RemoveTimeScale(bulletInfo, timeScaleId);
			}
		}
		if (isPersistent)
		{
			this.PersistentTimeScaleMap.Remove(timeScaleId);
		}
	}

	// Token: 0x06017D00 RID: 97536 RVA: 0x006A3CF0 File Offset: 0x006A1EF0
	private void ClearPersistentTimeScale()
	{
		this.PersistentTimeScaleId = 0;
		this.PersistentTimeScaleMap.Clear();
	}

	// Token: 0x17002050 RID: 8272
	// (get) Token: 0x06017D01 RID: 97537 RVA: 0x006A3D04 File Offset: 0x006A1F04
	// (set) Token: 0x06017D02 RID: 97538 RVA: 0x006A3D0C File Offset: 0x006A1F0C
	public long SceneBulletOwnerId
	{
		get
		{
			return this.SceneBulletOwnerIdInternal;
		}
		set
		{
			this.SceneBulletOwnerIdInternal = value;
		}
	}

	// Token: 0x06017D03 RID: 97539 RVA: 0x006A3D18 File Offset: 0x006A1F18
	[NullableContext(2)]
	public CustomPromise<bool> WaitSceneBulletOwnerInit()
	{
		long creatureDataId = this.SceneBulletOwnerId;
		if (creatureDataId == 0L)
		{
			Singleton<Log>.Instance.Error(ELogModule.Bullet, ELogAuthor.CFT, "等待场景子弹owner创建失败, creatureDataId为0", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		if (this.PreloadPromise != null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Bullet, ELogAuthor.CFT, "重复调用WaitSceneBulletOwnerInit", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		this.PreloadPromise = new CustomPromise<bool>();
		this.ClearWaitSceneBulletOwnerTask();
		this.WaitSceneBulletOwnerTask = WaitEntityTask.Create("BulletModel.WaitSceneBulletOwnerInit", creatureDataId, delegate(bool? result)
		{
			if (!result.GetValueOrDefault())
			{
				Singleton<Log>.Instance.Warn(ELogModule.Bullet, ELogAuthor.CFT, "等待场景子弹owner创建失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				CustomPromise<bool> preloadPromise = this.PreloadPromise;
				if (preloadPromise == null)
				{
					return;
				}
				preloadPromise.SetResult(false);
				return;
			}
			else
			{
				if (this.SceneBulletOwnerId == creatureDataId)
				{
					this.WaitSceneBulletOwnerTask = null;
					this.IsSceneBulletOwnerCreated = true;
					CustomPromise<bool> preloadPromise2 = this.PreloadPromise;
					if (preloadPromise2 != null)
					{
						preloadPromise2.SetResult(true);
					}
					this.PreloadPromise = null;
					Singleton<EventSystem>.Instance.Emit(EEventName.SceneBulletOwnerCreated);
					return;
				}
				Singleton<Log>.Instance.Warn(ELogModule.Bullet, ELogAuthor.CFT, "等待场景子弹owner创建返回时，creatureDataId已改变", default(ReadOnlySpan<ValueTuple<string, object>>));
				CustomPromise<bool> preloadPromise3 = this.PreloadPromise;
				if (preloadPromise3 == null)
				{
					return;
				}
				preloadPromise3.SetResult(false);
				return;
			}
		}, -1, true, false);
		if (this.IsSceneBulletOwnerCreated)
		{
			this.WaitSceneBulletOwnerTask = null;
			return null;
		}
		return this.PreloadPromise;
	}

	// Token: 0x06017D04 RID: 97540 RVA: 0x006A3DD7 File Offset: 0x006A1FD7
	private void ClearWaitSceneBulletOwnerTask()
	{
		this.IsSceneBulletOwnerCreated = false;
		if (this.WaitSceneBulletOwnerTask != null)
		{
			this.WaitSceneBulletOwnerTask.Cancel();
			this.WaitSceneBulletOwnerTask = null;
		}
	}

	// Token: 0x06017D05 RID: 97541 RVA: 0x006A3DFC File Offset: 0x006A1FFC
	private void SetAllBulletEffectHidden(bool hidden)
	{
		foreach (BulletEntity bulletEntity in this.BulletEntityMap.Values)
		{
			this.SetBulletEffectHidden(bulletEntity, hidden);
		}
	}

	// Token: 0x06017D06 RID: 97542 RVA: 0x006A3E58 File Offset: 0x006A2058
	[NullableContext(2)]
	private void SetBulletEffectHidden(BulletEntity bulletEntity, bool hidden)
	{
		if (bulletEntity == null || !bulletEntity.Valid)
		{
			return;
		}
		BulletInfo bulletInfo = bulletEntity.GetBulletInfo();
		Singleton<EffectSystem>.Instance.SetEffectHidden(bulletInfo.EffectInfo.Effect, hidden, "演出子弹特效清场", false);
	}

	// Token: 0x06017D07 RID: 97543 RVA: 0x006A3E9C File Offset: 0x006A209C
	public void SummonerSummon(int summonerId, long creatureDataId)
	{
		if (!this.SummonerSummonedCreatureDataIds.ContainsKey(summonerId))
		{
			this.SummonerSummonedCreatureDataIds[summonerId] = new HashSet<long>();
		}
		this.SummonerSummonedCreatureDataIds[summonerId].Add(creatureDataId);
		this.SummonedCreatureDataIdToSummoner[creatureDataId] = summonerId;
	}

	// Token: 0x06017D08 RID: 97544 RVA: 0x006A3EE8 File Offset: 0x006A20E8
	public List<int> GetSummonEntityIds(int summonerId)
	{
		List<int> list = new List<int>();
		if (this.SummonerSummonedCreatureDataIds.ContainsKey(summonerId))
		{
			foreach (long num in this.SummonerSummonedCreatureDataIds[summonerId])
			{
				int entityId = ModelBase<CreatureModel>.Instance.GetEntityId(num);
				if (entityId != 0)
				{
					list.Add(entityId);
				}
				else
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Bullet;
					ELogAuthor author = ELogAuthor.XDW;
					string message = "[BulletModel] 不存在实体Id";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CreatureDataId", num);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
			}
		}
		return list;
	}

	// Token: 0x06017D09 RID: 97545 RVA: 0x006A3F98 File Offset: 0x006A2198
	private void OnRemoveEntity(ERemoveEntityType removeType, EntityHandle handle)
	{
		int id = handle.Id;
		if (id != 0)
		{
			OrderedSet<BulletEntity> orderedSet;
			if (this.AttackerBullet.TryGetValue(id, out orderedSet) && orderedSet.Count > 0)
			{
				foreach (BulletEntity bulletEntity in orderedSet)
				{
					ControllerBase<BulletController>.Instance.DestroyBullet(bulletEntity.Id, false, EBulletDestroyReason.Normal, false);
				}
			}
			if (this.PatternOwnerEntityIds.Contains(id))
			{
				this.DestroyPatternsByOwner(handle);
			}
		}
		long creatureDataId = ModelBase<CreatureModel>.Instance.GetCreatureDataId(handle.Id);
		if (this.SummonedCreatureDataIdToSummoner.ContainsKey(creatureDataId))
		{
			int key = this.SummonedCreatureDataIdToSummoner[creatureDataId];
			this.SummonedCreatureDataIdToSummoner.Remove(creatureDataId);
			if (this.SummonerSummonedCreatureDataIds.ContainsKey(key))
			{
				this.SummonerSummonedCreatureDataIds[key].Remove(creatureDataId);
			}
		}
	}

	// Token: 0x06017D0A RID: 97546 RVA: 0x006A408C File Offset: 0x006A228C
	public unsafe int SpawnPattern(Entity ownerEntity, UKuroBulletPatternDataAsset patternData, FWorldEntityBulletParam extraParam)
	{
		if (ownerEntity == null || !ownerEntity.Valid)
		{
			return 0;
		}
		if (patternData == null || !patternData.IsValid())
		{
			return 0;
		}
		BaseActorComponent component = ownerEntity.GetComponent<BaseActorComponent>();
		AActor aactor = (component != null) ? component.Owner : null;
		CreatureDataComponent component2 = ownerEntity.GetComponent<CreatureDataComponent>();
		BaseSkillComponent component3 = ownerEntity.GetComponent<BaseSkillComponent>();
		if (aactor == null || component2 == null || component3 == null)
		{
			return 0;
		}
		BulletPatternComponent component4 = ownerEntity.GetComponent<BulletPatternComponent>();
		if (component4 == null || !component4.HasBulletPatternSkill)
		{
			Singleton<CombatLog>.Instance.Error(CombatLog.EDebugModule.Bullet, ownerEntity, "SpawnPattern失败，该实体没有弹幕子弹能力", default(ReadOnlySpan<ValueTuple<string, object>>));
			return 0;
		}
		UWorldEntityBulletContext uworldEntityBulletContext = UE.NewObject<UWorldEntityBulletContext>(GlobalData.World, null, EObjectFlags.RF_NoFlags);
		uworldEntityBulletContext.ExtraParam = extraParam;
		uworldEntityBulletContext.OwnerActor = aactor;
		uworldEntityBulletContext.OwnerEntityId = ownerEntity.Id;
		uworldEntityBulletContext.BulletDataTable = component3.DtKuroBulletInfo;
		uworldEntityBulletContext.Camp = (int)component2.GetEntityCamp();
		EntityHandle skillTarget = component3.SkillTarget;
		if (skillTarget != null && skillTarget.Valid)
		{
			WorldEntity entity = skillTarget.Entity;
			BaseActorComponent baseActorComponent = (entity != null) ? entity.GetComponent<BaseActorComponent>() : null;
			uworldEntityBulletContext.TargetActor = ((baseActorComponent != null) ? baseActorComponent.Owner : null);
			string skillTargetSocket = component3.SkillTargetSocket;
			if (!string.IsNullOrEmpty(skillTargetSocket))
			{
				FName? dynamicFName = FNameUtil.GetDynamicFName(skillTargetSocket);
				if (dynamicFName != null)
				{
					uworldEntityBulletContext.TargetSocket = dynamicFName.Value;
				}
			}
		}
		int num = UKuroBulletFunctionLibrary.SpawnPattern(uworldEntityBulletContext, patternData);
		if (num > 0)
		{
			this.PatternOwnerEntityIds.Add(ownerEntity.Id);
		}
		if (Singleton<BulletConstant>.Instance.OpenCreateLog && num <= 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Bullet;
			ELogAuthor author = ELogAuthor.HXY;
			string message = "创建弹幕失败";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("弹幕DA", patternData);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("拥有者实体ID", ownerEntity.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("拥有者名称", aactor.GetName());
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}
		return num;
	}

	// Token: 0x06017D0B RID: 97547 RVA: 0x006A4280 File Offset: 0x006A2480
	public void DestroyPatternById(int patternId)
	{
		if (patternId <= 0)
		{
			return;
		}
		if (Singleton<BulletConstant>.Instance.OpenDestroyLog)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Bullet;
			ELogAuthor author = ELogAuthor.HXY;
			string message = "销毁弹幕开始";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("弹幕Id", patternId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		else
		{
			bool openCreateLog = Singleton<BulletConstant>.Instance.OpenCreateLog;
		}
		UKuroBulletFunctionLibrary.DestroyPattern(patternId);
		bool openCreateLog2 = Singleton<BulletConstant>.Instance.OpenCreateLog;
	}

	// Token: 0x06017D0C RID: 97548 RVA: 0x006A42E8 File Offset: 0x006A24E8
	public void DestroyPatternsByOwner(object owner)
	{
		if (owner == null)
		{
			return;
		}
		AActor aactor = null;
		int num = 0;
		EntityHandle entityHandle = owner as EntityHandle;
		if (entityHandle != null)
		{
			num = entityHandle.Id;
			WorldEntity entity = entityHandle.Entity;
			AActor aactor2;
			if (entity == null)
			{
				aactor2 = null;
			}
			else
			{
				BaseActorComponent component = entity.GetComponent<BaseActorComponent>();
				aactor2 = ((component != null) ? component.Owner : null);
			}
			aactor = aactor2;
		}
		else
		{
			AActor aactor3 = owner as AActor;
			if (aactor3 != null)
			{
				aactor = aactor3;
			}
		}
		if (aactor == null)
		{
			return;
		}
		UKuroBulletFunctionLibrary.DestroyPatternsByOwner(aactor);
		if (num != 0)
		{
			this.PatternOwnerEntityIds.Remove(num);
		}
		bool openCreateLog = Singleton<BulletConstant>.Instance.OpenCreateLog;
	}

	// Token: 0x06017D0D RID: 97549 RVA: 0x006A4360 File Offset: 0x006A2560
	[NullableContext(2)]
	public UBulletWorld GetKuroBulletWorld()
	{
		return this.KuroBulletWorldInternal;
	}

	// Token: 0x06017D0E RID: 97550 RVA: 0x006A4368 File Offset: 0x006A2568
	[NullableContext(2)]
	public UBulletHitWorldEntityManager GetBulletHitWorldEntityManager()
	{
		return this.BulletHitWorldEntityManager;
	}

	// Token: 0x06017D0F RID: 97551 RVA: 0x006A4370 File Offset: 0x006A2570
	public void StartKuroBulletWorld(UKuroFastCollisionAlgorithm algorithm, bool needHitWorldEntity = false)
	{
		UKuroBulletCoreSubsystem ukuroBulletCoreSubsystem = USubsystemBlueprintLibrary.GetGameInstanceSubsystem(GlobalData.GameInstance, UKuroBulletCoreSubsystem.StaticClass()) as UKuroBulletCoreSubsystem;
		this.KuroBulletWorldInternal = ukuroBulletCoreSubsystem.GetBulletWorld();
		if (this.KuroBulletWorldInternal == null)
		{
			this.KuroBulletWorldInternal = ukuroBulletCoreSubsystem.CreateWorld();
		}
		if (this.KuroBulletWorldInternal != null)
		{
			this.KuroBulletWorldInternal.ForceUpdateOverlap = true;
			this.KuroBulletWorldInternal.OnBulletModifyBuff.Add(new Action<int, long, bool>(this.OnBulletModifyBuff));
			this.KuroBulletWorldInternal.OnBulletCameraShake.Add(new Action<string>(this.OnBulletCameraShake));
			this.KuroBulletWorldInternal.SetKFCAlgorithm(algorithm);
			this.KuroBulletWorldInternal.RegisterBulletActionClassByTag(GameplayTagUtils.GetGameplayTagById(GameplayTagDefine.EGameplayTagId["子弹.KuroBullet.碰撞平地"]).Value, UActionFlatGroundCollision.StaticClass());
			Singleton<Log>.Instance.Info(ELogModule.Bullet, ELogAuthor.HXY, "KuroBulletWorld创建成功", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		else
		{
			Singleton<Log>.Instance.Error(ELogModule.Bullet, ELogAuthor.HXY, "KuroBulletWorld创建失败", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		if (needHitWorldEntity)
		{
			if (this.BulletHitWorldEntityManager != null)
			{
				return;
			}
			this.BulletHitWorldEntityManager = UBulletHitWorldEntityManager.CreateInstance(GlobalData.World);
			this.BulletHitWorldEntityBridge = UE.NewObject<BP_BulletHitWorldEntityBridge_C>(GlobalData.GameInstance, null, EObjectFlags.RF_NoFlags);
			this.BulletHitWorldEntityManager.SetBulletHitWorldEntityBridge(this.BulletHitWorldEntityBridge);
			UHitEffectManager hitEffectManager = this.BulletHitWorldEntityManager.HitEffectManager;
			if (hitEffectManager != null)
			{
				hitEffectManager.MaxEffectCountPerFrame = 20;
				hitEffectManager.MaxEffectCountPerPath = 20;
			}
		}
	}

	// Token: 0x06017D10 RID: 97552 RVA: 0x006A44DC File Offset: 0x006A26DC
	public void StopKuroBulletWorld()
	{
		this.BulletHitWorldEntityBridge = null;
		if (this.BulletHitWorldEntityManager != null)
		{
			UBulletHitWorldEntityManager.DestroyInstance();
			this.BulletHitWorldEntityManager = null;
			this.OperationList.Empty(true);
		}
		if (this.KuroBulletWorldInternal == null)
		{
			return;
		}
		this.KuroBulletWorldInternal.OnBulletModifyBuff.Clear();
		this.KuroBulletWorldInternal.OnBulletCameraShake.Clear();
		(USubsystemBlueprintLibrary.GetGameInstanceSubsystem(GlobalData.GameInstance, UKuroBulletCoreSubsystem.StaticClass()) as UKuroBulletCoreSubsystem).DestroyWorld();
		this.KuroBulletWorldInternal = null;
		Singleton<Log>.Instance.Info(ELogModule.Bullet, ELogAuthor.HXY, "KuroBulletWorld销毁成功", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x06017D11 RID: 97553 RVA: 0x006A457A File Offset: 0x006A277A
	private void OnBulletModifyBuff(int entityId, long buffId, bool isAdd)
	{
		ControllerBase<KuroSimpleCombatController>.Instance.ModifyBuffAsync(entityId, isAdd, (int)buffId);
	}

	// Token: 0x06017D12 RID: 97554 RVA: 0x006A458A File Offset: 0x006A278A
	private void OnBulletCameraShake(string shakePath)
	{
		if (string.IsNullOrEmpty(shakePath))
		{
			return;
		}
		Singleton<ResourceSystem>.Instance.LoadAsync<UClass>(shakePath, delegate([Nullable(2)] UClass shakeType, string _)
		{
			APlayerCameraManager characterCameraManager = Global.CharacterCameraManager;
			if (characterCameraManager == null || !characterCameraManager.IsValid())
			{
				return;
			}
			FVectorDouble value = characterCameraManager.D_GetCameraLocation();
			ControllerBase<CameraController>.Instance.PlayWorldCameraShake(shakeType, new FVectorDouble?(value), 0f, 100f, 1f, false, "MainCamera");
		}, 100, "js_undefined");
	}

	// Token: 0x06017D13 RID: 97555 RVA: 0x006A45C8 File Offset: 0x006A27C8
	private void ForceDestroyKuroBulletWorld()
	{
		this.StopKuroBulletWorld();
		Singleton<Log>.Instance.Info(ELogModule.Bullet, ELogAuthor.HXY, "KuroBulletWorld强制销毁完成", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x06017D14 RID: 97556 RVA: 0x006A45F7 File Offset: 0x006A27F7
	public void StartKscBullet()
	{
		if (this.KscBulletManager != null)
		{
			return;
		}
		this.KscBulletManager = UKscBulletManager.CreateInstance(GlobalData.World);
	}

	// Token: 0x06017D15 RID: 97557 RVA: 0x006A4612 File Offset: 0x006A2812
	public void StopKscBullet()
	{
		if (this.KscBulletManager == null)
		{
			return;
		}
		UKscBulletManager.DestroyInstance();
		this.KscBulletManager = null;
	}

	// Token: 0x06017D16 RID: 97558 RVA: 0x006A462C File Offset: 0x006A282C
	public void ProcessKuroBulletOperationList()
	{
		if (this.BulletHitWorldEntityManager == null)
		{
			return;
		}
		this.BulletHitWorldEntityManager.GetOperationList(ref this.OperationList);
		TArray<FBulletHitWorldEntityOperation> operationList = this.OperationList;
		int num = operationList.Num();
		for (int i = 0; i < num; i++)
		{
			this.PendingOperationQueue.Push(operationList.Get(i));
		}
	}

	// Token: 0x06017D17 RID: 97559 RVA: 0x006A4680 File Offset: 0x006A2880
	public void ProcessKuroBulletPendingOperation()
	{
		this.TimeLimit.ResetCost();
		while (!this.PendingOperationQueue.Empty)
		{
			double microseconds = KuroTime.GetMicroseconds64();
			FBulletHitWorldEntityOperation fbulletHitWorldEntityOperation = this.PendingOperationQueue.Pop();
			if (fbulletHitWorldEntityOperation == null)
			{
				break;
			}
			this.ProcessKuroBulletOperation(fbulletHitWorldEntityOperation);
			double microseconds2 = KuroTime.GetMicroseconds64();
			this.TimeLimit.AddCost(microseconds2 - microseconds);
			if (this.TimeLimit.IsTimeLimitExceeded())
			{
				break;
			}
		}
	}

	// Token: 0x06017D18 RID: 97560 RVA: 0x006A46EC File Offset: 0x006A28EC
	public void ProcessKuroBulletOperation(FBulletHitWorldEntityOperation operation)
	{
		int operationType = (int)operation.OperationType;
		if (operationType == 0)
		{
			this.KuroBulletAddBuff(operation);
			return;
		}
		if (operationType == 1)
		{
			this.KuroBulletHit(operation);
			return;
		}
		if (operationType == 2)
		{
			this.KuroBulletDodge(operation);
			return;
		}
		if (operationType == 3)
		{
			this.KuroBulletAddBuffWithRef(operation);
			return;
		}
		if (operationType == 4)
		{
			this.KuroBulletRemoveBuffWithRef(operation);
		}
	}

	// Token: 0x06017D19 RID: 97561 RVA: 0x006A473C File Offset: 0x006A293C
	private void KuroBulletAddBuff(FBulletHitWorldEntityOperation operation)
	{
		EntityHandle handle = ModelBase<CharacterModel>.Instance.GetHandle(operation.CasterEntityId);
		if (handle == null || !handle.Valid)
		{
			return;
		}
		CreatureDataComponent component = handle.Entity.GetComponent<CreatureDataComponent>();
		if (component == null)
		{
			return;
		}
		EntityHandle handle2 = ModelBase<CharacterModel>.Instance.GetHandle(operation.EntityId);
		if (handle2 == null || !handle2.Valid)
		{
			return;
		}
		BaseBuffComponent component2 = handle2.Entity.GetComponent<BaseBuffComponent>();
		if (component2 == null)
		{
			return;
		}
		component2.AddBuff(operation.LongParam1, new AddBuffParam
		{
			InstigatorId = component.GetCreatureDataId(),
			PreMessageId = new long?(operation.ExtraParam.MessageId),
			Reason = "KuroBullet命中",
			BulletMessageId = new long?(operation.ExtraParam.MessageId)
		});
	}

	// Token: 0x06017D1A RID: 97562 RVA: 0x006A47F8 File Offset: 0x006A29F8
	private void KuroBulletHit(FBulletHitWorldEntityOperation operation)
	{
		EntityHandle handle = ModelBase<CharacterModel>.Instance.GetHandle(operation.EntityId);
		if (handle == null || !handle.Valid)
		{
			return;
		}
		CharacterHitComponent component = handle.Entity.GetComponent<CharacterHitComponent>();
		if (component == null)
		{
			return;
		}
		component.OnHitByKuroBullet(operation.CasterEntityId, operation.LongParam1, operation.Location, operation.ExtraParam);
	}

	// Token: 0x06017D1B RID: 97563 RVA: 0x006A4850 File Offset: 0x006A2A50
	private void KuroBulletDodge(FBulletHitWorldEntityOperation operation)
	{
		EntityHandle handle = ModelBase<CharacterModel>.Instance.GetHandle(operation.EntityId);
		if (handle == null || !handle.Valid)
		{
			return;
		}
		RoleKuroFastCollisionComponent component = handle.Entity.GetComponent<RoleKuroFastCollisionComponent>();
		if (component == null)
		{
			return;
		}
		if (!component.CanDodge())
		{
			return;
		}
		CharacterActorComponent component2 = handle.Entity.GetComponent<CharacterActorComponent>();
		if (component2 == null)
		{
			return;
		}
		UAbilitySystemBlueprintLibrary.SendGameplayEventToActor(component2.Actor, GameplayTagUtils.GetGameplayTagById(GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.触发极限闪避"]).Value, new FGameplayEventData());
		EntityHandle handle2 = ModelBase<CharacterModel>.Instance.GetHandle(operation.CasterEntityId);
		if (handle2 == null || !handle2.Valid)
		{
			return;
		}
		CreatureDataComponent component3 = handle2.Entity.GetComponent<CreatureDataComponent>();
		long? num = (component3 != null) ? new long?(component3.GetCreatureDataId()) : null;
		if (num != null)
		{
			this.SendDodgeInfoPush(handle.Entity, num.Value, operation.LongParam1, new long?(operation.ExtraParam.MessageId));
		}
		ControllerBase<SceneTeamController>.Instance.EmitEvent<Entity, Entity, int, long>(handle.Entity, EEventName.CharLimitDodge, handle2.Entity, handle.Entity, operation.ExtraParam.SkillId, operation.LongParam1);
	}

	// Token: 0x06017D1C RID: 97564 RVA: 0x006A4978 File Offset: 0x006A2B78
	private void KuroBulletAddBuffWithRef(FBulletHitWorldEntityOperation operation)
	{
		EntityHandle handle = ModelBase<CharacterModel>.Instance.GetHandle(operation.CasterEntityId);
		if (handle == null || !handle.Valid)
		{
			return;
		}
		CreatureDataComponent component = handle.Entity.GetComponent<CreatureDataComponent>();
		if (component == null)
		{
			return;
		}
		EntityHandle handle2 = ModelBase<CharacterModel>.Instance.GetHandle(operation.EntityId);
		if (handle2 == null || !handle2.Valid)
		{
			return;
		}
		BaseBuffComponent component2 = handle2.Entity.GetComponent<BaseBuffComponent>();
		if (component2 == null)
		{
			return;
		}
		long longParam = operation.LongParam1;
		long creatureDataId = component.GetCreatureDataId();
		BaseBuffComponent buffApplyTarget = component2.GetBuffApplyTarget(longParam, creatureDataId);
		if (buffApplyTarget != null)
		{
			buffApplyTarget.AddBuffRefEntityId(longParam, operation.EntityId);
			if (buffApplyTarget.HasBuff(longParam, false))
			{
				return;
			}
		}
		component2.AddBuff(longParam, new AddBuffParam
		{
			InstigatorId = creatureDataId,
			PreMessageId = new long?(operation.ExtraParam.MessageId),
			Reason = "KuroBullet进入范围",
			BulletMessageId = new long?(operation.ExtraParam.MessageId)
		});
	}

	// Token: 0x06017D1D RID: 97565 RVA: 0x006A4A68 File Offset: 0x006A2C68
	private void KuroBulletRemoveBuffWithRef(FBulletHitWorldEntityOperation operation)
	{
		EntityHandle handle = ModelBase<CharacterModel>.Instance.GetHandle(operation.CasterEntityId);
		if (handle == null || !handle.Valid)
		{
			return;
		}
		CreatureDataComponent component = handle.Entity.GetComponent<CreatureDataComponent>();
		if (component == null)
		{
			return;
		}
		EntityHandle handle2 = ModelBase<CharacterModel>.Instance.GetHandle(operation.EntityId);
		if (handle2 == null || !handle2.Valid)
		{
			return;
		}
		BaseBuffComponent component2 = handle2.Entity.GetComponent<BaseBuffComponent>();
		if (component2 == null)
		{
			return;
		}
		long longParam = operation.LongParam1;
		BaseBuffComponent buffApplyTarget = component2.GetBuffApplyTarget(longParam, component.GetCreatureDataId());
		if (buffApplyTarget != null)
		{
			buffApplyTarget.RemoveBuffRefEntityId(longParam, operation.EntityId);
			if (buffApplyTarget.HasBuffRefEntityId(longParam))
			{
				return;
			}
		}
		component2.RemoveBuff(longParam, -1, "KuroBullet离开范围", null, null, null);
	}

	// Token: 0x0400B885 RID: 47237
	private readonly OrderedDictionary<int, BulletEntity> BulletEntityMap = new OrderedDictionary<int, BulletEntity>();

	// Token: 0x0400B886 RID: 47238
	[StaticVariableRuleIgnore]
	private static readonly int MaxBulletEntitySetCacheCount = 20;

	// Token: 0x0400B887 RID: 47239
	private readonly List<OrderedSet<BulletEntity>> BulletEntitySets = new List<OrderedSet<BulletEntity>>();

	// Token: 0x0400B888 RID: 47240
	private readonly Dictionary<int, OrderedSet<BulletEntity>> AttackerBullet = new Dictionary<int, OrderedSet<BulletEntity>>();

	// Token: 0x0400B889 RID: 47241
	private readonly HashSet<int> NeedDestroyBullets = new HashSet<int>();

	// Token: 0x0400B88A RID: 47242
	[Nullable(2)]
	private BulletCommonDataAsset_C CommonConfig;

	// Token: 0x0400B88B RID: 47243
	[Nullable(2)]
	public DefaultBulletSceneInteraction_C DefaultBulletSceneInteraction;

	// Token: 0x0400B88C RID: 47244
	public int PatternHandleIdGen;

	// Token: 0x0400B88D RID: 47245
	private int OnHitMaterialDelayMsInternal;

	// Token: 0x0400B88E RID: 47246
	private bool OpenHitMaterialInternal = true;

	// Token: 0x0400B88F RID: 47247
	[StaticVariableRuleIgnore]
	private static readonly Stat BulletPreloadStat = Stat.Create("BulletPreload", "", "");

	// Token: 0x0400B890 RID: 47248
	private readonly Dictionary<int, bool> MapBulletHit = new Dictionary<int, bool>();

	// Token: 0x0400B891 RID: 47249
	[StaticVariableRuleIgnore]
	private static readonly Stat BulletCreateEntityStat = Stat.Create("BulletCreateEntity", "", "");

	// Token: 0x0400B892 RID: 47250
	[StaticVariableRuleIgnore]
	private static readonly Stat BulletClearDestroyedStat = Stat.Create("BulletClearDestroyed", "", "");

	// Token: 0x0400B893 RID: 47251
	[StaticVariableRuleIgnore]
	private static readonly Stat BulletRecycleBulletEntityStat = Stat.Create("BulletRecycleBulletEntity", "", "");

	// Token: 0x0400B894 RID: 47252
	private readonly Dictionary<int, Dictionary<int, int>> HandleToEntityIdDict = new Dictionary<int, Dictionary<int, int>>();

	// Token: 0x0400B895 RID: 47253
	private readonly Dictionary<int, ActiveBulletHandle> EntityIdToHandleDict = new Dictionary<int, ActiveBulletHandle>();

	// Token: 0x0400B896 RID: 47254
	private readonly Dictionary<string, int> MapCustomKey = new Dictionary<string, int>();

	// Token: 0x0400B897 RID: 47255
	private readonly Dictionary<string, int> CustomBulletAttacker = new Dictionary<string, int>();

	// Token: 0x0400B898 RID: 47256
	private readonly HashSet<int> PatternOwnerEntityIds = new HashSet<int>();

	// Token: 0x0400B899 RID: 47257
	private readonly Dictionary<int, bool> MapAttackerDrawCollision = new Dictionary<int, bool>();

	// Token: 0x0400B89A RID: 47258
	private readonly Dictionary<int, bool> MapAttackerDrawTrace = new Dictionary<int, bool>();

	// Token: 0x0400B89B RID: 47259
	[Nullable(2)]
	public HashSet<EHitAnim> SelfAdaptBeHitAnim;

	// Token: 0x0400B89C RID: 47260
	[Nullable(2)]
	public HashSet<EHitAnim> HeavyHitAnim;

	// Token: 0x0400B89D RID: 47261
	[Nullable(2)]
	public EHitAnim[] Index2LightHitAnimMap;

	// Token: 0x0400B89E RID: 47262
	[Nullable(2)]
	public EHitAnim[] Index2HeavyHitAnimMap;

	// Token: 0x0400B89F RID: 47263
	private readonly HashSet<int> BulletEntityDestroyWhenPlot = new HashSet<int>();

	// Token: 0x0400B8A0 RID: 47264
	private bool PlotPlaying;

	// Token: 0x0400B8A1 RID: 47265
	public Dictionary<int, BulletPersistentTimeScale> PersistentTimeScaleMap = new Dictionary<int, BulletPersistentTimeScale>();

	// Token: 0x0400B8A2 RID: 47266
	public int PersistentTimeScaleId;

	// Token: 0x0400B8A3 RID: 47267
	private long SceneBulletOwnerIdInternal;

	// Token: 0x0400B8A4 RID: 47268
	public bool IsSceneBulletOwnerCreated;

	// Token: 0x0400B8A5 RID: 47269
	[Nullable(2)]
	private WaitEntityTask WaitSceneBulletOwnerTask;

	// Token: 0x0400B8A6 RID: 47270
	[Nullable(2)]
	private CustomPromise<bool> PreloadPromise;

	// Token: 0x0400B8A7 RID: 47271
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<int, HashSet<long>> SummonerSummonedCreatureDataIds;

	// Token: 0x0400B8A8 RID: 47272
	[Nullable(2)]
	private Dictionary<long, int> SummonedCreatureDataIdToSummoner;

	// Token: 0x0400B8A9 RID: 47273
	[Nullable(2)]
	private UBulletWorld KuroBulletWorldInternal;

	// Token: 0x0400B8AA RID: 47274
	[Nullable(2)]
	private UKscBulletManager KscBulletManager;

	// Token: 0x0400B8AB RID: 47275
	[Nullable(2)]
	private UBulletHitWorldEntityManager BulletHitWorldEntityManager;

	// Token: 0x0400B8AC RID: 47276
	[Nullable(2)]
	private UBulletHitWorldEntityBridge BulletHitWorldEntityBridge;

	// Token: 0x0400B8AD RID: 47277
	private readonly TimeLimit TimeLimit = new TimeLimit(new long?(1000L));

	// Token: 0x0400B8AE RID: 47278
	private TArray<FBulletHitWorldEntityOperation> OperationList = new TArray<FBulletHitWorldEntityOperation>();

	// Token: 0x0400B8AF RID: 47279
	private readonly Queue<FBulletHitWorldEntityOperation> PendingOperationQueue = new Queue<FBulletHitWorldEntityOperation>(4);
}
