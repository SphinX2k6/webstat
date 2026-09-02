using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FarRotatorCloud
{
	// Token: 0x02003D1B RID: 15643
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/FarRotatorCloud/BP_FarRotatorCloud.BP_FarRotatorCloud_C")]
	[UnrealStructLayout(1440, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1436)]
	public class BP_FarRotatorCloud_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025CBF RID: 154815 RVA: 0x009C551C File Offset: 0x009C371C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FarRotatorCloud_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/FarRotatorCloud/BP_FarRotatorCloud.BP_FarRotatorCloud_C");
			}
			return BP_FarRotatorCloud_C._ClassPtr;
		}

		// Token: 0x06025CC0 RID: 154816 RVA: 0x009C5540 File Offset: 0x009C3740
		public BP_FarRotatorCloud_C() : this(BuiltinUtils.AllocNativeUObject(BP_FarRotatorCloud_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025CC1 RID: 154817 RVA: 0x009C5568 File Offset: 0x009C3768
		[NullableContext(1)]
		public BP_FarRotatorCloud_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FarRotatorCloud_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170053C8 RID: 21448
		// (get) Token: 0x06025CC2 RID: 154818 RVA: 0x009C559C File Offset: 0x009C379C
		// (set) Token: 0x06025CC3 RID: 154819 RVA: 0x009C55D5 File Offset: 0x009C37D5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_FarRotatorCloud_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_FarRotatorCloud_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170053C9 RID: 21449
		// (get) Token: 0x06025CC4 RID: 154820 RVA: 0x009C55F6 File Offset: 0x009C37F6
		// (set) Token: 0x06025CC5 RID: 154821 RVA: 0x009C560A File Offset: 0x009C380A
		public unsafe UStaticMeshComponent Layer3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FarRotatorCloud_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FarRotatorCloud_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170053CA RID: 21450
		// (get) Token: 0x06025CC6 RID: 154822 RVA: 0x009C561F File Offset: 0x009C381F
		// (set) Token: 0x06025CC7 RID: 154823 RVA: 0x009C5633 File Offset: 0x009C3833
		public unsafe UStaticMeshComponent Layer2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FarRotatorCloud_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FarRotatorCloud_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170053CB RID: 21451
		// (get) Token: 0x06025CC8 RID: 154824 RVA: 0x009C5648 File Offset: 0x009C3848
		// (set) Token: 0x06025CC9 RID: 154825 RVA: 0x009C565C File Offset: 0x009C385C
		public unsafe UStaticMeshComponent Layer1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FarRotatorCloud_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FarRotatorCloud_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170053CC RID: 21452
		// (get) Token: 0x06025CCA RID: 154826 RVA: 0x009C5671 File Offset: 0x009C3871
		// (set) Token: 0x06025CCB RID: 154827 RVA: 0x009C5685 File Offset: 0x009C3885
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FarRotatorCloud_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FarRotatorCloud_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170053CD RID: 21453
		// (get) Token: 0x06025CCC RID: 154828 RVA: 0x009C569A File Offset: 0x009C389A
		// (set) Token: 0x06025CCD RID: 154829 RVA: 0x009C56AE File Offset: 0x009C38AE
		public unsafe UStaticMesh StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FarRotatorCloud_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FarRotatorCloud_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170053CE RID: 21454
		// (get) Token: 0x06025CCE RID: 154830 RVA: 0x009C56C3 File Offset: 0x009C38C3
		// (set) Token: 0x06025CCF RID: 154831 RVA: 0x009C56D3 File Offset: 0x009C38D3
		public unsafe bool Close_Billboard
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FarRotatorCloud_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FarRotatorCloud_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x170053CF RID: 21455
		// (get) Token: 0x06025CD0 RID: 154832 RVA: 0x009C56E4 File Offset: 0x009C38E4
		// (set) Token: 0x06025CD1 RID: 154833 RVA: 0x009C56F4 File Offset: 0x009C38F4
		public unsafe float CloudRotatorSpeed_Layer1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FarRotatorCloud_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FarRotatorCloud_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170053D0 RID: 21456
		// (get) Token: 0x06025CD2 RID: 154834 RVA: 0x009C5705 File Offset: 0x009C3905
		// (set) Token: 0x06025CD3 RID: 154835 RVA: 0x009C5715 File Offset: 0x009C3915
		public unsafe float CloudRotatorSpeed_Layer2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FarRotatorCloud_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FarRotatorCloud_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170053D1 RID: 21457
		// (get) Token: 0x06025CD4 RID: 154836 RVA: 0x009C5726 File Offset: 0x009C3926
		// (set) Token: 0x06025CD5 RID: 154837 RVA: 0x009C5736 File Offset: 0x009C3936
		public unsafe float CloudRotatorSpeed_Layer3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FarRotatorCloud_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FarRotatorCloud_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170053D2 RID: 21458
		// (get) Token: 0x06025CD6 RID: 154838 RVA: 0x009C5747 File Offset: 0x009C3947
		// (set) Token: 0x06025CD7 RID: 154839 RVA: 0x009C5757 File Offset: 0x009C3957
		public unsafe float WorldPositionOffset_Intansity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FarRotatorCloud_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FarRotatorCloud_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170053D3 RID: 21459
		// (get) Token: 0x06025CD8 RID: 154840 RVA: 0x009C5768 File Offset: 0x009C3968
		// (set) Token: 0x06025CD9 RID: 154841 RVA: 0x009C577C File Offset: 0x009C397C
		public unsafe UMaterialInstance Material_Layer1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FarRotatorCloud_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FarRotatorCloud_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x170053D4 RID: 21460
		// (get) Token: 0x06025CDA RID: 154842 RVA: 0x009C5791 File Offset: 0x009C3991
		// (set) Token: 0x06025CDB RID: 154843 RVA: 0x009C57A5 File Offset: 0x009C39A5
		public unsafe UMaterialInstance Material_Layer2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FarRotatorCloud_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FarRotatorCloud_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x170053D5 RID: 21461
		// (get) Token: 0x06025CDC RID: 154844 RVA: 0x009C57BA File Offset: 0x009C39BA
		// (set) Token: 0x06025CDD RID: 154845 RVA: 0x009C57CE File Offset: 0x009C39CE
		public unsafe UMaterialInstance Material_Layer3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FarRotatorCloud_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FarRotatorCloud_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x170053D6 RID: 21462
		// (get) Token: 0x06025CDE RID: 154846 RVA: 0x009C57E3 File Offset: 0x009C39E3
		// (set) Token: 0x06025CDF RID: 154847 RVA: 0x009C57F7 File Offset: 0x009C39F7
		public unsafe UMaterialInstanceDynamic MID_Material_Layer1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FarRotatorCloud_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FarRotatorCloud_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x170053D7 RID: 21463
		// (get) Token: 0x06025CE0 RID: 154848 RVA: 0x009C580C File Offset: 0x009C3A0C
		// (set) Token: 0x06025CE1 RID: 154849 RVA: 0x009C5820 File Offset: 0x009C3A20
		public unsafe UMaterialInstanceDynamic MID_Material_Layer2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FarRotatorCloud_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FarRotatorCloud_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x170053D8 RID: 21464
		// (get) Token: 0x06025CE2 RID: 154850 RVA: 0x009C5835 File Offset: 0x009C3A35
		// (set) Token: 0x06025CE3 RID: 154851 RVA: 0x009C5849 File Offset: 0x009C3A49
		public unsafe UMaterialInstanceDynamic MID_Material_Layer3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FarRotatorCloud_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FarRotatorCloud_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x170053D9 RID: 21465
		// (get) Token: 0x06025CE4 RID: 154852 RVA: 0x009C585E File Offset: 0x009C3A5E
		// (set) Token: 0x06025CE5 RID: 154853 RVA: 0x009C586E File Offset: 0x009C3A6E
		public unsafe float VolumeCloudFade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FarRotatorCloud_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FarRotatorCloud_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x06025CE6 RID: 154854 RVA: 0x009C587F File Offset: 0x009C3A7F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FarRotatorCloud_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06025CE7 RID: 154855 RVA: 0x009C5893 File Offset: 0x009C3A93
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FarRotatorCloud_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025CE8 RID: 154856 RVA: 0x009C58A8 File Offset: 0x009C3AA8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FarRotatorCloud_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06025CE9 RID: 154857 RVA: 0x009C58BC File Offset: 0x009C3ABC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FarRotatorCloud_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025CEA RID: 154858 RVA: 0x009C58D4 File Offset: 0x009C3AD4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_FarRotatorCloud_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_FarRotatorCloud_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FarRotatorCloud_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FarRotatorCloud_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FarRotatorCloud_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025CEB RID: 154859 RVA: 0x009C591C File Offset: 0x009C3B1C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_FarRotatorCloud_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_FarRotatorCloud_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FarRotatorCloud_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FarRotatorCloud_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FarRotatorCloud_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025CEC RID: 154860 RVA: 0x009C5964 File Offset: 0x009C3B64
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_FarRotatorCloud_C.__EditorTick_FunctionParams* ptr = stackalloc BP_FarRotatorCloud_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FarRotatorCloud_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FarRotatorCloud_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FarRotatorCloud_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025CED RID: 154861 RVA: 0x009C59AC File Offset: 0x009C3BAC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_FarRotatorCloud_C.__EditorTick_FunctionParams* ptr = stackalloc BP_FarRotatorCloud_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FarRotatorCloud_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FarRotatorCloud_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FarRotatorCloud_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025CEE RID: 154862 RVA: 0x009C59F4 File Offset: 0x009C3BF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_FarRotatorCloud(int EntryPoint)
		{
			BP_FarRotatorCloud_C.__ExecuteUbergraph_BP_FarRotatorCloud_FunctionParams* ptr = stackalloc BP_FarRotatorCloud_C.__ExecuteUbergraph_BP_FarRotatorCloud_FunctionParams[(UIntPtr)35] + 15L / (long)sizeof(BP_FarRotatorCloud_C.__ExecuteUbergraph_BP_FarRotatorCloud_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FarRotatorCloud_C.__ExecuteUbergraph_BP_FarRotatorCloud_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FarRotatorCloud_C.__ExecuteUbergraph_BP_FarRotatorCloud_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025CEF RID: 154863 RVA: 0x009C5A3B File Offset: 0x009C3C3B
		protected BP_FarRotatorCloud_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401387B RID: 79995
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FarRotatorCloud/BP_FarRotatorCloud.BP_FarRotatorCloud_C";

		// Token: 0x0401387C RID: 79996
		private static IntPtr _ClassPtr;

		// Token: 0x0401387D RID: 79997
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401387E RID: 79998
		internal static int __PropertyOffset_0;

		// Token: 0x0401387F RID: 79999
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04013880 RID: 80000
		internal static int __PropertyOffset_1;

		// Token: 0x04013881 RID: 80001
		internal static int __PropertyOffset_2;

		// Token: 0x04013882 RID: 80002
		internal static int __PropertyOffset_3;

		// Token: 0x04013883 RID: 80003
		internal static int __PropertyOffset_4;

		// Token: 0x04013884 RID: 80004
		internal static int __PropertyOffset_5;

		// Token: 0x04013885 RID: 80005
		internal static int __PropertyOffset_6;

		// Token: 0x04013886 RID: 80006
		internal static int __PropertyOffset_7;

		// Token: 0x04013887 RID: 80007
		internal static int __PropertyOffset_8;

		// Token: 0x04013888 RID: 80008
		internal static int __PropertyOffset_9;

		// Token: 0x04013889 RID: 80009
		internal static int __PropertyOffset_10;

		// Token: 0x0401388A RID: 80010
		internal static int __PropertyOffset_11;

		// Token: 0x0401388B RID: 80011
		internal static int __PropertyOffset_12;

		// Token: 0x0401388C RID: 80012
		internal static int __PropertyOffset_13;

		// Token: 0x0401388D RID: 80013
		internal static int __PropertyOffset_14;

		// Token: 0x0401388E RID: 80014
		internal static int __PropertyOffset_15;

		// Token: 0x0401388F RID: 80015
		internal static int __PropertyOffset_16;

		// Token: 0x04013890 RID: 80016
		internal static int __PropertyOffset_17;

		// Token: 0x04013891 RID: 80017
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04013892 RID: 80018
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04013893 RID: 80019
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04013894 RID: 80020
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04013895 RID: 80021
		private static IntPtr __ExecuteUbergraph_BP_FarRotatorCloud_NativeFunctionPtr;

		// Token: 0x02009FB3 RID: 40883
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032B69 RID: 207721
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009FB4 RID: 40884
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032B6A RID: 207722
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009FB5 RID: 40885
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 20)]
		protected ref struct __ExecuteUbergraph_BP_FarRotatorCloud_FunctionParams
		{
			// Token: 0x04032B6B RID: 207723
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
