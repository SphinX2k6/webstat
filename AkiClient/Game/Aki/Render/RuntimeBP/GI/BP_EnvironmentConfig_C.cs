using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI
{
	// Token: 0x02003C93 RID: 15507
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/BP_EnvironmentConfig.BP_EnvironmentConfig_C")]
	[UnrealStructLayout(1080, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1080)]
	public class BP_EnvironmentConfig_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024352 RID: 148306 RVA: 0x00997984 File Offset: 0x00995B84
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_EnvironmentConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/BP_EnvironmentConfig.BP_EnvironmentConfig_C");
			}
			return BP_EnvironmentConfig_C._ClassPtr;
		}

		// Token: 0x06024353 RID: 148307 RVA: 0x009979A8 File Offset: 0x00995BA8
		public BP_EnvironmentConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_EnvironmentConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024354 RID: 148308 RVA: 0x009979D0 File Offset: 0x00995BD0
		public BP_EnvironmentConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_EnvironmentConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004AA8 RID: 19112
		// (get) Token: 0x06024355 RID: 148309 RVA: 0x00997A04 File Offset: 0x00995C04
		// (set) Token: 0x06024356 RID: 148310 RVA: 0x00997A3D File Offset: 0x00995C3D
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_EnvironmentConfig_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_EnvironmentConfig_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004AA9 RID: 19113
		// (get) Token: 0x06024357 RID: 148311 RVA: 0x00997A5E File Offset: 0x00995C5E
		// (set) Token: 0x06024358 RID: 148312 RVA: 0x00997A72 File Offset: 0x00995C72
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_EnvironmentConfig_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_EnvironmentConfig_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004AAA RID: 19114
		// (get) Token: 0x06024359 RID: 148313 RVA: 0x00997A88 File Offset: 0x00995C88
		// (set) Token: 0x0602435A RID: 148314 RVA: 0x00997AC1 File Offset: 0x00995CC1
		public TArray<string> BeginCommandList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._BeginCommandList) == null)
				{
					result = (this._BeginCommandList = new TArray<string>(base.NativePtr + (IntPtr)BP_EnvironmentConfig_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				this.BeginCommandList.CopyAssign(value);
			}
		}

		// Token: 0x17004AAB RID: 19115
		// (get) Token: 0x0602435B RID: 148315 RVA: 0x00997AD0 File Offset: 0x00995CD0
		// (set) Token: 0x0602435C RID: 148316 RVA: 0x00997B09 File Offset: 0x00995D09
		public TArray<string> EndCommandList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._EndCommandList) == null)
				{
					result = (this._EndCommandList = new TArray<string>(base.NativePtr + (IntPtr)BP_EnvironmentConfig_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				this.EndCommandList.CopyAssign(value);
			}
		}

		// Token: 0x0602435D RID: 148317 RVA: 0x00997B17 File Offset: 0x00995D17
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_EnvironmentConfig_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602435E RID: 148318 RVA: 0x00997B2B File Offset: 0x00995D2B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_EnvironmentConfig_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602435F RID: 148319 RVA: 0x00997B40 File Offset: 0x00995D40
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_EnvironmentConfig_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_EnvironmentConfig_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_EnvironmentConfig_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_EnvironmentConfig_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_EnvironmentConfig_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024360 RID: 148320 RVA: 0x00997B8C File Offset: 0x00995D8C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_EnvironmentConfig_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_EnvironmentConfig_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_EnvironmentConfig_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_EnvironmentConfig_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_EnvironmentConfig_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024361 RID: 148321 RVA: 0x00997BD8 File Offset: 0x00995DD8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_EnvironmentConfig(int EntryPoint)
		{
			BP_EnvironmentConfig_C.__ExecuteUbergraph_BP_EnvironmentConfig_FunctionParams* ptr = stackalloc BP_EnvironmentConfig_C.__ExecuteUbergraph_BP_EnvironmentConfig_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_EnvironmentConfig_C.__ExecuteUbergraph_BP_EnvironmentConfig_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_EnvironmentConfig_C.__ExecuteUbergraph_BP_EnvironmentConfig_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_EnvironmentConfig_C.__ExecuteUbergraph_BP_EnvironmentConfig_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024362 RID: 148322 RVA: 0x00997C1F File Offset: 0x00995E1F
		protected BP_EnvironmentConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012860 RID: 75872
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/BP_EnvironmentConfig.BP_EnvironmentConfig_C";

		// Token: 0x04012861 RID: 75873
		private static IntPtr _ClassPtr;

		// Token: 0x04012862 RID: 75874
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012863 RID: 75875
		internal static int __PropertyOffset_0;

		// Token: 0x04012864 RID: 75876
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012865 RID: 75877
		internal static int __PropertyOffset_1;

		// Token: 0x04012866 RID: 75878
		internal static int __PropertyOffset_2;

		// Token: 0x04012867 RID: 75879
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _BeginCommandList;

		// Token: 0x04012868 RID: 75880
		internal static int __PropertyOffset_3;

		// Token: 0x04012869 RID: 75881
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _EndCommandList;

		// Token: 0x0401286A RID: 75882
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401286B RID: 75883
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x0401286C RID: 75884
		private static IntPtr __ExecuteUbergraph_BP_EnvironmentConfig_NativeFunctionPtr;

		// Token: 0x02009DA0 RID: 40352
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04032797 RID: 206743
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009DA1 RID: 40353
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __ExecuteUbergraph_BP_EnvironmentConfig_FunctionParams
		{
			// Token: 0x04032798 RID: 206744
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
