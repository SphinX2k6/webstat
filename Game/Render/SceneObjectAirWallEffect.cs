using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.SceneItem.RefCompController;
using CSharpScript.Game.Utils;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x0200478D RID: 18317
	[NullableContext(1)]
	[Nullable(0)]
	public class SceneObjectAirWallEffect
	{
		// Token: 0x0602F889 RID: 194697 RVA: 0x00B52174 File Offset: 0x00B50374
		private void InitTraceInfo()
		{
			UTraceSphereElement utraceSphereElement = new UTraceSphereElement();
			utraceSphereElement.WorldContextObject = GlobalData.World;
			utraceSphereElement.bIsSingle = false;
			utraceSphereElement.bIgnoreSelf = true;
			utraceSphereElement.Radius = 1f;
			TArray<TEnumAsByte<EObjectTypeQuery>> tarray = new TArray<TEnumAsByte<EObjectTypeQuery>>();
			tarray.Add(KuroObjectTypeQuery.WorldStatic);
			tarray.Add(KuroObjectTypeQuery.WorldStaticIgnoreBullet);
			utraceSphereElement.SetObjectTypesQuery(ref tarray);
			if (Singleton<EffectGlobal>.Instance.SceneObjectAirWallEffectShowDebugTrace)
			{
				utraceSphereElement.DrawTime = 5f;
				utraceSphereElement.SetDrawDebugTrace(EDrawDebugTrace.ForDuration);
				Singleton<TraceElementCommon>.Instance.SetTraceColor(utraceSphereElement, ColorUtils.LinearGreen);
				Singleton<TraceElementCommon>.Instance.SetTraceHitColor(utraceSphereElement, ColorUtils.LinearRed);
			}
			this.SphereTrace = utraceSphereElement;
		}

		// Token: 0x0602F88A RID: 194698 RVA: 0x00B52220 File Offset: 0x00B50420
		protected void GetActorLocation()
		{
			Vector curPosition = this.CurPosition;
			FVectorDouble fvectorDouble = this.ActorToAttach.D_K2_GetComponentLocation();
			curPosition.FromUeVector(fvectorDouble);
		}

		// Token: 0x0602F88B RID: 194699 RVA: 0x00B52246 File Offset: 0x00B50446
		[NullableContext(2)]
		public void Start(USceneComponent actorToAttach)
		{
			if (actorToAttach == null)
			{
				return;
			}
			this.ActorToAttach = actorToAttach;
			this.IsReady = true;
			this.InitTraceInfo();
		}

		// Token: 0x0602F88C RID: 194700 RVA: 0x00B52260 File Offset: 0x00B50460
		public void AfterRegistered()
		{
			if (!this.IsReady)
			{
				return;
			}
			this.GetActorLocation();
			this.LastPosition.DeepCopy(this.CurPosition);
			this.IsEnabled = true;
		}

		// Token: 0x0602F88D RID: 194701 RVA: 0x00B52289 File Offset: 0x00B50489
		public void BeforeUnregistered()
		{
			this.IsEnabled = false;
		}

		// Token: 0x0602F88E RID: 194702 RVA: 0x00B52294 File Offset: 0x00B50494
		public void Update(double deltaTime)
		{
			if (this.IsEnabled)
			{
				USceneComponent actorToAttach = this.ActorToAttach;
				if (actorToAttach != null && actorToAttach.IsValid())
				{
					this.GetActorLocation();
					UTraceSphereElement sphereTrace = this.SphereTrace;
					Singleton<TraceElementCommon>.Instance.SetStartLocation(sphereTrace, this.LastPosition);
					Singleton<TraceElementCommon>.Instance.SetEndLocation(sphereTrace, this.CurPosition);
					bool flag = Singleton<TraceElementCommon>.Instance.SphereTrace(sphereTrace, "SceneObjectAirWallEffect_Update");
					UKuroHitResult hitResult = sphereTrace.HitResult;
					if (flag && hitResult != null && hitResult.bBlockingHit)
					{
						int hitCount = hitResult.GetHitCount();
						for (int i = 0; i < hitCount; i++)
						{
							AActor aactor = hitResult.Actors.Get(i).Get();
							if (aactor.Tags.FindIndex(RefCompAirWallController.AIR_WALL) != -1)
							{
								Vector vector = Vector.Create();
								Singleton<TraceElementCommon>.Instance.GetImpactPoint(hitResult, i, vector);
								Vector vector2 = Vector.Create();
								Singleton<TraceElementCommon>.Instance.GetImpactNormal(hitResult, i, vector2);
								Singleton<EventSystem>.Instance.EmitWithTarget<AActor, Vector, Vector>(aactor, EEventName.BulletHitAirWall, aactor, vector, vector2);
							}
						}
					}
					this.LastPosition.DeepCopy(this.CurPosition);
					return;
				}
			}
		}

		// Token: 0x0401B2EA RID: 111338
		private const string PROFILE_KEY = "SceneObjectAirWallEffect_Update";

		// Token: 0x0401B2EB RID: 111339
		private const int RADIUS = 1;

		// Token: 0x0401B2EC RID: 111340
		[Nullable(2)]
		public USceneComponent ActorToAttach;

		// Token: 0x0401B2ED RID: 111341
		public bool IsReady;

		// Token: 0x0401B2EE RID: 111342
		public bool IsEnabled;

		// Token: 0x0401B2EF RID: 111343
		private readonly Vector LastPosition = Vector.Create();

		// Token: 0x0401B2F0 RID: 111344
		private readonly Vector CurPosition = Vector.Create();

		// Token: 0x0401B2F1 RID: 111345
		[Nullable(2)]
		private UTraceSphereElement SphereTrace;
	}
}
