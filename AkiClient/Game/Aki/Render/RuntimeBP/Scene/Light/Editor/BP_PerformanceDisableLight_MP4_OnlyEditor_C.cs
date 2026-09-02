using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light.Editor
{
	// Token: 0x02003AB1 RID: 15025
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/Editor/BP_PerformanceDisableLight_MP4_OnlyEditor.BP_PerformanceDisableLight_MP4_OnlyEditor_C")]
	[UnrealStructLayout(1072, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1072)]
	public class BP_PerformanceDisableLight_MP4_OnlyEditor_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602008B RID: 131211 RVA: 0x00920668 File Offset: 0x0091E868
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PerformanceDisableLight_MP4_OnlyEditor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/Editor/BP_PerformanceDisableLight_MP4_OnlyEditor.BP_PerformanceDisableLight_MP4_OnlyEditor_C");
			}
			return BP_PerformanceDisableLight_MP4_OnlyEditor_C._ClassPtr;
		}

		// Token: 0x0602008C RID: 131212 RVA: 0x0092068C File Offset: 0x0091E88C
		public BP_PerformanceDisableLight_MP4_OnlyEditor_C() : this(BuiltinUtils.AllocNativeUObject(BP_PerformanceDisableLight_MP4_OnlyEditor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602008D RID: 131213 RVA: 0x009206B4 File Offset: 0x0091E8B4
		public BP_PerformanceDisableLight_MP4_OnlyEditor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PerformanceDisableLight_MP4_OnlyEditor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003398 RID: 13208
		// (get) Token: 0x0602008E RID: 131214 RVA: 0x009206E8 File Offset: 0x0091E8E8
		// (set) Token: 0x0602008F RID: 131215 RVA: 0x00920721 File Offset: 0x0091E921
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_PerformanceDisableLight_MP4_OnlyEditor_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_PerformanceDisableLight_MP4_OnlyEditor_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003399 RID: 13209
		// (get) Token: 0x06020090 RID: 131216 RVA: 0x00920742 File Offset: 0x0091E942
		// (set) Token: 0x06020091 RID: 131217 RVA: 0x00920756 File Offset: 0x0091E956
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PerformanceDisableLight_MP4_OnlyEditor_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PerformanceDisableLight_MP4_OnlyEditor_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700339A RID: 13210
		// (get) Token: 0x06020092 RID: 131218 RVA: 0x0092076B File Offset: 0x0091E96B
		// (set) Token: 0x06020093 RID: 131219 RVA: 0x0092077B File Offset: 0x0091E97B
		public unsafe float LightIntensity_MP4
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PerformanceDisableLight_MP4_OnlyEditor_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PerformanceDisableLight_MP4_OnlyEditor_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700339B RID: 13211
		// (get) Token: 0x06020094 RID: 131220 RVA: 0x0092078C File Offset: 0x0091E98C
		// (set) Token: 0x06020095 RID: 131221 RVA: 0x009207A0 File Offset: 0x0091E9A0
		public unsafe string MainCommand
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_PerformanceDisableLight_MP4_OnlyEditor_C.__PropertyOffset_3)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_PerformanceDisableLight_MP4_OnlyEditor_C.__PropertyOffset_3)), value);
			}
		}

		// Token: 0x06020096 RID: 131222 RVA: 0x009207B5 File Offset: 0x0091E9B5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DisableLightFun_MP4()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PerformanceDisableLight_MP4_OnlyEditor_C.__DisableLightFun_MP4_NativeFunctionPtr, null);
		}

		// Token: 0x06020097 RID: 131223 RVA: 0x009207C9 File Offset: 0x0091E9C9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DisableLightFun()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PerformanceDisableLight_MP4_OnlyEditor_C.__DisableLightFun_NativeFunctionPtr, null);
		}

		// Token: 0x06020098 RID: 131224 RVA: 0x009207DD File Offset: 0x0091E9DD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PerformanceDisableLight_MP4_OnlyEditor_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06020099 RID: 131225 RVA: 0x009207F1 File Offset: 0x0091E9F1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PerformanceDisableLight_MP4_OnlyEditor_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602009A RID: 131226 RVA: 0x00920808 File Offset: 0x0091EA08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_PerformanceDisableLight_MP4_OnlyEditor_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PerformanceDisableLight_MP4_OnlyEditor_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PerformanceDisableLight_MP4_OnlyEditor_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PerformanceDisableLight_MP4_OnlyEditor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PerformanceDisableLight_MP4_OnlyEditor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602009B RID: 131227 RVA: 0x00920850 File Offset: 0x0091EA50
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_PerformanceDisableLight_MP4_OnlyEditor_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PerformanceDisableLight_MP4_OnlyEditor_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PerformanceDisableLight_MP4_OnlyEditor_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PerformanceDisableLight_MP4_OnlyEditor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PerformanceDisableLight_MP4_OnlyEditor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602009C RID: 131228 RVA: 0x00920898 File Offset: 0x0091EA98
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_PerformanceDisableLight_MP4_OnlyEditor(int EntryPoint)
		{
			BP_PerformanceDisableLight_MP4_OnlyEditor_C.__ExecuteUbergraph_BP_PerformanceDisableLight_MP4_OnlyEditor_FunctionParams* ptr = stackalloc BP_PerformanceDisableLight_MP4_OnlyEditor_C.__ExecuteUbergraph_BP_PerformanceDisableLight_MP4_OnlyEditor_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_PerformanceDisableLight_MP4_OnlyEditor_C.__ExecuteUbergraph_BP_PerformanceDisableLight_MP4_OnlyEditor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PerformanceDisableLight_MP4_OnlyEditor_C.__ExecuteUbergraph_BP_PerformanceDisableLight_MP4_OnlyEditor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PerformanceDisableLight_MP4_OnlyEditor_C.__ExecuteUbergraph_BP_PerformanceDisableLight_MP4_OnlyEditor_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602009D RID: 131229 RVA: 0x009208DF File Offset: 0x0091EADF
		protected BP_PerformanceDisableLight_MP4_OnlyEditor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FF46 RID: 65350
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/Editor/BP_PerformanceDisableLight_MP4_OnlyEditor.BP_PerformanceDisableLight_MP4_OnlyEditor_C";

		// Token: 0x0400FF47 RID: 65351
		private static IntPtr _ClassPtr;

		// Token: 0x0400FF48 RID: 65352
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FF49 RID: 65353
		internal static int __PropertyOffset_0;

		// Token: 0x0400FF4A RID: 65354
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FF4B RID: 65355
		internal static int __PropertyOffset_1;

		// Token: 0x0400FF4C RID: 65356
		internal static int __PropertyOffset_2;

		// Token: 0x0400FF4D RID: 65357
		internal static int __PropertyOffset_3;

		// Token: 0x0400FF4E RID: 65358
		private static IntPtr __DisableLightFun_MP4_NativeFunctionPtr;

		// Token: 0x0400FF4F RID: 65359
		private static IntPtr __DisableLightFun_NativeFunctionPtr;

		// Token: 0x0400FF50 RID: 65360
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400FF51 RID: 65361
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400FF52 RID: 65362
		private static IntPtr __ExecuteUbergraph_BP_PerformanceDisableLight_MP4_OnlyEditor_NativeFunctionPtr;

		// Token: 0x0200994D RID: 39245
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031FB3 RID: 204723
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200994E RID: 39246
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_PerformanceDisableLight_MP4_OnlyEditor_FunctionParams
		{
			// Token: 0x04031FB4 RID: 204724
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
