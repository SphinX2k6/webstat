using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SimpleShatter
{
	// Token: 0x02003B76 RID: 15222
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SimpleShatter/PD_MeshToMeshArr.PD_MeshToMeshArr_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 160)]
	public class PD_MeshToMeshArr_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602189C RID: 137372 RVA: 0x0094C19C File Offset: 0x0094A39C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PD_MeshToMeshArr_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SimpleShatter/PD_MeshToMeshArr.PD_MeshToMeshArr_C");
			}
			return PD_MeshToMeshArr_C._ClassPtr;
		}

		// Token: 0x0602189D RID: 137373 RVA: 0x0094C1C0 File Offset: 0x0094A3C0
		public PD_MeshToMeshArr_C() : this(BuiltinUtils.AllocNativeUObject(PD_MeshToMeshArr_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602189E RID: 137374 RVA: 0x0094C1E8 File Offset: 0x0094A3E8
		public PD_MeshToMeshArr_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PD_MeshToMeshArr_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003BAA RID: 15274
		// (get) Token: 0x0602189F RID: 137375 RVA: 0x0094C21C File Offset: 0x0094A41C
		// (set) Token: 0x060218A0 RID: 137376 RVA: 0x0094C255 File Offset: 0x0094A455
		public TMap<TSoftObjectPtr<UStaticMesh>, S_MeshToMeshArr> SMTo2SMArr
		{
			get
			{
				base.FastCheckIsValid();
				TMap<TSoftObjectPtr<UStaticMesh>, S_MeshToMeshArr> result;
				if ((result = this._SMTo2SMArr) == null)
				{
					result = (this._SMTo2SMArr = new TMap<TSoftObjectPtr<UStaticMesh>, S_MeshToMeshArr>(base.NativePtr + (IntPtr)PD_MeshToMeshArr_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.SMTo2SMArr.CopyAssign(value);
			}
		}

		// Token: 0x060218A1 RID: 137377 RVA: 0x0094C263 File Offset: 0x0094A463
		protected PD_MeshToMeshArr_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010E53 RID: 69203
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SimpleShatter/PD_MeshToMeshArr.PD_MeshToMeshArr_C";

		// Token: 0x04010E54 RID: 69204
		private static IntPtr _ClassPtr;

		// Token: 0x04010E55 RID: 69205
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010E56 RID: 69206
		internal static int __PropertyOffset_0;

		// Token: 0x04010E57 RID: 69207
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private TMap<TSoftObjectPtr<UStaticMesh>, S_MeshToMeshArr> _SMTo2SMArr;
	}
}
