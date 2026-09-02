using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroCS.Cloth
{
	// Token: 0x02003C00 RID: 15360
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/KuroCS/Cloth/PD_MeshToClothData.PD_MeshToClothData_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 160)]
	public class PD_MeshToClothData_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022C89 RID: 142473 RVA: 0x0096EFB7 File Offset: 0x0096D1B7
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PD_MeshToClothData_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/KuroCS/Cloth/PD_MeshToClothData.PD_MeshToClothData_C");
			}
			return PD_MeshToClothData_C._ClassPtr;
		}

		// Token: 0x06022C8A RID: 142474 RVA: 0x0096EFDC File Offset: 0x0096D1DC
		public PD_MeshToClothData_C() : this(BuiltinUtils.AllocNativeUObject(PD_MeshToClothData_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022C8B RID: 142475 RVA: 0x0096F004 File Offset: 0x0096D204
		public PD_MeshToClothData_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PD_MeshToClothData_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170042B4 RID: 17076
		// (get) Token: 0x06022C8C RID: 142476 RVA: 0x0096F038 File Offset: 0x0096D238
		// (set) Token: 0x06022C8D RID: 142477 RVA: 0x0096F071 File Offset: 0x0096D271
		public TMap<TSoftObjectPtr<UStaticMesh>, S_KuroCSClothPreset> MeshToCloth
		{
			get
			{
				base.FastCheckIsValid();
				TMap<TSoftObjectPtr<UStaticMesh>, S_KuroCSClothPreset> result;
				if ((result = this._MeshToCloth) == null)
				{
					result = (this._MeshToCloth = new TMap<TSoftObjectPtr<UStaticMesh>, S_KuroCSClothPreset>(base.NativePtr + (IntPtr)PD_MeshToClothData_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.MeshToCloth.CopyAssign(value);
			}
		}

		// Token: 0x06022C8E RID: 142478 RVA: 0x0096F07F File Offset: 0x0096D27F
		protected PD_MeshToClothData_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011A51 RID: 72273
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/KuroCS/Cloth/PD_MeshToClothData.PD_MeshToClothData_C";

		// Token: 0x04011A52 RID: 72274
		private static IntPtr _ClassPtr;

		// Token: 0x04011A53 RID: 72275
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011A54 RID: 72276
		internal static int __PropertyOffset_0;

		// Token: 0x04011A55 RID: 72277
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private TMap<TSoftObjectPtr<UStaticMesh>, S_KuroCSClothPreset> _MeshToCloth;
	}
}
