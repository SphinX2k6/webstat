using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_AttributeModifier
{
	// Token: 0x0200436D RID: 17261
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_Element5Clear.GE_Element5Clear_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Element5Clear_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DB22 RID: 187170 RVA: 0x00AC7564 File Offset: 0x00AC5764
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Element5Clear_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_Element5Clear.GE_Element5Clear_C");
			}
			return GE_Element5Clear_C._ClassPtr;
		}

		// Token: 0x0602DB23 RID: 187171 RVA: 0x00AC7588 File Offset: 0x00AC5788
		public GE_Element5Clear_C() : this(BuiltinUtils.AllocNativeUObject(GE_Element5Clear_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DB24 RID: 187172 RVA: 0x00AC75B0 File Offset: 0x00AC57B0
		[NullableContext(1)]
		public GE_Element5Clear_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Element5Clear_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DB25 RID: 187173 RVA: 0x00AC75E3 File Offset: 0x00AC57E3
		protected GE_Element5Clear_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C63 RID: 105571
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_Element5Clear.GE_Element5Clear_C";

		// Token: 0x04019C64 RID: 105572
		private static IntPtr _ClassPtr;

		// Token: 0x04019C65 RID: 105573
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
