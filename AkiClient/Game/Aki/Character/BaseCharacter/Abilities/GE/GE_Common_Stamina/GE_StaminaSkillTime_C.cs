using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_Stamina
{
	// Token: 0x0200435A RID: 17242
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Stamina/GE_StaminaSkillTime.GE_StaminaSkillTime_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_StaminaSkillTime_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DAD6 RID: 187094 RVA: 0x00AC6B4C File Offset: 0x00AC4D4C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_StaminaSkillTime_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Stamina/GE_StaminaSkillTime.GE_StaminaSkillTime_C");
			}
			return GE_StaminaSkillTime_C._ClassPtr;
		}

		// Token: 0x0602DAD7 RID: 187095 RVA: 0x00AC6B70 File Offset: 0x00AC4D70
		public GE_StaminaSkillTime_C() : this(BuiltinUtils.AllocNativeUObject(GE_StaminaSkillTime_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DAD8 RID: 187096 RVA: 0x00AC6B98 File Offset: 0x00AC4D98
		[NullableContext(1)]
		public GE_StaminaSkillTime_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_StaminaSkillTime_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DAD9 RID: 187097 RVA: 0x00AC6BCB File Offset: 0x00AC4DCB
		protected GE_StaminaSkillTime_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C2A RID: 105514
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Stamina/GE_StaminaSkillTime.GE_StaminaSkillTime_C";

		// Token: 0x04019C2B RID: 105515
		private static IntPtr _ClassPtr;

		// Token: 0x04019C2C RID: 105516
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
