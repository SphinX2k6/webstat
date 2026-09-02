using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Sample
{
	// Token: 0x0200433A RID: 17210
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Sample/GE_Damage.GE_Damage_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Damage_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DA54 RID: 186964 RVA: 0x00AC58F4 File Offset: 0x00AC3AF4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Damage_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Sample/GE_Damage.GE_Damage_C");
			}
			return GE_Damage_C._ClassPtr;
		}

		// Token: 0x0602DA55 RID: 186965 RVA: 0x00AC5918 File Offset: 0x00AC3B18
		public GE_Damage_C() : this(BuiltinUtils.AllocNativeUObject(GE_Damage_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DA56 RID: 186966 RVA: 0x00AC5940 File Offset: 0x00AC3B40
		[NullableContext(1)]
		public GE_Damage_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Damage_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DA57 RID: 186967 RVA: 0x00AC5973 File Offset: 0x00AC3B73
		protected GE_Damage_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019BC9 RID: 105417
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Sample/GE_Damage.GE_Damage_C";

		// Token: 0x04019BCA RID: 105418
		private static IntPtr _ClassPtr;

		// Token: 0x04019BCB RID: 105419
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
