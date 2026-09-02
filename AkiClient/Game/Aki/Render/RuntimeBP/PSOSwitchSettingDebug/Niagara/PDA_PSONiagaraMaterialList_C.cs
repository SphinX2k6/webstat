using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PSOSwitchSettingDebug.Niagara
{
	// Token: 0x02003B49 RID: 15177
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PSOSwitchSettingDebug/Niagara/PDA_PSONiagaraMaterialList.PDA_PSONiagaraMaterialList_C")]
	[UnrealStructLayout(96, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 96)]
	public class PDA_PSONiagaraMaterialList_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020EC0 RID: 134848 RVA: 0x0093AE8F File Offset: 0x0093908F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PDA_PSONiagaraMaterialList_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PSOSwitchSettingDebug/Niagara/PDA_PSONiagaraMaterialList.PDA_PSONiagaraMaterialList_C");
			}
			return PDA_PSONiagaraMaterialList_C._ClassPtr;
		}

		// Token: 0x06020EC1 RID: 134849 RVA: 0x0093AEB4 File Offset: 0x009390B4
		public PDA_PSONiagaraMaterialList_C() : this(BuiltinUtils.AllocNativeUObject(PDA_PSONiagaraMaterialList_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020EC2 RID: 134850 RVA: 0x0093AEDC File Offset: 0x009390DC
		public PDA_PSONiagaraMaterialList_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PDA_PSONiagaraMaterialList_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003801 RID: 14337
		// (get) Token: 0x06020EC3 RID: 134851 RVA: 0x0093AF10 File Offset: 0x00939110
		// (set) Token: 0x06020EC4 RID: 134852 RVA: 0x0093AF49 File Offset: 0x00939149
		public TArray<UMaterialInterface> Materials
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInterface> result;
				if ((result = this._Materials) == null)
				{
					result = (this._Materials = new TArray<UMaterialInterface>(base.NativePtr + (IntPtr)PDA_PSONiagaraMaterialList_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.Materials.CopyAssign(value);
			}
		}

		// Token: 0x06020EC5 RID: 134853 RVA: 0x0093AF57 File Offset: 0x00939157
		protected PDA_PSONiagaraMaterialList_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010862 RID: 67682
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PSOSwitchSettingDebug/Niagara/PDA_PSONiagaraMaterialList.PDA_PSONiagaraMaterialList_C";

		// Token: 0x04010863 RID: 67683
		private static IntPtr _ClassPtr;

		// Token: 0x04010864 RID: 67684
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010865 RID: 67685
		internal static int __PropertyOffset_0;

		// Token: 0x04010866 RID: 67686
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInterface> _Materials;
	}
}
