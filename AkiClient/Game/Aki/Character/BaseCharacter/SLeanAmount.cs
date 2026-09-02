using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200426C RID: 17004
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(8, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 8)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SLeanAmount.SLeanAmount")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 8)]
	public struct SLeanAmount : IEqualityOperators<SLeanAmount, SLeanAmount, bool>, IEquatable<SLeanAmount>, IUnrealScriptStruct
	{
		// Token: 0x0602D166 RID: 184678 RVA: 0x00AB7094 File Offset: 0x00AB5294
		public SLeanAmount(float 前后, float 左右)
		{
			this.前后 = 前后;
			this.左右 = 左右;
		}

		// Token: 0x0602D167 RID: 184679 RVA: 0x00AB70A4 File Offset: 0x00AB52A4
		public static bool operator ==(SLeanAmount left, SLeanAmount right)
		{
			return left.前后 == right.前后 && left.左右 == right.左右;
		}

		// Token: 0x0602D168 RID: 184680 RVA: 0x00AB70C4 File Offset: 0x00AB52C4
		public static bool operator !=(SLeanAmount left, SLeanAmount right)
		{
			return !(left == right);
		}

		// Token: 0x0602D169 RID: 184681 RVA: 0x00AB70D0 File Offset: 0x00AB52D0
		public bool Equals(SLeanAmount other)
		{
			return this == other;
		}

		// Token: 0x0602D16A RID: 184682 RVA: 0x00AB70E0 File Offset: 0x00AB52E0
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SLeanAmount)
			{
				SLeanAmount other = (SLeanAmount)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0602D16B RID: 184683 RVA: 0x00AB7105 File Offset: 0x00AB5305
		public override int GetHashCode()
		{
			return HashCode.Combine<float, float>(this.前后, this.左右);
		}

		// Token: 0x0602D16C RID: 184684 RVA: 0x00AB7118 File Offset: 0x00AB5318
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SLeanAmount._ScriptStructPtr != 0) ? SLeanAmount._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SLeanAmount.SLeanAmount", ref SLeanAmount._ScriptStructPtr);
		}

		// Token: 0x0401947E RID: 103550
		[FieldOffset(0)]
		public float 前后;

		// Token: 0x0401947F RID: 103551
		[FieldOffset(4)]
		public float 左右;

		// Token: 0x04019480 RID: 103552
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SLeanAmount.SLeanAmount";

		// Token: 0x04019481 RID: 103553
		private static IntPtr _ScriptStructPtr;
	}
}
