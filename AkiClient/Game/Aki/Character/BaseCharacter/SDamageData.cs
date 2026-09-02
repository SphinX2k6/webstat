using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004256 RID: 16982
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(8, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 8)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SDamageData.SDamageData")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 8)]
	public struct SDamageData : IEqualityOperators<SDamageData, SDamageData, bool>, IEquatable<SDamageData>, IUnrealScriptStruct
	{
		// Token: 0x0602CFD8 RID: 184280 RVA: 0x00AB4F44 File Offset: 0x00AB3144
		public SDamageData(float 伤害数值, int 属性Id)
		{
			this.伤害数值 = 伤害数值;
			this.属性Id = 属性Id;
		}

		// Token: 0x0602CFD9 RID: 184281 RVA: 0x00AB4F54 File Offset: 0x00AB3154
		public static bool operator ==(SDamageData left, SDamageData right)
		{
			return left.伤害数值 == right.伤害数值 && left.属性Id == right.属性Id;
		}

		// Token: 0x0602CFDA RID: 184282 RVA: 0x00AB4F74 File Offset: 0x00AB3174
		public static bool operator !=(SDamageData left, SDamageData right)
		{
			return !(left == right);
		}

		// Token: 0x0602CFDB RID: 184283 RVA: 0x00AB4F80 File Offset: 0x00AB3180
		public bool Equals(SDamageData other)
		{
			return this == other;
		}

		// Token: 0x0602CFDC RID: 184284 RVA: 0x00AB4F90 File Offset: 0x00AB3190
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SDamageData)
			{
				SDamageData other = (SDamageData)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0602CFDD RID: 184285 RVA: 0x00AB4FB5 File Offset: 0x00AB31B5
		public override int GetHashCode()
		{
			return HashCode.Combine<float, int>(this.伤害数值, this.属性Id);
		}

		// Token: 0x0602CFDE RID: 184286 RVA: 0x00AB4FC8 File Offset: 0x00AB31C8
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SDamageData._ScriptStructPtr != 0) ? SDamageData._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SDamageData.SDamageData", ref SDamageData._ScriptStructPtr);
		}

		// Token: 0x040193C8 RID: 103368
		[FieldOffset(0)]
		public float 伤害数值;

		// Token: 0x040193C9 RID: 103369
		[FieldOffset(4)]
		public int 属性Id;

		// Token: 0x040193CA RID: 103370
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SDamageData.SDamageData";

		// Token: 0x040193CB RID: 103371
		private static IntPtr _ScriptStructPtr;
	}
}
