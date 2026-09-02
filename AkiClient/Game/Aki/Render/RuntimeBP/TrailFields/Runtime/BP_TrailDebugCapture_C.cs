using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.TrailFields.Runtime
{
	// Token: 0x02003A28 RID: 14888
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/BP_TrailDebugCapture.BP_TrailDebugCapture_C")]
	[UnrealStructLayout(1048, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1048)]
	public class BP_TrailDebugCapture_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601EA08 RID: 125448 RVA: 0x008F9EFA File Offset: 0x008F80FA
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_TrailDebugCapture_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/BP_TrailDebugCapture.BP_TrailDebugCapture_C");
			}
			return BP_TrailDebugCapture_C._ClassPtr;
		}

		// Token: 0x0601EA09 RID: 125449 RVA: 0x008F9F20 File Offset: 0x008F8120
		public BP_TrailDebugCapture_C() : this(BuiltinUtils.AllocNativeUObject(BP_TrailDebugCapture_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601EA0A RID: 125450 RVA: 0x008F9F48 File Offset: 0x008F8148
		[NullableContext(1)]
		public BP_TrailDebugCapture_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_TrailDebugCapture_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002B93 RID: 11155
		// (get) Token: 0x0601EA0B RID: 125451 RVA: 0x008F9F7B File Offset: 0x008F817B
		// (set) Token: 0x0601EA0C RID: 125452 RVA: 0x008F9F8F File Offset: 0x008F818F
		public unsafe USceneCaptureComponent2D SceneCaptureComponent2D
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneCaptureComponent2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDebugCapture_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDebugCapture_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17002B94 RID: 11156
		// (get) Token: 0x0601EA0D RID: 125453 RVA: 0x008F9FA4 File Offset: 0x008F81A4
		// (set) Token: 0x0601EA0E RID: 125454 RVA: 0x008F9FB8 File Offset: 0x008F81B8
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDebugCapture_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDebugCapture_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002B95 RID: 11157
		// (get) Token: 0x0601EA0F RID: 125455 RVA: 0x008F9FCD File Offset: 0x008F81CD
		// (set) Token: 0x0601EA10 RID: 125456 RVA: 0x008F9FE1 File Offset: 0x008F81E1
		public unsafe AActor CaptureActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDebugCapture_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDebugCapture_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x0601EA11 RID: 125457 RVA: 0x008F9FF6 File Offset: 0x008F81F6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StartCapture()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailDebugCapture_C.__StartCapture_NativeFunctionPtr, null);
		}

		// Token: 0x0601EA12 RID: 125458 RVA: 0x008FA00A File Offset: 0x008F820A
		protected BP_TrailDebugCapture_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F19D RID: 61853
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/BP_TrailDebugCapture.BP_TrailDebugCapture_C";

		// Token: 0x0400F19E RID: 61854
		private static IntPtr _ClassPtr;

		// Token: 0x0400F19F RID: 61855
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F1A0 RID: 61856
		internal static int __PropertyOffset_0;

		// Token: 0x0400F1A1 RID: 61857
		internal static int __PropertyOffset_1;

		// Token: 0x0400F1A2 RID: 61858
		internal static int __PropertyOffset_2;

		// Token: 0x0400F1A3 RID: 61859
		private static IntPtr __StartCapture_NativeFunctionPtr;
	}
}
