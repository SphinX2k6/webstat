using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.NewWorld.SceneItem;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052F1 RID: 21233
	[NullableContext(1)]
	[Nullable(0)]
	public class QuickHackAimTargetSelector : QuickHackTargetSelector
	{
		// Token: 0x0603635A RID: 222042 RVA: 0x00DA8FA8 File Offset: 0x00DA71A8
		public override void Init(int selectRange, int selectScreenRadius)
		{
			base.Init(selectRange, selectScreenRadius);
			UTraceLineElement utraceLineElement = new UTraceLineElement();
			utraceLineElement.WorldContextObject = GlobalData.World;
			utraceLineElement.bIsSingle = false;
			TArray<TEnumAsByte<EObjectTypeQuery>> tarray = new TArray<TEnumAsByte<EObjectTypeQuery>>();
			tarray.Add(KuroObjectTypeQuery.WorldStatic);
			tarray.Add(KuroObjectTypeQuery.WorldStaticIgnoreBullet);
			tarray.Add(KuroObjectTypeQuery.PawnMonster);
			tarray.Add(KuroObjectTypeQuery.Pawn);
			utraceLineElement.SetObjectTypesQuery(ref tarray);
			this.LineElement = utraceLineElement;
		}

		// Token: 0x0603635B RID: 222043 RVA: 0x00DA902A File Offset: 0x00DA722A
		public override void Clear()
		{
			this.LineElement = null;
			this.EntitiesInRange.Clear();
			this.Targets.Clear();
			this.LockTargetInfo = null;
			this.OnScreenTargetInfo = null;
		}

		// Token: 0x0603635C RID: 222044 RVA: 0x00DA9058 File Offset: 0x00DA7258
		public override bool UpdateTargetInfo(float delta)
		{
			if (this.LockTargetInfo == null)
			{
				this.LockTargetInfo = new QuickHackLockTargetInfo
				{
					HackType = null,
					Targets = this.Targets
				};
			}
			if (this.OnScreenTargetInfo == null)
			{
				this.OnScreenTargetInfo = new QuickHackOnScreenTargetInfo
				{
					TargetIdToIndexMap = new Dictionary<int, int>(),
					Targets = new List<EntityHandle>(),
					SignedScreenDistSquaredList = new List<double>(),
					DistSquaredList = new List<double>()
				};
			}
			if (this.NeedUpdateCurrentTarget)
			{
				this.NeedUpdateCurrentTarget = false;
				return this.UpdateCurrentTarget();
			}
			if (this.TraceInterval > 0f)
			{
				this.TraceInterval -= delta;
				return false;
			}
			this.UpdatePendingTarget();
			this.NeedUpdateCurrentTarget = true;
			this.TraceInterval = 200f;
			return false;
		}

		// Token: 0x0603635D RID: 222045 RVA: 0x00DA9120 File Offset: 0x00DA7320
		private void UpdatePendingTarget()
		{
			QuickHackAimTargetSelector.TraceInfo traceInfo = null;
			EntityHandle pendingLockTarget = null;
			bool flag = true;
			Dictionary<int, bool> dictionary = new Dictionary<int, bool>();
			foreach (QuickHackAimTargetSelector.TraceInfo traceInfo2 in this.AimTrace())
			{
				AActor aactor = (traceInfo2 != null) ? traceInfo2.Actor : null;
				if (aactor == null || !aactor.IsValid())
				{
					flag = false;
				}
				else
				{
					EntityHandle entityByChildActor = ModelBase<CreatureModel>.Instance.GetEntityByChildActor(aactor);
					if (entityByChildActor != null)
					{
						int id = entityByChildActor.Id;
						if (!dictionary.ContainsKey(id))
						{
							bool flag2 = this.CheckEntityValid(entityByChildActor);
							dictionary[id] = flag2;
							if (flag2 && (traceInfo == null || traceInfo2.Distance <= traceInfo.Distance))
							{
								traceInfo = traceInfo2;
								pendingLockTarget = entityByChildActor;
							}
						}
					}
				}
			}
			this.PendingLockTarget = pendingLockTarget;
			Dictionary<int, int> targetIdToIndexMap = this.OnScreenTargetInfo.TargetIdToIndexMap;
			List<EntityHandle> targets = this.OnScreenTargetInfo.Targets;
			List<double> signedScreenDistSquaredList = this.OnScreenTargetInfo.SignedScreenDistSquaredList;
			List<double> distSquaredList = this.OnScreenTargetInfo.DistSquaredList;
			targetIdToIndexMap.Clear();
			targets.Clear();
			signedScreenDistSquaredList.Clear();
			distSquaredList.Clear();
			FVectorDouble fvectorDouble = Global.CharacterCameraManager.D_GetCameraLocation();
			this.StartLocation.FromUeVector(fvectorDouble);
			ModelBase<CreatureModel>.Instance.GetEntitiesInRangeWithLocation(this.StartLocation, (float)this.SelectRange, this.EntityTypeQuery, this.EntitiesInRange, true);
			double num = double.MaxValue;
			foreach (EntityHandle entityHandle in this.EntitiesInRange)
			{
				int id2 = entityHandle.Id;
				bool flag3;
				if ((dictionary.TryGetValue(id2, out flag3) ? flag3 : this.CheckEntityValid(entityHandle)) && this.CheckEntityRendered(entityHandle))
				{
					FVectorDouble entityLocation = this.GetEntityLocation(entityHandle);
					if (base.ProjectWorldToScreen(entityLocation, this.ScreenPos, 0.1f))
					{
						bool flag4 = this.ScreenPos.X <= 0.0;
						double num2 = this.ScreenPos.SizeSquared();
						this.TempVector.FromUeVector(entityLocation);
						this.TempVector.SubtractionEqual(this.StartLocation);
						double num3 = this.TempVector.SizeSquared();
						int count = targets.Count;
						targetIdToIndexMap[id2] = count;
						targets.Add(entityHandle);
						signedScreenDistSquaredList.Add(flag4 ? (-num2) : num2);
						distSquaredList.Add(num3);
						if (!flag && this.PendingLockTarget == null && num2 <= (double)this.ScreenRadiusSquared && num3 < num)
						{
							num = num3;
							pendingLockTarget = entityHandle;
						}
					}
				}
			}
			this.PendingLockTarget = pendingLockTarget;
		}

		// Token: 0x0603635E RID: 222046 RVA: 0x00DA9404 File Offset: 0x00DA7604
		[return: Nullable(new byte[]
		{
			1,
			2
		})]
		private List<QuickHackAimTargetSelector.TraceInfo> AimTrace()
		{
			List<QuickHackAimTargetSelector.TraceInfo> list = new List<QuickHackAimTargetSelector.TraceInfo>();
			APlayerCameraManager characterCameraManager = Global.CharacterCameraManager;
			if (characterCameraManager == null)
			{
				return list;
			}
			FVectorDouble fvectorDouble = characterCameraManager.D_GetCameraLocation();
			this.CameraLocation.FromUeVector(fvectorDouble);
			int num = (this.SelectRange <= 2000) ? this.SelectRange : 2000;
			Vector tempVector = this.TempVector;
			FVectorDouble fvectorDouble2 = characterCameraManager.D_GetActorForwardVector();
			tempVector.FromUeVector(fvectorDouble2);
			this.TempVector.MultiplyEqual((double)num);
			list.Add(this.LineTrace(this.CameraLocation, Vector.ZeroVectorProxy, this.TempVector));
			FVectorDouble fvectorDouble3 = characterCameraManager.D_GetActorUpVector();
			this.StartOffset.FromUeVector(fvectorDouble3);
			list.Add(this.LineTrace(this.CameraLocation, this.StartOffset, this.TempVector));
			this.StartOffset.MultiplyEqual(-1.0);
			list.Add(this.LineTrace(this.CameraLocation, this.StartOffset, this.TempVector));
			FVectorDouble fvectorDouble4 = characterCameraManager.D_GetActorRightVector();
			this.StartOffset.FromUeVector(fvectorDouble4);
			list.Add(this.LineTrace(this.CameraLocation, this.StartOffset, this.TempVector));
			this.StartOffset.MultiplyEqual(-1.0);
			list.Add(this.LineTrace(this.CameraLocation, this.StartOffset, this.TempVector));
			return list;
		}

		// Token: 0x0603635F RID: 222047 RVA: 0x00DA9560 File Offset: 0x00DA7760
		[return: Nullable(2)]
		private QuickHackAimTargetSelector.TraceInfo LineTrace(Vector start, Vector startOffsetDirect, Vector endOffset)
		{
			this.StartLocation.DeepCopy(startOffsetDirect);
			this.StartLocation.MultiplyEqual(22.0);
			this.StartLocation.AdditionEqual(start);
			this.EndLocation.DeepCopy(this.StartLocation);
			this.EndLocation.AdditionEqual(endOffset);
			UTraceLineElement lineElement = this.LineElement;
			Singleton<TraceElementCommon>.Instance.SetStartLocation(lineElement, this.StartLocation);
			Singleton<TraceElementCommon>.Instance.SetEndLocation(lineElement, this.EndLocation);
			if (!Singleton<TraceElementCommon>.Instance.LineTrace(lineElement, "QuickHackAimTargetSelector"))
			{
				return null;
			}
			UKuroHitResult hitResult = lineElement.HitResult;
			if (!hitResult.bBlockingHit)
			{
				return null;
			}
			TArray<TWeakObjectPtr<AActor>> actors = hitResult.Actors;
			TArray<float> distanceArray = hitResult.DistanceArray;
			int hitCount = hitResult.GetHitCount();
			for (int i = 0; i < hitCount; i++)
			{
				AActor aactor = actors.Get(i).Get();
				if (aactor != null)
				{
					FName? dynamicFName = FNameUtil.GetDynamicFName("IgnoreHackTrace");
					if (dynamicFName == null || !aactor.ActorHasTag(dynamicFName.Value))
					{
						return new QuickHackAimTargetSelector.TraceInfo(aactor, distanceArray.Get(i));
					}
				}
			}
			return null;
		}

		// Token: 0x06036360 RID: 222048 RVA: 0x00DA967C File Offset: 0x00DA787C
		private bool UpdateCurrentTarget()
		{
			EntityHandle pendingLockTarget = this.PendingLockTarget;
			if (pendingLockTarget == null || !pendingLockTarget.Valid)
			{
				return this.ClearCurrentTarget();
			}
			CreatureDataComponent component = pendingLockTarget.Entity.GetComponent<CreatureDataComponent>();
			if (component.GetRemoveState())
			{
				return this.ClearCurrentTarget();
			}
			if (this.Targets.Count > 0 && this.Targets[0].Id == pendingLockTarget.Id)
			{
				return false;
			}
			EQuickHackTargetType? hackType = null;
			if (component.IsMonster())
			{
				hackType = new EQuickHackTargetType?(EQuickHackTargetType.EnemyMonster);
			}
			else if (component.IsSceneItem())
			{
				hackType = new EQuickHackTargetType?(EQuickHackTargetType.SceneItem);
			}
			if (hackType == null)
			{
				return false;
			}
			this.Targets.Clear();
			this.Targets.Add(pendingLockTarget);
			this.LockTargetInfo.HackType = hackType;
			return true;
		}

		// Token: 0x06036361 RID: 222049 RVA: 0x00DA9748 File Offset: 0x00DA7948
		private bool ClearCurrentTarget()
		{
			if (this.Targets.Count <= 0)
			{
				return false;
			}
			this.Targets.Clear();
			this.LockTargetInfo.HackType = null;
			return true;
		}

		// Token: 0x06036362 RID: 222050 RVA: 0x00DA9788 File Offset: 0x00DA7988
		public override IQuickHackLockTargetInfo GetLockTargetInfo()
		{
			if (this.LockTargetInfo == null)
			{
				this.LockTargetInfo = new QuickHackLockTargetInfo
				{
					HackType = null,
					Targets = this.Targets
				};
			}
			return this.LockTargetInfo;
		}

		// Token: 0x06036363 RID: 222051 RVA: 0x00DA97CC File Offset: 0x00DA79CC
		public override IQuickHackOnScreenTargetInfo GetOnScreenTargetInfo()
		{
			if (this.OnScreenTargetInfo == null)
			{
				this.OnScreenTargetInfo = new QuickHackOnScreenTargetInfo
				{
					TargetIdToIndexMap = new Dictionary<int, int>(),
					Targets = new List<EntityHandle>(),
					SignedScreenDistSquaredList = new List<double>(),
					DistSquaredList = new List<double>()
				};
			}
			return this.OnScreenTargetInfo;
		}

		// Token: 0x06036364 RID: 222052 RVA: 0x00DA9820 File Offset: 0x00DA7A20
		private bool CheckEntityValid(EntityHandle entityHandle)
		{
			if (!entityHandle.IsInit)
			{
				return false;
			}
			WorldEntity entity = entityHandle.Entity;
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			if (component.GetRemoveState())
			{
				return false;
			}
			if (!entity.Active)
			{
				return false;
			}
			if (!component.IsMonster())
			{
				return component.IsSceneItem() && entity.GetComponent<SceneItemQuickHackComponent>() != null && entity.GetComponent<SceneItemActorComponent>() != null;
			}
			BaseTagComponent component2 = entity.GetComponent<BaseTagComponent>();
			if (component2 != null && component2.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.隐身"]))
			{
				return false;
			}
			if (CampUtils.GetCampRelationship(component.GetEntityCamp(), ECamp.Player) != ERelation.Enemy)
			{
				return false;
			}
			BaseDeathComponent component3 = entity.GetComponent<BaseDeathComponent>();
			return component3 == null || !component3.IsDead();
		}

		// Token: 0x06036365 RID: 222053 RVA: 0x00DA98D0 File Offset: 0x00DA7AD0
		private bool CheckEntityRendered(EntityHandle entityHandle)
		{
			WorldEntity entity = entityHandle.Entity;
			SceneItemActorComponent component = entity.GetComponent<SceneItemActorComponent>();
			if (component != null)
			{
				component.TryRefreshShowActor();
				AActor curLevelPrefabShowActor = component.CurLevelPrefabShowActor;
				return curLevelPrefabShowActor != null && curLevelPrefabShowActor.IsValid() && curLevelPrefabShowActor.WasRecentlyRenderedOnScreen(0.2f);
			}
			BaseActorComponent component2 = entity.GetComponent<BaseActorComponent>();
			bool? flag;
			if (component2 == null)
			{
				flag = null;
			}
			else
			{
				AActor owner = component2.Owner;
				flag = ((owner != null) ? new bool?(owner.WasRecentlyRenderedOnScreen(0.2f)) : null);
			}
			bool? flag2 = flag;
			return flag2.GetValueOrDefault();
		}

		// Token: 0x06036366 RID: 222054 RVA: 0x00DA9954 File Offset: 0x00DA7B54
		private FVectorDouble GetEntityLocation(EntityHandle entityHandle)
		{
			SceneItemActorComponent component = entityHandle.Entity.GetComponent<SceneItemActorComponent>();
			if (component != null)
			{
				AActor referenceActor = component.GetReferenceActor("Center");
				if (referenceActor != null)
				{
					return referenceActor.D_K2_GetActorLocation();
				}
			}
			return entityHandle.Entity.GetComponent<BaseActorComponent>().ActorLocation;
		}

		// Token: 0x0401F2BA RID: 127674
		private const int TRACE_INTERVAL = 200;

		// Token: 0x0401F2BB RID: 127675
		private const int TRACE_RADIUS = 22;

		// Token: 0x0401F2BC RID: 127676
		private const int TRACE_DISTANCE_MAX = 2000;

		// Token: 0x0401F2BD RID: 127677
		private const string IGNORE_HACK_TRACE = "IgnoreHackTrace";

		// Token: 0x0401F2BE RID: 127678
		private readonly EEntityTypeQuery EntityTypeQuery = EEntityTypeQuery.NormalEntity | EEntityTypeQuery.NormalEntityAlwaysTick | EEntityTypeQuery.NormalEntityAlwaysTickWhitoutNotRenderedGroup | EEntityTypeQuery.MoveSceneItem | EEntityTypeQuery.PasserbyNPC | EEntityTypeQuery.Boss;

		// Token: 0x0401F2BF RID: 127679
		private readonly List<EntityHandle> EntitiesInRange = new List<EntityHandle>();

		// Token: 0x0401F2C0 RID: 127680
		private readonly List<EntityHandle> Targets = new List<EntityHandle>();

		// Token: 0x0401F2C1 RID: 127681
		[Nullable(2)]
		private IQuickHackOnScreenTargetInfo OnScreenTargetInfo;

		// Token: 0x0401F2C2 RID: 127682
		[Nullable(2)]
		private IQuickHackLockTargetInfo LockTargetInfo;

		// Token: 0x0401F2C3 RID: 127683
		[Nullable(2)]
		private UTraceLineElement LineElement;

		// Token: 0x0401F2C4 RID: 127684
		private float TraceInterval;

		// Token: 0x0401F2C5 RID: 127685
		private bool NeedUpdateCurrentTarget;

		// Token: 0x0401F2C6 RID: 127686
		[Nullable(2)]
		private EntityHandle PendingLockTarget;

		// Token: 0x0401F2C7 RID: 127687
		private readonly Vector2D ScreenPos = Vector2D.Create();

		// Token: 0x0401F2C8 RID: 127688
		private readonly Vector CameraLocation = Vector.Create();

		// Token: 0x0401F2C9 RID: 127689
		private readonly Vector StartLocation = Vector.Create();

		// Token: 0x0401F2CA RID: 127690
		private readonly Vector StartOffset = Vector.Create();

		// Token: 0x0401F2CB RID: 127691
		private readonly Vector EndLocation = Vector.Create();

		// Token: 0x0401F2CC RID: 127692
		private readonly Vector TempVector = Vector.Create();

		// Token: 0x0200B22C RID: 45612
		[Nullable(0)]
		private class TraceInfo
		{
			// Token: 0x0604C765 RID: 313189 RVA: 0x014F063E File Offset: 0x014EE83E
			public TraceInfo(AActor actor, float distance)
			{
			}

			// Token: 0x040373A5 RID: 226213
			public readonly AActor Actor = actor;

			// Token: 0x040373A6 RID: 226214
			public readonly float Distance = distance;
		}
	}
}
