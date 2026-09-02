using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Sample
{
	// Token: 0x0200433D RID: 17213
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Sample/GE_Heal.GE_Heal_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Heal_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DA60 RID: 186976 RVA: 0x00AC5A8C File Offset: 0x00AC3C8C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Heal_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Sample/GE_Heal.GE_Heal_C");
			}
			return GE_Heal_C._ClassPtr;
		}

		// Token: 0x0602DA61 RID: 186977 RVA: 0x00AC5AB0 File Offset: 0x00AC3CB0
		public GE_Heal_C() : this(BuiltinUtils.AllocNativeUObject(GE_Heal_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DA62 RID: 186978 RVA: 0x00AC5AD8 File Offset: 0x00AC3CD8
		[NullableContext(1)]
		public GE_Heal_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Heal_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DA63 RID: 186979 RVA: 0x00AC5B0B File Offset: 0x00AC3D0B
		protected GE_Heal_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019BD2 RID: 105426
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Sample/GE_Heal.GE_Heal_C";

		// Token: 0x04019BD3 RID: 105427
		private static IntPtr _ClassPtr;

		// Token: 0x04019BD4 RID: 105428
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
