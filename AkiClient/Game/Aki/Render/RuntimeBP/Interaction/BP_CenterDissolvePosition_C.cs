using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Interaction
{
	// Token: 0x02003C76 RID: 15478
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Interaction/BP_CenterDissolvePosition.BP_CenterDissolvePosition_C")]
	[UnrealStructLayout(1416, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1409)]
	public class BP_CenterDissolvePosition_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023F01 RID: 147201 RVA: 0x00990228 File Offset: 0x0098E428
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CenterDissolvePosition_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Interaction/BP_CenterDissolvePosition.BP_CenterDissolvePosition_C");
			}
			return BP_CenterDissolvePosition_C._ClassPtr;
		}

		// Token: 0x06023F02 RID: 147202 RVA: 0x0099024C File Offset: 0x0098E44C
		public BP_CenterDissolvePosition_C() : this(BuiltinUtils.AllocNativeUObject(BP_CenterDissolvePosition_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023F03 RID: 147203 RVA: 0x00990274 File Offset: 0x0098E474
		[NullableContext(1)]
		public BP_CenterDissolvePosition_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CenterDissolvePosition_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004924 RID: 18724
		// (get) Token: 0x06023F04 RID: 147204 RVA: 0x009902A8 File Offset: 0x0098E4A8
		// (set) Token: 0x06023F05 RID: 147205 RVA: 0x009902E1 File Offset: 0x0098E4E1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_CenterDissolvePosition_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_CenterDissolvePosition_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004925 RID: 18725
		// (get) Token: 0x06023F06 RID: 147206 RVA: 0x00990302 File Offset: 0x0098E502
		// (set) Token: 0x06023F07 RID: 147207 RVA: 0x00990316 File Offset: 0x0098E516
		public unsafe USceneComponent DissolveCenter
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CenterDissolvePosition_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CenterDissolvePosition_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004926 RID: 18726
		// (get) Token: 0x06023F08 RID: 147208 RVA: 0x0099032B File Offset: 0x0098E52B
		// (set) Token: 0x06023F09 RID: 147209 RVA: 0x0099033F File Offset: 0x0098E53F
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CenterDissolvePosition_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CenterDissolvePosition_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004927 RID: 18727
		// (get) Token: 0x06023F0A RID: 147210 RVA: 0x00990354 File Offset: 0x0098E554
		// (set) Token: 0x06023F0B RID: 147211 RVA: 0x00990368 File Offset: 0x0098E568
		public unsafe UTexture2D T_Noise
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CenterDissolvePosition_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CenterDissolvePosition_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004928 RID: 18728
		// (get) Token: 0x06023F0C RID: 147212 RVA: 0x0099037D File Offset: 0x0098E57D
		// (set) Token: 0x06023F0D RID: 147213 RVA: 0x0099038D File Offset: 0x0098E58D
		public unsafe float Dist_UV
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CenterDissolvePosition_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CenterDissolvePosition_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17004929 RID: 18729
		// (get) Token: 0x06023F0E RID: 147214 RVA: 0x0099039E File Offset: 0x0098E59E
		// (set) Token: 0x06023F0F RID: 147215 RVA: 0x009903B2 File Offset: 0x0098E5B2
		public unsafe FLinearColor EmissiveColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CenterDissolvePosition_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CenterDissolvePosition_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700492A RID: 18730
		// (get) Token: 0x06023F10 RID: 147216 RVA: 0x009903C7 File Offset: 0x0098E5C7
		// (set) Token: 0x06023F11 RID: 147217 RVA: 0x009903DB File Offset: 0x0098E5DB
		public unsafe FVector CubeSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CenterDissolvePosition_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CenterDissolvePosition_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700492B RID: 18731
		// (get) Token: 0x06023F12 RID: 147218 RVA: 0x009903F0 File Offset: 0x0098E5F0
		// (set) Token: 0x06023F13 RID: 147219 RVA: 0x00990400 File Offset: 0x0098E600
		public unsafe float DissolveRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CenterDissolvePosition_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CenterDissolvePosition_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700492C RID: 18732
		// (get) Token: 0x06023F14 RID: 147220 RVA: 0x00990411 File Offset: 0x0098E611
		// (set) Token: 0x06023F15 RID: 147221 RVA: 0x00990421 File Offset: 0x0098E621
		public unsafe float EdgeFade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CenterDissolvePosition_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CenterDissolvePosition_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700492D RID: 18733
		// (get) Token: 0x06023F16 RID: 147222 RVA: 0x00990432 File Offset: 0x0098E632
		// (set) Token: 0x06023F17 RID: 147223 RVA: 0x00990442 File Offset: 0x0098E642
		public unsafe float DissolveEdgeWidth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CenterDissolvePosition_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CenterDissolvePosition_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x1700492E RID: 18734
		// (get) Token: 0x06023F18 RID: 147224 RVA: 0x00990454 File Offset: 0x0098E654
		// (set) Token: 0x06023F19 RID: 147225 RVA: 0x0099048D File Offset: 0x0098E68D
		[Nullable(1)]
		public TArray<UMaterialInstanceDynamic> StaticMeshDMI
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceDynamic> result;
				if ((result = this._StaticMeshDMI) == null)
				{
					result = (this._StaticMeshDMI = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)BP_CenterDissolvePosition_C.__PropertyOffset_10, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.StaticMeshDMI.CopyAssign(value);
			}
		}

		// Token: 0x1700492F RID: 18735
		// (get) Token: 0x06023F1A RID: 147226 RVA: 0x0099049B File Offset: 0x0098E69B
		// (set) Token: 0x06023F1B RID: 147227 RVA: 0x009904AB File Offset: 0x0098E6AB
		public unsafe bool DMISet
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CenterDissolvePosition_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CenterDissolvePosition_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x06023F1C RID: 147228 RVA: 0x009904BC File Offset: 0x0098E6BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_Dissolve_Param()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CenterDissolvePosition_C.__Set_Dissolve_Param_NativeFunctionPtr, null);
		}

		// Token: 0x06023F1D RID: 147229 RVA: 0x009904D0 File Offset: 0x0098E6D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Create_Dynamic_Material_Instance()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CenterDissolvePosition_C.__Create_Dynamic_Material_Instance_NativeFunctionPtr, null);
		}

		// Token: 0x06023F1E RID: 147230 RVA: 0x009904E4 File Offset: 0x0098E6E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CenterDissolvePosition_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06023F1F RID: 147231 RVA: 0x009904F8 File Offset: 0x0098E6F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CenterDissolvePosition_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023F20 RID: 147232 RVA: 0x00990510 File Offset: 0x0098E710
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_CenterDissolvePosition_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CenterDissolvePosition_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CenterDissolvePosition_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CenterDissolvePosition_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CenterDissolvePosition_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023F21 RID: 147233 RVA: 0x00990558 File Offset: 0x0098E758
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_CenterDissolvePosition_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CenterDissolvePosition_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CenterDissolvePosition_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CenterDissolvePosition_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CenterDissolvePosition_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023F22 RID: 147234 RVA: 0x009905A0 File Offset: 0x0098E7A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_CenterDissolvePosition_C.__EditorTick_FunctionParams* ptr = stackalloc BP_CenterDissolvePosition_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CenterDissolvePosition_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CenterDissolvePosition_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CenterDissolvePosition_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023F23 RID: 147235 RVA: 0x009905E8 File Offset: 0x0098E7E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_CenterDissolvePosition_C.__EditorTick_FunctionParams* ptr = stackalloc BP_CenterDissolvePosition_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CenterDissolvePosition_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CenterDissolvePosition_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CenterDissolvePosition_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023F24 RID: 147236 RVA: 0x00990630 File Offset: 0x0098E830
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_CenterDissolvePosition(int EntryPoint)
		{
			BP_CenterDissolvePosition_C.__ExecuteUbergraph_BP_CenterDissolvePosition_FunctionParams* ptr = stackalloc BP_CenterDissolvePosition_C.__ExecuteUbergraph_BP_CenterDissolvePosition_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(BP_CenterDissolvePosition_C.__ExecuteUbergraph_BP_CenterDissolvePosition_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CenterDissolvePosition_C.__ExecuteUbergraph_BP_CenterDissolvePosition_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CenterDissolvePosition_C.__ExecuteUbergraph_BP_CenterDissolvePosition_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023F25 RID: 147237 RVA: 0x00990677 File Offset: 0x0098E877
		protected BP_CenterDissolvePosition_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040125BB RID: 75195
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Interaction/BP_CenterDissolvePosition.BP_CenterDissolvePosition_C";

		// Token: 0x040125BC RID: 75196
		private static IntPtr _ClassPtr;

		// Token: 0x040125BD RID: 75197
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040125BE RID: 75198
		internal static int __PropertyOffset_0;

		// Token: 0x040125BF RID: 75199
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040125C0 RID: 75200
		internal static int __PropertyOffset_1;

		// Token: 0x040125C1 RID: 75201
		internal static int __PropertyOffset_2;

		// Token: 0x040125C2 RID: 75202
		internal static int __PropertyOffset_3;

		// Token: 0x040125C3 RID: 75203
		internal static int __PropertyOffset_4;

		// Token: 0x040125C4 RID: 75204
		internal static int __PropertyOffset_5;

		// Token: 0x040125C5 RID: 75205
		internal static int __PropertyOffset_6;

		// Token: 0x040125C6 RID: 75206
		internal static int __PropertyOffset_7;

		// Token: 0x040125C7 RID: 75207
		internal static int __PropertyOffset_8;

		// Token: 0x040125C8 RID: 75208
		internal static int __PropertyOffset_9;

		// Token: 0x040125C9 RID: 75209
		internal static int __PropertyOffset_10;

		// Token: 0x040125CA RID: 75210
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _StaticMeshDMI;

		// Token: 0x040125CB RID: 75211
		internal static int __PropertyOffset_11;

		// Token: 0x040125CC RID: 75212
		private static IntPtr __Set_Dissolve_Param_NativeFunctionPtr;

		// Token: 0x040125CD RID: 75213
		private static IntPtr __Create_Dynamic_Material_Instance_NativeFunctionPtr;

		// Token: 0x040125CE RID: 75214
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040125CF RID: 75215
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040125D0 RID: 75216
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x040125D1 RID: 75217
		private static IntPtr __ExecuteUbergraph_BP_CenterDissolvePosition_NativeFunctionPtr;

		// Token: 0x02009D66 RID: 40294
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403275B RID: 206683
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D67 RID: 40295
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x0403275C RID: 206684
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D68 RID: 40296
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __ExecuteUbergraph_BP_CenterDissolvePosition_FunctionParams
		{
			// Token: 0x0403275D RID: 206685
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
