using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Gameplay.WuWaGo
{
	// Token: 0x02003E97 RID: 16023
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Gameplay/WuWaGo/BP_WuWaGo_WallBox.BP_WuWaGo_WallBox_C")]
	[UnrealStructLayout(1080, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1080)]
	public class BP_WuWaGo_WallBox_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06027B99 RID: 162713 RVA: 0x009F9014 File Offset: 0x009F7214
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_WuWaGo_WallBox_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Gameplay/WuWaGo/BP_WuWaGo_WallBox.BP_WuWaGo_WallBox_C");
			}
			return BP_WuWaGo_WallBox_C._ClassPtr;
		}

		// Token: 0x06027B9A RID: 162714 RVA: 0x009F9038 File Offset: 0x009F7238
		public BP_WuWaGo_WallBox_C() : this(BuiltinUtils.AllocNativeUObject(BP_WuWaGo_WallBox_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06027B9B RID: 162715 RVA: 0x009F9060 File Offset: 0x009F7260
		[NullableContext(1)]
		public BP_WuWaGo_WallBox_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_WuWaGo_WallBox_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005E8A RID: 24202
		// (get) Token: 0x06027B9C RID: 162716 RVA: 0x009F9094 File Offset: 0x009F7294
		// (set) Token: 0x06027B9D RID: 162717 RVA: 0x009F90CD File Offset: 0x009F72CD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_WuWaGo_WallBox_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_WuWaGo_WallBox_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005E8B RID: 24203
		// (get) Token: 0x06027B9E RID: 162718 RVA: 0x009F90EE File Offset: 0x009F72EE
		// (set) Token: 0x06027B9F RID: 162719 RVA: 0x009F9102 File Offset: 0x009F7302
		public unsafe UStaticMeshComponent 模型
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WuWaGo_WallBox_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WuWaGo_WallBox_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005E8C RID: 24204
		// (get) Token: 0x06027BA0 RID: 162720 RVA: 0x009F9117 File Offset: 0x009F7317
		// (set) Token: 0x06027BA1 RID: 162721 RVA: 0x009F912B File Offset: 0x009F732B
		public unsafe UStaticMeshComponent Plane
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WuWaGo_WallBox_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WuWaGo_WallBox_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17005E8D RID: 24205
		// (get) Token: 0x06027BA2 RID: 162722 RVA: 0x009F9140 File Offset: 0x009F7340
		// (set) Token: 0x06027BA3 RID: 162723 RVA: 0x009F9154 File Offset: 0x009F7354
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WuWaGo_WallBox_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WuWaGo_WallBox_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17005E8E RID: 24206
		// (get) Token: 0x06027BA4 RID: 162724 RVA: 0x009F9169 File Offset: 0x009F7369
		// (set) Token: 0x06027BA5 RID: 162725 RVA: 0x009F917D File Offset: 0x009F737D
		public unsafe UMaterialInstance W_默认贴花
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WuWaGo_WallBox_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WuWaGo_WallBox_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17005E8F RID: 24207
		// (get) Token: 0x06027BA6 RID: 162726 RVA: 0x009F9192 File Offset: 0x009F7392
		// (set) Token: 0x06027BA7 RID: 162727 RVA: 0x009F91A6 File Offset: 0x009F73A6
		public unsafe UStaticMesh W_默认模型
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WuWaGo_WallBox_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WuWaGo_WallBox_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x06027BA8 RID: 162728 RVA: 0x009F91BB File Offset: 0x009F73BB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WuWaGo_WallBox_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06027BA9 RID: 162729 RVA: 0x009F91CF File Offset: 0x009F73CF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WuWaGo_WallBox_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06027BAA RID: 162730 RVA: 0x009F91E4 File Offset: 0x009F73E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WuWaGo_WallBox_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06027BAB RID: 162731 RVA: 0x009F91F8 File Offset: 0x009F73F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WuWaGo_WallBox_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06027BAC RID: 162732 RVA: 0x009F9210 File Offset: 0x009F7410
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_WuWaGo_WallBox(int EntryPoint)
		{
			BP_WuWaGo_WallBox_C.__ExecuteUbergraph_BP_WuWaGo_WallBox_FunctionParams* ptr = stackalloc BP_WuWaGo_WallBox_C.__ExecuteUbergraph_BP_WuWaGo_WallBox_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WuWaGo_WallBox_C.__ExecuteUbergraph_BP_WuWaGo_WallBox_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WuWaGo_WallBox_C.__ExecuteUbergraph_BP_WuWaGo_WallBox_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WuWaGo_WallBox_C.__ExecuteUbergraph_BP_WuWaGo_WallBox_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06027BAD RID: 162733 RVA: 0x009F9257 File Offset: 0x009F7457
		protected BP_WuWaGo_WallBox_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014D61 RID: 85345
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Data/Gameplay/WuWaGo/BP_WuWaGo_WallBox.BP_WuWaGo_WallBox_C";

		// Token: 0x04014D62 RID: 85346
		private static IntPtr _ClassPtr;

		// Token: 0x04014D63 RID: 85347
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014D64 RID: 85348
		internal static int __PropertyOffset_0;

		// Token: 0x04014D65 RID: 85349
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04014D66 RID: 85350
		internal static int __PropertyOffset_1;

		// Token: 0x04014D67 RID: 85351
		internal static int __PropertyOffset_2;

		// Token: 0x04014D68 RID: 85352
		internal static int __PropertyOffset_3;

		// Token: 0x04014D69 RID: 85353
		internal static int __PropertyOffset_4;

		// Token: 0x04014D6A RID: 85354
		internal static int __PropertyOffset_5;

		// Token: 0x04014D6B RID: 85355
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04014D6C RID: 85356
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04014D6D RID: 85357
		private static IntPtr __ExecuteUbergraph_BP_WuWaGo_WallBox_NativeFunctionPtr;

		// Token: 0x0200A0DD RID: 41181
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_WuWaGo_WallBox_FunctionParams
		{
			// Token: 0x04032D97 RID: 208279
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
