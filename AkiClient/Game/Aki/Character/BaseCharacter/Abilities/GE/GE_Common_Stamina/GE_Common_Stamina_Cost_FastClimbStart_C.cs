using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_Stamina
{
	// Token: 0x02004356 RID: 17238
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Stamina/GE_Common_Stamina_Cost_FastClimbStart.GE_Common_Stamina_Cost_FastClimbStart_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Common_Stamina_Cost_FastClimbStart_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DAC6 RID: 187078 RVA: 0x00AC692C File Offset: 0x00AC4B2C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Common_Stamina_Cost_FastClimbStart_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Stamina/GE_Common_Stamina_Cost_FastClimbStart.GE_Common_Stamina_Cost_FastClimbStart_C");
			}
			return GE_Common_Stamina_Cost_FastClimbStart_C._ClassPtr;
		}

		// Token: 0x0602DAC7 RID: 187079 RVA: 0x00AC6950 File Offset: 0x00AC4B50
		public GE_Common_Stamina_Cost_FastClimbStart_C() : this(BuiltinUtils.AllocNativeUObject(GE_Common_Stamina_Cost_FastClimbStart_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DAC8 RID: 187080 RVA: 0x00AC6978 File Offset: 0x00AC4B78
		[NullableContext(1)]
		public GE_Common_Stamina_Cost_FastClimbStart_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Common_Stamina_Cost_FastClimbStart_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DAC9 RID: 187081 RVA: 0x00AC69AB File Offset: 0x00AC4BAB
		protected GE_Common_Stamina_Cost_FastClimbStart_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C1E RID: 105502
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Stamina/GE_Common_Stamina_Cost_FastClimbStart.GE_Common_Stamina_Cost_FastClimbStart_C";

		// Token: 0x04019C1F RID: 105503
		private static IntPtr _ClassPtr;

		// Token: 0x04019C20 RID: 105504
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
