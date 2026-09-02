using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_Stamina
{
	// Token: 0x02004352 RID: 17234
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Stamina/GE_Common_StaminaPunish.GE_Common_StaminaPunish_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Common_StaminaPunish_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DAB6 RID: 187062 RVA: 0x00AC670C File Offset: 0x00AC490C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Common_StaminaPunish_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Stamina/GE_Common_StaminaPunish.GE_Common_StaminaPunish_C");
			}
			return GE_Common_StaminaPunish_C._ClassPtr;
		}

		// Token: 0x0602DAB7 RID: 187063 RVA: 0x00AC6730 File Offset: 0x00AC4930
		public GE_Common_StaminaPunish_C() : this(BuiltinUtils.AllocNativeUObject(GE_Common_StaminaPunish_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DAB8 RID: 187064 RVA: 0x00AC6758 File Offset: 0x00AC4958
		[NullableContext(1)]
		public GE_Common_StaminaPunish_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Common_StaminaPunish_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DAB9 RID: 187065 RVA: 0x00AC678B File Offset: 0x00AC498B
		protected GE_Common_StaminaPunish_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C12 RID: 105490
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Stamina/GE_Common_StaminaPunish.GE_Common_StaminaPunish_C";

		// Token: 0x04019C13 RID: 105491
		private static IntPtr _ClassPtr;

		// Token: 0x04019C14 RID: 105492
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
