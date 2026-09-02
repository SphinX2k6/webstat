using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.LevelGamePlay.StrikeResponse.Stuct
{
	// Token: 0x02003E83 RID: 16003
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(12, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 10)]
	[UnrealObjectPath("/Game/Aki/Data/LevelGamePlay/StrikeResponse/Stuct/SStrikeInfo.SStrikeInfo")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 12)]
	public struct SStrikeInfo : IEqualityOperators<SStrikeInfo, SStrikeInfo, bool>, IEquatable<SStrikeInfo>, IUnrealScriptStruct
	{
		// Token: 0x06027A3E RID: 162366 RVA: 0x009F6D2F File Offset: 0x009F4F2F
		public SStrikeInfo(TEnumAsByte<ECamp> Striker, float SrikeDirection, TEnumAsByte<SrikeElement> Element, TEnumAsByte<StrikeType> SrikeType)
		{
			this.Striker = Striker;
			this.SrikeDirection = SrikeDirection;
			this.Element = Element;
			this.SrikeType = SrikeType;
		}

		// Token: 0x06027A3F RID: 162367 RVA: 0x009F6D50 File Offset: 0x009F4F50
		public static bool operator ==(SStrikeInfo left, SStrikeInfo right)
		{
			return left.Striker == right.Striker && left.SrikeDirection == right.SrikeDirection && left.Element == right.Element && left.SrikeType == right.SrikeType;
		}

		// Token: 0x06027A40 RID: 162368 RVA: 0x009F6DA4 File Offset: 0x009F4FA4
		public static bool operator !=(SStrikeInfo left, SStrikeInfo right)
		{
			return !(left == right);
		}

		// Token: 0x06027A41 RID: 162369 RVA: 0x009F6DB0 File Offset: 0x009F4FB0
		public bool Equals(SStrikeInfo other)
		{
			return this == other;
		}

		// Token: 0x06027A42 RID: 162370 RVA: 0x009F6DC0 File Offset: 0x009F4FC0
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SStrikeInfo)
			{
				SStrikeInfo other = (SStrikeInfo)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06027A43 RID: 162371 RVA: 0x009F6DE5 File Offset: 0x009F4FE5
		public override int GetHashCode()
		{
			return HashCode.Combine<TEnumAsByte<ECamp>, float, TEnumAsByte<SrikeElement>, TEnumAsByte<StrikeType>>(this.Striker, this.SrikeDirection, this.Element, this.SrikeType);
		}

		// Token: 0x06027A44 RID: 162372 RVA: 0x009F6E04 File Offset: 0x009F5004
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SStrikeInfo._ScriptStructPtr != 0) ? SStrikeInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/LevelGamePlay/StrikeResponse/Stuct/SStrikeInfo.SStrikeInfo", ref SStrikeInfo._ScriptStructPtr);
		}

		// Token: 0x04014C89 RID: 85129
		[FieldOffset(0)]
		public TEnumAsByte<ECamp> Striker;

		// Token: 0x04014C8A RID: 85130
		[FieldOffset(4)]
		public float SrikeDirection;

		// Token: 0x04014C8B RID: 85131
		[FieldOffset(8)]
		public TEnumAsByte<SrikeElement> Element;

		// Token: 0x04014C8C RID: 85132
		[FieldOffset(9)]
		public TEnumAsByte<StrikeType> SrikeType;

		// Token: 0x04014C8D RID: 85133
		public const string __ObjectPath = "/Game/Aki/Data/LevelGamePlay/StrikeResponse/Stuct/SStrikeInfo.SStrikeInfo";

		// Token: 0x04014C8E RID: 85134
		private static IntPtr _ScriptStructPtr;
	}
}
