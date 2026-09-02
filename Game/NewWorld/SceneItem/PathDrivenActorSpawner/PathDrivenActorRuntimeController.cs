using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.PathDrivenActorSpawner
{
	// Token: 0x02004833 RID: 18483
	[NullableContext(1)]
	[Nullable(0)]
	public class PathDrivenActorRuntimeController
	{
		// Token: 0x06030181 RID: 196993 RVA: 0x00BAA6F8 File Offset: 0x00BA88F8
		public PathDrivenActorRuntimeController(Entity ownerEntity, int? ownerPbDataId, UClass actorClass, IIntervalSplineSpawn spawnRule, IReadOnlyList<IPathDrivenSplineRuntimeData> trackList)
		{
			this.OwnerEntity = ownerEntity;
			this.OwnerPbDataId = ownerPbDataId;
			this.ActorClass = actorClass;
			this.SpawnRule = spawnRule;
			this.TrackList = trackList;
		}

		// Token: 0x06030182 RID: 196994 RVA: 0x00BAA751 File Offset: 0x00BA8951
		public void Tick(float deltaSeconds)
		{
			this.RecyclePendingActors();
			this.UpdateActiveActors();
			if (deltaSeconds <= 0f)
			{
				return;
			}
			this.TickActiveBehaviors(deltaSeconds);
			this.UpdateSpawn(deltaSeconds);
		}

		// Token: 0x06030183 RID: 196995 RVA: 0x00BAA778 File Offset: 0x00BA8978
		public void ClearAllActors(string reason)
		{
			for (int i = this.ActiveRuntimeDataList.Count - 1; i >= 0; i--)
			{
				this.CleanupActiveRuntimeData(this.ActiveRuntimeDataList[i], reason);
			}
			this.PendingRecycleList.Clear();
			this.NextSpawnDelaySec = 0f;
			this.NextSplineIndex = 0;
		}

		// Token: 0x06030184 RID: 196996 RVA: 0x00BAA7D0 File Offset: 0x00BA89D0
		private void UpdateActiveActors()
		{
			for (int i = this.ActiveRuntimeDataList.Count - 1; i >= 0; i--)
			{
				IPathDrivenActorRuntimeData pathDrivenActorRuntimeData = this.ActiveRuntimeDataList[i];
				AActor actor = pathDrivenActorRuntimeData.Actor;
				if (actor == null || !actor.IsValid())
				{
					this.CleanupActiveRuntimeData(pathDrivenActorRuntimeData, "[PathDrivenActorSpawnerComponent] ActorInvalid");
				}
			}
		}

		// Token: 0x06030185 RID: 196997 RVA: 0x00BAA828 File Offset: 0x00BA8A28
		private void TickActiveBehaviors(float deltaSeconds)
		{
			for (int i = 0; i < this.ActiveRuntimeDataList.Count; i++)
			{
				IPathDrivenActorRuntimeData pathDrivenActorRuntimeData = this.ActiveRuntimeDataList[i];
				if (!pathDrivenActorRuntimeData.Finished)
				{
					AActor actor = pathDrivenActorRuntimeData.Actor;
					if (actor != null && actor.IsValid())
					{
						IPathDrivenActorBehavior behavior = pathDrivenActorRuntimeData.Behavior;
						if (behavior != null)
						{
							behavior.Tick(pathDrivenActorRuntimeData, deltaSeconds);
						}
					}
				}
			}
		}

		// Token: 0x06030186 RID: 196998 RVA: 0x00BAA88A File Offset: 0x00BA8A8A
		private void UpdateSpawn(float deltaSeconds)
		{
			this.NextSpawnDelaySec -= deltaSeconds;
			if (this.NextSpawnDelaySec > 0f)
			{
				return;
			}
			this.TrySpawnActor();
			this.NextSpawnDelaySec = this.GetNextSpawnDelaySec();
		}

		// Token: 0x06030187 RID: 196999 RVA: 0x00BAA8BC File Offset: 0x00BA8ABC
		private unsafe void TrySpawnActor()
		{
			PathDrivenActorRuntimeController.<>c__DisplayClass17_0 CS$<>8__locals1 = new PathDrivenActorRuntimeController.<>c__DisplayClass17_0();
			CS$<>8__locals1.<>4__this = this;
			int valueOrDefault = this.SpawnRule.MaxActiveCount.GetValueOrDefault();
			if (valueOrDefault > 0 && this.GetActiveRuntimeCount() >= valueOrDefault)
			{
				return;
			}
			IPathDrivenSplineRuntimeData pathDrivenSplineRuntimeData = this.SelectTrackRuntimeData();
			if (pathDrivenSplineRuntimeData == null)
			{
				return;
			}
			SceneItemMoveComponent.SceneItemSplineMoveAtConstantTimeParam sceneItemSplineMoveAtConstantTimeParam = this.CloneMoveParam(pathDrivenSplineRuntimeData.MoveParamTemplate);
			float distance = (sceneItemSplineMoveAtConstantTimeParam.StartDis >= 0f) ? sceneItemSplineMoveAtConstantTimeParam.StartDis : 0f;
			FTransformDouble transform = pathDrivenSplineRuntimeData.SplineComponent.D_GetTransformAtDistanceAlongSpline(distance, ESplineCoordinateSpace.World, false);
			AActor aactor = Singleton<ActorSystem>.Instance.Get<AActor>(this.ActorClass.ClassStackOnlyPtr, transform, null, true);
			if (aactor == null || !aactor.IsValid())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PathDrivenActor;
				ELogAuthor author = ELogAuthor.WRY;
				string message = "[PathDrivenActorSpawnerComponent] 创建Actor失败";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PbDataId", this.OwnerPbDataId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ActorBlueprintPath", this.SpawnRule.ActorBlueprintPath);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			aactor.SetActorTickEnabled(false);
			aactor.SetActorHiddenInGame(true);
			UKuroSceneItemMoveComponent orAddMoveComponent = this.GetOrAddMoveComponent(aactor);
			if (orAddMoveComponent == null || !orAddMoveComponent.IsValid())
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.PathDrivenActor;
				ELogAuthor author2 = ELogAuthor.WRY;
				string message2 = "[PathDrivenActorSpawnerComponent] Actor缺少KuroSceneItemMoveComponent";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("PbDataId", this.OwnerPbDataId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("ActorBlueprintPath", this.SpawnRule.ActorBlueprintPath);
				instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				Singleton<ActorSystem>.Instance.Put("[PathDrivenActorSpawnerComponent] InvalidMoveComponent", aactor, null);
				return;
			}
			PathDrivenActorRuntimeController.<>c__DisplayClass17_0 CS$<>8__locals2 = CS$<>8__locals1;
			PathDrivenActorRuntimeData pathDrivenActorRuntimeData = new PathDrivenActorRuntimeData();
			pathDrivenActorRuntimeData.OwnerEntity = this.OwnerEntity;
			pathDrivenActorRuntimeData.Actor = aactor;
			pathDrivenActorRuntimeData.MoveComponent = orAddMoveComponent;
			pathDrivenActorRuntimeData.Finished = false;
			pathDrivenActorRuntimeData.PendingRecycle = false;
			pathDrivenActorRuntimeData.RequestFinish = delegate(EPathDrivenActorFinishReason _)
			{
			};
			pathDrivenActorRuntimeData.OnMoveStoppedHandler = delegate()
			{
			};
			CS$<>8__locals2.runtimeData = pathDrivenActorRuntimeData;
			CS$<>8__locals1.runtimeData.RequestFinish = delegate(EPathDrivenActorFinishReason reason)
			{
				CS$<>8__locals1.<>4__this.RequestFinish(CS$<>8__locals1.runtimeData, reason);
			};
			CS$<>8__locals1.runtimeData.OnMoveStoppedHandler = delegate()
			{
				AActor actor = CS$<>8__locals1.runtimeData.Actor;
				if (actor != null && actor.IsValid())
				{
					CS$<>8__locals1.runtimeData.RequestFinish(EPathDrivenActorFinishReason.ReachEnd);
				}
			};
			CS$<>8__locals1.runtimeData.Behavior = this.BehaviorFactory.CreateBehavior(aactor, this.OwnerPbDataId);
			if (CS$<>8__locals1.runtimeData.Behavior != null && !CS$<>8__locals1.runtimeData.Behavior.Initialize(CS$<>8__locals1.runtimeData))
			{
				this.CleanupBehavior(CS$<>8__locals1.runtimeData);
				orAddMoveComponent.StopAllMove(false, false);
				Singleton<ActorSystem>.Instance.Put("[PathDrivenActorSpawnerComponent] InitBehaviorFailed", aactor, null);
				return;
			}
			this.PrepareBehaviorCollisionBeforeSpawn(CS$<>8__locals1.runtimeData);
			this.RegisterActiveRuntimeData(CS$<>8__locals1.runtimeData);
			aactor.D_K2_SetActorTransform(transform, false, null, false);
			aactor.SetActorHiddenInGame(false);
			aactor.SetActorTickEnabled(true);
			if (!orAddMoveComponent.StartMoveWithSplineAtConstantTime(sceneItemSplineMoveAtConstantTimeParam.Spline, sceneItemSplineMoveAtConstantTimeParam.IsRepeat, sceneItemSplineMoveAtConstantTimeParam.IsCycle, sceneItemSplineMoveAtConstantTimeParam.IsKeepLookAt, sceneItemSplineMoveAtConstantTimeParam.TimeSec, sceneItemSplineMoveAtConstantTimeParam.TimeDisCurve, sceneItemSplineMoveAtConstantTimeParam.StartTimeOffset, sceneItemSplineMoveAtConstantTimeParam.StartDis, sceneItemSplineMoveAtConstantTimeParam.EndDis))
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.PathDrivenActor;
				ELogAuthor author3 = ELogAuthor.WRY;
				string message3 = "[PathDrivenActorSpawnerComponent] 原生样条移动启动失败";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("PbDataId", this.OwnerPbDataId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("SplineEntityId", pathDrivenSplineRuntimeData.SplineEntityId);
				instance3.Warn(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
				this.CleanupActiveRuntimeData(CS$<>8__locals1.runtimeData, "[PathDrivenActorSpawnerComponent] StartMoveFailed");
				return;
			}
			this.RestoreBehaviorCollisionAfterSpawn(CS$<>8__locals1.runtimeData);
		}

		// Token: 0x06030188 RID: 197000 RVA: 0x00BAAC98 File Offset: 0x00BA8E98
		private int GetActiveRuntimeCount()
		{
			int num = 0;
			for (int i = 0; i < this.ActiveRuntimeDataList.Count; i++)
			{
				if (!this.ActiveRuntimeDataList[i].Finished)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06030189 RID: 197001 RVA: 0x00BAACD8 File Offset: 0x00BA8ED8
		[NullableContext(2)]
		private IPathDrivenSplineRuntimeData SelectTrackRuntimeData()
		{
			if (this.TrackList.Count <= 0)
			{
				return null;
			}
			IPathDrivenActorSplineMove moveMode = this.SpawnRule.MoveMode;
			if (moveMode != null && moveMode.IsRandomSpline.GetValueOrDefault())
			{
				int num = (int)Math.Floor(Singleton<MathUtils>.Instance.GetRandomRange(0.0, (double)this.TrackList.Count));
				if (num >= this.TrackList.Count)
				{
					num = this.TrackList.Count - 1;
				}
				return this.TrackList[num];
			}
			int index = this.NextSplineIndex % this.TrackList.Count;
			this.NextSplineIndex++;
			return this.TrackList[index];
		}

		// Token: 0x0603018A RID: 197002 RVA: 0x00BAAD94 File Offset: 0x00BA8F94
		private float GetNextSpawnDelaySec()
		{
			float num = Math.Max(this.SpawnRule.SpawnInterval, 0.01f);
			float? maxSpawnInterval = this.SpawnRule.MaxSpawnInterval;
			if (maxSpawnInterval != null)
			{
				float? num2 = maxSpawnInterval;
				float num3 = num;
				if (num2.GetValueOrDefault() > num3 & num2 != null)
				{
					return (float)Math.Max(Singleton<MathUtils>.Instance.GetRandomRange((double)num, (double)maxSpawnInterval.Value), 0.009999999776482582);
				}
			}
			return num;
		}

		// Token: 0x0603018B RID: 197003 RVA: 0x00BAAE0C File Offset: 0x00BA900C
		private SceneItemMoveComponent.SceneItemSplineMoveAtConstantTimeParam CloneMoveParam(SceneItemMoveComponent.SceneItemSplineMoveAtConstantTimeParam template)
		{
			return new SceneItemMoveComponent.SceneItemSplineMoveAtConstantTimeParam(template.Spline)
			{
				IsRepeat = template.IsRepeat,
				IsCycle = template.IsCycle,
				IsKeepLookAt = template.IsKeepLookAt,
				TimeSec = template.TimeSec,
				TimeDisCurve = template.TimeDisCurve,
				StartTimeOffset = template.StartTimeOffset,
				StartDis = template.StartDis,
				EndDis = template.EndDis
			};
		}

		// Token: 0x0603018C RID: 197004 RVA: 0x00BAAE84 File Offset: 0x00BA9084
		[return: Nullable(2)]
		private UKuroSceneItemMoveComponent GetOrAddMoveComponent(AActor actor)
		{
			UKuroSceneItemMoveComponent ukuroSceneItemMoveComponent = actor.GetComponentByClass(UKuroSceneItemMoveComponent.StaticClass()) as UKuroSceneItemMoveComponent;
			if (ukuroSceneItemMoveComponent == null || !ukuroSceneItemMoveComponent.IsValid())
			{
				TSubclassOf<UActorComponent> @class = UKuroSceneItemMoveComponent.StaticClass();
				bool bManualAttachment = false;
				FTransform ftransform = new FTransform();
				ukuroSceneItemMoveComponent = (actor.AddComponentByClass(@class, bManualAttachment, ftransform, false, default(FName)) as UKuroSceneItemMoveComponent);
			}
			if (ukuroSceneItemMoveComponent == null || !ukuroSceneItemMoveComponent.IsValid())
			{
				return null;
			}
			return ukuroSceneItemMoveComponent;
		}

		// Token: 0x0603018D RID: 197005 RVA: 0x00BAAEEF File Offset: 0x00BA90EF
		private void PrepareBehaviorCollisionBeforeSpawn(IPathDrivenActorRuntimeData runtimeData)
		{
			IPathDrivenActorBehavior behavior = runtimeData.Behavior;
			if (behavior == null)
			{
				return;
			}
			behavior.PrepareCollisionBeforeSpawn(runtimeData);
		}

		// Token: 0x0603018E RID: 197006 RVA: 0x00BAAF02 File Offset: 0x00BA9102
		private void RestoreBehaviorCollisionAfterSpawn(IPathDrivenActorRuntimeData runtimeData)
		{
			IPathDrivenActorBehavior behavior = runtimeData.Behavior;
			if (behavior == null)
			{
				return;
			}
			behavior.RestoreCollisionAfterSpawn(runtimeData);
		}

		// Token: 0x0603018F RID: 197007 RVA: 0x00BAAF15 File Offset: 0x00BA9115
		private void ClearBehaviorCollisionBeforeRecycle(IPathDrivenActorRuntimeData runtimeData)
		{
			IPathDrivenActorBehavior behavior = runtimeData.Behavior;
			if (behavior == null)
			{
				return;
			}
			behavior.ClearCollisionBeforeRecycle(runtimeData);
		}

		// Token: 0x06030190 RID: 197008 RVA: 0x00BAAF28 File Offset: 0x00BA9128
		private void RegisterActiveRuntimeData(IPathDrivenActorRuntimeData runtimeData)
		{
			runtimeData.MoveComponent.OnMoveStopCallback.Add(runtimeData.OnMoveStoppedHandler);
			this.ActiveRuntimeDataList.Add(runtimeData);
		}

		// Token: 0x06030191 RID: 197009 RVA: 0x00BAAF4C File Offset: 0x00BA914C
		private void CleanupMoveCallback(IPathDrivenActorRuntimeData runtimeData)
		{
			UKuroSceneItemMoveComponent moveComponent = runtimeData.MoveComponent;
			if (moveComponent != null && moveComponent.IsValid())
			{
				runtimeData.MoveComponent.OnMoveStopCallback.Remove(runtimeData.OnMoveStoppedHandler);
			}
		}

		// Token: 0x06030192 RID: 197010 RVA: 0x00BAAF78 File Offset: 0x00BA9178
		private void RemoveRuntimeData(IPathDrivenActorRuntimeData runtimeData)
		{
			int num = this.ActiveRuntimeDataList.IndexOf(runtimeData);
			if (num >= 0)
			{
				this.ActiveRuntimeDataList.RemoveAt(num);
			}
		}

		// Token: 0x06030193 RID: 197011 RVA: 0x00BAAFA2 File Offset: 0x00BA91A2
		private bool TryStartFinishing(IPathDrivenActorRuntimeData runtimeData)
		{
			if (runtimeData.Finished)
			{
				return false;
			}
			runtimeData.Finished = true;
			this.CleanupMoveCallback(runtimeData);
			return true;
		}

		// Token: 0x06030194 RID: 197012 RVA: 0x00BAAFBD File Offset: 0x00BA91BD
		private void RequestFinish(IPathDrivenActorRuntimeData runtimeData, EPathDrivenActorFinishReason reason)
		{
			if (!this.TryStartFinishing(runtimeData))
			{
				return;
			}
			this.ApplyFinishPresentation(runtimeData, reason);
			this.NotifyBehaviorFinishing(runtimeData, reason);
			this.MarkPendingRecycle(runtimeData);
		}

		// Token: 0x06030195 RID: 197013 RVA: 0x00BAAFE0 File Offset: 0x00BA91E0
		private void ApplyFinishPresentation(IPathDrivenActorRuntimeData runtimeData, EPathDrivenActorFinishReason reason)
		{
			if (reason == EPathDrivenActorFinishReason.Overlap)
			{
				AActor actor = runtimeData.Actor;
				if (actor != null && actor.IsValid())
				{
					runtimeData.Actor.SetActorHiddenInGame(true);
					runtimeData.Actor.SetActorTickEnabled(false);
					return;
				}
			}
		}

		// Token: 0x06030196 RID: 197014 RVA: 0x00BAB015 File Offset: 0x00BA9215
		private void NotifyBehaviorFinishing(IPathDrivenActorRuntimeData runtimeData, EPathDrivenActorFinishReason reason)
		{
			if (runtimeData.Behavior == null)
			{
				return;
			}
			this.ClearBehaviorCollisionBeforeRecycle(runtimeData);
			runtimeData.Behavior.OnFinishing(runtimeData, reason);
		}

		// Token: 0x06030197 RID: 197015 RVA: 0x00BAB034 File Offset: 0x00BA9234
		private void CleanupActiveRuntimeData(IPathDrivenActorRuntimeData runtimeData, string reason)
		{
			UKuroSceneItemMoveComponent moveComponent = runtimeData.MoveComponent;
			runtimeData.PendingRecycle = false;
			this.CleanupMoveCallback(runtimeData);
			this.RemoveRuntimeData(runtimeData);
			this.ClearBehaviorCollisionBeforeRecycle(runtimeData);
			this.CleanupBehavior(runtimeData);
			if (!runtimeData.Finished && moveComponent != null && moveComponent.IsValid())
			{
				moveComponent.StopAllMove(false, false);
			}
			AActor actor = runtimeData.Actor;
			if (actor != null && actor.IsValid())
			{
				Singleton<ActorSystem>.Instance.Put(reason, runtimeData.Actor, null);
			}
		}

		// Token: 0x06030198 RID: 197016 RVA: 0x00BAB0AD File Offset: 0x00BA92AD
		private void CleanupBehavior(IPathDrivenActorRuntimeData runtimeData)
		{
			if (runtimeData.Behavior == null)
			{
				return;
			}
			runtimeData.Behavior.Cleanup(runtimeData);
			runtimeData.Behavior = null;
		}

		// Token: 0x06030199 RID: 197017 RVA: 0x00BAB0CB File Offset: 0x00BA92CB
		private void MarkPendingRecycle(IPathDrivenActorRuntimeData runtimeData)
		{
			if (runtimeData.PendingRecycle)
			{
				return;
			}
			runtimeData.PendingRecycle = true;
			this.PendingRecycleList.Add(runtimeData);
		}

		// Token: 0x0603019A RID: 197018 RVA: 0x00BAB0EC File Offset: 0x00BA92EC
		private void RecyclePendingActors()
		{
			int count = this.PendingRecycleList.Count;
			for (int i = 0; i < count; i++)
			{
				IPathDrivenActorRuntimeData pathDrivenActorRuntimeData = this.PendingRecycleList[i];
				if (pathDrivenActorRuntimeData.PendingRecycle)
				{
					this.CleanupActiveRuntimeData(pathDrivenActorRuntimeData, "[PathDrivenActorSpawnerComponent] FinishRecycle");
				}
			}
			this.PendingRecycleList.Clear();
		}

		// Token: 0x0401B9DB RID: 113115
		private const float MIN_SPAWN_INTERVAL = 0.01f;

		// Token: 0x0401B9DC RID: 113116
		private readonly Entity OwnerEntity;

		// Token: 0x0401B9DD RID: 113117
		private readonly int? OwnerPbDataId;

		// Token: 0x0401B9DE RID: 113118
		private readonly UClass ActorClass;

		// Token: 0x0401B9DF RID: 113119
		private readonly IIntervalSplineSpawn SpawnRule;

		// Token: 0x0401B9E0 RID: 113120
		private readonly IReadOnlyList<IPathDrivenSplineRuntimeData> TrackList;

		// Token: 0x0401B9E1 RID: 113121
		private readonly PathDrivenActorBehaviorFactory BehaviorFactory = new PathDrivenActorBehaviorFactory();

		// Token: 0x0401B9E2 RID: 113122
		private float NextSpawnDelaySec;

		// Token: 0x0401B9E3 RID: 113123
		private int NextSplineIndex;

		// Token: 0x0401B9E4 RID: 113124
		private readonly List<IPathDrivenActorRuntimeData> ActiveRuntimeDataList = new List<IPathDrivenActorRuntimeData>();

		// Token: 0x0401B9E5 RID: 113125
		private readonly List<IPathDrivenActorRuntimeData> PendingRecycleList = new List<IPathDrivenActorRuntimeData>();
	}
}
