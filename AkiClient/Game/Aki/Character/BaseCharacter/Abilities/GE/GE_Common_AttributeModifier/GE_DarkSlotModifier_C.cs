using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_AttributeModifier
{
	// Token: 0x02004368 RID: 17256
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_DarkSlotModifier.GE_DarkSlotModifier_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_DarkSlotModifier_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DB0E RID: 187150 RVA: 0x00AC72BC File Offset: 0x00AC54BC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_DarkSlotModifier_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_DarkSlotModifier.GE_DarkSlotModifier_C");
			}
			return GE_DarkSlotModifier_C._ClassPtr;
		}

		// Token: 0x0602DB0F RID: 187151 RVA: 0x00AC72E0 File Offset: 0x00AC54E0
		public GE_DarkSlotModifier_C() : this(BuiltinUtils.AllocNativeUObject(GE_DarkSlotModifier_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DB10 RID: 187152 RVA: 0x00AC7308 File Offset: 0x00AC5508
		[NullableContext(1)]
		public GE_DarkSlotModifier_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_DarkSlotModifier_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DB11 RID: 187153 RVA: 0x00AC733B File Offset: 0x00AC553B
		protected GE_DarkSlotModifier_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C54 RID: 105556
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_DarkSlotModifier.GE_DarkSlotModifier_C";

		// Token: 0x04019C55 RID: 105557
		private static IntPtr _ClassPtr;

		// Token: 0x04019C56 RID: 105558
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
