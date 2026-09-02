using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core
{
	// Token: 0x02003F3A RID: 16186
	[UnrealObjectPath("/Game/Aki/Core/BP_StartupPlayerController.BP_StartupPlayerController_C")]
	[UnrealStructLayout(2304, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2304)]
	public class BP_StartupPlayerController_C : __TsStartupPlayerController_InheritProxy, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028691 RID: 165521 RVA: 0x00A09B15 File Offset: 0x00A07D15
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_StartupPlayerController_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Core/BP_StartupPlayerController.BP_StartupPlayerController_C");
			}
			return BP_StartupPlayerController_C._ClassPtr;
		}

		// Token: 0x06028692 RID: 165522 RVA: 0x00A09B3C File Offset: 0x00A07D3C
		public BP_StartupPlayerController_C() : this(BuiltinUtils.AllocNativeUObject(BP_StartupPlayerController_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028693 RID: 165523 RVA: 0x00A09B64 File Offset: 0x00A07D64
		[NullableContext(1)]
		public BP_StartupPlayerController_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_StartupPlayerController_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06028694 RID: 165524 RVA: 0x00A09B97 File Offset: 0x00A07D97
		protected BP_StartupPlayerController_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015411 RID: 87057
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Core/BP_StartupPlayerController.BP_StartupPlayerController_C";

		// Token: 0x04015412 RID: 87058
		private static IntPtr _ClassPtr;

		// Token: 0x04015413 RID: 87059
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
