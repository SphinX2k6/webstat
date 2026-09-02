using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera.MovieCamera
{
	// Token: 0x02004327 RID: 17191
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(1, 1, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 1)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/MovieCamera/SMovieCameraConfigItem_Condition.SMovieCameraConfigItem_Condition")]
	[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 1)]
	public struct SMovieCameraConfigItem_Condition : IEqualityOperators<SMovieCameraConfigItem_Condition, SMovieCameraConfigItem_Condition, bool>, IEquatable<SMovieCameraConfigItem_Condition>, IUnrealScriptStruct
	{
		// Token: 0x0602D99A RID: 186778 RVA: 0x00AC450D File Offset: 0x00AC270D
		public SMovieCameraConfigItem_Condition(TEnumAsByte<EMovieCameraItem_ConditionType> ConditionType)
		{
			this.ConditionType = ConditionType;
		}

		// Token: 0x0602D99B RID: 186779 RVA: 0x00AC4516 File Offset: 0x00AC2716
		public static bool operator ==(SMovieCameraConfigItem_Condition left, SMovieCameraConfigItem_Condition right)
		{
			return left.ConditionType == right.ConditionType;
		}

		// Token: 0x0602D99C RID: 186780 RVA: 0x00AC4529 File Offset: 0x00AC2729
		public static bool operator !=(SMovieCameraConfigItem_Condition left, SMovieCameraConfigItem_Condition right)
		{
			return !(left == right);
		}

		// Token: 0x0602D99D RID: 186781 RVA: 0x00AC4535 File Offset: 0x00AC2735
		public bool Equals(SMovieCameraConfigItem_Condition other)
		{
			return this == other;
		}

		// Token: 0x0602D99E RID: 186782 RVA: 0x00AC4544 File Offset: 0x00AC2744
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SMovieCameraConfigItem_Condition)
			{
				SMovieCameraConfigItem_Condition other = (SMovieCameraConfigItem_Condition)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0602D99F RID: 186783 RVA: 0x00AC4569 File Offset: 0x00AC2769
		public override int GetHashCode()
		{
			return HashCode.Combine<TEnumAsByte<EMovieCameraItem_ConditionType>>(this.ConditionType);
		}

		// Token: 0x0602D9A0 RID: 186784 RVA: 0x00AC4576 File Offset: 0x00AC2776
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMovieCameraConfigItem_Condition._ScriptStructPtr != 0) ? SMovieCameraConfigItem_Condition._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/Camera/MovieCamera/SMovieCameraConfigItem_Condition.SMovieCameraConfigItem_Condition", ref SMovieCameraConfigItem_Condition._ScriptStructPtr);
		}

		// Token: 0x04019B60 RID: 105312
		[FieldOffset(0)]
		public TEnumAsByte<EMovieCameraItem_ConditionType> ConditionType;

		// Token: 0x04019B61 RID: 105313
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Camera/MovieCamera/SMovieCameraConfigItem_Condition.SMovieCameraConfigItem_Condition";

		// Token: 0x04019B62 RID: 105314
		private static IntPtr _ScriptStructPtr;
	}
}
