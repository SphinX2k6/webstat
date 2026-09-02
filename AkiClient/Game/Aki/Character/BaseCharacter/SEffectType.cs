using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200425C RID: 16988
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(8, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 8)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SEffectType.SEffectType")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 8)]
	public struct SEffectType : IEqualityOperators<SEffectType, SEffectType, bool>, IEquatable<SEffectType>, IUnrealScriptStruct
	{
		// Token: 0x0602D02F RID: 184367 RVA: 0x00AB55D8 File Offset: 0x00AB37D8
		public SEffectType(TEnumAsByte<EAttributeEffectType> 类型, int Id)
		{
			this.类型 = 类型;
			this.Id = Id;
		}

		// Token: 0x0602D030 RID: 184368 RVA: 0x00AB55E8 File Offset: 0x00AB37E8
		public static bool operator ==(SEffectType left, SEffectType right)
		{
			return left.类型 == right.类型 && left.Id == right.Id;
		}

		// Token: 0x0602D031 RID: 184369 RVA: 0x00AB560D File Offset: 0x00AB380D
		public static bool operator !=(SEffectType left, SEffectType right)
		{
			return !(left == right);
		}

		// Token: 0x0602D032 RID: 184370 RVA: 0x00AB5619 File Offset: 0x00AB3819
		public bool Equals(SEffectType other)
		{
			return this == other;
		}

		// Token: 0x0602D033 RID: 184371 RVA: 0x00AB5628 File Offset: 0x00AB3828
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SEffectType)
			{
				SEffectType other = (SEffectType)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0602D034 RID: 184372 RVA: 0x00AB564D File Offset: 0x00AB384D
		public override int GetHashCode()
		{
			return HashCode.Combine<TEnumAsByte<EAttributeEffectType>, int>(this.类型, this.Id);
		}

		// Token: 0x0602D035 RID: 184373 RVA: 0x00AB5660 File Offset: 0x00AB3860
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SEffectType._ScriptStructPtr != 0) ? SEffectType._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SEffectType.SEffectType", ref SEffectType._ScriptStructPtr);
		}

		// Token: 0x040193EC RID: 103404
		[FieldOffset(0)]
		public TEnumAsByte<EAttributeEffectType> 类型;

		// Token: 0x040193ED RID: 103405
		[FieldOffset(4)]
		public int Id;

		// Token: 0x040193EE RID: 103406
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SEffectType.SEffectType";

		// Token: 0x040193EF RID: 103407
		private static IntPtr _ScriptStructPtr;
	}
}
