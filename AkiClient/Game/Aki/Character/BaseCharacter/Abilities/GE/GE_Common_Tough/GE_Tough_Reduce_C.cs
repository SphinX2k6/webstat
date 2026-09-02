using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_Tough
{
	// Token: 0x02004348 RID: 17224
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Tough/GE_Tough_Reduce.GE_Tough_Reduce_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Tough_Reduce_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DA8E RID: 187022 RVA: 0x00AC61BC File Offset: 0x00AC43BC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Tough_Reduce_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Tough/GE_Tough_Reduce.GE_Tough_Reduce_C");
			}
			return GE_Tough_Reduce_C._ClassPtr;
		}

		// Token: 0x0602DA8F RID: 187023 RVA: 0x00AC61E0 File Offset: 0x00AC43E0
		public GE_Tough_Reduce_C() : this(BuiltinUtils.AllocNativeUObject(GE_Tough_Reduce_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DA90 RID: 187024 RVA: 0x00AC6208 File Offset: 0x00AC4408
		[NullableContext(1)]
		public GE_Tough_Reduce_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Tough_Reduce_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DA91 RID: 187025 RVA: 0x00AC623B File Offset: 0x00AC443B
		protected GE_Tough_Reduce_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019BF4 RID: 105460
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Tough/GE_Tough_Reduce.GE_Tough_Reduce_C";

		// Token: 0x04019BF5 RID: 105461
		private static IntPtr _ClassPtr;

		// Token: 0x04019BF6 RID: 105462
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
