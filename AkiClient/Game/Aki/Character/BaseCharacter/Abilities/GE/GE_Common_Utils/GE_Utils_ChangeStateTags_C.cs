using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_Utils
{
	// Token: 0x02004345 RID: 17221
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Utils/GE_Utils_ChangeStateTags.GE_Utils_ChangeStateTags_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Utils_ChangeStateTags_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DA82 RID: 187010 RVA: 0x00AC6024 File Offset: 0x00AC4224
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Utils_ChangeStateTags_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Utils/GE_Utils_ChangeStateTags.GE_Utils_ChangeStateTags_C");
			}
			return GE_Utils_ChangeStateTags_C._ClassPtr;
		}

		// Token: 0x0602DA83 RID: 187011 RVA: 0x00AC6048 File Offset: 0x00AC4248
		public GE_Utils_ChangeStateTags_C() : this(BuiltinUtils.AllocNativeUObject(GE_Utils_ChangeStateTags_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DA84 RID: 187012 RVA: 0x00AC6070 File Offset: 0x00AC4270
		[NullableContext(1)]
		public GE_Utils_ChangeStateTags_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Utils_ChangeStateTags_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DA85 RID: 187013 RVA: 0x00AC60A3 File Offset: 0x00AC42A3
		protected GE_Utils_ChangeStateTags_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019BEB RID: 105451
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Utils/GE_Utils_ChangeStateTags.GE_Utils_ChangeStateTags_C";

		// Token: 0x04019BEC RID: 105452
		private static IntPtr _ClassPtr;

		// Token: 0x04019BED RID: 105453
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
