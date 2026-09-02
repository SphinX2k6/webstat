using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Template
{
	// Token: 0x02004332 RID: 17202
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Template/GE_Template_Duration.GE_Template_Duration_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Template_Duration_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DA2D RID: 186925 RVA: 0x00AC53C0 File Offset: 0x00AC35C0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Template_Duration_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Template/GE_Template_Duration.GE_Template_Duration_C");
			}
			return GE_Template_Duration_C._ClassPtr;
		}

		// Token: 0x0602DA2E RID: 186926 RVA: 0x00AC53E4 File Offset: 0x00AC35E4
		public GE_Template_Duration_C() : this(BuiltinUtils.AllocNativeUObject(GE_Template_Duration_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DA2F RID: 186927 RVA: 0x00AC540C File Offset: 0x00AC360C
		[NullableContext(1)]
		public GE_Template_Duration_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Template_Duration_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DA30 RID: 186928 RVA: 0x00AC543F File Offset: 0x00AC363F
		protected GE_Template_Duration_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019BAC RID: 105388
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Template/GE_Template_Duration.GE_Template_Duration_C";

		// Token: 0x04019BAD RID: 105389
		private static IntPtr _ClassPtr;

		// Token: 0x04019BAE RID: 105390
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
