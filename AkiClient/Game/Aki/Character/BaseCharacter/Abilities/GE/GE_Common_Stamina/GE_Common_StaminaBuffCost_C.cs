using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_Stamina
{
	// Token: 0x02004350 RID: 17232
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Stamina/GE_Common_StaminaBuffCost.GE_Common_StaminaBuffCost_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Common_StaminaBuffCost_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DAAE RID: 187054 RVA: 0x00AC65FC File Offset: 0x00AC47FC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Common_StaminaBuffCost_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Stamina/GE_Common_StaminaBuffCost.GE_Common_StaminaBuffCost_C");
			}
			return GE_Common_StaminaBuffCost_C._ClassPtr;
		}

		// Token: 0x0602DAAF RID: 187055 RVA: 0x00AC6620 File Offset: 0x00AC4820
		public GE_Common_StaminaBuffCost_C() : this(BuiltinUtils.AllocNativeUObject(GE_Common_StaminaBuffCost_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DAB0 RID: 187056 RVA: 0x00AC6648 File Offset: 0x00AC4848
		[NullableContext(1)]
		public GE_Common_StaminaBuffCost_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Common_StaminaBuffCost_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DAB1 RID: 187057 RVA: 0x00AC667B File Offset: 0x00AC487B
		protected GE_Common_StaminaBuffCost_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C0C RID: 105484
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Stamina/GE_Common_StaminaBuffCost.GE_Common_StaminaBuffCost_C";

		// Token: 0x04019C0D RID: 105485
		private static IntPtr _ClassPtr;

		// Token: 0x04019C0E RID: 105486
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
