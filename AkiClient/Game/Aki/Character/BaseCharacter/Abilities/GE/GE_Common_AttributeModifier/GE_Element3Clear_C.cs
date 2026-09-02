using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_AttributeModifier
{
	// Token: 0x0200436B RID: 17259
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_Element3Clear.GE_Element3Clear_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Element3Clear_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DB1A RID: 187162 RVA: 0x00AC7454 File Offset: 0x00AC5654
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Element3Clear_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_Element3Clear.GE_Element3Clear_C");
			}
			return GE_Element3Clear_C._ClassPtr;
		}

		// Token: 0x0602DB1B RID: 187163 RVA: 0x00AC7478 File Offset: 0x00AC5678
		public GE_Element3Clear_C() : this(BuiltinUtils.AllocNativeUObject(GE_Element3Clear_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DB1C RID: 187164 RVA: 0x00AC74A0 File Offset: 0x00AC56A0
		[NullableContext(1)]
		public GE_Element3Clear_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Element3Clear_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DB1D RID: 187165 RVA: 0x00AC74D3 File Offset: 0x00AC56D3
		protected GE_Element3Clear_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C5D RID: 105565
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_Element3Clear.GE_Element3Clear_C";

		// Token: 0x04019C5E RID: 105566
		private static IntPtr _ClassPtr;

		// Token: 0x04019C5F RID: 105567
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
