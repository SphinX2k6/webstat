using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Sample
{
	// Token: 0x02004341 RID: 17217
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Sample/GE_SummonBullet.GE_SummonBullet_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_SummonBullet_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DA70 RID: 186992 RVA: 0x00AC5CAC File Offset: 0x00AC3EAC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_SummonBullet_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Sample/GE_SummonBullet.GE_SummonBullet_C");
			}
			return GE_SummonBullet_C._ClassPtr;
		}

		// Token: 0x0602DA71 RID: 186993 RVA: 0x00AC5CD0 File Offset: 0x00AC3ED0
		public GE_SummonBullet_C() : this(BuiltinUtils.AllocNativeUObject(GE_SummonBullet_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DA72 RID: 186994 RVA: 0x00AC5CF8 File Offset: 0x00AC3EF8
		[NullableContext(1)]
		public GE_SummonBullet_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_SummonBullet_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DA73 RID: 186995 RVA: 0x00AC5D2B File Offset: 0x00AC3F2B
		protected GE_SummonBullet_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019BDE RID: 105438
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Sample/GE_SummonBullet.GE_SummonBullet_C";

		// Token: 0x04019BDF RID: 105439
		private static IntPtr _ClassPtr;

		// Token: 0x04019BE0 RID: 105440
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
