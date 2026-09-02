using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Sample
{
	// Token: 0x02004338 RID: 17208
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Sample/GE_AttributeModifier.GE_AttributeModifier_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_AttributeModifier_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DA4C RID: 186956 RVA: 0x00AC57E4 File Offset: 0x00AC39E4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_AttributeModifier_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Sample/GE_AttributeModifier.GE_AttributeModifier_C");
			}
			return GE_AttributeModifier_C._ClassPtr;
		}

		// Token: 0x0602DA4D RID: 186957 RVA: 0x00AC5808 File Offset: 0x00AC3A08
		public GE_AttributeModifier_C() : this(BuiltinUtils.AllocNativeUObject(GE_AttributeModifier_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DA4E RID: 186958 RVA: 0x00AC5830 File Offset: 0x00AC3A30
		[NullableContext(1)]
		public GE_AttributeModifier_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_AttributeModifier_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DA4F RID: 186959 RVA: 0x00AC5863 File Offset: 0x00AC3A63
		protected GE_AttributeModifier_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019BC3 RID: 105411
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Sample/GE_AttributeModifier.GE_AttributeModifier_C";

		// Token: 0x04019BC4 RID: 105412
		private static IntPtr _ClassPtr;

		// Token: 0x04019BC5 RID: 105413
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
