using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Sequence.Seq_BP.SeqStreamingSource
{
	// Token: 0x0200439A RID: 17306
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Sequence/Seq_BP/SeqStreamingSource/BP_KuroStreamingSourceProxy_Seq.BP_KuroStreamingSourceProxy_Seq_C")]
	[UnrealStructLayout(1352, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1348)]
	public class BP_KuroStreamingSourceProxy_Seq_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DE82 RID: 188034 RVA: 0x00AD0DB1 File Offset: 0x00ACEFB1
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroStreamingSourceProxy_Seq_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Sequence/Seq_BP/SeqStreamingSource/BP_KuroStreamingSourceProxy_Seq.BP_KuroStreamingSourceProxy_Seq_C");
			}
			return BP_KuroStreamingSourceProxy_Seq_C._ClassPtr;
		}

		// Token: 0x0602DE83 RID: 188035 RVA: 0x00AD0DD8 File Offset: 0x00ACEFD8
		public BP_KuroStreamingSourceProxy_Seq_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroStreamingSourceProxy_Seq_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DE84 RID: 188036 RVA: 0x00AD0E00 File Offset: 0x00ACF000
		public BP_KuroStreamingSourceProxy_Seq_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroStreamingSourceProxy_Seq_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007DEE RID: 32238
		// (get) Token: 0x0602DE85 RID: 188037 RVA: 0x00AD0E34 File Offset: 0x00ACF034
		// (set) Token: 0x0602DE86 RID: 188038 RVA: 0x00AD0E6D File Offset: 0x00ACF06D
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_KuroStreamingSourceProxy_Seq_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroStreamingSourceProxy_Seq_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007DEF RID: 32239
		// (get) Token: 0x0602DE87 RID: 188039 RVA: 0x00AD0E8E File Offset: 0x00ACF08E
		// (set) Token: 0x0602DE88 RID: 188040 RVA: 0x00AD0EA2 File Offset: 0x00ACF0A2
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroStreamingSourceProxy_Seq_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroStreamingSourceProxy_Seq_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007DF0 RID: 32240
		// (get) Token: 0x0602DE89 RID: 188041 RVA: 0x00AD0EB7 File Offset: 0x00ACF0B7
		// (set) Token: 0x0602DE8A RID: 188042 RVA: 0x00AD0ECB File Offset: 0x00ACF0CB
		public unsafe string CurrSpeed
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_KuroStreamingSourceProxy_Seq_C.__PropertyOffset_2)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_KuroStreamingSourceProxy_Seq_C.__PropertyOffset_2)), value);
			}
		}

		// Token: 0x17007DF1 RID: 32241
		// (get) Token: 0x0602DE8B RID: 188043 RVA: 0x00AD0EE0 File Offset: 0x00ACF0E0
		// (set) Token: 0x0602DE8C RID: 188044 RVA: 0x00AD0EF0 File Offset: 0x00ACF0F0
		public unsafe float velocity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroStreamingSourceProxy_Seq_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroStreamingSourceProxy_Seq_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x0602DE8D RID: 188045 RVA: 0x00AD0F04 File Offset: 0x00ACF104
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_KuroStreamingSourceProxy_Seq_C.__EditorTick_FunctionParams* ptr = stackalloc BP_KuroStreamingSourceProxy_Seq_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroStreamingSourceProxy_Seq_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroStreamingSourceProxy_Seq_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroStreamingSourceProxy_Seq_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DE8E RID: 188046 RVA: 0x00AD0F4C File Offset: 0x00ACF14C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_KuroStreamingSourceProxy_Seq_C.__EditorTick_FunctionParams* ptr = stackalloc BP_KuroStreamingSourceProxy_Seq_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroStreamingSourceProxy_Seq_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroStreamingSourceProxy_Seq_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroStreamingSourceProxy_Seq_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602DE8F RID: 188047 RVA: 0x00AD0F94 File Offset: 0x00ACF194
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_KuroStreamingSourceProxy_Seq(int EntryPoint)
		{
			BP_KuroStreamingSourceProxy_Seq_C.__ExecuteUbergraph_BP_KuroStreamingSourceProxy_Seq_FunctionParams* ptr = stackalloc BP_KuroStreamingSourceProxy_Seq_C.__ExecuteUbergraph_BP_KuroStreamingSourceProxy_Seq_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(BP_KuroStreamingSourceProxy_Seq_C.__ExecuteUbergraph_BP_KuroStreamingSourceProxy_Seq_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroStreamingSourceProxy_Seq_C.__ExecuteUbergraph_BP_KuroStreamingSourceProxy_Seq_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroStreamingSourceProxy_Seq_C.__ExecuteUbergraph_BP_KuroStreamingSourceProxy_Seq_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602DE90 RID: 188048 RVA: 0x00AD0FDB File Offset: 0x00ACF1DB
		protected BP_KuroStreamingSourceProxy_Seq_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019F0C RID: 106252
		public new const string __ObjectPath = "/Game/Aki/Sequence/Seq_BP/SeqStreamingSource/BP_KuroStreamingSourceProxy_Seq.BP_KuroStreamingSourceProxy_Seq_C";

		// Token: 0x04019F0D RID: 106253
		private static IntPtr _ClassPtr;

		// Token: 0x04019F0E RID: 106254
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019F0F RID: 106255
		internal static int __PropertyOffset_0;

		// Token: 0x04019F10 RID: 106256
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04019F11 RID: 106257
		internal static int __PropertyOffset_1;

		// Token: 0x04019F12 RID: 106258
		internal static int __PropertyOffset_2;

		// Token: 0x04019F13 RID: 106259
		internal static int __PropertyOffset_3;

		// Token: 0x04019F14 RID: 106260
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04019F15 RID: 106261
		private static IntPtr __ExecuteUbergraph_BP_KuroStreamingSourceProxy_Seq_NativeFunctionPtr;

		// Token: 0x0200A5E6 RID: 42470
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04033589 RID: 210313
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A5E7 RID: 42471
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected ref struct __ExecuteUbergraph_BP_KuroStreamingSourceProxy_Seq_FunctionParams
		{
			// Token: 0x0403358A RID: 210314
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
