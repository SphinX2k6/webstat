using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive.Core
{
	// Token: 0x02003D02 RID: 15618
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/NinjaLiveFunctions.NinjaLiveFunctions_C")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 48)]
	public class NinjaLiveFunctions_C : UBlueprintFunctionLibrary, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025A5B RID: 154203 RVA: 0x009BFBB8 File Offset: 0x009BDDB8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NinjaLiveFunctions_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/NinjaLiveFunctions.NinjaLiveFunctions_C");
			}
			return NinjaLiveFunctions_C._ClassPtr;
		}

		// Token: 0x06025A5C RID: 154204 RVA: 0x009BFBDC File Offset: 0x009BDDDC
		public NinjaLiveFunctions_C() : this(BuiltinUtils.AllocNativeUObject(NinjaLiveFunctions_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025A5D RID: 154205 RVA: 0x009BFC04 File Offset: 0x009BDE04
		[NullableContext(1)]
		public NinjaLiveFunctions_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NinjaLiveFunctions_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06025A5E RID: 154206 RVA: 0x009BFC38 File Offset: 0x009BDE38
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void TraceOverlapSingle(FVector Start, FVector End, float TracelineOvershoot, UPrimitiveComponent TraceMesh, UObject __WorldContext, ref FLinearColor HitUV, ref FVector TracePosition)
		{
			NinjaLiveFunctions_C.StaticClass();
			NinjaLiveFunctions_C.__TraceOverlapSingle_FunctionParams* ptr = stackalloc NinjaLiveFunctions_C.__TraceOverlapSingle_FunctionParams[(UIntPtr)559] + 15L / (long)sizeof(NinjaLiveFunctions_C.__TraceOverlapSingle_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveFunctions_C.__TraceOverlapSingle_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Start = Start;
			ptr->End = End;
			ptr->TracelineOvershoot = TracelineOvershoot;
			ptr->TraceMesh = ((TraceMesh != null) ? TraceMesh.NativePtr : IntPtr.Zero);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->HitUV = HitUV;
			ptr->TracePosition = TracePosition;
			UnrealReflectionUtils.CallVirtualUFunction(NinjaLiveFunctions_C._ClassDefaultObjectPtr, NinjaLiveFunctions_C.__TraceOverlapSingle_NativeFunctionPtr, (void*)ptr);
			HitUV = ptr->HitUV;
			TracePosition = ptr->TracePosition;
		}

		// Token: 0x06025A5F RID: 154207 RVA: 0x009BFCF8 File Offset: 0x009BDEF8
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void CameraFacing(USceneComponent InMesh, bool UseLegacyFacing, bool LockY, FRotator TraceMeshInitRot, UObject __WorldContext)
		{
			NinjaLiveFunctions_C.StaticClass();
			NinjaLiveFunctions_C.__CameraFacing_FunctionParams* ptr = stackalloc NinjaLiveFunctions_C.__CameraFacing_FunctionParams[(UIntPtr)407] + 15L / (long)sizeof(NinjaLiveFunctions_C.__CameraFacing_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveFunctions_C.__CameraFacing_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InMesh = ((InMesh != null) ? InMesh.NativePtr : IntPtr.Zero);
			ptr->UseLegacyFacing = UseLegacyFacing;
			ptr->LockY = LockY;
			ptr->TraceMeshInitRot = TraceMeshInitRot;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(NinjaLiveFunctions_C._ClassDefaultObjectPtr, NinjaLiveFunctions_C.__CameraFacing_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025A60 RID: 154208 RVA: 0x009BFD84 File Offset: 0x009BDF84
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void RenderTgAcquisitionStatus(UObject SelfRef, int RT_number___added, SimPrecision_Enum SimPrecision, int ResX, int ResY, bool PoolManDetected, bool HalfRes, int NumberOfChannels, UObject __WorldContext, [Nullable(1)] ref string Print, ref float MemConsumtion)
		{
			NinjaLiveFunctions_C.StaticClass();
			NinjaLiveFunctions_C.__RenderTgAcquisitionStatus_FunctionParams* ptr = stackalloc NinjaLiveFunctions_C.__RenderTgAcquisitionStatus_FunctionParams[(UIntPtr)575] + 15L / (long)sizeof(NinjaLiveFunctions_C.__RenderTgAcquisitionStatus_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveFunctions_C.__RenderTgAcquisitionStatus_NativeFunctionPtr, (void*)ptr, 1);
			ptr->SelfRef = ((SelfRef != null) ? SelfRef.NativePtr : IntPtr.Zero);
			ptr->RT_number___added = RT_number___added;
			ptr->SimPrecision = SimPrecision;
			ptr->ResX = ResX;
			ptr->ResY = ResY;
			ptr->PoolManDetected = PoolManDetected;
			ptr->HalfRes = HalfRes;
			ptr->NumberOfChannels = NumberOfChannels;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			FString.CopyFrom((void*)(&ptr->Print), Print);
			ptr->MemConsumtion = MemConsumtion;
			UnrealReflectionUtils.CallVirtualUFunction(NinjaLiveFunctions_C._ClassDefaultObjectPtr, NinjaLiveFunctions_C.__RenderTgAcquisitionStatus_NativeFunctionPtr, (void*)ptr);
			Print = FString.ToString((void*)(&ptr->Print));
			MemConsumtion = ptr->MemConsumtion;
			UnrealReflectionUtils.DestroyStruct(NinjaLiveFunctions_C.__RenderTgAcquisitionStatus_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06025A61 RID: 154209 RVA: 0x009BFE74 File Offset: 0x009BE074
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void AcquireRenderTargetsFromPool(int Request_0isRGBA1isRG2isR, int Host_RenderTG_List_Index, [Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<string> RenderTargetList, UObject __WorldContext, [Nullable(new byte[]
		{
			2,
			1,
			1
		})] ref TMap<string, UTextureRenderTarget2D> RenderTargetsMapTmp)
		{
			NinjaLiveFunctions_C.StaticClass();
			NinjaLiveFunctions_C.__AcquireRenderTargetsFromPool_FunctionParams* ptr = stackalloc NinjaLiveFunctions_C.__AcquireRenderTargetsFromPool_FunctionParams[(UIntPtr)327] + 15L / (long)sizeof(NinjaLiveFunctions_C.__AcquireRenderTargetsFromPool_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveFunctions_C.__AcquireRenderTargetsFromPool_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Request_0isRGBA1isRG2isR = Request_0isRGBA1isRG2isR;
			ptr->Host_RenderTG_List_Index = Host_RenderTG_List_Index;
			TArray<string> tarray = RenderTargetList;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->RenderTargetList);
			}
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			TMap<string, UTextureRenderTarget2D> tmap = RenderTargetsMapTmp;
			if (tmap != null)
			{
				tmap.MoveTo(&ptr->RenderTargetsMapTmp);
			}
			UnrealReflectionUtils.CallVirtualUFunction(NinjaLiveFunctions_C._ClassDefaultObjectPtr, NinjaLiveFunctions_C.__AcquireRenderTargetsFromPool_NativeFunctionPtr, (void*)ptr);
			TArray<string> tarray2 = RenderTargetList;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->RenderTargetList);
			}
			TMap<string, UTextureRenderTarget2D> tmap2 = RenderTargetsMapTmp;
			if (tmap2 != null)
			{
				tmap2.MoveAssign(&ptr->RenderTargetsMapTmp);
			}
			UnrealReflectionUtils.DestroyStruct(NinjaLiveFunctions_C.__AcquireRenderTargetsFromPool_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06025A62 RID: 154210 RVA: 0x009BFF44 File Offset: 0x009BE144
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void TemplateLoader(FName TemplateDefinition, [Nullable(2)] UDataTable LoadedDataTable, string LoadedDatatablePath, [Nullable(2)] UObject __WorldContext, ref bool LoadFailed, [Nullable(2)] ref UObject LoadedTemplateObject, ref string LoadedTmpFullPath, ref string LoadedTemplateNameOnly, ref bool UsesAbsolutePath)
		{
			NinjaLiveFunctions_C.StaticClass();
			NinjaLiveFunctions_C.__TemplateLoader_FunctionParams* ptr = stackalloc NinjaLiveFunctions_C.__TemplateLoader_FunctionParams[(UIntPtr)831] + 15L / (long)sizeof(NinjaLiveFunctions_C.__TemplateLoader_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveFunctions_C.__TemplateLoader_NativeFunctionPtr, (void*)ptr, 1);
			ptr->TemplateDefinition = TemplateDefinition;
			ptr->LoadedDataTable = ((LoadedDataTable != null) ? LoadedDataTable.NativePtr : IntPtr.Zero);
			FString.CopyFrom((void*)(&ptr->LoadedDatatablePath), LoadedDatatablePath);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->LoadFailed = LoadFailed;
			ref NinjaLiveFunctions_C.__TemplateLoader_FunctionParams ptr2 = ref *ptr;
			UObject uobject = LoadedTemplateObject;
			ptr2.LoadedTemplateObject = ((uobject != null) ? uobject.NativePtr : IntPtr.Zero);
			FString.CopyFrom((void*)(&ptr->LoadedTmpFullPath), LoadedTmpFullPath);
			FString.CopyFrom((void*)(&ptr->LoadedTemplateNameOnly), LoadedTemplateNameOnly);
			ptr->UsesAbsolutePath = UsesAbsolutePath;
			UnrealReflectionUtils.CallVirtualUFunction(NinjaLiveFunctions_C._ClassDefaultObjectPtr, NinjaLiveFunctions_C.__TemplateLoader_NativeFunctionPtr, (void*)ptr);
			LoadFailed = ptr->LoadFailed;
			LoadedTemplateObject = BuiltinUtils.GetOrCreateUObjectByNativePointer<UObject>(ptr->LoadedTemplateObject);
			LoadedTmpFullPath = FString.ToString((void*)(&ptr->LoadedTmpFullPath));
			LoadedTemplateNameOnly = FString.ToString((void*)(&ptr->LoadedTemplateNameOnly));
			UsesAbsolutePath = ptr->UsesAbsolutePath;
			UnrealReflectionUtils.DestroyStruct(NinjaLiveFunctions_C.__TemplateLoader_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06025A63 RID: 154211 RVA: 0x009C0064 File Offset: 0x009BE264
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void SingleKeyPicker([Nullable(2)] UDataTable DataTableIn, string KeyToPick, [Nullable(2)] UObject __WorldContext, ref string PickedKeyValue, ref bool NotFound)
		{
			NinjaLiveFunctions_C.StaticClass();
			NinjaLiveFunctions_C.__SingleKeyPicker_FunctionParams* ptr = stackalloc NinjaLiveFunctions_C.__SingleKeyPicker_FunctionParams[(UIntPtr)143] + 15L / (long)sizeof(NinjaLiveFunctions_C.__SingleKeyPicker_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveFunctions_C.__SingleKeyPicker_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DataTableIn = ((DataTableIn != null) ? DataTableIn.NativePtr : IntPtr.Zero);
			FString.CopyFrom((void*)(&ptr->KeyToPick), KeyToPick);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			FString.CopyFrom((void*)(&ptr->PickedKeyValue), PickedKeyValue);
			ptr->NotFound = NotFound;
			UnrealReflectionUtils.CallVirtualUFunction(NinjaLiveFunctions_C._ClassDefaultObjectPtr, NinjaLiveFunctions_C.__SingleKeyPicker_NativeFunctionPtr, (void*)ptr);
			PickedKeyValue = FString.ToString((void*)(&ptr->PickedKeyValue));
			NotFound = ptr->NotFound;
			UnrealReflectionUtils.DestroyStruct(NinjaLiveFunctions_C.__SingleKeyPicker_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06025A64 RID: 154212 RVA: 0x009C0124 File Offset: 0x009BE324
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void CreateRenderTarget(int Width, int Height, ETextureRenderTargetFormat Format, bool Clamping, TextureGroup LODgroup, TextureFilter Filter, UObject __WorldContext, ref UTextureRenderTarget2D RTout)
		{
			NinjaLiveFunctions_C.StaticClass();
			NinjaLiveFunctions_C.__CreateRenderTarget_FunctionParams* ptr = stackalloc NinjaLiveFunctions_C.__CreateRenderTarget_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(NinjaLiveFunctions_C.__CreateRenderTarget_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveFunctions_C.__CreateRenderTarget_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Width = Width;
			ptr->Height = Height;
			ptr->Format = Format;
			ptr->Clamping = Clamping;
			ptr->LODgroup = LODgroup;
			ptr->Filter = Filter;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ref NinjaLiveFunctions_C.__CreateRenderTarget_FunctionParams ptr2 = ref *ptr;
			UTextureRenderTarget2D utextureRenderTarget2D = RTout;
			ptr2.RTout = ((utextureRenderTarget2D != null) ? utextureRenderTarget2D.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(NinjaLiveFunctions_C._ClassDefaultObjectPtr, NinjaLiveFunctions_C.__CreateRenderTarget_NativeFunctionPtr, (void*)ptr);
			RTout = BuiltinUtils.GetOrCreateUObjectByNativePointer<UTextureRenderTarget2D>(ptr->RTout);
		}

		// Token: 0x06025A65 RID: 154213 RVA: 0x009C01E4 File Offset: 0x009BE3E4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void PresetLoader([Nullable(1)] string PresetName, ref TArray<FName> AssetPath, FName AssetTrimmedName, bool ForcePreferredPreset, UDataTable PreferredPreset, UObject __WorldContext, ref UDataTable LoadedDataTable, [Nullable(1)] ref string LoadedDataTablePath, [Nullable(new byte[]
		{
			2,
			1
		})] ref TMap<string, float> PresetMap)
		{
			NinjaLiveFunctions_C.StaticClass();
			NinjaLiveFunctions_C.__PresetLoader_FunctionParams* ptr = stackalloc NinjaLiveFunctions_C.__PresetLoader_FunctionParams[(UIntPtr)1415] + 15L / (long)sizeof(NinjaLiveFunctions_C.__PresetLoader_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveFunctions_C.__PresetLoader_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->PresetName), PresetName);
			TArray<FName> tarray = AssetPath;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->AssetPath);
			}
			ptr->AssetTrimmedName = AssetTrimmedName;
			ptr->ForcePreferredPreset = ForcePreferredPreset;
			ptr->PreferredPreset = ((PreferredPreset != null) ? PreferredPreset.NativePtr : IntPtr.Zero);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ref NinjaLiveFunctions_C.__PresetLoader_FunctionParams ptr2 = ref *ptr;
			UDataTable udataTable = LoadedDataTable;
			ptr2.LoadedDataTable = ((udataTable != null) ? udataTable.NativePtr : IntPtr.Zero);
			FString.CopyFrom((void*)(&ptr->LoadedDataTablePath), LoadedDataTablePath);
			TMap<string, float> tmap = PresetMap;
			if (tmap != null)
			{
				tmap.MoveTo(&ptr->PresetMap);
			}
			UnrealReflectionUtils.CallVirtualUFunction(NinjaLiveFunctions_C._ClassDefaultObjectPtr, NinjaLiveFunctions_C.__PresetLoader_NativeFunctionPtr, (void*)ptr);
			TArray<FName> tarray2 = AssetPath;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->AssetPath);
			}
			LoadedDataTable = BuiltinUtils.GetOrCreateUObjectByNativePointer<UDataTable>(ptr->LoadedDataTable);
			LoadedDataTablePath = FString.ToString((void*)(&ptr->LoadedDataTablePath));
			TMap<string, float> tmap2 = PresetMap;
			if (tmap2 != null)
			{
				tmap2.MoveAssign(&ptr->PresetMap);
			}
			UnrealReflectionUtils.DestroyStruct(NinjaLiveFunctions_C.__PresetLoader_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06025A66 RID: 154214 RVA: 0x009C0320 File Offset: 0x009BE520
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void TraceOverlap(FVector Start, FVector End, float TracelineOvershoot, ETraceTypeQuery TraceChannel, [Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<AActor> FluidNinjaLIVEActors, UObject __WorldContext, ref FLinearColor HitUV, ref FVector TracePosition)
		{
			NinjaLiveFunctions_C.StaticClass();
			NinjaLiveFunctions_C.__TraceOverlap_FunctionParams* ptr = stackalloc NinjaLiveFunctions_C.__TraceOverlap_FunctionParams[(UIntPtr)503] + 15L / (long)sizeof(NinjaLiveFunctions_C.__TraceOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveFunctions_C.__TraceOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Start = Start;
			ptr->End = End;
			ptr->TracelineOvershoot = TracelineOvershoot;
			ptr->TraceChannel = TraceChannel;
			TArray<AActor> tarray = FluidNinjaLIVEActors;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->FluidNinjaLIVEActors);
			}
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->HitUV = HitUV;
			ptr->TracePosition = TracePosition;
			UnrealReflectionUtils.CallVirtualUFunction(NinjaLiveFunctions_C._ClassDefaultObjectPtr, NinjaLiveFunctions_C.__TraceOverlap_NativeFunctionPtr, (void*)ptr);
			TArray<AActor> tarray2 = FluidNinjaLIVEActors;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->FluidNinjaLIVEActors);
			}
			HitUV = ptr->HitUV;
			TracePosition = ptr->TracePosition;
			UnrealReflectionUtils.DestroyStruct(NinjaLiveFunctions_C.__TraceOverlap_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06025A67 RID: 154215 RVA: 0x009C0410 File Offset: 0x009BE610
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void TraceMouse(UObject HitComponent, bool TouchSensitive, byte FingerIndex, ETraceTypeQuery TraceChannel, [Nullable(new byte[]
		{
			2,
			1
		})] in TArray<AActor> FluidNinjaLIVEActors, UObject __WorldContext, ref FLinearColor HitUV, ref bool SimHitByMouse, ref bool MouseClickValid, ref bool TouchValid)
		{
			NinjaLiveFunctions_C.StaticClass();
			NinjaLiveFunctions_C.__TraceMouse_FunctionParams* ptr = stackalloc NinjaLiveFunctions_C.__TraceMouse_FunctionParams[(UIntPtr)1103] + 15L / (long)sizeof(NinjaLiveFunctions_C.__TraceMouse_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveFunctions_C.__TraceMouse_NativeFunctionPtr, (void*)ptr, 1);
			ptr->HitComponent = ((HitComponent != null) ? HitComponent.NativePtr : IntPtr.Zero);
			ptr->TouchSensitive = TouchSensitive;
			ptr->FingerIndex = FingerIndex;
			ptr->TraceChannel = TraceChannel;
			TArray<AActor> tarray = FluidNinjaLIVEActors;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->FluidNinjaLIVEActors);
			}
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->HitUV = HitUV;
			ptr->SimHitByMouse = SimHitByMouse;
			ptr->MouseClickValid = MouseClickValid;
			ptr->TouchValid = TouchValid;
			UnrealReflectionUtils.CallVirtualUFunction(NinjaLiveFunctions_C._ClassDefaultObjectPtr, NinjaLiveFunctions_C.__TraceMouse_NativeFunctionPtr, (void*)ptr);
			TArray<AActor> tarray2 = FluidNinjaLIVEActors;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->FluidNinjaLIVEActors);
			}
			HitUV = ptr->HitUV;
			SimHitByMouse = ptr->SimHitByMouse;
			MouseClickValid = ptr->MouseClickValid;
			TouchValid = ptr->TouchValid;
			UnrealReflectionUtils.DestroyStruct(NinjaLiveFunctions_C.__TraceMouse_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06025A68 RID: 154216 RVA: 0x009C052A File Offset: 0x009BE72A
		protected NinjaLiveFunctions_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040136CE RID: 79566
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/NinjaLiveFunctions.NinjaLiveFunctions_C";

		// Token: 0x040136CF RID: 79567
		private static IntPtr _ClassPtr;

		// Token: 0x040136D0 RID: 79568
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040136D1 RID: 79569
		private static IntPtr __TraceOverlapSingle_NativeFunctionPtr;

		// Token: 0x040136D2 RID: 79570
		private static IntPtr __CameraFacing_NativeFunctionPtr;

		// Token: 0x040136D3 RID: 79571
		private static IntPtr __RenderTgAcquisitionStatus_NativeFunctionPtr;

		// Token: 0x040136D4 RID: 79572
		private static IntPtr __AcquireRenderTargetsFromPool_NativeFunctionPtr;

		// Token: 0x040136D5 RID: 79573
		private static IntPtr __TemplateLoader_NativeFunctionPtr;

		// Token: 0x040136D6 RID: 79574
		private static IntPtr __SingleKeyPicker_NativeFunctionPtr;

		// Token: 0x040136D7 RID: 79575
		private static IntPtr __CreateRenderTarget_NativeFunctionPtr;

		// Token: 0x040136D8 RID: 79576
		private static IntPtr __PresetLoader_NativeFunctionPtr;

		// Token: 0x040136D9 RID: 79577
		private static IntPtr __TraceOverlap_NativeFunctionPtr;

		// Token: 0x040136DA RID: 79578
		private static IntPtr __TraceMouse_NativeFunctionPtr;

		// Token: 0x02009F3F RID: 40767
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 544)]
		protected ref struct __TraceOverlapSingle_FunctionParams
		{
			// Token: 0x04032A70 RID: 207472
			[FieldOffset(0)]
			public FVector Start;

			// Token: 0x04032A71 RID: 207473
			[FieldOffset(12)]
			public FVector End;

			// Token: 0x04032A72 RID: 207474
			[FieldOffset(24)]
			public float TracelineOvershoot;

			// Token: 0x04032A73 RID: 207475
			[FieldOffset(32)]
			public IntPtr TraceMesh;

			// Token: 0x04032A74 RID: 207476
			[FieldOffset(40)]
			public IntPtr __WorldContext;

			// Token: 0x04032A75 RID: 207477
			[FieldOffset(48)]
			public FLinearColor HitUV;

			// Token: 0x04032A76 RID: 207478
			[FieldOffset(64)]
			public FVector TracePosition;
		}

		// Token: 0x02009F40 RID: 40768
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 392)]
		protected ref struct __CameraFacing_FunctionParams
		{
			// Token: 0x04032A77 RID: 207479
			[FieldOffset(0)]
			public IntPtr InMesh;

			// Token: 0x04032A78 RID: 207480
			[FieldOffset(8)]
			public bool UseLegacyFacing;

			// Token: 0x04032A79 RID: 207481
			[FieldOffset(9)]
			public bool LockY;

			// Token: 0x04032A7A RID: 207482
			[FieldOffset(12)]
			public FRotator TraceMeshInitRot;

			// Token: 0x04032A7B RID: 207483
			[FieldOffset(24)]
			public IntPtr __WorldContext;
		}

		// Token: 0x02009F41 RID: 40769
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 560)]
		protected ref struct __RenderTgAcquisitionStatus_FunctionParams
		{
			// Token: 0x04032A7C RID: 207484
			[FieldOffset(0)]
			public IntPtr SelfRef;

			// Token: 0x04032A7D RID: 207485
			[FieldOffset(8)]
			public int RT_number___added;

			// Token: 0x04032A7E RID: 207486
			[FieldOffset(12)]
			public TEnumAsByte<SimPrecision_Enum> SimPrecision;

			// Token: 0x04032A7F RID: 207487
			[FieldOffset(16)]
			public int ResX;

			// Token: 0x04032A80 RID: 207488
			[FieldOffset(20)]
			public int ResY;

			// Token: 0x04032A81 RID: 207489
			[FieldOffset(24)]
			public bool PoolManDetected;

			// Token: 0x04032A82 RID: 207490
			[FieldOffset(25)]
			public bool HalfRes;

			// Token: 0x04032A83 RID: 207491
			[FieldOffset(28)]
			public int NumberOfChannels;

			// Token: 0x04032A84 RID: 207492
			[FieldOffset(32)]
			public IntPtr __WorldContext;

			// Token: 0x04032A85 RID: 207493
			[FieldOffset(40)]
			public FString Print;

			// Token: 0x04032A86 RID: 207494
			[FieldOffset(56)]
			public float MemConsumtion;
		}

		// Token: 0x02009F42 RID: 40770
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 312)]
		protected ref struct __AcquireRenderTargetsFromPool_FunctionParams
		{
			// Token: 0x04032A87 RID: 207495
			[FieldOffset(0)]
			public int Request_0isRGBA1isRG2isR;

			// Token: 0x04032A88 RID: 207496
			[FieldOffset(4)]
			public int Host_RenderTG_List_Index;

			// Token: 0x04032A89 RID: 207497
			[FieldOffset(8)]
			public byte RenderTargetList;

			// Token: 0x04032A8A RID: 207498
			[FieldOffset(24)]
			public IntPtr __WorldContext;

			// Token: 0x04032A8B RID: 207499
			[FieldOffset(32)]
			public byte RenderTargetsMapTmp;
		}

		// Token: 0x02009F43 RID: 40771
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 816)]
		protected ref struct __TemplateLoader_FunctionParams
		{
			// Token: 0x04032A8C RID: 207500
			[FieldOffset(0)]
			public FName TemplateDefinition;

			// Token: 0x04032A8D RID: 207501
			[FieldOffset(16)]
			public IntPtr LoadedDataTable;

			// Token: 0x04032A8E RID: 207502
			[FieldOffset(24)]
			public FString LoadedDatatablePath;

			// Token: 0x04032A8F RID: 207503
			[FieldOffset(40)]
			public IntPtr __WorldContext;

			// Token: 0x04032A90 RID: 207504
			[FieldOffset(48)]
			public bool LoadFailed;

			// Token: 0x04032A91 RID: 207505
			[FieldOffset(56)]
			public IntPtr LoadedTemplateObject;

			// Token: 0x04032A92 RID: 207506
			[FieldOffset(64)]
			public FString LoadedTmpFullPath;

			// Token: 0x04032A93 RID: 207507
			[FieldOffset(80)]
			public FString LoadedTemplateNameOnly;

			// Token: 0x04032A94 RID: 207508
			[FieldOffset(96)]
			public bool UsesAbsolutePath;
		}

		// Token: 0x02009F44 RID: 40772
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 128)]
		protected ref struct __SingleKeyPicker_FunctionParams
		{
			// Token: 0x04032A95 RID: 207509
			[FieldOffset(0)]
			public IntPtr DataTableIn;

			// Token: 0x04032A96 RID: 207510
			[FieldOffset(8)]
			public FString KeyToPick;

			// Token: 0x04032A97 RID: 207511
			[FieldOffset(24)]
			public IntPtr __WorldContext;

			// Token: 0x04032A98 RID: 207512
			[FieldOffset(32)]
			public FString PickedKeyValue;

			// Token: 0x04032A99 RID: 207513
			[FieldOffset(48)]
			public bool NotFound;
		}

		// Token: 0x02009F45 RID: 40773
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __CreateRenderTarget_FunctionParams
		{
			// Token: 0x04032A9A RID: 207514
			[FieldOffset(0)]
			public int Width;

			// Token: 0x04032A9B RID: 207515
			[FieldOffset(4)]
			public int Height;

			// Token: 0x04032A9C RID: 207516
			[FieldOffset(8)]
			public TEnumAsByte<ETextureRenderTargetFormat> Format;

			// Token: 0x04032A9D RID: 207517
			[FieldOffset(9)]
			public bool Clamping;

			// Token: 0x04032A9E RID: 207518
			[FieldOffset(10)]
			public TEnumAsByte<TextureGroup> LODgroup;

			// Token: 0x04032A9F RID: 207519
			[FieldOffset(11)]
			public TEnumAsByte<TextureFilter> Filter;

			// Token: 0x04032AA0 RID: 207520
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04032AA1 RID: 207521
			[FieldOffset(24)]
			public IntPtr RTout;
		}

		// Token: 0x02009F46 RID: 40774
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1400)]
		protected ref struct __PresetLoader_FunctionParams
		{
			// Token: 0x04032AA2 RID: 207522
			[FieldOffset(0)]
			public FString PresetName;

			// Token: 0x04032AA3 RID: 207523
			[FieldOffset(16)]
			public byte AssetPath;

			// Token: 0x04032AA4 RID: 207524
			[FieldOffset(32)]
			public FName AssetTrimmedName;

			// Token: 0x04032AA5 RID: 207525
			[FieldOffset(44)]
			public bool ForcePreferredPreset;

			// Token: 0x04032AA6 RID: 207526
			[FieldOffset(48)]
			public IntPtr PreferredPreset;

			// Token: 0x04032AA7 RID: 207527
			[FieldOffset(56)]
			public IntPtr __WorldContext;

			// Token: 0x04032AA8 RID: 207528
			[FieldOffset(64)]
			public IntPtr LoadedDataTable;

			// Token: 0x04032AA9 RID: 207529
			[FieldOffset(72)]
			public FString LoadedDataTablePath;

			// Token: 0x04032AAA RID: 207530
			[FieldOffset(88)]
			public byte PresetMap;
		}

		// Token: 0x02009F47 RID: 40775
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 488)]
		protected ref struct __TraceOverlap_FunctionParams
		{
			// Token: 0x04032AAB RID: 207531
			[FieldOffset(0)]
			public FVector Start;

			// Token: 0x04032AAC RID: 207532
			[FieldOffset(12)]
			public FVector End;

			// Token: 0x04032AAD RID: 207533
			[FieldOffset(24)]
			public float TracelineOvershoot;

			// Token: 0x04032AAE RID: 207534
			[FieldOffset(28)]
			public TEnumAsByte<ETraceTypeQuery> TraceChannel;

			// Token: 0x04032AAF RID: 207535
			[FieldOffset(32)]
			public byte FluidNinjaLIVEActors;

			// Token: 0x04032AB0 RID: 207536
			[FieldOffset(48)]
			public IntPtr __WorldContext;

			// Token: 0x04032AB1 RID: 207537
			[FieldOffset(56)]
			public FLinearColor HitUV;

			// Token: 0x04032AB2 RID: 207538
			[FieldOffset(72)]
			public FVector TracePosition;
		}

		// Token: 0x02009F48 RID: 40776
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1088)]
		protected ref struct __TraceMouse_FunctionParams
		{
			// Token: 0x04032AB3 RID: 207539
			[FieldOffset(0)]
			public IntPtr HitComponent;

			// Token: 0x04032AB4 RID: 207540
			[FieldOffset(8)]
			public bool TouchSensitive;

			// Token: 0x04032AB5 RID: 207541
			[FieldOffset(9)]
			public byte FingerIndex;

			// Token: 0x04032AB6 RID: 207542
			[FieldOffset(10)]
			public TEnumAsByte<ETraceTypeQuery> TraceChannel;

			// Token: 0x04032AB7 RID: 207543
			[FieldOffset(16)]
			public byte FluidNinjaLIVEActors;

			// Token: 0x04032AB8 RID: 207544
			[FieldOffset(32)]
			public IntPtr __WorldContext;

			// Token: 0x04032AB9 RID: 207545
			[FieldOffset(40)]
			public FLinearColor HitUV;

			// Token: 0x04032ABA RID: 207546
			[FieldOffset(56)]
			public bool SimHitByMouse;

			// Token: 0x04032ABB RID: 207547
			[FieldOffset(57)]
			public bool MouseClickValid;

			// Token: 0x04032ABC RID: 207548
			[FieldOffset(58)]
			public bool TouchValid;
		}
	}
}
