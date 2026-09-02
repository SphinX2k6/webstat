using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.TrailFields.Runtime.Sensors
{
	// Token: 0x02003A30 RID: 14896
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/Sensors/BP_TrailSensor_Mesh.BP_TrailSensor_Mesh_C")]
	[UnrealStructLayout(1328, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1324)]
	public class BP_TrailSensor_Mesh_C : BP_TrailSensorActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601EB03 RID: 125699 RVA: 0x008FBB70 File Offset: 0x008F9D70
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_TrailSensor_Mesh_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/Sensors/BP_TrailSensor_Mesh.BP_TrailSensor_Mesh_C");
			}
			return BP_TrailSensor_Mesh_C._ClassPtr;
		}

		// Token: 0x0601EB04 RID: 125700 RVA: 0x008FBB94 File Offset: 0x008F9D94
		public BP_TrailSensor_Mesh_C() : this(BuiltinUtils.AllocNativeUObject(BP_TrailSensor_Mesh_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601EB05 RID: 125701 RVA: 0x008FBBBC File Offset: 0x008F9DBC
		[NullableContext(1)]
		public BP_TrailSensor_Mesh_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_TrailSensor_Mesh_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002BEA RID: 11242
		// (get) Token: 0x0601EB06 RID: 125702 RVA: 0x008FBBF0 File Offset: 0x008F9DF0
		// (set) Token: 0x0601EB07 RID: 125703 RVA: 0x008FBC29 File Offset: 0x008F9E29
		[Nullable(1)]
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_TrailSensor_Mesh_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_TrailSensor_Mesh_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002BEB RID: 11243
		// (get) Token: 0x0601EB08 RID: 125704 RVA: 0x008FBC4A File Offset: 0x008F9E4A
		// (set) Token: 0x0601EB09 RID: 125705 RVA: 0x008FBC5E File Offset: 0x008F9E5E
		public unsafe USceneComponent Mesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensor_Mesh_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensor_Mesh_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002BEC RID: 11244
		// (get) Token: 0x0601EB0A RID: 125706 RVA: 0x008FBC73 File Offset: 0x008F9E73
		// (set) Token: 0x0601EB0B RID: 125707 RVA: 0x008FBC87 File Offset: 0x008F9E87
		public unsafe BP_TrailsManager_C Manager
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_TrailsManager_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensor_Mesh_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensor_Mesh_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002BED RID: 11245
		// (get) Token: 0x0601EB0C RID: 125708 RVA: 0x008FBC9C File Offset: 0x008F9E9C
		// (set) Token: 0x0601EB0D RID: 125709 RVA: 0x008FBCB0 File Offset: 0x008F9EB0
		public unsafe UMaterialInstanceDynamic SnowMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensor_Mesh_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensor_Mesh_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002BEE RID: 11246
		// (get) Token: 0x0601EB0E RID: 125710 RVA: 0x008FBCC5 File Offset: 0x008F9EC5
		// (set) Token: 0x0601EB0F RID: 125711 RVA: 0x008FBCD9 File Offset: 0x008F9ED9
		public unsafe UMaterialInterface Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensor_Mesh_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensor_Mesh_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17002BEF RID: 11247
		// (get) Token: 0x0601EB10 RID: 125712 RVA: 0x008FBCEE File Offset: 0x008F9EEE
		// (set) Token: 0x0601EB11 RID: 125713 RVA: 0x008FBD02 File Offset: 0x008F9F02
		public unsafe FRotator MeshRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailSensor_Mesh_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailSensor_Mesh_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x0601EB12 RID: 125714 RVA: 0x008FBD17 File Offset: 0x008F9F17
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CreateSnowfield()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailSensor_Mesh_C.__CreateSnowfield_NativeFunctionPtr, null);
		}

		// Token: 0x0601EB13 RID: 125715 RVA: 0x008FBD2C File Offset: 0x008F9F2C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CreatePreviewMat(float PreviewTexSize, UTexture PrevuewTexture)
		{
			BP_TrailSensor_Mesh_C.__CreatePreviewMat_FunctionParams* ptr = stackalloc BP_TrailSensor_Mesh_C.__CreatePreviewMat_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_TrailSensor_Mesh_C.__CreatePreviewMat_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailSensor_Mesh_C.__CreatePreviewMat_NativeFunctionPtr, (void*)ptr, 1);
			ptr->PreviewTexSize = PreviewTexSize;
			ptr->PrevuewTexture = ((PrevuewTexture != null) ? PrevuewTexture.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailSensor_Mesh_C.__CreatePreviewMat_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EB14 RID: 125716 RVA: 0x008FBD88 File Offset: 0x008F9F88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitializeSnowMatInfo()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailSensor_Mesh_C.__InitializeSnowMatInfo_NativeFunctionPtr, null);
		}

		// Token: 0x0601EB15 RID: 125717 RVA: 0x008FBD9C File Offset: 0x008F9F9C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailSensor_Mesh_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601EB16 RID: 125718 RVA: 0x008FBDB0 File Offset: 0x008F9FB0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrailSensor_Mesh_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EB17 RID: 125719 RVA: 0x008FBDC5 File Offset: 0x008F9FC5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailSensor_Mesh_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601EB18 RID: 125720 RVA: 0x008FBDD9 File Offset: 0x008F9FD9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrailSensor_Mesh_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EB19 RID: 125721 RVA: 0x008FBDF0 File Offset: 0x008F9FF0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_TrailSensor_Mesh(int EntryPoint)
		{
			BP_TrailSensor_Mesh_C.__ExecuteUbergraph_BP_TrailSensor_Mesh_FunctionParams* ptr = stackalloc BP_TrailSensor_Mesh_C.__ExecuteUbergraph_BP_TrailSensor_Mesh_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_TrailSensor_Mesh_C.__ExecuteUbergraph_BP_TrailSensor_Mesh_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailSensor_Mesh_C.__ExecuteUbergraph_BP_TrailSensor_Mesh_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrailSensor_Mesh_C.__ExecuteUbergraph_BP_TrailSensor_Mesh_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EB1A RID: 125722 RVA: 0x008FBE37 File Offset: 0x008FA037
		protected BP_TrailSensor_Mesh_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F23C RID: 62012
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/Sensors/BP_TrailSensor_Mesh.BP_TrailSensor_Mesh_C";

		// Token: 0x0400F23D RID: 62013
		private static IntPtr _ClassPtr;

		// Token: 0x0400F23E RID: 62014
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F23F RID: 62015
		internal new static int __PropertyOffset_0;

		// Token: 0x0400F240 RID: 62016
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F241 RID: 62017
		internal new static int __PropertyOffset_1;

		// Token: 0x0400F242 RID: 62018
		internal new static int __PropertyOffset_2;

		// Token: 0x0400F243 RID: 62019
		internal new static int __PropertyOffset_3;

		// Token: 0x0400F244 RID: 62020
		internal new static int __PropertyOffset_4;

		// Token: 0x0400F245 RID: 62021
		internal new static int __PropertyOffset_5;

		// Token: 0x0400F246 RID: 62022
		private static IntPtr __CreateSnowfield_NativeFunctionPtr;

		// Token: 0x0400F247 RID: 62023
		private static IntPtr __CreatePreviewMat_NativeFunctionPtr;

		// Token: 0x0400F248 RID: 62024
		private static IntPtr __InitializeSnowMatInfo_NativeFunctionPtr;

		// Token: 0x0400F249 RID: 62025
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F24A RID: 62026
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F24B RID: 62027
		private static IntPtr __ExecuteUbergraph_BP_TrailSensor_Mesh_NativeFunctionPtr;

		// Token: 0x020097EA RID: 38890
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __CreatePreviewMat_FunctionParams
		{
			// Token: 0x04031DDD RID: 204253
			[FieldOffset(0)]
			public float PreviewTexSize;

			// Token: 0x04031DDE RID: 204254
			[FieldOffset(8)]
			public IntPtr PrevuewTexture;
		}

		// Token: 0x020097EB RID: 38891
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_TrailSensor_Mesh_FunctionParams
		{
			// Token: 0x04031DDF RID: 204255
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
