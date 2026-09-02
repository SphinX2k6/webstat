using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_State
{
	// Token: 0x0200434C RID: 17228
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_State/GE_CounterAttack.GE_CounterAttack_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_CounterAttack_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DA9E RID: 187038 RVA: 0x00AC63DC File Offset: 0x00AC45DC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_CounterAttack_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_State/GE_CounterAttack.GE_CounterAttack_C");
			}
			return GE_CounterAttack_C._ClassPtr;
		}

		// Token: 0x0602DA9F RID: 187039 RVA: 0x00AC6400 File Offset: 0x00AC4600
		public GE_CounterAttack_C() : this(BuiltinUtils.AllocNativeUObject(GE_CounterAttack_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DAA0 RID: 187040 RVA: 0x00AC6428 File Offset: 0x00AC4628
		[NullableContext(1)]
		public GE_CounterAttack_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_CounterAttack_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DAA1 RID: 187041 RVA: 0x00AC645B File Offset: 0x00AC465B
		protected GE_CounterAttack_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C00 RID: 105472
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_State/GE_CounterAttack.GE_CounterAttack_C";

		// Token: 0x04019C01 RID: 105473
		private static IntPtr _ClassPtr;

		// Token: 0x04019C02 RID: 105474
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
