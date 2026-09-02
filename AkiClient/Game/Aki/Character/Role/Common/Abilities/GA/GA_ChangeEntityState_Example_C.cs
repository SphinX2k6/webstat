using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GA;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Abilities.GA
{
	// Token: 0x02004077 RID: 16503
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_ChangeEntityState_Example.GA_ChangeEntityState_Example_C")]
	[UnrealStructLayout(1536, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1532)]
	public class GA_ChangeEntityState_Example_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AE33 RID: 175667 RVA: 0x00A68A67 File Offset: 0x00A66C67
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_ChangeEntityState_Example_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_ChangeEntityState_Example.GA_ChangeEntityState_Example_C");
			}
			return GA_ChangeEntityState_Example_C._ClassPtr;
		}

		// Token: 0x0602AE34 RID: 175668 RVA: 0x00A68A8C File Offset: 0x00A66C8C
		public GA_ChangeEntityState_Example_C() : this(BuiltinUtils.AllocNativeUObject(GA_ChangeEntityState_Example_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AE35 RID: 175669 RVA: 0x00A68AB4 File Offset: 0x00A66CB4
		public GA_ChangeEntityState_Example_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_ChangeEntityState_Example_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700701A RID: 28698
		// (get) Token: 0x0602AE36 RID: 175670 RVA: 0x00A68AE8 File Offset: 0x00A66CE8
		// (set) Token: 0x0602AE37 RID: 175671 RVA: 0x00A68B21 File Offset: 0x00A66D21
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_ChangeEntityState_Example_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_ChangeEntityState_Example_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700701B RID: 28699
		// (get) Token: 0x0602AE38 RID: 175672 RVA: 0x00A68B42 File Offset: 0x00A66D42
		// (set) Token: 0x0602AE39 RID: 175673 RVA: 0x00A68B52 File Offset: 0x00A66D52
		public unsafe bool 命中目标
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_ChangeEntityState_Example_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_ChangeEntityState_Example_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700701C RID: 28700
		// (get) Token: 0x0602AE3A RID: 175674 RVA: 0x00A68B63 File Offset: 0x00A66D63
		// (set) Token: 0x0602AE3B RID: 175675 RVA: 0x00A68B73 File Offset: 0x00A66D73
		public unsafe int 施法者实体id
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_ChangeEntityState_Example_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_ChangeEntityState_Example_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700701D RID: 28701
		// (get) Token: 0x0602AE3C RID: 175676 RVA: 0x00A68B84 File Offset: 0x00A66D84
		// (set) Token: 0x0602AE3D RID: 175677 RVA: 0x00A68BBD File Offset: 0x00A66DBD
		public TArray<int> 卡牌实体id
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._卡牌实体id) == null)
				{
					result = (this._卡牌实体id = new TArray<int>(base.NativePtr + (IntPtr)GA_ChangeEntityState_Example_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				this.卡牌实体id.CopyAssign(value);
			}
		}

		// Token: 0x1700701E RID: 28702
		// (get) Token: 0x0602AE3E RID: 175678 RVA: 0x00A68BCC File Offset: 0x00A66DCC
		// (set) Token: 0x0602AE3F RID: 175679 RVA: 0x00A68C05 File Offset: 0x00A66E05
		public TArray<string> 卡牌黑板数组
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._卡牌黑板数组) == null)
				{
					result = (this._卡牌黑板数组 = new TArray<string>(base.NativePtr + (IntPtr)GA_ChangeEntityState_Example_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				this.卡牌黑板数组.CopyAssign(value);
			}
		}

		// Token: 0x1700701F RID: 28703
		// (get) Token: 0x0602AE40 RID: 175680 RVA: 0x00A68C13 File Offset: 0x00A66E13
		// (set) Token: 0x0602AE41 RID: 175681 RVA: 0x00A68C23 File Offset: 0x00A66E23
		public unsafe int 随机卡牌
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_ChangeEntityState_Example_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_ChangeEntityState_Example_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x0602AE42 RID: 175682 RVA: 0x00A68C34 File Offset: 0x00A66E34
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_A8850AB04A2EE1E2656E5FB4035E8B6F()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_ChangeEntityState_Example_C.__OnFinish_A8850AB04A2EE1E2656E5FB4035E8B6F_NativeFunctionPtr, null);
		}

		// Token: 0x0602AE43 RID: 175683 RVA: 0x00A68C48 File Offset: 0x00A66E48
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_ChangeEntityState_Example_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602AE44 RID: 175684 RVA: 0x00A68C5C File Offset: 0x00A66E5C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_ChangeEntityState_Example_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602AE45 RID: 175685 RVA: 0x00A68C74 File Offset: 0x00A66E74
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_ChangeEntityState_Example(int EntryPoint)
		{
			GA_ChangeEntityState_Example_C.__ExecuteUbergraph_GA_ChangeEntityState_Example_FunctionParams* ptr = stackalloc GA_ChangeEntityState_Example_C.__ExecuteUbergraph_GA_ChangeEntityState_Example_FunctionParams[(UIntPtr)663] + 15L / (long)sizeof(GA_ChangeEntityState_Example_C.__ExecuteUbergraph_GA_ChangeEntityState_Example_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_ChangeEntityState_Example_C.__ExecuteUbergraph_GA_ChangeEntityState_Example_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_ChangeEntityState_Example_C.__ExecuteUbergraph_GA_ChangeEntityState_Example_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AE46 RID: 175686 RVA: 0x00A68CBE File Offset: 0x00A66EBE
		protected GA_ChangeEntityState_Example_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040176C2 RID: 95938
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_ChangeEntityState_Example.GA_ChangeEntityState_Example_C";

		// Token: 0x040176C3 RID: 95939
		private static IntPtr _ClassPtr;

		// Token: 0x040176C4 RID: 95940
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040176C5 RID: 95941
		internal new static int __PropertyOffset_0;

		// Token: 0x040176C6 RID: 95942
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040176C7 RID: 95943
		internal new static int __PropertyOffset_1;

		// Token: 0x040176C8 RID: 95944
		internal new static int __PropertyOffset_2;

		// Token: 0x040176C9 RID: 95945
		internal new static int __PropertyOffset_3;

		// Token: 0x040176CA RID: 95946
		[Nullable(2)]
		private TArray<int> _卡牌实体id;

		// Token: 0x040176CB RID: 95947
		internal static int __PropertyOffset_4;

		// Token: 0x040176CC RID: 95948
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _卡牌黑板数组;

		// Token: 0x040176CD RID: 95949
		internal static int __PropertyOffset_5;

		// Token: 0x040176CE RID: 95950
		private static IntPtr __OnFinish_A8850AB04A2EE1E2656E5FB4035E8B6F_NativeFunctionPtr;

		// Token: 0x040176CF RID: 95951
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x040176D0 RID: 95952
		private static IntPtr __ExecuteUbergraph_GA_ChangeEntityState_Example_NativeFunctionPtr;

		// Token: 0x0200A274 RID: 41588
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 648)]
		protected ref struct __ExecuteUbergraph_GA_ChangeEntityState_Example_FunctionParams
		{
			// Token: 0x04033022 RID: 208930
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
