using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_WhiteBar
{
	// Token: 0x02004344 RID: 17220
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_WhiteBar/GE_Common_WhiteBarRegen.GE_Common_WhiteBarRegen_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Common_WhiteBarRegen_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DA7E RID: 187006 RVA: 0x00AC5F9C File Offset: 0x00AC419C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Common_WhiteBarRegen_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_WhiteBar/GE_Common_WhiteBarRegen.GE_Common_WhiteBarRegen_C");
			}
			return GE_Common_WhiteBarRegen_C._ClassPtr;
		}

		// Token: 0x0602DA7F RID: 187007 RVA: 0x00AC5FC0 File Offset: 0x00AC41C0
		public GE_Common_WhiteBarRegen_C() : this(BuiltinUtils.AllocNativeUObject(GE_Common_WhiteBarRegen_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DA80 RID: 187008 RVA: 0x00AC5FE8 File Offset: 0x00AC41E8
		[NullableContext(1)]
		public GE_Common_WhiteBarRegen_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Common_WhiteBarRegen_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DA81 RID: 187009 RVA: 0x00AC601B File Offset: 0x00AC421B
		protected GE_Common_WhiteBarRegen_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019BE8 RID: 105448
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_WhiteBar/GE_Common_WhiteBarRegen.GE_Common_WhiteBarRegen_C";

		// Token: 0x04019BE9 RID: 105449
		private static IntPtr _ClassPtr;

		// Token: 0x04019BEA RID: 105450
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
