using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Module.WuwaGo.Controller.GameMode;
using CSharpScript.Game.Module.WuwaGo.Model;
using CSharpScript.Game.Module.WuwaGo.Model.Role;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WuwaGo.Controller.Role
{
	// Token: 0x02004AF9 RID: 19193
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public abstract class WuWaGoMonsterControllerBase<[Nullable(0)] TRole> : WuWaGoRoleController<TRole>, IWuWaGoMonsterController where TRole : WuWaGoRole
	{
		// Token: 0x060320CF RID: 205007 RVA: 0x00C864E7 File Offset: 0x00C846E7
		protected WuWaGoMonsterControllerBase(TRole role, WuWaGoGameData gameData, WuWaGoGameModeBase gameMode) : base(role, gameData, gameMode)
		{
		}

		// Token: 0x060320D0 RID: 205008 RVA: 0x00C864FD File Offset: 0x00C846FD
		protected override bool OnCreate()
		{
			if (!base.OnCreate())
			{
				return false;
			}
			this.SpawnAttackRangeEffect();
			this.HideAttackRangeForBusy("WuWaGo.AttackRange.Intro");
			return true;
		}

		// Token: 0x060320D1 RID: 205009 RVA: 0x00C8651C File Offset: 0x00C8471C
		public override void OnEnterRunning()
		{
			this.RestoreAttackRangeFromBusy("WuWaGo.AttackRange.Running");
		}

		// Token: 0x060320D2 RID: 205010 RVA: 0x00C8652C File Offset: 0x00C8472C
		protected override void OnDestroy()
		{
			base.OnDestroy();
			this.AttackRangeEffectRequestSeq++;
			if (Singleton<EffectSystem>.Instance.IsValid(this.AttackRangeEffectHandle))
			{
				Singleton<EffectSystem>.Instance.StopEffectById(this.AttackRangeEffectHandle, "WuWaGo.AttackRange.Clear", true, null);
			}
			this.AttackRangeEffectHandle = 0;
		}

		// Token: 0x060320D3 RID: 205011 RVA: 0x00C86586 File Offset: 0x00C84786
		protected override void OnBeforeExecuteAction()
		{
			this.HideAttackRangeForBusy("WuWaGo.AttackRange.Acting");
		}

		// Token: 0x060320D4 RID: 205012 RVA: 0x00C86593 File Offset: 0x00C84793
		protected override void OnAfterExecuteAction()
		{
			this.RestoreAttackRangeFromBusy("WuWaGo.AttackRange.Idle");
		}

		// Token: 0x060320D5 RID: 205013 RVA: 0x00C865A0 File Offset: 0x00C847A0
		public override void OnRollbackRestore()
		{
			base.OnRollbackRestore();
			this.SyncAttackRangeEffectTransform();
			if (this.Role.IsDead)
			{
				this.HideAttackRangeForBusy("WuWaGo.AttackRange.RollbackRestoreDead");
				return;
			}
			this.RestoreAttackRangeFromBusy("WuWaGo.AttackRange.RollbackRestore");
		}

		// Token: 0x060320D6 RID: 205014 RVA: 0x00C865D7 File Offset: 0x00C847D7
		public override void SyncRuntimePresentationAfterCoordinateChanged()
		{
			if (!Singleton<EffectSystem>.Instance.IsValid(this.AttackRangeEffectHandle))
			{
				return;
			}
			this.SyncAttackRangeEffectTransform();
		}

		// Token: 0x060320D7 RID: 205015 RVA: 0x00C865F2 File Offset: 0x00C847F2
		public override void HideAttackRangeEffect(string reason)
		{
			this.HideAttackRangeForBusy(reason);
		}

		// Token: 0x060320D8 RID: 205016 RVA: 0x00C865FB File Offset: 0x00C847FB
		public override void ShowAttackRangeEffect(string reason)
		{
			this.RestoreAttackRangeFromBusy(reason);
		}

		// Token: 0x060320D9 RID: 205017 RVA: 0x00C86604 File Offset: 0x00C84804
		[NullableContext(2)]
		public override UniTask TakeAttack(bool playBeHitAnim, UAnimMontage deathMontage = null)
		{
			WuWaGoMonsterControllerBase<TRole>.<TakeAttack>d__14 <TakeAttack>d__;
			<TakeAttack>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TakeAttack>d__.<>4__this = this;
			<TakeAttack>d__.playBeHitAnim = playBeHitAnim;
			<TakeAttack>d__.deathMontage = deathMontage;
			<TakeAttack>d__.<>1__state = -1;
			<TakeAttack>d__.<>t__builder.Start<WuWaGoMonsterControllerBase<TRole>.<TakeAttack>d__14>(ref <TakeAttack>d__);
			return <TakeAttack>d__.<>t__builder.Task;
		}

		// Token: 0x060320DA RID: 205018 RVA: 0x00C86658 File Offset: 0x00C84858
		public UniTask ExecutePostMovableFloorAttackJudgement()
		{
			WuWaGoMonsterControllerBase<TRole>.<ExecutePostMovableFloorAttackJudgement>d__15 <ExecutePostMovableFloorAttackJudgement>d__;
			<ExecutePostMovableFloorAttackJudgement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecutePostMovableFloorAttackJudgement>d__.<>4__this = this;
			<ExecutePostMovableFloorAttackJudgement>d__.<>1__state = -1;
			<ExecutePostMovableFloorAttackJudgement>d__.<>t__builder.Start<WuWaGoMonsterControllerBase<TRole>.<ExecutePostMovableFloorAttackJudgement>d__15>(ref <ExecutePostMovableFloorAttackJudgement>d__);
			return <ExecutePostMovableFloorAttackJudgement>d__.<>t__builder.Task;
		}

		// Token: 0x060320DB RID: 205019 RVA: 0x00C8669B File Offset: 0x00C8489B
		private void HideAttackRangeForBusy(string reason)
		{
			if (this.IsAttackRangeHidden)
			{
				return;
			}
			this.IsAttackRangeHidden = true;
			if (!Singleton<EffectSystem>.Instance.IsValid(this.AttackRangeEffectHandle))
			{
				return;
			}
			Singleton<EffectSystem>.Instance.SetEffectHidden(this.AttackRangeEffectHandle, true, reason, false);
		}

		// Token: 0x060320DC RID: 205020 RVA: 0x00C866D4 File Offset: 0x00C848D4
		private void RestoreAttackRangeFromBusy(string reason)
		{
			if (!this.IsAttackRangeHidden)
			{
				return;
			}
			if (this.Role.IsDead)
			{
				return;
			}
			this.IsAttackRangeHidden = false;
			if (!Singleton<EffectSystem>.Instance.IsValid(this.AttackRangeEffectHandle))
			{
				return;
			}
			this.SyncAttackRangeEffectTransform();
			Singleton<EffectSystem>.Instance.SetEffectHidden(this.AttackRangeEffectHandle, false, reason, false);
		}

		// Token: 0x060320DD RID: 205021 RVA: 0x00C86730 File Offset: 0x00C84930
		private Rotator GetAttackRangeEffectRotator()
		{
			Rotator rotator = this.Role.Rotator;
			this.TempAttackRangeRotator.Set(rotator.Pitch, rotator.Yaw + 180f, rotator.Roll);
			return this.TempAttackRangeRotator;
		}

		// Token: 0x060320DE RID: 205022 RVA: 0x00C86778 File Offset: 0x00C84978
		private UniTask SpawnAttackRangeEffect()
		{
			WuWaGoMonsterControllerBase<TRole>.<SpawnAttackRangeEffect>d__19 <SpawnAttackRangeEffect>d__;
			<SpawnAttackRangeEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SpawnAttackRangeEffect>d__.<>4__this = this;
			<SpawnAttackRangeEffect>d__.<>1__state = -1;
			<SpawnAttackRangeEffect>d__.<>t__builder.Start<WuWaGoMonsterControllerBase<TRole>.<SpawnAttackRangeEffect>d__19>(ref <SpawnAttackRangeEffect>d__);
			return <SpawnAttackRangeEffect>d__.<>t__builder.Task;
		}

		// Token: 0x060320DF RID: 205023 RVA: 0x00C867BC File Offset: 0x00C849BC
		private void SyncAttackRangeEffectTransform()
		{
			AActor sureEffectActor = Singleton<EffectSystem>.Instance.GetSureEffectActor(this.AttackRangeEffectHandle);
			if (sureEffectActor == null || !sureEffectActor.IsValid())
			{
				return;
			}
			Transform originTransform = ModelBase<WuWaGoModel>.Instance.GameData.OriginTransform;
			if (originTransform == null)
			{
				return;
			}
			Vector worldPositionByCoordinate = WuWaGoUtil.GetWorldPositionByCoordinate(originTransform, this.Role.Coordinate, null);
			Quat quat = Quat.Create(0f, 0f, 0f, 1f);
			originTransform.GetRotation().Multiply(this.GetAttackRangeEffectRotator().Quaternion(null), quat);
			sureEffectActor.D_K2_SetActorLocationAndRotation(worldPositionByCoordinate.ToUeVector(false), quat.Rotator(null).ToUeRotator(), false, ref WorldGlobal.SweepHitResult, false);
		}

		// Token: 0x0401D43E RID: 119870
		private int AttackRangeEffectHandle;

		// Token: 0x0401D43F RID: 119871
		private int AttackRangeEffectRequestSeq;

		// Token: 0x0401D440 RID: 119872
		private readonly Rotator TempAttackRangeRotator = Rotator.Create();

		// Token: 0x0401D441 RID: 119873
		private bool IsAttackRangeHidden;
	}
}
