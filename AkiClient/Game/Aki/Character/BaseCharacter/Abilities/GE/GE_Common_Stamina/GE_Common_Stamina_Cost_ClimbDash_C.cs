using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_Stamina
{
	// Token: 0x02004354 RID: 17236
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Stamina/GE_Common_Stamina_Cost_ClimbDash.GE_Common_Stamina_Cost_ClimbDash_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Common_Stamina_Cost_ClimbDash_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DABE RID: 187070 RVA: 0x00AC681C File Offset: 0x00AC4A1C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Common_Stamina_Cost_ClimbDash_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Stamina/GE_Common_Stamina_Cost_ClimbDash.GE_Common_Stamina_Cost_ClimbDash_C");
			}
			return GE_Common_Stamina_Cost_ClimbDash_C._ClassPtr;
		}

		// Token: 0x0602DABF RID: 187071 RVA: 0x00AC6840 File Offset: 0x00AC4A40
		public GE_Common_Stamina_Cost_ClimbDash_C() : this(BuiltinUtils.AllocNativeUObject(GE_Common_Stamina_Cost_ClimbDash_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DAC0 RID: 187072 RVA: 0x00AC6868 File Offset: 0x00AC4A68
		[NullableContext(1)]
		public GE_Common_Stamina_Cost_ClimbDash_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Common_Stamina_Cost_ClimbDash_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DAC1 RID: 187073 RVA: 0x00AC689B File Offset: 0x00AC4A9B
		protected GE_Common_Stamina_Cost_ClimbDash_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C18 RID: 105496
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Stamina/GE_Common_Stamina_Cost_ClimbDash.GE_Common_Stamina_Cost_ClimbDash_C";

		// Token: 0x04019C19 RID: 105497
		private static IntPtr _ClassPtr;

		// Token: 0x04019C1A RID: 105498
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
