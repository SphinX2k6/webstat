using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Vehicle.Motorcycle
{
	// Token: 0x020047AE RID: 18350
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorcycleTraceWaterCapability : GameCapability
	{
		// Token: 0x0602FA03 RID: 195075 RVA: 0x00B5DA16 File Offset: 0x00B5BC16
		public MotorcycleTraceWaterCapability(VehicleActorComponent ActorComp)
		{
			this.ActorComp = ActorComp;
		}

		// Token: 0x0602FA04 RID: 195076 RVA: 0x00B5DA3C File Offset: 0x00B5BC3C
		public override void Activate()
		{
			this.WaterTrace = new UTraceSphereElement();
			this.WaterTrace.WorldContextObject = this.ActorComp.Owner;
			this.WaterTrace.Radius = 1f;
			this.WaterTrace.bIgnoreSelf = true;
			this.WaterTrace.bIsSingle = false;
			this.WaterTrace.DrawTime = 0.1f;
			this.WaterTrace.SetTraceTypeQuery(KuroTraceTypeQuery.Water);
			Singleton<TraceElementCommon>.Instance.SetTraceColor(this.WaterTrace, CharacterSwimUtils.DebugColor3);
			Singleton<TraceElementCommon>.Instance.SetTraceHitColor(this.WaterTrace, CharacterSwimUtils.DebugColor4);
		}

		// Token: 0x0602FA05 RID: 195077 RVA: 0x00B5DADC File Offset: 0x00B5BCDC
		public override void Deactivate()
		{
			UTraceSphereElement waterTrace = this.WaterTrace;
			if (waterTrace != null)
			{
				waterTrace.Dispose();
			}
			this.WaterTrace = null;
		}

		// Token: 0x0602FA06 RID: 195078 RVA: 0x00B5DAF8 File Offset: 0x00B5BCF8
		public TraceWaterResult TraceWater(double relativeStartHeight, double relativeEndHeight)
		{
			VehicleActorComponent actorComp = this.ActorComp;
			Singleton<MathUtils>.Instance.CommonTempVector.DeepCopy(actorComp.ActorLocationProxy);
			Singleton<GravityUtils>.Instance.AddZnInGravityForActor(actorComp, Singleton<MathUtils>.Instance.CommonTempVector, relativeStartHeight);
			Singleton<TraceElementCommon>.Instance.SetStartLocation(this.WaterTrace, Singleton<MathUtils>.Instance.CommonTempVector);
			Singleton<MathUtils>.Instance.CommonTempVector.DeepCopy(actorComp.ActorLocationProxy);
			Singleton<GravityUtils>.Instance.AddZnInGravityForActor(actorComp, Singleton<MathUtils>.Instance.CommonTempVector, relativeEndHeight);
			Singleton<TraceElementCommon>.Instance.SetEndLocation(this.WaterTrace, Singleton<MathUtils>.Instance.CommonTempVector);
			this.WaterTrace.SetDrawDebugTrace((ModelBase<SundryModel>.Instance.GetModuleDebugLevel("MotorWater") > 0) ? EDrawDebugTrace.ForDuration : EDrawDebugTrace.None);
			bool flag = Singleton<TraceElementCommon>.Instance.SphereTrace(this.WaterTrace, "MotorWaterTrace");
			bool foundWater = false;
			double num = relativeStartHeight + 1.0;
			if (flag)
			{
				UKuroHitResult hitResult = this.WaterTrace.HitResult;
				int hitCount = hitResult.GetHitCount();
				for (int i = 0; i < hitCount; i++)
				{
					if (hitResult.Actors.Get(i).IsValid(false, false))
					{
						Singleton<TraceElementCommon>.Instance.GetImpactPoint(hitResult, i, Singleton<MathUtils>.Instance.CommonTempVector);
						Singleton<MathUtils>.Instance.CommonTempVector.SubtractionEqual(actorComp.ActorLocationProxy);
						double znInGravityForActor = Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, Singleton<MathUtils>.Instance.CommonTempVector);
						foundWater = true;
						if (znInGravityForActor < num)
						{
							num = znInGravityForActor;
							Singleton<TraceElementCommon>.Instance.GetImpactPoint(hitResult, i, this.ImpactPoint);
							Singleton<TraceElementCommon>.Instance.GetImpactNormal(hitResult, i, this.ImpactNormal);
						}
					}
				}
			}
			return new TraceWaterResult
			{
				FoundWater = foundWater,
				MinWaterHeight = (float)num,
				ImpactPoint = this.ImpactPoint,
				ImpactNormal = this.ImpactNormal
			};
		}

		// Token: 0x0602FA07 RID: 195079 RVA: 0x00B5DCCC File Offset: 0x00B5BECC
		public bool CeilingCheck(double relativeHeight)
		{
			UTraceSphereElement actorTrace = ModelBase<TraceElementModel>.Instance.GetActorTrace();
			VehicleActorComponent actorComp = this.ActorComp;
			actorTrace.WorldContextObject = this.ActorComp.Owner;
			actorTrace.Radius = 5f;
			Singleton<MathUtils>.Instance.CommonTempVector.DeepCopy(actorComp.ActorLocationProxy);
			Singleton<TraceElementCommon>.Instance.SetStartLocation(actorTrace, Singleton<MathUtils>.Instance.CommonTempVector);
			Singleton<MathUtils>.Instance.CommonTempVector.DeepCopy(actorComp.ActorLocationProxy);
			Singleton<GravityUtils>.Instance.AddZnInGravityForActor(actorComp, Singleton<MathUtils>.Instance.CommonTempVector, relativeHeight);
			Singleton<TraceElementCommon>.Instance.SetEndLocation(actorTrace, Singleton<MathUtils>.Instance.CommonTempVector);
			actorTrace.ActorsToIgnore.Empty(true);
			foreach (AActor value in ModelBase<WorldModel>.Instance.ActorsToIgnoreSet)
			{
				actorTrace.ActorsToIgnore.Add(value);
			}
			if (Singleton<TraceElementCommon>.Instance.ShapeTrace(actorComp.Actor.CapsuleComponent, actorTrace, "MotorWaterTrace", "MotorWaterTrace"))
			{
				UKuroHitResult hitResult = actorTrace.HitResult;
				int hitCount = hitResult.GetHitCount();
				for (int i = 0; i < hitCount; i++)
				{
					if (!(UKuroCollisionLibrary.GetBodyInstance(hitResult, i).ObjectType == KuroCollisionChannel.KuroWater))
					{
						TWeakObjectPtr<AActor> tweakObjectPtr = hitResult.Actors.Get(i);
						if (tweakObjectPtr.IsValid(false, false) && !(tweakObjectPtr.Get() is TsBaseCharacter) && !(tweakObjectPtr.Get() is TsBaseVehicle))
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0401B3F2 RID: 111602
		private const string PROFILE_DETECT_WATER_DEPTH = "MotorWaterTrace";

		// Token: 0x0401B3F3 RID: 111603
		[StaticVariableRuleIgnore]
		public static FName waterCollisionProfileName = new FName("水体");

		// Token: 0x0401B3F4 RID: 111604
		public const int ONE_HUNDRED = 100;

		// Token: 0x0401B3F5 RID: 111605
		public const int FIVE_HUNDRED = 500;

		// Token: 0x0401B3F6 RID: 111606
		public const string MOTORCYCLE_WATER_DEBUG_KEY = "MotorWater";

		// Token: 0x0401B3F7 RID: 111607
		[Nullable(2)]
		private UTraceSphereElement WaterTrace;

		// Token: 0x0401B3F8 RID: 111608
		public readonly Vector ImpactPoint = Vector.Create();

		// Token: 0x0401B3F9 RID: 111609
		public readonly Vector ImpactNormal = Vector.Create();

		// Token: 0x0401B3FA RID: 111610
		private readonly VehicleActorComponent ActorComp;
	}
}
