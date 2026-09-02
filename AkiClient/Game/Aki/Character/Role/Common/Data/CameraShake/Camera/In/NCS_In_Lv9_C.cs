using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.In
{
	// Token: 0x02004061 RID: 16481
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/In/NCS_In_Lv9.NCS_In_Lv9_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_In_Lv9_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AAE9 RID: 174825 RVA: 0x00A60588 File Offset: 0x00A5E788
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_In_Lv9_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/In/NCS_In_Lv9.NCS_In_Lv9_C");
			}
			return NCS_In_Lv9_C._ClassPtr;
		}

		// Token: 0x0602AAEA RID: 174826 RVA: 0x00A605AC File Offset: 0x00A5E7AC
		public NCS_In_Lv9_C() : this(BuiltinUtils.AllocNativeUObject(NCS_In_Lv9_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AAEB RID: 174827 RVA: 0x00A605D4 File Offset: 0x00A5E7D4
		[NullableContext(1)]
		public NCS_In_Lv9_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_In_Lv9_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AAEC RID: 174828 RVA: 0x00A60607 File Offset: 0x00A5E807
		protected NCS_In_Lv9_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040173C4 RID: 95172
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/In/NCS_In_Lv9.NCS_In_Lv9_C";

		// Token: 0x040173C5 RID: 95173
		private static IntPtr _ClassPtr;

		// Token: 0x040173C6 RID: 95174
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
