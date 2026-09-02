using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002DFD RID: 11773
[NullableContext(1)]
[Nullable(0)]
public class BulletCollisionInfo
{
	// Token: 0x1700202A RID: 8234
	// (get) Token: 0x06017C6D RID: 97389 RVA: 0x006A05D8 File Offset: 0x0069E7D8
	public FTransformDouble CollisionTransform
	{
		get
		{
			if (this.CollisionComponent == null)
			{
				return Singleton<MathUtils>.Instance.DefaultTransformDouble;
			}
			return this.CollisionComponent.D_K2_GetComponentToWorld();
		}
	}

	// Token: 0x06017C6E RID: 97390 RVA: 0x006A05F8 File Offset: 0x0069E7F8
	public void RecordPreResolvedDamageId(long damageId, long preResolvedDamageId)
	{
		this.PreResolvedDamageIdMap[damageId] = preResolvedDamageId;
	}

	// Token: 0x06017C6F RID: 97391 RVA: 0x006A0608 File Offset: 0x0069E808
	public void SetDamageIdByOriginal(long damageId)
	{
		long damageId2;
		if (this.PreResolvedDamageIdMap.TryGetValue(damageId, out damageId2))
		{
			this.DamageId = damageId2;
			this.IsCurrentDamageIdPreResolvedInternal = true;
			return;
		}
		this.DamageId = damageId;
		this.IsCurrentDamageIdPreResolvedInternal = false;
	}

	// Token: 0x1700202B RID: 8235
	// (get) Token: 0x06017C70 RID: 97392 RVA: 0x006A0642 File Offset: 0x0069E842
	public bool IsCurrentDamageIdPreResolved
	{
		get
		{
			return this.IsCurrentDamageIdPreResolvedInternal;
		}
	}

