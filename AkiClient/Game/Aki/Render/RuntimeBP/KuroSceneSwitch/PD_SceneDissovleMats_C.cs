using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.KuroSceneSwitch
{
	// Token: 0x02003C6F RID: 15471
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/KuroSceneSwitch/PD_SceneDissovleMats.PD_SceneDissovleMats_C")]
	[UnrealStructLayout(96, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 96)]
	public class PD_SceneDissovleMats_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023E28 RID: 146984 RVA: 0x0098ED03 File Offset: 0x0098CF03
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PD_SceneDissovleMats_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/KuroSceneSwitch/PD_SceneDissovleMats.PD_SceneDissovleMats_C");
			}
			return PD_SceneDissovleMats_C._ClassPtr;
		}

		// Token: 0x06023E29 RID: 146985 RVA: 0x0098ED28 File Offset: 0x0098CF28
		public PD_SceneDissovleMats_C() : this(BuiltinUtils.AllocNativeUObject(PD_SceneDissovleMats_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023E2A RID: 146986 RVA: 0x0098ED50 File Offset: 0x0098CF50
		public PD_SceneDissovleMats_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PD_SceneDissovleMats_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170048D7 RID: 18647
		// (get) Token: 0x06023E2B RID: 146987 RVA: 0x0098ED84 File Offset: 0x0098CF84
		// (set) Token: 0x06023E2C RID: 146988 RVA: 0x0098EDBD File Offset: 0x0098CFBD
		public TArray<UMaterialInstanceConstant> MATS
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceConstant> result;
				if ((result = this._MATS) == null)
				{
					result = (this._MATS = new TArray<UMaterialInstanceConstant>(base.NativePtr + (IntPtr)PD_SceneDissovleMats_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.MATS.CopyAssign(value);
			}
		}

		// Token: 0x06023E2D RID: 146989 RVA: 0x0098EDCB File Offset: 0x0098CFCB
		protected PD_SceneDissovleMats_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401253E RID: 75070
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/KuroSceneSwitch/PD_SceneDissovleMats.PD_SceneDissovleMats_C";

		// Token: 0x0401253F RID: 75071
		private static IntPtr _ClassPtr;

		// Token: 0x04012540 RID: 75072
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012541 RID: 75073
		internal static int __PropertyOffset_0;

		// Token: 0x04012542 RID: 75074
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceConstant> _MATS;
	}
}
