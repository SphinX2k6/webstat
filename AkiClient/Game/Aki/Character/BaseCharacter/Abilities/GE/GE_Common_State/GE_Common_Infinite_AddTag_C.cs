using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_State
{
	// Token: 0x0200434B RID: 17227
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_State/GE_Common_Infinite_AddTag.GE_Common_Infinite_AddTag_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Common_Infinite_AddTag_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DA9A RID: 187034 RVA: 0x00AC6354 File Offset: 0x00AC4554
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Common_Infinite_AddTag_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_State/GE_Common_Infinite_AddTag.GE_Common_Infinite_AddTag_C");
			}
			return GE_Common_Infinite_AddTag_C._ClassPtr;
		}

		// Token: 0x0602DA9B RID: 187035 RVA: 0x00AC6378 File Offset: 0x00AC4578
		public GE_Common_Infinite_AddTag_C() : this(BuiltinUtils.AllocNativeUObject(GE_Common_Infinite_AddTag_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DA9C RID: 187036 RVA: 0x00AC63A0 File Offset: 0x00AC45A0
		[NullableContext(1)]
		public GE_Common_Infinite_AddTag_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Common_Infinite_AddTag_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DA9D RID: 187037 RVA: 0x00AC63D3 File Offset: 0x00AC45D3
		protected GE_Common_Infinite_AddTag_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019BFD RID: 105469
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_State/GE_Common_Infinite_AddTag.GE_Common_Infinite_AddTag_C";

		// Token: 0x04019BFE RID: 105470
		private static IntPtr _ClassPtr;

		// Token: 0x04019BFF RID: 105471
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
