using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_Stamina
{
	// Token: 0x02004357 RID: 17239
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Stamina/GE_Common_Stamina_Cost_Jump.GE_Common_Stamina_Cost_Jump_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Common_Stamina_Cost_Jump_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DACA RID: 187082 RVA: 0x00AC69B4 File Offset: 0x00AC4BB4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Common_Stamina_Cost_Jump_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Stamina/GE_Common_Stamina_Cost_Jump.GE_Common_Stamina_Cost_Jump_C");
			}
			return GE_Common_Stamina_Cost_Jump_C._ClassPtr;
		}

		// Token: 0x0602DACB RID: 187083 RVA: 0x00AC69D8 File Offset: 0x00AC4BD8
		public GE_Common_Stamina_Cost_Jump_C() : this(BuiltinUtils.AllocNativeUObject(GE_Common_Stamina_Cost_Jump_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DACC RID: 187084 RVA: 0x00AC6A00 File Offset: 0x00AC4C00
		[NullableContext(1)]
		public GE_Common_Stamina_Cost_Jump_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Common_Stamina_Cost_Jump_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DACD RID: 187085 RVA: 0x00AC6A33 File Offset: 0x00AC4C33
		protected GE_Common_Stamina_Cost_Jump_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C21 RID: 105505
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Stamina/GE_Common_Stamina_Cost_Jump.GE_Common_Stamina_Cost_Jump_C";

		// Token: 0x04019C22 RID: 105506
		private static IntPtr _ClassPtr;

		// Token: 0x04019C23 RID: 105507
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
