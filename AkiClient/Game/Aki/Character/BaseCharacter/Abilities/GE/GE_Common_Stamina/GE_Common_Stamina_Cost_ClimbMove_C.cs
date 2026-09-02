using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_Stamina
{
	// Token: 0x02004355 RID: 17237
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Stamina/GE_Common_Stamina_Cost_ClimbMove.GE_Common_Stamina_Cost_ClimbMove_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Common_Stamina_Cost_ClimbMove_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DAC2 RID: 187074 RVA: 0x00AC68A4 File Offset: 0x00AC4AA4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Common_Stamina_Cost_ClimbMove_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Stamina/GE_Common_Stamina_Cost_ClimbMove.GE_Common_Stamina_Cost_ClimbMove_C");
			}
			return GE_Common_Stamina_Cost_ClimbMove_C._ClassPtr;
		}

		// Token: 0x0602DAC3 RID: 187075 RVA: 0x00AC68C8 File Offset: 0x00AC4AC8
		public GE_Common_Stamina_Cost_ClimbMove_C() : this(BuiltinUtils.AllocNativeUObject(GE_Common_Stamina_Cost_ClimbMove_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DAC4 RID: 187076 RVA: 0x00AC68F0 File Offset: 0x00AC4AF0
		[NullableContext(1)]
		public GE_Common_Stamina_Cost_ClimbMove_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Common_Stamina_Cost_ClimbMove_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DAC5 RID: 187077 RVA: 0x00AC6923 File Offset: 0x00AC4B23
		protected GE_Common_Stamina_Cost_ClimbMove_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C1B RID: 105499
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Stamina/GE_Common_Stamina_Cost_ClimbMove.GE_Common_Stamina_Cost_ClimbMove_C";

		// Token: 0x04019C1C RID: 105500
		private static IntPtr _ClassPtr;

		// Token: 0x04019C1D RID: 105501
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
