using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.GPUBoxSimulation
{
	// Token: 0x02003C2A RID: 15402
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/PD_SM_2_BPSM.PD_SM_2_BPSM_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 160)]
	public class PD_SM_2_BPSM_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060233C5 RID: 144325 RVA: 0x0097CC14 File Offset: 0x0097AE14
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PD_SM_2_BPSM_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/PD_SM_2_BPSM.PD_SM_2_BPSM_C");
			}
			return PD_SM_2_BPSM_C._ClassPtr;
		}

		// Token: 0x060233C6 RID: 144326 RVA: 0x0097CC38 File Offset: 0x0097AE38
		public PD_SM_2_BPSM_C() : this(BuiltinUtils.AllocNativeUObject(PD_SM_2_BPSM_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060233C7 RID: 144327 RVA: 0x0097CC60 File Offset: 0x0097AE60
		public PD_SM_2_BPSM_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PD_SM_2_BPSM_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004537 RID: 17719
		// (get) Token: 0x060233C8 RID: 144328 RVA: 0x0097CC94 File Offset: 0x0097AE94
		// (set) Token: 0x060233C9 RID: 144329 RVA: 0x0097CCCD File Offset: 0x0097AECD
		public TMap<TSoftObjectPtr<UStaticMesh>, UStaticMesh> SMTo2SM
		{
			get
			{
				base.FastCheckIsValid();
				TMap<TSoftObjectPtr<UStaticMesh>, UStaticMesh> result;
				if ((result = this._SMTo2SM) == null)
				{
					result = (this._SMTo2SM = new TMap<TSoftObjectPtr<UStaticMesh>, UStaticMesh>(base.NativePtr + (IntPtr)PD_SM_2_BPSM_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.SMTo2SM.CopyAssign(value);
			}
		}

		// Token: 0x060233CA RID: 144330 RVA: 0x0097CCDB File Offset: 0x0097AEDB
		protected PD_SM_2_BPSM_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011ECA RID: 73418
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/PD_SM_2_BPSM.PD_SM_2_BPSM_C";

		// Token: 0x04011ECB RID: 73419
		private static IntPtr _ClassPtr;

		// Token: 0x04011ECC RID: 73420
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011ECD RID: 73421
		internal static int __PropertyOffset_0;

		// Token: 0x04011ECE RID: 73422
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private TMap<TSoftObjectPtr<UStaticMesh>, UStaticMesh> _SMTo2SM;
	}
}
