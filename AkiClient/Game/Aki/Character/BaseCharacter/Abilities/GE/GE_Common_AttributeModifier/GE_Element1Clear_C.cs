using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_AttributeModifier
{
	// Token: 0x02004369 RID: 17257
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_Element1Clear.GE_Element1Clear_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Element1Clear_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DB12 RID: 187154 RVA: 0x00AC7344 File Offset: 0x00AC5544
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Element1Clear_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_Element1Clear.GE_Element1Clear_C");
			}
			return GE_Element1Clear_C._ClassPtr;
		}

		// Token: 0x0602DB13 RID: 187155 RVA: 0x00AC7368 File Offset: 0x00AC5568
		public GE_Element1Clear_C() : this(BuiltinUtils.AllocNativeUObject(GE_Element1Clear_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DB14 RID: 187156 RVA: 0x00AC7390 File Offset: 0x00AC5590
		[NullableContext(1)]
		public GE_Element1Clear_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Element1Clear_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DB15 RID: 187157 RVA: 0x00AC73C3 File Offset: 0x00AC55C3
		protected GE_Element1Clear_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C57 RID: 105559
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_Element1Clear.GE_Element1Clear_C";

		// Token: 0x04019C58 RID: 105560
		private static IntPtr _ClassPtr;

		// Token: 0x04019C59 RID: 105561
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
