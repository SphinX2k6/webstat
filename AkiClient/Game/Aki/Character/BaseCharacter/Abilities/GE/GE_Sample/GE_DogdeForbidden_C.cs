using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Sample
{
	// Token: 0x0200433B RID: 17211
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Sample/GE_DogdeForbidden.GE_DogdeForbidden_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_DogdeForbidden_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DA58 RID: 186968 RVA: 0x00AC597C File Offset: 0x00AC3B7C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_DogdeForbidden_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Sample/GE_DogdeForbidden.GE_DogdeForbidden_C");
			}
			return GE_DogdeForbidden_C._ClassPtr;
		}

		// Token: 0x0602DA59 RID: 186969 RVA: 0x00AC59A0 File Offset: 0x00AC3BA0
		public GE_DogdeForbidden_C() : this(BuiltinUtils.AllocNativeUObject(GE_DogdeForbidden_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DA5A RID: 186970 RVA: 0x00AC59C8 File Offset: 0x00AC3BC8
		[NullableContext(1)]
		public GE_DogdeForbidden_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_DogdeForbidden_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DA5B RID: 186971 RVA: 0x00AC59FB File Offset: 0x00AC3BFB
		protected GE_DogdeForbidden_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019BCC RID: 105420
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Sample/GE_DogdeForbidden.GE_DogdeForbidden_C";

		// Token: 0x04019BCD RID: 105421
		private static IntPtr _ClassPtr;

		// Token: 0x04019BCE RID: 105422
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
