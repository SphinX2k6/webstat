using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.TypeScript.Game.Render.Effect.Data
{
	// Token: 0x020039B9 RID: 14777
	[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelNDC.EffectModelNDC_C")]
	[UnrealStructLayout(152, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 152)]
	public class EffectModelNDC_C : UEffectModelNDC, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601DDA6 RID: 122278 RVA: 0x008E47AC File Offset: 0x008E29AC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (EffectModelNDC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelNDC.EffectModelNDC_C");
			}
			return EffectModelNDC_C._ClassPtr;
		}

		// Token: 0x0601DDA7 RID: 122279 RVA: 0x008E47D0 File Offset: 0x008E29D0
		public EffectModelNDC_C() : this(BuiltinUtils.AllocNativeUObject(EffectModelNDC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601DDA8 RID: 122280 RVA: 0x008E47F8 File Offset: 0x008E29F8
		[NullableContext(1)]
		public EffectModelNDC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelNDC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0601DDA9 RID: 122281 RVA: 0x008E482B File Offset: 0x008E2A2B
		protected EffectModelNDC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400E9DB RID: 59867
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelNDC.EffectModelNDC_C";

		// Token: 0x0400E9DC RID: 59868
		private static IntPtr _ClassPtr;

		// Token: 0x0400E9DD RID: 59869
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
