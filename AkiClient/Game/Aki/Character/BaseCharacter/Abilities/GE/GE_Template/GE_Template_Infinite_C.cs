using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Template
{
	// Token: 0x02004334 RID: 17204
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Template/GE_Template_Infinite.GE_Template_Infinite_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Template_Infinite_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DA35 RID: 186933 RVA: 0x00AC54D0 File Offset: 0x00AC36D0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Template_Infinite_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Template/GE_Template_Infinite.GE_Template_Infinite_C");
			}
			return GE_Template_Infinite_C._ClassPtr;
		}

		// Token: 0x0602DA36 RID: 186934 RVA: 0x00AC54F4 File Offset: 0x00AC36F4
		public GE_Template_Infinite_C() : this(BuiltinUtils.AllocNativeUObject(GE_Template_Infinite_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DA37 RID: 186935 RVA: 0x00AC551C File Offset: 0x00AC371C
		[NullableContext(1)]
		public GE_Template_Infinite_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Template_Infinite_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DA38 RID: 186936 RVA: 0x00AC554F File Offset: 0x00AC374F
		protected GE_Template_Infinite_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019BB2 RID: 105394
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Template/GE_Template_Infinite.GE_Template_Infinite_C";

		// Token: 0x04019BB3 RID: 105395
		private static IntPtr _ClassPtr;

		// Token: 0x04019BB4 RID: 105396
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
