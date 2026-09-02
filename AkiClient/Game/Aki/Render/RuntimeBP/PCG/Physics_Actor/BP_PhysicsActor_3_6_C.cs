using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.PCG.Physics_Actor.RuntimeData;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.Physics_Actor
{
	// Token: 0x02003BA5 RID: 15269
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/Physics_Actor/BP_PhysicsActor_3_6.BP_PhysicsActor_3_6_C")]
	[UnrealStructLayout(1408, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1408)]
	public class BP_PhysicsActor_3_6_C : AKuroPhysicActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021F51 RID: 139089 RVA: 0x009583BC File Offset: 0x009565BC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PhysicsActor_3_6_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/Physics_Actor/BP_PhysicsActor_3_6.BP_PhysicsActor_3_6_C");
			}
			return BP_PhysicsActor_3_6_C._ClassPtr;
		}

		// Token: 0x06021F52 RID: 139090 RVA: 0x009583E0 File Offset: 0x009565E0
		public BP_PhysicsActor_3_6_C() : this(BuiltinUtils.AllocNativeUObject(BP_PhysicsActor_3_6_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021F53 RID: 139091 RVA: 0x00958408 File Offset: 0x00956608
		public BP_PhysicsActor_3_6_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PhysicsActor_3_6_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003DF2 RID: 15858
		// (get) Token: 0x06021F54 RID: 139092 RVA: 0x0095843C File Offset: 0x0095663C
		// (set) Token: 0x06021F55 RID: 139093 RVA: 0x00958475 File Offset: 0x00956675
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_PhysicsActor_3_6_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_PhysicsActor_3_6_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003DF3 RID: 15859
		// (get) Token: 0x06021F56 RID: 139094 RVA: 0x00958496 File Offset: 0x00956696
		// (set) Token: 0x06021F57 RID: 139095 RVA: 0x009584AA File Offset: 0x009566AA
		[Nullable(2)]
		public unsafe UStaticMeshComponent StaticMesh_0
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicsActor_3_6_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicsActor_3_6_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003DF4 RID: 15860
		// (get) Token: 0x06021F58 RID: 139096 RVA: 0x009584BF File Offset: 0x009566BF
		// (set) Token: 0x06021F59 RID: 139097 RVA: 0x009584D3 File Offset: 0x009566D3
		[Nullable(2)]
		public unsafe UDataTable DT_PhysicalAudio
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDataTable>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicsActor_3_6_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicsActor_3_6_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003DF5 RID: 15861
		// (get) Token: 0x06021F5A RID: 139098 RVA: 0x009584E8 File Offset: 0x009566E8
		// (set) Token: 0x06021F5B RID: 139099 RVA: 0x00958521 File Offset: 0x00956721
		public TArray<S_PhysicalAudio> PhysicalAudioArray
		{
			get
			{
				base.FastCheckIsValid();
				TArray<S_PhysicalAudio> result;
				if ((result = this._PhysicalAudioArray) == null)
				{
					result = (this._PhysicalAudioArray = new TArray<S_PhysicalAudio>(base.NativePtr + (IntPtr)BP_PhysicsActor_3_6_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				this.PhysicalAudioArray.CopyAssign(value);
			}
		}

		// Token: 0x17003DF6 RID: 15862
		// (get) Token: 0x06021F5C RID: 139100 RVA: 0x00958530 File Offset: 0x00956730
		// (set) Token: 0x06021F5D RID: 139101 RVA: 0x00958569 File Offset: 0x00956769
		public S_PhysicalAudio PhysicalAudioDefault
		{
			get
			{
				base.FastCheckIsValid();
				S_PhysicalAudio result;
				if ((result = this._PhysicalAudioDefault) == null)
				{
					result = (this._PhysicalAudioDefault = new S_PhysicalAudio(base.NativePtr + (IntPtr)BP_PhysicsActor_3_6_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(S_PhysicalAudio.StaticStruct(), base.NativePtr + (IntPtr)BP_PhysicsActor_3_6_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003DF7 RID: 15863
		// (get) Token: 0x06021F5E RID: 139102 RVA: 0x0095858C File Offset: 0x0095678C
		// (set) Token: 0x06021F5F RID: 139103 RVA: 0x009585C5 File Offset: 0x009567C5
		public S_PhysicalAudio CurrentPhysicalAudio
		{
			get
			{
				base.FastCheckIsValid();
				S_PhysicalAudio result;
				if ((result = this._CurrentPhysicalAudio) == null)
				{
					result = (this._CurrentPhysicalAudio = new S_PhysicalAudio(base.NativePtr + (IntPtr)BP_PhysicsActor_3_6_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(S_PhysicalAudio.StaticStruct(), base.NativePtr + (IntPtr)BP_PhysicsActor_3_6_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06021F60 RID: 139104 RVA: 0x009585E6 File Offset: 0x009567E6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Physics_Audio_Table()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicsActor_3_6_C.__Physics_Audio_Table_NativeFunctionPtr, null);
		}

		// Token: 0x06021F61 RID: 139105 RVA: 0x009585FC File Offset: 0x009567FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Completed_3AEBD3224C7D32CC3C79A8B855CA6F69(int PlayingID)
		{
			BP_PhysicsActor_3_6_C.__Completed_3AEBD3224C7D32CC3C79A8B855CA6F69_FunctionParams* ptr = stackalloc BP_PhysicsActor_3_6_C.__Completed_3AEBD3224C7D32CC3C79A8B855CA6F69_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PhysicsActor_3_6_C.__Completed_3AEBD3224C7D32CC3C79A8B855CA6F69_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PhysicsActor_3_6_C.__Completed_3AEBD3224C7D32CC3C79A8B855CA6F69_NativeFunctionPtr, (void*)ptr, 1);
			ptr->PlayingID = PlayingID;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicsActor_3_6_C.__Completed_3AEBD3224C7D32CC3C79A8B855CA6F69_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021F62 RID: 139106 RVA: 0x00958642 File Offset: 0x00956842
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicDisable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicsActor_3_6_C.__OnLogicDisable_NativeFunctionPtr, null);
		}

		// Token: 0x06021F63 RID: 139107 RVA: 0x00958656 File Offset: 0x00956856
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicDisable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PhysicsActor_3_6_C.__OnLogicDisable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021F64 RID: 139108 RVA: 0x0095866B File Offset: 0x0095686B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicEnable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicsActor_3_6_C.__OnLogicEnable_NativeFunctionPtr, null);
		}

		// Token: 0x06021F65 RID: 139109 RVA: 0x0095867F File Offset: 0x0095687F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicEnable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PhysicsActor_3_6_C.__OnLogicEnable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021F66 RID: 139110 RVA: 0x00958694 File Offset: 0x00956894
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicsActor_3_6_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06021F67 RID: 139111 RVA: 0x009586A8 File Offset: 0x009568A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PhysicsActor_3_6_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021F68 RID: 139112 RVA: 0x009586C0 File Offset: 0x009568C0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_PhysicsActor_3_6_StaticMesh_0_K2Node_ComponentBoundEvent_0_ComponentHitSignature__DelegateSignature(UPrimitiveComponent HitComponent, AActor OtherActor, UPrimitiveComponent OtherComp, FVector NormalImpulse, in FHitResult Hit)
		{
			BP_PhysicsActor_3_6_C.__BndEvt__BP_PhysicsActor_3_6_StaticMesh_0_K2Node_ComponentBoundEvent_0_ComponentHitSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_PhysicsActor_3_6_C.__BndEvt__BP_PhysicsActor_3_6_StaticMesh_0_K2Node_ComponentBoundEvent_0_ComponentHitSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_PhysicsActor_3_6_C.__BndEvt__BP_PhysicsActor_3_6_StaticMesh_0_K2Node_ComponentBoundEvent_0_ComponentHitSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PhysicsActor_3_6_C.__BndEvt__BP_PhysicsActor_3_6_StaticMesh_0_K2Node_ComponentBoundEvent_0_ComponentHitSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->HitComponent = ((HitComponent != null) ? HitComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->NormalImpulse = NormalImpulse;
			if (Hit != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->Hit, Hit.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicsActor_3_6_C.__BndEvt__BP_PhysicsActor_3_6_StaticMesh_0_K2Node_ComponentBoundEvent_0_ComponentHitSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021F69 RID: 139113 RVA: 0x00958774 File Offset: 0x00956974
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_PhysicsActor_3_6(int EntryPoint)
		{
			BP_PhysicsActor_3_6_C.__ExecuteUbergraph_BP_PhysicsActor_3_6_FunctionParams* ptr = stackalloc BP_PhysicsActor_3_6_C.__ExecuteUbergraph_BP_PhysicsActor_3_6_FunctionParams[(UIntPtr)567] + 15L / (long)sizeof(BP_PhysicsActor_3_6_C.__ExecuteUbergraph_BP_PhysicsActor_3_6_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PhysicsActor_3_6_C.__ExecuteUbergraph_BP_PhysicsActor_3_6_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PhysicsActor_3_6_C.__ExecuteUbergraph_BP_PhysicsActor_3_6_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021F6A RID: 139114 RVA: 0x009587BE File Offset: 0x009569BE
		protected BP_PhysicsActor_3_6_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401125D RID: 70237
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/Physics_Actor/BP_PhysicsActor_3_6.BP_PhysicsActor_3_6_C";

		// Token: 0x0401125E RID: 70238
		private static IntPtr _ClassPtr;

		// Token: 0x0401125F RID: 70239
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011260 RID: 70240
		internal static int __PropertyOffset_0;

		// Token: 0x04011261 RID: 70241
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011262 RID: 70242
		internal static int __PropertyOffset_1;

		// Token: 0x04011263 RID: 70243
		internal static int __PropertyOffset_2;

		// Token: 0x04011264 RID: 70244
		internal static int __PropertyOffset_3;

		// Token: 0x04011265 RID: 70245
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<S_PhysicalAudio> _PhysicalAudioArray;

		// Token: 0x04011266 RID: 70246
		internal static int __PropertyOffset_4;

		// Token: 0x04011267 RID: 70247
		[Nullable(2)]
		private S_PhysicalAudio _PhysicalAudioDefault;

		// Token: 0x04011268 RID: 70248
		internal static int __PropertyOffset_5;

		// Token: 0x04011269 RID: 70249
		[Nullable(2)]
		private S_PhysicalAudio _CurrentPhysicalAudio;

		// Token: 0x0401126A RID: 70250
		private static IntPtr __Physics_Audio_Table_NativeFunctionPtr;

		// Token: 0x0401126B RID: 70251
		private static IntPtr __Completed_3AEBD3224C7D32CC3C79A8B855CA6F69_NativeFunctionPtr;

		// Token: 0x0401126C RID: 70252
		private static IntPtr __OnLogicDisable_NativeFunctionPtr;

		// Token: 0x0401126D RID: 70253
		private static IntPtr __OnLogicEnable_NativeFunctionPtr;

		// Token: 0x0401126E RID: 70254
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401126F RID: 70255
		private static IntPtr __BndEvt__BP_PhysicsActor_3_6_StaticMesh_0_K2Node_ComponentBoundEvent_0_ComponentHitSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011270 RID: 70256
		private static IntPtr __ExecuteUbergraph_BP_PhysicsActor_3_6_NativeFunctionPtr;

		// Token: 0x02009B7A RID: 39802
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __Completed_3AEBD3224C7D32CC3C79A8B855CA6F69_FunctionParams
		{
			// Token: 0x0403236D RID: 205677
			[FieldOffset(0)]
			public int PlayingID;
		}

		// Token: 0x02009B7B RID: 39803
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_PhysicsActor_3_6_StaticMesh_0_K2Node_ComponentBoundEvent_0_ComponentHitSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x0403236E RID: 205678
			[FieldOffset(0)]
			public IntPtr HitComponent;

			// Token: 0x0403236F RID: 205679
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032370 RID: 205680
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032371 RID: 205681
			[FieldOffset(24)]
			public FVector NormalImpulse;

			// Token: 0x04032372 RID: 205682
			[FieldOffset(36)]
			public byte Hit;
		}

		// Token: 0x02009B7C RID: 39804
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 552)]
		protected ref struct __ExecuteUbergraph_BP_PhysicsActor_3_6_FunctionParams
		{
			// Token: 0x04032373 RID: 205683
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
