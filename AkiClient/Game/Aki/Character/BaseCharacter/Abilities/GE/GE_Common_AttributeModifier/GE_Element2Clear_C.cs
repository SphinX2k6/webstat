using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_AttributeModifier
{
	// Token: 0x0200436A RID: 17258
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_Element2Clear.GE_Element2Clear_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Element2Clear_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DB16 RID: 187158 RVA: 0x00AC73CC File Offset: 0x00AC55CC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Element2Clear_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_Element2Clear.GE_Element2Clear_C");
			}
			return GE_Element2Clear_C._ClassPtr;
		}

		// Token: 0x0602DB17 RID: 187159 RVA: 0x00AC73F0 File Offset: 0x00AC55F0
		public GE_Element2Clear_C() : this(BuiltinUtils.AllocNativeUObject(GE_Element2Clear_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DB18 RID: 187160 RVA: 0x00AC7418 File Offset: 0x00AC5618
		[NullableContext(1)]
		public GE_Element2Clear_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Element2Clear_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DB19 RID: 187161 RVA: 0x00AC744B File Offset: 0x00AC564B
		protected GE_Element2Clear_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C5A RID: 105562
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_Element2Clear.GE_Element2Clear_C";

		// Token: 0x04019C5B RID: 105563
		private static IntPtr _ClassPtr;

		// Token: 0x04019C5C RID: 105564
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
