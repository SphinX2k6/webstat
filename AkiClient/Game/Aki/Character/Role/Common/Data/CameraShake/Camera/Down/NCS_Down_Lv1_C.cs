using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Down
{
	// Token: 0x02004064 RID: 16484
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Down/NCS_Down_Lv1.NCS_Down_Lv1_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_Down_Lv1_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AAF5 RID: 174837 RVA: 0x00A60720 File Offset: 0x00A5E920
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Down_Lv1_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Down/NCS_Down_Lv1.NCS_Down_Lv1_C");
			}
			return NCS_Down_Lv1_C._ClassPtr;
		}

		// Token: 0x0602AAF6 RID: 174838 RVA: 0x00A60744 File Offset: 0x00A5E944
		public NCS_Down_Lv1_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Down_Lv1_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AAF7 RID: 174839 RVA: 0x00A6076C File Offset: 0x00A5E96C
		[NullableContext(1)]
		public NCS_Down_Lv1_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Down_Lv1_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AAF8 RID: 174840 RVA: 0x00A6079F File Offset: 0x00A5E99F
		protected NCS_Down_Lv1_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040173CD RID: 95181
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Down/NCS_Down_Lv1.NCS_Down_Lv1_C";

		// Token: 0x040173CE RID: 95182
		private static IntPtr _ClassPtr;

		// Token: 0x040173CF RID: 95183
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
