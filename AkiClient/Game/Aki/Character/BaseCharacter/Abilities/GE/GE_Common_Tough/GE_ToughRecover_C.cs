using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_Tough
{
	// Token: 0x02004347 RID: 17223
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Tough/GE_ToughRecover.GE_ToughRecover_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_ToughRecover_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DA8A RID: 187018 RVA: 0x00AC6134 File Offset: 0x00AC4334
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_ToughRecover_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Tough/GE_ToughRecover.GE_ToughRecover_C");
			}
			return GE_ToughRecover_C._ClassPtr;
		}

		// Token: 0x0602DA8B RID: 187019 RVA: 0x00AC6158 File Offset: 0x00AC4358
		public GE_ToughRecover_C() : this(BuiltinUtils.AllocNativeUObject(GE_ToughRecover_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DA8C RID: 187020 RVA: 0x00AC6180 File Offset: 0x00AC4380
		[NullableContext(1)]
		public GE_ToughRecover_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_ToughRecover_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DA8D RID: 187021 RVA: 0x00AC61B3 File Offset: 0x00AC43B3
		protected GE_ToughRecover_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019BF1 RID: 105457
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Tough/GE_ToughRecover.GE_ToughRecover_C";

		// Token: 0x04019BF2 RID: 105458
		private static IntPtr _ClassPtr;

		// Token: 0x04019BF3 RID: 105459
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
