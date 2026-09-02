using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_Element
{
	// Token: 0x0200435B RID: 17243
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Element/GE_ATClearElementEnergy.GE_ATClearElementEnergy_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_ATClearElementEnergy_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DADA RID: 187098 RVA: 0x00AC6BD4 File Offset: 0x00AC4DD4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_ATClearElementEnergy_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Element/GE_ATClearElementEnergy.GE_ATClearElementEnergy_C");
			}
			return GE_ATClearElementEnergy_C._ClassPtr;
		}

		// Token: 0x0602DADB RID: 187099 RVA: 0x00AC6BF8 File Offset: 0x00AC4DF8
		public GE_ATClearElementEnergy_C() : this(BuiltinUtils.AllocNativeUObject(GE_ATClearElementEnergy_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DADC RID: 187100 RVA: 0x00AC6C20 File Offset: 0x00AC4E20
		[NullableContext(1)]
		public GE_ATClearElementEnergy_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_ATClearElementEnergy_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DADD RID: 187101 RVA: 0x00AC6C53 File Offset: 0x00AC4E53
		protected GE_ATClearElementEnergy_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C2D RID: 105517
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Element/GE_ATClearElementEnergy.GE_ATClearElementEnergy_C";

		// Token: 0x04019C2E RID: 105518
		private static IntPtr _ClassPtr;

		// Token: 0x04019C2F RID: 105519
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
