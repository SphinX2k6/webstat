using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Sample
{
	// Token: 0x0200433C RID: 17212
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Sample/GE_Frozen.GE_Frozen_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Frozen_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DA5C RID: 186972 RVA: 0x00AC5A04 File Offset: 0x00AC3C04
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Frozen_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Sample/GE_Frozen.GE_Frozen_C");
			}
			return GE_Frozen_C._ClassPtr;
		}

		// Token: 0x0602DA5D RID: 186973 RVA: 0x00AC5A28 File Offset: 0x00AC3C28
		public GE_Frozen_C() : this(BuiltinUtils.AllocNativeUObject(GE_Frozen_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DA5E RID: 186974 RVA: 0x00AC5A50 File Offset: 0x00AC3C50
		[NullableContext(1)]
		public GE_Frozen_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Frozen_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DA5F RID: 186975 RVA: 0x00AC5A83 File Offset: 0x00AC3C83
		protected GE_Frozen_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019BCF RID: 105423
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Sample/GE_Frozen.GE_Frozen_C";

		// Token: 0x04019BD0 RID: 105424
		private static IntPtr _ClassPtr;

		// Token: 0x04019BD1 RID: 105425
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
