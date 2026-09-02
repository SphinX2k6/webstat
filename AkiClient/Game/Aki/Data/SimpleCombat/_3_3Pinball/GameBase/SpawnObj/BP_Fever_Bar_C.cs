using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.SimpleCombat._3_3Pinball.GameBase.SpawnObj
{
	// Token: 0x02003E04 RID: 15876
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/SimpleCombat/3_3Pinball/GameBase/SpawnObj/BP_Fever_Bar.BP_Fever_Bar_C")]
	[UnrealStructLayout(1048, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1048)]
	public class BP_Fever_Bar_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060271C3 RID: 160195 RVA: 0x009EA145 File Offset: 0x009E8345
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Fever_Bar_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/SimpleCombat/3_3Pinball/GameBase/SpawnObj/BP_Fever_Bar.BP_Fever_Bar_C");
			}
			return BP_Fever_Bar_C._ClassPtr;
		}

		// Token: 0x060271C4 RID: 160196 RVA: 0x009EA16C File Offset: 0x009E836C
		public BP_Fever_Bar_C() : this(BuiltinUtils.AllocNativeUObject(BP_Fever_Bar_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060271C5 RID: 160197 RVA: 0x009EA194 File Offset: 0x009E8394
		[NullableContext(1)]
		public BP_Fever_Bar_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Fever_Bar_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005B27 RID: 23335
		// (get) Token: 0x060271C6 RID: 160198 RVA: 0x009EA1C7 File Offset: 0x009E83C7
		// (set) Token: 0x060271C7 RID: 160199 RVA: 0x009EA1DB File Offset: 0x009E83DB
		public unsafe UStaticMeshComponent Bg
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fever_Bar_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fever_Bar_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17005B28 RID: 23336
		// (get) Token: 0x060271C8 RID: 160200 RVA: 0x009EA1F0 File Offset: 0x009E83F0
		// (set) Token: 0x060271C9 RID: 160201 RVA: 0x009EA204 File Offset: 0x009E8404
		public unsafe UStaticMeshComponent Mesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fever_Bar_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fever_Bar_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005B29 RID: 23337
		// (get) Token: 0x060271CA RID: 160202 RVA: 0x009EA219 File Offset: 0x009E8419
		// (set) Token: 0x060271CB RID: 160203 RVA: 0x009EA22D File Offset: 0x009E842D
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fever_Bar_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fever_Bar_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x060271CC RID: 160204 RVA: 0x009EA242 File Offset: 0x009E8442
		protected BP_Fever_Bar_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014701 RID: 83713
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Data/SimpleCombat/3_3Pinball/GameBase/SpawnObj/BP_Fever_Bar.BP_Fever_Bar_C";

		// Token: 0x04014702 RID: 83714
		private static IntPtr _ClassPtr;

		// Token: 0x04014703 RID: 83715
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014704 RID: 83716
		internal static int __PropertyOffset_0;

		// Token: 0x04014705 RID: 83717
		internal static int __PropertyOffset_1;

		// Token: 0x04014706 RID: 83718
		internal static int __PropertyOffset_2;
	}
}
