using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.PloarLight.MingHePloarLight
{
	// Token: 0x02003BA1 RID: 15265
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/PloarLight/MingHePloarLight/BP_MingHePloarLight.BP_MingHePloarLight_C")]
	[UnrealStructLayout(1456, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1456)]
	public class BP_MingHePloarLight_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021EA9 RID: 138921 RVA: 0x0095731C File Offset: 0x0095551C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_MingHePloarLight_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/PloarLight/MingHePloarLight/BP_MingHePloarLight.BP_MingHePloarLight_C");
			}
			return BP_MingHePloarLight_C._ClassPtr;
		}

		// Token: 0x06021EAA RID: 138922 RVA: 0x00957340 File Offset: 0x00955540
		public BP_MingHePloarLight_C() : this(BuiltinUtils.AllocNativeUObject(BP_MingHePloarLight_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021EAB RID: 138923 RVA: 0x00957368 File Offset: 0x00955568
		[NullableContext(1)]
		public BP_MingHePloarLight_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_MingHePloarLight_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003DB6 RID: 15798
		// (get) Token: 0x06021EAC RID: 138924 RVA: 0x0095739C File Offset: 0x0095559C
		// (set) Token: 0x06021EAD RID: 138925 RVA: 0x009573D5 File Offset: 0x009555D5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_MingHePloarLight_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_MingHePloarLight_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003DB7 RID: 15799
		// (get) Token: 0x06021EAE RID: 138926 RVA: 0x009573F6 File Offset: 0x009555F6
		// (set) Token: 0x06021EAF RID: 138927 RVA: 0x0095740A File Offset: 0x0095560A
		public unsafe UTextRenderComponent BP_PloarLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextRenderComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MingHePloarLight_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MingHePloarLight_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003DB8 RID: 15800
		// (get) Token: 0x06021EB0 RID: 138928 RVA: 0x0095741F File Offset: 0x0095561F
		// (set) Token: 0x06021EB1 RID: 138929 RVA: 0x00957433 File Offset: 0x00955633
		public unsafe UStaticMeshComponent SM_NewPloarLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MingHePloarLight_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MingHePloarLight_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003DB9 RID: 15801
		// (get) Token: 0x06021EB2 RID: 138930 RVA: 0x00957448 File Offset: 0x00955648
		// (set) Token: 0x06021EB3 RID: 138931 RVA: 0x0095745C File Offset: 0x0095565C
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MingHePloarLight_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MingHePloarLight_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003DBA RID: 15802
		// (get) Token: 0x06021EB4 RID: 138932 RVA: 0x00957471 File Offset: 0x00955671
		// (set) Token: 0x06021EB5 RID: 138933 RVA: 0x00957481 File Offset: 0x00955681
		public unsafe bool DebugView
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MingHePloarLight_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MingHePloarLight_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003DBB RID: 15803
		// (get) Token: 0x06021EB6 RID: 138934 RVA: 0x00957492 File Offset: 0x00955692
		// (set) Token: 0x06021EB7 RID: 138935 RVA: 0x009574A2 File Offset: 0x009556A2
		public unsafe float Location_Z
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MingHePloarLight_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MingHePloarLight_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003DBC RID: 15804
		// (get) Token: 0x06021EB8 RID: 138936 RVA: 0x009574B3 File Offset: 0x009556B3
		// (set) Token: 0x06021EB9 RID: 138937 RVA: 0x009574C7 File Offset: 0x009556C7
		public unsafe FRotator Rotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MingHePloarLight_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MingHePloarLight_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003DBD RID: 15805
		// (get) Token: 0x06021EBA RID: 138938 RVA: 0x009574DC File Offset: 0x009556DC
		// (set) Token: 0x06021EBB RID: 138939 RVA: 0x009574F0 File Offset: 0x009556F0
		public unsafe FVector Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MingHePloarLight_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MingHePloarLight_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003DBE RID: 15806
		// (get) Token: 0x06021EBC RID: 138940 RVA: 0x00957505 File Offset: 0x00955705
		// (set) Token: 0x06021EBD RID: 138941 RVA: 0x00957519 File Offset: 0x00955719
		public unsafe UMaterialInstanceDynamic Material_DMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MingHePloarLight_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MingHePloarLight_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17003DBF RID: 15807
		// (get) Token: 0x06021EBE RID: 138942 RVA: 0x0095752E File Offset: 0x0095572E
		// (set) Token: 0x06021EBF RID: 138943 RVA: 0x00957542 File Offset: 0x00955742
		public unsafe UStaticMesh StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MingHePloarLight_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MingHePloarLight_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17003DC0 RID: 15808
		// (get) Token: 0x06021EC0 RID: 138944 RVA: 0x00957557 File Offset: 0x00955757
		// (set) Token: 0x06021EC1 RID: 138945 RVA: 0x0095756B File Offset: 0x0095576B
		public unsafe UMaterialInstance Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MingHePloarLight_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MingHePloarLight_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17003DC1 RID: 15809
		// (get) Token: 0x06021EC2 RID: 138946 RVA: 0x00957580 File Offset: 0x00955780
		// (set) Token: 0x06021EC3 RID: 138947 RVA: 0x00957594 File Offset: 0x00955794
		public unsafe FLinearColor ColorTint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MingHePloarLight_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MingHePloarLight_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17003DC2 RID: 15810
		// (get) Token: 0x06021EC4 RID: 138948 RVA: 0x009575A9 File Offset: 0x009557A9
		// (set) Token: 0x06021EC5 RID: 138949 RVA: 0x009575B9 File Offset: 0x009557B9
		public unsafe float MaskContrast
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MingHePloarLight_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MingHePloarLight_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003DC3 RID: 15811
		// (get) Token: 0x06021EC6 RID: 138950 RVA: 0x009575CA File Offset: 0x009557CA
		// (set) Token: 0x06021EC7 RID: 138951 RVA: 0x009575DA File Offset: 0x009557DA
		public unsafe float Opacity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MingHePloarLight_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MingHePloarLight_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17003DC4 RID: 15812
		// (get) Token: 0x06021EC8 RID: 138952 RVA: 0x009575EB File Offset: 0x009557EB
		// (set) Token: 0x06021EC9 RID: 138953 RVA: 0x009575FB File Offset: 0x009557FB
		public unsafe bool Is_Android
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MingHePloarLight_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MingHePloarLight_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003DC5 RID: 15813
		// (get) Token: 0x06021ECA RID: 138954 RVA: 0x0095760C File Offset: 0x0095580C
		// (set) Token: 0x06021ECB RID: 138955 RVA: 0x00957620 File Offset: 0x00955820
		public unsafe UMaterialInstance ES3_Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MingHePloarLight_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MingHePloarLight_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x17003DC6 RID: 15814
		// (get) Token: 0x06021ECC RID: 138956 RVA: 0x00957635 File Offset: 0x00955835
		// (set) Token: 0x06021ECD RID: 138957 RVA: 0x00957649 File Offset: 0x00955849
		public unsafe UMaterialInstanceDynamic Material_DMI_ES3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MingHePloarLight_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MingHePloarLight_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x06021ECE RID: 138958 RVA: 0x0095765E File Offset: 0x0095585E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Is_ES3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MingHePloarLight_C.__Is_ES3_NativeFunctionPtr, null);
		}

		// Token: 0x06021ECF RID: 138959 RVA: 0x00957672 File Offset: 0x00955872
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MingHePloarLight_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021ED0 RID: 138960 RVA: 0x00957686 File Offset: 0x00955886
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MingHePloarLight_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021ED1 RID: 138961 RVA: 0x0095769B File Offset: 0x0095589B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MingHePloarLight_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06021ED2 RID: 138962 RVA: 0x009576AF File Offset: 0x009558AF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MingHePloarLight_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021ED3 RID: 138963 RVA: 0x009576C4 File Offset: 0x009558C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_MingHePloarLight(int EntryPoint)
		{
			BP_MingHePloarLight_C.__ExecuteUbergraph_BP_MingHePloarLight_FunctionParams* ptr = stackalloc BP_MingHePloarLight_C.__ExecuteUbergraph_BP_MingHePloarLight_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MingHePloarLight_C.__ExecuteUbergraph_BP_MingHePloarLight_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MingHePloarLight_C.__ExecuteUbergraph_BP_MingHePloarLight_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MingHePloarLight_C.__ExecuteUbergraph_BP_MingHePloarLight_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021ED4 RID: 138964 RVA: 0x0095770B File Offset: 0x0095590B
		protected BP_MingHePloarLight_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040111FD RID: 70141
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/PloarLight/MingHePloarLight/BP_MingHePloarLight.BP_MingHePloarLight_C";

		// Token: 0x040111FE RID: 70142
		private static IntPtr _ClassPtr;

		// Token: 0x040111FF RID: 70143
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011200 RID: 70144
		internal static int __PropertyOffset_0;

		// Token: 0x04011201 RID: 70145
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011202 RID: 70146
		internal static int __PropertyOffset_1;

		// Token: 0x04011203 RID: 70147
		internal static int __PropertyOffset_2;

		// Token: 0x04011204 RID: 70148
		internal static int __PropertyOffset_3;

		// Token: 0x04011205 RID: 70149
		internal static int __PropertyOffset_4;

		// Token: 0x04011206 RID: 70150
		internal static int __PropertyOffset_5;

		// Token: 0x04011207 RID: 70151
		internal static int __PropertyOffset_6;

		// Token: 0x04011208 RID: 70152
		internal static int __PropertyOffset_7;

		// Token: 0x04011209 RID: 70153
		internal static int __PropertyOffset_8;

		// Token: 0x0401120A RID: 70154
		internal static int __PropertyOffset_9;

		// Token: 0x0401120B RID: 70155
		internal static int __PropertyOffset_10;

		// Token: 0x0401120C RID: 70156
		internal static int __PropertyOffset_11;

		// Token: 0x0401120D RID: 70157
		internal static int __PropertyOffset_12;

		// Token: 0x0401120E RID: 70158
		internal static int __PropertyOffset_13;

		// Token: 0x0401120F RID: 70159
		internal static int __PropertyOffset_14;

		// Token: 0x04011210 RID: 70160
		internal static int __PropertyOffset_15;

		// Token: 0x04011211 RID: 70161
		internal static int __PropertyOffset_16;

		// Token: 0x04011212 RID: 70162
		private static IntPtr __Is_ES3_NativeFunctionPtr;

		// Token: 0x04011213 RID: 70163
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011214 RID: 70164
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011215 RID: 70165
		private static IntPtr __ExecuteUbergraph_BP_MingHePloarLight_NativeFunctionPtr;

		// Token: 0x02009B72 RID: 39794
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_MingHePloarLight_FunctionParams
		{
			// Token: 0x04032365 RID: 205669
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
