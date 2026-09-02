using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_AttributeModifier
{
	// Token: 0x0200436C RID: 17260
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_Element4Clear.GE_Element4Clear_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Element4Clear_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DB1E RID: 187166 RVA: 0x00AC74DC File Offset: 0x00AC56DC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Element4Clear_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_Element4Clear.GE_Element4Clear_C");
			}
			return GE_Element4Clear_C._ClassPtr;
		}

		// Token: 0x0602DB1F RID: 187167 RVA: 0x00AC7500 File Offset: 0x00AC5700
		public GE_Element4Clear_C() : this(BuiltinUtils.AllocNativeUObject(GE_Element4Clear_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DB20 RID: 187168 RVA: 0x00AC7528 File Offset: 0x00AC5728
		[NullableContext(1)]
		public GE_Element4Clear_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Element4Clear_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DB21 RID: 187169 RVA: 0x00AC755B File Offset: 0x00AC575B
		protected GE_Element4Clear_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C60 RID: 105568
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_Element4Clear.GE_Element4Clear_C";

		// Token: 0x04019C61 RID: 105569
		private static IntPtr _ClassPtr;

		// Token: 0x04019C62 RID: 105570
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
