using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_Element.ElementGain
{
	// Token: 0x02004361 RID: 17249
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Element/ElementGain/GE_Element_Gain_Light.GE_Element_Gain_Light_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Element_Gain_Light_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DAF2 RID: 187122 RVA: 0x00AC6F04 File Offset: 0x00AC5104
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Element_Gain_Light_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Element/ElementGain/GE_Element_Gain_Light.GE_Element_Gain_Light_C");
			}
			return GE_Element_Gain_Light_C._ClassPtr;
		}

		// Token: 0x0602DAF3 RID: 187123 RVA: 0x00AC6F28 File Offset: 0x00AC5128
		public GE_Element_Gain_Light_C() : this(BuiltinUtils.AllocNativeUObject(GE_Element_Gain_Light_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DAF4 RID: 187124 RVA: 0x00AC6F50 File Offset: 0x00AC5150
		[NullableContext(1)]
		public GE_Element_Gain_Light_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Element_Gain_Light_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DAF5 RID: 187125 RVA: 0x00AC6F83 File Offset: 0x00AC5183
		protected GE_Element_Gain_Light_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C3F RID: 105535
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Element/ElementGain/GE_Element_Gain_Light.GE_Element_Gain_Light_C";

		// Token: 0x04019C40 RID: 105536
		private static IntPtr _ClassPtr;

		// Token: 0x04019C41 RID: 105537
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
