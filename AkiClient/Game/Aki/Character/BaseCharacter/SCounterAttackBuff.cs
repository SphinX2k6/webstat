using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004250 RID: 16976
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 12)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SCounterAttackBuff.SCounterAttackBuff")]
	[StructLayout(LayoutKind.Explicit, Pack = 8, Size = 16)]
	public struct SCounterAttackBuff : IEqualityOperators<SCounterAttackBuff, SCounterAttackBuff, bool>, IEquatable<SCounterAttackBuff>, IUnrealScriptStruct
	{
		// Token: 0x0602CF67 RID: 184167 RVA: 0x00AB4454 File Offset: 0x00AB2654
		public SCounterAttackBuff(long BuffID, int 层数)
		{
			this.BuffID = BuffID;
			this.层数 = 层数;
		}

		// Token: 0x0602CF68 RID: 184168 RVA: 0x00AB4464 File Offset: 0x00AB2664
		public static bool operator ==(SCounterAttackBuff left, SCounterAttackBuff right)
		{
			return left.BuffID == right.BuffID && left.层数 == right.层数;
		}

		// Token: 0x0602CF69 RID: 184169 RVA: 0x00AB4484 File Offset: 0x00AB2684
		public static bool operator !=(SCounterAttackBuff left, SCounterAttackBuff right)
		{
			return !(left == right);
		}

		// Token: 0x0602CF6A RID: 184170 RVA: 0x00AB4490 File Offset: 0x00AB2690
		public bool Equals(SCounterAttackBuff other)
		{
			return this == other;
		}

		// Token: 0x0602CF6B RID: 184171 RVA: 0x00AB44A0 File Offset: 0x00AB26A0
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SCounterAttackBuff)
			{
				SCounterAttackBuff other = (SCounterAttackBuff)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0602CF6C RID: 184172 RVA: 0x00AB44C5 File Offset: 0x00AB26C5
		public override int GetHashCode()
		{
			return HashCode.Combine<long, int>(this.BuffID, this.层数);
		}

		// Token: 0x0602CF6D RID: 184173 RVA: 0x00AB44D8 File Offset: 0x00AB26D8
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCounterAttackBuff._ScriptStructPtr != 0) ? SCounterAttackBuff._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SCounterAttackBuff.SCounterAttackBuff", ref SCounterAttackBuff._ScriptStructPtr);
		}

		// Token: 0x0401938F RID: 103311
		[FieldOffset(0)]
		public long BuffID;

		// Token: 0x04019390 RID: 103312
		[FieldOffset(8)]
		public int 层数;

		// Token: 0x04019391 RID: 103313
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SCounterAttackBuff.SCounterAttackBuff";

		// Token: 0x04019392 RID: 103314
		private static IntPtr _ScriptStructPtr;
	}
}
