using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_WhiteBar
{
	// Token: 0x02004343 RID: 17219
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_WhiteBar/GE_Common_WhiteBarPunish.GE_Common_WhiteBarPunish_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Common_WhiteBarPunish_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DA7A RID: 187002 RVA: 0x00AC5F13 File Offset: 0x00AC4113
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Common_WhiteBarPunish_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_WhiteBar/GE_Common_WhiteBarPunish.GE_Common_WhiteBarPunish_C");
			}
			return GE_Common_WhiteBarPunish_C._ClassPtr;
		}

		// Token: 0x0602DA7B RID: 187003 RVA: 0x00AC5F38 File Offset: 0x00AC4138
		public GE_Common_WhiteBarPunish_C() : this(BuiltinUtils.AllocNativeUObject(GE_Common_WhiteBarPunish_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DA7C RID: 187004 RVA: 0x00AC5F60 File Offset: 0x00AC4160
		[NullableContext(1)]
		public GE_Common_WhiteBarPunish_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Common_WhiteBarPunish_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DA7D RID: 187005 RVA: 0x00AC5F93 File Offset: 0x00AC4193
		protected GE_Common_WhiteBarPunish_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019BE5 RID: 105445
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_WhiteBar/GE_Common_WhiteBarPunish.GE_Common_WhiteBarPunish_C";

		// Token: 0x04019BE6 RID: 105446
		private static IntPtr _ClassPtr;

		// Token: 0x04019BE7 RID: 105447
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
