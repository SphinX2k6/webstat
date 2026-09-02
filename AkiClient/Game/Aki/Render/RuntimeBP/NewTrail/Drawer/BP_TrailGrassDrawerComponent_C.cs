using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.NewTrail.Drawer
{
	// Token: 0x02003C56 RID: 15446
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/NewTrail/Drawer/BP_TrailGrassDrawerComponent.BP_TrailGrassDrawerComponent_C")]
	[UnrealStructLayout(608, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 608)]
	public class BP_TrailGrassDrawerComponent_C : UKuroTrailDrawerComponent, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023AA8 RID: 146088 RVA: 0x00988A97 File Offset: 0x00986C97
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_TrailGrassDrawerComponent_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/NewTrail/Drawer/BP_TrailGrassDrawerComponent.BP_TrailGrassDrawerComponent_C");
			}
			return BP_TrailGrassDrawerComponent_C._ClassPtr;
		}

		// Token: 0x06023AA9 RID: 146089 RVA: 0x00988ABC File Offset: 0x00986CBC
		public BP_TrailGrassDrawerComponent_C() : this(BuiltinUtils.AllocNativeUObject(BP_TrailGrassDrawerComponent_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023AAA RID: 146090 RVA: 0x00988AE4 File Offset: 0x00986CE4
		[NullableContext(1)]
		public BP_TrailGrassDrawerComponent_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_TrailGrassDrawerComponent_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170047B8 RID: 18360
		// (get) Token: 0x06023AAB RID: 146091 RVA: 0x00988B18 File Offset: 0x00986D18
		// (set) Token: 0x06023AAC RID: 146092 RVA: 0x00988B51 File Offset: 0x00986D51
		[Nullable(1)]
		public FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_TrailGrassDrawerComponent_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_TrailGrassDrawerComponent_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06023AAD RID: 146093 RVA: 0x00988B72 File Offset: 0x00986D72
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnDrawerBegin()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailGrassDrawerComponent_C.__OnDrawerBegin_NativeFunctionPtr, null);
		}

		// Token: 0x06023AAE RID: 146094 RVA: 0x00988B88 File Offset: 0x00986D88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnDrawerEnd(EEndPlayReason EndPlayReason)
		{
			BP_TrailGrassDrawerComponent_C.__OnDrawerEnd_FunctionParams* ptr = stackalloc BP_TrailGrassDrawerComponent_C.__OnDrawerEnd_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_TrailGrassDrawerComponent_C.__OnDrawerEnd_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailGrassDrawerComponent_C.__OnDrawerEnd_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailGrassDrawerComponent_C.__OnDrawerEnd_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023AAF RID: 146095 RVA: 0x00988BD4 File Offset: 0x00986DD4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnDrawerTick(float DeltaTime)
		{
			BP_TrailGrassDrawerComponent_C.__OnDrawerTick_FunctionParams* ptr = stackalloc BP_TrailGrassDrawerComponent_C.__OnDrawerTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_TrailGrassDrawerComponent_C.__OnDrawerTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailGrassDrawerComponent_C.__OnDrawerTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailGrassDrawerComponent_C.__OnDrawerTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023AB0 RID: 146096 RVA: 0x00988C1C File Offset: 0x00986E1C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_TrailGrassDrawerComponent(int EntryPoint)
		{
			BP_TrailGrassDrawerComponent_C.__ExecuteUbergraph_BP_TrailGrassDrawerComponent_FunctionParams* ptr = stackalloc BP_TrailGrassDrawerComponent_C.__ExecuteUbergraph_BP_TrailGrassDrawerComponent_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_TrailGrassDrawerComponent_C.__ExecuteUbergraph_BP_TrailGrassDrawerComponent_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailGrassDrawerComponent_C.__ExecuteUbergraph_BP_TrailGrassDrawerComponent_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrailGrassDrawerComponent_C.__ExecuteUbergraph_BP_TrailGrassDrawerComponent_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023AB1 RID: 146097 RVA: 0x00988C63 File Offset: 0x00986E63
		protected BP_TrailGrassDrawerComponent_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040122EE RID: 74478
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/NewTrail/Drawer/BP_TrailGrassDrawerComponent.BP_TrailGrassDrawerComponent_C";

		// Token: 0x040122EF RID: 74479
		private static IntPtr _ClassPtr;

		// Token: 0x040122F0 RID: 74480
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040122F1 RID: 74481
		internal static int __PropertyOffset_0;

		// Token: 0x040122F2 RID: 74482
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040122F3 RID: 74483
		private static IntPtr __OnDrawerBegin_NativeFunctionPtr;

		// Token: 0x040122F4 RID: 74484
		private static IntPtr __OnDrawerEnd_NativeFunctionPtr;

		// Token: 0x040122F5 RID: 74485
		private static IntPtr __OnDrawerTick_NativeFunctionPtr;

		// Token: 0x040122F6 RID: 74486
		private static IntPtr __ExecuteUbergraph_BP_TrailGrassDrawerComponent_NativeFunctionPtr;

		// Token: 0x02009D16 RID: 40214
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __OnDrawerEnd_FunctionParams
		{
			// Token: 0x040326D0 RID: 206544
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009D17 RID: 40215
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __OnDrawerTick_FunctionParams
		{
			// Token: 0x040326D1 RID: 206545
			[FieldOffset(0)]
			public float DeltaTime;
		}

		// Token: 0x02009D18 RID: 40216
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_TrailGrassDrawerComponent_FunctionParams
		{
			// Token: 0x040326D2 RID: 206546
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
