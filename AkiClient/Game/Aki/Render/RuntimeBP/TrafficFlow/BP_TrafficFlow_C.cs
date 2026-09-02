using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.TrafficFlow
{
	// Token: 0x02003A39 RID: 14905
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/TrafficFlow/BP_TrafficFlow.BP_TrafficFlow_C")]
	[UnrealStructLayout(1104, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1104)]
	public class BP_TrafficFlow_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601EBBE RID: 125886 RVA: 0x008FD1DF File Offset: 0x008FB3DF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_TrafficFlow_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/TrafficFlow/BP_TrafficFlow.BP_TrafficFlow_C");
			}
			return BP_TrafficFlow_C._ClassPtr;
		}

		// Token: 0x0601EBBF RID: 125887 RVA: 0x008FD204 File Offset: 0x008FB404
		public BP_TrafficFlow_C() : this(BuiltinUtils.AllocNativeUObject(BP_TrafficFlow_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601EBC0 RID: 125888 RVA: 0x008FD22C File Offset: 0x008FB42C
		[NullableContext(1)]
		public BP_TrafficFlow_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_TrafficFlow_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002C20 RID: 11296
		// (get) Token: 0x0601EBC1 RID: 125889 RVA: 0x008FD260 File Offset: 0x008FB460
		// (set) Token: 0x0601EBC2 RID: 125890 RVA: 0x008FD299 File Offset: 0x008FB499
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_TrafficFlow_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_TrafficFlow_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002C21 RID: 11297
		// (get) Token: 0x0601EBC3 RID: 125891 RVA: 0x008FD2BA File Offset: 0x008FB4BA
		// (set) Token: 0x0601EBC4 RID: 125892 RVA: 0x008FD2CE File Offset: 0x008FB4CE
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrafficFlow_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrafficFlow_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002C22 RID: 11298
		// (get) Token: 0x0601EBC5 RID: 125893 RVA: 0x008FD2E3 File Offset: 0x008FB4E3
		// (set) Token: 0x0601EBC6 RID: 125894 RVA: 0x008FD2F3 File Offset: 0x008FB4F3
		public unsafe float 车流速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrafficFlow_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrafficFlow_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17002C23 RID: 11299
		// (get) Token: 0x0601EBC7 RID: 125895 RVA: 0x008FD304 File Offset: 0x008FB504
		// (set) Token: 0x0601EBC8 RID: 125896 RVA: 0x008FD314 File Offset: 0x008FB514
		public unsafe float 车流密度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrafficFlow_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrafficFlow_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17002C24 RID: 11300
		// (get) Token: 0x0601EBC9 RID: 125897 RVA: 0x008FD325 File Offset: 0x008FB525
		// (set) Token: 0x0601EBCA RID: 125898 RVA: 0x008FD339 File Offset: 0x008FB539
		public unsafe UNiagaraSystem PC端资产
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraSystem>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrafficFlow_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrafficFlow_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17002C25 RID: 11301
		// (get) Token: 0x0601EBCB RID: 125899 RVA: 0x008FD34E File Offset: 0x008FB54E
		// (set) Token: 0x0601EBCC RID: 125900 RVA: 0x008FD35E File Offset: 0x008FB55E
		public unsafe bool 移动端优化
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrafficFlow_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrafficFlow_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002C26 RID: 11302
		// (get) Token: 0x0601EBCD RID: 125901 RVA: 0x008FD36F File Offset: 0x008FB56F
		// (set) Token: 0x0601EBCE RID: 125902 RVA: 0x008FD383 File Offset: 0x008FB583
		public unsafe UNiagaraSystem 移动端资产
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraSystem>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrafficFlow_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrafficFlow_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17002C27 RID: 11303
		// (get) Token: 0x0601EBCF RID: 125903 RVA: 0x008FD398 File Offset: 0x008FB598
		// (set) Token: 0x0601EBD0 RID: 125904 RVA: 0x008FD3D1 File Offset: 0x008FB5D1
		[Nullable(1)]
		public TArray<TSoftObjectPtr<AActor>> 道路样条线
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<TSoftObjectPtr<AActor>> result;
				if ((result = this._道路样条线) == null)
				{
					result = (this._道路样条线 = new TArray<TSoftObjectPtr<AActor>>(base.NativePtr + (IntPtr)BP_TrafficFlow_C.__PropertyOffset_7, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.道路样条线.CopyAssign(value);
			}
		}

		// Token: 0x17002C28 RID: 11304
		// (get) Token: 0x0601EBD1 RID: 125905 RVA: 0x008FD3DF File Offset: 0x008FB5DF
		// (set) Token: 0x0601EBD2 RID: 125906 RVA: 0x008FD3EF File Offset: 0x008FB5EF
		public unsafe int Level
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrafficFlow_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrafficFlow_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17002C29 RID: 11305
		// (get) Token: 0x0601EBD3 RID: 125907 RVA: 0x008FD400 File Offset: 0x008FB600
		// (set) Token: 0x0601EBD4 RID: 125908 RVA: 0x008FD410 File Offset: 0x008FB610
		public unsafe int CurrentLevel
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrafficFlow_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrafficFlow_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x0601EBD5 RID: 125909 RVA: 0x008FD421 File Offset: 0x008FB621
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 生成车流()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrafficFlow_C.__生成车流_NativeFunctionPtr, null);
		}

		// Token: 0x0601EBD6 RID: 125910 RVA: 0x008FD435 File Offset: 0x008FB635
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrafficFlow_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601EBD7 RID: 125911 RVA: 0x008FD449 File Offset: 0x008FB649
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrafficFlow_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EBD8 RID: 125912 RVA: 0x008FD45E File Offset: 0x008FB65E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CustomEvent_Start()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrafficFlow_C.__CustomEvent_Start_NativeFunctionPtr, null);
		}

		// Token: 0x0601EBD9 RID: 125913 RVA: 0x008FD472 File Offset: 0x008FB672
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CustomEvent_Manual()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrafficFlow_C.__CustomEvent_Manual_NativeFunctionPtr, null);
		}

		// Token: 0x0601EBDA RID: 125914 RVA: 0x008FD488 File Offset: 0x008FB688
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_TrafficFlow(int EntryPoint)
		{
			BP_TrafficFlow_C.__ExecuteUbergraph_BP_TrafficFlow_FunctionParams* ptr = stackalloc BP_TrafficFlow_C.__ExecuteUbergraph_BP_TrafficFlow_FunctionParams[(UIntPtr)575] + 15L / (long)sizeof(BP_TrafficFlow_C.__ExecuteUbergraph_BP_TrafficFlow_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrafficFlow_C.__ExecuteUbergraph_BP_TrafficFlow_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrafficFlow_C.__ExecuteUbergraph_BP_TrafficFlow_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EBDB RID: 125915 RVA: 0x008FD4D2 File Offset: 0x008FB6D2
		protected BP_TrafficFlow_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F2B4 RID: 62132
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/TrafficFlow/BP_TrafficFlow.BP_TrafficFlow_C";

		// Token: 0x0400F2B5 RID: 62133
		private static IntPtr _ClassPtr;

		// Token: 0x0400F2B6 RID: 62134
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F2B7 RID: 62135
		internal static int __PropertyOffset_0;

		// Token: 0x0400F2B8 RID: 62136
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F2B9 RID: 62137
		internal static int __PropertyOffset_1;

		// Token: 0x0400F2BA RID: 62138
		internal static int __PropertyOffset_2;

		// Token: 0x0400F2BB RID: 62139
		internal static int __PropertyOffset_3;

		// Token: 0x0400F2BC RID: 62140
		internal static int __PropertyOffset_4;

		// Token: 0x0400F2BD RID: 62141
		internal static int __PropertyOffset_5;

		// Token: 0x0400F2BE RID: 62142
		internal static int __PropertyOffset_6;

		// Token: 0x0400F2BF RID: 62143
		internal static int __PropertyOffset_7;

		// Token: 0x0400F2C0 RID: 62144
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TArray<TSoftObjectPtr<AActor>> _道路样条线;

		// Token: 0x0400F2C1 RID: 62145
		internal static int __PropertyOffset_8;

		// Token: 0x0400F2C2 RID: 62146
		internal static int __PropertyOffset_9;

		// Token: 0x0400F2C3 RID: 62147
		private static IntPtr __生成车流_NativeFunctionPtr;

		// Token: 0x0400F2C4 RID: 62148
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F2C5 RID: 62149
		private static IntPtr __CustomEvent_Start_NativeFunctionPtr;

		// Token: 0x0400F2C6 RID: 62150
		private static IntPtr __CustomEvent_Manual_NativeFunctionPtr;

		// Token: 0x0400F2C7 RID: 62151
		private static IntPtr __ExecuteUbergraph_BP_TrafficFlow_NativeFunctionPtr;

		// Token: 0x020097F9 RID: 38905
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 560)]
		protected ref struct __ExecuteUbergraph_BP_TrafficFlow_FunctionParams
		{
			// Token: 0x04031DEE RID: 204270
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
