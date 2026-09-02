using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.In
{
	// Token: 0x02004060 RID: 16480
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/In/NCS_In_Lv8.NCS_In_Lv8_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_In_Lv8_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AAE5 RID: 174821 RVA: 0x00A60500 File Offset: 0x00A5E700
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_In_Lv8_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/In/NCS_In_Lv8.NCS_In_Lv8_C");
			}
			return NCS_In_Lv8_C._ClassPtr;
		}

		// Token: 0x0602AAE6 RID: 174822 RVA: 0x00A60524 File Offset: 0x00A5E724
		public NCS_In_Lv8_C() : this(BuiltinUtils.AllocNativeUObject(NCS_In_Lv8_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AAE7 RID: 174823 RVA: 0x00A6054C File Offset: 0x00A5E74C
		[NullableContext(1)]
		public NCS_In_Lv8_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_In_Lv8_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AAE8 RID: 174824 RVA: 0x00A6057F File Offset: 0x00A5E77F
		protected NCS_In_Lv8_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040173C1 RID: 95169
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/In/NCS_In_Lv8.NCS_In_Lv8_C";

		// Token: 0x040173C2 RID: 95170
		private static IntPtr _ClassPtr;

		// Token: 0x040173C3 RID: 95171
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
