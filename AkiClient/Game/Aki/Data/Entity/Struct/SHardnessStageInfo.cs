using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Entity.Struct
{
	// Token: 0x02003EF5 RID: 16117
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(8, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 8)]
	[UnrealObjectPath("/Game/Aki/Data/Entity/Struct/SHardnessStageInfo.SHardnessStageInfo")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 8)]
	public struct SHardnessStageInfo : IEqualityOperators<SHardnessStageInfo, SHardnessStageInfo, bool>, IEquatable<SHardnessStageInfo>, IUnrealScriptStruct
	{
		// Token: 0x0602826F RID: 164463 RVA: 0x00A03BA4 File Offset: 0x00A01DA4
		public SHardnessStageInfo(int HardnessStagePercent, int HardnessStrengh)
		{
			this.HardnessStagePercent = HardnessStagePercent;
			this.HardnessStrengh = HardnessStrengh;
		}

		// Token: 0x06028270 RID: 164464 RVA: 0x00A03BB4 File Offset: 0x00A01DB4
		public static bool operator ==(SHardnessStageInfo left, SHardnessStageInfo right)
		{
			return left.HardnessStagePercent == right.HardnessStagePercent && left.HardnessStrengh == right.HardnessStrengh;
		}

		// Token: 0x06028271 RID: 164465 RVA: 0x00A03BD4 File Offset: 0x00A01DD4
		public static bool operator !=(SHardnessStageInfo left, SHardnessStageInfo right)
		{
			return !(left == right);
		}

		// Token: 0x06028272 RID: 164466 RVA: 0x00A03BE0 File Offset: 0x00A01DE0
		public bool Equals(SHardnessStageInfo other)
		{
			return this == other;
		}

		// Token: 0x06028273 RID: 164467 RVA: 0x00A03BF0 File Offset: 0x00A01DF0
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SHardnessStageInfo)
			{
				SHardnessStageInfo other = (SHardnessStageInfo)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06028274 RID: 164468 RVA: 0x00A03C15 File Offset: 0x00A01E15
		public override int GetHashCode()
		{
			return HashCode.Combine<int, int>(this.HardnessStagePercent, this.HardnessStrengh);
		}

		// Token: 0x06028275 RID: 164469 RVA: 0x00A03C28 File Offset: 0x00A01E28
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SHardnessStageInfo._ScriptStructPtr != 0) ? SHardnessStageInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Entity/Struct/SHardnessStageInfo.SHardnessStageInfo", ref SHardnessStageInfo._ScriptStructPtr);
		}

		// Token: 0x04015169 RID: 86377
		[FieldOffset(0)]
		public int HardnessStagePercent;

		// Token: 0x0401516A RID: 86378
		[FieldOffset(4)]
		public int HardnessStrengh;

		// Token: 0x0401516B RID: 86379
		public const string __ObjectPath = "/Game/Aki/Data/Entity/Struct/SHardnessStageInfo.SHardnessStageInfo";

		// Token: 0x0401516C RID: 86380
		private static IntPtr _ScriptStructPtr;
	}
}
