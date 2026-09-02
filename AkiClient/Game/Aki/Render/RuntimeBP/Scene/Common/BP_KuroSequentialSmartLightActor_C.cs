using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common
{
	// Token: 0x02003ADB RID: 15067
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/BP_KuroSequentialSmartLightActor.BP_KuroSequentialSmartLightActor_C")]
	[UnrealStructLayout(1224, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1224)]
	public class BP_KuroSequentialSmartLightActor_C : AKuroSequentialSmartLightActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602042C RID: 132140 RVA: 0x00926D50 File Offset: 0x00924F50
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroSequentialSmartLightActor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/BP_KuroSequentialSmartLightActor.BP_KuroSequentialSmartLightActor_C");
			}
			return BP_KuroSequentialSmartLightActor_C._ClassPtr;
		}

		// Token: 0x0602042D RID: 132141 RVA: 0x00926D74 File Offset: 0x00924F74
		public BP_KuroSequentialSmartLightActor_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroSequentialSmartLightActor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602042E RID: 132142 RVA: 0x00926D9C File Offset: 0x00924F9C
		[NullableContext(1)]
		public BP_KuroSequentialSmartLightActor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroSequentialSmartLightActor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602042F RID: 132143 RVA: 0x00926DCF File Offset: 0x00924FCF
		protected BP_KuroSequentialSmartLightActor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010181 RID: 65921
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/BP_KuroSequentialSmartLightActor.BP_KuroSequentialSmartLightActor_C";

		// Token: 0x04010182 RID: 65922
		private static IntPtr _ClassPtr;

		// Token: 0x04010183 RID: 65923
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
