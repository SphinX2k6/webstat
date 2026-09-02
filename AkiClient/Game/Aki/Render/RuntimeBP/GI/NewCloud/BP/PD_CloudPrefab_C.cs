using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.NewCloud.BP
{
	// Token: 0x02003CCA RID: 15562
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/PD_CloudPrefab.PD_CloudPrefab_C")]
	[UnrealStructLayout(448, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 448)]
	public class PD_CloudPrefab_C : UKuroPDCloudPrefab, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025093 RID: 151699 RVA: 0x009AF22B File Offset: 0x009AD42B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PD_CloudPrefab_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/PD_CloudPrefab.PD_CloudPrefab_C");
			}
			return PD_CloudPrefab_C._ClassPtr;
		}

		// Token: 0x06025094 RID: 151700 RVA: 0x009AF250 File Offset: 0x009AD450
		public PD_CloudPrefab_C() : this(BuiltinUtils.AllocNativeUObject(PD_CloudPrefab_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025095 RID: 151701 RVA: 0x009AF278 File Offset: 0x009AD478
		[NullableContext(1)]
		public PD_CloudPrefab_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PD_CloudPrefab_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004F30 RID: 20272
		// (get) Token: 0x06025096 RID: 151702 RVA: 0x009AF2AB File Offset: 0x009AD4AB
		// (set) Token: 0x06025097 RID: 151703 RVA: 0x009AF2BF File Offset: 0x009AD4BF
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public unsafe TSubclassOf<BP_CloudPrefab_C> PrefebBP
		{
			[return: Nullable(new byte[]
			{
				0,
				1
			})]
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CloudPrefab_C.__PropertyOffset_0);
			}
			[param: Nullable(new byte[]
			{
				0,
				1
			})]
			set
			{
				*(base.NativePtr + (IntPtr)PD_CloudPrefab_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x06025098 RID: 151704 RVA: 0x009AF2D4 File Offset: 0x009AD4D4
		protected PD_CloudPrefab_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013114 RID: 78100
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/PD_CloudPrefab.PD_CloudPrefab_C";

		// Token: 0x04013115 RID: 78101
		private static IntPtr _ClassPtr;

		// Token: 0x04013116 RID: 78102
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013117 RID: 78103
		internal static int __PropertyOffset_0;
	}
}
