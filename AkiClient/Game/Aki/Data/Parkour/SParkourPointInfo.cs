using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Parkour
{
	// Token: 0x02003E59 RID: 15961
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(24, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 24)]
	[UnrealObjectPath("/Game/Aki/Data/Parkour/SParkourPointInfo.SParkourPointInfo")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 24)]
	public struct SParkourPointInfo : IEqualityOperators<SParkourPointInfo, SParkourPointInfo, bool>, IEquatable<SParkourPointInfo>, IUnrealScriptStruct
	{
		// Token: 0x06027668 RID: 161384 RVA: 0x009F1068 File Offset: 0x009EF268
		public SParkourPointInfo(FVector Location, float Radius, float ModifiedTime, int BuffId)
		{
			this.Location = Location;
			this.Radius = Radius;
			this.ModifiedTime = ModifiedTime;
			this.BuffId = BuffId;
		}

		// Token: 0x06027669 RID: 161385 RVA: 0x009F1088 File Offset: 0x009EF288
		public static bool operator ==(SParkourPointInfo left, SParkourPointInfo right)
		{
			return left.Location == right.Location && left.Radius == right.Radius && left.ModifiedTime == right.ModifiedTime && left.BuffId == right.BuffId;
		}

		// Token: 0x0602766A RID: 161386 RVA: 0x009F10D4 File Offset: 0x009EF2D4
		public static bool operator !=(SParkourPointInfo left, SParkourPointInfo right)
		{
			return !(left == right);
		}

		// Token: 0x0602766B RID: 161387 RVA: 0x009F10E0 File Offset: 0x009EF2E0
		public bool Equals(SParkourPointInfo other)
		{
			return this == other;
		}

		// Token: 0x0602766C RID: 161388 RVA: 0x009F10F0 File Offset: 0x009EF2F0
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SParkourPointInfo)
			{
				SParkourPointInfo other = (SParkourPointInfo)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0602766D RID: 161389 RVA: 0x009F1115 File Offset: 0x009EF315
		public override int GetHashCode()
		{
			return HashCode.Combine<FVector, float, float, int>(this.Location, this.Radius, this.ModifiedTime, this.BuffId);
		}

		// Token: 0x0602766E RID: 161390 RVA: 0x009F1134 File Offset: 0x009EF334
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SParkourPointInfo._ScriptStructPtr != 0) ? SParkourPointInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Parkour/SParkourPointInfo.SParkourPointInfo", ref SParkourPointInfo._ScriptStructPtr);
		}

		// Token: 0x04014A11 RID: 84497
		[FieldOffset(0)]
		public FVector Location;

		// Token: 0x04014A12 RID: 84498
		[FieldOffset(12)]
		public float Radius;

		// Token: 0x04014A13 RID: 84499
		[FieldOffset(16)]
		public float ModifiedTime;

		// Token: 0x04014A14 RID: 84500
		[FieldOffset(20)]
		public int BuffId;

		// Token: 0x04014A15 RID: 84501
		public const string __ObjectPath = "/Game/Aki/Data/Parkour/SParkourPointInfo.SParkourPointInfo";

		// Token: 0x04014A16 RID: 84502
		private static IntPtr _ScriptStructPtr;
	}
}
