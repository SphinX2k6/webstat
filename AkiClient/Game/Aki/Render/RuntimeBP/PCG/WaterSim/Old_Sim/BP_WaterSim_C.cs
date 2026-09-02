using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.WaterSim.Old_Sim
{
	// Token: 0x02003B4C RID: 15180
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/WaterSim/Old_Sim/BP_WaterSim.BP_WaterSim_C")]
	[UnrealStructLayout(1464, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1457)]
	public class BP_WaterSim_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020EDE RID: 134878 RVA: 0x0093B274 File Offset: 0x00939474
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_WaterSim_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/WaterSim/Old_Sim/BP_WaterSim.BP_WaterSim_C");
			}
			return BP_WaterSim_C._ClassPtr;
		}

		// Token: 0x06020EDF RID: 134879 RVA: 0x0093B298 File Offset: 0x00939498
		public BP_WaterSim_C() : this(BuiltinUtils.AllocNativeUObject(BP_WaterSim_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020EE0 RID: 134880 RVA: 0x0093B2C0 File Offset: 0x009394C0
		[NullableContext(1)]
		public BP_WaterSim_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_WaterSim_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003807 RID: 14343
		// (get) Token: 0x06020EE1 RID: 134881 RVA: 0x0093B2F4 File Offset: 0x009394F4
		// (set) Token: 0x06020EE2 RID: 134882 RVA: 0x0093B32D File Offset: 0x0093952D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_WaterSim_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_WaterSim_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003808 RID: 14344
		// (get) Token: 0x06020EE3 RID: 134883 RVA: 0x0093B34E File Offset: 0x0093954E
		// (set) Token: 0x06020EE4 RID: 134884 RVA: 0x0093B362 File Offset: 0x00939562
		public unsafe UStaticMeshComponent WaterSource
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSim_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSim_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003809 RID: 14345
		// (get) Token: 0x06020EE5 RID: 134885 RVA: 0x0093B377 File Offset: 0x00939577
		// (set) Token: 0x06020EE6 RID: 134886 RVA: 0x0093B38B File Offset: 0x0093958B
		public unsafe UStaticMeshComponent SM_Plane512x512
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSim_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSim_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700380A RID: 14346
		// (get) Token: 0x06020EE7 RID: 134887 RVA: 0x0093B3A0 File Offset: 0x009395A0
		// (set) Token: 0x06020EE8 RID: 134888 RVA: 0x0093B3B4 File Offset: 0x009395B4
		public unsafe UBoxComponent Sim_Volume
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSim_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSim_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700380B RID: 14347
		// (get) Token: 0x06020EE9 RID: 134889 RVA: 0x0093B3C9 File Offset: 0x009395C9
		// (set) Token: 0x06020EEA RID: 134890 RVA: 0x0093B3DD File Offset: 0x009395DD
		public unsafe USceneCaptureComponent2D SceneCaptureComponent2D
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneCaptureComponent2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSim_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSim_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700380C RID: 14348
		// (get) Token: 0x06020EEB RID: 134891 RVA: 0x0093B3F2 File Offset: 0x009395F2
		// (set) Token: 0x06020EEC RID: 134892 RVA: 0x0093B406 File Offset: 0x00939606
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSim_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSim_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x1700380D RID: 14349
		// (get) Token: 0x06020EED RID: 134893 RVA: 0x0093B41B File Offset: 0x0093961B
		// (set) Token: 0x06020EEE RID: 134894 RVA: 0x0093B42B File Offset: 0x0093962B
		public unsafe int SimSize_M_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSim_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSim_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700380E RID: 14350
		// (get) Token: 0x06020EEF RID: 134895 RVA: 0x0093B43C File Offset: 0x0093963C
		// (set) Token: 0x06020EF0 RID: 134896 RVA: 0x0093B450 File Offset: 0x00939650
		public unsafe UMaterial M_Height
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSim_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSim_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x1700380F RID: 14351
		// (get) Token: 0x06020EF1 RID: 134897 RVA: 0x0093B465 File Offset: 0x00939665
		// (set) Token: 0x06020EF2 RID: 134898 RVA: 0x0093B479 File Offset: 0x00939679
		public unsafe UMaterial M_Velocity
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSim_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSim_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17003810 RID: 14352
		// (get) Token: 0x06020EF3 RID: 134899 RVA: 0x0093B48E File Offset: 0x0093968E
		// (set) Token: 0x06020EF4 RID: 134900 RVA: 0x0093B4A2 File Offset: 0x009396A2
		public unsafe UMaterial M_Blur
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSim_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSim_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17003811 RID: 14353
		// (get) Token: 0x06020EF5 RID: 134901 RVA: 0x0093B4B7 File Offset: 0x009396B7
		// (set) Token: 0x06020EF6 RID: 134902 RVA: 0x0093B4CB File Offset: 0x009396CB
		public unsafe UMaterial M_PreView
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSim_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSim_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17003812 RID: 14354
		// (get) Token: 0x06020EF7 RID: 134903 RVA: 0x0093B4E0 File Offset: 0x009396E0
		// (set) Token: 0x06020EF8 RID: 134904 RVA: 0x0093B4F4 File Offset: 0x009396F4
		public unsafe UMaterial M_Water_Clear
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSim_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSim_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17003813 RID: 14355
		// (get) Token: 0x06020EF9 RID: 134905 RVA: 0x0093B509 File Offset: 0x00939709
		// (set) Token: 0x06020EFA RID: 134906 RVA: 0x0093B51D File Offset: 0x0093971D
		public unsafe UMaterialInstanceDynamic MI_Velocity
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSim_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSim_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17003814 RID: 14356
		// (get) Token: 0x06020EFB RID: 134907 RVA: 0x0093B532 File Offset: 0x00939732
		// (set) Token: 0x06020EFC RID: 134908 RVA: 0x0093B546 File Offset: 0x00939746
		public unsafe UMaterialInstanceDynamic MI_Height
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSim_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSim_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17003815 RID: 14357
		// (get) Token: 0x06020EFD RID: 134909 RVA: 0x0093B55B File Offset: 0x0093975B
		// (set) Token: 0x06020EFE RID: 134910 RVA: 0x0093B56F File Offset: 0x0093976F
		public unsafe UMaterialInstanceDynamic MI_Blur
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSim_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSim_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17003816 RID: 14358
		// (get) Token: 0x06020EFF RID: 134911 RVA: 0x0093B584 File Offset: 0x00939784
		// (set) Token: 0x06020F00 RID: 134912 RVA: 0x0093B598 File Offset: 0x00939798
		public unsafe UMaterialInstanceDynamic MI_PreView
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSim_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSim_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x17003817 RID: 14359
		// (get) Token: 0x06020F01 RID: 134913 RVA: 0x0093B5AD File Offset: 0x009397AD
		// (set) Token: 0x06020F02 RID: 134914 RVA: 0x0093B5C1 File Offset: 0x009397C1
		public unsafe UTextureRenderTarget RT_HeightMap
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSim_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSim_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x17003818 RID: 14360
		// (get) Token: 0x06020F03 RID: 134915 RVA: 0x0093B5D6 File Offset: 0x009397D6
		// (set) Token: 0x06020F04 RID: 134916 RVA: 0x0093B5EA File Offset: 0x009397EA
		public unsafe UTextureRenderTarget RT_Water_VelocityHeightFoam
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSim_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSim_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17003819 RID: 14361
		// (get) Token: 0x06020F05 RID: 134917 RVA: 0x0093B5FF File Offset: 0x009397FF
		// (set) Token: 0x06020F06 RID: 134918 RVA: 0x0093B613 File Offset: 0x00939813
		public unsafe UTextureRenderTarget RT_Water_VelocityHeightFoam_Temp
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSim_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSim_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x1700381A RID: 14362
		// (get) Token: 0x06020F07 RID: 134919 RVA: 0x0093B628 File Offset: 0x00939828
		// (set) Token: 0x06020F08 RID: 134920 RVA: 0x0093B638 File Offset: 0x00939838
		public unsafe bool Sim
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSim_C.__PropertyOffset_19) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSim_C.__PropertyOffset_19) = (value ? 1 : 0);
			}
		}

		// Token: 0x06020F09 RID: 134921 RVA: 0x0093B649 File Offset: 0x00939849
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ClearWater()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSim_C.__ClearWater_NativeFunctionPtr, null);
		}

		// Token: 0x06020F0A RID: 134922 RVA: 0x0093B65D File Offset: 0x0093985D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSim_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06020F0B RID: 134923 RVA: 0x0093B671 File Offset: 0x00939871
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterSim_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020F0C RID: 134924 RVA: 0x0093B688 File Offset: 0x00939888
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_WaterSim_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WaterSim_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WaterSim_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSim_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSim_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020F0D RID: 134925 RVA: 0x0093B6D0 File Offset: 0x009398D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_WaterSim_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WaterSim_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WaterSim_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSim_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterSim_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020F0E RID: 134926 RVA: 0x0093B717 File Offset: 0x00939917
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSim_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x06020F0F RID: 134927 RVA: 0x0093B72C File Offset: 0x0093992C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_WaterSim(int EntryPoint)
		{
			BP_WaterSim_C.__ExecuteUbergraph_BP_WaterSim_FunctionParams* ptr = stackalloc BP_WaterSim_C.__ExecuteUbergraph_BP_WaterSim_FunctionParams[(UIntPtr)43] + 15L / (long)sizeof(BP_WaterSim_C.__ExecuteUbergraph_BP_WaterSim_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSim_C.__ExecuteUbergraph_BP_WaterSim_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterSim_C.__ExecuteUbergraph_BP_WaterSim_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020F10 RID: 134928 RVA: 0x0093B773 File Offset: 0x00939973
		protected BP_WaterSim_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010877 RID: 67703
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/WaterSim/Old_Sim/BP_WaterSim.BP_WaterSim_C";

		// Token: 0x04010878 RID: 67704
		private static IntPtr _ClassPtr;

		// Token: 0x04010879 RID: 67705
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401087A RID: 67706
		internal static int __PropertyOffset_0;

		// Token: 0x0401087B RID: 67707
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401087C RID: 67708
		internal static int __PropertyOffset_1;

		// Token: 0x0401087D RID: 67709
		internal static int __PropertyOffset_2;

		// Token: 0x0401087E RID: 67710
		internal static int __PropertyOffset_3;

		// Token: 0x0401087F RID: 67711
		internal static int __PropertyOffset_4;

		// Token: 0x04010880 RID: 67712
		internal static int __PropertyOffset_5;

		// Token: 0x04010881 RID: 67713
		internal static int __PropertyOffset_6;

		// Token: 0x04010882 RID: 67714
		internal static int __PropertyOffset_7;

		// Token: 0x04010883 RID: 67715
		internal static int __PropertyOffset_8;

		// Token: 0x04010884 RID: 67716
		internal static int __PropertyOffset_9;

		// Token: 0x04010885 RID: 67717
		internal static int __PropertyOffset_10;

		// Token: 0x04010886 RID: 67718
		internal static int __PropertyOffset_11;

		// Token: 0x04010887 RID: 67719
		internal static int __PropertyOffset_12;

		// Token: 0x04010888 RID: 67720
		internal static int __PropertyOffset_13;

		// Token: 0x04010889 RID: 67721
		internal static int __PropertyOffset_14;

		// Token: 0x0401088A RID: 67722
		internal static int __PropertyOffset_15;

		// Token: 0x0401088B RID: 67723
		internal static int __PropertyOffset_16;

		// Token: 0x0401088C RID: 67724
		internal static int __PropertyOffset_17;

		// Token: 0x0401088D RID: 67725
		internal static int __PropertyOffset_18;

		// Token: 0x0401088E RID: 67726
		internal static int __PropertyOffset_19;

		// Token: 0x0401088F RID: 67727
		private static IntPtr __ClearWater_NativeFunctionPtr;

		// Token: 0x04010890 RID: 67728
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010891 RID: 67729
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010892 RID: 67730
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04010893 RID: 67731
		private static IntPtr __ExecuteUbergraph_BP_WaterSim_NativeFunctionPtr;

		// Token: 0x02009A51 RID: 39505
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032152 RID: 205138
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A52 RID: 39506
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 28)]
		protected ref struct __ExecuteUbergraph_BP_WaterSim_FunctionParams
		{
			// Token: 0x04032153 RID: 205139
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
