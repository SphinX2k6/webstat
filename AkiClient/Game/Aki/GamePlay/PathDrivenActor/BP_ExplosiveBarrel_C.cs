using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.GamePlay.PathDrivenActor
{
	// Token: 0x02003DD1 RID: 15825
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/GamePlay/PathDrivenActor/BP_ExplosiveBarrel.BP_ExplosiveBarrel_C")]
	[UnrealStructLayout(1384, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1384)]
	public class BP_ExplosiveBarrel_C : AKuroGameBudgetBlueprintActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026C3A RID: 158778 RVA: 0x009E1743 File Offset: 0x009DF943
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_ExplosiveBarrel_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/GamePlay/PathDrivenActor/BP_ExplosiveBarrel.BP_ExplosiveBarrel_C");
			}
			return BP_ExplosiveBarrel_C._ClassPtr;
		}

		// Token: 0x06026C3B RID: 158779 RVA: 0x009E1768 File Offset: 0x009DF968
		public BP_ExplosiveBarrel_C() : this(BuiltinUtils.AllocNativeUObject(BP_ExplosiveBarrel_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026C3C RID: 158780 RVA: 0x009E1790 File Offset: 0x009DF990
		[NullableContext(1)]
		public BP_ExplosiveBarrel_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_ExplosiveBarrel_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170058F2 RID: 22770
		// (get) Token: 0x06026C3D RID: 158781 RVA: 0x009E17C3 File Offset: 0x009DF9C3
		// (set) Token: 0x06026C3E RID: 158782 RVA: 0x009E17D7 File Offset: 0x009DF9D7
		public unsafe UNiagaraComponent NS_Fx_Sl2_3_5_MZ_Baozhatong_Trail
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ExplosiveBarrel_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ExplosiveBarrel_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170058F3 RID: 22771
		// (get) Token: 0x06026C3F RID: 158783 RVA: 0x009E17EC File Offset: 0x009DF9EC
		// (set) Token: 0x06026C40 RID: 158784 RVA: 0x009E1800 File Offset: 0x009DFA00
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ExplosiveBarrel_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ExplosiveBarrel_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170058F4 RID: 22772
		// (get) Token: 0x06026C41 RID: 158785 RVA: 0x009E1815 File Offset: 0x009DFA15
		// (set) Token: 0x06026C42 RID: 158786 RVA: 0x009E1829 File Offset: 0x009DFA29
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ExplosiveBarrel_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ExplosiveBarrel_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170058F5 RID: 22773
		// (get) Token: 0x06026C43 RID: 158787 RVA: 0x009E183E File Offset: 0x009DFA3E
		// (set) Token: 0x06026C44 RID: 158788 RVA: 0x009E184E File Offset: 0x009DFA4E
		public unsafe float BarrelRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ExplosiveBarrel_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ExplosiveBarrel_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170058F6 RID: 22774
		// (get) Token: 0x06026C45 RID: 158789 RVA: 0x009E185F File Offset: 0x009DFA5F
		// (set) Token: 0x06026C46 RID: 158790 RVA: 0x009E1873 File Offset: 0x009DFA73
		[Nullable(1)]
		public unsafe string AudioEvent
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_ExplosiveBarrel_C.__PropertyOffset_4)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_ExplosiveBarrel_C.__PropertyOffset_4)), value);
			}
		}

		// Token: 0x170058F7 RID: 22775
		// (get) Token: 0x06026C47 RID: 158791 RVA: 0x009E1888 File Offset: 0x009DFA88
		// (set) Token: 0x06026C48 RID: 158792 RVA: 0x009E189D File Offset: 0x009DFA9D
		[Nullable(1)]
		public TSoftObjectPtr<UEffectModelBase> ExplodeEffectAsset
		{
			[NullableContext(1)]
			get
			{
				return new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)BP_ExplosiveBarrel_C.__PropertyOffset_5, this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_ExplosiveBarrel_C.__PropertyOffset_5, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x06026C49 RID: 158793 RVA: 0x009E18C2 File Offset: 0x009DFAC2
		protected BP_ExplosiveBarrel_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014374 RID: 82804
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/GamePlay/PathDrivenActor/BP_ExplosiveBarrel.BP_ExplosiveBarrel_C";

		// Token: 0x04014375 RID: 82805
		private static IntPtr _ClassPtr;

		// Token: 0x04014376 RID: 82806
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014377 RID: 82807
		internal static int __PropertyOffset_0;

		// Token: 0x04014378 RID: 82808
		internal static int __PropertyOffset_1;

		// Token: 0x04014379 RID: 82809
		internal static int __PropertyOffset_2;

		// Token: 0x0401437A RID: 82810
		internal static int __PropertyOffset_3;

		// Token: 0x0401437B RID: 82811
		internal static int __PropertyOffset_4;

		// Token: 0x0401437C RID: 82812
		internal static int __PropertyOffset_5;
	}
}
