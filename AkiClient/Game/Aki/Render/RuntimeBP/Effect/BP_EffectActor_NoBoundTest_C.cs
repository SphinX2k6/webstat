using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect
{
	// Token: 0x02003D1E RID: 15646
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/BP_EffectActor_NoBoundTest.BP_EffectActor_NoBoundTest_C")]
	[UnrealStructLayout(1344, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1339)]
	public class BP_EffectActor_NoBoundTest_C : BP_EffectActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025D5B RID: 154971 RVA: 0x009C6754 File Offset: 0x009C4954
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_EffectActor_NoBoundTest_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Effect/BP_EffectActor_NoBoundTest.BP_EffectActor_NoBoundTest_C");
			}
			return BP_EffectActor_NoBoundTest_C._ClassPtr;
		}

		// Token: 0x06025D5C RID: 154972 RVA: 0x009C6778 File Offset: 0x009C4978
		public BP_EffectActor_NoBoundTest_C() : this(BuiltinUtils.AllocNativeUObject(BP_EffectActor_NoBoundTest_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025D5D RID: 154973 RVA: 0x009C67A0 File Offset: 0x009C49A0
		[NullableContext(1)]
		public BP_EffectActor_NoBoundTest_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_EffectActor_NoBoundTest_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06025D5E RID: 154974 RVA: 0x009C67D3 File Offset: 0x009C49D3
		protected BP_EffectActor_NoBoundTest_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040138DA RID: 80090
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/BP_EffectActor_NoBoundTest.BP_EffectActor_NoBoundTest_C";

		// Token: 0x040138DB RID: 80091
		private static IntPtr _ClassPtr;

		// Token: 0x040138DC RID: 80092
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
