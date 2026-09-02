using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_Element.ElementGain
{
	// Token: 0x02004360 RID: 17248
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Element/ElementGain/GE_Element_Gain_Ice.GE_Element_Gain_Ice_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Element_Gain_Ice_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DAEE RID: 187118 RVA: 0x00AC6E7C File Offset: 0x00AC507C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Element_Gain_Ice_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Element/ElementGain/GE_Element_Gain_Ice.GE_Element_Gain_Ice_C");
			}
			return GE_Element_Gain_Ice_C._ClassPtr;
		}

		// Token: 0x0602DAEF RID: 187119 RVA: 0x00AC6EA0 File Offset: 0x00AC50A0
		public GE_Element_Gain_Ice_C() : this(BuiltinUtils.AllocNativeUObject(GE_Element_Gain_Ice_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DAF0 RID: 187120 RVA: 0x00AC6EC8 File Offset: 0x00AC50C8
		[NullableContext(1)]
		public GE_Element_Gain_Ice_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Element_Gain_Ice_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DAF1 RID: 187121 RVA: 0x00AC6EFB File Offset: 0x00AC50FB
		protected GE_Element_Gain_Ice_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C3C RID: 105532
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Element/ElementGain/GE_Element_Gain_Ice.GE_Element_Gain_Ice_C";

		// Token: 0x04019C3D RID: 105533
		private static IntPtr _ClassPtr;

		// Token: 0x04019C3E RID: 105534
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
