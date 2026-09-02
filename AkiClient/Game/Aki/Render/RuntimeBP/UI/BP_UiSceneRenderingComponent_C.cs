using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.GI;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.UI
{
	// Token: 0x02003A21 RID: 14881
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/UI/BP_UiSceneRenderingComponent.BP_UiSceneRenderingComponent_C")]
	[UnrealStructLayout(256, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 256)]
	public class BP_UiSceneRenderingComponent_C : UActorComponent, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601E981 RID: 125313 RVA: 0x008F8D8F File Offset: 0x008F6F8F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_UiSceneRenderingComponent_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/UI/BP_UiSceneRenderingComponent.BP_UiSceneRenderingComponent_C");
			}
			return BP_UiSceneRenderingComponent_C._ClassPtr;
		}

		// Token: 0x0601E982 RID: 125314 RVA: 0x008F8DB4 File Offset: 0x008F6FB4
		public BP_UiSceneRenderingComponent_C() : this(BuiltinUtils.AllocNativeUObject(BP_UiSceneRenderingComponent_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E983 RID: 125315 RVA: 0x008F8DDC File Offset: 0x008F6FDC
		public BP_UiSceneRenderingComponent_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_UiSceneRenderingComponent_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002B6F RID: 11119
		// (get) Token: 0x0601E984 RID: 125316 RVA: 0x008F8E10 File Offset: 0x008F7010
		// (set) Token: 0x0601E985 RID: 125317 RVA: 0x008F8E49 File Offset: 0x008F7049
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_UiSceneRenderingComponent_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_UiSceneRenderingComponent_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002B70 RID: 11120
		// (get) Token: 0x0601E986 RID: 125318 RVA: 0x008F8E6A File Offset: 0x008F706A
		// (set) Token: 0x0601E987 RID: 125319 RVA: 0x008F8E7E File Offset: 0x008F707E
		[Nullable(2)]
		public unsafe BP_GlobalGI_C BP_GlobalGI
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_GlobalGI_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_UiSceneRenderingComponent_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_UiSceneRenderingComponent_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002B71 RID: 11121
		// (get) Token: 0x0601E988 RID: 125320 RVA: 0x008F8E93 File Offset: 0x008F7093
		// (set) Token: 0x0601E989 RID: 125321 RVA: 0x008F8EA3 File Offset: 0x008F70A3
		public unsafe bool IsInUiSceneRenderingState
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_UiSceneRenderingComponent_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_UiSceneRenderingComponent_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002B72 RID: 11122
		// (get) Token: 0x0601E98A RID: 125322 RVA: 0x008F8EB4 File Offset: 0x008F70B4
		// (set) Token: 0x0601E98B RID: 125323 RVA: 0x008F8EC8 File Offset: 0x008F70C8
		public unsafe string CurUiScenePath
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_UiSceneRenderingComponent_C.__PropertyOffset_3)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_UiSceneRenderingComponent_C.__PropertyOffset_3)), value);
			}
		}

		// Token: 0x17002B73 RID: 11123
		// (get) Token: 0x0601E98C RID: 125324 RVA: 0x008F8EDD File Offset: 0x008F70DD
		// (set) Token: 0x0601E98D RID: 125325 RVA: 0x008F8EF1 File Offset: 0x008F70F1
		[Nullable(2)]
		public unsafe UDirectionalLightComponent MainLightComponent
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDirectionalLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_UiSceneRenderingComponent_C.__PropertyOffset_4);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_UiSceneRenderingComponent_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x0601E98E RID: 125326 RVA: 0x008F8F06 File Offset: 0x008F7106
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnKuroEndUiScene()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UiSceneRenderingComponent_C.__OnKuroEndUiScene_NativeFunctionPtr, null);
		}

		// Token: 0x0601E98F RID: 125327 RVA: 0x008F8F1C File Offset: 0x008F711C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnKuroStartUiScene(string UiScenePath)
		{
			BP_UiSceneRenderingComponent_C.__OnKuroStartUiScene_FunctionParams* ptr = stackalloc BP_UiSceneRenderingComponent_C.__OnKuroStartUiScene_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_UiSceneRenderingComponent_C.__OnKuroStartUiScene_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_UiSceneRenderingComponent_C.__OnKuroStartUiScene_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->UiScenePath), UiScenePath);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UiSceneRenderingComponent_C.__OnKuroStartUiScene_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_UiSceneRenderingComponent_C.__OnKuroStartUiScene_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601E990 RID: 125328 RVA: 0x008F8F7C File Offset: 0x008F717C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Init(BP_GlobalGI_C InGlobalGI)
		{
			BP_UiSceneRenderingComponent_C.__Init_FunctionParams* ptr = stackalloc BP_UiSceneRenderingComponent_C.__Init_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_UiSceneRenderingComponent_C.__Init_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_UiSceneRenderingComponent_C.__Init_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InGlobalGI = ((InGlobalGI != null) ? InGlobalGI.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UiSceneRenderingComponent_C.__Init_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E991 RID: 125329 RVA: 0x008F8FD4 File Offset: 0x008F71D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_UiSceneRenderingComponent_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_UiSceneRenderingComponent_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_UiSceneRenderingComponent_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_UiSceneRenderingComponent_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UiSceneRenderingComponent_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E992 RID: 125330 RVA: 0x008F9020 File Offset: 0x008F7220
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_UiSceneRenderingComponent_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_UiSceneRenderingComponent_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_UiSceneRenderingComponent_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_UiSceneRenderingComponent_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_UiSceneRenderingComponent_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E993 RID: 125331 RVA: 0x008F906C File Offset: 0x008F726C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_UiSceneRenderingComponent(int EntryPoint)
		{
			BP_UiSceneRenderingComponent_C.__ExecuteUbergraph_BP_UiSceneRenderingComponent_FunctionParams* ptr = stackalloc BP_UiSceneRenderingComponent_C.__ExecuteUbergraph_BP_UiSceneRenderingComponent_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_UiSceneRenderingComponent_C.__ExecuteUbergraph_BP_UiSceneRenderingComponent_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_UiSceneRenderingComponent_C.__ExecuteUbergraph_BP_UiSceneRenderingComponent_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_UiSceneRenderingComponent_C.__ExecuteUbergraph_BP_UiSceneRenderingComponent_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E994 RID: 125332 RVA: 0x008F90B3 File Offset: 0x008F72B3
		protected BP_UiSceneRenderingComponent_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F148 RID: 61768
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/UI/BP_UiSceneRenderingComponent.BP_UiSceneRenderingComponent_C";

		// Token: 0x0400F149 RID: 61769
		private static IntPtr _ClassPtr;

		// Token: 0x0400F14A RID: 61770
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F14B RID: 61771
		internal static int __PropertyOffset_0;

		// Token: 0x0400F14C RID: 61772
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F14D RID: 61773
		internal static int __PropertyOffset_1;

		// Token: 0x0400F14E RID: 61774
		internal static int __PropertyOffset_2;

		// Token: 0x0400F14F RID: 61775
		internal static int __PropertyOffset_3;

		// Token: 0x0400F150 RID: 61776
		internal static int __PropertyOffset_4;

		// Token: 0x0400F151 RID: 61777
		private static IntPtr __OnKuroEndUiScene_NativeFunctionPtr;

		// Token: 0x0400F152 RID: 61778
		private static IntPtr __OnKuroStartUiScene_NativeFunctionPtr;

		// Token: 0x0400F153 RID: 61779
		private static IntPtr __Init_NativeFunctionPtr;

		// Token: 0x0400F154 RID: 61780
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x0400F155 RID: 61781
		private static IntPtr __ExecuteUbergraph_BP_UiSceneRenderingComponent_NativeFunctionPtr;

		// Token: 0x020097C6 RID: 38854
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __OnKuroStartUiScene_FunctionParams
		{
			// Token: 0x04031DAC RID: 204204
			[FieldOffset(0)]
			public FString UiScenePath;
		}

		// Token: 0x020097C7 RID: 38855
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __Init_FunctionParams
		{
			// Token: 0x04031DAD RID: 204205
			[FieldOffset(0)]
			public IntPtr InGlobalGI;
		}

		// Token: 0x020097C8 RID: 38856
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04031DAE RID: 204206
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x020097C9 RID: 38857
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_UiSceneRenderingComponent_FunctionParams
		{
			// Token: 0x04031DAF RID: 204207
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
