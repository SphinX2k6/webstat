using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Scene.Destructible;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Water.BP
{
	// Token: 0x02003A09 RID: 14857
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Water/BP/BP_OceanHeight_Offset.BP_OceanHeight_Offset_C")]
	[UnrealStructLayout(1112, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1112)]
	public class BP_OceanHeight_Offset_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601E4E9 RID: 124137 RVA: 0x008F2603 File Offset: 0x008F0803
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_OceanHeight_Offset_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Water/BP/BP_OceanHeight_Offset.BP_OceanHeight_Offset_C");
			}
			return BP_OceanHeight_Offset_C._ClassPtr;
		}

		// Token: 0x0601E4EA RID: 124138 RVA: 0x008F2628 File Offset: 0x008F0828
		public BP_OceanHeight_Offset_C() : this(BuiltinUtils.AllocNativeUObject(BP_OceanHeight_Offset_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E4EB RID: 124139 RVA: 0x008F2650 File Offset: 0x008F0850
		[NullableContext(1)]
		public BP_OceanHeight_Offset_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_OceanHeight_Offset_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002981 RID: 10625
		// (get) Token: 0x0601E4EC RID: 124140 RVA: 0x008F2684 File Offset: 0x008F0884
		// (set) Token: 0x0601E4ED RID: 124141 RVA: 0x008F26BD File Offset: 0x008F08BD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_OceanHeight_Offset_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_OceanHeight_Offset_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002982 RID: 10626
		// (get) Token: 0x0601E4EE RID: 124142 RVA: 0x008F26DE File Offset: 0x008F08DE
		// (set) Token: 0x0601E4EF RID: 124143 RVA: 0x008F26F2 File Offset: 0x008F08F2
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_OceanHeight_Offset_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_OceanHeight_Offset_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002983 RID: 10627
		// (get) Token: 0x0601E4F0 RID: 124144 RVA: 0x008F2707 File Offset: 0x008F0907
		// (set) Token: 0x0601E4F1 RID: 124145 RVA: 0x008F271B File Offset: 0x008F091B
		public unsafe UMaterialInstance Mat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_OceanHeight_Offset_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_OceanHeight_Offset_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002984 RID: 10628
		// (get) Token: 0x0601E4F2 RID: 124146 RVA: 0x008F2730 File Offset: 0x008F0930
		// (set) Token: 0x0601E4F3 RID: 124147 RVA: 0x008F2744 File Offset: 0x008F0944
		public unsafe UStaticMeshComponent Mesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_OceanHeight_Offset_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_OceanHeight_Offset_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002985 RID: 10629
		// (get) Token: 0x0601E4F4 RID: 124148 RVA: 0x008F2759 File Offset: 0x008F0959
		// (set) Token: 0x0601E4F5 RID: 124149 RVA: 0x008F276D File Offset: 0x008F096D
		public unsafe BP_KuroSkeletalMeshDestructibleActor_C ParentActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_KuroSkeletalMeshDestructibleActor_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_OceanHeight_Offset_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_OceanHeight_Offset_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17002986 RID: 10630
		// (get) Token: 0x0601E4F6 RID: 124150 RVA: 0x008F2784 File Offset: 0x008F0984
		// (set) Token: 0x0601E4F7 RID: 124151 RVA: 0x008F27BD File Offset: 0x008F09BD
		[Nullable(1)]
		public TArray<UMaterialInstance> MaterialsArray
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstance> result;
				if ((result = this._MaterialsArray) == null)
				{
					result = (this._MaterialsArray = new TArray<UMaterialInstance>(base.NativePtr + (IntPtr)BP_OceanHeight_Offset_C.__PropertyOffset_5, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.MaterialsArray.CopyAssign(value);
			}
		}

		// Token: 0x17002987 RID: 10631
		// (get) Token: 0x0601E4F8 RID: 124152 RVA: 0x008F27CC File Offset: 0x008F09CC
		// (set) Token: 0x0601E4F9 RID: 124153 RVA: 0x008F2805 File Offset: 0x008F0A05
		[Nullable(1)]
		public TArray<FLinearColor> OceanRange
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FLinearColor> result;
				if ((result = this._OceanRange) == null)
				{
					result = (this._OceanRange = new TArray<FLinearColor>(base.NativePtr + (IntPtr)BP_OceanHeight_Offset_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.OceanRange.CopyAssign(value);
			}
		}

		// Token: 0x17002988 RID: 10632
		// (get) Token: 0x0601E4FA RID: 124154 RVA: 0x008F2813 File Offset: 0x008F0A13
		// (set) Token: 0x0601E4FB RID: 124155 RVA: 0x008F2827 File Offset: 0x008F0A27
		public unsafe UMaterialInstance Mat_LOD
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_OceanHeight_Offset_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_OceanHeight_Offset_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x0601E4FC RID: 124156 RVA: 0x008F283C File Offset: 0x008F0A3C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_OceanHeight_Offset_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601E4FD RID: 124157 RVA: 0x008F2850 File Offset: 0x008F0A50
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_OceanHeight_Offset_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E4FE RID: 124158 RVA: 0x008F2868 File Offset: 0x008F0A68
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_OceanHeight_Offset(int EntryPoint)
		{
			BP_OceanHeight_Offset_C.__ExecuteUbergraph_BP_OceanHeight_Offset_FunctionParams* ptr = stackalloc BP_OceanHeight_Offset_C.__ExecuteUbergraph_BP_OceanHeight_Offset_FunctionParams[(UIntPtr)159] + 15L / (long)sizeof(BP_OceanHeight_Offset_C.__ExecuteUbergraph_BP_OceanHeight_Offset_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_OceanHeight_Offset_C.__ExecuteUbergraph_BP_OceanHeight_Offset_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_OceanHeight_Offset_C.__ExecuteUbergraph_BP_OceanHeight_Offset_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E4FF RID: 124159 RVA: 0x008F28B2 File Offset: 0x008F0AB2
		protected BP_OceanHeight_Offset_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400EE82 RID: 61058
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Water/BP/BP_OceanHeight_Offset.BP_OceanHeight_Offset_C";

		// Token: 0x0400EE83 RID: 61059
		private static IntPtr _ClassPtr;

		// Token: 0x0400EE84 RID: 61060
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400EE85 RID: 61061
		internal static int __PropertyOffset_0;

		// Token: 0x0400EE86 RID: 61062
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400EE87 RID: 61063
		internal static int __PropertyOffset_1;

		// Token: 0x0400EE88 RID: 61064
		internal static int __PropertyOffset_2;

		// Token: 0x0400EE89 RID: 61065
		internal static int __PropertyOffset_3;

		// Token: 0x0400EE8A RID: 61066
		internal static int __PropertyOffset_4;

		// Token: 0x0400EE8B RID: 61067
		internal static int __PropertyOffset_5;

		// Token: 0x0400EE8C RID: 61068
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstance> _MaterialsArray;

		// Token: 0x0400EE8D RID: 61069
		internal static int __PropertyOffset_6;

		// Token: 0x0400EE8E RID: 61070
		private TArray<FLinearColor> _OceanRange;

		// Token: 0x0400EE8F RID: 61071
		internal static int __PropertyOffset_7;

		// Token: 0x0400EE90 RID: 61072
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400EE91 RID: 61073
		private static IntPtr __ExecuteUbergraph_BP_OceanHeight_Offset_NativeFunctionPtr;

		// Token: 0x020097A3 RID: 38819
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 144)]
		protected ref struct __ExecuteUbergraph_BP_OceanHeight_Offset_FunctionParams
		{
			// Token: 0x04031D6E RID: 204142
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
