using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.PathLine
{
	// Token: 0x02003E51 RID: 15953
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/PathLine/BP_Miaozhunxian.BP_Miaozhunxian_C")]
	[UnrealStructLayout(1104, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1097)]
	public class BP_Miaozhunxian_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060275D2 RID: 161234 RVA: 0x009F0199 File Offset: 0x009EE399
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Miaozhunxian_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/PathLine/BP_Miaozhunxian.BP_Miaozhunxian_C");
			}
			return BP_Miaozhunxian_C._ClassPtr;
		}

		// Token: 0x060275D3 RID: 161235 RVA: 0x009F01C0 File Offset: 0x009EE3C0
		public BP_Miaozhunxian_C() : this(BuiltinUtils.AllocNativeUObject(BP_Miaozhunxian_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060275D4 RID: 161236 RVA: 0x009F01E8 File Offset: 0x009EE3E8
		[NullableContext(1)]
		public BP_Miaozhunxian_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Miaozhunxian_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005C6A RID: 23658
		// (get) Token: 0x060275D5 RID: 161237 RVA: 0x009F021C File Offset: 0x009EE41C
		// (set) Token: 0x060275D6 RID: 161238 RVA: 0x009F0255 File Offset: 0x009EE455
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Miaozhunxian_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Miaozhunxian_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005C6B RID: 23659
		// (get) Token: 0x060275D7 RID: 161239 RVA: 0x009F0276 File Offset: 0x009EE476
		// (set) Token: 0x060275D8 RID: 161240 RVA: 0x009F028A File Offset: 0x009EE48A
		public unsafe UInstancedStaticMeshComponent InstancedStaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UInstancedStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Miaozhunxian_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Miaozhunxian_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005C6C RID: 23660
		// (get) Token: 0x060275D9 RID: 161241 RVA: 0x009F029F File Offset: 0x009EE49F
		// (set) Token: 0x060275DA RID: 161242 RVA: 0x009F02B3 File Offset: 0x009EE4B3
		public unsafe USplineComponent Spline
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USplineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Miaozhunxian_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Miaozhunxian_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17005C6D RID: 23661
		// (get) Token: 0x060275DB RID: 161243 RVA: 0x009F02C8 File Offset: 0x009EE4C8
		// (set) Token: 0x060275DC RID: 161244 RVA: 0x009F02DC File Offset: 0x009EE4DC
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Miaozhunxian_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Miaozhunxian_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17005C6E RID: 23662
		// (get) Token: 0x060275DD RID: 161245 RVA: 0x009F02F1 File Offset: 0x009EE4F1
		// (set) Token: 0x060275DE RID: 161246 RVA: 0x009F0305 File Offset: 0x009EE505
		public unsafe UStaticMesh BasicStaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Miaozhunxian_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Miaozhunxian_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17005C6F RID: 23663
		// (get) Token: 0x060275DF RID: 161247 RVA: 0x009F031A File Offset: 0x009EE51A
		// (set) Token: 0x060275E0 RID: 161248 RVA: 0x009F032A File Offset: 0x009EE52A
		public unsafe float SamplingNum
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Miaozhunxian_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Miaozhunxian_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005C70 RID: 23664
		// (get) Token: 0x060275E1 RID: 161249 RVA: 0x009F033C File Offset: 0x009EE53C
		// (set) Token: 0x060275E2 RID: 161250 RVA: 0x009F0375 File Offset: 0x009EE575
		[Nullable(1)]
		public TArray<UStaticMeshComponent> BasicStaticMeshs
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UStaticMeshComponent> result;
				if ((result = this._BasicStaticMeshs) == null)
				{
					result = (this._BasicStaticMeshs = new TArray<UStaticMeshComponent>(base.NativePtr + (IntPtr)BP_Miaozhunxian_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.BasicStaticMeshs.CopyAssign(value);
			}
		}

		// Token: 0x17005C71 RID: 23665
		// (get) Token: 0x060275E3 RID: 161251 RVA: 0x009F0383 File Offset: 0x009EE583
		// (set) Token: 0x060275E4 RID: 161252 RVA: 0x009F0393 File Offset: 0x009EE593
		public unsafe bool Showing
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Miaozhunxian_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Miaozhunxian_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x060275E5 RID: 161253 RVA: 0x009F03A4 File Offset: 0x009EE5A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ShowMesh()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Miaozhunxian_C.__ShowMesh_NativeFunctionPtr, null);
		}

		// Token: 0x060275E6 RID: 161254 RVA: 0x009F03B8 File Offset: 0x009EE5B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void HideMesh()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Miaozhunxian_C.__HideMesh_NativeFunctionPtr, null);
		}

		// Token: 0x060275E7 RID: 161255 RVA: 0x009F03CC File Offset: 0x009EE5CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateMesh()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Miaozhunxian_C.__UpdateMesh_NativeFunctionPtr, null);
		}

		// Token: 0x060275E8 RID: 161256 RVA: 0x009F03E0 File Offset: 0x009EE5E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Init()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Miaozhunxian_C.__Init_NativeFunctionPtr, null);
		}

		// Token: 0x060275E9 RID: 161257 RVA: 0x009F03F4 File Offset: 0x009EE5F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Miaozhunxian_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060275EA RID: 161258 RVA: 0x009F0408 File Offset: 0x009EE608
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Miaozhunxian_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060275EB RID: 161259 RVA: 0x009F0420 File Offset: 0x009EE620
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Miaozhunxian_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Miaozhunxian_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Miaozhunxian_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Miaozhunxian_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Miaozhunxian_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060275EC RID: 161260 RVA: 0x009F0468 File Offset: 0x009EE668
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Miaozhunxian_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Miaozhunxian_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Miaozhunxian_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Miaozhunxian_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Miaozhunxian_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060275ED RID: 161261 RVA: 0x009F04B0 File Offset: 0x009EE6B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Miaozhunxian(int EntryPoint)
		{
			BP_Miaozhunxian_C.__ExecuteUbergraph_BP_Miaozhunxian_FunctionParams* ptr = stackalloc BP_Miaozhunxian_C.__ExecuteUbergraph_BP_Miaozhunxian_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_Miaozhunxian_C.__ExecuteUbergraph_BP_Miaozhunxian_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Miaozhunxian_C.__ExecuteUbergraph_BP_Miaozhunxian_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Miaozhunxian_C.__ExecuteUbergraph_BP_Miaozhunxian_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060275EE RID: 161262 RVA: 0x009F04F7 File Offset: 0x009EE6F7
		protected BP_Miaozhunxian_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040149BD RID: 84413
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Data/PathLine/BP_Miaozhunxian.BP_Miaozhunxian_C";

		// Token: 0x040149BE RID: 84414
		private static IntPtr _ClassPtr;

		// Token: 0x040149BF RID: 84415
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040149C0 RID: 84416
		internal static int __PropertyOffset_0;

		// Token: 0x040149C1 RID: 84417
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040149C2 RID: 84418
		internal static int __PropertyOffset_1;

		// Token: 0x040149C3 RID: 84419
		internal static int __PropertyOffset_2;

		// Token: 0x040149C4 RID: 84420
		internal static int __PropertyOffset_3;

		// Token: 0x040149C5 RID: 84421
		internal static int __PropertyOffset_4;

		// Token: 0x040149C6 RID: 84422
		internal static int __PropertyOffset_5;

		// Token: 0x040149C7 RID: 84423
		internal static int __PropertyOffset_6;

		// Token: 0x040149C8 RID: 84424
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMeshComponent> _BasicStaticMeshs;

		// Token: 0x040149C9 RID: 84425
		internal static int __PropertyOffset_7;

		// Token: 0x040149CA RID: 84426
		private static IntPtr __ShowMesh_NativeFunctionPtr;

		// Token: 0x040149CB RID: 84427
		private static IntPtr __HideMesh_NativeFunctionPtr;

		// Token: 0x040149CC RID: 84428
		private static IntPtr __UpdateMesh_NativeFunctionPtr;

		// Token: 0x040149CD RID: 84429
		private static IntPtr __Init_NativeFunctionPtr;

		// Token: 0x040149CE RID: 84430
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040149CF RID: 84431
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040149D0 RID: 84432
		private static IntPtr __ExecuteUbergraph_BP_Miaozhunxian_NativeFunctionPtr;

		// Token: 0x0200A0D2 RID: 41170
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032D87 RID: 208263
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A0D3 RID: 41171
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_Miaozhunxian_FunctionParams
		{
			// Token: 0x04032D88 RID: 208264
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
