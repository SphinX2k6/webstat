using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Down
{
	// Token: 0x02004062 RID: 16482
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Down/NCS_Down_Lv10.NCS_Down_Lv10_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Down_Lv10_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AAED RID: 174829 RVA: 0x00A60610 File Offset: 0x00A5E810
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Down_Lv10_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Down/NCS_Down_Lv10.NCS_Down_Lv10_C");
			}
			return NCS_Down_Lv10_C._ClassPtr;
		}

		// Token: 0x0602AAEE RID: 174830 RVA: 0x00A60634 File Offset: 0x00A5E834
		public NCS_Down_Lv10_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Down_Lv10_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AAEF RID: 174831 RVA: 0x00A6065C File Offset: 0x00A5E85C
		[NullableContext(1)]
		public NCS_Down_Lv10_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Down_Lv10_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AAF0 RID: 174832 RVA: 0x00A6068F File Offset: 0x00A5E88F
		protected NCS_Down_Lv10_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040173C7 RID: 95175
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Down/NCS_Down_Lv10.NCS_Down_Lv10_C";

		// Token: 0x040173C8 RID: 95176
		private static IntPtr _ClassPtr;

		// Token: 0x040173C9 RID: 95177
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
