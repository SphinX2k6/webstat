using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_Element
{
	// Token: 0x0200435D RID: 17245
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Element/GE_SetElementEnergy.GE_SetElementEnergy_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_SetElementEnergy_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DAE2 RID: 187106 RVA: 0x00AC6CE4 File Offset: 0x00AC4EE4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_SetElementEnergy_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Element/GE_SetElementEnergy.GE_SetElementEnergy_C");
			}
			return GE_SetElementEnergy_C._ClassPtr;
		}

		// Token: 0x0602DAE3 RID: 187107 RVA: 0x00AC6D08 File Offset: 0x00AC4F08
		public GE_SetElementEnergy_C() : this(BuiltinUtils.AllocNativeUObject(GE_SetElementEnergy_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DAE4 RID: 187108 RVA: 0x00AC6D30 File Offset: 0x00AC4F30
		[NullableContext(1)]
		public GE_SetElementEnergy_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_SetElementEnergy_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DAE5 RID: 187109 RVA: 0x00AC6D63 File Offset: 0x00AC4F63
		protected GE_SetElementEnergy_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C33 RID: 105523
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Element/GE_SetElementEnergy.GE_SetElementEnergy_C";

		// Token: 0x04019C34 RID: 105524
		private static IntPtr _ClassPtr;

		// Token: 0x04019C35 RID: 105525
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
