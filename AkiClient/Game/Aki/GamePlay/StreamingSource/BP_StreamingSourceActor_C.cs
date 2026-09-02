using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.GamePlay.StreamingSource
{
	// Token: 0x02003DC6 RID: 15814
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/GamePlay/StreamingSource/BP_StreamingSourceActor.BP_StreamingSourceActor_C")]
	[UnrealStructLayout(1040, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1040)]
	public class BP_StreamingSourceActor_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026B8F RID: 158607 RVA: 0x009E050A File Offset: 0x009DE70A
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_StreamingSourceActor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/GamePlay/StreamingSource/BP_StreamingSourceActor.BP_StreamingSourceActor_C");
			}
			return BP_StreamingSourceActor_C._ClassPtr;
		}

		// Token: 0x06026B90 RID: 158608 RVA: 0x009E0530 File Offset: 0x009DE730
		public BP_StreamingSourceActor_C() : this(BuiltinUtils.AllocNativeUObject(BP_StreamingSourceActor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026B91 RID: 158609 RVA: 0x009E0558 File Offset: 0x009DE758
		[NullableContext(1)]
		public BP_StreamingSourceActor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_StreamingSourceActor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170058C8 RID: 22728
		// (get) Token: 0x06026B92 RID: 158610 RVA: 0x009E058B File Offset: 0x009DE78B
		// (set) Token: 0x06026B93 RID: 158611 RVA: 0x009E059F File Offset: 0x009DE79F
		public unsafe UWorldPartitionStreamingSourceComponent WorldPartitionStreamingSource
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UWorldPartitionStreamingSourceComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_StreamingSourceActor_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_StreamingSourceActor_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170058C9 RID: 22729
		// (get) Token: 0x06026B94 RID: 158612 RVA: 0x009E05B4 File Offset: 0x009DE7B4
		// (set) Token: 0x06026B95 RID: 158613 RVA: 0x009E05C8 File Offset: 0x009DE7C8
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_StreamingSourceActor_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_StreamingSourceActor_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x06026B96 RID: 158614 RVA: 0x009E05DD File Offset: 0x009DE7DD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_StreamingSourceActor_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06026B97 RID: 158615 RVA: 0x009E05F1 File Offset: 0x009DE7F1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_StreamingSourceActor_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06026B98 RID: 158616 RVA: 0x009E0606 File Offset: 0x009DE806
		protected BP_StreamingSourceActor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401431A RID: 82714
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/GamePlay/StreamingSource/BP_StreamingSourceActor.BP_StreamingSourceActor_C";

		// Token: 0x0401431B RID: 82715
		private static IntPtr _ClassPtr;

		// Token: 0x0401431C RID: 82716
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401431D RID: 82717
		internal static int __PropertyOffset_0;

		// Token: 0x0401431E RID: 82718
		internal static int __PropertyOffset_1;

		// Token: 0x0401431F RID: 82719
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;
	}
}
