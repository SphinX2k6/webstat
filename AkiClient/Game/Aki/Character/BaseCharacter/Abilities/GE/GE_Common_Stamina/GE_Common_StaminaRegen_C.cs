using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_Stamina
{
	// Token: 0x02004353 RID: 17235
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Stamina/GE_Common_StaminaRegen.GE_Common_StaminaRegen_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Common_StaminaRegen_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DABA RID: 187066 RVA: 0x00AC6794 File Offset: 0x00AC4994
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Common_StaminaRegen_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Stamina/GE_Common_StaminaRegen.GE_Common_StaminaRegen_C");
			}
			return GE_Common_StaminaRegen_C._ClassPtr;
		}

		// Token: 0x0602DABB RID: 187067 RVA: 0x00AC67B8 File Offset: 0x00AC49B8
		public GE_Common_StaminaRegen_C() : this(BuiltinUtils.AllocNativeUObject(GE_Common_StaminaRegen_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DABC RID: 187068 RVA: 0x00AC67E0 File Offset: 0x00AC49E0
		[NullableContext(1)]
		public GE_Common_StaminaRegen_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Common_StaminaRegen_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DABD RID: 187069 RVA: 0x00AC6813 File Offset: 0x00AC4A13
		protected GE_Common_StaminaRegen_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C15 RID: 105493
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Stamina/GE_Common_StaminaRegen.GE_Common_StaminaRegen_C";

		// Token: 0x04019C16 RID: 105494
		private static IntPtr _ClassPtr;

		// Token: 0x04019C17 RID: 105495
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
