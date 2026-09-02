using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_AttributeModifier
{
	// Token: 0x02004367 RID: 17255
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_A_InitCharacterStateAttribute.GE_A_InitCharacterStateAttribute_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_A_InitCharacterStateAttribute_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DB0A RID: 187146 RVA: 0x00AC7234 File Offset: 0x00AC5434
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_A_InitCharacterStateAttribute_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_A_InitCharacterStateAttribute.GE_A_InitCharacterStateAttribute_C");
			}
			return GE_A_InitCharacterStateAttribute_C._ClassPtr;
		}

		// Token: 0x0602DB0B RID: 187147 RVA: 0x00AC7258 File Offset: 0x00AC5458
		public GE_A_InitCharacterStateAttribute_C() : this(BuiltinUtils.AllocNativeUObject(GE_A_InitCharacterStateAttribute_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DB0C RID: 187148 RVA: 0x00AC7280 File Offset: 0x00AC5480
		[NullableContext(1)]
		public GE_A_InitCharacterStateAttribute_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_A_InitCharacterStateAttribute_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DB0D RID: 187149 RVA: 0x00AC72B3 File Offset: 0x00AC54B3
		protected GE_A_InitCharacterStateAttribute_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C51 RID: 105553
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_A_InitCharacterStateAttribute.GE_A_InitCharacterStateAttribute_C";

		// Token: 0x04019C52 RID: 105554
		private static IntPtr _ClassPtr;

		// Token: 0x04019C53 RID: 105555
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
