using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Effect;
using CSharpScript.Game.LevelGamePlay.Common;
using CSharpScript.Game.Module.TowerDefenseEvent.Model;
using UnrealEngine;

// Token: 0x02002BD3 RID: 11219
[NullableContext(1)]
[Nullable(0)]
public class TowerDefenseEventPreviewMonsterSpawner
{
	// Token: 0x06016646 RID: 91718 RVA: 0x00637431 File Offset: 0x00635631
	public void Init(Dictionary<int, TrapDefenseMonsterPbGroup> data)
	{
		this.Reset();
		this.InitPreviewMonsters(data);
		this.PreviewSplines();
	}

	// Token: 0x06016647 RID: 91719 RVA: 0x00637448 File Offset: 0x00635648
	private unsafe void PreviewSplines()
	{
		ModelBase<TowerDefenseEventModel>.Instance.GetWaveSplineIds(this.PreviewSplineIds);
		foreach (int num in this.PreviewSplineIds)
		{
			if (ModelBase<GameSplineModel>.Instance.LoadAndGetSplineComponent(num, 0, EIdType.SimpleCombatPreviewId) == null)
			{
				ModelBase<GameSplineModel>.Instance.ReleaseSpline(num, 0L, EIdType.SimpleCombatPreviewId);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.TowerDefenseEvent;
				ELogAuthor author = ELogAuthor.XY;
				string message = "预览怪物组样条线加载失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("splineId", num);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			else
			{
				TsGameSplineActor splineActorBySplineId = ModelBase<GameSplineModel>.Instance.GetSplineActorBySplineId(num);
				ISplineType splineData = splineActorBySplineId.SplineData;
				if (splineData == null || splineData.Type != ESplineType.Effect)
				{
					ModelBase<GameSplineModel>.Instance.ReleaseSpline(num, 0L, EIdType.SimpleCombatPreviewId);
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.TowerDefenseEvent;
					ELogAuthor author2 = ELogAuthor.XY;
					string message2 = "预览怪物组样条线类型错误";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("splineId", num);
					ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
					string item = "splineType";
					ISplineType splineData2 = splineActorBySplineId.SplineData;
					ptr = new ValueTuple<string, object>(item, (splineData2 != null) ? new ESplineType?(splineData2.Type) : null);
					instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
				else
				{
					IEffectSpline effectSpline = splineActorBySplineId.SplineData as IEffectSpline;
					EffectSystem instance3 = Singleton<EffectSystem>.Instance;
					UObject world = GlobalData.World;
					FTransformDouble? ftransformDouble = new FTransformDouble?(Singleton<MathUtils>.Instance.DefaultTransformDouble);
					int num2 = instance3.SpawnEffect(world, ftransformDouble, effectSpline.Effect, "TowerDefenseEventPreviewMonsterSpawner.PreviewSplines", new EffectContext(null, splineActorBySplineId, false), EEffectType.Scene, null, null, null, false, false);
					if (Singleton<EffectSystem>.Instance.IsValid(num2))
					{
						OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(num2);
						AActor parent = splineActorBySplineId;
						FName? fname = null;
						effectActor.K2_AttachToActor(parent, fname, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, false);
						Singleton<EffectSystem>.Instance.SetEffectIgnoreVisibilityOptimize(num2, true);
					}
					this.SpawnedSplines[num] = num2;
				}
			}
		}
	}

	// Token: 0x06016648 RID: 91720 RVA: 0x00637664 File Offset: 0x00635864
	private void ReleaseSplines()
	{
		foreach (KeyValuePair<int, int> keyValuePair in this.SpawnedSplines)
		{
			int key = keyValuePair.Key;
			int value = keyValuePair.Value;
			ModelBase<GameSplineModel>.Instance.ReleaseSpline(key, 0L, EIdType.SimpleCombatPreviewId);
			if (Singleton<EffectSystem>.Instance.IsValid(value))
			{
				Singleton<EffectSystem>.Instance.StopEffectById(value, "TowerDefenseEventPreviewMonsterSpawner.ReleaseSplines", true, null);
			}
		}
		this.SpawnedSplines.Clear();
		this.PreviewSplineIds.Clear();
	}

	// Token: 0x06016649 RID: 91721 RVA: 0x00637710 File Offset: 0x00635910
	private void InitPreviewMonsters(Dictionary<int, TrapDefenseMonsterPbGroup> data)
	{
		foreach (int num in data.Keys)
		{
			TrapDefenseMonsterPbGroup trapDefenseMonsterPbGroup;
			if (data.TryGetValue(num, out trapDefenseMonsterPbGroup) && trapDefenseMonsterPbGroup != null && trapDefenseMonsterPbGroup.MonsterConfigIds != null && trapDefenseMonsterPbGroup.MonsterConfigIds.Count != 0)
			{
				int num2 = num;
				TowerDefenseEventSplineMonsterSpawner towerDefenseEventSplineMonsterSpawner = TowerDefenseEventPreviewMonsterSpawner.SplineSpawnerPool.Get();
				if (towerDefenseEventSplineMonsterSpawner == null)
				{
					towerDefenseEventSplineMonsterSpawner = TowerDefenseEventPreviewMonsterSpawner.SplineSpawnerPool.Create();
				}
				towerDefenseEventSplineMonsterSpawner.Init(this, num2, trapDefenseMonsterPbGroup);
				this.SplineMonsterSpawners[num2] = towerDefenseEventSplineMonsterSpawner;
			}
		}
	}

	// Token: 0x0601664A RID: 91722 RVA: 0x006377B8 File Offset: 0x006359B8
	public int GetSpawnUid()
	{
		this.SpawnedUid += 2;
		return this.SpawnedUid;
	}

	// Token: 0x0601664B RID: 91723 RVA: 0x006377D0 File Offset: 0x006359D0
	public void OnTick(float delta)
	{
		if (this.SplineMonsterSpawners.Count == 0)
		{
			return;
		}
		foreach (TowerDefenseEventSplineMonsterSpawner towerDefenseEventSplineMonsterSpawner in this.SplineMonsterSpawners.Values)
		{
			towerDefenseEventSplineMonsterSpawner.OnTick(delta);
		}
	}

	// Token: 0x0601664C RID: 91724 RVA: 0x00637834 File Offset: 0x00635A34
	private void ReleaseSplineSpawners()
	{
		foreach (TowerDefenseEventSplineMonsterSpawner towerDefenseEventSplineMonsterSpawner in this.SplineMonsterSpawners.Values)
		{
			towerDefenseEventSplineMonsterSpawner.Reset();
			TowerDefenseEventPreviewMonsterSpawner.SplineSpawnerPool.Put(towerDefenseEventSplineMonsterSpawner);
		}
		this.SplineMonsterSpawners.Clear();
	}

	// Token: 0x0601664D RID: 91725 RVA: 0x006378A4 File Offset: 0x00635AA4
	public void RemovePreviewMonster(long uid)
	{
		foreach (TowerDefenseEventSplineMonsterSpawner towerDefenseEventSplineMonsterSpawner in this.SplineMonsterSpawners.Values)
		{
			towerDefenseEventSplineMonsterSpawner.RemovePreviewMonster(uid);
		}
	}

	// Token: 0x0601664E RID: 91726 RVA: 0x006378FC File Offset: 0x00635AFC
	public void Reset()
	{
		this.SpawnedUid = 1;
		this.ReleaseSplines();
		this.ReleaseSplineSpawners();
	}

	// Token: 0x0601664F RID: 91727 RVA: 0x00637911 File Offset: 0x00635B11
	public void Clear()
	{
		this.Reset();
		TowerDefenseEventPreviewMonsterSpawner.SplineSpawnerPool.Clear();
	}

	// Token: 0x0400AD3E RID: 44350
	private static readonly Pool<TowerDefenseEventSplineMonsterSpawner> SplineSpawnerPool = new Pool<TowerDefenseEventSplineMonsterSpawner>(10, () => new TowerDefenseEventSplineMonsterSpawner(), null);

	// Token: 0x0400AD3F RID: 44351
	private int SpawnedUid = 1;

	// Token: 0x0400AD40 RID: 44352
	private readonly Dictionary<int, TowerDefenseEventSplineMonsterSpawner> SplineMonsterSpawners = new Dictionary<int, TowerDefenseEventSplineMonsterSpawner>();

	// Token: 0x0400AD41 RID: 44353
	private readonly List<int> PreviewSplineIds = new List<int>();

	// Token: 0x0400AD42 RID: 44354
	private readonly Dictionary<int, int> SpawnedSplines = new Dictionary<int, int>();
}
