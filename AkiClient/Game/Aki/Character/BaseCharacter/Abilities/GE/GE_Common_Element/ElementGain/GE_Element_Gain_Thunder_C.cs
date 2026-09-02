using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_Element.ElementGain
{
	// Token: 0x02004362 RID: 17250
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Element/ElementGain/GE_Element_Gain_Thunder.GE_Element_Gain_Thunder_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Element_Gain_Thunder_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DAF6 RID: 187126 RVA: 0x00AC6F8C File Offset: 0x00AC518C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Element_Gain_Thunder_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Element/ElementGain/GE_Element_Gain_Thunder.GE_Element_Gain_Thunder_C");
			}
			return GE_Element_Gain_Thunder_C._ClassPtr;
		}

		// Token: 0x0602DAF7 RID: 187127 RVA: 0x00AC6FB0 File Offset: 0x00AC51B0
		public GE_Element_Gain_Thunder_C() : this(BuiltinUtils.AllocNativeUObject(GE_Element_Gain_Thunder_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DAF8 RID: 187128 RVA: 0x00AC6FD8 File Offset: 0x00AC51D8
		[NullableContext(1)]
		public GE_Element_Gain_Thunder_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Element_Gain_Thunder_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DAF9 RID: 187129 RVA: 0x00AC700B File Offset: 0x00AC520B
		protected GE_Element_Gain_Thunder_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C42 RID: 105538
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Element/ElementGain/GE_Element_Gain_Thunder.GE_Element_Gain_Thunder_C";

		// Token: 0x04019C43 RID: 105539
		private static IntPtr _ClassPtr;

		// Token: 0x04019C44 RID: 105540
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
