using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Sample
{
	// Token: 0x02004339 RID: 17209
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Sample/GE_ChangeEnergy.GE_ChangeEnergy_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_ChangeEnergy_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DA50 RID: 186960 RVA: 0x00AC586C File Offset: 0x00AC3A6C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_ChangeEnergy_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Sample/GE_ChangeEnergy.GE_ChangeEnergy_C");
			}
			return GE_ChangeEnergy_C._ClassPtr;
		}

		// Token: 0x0602DA51 RID: 186961 RVA: 0x00AC5890 File Offset: 0x00AC3A90
		public GE_ChangeEnergy_C() : this(BuiltinUtils.AllocNativeUObject(GE_ChangeEnergy_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DA52 RID: 186962 RVA: 0x00AC58B8 File Offset: 0x00AC3AB8
		[NullableContext(1)]
		public GE_ChangeEnergy_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_ChangeEnergy_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DA53 RID: 186963 RVA: 0x00AC58EB File Offset: 0x00AC3AEB
		protected GE_ChangeEnergy_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019BC6 RID: 105414
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Sample/GE_ChangeEnergy.GE_ChangeEnergy_C";

		// Token: 0x04019BC7 RID: 105415
		private static IntPtr _ClassPtr;

		// Token: 0x04019BC8 RID: 105416
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
