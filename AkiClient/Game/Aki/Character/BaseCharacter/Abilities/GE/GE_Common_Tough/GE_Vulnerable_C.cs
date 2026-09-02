using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_Tough
{
	// Token: 0x0200434A RID: 17226
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Tough/GE_Vulnerable.GE_Vulnerable_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Vulnerable_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DA96 RID: 187030 RVA: 0x00AC62CC File Offset: 0x00AC44CC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Vulnerable_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Tough/GE_Vulnerable.GE_Vulnerable_C");
			}
			return GE_Vulnerable_C._ClassPtr;
		}

		// Token: 0x0602DA97 RID: 187031 RVA: 0x00AC62F0 File Offset: 0x00AC44F0
		public GE_Vulnerable_C() : this(BuiltinUtils.AllocNativeUObject(GE_Vulnerable_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DA98 RID: 187032 RVA: 0x00AC6318 File Offset: 0x00AC4518
		[NullableContext(1)]
		public GE_Vulnerable_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Vulnerable_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DA99 RID: 187033 RVA: 0x00AC634B File Offset: 0x00AC454B
		protected GE_Vulnerable_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019BFA RID: 105466
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Tough/GE_Vulnerable.GE_Vulnerable_C";

		// Token: 0x04019BFB RID: 105467
		private static IntPtr _ClassPtr;

		// Token: 0x04019BFC RID: 105468
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
