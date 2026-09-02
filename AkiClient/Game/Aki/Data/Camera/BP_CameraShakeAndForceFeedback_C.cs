using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Camera
{
	// Token: 0x02003F12 RID: 16146
	[UnrealObjectPath("/Game/Aki/Data/Camera/BP_CameraShakeAndForceFeedback.BP_CameraShakeAndForceFeedback_C")]
	[UnrealStructLayout(480, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 472)]
	public class BP_CameraShakeAndForceFeedback_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028457 RID: 164951 RVA: 0x00A06542 File Offset: 0x00A04742
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CameraShakeAndForceFeedback_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Camera/BP_CameraShakeAndForceFeedback.BP_CameraShakeAndForceFeedback_C");
			}
			return BP_CameraShakeAndForceFeedback_C._ClassPtr;
		}

		// Token: 0x06028458 RID: 164952 RVA: 0x00A06568 File Offset: 0x00A04768
		public BP_CameraShakeAndForceFeedback_C() : this(BuiltinUtils.AllocNativeUObject(BP_CameraShakeAndForceFeedback_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028459 RID: 164953 RVA: 0x00A06590 File Offset: 0x00A04790
		[NullableContext(1)]
		public BP_CameraShakeAndForceFeedback_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CameraShakeAndForceFeedback_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700618A RID: 24970
		// (get) Token: 0x0602845A RID: 164954 RVA: 0x00A065C3 File Offset: 0x00A047C3
		// (set) Token: 0x0602845B RID: 164955 RVA: 0x00A065D7 File Offset: 0x00A047D7
		[Nullable(2)]
		public unsafe UKuroForceFeedbackEffect ForceFeedbackEffect
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroForceFeedbackEffect>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CameraShakeAndForceFeedback_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CameraShakeAndForceFeedback_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x0602845C RID: 164956 RVA: 0x00A065EC File Offset: 0x00A047EC
		protected BP_CameraShakeAndForceFeedback_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040152CB RID: 86731
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Data/Camera/BP_CameraShakeAndForceFeedback.BP_CameraShakeAndForceFeedback_C";

		// Token: 0x040152CC RID: 86732
		private static IntPtr _ClassPtr;

		// Token: 0x040152CD RID: 86733
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040152CE RID: 86734
		internal static int __PropertyOffset_0;
	}
}
