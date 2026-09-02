using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Interaction
{
	// Token: 0x02003C7A RID: 15482
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Interaction/BP_DiceOL.BP_DiceOL_C")]
	[UnrealStructLayout(1048, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1048)]
	public class BP_DiceOL_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023FA4 RID: 147364 RVA: 0x00991508 File Offset: 0x0098F708
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DiceOL_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Interaction/BP_DiceOL.BP_DiceOL_C");
			}
			return BP_DiceOL_C._ClassPtr;
		}

		// Token: 0x06023FA5 RID: 147365 RVA: 0x0099152C File Offset: 0x0098F72C
		public BP_DiceOL_C() : this(BuiltinUtils.AllocNativeUObject(BP_DiceOL_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023FA6 RID: 147366 RVA: 0x00991554 File Offset: 0x0098F754
		[NullableContext(1)]
		public BP_DiceOL_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DiceOL_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004959 RID: 18777
		// (get) Token: 0x06023FA7 RID: 147367 RVA: 0x00991587 File Offset: 0x0098F787
		// (set) Token: 0x06023FA8 RID: 147368 RVA: 0x0099159B File Offset: 0x0098F79B
		public unsafe UStaticMeshComponent DiceOL1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DiceOL_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DiceOL_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x1700495A RID: 18778
		// (get) Token: 0x06023FA9 RID: 147369 RVA: 0x009915B0 File Offset: 0x0098F7B0
		// (set) Token: 0x06023FAA RID: 147370 RVA: 0x009915C4 File Offset: 0x0098F7C4
		public unsafe UStaticMeshComponent DiceOL
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DiceOL_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DiceOL_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700495B RID: 18779
		// (get) Token: 0x06023FAB RID: 147371 RVA: 0x009915D9 File Offset: 0x0098F7D9
		// (set) Token: 0x06023FAC RID: 147372 RVA: 0x009915ED File Offset: 0x0098F7ED
		public unsafe UStaticMeshComponent Dice
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DiceOL_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DiceOL_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x06023FAD RID: 147373 RVA: 0x00991602 File Offset: 0x0098F802
		protected BP_DiceOL_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012624 RID: 75300
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Interaction/BP_DiceOL.BP_DiceOL_C";

		// Token: 0x04012625 RID: 75301
		private static IntPtr _ClassPtr;

		// Token: 0x04012626 RID: 75302
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012627 RID: 75303
		internal static int __PropertyOffset_0;

		// Token: 0x04012628 RID: 75304
		internal static int __PropertyOffset_1;

		// Token: 0x04012629 RID: 75305
		internal static int __PropertyOffset_2;
	}
}
