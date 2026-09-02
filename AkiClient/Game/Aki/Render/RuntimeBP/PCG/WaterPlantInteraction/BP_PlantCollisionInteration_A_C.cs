using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.WaterPlantInteraction
{
	// Token: 0x02003B54 RID: 15188
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/WaterPlantInteraction/BP_PlantCollisionInteration_A.BP_PlantCollisionInteration_A_C")]
	[UnrealStructLayout(1248, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1248)]
	public class BP_PlantCollisionInteration_A_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060211EF RID: 135663 RVA: 0x00940530 File Offset: 0x0093E730
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PlantCollisionInteration_A_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/WaterPlantInteraction/BP_PlantCollisionInteration_A.BP_PlantCollisionInteration_A_C");
			}
			return BP_PlantCollisionInteration_A_C._ClassPtr;
		}

		// Token: 0x060211F0 RID: 135664 RVA: 0x00940554 File Offset: 0x0093E754
		public BP_PlantCollisionInteration_A_C() : this(BuiltinUtils.AllocNativeUObject(BP_PlantCollisionInteration_A_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060211F1 RID: 135665 RVA: 0x0094057C File Offset: 0x0093E77C
		public BP_PlantCollisionInteration_A_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PlantCollisionInteration_A_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003945 RID: 14661
		// (get) Token: 0x060211F2 RID: 135666 RVA: 0x009405B0 File Offset: 0x0093E7B0
		// (set) Token: 0x060211F3 RID: 135667 RVA: 0x009405E9 File Offset: 0x0093E7E9
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_PlantCollisionInteration_A_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_PlantCollisionInteration_A_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003946 RID: 14662
		// (get) Token: 0x060211F4 RID: 135668 RVA: 0x0094060A File Offset: 0x0093E80A
		// (set) Token: 0x060211F5 RID: 135669 RVA: 0x0094061E File Offset: 0x0093E81E
		[Nullable(2)]
		public unsafe UStaticMeshComponent StaticMesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlantCollisionInteration_A_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlantCollisionInteration_A_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003947 RID: 14663
		// (get) Token: 0x060211F6 RID: 135670 RVA: 0x00940633 File Offset: 0x0093E833
		// (set) Token: 0x060211F7 RID: 135671 RVA: 0x00940647 File Offset: 0x0093E847
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlantCollisionInteration_A_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlantCollisionInteration_A_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003948 RID: 14664
		// (get) Token: 0x060211F8 RID: 135672 RVA: 0x0094065C File Offset: 0x0093E85C
		// (set) Token: 0x060211F9 RID: 135673 RVA: 0x0094066C File Offset: 0x0093E86C
		public unsafe bool debugDraw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlantCollisionInteration_A_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlantCollisionInteration_A_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003949 RID: 14665
		// (get) Token: 0x060211FA RID: 135674 RVA: 0x00940680 File Offset: 0x0093E880
		// (set) Token: 0x060211FB RID: 135675 RVA: 0x009406B9 File Offset: 0x0093E8B9
		public TArray<FVector> posArr
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._posArr) == null)
				{
					result = (this._posArr = new TArray<FVector>(base.NativePtr + (IntPtr)BP_PlantCollisionInteration_A_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				this.posArr.CopyAssign(value);
			}
		}

		// Token: 0x1700394A RID: 14666
		// (get) Token: 0x060211FC RID: 135676 RVA: 0x009406C8 File Offset: 0x0093E8C8
		// (set) Token: 0x060211FD RID: 135677 RVA: 0x00940701 File Offset: 0x0093E901
		public TArray<FVector> volArr
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._volArr) == null)
				{
					result = (this._volArr = new TArray<FVector>(base.NativePtr + (IntPtr)BP_PlantCollisionInteration_A_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				this.volArr.CopyAssign(value);
			}
		}

		// Token: 0x1700394B RID: 14667
		// (get) Token: 0x060211FE RID: 135678 RVA: 0x0094070F File Offset: 0x0093E90F
		// (set) Token: 0x060211FF RID: 135679 RVA: 0x0094071F File Offset: 0x0093E91F
		public unsafe int particleCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlantCollisionInteration_A_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlantCollisionInteration_A_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700394C RID: 14668
		// (get) Token: 0x06021200 RID: 135680 RVA: 0x00940730 File Offset: 0x0093E930
		// (set) Token: 0x06021201 RID: 135681 RVA: 0x00940740 File Offset: 0x0093E940
		public unsafe float linkDis
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlantCollisionInteration_A_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlantCollisionInteration_A_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700394D RID: 14669
		// (get) Token: 0x06021202 RID: 135682 RVA: 0x00940751 File Offset: 0x0093E951
		// (set) Token: 0x06021203 RID: 135683 RVA: 0x00940765 File Offset: 0x0093E965
		public unsafe FVector emitterOriginPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlantCollisionInteration_A_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlantCollisionInteration_A_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700394E RID: 14670
		// (get) Token: 0x06021204 RID: 135684 RVA: 0x0094077A File Offset: 0x0093E97A
		// (set) Token: 0x06021205 RID: 135685 RVA: 0x0094078E File Offset: 0x0093E98E
		public unsafe FVector accel_ext
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlantCollisionInteration_A_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlantCollisionInteration_A_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x1700394F RID: 14671
		// (get) Token: 0x06021206 RID: 135686 RVA: 0x009407A4 File Offset: 0x0093E9A4
		// (set) Token: 0x06021207 RID: 135687 RVA: 0x009407DD File Offset: 0x0093E9DD
		public TArray<FVector> posArr_foe
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._posArr_foe) == null)
				{
					result = (this._posArr_foe = new TArray<FVector>(base.NativePtr + (IntPtr)BP_PlantCollisionInteration_A_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				this.posArr_foe.CopyAssign(value);
			}
		}

		// Token: 0x17003950 RID: 14672
		// (get) Token: 0x06021208 RID: 135688 RVA: 0x009407EB File Offset: 0x0093E9EB
		// (set) Token: 0x06021209 RID: 135689 RVA: 0x009407FB File Offset: 0x0093E9FB
		public unsafe float collisionR
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlantCollisionInteration_A_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlantCollisionInteration_A_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17003951 RID: 14673
		// (get) Token: 0x0602120A RID: 135690 RVA: 0x0094080C File Offset: 0x0093EA0C
		// (set) Token: 0x0602120B RID: 135691 RVA: 0x0094081C File Offset: 0x0093EA1C
		public unsafe long frameID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlantCollisionInteration_A_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlantCollisionInteration_A_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003952 RID: 14674
		// (get) Token: 0x0602120C RID: 135692 RVA: 0x0094082D File Offset: 0x0093EA2D
		// (set) Token: 0x0602120D RID: 135693 RVA: 0x0094083D File Offset: 0x0093EA3D
		public unsafe float volDamping
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlantCollisionInteration_A_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlantCollisionInteration_A_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17003953 RID: 14675
		// (get) Token: 0x0602120E RID: 135694 RVA: 0x00940850 File Offset: 0x0093EA50
		// (set) Token: 0x0602120F RID: 135695 RVA: 0x00940889 File Offset: 0x0093EA89
		public TArray<FVector> posArrOrigin
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._posArrOrigin) == null)
				{
					result = (this._posArrOrigin = new TArray<FVector>(base.NativePtr + (IntPtr)BP_PlantCollisionInteration_A_C.__PropertyOffset_14, this));
				}
				return result;
			}
			set
			{
				this.posArrOrigin.CopyAssign(value);
			}
		}

		// Token: 0x17003954 RID: 14676
		// (get) Token: 0x06021210 RID: 135696 RVA: 0x00940897 File Offset: 0x0093EA97
		// (set) Token: 0x06021211 RID: 135697 RVA: 0x009408AB File Offset: 0x0093EAAB
		[Nullable(2)]
		public unsafe UMaterialInstanceDynamic DMI
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlantCollisionInteration_A_C.__PropertyOffset_15);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlantCollisionInteration_A_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x17003955 RID: 14677
		// (get) Token: 0x06021212 RID: 135698 RVA: 0x009408C0 File Offset: 0x0093EAC0
		// (set) Token: 0x06021213 RID: 135699 RVA: 0x009408D4 File Offset: 0x0093EAD4
		[Nullable(2)]
		public unsafe UMaterialInterface Material_InstanceTemp
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlantCollisionInteration_A_C.__PropertyOffset_16);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlantCollisionInteration_A_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x17003956 RID: 14678
		// (get) Token: 0x06021214 RID: 135700 RVA: 0x009408E9 File Offset: 0x0093EAE9
		// (set) Token: 0x06021215 RID: 135701 RVA: 0x009408F9 File Offset: 0x0093EAF9
		public unsafe bool PC_Platform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlantCollisionInteration_A_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlantCollisionInteration_A_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003957 RID: 14679
		// (get) Token: 0x06021216 RID: 135702 RVA: 0x0094090A File Offset: 0x0093EB0A
		// (set) Token: 0x06021217 RID: 135703 RVA: 0x0094091A File Offset: 0x0093EB1A
		public unsafe float Debug_Radius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlantCollisionInteration_A_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlantCollisionInteration_A_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17003958 RID: 14680
		// (get) Token: 0x06021218 RID: 135704 RVA: 0x0094092B File Offset: 0x0093EB2B
		// (set) Token: 0x06021219 RID: 135705 RVA: 0x0094093F File Offset: 0x0093EB3F
		public unsafe FVectorDouble CharacterPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlantCollisionInteration_A_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlantCollisionInteration_A_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17003959 RID: 14681
		// (get) Token: 0x0602121A RID: 135706 RVA: 0x00940954 File Offset: 0x0093EB54
		// (set) Token: 0x0602121B RID: 135707 RVA: 0x00940964 File Offset: 0x0093EB64
		public unsafe float Self_WorldScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlantCollisionInteration_A_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlantCollisionInteration_A_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x1700395A RID: 14682
		// (get) Token: 0x0602121C RID: 135708 RVA: 0x00940975 File Offset: 0x0093EB75
		// (set) Token: 0x0602121D RID: 135709 RVA: 0x00940989 File Offset: 0x0093EB89
		public unsafe FVector rootOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlantCollisionInteration_A_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlantCollisionInteration_A_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x0602121E RID: 135710 RVA: 0x009409A0 File Offset: 0x0093EBA0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ScheduledTick(float DeltaSeconds)
		{
			BP_PlantCollisionInteration_A_C.__ScheduledTick_FunctionParams* ptr = stackalloc BP_PlantCollisionInteration_A_C.__ScheduledTick_FunctionParams[(UIntPtr)399] + 15L / (long)sizeof(BP_PlantCollisionInteration_A_C.__ScheduledTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PlantCollisionInteration_A_C.__ScheduledTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PlantCollisionInteration_A_C.__ScheduledTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602121F RID: 135711 RVA: 0x009409E9 File Offset: 0x0093EBE9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Get_CharacterPosition()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PlantCollisionInteration_A_C.__Get_CharacterPosition_NativeFunctionPtr, null);
		}

		// Token: 0x06021220 RID: 135712 RVA: 0x00940A00 File Offset: 0x0093EC00
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void solve(bool isPinned, FVector pos, FVector linkPos, float targetLen, FVector emitterOriginPos, ref FVector pos_new)
		{
			BP_PlantCollisionInteration_A_C.__solve_FunctionParams* ptr = stackalloc BP_PlantCollisionInteration_A_C.__solve_FunctionParams[(UIntPtr)131] + 15L / (long)sizeof(BP_PlantCollisionInteration_A_C.__solve_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PlantCollisionInteration_A_C.__solve_NativeFunctionPtr, (void*)ptr, 1);
			ptr->isPinned = isPinned;
			ptr->pos = pos;
			ptr->linkPos = linkPos;
			ptr->targetLen = targetLen;
			ptr->emitterOriginPos = emitterOriginPos;
			ptr->pos_new = pos_new;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PlantCollisionInteration_A_C.__solve_NativeFunctionPtr, (void*)ptr);
			pos_new = ptr->pos_new;
		}

		// Token: 0x06021221 RID: 135713 RVA: 0x00940A81 File Offset: 0x0093EC81
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PlantCollisionInteration_A_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021222 RID: 135714 RVA: 0x00940A95 File Offset: 0x0093EC95
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PlantCollisionInteration_A_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021223 RID: 135715 RVA: 0x00940AAC File Offset: 0x0093ECAC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_PlantCollisionInteration_A_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_PlantCollisionInteration_A_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_PlantCollisionInteration_A_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PlantCollisionInteration_A_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PlantCollisionInteration_A_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021224 RID: 135716 RVA: 0x00940AF8 File Offset: 0x0093ECF8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_PlantCollisionInteration_A_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_PlantCollisionInteration_A_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_PlantCollisionInteration_A_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PlantCollisionInteration_A_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PlantCollisionInteration_A_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021225 RID: 135717 RVA: 0x00940B44 File Offset: 0x0093ED44
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PlantCollisionInteration_A_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06021226 RID: 135718 RVA: 0x00940B58 File Offset: 0x0093ED58
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PlantCollisionInteration_A_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021227 RID: 135719 RVA: 0x00940B70 File Offset: 0x0093ED70
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_PlantCollisionInteration_A(int EntryPoint)
		{
			BP_PlantCollisionInteration_A_C.__ExecuteUbergraph_BP_PlantCollisionInteration_A_FunctionParams* ptr = stackalloc BP_PlantCollisionInteration_A_C.__ExecuteUbergraph_BP_PlantCollisionInteration_A_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_PlantCollisionInteration_A_C.__ExecuteUbergraph_BP_PlantCollisionInteration_A_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PlantCollisionInteration_A_C.__ExecuteUbergraph_BP_PlantCollisionInteration_A_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PlantCollisionInteration_A_C.__ExecuteUbergraph_BP_PlantCollisionInteration_A_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021228 RID: 135720 RVA: 0x00940BB7 File Offset: 0x0093EDB7
		protected BP_PlantCollisionInteration_A_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010A37 RID: 68151
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/WaterPlantInteraction/BP_PlantCollisionInteration_A.BP_PlantCollisionInteration_A_C";

		// Token: 0x04010A38 RID: 68152
		private static IntPtr _ClassPtr;

		// Token: 0x04010A39 RID: 68153
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010A3A RID: 68154
		internal static int __PropertyOffset_0;

		// Token: 0x04010A3B RID: 68155
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010A3C RID: 68156
		internal static int __PropertyOffset_1;

		// Token: 0x04010A3D RID: 68157
		internal static int __PropertyOffset_2;

		// Token: 0x04010A3E RID: 68158
		internal static int __PropertyOffset_3;

		// Token: 0x04010A3F RID: 68159
		internal static int __PropertyOffset_4;

		// Token: 0x04010A40 RID: 68160
		[Nullable(2)]
		private TArray<FVector> _posArr;

		// Token: 0x04010A41 RID: 68161
		internal static int __PropertyOffset_5;

		// Token: 0x04010A42 RID: 68162
		[Nullable(2)]
		private TArray<FVector> _volArr;

		// Token: 0x04010A43 RID: 68163
		internal static int __PropertyOffset_6;

		// Token: 0x04010A44 RID: 68164
		internal static int __PropertyOffset_7;

		// Token: 0x04010A45 RID: 68165
		internal static int __PropertyOffset_8;

		// Token: 0x04010A46 RID: 68166
		internal static int __PropertyOffset_9;

		// Token: 0x04010A47 RID: 68167
		internal static int __PropertyOffset_10;

		// Token: 0x04010A48 RID: 68168
		[Nullable(2)]
		private TArray<FVector> _posArr_foe;

		// Token: 0x04010A49 RID: 68169
		internal static int __PropertyOffset_11;

		// Token: 0x04010A4A RID: 68170
		internal static int __PropertyOffset_12;

		// Token: 0x04010A4B RID: 68171
		internal static int __PropertyOffset_13;

		// Token: 0x04010A4C RID: 68172
		internal static int __PropertyOffset_14;

		// Token: 0x04010A4D RID: 68173
		[Nullable(2)]
		private TArray<FVector> _posArrOrigin;

		// Token: 0x04010A4E RID: 68174
		internal static int __PropertyOffset_15;

		// Token: 0x04010A4F RID: 68175
		internal static int __PropertyOffset_16;

		// Token: 0x04010A50 RID: 68176
		internal static int __PropertyOffset_17;

		// Token: 0x04010A51 RID: 68177
		internal static int __PropertyOffset_18;

		// Token: 0x04010A52 RID: 68178
		internal static int __PropertyOffset_19;

		// Token: 0x04010A53 RID: 68179
		internal static int __PropertyOffset_20;

		// Token: 0x04010A54 RID: 68180
		internal static int __PropertyOffset_21;

		// Token: 0x04010A55 RID: 68181
		private static IntPtr __ScheduledTick_NativeFunctionPtr;

		// Token: 0x04010A56 RID: 68182
		private static IntPtr __Get_CharacterPosition_NativeFunctionPtr;

		// Token: 0x04010A57 RID: 68183
		private static IntPtr __solve_NativeFunctionPtr;

		// Token: 0x04010A58 RID: 68184
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010A59 RID: 68185
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04010A5A RID: 68186
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010A5B RID: 68187
		private static IntPtr __ExecuteUbergraph_BP_PlantCollisionInteration_A_NativeFunctionPtr;

		// Token: 0x02009A7D RID: 39549
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 384)]
		protected ref struct __ScheduledTick_FunctionParams
		{
			// Token: 0x040321CC RID: 205260
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A7E RID: 39550
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 116)]
		protected ref struct __solve_FunctionParams
		{
			// Token: 0x040321CD RID: 205261
			[FieldOffset(0)]
			public bool isPinned;

			// Token: 0x040321CE RID: 205262
			[FieldOffset(4)]
			public FVector pos;

			// Token: 0x040321CF RID: 205263
			[FieldOffset(16)]
			public FVector linkPos;

			// Token: 0x040321D0 RID: 205264
			[FieldOffset(28)]
			public float targetLen;

			// Token: 0x040321D1 RID: 205265
			[FieldOffset(32)]
			public FVector emitterOriginPos;

			// Token: 0x040321D2 RID: 205266
			[FieldOffset(44)]
			public FVector pos_new;
		}

		// Token: 0x02009A7F RID: 39551
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x040321D3 RID: 205267
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009A80 RID: 39552
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ExecuteUbergraph_BP_PlantCollisionInteration_A_FunctionParams
		{
			// Token: 0x040321D4 RID: 205268
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
