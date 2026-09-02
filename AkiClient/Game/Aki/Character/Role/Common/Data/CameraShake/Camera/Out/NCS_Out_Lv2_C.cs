using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Out
{
	// Token: 0x02004045 RID: 16453
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Lv2.NCS_Out_Lv2_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_Out_Lv2_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA79 RID: 174713 RVA: 0x00A5F6A8 File Offset: 0x00A5D8A8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Out_Lv2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Lv2.NCS_Out_Lv2_C");
			}
			return NCS_Out_Lv2_C._ClassPtr;
		}

		// Token: 0x0602AA7A RID: 174714 RVA: 0x00A5F6CC File Offset: 0x00A5D8CC
		public NCS_Out_Lv2_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Out_Lv2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA7B RID: 174715 RVA: 0x00A5F6F4 File Offset: 0x00A5D8F4
		[NullableContext(1)]
		public NCS_Out_Lv2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Out_Lv2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA7C RID: 174716 RVA: 0x00A5F727 File Offset: 0x00A5D927
		protected NCS_Out_Lv2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017370 RID: 95088
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Lv2.NCS_Out_Lv2_C";

		// Token: 0x04017371 RID: 95089
		private static IntPtr _ClassPtr;

		// Token: 0x04017372 RID: 95090
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
