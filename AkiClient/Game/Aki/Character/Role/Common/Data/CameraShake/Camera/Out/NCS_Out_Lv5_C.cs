using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Out
{
	// Token: 0x02004048 RID: 16456
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Lv5.NCS_Out_Lv5_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_Out_Lv5_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA85 RID: 174725 RVA: 0x00A5F840 File Offset: 0x00A5DA40
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Out_Lv5_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Lv5.NCS_Out_Lv5_C");
			}
			return NCS_Out_Lv5_C._ClassPtr;
		}

		// Token: 0x0602AA86 RID: 174726 RVA: 0x00A5F864 File Offset: 0x00A5DA64
		public NCS_Out_Lv5_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Out_Lv5_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA87 RID: 174727 RVA: 0x00A5F88C File Offset: 0x00A5DA8C
		[NullableContext(1)]
		public NCS_Out_Lv5_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Out_Lv5_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA88 RID: 174728 RVA: 0x00A5F8BF File Offset: 0x00A5DABF
		protected NCS_Out_Lv5_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017379 RID: 95097
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Lv5.NCS_Out_Lv5_C";

		// Token: 0x0401737A RID: 95098
		private static IntPtr _ClassPtr;

		// Token: 0x0401737B RID: 95099
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
