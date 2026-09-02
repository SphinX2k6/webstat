using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Down
{
	// Token: 0x0200406A RID: 16490
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Down/NCS_Down_Lv7.NCS_Down_Lv7_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Down_Lv7_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AB0D RID: 174861 RVA: 0x00A60A50 File Offset: 0x00A5EC50
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Down_Lv7_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Down/NCS_Down_Lv7.NCS_Down_Lv7_C");
			}
			return NCS_Down_Lv7_C._ClassPtr;
		}

		// Token: 0x0602AB0E RID: 174862 RVA: 0x00A60A74 File Offset: 0x00A5EC74
		public NCS_Down_Lv7_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Down_Lv7_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AB0F RID: 174863 RVA: 0x00A60A9C File Offset: 0x00A5EC9C
		[NullableContext(1)]
		public NCS_Down_Lv7_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Down_Lv7_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AB10 RID: 174864 RVA: 0x00A60ACF File Offset: 0x00A5ECCF
		protected NCS_Down_Lv7_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040173DF RID: 95199
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Down/NCS_Down_Lv7.NCS_Down_Lv7_C";

		// Token: 0x040173E0 RID: 95200
		private static IntPtr _ClassPtr;

		// Token: 0x040173E1 RID: 95201
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
