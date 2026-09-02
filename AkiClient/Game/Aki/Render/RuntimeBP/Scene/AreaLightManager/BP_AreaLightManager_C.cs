using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Scene.AreaLightManager.Asset;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.AreaLightManager
{
	// Token: 0x02003B23 RID: 15139
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/AreaLightManager/BP_AreaLightManager.BP_AreaLightManager_C")]
	[UnrealStructLayout(1136, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1132)]
	public class BP_AreaLightManager_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020927 RID: 133415 RVA: 0x0093079C File Offset: 0x0092E99C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_AreaLightManager_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/AreaLightManager/BP_AreaLightManager.BP_AreaLightManager_C");
			}
			return BP_AreaLightManager_C._ClassPtr;
		}

		// Token: 0x06020928 RID: 133416 RVA: 0x009307C0 File Offset: 0x0092E9C0
		public BP_AreaLightManager_C() : this(BuiltinUtils.AllocNativeUObject(BP_AreaLightManager_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020929 RID: 133417 RVA: 0x009307E8 File Offset: 0x0092E9E8
		public BP_AreaLightManager_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_AreaLightManager_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003631 RID: 13873
		// (get) Token: 0x0602092A RID: 133418 RVA: 0x0093081C File Offset: 0x0092EA1C
		// (set) Token: 0x0602092B RID: 133419 RVA: 0x00930855 File Offset: 0x0092EA55
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_AreaLightManager_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_AreaLightManager_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003632 RID: 13874
		// (get) Token: 0x0602092C RID: 133420 RVA: 0x00930876 File Offset: 0x0092EA76
		// (set) Token: 0x0602092D RID: 133421 RVA: 0x0093088A File Offset: 0x0092EA8A
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AreaLightManager_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AreaLightManager_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003633 RID: 13875
		// (get) Token: 0x0602092E RID: 133422 RVA: 0x009308A0 File Offset: 0x0092EAA0
		// (set) Token: 0x0602092F RID: 133423 RVA: 0x009308D9 File Offset: 0x0092EAD9
		public TMap<int, SAreaAdjacencyList> AreaAdjacencyList
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, SAreaAdjacencyList> result;
				if ((result = this._AreaAdjacencyList) == null)
				{
					result = (this._AreaAdjacencyList = new TMap<int, SAreaAdjacencyList>(base.NativePtr + (IntPtr)BP_AreaLightManager_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				this.AreaAdjacencyList.CopyAssign(value);
			}
		}

		// Token: 0x17003634 RID: 13876
		// (get) Token: 0x06020930 RID: 133424 RVA: 0x009308E7 File Offset: 0x0092EAE7
		// (set) Token: 0x06020931 RID: 133425 RVA: 0x009308F7 File Offset: 0x0092EAF7
		public unsafe int Player_in_Area_Index
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AreaLightManager_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AreaLightManager_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x06020932 RID: 133426 RVA: 0x00930908 File Offset: 0x0092EB08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CheckPlatform([Nullable(2)] AActor WordlContext, string Tag, ref bool bSaveLight)
		{
			BP_AreaLightManager_C.__CheckPlatform_FunctionParams* ptr = stackalloc BP_AreaLightManager_C.__CheckPlatform_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_AreaLightManager_C.__CheckPlatform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AreaLightManager_C.__CheckPlatform_NativeFunctionPtr, (void*)ptr, 1);
			ptr->WordlContext = ((WordlContext != null) ? WordlContext.NativePtr : IntPtr.Zero);
			FString.CopyFrom((void*)(&ptr->Tag), Tag);
			ptr->bSaveLight = bSaveLight;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AreaLightManager_C.__CheckPlatform_NativeFunctionPtr, (void*)ptr);
			bSaveLight = ptr->bSaveLight;
			UnrealReflectionUtils.DestroyStruct(BP_AreaLightManager_C.__CheckPlatform_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06020933 RID: 133427 RVA: 0x0093098C File Offset: 0x0092EB8C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetAreaIndexFromTag(string Tag, ref int AreaIndex)
		{
			BP_AreaLightManager_C.__GetAreaIndexFromTag_FunctionParams* ptr = stackalloc BP_AreaLightManager_C.__GetAreaIndexFromTag_FunctionParams[(UIntPtr)167] + 15L / (long)sizeof(BP_AreaLightManager_C.__GetAreaIndexFromTag_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AreaLightManager_C.__GetAreaIndexFromTag_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->Tag), Tag);
			ptr->AreaIndex = AreaIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AreaLightManager_C.__GetAreaIndexFromTag_NativeFunctionPtr, (void*)ptr);
			AreaIndex = ptr->AreaIndex;
			UnrealReflectionUtils.DestroyStruct(BP_AreaLightManager_C.__GetAreaIndexFromTag_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06020934 RID: 133428 RVA: 0x009309FC File Offset: 0x0092EBFC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AddAreaAdjacencyList(int Key, int Value)
		{
			BP_AreaLightManager_C.__AddAreaAdjacencyList_FunctionParams* ptr = stackalloc BP_AreaLightManager_C.__AddAreaAdjacencyList_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(BP_AreaLightManager_C.__AddAreaAdjacencyList_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AreaLightManager_C.__AddAreaAdjacencyList_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Key = Key;
			ptr->Value = Value;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AreaLightManager_C.__AddAreaAdjacencyList_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020935 RID: 133429 RVA: 0x00930A4C File Offset: 0x0092EC4C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void HandlePlayerCrossArea(int PlayerInAreaIndex)
		{
			BP_AreaLightManager_C.__HandlePlayerCrossArea_FunctionParams* ptr = stackalloc BP_AreaLightManager_C.__HandlePlayerCrossArea_FunctionParams[(UIntPtr)207] + 15L / (long)sizeof(BP_AreaLightManager_C.__HandlePlayerCrossArea_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AreaLightManager_C.__HandlePlayerCrossArea_NativeFunctionPtr, (void*)ptr, 1);
			ptr->PlayerInAreaIndex = PlayerInAreaIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AreaLightManager_C.__HandlePlayerCrossArea_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020936 RID: 133430 RVA: 0x00930A95 File Offset: 0x0092EC95
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AreaLightManager_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06020937 RID: 133431 RVA: 0x00930AA9 File Offset: 0x0092ECA9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AreaLightManager_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020938 RID: 133432 RVA: 0x00930AC0 File Offset: 0x0092ECC0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_AreaLightManager(int EntryPoint)
		{
			BP_AreaLightManager_C.__ExecuteUbergraph_BP_AreaLightManager_FunctionParams* ptr = stackalloc BP_AreaLightManager_C.__ExecuteUbergraph_BP_AreaLightManager_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_AreaLightManager_C.__ExecuteUbergraph_BP_AreaLightManager_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AreaLightManager_C.__ExecuteUbergraph_BP_AreaLightManager_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AreaLightManager_C.__ExecuteUbergraph_BP_AreaLightManager_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020939 RID: 133433 RVA: 0x00930B07 File Offset: 0x0092ED07
		protected BP_AreaLightManager_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040104CA RID: 66762
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/AreaLightManager/BP_AreaLightManager.BP_AreaLightManager_C";

		// Token: 0x040104CB RID: 66763
		private static IntPtr _ClassPtr;

		// Token: 0x040104CC RID: 66764
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040104CD RID: 66765
		internal static int __PropertyOffset_0;

		// Token: 0x040104CE RID: 66766
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040104CF RID: 66767
		internal static int __PropertyOffset_1;

		// Token: 0x040104D0 RID: 66768
		internal static int __PropertyOffset_2;

		// Token: 0x040104D1 RID: 66769
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<int, SAreaAdjacencyList> _AreaAdjacencyList;

		// Token: 0x040104D2 RID: 66770
		internal static int __PropertyOffset_3;

		// Token: 0x040104D3 RID: 66771
		private static IntPtr __CheckPlatform_NativeFunctionPtr;

		// Token: 0x040104D4 RID: 66772
		private static IntPtr __GetAreaIndexFromTag_NativeFunctionPtr;

		// Token: 0x040104D5 RID: 66773
		private static IntPtr __AddAreaAdjacencyList_NativeFunctionPtr;

		// Token: 0x040104D6 RID: 66774
		private static IntPtr __HandlePlayerCrossArea_NativeFunctionPtr;

		// Token: 0x040104D7 RID: 66775
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040104D8 RID: 66776
		private static IntPtr __ExecuteUbergraph_BP_AreaLightManager_NativeFunctionPtr;

		// Token: 0x020099E5 RID: 39397
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __CheckPlatform_FunctionParams
		{
			// Token: 0x040320AC RID: 204972
			[FieldOffset(0)]
			public IntPtr WordlContext;

			// Token: 0x040320AD RID: 204973
			[FieldOffset(8)]
			public FString Tag;

			// Token: 0x040320AE RID: 204974
			[FieldOffset(24)]
			public bool bSaveLight;
		}

		// Token: 0x020099E6 RID: 39398
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 152)]
		protected ref struct __GetAreaIndexFromTag_FunctionParams
		{
			// Token: 0x040320AF RID: 204975
			[FieldOffset(0)]
			public FString Tag;

			// Token: 0x040320B0 RID: 204976
			[FieldOffset(16)]
			public int AreaIndex;
		}

		// Token: 0x020099E7 RID: 39399
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected ref struct __AddAreaAdjacencyList_FunctionParams
		{
			// Token: 0x040320B1 RID: 204977
			[FieldOffset(0)]
			public int Key;

			// Token: 0x040320B2 RID: 204978
			[FieldOffset(4)]
			public int Value;
		}

		// Token: 0x020099E8 RID: 39400
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 192)]
		protected ref struct __HandlePlayerCrossArea_FunctionParams
		{
			// Token: 0x040320B3 RID: 204979
			[FieldOffset(0)]
			public int PlayerInAreaIndex;
		}

		// Token: 0x020099E9 RID: 39401
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __ExecuteUbergraph_BP_AreaLightManager_FunctionParams
		{
			// Token: 0x040320B4 RID: 204980
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
