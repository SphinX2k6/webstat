using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Down
{
	// Token: 0x02004066 RID: 16486
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Down/NCS_Down_Lv3.NCS_Down_Lv3_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_Down_Lv3_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AAFD RID: 174845 RVA: 0x00A60830 File Offset: 0x00A5EA30
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Down_Lv3_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Down/NCS_Down_Lv3.NCS_Down_Lv3_C");
			}
			return NCS_Down_Lv3_C._ClassPtr;
		}

		// Token: 0x0602AAFE RID: 174846 RVA: 0x00A60854 File Offset: 0x00A5EA54
		public NCS_Down_Lv3_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Down_Lv3_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AAFF RID: 174847 RVA: 0x00A6087C File Offset: 0x00A5EA7C
		[NullableContext(1)]
		public NCS_Down_Lv3_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Down_Lv3_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AB00 RID: 174848 RVA: 0x00A608AF File Offset: 0x00A5EAAF
		protected NCS_Down_Lv3_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040173D3 RID: 95187
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Down/NCS_Down_Lv3.NCS_Down_Lv3_C";

		// Token: 0x040173D4 RID: 95188
		private static IntPtr _ClassPtr;

		// Token: 0x040173D5 RID: 95189
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
