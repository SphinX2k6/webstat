using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Out
{
	// Token: 0x02004046 RID: 16454
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Lv3.NCS_Out_Lv3_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_Out_Lv3_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA7D RID: 174717 RVA: 0x00A5F730 File Offset: 0x00A5D930
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Out_Lv3_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Lv3.NCS_Out_Lv3_C");
			}
			return NCS_Out_Lv3_C._ClassPtr;
		}

		// Token: 0x0602AA7E RID: 174718 RVA: 0x00A5F754 File Offset: 0x00A5D954
		public NCS_Out_Lv3_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Out_Lv3_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA7F RID: 174719 RVA: 0x00A5F77C File Offset: 0x00A5D97C
		[NullableContext(1)]
		public NCS_Out_Lv3_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Out_Lv3_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA80 RID: 174720 RVA: 0x00A5F7AF File Offset: 0x00A5D9AF
		protected NCS_Out_Lv3_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017373 RID: 95091
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Lv3.NCS_Out_Lv3_C";

		// Token: 0x04017374 RID: 95092
		private static IntPtr _ClassPtr;

		// Token: 0x04017375 RID: 95093
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
