using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera
{
	// Token: 0x02004014 RID: 16404
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Block_Perfect.NCS_Block_Perfect_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Block_Perfect_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602A9B5 RID: 174517 RVA: 0x00A5DCA0 File Offset: 0x00A5BEA0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Block_Perfect_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Block_Perfect.NCS_Block_Perfect_C");
			}
			return NCS_Block_Perfect_C._ClassPtr;
		}

		// Token: 0x0602A9B6 RID: 174518 RVA: 0x00A5DCC4 File Offset: 0x00A5BEC4
		public NCS_Block_Perfect_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Block_Perfect_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602A9B7 RID: 174519 RVA: 0x00A5DCEC File Offset: 0x00A5BEEC
		[NullableContext(1)]
		public NCS_Block_Perfect_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Block_Perfect_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602A9B8 RID: 174520 RVA: 0x00A5DD1F File Offset: 0x00A5BF1F
		protected NCS_Block_Perfect_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040172DD RID: 94941
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Block_Perfect.NCS_Block_Perfect_C";

		// Token: 0x040172DE RID: 94942
		private static IntPtr _ClassPtr;

		// Token: 0x040172DF RID: 94943
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
