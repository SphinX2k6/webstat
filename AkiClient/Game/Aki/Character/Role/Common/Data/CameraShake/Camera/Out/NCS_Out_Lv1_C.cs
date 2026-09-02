using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Out
{
	// Token: 0x02004044 RID: 16452
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Lv1.NCS_Out_Lv1_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_Out_Lv1_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA75 RID: 174709 RVA: 0x00A5F620 File Offset: 0x00A5D820
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Out_Lv1_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Lv1.NCS_Out_Lv1_C");
			}
			return NCS_Out_Lv1_C._ClassPtr;
		}

		// Token: 0x0602AA76 RID: 174710 RVA: 0x00A5F644 File Offset: 0x00A5D844
		public NCS_Out_Lv1_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Out_Lv1_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA77 RID: 174711 RVA: 0x00A5F66C File Offset: 0x00A5D86C
		[NullableContext(1)]
		public NCS_Out_Lv1_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Out_Lv1_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA78 RID: 174712 RVA: 0x00A5F69F File Offset: 0x00A5D89F
		protected NCS_Out_Lv1_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401736D RID: 95085
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Lv1.NCS_Out_Lv1_C";

		// Token: 0x0401736E RID: 95086
		private static IntPtr _ClassPtr;

		// Token: 0x0401736F RID: 95087
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
