using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_Element.ElementGain
{
	// Token: 0x0200435F RID: 17247
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Element/ElementGain/GE_Element_Gain_Fire.GE_Element_Gain_Fire_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Element_Gain_Fire_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DAEA RID: 187114 RVA: 0x00AC6DF4 File Offset: 0x00AC4FF4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Element_Gain_Fire_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Element/ElementGain/GE_Element_Gain_Fire.GE_Element_Gain_Fire_C");
			}
			return GE_Element_Gain_Fire_C._ClassPtr;
		}

		// Token: 0x0602DAEB RID: 187115 RVA: 0x00AC6E18 File Offset: 0x00AC5018
		public GE_Element_Gain_Fire_C() : this(BuiltinUtils.AllocNativeUObject(GE_Element_Gain_Fire_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DAEC RID: 187116 RVA: 0x00AC6E40 File Offset: 0x00AC5040
		[NullableContext(1)]
		public GE_Element_Gain_Fire_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Element_Gain_Fire_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DAED RID: 187117 RVA: 0x00AC6E73 File Offset: 0x00AC5073
		protected GE_Element_Gain_Fire_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C39 RID: 105529
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Element/ElementGain/GE_Element_Gain_Fire.GE_Element_Gain_Fire_C";

		// Token: 0x04019C3A RID: 105530
		private static IntPtr _ClassPtr;

		// Token: 0x04019C3B RID: 105531
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
