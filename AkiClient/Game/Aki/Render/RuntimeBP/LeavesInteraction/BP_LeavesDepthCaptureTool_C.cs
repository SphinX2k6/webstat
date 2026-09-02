using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.LeavesInteraction
{
	// Token: 0x02003C62 RID: 15458
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/LeavesInteraction/BP_LeavesDepthCaptureTool.BP_LeavesDepthCaptureTool_C")]
	[UnrealStructLayout(1072, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1072)]
	public class BP_LeavesDepthCaptureTool_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023C13 RID: 146451 RVA: 0x0098B568 File Offset: 0x00989768
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_LeavesDepthCaptureTool_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/LeavesInteraction/BP_LeavesDepthCaptureTool.BP_LeavesDepthCaptureTool_C");
			}
			return BP_LeavesDepthCaptureTool_C._ClassPtr;
		}

		// Token: 0x06023C14 RID: 146452 RVA: 0x0098B58C File Offset: 0x0098978C
		public BP_LeavesDepthCaptureTool_C() : this(BuiltinUtils.AllocNativeUObject(BP_LeavesDepthCaptureTool_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023C15 RID: 146453 RVA: 0x0098B5B4 File Offset: 0x009897B4
		public BP_LeavesDepthCaptureTool_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_LeavesDepthCaptureTool_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700481E RID: 18462
		// (get) Token: 0x06023C16 RID: 146454 RVA: 0x0098B5E7 File Offset: 0x009897E7
		// (set) Token: 0x06023C17 RID: 146455 RVA: 0x0098B5FB File Offset: 0x009897FB
		[Nullable(2)]
		public unsafe USceneCaptureComponent2D SceneCaptureComponent2D
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneCaptureComponent2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesDepthCaptureTool_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesDepthCaptureTool_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x1700481F RID: 18463
		// (get) Token: 0x06023C18 RID: 146456 RVA: 0x0098B610 File Offset: 0x00989810
		// (set) Token: 0x06023C19 RID: 146457 RVA: 0x0098B624 File Offset: 0x00989824
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesDepthCaptureTool_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesDepthCaptureTool_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004820 RID: 18464
		// (get) Token: 0x06023C1A RID: 146458 RVA: 0x0098B639 File Offset: 0x00989839
		// (set) Token: 0x06023C1B RID: 146459 RVA: 0x0098B64D File Offset: 0x0098984D
		public unsafe string SavePath
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_LeavesDepthCaptureTool_C.__PropertyOffset_2)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_LeavesDepthCaptureTool_C.__PropertyOffset_2)), value);
			}
		}

		// Token: 0x17004821 RID: 18465
		// (get) Token: 0x06023C1C RID: 146460 RVA: 0x0098B662 File Offset: 0x00989862
		// (set) Token: 0x06023C1D RID: 146461 RVA: 0x0098B676 File Offset: 0x00989876
		public unsafe string Name
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_LeavesDepthCaptureTool_C.__PropertyOffset_3)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_LeavesDepthCaptureTool_C.__PropertyOffset_3)), value);
			}
		}

		// Token: 0x06023C1E RID: 146462 RVA: 0x0098B68B File Offset: 0x0098988B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Create_Depth_Texture()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LeavesDepthCaptureTool_C.__Create_Depth_Texture_NativeFunctionPtr, null);
		}

		// Token: 0x06023C1F RID: 146463 RVA: 0x0098B69F File Offset: 0x0098989F
		protected BP_LeavesDepthCaptureTool_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040123F9 RID: 74745
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/LeavesInteraction/BP_LeavesDepthCaptureTool.BP_LeavesDepthCaptureTool_C";

		// Token: 0x040123FA RID: 74746
		private static IntPtr _ClassPtr;

		// Token: 0x040123FB RID: 74747
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040123FC RID: 74748
		internal static int __PropertyOffset_0;

		// Token: 0x040123FD RID: 74749
		internal static int __PropertyOffset_1;

		// Token: 0x040123FE RID: 74750
		internal static int __PropertyOffset_2;

		// Token: 0x040123FF RID: 74751
		internal static int __PropertyOffset_3;

		// Token: 0x04012400 RID: 74752
		private static IntPtr __Create_Depth_Texture_NativeFunctionPtr;
	}
}
