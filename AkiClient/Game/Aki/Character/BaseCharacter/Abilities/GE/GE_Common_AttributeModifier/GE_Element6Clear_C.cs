using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_AttributeModifier
{
	// Token: 0x0200436E RID: 17262
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_Element6Clear.GE_Element6Clear_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Element6Clear_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DB26 RID: 187174 RVA: 0x00AC75EC File Offset: 0x00AC57EC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Element6Clear_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_Element6Clear.GE_Element6Clear_C");
			}
			return GE_Element6Clear_C._ClassPtr;
		}

		// Token: 0x0602DB27 RID: 187175 RVA: 0x00AC7610 File Offset: 0x00AC5810
		public GE_Element6Clear_C() : this(BuiltinUtils.AllocNativeUObject(GE_Element6Clear_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DB28 RID: 187176 RVA: 0x00AC7638 File Offset: 0x00AC5838
		[NullableContext(1)]
		public GE_Element6Clear_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Element6Clear_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DB29 RID: 187177 RVA: 0x00AC766B File Offset: 0x00AC586B
		protected GE_Element6Clear_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C66 RID: 105574
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_AttributeModifier/GE_Element6Clear.GE_Element6Clear_C";

		// Token: 0x04019C67 RID: 105575
		private static IntPtr _ClassPtr;

		// Token: 0x04019C68 RID: 105576
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
