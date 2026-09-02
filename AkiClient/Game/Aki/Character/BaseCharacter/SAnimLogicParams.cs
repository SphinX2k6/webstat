using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004237 RID: 16951
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(180, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 180)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SAnimLogicParams.SAnimLogicParams")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 180)]
	public struct SAnimLogicParams : IEqualityOperators<SAnimLogicParams, SAnimLogicParams, bool>, IEquatable<SAnimLogicParams>, IUnrealScriptStruct
	{
		// Token: 0x0602CD4E RID: 183630 RVA: 0x00AB0DD8 File Offset: 0x00AAEFD8
		public SAnimLogicParams(bool AcceptedNewBeHit, TEnumAsByte<EHitAnim> BeHitAnim, bool EnterFk, bool DoubleHitInAir, FVector BeHitDirect, FVector BeHitLocation, TEnumAsByte<ECharState> CharMoveState, TEnumAsByte<ECharParentMoveState> CharPositionState, TEnumAsByte<ECharViewDirectionState> CharCameraState, float BattleIdleTime, float DegMovementSlope, FVector SightDirect, bool RagQuitState, bool IsJump, FVector Acceleration, bool IsMoving, float Speed, FVector InputDirect, bool IsFallingIntoWater, float GroundedTime, bool HasMoveInput, SClimbInfo ClimbInfo, SClimbState ClimbState, float ClimbRadius, FRotator InputRotator, float ClimbOnWallAngle, float SprintSwimOffset, float SprintSwimOffsetLerpSpeed, FVector SlideForward, bool SlideSwitchThisFrame, bool SlideStandMode, float JumpUpRate)
		{
			this.AcceptedNewBeHit = AcceptedNewBeHit;
			this.BeHitAnim = BeHitAnim;
			this.EnterFk = EnterFk;
			this.DoubleHitInAir = DoubleHitInAir;
			this.BeHitDirect = BeHitDirect;
			this.BeHitLocation = BeHitLocation;
			this.CharMoveState = CharMoveState;
			this.CharPositionState = CharPositionState;
			this.CharCameraState = CharCameraState;
			this.BattleIdleTime = BattleIdleTime;
			this.DegMovementSlope = DegMovementSlope;
			this.SightDirect = SightDirect;
			this.RagQuitState = RagQuitState;
			this.IsJump = IsJump;
			this.Acceleration = Acceleration;
			this.IsMoving = IsMoving;
			this.Speed = Speed;
			this.InputDirect = InputDirect;
			this.IsFallingIntoWater = IsFallingIntoWater;
			this.GroundedTime = GroundedTime;
			this.HasMoveInput = HasMoveInput;
			this.ClimbInfo = ClimbInfo;
			this.ClimbState = ClimbState;
			this.ClimbRadius = ClimbRadius;
			this.InputRotator = InputRotator;
			this.ClimbOnWallAngle = ClimbOnWallAngle;
			this.SprintSwimOffset = SprintSwimOffset;
			this.SprintSwimOffsetLerpSpeed = SprintSwimOffsetLerpSpeed;
			this.SlideForward = SlideForward;
			this.SlideSwitchThisFrame = SlideSwitchThisFrame;
			this.SlideStandMode = SlideStandMode;
			this.JumpUpRate = JumpUpRate;
		}

		// Token: 0x0602CD4F RID: 183631 RVA: 0x00AB0EE4 File Offset: 0x00AAF0E4
		public static bool operator ==(SAnimLogicParams left, SAnimLogicParams right)
		{
			return left.AcceptedNewBeHit == right.AcceptedNewBeHit && left.BeHitAnim == right.BeHitAnim && left.EnterFk == right.EnterFk && left.DoubleHitInAir == right.DoubleHitInAir && left.BeHitDirect == right.BeHitDirect && left.BeHitLocation == right.BeHitLocation && left.CharMoveState == right.CharMoveState && left.CharPositionState == right.CharPositionState && left.CharCameraState == right.CharCameraState && left.BattleIdleTime == right.BattleIdleTime && left.DegMovementSlope == right.DegMovementSlope && left.SightDirect == right.SightDirect && left.RagQuitState == right.RagQuitState && left.IsJump == right.IsJump && left.Acceleration == right.Acceleration && left.IsMoving == right.IsMoving && left.Speed == right.Speed && left.InputDirect == right.InputDirect && left.IsFallingIntoWater == right.IsFallingIntoWater && left.GroundedTime == right.GroundedTime && left.HasMoveInput == right.HasMoveInput && left.ClimbInfo == right.ClimbInfo && left.ClimbState == right.ClimbState && left.ClimbRadius == right.ClimbRadius && left.InputRotator == right.InputRotator && left.ClimbOnWallAngle == right.ClimbOnWallAngle && left.SprintSwimOffset == right.SprintSwimOffset && left.SprintSwimOffsetLerpSpeed == right.SprintSwimOffsetLerpSpeed && left.SlideForward == right.SlideForward && left.SlideSwitchThisFrame == right.SlideSwitchThisFrame && left.SlideStandMode == right.SlideStandMode && left.JumpUpRate == right.JumpUpRate;
		}

		// Token: 0x0602CD50 RID: 183632 RVA: 0x00AB1139 File Offset: 0x00AAF339
		public static bool operator !=(SAnimLogicParams left, SAnimLogicParams right)
		{
			return !(left == right);
		}

		// Token: 0x0602CD51 RID: 183633 RVA: 0x00AB1145 File Offset: 0x00AAF345
		public bool Equals(SAnimLogicParams other)
		{
			return this == other;
		}

		// Token: 0x0602CD52 RID: 183634 RVA: 0x00AB1154 File Offset: 0x00AAF354
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SAnimLogicParams)
			{
				SAnimLogicParams other = (SAnimLogicParams)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0602CD53 RID: 183635 RVA: 0x00AB117C File Offset: 0x00AAF37C
		public override int GetHashCode()
		{
			HashCode hashCode = default(HashCode);
			hashCode.Add<bool>(this.AcceptedNewBeHit);
			hashCode.Add<TEnumAsByte<EHitAnim>>(this.BeHitAnim);
			hashCode.Add<bool>(this.EnterFk);
			hashCode.Add<bool>(this.DoubleHitInAir);
			hashCode.Add<FVector>(this.BeHitDirect);
			hashCode.Add<FVector>(this.BeHitLocation);
			hashCode.Add<TEnumAsByte<ECharState>>(this.CharMoveState);
			hashCode.Add<TEnumAsByte<ECharParentMoveState>>(this.CharPositionState);
			hashCode.Add<TEnumAsByte<ECharViewDirectionState>>(this.CharCameraState);
			hashCode.Add<float>(this.BattleIdleTime);
			hashCode.Add<float>(this.DegMovementSlope);
			hashCode.Add<FVector>(this.SightDirect);
			hashCode.Add<bool>(this.RagQuitState);
			hashCode.Add<bool>(this.IsJump);
			hashCode.Add<FVector>(this.Acceleration);
			hashCode.Add<bool>(this.IsMoving);
			hashCode.Add<float>(this.Speed);
			hashCode.Add<FVector>(this.InputDirect);
			hashCode.Add<bool>(this.IsFallingIntoWater);
			hashCode.Add<float>(this.GroundedTime);
			hashCode.Add<bool>(this.HasMoveInput);
			hashCode.Add<SClimbInfo>(this.ClimbInfo);
			hashCode.Add<SClimbState>(this.ClimbState);
			hashCode.Add<float>(this.ClimbRadius);
			hashCode.Add<FRotator>(this.InputRotator);
			hashCode.Add<float>(this.ClimbOnWallAngle);
			hashCode.Add<float>(this.SprintSwimOffset);
			hashCode.Add<float>(this.SprintSwimOffsetLerpSpeed);
			hashCode.Add<FVector>(this.SlideForward);
			hashCode.Add<bool>(this.SlideSwitchThisFrame);
			hashCode.Add<bool>(this.SlideStandMode);
			hashCode.Add<float>(this.JumpUpRate);
			return hashCode.ToHashCode();
		}

		// Token: 0x0602CD54 RID: 183636 RVA: 0x00AB1338 File Offset: 0x00AAF538
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SAnimLogicParams._ScriptStructPtr != 0) ? SAnimLogicParams._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SAnimLogicParams.SAnimLogicParams", ref SAnimLogicParams._ScriptStructPtr);
		}

		// Token: 0x0401926A RID: 103018
		[FieldOffset(0)]
		public bool AcceptedNewBeHit;

		// Token: 0x0401926B RID: 103019
		[FieldOffset(1)]
		public TEnumAsByte<EHitAnim> BeHitAnim;

		// Token: 0x0401926C RID: 103020
		[FieldOffset(2)]
		public bool EnterFk;

		// Token: 0x0401926D RID: 103021
		[FieldOffset(3)]
		public bool DoubleHitInAir;

		// Token: 0x0401926E RID: 103022
		[FieldOffset(4)]
		public FVector BeHitDirect;

		// Token: 0x0401926F RID: 103023
		[FieldOffset(16)]
		public FVector BeHitLocation;

		// Token: 0x04019270 RID: 103024
		[FieldOffset(28)]
		public TEnumAsByte<ECharState> CharMoveState;

		// Token: 0x04019271 RID: 103025
		[FieldOffset(29)]
		public TEnumAsByte<ECharParentMoveState> CharPositionState;

		// Token: 0x04019272 RID: 103026
		[FieldOffset(30)]
		public TEnumAsByte<ECharViewDirectionState> CharCameraState;

		// Token: 0x04019273 RID: 103027
		[FieldOffset(32)]
		public float BattleIdleTime;

		// Token: 0x04019274 RID: 103028
		[FieldOffset(36)]
		public float DegMovementSlope;

		// Token: 0x04019275 RID: 103029
		[FieldOffset(40)]
		public FVector SightDirect;

		// Token: 0x04019276 RID: 103030
		[FieldOffset(52)]
		public bool RagQuitState;

		// Token: 0x04019277 RID: 103031
		[FieldOffset(53)]
		public bool IsJump;

		// Token: 0x04019278 RID: 103032
		[FieldOffset(56)]
		public FVector Acceleration;

		// Token: 0x04019279 RID: 103033
		[FieldOffset(68)]
		public bool IsMoving;

		// Token: 0x0401927A RID: 103034
		[FieldOffset(72)]
		public float Speed;

		// Token: 0x0401927B RID: 103035
		[FieldOffset(76)]
		public FVector InputDirect;

		// Token: 0x0401927C RID: 103036
		[FieldOffset(88)]
		public bool IsFallingIntoWater;

		// Token: 0x0401927D RID: 103037
		[FieldOffset(92)]
		public float GroundedTime;

		// Token: 0x0401927E RID: 103038
		[FieldOffset(96)]
		public bool HasMoveInput;

		// Token: 0x0401927F RID: 103039
		[FieldOffset(100)]
		public SClimbInfo ClimbInfo;

		// Token: 0x04019280 RID: 103040
		[FieldOffset(128)]
		public SClimbState ClimbState;

		// Token: 0x04019281 RID: 103041
		[FieldOffset(132)]
		public float ClimbRadius;

		// Token: 0x04019282 RID: 103042
		[FieldOffset(136)]
		public FRotator InputRotator;

		// Token: 0x04019283 RID: 103043
		[FieldOffset(148)]
		public float ClimbOnWallAngle;

		// Token: 0x04019284 RID: 103044
		[FieldOffset(152)]
		public float SprintSwimOffset;

		// Token: 0x04019285 RID: 103045
		[FieldOffset(156)]
		public float SprintSwimOffsetLerpSpeed;

		// Token: 0x04019286 RID: 103046
		[FieldOffset(160)]
		public FVector SlideForward;

		// Token: 0x04019287 RID: 103047
		[FieldOffset(172)]
		public bool SlideSwitchThisFrame;

		// Token: 0x04019288 RID: 103048
		[FieldOffset(173)]
		public bool SlideStandMode;

		// Token: 0x04019289 RID: 103049
		[FieldOffset(176)]
		public float JumpUpRate;

		// Token: 0x0401928A RID: 103050
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SAnimLogicParams.SAnimLogicParams";

		// Token: 0x0401928B RID: 103051
		private static IntPtr _ScriptStructPtr;
	}
}
