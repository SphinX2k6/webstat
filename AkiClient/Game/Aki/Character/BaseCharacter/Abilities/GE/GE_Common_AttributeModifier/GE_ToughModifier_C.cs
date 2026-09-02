using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_AttributeModifier
{
	// Token: 0x02004372 RID: 17266
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_ToughModifier.GE_ToughModifier_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_ToughModifier_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DB36 RID: 187190 RVA: 0x00AC780C File Offset: 0x00AC5A0C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_ToughModifier_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_ToughModifier.GE_ToughModifier_C");
			}
			return GE_ToughModifier_C._ClassPtr;
		}

		// Token: 0x0602DB37 RID: 187191 RVA: 0x00AC7830 File Offset: 0x00AC5A30
		public GE_ToughModifier_C() : this(BuiltinUtils.AllocNativeUObject(GE_ToughModifier_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DB38 RID: 187192 RVA: 0x00AC7858 File Offset: 0x00AC5A58
		[NullableContext(1)]
		public GE_ToughModifier_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_ToughModifier_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DB39 RID: 187193 RVA: 0x00AC788B File Offset: 0x00AC5A8B
		protected GE_ToughModifier_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C72 RID: 105586
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_ToughModifier.GE_ToughModifier_C";

		// Token: 0x04019C73 RID: 105587
		private static IntPtr _ClassPtr;

		// Token: 0x04019C74 RID: 105588
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
