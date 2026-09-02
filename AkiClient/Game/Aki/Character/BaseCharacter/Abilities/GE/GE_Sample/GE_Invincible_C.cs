using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Sample
{
	// Token: 0x0200433E RID: 17214
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Sample/GE_Invincible.GE_Invincible_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Invincible_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DA64 RID: 186980 RVA: 0x00AC5B14 File Offset: 0x00AC3D14
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Invincible_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Sample/GE_Invincible.GE_Invincible_C");
			}
			return GE_Invincible_C._ClassPtr;
		}

		// Token: 0x0602DA65 RID: 186981 RVA: 0x00AC5B38 File Offset: 0x00AC3D38
		public GE_Invincible_C() : this(BuiltinUtils.AllocNativeUObject(GE_Invincible_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DA66 RID: 186982 RVA: 0x00AC5B60 File Offset: 0x00AC3D60
		[NullableContext(1)]
		public GE_Invincible_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Invincible_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DA67 RID: 186983 RVA: 0x00AC5B93 File Offset: 0x00AC3D93
		protected GE_Invincible_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019BD5 RID: 105429
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Sample/GE_Invincible.GE_Invincible_C";

		// Token: 0x04019BD6 RID: 105430
		private static IntPtr _ClassPtr;

		// Token: 0x04019BD7 RID: 105431
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
