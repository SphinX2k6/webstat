using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera
{
	// Token: 0x02004013 RID: 16403
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Block_Nomal.NCS_Block_Nomal_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Block_Nomal_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602A9B1 RID: 174513 RVA: 0x00A5DC18 File Offset: 0x00A5BE18
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Block_Nomal_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Block_Nomal.NCS_Block_Nomal_C");
			}
			return NCS_Block_Nomal_C._ClassPtr;
		}

		// Token: 0x0602A9B2 RID: 174514 RVA: 0x00A5DC3C File Offset: 0x00A5BE3C
		public NCS_Block_Nomal_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Block_Nomal_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602A9B3 RID: 174515 RVA: 0x00A5DC64 File Offset: 0x00A5BE64
		[NullableContext(1)]
		public NCS_Block_Nomal_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Block_Nomal_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602A9B4 RID: 174516 RVA: 0x00A5DC97 File Offset: 0x00A5BE97
		protected NCS_Block_Nomal_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040172DA RID: 94938
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/NCS_Block_Nomal.NCS_Block_Nomal_C";

		// Token: 0x040172DB RID: 94939
		private static IntPtr _ClassPtr;

		// Token: 0x040172DC RID: 94940
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
