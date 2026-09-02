using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_Tough
{
	// Token: 0x02004346 RID: 17222
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Tough/GE_Common_ToughRegen.GE_Common_ToughRegen_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Common_ToughRegen_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DA86 RID: 187014 RVA: 0x00AC60AC File Offset: 0x00AC42AC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Common_ToughRegen_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Tough/GE_Common_ToughRegen.GE_Common_ToughRegen_C");
			}
			return GE_Common_ToughRegen_C._ClassPtr;
		}

		// Token: 0x0602DA87 RID: 187015 RVA: 0x00AC60D0 File Offset: 0x00AC42D0
		public GE_Common_ToughRegen_C() : this(BuiltinUtils.AllocNativeUObject(GE_Common_ToughRegen_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DA88 RID: 187016 RVA: 0x00AC60F8 File Offset: 0x00AC42F8
		[NullableContext(1)]
		public GE_Common_ToughRegen_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Common_ToughRegen_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DA89 RID: 187017 RVA: 0x00AC612B File Offset: 0x00AC432B
		protected GE_Common_ToughRegen_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019BEE RID: 105454
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Tough/GE_Common_ToughRegen.GE_Common_ToughRegen_C";

		// Token: 0x04019BEF RID: 105455
		private static IntPtr _ClassPtr;

		// Token: 0x04019BF0 RID: 105456
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
