using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.KuroVolumetricCloud
{
	// Token: 0x02003C6B RID: 15467
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/KuroVolumetricCloud/BP_KuroVolumetricCloud.BP_KuroVolumetricCloud_C")]
	[UnrealStructLayout(1048, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1048)]
	public class BP_KuroVolumetricCloud_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023D8F RID: 146831 RVA: 0x0098DBEF File Offset: 0x0098BDEF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroVolumetricCloud_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/KuroVolumetricCloud/BP_KuroVolumetricCloud.BP_KuroVolumetricCloud_C");
			}
			return BP_KuroVolumetricCloud_C._ClassPtr;
		}

		// Token: 0x06023D90 RID: 146832 RVA: 0x0098DC14 File Offset: 0x0098BE14
		public BP_KuroVolumetricCloud_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroVolumetricCloud_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023D91 RID: 146833 RVA: 0x0098DC3C File Offset: 0x0098BE3C
		public BP_KuroVolumetricCloud_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroVolumetricCloud_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170048A7 RID: 18599
		// (get) Token: 0x06023D92 RID: 146834 RVA: 0x0098DC70 File Offset: 0x0098BE70
		// (set) Token: 0x06023D93 RID: 146835 RVA: 0x0098DCA9 File Offset: 0x0098BEA9
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_KuroVolumetricCloud_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroVolumetricCloud_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170048A8 RID: 18600
		// (get) Token: 0x06023D94 RID: 146836 RVA: 0x0098DCCA File Offset: 0x0098BECA
		// (set) Token: 0x06023D95 RID: 146837 RVA: 0x0098DCDE File Offset: 0x0098BEDE
		[Nullable(2)]
		public unsafe UKuroVolumetricCloudComponent KuroVolumetricCloud
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroVolumetricCloudComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumetricCloud_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumetricCloud_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x06023D96 RID: 146838 RVA: 0x0098DCF3 File Offset: 0x0098BEF3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumetricCloud_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06023D97 RID: 146839 RVA: 0x0098DD07 File Offset: 0x0098BF07
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroVolumetricCloud_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023D98 RID: 146840 RVA: 0x0098DD1C File Offset: 0x0098BF1C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_KuroVolumetricCloud(int EntryPoint)
		{
			BP_KuroVolumetricCloud_C.__ExecuteUbergraph_BP_KuroVolumetricCloud_FunctionParams* ptr = stackalloc BP_KuroVolumetricCloud_C.__ExecuteUbergraph_BP_KuroVolumetricCloud_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroVolumetricCloud_C.__ExecuteUbergraph_BP_KuroVolumetricCloud_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroVolumetricCloud_C.__ExecuteUbergraph_BP_KuroVolumetricCloud_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroVolumetricCloud_C.__ExecuteUbergraph_BP_KuroVolumetricCloud_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023D99 RID: 146841 RVA: 0x0098DD63 File Offset: 0x0098BF63
		protected BP_KuroVolumetricCloud_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040124D4 RID: 74964
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/KuroVolumetricCloud/BP_KuroVolumetricCloud.BP_KuroVolumetricCloud_C";

		// Token: 0x040124D5 RID: 74965
		private static IntPtr _ClassPtr;

		// Token: 0x040124D6 RID: 74966
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040124D7 RID: 74967
		internal static int __PropertyOffset_0;

		// Token: 0x040124D8 RID: 74968
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040124D9 RID: 74969
		internal static int __PropertyOffset_1;

		// Token: 0x040124DA RID: 74970
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040124DB RID: 74971
		private static IntPtr __ExecuteUbergraph_BP_KuroVolumetricCloud_NativeFunctionPtr;

		// Token: 0x02009D52 RID: 40274
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_KuroVolumetricCloud_FunctionParams
		{
			// Token: 0x04032736 RID: 206646
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
