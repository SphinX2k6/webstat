using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x020042E8 RID: 17128
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/BP_CameraShake.BP_CameraShake_C")]
	[UnrealStructLayout(416, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 416)]
	public class BP_CameraShake_C : UMatineeCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D6DE RID: 186078 RVA: 0x00ABFE4D File Offset: 0x00ABE04D
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CameraShake_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Camera/BP_CameraShake.BP_CameraShake_C");
			}
			return BP_CameraShake_C._ClassPtr;
		}

		// Token: 0x0602D6DF RID: 186079 RVA: 0x00ABFE74 File Offset: 0x00ABE074
		public BP_CameraShake_C() : this(BuiltinUtils.AllocNativeUObject(BP_CameraShake_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D6E0 RID: 186080 RVA: 0x00ABFE9C File Offset: 0x00ABE09C
		[NullableContext(1)]
		public BP_CameraShake_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CameraShake_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602D6E1 RID: 186081 RVA: 0x00ABFECF File Offset: 0x00ABE0CF
		protected BP_CameraShake_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040197BC RID: 104380
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Camera/BP_CameraShake.BP_CameraShake_C";

		// Token: 0x040197BD RID: 104381
		private static IntPtr _ClassPtr;

		// Token: 0x040197BE RID: 104382
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
