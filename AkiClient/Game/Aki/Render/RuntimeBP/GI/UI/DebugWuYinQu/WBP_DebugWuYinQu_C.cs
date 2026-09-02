using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.UI.Module.Common.View.Widget;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.UI.DebugWuYinQu
{
	// Token: 0x02003CA1 RID: 15521
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/UI/DebugWuYinQu/WBP_DebugWuYinQu.WBP_DebugWuYinQu_C")]
	[UnrealStructLayout(1208, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1208)]
	public class WBP_DebugWuYinQu_C : UUserWidget, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602492F RID: 149807 RVA: 0x009A1640 File Offset: 0x0099F840
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (WBP_DebugWuYinQu_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/UI/DebugWuYinQu/WBP_DebugWuYinQu.WBP_DebugWuYinQu_C");
			}
			return WBP_DebugWuYinQu_C._ClassPtr;
		}

		// Token: 0x06024930 RID: 149808 RVA: 0x009A1664 File Offset: 0x0099F864
		public WBP_DebugWuYinQu_C() : this(BuiltinUtils.AllocNativeUObject(WBP_DebugWuYinQu_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024931 RID: 149809 RVA: 0x009A168C File Offset: 0x0099F88C
		[NullableContext(1)]
		public WBP_DebugWuYinQu_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(WBP_DebugWuYinQu_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004CC9 RID: 19657
		// (get) Token: 0x06024932 RID: 149810 RVA: 0x009A16C0 File Offset: 0x0099F8C0
		// (set) Token: 0x06024933 RID: 149811 RVA: 0x009A16F9 File Offset: 0x0099F8F9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)WBP_DebugWuYinQu_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)WBP_DebugWuYinQu_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004CCA RID: 19658
		// (get) Token: 0x06024934 RID: 149812 RVA: 0x009A171A File Offset: 0x0099F91A
		// (set) Token: 0x06024935 RID: 149813 RVA: 0x009A172E File Offset: 0x0099F92E
		public unsafe UButton BtnClose
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugWuYinQu_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugWuYinQu_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004CCB RID: 19659
		// (get) Token: 0x06024936 RID: 149814 RVA: 0x009A1743 File Offset: 0x0099F943
		// (set) Token: 0x06024937 RID: 149815 RVA: 0x009A1757 File Offset: 0x0099F957
		public unsafe KuroImage_C KuroImage_C_76
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<KuroImage_C>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugWuYinQu_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugWuYinQu_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004CCC RID: 19660
		// (get) Token: 0x06024938 RID: 149816 RVA: 0x009A176C File Offset: 0x0099F96C
		// (set) Token: 0x06024939 RID: 149817 RVA: 0x009A1780 File Offset: 0x0099F980
		public unsafe UTextBlock TxtCurActiveActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugWuYinQu_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugWuYinQu_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004CCD RID: 19661
		// (get) Token: 0x0602493A RID: 149818 RVA: 0x009A1795 File Offset: 0x0099F995
		// (set) Token: 0x0602493B RID: 149819 RVA: 0x009A17A9 File Offset: 0x0099F9A9
		public unsafe UTextBlock TxtCurActiveState_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugWuYinQu_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_DebugWuYinQu_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x0602493C RID: 149820 RVA: 0x009A17BE File Offset: 0x0099F9BE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_DebugWuYinQu_C.__Update_NativeFunctionPtr, null);
		}

		// Token: 0x0602493D RID: 149821 RVA: 0x009A17D2 File Offset: 0x0099F9D2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Init()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_DebugWuYinQu_C.__Init_NativeFunctionPtr, null);
		}

		// Token: 0x0602493E RID: 149822 RVA: 0x009A17E8 File Offset: 0x0099F9E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void Tick(FGeometry MyGeometry, float InDeltaTime)
		{
			WBP_DebugWuYinQu_C.__Tick_FunctionParams* ptr = stackalloc WBP_DebugWuYinQu_C.__Tick_FunctionParams[(UIntPtr)75] + 15L / (long)sizeof(WBP_DebugWuYinQu_C.__Tick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_DebugWuYinQu_C.__Tick_NativeFunctionPtr, (void*)ptr, 1);
			if (MyGeometry != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGeometry.StaticStruct(), &ptr->MyGeometry, MyGeometry.NativePtr, 1, false);
			}
			ptr->InDeltaTime = InDeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_DebugWuYinQu_C.__Tick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602493F RID: 149823 RVA: 0x009A1850 File Offset: 0x0099FA50
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void Tick_Implementation(FGeometry MyGeometry, float InDeltaTime)
		{
			WBP_DebugWuYinQu_C.__Tick_FunctionParams* ptr = stackalloc WBP_DebugWuYinQu_C.__Tick_FunctionParams[(UIntPtr)75] + 15L / (long)sizeof(WBP_DebugWuYinQu_C.__Tick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_DebugWuYinQu_C.__Tick_NativeFunctionPtr, (void*)ptr, 1);
			if (MyGeometry != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGeometry.StaticStruct(), &ptr->MyGeometry, MyGeometry.NativePtr, 1, false);
			}
			ptr->InDeltaTime = InDeltaTime;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, WBP_DebugWuYinQu_C.__Tick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024940 RID: 149824 RVA: 0x009A18B9 File Offset: 0x0099FAB9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugWuYinQu_BtnClose_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_DebugWuYinQu_C.__BndEvt__BP_DebugWuYinQu_BtnClose_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x06024941 RID: 149825 RVA: 0x009A18D0 File Offset: 0x0099FAD0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_WBP_DebugWuYinQu(int EntryPoint)
		{
			WBP_DebugWuYinQu_C.__ExecuteUbergraph_WBP_DebugWuYinQu_FunctionParams* ptr = stackalloc WBP_DebugWuYinQu_C.__ExecuteUbergraph_WBP_DebugWuYinQu_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(WBP_DebugWuYinQu_C.__ExecuteUbergraph_WBP_DebugWuYinQu_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_DebugWuYinQu_C.__ExecuteUbergraph_WBP_DebugWuYinQu_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, WBP_DebugWuYinQu_C.__ExecuteUbergraph_WBP_DebugWuYinQu_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024942 RID: 149826 RVA: 0x009A191A File Offset: 0x0099FB1A
		protected WBP_DebugWuYinQu_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012BF0 RID: 76784
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/UI/DebugWuYinQu/WBP_DebugWuYinQu.WBP_DebugWuYinQu_C";

		// Token: 0x04012BF1 RID: 76785
		private static IntPtr _ClassPtr;

		// Token: 0x04012BF2 RID: 76786
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012BF3 RID: 76787
		internal static int __PropertyOffset_0;

		// Token: 0x04012BF4 RID: 76788
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012BF5 RID: 76789
		internal static int __PropertyOffset_1;

		// Token: 0x04012BF6 RID: 76790
		internal static int __PropertyOffset_2;

		// Token: 0x04012BF7 RID: 76791
		internal static int __PropertyOffset_3;

		// Token: 0x04012BF8 RID: 76792
		internal static int __PropertyOffset_4;

		// Token: 0x04012BF9 RID: 76793
		private static IntPtr __Update_NativeFunctionPtr;

		// Token: 0x04012BFA RID: 76794
		private static IntPtr __Init_NativeFunctionPtr;

		// Token: 0x04012BFB RID: 76795
		private static IntPtr __Tick_NativeFunctionPtr;

		// Token: 0x04012BFC RID: 76796
		private static IntPtr __BndEvt__BP_DebugWuYinQu_BtnClose_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BFD RID: 76797
		private static IntPtr __ExecuteUbergraph_WBP_DebugWuYinQu_NativeFunctionPtr;

		// Token: 0x02009E11 RID: 40465
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 60)]
		protected new ref struct __Tick_FunctionParams
		{
			// Token: 0x04032858 RID: 206936
			[FieldOffset(0)]
			public byte MyGeometry;

			// Token: 0x04032859 RID: 206937
			[FieldOffset(56)]
			public float InDeltaTime;
		}

		// Token: 0x02009E12 RID: 40466
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __ExecuteUbergraph_WBP_DebugWuYinQu_FunctionParams
		{
			// Token: 0x0403285A RID: 206938
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
