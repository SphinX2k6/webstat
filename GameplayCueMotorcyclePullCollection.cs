using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Character.Common.Component.Explore;
using CSharpScript.Game.NewWorld.Character.Custom.Components;
using UnrealEngine;

// Token: 0x02002FB3 RID: 12211
[NullableContext(1)]
[Nullable(0)]
public class GameplayCueMotorcyclePullCollection : GameplayCueBase
{
	// Token: 0x06018E70 RID: 102000 RVA: 0x0070DA43 File Offset: 0x0070BC43
	protected override void OnInit()
	{
	}

	// Token: 0x06018E71 RID: 102001 RVA: 0x0070DA48 File Offset: 0x0070BC48
	public override void OnDisable()
	{
		VehicleBuffComponent motorcycleBuffComponent = this.MotorcycleBuffComponent;
		if (motorcycleBuffComponent != null)
		{
			motorcycleBuffComponent.RemoveBuff(640003034L, 1, "模拟摩托车采集物采集过程结束", null, null, null);
		}
		this.FakePullCollectionFinished = true;
	}

	// Token: 0x06018E72 RID: 102002 RVA: 0x0070DA94 File Offset: 0x0070BC94
	protected override void OnTick(float delta)
	{
		if (this.HookItem == null)
		{
			return;
		}
		if (this.FakePullCollectionProgress)
		{
			this.FakePullCollectionProgressTick(delta);
			return;
		}
		this.PullCollectionProgressTick(delta);
	}

