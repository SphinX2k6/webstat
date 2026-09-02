using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_Element.ElementGain
{
	// Token: 0x02004363 RID: 17251
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Element/ElementGain/GE_Element_Gain_Wind.GE_Element_Gain_Wind_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Element_Gain_Wind_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DAFA RID: 187130 RVA: 0x00AC7014 File Offset: 0x00AC5214
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Element_Gain_Wind_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Element/ElementGain/GE_Element_Gain_Wind.GE_Element_Gain_Wind_C");
			}
			return GE_Element_Gain_Wind_C._ClassPtr;
		}

		// Token: 0x0602DAFB RID: 187131 RVA: 0x00AC7038 File Offset: 0x00AC5238
		public GE_Element_Gain_Wind_C() : this(BuiltinUtils.AllocNativeUObject(GE_Element_Gain_Wind_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DAFC RID: 187132 RVA: 0x00AC7060 File Offset: 0x00AC5260
		[NullableContext(1)]
		public GE_Element_Gain_Wind_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Element_Gain_Wind_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DAFD RID: 187133 RVA: 0x00AC7093 File Offset: 0x00AC5293
		protected GE_Element_Gain_Wind_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C45 RID: 105541
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Element/ElementGain/GE_Element_Gain_Wind.GE_Element_Gain_Wind_C";

		// Token: 0x04019C46 RID: 105542
		private static IntPtr _ClassPtr;

		// Token: 0x04019C47 RID: 105543
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
