using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Effect.Setting.EffectDataAsset
{
	// Token: 0x02003DDF RID: 15839
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelGhost.BP_EffectModelGhost_C")]
	[UnrealStructLayout(128, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 128)]
	public class BP_EffectModelGhost_C : BP_EffectModelBase_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026D97 RID: 159127 RVA: 0x009E364D File Offset: 0x009E184D
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_EffectModelGhost_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelGhost.BP_EffectModelGhost_C");
			}
			return BP_EffectModelGhost_C._ClassPtr;
		}

		// Token: 0x06026D98 RID: 159128 RVA: 0x009E3674 File Offset: 0x009E1874
		public BP_EffectModelGhost_C() : this(BuiltinUtils.AllocNativeUObject(BP_EffectModelGhost_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026D99 RID: 159129 RVA: 0x009E369C File Offset: 0x009E189C
		[NullableContext(1)]
		public BP_EffectModelGhost_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_EffectModelGhost_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005986 RID: 22918
		// (get) Token: 0x06026D9A RID: 159130 RVA: 0x009E36CF File Offset: 0x009E18CF
		// (set) Token: 0x06026D9B RID: 159131 RVA: 0x009E36E3 File Offset: 0x009E18E3
		public unsafe USkeletalMesh Mesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectModelGhost_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectModelGhost_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17005987 RID: 22919
		// (get) Token: 0x06026D9C RID: 159132 RVA: 0x009E36F8 File Offset: 0x009E18F8
		// (set) Token: 0x06026D9D RID: 159133 RVA: 0x009E370C File Offset: 0x009E190C
		public unsafe UMaterialInterface MaterialRef
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectModelGhost_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectModelGhost_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x06026D9E RID: 159134 RVA: 0x009E3721 File Offset: 0x009E1921
		protected BP_EffectModelGhost_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401443C RID: 83004
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelGhost.BP_EffectModelGhost_C";

		// Token: 0x0401443D RID: 83005
		private static IntPtr _ClassPtr;

		// Token: 0x0401443E RID: 83006
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401443F RID: 83007
		internal new static int __PropertyOffset_0;

		// Token: 0x04014440 RID: 83008
		internal new static int __PropertyOffset_1;
	}
}