	// Token: 0x06018E73 RID: 102003 RVA: 0x0070DAB8 File Offset: 0x0070BCB8
	private void FakePullCollectionProgressTick(float delta)
	{
		if (this.FakePullCollectionFinished)
		{
			Singleton<Log>.Instance.Info(ELogModule.SceneItem, ELogAuthor.CK, "模拟摩托车采集物采集过程已经结束", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
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
		if (characterActorComponent2 == null || !characterActorComponent2.Valid)
		{
			VehicleBuffComponent motorcycleBuffComponent = this.MotorcycleBuffComponent;
			if (motorcycleBuffComponent != null)
			{
				motorcycleBuffComponent.RemoveBuff(640003034L, 1, "模拟摩托车采集物采集过程结束", null, null, null);
			}
			this.FakePullCollectionFinished = true;
			return;
		}
		this.CurrentMoveSpeed = MathF.Min(this.CurrentMoveSpeed + 500f, 6000f);
		this.TmpVector.DeepCopy(characterActorComponent2.ActorLocationProxy);
		if (this.TmpVector.SubtractionEqual(this.PullingTargetLocation).SizeSquared() < 22500.0)
		{
			VehicleBuffComponent motorcycleBuffComponent2 = this.MotorcycleBuffComponent;
			if (motorcycleBuffComponent2 != null)
			{
				motorcycleBuffComponent2.RemoveBuff(640003034L, 1, "模拟摩托车采集物采集过程结束", null, null, null);
			}
			this.FakePullCollectionFinished = true;
			return;
		}
		this.TmpVector.Normalize(0.009999999776482582);
		this.TmpVector.MultiplyEqual((double)(this.CurrentMoveSpeed * delta)).AdditionEqual(this.PullingTargetLocation);
		GameplayCueHookCommonItem hookItem = this.HookItem;
		if (hookItem != null)
		{
			hookItem.Tick(this.TmpVector.ToUeVector(false));
		}
		this.PullingTargetLocation.DeepCopy(this.TmpVector);
	}

	// Token: 0x06018E74 RID: 102004 RVA: 0x0070DC50 File Offset: 0x0070BE50
	private void PullCollectionProgressTick(float delta)
	{
		GrapplingHookPointComponent pullingTarget = this.PullingTarget;
		if (pullingTarget == null || !pullingTarget.Valid || !this.PullingTarget.Active)
		{
			return;
		}
		FVectorDouble fvectorDouble = this.PullingTarget.TriggerLocation.ToUeVector(false);
		GameplayCueHookCommonItem hookItem = this.HookItem;
		if (hookItem != null)
		{
			hookItem.Tick(fvectorDouble);
		}
		this.LastLocation = new FVectorDouble?(fvectorDouble);
	}

	// Token: 0x06018E75 RID: 102005 RVA: 0x0070DCB4 File Offset: 0x0070BEB4
	protected override void OnCreate()
	{
		WorldEntity entity = this.EntityHandle.Entity;
		MotorcycleExploreComponent motorcycleExploreComponent = (entity != null) ? entity.GetComponent<MotorcycleExploreComponent>() : null;
		if (motorcycleExploreComponent == null || !motorcycleExploreComponent.Valid)
		{
			Singleton<Log>.Instance.Error(ELogModule.SceneItem, ELogAuthor.CK, "GameplayCueMotorcyclePullCollection播放失败, 摩托车探索组件已失效", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		WorldEntity entity2 = this.EntityHandle.Entity;
		this.MotorcycleBuffComponent = ((entity2 != null) ? entity2.GetComponent<VehicleBuffComponent>() : null);
		VehicleBuffComponent motorcycleBuffComponent = this.MotorcycleBuffComponent;
		if (motorcycleBuffComponent == null || !motorcycleBuffComponent.Valid)
		{
			Singleton<Log>.Instance.Error(ELogModule.SceneItem, ELogAuthor.CK, "GameplayCueMotorcyclePullCollection播放失败, 摩托车Buff组件已失效", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		GrapplingHookPointComponent pullingTarget = motorcycleExploreComponent.PullingTarget;
		if (pullingTarget == null || !pullingTarget.Active)
		{
			Singleton<Log>.Instance.Error(ELogModule.SceneItem, ELogAuthor.CK, "GameplayCueMotorcyclePullCollection播放失败, 当前探索组件正在交互实体已失效", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.PullingTarget = pullingTarget;
		this.FakePullCollectionProgress = !pullingTarget.PullCollectionWithProgress;
		if (this.FakePullCollectionProgress)
		{
			this.PullingTargetLocation.DeepCopy(this.PullingTarget.TriggerLocation);
		}
		this.HookItem = GameplayCueHookCommonItem.Spawn(this.ActorInternal, FNameUtil.GetDynamicFName(this.CueConfig.Socket).Value, this.PullingTargetLocation.ToUeVector(false), this.GetResourcePaths(), true);
	}

	// Token: 0x06018E76 RID: 102006 RVA: 0x0070DDF8 File Offset: 0x0070BFF8
	private string[] GetResourcePaths()
	{
		WorldEntity entity = this.EntityHandle.Entity;
		BaseActorComponent baseActorComponent = (entity != null) ? entity.GetComponent<BaseActorComponent>() : null;
		string[] array = this.CueConfig.Resources();
		if (baseActorComponent == null || !baseActorComponent.Valid)
		{
			return array;
		}
		string[] array2 = new string[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = (baseActorComponent.GetReplaceEffect(array[i]) ?? array[i]);
		}
		return array2;
	}

	// Token: 0x06018E77 RID: 102007 RVA: 0x0070DE67 File Offset: 0x0070C067
	protected override void OnDestroy()
	{
		if (this.HookItem != null)
		{
			this.HookItem.Destroy();
			this.HookItem = null;
		}
	}

	// Token: 0x0400C28C RID: 49804
	[Nullable(2)]
	private GameplayCueHookCommonItem HookItem;

	// Token: 0x0400C28D RID: 49805
	[Nullable(2)]
	private GrapplingHookPointComponent PullingTarget;

	// Token: 0x0400C28E RID: 49806
	[Nullable(2)]
	private VehicleBuffComponent MotorcycleBuffComponent;

	// Token: 0x0400C28F RID: 49807
	private FVectorDouble? LastLocation;

	// Token: 0x0400C290 RID: 49808
	private readonly Vector PullingTargetLocation = Vector.Create(0.0, 0.0, 0.0);

	// Token: 0x0400C291 RID: 49809
	private readonly Vector TmpVector = Vector.Create(0.0, 0.0, 0.0);

	// Token: 0x0400C292 RID: 49810
	private bool FakePullCollectionProgress;

	// Token: 0x0400C293 RID: 49811
	private bool FakePullCollectionFinished;

	// Token: 0x0400C294 RID: 49812
	private float CurrentMoveSpeed;

	// Token: 0x0400C295 RID: 49813
	private const float NORMALIZE = 0.01f;

	// Token: 0x0400C296 RID: 49814
	private const int PULL_COLLECTION_EFFECT_BUFF_ID = 640003034;
}
