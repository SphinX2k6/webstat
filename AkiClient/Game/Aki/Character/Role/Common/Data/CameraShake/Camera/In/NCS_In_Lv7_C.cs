using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.In
{
	// Token: 0x0200405F RID: 16479
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/In/NCS_In_Lv7.NCS_In_Lv7_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_In_Lv7_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AAE1 RID: 174817 RVA: 0x00A60478 File Offset: 0x00A5E678
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_In_Lv7_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/In/NCS_In_Lv7.NCS_In_Lv7_C");
			}
			return NCS_In_Lv7_C._ClassPtr;
		}

		// Token: 0x0602AAE2 RID: 174818 RVA: 0x00A6049C File Offset: 0x00A5E69C
		public NCS_In_Lv7_C() : this(BuiltinUtils.AllocNativeUObject(NCS_In_Lv7_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AAE3 RID: 174819 RVA: 0x00A604C4 File Offset: 0x00A5E6C4
		[NullableContext(1)]
		public NCS_In_Lv7_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_In_Lv7_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AAE4 RID: 174820 RVA: 0x00A604F7 File Offset: 0x00A5E6F7
		protected NCS_In_Lv7_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040173BE RID: 95166
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/In/NCS_In_Lv7.NCS_In_Lv7_C";

		// Token: 0x040173BF RID: 95167
		private static IntPtr _ClassPtr;

		// Token: 0x040173C0 RID: 95168
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
