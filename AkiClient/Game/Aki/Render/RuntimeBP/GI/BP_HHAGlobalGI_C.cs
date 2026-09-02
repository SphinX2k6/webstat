using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI
{
	// Token: 0x02003C98 RID: 15512
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/BP_HHAGlobalGI.BP_HHAGlobalGI_C")]
	[UnrealStructLayout(17008, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 17002)]
	public class BP_HHAGlobalGI_C : BP_GlobalGI_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024789 RID: 149385 RVA: 0x0099E827 File Offset: 0x0099CA27
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_HHAGlobalGI_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/BP_HHAGlobalGI.BP_HHAGlobalGI_C");
			}
			return BP_HHAGlobalGI_C._ClassPtr;
		}

		// Token: 0x0602478A RID: 149386 RVA: 0x0099E84C File Offset: 0x0099CA4C
		public BP_HHAGlobalGI_C() : this(BuiltinUtils.AllocNativeUObject(BP_HHAGlobalGI_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602478B RID: 149387 RVA: 0x0099E874 File Offset: 0x0099CA74
		[NullableContext(1)]
		public BP_HHAGlobalGI_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_HHAGlobalGI_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602478C RID: 149388 RVA: 0x0099E8A7 File Offset: 0x0099CAA7
		protected BP_HHAGlobalGI_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012AED RID: 76525
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/BP_HHAGlobalGI.BP_HHAGlobalGI_C";

		// Token: 0x04012AEE RID: 76526
		private static IntPtr _ClassPtr;

		// Token: 0x04012AEF RID: 76527
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
