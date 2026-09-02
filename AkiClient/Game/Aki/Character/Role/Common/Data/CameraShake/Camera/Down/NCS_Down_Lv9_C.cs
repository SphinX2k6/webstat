using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Down
{
	// Token: 0x0200406C RID: 16492
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Down/NCS_Down_Lv9.NCS_Down_Lv9_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Down_Lv9_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AB15 RID: 174869 RVA: 0x00A60B60 File Offset: 0x00A5ED60
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Down_Lv9_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Down/NCS_Down_Lv9.NCS_Down_Lv9_C");
			}
			return NCS_Down_Lv9_C._ClassPtr;
		}

		// Token: 0x0602AB16 RID: 174870 RVA: 0x00A60B84 File Offset: 0x00A5ED84
		public NCS_Down_Lv9_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Down_Lv9_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AB17 RID: 174871 RVA: 0x00A60BAC File Offset: 0x00A5EDAC
		[NullableContext(1)]
		public NCS_Down_Lv9_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Down_Lv9_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AB18 RID: 174872 RVA: 0x00A60BDF File Offset: 0x00A5EDDF
		protected NCS_Down_Lv9_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040173E5 RID: 95205
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Down/NCS_Down_Lv9.NCS_Down_Lv9_C";

		// Token: 0x040173E6 RID: 95206
		private static IntPtr _ClassPtr;

		// Token: 0x040173E7 RID: 95207
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
