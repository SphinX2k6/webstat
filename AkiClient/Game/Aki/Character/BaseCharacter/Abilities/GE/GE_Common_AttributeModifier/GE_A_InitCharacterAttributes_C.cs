using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_AttributeModifier
{
	// Token: 0x02004366 RID: 17254
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_A_InitCharacterAttributes.GE_A_InitCharacterAttributes_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_A_InitCharacterAttributes_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DB06 RID: 187142 RVA: 0x00AC71AC File Offset: 0x00AC53AC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_A_InitCharacterAttributes_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_A_InitCharacterAttributes.GE_A_InitCharacterAttributes_C");
			}
			return GE_A_InitCharacterAttributes_C._ClassPtr;
		}

		// Token: 0x0602DB07 RID: 187143 RVA: 0x00AC71D0 File Offset: 0x00AC53D0
		public GE_A_InitCharacterAttributes_C() : this(BuiltinUtils.AllocNativeUObject(GE_A_InitCharacterAttributes_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DB08 RID: 187144 RVA: 0x00AC71F8 File Offset: 0x00AC53F8
		[NullableContext(1)]
		public GE_A_InitCharacterAttributes_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_A_InitCharacterAttributes_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DB09 RID: 187145 RVA: 0x00AC722B File Offset: 0x00AC542B
		protected GE_A_InitCharacterAttributes_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C4E RID: 105550
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_A_InitCharacterAttributes.GE_A_InitCharacterAttributes_C";

		// Token: 0x04019C4F RID: 105551
		private static IntPtr _ClassPtr;

		// Token: 0x04019C50 RID: 105552
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
