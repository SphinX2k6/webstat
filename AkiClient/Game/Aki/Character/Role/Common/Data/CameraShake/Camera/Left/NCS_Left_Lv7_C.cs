using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Left
{
	// Token: 0x02004055 RID: 16469
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Left/NCS_Left_Lv7.NCS_Left_Lv7_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Left_Lv7_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AAB9 RID: 174777 RVA: 0x00A5FF28 File Offset: 0x00A5E128
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Left_Lv7_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Left/NCS_Left_Lv7.NCS_Left_Lv7_C");
			}
			return NCS_Left_Lv7_C._ClassPtr;
		}

		// Token: 0x0602AABA RID: 174778 RVA: 0x00A5FF4C File Offset: 0x00A5E14C
		public NCS_Left_Lv7_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Left_Lv7_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AABB RID: 174779 RVA: 0x00A5FF74 File Offset: 0x00A5E174
		[NullableContext(1)]
		public NCS_Left_Lv7_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Left_Lv7_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AABC RID: 174780 RVA: 0x00A5FFA7 File Offset: 0x00A5E1A7
		protected NCS_Left_Lv7_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040173A0 RID: 95136
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Left/NCS_Left_Lv7.NCS_Left_Lv7_C";

		// Token: 0x040173A1 RID: 95137
		private static IntPtr _ClassPtr;

		// Token: 0x040173A2 RID: 95138
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
