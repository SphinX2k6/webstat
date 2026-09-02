using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Gameplay.WuWaGo;
using CSharpScript.Game.Module.WuwaGo.Model;
using CSharpScript.Game.Module.WuwaGo.Model.Role;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WuwaGo.Controller.Role.Capability
{
	// Token: 0x02004B02 RID: 19202
	[NullableContext(1)]
	[Nullable(0)]
	public class MoveCapability : CapabilityBase
	{
		// Token: 0x0603212D RID: 205101 RVA: 0x00C87B35 File Offset: 0x00C85D35
		public MoveCapability(WuWaGoRole role) : base(role)
		{
		}

		// Token: 0x0603212E RID: 205102 RVA: 0x00C87B40 File Offset: 0x00C85D40
		[NullableContext(2)]
		public UniTask MoveToGrid(WuWaGoGrid grid)
		{
			MoveCapability.<MoveToGrid>d__9 <MoveToGrid>d__;
			<MoveToGrid>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<MoveToGrid>d__.<>4__this = this;
			<MoveToGrid>d__.grid = grid;
			<MoveToGrid>d__.<>1__state = -1;
			<MoveToGrid>d__.<>t__builder.Start<MoveCapability.<MoveToGrid>d__9>(ref <MoveToGrid>d__);
			return <MoveToGrid>d__.<>t__builder.Task;
		}

		// Token: 0x0603212F RID: 205103 RVA: 0x00C87B8C File Offset: 0x00C85D8C
		public UniTask MoveToWorldPosition(Vector targetWorldPosition)
		{
			MoveCapability.<MoveToWorldPosition>d__10 <MoveToWorldPosition>d__;
			<MoveToWorldPosition>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<MoveToWorldPosition>d__.<>4__this = this;
			<MoveToWorldPosition>d__.targetWorldPosition = targetWorldPosition;
			<MoveToWorldPosition>d__.<>1__state = -1;
			<MoveToWorldPosition>d__.<>t__builder.Start<MoveCapability.<MoveToWorldPosition>d__10>(ref <MoveToWorldPosition>d__);
			return <MoveToWorldPosition>d__.<>t__builder.Task;
		}

		// Token: 0x06032130 RID: 205104 RVA: 0x00C87BD8 File Offset: 0x00C85DD8
		public UniTask MoveActorVisuallyTowardsAsync(Vector targetWorldPosition, float maxStepDistance)
		{
			MoveCapability.<MoveActorVisuallyTowardsAsync>d__11 <MoveActorVisuallyTowardsAsync>d__;
			<MoveActorVisuallyTowardsAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<MoveActorVisuallyTowardsAsync>d__.<>4__this = this;
			<MoveActorVisuallyTowardsAsync>d__.targetWorldPosition = targetWorldPosition;
			<MoveActorVisuallyTowardsAsync>d__.maxStepDistance = maxStepDistance;
			<MoveActorVisuallyTowardsAsync>d__.<>1__state = -1;
			<MoveActorVisuallyTowardsAsync>d__.<>t__builder.Start<MoveCapability.<MoveActorVisuallyTowardsAsync>d__11>(ref <MoveActorVisuallyTowardsAsync>d__);
			return <MoveActorVisuallyTowardsAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032131 RID: 205105 RVA: 0x00C87C2C File Offset: 0x00C85E2C
		[NullableContext(2)]
		public void FaceTowardsGrid(WuWaGoGrid grid)
		{
			if (!this.Role.IsActorValid() || grid == null)
			{
				return;
			}
			Vector worldPositionByCoordinate = WuWaGoUtil.GetWorldPositionByCoordinate(ModelBase<WuWaGoModel>.Instance.GameData.OriginTransform, grid.Coordinate, null);
			this.FaceActorTowardsWorldPosition(worldPositionByCoordinate);
		}

		// Token: 0x06032132 RID: 205106 RVA: 0x00C87C70 File Offset: 0x00C85E70
		[NullableContext(0)]
		private UniTask<bool> MoveActorToWorldPosition([Nullable(1)] Vector targetWorldPosition)
		{
			MoveCapability.<MoveActorToWorldPosition>d__13 <MoveActorToWorldPosition>d__;
			<MoveActorToWorldPosition>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<MoveActorToWorldPosition>d__.<>4__this = this;
			<MoveActorToWorldPosition>d__.targetWorldPosition = targetWorldPosition;
			<MoveActorToWorldPosition>d__.<>1__state = -1;
			<MoveActorToWorldPosition>d__.<>t__builder.Start<MoveCapability.<MoveActorToWorldPosition>d__13>(ref <MoveActorToWorldPosition>d__);
			return <MoveActorToWorldPosition>d__.<>t__builder.Task;
		}

		// Token: 0x06032133 RID: 205107 RVA: 0x00C87CBC File Offset: 0x00C85EBC
		private void FaceActorTowardsWorldPosition(Vector targetWorldPosition)
		{
			if (!this.Role.IsActorValid())
			{
				return;
			}
			Transform originTransform = ModelBase<WuWaGoModel>.Instance.GameData.OriginTransform;
			WuWaGoUtil.ComputeFaceTowardsRotations(this.Role, targetWorldPosition, originTransform, MoveCapability.WorldRotationTemp, MoveCapability.LocalRotationTemp);
			this.Role.SetActorWorldRotation(MoveCapability.WorldRotationTemp);
			this.Role.SetRotator(MoveCapability.LocalRotationTemp);
		}

		// Token: 0x06032134 RID: 205108 RVA: 0x00C87D1E File Offset: 0x00C85F1E
		private static bool HasKuroAnimInstance(WuWaGoRole role)
		{
			UKuroAnimInstanceChar animInstance = role.GetAnimInstance();
			return ((animInstance != null) ? animInstance.LogicParams : null) != null;
		}

		// Token: 0x06032135 RID: 205109 RVA: 0x00C87D38 File Offset: 0x00C85F38
		[NullableContext(0)]
		private UniTask<bool> PerformMoveAnim([Nullable(1)] Vector targetLocation)
		{
			MoveCapability.<PerformMoveAnim>d__16 <PerformMoveAnim>d__;
			<PerformMoveAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<PerformMoveAnim>d__.<>4__this = this;
			<PerformMoveAnim>d__.targetLocation = targetLocation;
			<PerformMoveAnim>d__.<>1__state = -1;
			<PerformMoveAnim>d__.<>t__builder.Start<MoveCapability.<PerformMoveAnim>d__16>(ref <PerformMoveAnim>d__);
			return <PerformMoveAnim>d__.<>t__builder.Task;
		}

		// Token: 0x06032136 RID: 205110 RVA: 0x00C87D84 File Offset: 0x00C85F84
		[NullableContext(2)]
		private float GetCharacterMoveSpeed(UCharacterMovementComponent charMove)
		{
			BP_WuWaGo_C setting = WuWaGoGlobal.Setting;
			int? num = (setting != null) ? new int?(setting.CharacterMoveSpeed) : null;
			if (num != null && num.GetValueOrDefault() > 0)
			{
				return (float)num.Value;
			}
			float? num2 = (charMove != null) ? new float?(charMove.MaxWalkSpeed) : null;
			if (num2 != null && num2.GetValueOrDefault() > 0f)
			{
				return charMove.MaxWalkSpeed;
			}
			return 200f;
		}

		// Token: 0x0401D45D RID: 119901
		private const int ARRIVE_TOLERANCE = 5;

		// Token: 0x0401D45E RID: 119902
		private const int FALLBACK_WALK_SPEED = 200;

		// Token: 0x0401D45F RID: 119903
		private const int TICK_INTERVAL_MS = 20;

		// Token: 0x0401D460 RID: 119904
		private const int SETTLE_DURATION_MS = 60;

		// Token: 0x0401D461 RID: 119905
		private const float SAFE_TIMEOUT_RATIO = 1.5f;

		// Token: 0x0401D462 RID: 119906
		private const string MAIN_CONTROL_MOVE_AUDIO_KEY = "play_interact_waves_go_move";

		// Token: 0x0401D463 RID: 119907
		[StaticVariableRuleIgnore]
		private static readonly Rotator WorldRotationTemp = Rotator.Create();

		// Token: 0x0401D464 RID: 119908
		[StaticVariableRuleIgnore]
		private static readonly Rotator LocalRotationTemp = Rotator.Create();
	}
}
