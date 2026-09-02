using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.YangYangBirds
{
	// Token: 0x020039F7 RID: 14839
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/YangYangBirds/BP_YangyangBirdssss_Skill.BP_YangyangBirdssss_Skill_C")]
	[UnrealStructLayout(1056, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1056)]
	public class BP_YangyangBirdssss_Skill_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601E2A5 RID: 123557 RVA: 0x008EE3A3 File Offset: 0x008EC5A3
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_YangyangBirdssss_Skill_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/YangYangBirds/BP_YangyangBirdssss_Skill.BP_YangyangBirdssss_Skill_C");
			}
			return BP_YangyangBirdssss_Skill_C._ClassPtr;
		}

		// Token: 0x0601E2A6 RID: 123558 RVA: 0x008EE3C8 File Offset: 0x008EC5C8
		public BP_YangyangBirdssss_Skill_C() : this(BuiltinUtils.AllocNativeUObject(BP_YangyangBirdssss_Skill_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E2A7 RID: 123559 RVA: 0x008EE3F0 File Offset: 0x008EC5F0
		[NullableContext(1)]
		public BP_YangyangBirdssss_Skill_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_YangyangBirdssss_Skill_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170028C8 RID: 10440
		// (get) Token: 0x0601E2A8 RID: 123560 RVA: 0x008EE424 File Offset: 0x008EC624
		// (set) Token: 0x0601E2A9 RID: 123561 RVA: 0x008EE45D File Offset: 0x008EC65D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_YangyangBirdssss_Skill_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_YangyangBirdssss_Skill_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170028C9 RID: 10441
		// (get) Token: 0x0601E2AA RID: 123562 RVA: 0x008EE47E File Offset: 0x008EC67E
		// (set) Token: 0x0601E2AB RID: 123563 RVA: 0x008EE492 File Offset: 0x008EC692
		public unsafe UNiagaraComponent NS_YY_Birds_Skill
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_YangyangBirdssss_Skill_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_YangyangBirdssss_Skill_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170028CA RID: 10442
		// (get) Token: 0x0601E2AC RID: 123564 RVA: 0x008EE4A7 File Offset: 0x008EC6A7
		// (set) Token: 0x0601E2AD RID: 123565 RVA: 0x008EE4BB File Offset: 0x008EC6BB
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_YangyangBirdssss_Skill_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_YangyangBirdssss_Skill_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x0601E2AE RID: 123566 RVA: 0x008EE4D0 File Offset: 0x008EC6D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Deactivate()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_YangyangBirdssss_Skill_C.__Deactivate_NativeFunctionPtr, null);
		}

		// Token: 0x0601E2AF RID: 123567 RVA: 0x008EE4E4 File Offset: 0x008EC6E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_YangyangBirdssss_Skill(int EntryPoint)
		{
			BP_YangyangBirdssss_Skill_C.__ExecuteUbergraph_BP_YangyangBirdssss_Skill_FunctionParams* ptr = stackalloc BP_YangyangBirdssss_Skill_C.__ExecuteUbergraph_BP_YangyangBirdssss_Skill_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_YangyangBirdssss_Skill_C.__ExecuteUbergraph_BP_YangyangBirdssss_Skill_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_YangyangBirdssss_Skill_C.__ExecuteUbergraph_BP_YangyangBirdssss_Skill_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_YangyangBirdssss_Skill_C.__ExecuteUbergraph_BP_YangyangBirdssss_Skill_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E2B0 RID: 123568 RVA: 0x008EE52B File Offset: 0x008EC72B
		protected BP_YangyangBirdssss_Skill_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400ED1E RID: 60702
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/YangYangBirds/BP_YangyangBirdssss_Skill.BP_YangyangBirdssss_Skill_C";

		// Token: 0x0400ED1F RID: 60703
		private static IntPtr _ClassPtr;

		// Token: 0x0400ED20 RID: 60704
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400ED21 RID: 60705
		internal static int __PropertyOffset_0;

		// Token: 0x0400ED22 RID: 60706
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400ED23 RID: 60707
		internal static int __PropertyOffset_1;

		// Token: 0x0400ED24 RID: 60708
		internal static int __PropertyOffset_2;

		// Token: 0x0400ED25 RID: 60709
		private static IntPtr __Deactivate_NativeFunctionPtr;

		// Token: 0x0400ED26 RID: 60710
		private static IntPtr __ExecuteUbergraph_BP_YangyangBirdssss_Skill_NativeFunctionPtr;

		// Token: 0x0200977A RID: 38778
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_YangyangBirdssss_Skill_FunctionParams
		{
			// Token: 0x04031D2F RID: 204079
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
