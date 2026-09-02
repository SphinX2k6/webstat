using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.VortexCloud
{
	// Token: 0x02003C9C RID: 15516
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/VortexCloud/BP_VortexCloud.BP_VortexCloud_C")]
	[UnrealStructLayout(1432, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1426)]
	public class BP_VortexCloud_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602482C RID: 149548 RVA: 0x0099FB46 File Offset: 0x0099DD46
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_VortexCloud_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/VortexCloud/BP_VortexCloud.BP_VortexCloud_C");
			}
			return BP_VortexCloud_C._ClassPtr;
		}

		// Token: 0x0602482D RID: 149549 RVA: 0x0099FB6C File Offset: 0x0099DD6C
		public BP_VortexCloud_C() : this(BuiltinUtils.AllocNativeUObject(BP_VortexCloud_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602482E RID: 149550 RVA: 0x0099FB94 File Offset: 0x0099DD94
		[NullableContext(1)]
		public BP_VortexCloud_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_VortexCloud_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004C79 RID: 19577
		// (get) Token: 0x0602482F RID: 149551 RVA: 0x0099FBC8 File Offset: 0x0099DDC8
		// (set) Token: 0x06024830 RID: 149552 RVA: 0x0099FC01 File Offset: 0x0099DE01
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_VortexCloud_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_VortexCloud_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004C7A RID: 19578
		// (get) Token: 0x06024831 RID: 149553 RVA: 0x0099FC22 File Offset: 0x0099DE22
		// (set) Token: 0x06024832 RID: 149554 RVA: 0x0099FC36 File Offset: 0x0099DE36
		public unsafe UStaticMeshComponent SM_StromCloud_ES3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VortexCloud_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VortexCloud_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004C7B RID: 19579
		// (get) Token: 0x06024833 RID: 149555 RVA: 0x0099FC4B File Offset: 0x0099DE4B
		// (set) Token: 0x06024834 RID: 149556 RVA: 0x0099FC5F File Offset: 0x0099DE5F
		public unsafe UStaticMeshComponent SM_VortexCloud
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VortexCloud_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VortexCloud_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004C7C RID: 19580
		// (get) Token: 0x06024835 RID: 149557 RVA: 0x0099FC74 File Offset: 0x0099DE74
		// (set) Token: 0x06024836 RID: 149558 RVA: 0x0099FC88 File Offset: 0x0099DE88
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VortexCloud_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VortexCloud_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004C7D RID: 19581
		// (get) Token: 0x06024837 RID: 149559 RVA: 0x0099FC9D File Offset: 0x0099DE9D
		// (set) Token: 0x06024838 RID: 149560 RVA: 0x0099FCAD File Offset: 0x0099DEAD
		public unsafe bool Updata
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VortexCloud_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VortexCloud_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004C7E RID: 19582
		// (get) Token: 0x06024839 RID: 149561 RVA: 0x0099FCBE File Offset: 0x0099DEBE
		// (set) Token: 0x0602483A RID: 149562 RVA: 0x0099FCD2 File Offset: 0x0099DED2
		public unsafe UMaterialInstanceDynamic DMI_VortexCloud_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VortexCloud_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VortexCloud_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004C7F RID: 19583
		// (get) Token: 0x0602483B RID: 149563 RVA: 0x0099FCE7 File Offset: 0x0099DEE7
		// (set) Token: 0x0602483C RID: 149564 RVA: 0x0099FCFB File Offset: 0x0099DEFB
		public unsafe UMaterialInstanceDynamic DMI_VortexCloud_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VortexCloud_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VortexCloud_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17004C80 RID: 19584
		// (get) Token: 0x0602483D RID: 149565 RVA: 0x0099FD10 File Offset: 0x0099DF10
		// (set) Token: 0x0602483E RID: 149566 RVA: 0x0099FD24 File Offset: 0x0099DF24
		public unsafe UStaticMesh VortexCloudMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VortexCloud_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VortexCloud_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17004C81 RID: 19585
		// (get) Token: 0x0602483F RID: 149567 RVA: 0x0099FD39 File Offset: 0x0099DF39
		// (set) Token: 0x06024840 RID: 149568 RVA: 0x0099FD4D File Offset: 0x0099DF4D
		public unsafe UMaterialInstance Cloud_MaterialInstance
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VortexCloud_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VortexCloud_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17004C82 RID: 19586
		// (get) Token: 0x06024841 RID: 149569 RVA: 0x0099FD62 File Offset: 0x0099DF62
		// (set) Token: 0x06024842 RID: 149570 RVA: 0x0099FD72 File Offset: 0x0099DF72
		public unsafe float Scaler
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VortexCloud_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VortexCloud_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17004C83 RID: 19587
		// (get) Token: 0x06024843 RID: 149571 RVA: 0x0099FD83 File Offset: 0x0099DF83
		// (set) Token: 0x06024844 RID: 149572 RVA: 0x0099FD93 File Offset: 0x0099DF93
		public unsafe float WorldOffsetIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VortexCloud_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VortexCloud_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17004C84 RID: 19588
		// (get) Token: 0x06024845 RID: 149573 RVA: 0x0099FDA4 File Offset: 0x0099DFA4
		// (set) Token: 0x06024846 RID: 149574 RVA: 0x0099FDB4 File Offset: 0x0099DFB4
		public unsafe float FlowMap_DistortIntansity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VortexCloud_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VortexCloud_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17004C85 RID: 19589
		// (get) Token: 0x06024847 RID: 149575 RVA: 0x0099FDC5 File Offset: 0x0099DFC5
		// (set) Token: 0x06024848 RID: 149576 RVA: 0x0099FDD5 File Offset: 0x0099DFD5
		public unsafe float FlowMap_Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VortexCloud_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VortexCloud_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17004C86 RID: 19590
		// (get) Token: 0x06024849 RID: 149577 RVA: 0x0099FDE6 File Offset: 0x0099DFE6
		// (set) Token: 0x0602484A RID: 149578 RVA: 0x0099FDFA File Offset: 0x0099DFFA
		public unsafe AKuroPostProcessVolume Current_PostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AKuroPostProcessVolume>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VortexCloud_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VortexCloud_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17004C87 RID: 19591
		// (get) Token: 0x0602484B RID: 149579 RVA: 0x0099FE0F File Offset: 0x0099E00F
		// (set) Token: 0x0602484C RID: 149580 RVA: 0x0099FE23 File Offset: 0x0099E023
		public unsafe BP_GlobalGI_C BP_Global_GI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_GlobalGI_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VortexCloud_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VortexCloud_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17004C88 RID: 19592
		// (get) Token: 0x0602484D RID: 149581 RVA: 0x0099FE38 File Offset: 0x0099E038
		// (set) Token: 0x0602484E RID: 149582 RVA: 0x0099FE48 File Offset: 0x0099E048
		public unsafe bool Is_Android
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VortexCloud_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VortexCloud_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004C89 RID: 19593
		// (get) Token: 0x0602484F RID: 149583 RVA: 0x0099FE59 File Offset: 0x0099E059
		// (set) Token: 0x06024850 RID: 149584 RVA: 0x0099FE69 File Offset: 0x0099E069
		public unsafe bool Is_Haidao
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VortexCloud_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VortexCloud_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x06024851 RID: 149585 RVA: 0x0099FE7A File Offset: 0x0099E07A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Is_PC_Or_Android()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VortexCloud_C.__Is_PC_Or_Android_NativeFunctionPtr, null);
		}

		// Token: 0x06024852 RID: 149586 RVA: 0x0099FE8E File Offset: 0x0099E08E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_VortexParameters()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VortexCloud_C.__Set_VortexParameters_NativeFunctionPtr, null);
		}

		// Token: 0x06024853 RID: 149587 RVA: 0x0099FEA2 File Offset: 0x0099E0A2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_Current_Post_Process_Weight()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VortexCloud_C.__Set_Current_Post_Process_Weight_NativeFunctionPtr, null);
		}

		// Token: 0x06024854 RID: 149588 RVA: 0x0099FEB6 File Offset: 0x0099E0B6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VortexCloud_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06024855 RID: 149589 RVA: 0x0099FECA File Offset: 0x0099E0CA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VortexCloud_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024856 RID: 149590 RVA: 0x0099FEDF File Offset: 0x0099E0DF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VortexCloud_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06024857 RID: 149591 RVA: 0x0099FEF3 File Offset: 0x0099E0F3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VortexCloud_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024858 RID: 149592 RVA: 0x0099FF08 File Offset: 0x0099E108
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_VortexCloud_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_VortexCloud_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VortexCloud_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VortexCloud_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VortexCloud_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024859 RID: 149593 RVA: 0x0099FF50 File Offset: 0x0099E150
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_VortexCloud_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_VortexCloud_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VortexCloud_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VortexCloud_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VortexCloud_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602485A RID: 149594 RVA: 0x0099FF98 File Offset: 0x0099E198
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_VortexCloud_C.__EditorTick_FunctionParams* ptr = stackalloc BP_VortexCloud_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VortexCloud_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VortexCloud_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VortexCloud_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602485B RID: 149595 RVA: 0x0099FFE0 File Offset: 0x0099E1E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_VortexCloud_C.__EditorTick_FunctionParams* ptr = stackalloc BP_VortexCloud_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VortexCloud_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VortexCloud_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VortexCloud_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602485C RID: 149596 RVA: 0x009A0028 File Offset: 0x0099E228
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_VortexCloud(int EntryPoint)
		{
			BP_VortexCloud_C.__ExecuteUbergraph_BP_VortexCloud_FunctionParams* ptr = stackalloc BP_VortexCloud_C.__ExecuteUbergraph_BP_VortexCloud_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_VortexCloud_C.__ExecuteUbergraph_BP_VortexCloud_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VortexCloud_C.__ExecuteUbergraph_BP_VortexCloud_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VortexCloud_C.__ExecuteUbergraph_BP_VortexCloud_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602485D RID: 149597 RVA: 0x009A006F File Offset: 0x0099E26F
		protected BP_VortexCloud_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012B47 RID: 76615
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/VortexCloud/BP_VortexCloud.BP_VortexCloud_C";

		// Token: 0x04012B48 RID: 76616
		private static IntPtr _ClassPtr;

		// Token: 0x04012B49 RID: 76617
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012B4A RID: 76618
		internal static int __PropertyOffset_0;

		// Token: 0x04012B4B RID: 76619
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012B4C RID: 76620
		internal static int __PropertyOffset_1;

		// Token: 0x04012B4D RID: 76621
		internal static int __PropertyOffset_2;

		// Token: 0x04012B4E RID: 76622
		internal static int __PropertyOffset_3;

		// Token: 0x04012B4F RID: 76623
		internal static int __PropertyOffset_4;

		// Token: 0x04012B50 RID: 76624
		internal static int __PropertyOffset_5;

		// Token: 0x04012B51 RID: 76625
		internal static int __PropertyOffset_6;

		// Token: 0x04012B52 RID: 76626
		internal static int __PropertyOffset_7;

		// Token: 0x04012B53 RID: 76627
		internal static int __PropertyOffset_8;

		// Token: 0x04012B54 RID: 76628
		internal static int __PropertyOffset_9;

		// Token: 0x04012B55 RID: 76629
		internal static int __PropertyOffset_10;

		// Token: 0x04012B56 RID: 76630
		internal static int __PropertyOffset_11;

		// Token: 0x04012B57 RID: 76631
		internal static int __PropertyOffset_12;

		// Token: 0x04012B58 RID: 76632
		internal static int __PropertyOffset_13;

		// Token: 0x04012B59 RID: 76633
		internal static int __PropertyOffset_14;

		// Token: 0x04012B5A RID: 76634
		internal static int __PropertyOffset_15;

		// Token: 0x04012B5B RID: 76635
		internal static int __PropertyOffset_16;

		// Token: 0x04012B5C RID: 76636
		private static IntPtr __Is_PC_Or_Android_NativeFunctionPtr;

		// Token: 0x04012B5D RID: 76637
		private static IntPtr __Set_VortexParameters_NativeFunctionPtr;

		// Token: 0x04012B5E RID: 76638
		private static IntPtr __Set_Current_Post_Process_Weight_NativeFunctionPtr;

		// Token: 0x04012B5F RID: 76639
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04012B60 RID: 76640
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012B61 RID: 76641
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012B62 RID: 76642
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04012B63 RID: 76643
		private static IntPtr __ExecuteUbergraph_BP_VortexCloud_NativeFunctionPtr;

		// Token: 0x02009E02 RID: 40450
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032848 RID: 206920
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009E03 RID: 40451
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032849 RID: 206921
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009E04 RID: 40452
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_VortexCloud_FunctionParams
		{
			// Token: 0x0403284A RID: 206922
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
