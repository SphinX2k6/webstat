using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Sample
{
	// Token: 0x02004340 RID: 17216
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Sample/GE_Stun.GE_Stun_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Stun_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DA6C RID: 186988 RVA: 0x00AC5C24 File Offset: 0x00AC3E24
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Stun_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Sample/GE_Stun.GE_Stun_C");
			}
			return GE_Stun_C._ClassPtr;
		}

		// Token: 0x0602DA6D RID: 186989 RVA: 0x00AC5C48 File Offset: 0x00AC3E48
		public GE_Stun_C() : this(BuiltinUtils.AllocNativeUObject(GE_Stun_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DA6E RID: 186990 RVA: 0x00AC5C70 File Offset: 0x00AC3E70
		[NullableContext(1)]
		public GE_Stun_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Stun_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DA6F RID: 186991 RVA: 0x00AC5CA3 File Offset: 0x00AC3EA3
		protected GE_Stun_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019BDB RID: 105435
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Sample/GE_Stun.GE_Stun_C";

		// Token: 0x04019BDC RID: 105436
		private static IntPtr _ClassPtr;

		// Token: 0x04019BDD RID: 105437
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
