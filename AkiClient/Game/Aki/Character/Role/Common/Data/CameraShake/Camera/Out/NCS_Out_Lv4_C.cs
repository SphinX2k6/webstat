using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Out
{
	// Token: 0x02004047 RID: 16455
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Lv4.NCS_Out_Lv4_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_Out_Lv4_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA81 RID: 174721 RVA: 0x00A5F7B8 File Offset: 0x00A5D9B8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Out_Lv4_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Lv4.NCS_Out_Lv4_C");
			}
			return NCS_Out_Lv4_C._ClassPtr;
		}

		// Token: 0x0602AA82 RID: 174722 RVA: 0x00A5F7DC File Offset: 0x00A5D9DC
		public NCS_Out_Lv4_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Out_Lv4_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA83 RID: 174723 RVA: 0x00A5F804 File Offset: 0x00A5DA04
		[NullableContext(1)]
		public NCS_Out_Lv4_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Out_Lv4_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA84 RID: 174724 RVA: 0x00A5F837 File Offset: 0x00A5DA37
		protected NCS_Out_Lv4_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017376 RID: 95094
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Lv4.NCS_Out_Lv4_C";

		// Token: 0x04017377 RID: 95095
		private static IntPtr _ClassPtr;

		// Token: 0x04017378 RID: 95096
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
