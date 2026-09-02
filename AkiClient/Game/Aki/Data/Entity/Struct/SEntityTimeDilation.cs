using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Entity.Struct
{
	// Token: 0x02003EF4 RID: 16116
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(8, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 8)]
	[UnrealObjectPath("/Game/Aki/Data/Entity/Struct/SEntityTimeDilation.SEntityTimeDilation")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 8)]
	public struct SEntityTimeDilation : IEqualityOperators<SEntityTimeDilation, SEntityTimeDilation, bool>, IEquatable<SEntityTimeDilation>, IUnrealScriptStruct
	{
		// Token: 0x06028268 RID: 164456 RVA: 0x00A03AFC File Offset: 0x00A01CFC
		public SEntityTimeDilation(int SourceType, float TimeDilation)
		{
			this.SourceType = SourceType;
			this.TimeDilation = TimeDilation;
		}

		// Token: 0x06028269 RID: 164457 RVA: 0x00A03B0C File Offset: 0x00A01D0C
		public static bool operator ==(SEntityTimeDilation left, SEntityTimeDilation right)
		{
			return left.SourceType == right.SourceType && left.TimeDilation == right.TimeDilation;
		}

		// Token: 0x0602826A RID: 164458 RVA: 0x00A03B2C File Offset: 0x00A01D2C
		public static bool operator !=(SEntityTimeDilation left, SEntityTimeDilation right)
		{
			return !(left == right);
		}

		// Token: 0x0602826B RID: 164459 RVA: 0x00A03B38 File Offset: 0x00A01D38
		public bool Equals(SEntityTimeDilation other)
		{
			return this == other;
		}

		// Token: 0x0602826C RID: 164460 RVA: 0x00A03B48 File Offset: 0x00A01D48
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SEntityTimeDilation)
			{
				SEntityTimeDilation other = (SEntityTimeDilation)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0602826D RID: 164461 RVA: 0x00A03B6D File Offset: 0x00A01D6D
		public override int GetHashCode()
		{
			return HashCode.Combine<int, float>(this.SourceType, this.TimeDilation);
		}

		// Token: 0x0602826E RID: 164462 RVA: 0x00A03B80 File Offset: 0x00A01D80
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SEntityTimeDilation._ScriptStructPtr != 0) ? SEntityTimeDilation._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Entity/Struct/SEntityTimeDilation.SEntityTimeDilation", ref SEntityTimeDilation._ScriptStructPtr);
		}

		// Token: 0x04015165 RID: 86373
		[FieldOffset(0)]
		public int SourceType;

		// Token: 0x04015166 RID: 86374
		[FieldOffset(4)]
		public float TimeDilation;

		// Token: 0x04015167 RID: 86375
		public const string __ObjectPath = "/Game/Aki/Data/Entity/Struct/SEntityTimeDilation.SEntityTimeDilation";

		// Token: 0x04015168 RID: 86376
		private static IntPtr _ScriptStructPtr;
	}
}
