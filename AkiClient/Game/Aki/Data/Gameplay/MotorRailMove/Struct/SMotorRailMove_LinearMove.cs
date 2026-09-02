using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Gameplay.MotorRailMove.Struct
{
	// Token: 0x02003EAF RID: 16047
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(8, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 8)]
	[UnrealObjectPath("/Game/Aki/Data/Gameplay/MotorRailMove/Struct/SMotorRailMove_LinearMove.SMotorRailMove_LinearMove")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 8)]
	public struct SMotorRailMove_LinearMove : IEqualityOperators<SMotorRailMove_LinearMove, SMotorRailMove_LinearMove, bool>, IEquatable<SMotorRailMove_LinearMove>, IUnrealScriptStruct
	{
		// Token: 0x06027D97 RID: 163223 RVA: 0x009FC134 File Offset: 0x009FA334
		public SMotorRailMove_LinearMove(float MinSpeed, float MaxSpeed)
		{
			this.MinSpeed = MinSpeed;
			this.MaxSpeed = MaxSpeed;
		}

		// Token: 0x06027D98 RID: 163224 RVA: 0x009FC144 File Offset: 0x009FA344
		public static bool operator ==(SMotorRailMove_LinearMove left, SMotorRailMove_LinearMove right)
		{
			return left.MinSpeed == right.MinSpeed && left.MaxSpeed == right.MaxSpeed;
		}

		// Token: 0x06027D99 RID: 163225 RVA: 0x009FC164 File Offset: 0x009FA364
		public static bool operator !=(SMotorRailMove_LinearMove left, SMotorRailMove_LinearMove right)
		{
			return !(left == right);
		}

		// Token: 0x06027D9A RID: 163226 RVA: 0x009FC170 File Offset: 0x009FA370
		public bool Equals(SMotorRailMove_LinearMove other)
		{
			return this == other;
		}

		// Token: 0x06027D9B RID: 163227 RVA: 0x009FC180 File Offset: 0x009FA380
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SMotorRailMove_LinearMove)
			{
				SMotorRailMove_LinearMove other = (SMotorRailMove_LinearMove)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06027D9C RID: 163228 RVA: 0x009FC1A5 File Offset: 0x009FA3A5
		public override int GetHashCode()
		{
			return HashCode.Combine<float, float>(this.MinSpeed, this.MaxSpeed);
		}

		// Token: 0x06027D9D RID: 163229 RVA: 0x009FC1B8 File Offset: 0x009FA3B8
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMotorRailMove_LinearMove._ScriptStructPtr != 0) ? SMotorRailMove_LinearMove._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Gameplay/MotorRailMove/Struct/SMotorRailMove_LinearMove.SMotorRailMove_LinearMove", ref SMotorRailMove_LinearMove._ScriptStructPtr);
		}

		// Token: 0x04014E8E RID: 85646
		[FieldOffset(0)]
		public float MinSpeed;

		// Token: 0x04014E8F RID: 85647
		[FieldOffset(4)]
		public float MaxSpeed;

		// Token: 0x04014E90 RID: 85648
		public const string __ObjectPath = "/Game/Aki/Data/Gameplay/MotorRailMove/Struct/SMotorRailMove_LinearMove.SMotorRailMove_LinearMove";

		// Token: 0x04014E91 RID: 85649
		private static IntPtr _ScriptStructPtr;
	}
}
