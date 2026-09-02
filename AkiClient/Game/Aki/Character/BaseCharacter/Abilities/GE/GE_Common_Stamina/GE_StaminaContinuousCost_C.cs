using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_Stamina
{
	// Token: 0x02004358 RID: 17240
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Stamina/GE_StaminaContinuousCost.GE_StaminaContinuousCost_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_StaminaContinuousCost_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DACE RID: 187086 RVA: 0x00AC6A3C File Offset: 0x00AC4C3C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_StaminaContinuousCost_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Stamina/GE_StaminaContinuousCost.GE_StaminaContinuousCost_C");
			}
			return GE_StaminaContinuousCost_C._ClassPtr;
		}

		// Token: 0x0602DACF RID: 187087 RVA: 0x00AC6A60 File Offset: 0x00AC4C60
		public GE_StaminaContinuousCost_C() : this(BuiltinUtils.AllocNativeUObject(GE_StaminaContinuousCost_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DAD0 RID: 187088 RVA: 0x00AC6A88 File Offset: 0x00AC4C88
		[NullableContext(1)]
		public GE_StaminaContinuousCost_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_StaminaContinuousCost_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DAD1 RID: 187089 RVA: 0x00AC6ABB File Offset: 0x00AC4CBB
		protected GE_StaminaContinuousCost_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C24 RID: 105508
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Stamina/GE_StaminaContinuousCost.GE_StaminaContinuousCost_C";

		// Token: 0x04019C25 RID: 105509
		private static IntPtr _ClassPtr;

		// Token: 0x04019C26 RID: 105510
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
