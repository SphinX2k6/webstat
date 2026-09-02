using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.NewCloud.BP
{
	// Token: 0x02003CC4 RID: 15556
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/BP_Cloud_LaunchScene.BP_Cloud_LaunchScene_C")]
	[UnrealStructLayout(1064, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1064)]
	public class BP_Cloud_LaunchScene_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024F5A RID: 151386 RVA: 0x009AD163 File Offset: 0x009AB363
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Cloud_LaunchScene_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/BP_Cloud_LaunchScene.BP_Cloud_LaunchScene_C");
			}
			return BP_Cloud_LaunchScene_C._ClassPtr;
		}

		// Token: 0x06024F5B RID: 151387 RVA: 0x009AD188 File Offset: 0x009AB388
		public BP_Cloud_LaunchScene_C() : this(BuiltinUtils.AllocNativeUObject(BP_Cloud_LaunchScene_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024F5C RID: 151388 RVA: 0x009AD1B0 File Offset: 0x009AB3B0
		[NullableContext(1)]
		public BP_Cloud_LaunchScene_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Cloud_LaunchScene_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004EBE RID: 20158
		// (get) Token: 0x06024F5D RID: 151389 RVA: 0x009AD1E4 File Offset: 0x009AB3E4
		// (set) Token: 0x06024F5E RID: 151390 RVA: 0x009AD21D File Offset: 0x009AB41D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Cloud_LaunchScene_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Cloud_LaunchScene_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004EBF RID: 20159
		// (get) Token: 0x06024F5F RID: 151391 RVA: 0x009AD23E File Offset: 0x009AB43E
		// (set) Token: 0x06024F60 RID: 151392 RVA: 0x009AD252 File Offset: 0x009AB452
		public unsafe UChildActorComponent Cloud
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cloud_LaunchScene_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cloud_LaunchScene_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004EC0 RID: 20160
		// (get) Token: 0x06024F61 RID: 151393 RVA: 0x009AD267 File Offset: 0x009AB467
		// (set) Token: 0x06024F62 RID: 151394 RVA: 0x009AD27B File Offset: 0x009AB47B
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cloud_LaunchScene_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cloud_LaunchScene_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004EC1 RID: 20161
		// (get) Token: 0x06024F63 RID: 151395 RVA: 0x009AD290 File Offset: 0x009AB490
		// (set) Token: 0x06024F64 RID: 151396 RVA: 0x009AD2A4 File Offset: 0x009AB4A4
		public unsafe PD_CloudPrefab_C CloudPrefeb
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_CloudPrefab_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cloud_LaunchScene_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cloud_LaunchScene_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x06024F65 RID: 151397 RVA: 0x009AD2B9 File Offset: 0x009AB4B9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_LaunchScene_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06024F66 RID: 151398 RVA: 0x009AD2CD File Offset: 0x009AB4CD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_LaunchScene_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024F67 RID: 151399 RVA: 0x009AD2E2 File Offset: 0x009AB4E2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_LaunchScene_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06024F68 RID: 151400 RVA: 0x009AD2F6 File Offset: 0x009AB4F6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_LaunchScene_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024F69 RID: 151401 RVA: 0x009AD30B File Offset: 0x009AB50B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Init()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_LaunchScene_C.__Init_NativeFunctionPtr, null);
		}

		// Token: 0x06024F6A RID: 151402 RVA: 0x009AD320 File Offset: 0x009AB520
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Cloud_LaunchScene(int EntryPoint)
		{
			BP_Cloud_LaunchScene_C.__ExecuteUbergraph_BP_Cloud_LaunchScene_FunctionParams* ptr = stackalloc BP_Cloud_LaunchScene_C.__ExecuteUbergraph_BP_Cloud_LaunchScene_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_Cloud_LaunchScene_C.__ExecuteUbergraph_BP_Cloud_LaunchScene_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_LaunchScene_C.__ExecuteUbergraph_BP_Cloud_LaunchScene_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_LaunchScene_C.__ExecuteUbergraph_BP_Cloud_LaunchScene_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024F6B RID: 151403 RVA: 0x009AD367 File Offset: 0x009AB567
		protected BP_Cloud_LaunchScene_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012FD7 RID: 77783
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/BP_Cloud_LaunchScene.BP_Cloud_LaunchScene_C";

		// Token: 0x04012FD8 RID: 77784
		private static IntPtr _ClassPtr;

		// Token: 0x04012FD9 RID: 77785
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012FDA RID: 77786
		internal static int __PropertyOffset_0;

		// Token: 0x04012FDB RID: 77787
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012FDC RID: 77788
		internal static int __PropertyOffset_1;

		// Token: 0x04012FDD RID: 77789
		internal static int __PropertyOffset_2;

		// Token: 0x04012FDE RID: 77790
		internal static int __PropertyOffset_3;

		// Token: 0x04012FDF RID: 77791
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04012FE0 RID: 77792
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012FE1 RID: 77793
		private static IntPtr __Init_NativeFunctionPtr;

		// Token: 0x04012FE2 RID: 77794
		private static IntPtr __ExecuteUbergraph_BP_Cloud_LaunchScene_NativeFunctionPtr;

		// Token: 0x02009EA8 RID: 40616
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ExecuteUbergraph_BP_Cloud_LaunchScene_FunctionParams
		{
			// Token: 0x04032968 RID: 207208
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
