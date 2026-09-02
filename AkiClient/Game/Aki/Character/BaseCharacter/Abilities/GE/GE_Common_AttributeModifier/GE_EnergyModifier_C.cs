using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_AttributeModifier
{
	// Token: 0x0200436F RID: 17263
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_EnergyModifier.GE_EnergyModifier_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_EnergyModifier_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DB2A RID: 187178 RVA: 0x00AC7674 File Offset: 0x00AC5874
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_EnergyModifier_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_EnergyModifier.GE_EnergyModifier_C");
			}
			return GE_EnergyModifier_C._ClassPtr;
		}

		// Token: 0x0602DB2B RID: 187179 RVA: 0x00AC7698 File Offset: 0x00AC5898
		public GE_EnergyModifier_C() : this(BuiltinUtils.AllocNativeUObject(GE_EnergyModifier_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DB2C RID: 187180 RVA: 0x00AC76C0 File Offset: 0x00AC58C0
		[NullableContext(1)]
		public GE_EnergyModifier_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_EnergyModifier_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DB2D RID: 187181 RVA: 0x00AC76F3 File Offset: 0x00AC58F3
		protected GE_EnergyModifier_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C69 RID: 105577
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_EnergyModifier.GE_EnergyModifier_C";

		// Token: 0x04019C6A RID: 105578
		private static IntPtr _ClassPtr;

		// Token: 0x04019C6B RID: 105579
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
