using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.TrailFields.Runtime.Drawers
{
	// Token: 0x02003A32 RID: 14898
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/Drawers/BP_SnowTrailDrawActor.BP_SnowTrailDrawActor_C")]
	[UnrealStructLayout(1040, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1040)]
	public class BP_SnowTrailDrawActor_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601EB25 RID: 125733 RVA: 0x008FBFA8 File Offset: 0x008FA1A8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SnowTrailDrawActor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/Drawers/BP_SnowTrailDrawActor.BP_SnowTrailDrawActor_C");
			}
			return BP_SnowTrailDrawActor_C._ClassPtr;
		}

		// Token: 0x0601EB26 RID: 125734 RVA: 0x008FBFCC File Offset: 0x008FA1CC
		public BP_SnowTrailDrawActor_C() : this(BuiltinUtils.AllocNativeUObject(BP_SnowTrailDrawActor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601EB27 RID: 125735 RVA: 0x008FBFF4 File Offset: 0x008FA1F4
		[NullableContext(1)]
		public BP_SnowTrailDrawActor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SnowTrailDrawActor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002BF2 RID: 11250
		// (get) Token: 0x0601EB28 RID: 125736 RVA: 0x008FC027 File Offset: 0x008FA227
		// (set) Token: 0x0601EB29 RID: 125737 RVA: 0x008FC03B File Offset: 0x008FA23B
		public unsafe BP_TrailDrawComponent_Snow_C BP_TrailDrawComponent_Snow
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_TrailDrawComponent_Snow_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTrailDrawActor_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTrailDrawActor_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17002BF3 RID: 11251
		// (get) Token: 0x0601EB2A RID: 125738 RVA: 0x008FC050 File Offset: 0x008FA250
		// (set) Token: 0x0601EB2B RID: 125739 RVA: 0x008FC064 File Offset: 0x008FA264
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTrailDrawActor_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTrailDrawActor_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0601EB2C RID: 125740 RVA: 0x008FC079 File Offset: 0x008FA279
		protected BP_SnowTrailDrawActor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F254 RID: 62036
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/Drawers/BP_SnowTrailDrawActor.BP_SnowTrailDrawActor_C";

		// Token: 0x0400F255 RID: 62037
		private static IntPtr _ClassPtr;

		// Token: 0x0400F256 RID: 62038
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F257 RID: 62039
		internal static int __PropertyOffset_0;

		// Token: 0x0400F258 RID: 62040
		internal static int __PropertyOffset_1;
	}
}
