using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Out
{
	// Token: 0x0200404D RID: 16461
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Lv9.NCS_Out_Lv9_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Out_Lv9_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA99 RID: 174745 RVA: 0x00A5FAE8 File Offset: 0x00A5DCE8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Out_Lv9_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Lv9.NCS_Out_Lv9_C");
			}
			return NCS_Out_Lv9_C._ClassPtr;
		}

		// Token: 0x0602AA9A RID: 174746 RVA: 0x00A5FB0C File Offset: 0x00A5DD0C
		public NCS_Out_Lv9_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Out_Lv9_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA9B RID: 174747 RVA: 0x00A5FB34 File Offset: 0x00A5DD34
		[NullableContext(1)]
		public NCS_Out_Lv9_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Out_Lv9_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA9C RID: 174748 RVA: 0x00A5FB67 File Offset: 0x00A5DD67
		protected NCS_Out_Lv9_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017388 RID: 95112
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Lv9.NCS_Out_Lv9_C";

		// Token: 0x04017389 RID: 95113
		private static IntPtr _ClassPtr;

		// Token: 0x0401738A RID: 95114
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
