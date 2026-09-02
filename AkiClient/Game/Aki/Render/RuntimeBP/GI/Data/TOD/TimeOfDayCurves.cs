using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.Data.TOD
{
	// Token: 0x02003CD6 RID: 15574
	[NullableContext(2)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/Data/TOD/TimeOfDayCurves.TimeOfDayCurves")]
	[UnrealStructLayout(80, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 80)]
	public class TimeOfDayCurves : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602523D RID: 152125 RVA: 0x009B1CF0 File Offset: 0x009AFEF0
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (TimeOfDayCurves._ScriptStructPtr != 0) ? TimeOfDayCurves._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/GI/Data/TOD/TimeOfDayCurves.TimeOfDayCurves", ref TimeOfDayCurves._ScriptStructPtr);
		}

		// Token: 0x17004FDD RID: 20445
		// (get) Token: 0x0602523E RID: 152126 RVA: 0x009B1D14 File Offset: 0x009AFF14
		// (set) Token: 0x0602523F RID: 152127 RVA: 0x009B1D28 File Offset: 0x009AFF28
		public unsafe UCurveLinearColor SkyUpperColorCurve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveLinearColor>(base.NativePtr / (IntPtr)sizeof(void*) + TimeOfDayCurves.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TimeOfDayCurves.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17004FDE RID: 20446
		// (get) Token: 0x06025240 RID: 152128 RVA: 0x009B1D3D File Offset: 0x009AFF3D
		// (set) Token: 0x06025241 RID: 152129 RVA: 0x009B1D51 File Offset: 0x009AFF51
		public unsafe UCurveLinearColor SkyLowerColorCurve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveLinearColor>(base.NativePtr / (IntPtr)sizeof(void*) + TimeOfDayCurves.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TimeOfDayCurves.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004FDF RID: 20447
		// (get) Token: 0x06025242 RID: 152130 RVA: 0x009B1D66 File Offset: 0x009AFF66
		// (set) Token: 0x06025243 RID: 152131 RVA: 0x009B1D7A File Offset: 0x009AFF7A
		public unsafe UCurveLinearColor CloudsUpperColorCurve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveLinearColor>(base.NativePtr / (IntPtr)sizeof(void*) + TimeOfDayCurves.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TimeOfDayCurves.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004FE0 RID: 20448
		// (get) Token: 0x06025244 RID: 152132 RVA: 0x009B1D8F File Offset: 0x009AFF8F
		// (set) Token: 0x06025245 RID: 152133 RVA: 0x009B1DA3 File Offset: 0x009AFFA3
		public unsafe UCurveLinearColor CloudsLowerColorCurve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveLinearColor>(base.NativePtr / (IntPtr)sizeof(void*) + TimeOfDayCurves.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TimeOfDayCurves.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004FE1 RID: 20449
		// (get) Token: 0x06025246 RID: 152134 RVA: 0x009B1DB8 File Offset: 0x009AFFB8
		// (set) Token: 0x06025247 RID: 152135 RVA: 0x009B1DCC File Offset: 0x009AFFCC
		public unsafe UCurveLinearColor CloudsBackgroundCurve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveLinearColor>(base.NativePtr / (IntPtr)sizeof(void*) + TimeOfDayCurves.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TimeOfDayCurves.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004FE2 RID: 20450
		// (get) Token: 0x06025248 RID: 152136 RVA: 0x009B1DE1 File Offset: 0x009AFFE1
		// (set) Token: 0x06025249 RID: 152137 RVA: 0x009B1DF5 File Offset: 0x009AFFF5
		public unsafe UCurveLinearColor CloudsSecondaryColorCurve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveLinearColor>(base.NativePtr / (IntPtr)sizeof(void*) + TimeOfDayCurves.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TimeOfDayCurves.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004FE3 RID: 20451
		// (get) Token: 0x0602524A RID: 152138 RVA: 0x009B1E0A File Offset: 0x009B000A
		// (set) Token: 0x0602524B RID: 152139 RVA: 0x009B1E1E File Offset: 0x009B001E
		public unsafe UCurveLinearColor SunColorCurve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveLinearColor>(base.NativePtr / (IntPtr)sizeof(void*) + TimeOfDayCurves.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TimeOfDayCurves.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17004FE4 RID: 20452
		// (get) Token: 0x0602524C RID: 152140 RVA: 0x009B1E33 File Offset: 0x009B0033
		// (set) Token: 0x0602524D RID: 152141 RVA: 0x009B1E47 File Offset: 0x009B0047
		public unsafe UCurveLinearColor MoonColorCurve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveLinearColor>(base.NativePtr / (IntPtr)sizeof(void*) + TimeOfDayCurves.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TimeOfDayCurves.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17004FE5 RID: 20453
		// (get) Token: 0x0602524E RID: 152142 RVA: 0x009B1E5C File Offset: 0x009B005C
		// (set) Token: 0x0602524F RID: 152143 RVA: 0x009B1E70 File Offset: 0x009B0070
		public unsafe UCurveLinearColor StarsColorCurve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveLinearColor>(base.NativePtr / (IntPtr)sizeof(void*) + TimeOfDayCurves.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TimeOfDayCurves.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17004FE6 RID: 20454
		// (get) Token: 0x06025250 RID: 152144 RVA: 0x009B1E85 File Offset: 0x009B0085
		// (set) Token: 0x06025251 RID: 152145 RVA: 0x009B1E99 File Offset: 0x009B0099
		public unsafe UCurveLinearColor FogColorCurve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveLinearColor>(base.NativePtr / (IntPtr)sizeof(void*) + TimeOfDayCurves.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TimeOfDayCurves.__PropertyOffset_9, value);
			}
		}

		// Token: 0x06025252 RID: 152146 RVA: 0x009B1EAE File Offset: 0x009B00AE
		public TimeOfDayCurves()
		{
		}

		// Token: 0x06025253 RID: 152147 RVA: 0x009B1EB8 File Offset: 0x009B00B8
		[NullableContext(1)]
		public TimeOfDayCurves(UCurveLinearColor SkyUpperColorCurve, UCurveLinearColor SkyLowerColorCurve, UCurveLinearColor CloudsUpperColorCurve, UCurveLinearColor CloudsLowerColorCurve, UCurveLinearColor CloudsBackgroundCurve, UCurveLinearColor CloudsSecondaryColorCurve, UCurveLinearColor SunColorCurve, UCurveLinearColor MoonColorCurve, UCurveLinearColor StarsColorCurve, UCurveLinearColor FogColorCurve)
		{
			this.SkyUpperColorCurve = SkyUpperColorCurve;
			this.SkyLowerColorCurve = SkyLowerColorCurve;
			this.CloudsUpperColorCurve = CloudsUpperColorCurve;
			this.CloudsLowerColorCurve = CloudsLowerColorCurve;
			this.CloudsBackgroundCurve = CloudsBackgroundCurve;
			this.CloudsSecondaryColorCurve = CloudsSecondaryColorCurve;
			this.SunColorCurve = SunColorCurve;
			this.MoonColorCurve = MoonColorCurve;
			this.StarsColorCurve = StarsColorCurve;
			this.FogColorCurve = FogColorCurve;
		}

		// Token: 0x06025254 RID: 152148 RVA: 0x009B1F18 File Offset: 0x009B0118
		protected override IntPtr GetUStructPtr()
		{
			return TimeOfDayCurves.StaticStruct();
		}

		// Token: 0x06025255 RID: 152149 RVA: 0x009B1F24 File Offset: 0x009B0124
		public TimeOfDayCurves(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06025256 RID: 152150 RVA: 0x009B1F2E File Offset: 0x009B012E
		public TimeOfDayCurves(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06025257 RID: 152151 RVA: 0x009B1F39 File Offset: 0x009B0139
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new TimeOfDayCurves(Pointer, false, true);
		}

		// Token: 0x06025258 RID: 152152 RVA: 0x009B1F43 File Offset: 0x009B0143
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new TimeOfDayCurves(Pointer, MemoryOwner);
		}

		// Token: 0x040131E8 RID: 78312
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/Data/TOD/TimeOfDayCurves.TimeOfDayCurves";

		// Token: 0x040131E9 RID: 78313
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040131EA RID: 78314
		internal static int __PropertyOffset_0;

		// Token: 0x040131EB RID: 78315
		internal static int __PropertyOffset_1;

		// Token: 0x040131EC RID: 78316
		internal static int __PropertyOffset_2;

		// Token: 0x040131ED RID: 78317
		internal static int __PropertyOffset_3;

		// Token: 0x040131EE RID: 78318
		internal static int __PropertyOffset_4;

		// Token: 0x040131EF RID: 78319
		internal static int __PropertyOffset_5;

		// Token: 0x040131F0 RID: 78320
		internal static int __PropertyOffset_6;

		// Token: 0x040131F1 RID: 78321
		internal static int __PropertyOffset_7;

		// Token: 0x040131F2 RID: 78322
		internal static int __PropertyOffset_8;

		// Token: 0x040131F3 RID: 78323
		internal static int __PropertyOffset_9;
	}
}
