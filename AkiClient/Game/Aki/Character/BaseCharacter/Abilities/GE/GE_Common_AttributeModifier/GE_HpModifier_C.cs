using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_AttributeModifier
{
	// Token: 0x02004370 RID: 17264
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_HpModifier.GE_HpModifier_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_HpModifier_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DB2E RID: 187182 RVA: 0x00AC76FC File Offset: 0x00AC58FC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_HpModifier_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_HpModifier.GE_HpModifier_C");
			}
			return GE_HpModifier_C._ClassPtr;
		}

		// Token: 0x0602DB2F RID: 187183 RVA: 0x00AC7720 File Offset: 0x00AC5920
		public GE_HpModifier_C() : this(BuiltinUtils.AllocNativeUObject(GE_HpModifier_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DB30 RID: 187184 RVA: 0x00AC7748 File Offset: 0x00AC5948
		[NullableContext(1)]
		public GE_HpModifier_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_HpModifier_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DB31 RID: 187185 RVA: 0x00AC777B File Offset: 0x00AC597B
		protected GE_HpModifier_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C6C RID: 105580
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_HpModifier.GE_HpModifier_C";

		// Token: 0x04019C6D RID: 105581
		private static IntPtr _ClassPtr;

		// Token: 0x04019C6E RID: 105582
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
