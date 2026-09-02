using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_State
{
	// Token: 0x0200434D RID: 17229
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_State/GE_Dying.GE_Dying_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Dying_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DAA2 RID: 187042 RVA: 0x00AC6464 File Offset: 0x00AC4664
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Dying_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_State/GE_Dying.GE_Dying_C");
			}
			return GE_Dying_C._ClassPtr;
		}

		// Token: 0x0602DAA3 RID: 187043 RVA: 0x00AC6488 File Offset: 0x00AC4688
		public GE_Dying_C() : this(BuiltinUtils.AllocNativeUObject(GE_Dying_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DAA4 RID: 187044 RVA: 0x00AC64B0 File Offset: 0x00AC46B0
		[NullableContext(1)]
		public GE_Dying_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Dying_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DAA5 RID: 187045 RVA: 0x00AC64E3 File Offset: 0x00AC46E3
		protected GE_Dying_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C03 RID: 105475
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_State/GE_Dying.GE_Dying_C";

		// Token: 0x04019C04 RID: 105476
		private static IntPtr _ClassPtr;

		// Token: 0x04019C05 RID: 105477
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
