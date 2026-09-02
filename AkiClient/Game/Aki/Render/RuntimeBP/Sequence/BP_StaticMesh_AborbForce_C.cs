using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Sequence
{
	// Token: 0x02003A60 RID: 14944
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Sequence/BP_StaticMesh_AborbForce.BP_StaticMesh_AborbForce_C")]
	[UnrealStructLayout(1336, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1332)]
	public class BP_StaticMesh_AborbForce_C : AKuroEffectActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F123 RID: 127267 RVA: 0x00906DDF File Offset: 0x00904FDF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_StaticMesh_AborbForce_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Sequence/BP_StaticMesh_AborbForce.BP_StaticMesh_AborbForce_C");
			}
			return BP_StaticMesh_AborbForce_C._ClassPtr;
		}

		// Token: 0x0601F124 RID: 127268 RVA: 0x00906E04 File Offset: 0x00905004
		public BP_StaticMesh_AborbForce_C() : this(BuiltinUtils.AllocNativeUObject(BP_StaticMesh_AborbForce_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F125 RID: 127269 RVA: 0x00906E2C File Offset: 0x0090502C
		public BP_StaticMesh_AborbForce_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_StaticMesh_AborbForce_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002DE8 RID: 11752
		// (get) Token: 0x0601F126 RID: 127270 RVA: 0x00906E60 File Offset: 0x00905060
		// (set) Token: 0x0601F127 RID: 127271 RVA: 0x00906E99 File Offset: 0x00905099
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_StaticMesh_AborbForce_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_StaticMesh_AborbForce_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002DE9 RID: 11753
		// (get) Token: 0x0601F128 RID: 127272 RVA: 0x00906EBA File Offset: 0x009050BA
		// (set) Token: 0x0601F129 RID: 127273 RVA: 0x00906ECE File Offset: 0x009050CE
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_StaticMesh_AborbForce_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_StaticMesh_AborbForce_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002DEA RID: 11754
		// (get) Token: 0x0601F12A RID: 127274 RVA: 0x00906EE4 File Offset: 0x009050E4
		// (set) Token: 0x0601F12B RID: 127275 RVA: 0x00906F1D File Offset: 0x0090511D
		public TArray<AActor> StaticActors
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._StaticActors) == null)
				{
					result = (this._StaticActors = new TArray<AActor>(base.NativePtr + (IntPtr)BP_StaticMesh_AborbForce_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				this.StaticActors.CopyAssign(value);
			}
		}

		// Token: 0x17002DEB RID: 11755
		// (get) Token: 0x0601F12C RID: 127276 RVA: 0x00906F2B File Offset: 0x0090512B
		// (set) Token: 0x0601F12D RID: 127277 RVA: 0x00906F3F File Offset: 0x0090513F
		public unsafe FVector Center
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_StaticMesh_AborbForce_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_StaticMesh_AborbForce_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17002DEC RID: 11756
		// (get) Token: 0x0601F12E RID: 127278 RVA: 0x00906F54 File Offset: 0x00905154
		// (set) Token: 0x0601F12F RID: 127279 RVA: 0x00906F8D File Offset: 0x0090518D
		public FKuroCurveFloat Acceleration
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._Acceleration) == null)
				{
					result = (this._Acceleration = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_StaticMesh_AborbForce_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_StaticMesh_AborbForce_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002DED RID: 11757
		// (get) Token: 0x0601F130 RID: 127280 RVA: 0x00906FB0 File Offset: 0x009051B0
		// (set) Token: 0x0601F131 RID: 127281 RVA: 0x00906FE9 File Offset: 0x009051E9
		public TArray<AActor> RuntimeActors
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._RuntimeActors) == null)
				{
					result = (this._RuntimeActors = new TArray<AActor>(base.NativePtr + (IntPtr)BP_StaticMesh_AborbForce_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				this.RuntimeActors.CopyAssign(value);
			}
		}

		// Token: 0x17002DEE RID: 11758
		// (get) Token: 0x0601F132 RID: 127282 RVA: 0x00906FF8 File Offset: 0x009051F8
		// (set) Token: 0x0601F133 RID: 127283 RVA: 0x00907031 File Offset: 0x00905231
		public TArray<FVector> Speeds
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._Speeds) == null)
				{
					result = (this._Speeds = new TArray<FVector>(base.NativePtr + (IntPtr)BP_StaticMesh_AborbForce_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				this.Speeds.CopyAssign(value);
			}
		}

		// Token: 0x17002DEF RID: 11759
		// (get) Token: 0x0601F134 RID: 127284 RVA: 0x0090703F File Offset: 0x0090523F
		// (set) Token: 0x0601F135 RID: 127285 RVA: 0x0090704F File Offset: 0x0090524F
		public unsafe float TimeScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_StaticMesh_AborbForce_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_StaticMesh_AborbForce_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17002DF0 RID: 11760
		// (get) Token: 0x0601F136 RID: 127286 RVA: 0x00907060 File Offset: 0x00905260
		// (set) Token: 0x0601F137 RID: 127287 RVA: 0x00907070 File Offset: 0x00905270
		public unsafe float Delta_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_StaticMesh_AborbForce_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_StaticMesh_AborbForce_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17002DF1 RID: 11761
		// (get) Token: 0x0601F138 RID: 127288 RVA: 0x00907081 File Offset: 0x00905281
		// (set) Token: 0x0601F139 RID: 127289 RVA: 0x00907095 File Offset: 0x00905295
		public unsafe FVector Speed_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_StaticMesh_AborbForce_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_StaticMesh_AborbForce_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17002DF2 RID: 11762
		// (get) Token: 0x0601F13A RID: 127290 RVA: 0x009070AA File Offset: 0x009052AA
		// (set) Token: 0x0601F13B RID: 127291 RVA: 0x009070BE File Offset: 0x009052BE
		[Nullable(2)]
		public unsafe AActor Actor_
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_StaticMesh_AborbForce_C.__PropertyOffset_10);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_StaticMesh_AborbForce_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17002DF3 RID: 11763
		// (get) Token: 0x0601F13C RID: 127292 RVA: 0x009070D4 File Offset: 0x009052D4
		// (set) Token: 0x0601F13D RID: 127293 RVA: 0x0090710D File Offset: 0x0090530D
		public TArray<UStaticMeshComponent> StaticMeshesHidden
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UStaticMeshComponent> result;
				if ((result = this._StaticMeshesHidden) == null)
				{
					result = (this._StaticMeshesHidden = new TArray<UStaticMeshComponent>(base.NativePtr + (IntPtr)BP_StaticMesh_AborbForce_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				this.StaticMeshesHidden.CopyAssign(value);
			}
		}

		// Token: 0x17002DF4 RID: 11764
		// (get) Token: 0x0601F13E RID: 127294 RVA: 0x0090711C File Offset: 0x0090531C
		// (set) Token: 0x0601F13F RID: 127295 RVA: 0x00907155 File Offset: 0x00905355
		public TArray<float> Masses
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._Masses) == null)
				{
					result = (this._Masses = new TArray<float>(base.NativePtr + (IntPtr)BP_StaticMesh_AborbForce_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				this.Masses.CopyAssign(value);
			}
		}

		// Token: 0x17002DF5 RID: 11765
		// (get) Token: 0x0601F140 RID: 127296 RVA: 0x00907163 File Offset: 0x00905363
		// (set) Token: 0x0601F141 RID: 127297 RVA: 0x00907173 File Offset: 0x00905373
		public unsafe float Acc_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_StaticMesh_AborbForce_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_StaticMesh_AborbForce_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x0601F142 RID: 127298 RVA: 0x00907184 File Offset: 0x00905384
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CopyStaticMeshAndHide(AActor Actor, ref AActor ActorAdded)
		{
			BP_StaticMesh_AborbForce_C.__CopyStaticMeshAndHide_FunctionParams* ptr = stackalloc BP_StaticMesh_AborbForce_C.__CopyStaticMeshAndHide_FunctionParams[(UIntPtr)239] + 15L / (long)sizeof(BP_StaticMesh_AborbForce_C.__CopyStaticMeshAndHide_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_StaticMesh_AborbForce_C.__CopyStaticMeshAndHide_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Actor = ((Actor != null) ? Actor.NativePtr : IntPtr.Zero);
			ref BP_StaticMesh_AborbForce_C.__CopyStaticMeshAndHide_FunctionParams ptr2 = ref *ptr;
			AActor aactor = ActorAdded;
			ptr2.ActorAdded = ((aactor != null) ? aactor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_StaticMesh_AborbForce_C.__CopyStaticMeshAndHide_NativeFunctionPtr, (void*)ptr);
			ActorAdded = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(ptr->ActorAdded);
		}

		// Token: 0x0601F143 RID: 127299 RVA: 0x00907201 File Offset: 0x00905401
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Revert()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_StaticMesh_AborbForce_C.__Revert_NativeFunctionPtr, null);
		}

		// Token: 0x0601F144 RID: 127300 RVA: 0x00907215 File Offset: 0x00905415
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Start()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_StaticMesh_AborbForce_C.__Start_NativeFunctionPtr, null);
		}

		// Token: 0x0601F145 RID: 127301 RVA: 0x00907229 File Offset: 0x00905429
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_StaticMesh_AborbForce_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601F146 RID: 127302 RVA: 0x0090723D File Offset: 0x0090543D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_StaticMesh_AborbForce_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F147 RID: 127303 RVA: 0x00907254 File Offset: 0x00905454
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_StaticMesh_AborbForce_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_StaticMesh_AborbForce_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_StaticMesh_AborbForce_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_StaticMesh_AborbForce_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_StaticMesh_AborbForce_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F148 RID: 127304 RVA: 0x0090729C File Offset: 0x0090549C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_StaticMesh_AborbForce_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_StaticMesh_AborbForce_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_StaticMesh_AborbForce_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_StaticMesh_AborbForce_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_StaticMesh_AborbForce_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F149 RID: 127305 RVA: 0x009072E4 File Offset: 0x009054E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_StaticMesh_AborbForce_C.__EditorTick_FunctionParams* ptr = stackalloc BP_StaticMesh_AborbForce_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_StaticMesh_AborbForce_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_StaticMesh_AborbForce_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_StaticMesh_AborbForce_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F14A RID: 127306 RVA: 0x0090732C File Offset: 0x0090552C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_StaticMesh_AborbForce_C.__EditorTick_FunctionParams* ptr = stackalloc BP_StaticMesh_AborbForce_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_StaticMesh_AborbForce_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_StaticMesh_AborbForce_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_StaticMesh_AborbForce_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F14B RID: 127307 RVA: 0x00907374 File Offset: 0x00905574
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_StaticMesh_AborbForce(int EntryPoint)
		{
			BP_StaticMesh_AborbForce_C.__ExecuteUbergraph_BP_StaticMesh_AborbForce_FunctionParams* ptr = stackalloc BP_StaticMesh_AborbForce_C.__ExecuteUbergraph_BP_StaticMesh_AborbForce_FunctionParams[(UIntPtr)423] + 15L / (long)sizeof(BP_StaticMesh_AborbForce_C.__ExecuteUbergraph_BP_StaticMesh_AborbForce_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_StaticMesh_AborbForce_C.__ExecuteUbergraph_BP_StaticMesh_AborbForce_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_StaticMesh_AborbForce_C.__ExecuteUbergraph_BP_StaticMesh_AborbForce_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F14C RID: 127308 RVA: 0x009073BE File Offset: 0x009055BE
		protected BP_StaticMesh_AborbForce_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F615 RID: 62997
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Sequence/BP_StaticMesh_AborbForce.BP_StaticMesh_AborbForce_C";

		// Token: 0x0400F616 RID: 62998
		private static IntPtr _ClassPtr;

		// Token: 0x0400F617 RID: 62999
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F618 RID: 63000
		internal static int __PropertyOffset_0;

		// Token: 0x0400F619 RID: 63001
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F61A RID: 63002
		internal static int __PropertyOffset_1;

		// Token: 0x0400F61B RID: 63003
		internal static int __PropertyOffset_2;

		// Token: 0x0400F61C RID: 63004
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _StaticActors;

		// Token: 0x0400F61D RID: 63005
		internal static int __PropertyOffset_3;

		// Token: 0x0400F61E RID: 63006
		internal static int __PropertyOffset_4;

		// Token: 0x0400F61F RID: 63007
		[Nullable(2)]
		private FKuroCurveFloat _Acceleration;

		// Token: 0x0400F620 RID: 63008
		internal static int __PropertyOffset_5;

		// Token: 0x0400F621 RID: 63009
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _RuntimeActors;

		// Token: 0x0400F622 RID: 63010
		internal static int __PropertyOffset_6;

		// Token: 0x0400F623 RID: 63011
		[Nullable(2)]
		private TArray<FVector> _Speeds;

		// Token: 0x0400F624 RID: 63012
		internal static int __PropertyOffset_7;

		// Token: 0x0400F625 RID: 63013
		internal static int __PropertyOffset_8;

		// Token: 0x0400F626 RID: 63014
		internal static int __PropertyOffset_9;

		// Token: 0x0400F627 RID: 63015
		internal static int __PropertyOffset_10;

		// Token: 0x0400F628 RID: 63016
		internal static int __PropertyOffset_11;

		// Token: 0x0400F629 RID: 63017
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMeshComponent> _StaticMeshesHidden;

		// Token: 0x0400F62A RID: 63018
		internal static int __PropertyOffset_12;

		// Token: 0x0400F62B RID: 63019
		[Nullable(2)]
		private TArray<float> _Masses;

		// Token: 0x0400F62C RID: 63020
		internal static int __PropertyOffset_13;

		// Token: 0x0400F62D RID: 63021
		private static IntPtr __CopyStaticMeshAndHide_NativeFunctionPtr;

		// Token: 0x0400F62E RID: 63022
		private static IntPtr __Revert_NativeFunctionPtr;

		// Token: 0x0400F62F RID: 63023
		private static IntPtr __Start_NativeFunctionPtr;

		// Token: 0x0400F630 RID: 63024
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F631 RID: 63025
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F632 RID: 63026
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400F633 RID: 63027
		private static IntPtr __ExecuteUbergraph_BP_StaticMesh_AborbForce_NativeFunctionPtr;

		// Token: 0x02009856 RID: 38998
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 224)]
		protected ref struct __CopyStaticMeshAndHide_FunctionParams
		{
			// Token: 0x04031E8A RID: 204426
			[FieldOffset(0)]
			public IntPtr Actor;

			// Token: 0x04031E8B RID: 204427
			[FieldOffset(8)]
			public IntPtr ActorAdded;
		}

		// Token: 0x02009857 RID: 38999
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031E8C RID: 204428
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009858 RID: 39000
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031E8D RID: 204429
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009859 RID: 39001
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 408)]
		protected ref struct __ExecuteUbergraph_BP_StaticMesh_AborbForce_FunctionParams
		{
			// Token: 0x04031E8E RID: 204430
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
