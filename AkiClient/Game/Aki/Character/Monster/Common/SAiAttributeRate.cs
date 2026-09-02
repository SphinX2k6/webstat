using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Protocol;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.Monster.Common
{
	// Token: 0x0200419D RID: 16797
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(20, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 20)]
	[UnrealObjectPath("/Game/Aki/Character/Monster/Common/SAiAttributeRate.SAiAttributeRate")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 20)]
	public struct SAiAttributeRate : IEqualityOperators<SAiAttributeRate, SAiAttributeRate, bool>, IEquatable<SAiAttributeRate>, IUnrealScriptStruct
	{
		// Token: 0x0602C94C RID: 182604 RVA: 0x00AA70C6 File Offset: 0x00AA52C6
		public SAiAttributeRate(TEnumAsByte<EAttributeType> Numerator, TEnumAsByte<EAttributeType> Denominator, FFloatRange Range)
		{
			this.Numerator = Numerator;
			this.Denominator = Denominator;
			this.Range = Range;
		}

		// Token: 0x0602C94D RID: 182605 RVA: 0x00AA70DD File Offset: 0x00AA52DD
		public static bool operator ==(SAiAttributeRate left, SAiAttributeRate right)
		{
			return left.Numerator == right.Numerator && left.Denominator == right.Denominator && left.Range == right.Range;
		}

		// Token: 0x0602C94E RID: 182606 RVA: 0x00AA7118 File Offset: 0x00AA5318
		public static bool operator !=(SAiAttributeRate left, SAiAttributeRate right)
		{
			return !(left == right);
		}

		// Token: 0x0602C94F RID: 182607 RVA: 0x00AA7124 File Offset: 0x00AA5324
		public bool Equals(SAiAttributeRate other)
		{
			return this == other;
		}

		// Token: 0x0602C950 RID: 182608 RVA: 0x00AA7134 File Offset: 0x00AA5334
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SAiAttributeRate)
			{
				SAiAttributeRate other = (SAiAttributeRate)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0602C951 RID: 182609 RVA: 0x00AA7159 File Offset: 0x00AA5359
		public override int GetHashCode()
		{
			return HashCode.Combine<TEnumAsByte<EAttributeType>, TEnumAsByte<EAttributeType>, FFloatRange>(this.Numerator, this.Denominator, this.Range);
		}

		// Token: 0x0602C952 RID: 182610 RVA: 0x00AA7172 File Offset: 0x00AA5372
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SAiAttributeRate._ScriptStructPtr != 0) ? SAiAttributeRate._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/Monster/Common/SAiAttributeRate.SAiAttributeRate", ref SAiAttributeRate._ScriptStructPtr);
		}

		// Token: 0x04018CDB RID: 101595
		[FieldOffset(0)]
		public TEnumAsByte<EAttributeType> Numerator;

		// Token: 0x04018CDC RID: 101596
		[FieldOffset(1)]
		public TEnumAsByte<EAttributeType> Denominator;

		// Token: 0x04018CDD RID: 101597
		[FieldOffset(4)]
		public FFloatRange Range;

		// Token: 0x04018CDE RID: 101598
		public const string __ObjectPath = "/Game/Aki/Character/Monster/Common/SAiAttributeRate.SAiAttributeRate";

		// Token: 0x04018CDF RID: 101599
		private static IntPtr _ScriptStructPtr;
	}
}
