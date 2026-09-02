using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A8F RID: 14991
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_LightsGroup.BP_LightsGroup_C")]
	[UnrealStructLayout(1136, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1129)]
	public class BP_LightsGroup_C : AActor, IUnrealUObject, IUnrealObject, IInterface_KuroLightBP, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x0601F846 RID: 129094 RVA: 0x0091387E File Offset: 0x00911A7E
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_LightsGroup_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_LightsGroup.BP_LightsGroup_C");
			}
			return BP_LightsGroup_C._ClassPtr;
		}

		// Token: 0x0601F847 RID: 129095 RVA: 0x009138A2 File Offset: 0x00911AA2
		int IInterface_KuroLightBP.InterfaceOffset()
		{
			return BP_LightsGroup_C.__InterfaceOffset_IInterface_KuroLightBP;
		}

		// Token: 0x0601F848 RID: 129096 RVA: 0x009138AC File Offset: 0x00911AAC
		public BP_LightsGroup_C() : this(BuiltinUtils.AllocNativeUObject(BP_LightsGroup_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F849 RID: 129097 RVA: 0x009138D4 File Offset: 0x00911AD4
		[NullableContext(1)]
		public BP_LightsGroup_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_LightsGroup_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700306A RID: 12394
		// (get) Token: 0x0601F84A RID: 129098 RVA: 0x00913908 File Offset: 0x00911B08
		// (set) Token: 0x0601F84B RID: 129099 RVA: 0x00913941 File Offset: 0x00911B41
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_LightsGroup_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_LightsGroup_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700306B RID: 12395
		// (get) Token: 0x0601F84C RID: 129100 RVA: 0x00913962 File Offset: 0x00911B62
		// (set) Token: 0x0601F84D RID: 129101 RVA: 0x00913976 File Offset: 0x00911B76
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightsGroup_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightsGroup_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700306C RID: 12396
		// (get) Token: 0x0601F84E RID: 129102 RVA: 0x0091398B File Offset: 0x00911B8B
		// (set) Token: 0x0601F84F RID: 129103 RVA: 0x0091399B File Offset: 0x00911B9B
		public unsafe bool IsTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightsGroup_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightsGroup_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700306D RID: 12397
		// (get) Token: 0x0601F850 RID: 129104 RVA: 0x009139AC File Offset: 0x00911BAC
		// (set) Token: 0x0601F851 RID: 129105 RVA: 0x009139BC File Offset: 0x00911BBC
		public unsafe bool TurnOffOrOn
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightsGroup_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightsGroup_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700306E RID: 12398
		// (get) Token: 0x0601F852 RID: 129106 RVA: 0x009139CD File Offset: 0x00911BCD
		// (set) Token: 0x0601F853 RID: 129107 RVA: 0x009139DD File Offset: 0x00911BDD
		public unsafe bool UseSimpleToggle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightsGroup_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightsGroup_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700306F RID: 12399
		// (get) Token: 0x0601F854 RID: 129108 RVA: 0x009139EE File Offset: 0x00911BEE
		// (set) Token: 0x0601F855 RID: 129109 RVA: 0x009139FE File Offset: 0x00911BFE
		public unsafe bool UseColorChange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightsGroup_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightsGroup_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003070 RID: 12400
		// (get) Token: 0x0601F856 RID: 129110 RVA: 0x00913A0F File Offset: 0x00911C0F
		// (set) Token: 0x0601F857 RID: 129111 RVA: 0x00913A1F File Offset: 0x00911C1F
		public unsafe float Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightsGroup_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightsGroup_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003071 RID: 12401
		// (get) Token: 0x0601F858 RID: 129112 RVA: 0x00913A30 File Offset: 0x00911C30
		// (set) Token: 0x0601F859 RID: 129113 RVA: 0x00913A40 File Offset: 0x00911C40
		public unsafe float Duration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightsGroup_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightsGroup_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003072 RID: 12402
		// (get) Token: 0x0601F85A RID: 129114 RVA: 0x00913A51 File Offset: 0x00911C51
		// (set) Token: 0x0601F85B RID: 129115 RVA: 0x00913A61 File Offset: 0x00911C61
		public unsafe float DeltaSeconds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightsGroup_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightsGroup_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003073 RID: 12403
		// (get) Token: 0x0601F85C RID: 129116 RVA: 0x00913A74 File Offset: 0x00911C74
		// (set) Token: 0x0601F85D RID: 129117 RVA: 0x00913AAD File Offset: 0x00911CAD
		[Nullable(1)]
		public TArray<float> LightsIntensity
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._LightsIntensity) == null)
				{
					result = (this._LightsIntensity = new TArray<float>(base.NativePtr + (IntPtr)BP_LightsGroup_C.__PropertyOffset_9, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.LightsIntensity.CopyAssign(value);
			}
		}

		// Token: 0x17003074 RID: 12404
		// (get) Token: 0x0601F85E RID: 129118 RVA: 0x00913ABB File Offset: 0x00911CBB
		// (set) Token: 0x0601F85F RID: 129119 RVA: 0x00913ACF File Offset: 0x00911CCF
		public unsafe FLinearColor ColorOriginal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightsGroup_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightsGroup_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17003075 RID: 12405
		// (get) Token: 0x0601F860 RID: 129120 RVA: 0x00913AE4 File Offset: 0x00911CE4
		// (set) Token: 0x0601F861 RID: 129121 RVA: 0x00913AF8 File Offset: 0x00911CF8
		public unsafe FLinearColor ColorTarget
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightsGroup_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightsGroup_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17003076 RID: 12406
		// (get) Token: 0x0601F862 RID: 129122 RVA: 0x00913B0D File Offset: 0x00911D0D
		// (set) Token: 0x0601F863 RID: 129123 RVA: 0x00913B21 File Offset: 0x00911D21
		[Nullable(1)]
		public unsafe string Test
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_LightsGroup_C.__PropertyOffset_12)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_LightsGroup_C.__PropertyOffset_12)), value);
			}
		}

		// Token: 0x17003077 RID: 12407
		// (get) Token: 0x0601F864 RID: 129124 RVA: 0x00913B36 File Offset: 0x00911D36
		// (set) Token: 0x0601F865 RID: 129125 RVA: 0x00913B46 File Offset: 0x00911D46
		public unsafe bool EnableLightsOnBeginPlay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightsGroup_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightsGroup_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601F866 RID: 129126 RVA: 0x00913B58 File Offset: 0x00911D58
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual int GetPlacementSortOrder()
		{
			BP_LightsGroup_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_LightsGroup_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LightsGroup_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightsGroup_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightsGroup_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0601F867 RID: 129127 RVA: 0x00913BA0 File Offset: 0x00911DA0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual int GetPlacementSortOrder_Implementation()
		{
			BP_LightsGroup_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_LightsGroup_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LightsGroup_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightsGroup_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LightsGroup_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0601F868 RID: 129128 RVA: 0x00913BE8 File Offset: 0x00911DE8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void LightsColorChange(float ElapsedTime, FLinearColor ColorOriginal, FLinearColor ColorTarget)
		{
			BP_LightsGroup_C.__LightsColorChange_FunctionParams* ptr = stackalloc BP_LightsGroup_C.__LightsColorChange_FunctionParams[(UIntPtr)143] + 15L / (long)sizeof(BP_LightsGroup_C.__LightsColorChange_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightsGroup_C.__LightsColorChange_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ElapsedTime = ElapsedTime;
			ptr->ColorOriginal = ColorOriginal;
			ptr->ColorTarget = ColorTarget;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightsGroup_C.__LightsColorChange_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F869 RID: 129129 RVA: 0x00913C3F File Offset: 0x00911E3F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ToggleLightsColorChange()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightsGroup_C.__ToggleLightsColorChange_NativeFunctionPtr, null);
		}

		// Token: 0x0601F86A RID: 129130 RVA: 0x00913C53 File Offset: 0x00911E53
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void GetLightsIntensity()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightsGroup_C.__GetLightsIntensity_NativeFunctionPtr, null);
		}

		// Token: 0x0601F86B RID: 129131 RVA: 0x00913C68 File Offset: 0x00911E68
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Timer(ref float ElapsedTime)
		{
			BP_LightsGroup_C.__Timer_FunctionParams* ptr = stackalloc BP_LightsGroup_C.__Timer_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_LightsGroup_C.__Timer_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightsGroup_C.__Timer_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ElapsedTime = ElapsedTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightsGroup_C.__Timer_NativeFunctionPtr, (void*)ptr);
			ElapsedTime = ptr->ElapsedTime;
		}

		// Token: 0x0601F86C RID: 129132 RVA: 0x00913CB8 File Offset: 0x00911EB8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void TurnOnLights(float ElapsedTime)
		{
			BP_LightsGroup_C.__TurnOnLights_FunctionParams* ptr = stackalloc BP_LightsGroup_C.__TurnOnLights_FunctionParams[(UIntPtr)119] + 15L / (long)sizeof(BP_LightsGroup_C.__TurnOnLights_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightsGroup_C.__TurnOnLights_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ElapsedTime = ElapsedTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightsGroup_C.__TurnOnLights_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F86D RID: 129133 RVA: 0x00913D00 File Offset: 0x00911F00
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void TurnOffLights(float ElapsedTime)
		{
			BP_LightsGroup_C.__TurnOffLights_FunctionParams* ptr = stackalloc BP_LightsGroup_C.__TurnOffLights_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(BP_LightsGroup_C.__TurnOffLights_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightsGroup_C.__TurnOffLights_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ElapsedTime = ElapsedTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightsGroup_C.__TurnOffLights_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F86E RID: 129134 RVA: 0x00913D46 File Offset: 0x00911F46
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ToggleLightsIntensity()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightsGroup_C.__ToggleLightsIntensity_NativeFunctionPtr, null);
		}

		// Token: 0x0601F86F RID: 129135 RVA: 0x00913D5C File Offset: 0x00911F5C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ToggleLights(bool inEnable)
		{
			BP_LightsGroup_C.__ToggleLights_FunctionParams* ptr = stackalloc BP_LightsGroup_C.__ToggleLights_FunctionParams[(UIntPtr)175] + 15L / (long)sizeof(BP_LightsGroup_C.__ToggleLights_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightsGroup_C.__ToggleLights_NativeFunctionPtr, (void*)ptr, 1);
			ptr->inEnable = inEnable;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightsGroup_C.__ToggleLights_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F870 RID: 129136 RVA: 0x00913DA5 File Offset: 0x00911FA5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightsGroup_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601F871 RID: 129137 RVA: 0x00913DB9 File Offset: 0x00911FB9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LightsGroup_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F872 RID: 129138 RVA: 0x00913DD0 File Offset: 0x00911FD0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_LightsGroup_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LightsGroup_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LightsGroup_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightsGroup_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightsGroup_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F873 RID: 129139 RVA: 0x00913E18 File Offset: 0x00912018
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_LightsGroup_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LightsGroup_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LightsGroup_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightsGroup_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LightsGroup_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F874 RID: 129140 RVA: 0x00913E60 File Offset: 0x00912060
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_LightsGroup(int EntryPoint)
		{
			BP_LightsGroup_C.__ExecuteUbergraph_BP_LightsGroup_FunctionParams* ptr = stackalloc BP_LightsGroup_C.__ExecuteUbergraph_BP_LightsGroup_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_LightsGroup_C.__ExecuteUbergraph_BP_LightsGroup_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightsGroup_C.__ExecuteUbergraph_BP_LightsGroup_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LightsGroup_C.__ExecuteUbergraph_BP_LightsGroup_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F875 RID: 129141 RVA: 0x00913EA7 File Offset: 0x009120A7
		protected BP_LightsGroup_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FA8B RID: 64139
		internal static int __InterfaceOffset_IInterface_KuroLightBP;

		// Token: 0x0400FA8C RID: 64140
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_LightsGroup.BP_LightsGroup_C";

		// Token: 0x0400FA8D RID: 64141
		private static IntPtr _ClassPtr;

		// Token: 0x0400FA8E RID: 64142
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FA8F RID: 64143
		internal static int __PropertyOffset_0;

		// Token: 0x0400FA90 RID: 64144
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FA91 RID: 64145
		internal static int __PropertyOffset_1;

		// Token: 0x0400FA92 RID: 64146
		internal static int __PropertyOffset_2;

		// Token: 0x0400FA93 RID: 64147
		internal static int __PropertyOffset_3;

		// Token: 0x0400FA94 RID: 64148
		internal static int __PropertyOffset_4;

		// Token: 0x0400FA95 RID: 64149
		internal static int __PropertyOffset_5;

		// Token: 0x0400FA96 RID: 64150
		internal static int __PropertyOffset_6;

		// Token: 0x0400FA97 RID: 64151
		internal static int __PropertyOffset_7;

		// Token: 0x0400FA98 RID: 64152
		internal static int __PropertyOffset_8;

		// Token: 0x0400FA99 RID: 64153
		internal static int __PropertyOffset_9;

		// Token: 0x0400FA9A RID: 64154
		[Nullable(2)]
		private TArray<float> _LightsIntensity;

		// Token: 0x0400FA9B RID: 64155
		internal static int __PropertyOffset_10;

		// Token: 0x0400FA9C RID: 64156
		internal static int __PropertyOffset_11;

		// Token: 0x0400FA9D RID: 64157
		internal static int __PropertyOffset_12;

		// Token: 0x0400FA9E RID: 64158
		internal static int __PropertyOffset_13;

		// Token: 0x0400FA9F RID: 64159
		private static IntPtr __GetPlacementSortOrder_NativeFunctionPtr;

		// Token: 0x0400FAA0 RID: 64160
		private static IntPtr __LightsColorChange_NativeFunctionPtr;

		// Token: 0x0400FAA1 RID: 64161
		private static IntPtr __ToggleLightsColorChange_NativeFunctionPtr;

		// Token: 0x0400FAA2 RID: 64162
		private static IntPtr __GetLightsIntensity_NativeFunctionPtr;

		// Token: 0x0400FAA3 RID: 64163
		private static IntPtr __Timer_NativeFunctionPtr;

		// Token: 0x0400FAA4 RID: 64164
		private static IntPtr __TurnOnLights_NativeFunctionPtr;

		// Token: 0x0400FAA5 RID: 64165
		private static IntPtr __TurnOffLights_NativeFunctionPtr;

		// Token: 0x0400FAA6 RID: 64166
		private static IntPtr __ToggleLightsIntensity_NativeFunctionPtr;

		// Token: 0x0400FAA7 RID: 64167
		private static IntPtr __ToggleLights_NativeFunctionPtr;

		// Token: 0x0400FAA8 RID: 64168
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400FAA9 RID: 64169
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400FAAA RID: 64170
		private static IntPtr __ExecuteUbergraph_BP_LightsGroup_NativeFunctionPtr;

		// Token: 0x020098EB RID: 39147
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetPlacementSortOrder_FunctionParams
		{
			// Token: 0x04031F48 RID: 204616
			[FieldOffset(0)]
			public int __Result;
		}

		// Token: 0x020098EC RID: 39148
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 128)]
		protected ref struct __LightsColorChange_FunctionParams
		{
			// Token: 0x04031F49 RID: 204617
			[FieldOffset(0)]
			public float ElapsedTime;

			// Token: 0x04031F4A RID: 204618
			[FieldOffset(4)]
			public FLinearColor ColorOriginal;

			// Token: 0x04031F4B RID: 204619
			[FieldOffset(20)]
			public FLinearColor ColorTarget;
		}

		// Token: 0x020098ED RID: 39149
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __Timer_FunctionParams
		{
			// Token: 0x04031F4C RID: 204620
			[FieldOffset(0)]
			public float ElapsedTime;
		}

		// Token: 0x020098EE RID: 39150
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 104)]
		protected ref struct __TurnOnLights_FunctionParams
		{
			// Token: 0x04031F4D RID: 204621
			[FieldOffset(0)]
			public float ElapsedTime;
		}

		// Token: 0x020098EF RID: 39151
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected ref struct __TurnOffLights_FunctionParams
		{
			// Token: 0x04031F4E RID: 204622
			[FieldOffset(0)]
			public float ElapsedTime;
		}

		// Token: 0x020098F0 RID: 39152
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 160)]
		protected ref struct __ToggleLights_FunctionParams
		{
			// Token: 0x04031F4F RID: 204623
			[FieldOffset(0)]
			public bool inEnable;
		}

		// Token: 0x020098F1 RID: 39153
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031F50 RID: 204624
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020098F2 RID: 39154
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_LightsGroup_FunctionParams
		{
			// Token: 0x04031F51 RID: 204625
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
