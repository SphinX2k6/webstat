using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Macros
{
	// Token: 0x02003C5B RID: 15451
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Macros/FKuroMacros.FKuroMacros_C")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 48)]
	public abstract class FKuroMacros_C : UObject, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023B7E RID: 146302 RVA: 0x0098A0C0 File Offset: 0x009882C0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (FKuroMacros_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Macros/FKuroMacros.FKuroMacros_C");
			}
			return FKuroMacros_C._ClassPtr;
		}

		// Token: 0x06023B7F RID: 146303 RVA: 0x0098A0E4 File Offset: 0x009882E4
		protected FKuroMacros_C() : this(BuiltinUtils.AllocNativeUObject(FKuroMacros_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023B80 RID: 146304 RVA: 0x0098A10C File Offset: 0x0098830C
		protected FKuroMacros_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012378 RID: 74616
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Macros/FKuroMacros.FKuroMacros_C";

		// Token: 0x04012379 RID: 74617
		private static IntPtr _ClassPtr;

		// Token: 0x0401237A RID: 74618
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
