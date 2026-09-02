using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.WeaponLevelMaterial
{
	// Token: 0x02003D5D RID: 15709
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/WeaponLevelMaterial/PD_WeaponLevelMaterialDatas.PD_WeaponLevelMaterialDatas_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 160)]
	public class PD_WeaponLevelMaterialDatas_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026303 RID: 156419 RVA: 0x009D06B0 File Offset: 0x009CE8B0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PD_WeaponLevelMaterialDatas_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Character/WeaponLevelMaterial/PD_WeaponLevelMaterialDatas.PD_WeaponLevelMaterialDatas_C");
			}
			return PD_WeaponLevelMaterialDatas_C._ClassPtr;
		}

		// Token: 0x06026304 RID: 156420 RVA: 0x009D06D4 File Offset: 0x009CE8D4
		public PD_WeaponLevelMaterialDatas_C() : this(BuiltinUtils.AllocNativeUObject(PD_WeaponLevelMaterialDatas_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026305 RID: 156421 RVA: 0x009D06FC File Offset: 0x009CE8FC
		public PD_WeaponLevelMaterialDatas_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PD_WeaponLevelMaterialDatas_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170055E9 RID: 21993
		// (get) Token: 0x06026306 RID: 156422 RVA: 0x009D0730 File Offset: 0x009CE930
		// (set) Token: 0x06026307 RID: 156423 RVA: 0x009D0769 File Offset: 0x009CE969
		public TMap<int, SWeaponLevelMaterialData> LevelDatas
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, SWeaponLevelMaterialData> result;
				if ((result = this._LevelDatas) == null)
				{
					result = (this._LevelDatas = new TMap<int, SWeaponLevelMaterialData>(base.NativePtr + (IntPtr)PD_WeaponLevelMaterialDatas_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.LevelDatas.CopyAssign(value);
			}
		}

		// Token: 0x06026308 RID: 156424 RVA: 0x009D0777 File Offset: 0x009CE977
		protected PD_WeaponLevelMaterialDatas_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013C91 RID: 81041
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/WeaponLevelMaterial/PD_WeaponLevelMaterialDatas.PD_WeaponLevelMaterialDatas_C";

		// Token: 0x04013C92 RID: 81042
		private static IntPtr _ClassPtr;

		// Token: 0x04013C93 RID: 81043
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013C94 RID: 81044
		internal static int __PropertyOffset_0;

		// Token: 0x04013C95 RID: 81045
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<int, SWeaponLevelMaterialData> _LevelDatas;
	}
}
