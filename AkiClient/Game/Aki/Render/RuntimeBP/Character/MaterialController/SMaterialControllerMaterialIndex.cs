using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialContainer;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController
{
	// Token: 0x02003D84 RID: 15748
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(24, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 24)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/MaterialController/SMaterialControllerMaterialIndex.SMaterialControllerMaterialIndex")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 24)]
	public struct SMaterialControllerMaterialIndex : IEqualityOperators<SMaterialControllerMaterialIndex, SMaterialControllerMaterialIndex, bool>, IEquatable<SMaterialControllerMaterialIndex>, IUnrealScriptStruct
	{
		// Token: 0x06026713 RID: 157459 RVA: 0x009D7E8A File Offset: 0x009D608A
		public SMaterialControllerMaterialIndex(FName BodyName, int SectionIndex, TEnumAsByte<ECharacterSlotSpecifiedType> SlotType, int MaterialIndex)
		{
			this.BodyName = BodyName;
			this.SectionIndex = SectionIndex;
			this.SlotType = SlotType;
			this.MaterialIndex = MaterialIndex;
		}

		// Token: 0x06026714 RID: 157460 RVA: 0x009D7EAC File Offset: 0x009D60AC
		public static bool operator ==(SMaterialControllerMaterialIndex left, SMaterialControllerMaterialIndex right)
		{
			return left.BodyName == right.BodyName && left.SectionIndex == right.SectionIndex && left.SlotType == right.SlotType && left.MaterialIndex == right.MaterialIndex;
		}

		// Token: 0x06026715 RID: 157461 RVA: 0x009D7EFD File Offset: 0x009D60FD
		public static bool operator !=(SMaterialControllerMaterialIndex left, SMaterialControllerMaterialIndex right)
		{
			return !(left == right);
		}

		// Token: 0x06026716 RID: 157462 RVA: 0x009D7F09 File Offset: 0x009D6109
		public bool Equals(SMaterialControllerMaterialIndex other)
		{
			return this == other;
		}

		// Token: 0x06026717 RID: 157463 RVA: 0x009D7F18 File Offset: 0x009D6118
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SMaterialControllerMaterialIndex)
			{
				SMaterialControllerMaterialIndex other = (SMaterialControllerMaterialIndex)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06026718 RID: 157464 RVA: 0x009D7F3D File Offset: 0x009D613D
		public override int GetHashCode()
		{
			return HashCode.Combine<FName, int, TEnumAsByte<ECharacterSlotSpecifiedType>, int>(this.BodyName, this.SectionIndex, this.SlotType, this.MaterialIndex);
		}

		// Token: 0x06026719 RID: 157465 RVA: 0x009D7F5C File Offset: 0x009D615C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMaterialControllerMaterialIndex._ScriptStructPtr != 0) ? SMaterialControllerMaterialIndex._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Character/MaterialController/SMaterialControllerMaterialIndex.SMaterialControllerMaterialIndex", ref SMaterialControllerMaterialIndex._ScriptStructPtr);
		}

		// Token: 0x04013F6E RID: 81774
		[FieldOffset(0)]
		public FName BodyName;

		// Token: 0x04013F6F RID: 81775
		[FieldOffset(12)]
		public int SectionIndex;

		// Token: 0x04013F70 RID: 81776
		[FieldOffset(16)]
		public TEnumAsByte<ECharacterSlotSpecifiedType> SlotType;

		// Token: 0x04013F71 RID: 81777
		[FieldOffset(20)]
		public int MaterialIndex;

		// Token: 0x04013F72 RID: 81778
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/MaterialController/SMaterialControllerMaterialIndex.SMaterialControllerMaterialIndex";

		// Token: 0x04013F73 RID: 81779
		private static IntPtr _ScriptStructPtr;
	}
}
