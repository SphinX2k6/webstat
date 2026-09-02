using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_Element.Camera
{
	// Token: 0x02004364 RID: 17252
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Element/Camera/BP_Fx_Shake_FireWind.BP_Fx_Shake_FireWind_C")]
	[UnrealStructLayout(416, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 416)]
	public class BP_Fx_Shake_FireWind_C : UMatineeCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DAFE RID: 187134 RVA: 0x00AC709C File Offset: 0x00AC529C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Fx_Shake_FireWind_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Element/Camera/BP_Fx_Shake_FireWind.BP_Fx_Shake_FireWind_C");
			}
			return BP_Fx_Shake_FireWind_C._ClassPtr;
		}

		// Token: 0x0602DAFF RID: 187135 RVA: 0x00AC70C0 File Offset: 0x00AC52C0
		public BP_Fx_Shake_FireWind_C() : this(BuiltinUtils.AllocNativeUObject(BP_Fx_Shake_FireWind_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DB00 RID: 187136 RVA: 0x00AC70E8 File Offset: 0x00AC52E8
		[NullableContext(1)]
		public BP_Fx_Shake_FireWind_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Fx_Shake_FireWind_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DB01 RID: 187137 RVA: 0x00AC711B File Offset: 0x00AC531B
		protected BP_Fx_Shake_FireWind_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C48 RID: 105544
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Element/Camera/BP_Fx_Shake_FireWind.BP_Fx_Shake_FireWind_C";

		// Token: 0x04019C49 RID: 105545
		private static IntPtr _ClassPtr;

		// Token: 0x04019C4A RID: 105546
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
