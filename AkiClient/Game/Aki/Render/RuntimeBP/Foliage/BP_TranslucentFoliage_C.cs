using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Foliage
{
	// Token: 0x02003CEB RID: 15595
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Foliage/BP_TranslucentFoliage.BP_TranslucentFoliage_C")]
	[UnrealStructLayout(1096, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1096)]
	public class BP_TranslucentFoliage_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060253D7 RID: 152535 RVA: 0x009B4E94 File Offset: 0x009B3094
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_TranslucentFoliage_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Foliage/BP_TranslucentFoliage.BP_TranslucentFoliage_C");
			}
			return BP_TranslucentFoliage_C._ClassPtr;
		}

		// Token: 0x060253D8 RID: 152536 RVA: 0x009B4EB8 File Offset: 0x009B30B8
		public BP_TranslucentFoliage_C() : this(BuiltinUtils.AllocNativeUObject(BP_TranslucentFoliage_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060253D9 RID: 152537 RVA: 0x009B4EE0 File Offset: 0x009B30E0
		public BP_TranslucentFoliage_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_TranslucentFoliage_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005060 RID: 20576
		// (get) Token: 0x060253DA RID: 152538 RVA: 0x009B4F14 File Offset: 0x009B3114
		// (set) Token: 0x060253DB RID: 152539 RVA: 0x009B4F4D File Offset: 0x009B314D
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_TranslucentFoliage_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_TranslucentFoliage_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005061 RID: 20577
		// (get) Token: 0x060253DC RID: 152540 RVA: 0x009B4F6E File Offset: 0x009B316E
		// (set) Token: 0x060253DD RID: 152541 RVA: 0x009B4F82 File Offset: 0x009B3182
		[Nullable(2)]
		public unsafe UStaticMeshComponent StaticMesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TranslucentFoliage_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TranslucentFoliage_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005062 RID: 20578
		// (get) Token: 0x060253DE RID: 152542 RVA: 0x009B4F97 File Offset: 0x009B3197
		// (set) Token: 0x060253DF RID: 152543 RVA: 0x009B4FAB File Offset: 0x009B31AB
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TranslucentFoliage_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TranslucentFoliage_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17005063 RID: 20579
		// (get) Token: 0x060253E0 RID: 152544 RVA: 0x009B4FC0 File Offset: 0x009B31C0
		// (set) Token: 0x060253E1 RID: 152545 RVA: 0x009B4FD0 File Offset: 0x009B31D0
		public unsafe bool bEditorTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TranslucentFoliage_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TranslucentFoliage_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005064 RID: 20580
		// (get) Token: 0x060253E2 RID: 152546 RVA: 0x009B4FE1 File Offset: 0x009B31E1
		// (set) Token: 0x060253E3 RID: 152547 RVA: 0x009B4FF1 File Offset: 0x009B31F1
		public unsafe bool bVisible
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TranslucentFoliage_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TranslucentFoliage_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005065 RID: 20581
		// (get) Token: 0x060253E4 RID: 152548 RVA: 0x009B5002 File Offset: 0x009B3202
		// (set) Token: 0x060253E5 RID: 152549 RVA: 0x009B5012 File Offset: 0x009B3212
		public unsafe bool bDissolve
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TranslucentFoliage_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TranslucentFoliage_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005066 RID: 20582
		// (get) Token: 0x060253E6 RID: 152550 RVA: 0x009B5024 File Offset: 0x009B3224
		// (set) Token: 0x060253E7 RID: 152551 RVA: 0x009B505D File Offset: 0x009B325D
		public TArray<UMaterialInterface> MaterialsWithDissolve
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInterface> result;
				if ((result = this._MaterialsWithDissolve) == null)
				{
					result = (this._MaterialsWithDissolve = new TArray<UMaterialInterface>(base.NativePtr + (IntPtr)BP_TranslucentFoliage_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				this.MaterialsWithDissolve.CopyAssign(value);
			}
		}

		// Token: 0x17005067 RID: 20583
		// (get) Token: 0x060253E8 RID: 152552 RVA: 0x009B506C File Offset: 0x009B326C
		// (set) Token: 0x060253E9 RID: 152553 RVA: 0x009B50A5 File Offset: 0x009B32A5
		public TArray<UMaterialInterface> MaterialsWithoutDissolve
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInterface> result;
				if ((result = this._MaterialsWithoutDissolve) == null)
				{
					result = (this._MaterialsWithoutDissolve = new TArray<UMaterialInterface>(base.NativePtr + (IntPtr)BP_TranslucentFoliage_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				this.MaterialsWithoutDissolve.CopyAssign(value);
			}
		}

		// Token: 0x060253EA RID: 152554 RVA: 0x009B50B3 File Offset: 0x009B32B3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TranslucentFoliage_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060253EB RID: 152555 RVA: 0x009B50C7 File Offset: 0x009B32C7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TranslucentFoliage_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060253EC RID: 152556 RVA: 0x009B50DC File Offset: 0x009B32DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TranslucentFoliage_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060253ED RID: 152557 RVA: 0x009B50F0 File Offset: 0x009B32F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TranslucentFoliage_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060253EE RID: 152558 RVA: 0x009B5108 File Offset: 0x009B3308
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_TranslucentFoliage_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_TranslucentFoliage_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_TranslucentFoliage_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TranslucentFoliage_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TranslucentFoliage_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060253EF RID: 152559 RVA: 0x009B5150 File Offset: 0x009B3350
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_TranslucentFoliage_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_TranslucentFoliage_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_TranslucentFoliage_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TranslucentFoliage_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TranslucentFoliage_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060253F0 RID: 152560 RVA: 0x009B5197 File Offset: 0x009B3397
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TranslucentFoliage_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x060253F1 RID: 152561 RVA: 0x009B51AC File Offset: 0x009B33AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_TranslucentFoliage(int EntryPoint)
		{
			BP_TranslucentFoliage_C.__ExecuteUbergraph_BP_TranslucentFoliage_FunctionParams* ptr = stackalloc BP_TranslucentFoliage_C.__ExecuteUbergraph_BP_TranslucentFoliage_FunctionParams[(UIntPtr)295] + 15L / (long)sizeof(BP_TranslucentFoliage_C.__ExecuteUbergraph_BP_TranslucentFoliage_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TranslucentFoliage_C.__ExecuteUbergraph_BP_TranslucentFoliage_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TranslucentFoliage_C.__ExecuteUbergraph_BP_TranslucentFoliage_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060253F2 RID: 152562 RVA: 0x009B51F6 File Offset: 0x009B33F6
		protected BP_TranslucentFoliage_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040132E6 RID: 78566
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Foliage/BP_TranslucentFoliage.BP_TranslucentFoliage_C";

		// Token: 0x040132E7 RID: 78567
		private static IntPtr _ClassPtr;

		// Token: 0x040132E8 RID: 78568
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040132E9 RID: 78569
		internal static int __PropertyOffset_0;

		// Token: 0x040132EA RID: 78570
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040132EB RID: 78571
		internal static int __PropertyOffset_1;

		// Token: 0x040132EC RID: 78572
		internal static int __PropertyOffset_2;

		// Token: 0x040132ED RID: 78573
		internal static int __PropertyOffset_3;

		// Token: 0x040132EE RID: 78574
		internal static int __PropertyOffset_4;

		// Token: 0x040132EF RID: 78575
		internal static int __PropertyOffset_5;

		// Token: 0x040132F0 RID: 78576
		internal static int __PropertyOffset_6;

		// Token: 0x040132F1 RID: 78577
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInterface> _MaterialsWithDissolve;

		// Token: 0x040132F2 RID: 78578
		internal static int __PropertyOffset_7;

		// Token: 0x040132F3 RID: 78579
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInterface> _MaterialsWithoutDissolve;

		// Token: 0x040132F4 RID: 78580
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040132F5 RID: 78581
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040132F6 RID: 78582
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040132F7 RID: 78583
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x040132F8 RID: 78584
		private static IntPtr __ExecuteUbergraph_BP_TranslucentFoliage_NativeFunctionPtr;

		// Token: 0x02009EEA RID: 40682
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040329DA RID: 207322
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009EEB RID: 40683
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 280)]
		protected ref struct __ExecuteUbergraph_BP_TranslucentFoliage_FunctionParams
		{
			// Token: 0x040329DB RID: 207323
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
