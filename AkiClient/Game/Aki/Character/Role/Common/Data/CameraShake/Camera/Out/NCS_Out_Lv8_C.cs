using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Out
{
	// Token: 0x0200404B RID: 16459
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Lv8.NCS_Out_Lv8_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Out_Lv8_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA91 RID: 174737 RVA: 0x00A5F9D8 File Offset: 0x00A5DBD8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Out_Lv8_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Lv8.NCS_Out_Lv8_C");
			}
			return NCS_Out_Lv8_C._ClassPtr;
		}

		// Token: 0x0602AA92 RID: 174738 RVA: 0x00A5F9FC File Offset: 0x00A5DBFC
		public NCS_Out_Lv8_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Out_Lv8_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA93 RID: 174739 RVA: 0x00A5FA24 File Offset: 0x00A5DC24
		[NullableContext(1)]
		public NCS_Out_Lv8_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Out_Lv8_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA94 RID: 174740 RVA: 0x00A5FA57 File Offset: 0x00A5DC57
		protected NCS_Out_Lv8_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017382 RID: 95106
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Lv8.NCS_Out_Lv8_C";

		// Token: 0x04017383 RID: 95107
		private static IntPtr _ClassPtr;

		// Token: 0x04017384 RID: 95108
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
