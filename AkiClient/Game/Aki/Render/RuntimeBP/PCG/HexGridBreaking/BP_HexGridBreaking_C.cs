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
	// Token: 0x02003C10 RID: 15376
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/HexGridBreaking/BP_HexGridBreaking.BP_HexGridBreaking_C")]
	[UnrealStructLayout(1696, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1689)]
	public class BP_HexGridBreaking_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022F58 RID: 143192 RVA: 0x00974443 File Offset: 0x00972643
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_HexGridBreaking_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/HexGridBreaking/BP_HexGridBreaking.BP_HexGridBreaking_C");
			}
			return BP_HexGridBreaking_C._ClassPtr;
		}

		// Token: 0x06022F59 RID: 143193 RVA: 0x00974468 File Offset: 0x00972668
		public BP_HexGridBreaking_C() : this(BuiltinUtils.AllocNativeUObject(BP_HexGridBreaking_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022F5A RID: 143194 RVA: 0x00974490 File Offset: 0x00972690
		public BP_HexGridBreaking_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_HexGridBreaking_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170043A9 RID: 17321
		// (get) Token: 0x06022F5B RID: 143195 RVA: 0x009744C4 File Offset: 0x009726C4
		// (set) Token: 0x06022F5C RID: 143196 RVA: 0x009744FD File Offset: 0x009726FD
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_HexGridBreaking_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_HexGridBreaking_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170043AA RID: 17322
		// (get) Token: 0x06022F5D RID: 143197 RVA: 0x0097451E File Offset: 0x0097271E
		// (set) Token: 0x06022F5E RID: 143198 RVA: 0x00974532 File Offset: 0x00972732
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_HexGridBreaking_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_HexGridBreaking_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170043AB RID: 17323
		// (get) Token: 0x06022F5F RID: 143199 RVA: 0x00974548 File Offset: 0x00972748
		// (set) Token: 0x06022F60 RID: 143200 RVA: 0x00974581 File Offset: 0x00972781
		public TMap<BP_RuntimeCellPieces_C, float> HitCellPieceActors
		{
			get
			{
				base.FastCheckIsValid();
				TMap<BP_RuntimeCellPieces_C, float> result;
				if ((result = this._HitCellPieceActors) == null)
				{
					result = (this._HitCellPieceActors = new TMap<BP_RuntimeCellPieces_C, float>(base.NativePtr + (IntPtr)BP_HexGridBreaking_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				this.HitCellPieceActors.CopyAssign(value);
			}
		}

		// Token: 0x170043AC RID: 17324
		// (get) Token: 0x06022F61 RID: 143201 RVA: 0x00974590 File Offset: 0x00972790
		// (set) Token: 0x06022F62 RID: 143202 RVA: 0x009745C9 File Offset: 0x009727C9
		public TMap<UStaticMesh, UStaticMesh> SMPiecesMap
		{
			get
			{
				base.FastCheckIsValid();
				TMap<UStaticMesh, UStaticMesh> result;
				if ((result = this._SMPiecesMap) == null)
				{
					result = (this._SMPiecesMap = new TMap<UStaticMesh, UStaticMesh>(base.NativePtr + (IntPtr)BP_HexGridBreaking_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				this.SMPiecesMap.CopyAssign(value);
			}
		}

		// Token: 0x170043AD RID: 17325
		// (get) Token: 0x06022F63 RID: 143203 RVA: 0x009745D7 File Offset: 0x009727D7
		// (set) Token: 0x06022F64 RID: 143204 RVA: 0x009745E7 File Offset: 0x009727E7
		public unsafe float In_Delta_Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HexGridBreaking_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HexGridBreaking_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170043AE RID: 17326
		// (get) Token: 0x06022F65 RID: 143205 RVA: 0x009745F8 File Offset: 0x009727F8
		// (set) Token: 0x06022F66 RID: 143206 RVA: 0x00974608 File Offset: 0x00972808
		public unsafe int Index
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HexGridBreaking_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HexGridBreaking_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170043AF RID: 17327
		// (get) Token: 0x06022F67 RID: 143207 RVA: 0x0097461C File Offset: 0x0097281C
		// (set) Token: 0x06022F68 RID: 143208 RVA: 0x00974655 File Offset: 0x00972855
		public TArray<FVector> DirectoryList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._DirectoryList) == null)
				{
					result = (this._DirectoryList = new TArray<FVector>(base.NativePtr + (IntPtr)BP_HexGridBreaking_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				this.DirectoryList.CopyAssign(value);
			}
		}

		// Token: 0x170043B0 RID: 17328
		// (get) Token: 0x06022F69 RID: 143209 RVA: 0x00974663 File Offset: 0x00972863
		// (set) Token: 0x06022F6A RID: 143210 RVA: 0x00974677 File Offset: 0x00972877
		public unsafe FVectorDouble OriginPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HexGridBreaking_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HexGridBreaking_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170043B1 RID: 17329
		// (get) Token: 0x06022F6B RID: 143211 RVA: 0x0097468C File Offset: 0x0097288C
		// (set) Token: 0x06022F6C RID: 143212 RVA: 0x009746A0 File Offset: 0x009728A0
		public unsafe FVectorDouble OffsetPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HexGridBreaking_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HexGridBreaking_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170043B2 RID: 17330
		// (get) Token: 0x06022F6D RID: 143213 RVA: 0x009746B8 File Offset: 0x009728B8
		// (set) Token: 0x06022F6E RID: 143214 RVA: 0x009746F1 File Offset: 0x009728F1
		public TArray<BP_RuntimeCellPieces_C> CellPieceActors
		{
			get
			{
				base.FastCheckIsValid();
				TArray<BP_RuntimeCellPieces_C> result;
				if ((result = this._CellPieceActors) == null)
				{
					result = (this._CellPieceActors = new TArray<BP_RuntimeCellPieces_C>(base.NativePtr + (IntPtr)BP_HexGridBreaking_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				this.CellPieceActors.CopyAssign(value);
			}
		}

		// Token: 0x170043B3 RID: 17331
		// (get) Token: 0x06022F6F RID: 143215 RVA: 0x009746FF File Offset: 0x009728FF
		// (set) Token: 0x06022F70 RID: 143216 RVA: 0x0097470F File Offset: 0x0097290F
		public unsafe bool Ready
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HexGridBreaking_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HexGridBreaking_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x170043B4 RID: 17332
		// (get) Token: 0x06022F71 RID: 143217 RVA: 0x00974720 File Offset: 0x00972920
		// (set) Token: 0x06022F72 RID: 143218 RVA: 0x00974759 File Offset: 0x00972959
		public TMap<string, AStaticMeshActor> CellActors
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, AStaticMeshActor> result;
				if ((result = this._CellActors) == null)
				{
					result = (this._CellActors = new TMap<string, AStaticMeshActor>(base.NativePtr + (IntPtr)BP_HexGridBreaking_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				this.CellActors.CopyAssign(value);
			}
		}

		// Token: 0x170043B5 RID: 17333
		// (get) Token: 0x06022F73 RID: 143219 RVA: 0x00974768 File Offset: 0x00972968
		// (set) Token: 0x06022F74 RID: 143220 RVA: 0x009747A1 File Offset: 0x009729A1
		public TArray<int> NewVar_0
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._NewVar_0) == null)
				{
					result = (this._NewVar_0 = new TArray<int>(base.NativePtr + (IntPtr)BP_HexGridBreaking_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				this.NewVar_0.CopyAssign(value);
			}
		}

		// Token: 0x170043B6 RID: 17334
		// (get) Token: 0x06022F75 RID: 143221 RVA: 0x009747AF File Offset: 0x009729AF
		// (set) Token: 0x06022F76 RID: 143222 RVA: 0x009747BF File Offset: 0x009729BF
		public unsafe bool IsMonster
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HexGridBreaking_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HexGridBreaking_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x06022F77 RID: 143223 RVA: 0x009747D0 File Offset: 0x009729D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Initialization()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HexGridBreaking_C.__Initialization_NativeFunctionPtr, null);
		}

		// Token: 0x06022F78 RID: 143224 RVA: 0x009747E4 File Offset: 0x009729E4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetBreakActor(FVectorDouble Position, ref BP_RuntimeCellPieces_C Actor)
		{
			BP_HexGridBreaking_C.__GetBreakActor_FunctionParams* ptr = stackalloc BP_HexGridBreaking_C.__GetBreakActor_FunctionParams[(UIntPtr)151] + 15L / (long)sizeof(BP_HexGridBreaking_C.__GetBreakActor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HexGridBreaking_C.__GetBreakActor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Position = Position;
			ref BP_HexGridBreaking_C.__GetBreakActor_FunctionParams ptr2 = ref *ptr;
			BP_RuntimeCellPieces_C bp_RuntimeCellPieces_C = Actor;
			ptr2.Actor = ((bp_RuntimeCellPieces_C != null) ? bp_RuntimeCellPieces_C.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HexGridBreaking_C.__GetBreakActor_NativeFunctionPtr, (void*)ptr);
			Actor = BuiltinUtils.GetOrCreateUObjectByNativePointer<BP_RuntimeCellPieces_C>(ptr->Actor);
		}

		// Token: 0x06022F79 RID: 143225 RVA: 0x00974854 File Offset: 0x00972A54
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetOffsetPosition(int Index, float OffsetDistance, ref FVectorDouble OffsetPosition)
		{
			BP_HexGridBreaking_C.__GetOffsetPosition_FunctionParams* ptr = stackalloc BP_HexGridBreaking_C.__GetOffsetPosition_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_HexGridBreaking_C.__GetOffsetPosition_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HexGridBreaking_C.__GetOffsetPosition_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Index = Index;
			ptr->OffsetDistance = OffsetDistance;
			ptr->OffsetPosition = OffsetPosition;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HexGridBreaking_C.__GetOffsetPosition_NativeFunctionPtr, (void*)ptr);
			OffsetPosition = ptr->OffsetPosition;
		}

		// Token: 0x06022F7A RID: 143226 RVA: 0x009748BC File Offset: 0x00972ABC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void WorldToHexCoord(FVectorDouble Position, float Size, ref FIntVector HexCoord)
		{
			BP_HexGridBreaking_C.__WorldToHexCoord_FunctionParams* ptr = stackalloc BP_HexGridBreaking_C.__WorldToHexCoord_FunctionParams[(UIntPtr)431] + 15L / (long)sizeof(BP_HexGridBreaking_C.__WorldToHexCoord_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HexGridBreaking_C.__WorldToHexCoord_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Position = Position;
			ptr->Size = Size;
			ptr->HexCoord = HexCoord;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HexGridBreaking_C.__WorldToHexCoord_NativeFunctionPtr, (void*)ptr);
			HexCoord = ptr->HexCoord;
		}

		// Token: 0x06022F7B RID: 143227 RVA: 0x00974924 File Offset: 0x00972B24
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HexGridBreaking_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06022F7C RID: 143228 RVA: 0x00974938 File Offset: 0x00972B38
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_HexGridBreaking_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022F7D RID: 143229 RVA: 0x00974950 File Offset: 0x00972B50
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_HexGridBreaking_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_HexGridBreaking_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_HexGridBreaking_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HexGridBreaking_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HexGridBreaking_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022F7E RID: 143230 RVA: 0x00974998 File Offset: 0x00972B98
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_HexGridBreaking_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_HexGridBreaking_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_HexGridBreaking_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HexGridBreaking_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_HexGridBreaking_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022F7F RID: 143231 RVA: 0x009749E0 File Offset: 0x00972BE0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeaponInteraction(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_HexGridBreaking_C.__OnWeaponInteraction_FunctionParams* ptr = stackalloc BP_HexGridBreaking_C.__OnWeaponInteraction_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_HexGridBreaking_C.__OnWeaponInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HexGridBreaking_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HexGridBreaking_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022F80 RID: 143232 RVA: 0x00974A44 File Offset: 0x00972C44
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_HexGridBreaking(int EntryPoint)
		{
			BP_HexGridBreaking_C.__ExecuteUbergraph_BP_HexGridBreaking_FunctionParams* ptr = stackalloc BP_HexGridBreaking_C.__ExecuteUbergraph_BP_HexGridBreaking_FunctionParams[(UIntPtr)1071] + 15L / (long)sizeof(BP_HexGridBreaking_C.__ExecuteUbergraph_BP_HexGridBreaking_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HexGridBreaking_C.__ExecuteUbergraph_BP_HexGridBreaking_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_HexGridBreaking_C.__ExecuteUbergraph_BP_HexGridBreaking_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022F81 RID: 143233 RVA: 0x00974A8E File Offset: 0x00972C8E
		protected BP_HexGridBreaking_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011C1E RID: 72734
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/HexGridBreaking/BP_HexGridBreaking.BP_HexGridBreaking_C";

		// Token: 0x04011C1F RID: 72735
		private static IntPtr _ClassPtr;

		// Token: 0x04011C20 RID: 72736
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011C21 RID: 72737
		internal static int __PropertyOffset_0;

		// Token: 0x04011C22 RID: 72738
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011C23 RID: 72739
		internal static int __PropertyOffset_1;

		// Token: 0x04011C24 RID: 72740
		internal static int __PropertyOffset_2;

		// Token: 0x04011C25 RID: 72741
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<BP_RuntimeCellPieces_C, float> _HitCellPieceActors;

		// Token: 0x04011C26 RID: 72742
		internal static int __PropertyOffset_3;

		// Token: 0x04011C27 RID: 72743
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TMap<UStaticMesh, UStaticMesh> _SMPiecesMap;

		// Token: 0x04011C28 RID: 72744
		internal static int __PropertyOffset_4;

		// Token: 0x04011C29 RID: 72745
		internal static int __PropertyOffset_5;

		// Token: 0x04011C2A RID: 72746
		internal static int __PropertyOffset_6;

		// Token: 0x04011C2B RID: 72747
		[Nullable(2)]
		private TArray<FVector> _DirectoryList;

		// Token: 0x04011C2C RID: 72748
		internal static int __PropertyOffset_7;

		// Token: 0x04011C2D RID: 72749
		internal static int __PropertyOffset_8;

		// Token: 0x04011C2E RID: 72750
		internal static int __PropertyOffset_9;

		// Token: 0x04011C2F RID: 72751
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<BP_RuntimeCellPieces_C> _CellPieceActors;

		// Token: 0x04011C30 RID: 72752
		internal static int __PropertyOffset_10;

		// Token: 0x04011C31 RID: 72753
		internal static int __PropertyOffset_11;

		// Token: 0x04011C32 RID: 72754
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TMap<string, AStaticMeshActor> _CellActors;

		// Token: 0x04011C33 RID: 72755
		internal static int __PropertyOffset_12;

		// Token: 0x04011C34 RID: 72756
		[Nullable(2)]
		private TArray<int> _NewVar_0;

		// Token: 0x04011C35 RID: 72757
		internal static int __PropertyOffset_13;

		// Token: 0x04011C36 RID: 72758
		private static IntPtr __Initialization_NativeFunctionPtr;

		// Token: 0x04011C37 RID: 72759
		private static IntPtr __GetBreakActor_NativeFunctionPtr;

		// Token: 0x04011C38 RID: 72760
		private static IntPtr __GetOffsetPosition_NativeFunctionPtr;

		// Token: 0x04011C39 RID: 72761
		private static IntPtr __WorldToHexCoord_NativeFunctionPtr;

		// Token: 0x04011C3A RID: 72762
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011C3B RID: 72763
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011C3C RID: 72764
		private static IntPtr __OnWeaponInteraction_NativeFunctionPtr;

		// Token: 0x04011C3D RID: 72765
		private static IntPtr __ExecuteUbergraph_BP_HexGridBreaking_NativeFunctionPtr;

		// Token: 0x02009C5E RID: 40030
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 136)]
		protected ref struct __GetBreakActor_FunctionParams
		{
			// Token: 0x0403252B RID: 206123
			[FieldOffset(0)]
			public FVectorDouble Position;

			// Token: 0x0403252C RID: 206124
			[FieldOffset(24)]
			public IntPtr Actor;
		}

		// Token: 0x02009C5F RID: 40031
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __GetOffsetPosition_FunctionParams
		{
			// Token: 0x0403252D RID: 206125
			[FieldOffset(0)]
			public int Index;

			// Token: 0x0403252E RID: 206126
			[FieldOffset(4)]
			public float OffsetDistance;

			// Token: 0x0403252F RID: 206127
			[FieldOffset(8)]
			public FVectorDouble OffsetPosition;
		}

		// Token: 0x02009C60 RID: 40032
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 416)]
		protected ref struct __WorldToHexCoord_FunctionParams
		{
			// Token: 0x04032530 RID: 206128
			[FieldOffset(0)]
			public FVectorDouble Position;

			// Token: 0x04032531 RID: 206129
			[FieldOffset(24)]
			public float Size;

			// Token: 0x04032532 RID: 206130
			[FieldOffset(28)]
			public FIntVector HexCoord;
		}

		// Token: 0x02009C61 RID: 40033
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032533 RID: 206131
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C62 RID: 40034
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeaponInteraction_FunctionParams
		{
			// Token: 0x04032534 RID: 206132
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x04032535 RID: 206133
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x04032536 RID: 206134
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x02009C63 RID: 40035
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1056)]
		protected ref struct __ExecuteUbergraph_BP_HexGridBreaking_FunctionParams
		{
			// Token: 0x04032537 RID: 206135
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
