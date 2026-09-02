using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A81 RID: 14977
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_GameBudgetBlurprintActor.BP_GameBudgetBlurprintActor_C")]
	[UnrealStructLayout(1032, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1032)]
	public class BP_GameBudgetBlurprintActor_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F568 RID: 128360 RVA: 0x0090F2BF File Offset: 0x0090D4BF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_GameBudgetBlurprintActor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_GameBudgetBlurprintActor.BP_GameBudgetBlurprintActor_C");
			}
			return BP_GameBudgetBlurprintActor_C._ClassPtr;
		}

		// Token: 0x0601F569 RID: 128361 RVA: 0x0090F2E4 File Offset: 0x0090D4E4
		public BP_GameBudgetBlurprintActor_C() : this(BuiltinUtils.AllocNativeUObject(BP_GameBudgetBlurprintActor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F56A RID: 128362 RVA: 0x0090F30C File Offset: 0x0090D50C
		[NullableContext(1)]
		public BP_GameBudgetBlurprintActor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_GameBudgetBlurprintActor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002F47 RID: 12103
		// (get) Token: 0x0601F56B RID: 128363 RVA: 0x0090F33F File Offset: 0x0090D53F
		// (set) Token: 0x0601F56C RID: 128364 RVA: 0x0090F353 File Offset: 0x0090D553
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GameBudgetBlurprintActor_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GameBudgetBlurprintActor_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x0601F56D RID: 128365 RVA: 0x0090F368 File Offset: 0x0090D568
		protected BP_GameBudgetBlurprintActor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F8E2 RID: 63714
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_GameBudgetBlurprintActor.BP_GameBudgetBlurprintActor_C";

		// Token: 0x0400F8E3 RID: 63715
		private static IntPtr _ClassPtr;

		// Token: 0x0400F8E4 RID: 63716
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F8E5 RID: 63717
		internal static int __PropertyOffset_0;
	}
}
