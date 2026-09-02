using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.GamePlay.TriggerItems
{
	// Token: 0x02003DC3 RID: 15811
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/GamePlay/TriggerItems/BP_TsTransitionWorldPartitionTriggerVolumeWrapper.BP_TsTransitionWorldPartitionTriggerVolumeWrapper_C")]
	[UnrealStructLayout(1040, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1040)]
	public class BP_TsTransitionWorldPartitionTriggerVolumeWrapper_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026B87 RID: 158599 RVA: 0x009E042F File Offset: 0x009DE62F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_TsTransitionWorldPartitionTriggerVolumeWrapper_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/GamePlay/TriggerItems/BP_TsTransitionWorldPartitionTriggerVolumeWrapper.BP_TsTransitionWorldPartitionTriggerVolumeWrapper_C");
			}
			return BP_TsTransitionWorldPartitionTriggerVolumeWrapper_C._ClassPtr;
		}

		// Token: 0x06026B88 RID: 158600 RVA: 0x009E0454 File Offset: 0x009DE654
		public BP_TsTransitionWorldPartitionTriggerVolumeWrapper_C() : this(BuiltinUtils.AllocNativeUObject(BP_TsTransitionWorldPartitionTriggerVolumeWrapper_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026B89 RID: 158601 RVA: 0x009E047C File Offset: 0x009DE67C
		[NullableContext(1)]
		public BP_TsTransitionWorldPartitionTriggerVolumeWrapper_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_TsTransitionWorldPartitionTriggerVolumeWrapper_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170058C6 RID: 22726
		// (get) Token: 0x06026B8A RID: 158602 RVA: 0x009E04AF File Offset: 0x009DE6AF
		// (set) Token: 0x06026B8B RID: 158603 RVA: 0x009E04C3 File Offset: 0x009DE6C3
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TsTransitionWorldPartitionTriggerVolumeWrapper_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TsTransitionWorldPartitionTriggerVolumeWrapper_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170058C7 RID: 22727
		// (get) Token: 0x06026B8C RID: 158604 RVA: 0x009E04D8 File Offset: 0x009DE6D8
		// (set) Token: 0x06026B8D RID: 158605 RVA: 0x009E04EC File Offset: 0x009DE6EC
		public unsafe TsTransitionWorldPartitionTriggerVolume TargetVolume
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsTransitionWorldPartitionTriggerVolume>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TsTransitionWorldPartitionTriggerVolumeWrapper_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TsTransitionWorldPartitionTriggerVolumeWrapper_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x06026B8E RID: 158606 RVA: 0x009E0501 File Offset: 0x009DE701
		protected BP_TsTransitionWorldPartitionTriggerVolumeWrapper_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014307 RID: 82695
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/GamePlay/TriggerItems/BP_TsTransitionWorldPartitionTriggerVolumeWrapper.BP_TsTransitionWorldPartitionTriggerVolumeWrapper_C";

		// Token: 0x04014308 RID: 82696
		private static IntPtr _ClassPtr;

		// Token: 0x04014309 RID: 82697
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401430A RID: 82698
		internal static int __PropertyOffset_0;

		// Token: 0x0401430B RID: 82699
		internal static int __PropertyOffset_1;
	}
}
