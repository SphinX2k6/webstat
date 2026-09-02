using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.TrailFields.Runtime.Drawers
{
	// Token: 0x02003A33 RID: 14899
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/Drawers/BP_TrailDrawActor.BP_TrailDrawActor_C")]
	[UnrealStructLayout(1048, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1041)]
	public class BP_TrailDrawActor_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601EB2D RID: 125741 RVA: 0x008FC082 File Offset: 0x008FA282
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_TrailDrawActor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/Drawers/BP_TrailDrawActor.BP_TrailDrawActor_C");
			}
			return BP_TrailDrawActor_C._ClassPtr;
		}

		// Token: 0x0601EB2E RID: 125742 RVA: 0x008FC0A8 File Offset: 0x008FA2A8
		public BP_TrailDrawActor_C() : this(BuiltinUtils.AllocNativeUObject(BP_TrailDrawActor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601EB2F RID: 125743 RVA: 0x008FC0D0 File Offset: 0x008FA2D0
		[NullableContext(1)]
		public BP_TrailDrawActor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_TrailDrawActor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002BF4 RID: 11252
		// (get) Token: 0x0601EB30 RID: 125744 RVA: 0x008FC103 File Offset: 0x008FA303
		// (set) Token: 0x0601EB31 RID: 125745 RVA: 0x008FC117 File Offset: 0x008FA317
		public unsafe BP_TrailDrawComponent_C DrawComponent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_TrailDrawComponent_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDrawActor_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDrawActor_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17002BF5 RID: 11253
		// (get) Token: 0x0601EB32 RID: 125746 RVA: 0x008FC12C File Offset: 0x008FA32C
		// (set) Token: 0x0601EB33 RID: 125747 RVA: 0x008FC140 File Offset: 0x008FA340
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDrawActor_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDrawActor_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002BF6 RID: 11254
		// (get) Token: 0x0601EB34 RID: 125748 RVA: 0x008FC155 File Offset: 0x008FA355
		// (set) Token: 0x0601EB35 RID: 125749 RVA: 0x008FC165 File Offset: 0x008FA365
		public unsafe bool IsEnabled
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailDrawActor_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailDrawActor_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601EB36 RID: 125750 RVA: 0x008FC178 File Offset: 0x008FA378
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void IsEnable(ref bool Ret)
		{
			BP_TrailDrawActor_C.__IsEnable_FunctionParams* ptr = stackalloc BP_TrailDrawActor_C.__IsEnable_FunctionParams[(UIntPtr)18] + 15L / (long)sizeof(BP_TrailDrawActor_C.__IsEnable_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailDrawActor_C.__IsEnable_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Ret = Ret;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailDrawActor_C.__IsEnable_NativeFunctionPtr, (void*)ptr);
			Ret = ptr->Ret;
		}

		// Token: 0x0601EB37 RID: 125751 RVA: 0x008FC1C7 File Offset: 0x008FA3C7
		protected BP_TrailDrawActor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F259 RID: 62041
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/Drawers/BP_TrailDrawActor.BP_TrailDrawActor_C";

		// Token: 0x0400F25A RID: 62042
		private static IntPtr _ClassPtr;

		// Token: 0x0400F25B RID: 62043
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F25C RID: 62044
		internal static int __PropertyOffset_0;

		// Token: 0x0400F25D RID: 62045
		internal static int __PropertyOffset_1;

		// Token: 0x0400F25E RID: 62046
		internal static int __PropertyOffset_2;

		// Token: 0x0400F25F RID: 62047
		private static IntPtr __IsEnable_NativeFunctionPtr;

		// Token: 0x020097ED RID: 38893
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 3)]
		protected ref struct __IsEnable_FunctionParams
		{
			// Token: 0x04031DE1 RID: 204257
			[FieldOffset(0)]
			public bool Ret;
		}
	}
}
