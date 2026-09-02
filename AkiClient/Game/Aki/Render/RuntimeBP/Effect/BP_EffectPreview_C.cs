using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect
{
	// Token: 0x02003D1F RID: 15647
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/BP_EffectPreview.BP_EffectPreview_C")]
	[UnrealStructLayout(1064, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1064)]
	public class BP_EffectPreview_C : AKuroEffectActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025D5F RID: 154975 RVA: 0x009C67DC File Offset: 0x009C49DC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_EffectPreview_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Effect/BP_EffectPreview.BP_EffectPreview_C");
			}
			return BP_EffectPreview_C._ClassPtr;
		}

		// Token: 0x06025D60 RID: 154976 RVA: 0x009C6800 File Offset: 0x009C4A00
		public BP_EffectPreview_C() : this(BuiltinUtils.AllocNativeUObject(BP_EffectPreview_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025D61 RID: 154977 RVA: 0x009C6828 File Offset: 0x009C4A28
		[NullableContext(1)]
		public BP_EffectPreview_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_EffectPreview_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170053FD RID: 21501
		// (get) Token: 0x06025D62 RID: 154978 RVA: 0x009C685C File Offset: 0x009C4A5C
		// (set) Token: 0x06025D63 RID: 154979 RVA: 0x009C6895 File Offset: 0x009C4A95
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_EffectPreview_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectPreview_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170053FE RID: 21502
		// (get) Token: 0x06025D64 RID: 154980 RVA: 0x009C68B6 File Offset: 0x009C4AB6
		// (set) Token: 0x06025D65 RID: 154981 RVA: 0x009C68CA File Offset: 0x009C4ACA
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectPreview_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectPreview_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170053FF RID: 21503
		// (get) Token: 0x06025D66 RID: 154982 RVA: 0x009C68DF File Offset: 0x009C4ADF
		// (set) Token: 0x06025D67 RID: 154983 RVA: 0x009C68EF File Offset: 0x009C4AEF
		public unsafe int EffectView
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectPreview_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectPreview_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005400 RID: 21504
		// (get) Token: 0x06025D68 RID: 154984 RVA: 0x009C6900 File Offset: 0x009C4B00
		// (set) Token: 0x06025D69 RID: 154985 RVA: 0x009C6910 File Offset: 0x009C4B10
		public unsafe int Transient
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectPreview_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectPreview_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x06025D6A RID: 154986 RVA: 0x009C6921 File Offset: 0x009C4B21
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_EffectPreview_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06025D6B RID: 154987 RVA: 0x009C6935 File Offset: 0x009C4B35
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_EffectPreview_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025D6C RID: 154988 RVA: 0x009C694C File Offset: 0x009C4B4C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_EffectPreview_C.__EditorTick_FunctionParams* ptr = stackalloc BP_EffectPreview_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_EffectPreview_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_EffectPreview_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_EffectPreview_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025D6D RID: 154989 RVA: 0x009C6994 File Offset: 0x009C4B94
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_EffectPreview_C.__EditorTick_FunctionParams* ptr = stackalloc BP_EffectPreview_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_EffectPreview_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_EffectPreview_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_EffectPreview_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025D6E RID: 154990 RVA: 0x009C69DC File Offset: 0x009C4BDC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_EffectPreview(int EntryPoint)
		{
			BP_EffectPreview_C.__ExecuteUbergraph_BP_EffectPreview_FunctionParams* ptr = stackalloc BP_EffectPreview_C.__ExecuteUbergraph_BP_EffectPreview_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_EffectPreview_C.__ExecuteUbergraph_BP_EffectPreview_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_EffectPreview_C.__ExecuteUbergraph_BP_EffectPreview_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_EffectPreview_C.__ExecuteUbergraph_BP_EffectPreview_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025D6F RID: 154991 RVA: 0x009C6A23 File Offset: 0x009C4C23
		protected BP_EffectPreview_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040138DD RID: 80093
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/BP_EffectPreview.BP_EffectPreview_C";

		// Token: 0x040138DE RID: 80094
		private static IntPtr _ClassPtr;

		// Token: 0x040138DF RID: 80095
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040138E0 RID: 80096
		internal static int __PropertyOffset_0;

		// Token: 0x040138E1 RID: 80097
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040138E2 RID: 80098
		internal static int __PropertyOffset_1;

		// Token: 0x040138E3 RID: 80099
		internal static int __PropertyOffset_2;

		// Token: 0x040138E4 RID: 80100
		internal static int __PropertyOffset_3;

		// Token: 0x040138E5 RID: 80101
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040138E6 RID: 80102
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x040138E7 RID: 80103
		private static IntPtr __ExecuteUbergraph_BP_EffectPreview_NativeFunctionPtr;

		// Token: 0x02009FC3 RID: 40899
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032B7B RID: 207739
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009FC4 RID: 40900
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_EffectPreview_FunctionParams
		{
			// Token: 0x04032B7C RID: 207740
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
