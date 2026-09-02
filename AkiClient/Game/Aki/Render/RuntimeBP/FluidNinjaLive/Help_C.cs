using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive
{
	// Token: 0x02003CF3 RID: 15603
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Help.Help_C")]
	[UnrealStructLayout(1056, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1056)]
	public class Help_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025491 RID: 152721 RVA: 0x009B63FE File Offset: 0x009B45FE
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (Help_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Help.Help_C");
			}
			return Help_C._ClassPtr;
		}

		// Token: 0x06025492 RID: 152722 RVA: 0x009B6424 File Offset: 0x009B4624
		public Help_C() : this(BuiltinUtils.AllocNativeUObject(Help_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025493 RID: 152723 RVA: 0x009B644C File Offset: 0x009B464C
		[NullableContext(1)]
		public Help_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(Help_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005093 RID: 20627
		// (get) Token: 0x06025494 RID: 152724 RVA: 0x009B6480 File Offset: 0x009B4680
		// (set) Token: 0x06025495 RID: 152725 RVA: 0x009B64B9 File Offset: 0x009B46B9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)Help_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)Help_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005094 RID: 20628
		// (get) Token: 0x06025496 RID: 152726 RVA: 0x009B64DA File Offset: 0x009B46DA
		// (set) Token: 0x06025497 RID: 152727 RVA: 0x009B64EE File Offset: 0x009B46EE
		public unsafe USceneComponent Root
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Help_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Help_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005095 RID: 20629
		// (get) Token: 0x06025498 RID: 152728 RVA: 0x009B6503 File Offset: 0x009B4703
		// (set) Token: 0x06025499 RID: 152729 RVA: 0x009B6517 File Offset: 0x009B4717
		public unsafe UMaterialBillboardComponent EditorIcon
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Help_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Help_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x0602549A RID: 152730 RVA: 0x009B652C File Offset: 0x009B472C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_Help(int EntryPoint)
		{
			Help_C.__ExecuteUbergraph_Help_FunctionParams* ptr = stackalloc Help_C.__ExecuteUbergraph_Help_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(Help_C.__ExecuteUbergraph_Help_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Help_C.__ExecuteUbergraph_Help_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, Help_C.__ExecuteUbergraph_Help_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602549B RID: 152731 RVA: 0x009B6573 File Offset: 0x009B4773
		protected Help_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401334A RID: 78666
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Help.Help_C";

		// Token: 0x0401334B RID: 78667
		private static IntPtr _ClassPtr;

		// Token: 0x0401334C RID: 78668
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401334D RID: 78669
		internal static int __PropertyOffset_0;

		// Token: 0x0401334E RID: 78670
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401334F RID: 78671
		internal static int __PropertyOffset_1;

		// Token: 0x04013350 RID: 78672
		internal static int __PropertyOffset_2;

		// Token: 0x04013351 RID: 78673
		private static IntPtr __ExecuteUbergraph_Help_NativeFunctionPtr;

		// Token: 0x02009EF6 RID: 40694
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_Help_FunctionParams
		{
			// Token: 0x040329ED RID: 207341
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
