using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_Stamina
{
	// Token: 0x02004359 RID: 17241
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Stamina/GE_StaminaExtraTime.GE_StaminaExtraTime_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_StaminaExtraTime_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DAD2 RID: 187090 RVA: 0x00AC6AC4 File Offset: 0x00AC4CC4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_StaminaExtraTime_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Stamina/GE_StaminaExtraTime.GE_StaminaExtraTime_C");
			}
			return GE_StaminaExtraTime_C._ClassPtr;
		}

		// Token: 0x0602DAD3 RID: 187091 RVA: 0x00AC6AE8 File Offset: 0x00AC4CE8
		public GE_StaminaExtraTime_C() : this(BuiltinUtils.AllocNativeUObject(GE_StaminaExtraTime_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DAD4 RID: 187092 RVA: 0x00AC6B10 File Offset: 0x00AC4D10
		[NullableContext(1)]
		public GE_StaminaExtraTime_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_StaminaExtraTime_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DAD5 RID: 187093 RVA: 0x00AC6B43 File Offset: 0x00AC4D43
		protected GE_StaminaExtraTime_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C27 RID: 105511
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Stamina/GE_StaminaExtraTime.GE_StaminaExtraTime_C";

		// Token: 0x04019C28 RID: 105512
		private static IntPtr _ClassPtr;

		// Token: 0x04019C29 RID: 105513
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
