using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_Stamina
{
	// Token: 0x02004351 RID: 17233
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Stamina/GE_Common_StaminaCost.GE_Common_StaminaCost_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Common_StaminaCost_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DAB2 RID: 187058 RVA: 0x00AC6684 File Offset: 0x00AC4884
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Common_StaminaCost_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Stamina/GE_Common_StaminaCost.GE_Common_StaminaCost_C");
			}
			return GE_Common_StaminaCost_C._ClassPtr;
		}

		// Token: 0x0602DAB3 RID: 187059 RVA: 0x00AC66A8 File Offset: 0x00AC48A8
		public GE_Common_StaminaCost_C() : this(BuiltinUtils.AllocNativeUObject(GE_Common_StaminaCost_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DAB4 RID: 187060 RVA: 0x00AC66D0 File Offset: 0x00AC48D0
		[NullableContext(1)]
		public GE_Common_StaminaCost_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Common_StaminaCost_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DAB5 RID: 187061 RVA: 0x00AC6703 File Offset: 0x00AC4903
		protected GE_Common_StaminaCost_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C0F RID: 105487
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Stamina/GE_Common_StaminaCost.GE_Common_StaminaCost_C";

		// Token: 0x04019C10 RID: 105488
		private static IntPtr _ClassPtr;

		// Token: 0x04019C11 RID: 105489
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
