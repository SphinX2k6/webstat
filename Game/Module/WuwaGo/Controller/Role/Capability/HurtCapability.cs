using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using AkiClient.Game.Aki.Data.Gameplay.WuWaGo;
using CSharpScript.Game.Module.WuwaGo.Model.Role;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WuwaGo.Controller.Role.Capability
{
	// Token: 0x02004B01 RID: 19201
	[NullableContext(1)]
	[Nullable(0)]
	public class HurtCapability : CapabilityBase
	{
		// Token: 0x06032124 RID: 205092 RVA: 0x00C876CE File Offset: 0x00C858CE
		public HurtCapability(WuWaGoRole role) : base(role)
		{
		}

		// Token: 0x06032125 RID: 205093 RVA: 0x00C876D8 File Offset: 0x00C858D8
		[NullableContext(2)]
		public UniTask TakeAttack(bool playBeHitAnim, UAnimMontage deathMontage = null)
		{
			HurtCapability.<TakeAttack>d__10 <TakeAttack>d__;
			<TakeAttack>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TakeAttack>d__.<>4__this = this;
			<TakeAttack>d__.playBeHitAnim = playBeHitAnim;
			<TakeAttack>d__.deathMontage = deathMontage;
			<TakeAttack>d__.<>1__state = -1;
			<TakeAttack>d__.<>t__builder.Start<HurtCapability.<TakeAttack>d__10>(ref <TakeAttack>d__);
			return <TakeAttack>d__.<>t__builder.Task;
		}

		// Token: 0x06032126 RID: 205094 RVA: 0x00C8772C File Offset: 0x00C8592C
		private UniTask PerformBeAttackAnim()
		{
			HurtCapability.<PerformBeAttackAnim>d__11 <PerformBeAttackAnim>d__;
			<PerformBeAttackAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PerformBeAttackAnim>d__.<>4__this = this;
			<PerformBeAttackAnim>d__.<>1__state = -1;
			<PerformBeAttackAnim>d__.<>t__builder.Start<HurtCapability.<PerformBeAttackAnim>d__11>(ref <PerformBeAttackAnim>d__);
			return <PerformBeAttackAnim>d__.<>t__builder.Task;
		}

		// Token: 0x06032127 RID: 205095 RVA: 0x00C87770 File Offset: 0x00C85970
		[NullableContext(2)]
		private UniTask PerformDeathAnim(UAnimMontage deathMontage = null)
		{
			HurtCapability.<PerformDeathAnim>d__12 <PerformDeathAnim>d__;
			<PerformDeathAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PerformDeathAnim>d__.<>4__this = this;
			<PerformDeathAnim>d__.deathMontage = deathMontage;
			<PerformDeathAnim>d__.<>1__state = -1;
			<PerformDeathAnim>d__.<>t__builder.Start<HurtCapability.<PerformDeathAnim>d__12>(ref <PerformDeathAnim>d__);
			return <PerformDeathAnim>d__.<>t__builder.Task;
		}

		// Token: 0x06032128 RID: 205096 RVA: 0x00C877BC File Offset: 0x00C859BC
		private UniTask PerformClimbDeathSequence(UAnimMontage montage)
		{
			HurtCapability.<PerformClimbDeathSequence>d__13 <PerformClimbDeathSequence>d__;
			<PerformClimbDeathSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PerformClimbDeathSequence>d__.<>4__this = this;
			<PerformClimbDeathSequence>d__.montage = montage;
			<PerformClimbDeathSequence>d__.<>1__state = -1;
			<PerformClimbDeathSequence>d__.<>t__builder.Start<HurtCapability.<PerformClimbDeathSequence>d__13>(ref <PerformClimbDeathSequence>d__);
			return <PerformClimbDeathSequence>d__.<>t__builder.Task;
		}

		// Token: 0x06032129 RID: 205097 RVA: 0x00C87808 File Offset: 0x00C85A08
		private HurtCapability.EClimbDeathPhase OnClimbDeathTick(UAnimInstance animInstance, UAnimMontage montage, float? groundZ, float delta, HurtCapability.EClimbDeathPhase phase)
		{
			FVectorDouble? worldLocation = this.Role.GetWorldLocation();
			if (worldLocation == null)
			{
				return phase;
			}
			FVectorDouble value = worldLocation.Value;
			switch (phase)
			{
			case HurtCapability.EClimbDeathPhase.BeforeLoop:
				if (animInstance.Montage_GetCurrentSection(montage) == HurtCapability.SectionLoop)
				{
					return HurtCapability.EClimbDeathPhase.Falling;
				}
				return phase;
			case HurtCapability.EClimbDeathPhase.Falling:
			{
				if (groundZ == null)
				{
					return phase;
				}
				BP_WuWaGo_C setting = WuWaGoGlobal.Setting;
				int? num = (setting != null) ? new int?(setting.CharacterMoveSpeed) : null;
				float num2 = (float)((num > 0) ? num.Value : 200) * WuWaGoUtil.GetMontagePlayRate() * delta / 1000f;
				double num3 = value.Z - (double)num2;
				if (num3 <= (double)groundZ.Value)
				{
					HurtCapability.DeathSnapTempLocation.Set(value.X, value.Y, (double)groundZ.Value);
					this.Role.SetActorWorldLocation(HurtCapability.DeathSnapTempLocation, false);
					animInstance.Montage_JumpToSection(HurtCapability.SectionFall, montage);
					return HurtCapability.EClimbDeathPhase.Done;
				}
				HurtCapability.DeathSnapTempLocation.Set(value.X, value.Y, num3);
				this.Role.SetActorWorldLocation(HurtCapability.DeathSnapTempLocation, false);
				return phase;
			}
			}
			return phase;
		}

		// Token: 0x0603212A RID: 205098 RVA: 0x00C87948 File Offset: 0x00C85B48
		private float? SolveGroundZ()
		{
			FVectorDouble? worldLocation = this.Role.GetWorldLocation();
			if (worldLocation == null)
			{
				return null;
			}
			FVectorDouble value = worldLocation.Value;
			UWorld world = GlobalData.World;
			AActor aactor = this.Role.GetActorAsObject() as AActor;
			if (world == null || (aactor == null || !aactor.IsValid()))
			{
				return null;
			}
			UTraceLineElement traceTypeElement = ModelBase<TraceElementModel>.Instance.GetTraceTypeElement<UTraceLineElement>(UTraceLineElement.StaticClass(), KuroTraceTypeQuery.IkGround, world, false, true);
			traceTypeElement.ActorsToIgnore.Add(aactor);
			HurtCapability.DeathSnapTempLocation.Set(value.X, value.Y, value.Z + 50.0);
			Singleton<TraceElementCommon>.Instance.SetStartLocation(traceTypeElement, HurtCapability.DeathSnapTempLocation);
			HurtCapability.DeathSnapTempLocation.Set(value.X, value.Y, value.Z + -5000.0);
			Singleton<TraceElementCommon>.Instance.SetEndLocation(traceTypeElement, HurtCapability.DeathSnapTempLocation);
			if (!Singleton<TraceElementCommon>.Instance.LineTrace(traceTypeElement, "WuWaGo.ClimbDeath.Ground"))
			{
				return null;
			}
			UKuroHitResult hitResult = traceTypeElement.HitResult;
			if (hitResult == null)
			{
				return null;
			}
			int num = hitResult.Actors.Num();
			for (int i = 0; i < num; i++)
			{
				AActor aactor2 = hitResult.Actors.Get(i).Get();
				if (aactor2 != null && aactor2.IsValid() && aactor2 is BP_WuWaGo_LandBox_C)
				{
					return new float?(hitResult.ImpactPointZ_Array.Get(i) + this.Role.GetCapsuleHalfHeight());
				}
			}
			return null;
		}

		// Token: 0x0603212B RID: 205099 RVA: 0x00C87B00 File Offset: 0x00C85D00
		private bool ShouldWaitAnimBeforeExit()
		{
			return base.RoleType == EWuWaGoRoleType.AircraftSoldiers;
		}

		// Token: 0x0401D455 RID: 119893
		[StaticVariableRuleIgnore]
		private static readonly FName SectionLoop = new FName("Loop");

		// Token: 0x0401D456 RID: 119894
		[StaticVariableRuleIgnore]
		private static readonly FName SectionFall = new FName("End");

		// Token: 0x0401D457 RID: 119895
		private const int FALLBACK_FALL_SPEED = 200;

		// Token: 0x0401D458 RID: 119896
		private const int GROUND_TRACE_START_OFFSET = 50;

		// Token: 0x0401D459 RID: 119897
		private const int GROUND_TRACE_END_OFFSET = -5000;

		// Token: 0x0401D45A RID: 119898
		private const int SECTION_POLL_INTERVAL_MS = 20;

		// Token: 0x0401D45B RID: 119899
		private const int MS_PER_SECOND = 1000;

		// Token: 0x0401D45C RID: 119900
		[StaticVariableRuleIgnore]
		private static readonly Vector DeathSnapTempLocation = Vector.Create();

		// Token: 0x0200AB84 RID: 43908
		[NullableContext(0)]
		private enum EClimbDeathPhase
		{
			// Token: 0x040355D6 RID: 218582
			BeforeLoop,
			// Token: 0x040355D7 RID: 218583
			Falling,
			// Token: 0x040355D8 RID: 218584
			Done
		}
	}
}
