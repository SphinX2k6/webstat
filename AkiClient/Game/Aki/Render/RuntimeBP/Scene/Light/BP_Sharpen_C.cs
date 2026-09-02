using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A9A RID: 15002
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_Sharpen.BP_Sharpen_C")]
	[UnrealStructLayout(1616, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1613)]
	public class BP_Sharpen_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601FA8E RID: 129678 RVA: 0x009175A4 File Offset: 0x009157A4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Sharpen_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_Sharpen.BP_Sharpen_C");
			}
			return BP_Sharpen_C._ClassPtr;
		}

		// Token: 0x0601FA8F RID: 129679 RVA: 0x009175C8 File Offset: 0x009157C8
		public BP_Sharpen_C() : this(BuiltinUtils.AllocNativeUObject(BP_Sharpen_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601FA90 RID: 129680 RVA: 0x009175F0 File Offset: 0x009157F0
		[NullableContext(1)]
		public BP_Sharpen_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Sharpen_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003137 RID: 12599
		// (get) Token: 0x0601FA91 RID: 129681 RVA: 0x00917624 File Offset: 0x00915824
		// (set) Token: 0x0601FA92 RID: 129682 RVA: 0x0091765D File Offset: 0x0091585D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Sharpen_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Sharpen_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003138 RID: 12600
		// (get) Token: 0x0601FA93 RID: 129683 RVA: 0x0091767E File Offset: 0x0091587E
		// (set) Token: 0x0601FA94 RID: 129684 RVA: 0x00917692 File Offset: 0x00915892
		public unsafe UKuroGameBudgetComponent KuroGameBudget
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroGameBudgetComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Sharpen_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Sharpen_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003139 RID: 12601
		// (get) Token: 0x0601FA95 RID: 129685 RVA: 0x009176A7 File Offset: 0x009158A7
		// (set) Token: 0x0601FA96 RID: 129686 RVA: 0x009176BB File Offset: 0x009158BB
		public unsafe UKuroPostProcessComponent KuroPostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Sharpen_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Sharpen_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700313A RID: 12602
		// (get) Token: 0x0601FA97 RID: 129687 RVA: 0x009176D0 File Offset: 0x009158D0
		// (set) Token: 0x0601FA98 RID: 129688 RVA: 0x009176E4 File Offset: 0x009158E4
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Sharpen_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Sharpen_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700313B RID: 12603
		// (get) Token: 0x0601FA99 RID: 129689 RVA: 0x009176F9 File Offset: 0x009158F9
		// (set) Token: 0x0601FA9A RID: 129690 RVA: 0x0091770D File Offset: 0x0091590D
		public unsafe UMaterialInstanceDynamic DynamicMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Sharpen_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Sharpen_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700313C RID: 12604
		// (get) Token: 0x0601FA9B RID: 129691 RVA: 0x00917724 File Offset: 0x00915924
		// (set) Token: 0x0601FA9C RID: 129692 RVA: 0x0091775D File Offset: 0x0091595D
		[Nullable(1)]
		public TMap<FName, float> Scalar_Parameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, float> result;
				if ((result = this._Scalar_Parameters) == null)
				{
					result = (this._Scalar_Parameters = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_Sharpen_C.__PropertyOffset_5, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Scalar_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x1700313D RID: 12605
		// (get) Token: 0x0601FA9D RID: 129693 RVA: 0x0091776C File Offset: 0x0091596C
		// (set) Token: 0x0601FA9E RID: 129694 RVA: 0x009177A5 File Offset: 0x009159A5
		[Nullable(1)]
		public TMap<FName, FLinearColor> Vector_Parameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FLinearColor> result;
				if ((result = this._Vector_Parameters) == null)
				{
					result = (this._Vector_Parameters = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_Sharpen_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Vector_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x1700313E RID: 12606
		// (get) Token: 0x0601FA9F RID: 129695 RVA: 0x009177B4 File Offset: 0x009159B4
		// (set) Token: 0x0601FAA0 RID: 129696 RVA: 0x009177ED File Offset: 0x009159ED
		[Nullable(1)]
		public TMap<FName, UTexture> Texture_Parameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, UTexture> result;
				if ((result = this._Texture_Parameters) == null)
				{
					result = (this._Texture_Parameters = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_Sharpen_C.__PropertyOffset_7, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Texture_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x1700313F RID: 12607
		// (get) Token: 0x0601FAA1 RID: 129697 RVA: 0x009177FB File Offset: 0x009159FB
		// (set) Token: 0x0601FAA2 RID: 129698 RVA: 0x0091780F File Offset: 0x00915A0F
		public unsafe UMaterialInstance Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Sharpen_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Sharpen_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17003140 RID: 12608
		// (get) Token: 0x0601FAA3 RID: 129699 RVA: 0x00917824 File Offset: 0x00915A24
		// (set) Token: 0x0601FAA4 RID: 129700 RVA: 0x00917834 File Offset: 0x00915A34
		public unsafe float Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Sharpen_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Sharpen_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003141 RID: 12609
		// (get) Token: 0x0601FAA5 RID: 129701 RVA: 0x00917845 File Offset: 0x00915A45
		// (set) Token: 0x0601FAA6 RID: 129702 RVA: 0x00917855 File Offset: 0x00915A55
		public unsafe float Radius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Sharpen_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Sharpen_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17003142 RID: 12610
		// (get) Token: 0x0601FAA7 RID: 129703 RVA: 0x00917866 File Offset: 0x00915A66
		// (set) Token: 0x0601FAA8 RID: 129704 RVA: 0x00917876 File Offset: 0x00915A76
		public unsafe float Density
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Sharpen_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Sharpen_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17003143 RID: 12611
		// (get) Token: 0x0601FAA9 RID: 129705 RVA: 0x00917887 File Offset: 0x00915A87
		// (set) Token: 0x0601FAAA RID: 129706 RVA: 0x00917897 File Offset: 0x00915A97
		public unsafe bool Debug
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Sharpen_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Sharpen_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601FAAB RID: 129707 RVA: 0x009178A8 File Offset: 0x00915AA8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetParameter()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Sharpen_C.__SetParameter_NativeFunctionPtr, null);
		}

		// Token: 0x0601FAAC RID: 129708 RVA: 0x009178BC File Offset: 0x00915ABC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Sharpen_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601FAAD RID: 129709 RVA: 0x009178D0 File Offset: 0x00915AD0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Sharpen_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FAAE RID: 129710 RVA: 0x009178E5 File Offset: 0x00915AE5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Sharpen_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601FAAF RID: 129711 RVA: 0x009178F9 File Offset: 0x00915AF9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Sharpen_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FAB0 RID: 129712 RVA: 0x00917910 File Offset: 0x00915B10
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Sharpen_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Sharpen_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Sharpen_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Sharpen_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Sharpen_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601FAB1 RID: 129713 RVA: 0x00917958 File Offset: 0x00915B58
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Sharpen_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Sharpen_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Sharpen_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Sharpen_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Sharpen_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FAB2 RID: 129714 RVA: 0x0091799F File Offset: 0x00915B9F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Sharpen_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x0601FAB3 RID: 129715 RVA: 0x009179B3 File Offset: 0x00915BB3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Sharpen_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FAB4 RID: 129716 RVA: 0x009179C8 File Offset: 0x00915BC8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_Sharpen_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Sharpen_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Sharpen_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Sharpen_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Sharpen_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601FAB5 RID: 129717 RVA: 0x00917A10 File Offset: 0x00915C10
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_Sharpen_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Sharpen_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Sharpen_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Sharpen_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Sharpen_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FAB6 RID: 129718 RVA: 0x00917A58 File Offset: 0x00915C58
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Sharpen(int EntryPoint)
		{
			BP_Sharpen_C.__ExecuteUbergraph_BP_Sharpen_FunctionParams* ptr = stackalloc BP_Sharpen_C.__ExecuteUbergraph_BP_Sharpen_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(BP_Sharpen_C.__ExecuteUbergraph_BP_Sharpen_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Sharpen_C.__ExecuteUbergraph_BP_Sharpen_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Sharpen_C.__ExecuteUbergraph_BP_Sharpen_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FAB7 RID: 129719 RVA: 0x00917A9F File Offset: 0x00915C9F
		protected BP_Sharpen_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FBE6 RID: 64486
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_Sharpen.BP_Sharpen_C";

		// Token: 0x0400FBE7 RID: 64487
		private static IntPtr _ClassPtr;

		// Token: 0x0400FBE8 RID: 64488
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FBE9 RID: 64489
		internal static int __PropertyOffset_0;

		// Token: 0x0400FBEA RID: 64490
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FBEB RID: 64491
		internal static int __PropertyOffset_1;

		// Token: 0x0400FBEC RID: 64492
		internal static int __PropertyOffset_2;

		// Token: 0x0400FBED RID: 64493
		internal static int __PropertyOffset_3;

		// Token: 0x0400FBEE RID: 64494
		internal static int __PropertyOffset_4;

		// Token: 0x0400FBEF RID: 64495
		internal static int __PropertyOffset_5;

		// Token: 0x0400FBF0 RID: 64496
		private TMap<FName, float> _Scalar_Parameters;

		// Token: 0x0400FBF1 RID: 64497
		internal static int __PropertyOffset_6;

		// Token: 0x0400FBF2 RID: 64498
		private TMap<FName, FLinearColor> _Vector_Parameters;

		// Token: 0x0400FBF3 RID: 64499
		internal static int __PropertyOffset_7;

		// Token: 0x0400FBF4 RID: 64500
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _Texture_Parameters;

		// Token: 0x0400FBF5 RID: 64501
		internal static int __PropertyOffset_8;

		// Token: 0x0400FBF6 RID: 64502
		internal static int __PropertyOffset_9;

		// Token: 0x0400FBF7 RID: 64503
		internal static int __PropertyOffset_10;

		// Token: 0x0400FBF8 RID: 64504
		internal static int __PropertyOffset_11;

		// Token: 0x0400FBF9 RID: 64505
		internal static int __PropertyOffset_12;

		// Token: 0x0400FBFA RID: 64506
		private static IntPtr __SetParameter_NativeFunctionPtr;

		// Token: 0x0400FBFB RID: 64507
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400FBFC RID: 64508
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400FBFD RID: 64509
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400FBFE RID: 64510
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x0400FBFF RID: 64511
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400FC00 RID: 64512
		private static IntPtr __ExecuteUbergraph_BP_Sharpen_NativeFunctionPtr;

		// Token: 0x02009910 RID: 39184
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031F6F RID: 204655
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009911 RID: 39185
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031F70 RID: 204656
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009912 RID: 39186
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __ExecuteUbergraph_BP_Sharpen_FunctionParams
		{
			// Token: 0x04031F71 RID: 204657
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
