using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.HexGridBreaking
{
	// Token: 0x02003C0F RID: 15375
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/HexGridBreaking/BP_FloorBreakInteraction.BP_FloorBreakInteraction_C")]
	[UnrealStructLayout(1664, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1657)]
	public class BP_FloorBreakInteraction_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022F20 RID: 143136 RVA: 0x00973CC3 File Offset: 0x00971EC3
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FloorBreakInteraction_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/HexGridBreaking/BP_FloorBreakInteraction.BP_FloorBreakInteraction_C");
			}
			return BP_FloorBreakInteraction_C._ClassPtr;
		}

		// Token: 0x06022F21 RID: 143137 RVA: 0x00973CE8 File Offset: 0x00971EE8
		public BP_FloorBreakInteraction_C() : this(BuiltinUtils.AllocNativeUObject(BP_FloorBreakInteraction_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022F22 RID: 143138 RVA: 0x00973D10 File Offset: 0x00971F10
		[NullableContext(1)]
		public BP_FloorBreakInteraction_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FloorBreakInteraction_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004396 RID: 17302
		// (get) Token: 0x06022F23 RID: 143139 RVA: 0x00973D44 File Offset: 0x00971F44
		// (set) Token: 0x06022F24 RID: 143140 RVA: 0x00973D7D File Offset: 0x00971F7D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_FloorBreakInteraction_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_FloorBreakInteraction_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004397 RID: 17303
		// (get) Token: 0x06022F25 RID: 143141 RVA: 0x00973D9E File Offset: 0x00971F9E
		// (set) Token: 0x06022F26 RID: 143142 RVA: 0x00973DB2 File Offset: 0x00971FB2
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloorBreakInteraction_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloorBreakInteraction_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004398 RID: 17304
		// (get) Token: 0x06022F27 RID: 143143 RVA: 0x00973DC7 File Offset: 0x00971FC7
		// (set) Token: 0x06022F28 RID: 143144 RVA: 0x00973DDB File Offset: 0x00971FDB
		public unsafe UInstancedStaticMeshComponent InstancedStaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UInstancedStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloorBreakInteraction_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloorBreakInteraction_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004399 RID: 17305
		// (get) Token: 0x06022F29 RID: 143145 RVA: 0x00973DF0 File Offset: 0x00971FF0
		// (set) Token: 0x06022F2A RID: 143146 RVA: 0x00973E04 File Offset: 0x00972004
		public unsafe UStaticMeshComponent StaticMeshComponent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloorBreakInteraction_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloorBreakInteraction_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700439A RID: 17306
		// (get) Token: 0x06022F2B RID: 143147 RVA: 0x00973E19 File Offset: 0x00972019
		// (set) Token: 0x06022F2C RID: 143148 RVA: 0x00973E2D File Offset: 0x0097202D
		public unsafe USceneComponent Scene
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloorBreakInteraction_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloorBreakInteraction_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700439B RID: 17307
		// (get) Token: 0x06022F2D RID: 143149 RVA: 0x00973E44 File Offset: 0x00972044
		// (set) Token: 0x06022F2E RID: 143150 RVA: 0x00973E7D File Offset: 0x0097207D
		[Nullable(1)]
		public TMap<string, int> InstanceIndex
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<string, int> result;
				if ((result = this._InstanceIndex) == null)
				{
					result = (this._InstanceIndex = new TMap<string, int>(base.NativePtr + (IntPtr)BP_FloorBreakInteraction_C.__PropertyOffset_5, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.InstanceIndex.CopyAssign(value);
			}
		}

		// Token: 0x1700439C RID: 17308
		// (get) Token: 0x06022F2F RID: 143151 RVA: 0x00973E8B File Offset: 0x0097208B
		// (set) Token: 0x06022F30 RID: 143152 RVA: 0x00973E9F File Offset: 0x0097209F
		public unsafe FVectorDouble OriginPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloorBreakInteraction_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloorBreakInteraction_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700439D RID: 17309
		// (get) Token: 0x06022F31 RID: 143153 RVA: 0x00973EB4 File Offset: 0x009720B4
		// (set) Token: 0x06022F32 RID: 143154 RVA: 0x00973EC4 File Offset: 0x009720C4
		public unsafe int Index
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloorBreakInteraction_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloorBreakInteraction_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700439E RID: 17310
		// (get) Token: 0x06022F33 RID: 143155 RVA: 0x00973ED8 File Offset: 0x009720D8
		// (set) Token: 0x06022F34 RID: 143156 RVA: 0x00973F11 File Offset: 0x00972111
		[Nullable(1)]
		public TArray<FVector> DirectoryList
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._DirectoryList) == null)
				{
					result = (this._DirectoryList = new TArray<FVector>(base.NativePtr + (IntPtr)BP_FloorBreakInteraction_C.__PropertyOffset_8, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.DirectoryList.CopyAssign(value);
			}
		}

		// Token: 0x1700439F RID: 17311
		// (get) Token: 0x06022F35 RID: 143157 RVA: 0x00973F1F File Offset: 0x0097211F
		// (set) Token: 0x06022F36 RID: 143158 RVA: 0x00973F2F File Offset: 0x0097212F
		public unsafe bool IsMonster
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloorBreakInteraction_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloorBreakInteraction_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x170043A0 RID: 17312
		// (get) Token: 0x06022F37 RID: 143159 RVA: 0x00973F40 File Offset: 0x00972140
		// (set) Token: 0x06022F38 RID: 143160 RVA: 0x00973F54 File Offset: 0x00972154
		public unsafe FVectorDouble OffsetPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloorBreakInteraction_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloorBreakInteraction_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170043A1 RID: 17313
		// (get) Token: 0x06022F39 RID: 143161 RVA: 0x00973F6C File Offset: 0x0097216C
		// (set) Token: 0x06022F3A RID: 143162 RVA: 0x00973FA5 File Offset: 0x009721A5
		[Nullable(1)]
		public TMap<BP_RuntimeCellPieces_C, float> HitCellPieceActors
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<BP_RuntimeCellPieces_C, float> result;
				if ((result = this._HitCellPieceActors) == null)
				{
					result = (this._HitCellPieceActors = new TMap<BP_RuntimeCellPieces_C, float>(base.NativePtr + (IntPtr)BP_FloorBreakInteraction_C.__PropertyOffset_11, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.HitCellPieceActors.CopyAssign(value);
			}
		}

		// Token: 0x170043A2 RID: 17314
		// (get) Token: 0x06022F3B RID: 143163 RVA: 0x00973FB3 File Offset: 0x009721B3
		// (set) Token: 0x06022F3C RID: 143164 RVA: 0x00973FC3 File Offset: 0x009721C3
		public unsafe float In_Delta_Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloorBreakInteraction_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloorBreakInteraction_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170043A3 RID: 17315
		// (get) Token: 0x06022F3D RID: 143165 RVA: 0x00973FD4 File Offset: 0x009721D4
		// (set) Token: 0x06022F3E RID: 143166 RVA: 0x00973FE8 File Offset: 0x009721E8
		[Nullable(1)]
		public unsafe string ISMInfo
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_FloorBreakInteraction_C.__PropertyOffset_13)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_FloorBreakInteraction_C.__PropertyOffset_13)), value);
			}
		}

		// Token: 0x170043A4 RID: 17316
		// (get) Token: 0x06022F3F RID: 143167 RVA: 0x00973FFD File Offset: 0x009721FD
		// (set) Token: 0x06022F40 RID: 143168 RVA: 0x00974011 File Offset: 0x00972211
		public unsafe UInstancedStaticMeshComponent ISMComp
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UInstancedStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloorBreakInteraction_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloorBreakInteraction_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x170043A5 RID: 17317
		// (get) Token: 0x06022F41 RID: 143169 RVA: 0x00974026 File Offset: 0x00972226
		// (set) Token: 0x06022F42 RID: 143170 RVA: 0x00974036 File Offset: 0x00972236
		public unsafe bool IsDesktop
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloorBreakInteraction_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloorBreakInteraction_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x170043A6 RID: 17318
		// (get) Token: 0x06022F43 RID: 143171 RVA: 0x00974047 File Offset: 0x00972247
		// (set) Token: 0x06022F44 RID: 143172 RVA: 0x0097405B File Offset: 0x0097225B
		public unsafe UStaticMesh MobileAsset
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloorBreakInteraction_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloorBreakInteraction_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x170043A7 RID: 17319
		// (get) Token: 0x06022F45 RID: 143173 RVA: 0x00974070 File Offset: 0x00972270
		// (set) Token: 0x06022F46 RID: 143174 RVA: 0x00974084 File Offset: 0x00972284
		public unsafe UAkAudioEvent AudioAsset
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloorBreakInteraction_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloorBreakInteraction_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x170043A8 RID: 17320
		// (get) Token: 0x06022F47 RID: 143175 RVA: 0x00974099 File Offset: 0x00972299
		// (set) Token: 0x06022F48 RID: 143176 RVA: 0x009740A9 File Offset: 0x009722A9
		public unsafe bool Voice
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloorBreakInteraction_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloorBreakInteraction_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x06022F49 RID: 143177 RVA: 0x009740BA File Offset: 0x009722BA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ResetMask()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloorBreakInteraction_C.__ResetMask_NativeFunctionPtr, null);
		}

		// Token: 0x06022F4A RID: 143178 RVA: 0x009740CE File Offset: 0x009722CE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void GenerateISM()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloorBreakInteraction_C.__GenerateISM_NativeFunctionPtr, null);
		}

		// Token: 0x06022F4B RID: 143179 RVA: 0x009740E4 File Offset: 0x009722E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetOffsetPosition(int Index, float OffsetDistance, ref FVectorDouble OffsetPosition)
		{
			BP_FloorBreakInteraction_C.__GetOffsetPosition_FunctionParams* ptr = stackalloc BP_FloorBreakInteraction_C.__GetOffsetPosition_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_FloorBreakInteraction_C.__GetOffsetPosition_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FloorBreakInteraction_C.__GetOffsetPosition_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Index = Index;
			ptr->OffsetDistance = OffsetDistance;
			ptr->OffsetPosition = OffsetPosition;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloorBreakInteraction_C.__GetOffsetPosition_NativeFunctionPtr, (void*)ptr);
			OffsetPosition = ptr->OffsetPosition;
		}

		// Token: 0x06022F4C RID: 143180 RVA: 0x0097414C File Offset: 0x0097234C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Initialization()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloorBreakInteraction_C.__Initialization_NativeFunctionPtr, null);
		}

		// Token: 0x06022F4D RID: 143181 RVA: 0x00974160 File Offset: 0x00972360
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloorBreakInteraction_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06022F4E RID: 143182 RVA: 0x00974174 File Offset: 0x00972374
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FloorBreakInteraction_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022F4F RID: 143183 RVA: 0x00974189 File Offset: 0x00972389
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloorBreakInteraction_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06022F50 RID: 143184 RVA: 0x0097419D File Offset: 0x0097239D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FloorBreakInteraction_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022F51 RID: 143185 RVA: 0x009741B4 File Offset: 0x009723B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_FloorBreakInteraction_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_FloorBreakInteraction_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FloorBreakInteraction_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FloorBreakInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloorBreakInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022F52 RID: 143186 RVA: 0x009741FC File Offset: 0x009723FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_FloorBreakInteraction_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_FloorBreakInteraction_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FloorBreakInteraction_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FloorBreakInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FloorBreakInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022F53 RID: 143187 RVA: 0x00974244 File Offset: 0x00972444
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeaponInteraction(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_FloorBreakInteraction_C.__OnWeaponInteraction_FunctionParams* ptr = stackalloc BP_FloorBreakInteraction_C.__OnWeaponInteraction_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_FloorBreakInteraction_C.__OnWeaponInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FloorBreakInteraction_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloorBreakInteraction_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022F54 RID: 143188 RVA: 0x009742A8 File Offset: 0x009724A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_FloorBreakInteraction_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_FloorBreakInteraction_C.__BndEvt__BP_FloorBreakInteraction_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_FloorBreakInteraction_C.__BndEvt__BP_FloorBreakInteraction_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_FloorBreakInteraction_C.__BndEvt__BP_FloorBreakInteraction_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FloorBreakInteraction_C.__BndEvt__BP_FloorBreakInteraction_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloorBreakInteraction_C.__BndEvt__BP_FloorBreakInteraction_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022F55 RID: 143189 RVA: 0x00974364 File Offset: 0x00972564
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_FloorBreakInteraction_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_FloorBreakInteraction_C.__BndEvt__BP_FloorBreakInteraction_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_FloorBreakInteraction_C.__BndEvt__BP_FloorBreakInteraction_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_FloorBreakInteraction_C.__BndEvt__BP_FloorBreakInteraction_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FloorBreakInteraction_C.__BndEvt__BP_FloorBreakInteraction_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloorBreakInteraction_C.__BndEvt__BP_FloorBreakInteraction_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022F56 RID: 143190 RVA: 0x009743F0 File Offset: 0x009725F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_FloorBreakInteraction(int EntryPoint)
		{
			BP_FloorBreakInteraction_C.__ExecuteUbergraph_BP_FloorBreakInteraction_FunctionParams* ptr = stackalloc BP_FloorBreakInteraction_C.__ExecuteUbergraph_BP_FloorBreakInteraction_FunctionParams[(UIntPtr)1199] + 15L / (long)sizeof(BP_FloorBreakInteraction_C.__ExecuteUbergraph_BP_FloorBreakInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FloorBreakInteraction_C.__ExecuteUbergraph_BP_FloorBreakInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FloorBreakInteraction_C.__ExecuteUbergraph_BP_FloorBreakInteraction_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022F57 RID: 143191 RVA: 0x0097443A File Offset: 0x0097263A
		protected BP_FloorBreakInteraction_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011BF9 RID: 72697
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/HexGridBreaking/BP_FloorBreakInteraction.BP_FloorBreakInteraction_C";

		// Token: 0x04011BFA RID: 72698
		private static IntPtr _ClassPtr;

		// Token: 0x04011BFB RID: 72699
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011BFC RID: 72700
		internal static int __PropertyOffset_0;

		// Token: 0x04011BFD RID: 72701
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011BFE RID: 72702
		internal static int __PropertyOffset_1;

		// Token: 0x04011BFF RID: 72703
		internal static int __PropertyOffset_2;

		// Token: 0x04011C00 RID: 72704
		internal static int __PropertyOffset_3;

		// Token: 0x04011C01 RID: 72705
		internal static int __PropertyOffset_4;

		// Token: 0x04011C02 RID: 72706
		internal static int __PropertyOffset_5;

		// Token: 0x04011C03 RID: 72707
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<string, int> _InstanceIndex;

		// Token: 0x04011C04 RID: 72708
		internal static int __PropertyOffset_6;

		// Token: 0x04011C05 RID: 72709
		internal static int __PropertyOffset_7;

		// Token: 0x04011C06 RID: 72710
		internal static int __PropertyOffset_8;

		// Token: 0x04011C07 RID: 72711
		private TArray<FVector> _DirectoryList;

		// Token: 0x04011C08 RID: 72712
		internal static int __PropertyOffset_9;

		// Token: 0x04011C09 RID: 72713
		internal static int __PropertyOffset_10;

		// Token: 0x04011C0A RID: 72714
		internal static int __PropertyOffset_11;

		// Token: 0x04011C0B RID: 72715
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<BP_RuntimeCellPieces_C, float> _HitCellPieceActors;

		// Token: 0x04011C0C RID: 72716
		internal static int __PropertyOffset_12;

		// Token: 0x04011C0D RID: 72717
		internal static int __PropertyOffset_13;

		// Token: 0x04011C0E RID: 72718
		internal static int __PropertyOffset_14;

		// Token: 0x04011C0F RID: 72719
		internal static int __PropertyOffset_15;

		// Token: 0x04011C10 RID: 72720
		internal static int __PropertyOffset_16;

		// Token: 0x04011C11 RID: 72721
		internal static int __PropertyOffset_17;

		// Token: 0x04011C12 RID: 72722
		internal static int __PropertyOffset_18;

		// Token: 0x04011C13 RID: 72723
		private static IntPtr __ResetMask_NativeFunctionPtr;

		// Token: 0x04011C14 RID: 72724
		private static IntPtr __GenerateISM_NativeFunctionPtr;

		// Token: 0x04011C15 RID: 72725
		private static IntPtr __GetOffsetPosition_NativeFunctionPtr;

		// Token: 0x04011C16 RID: 72726
		private static IntPtr __Initialization_NativeFunctionPtr;

		// Token: 0x04011C17 RID: 72727
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011C18 RID: 72728
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011C19 RID: 72729
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011C1A RID: 72730
		private static IntPtr __OnWeaponInteraction_NativeFunctionPtr;

		// Token: 0x04011C1B RID: 72731
		private static IntPtr __BndEvt__BP_FloorBreakInteraction_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011C1C RID: 72732
		private static IntPtr __BndEvt__BP_FloorBreakInteraction_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011C1D RID: 72733
		private static IntPtr __ExecuteUbergraph_BP_FloorBreakInteraction_NativeFunctionPtr;

		// Token: 0x02009C58 RID: 40024
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __GetOffsetPosition_FunctionParams
		{
			// Token: 0x04032519 RID: 206105
			[FieldOffset(0)]
			public int Index;

			// Token: 0x0403251A RID: 206106
			[FieldOffset(4)]
			public float OffsetDistance;

			// Token: 0x0403251B RID: 206107
			[FieldOffset(8)]
			public FVectorDouble OffsetPosition;
		}

		// Token: 0x02009C59 RID: 40025
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403251C RID: 206108
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C5A RID: 40026
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeaponInteraction_FunctionParams
		{
			// Token: 0x0403251D RID: 206109
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x0403251E RID: 206110
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x0403251F RID: 206111
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x02009C5B RID: 40027
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_FloorBreakInteraction_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032520 RID: 206112
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032521 RID: 206113
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032522 RID: 206114
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032523 RID: 206115
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x04032524 RID: 206116
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x04032525 RID: 206117
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009C5C RID: 40028
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_FloorBreakInteraction_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032526 RID: 206118
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032527 RID: 206119
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032528 RID: 206120
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032529 RID: 206121
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009C5D RID: 40029
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1184)]
		protected ref struct __ExecuteUbergraph_BP_FloorBreakInteraction_FunctionParams
		{
			// Token: 0x0403252A RID: 206122
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