	// Token: 0x06017C71 RID: 97393 RVA: 0x006A064C File Offset: 0x0069E84C
	public void AddHitActorData(AActor otherActor, BulletHitActorData hitActorData)
	{
		if (this.IsInProcessHit)
		{
			Singleton<Log>.Instance.Error(ELogModule.Bullet, ELogAuthor.CFT, "处理子弹碰撞期间不允许修改碰撞数组", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (this.MapHitActorData.ContainsKey(otherActor))
		{
			return;
		}
		this.MapHitActorData.Add(otherActor, hitActorData);
		this.ArrayHitActorData.Add(hitActorData);
	}

	// Token: 0x06017C72 RID: 97394 RVA: 0x006A06A8 File Offset: 0x0069E8A8
	public void ClearHitActorData()
	{
		if (this.IsInProcessHit)
		{
			Singleton<Log>.Instance.Error(ELogModule.Bullet, ELogAuthor.CFT, "处理子弹碰撞期间不允许修改碰撞数组", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		foreach (BulletHitActorData obj in this.ArrayHitActorData)
		{
			BulletPool.RecycleBulletHitActorData(obj);
		}
		this.MapHitActorData.Clear();
		this.ArrayHitActorData.Clear();
		this.HasSearchedHitActorsCurFrame = false;
	}

	// Token: 0x06017C73 RID: 97395 RVA: 0x006A073C File Offset: 0x0069E93C
	public void ClearLastHitActorData()
	{
		if (this.IsInProcessHit)
		{
			Singleton<Log>.Instance.Error(ELogModule.Bullet, ELogAuthor.CFT, "处理子弹碰撞期间不允许修改碰撞数组", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		foreach (BulletHitActorData obj in this.LastArrayHitActorData)
		{
			BulletPool.RecycleBulletHitActorData(obj);
		}
		this.LastMapHitActorData.Clear();
		this.LastArrayHitActorData.Clear();
	}

	// Token: 0x06017C74 RID: 97396 RVA: 0x006A07C8 File Offset: 0x0069E9C8
	public void UpdateLastHitActorData()
	{
		if (this.IsInProcessHit)
		{
			Singleton<Log>.Instance.Error(ELogModule.Bullet, ELogAuthor.CFT, "处理子弹碰撞期间不允许修改碰撞数组", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		List<BulletHitActorData> lastArrayHitActorData = this.LastArrayHitActorData;
		this.LastArrayHitActorData = this.ArrayHitActorData;
		this.ArrayHitActorData = lastArrayHitActorData;
		Dictionary<AActor, BulletHitActorData> lastMapHitActorData = this.LastMapHitActorData;
		this.LastMapHitActorData = this.MapHitActorData;
		this.MapHitActorData = lastMapHitActorData;
		this.ClearHitActorData();
	}

	// Token: 0x06017C75 RID: 97397 RVA: 0x006A0834 File Offset: 0x0069EA34
	[return: Nullable(2)]
	public Entity GetFirstVictim(EBulletHitActorType[] types)
	{
		foreach (BulletHitActorData bulletHitActorData in (this.IsInProcessHit ? this.ArrayHitActorData : this.LastArrayHitActorData))
		{
			if (bulletHitActorData.IsValidHit && types.Contains(bulletHitActorData.Type) && bulletHitActorData != null)
			{
				EntityHandle entityHandle = bulletHitActorData.EntityHandle;
				if (((entityHandle != null) ? new bool?(entityHandle.Valid) : null).GetValueOrDefault())
				{
					return bulletHitActorData.Entity;
				}
			}
		}
		return null;
	}

	// Token: 0x06017C76 RID: 97398 RVA: 0x006A08E0 File Offset: 0x0069EAE0
	public void Clear()
	{
		if (this.IsInProcessHit)
		{
			Singleton<Log>.Instance.Error(ELogModule.Bullet, ELogAuthor.CFT, "处理子弹碰撞期间不允许修改碰撞数组", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		foreach (BulletHitActorData obj in this.ArrayHitActorData)
		{
			BulletPool.RecycleBulletHitActorData(obj);
		}
		foreach (BulletHitActorData obj2 in this.LastArrayHitActorData)
		{
			BulletPool.RecycleBulletHitActorData(obj2);
		}
		foreach (BulletConditionResult obj3 in this.MapBulletConditionResult.Values)
		{
			BulletPool.RecycleBulletConditionResult(obj3);
		}
		this.MapBulletConditionResult.Clear();
		this.MapHitActorData.Clear();
		this.ArrayHitActorData.Clear();
		this.LastMapHitActorData.Clear();
		this.LastArrayHitActorData.Clear();
		this.ArrayHitActor.Clear();
		this.ActorCollisionEnable = false;
		this.CollisionComponent = null;
		this.RegionDetectComponent = null;
		this.RegionComponent = null;
		this.HasObstaclesCollision = false;
		this.NeedHitObstacles = false;
		this.IsInProcessHit = false;
		this.IsProcessOpen = false;
		this.HasSearchedHitActorsCurFrame = false;
		this.ObjectsHitCurrent.Clear();
		this.SceneItemPartsHitCurrent.Clear();
		this.SceneItemPartHitEntityId = null;
		this.StopHit = false;
		this.HaveCharacterInBullet = false;
		this.CharacterEntityMap.Clear();
		this.BulletEntityMap.Clear();
		this.HitTimeScaleEntityMap.Clear();
		this.HitObstaclesCurFrame = false;
		this.IsPassDelay = false;
		this.AllowedEnergy = false;
		this.AllowedAddEnergyBuff = false;
		this.ActiveDelayMs = 0f;
		this.ActiveLengthMs = 0f;
		this.IntervalMs = 0f;
		this.LastStageInterval = 0;
		this.StageInterval = 0;
		this.IsStartup = false;
		this.CenterLocalLocation.Reset();
		this.FinalScale.Reset();
		this.LastFramePosition.Reset();
		BulletTraceElementPool.RecycleTraceBoxElement(this.UpdateTraceBox);
		this.UpdateTraceBox = null;
		BulletTraceElementPool.RecycleTraceSphereElement(this.UpdateTraceSphere);
		this.UpdateTraceSphere = null;
		BulletTraceElementPool.RecycleTraceLineElement(this.UpdateTraceLine);
		this.UpdateTraceLine = null;
		BulletTraceElementPool.RecycleTraceSphereElement(this.ObstaclesTraceElement);
		this.ObstaclesTraceElement = null;
		this.IgnoreChannels.Clear();
		this.IgnoreQueries.Clear();
		this.DamageId = 0L;
		this.PreResolvedDamageIdMap.Clear();
		this.IsCurrentDamageIdPreResolvedInternal = false;
	}

	// Token: 0x0400B7AB RID: 47019
	private const int PRIORITY_OBSTACLE = 1000;

	// Token: 0x0400B7AC RID: 47020
	private const int PRIORITY_SCENEITEM = 2000;

	// Token: 0x0400B7AD RID: 47021
	private const int PRIORITY_CHARACTER = 3000;

	// Token: 0x0400B7AE RID: 47022
	private const int PRIORITY_NPC = 4000;

	// Token: 0x0400B7AF RID: 47023
	private const int PRIORITY_ANIMAL = 5000;

	// Token: 0x0400B7B0 RID: 47024
	private const int PRIORITY_BULLET = 6000;

	// Token: 0x0400B7B1 RID: 47025
	[StaticVariableRuleIgnore]
	public static readonly int?[] BulletHitPriorityList = new int?[]
	{
		null,
		new int?(3000),
		new int?(6000),
		new int?(2000),
		new int?(1000),
		new int?(4000),
		new int?(5000)
	};

	// Token: 0x0400B7B2 RID: 47026
	public bool ActorCollisionEnable;

	// Token: 0x0400B7B3 RID: 47027
	[Nullable(2)]
	public UPrimitiveComponent CollisionComponent;

	// Token: 0x0400B7B4 RID: 47028
	[Nullable(2)]
	public UKuroRegionDetectComponent RegionDetectComponent;

	// Token: 0x0400B7B5 RID: 47029
	[Nullable(2)]
	public UKuroRegionShapeComponent RegionComponent;

	// Token: 0x0400B7B6 RID: 47030
	public bool HasObstaclesCollision;

	// Token: 0x0400B7B7 RID: 47031
	public bool NeedHitObstacles;

	// Token: 0x0400B7B8 RID: 47032
	public readonly Dictionary<AActor, BulletConditionResult> MapBulletConditionResult = new Dictionary<AActor, BulletConditionResult>();

	// Token: 0x0400B7B9 RID: 47033
	public Dictionary<AActor, BulletHitActorData> MapHitActorData = new Dictionary<AActor, BulletHitActorData>();

	// Token: 0x0400B7BA RID: 47034
	public List<BulletHitActorData> ArrayHitActorData = new List<BulletHitActorData>();

	// Token: 0x0400B7BB RID: 47035
	public Dictionary<AActor, BulletHitActorData> LastMapHitActorData = new Dictionary<AActor, BulletHitActorData>();

	// Token: 0x0400B7BC RID: 47036
	public List<BulletHitActorData> LastArrayHitActorData = new List<BulletHitActorData>();

	// Token: 0x0400B7BD RID: 47037
	public readonly List<AActor> ArrayHitActor = new List<AActor>();

	// Token: 0x0400B7BE RID: 47038
	public bool IsInProcessHit;

	// Token: 0x0400B7BF RID: 47039
	public bool HasSearchedHitActorsCurFrame;

	// Token: 0x0400B7C0 RID: 47040
	public readonly Dictionary<int, int> ObjectsHitCurrent = new Dictionary<int, int>();

	// Token: 0x0400B7C1 RID: 47041
	public int? SceneItemPartHitEntityId;

	// Token: 0x0400B7C2 RID: 47042
	public readonly HashSet<string> SceneItemPartsHitCurrent = new HashSet<string>();

	// Token: 0x0400B7C3 RID: 47043
	public bool StopHit;

	// Token: 0x0400B7C4 RID: 47044
	public bool HaveCharacterInBullet;

	// Token: 0x0400B7C5 RID: 47045
	public readonly Dictionary<Entity, int> CharacterEntityMap = new Dictionary<Entity, int>();

	// Token: 0x0400B7C6 RID: 47046
	public readonly Dictionary<Entity, int> BulletEntityMap = new Dictionary<Entity, int>();

	// Token: 0x0400B7C7 RID: 47047
	public readonly Dictionary<int, int> HitTimeScaleEntityMap = new Dictionary<int, int>();

	// Token: 0x0400B7C8 RID: 47048
	public bool HitObstaclesCurFrame;

	// Token: 0x0400B7C9 RID: 47049
	public bool IsPassDelay;

	// Token: 0x0400B7CA RID: 47050
	public bool AllowedEnergy;

	// Token: 0x0400B7CB RID: 47051
	public bool AllowedAddEnergyBuff;

	// Token: 0x0400B7CC RID: 47052
	public float ActiveDelayMs;

	// Token: 0x0400B7CD RID: 47053
	public float ActiveLengthMs;

	// Token: 0x0400B7CE RID: 47054
	public float IntervalMs;

	// Token: 0x0400B7CF RID: 47055
	public bool IsProcessOpen;

	// Token: 0x0400B7D0 RID: 47056
	public int LastStageInterval;

	// Token: 0x0400B7D1 RID: 47057
	public int StageInterval;

	// Token: 0x0400B7D2 RID: 47058
	public bool IsStartup;

	// Token: 0x0400B7D3 RID: 47059
	public readonly Vector CenterLocalLocation = Vector.Create();

	// Token: 0x0400B7D4 RID: 47060
	public readonly Vector FinalScale = Vector.Create();

	// Token: 0x0400B7D5 RID: 47061
	public readonly Vector LastFramePosition = Vector.Create();

	// Token: 0x0400B7D6 RID: 47062
	[Nullable(2)]
	public UTraceBoxElement UpdateTraceBox;

	// Token: 0x0400B7D7 RID: 47063
	[Nullable(2)]
	public UTraceSphereElement UpdateTraceSphere;

	// Token: 0x0400B7D8 RID: 47064
	[Nullable(2)]
	public UTraceLineElement UpdateTraceLine;

	// Token: 0x0400B7D9 RID: 47065
	[Nullable(2)]
	public UTraceSphereElement ObstaclesTraceElement;

	// Token: 0x0400B7DA RID: 47066
	public readonly HashSet<ECollisionChannel> IgnoreChannels = new HashSet<ECollisionChannel>();

	// Token: 0x0400B7DB RID: 47067
	public readonly HashSet<EObjectTypeQuery> IgnoreQueries = new HashSet<EObjectTypeQuery>();

	// Token: 0x0400B7DC RID: 47068
	public long DamageId;

	// Token: 0x0400B7DD RID: 47069
	private readonly Dictionary<long, long> PreResolvedDamageIdMap = new Dictionary<long, long>();

	// Token: 0x0400B7DE RID: 47070
	private bool IsCurrentDamageIdPreResolvedInternal;

	// Token: 0x0400B7DF RID: 47071
	public FName BeHitEffect = FNameUtil.NONE;

	// Token: 0x0400B7E0 RID: 47072
	public FName WeaknessBeHitEffect = FNameUtil.NONE;
}
