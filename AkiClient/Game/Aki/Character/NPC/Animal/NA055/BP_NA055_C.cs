using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonSmallAnimal;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA055
{
	// Token: 0x02004131 RID: 16689
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA055/BP_NA055.BP_NA055_C")]
	[UnrealStructLayout(2256, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2256)]
	public class BP_NA055_C : BP_CommonSmallAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C5C9 RID: 181705 RVA: 0x00A9EC28 File Offset: 0x00A9CE28
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA055_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA055/BP_NA055.BP_NA055_C");
			}
			return BP_NA055_C._ClassPtr;
		}

		// Token: 0x0602C5CA RID: 181706 RVA: 0x00A9EC4C File Offset: 0x00A9CE4C
		public BP_NA055_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA055_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C5CB RID: 181707 RVA: 0x00A9EC74 File Offset: 0x00A9CE74
		public BP_NA055_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA055_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007764 RID: 30564
		// (get) Token: 0x0602C5CC RID: 181708 RVA: 0x00A9ECA8 File Offset: 0x00A9CEA8
		// (set) Token: 0x0602C5CD RID: 181709 RVA: 0x00A9ECE1 File Offset: 0x00A9CEE1
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_NA055_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_NA055_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007765 RID: 30565
		// (get) Token: 0x0602C5CE RID: 181710 RVA: 0x00A9ED02 File Offset: 0x00A9CF02
		// (set) Token: 0x0602C5CF RID: 181711 RVA: 0x00A9ED16 File Offset: 0x00A9CF16
		[Nullable(2)]
		public unsafe UKuroAdjustableCapsuleComponent ROOT
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroAdjustableCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA055_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA055_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0602C5D0 RID: 181712 RVA: 0x00A9ED2B File Offset: 0x00A9CF2B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NA055_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602C5D1 RID: 181713 RVA: 0x00A9ED3F File Offset: 0x00A9CF3F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NA055_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602C5D2 RID: 181714 RVA: 0x00A9ED54 File Offset: 0x00A9CF54
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_NA055(int EntryPoint)
		{
			BP_NA055_C.__ExecuteUbergraph_BP_NA055_FunctionParams* ptr = stackalloc BP_NA055_C.__ExecuteUbergraph_BP_NA055_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_NA055_C.__ExecuteUbergraph_BP_NA055_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NA055_C.__ExecuteUbergraph_BP_NA055_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NA055_C.__ExecuteUbergraph_BP_NA055_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C5D3 RID: 181715 RVA: 0x00A9ED9B File Offset: 0x00A9CF9B
		protected BP_NA055_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040189F2 RID: 100850
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA055/BP_NA055.BP_NA055_C";

		// Token: 0x040189F3 RID: 100851
		private static IntPtr _ClassPtr;

		// Token: 0x040189F4 RID: 100852
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040189F5 RID: 100853
		internal new static int __PropertyOffset_0;

		// Token: 0x040189F6 RID: 100854
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040189F7 RID: 100855
		internal static int __PropertyOffset_1;

		// Token: 0x040189F8 RID: 100856
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040189F9 RID: 100857
		private static IntPtr __ExecuteUbergraph_BP_NA055_NativeFunctionPtr;

		// Token: 0x0200A443 RID: 42051
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_NA055_FunctionParams
		{
			// Token: 0x0403323E RID: 209470
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
