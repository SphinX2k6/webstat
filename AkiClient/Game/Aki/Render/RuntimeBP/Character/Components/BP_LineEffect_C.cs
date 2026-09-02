using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.Components
{
	// Token: 0x02003D92 RID: 15762
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/Components/BP_LineEffect.BP_LineEffect_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class BP_LineEffect_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060267C8 RID: 157640 RVA: 0x009D9900 File Offset: 0x009D7B00
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_LineEffect_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Character/Components/BP_LineEffect.BP_LineEffect_C");
			}
			return BP_LineEffect_C._ClassPtr;
		}

		// Token: 0x060267C9 RID: 157641 RVA: 0x009D9924 File Offset: 0x009D7B24
		public BP_LineEffect_C() : this(BuiltinUtils.AllocNativeUObject(BP_LineEffect_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060267CA RID: 157642 RVA: 0x009D994C File Offset: 0x009D7B4C
		public BP_LineEffect_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_LineEffect_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700578F RID: 22415
		// (get) Token: 0x060267CB RID: 157643 RVA: 0x009D9980 File Offset: 0x009D7B80
		// (set) Token: 0x060267CC RID: 157644 RVA: 0x009D99B9 File Offset: 0x009D7BB9
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_LineEffect_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_LineEffect_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005790 RID: 22416
		// (get) Token: 0x060267CD RID: 157645 RVA: 0x009D99DA File Offset: 0x009D7BDA
		// (set) Token: 0x060267CE RID: 157646 RVA: 0x009D99EE File Offset: 0x009D7BEE
		[Nullable(2)]
		public unsafe UProceduralMeshComponent ProceduralMesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UProceduralMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LineEffect_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LineEffect_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005791 RID: 22417
		// (get) Token: 0x060267CF RID: 157647 RVA: 0x009D9A03 File Offset: 0x009D7C03
		// (set) Token: 0x060267D0 RID: 157648 RVA: 0x009D9A17 File Offset: 0x009D7C17
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LineEffect_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LineEffect_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17005792 RID: 22418
		// (get) Token: 0x060267D1 RID: 157649 RVA: 0x009D9A2C File Offset: 0x009D7C2C
		// (set) Token: 0x060267D2 RID: 157650 RVA: 0x009D9A40 File Offset: 0x009D7C40
		[Nullable(2)]
		public unsafe AActor CharacterA
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LineEffect_C.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LineEffect_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17005793 RID: 22419
		// (get) Token: 0x060267D3 RID: 157651 RVA: 0x009D9A55 File Offset: 0x009D7C55
		// (set) Token: 0x060267D4 RID: 157652 RVA: 0x009D9A69 File Offset: 0x009D7C69
		[Nullable(2)]
		public unsafe AActor CharacterB
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LineEffect_C.__PropertyOffset_4);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LineEffect_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17005794 RID: 22420
		// (get) Token: 0x060267D5 RID: 157653 RVA: 0x009D9A7E File Offset: 0x009D7C7E
		// (set) Token: 0x060267D6 RID: 157654 RVA: 0x009D9A8E File Offset: 0x009D7C8E
		public unsafe int XLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LineEffect_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LineEffect_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005795 RID: 22421
		// (get) Token: 0x060267D7 RID: 157655 RVA: 0x009D9A9F File Offset: 0x009D7C9F
		// (set) Token: 0x060267D8 RID: 157656 RVA: 0x009D9AAF File Offset: 0x009D7CAF
		public unsafe int YLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LineEffect_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LineEffect_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005796 RID: 22422
		// (get) Token: 0x060267D9 RID: 157657 RVA: 0x009D9AC0 File Offset: 0x009D7CC0
		// (set) Token: 0x060267DA RID: 157658 RVA: 0x009D9AD0 File Offset: 0x009D7CD0
		public unsafe int X
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LineEffect_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LineEffect_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005797 RID: 22423
		// (get) Token: 0x060267DB RID: 157659 RVA: 0x009D9AE1 File Offset: 0x009D7CE1
		// (set) Token: 0x060267DC RID: 157660 RVA: 0x009D9AF1 File Offset: 0x009D7CF1
		public unsafe int Y
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LineEffect_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LineEffect_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005798 RID: 22424
		// (get) Token: 0x060267DD RID: 157661 RVA: 0x009D9B04 File Offset: 0x009D7D04
		// (set) Token: 0x060267DE RID: 157662 RVA: 0x009D9B3D File Offset: 0x009D7D3D
		public TArray<FVector> Vertex
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._Vertex) == null)
				{
					result = (this._Vertex = new TArray<FVector>(base.NativePtr + (IntPtr)BP_LineEffect_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				this.Vertex.CopyAssign(value);
			}
		}

		// Token: 0x17005799 RID: 22425
		// (get) Token: 0x060267DF RID: 157663 RVA: 0x009D9B4C File Offset: 0x009D7D4C
		// (set) Token: 0x060267E0 RID: 157664 RVA: 0x009D9B85 File Offset: 0x009D7D85
		public TArray<FVector2D> UV
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector2D> result;
				if ((result = this._UV) == null)
				{
					result = (this._UV = new TArray<FVector2D>(base.NativePtr + (IntPtr)BP_LineEffect_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				this.UV.CopyAssign(value);
			}
		}

		// Token: 0x1700579A RID: 22426
		// (get) Token: 0x060267E1 RID: 157665 RVA: 0x009D9B94 File Offset: 0x009D7D94
		// (set) Token: 0x060267E2 RID: 157666 RVA: 0x009D9BCD File Offset: 0x009D7DCD
		public TArray<int> Triangle
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._Triangle) == null)
				{
					result = (this._Triangle = new TArray<int>(base.NativePtr + (IntPtr)BP_LineEffect_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				this.Triangle.CopyAssign(value);
			}
		}

		// Token: 0x1700579B RID: 22427
		// (get) Token: 0x060267E3 RID: 157667 RVA: 0x009D9BDC File Offset: 0x009D7DDC
		// (set) Token: 0x060267E4 RID: 157668 RVA: 0x009D9C15 File Offset: 0x009D7E15
		public TArray<FVector> Normals
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._Normals) == null)
				{
					result = (this._Normals = new TArray<FVector>(base.NativePtr + (IntPtr)BP_LineEffect_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				this.Normals.CopyAssign(value);
			}
		}

		// Token: 0x1700579C RID: 22428
		// (get) Token: 0x060267E5 RID: 157669 RVA: 0x009D9C24 File Offset: 0x009D7E24
		// (set) Token: 0x060267E6 RID: 157670 RVA: 0x009D9C5D File Offset: 0x009D7E5D
		public TArray<FProcMeshTangent> Tangents
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FProcMeshTangent> result;
				if ((result = this._Tangents) == null)
				{
					result = (this._Tangents = new TArray<FProcMeshTangent>(base.NativePtr + (IntPtr)BP_LineEffect_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				this.Tangents.CopyAssign(value);
			}
		}

		// Token: 0x1700579D RID: 22429
		// (get) Token: 0x060267E7 RID: 157671 RVA: 0x009D9C6B File Offset: 0x009D7E6B
		// (set) Token: 0x060267E8 RID: 157672 RVA: 0x009D9C7B File Offset: 0x009D7E7B
		public unsafe float Width
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LineEffect_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LineEffect_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x1700579E RID: 22430
		// (get) Token: 0x060267E9 RID: 157673 RVA: 0x009D9C8C File Offset: 0x009D7E8C
		// (set) Token: 0x060267EA RID: 157674 RVA: 0x009D9C9C File Offset: 0x009D7E9C
		public unsafe float height
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LineEffect_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LineEffect_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x1700579F RID: 22431
		// (get) Token: 0x060267EB RID: 157675 RVA: 0x009D9CAD File Offset: 0x009D7EAD
		// (set) Token: 0x060267EC RID: 157676 RVA: 0x009D9CC1 File Offset: 0x009D7EC1
		public unsafe FVector CharacterALastLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LineEffect_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LineEffect_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170057A0 RID: 22432
		// (get) Token: 0x060267ED RID: 157677 RVA: 0x009D9CD6 File Offset: 0x009D7ED6
		// (set) Token: 0x060267EE RID: 157678 RVA: 0x009D9CEA File Offset: 0x009D7EEA
		public unsafe FVector CharacterBLastLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LineEffect_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LineEffect_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x170057A1 RID: 22433
		// (get) Token: 0x060267EF RID: 157679 RVA: 0x009D9CFF File Offset: 0x009D7EFF
		// (set) Token: 0x060267F0 RID: 157680 RVA: 0x009D9D0F File Offset: 0x009D7F0F
		public unsafe float HeightGap
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LineEffect_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LineEffect_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x170057A2 RID: 22434
		// (get) Token: 0x060267F1 RID: 157681 RVA: 0x009D9D20 File Offset: 0x009D7F20
		// (set) Token: 0x060267F2 RID: 157682 RVA: 0x009D9D34 File Offset: 0x009D7F34
		[Nullable(2)]
		public unsafe UMaterialInstance Material
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LineEffect_C.__PropertyOffset_19);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LineEffect_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x060267F3 RID: 157683 RVA: 0x009D9D4C File Offset: 0x009D7F4C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void IsDirty(ref bool IsDirty)
		{
			BP_LineEffect_C.__IsDirty_FunctionParams* ptr = stackalloc BP_LineEffect_C.__IsDirty_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_LineEffect_C.__IsDirty_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LineEffect_C.__IsDirty_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsDirty = IsDirty;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LineEffect_C.__IsDirty_NativeFunctionPtr, (void*)ptr);
			IsDirty = ptr->IsDirty;
		}

		// Token: 0x060267F4 RID: 157684 RVA: 0x009D9D9B File Offset: 0x009D7F9B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ClearData()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LineEffect_C.__ClearData_NativeFunctionPtr, null);
		}

		// Token: 0x060267F5 RID: 157685 RVA: 0x009D9DAF File Offset: 0x009D7FAF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Construct()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LineEffect_C.__Construct_NativeFunctionPtr, null);
		}

		// Token: 0x060267F6 RID: 157686 RVA: 0x009D9DC3 File Offset: 0x009D7FC3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DrawQuad()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LineEffect_C.__DrawQuad_NativeFunctionPtr, null);
		}

		// Token: 0x060267F7 RID: 157687 RVA: 0x009D9DD7 File Offset: 0x009D7FD7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Connect()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LineEffect_C.__Connect_NativeFunctionPtr, null);
		}

		// Token: 0x060267F8 RID: 157688 RVA: 0x009D9DEC File Offset: 0x009D7FEC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_LineEffect_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LineEffect_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LineEffect_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LineEffect_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LineEffect_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060267F9 RID: 157689 RVA: 0x009D9E34 File Offset: 0x009D8034
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_LineEffect_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LineEffect_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LineEffect_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LineEffect_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LineEffect_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060267FA RID: 157690 RVA: 0x009D9E7C File Offset: 0x009D807C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_LineEffect_C.__EditorTick_FunctionParams* ptr = stackalloc BP_LineEffect_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LineEffect_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LineEffect_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LineEffect_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060267FB RID: 157691 RVA: 0x009D9EC4 File Offset: 0x009D80C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_LineEffect_C.__EditorTick_FunctionParams* ptr = stackalloc BP_LineEffect_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LineEffect_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LineEffect_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LineEffect_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060267FC RID: 157692 RVA: 0x009D9F0C File Offset: 0x009D810C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_LineEffect(int EntryPoint)
		{
			BP_LineEffect_C.__ExecuteUbergraph_BP_LineEffect_FunctionParams* ptr = stackalloc BP_LineEffect_C.__ExecuteUbergraph_BP_LineEffect_FunctionParams[(UIntPtr)35] + 15L / (long)sizeof(BP_LineEffect_C.__ExecuteUbergraph_BP_LineEffect_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LineEffect_C.__ExecuteUbergraph_BP_LineEffect_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LineEffect_C.__ExecuteUbergraph_BP_LineEffect_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060267FD RID: 157693 RVA: 0x009D9F53 File Offset: 0x009D8153
		protected BP_LineEffect_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014016 RID: 81942
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/Components/BP_LineEffect.BP_LineEffect_C";

		// Token: 0x04014017 RID: 81943
		private static IntPtr _ClassPtr;

		// Token: 0x04014018 RID: 81944
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014019 RID: 81945
		internal static int __PropertyOffset_0;

		// Token: 0x0401401A RID: 81946
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401401B RID: 81947
		internal static int __PropertyOffset_1;

		// Token: 0x0401401C RID: 81948
		internal static int __PropertyOffset_2;

		// Token: 0x0401401D RID: 81949
		internal static int __PropertyOffset_3;

		// Token: 0x0401401E RID: 81950
		internal static int __PropertyOffset_4;

		// Token: 0x0401401F RID: 81951
		internal static int __PropertyOffset_5;

		// Token: 0x04014020 RID: 81952
		internal static int __PropertyOffset_6;

		// Token: 0x04014021 RID: 81953
		internal static int __PropertyOffset_7;

		// Token: 0x04014022 RID: 81954
		internal static int __PropertyOffset_8;

		// Token: 0x04014023 RID: 81955
		internal static int __PropertyOffset_9;

		// Token: 0x04014024 RID: 81956
		[Nullable(2)]
		private TArray<FVector> _Vertex;

		// Token: 0x04014025 RID: 81957
		internal static int __PropertyOffset_10;

		// Token: 0x04014026 RID: 81958
		[Nullable(2)]
		private TArray<FVector2D> _UV;

		// Token: 0x04014027 RID: 81959
		internal static int __PropertyOffset_11;

		// Token: 0x04014028 RID: 81960
		[Nullable(2)]
		private TArray<int> _Triangle;

		// Token: 0x04014029 RID: 81961
		internal static int __PropertyOffset_12;

		// Token: 0x0401402A RID: 81962
		[Nullable(2)]
		private TArray<FVector> _Normals;

		// Token: 0x0401402B RID: 81963
		internal static int __PropertyOffset_13;

		// Token: 0x0401402C RID: 81964
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FProcMeshTangent> _Tangents;

		// Token: 0x0401402D RID: 81965
		internal static int __PropertyOffset_14;

		// Token: 0x0401402E RID: 81966
		internal static int __PropertyOffset_15;

		// Token: 0x0401402F RID: 81967
		internal static int __PropertyOffset_16;

		// Token: 0x04014030 RID: 81968
		internal static int __PropertyOffset_17;

		// Token: 0x04014031 RID: 81969
		internal static int __PropertyOffset_18;

		// Token: 0x04014032 RID: 81970
		internal static int __PropertyOffset_19;

		// Token: 0x04014033 RID: 81971
		private static IntPtr __IsDirty_NativeFunctionPtr;

		// Token: 0x04014034 RID: 81972
		private static IntPtr __ClearData_NativeFunctionPtr;

		// Token: 0x04014035 RID: 81973
		private static IntPtr __Construct_NativeFunctionPtr;

		// Token: 0x04014036 RID: 81974
		private static IntPtr __DrawQuad_NativeFunctionPtr;

		// Token: 0x04014037 RID: 81975
		private static IntPtr __Connect_NativeFunctionPtr;

		// Token: 0x04014038 RID: 81976
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04014039 RID: 81977
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0401403A RID: 81978
		private static IntPtr __ExecuteUbergraph_BP_LineEffect_NativeFunctionPtr;

		// Token: 0x0200A074 RID: 41076
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __IsDirty_FunctionParams
		{
			// Token: 0x04032CFC RID: 208124
			[FieldOffset(0)]
			public bool IsDirty;
		}

		// Token: 0x0200A075 RID: 41077
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032CFD RID: 208125
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A076 RID: 41078
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032CFE RID: 208126
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A077 RID: 41079
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 20)]
		protected ref struct __ExecuteUbergraph_BP_LineEffect_FunctionParams
		{
			// Token: 0x04032CFF RID: 208127
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
