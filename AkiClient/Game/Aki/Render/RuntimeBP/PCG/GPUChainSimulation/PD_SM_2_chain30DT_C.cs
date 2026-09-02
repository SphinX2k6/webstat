using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.GPUChainSimulation
{
	// Token: 0x02003C1F RID: 15391
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/GPUChainSimulation/PD_SM_2_chain30DT.PD_SM_2_chain30DT_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 160)]
	public class PD_SM_2_chain30DT_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602319D RID: 143773 RVA: 0x00978857 File Offset: 0x00976A57
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PD_SM_2_chain30DT_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/GPUChainSimulation/PD_SM_2_chain30DT.PD_SM_2_chain30DT_C");
			}
			return PD_SM_2_chain30DT_C._ClassPtr;
		}

		// Token: 0x0602319E RID: 143774 RVA: 0x0097887C File Offset: 0x00976A7C
		public PD_SM_2_chain30DT_C() : this(BuiltinUtils.AllocNativeUObject(PD_SM_2_chain30DT_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602319F RID: 143775 RVA: 0x009788A4 File Offset: 0x00976AA4
		public PD_SM_2_chain30DT_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PD_SM_2_chain30DT_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700446A RID: 17514
		// (get) Token: 0x060231A0 RID: 143776 RVA: 0x009788D8 File Offset: 0x00976AD8
		// (set) Token: 0x060231A1 RID: 143777 RVA: 0x00978911 File Offset: 0x00976B11
		public TMap<TSoftObjectPtr<UStaticMesh>, UDataTable> SMTo2SM
		{
			get
			{
				base.FastCheckIsValid();
				TMap<TSoftObjectPtr<UStaticMesh>, UDataTable> result;
				if ((result = this._SMTo2SM) == null)
				{
					result = (this._SMTo2SM = new TMap<TSoftObjectPtr<UStaticMesh>, UDataTable>(base.NativePtr + (IntPtr)PD_SM_2_chain30DT_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.SMTo2SM.CopyAssign(value);
			}
		}

		// Token: 0x060231A2 RID: 143778 RVA: 0x0097891F File Offset: 0x00976B1F
		protected PD_SM_2_chain30DT_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011D86 RID: 73094
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/GPUChainSimulation/PD_SM_2_chain30DT.PD_SM_2_chain30DT_C";

		// Token: 0x04011D87 RID: 73095
		private static IntPtr _ClassPtr;

		// Token: 0x04011D88 RID: 73096
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011D89 RID: 73097
		internal static int __PropertyOffset_0;

		// Token: 0x04011D8A RID: 73098
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private TMap<TSoftObjectPtr<UStaticMesh>, UDataTable> _SMTo2SM;
	}
}
