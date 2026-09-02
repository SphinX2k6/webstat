using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Down
{
	// Token: 0x02004063 RID: 16483
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Down/NCS_Down_Lv10_Long.NCS_Down_Lv10_Long_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class NCS_Down_Lv10_Long_C : BP_CameraShakeAndForceFeedback_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AAF1 RID: 174833 RVA: 0x00A60698 File Offset: 0x00A5E898
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Down_Lv10_Long_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Down/NCS_Down_Lv10_Long.NCS_Down_Lv10_Long_C");
			}
			return NCS_Down_Lv10_Long_C._ClassPtr;
		}

		// Token: 0x0602AAF2 RID: 174834 RVA: 0x00A606BC File Offset: 0x00A5E8BC
		public NCS_Down_Lv10_Long_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Down_Lv10_Long_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AAF3 RID: 174835 RVA: 0x00A606E4 File Offset: 0x00A5E8E4
		[NullableContext(1)]
		public NCS_Down_Lv10_Long_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Down_Lv10_Long_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AAF4 RID: 174836 RVA: 0x00A60717 File Offset: 0x00A5E917
		protected NCS_Down_Lv10_Long_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040173CA RID: 95178
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Down/NCS_Down_Lv10_Long.NCS_Down_Lv10_Long_C";

		// Token: 0x040173CB RID: 95179
		private static IntPtr _ClassPtr;

		// Token: 0x040173CC RID: 95180
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
