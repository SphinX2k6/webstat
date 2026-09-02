using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.DandelionInteraction
{
	// Token: 0x02003D50 RID: 15696
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/DandelionInteraction/BP_InstancedDandelionActor.BP_InstancedDandelionActor_C")]
	[UnrealStructLayout(1032, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1032)]
	public class BP_InstancedDandelionActor_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060261E2 RID: 156130 RVA: 0x009CE6EF File Offset: 0x009CC8EF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_InstancedDandelionActor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/DandelionInteraction/BP_InstancedDandelionActor.BP_InstancedDandelionActor_C");
			}
			return BP_InstancedDandelionActor_C._ClassPtr;
		}

		// Token: 0x060261E3 RID: 156131 RVA: 0x009CE714 File Offset: 0x009CC914
		public BP_InstancedDandelionActor_C() : this(BuiltinUtils.AllocNativeUObject(BP_InstancedDandelionActor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060261E4 RID: 156132 RVA: 0x009CE73C File Offset: 0x009CC93C
		[NullableContext(1)]
		public BP_InstancedDandelionActor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_InstancedDandelionActor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005591 RID: 21905
		// (get) Token: 0x060261E5 RID: 156133 RVA: 0x009CE76F File Offset: 0x009CC96F
		// (set) Token: 0x060261E6 RID: 156134 RVA: 0x009CE783 File Offset: 0x009CC983
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InstancedDandelionActor_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InstancedDandelionActor_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x060261E7 RID: 156135 RVA: 0x009CE798 File Offset: 0x009CC998
		protected BP_InstancedDandelionActor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013BE5 RID: 80869
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/DandelionInteraction/BP_InstancedDandelionActor.BP_InstancedDandelionActor_C";

		// Token: 0x04013BE6 RID: 80870
		private static IntPtr _ClassPtr;

		// Token: 0x04013BE7 RID: 80871
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013BE8 RID: 80872
		internal static int __PropertyOffset_0;
	}
}
