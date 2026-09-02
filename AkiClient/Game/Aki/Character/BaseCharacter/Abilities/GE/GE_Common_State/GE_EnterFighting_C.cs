using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_State
{
	// Token: 0x0200434E RID: 17230
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_State/GE_EnterFighting.GE_EnterFighting_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_EnterFighting_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DAA6 RID: 187046 RVA: 0x00AC64EC File Offset: 0x00AC46EC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_EnterFighting_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_State/GE_EnterFighting.GE_EnterFighting_C");
			}
			return GE_EnterFighting_C._ClassPtr;
		}

		// Token: 0x0602DAA7 RID: 187047 RVA: 0x00AC6510 File Offset: 0x00AC4710
		public GE_EnterFighting_C() : this(BuiltinUtils.AllocNativeUObject(GE_EnterFighting_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DAA8 RID: 187048 RVA: 0x00AC6538 File Offset: 0x00AC4738
		[NullableContext(1)]
		public GE_EnterFighting_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_EnterFighting_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DAA9 RID: 187049 RVA: 0x00AC656B File Offset: 0x00AC476B
		protected GE_EnterFighting_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C06 RID: 105478
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_State/GE_EnterFighting.GE_EnterFighting_C";

		// Token: 0x04019C07 RID: 105479
		private static IntPtr _ClassPtr;

		// Token: 0x04019C08 RID: 105480
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
