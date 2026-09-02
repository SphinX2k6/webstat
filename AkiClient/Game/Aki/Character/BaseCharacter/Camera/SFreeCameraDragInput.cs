using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x0200431B RID: 17179
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(1, 1, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 1)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/SFreeCameraDragInput.SFreeCameraDragInput")]
	[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 1)]
	public struct SFreeCameraDragInput : IEqualityOperators<SFreeCameraDragInput, SFreeCameraDragInput, bool>, IEquatable<SFreeCameraDragInput>, IUnrealScriptStruct
	{
		// Token: 0x0602D915 RID: 186645 RVA: 0x00AC39E0 File Offset: 0x00AC1BE0
		public SFreeCameraDragInput(bool MemberVar_0)
		{
			this.MemberVar_0 = MemberVar_0;
		}

		// Token: 0x0602D916 RID: 186646 RVA: 0x00AC39E9 File Offset: 0x00AC1BE9
		public static bool operator ==(SFreeCameraDragInput left, SFreeCameraDragInput right)
		{
			return left.MemberVar_0 == right.MemberVar_0;
		}

		// Token: 0x0602D917 RID: 186647 RVA: 0x00AC39F9 File Offset: 0x00AC1BF9
		public static bool operator !=(SFreeCameraDragInput left, SFreeCameraDragInput right)
		{
			return !(left == right);
		}

		// Token: 0x0602D918 RID: 186648 RVA: 0x00AC3A05 File Offset: 0x00AC1C05
		public bool Equals(SFreeCameraDragInput other)
		{
			return this == other;
		}

		// Token: 0x0602D919 RID: 186649 RVA: 0x00AC3A14 File Offset: 0x00AC1C14
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SFreeCameraDragInput)
			{
				SFreeCameraDragInput other = (SFreeCameraDragInput)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0602D91A RID: 186650 RVA: 0x00AC3A39 File Offset: 0x00AC1C39
		public override int GetHashCode()
		{
			return HashCode.Combine<bool>(this.MemberVar_0);
		}

		// Token: 0x0602D91B RID: 186651 RVA: 0x00AC3A46 File Offset: 0x00AC1C46
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SFreeCameraDragInput._ScriptStructPtr != 0) ? SFreeCameraDragInput._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/Camera/SFreeCameraDragInput.SFreeCameraDragInput", ref SFreeCameraDragInput._ScriptStructPtr);
		}

		// Token: 0x04019B0C RID: 105228
		[FieldOffset(0)]
		public bool MemberVar_0;

		// Token: 0x04019B0D RID: 105229
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Camera/SFreeCameraDragInput.SFreeCameraDragInput";

		// Token: 0x04019B0E RID: 105230
		private static IntPtr _ScriptStructPtr;
	}
}
