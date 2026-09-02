using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Manipulate
{
	// Token: 0x02003E66 RID: 15974
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(40, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 37)]
	[UnrealObjectPath("/Game/Aki/Data/Manipulate/SManipulatePointInfo.SManipulatePointInfo")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 40)]
	public struct SManipulatePointInfo : IEqualityOperators<SManipulatePointInfo, SManipulatePointInfo, bool>, IEquatable<SManipulatePointInfo>, IUnrealScriptStruct
	{
		// Token: 0x060276F6 RID: 161526 RVA: 0x009F1C57 File Offset: 0x009EFE57
		public SManipulatePointInfo(FVector Location, FVector ArriveTangent, FVector LeaveTangent, TEnumAsByte<ESplinePointType> PointType)
		{
			this.Location = Location;
			this.ArriveTangent = ArriveTangent;
			this.LeaveTangent = LeaveTangent;
			this.PointType = PointType;
		}

		// Token: 0x060276F7 RID: 161527 RVA: 0x009F1C78 File Offset: 0x009EFE78
		public static bool operator ==(SManipulatePointInfo left, SManipulatePointInfo right)
		{
			return left.Location == right.Location && left.ArriveTangent == right.ArriveTangent && left.LeaveTangent == right.LeaveTangent && left.PointType == right.PointType;
		}

		// Token: 0x060276F8 RID: 161528 RVA: 0x009F1CD1 File Offset: 0x009EFED1
		public static bool operator !=(SManipulatePointInfo left, SManipulatePointInfo right)
		{
			return !(left == right);
		}

		// Token: 0x060276F9 RID: 161529 RVA: 0x009F1CDD File Offset: 0x009EFEDD
		public bool Equals(SManipulatePointInfo other)
		{
			return this == other;
		}

		// Token: 0x060276FA RID: 161530 RVA: 0x009F1CEC File Offset: 0x009EFEEC
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SManipulatePointInfo)
			{
				SManipulatePointInfo other = (SManipulatePointInfo)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x060276FB RID: 161531 RVA: 0x009F1D11 File Offset: 0x009EFF11
		public override int GetHashCode()
		{
			return HashCode.Combine<FVector, FVector, FVector, TEnumAsByte<ESplinePointType>>(this.Location, this.ArriveTangent, this.LeaveTangent, this.PointType);
		}

		// Token: 0x060276FC RID: 161532 RVA: 0x009F1D30 File Offset: 0x009EFF30
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SManipulatePointInfo._ScriptStructPtr != 0) ? SManipulatePointInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Manipulate/SManipulatePointInfo.SManipulatePointInfo", ref SManipulatePointInfo._ScriptStructPtr);
		}

		// Token: 0x04014A72 RID: 84594
		[FieldOffset(0)]
		public FVector Location;

		// Token: 0x04014A73 RID: 84595
		[FieldOffset(12)]
		public FVector ArriveTangent;

		// Token: 0x04014A74 RID: 84596
		[FieldOffset(24)]
		public FVector LeaveTangent;

		// Token: 0x04014A75 RID: 84597
		[FieldOffset(36)]
		public TEnumAsByte<ESplinePointType> PointType;

		// Token: 0x04014A76 RID: 84598
		public const string __ObjectPath = "/Game/Aki/Data/Manipulate/SManipulatePointInfo.SManipulatePointInfo";

		// Token: 0x04014A77 RID: 84599
		private static IntPtr _ScriptStructPtr;
	}
}
