using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SimpleShatter
{
	// Token: 0x02003B75 RID: 15221
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SimpleShatter/PD_BakedShatterToDA.PD_BakedShatterToDA_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 160)]
	public class PD_BakedShatterToDA_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021896 RID: 137366 RVA: 0x0094C0CB File Offset: 0x0094A2CB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PD_BakedShatterToDA_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SimpleShatter/PD_BakedShatterToDA.PD_BakedShatterToDA_C");
			}
			return PD_BakedShatterToDA_C._ClassPtr;
		}

		// Token: 0x06021897 RID: 137367 RVA: 0x0094C0F0 File Offset: 0x0094A2F0
		public PD_BakedShatterToDA_C() : this(BuiltinUtils.AllocNativeUObject(PD_BakedShatterToDA_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021898 RID: 137368 RVA: 0x0094C118 File Offset: 0x0094A318
		public PD_BakedShatterToDA_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PD_BakedShatterToDA_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003BA9 RID: 15273
		// (get) Token: 0x06021899 RID: 137369 RVA: 0x0094C14C File Offset: 0x0094A34C
		// (set) Token: 0x0602189A RID: 137370 RVA: 0x0094C185 File Offset: 0x0094A385
		public TMap<int, S_BakedShatter> SMTo2SMArr
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, S_BakedShatter> result;
				if ((result = this._SMTo2SMArr) == null)
				{
					result = (this._SMTo2SMArr = new TMap<int, S_BakedShatter>(base.NativePtr + (IntPtr)PD_BakedShatterToDA_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.SMTo2SMArr.CopyAssign(value);
			}
		}

		// Token: 0x0602189B RID: 137371 RVA: 0x0094C193 File Offset: 0x0094A393
		protected PD_BakedShatterToDA_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010E4E RID: 69198
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SimpleShatter/PD_BakedShatterToDA.PD_BakedShatterToDA_C";

		// Token: 0x04010E4F RID: 69199
		private static IntPtr _ClassPtr;

		// Token: 0x04010E50 RID: 69200
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010E51 RID: 69201
		internal static int __PropertyOffset_0;

		// Token: 0x04010E52 RID: 69202
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<int, S_BakedShatter> _SMTo2SMArr;
	}
}
