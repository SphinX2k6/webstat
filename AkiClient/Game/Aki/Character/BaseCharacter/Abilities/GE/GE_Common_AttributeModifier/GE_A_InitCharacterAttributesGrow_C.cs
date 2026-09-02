using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_AttributeModifier
{
	// Token: 0x02004365 RID: 17253
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_A_InitCharacterAttributesGrow.GE_A_InitCharacterAttributesGrow_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_A_InitCharacterAttributesGrow_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DB02 RID: 187138 RVA: 0x00AC7124 File Offset: 0x00AC5324
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_A_InitCharacterAttributesGrow_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_A_InitCharacterAttributesGrow.GE_A_InitCharacterAttributesGrow_C");
			}
			return GE_A_InitCharacterAttributesGrow_C._ClassPtr;
		}

		// Token: 0x0602DB03 RID: 187139 RVA: 0x00AC7148 File Offset: 0x00AC5348
		public GE_A_InitCharacterAttributesGrow_C() : this(BuiltinUtils.AllocNativeUObject(GE_A_InitCharacterAttributesGrow_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DB04 RID: 187140 RVA: 0x00AC7170 File Offset: 0x00AC5370
		[NullableContext(1)]
		public GE_A_InitCharacterAttributesGrow_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_A_InitCharacterAttributesGrow_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DB05 RID: 187141 RVA: 0x00AC71A3 File Offset: 0x00AC53A3
		protected GE_A_InitCharacterAttributesGrow_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C4B RID: 105547
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_A_InitCharacterAttributesGrow.GE_A_InitCharacterAttributesGrow_C";

		// Token: 0x04019C4C RID: 105548
		private static IntPtr _ClassPtr;

		// Token: 0x04019C4D RID: 105549
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
