using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GA;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using AkiClient.Game.Aki.Character.Role.Common.Data.Structure;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Abilities.GA
{
	// Token: 0x0200407F RID: 16511
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Common_Paralysis_Camera.GA_Common_Paralysis_Camera_C")]
	[UnrealStructLayout(1968, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1968)]
	public class GA_Common_Paralysis_Camera_C : Ga_Passive_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AECC RID: 175820 RVA: 0x00A6A377 File Offset: 0x00A68577
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Common_Paralysis_Camera_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Common_Paralysis_Camera.GA_Common_Paralysis_Camera_C");
			}
			return GA_Common_Paralysis_Camera_C._ClassPtr;
		}

		// Token: 0x0602AECD RID: 175821 RVA: 0x00A6A39C File Offset: 0x00A6859C
		public GA_Common_Paralysis_Camera_C() : this(BuiltinUtils.AllocNativeUObject(GA_Common_Paralysis_Camera_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AECE RID: 175822 RVA: 0x00A6A3C4 File Offset: 0x00A685C4
		[NullableContext(1)]
		public GA_Common_Paralysis_Camera_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Common_Paralysis_Camera_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007036 RID: 28726
		// (get) Token: 0x0602AECF RID: 175823 RVA: 0x00A6A3F8 File Offset: 0x00A685F8
		// (set) Token: 0x0602AED0 RID: 175824 RVA: 0x00A6A431 File Offset: 0x00A68631
		[Nullable(1)]
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Common_Paralysis_Camera_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Common_Paralysis_Camera_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007037 RID: 28727
		// (get) Token: 0x0602AED1 RID: 175825 RVA: 0x00A6A452 File Offset: 0x00A68652
		// (set) Token: 0x0602AED2 RID: 175826 RVA: 0x00A6A466 File Offset: 0x00A68666
		public unsafe FVector 相机位置
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Common_Paralysis_Camera_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Common_Paralysis_Camera_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007038 RID: 28728
		// (get) Token: 0x0602AED3 RID: 175827 RVA: 0x00A6A47B File Offset: 0x00A6867B
		// (set) Token: 0x0602AED4 RID: 175828 RVA: 0x00A6A48F File Offset: 0x00A6868F
		public unsafe BP_QTE_Camera_C 角色在屏幕___右侧___近战
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_QTE_Camera_C>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Common_Paralysis_Camera_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Common_Paralysis_Camera_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17007039 RID: 28729
		// (get) Token: 0x0602AED5 RID: 175829 RVA: 0x00A6A4A4 File Offset: 0x00A686A4
		// (set) Token: 0x0602AED6 RID: 175830 RVA: 0x00A6A4B8 File Offset: 0x00A686B8
		public unsafe BP_QTE_Camera_C 角色在屏幕___左侧___近战
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_QTE_Camera_C>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Common_Paralysis_Camera_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Common_Paralysis_Camera_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700703A RID: 28730
		// (get) Token: 0x0602AED7 RID: 175831 RVA: 0x00A6A4CD File Offset: 0x00A686CD
		// (set) Token: 0x0602AED8 RID: 175832 RVA: 0x00A6A4E1 File Offset: 0x00A686E1
		public unsafe BP_QTE_Camera_C 角色在屏幕___右侧___远程
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_QTE_Camera_C>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Common_Paralysis_Camera_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Common_Paralysis_Camera_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700703B RID: 28731
		// (get) Token: 0x0602AED9 RID: 175833 RVA: 0x00A6A4F6 File Offset: 0x00A686F6
		// (set) Token: 0x0602AEDA RID: 175834 RVA: 0x00A6A50A File Offset: 0x00A6870A
		public unsafe BP_QTE_Camera_C 角色在屏幕___左侧___远程
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_QTE_Camera_C>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Common_Paralysis_Camera_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Common_Paralysis_Camera_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x1700703C RID: 28732
		// (get) Token: 0x0602AEDB RID: 175835 RVA: 0x00A6A51F File Offset: 0x00A6871F
		// (set) Token: 0x0602AEDC RID: 175836 RVA: 0x00A6A533 File Offset: 0x00A68733
		public unsafe BP_QTE_Camera_C 怪物不处于相机内___左侧___近战
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_QTE_Camera_C>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Common_Paralysis_Camera_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Common_Paralysis_Camera_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x1700703D RID: 28733
		// (get) Token: 0x0602AEDD RID: 175837 RVA: 0x00A6A548 File Offset: 0x00A68748
		// (set) Token: 0x0602AEDE RID: 175838 RVA: 0x00A6A55C File Offset: 0x00A6875C
		public unsafe BP_QTE_Camera_C 怪物不处于相机内___右侧___近战
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_QTE_Camera_C>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Common_Paralysis_Camera_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Common_Paralysis_Camera_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x1700703E RID: 28734
		// (get) Token: 0x0602AEDF RID: 175839 RVA: 0x00A6A571 File Offset: 0x00A68771
		// (set) Token: 0x0602AEE0 RID: 175840 RVA: 0x00A6A585 File Offset: 0x00A68785
		public unsafe BP_QTE_Camera_C 怪物不处于相机内___左侧___远程
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_QTE_Camera_C>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Common_Paralysis_Camera_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Common_Paralysis_Camera_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x1700703F RID: 28735
		// (get) Token: 0x0602AEE1 RID: 175841 RVA: 0x00A6A59A File Offset: 0x00A6879A
		// (set) Token: 0x0602AEE2 RID: 175842 RVA: 0x00A6A5AE File Offset: 0x00A687AE
		public unsafe BP_QTE_Camera_C 怪物不处于相机内___右侧___远程
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_QTE_Camera_C>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Common_Paralysis_Camera_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Common_Paralysis_Camera_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17007040 RID: 28736
		// (get) Token: 0x0602AEE3 RID: 175843 RVA: 0x00A6A5C4 File Offset: 0x00A687C4
		// (set) Token: 0x0602AEE4 RID: 175844 RVA: 0x00A6A5FD File Offset: 0x00A687FD
		[Nullable(1)]
		public SCameraModifier_Settings Camera_Modify_Settings
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				SCameraModifier_Settings result;
				if ((result = this._Camera_Modify_Settings) == null)
				{
					result = (this._Camera_Modify_Settings = new SCameraModifier_Settings(base.NativePtr + (IntPtr)GA_Common_Paralysis_Camera_C.__PropertyOffset_10, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCameraModifier_Settings.StaticStruct(), base.NativePtr + (IntPtr)GA_Common_Paralysis_Camera_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007041 RID: 28737
		// (get) Token: 0x0602AEE5 RID: 175845 RVA: 0x00A6A61E File Offset: 0x00A6881E
		// (set) Token: 0x0602AEE6 RID: 175846 RVA: 0x00A6A62E File Offset: 0x00A6882E
		public unsafe int 怪物类型
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Common_Paralysis_Camera_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Common_Paralysis_Camera_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17007042 RID: 28738
		// (get) Token: 0x0602AEE7 RID: 175847 RVA: 0x00A6A640 File Offset: 0x00A68840
		// (set) Token: 0x0602AEE8 RID: 175848 RVA: 0x00A6A679 File Offset: 0x00A68879
		[Nullable(1)]
		public TArray<SCameraModifier_Condition> Camera_Modifier_Contions
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<SCameraModifier_Condition> result;
				if ((result = this._Camera_Modifier_Contions) == null)
				{
					result = (this._Camera_Modifier_Contions = new TArray<SCameraModifier_Condition>(base.NativePtr + (IntPtr)GA_Common_Paralysis_Camera_C.__PropertyOffset_12, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Camera_Modifier_Contions.CopyAssign(value);
			}
		}

		// Token: 0x0602AEE9 RID: 175849 RVA: 0x00A6A688 File Offset: 0x00A68888
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 计算镜头相对方位(float 怪物方位, float 右前界限, float 左前界限, float 右后界限, float 左后界限, ref int 镜头位置)
		{
			GA_Common_Paralysis_Camera_C.__计算镜头相对方位_FunctionParams* ptr = stackalloc GA_Common_Paralysis_Camera_C.__计算镜头相对方位_FunctionParams[(UIntPtr)43] + 15L / (long)sizeof(GA_Common_Paralysis_Camera_C.__计算镜头相对方位_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Common_Paralysis_Camera_C.__计算镜头相对方位_NativeFunctionPtr, (void*)ptr, 1);
			ptr->怪物方位 = 怪物方位;
			ptr->右前界限 = 右前界限;
			ptr->左前界限 = 左前界限;
			ptr->右后界限 = 右后界限;
			ptr->左后界限 = 左后界限;
			ptr->镜头位置 = 镜头位置;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Common_Paralysis_Camera_C.__计算镜头相对方位_NativeFunctionPtr, (void*)ptr);
			镜头位置 = ptr->镜头位置;
		}

		// Token: 0x0602AEEA RID: 175850 RVA: 0x00A6A6FE File Offset: 0x00A688FE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_256560A8464BEDA6591444843B3076A1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Common_Paralysis_Camera_C.__OnFinish_256560A8464BEDA6591444843B3076A1_NativeFunctionPtr, null);
		}

		// Token: 0x0602AEEB RID: 175851 RVA: 0x00A6A712 File Offset: 0x00A68912
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_98A95071428C8D18044A4CADAAA243F5()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Common_Paralysis_Camera_C.__OnFinish_98A95071428C8D18044A4CADAAA243F5_NativeFunctionPtr, null);
		}

		// Token: 0x0602AEEC RID: 175852 RVA: 0x00A6A726 File Offset: 0x00A68926
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Common_Paralysis_Camera_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602AEED RID: 175853 RVA: 0x00A6A73A File Offset: 0x00A6893A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Common_Paralysis_Camera_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602AEEE RID: 175854 RVA: 0x00A6A750 File Offset: 0x00A68950
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Common_Paralysis_Camera(int EntryPoint)
		{
			GA_Common_Paralysis_Camera_C.__ExecuteUbergraph_GA_Common_Paralysis_Camera_FunctionParams* ptr = stackalloc GA_Common_Paralysis_Camera_C.__ExecuteUbergraph_GA_Common_Paralysis_Camera_FunctionParams[(UIntPtr)343] + 15L / (long)sizeof(GA_Common_Paralysis_Camera_C.__ExecuteUbergraph_GA_Common_Paralysis_Camera_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Common_Paralysis_Camera_C.__ExecuteUbergraph_GA_Common_Paralysis_Camera_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Common_Paralysis_Camera_C.__ExecuteUbergraph_GA_Common_Paralysis_Camera_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AEEF RID: 175855 RVA: 0x00A6A79A File Offset: 0x00A6899A
		protected GA_Common_Paralysis_Camera_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017733 RID: 96051
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Common_Paralysis_Camera.GA_Common_Paralysis_Camera_C";

		// Token: 0x04017734 RID: 96052
		private static IntPtr _ClassPtr;

		// Token: 0x04017735 RID: 96053
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017736 RID: 96054
		internal new static int __PropertyOffset_0;

		// Token: 0x04017737 RID: 96055
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017738 RID: 96056
		internal new static int __PropertyOffset_1;

		// Token: 0x04017739 RID: 96057
		internal new static int __PropertyOffset_2;

		// Token: 0x0401773A RID: 96058
		internal new static int __PropertyOffset_3;

		// Token: 0x0401773B RID: 96059
		internal static int __PropertyOffset_4;

		// Token: 0x0401773C RID: 96060
		internal static int __PropertyOffset_5;

		// Token: 0x0401773D RID: 96061
		internal static int __PropertyOffset_6;

		// Token: 0x0401773E RID: 96062
		internal static int __PropertyOffset_7;

		// Token: 0x0401773F RID: 96063
		internal static int __PropertyOffset_8;

		// Token: 0x04017740 RID: 96064
		internal static int __PropertyOffset_9;

		// Token: 0x04017741 RID: 96065
		internal static int __PropertyOffset_10;

		// Token: 0x04017742 RID: 96066
		private SCameraModifier_Settings _Camera_Modify_Settings;

		// Token: 0x04017743 RID: 96067
		internal static int __PropertyOffset_11;

		// Token: 0x04017744 RID: 96068
		internal static int __PropertyOffset_12;

		// Token: 0x04017745 RID: 96069
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SCameraModifier_Condition> _Camera_Modifier_Contions;

		// Token: 0x04017746 RID: 96070
		private static IntPtr __计算镜头相对方位_NativeFunctionPtr;

		// Token: 0x04017747 RID: 96071
		private static IntPtr __OnFinish_256560A8464BEDA6591444843B3076A1_NativeFunctionPtr;

		// Token: 0x04017748 RID: 96072
		private static IntPtr __OnFinish_98A95071428C8D18044A4CADAAA243F5_NativeFunctionPtr;

		// Token: 0x04017749 RID: 96073
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x0401774A RID: 96074
		private static IntPtr __ExecuteUbergraph_GA_Common_Paralysis_Camera_NativeFunctionPtr;

		// Token: 0x0200A298 RID: 41624
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 28)]
		protected ref struct __计算镜头相对方位_FunctionParams
		{
			// Token: 0x04033046 RID: 208966
			[FieldOffset(0)]
			public float 怪物方位;

			// Token: 0x04033047 RID: 208967
			[FieldOffset(4)]
			public float 右前界限;

			// Token: 0x04033048 RID: 208968
			[FieldOffset(8)]
			public float 左前界限;

			// Token: 0x04033049 RID: 208969
			[FieldOffset(12)]
			public float 右后界限;

			// Token: 0x0403304A RID: 208970
			[FieldOffset(16)]
			public float 左后界限;

			// Token: 0x0403304B RID: 208971
			[FieldOffset(20)]
			public int 镜头位置;
		}

		// Token: 0x0200A299 RID: 41625
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 328)]
		protected ref struct __ExecuteUbergraph_GA_Common_Paralysis_Camera_FunctionParams
		{
			// Token: 0x0403304C RID: 208972
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
