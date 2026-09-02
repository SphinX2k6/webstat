using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.AClusterBalloons
{
	// Token: 0x02003C4E RID: 15438
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/AClusterBalloons/PD_SM_To_Balloon.PD_SM_To_Balloon_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 160)]
	public class PD_SM_To_Balloon_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023980 RID: 145792 RVA: 0x0098695C File Offset: 0x00984B5C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PD_SM_To_Balloon_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/AClusterBalloons/PD_SM_To_Balloon.PD_SM_To_Balloon_C");
			}
			return PD_SM_To_Balloon_C._ClassPtr;
		}

		// Token: 0x06023981 RID: 145793 RVA: 0x00986980 File Offset: 0x00984B80
		public PD_SM_To_Balloon_C() : this(BuiltinUtils.AllocNativeUObject(PD_SM_To_Balloon_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023982 RID: 145794 RVA: 0x009869A8 File Offset: 0x00984BA8
		public PD_SM_To_Balloon_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PD_SM_To_Balloon_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700474F RID: 18255
		// (get) Token: 0x06023983 RID: 145795 RVA: 0x009869DC File Offset: 0x00984BDC
		// (set) Token: 0x06023984 RID: 145796 RVA: 0x00986A15 File Offset: 0x00984C15
		public TMap<TSoftObjectPtr<UStaticMesh>, UDataTable> SMToBalloon
		{
			get
			{
				base.FastCheckIsValid();
				TMap<TSoftObjectPtr<UStaticMesh>, UDataTable> result;
				if ((result = this._SMToBalloon) == null)
				{
					result = (this._SMToBalloon = new TMap<TSoftObjectPtr<UStaticMesh>, UDataTable>(base.NativePtr + (IntPtr)PD_SM_To_Balloon_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.SMToBalloon.CopyAssign(value);
			}
		}

		// Token: 0x06023985 RID: 145797 RVA: 0x00986A23 File Offset: 0x00984C23
		protected PD_SM_To_Balloon_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012215 RID: 74261
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/AClusterBalloons/PD_SM_To_Balloon.PD_SM_To_Balloon_C";

		// Token: 0x04012216 RID: 74262
		private static IntPtr _ClassPtr;

		// Token: 0x04012217 RID: 74263
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012218 RID: 74264
		internal static int __PropertyOffset_0;

		// Token: 0x04012219 RID: 74265
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private TMap<TSoftObjectPtr<UStaticMesh>, UDataTable> _SMToBalloon;
	}
}
