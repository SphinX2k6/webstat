using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Out
{
	// Token: 0x02004042 RID: 16450
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Lv10.NCS_Out_Lv10_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Out_Lv10_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AA6D RID: 174701 RVA: 0x00A5F510 File Offset: 0x00A5D710
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Out_Lv10_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Lv10.NCS_Out_Lv10_C");
			}
			return NCS_Out_Lv10_C._ClassPtr;
		}

		// Token: 0x0602AA6E RID: 174702 RVA: 0x00A5F534 File Offset: 0x00A5D734
		public NCS_Out_Lv10_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Out_Lv10_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AA6F RID: 174703 RVA: 0x00A5F55C File Offset: 0x00A5D75C
		[NullableContext(1)]
		public NCS_Out_Lv10_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Out_Lv10_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AA70 RID: 174704 RVA: 0x00A5F58F File Offset: 0x00A5D78F
		protected NCS_Out_Lv10_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017367 RID: 95079
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Out/NCS_Out_Lv10.NCS_Out_Lv10_C";

		// Token: 0x04017368 RID: 95080
		private static IntPtr _ClassPtr;

		// Token: 0x04017369 RID: 95081
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
