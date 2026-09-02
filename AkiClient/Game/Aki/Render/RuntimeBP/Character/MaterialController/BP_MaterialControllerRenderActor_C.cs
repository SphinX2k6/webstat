using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController
{
	// Token: 0x02003D74 RID: 15732
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/MaterialController/BP_MaterialControllerRenderActor.BP_MaterialControllerRenderActor_C")]
	[UnrealStructLayout(1048, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1048)]
	public class BP_MaterialControllerRenderActor_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026615 RID: 157205 RVA: 0x009D630B File Offset: 0x009D450B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_MaterialControllerRenderActor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Character/MaterialController/BP_MaterialControllerRenderActor.BP_MaterialControllerRenderActor_C");
			}
			return BP_MaterialControllerRenderActor_C._ClassPtr;
		}

		// Token: 0x06026616 RID: 157206 RVA: 0x009D6330 File Offset: 0x009D4530
		public BP_MaterialControllerRenderActor_C() : this(BuiltinUtils.AllocNativeUObject(BP_MaterialControllerRenderActor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026617 RID: 157207 RVA: 0x009D6358 File Offset: 0x009D4558
		[NullableContext(1)]
		public BP_MaterialControllerRenderActor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_MaterialControllerRenderActor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005704 RID: 22276
		// (get) Token: 0x06026618 RID: 157208 RVA: 0x009D638B File Offset: 0x009D458B
		// (set) Token: 0x06026619 RID: 157209 RVA: 0x009D639F File Offset: 0x009D459F
		public unsafe CharRenderingComponent CharRenderingComponent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<CharRenderingComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MaterialControllerRenderActor_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MaterialControllerRenderActor_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17005705 RID: 22277
		// (get) Token: 0x0602661A RID: 157210 RVA: 0x009D63B4 File Offset: 0x009D45B4
		// (set) Token: 0x0602661B RID: 157211 RVA: 0x009D63C8 File Offset: 0x009D45C8
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MaterialControllerRenderActor_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MaterialControllerRenderActor_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005706 RID: 22278
		// (get) Token: 0x0602661C RID: 157212 RVA: 0x009D63DD File Offset: 0x009D45DD
		// (set) Token: 0x0602661D RID: 157213 RVA: 0x009D63F1 File Offset: 0x009D45F1
		public unsafe AActor RefActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MaterialControllerRenderActor_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MaterialControllerRenderActor_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x0602661E RID: 157214 RVA: 0x009D6406 File Offset: 0x009D4606
		protected BP_MaterialControllerRenderActor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013E88 RID: 81544
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/MaterialController/BP_MaterialControllerRenderActor.BP_MaterialControllerRenderActor_C";

		// Token: 0x04013E89 RID: 81545
		private static IntPtr _ClassPtr;

		// Token: 0x04013E8A RID: 81546
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013E8B RID: 81547
		internal static int __PropertyOffset_0;

		// Token: 0x04013E8C RID: 81548
		internal static int __PropertyOffset_1;

		// Token: 0x04013E8D RID: 81549
		internal static int __PropertyOffset_2;
	}
}
