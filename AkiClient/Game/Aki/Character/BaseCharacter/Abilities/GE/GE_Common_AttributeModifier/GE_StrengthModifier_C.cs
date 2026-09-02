using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_AttributeModifier
{
	// Token: 0x02004371 RID: 17265
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_StrengthModifier.GE_StrengthModifier_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_StrengthModifier_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DB32 RID: 187186 RVA: 0x00AC7784 File Offset: 0x00AC5984
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_StrengthModifier_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_StrengthModifier.GE_StrengthModifier_C");
			}
			return GE_StrengthModifier_C._ClassPtr;
		}

		// Token: 0x0602DB33 RID: 187187 RVA: 0x00AC77A8 File Offset: 0x00AC59A8
		public GE_StrengthModifier_C() : this(BuiltinUtils.AllocNativeUObject(GE_StrengthModifier_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DB34 RID: 187188 RVA: 0x00AC77D0 File Offset: 0x00AC59D0
		[NullableContext(1)]
		public GE_StrengthModifier_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_StrengthModifier_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DB35 RID: 187189 RVA: 0x00AC7803 File Offset: 0x00AC5A03
		protected GE_StrengthModifier_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C6F RID: 105583
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_StrengthModifier.GE_StrengthModifier_C";

		// Token: 0x04019C70 RID: 105584
		private static IntPtr _ClassPtr;

		// Token: 0x04019C71 RID: 105585
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
