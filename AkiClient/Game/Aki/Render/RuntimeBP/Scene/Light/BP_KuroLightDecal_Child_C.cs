using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A88 RID: 14984
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_KuroLightDecal_Child.BP_KuroLightDecal_Child_C")]
	[UnrealStructLayout(1328, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1328)]
	public class BP_KuroLightDecal_Child_C : BP_KuroLightDecal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F729 RID: 128809 RVA: 0x00911B70 File Offset: 0x0090FD70
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroLightDecal_Child_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_KuroLightDecal_Child.BP_KuroLightDecal_Child_C");
			}
			return BP_KuroLightDecal_Child_C._ClassPtr;
		}

		// Token: 0x0601F72A RID: 128810 RVA: 0x00911B94 File Offset: 0x0090FD94
		public BP_KuroLightDecal_Child_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroLightDecal_Child_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F72B RID: 128811 RVA: 0x00911BBC File Offset: 0x0090FDBC
		[NullableContext(1)]
		public BP_KuroLightDecal_Child_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroLightDecal_Child_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0601F72C RID: 128812 RVA: 0x00911BEF File Offset: 0x0090FDEF
		protected BP_KuroLightDecal_Child_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F9DF RID: 63967
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_KuroLightDecal_Child.BP_KuroLightDecal_Child_C";

		// Token: 0x0400F9E0 RID: 63968
		private static IntPtr _ClassPtr;

		// Token: 0x0400F9E1 RID: 63969
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
