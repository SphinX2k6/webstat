using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Gameplay.MotorRailMove.Struct
{
	// Token: 0x02003EAD RID: 16045
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(20, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 20)]
	[UnrealObjectPath("/Game/Aki/Data/Gameplay/MotorRailMove/Struct/SMotorRailMove_EnterRailCondition.SMotorRailMove_EnterRailCondition")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 20)]
	public struct SMotorRailMove_EnterRailCondition : IEqualityOperators<SMotorRailMove_EnterRailCondition, SMotorRailMove_EnterRailCondition, bool>, IEquatable<SMotorRailMove_EnterRailCondition>, IUnrealScriptStruct
	{
		// Token: 0x06027D86 RID: 163206 RVA: 0x009FBF6C File Offset: 0x009FA16C
		public SMotorRailMove_EnterRailCondition(float MaxAngleBetweenForwardAndRailTangent, float MaxAngleBetweenUpAndRailUp, float MaxAngleBetweenVelocityAndRailTangent, float MinRailLenLeftAfterEnterRail, float MaxAngleBetweenTargetUpAndDirPlaneProjectionOfTargetToCurrent)
		{
			this.MaxAngleBetweenForwardAndRailTangent = MaxAngleBetweenForwardAndRailTangent;
			this.MaxAngleBetweenUpAndRailUp = MaxAngleBetweenUpAndRailUp;
			this.MaxAngleBetweenVelocityAndRailTangent = MaxAngleBetweenVelocityAndRailTangent;
			this.MinRailLenLeftAfterEnterRail = MinRailLenLeftAfterEnterRail;
			this.MaxAngleBetweenTargetUpAndDirPlaneProjectionOfTargetToCurrent = MaxAngleBetweenTargetUpAndDirPlaneProjectionOfTargetToCurrent;
		}

		// Token: 0x06027D87 RID: 163207 RVA: 0x009FBF94 File Offset: 0x009FA194
		public static bool operator ==(SMotorRailMove_EnterRailCondition left, SMotorRailMove_EnterRailCondition right)
		{
			return left.MaxAngleBetweenForwardAndRailTangent == right.MaxAngleBetweenForwardAndRailTangent && left.MaxAngleBetweenUpAndRailUp == right.MaxAngleBetweenUpAndRailUp && left.MaxAngleBetweenVelocityAndRailTangent == right.MaxAngleBetweenVelocityAndRailTangent && left.MinRailLenLeftAfterEnterRail == right.MinRailLenLeftAfterEnterRail && left.MaxAngleBetweenTargetUpAndDirPlaneProjectionOfTargetToCurrent == right.MaxAngleBetweenTargetUpAndDirPlaneProjectionOfTargetToCurrent;
		}

		// Token: 0x06027D88 RID: 163208 RVA: 0x009FBFE9 File Offset: 0x009FA1E9
		public static bool operator !=(SMotorRailMove_EnterRailCondition left, SMotorRailMove_EnterRailCondition right)
		{
			return !(left == right);
		}

		// Token: 0x06027D89 RID: 163209 RVA: 0x009FBFF5 File Offset: 0x009FA1F5
		public bool Equals(SMotorRailMove_EnterRailCondition other)
		{
			return this == other;
		}

		// Token: 0x06027D8A RID: 163210 RVA: 0x009FC004 File Offset: 0x009FA204
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SMotorRailMove_EnterRailCondition)
			{
				SMotorRailMove_EnterRailCondition other = (SMotorRailMove_EnterRailCondition)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06027D8B RID: 163211 RVA: 0x009FC029 File Offset: 0x009FA229
		public override int GetHashCode()
		{
			return HashCode.Combine<float, float, float, float, float>(this.MaxAngleBetweenForwardAndRailTangent, this.MaxAngleBetweenUpAndRailUp, this.MaxAngleBetweenVelocityAndRailTangent, this.MinRailLenLeftAfterEnterRail, this.MaxAngleBetweenTargetUpAndDirPlaneProjectionOfTargetToCurrent);
		}

		// Token: 0x06027D8C RID: 163212 RVA: 0x009FC04E File Offset: 0x009FA24E
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMotorRailMove_EnterRailCondition._ScriptStructPtr != 0) ? SMotorRailMove_EnterRailCondition._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Gameplay/MotorRailMove/Struct/SMotorRailMove_EnterRailCondition.SMotorRailMove_EnterRailCondition", ref SMotorRailMove_EnterRailCondition._ScriptStructPtr);
		}

		// Token: 0x04014E83 RID: 85635
		[FieldOffset(0)]
		public float MaxAngleBetweenForwardAndRailTangent;

		// Token: 0x04014E84 RID: 85636
		[FieldOffset(4)]
		public float MaxAngleBetweenUpAndRailUp;

		// Token: 0x04014E85 RID: 85637
		[FieldOffset(8)]
		public float MaxAngleBetweenVelocityAndRailTangent;

		// Token: 0x04014E86 RID: 85638
		[FieldOffset(12)]
		public float MinRailLenLeftAfterEnterRail;

		// Token: 0x04014E87 RID: 85639
		[FieldOffset(16)]
		public float MaxAngleBetweenTargetUpAndDirPlaneProjectionOfTargetToCurrent;

		// Token: 0x04014E88 RID: 85640
		public const string __ObjectPath = "/Game/Aki/Data/Gameplay/MotorRailMove/Struct/SMotorRailMove_EnterRailCondition.SMotorRailMove_EnterRailCondition";

		// Token: 0x04014E89 RID: 85641
		private static IntPtr _ScriptStructPtr;
	}
}
