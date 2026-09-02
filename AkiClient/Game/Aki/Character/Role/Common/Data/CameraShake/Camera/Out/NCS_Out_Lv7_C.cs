using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Out
{
	// Token: 0x0200404A RID: 16458
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Lv7.NCS_Out_Lv7_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Out_Lv7_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA8D RID: 174733 RVA: 0x00A5F950 File Offset: 0x00A5DB50
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Out_Lv7_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Lv7.NCS_Out_Lv7_C");
			}
			return NCS_Out_Lv7_C._ClassPtr;
		}

		// Token: 0x0602AA8E RID: 174734 RVA: 0x00A5F974 File Offset: 0x00A5DB74
		public NCS_Out_Lv7_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Out_Lv7_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA8F RID: 174735 RVA: 0x00A5F99C File Offset: 0x00A5DB9C
		[NullableContext(1)]
		public NCS_Out_Lv7_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Out_Lv7_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA90 RID: 174736 RVA: 0x00A5F9CF File Offset: 0x00A5DBCF
		protected NCS_Out_Lv7_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401737F RID: 95103
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Lv7.NCS_Out_Lv7_C";

		// Token: 0x04017380 RID: 95104
		private static IntPtr _ClassPtr;

		// Token: 0x04017381 RID: 95105
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
