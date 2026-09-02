using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_Element.ElementGain
{
	// Token: 0x0200435E RID: 17246
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Element/ElementGain/GE_Element_Gain_Dark.GE_Element_Gain_Dark_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Element_Gain_Dark_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DAE6 RID: 187110 RVA: 0x00AC6D6C File Offset: 0x00AC4F6C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Element_Gain_Dark_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Element/ElementGain/GE_Element_Gain_Dark.GE_Element_Gain_Dark_C");
			}
			return GE_Element_Gain_Dark_C._ClassPtr;
		}

		// Token: 0x0602DAE7 RID: 187111 RVA: 0x00AC6D90 File Offset: 0x00AC4F90
		public GE_Element_Gain_Dark_C() : this(BuiltinUtils.AllocNativeUObject(GE_Element_Gain_Dark_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DAE8 RID: 187112 RVA: 0x00AC6DB8 File Offset: 0x00AC4FB8
		[NullableContext(1)]
		public GE_Element_Gain_Dark_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Element_Gain_Dark_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DAE9 RID: 187113 RVA: 0x00AC6DEB File Offset: 0x00AC4FEB
		protected GE_Element_Gain_Dark_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C36 RID: 105526
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Element/ElementGain/GE_Element_Gain_Dark.GE_Element_Gain_Dark_C";

		// Token: 0x04019C37 RID: 105527
		private static IntPtr _ClassPtr;

		// Token: 0x04019C38 RID: 105528
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
