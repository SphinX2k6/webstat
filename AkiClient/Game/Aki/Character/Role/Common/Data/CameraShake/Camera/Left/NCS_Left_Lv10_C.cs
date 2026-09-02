using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Left
{
	// Token: 0x0200404E RID: 16462
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Left/NCS_Left_Lv10.NCS_Left_Lv10_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Left_Lv10_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA9D RID: 174749 RVA: 0x00A5FB70 File Offset: 0x00A5DD70
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Left_Lv10_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Left/NCS_Left_Lv10.NCS_Left_Lv10_C");
			}
			return NCS_Left_Lv10_C._ClassPtr;
		}

		// Token: 0x0602AA9E RID: 174750 RVA: 0x00A5FB94 File Offset: 0x00A5DD94
		public NCS_Left_Lv10_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Left_Lv10_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA9F RID: 174751 RVA: 0x00A5FBBC File Offset: 0x00A5DDBC
		[NullableContext(1)]
		public NCS_Left_Lv10_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Left_Lv10_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AAA0 RID: 174752 RVA: 0x00A5FBEF File Offset: 0x00A5DDEF
		protected NCS_Left_Lv10_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401738B RID: 95115
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Left/NCS_Left_Lv10.NCS_Left_Lv10_C";

		// Token: 0x0401738C RID: 95116
		private static IntPtr _ClassPtr;

		// Token: 0x0401738D RID: 95117
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
