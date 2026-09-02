using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SceneInteraction
{
	// Token: 0x02003B8F RID: 15247
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SceneInteraction/BP_SplitCloth.BP_SplitCloth_C")]
	[UnrealStructLayout(1160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1160)]
	public class BP_SplitCloth_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021C56 RID: 138326 RVA: 0x00952EC8 File Offset: 0x009510C8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SplitCloth_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SceneInteraction/BP_SplitCloth.BP_SplitCloth_C");
			}
			return BP_SplitCloth_C._ClassPtr;
		}

		// Token: 0x06021C57 RID: 138327 RVA: 0x00952EEC File Offset: 0x009510EC
		public BP_SplitCloth_C() : this(BuiltinUtils.AllocNativeUObject(BP_SplitCloth_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021C58 RID: 138328 RVA: 0x00952F14 File Offset: 0x00951114
		[NullableContext(1)]
		public BP_SplitCloth_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SplitCloth_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003CED RID: 15597
		// (get) Token: 0x06021C59 RID: 138329 RVA: 0x00952F48 File Offset: 0x00951148
		// (set) Token: 0x06021C5A RID: 138330 RVA: 0x00952F81 File Offset: 0x00951181
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SplitCloth_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SplitCloth_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003CEE RID: 15598
		// (get) Token: 0x06021C5B RID: 138331 RVA: 0x00952FA2 File Offset: 0x009511A2
		// (set) Token: 0x06021C5C RID: 138332 RVA: 0x00952FB6 File Offset: 0x009511B6
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitCloth_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitCloth_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003CEF RID: 15599
		// (get) Token: 0x06021C5D RID: 138333 RVA: 0x00952FCB File Offset: 0x009511CB
		// (set) Token: 0x06021C5E RID: 138334 RVA: 0x00952FDF File Offset: 0x009511DF
		public unsafe UStaticMeshComponent SM_Com3_Gra_06BS
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitCloth_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitCloth_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003CF0 RID: 15600
		// (get) Token: 0x06021C5F RID: 138335 RVA: 0x00952FF4 File Offset: 0x009511F4
		// (set) Token: 0x06021C60 RID: 138336 RVA: 0x00953008 File Offset: 0x00951208
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitCloth_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplitCloth_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003CF1 RID: 15601
		// (get) Token: 0x06021C61 RID: 138337 RVA: 0x0095301D File Offset: 0x0095121D
		// (set) Token: 0x06021C62 RID: 138338 RVA: 0x00953031 File Offset: 0x00951231
		public unsafe FVectorDouble AttackPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitCloth_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitCloth_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17003CF2 RID: 15602
		// (get) Token: 0x06021C63 RID: 138339 RVA: 0x00953046 File Offset: 0x00951246
		// (set) Token: 0x06021C64 RID: 138340 RVA: 0x0095305A File Offset: 0x0095125A
		public unsafe FVectorDouble PlayerDirectory
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitCloth_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitCloth_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003CF3 RID: 15603
		// (get) Token: 0x06021C65 RID: 138341 RVA: 0x0095306F File Offset: 0x0095126F
		// (set) Token: 0x06021C66 RID: 138342 RVA: 0x00953083 File Offset: 0x00951283
		public unsafe FVectorDouble PlayerPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitCloth_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitCloth_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003CF4 RID: 15604
		// (get) Token: 0x06021C67 RID: 138343 RVA: 0x00953098 File Offset: 0x00951298
		// (set) Token: 0x06021C68 RID: 138344 RVA: 0x009530A8 File Offset: 0x009512A8
		public unsafe float Delta_Seconds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitCloth_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitCloth_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003CF5 RID: 15605
		// (get) Token: 0x06021C69 RID: 138345 RVA: 0x009530B9 File Offset: 0x009512B9
		// (set) Token: 0x06021C6A RID: 138346 RVA: 0x009530C9 File Offset: 0x009512C9
		public unsafe bool Splited
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplitCloth_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplitCloth_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003CF6 RID: 15606
		// (get) Token: 0x06021C6B RID: 138347 RVA: 0x009530DC File Offset: 0x009512DC
		// (set) Token: 0x06021C6C RID: 138348 RVA: 0x00953115 File Offset: 0x00951315
		[Nullable(1)]
		public TArray<TSoftObjectPtr<UObject>> Staticmesh
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<TSoftObjectPtr<UObject>> result;
				if ((result = this._Staticmesh) == null)
				{
					result = (this._Staticmesh = new TArray<TSoftObjectPtr<UObject>>(base.NativePtr + (IntPtr)BP_SplitCloth_C.__PropertyOffset_9, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Staticmesh.CopyAssign(value);
			}
		}

		// Token: 0x06021C6D RID: 138349 RVA: 0x00953124 File Offset: 0x00951324
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnLoaded_25EAD0904F67E109FC4DF08D3AFE9413(UObject Loaded)
		{
			BP_SplitCloth_C.__OnLoaded_25EAD0904F67E109FC4DF08D3AFE9413_FunctionParams* ptr = stackalloc BP_SplitCloth_C.__OnLoaded_25EAD0904F67E109FC4DF08D3AFE9413_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SplitCloth_C.__OnLoaded_25EAD0904F67E109FC4DF08D3AFE9413_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplitCloth_C.__OnLoaded_25EAD0904F67E109FC4DF08D3AFE9413_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Loaded = ((Loaded != null) ? Loaded.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplitCloth_C.__OnLoaded_25EAD0904F67E109FC4DF08D3AFE9413_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021C6E RID: 138350 RVA: 0x00953179 File Offset: 0x00951379
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplitCloth_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06021C6F RID: 138351 RVA: 0x0095318D File Offset: 0x0095138D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SplitCloth_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021C70 RID: 138352 RVA: 0x009531A4 File Offset: 0x009513A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeaponInteraction(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_SplitCloth_C.__OnWeaponInteraction_FunctionParams* ptr = stackalloc BP_SplitCloth_C.__OnWeaponInteraction_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_SplitCloth_C.__OnWeaponInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplitCloth_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplitCloth_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021C71 RID: 138353 RVA: 0x00953208 File Offset: 0x00951408
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SplitCloth(int EntryPoint)
		{
			BP_SplitCloth_C.__ExecuteUbergraph_BP_SplitCloth_FunctionParams* ptr = stackalloc BP_SplitCloth_C.__ExecuteUbergraph_BP_SplitCloth_FunctionParams[(UIntPtr)343] + 15L / (long)sizeof(BP_SplitCloth_C.__ExecuteUbergraph_BP_SplitCloth_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplitCloth_C.__ExecuteUbergraph_BP_SplitCloth_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SplitCloth_C.__ExecuteUbergraph_BP_SplitCloth_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021C72 RID: 138354 RVA: 0x00953252 File Offset: 0x00951452
		protected BP_SplitCloth_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011094 RID: 69780
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SceneInteraction/BP_SplitCloth.BP_SplitCloth_C";

		// Token: 0x04011095 RID: 69781
		private static IntPtr _ClassPtr;

		// Token: 0x04011096 RID: 69782
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011097 RID: 69783
		internal static int __PropertyOffset_0;

		// Token: 0x04011098 RID: 69784
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011099 RID: 69785
		internal static int __PropertyOffset_1;

		// Token: 0x0401109A RID: 69786
		internal static int __PropertyOffset_2;

		// Token: 0x0401109B RID: 69787
		internal static int __PropertyOffset_3;

		// Token: 0x0401109C RID: 69788
		internal static int __PropertyOffset_4;

		// Token: 0x0401109D RID: 69789
		internal static int __PropertyOffset_5;

		// Token: 0x0401109E RID: 69790
		internal static int __PropertyOffset_6;

		// Token: 0x0401109F RID: 69791
		internal static int __PropertyOffset_7;

		// Token: 0x040110A0 RID: 69792
		internal static int __PropertyOffset_8;

		// Token: 0x040110A1 RID: 69793
		internal static int __PropertyOffset_9;

		// Token: 0x040110A2 RID: 69794
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TArray<TSoftObjectPtr<UObject>> _Staticmesh;

		// Token: 0x040110A3 RID: 69795
		private static IntPtr __OnLoaded_25EAD0904F67E109FC4DF08D3AFE9413_NativeFunctionPtr;

		// Token: 0x040110A4 RID: 69796
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040110A5 RID: 69797
		private static IntPtr __OnWeaponInteraction_NativeFunctionPtr;

		// Token: 0x040110A6 RID: 69798
		private static IntPtr __ExecuteUbergraph_BP_SplitCloth_NativeFunctionPtr;

		// Token: 0x02009B44 RID: 39748
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __OnLoaded_25EAD0904F67E109FC4DF08D3AFE9413_FunctionParams
		{
			// Token: 0x04032320 RID: 205600
			[FieldOffset(0)]
			public IntPtr Loaded;
		}

		// Token: 0x02009B45 RID: 39749
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeaponInteraction_FunctionParams
		{
			// Token: 0x04032321 RID: 205601
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x04032322 RID: 205602
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x04032323 RID: 205603
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x02009B46 RID: 39750
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 328)]
		protected ref struct __ExecuteUbergraph_BP_SplitCloth_FunctionParams
		{
			// Token: 0x04032324 RID: 205604
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
