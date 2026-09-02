using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Gameplay.MotorRailMove.Struct
{
	// Token: 0x02003EB0 RID: 16048
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(16, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 16)]
	[UnrealObjectPath("/Game/Aki/Data/Gameplay/MotorRailMove/Struct/SMotorRailMove_ParabolaMove.SMotorRailMove_ParabolaMove")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 16)]
	public struct SMotorRailMove_ParabolaMove : IEqualityOperators<SMotorRailMove_ParabolaMove, SMotorRailMove_ParabolaMove, bool>, IEquatable<SMotorRailMove_ParabolaMove>, IUnrealScriptStruct
	{
		// Token: 0x06027D9E RID: 163230 RVA: 0x009FC1DC File Offset: 0x009FA3DC
		public SMotorRailMove_ParabolaMove(float GravityAccelerationAbs, float Duration, float MinSpeedAlongRail, float MaxSpeedAlongRail)
		{
			this.GravityAccelerationAbs = GravityAccelerationAbs;
			this.Duration = Duration;
			this.MinSpeedAlongRail = MinSpeedAlongRail;
			this.MaxSpeedAlongRail = MaxSpeedAlongRail;
		}

		// Token: 0x06027D9F RID: 163231 RVA: 0x009FC1FB File Offset: 0x009FA3FB
		public static bool operator ==(SMotorRailMove_ParabolaMove left, SMotorRailMove_ParabolaMove right)
		{
			return left.GravityAccelerationAbs == right.GravityAccelerationAbs && left.Duration == right.Duration && left.MinSpeedAlongRail == right.MinSpeedAlongRail && left.MaxSpeedAlongRail == right.MaxSpeedAlongRail;
		}

		// Token: 0x06027DA0 RID: 163232 RVA: 0x009FC237 File Offset: 0x009FA437
		public static bool operator !=(SMotorRailMove_ParabolaMove left, SMotorRailMove_ParabolaMove right)
		{
			return !(left == right);
		}

		// Token: 0x06027DA1 RID: 163233 RVA: 0x009FC243 File Offset: 0x009FA443
		public bool Equals(SMotorRailMove_ParabolaMove other)
		{
			return this == other;
		}

		// Token: 0x06027DA2 RID: 163234 RVA: 0x009FC254 File Offset: 0x009FA454
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SMotorRailMove_ParabolaMove)
			{
				SMotorRailMove_ParabolaMove other = (SMotorRailMove_ParabolaMove)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06027DA3 RID: 163235 RVA: 0x009FC279 File Offset: 0x009FA479
		public override int GetHashCode()
		{
			return HashCode.Combine<float, float, float, float>(this.GravityAccelerationAbs, this.Duration, this.MinSpeedAlongRail, this.MaxSpeedAlongRail);
		}

		// Token: 0x06027DA4 RID: 163236 RVA: 0x009FC298 File Offset: 0x009FA498
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMotorRailMove_ParabolaMove._ScriptStructPtr != 0) ? SMotorRailMove_ParabolaMove._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Gameplay/MotorRailMove/Struct/SMotorRailMove_ParabolaMove.SMotorRailMove_ParabolaMove", ref SMotorRailMove_ParabolaMove._ScriptStructPtr);
		}

		// Token: 0x04014E92 RID: 85650
		[FieldOffset(0)]
		public float GravityAccelerationAbs;

		// Token: 0x04014E93 RID: 85651
		[FieldOffset(4)]
		public float Duration;

		// Token: 0x04014E94 RID: 85652
		[FieldOffset(8)]
		public float MinSpeedAlongRail;

		// Token: 0x04014E95 RID: 85653
		[FieldOffset(12)]
		public float MaxSpeedAlongRail;

		// Token: 0x04014E96 RID: 85654
		public const string __ObjectPath = "/Game/Aki/Data/Gameplay/MotorRailMove/Struct/SMotorRailMove_ParabolaMove.SMotorRailMove_ParabolaMove";

		// Token: 0x04014E97 RID: 85655
		private static IntPtr _ScriptStructPtr;
	}
}
