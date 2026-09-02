using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Out
{
	// Token: 0x02004043 RID: 16451
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Lv10_Long.NCS_Out_Lv10_Long_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Out_Lv10_Long_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA71 RID: 174705 RVA: 0x00A5F598 File Offset: 0x00A5D798
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Out_Lv10_Long_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Lv10_Long.NCS_Out_Lv10_Long_C");
			}
			return NCS_Out_Lv10_Long_C._ClassPtr;
		}

		// Token: 0x0602AA72 RID: 174706 RVA: 0x00A5F5BC File Offset: 0x00A5D7BC
		public NCS_Out_Lv10_Long_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Out_Lv10_Long_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA73 RID: 174707 RVA: 0x00A5F5E4 File Offset: 0x00A5D7E4
		[NullableContext(1)]
		public NCS_Out_Lv10_Long_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Out_Lv10_Long_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA74 RID: 174708 RVA: 0x00A5F617 File Offset: 0x00A5D817
		protected NCS_Out_Lv10_Long_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401736A RID: 95082
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Lv10_Long.NCS_Out_Lv10_Long_C";

		// Token: 0x0401736B RID: 95083
		private static IntPtr _ClassPtr;

		// Token: 0x0401736C RID: 95084
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
