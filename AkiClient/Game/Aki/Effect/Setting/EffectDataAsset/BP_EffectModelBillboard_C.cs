using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.Billboard;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Effect.Setting.EffectDataAsset
{
	// Token: 0x02003DDD RID: 15837
	[UnrealObjectPath("/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelBillboard.BP_EffectModelBillboard_C")]
	[UnrealStructLayout(136, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 132)]
	public class BP_EffectModelBillboard_C : BP_EffectModelBase_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026D77 RID: 159095 RVA: 0x009E329D File Offset: 0x009E149D
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_EffectModelBillboard_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelBillboard.BP_EffectModelBillboard_C");
			}
			return BP_EffectModelBillboard_C._ClassPtr;
		}

		// Token: 0x06026D78 RID: 159096 RVA: 0x009E32C4 File Offset: 0x009E14C4
		public BP_EffectModelBillboard_C() : this(BuiltinUtils.AllocNativeUObject(BP_EffectModelBillboard_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026D79 RID: 159097 RVA: 0x009E32EC File Offset: 0x009E14EC
		[NullableContext(1)]
		public BP_EffectModelBillboard_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_EffectModelBillboard_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700597A RID: 22906
		// (get) Token: 0x06026D7A RID: 159098 RVA: 0x009E331F File Offset: 0x009E151F
		// (set) Token: 0x06026D7B RID: 159099 RVA: 0x009E332F File Offset: 0x009E152F
		public unsafe bool IsUpdateEveryFrame
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelBillboard_C.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelBillboard_C.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700597B RID: 22907
		// (get) Token: 0x06026D7C RID: 159100 RVA: 0x009E3340 File Offset: 0x009E1540
		// (set) Token: 0x06026D7D RID: 159101 RVA: 0x009E3350 File Offset: 0x009E1550
		public unsafe bool IsFixSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelBillboard_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelBillboard_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700597C RID: 22908
		// (get) Token: 0x06026D7E RID: 159102 RVA: 0x009E3361 File Offset: 0x009E1561
		// (set) Token: 0x06026D7F RID: 159103 RVA: 0x009E3371 File Offset: 0x009E1571
		public unsafe float ScaleSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelBillboard_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelBillboard_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700597D RID: 22909
		// (get) Token: 0x06026D80 RID: 159104 RVA: 0x009E3382 File Offset: 0x009E1582
		// (set) Token: 0x06026D81 RID: 159105 RVA: 0x009E3392 File Offset: 0x009E1592
		public unsafe float MaxDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelBillboard_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelBillboard_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700597E RID: 22910
		// (get) Token: 0x06026D82 RID: 159106 RVA: 0x009E33A3 File Offset: 0x009E15A3
		// (set) Token: 0x06026D83 RID: 159107 RVA: 0x009E33B7 File Offset: 0x009E15B7
		public unsafe TEnumAsByte<E_BillboardMode> OrientAxis
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelBillboard_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelBillboard_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700597F RID: 22911
		// (get) Token: 0x06026D84 RID: 159108 RVA: 0x009E33CC File Offset: 0x009E15CC
		// (set) Token: 0x06026D85 RID: 159109 RVA: 0x009E33DC File Offset: 0x009E15DC
		public unsafe float MinSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelBillboard_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelBillboard_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x06026D86 RID: 159110 RVA: 0x009E33ED File Offset: 0x009E15ED
		protected BP_EffectModelBillboard_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014425 RID: 82981
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelBillboard.BP_EffectModelBillboard_C";

		// Token: 0x04014426 RID: 82982
		private static IntPtr _ClassPtr;

		// Token: 0x04014427 RID: 82983
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014428 RID: 82984
		internal new static int __PropertyOffset_0;

		// Token: 0x04014429 RID: 82985
		internal new static int __PropertyOffset_1;

		// Token: 0x0401442A RID: 82986
		internal new static int __PropertyOffset_2;

		// Token: 0x0401442B RID: 82987
		internal new static int __PropertyOffset_3;

		// Token: 0x0401442C RID: 82988
		internal new static int __PropertyOffset_4;

		// Token: 0x0401442D RID: 82989
		internal new static int __PropertyOffset_5;
	}
}
