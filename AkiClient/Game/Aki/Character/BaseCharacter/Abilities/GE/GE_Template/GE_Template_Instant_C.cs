using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Template
{
	// Token: 0x02004335 RID: 17205
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Template/GE_Template_Instant.GE_Template_Instant_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Template_Instant_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DA39 RID: 186937 RVA: 0x00AC5558 File Offset: 0x00AC3758
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Template_Instant_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Template/GE_Template_Instant.GE_Template_Instant_C");
			}
			return GE_Template_Instant_C._ClassPtr;
		}

		// Token: 0x0602DA3A RID: 186938 RVA: 0x00AC557C File Offset: 0x00AC377C
		public GE_Template_Instant_C() : this(BuiltinUtils.AllocNativeUObject(GE_Template_Instant_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DA3B RID: 186939 RVA: 0x00AC55A4 File Offset: 0x00AC37A4
		[NullableContext(1)]
		public GE_Template_Instant_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Template_Instant_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DA3C RID: 186940 RVA: 0x00AC55D7 File Offset: 0x00AC37D7
		protected GE_Template_Instant_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019BB5 RID: 105397
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Template/GE_Template_Instant.GE_Template_Instant_C";

		// Token: 0x04019BB6 RID: 105398
		private static IntPtr _ClassPtr;

		// Token: 0x04019BB7 RID: 105399
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
