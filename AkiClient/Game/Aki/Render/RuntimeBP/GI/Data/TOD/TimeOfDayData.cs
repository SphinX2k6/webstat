using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.Data.TOD
{
	// Token: 0x02003CD7 RID: 15575
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/Data/TOD/TimeOfDayData.TimeOfDayData")]
	[UnrealStructLayout(164, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 164)]
	public class TimeOfDayData : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06025259 RID: 152153 RVA: 0x009B1F4C File Offset: 0x009B014C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (TimeOfDayData._ScriptStructPtr != 0) ? TimeOfDayData._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/GI/Data/TOD/TimeOfDayData.TimeOfDayData", ref TimeOfDayData._ScriptStructPtr);
		}

		// Token: 0x17004FE7 RID: 20455
		// (get) Token: 0x0602525A RID: 152154 RVA: 0x009B1F70 File Offset: 0x009B0170
		// (set) Token: 0x0602525B RID: 152155 RVA: 0x009B1F80 File Offset: 0x009B0180
		public unsafe float PresetTimeOfDay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)TimeOfDayData.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)TimeOfDayData.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17004FE8 RID: 20456
		// (get) Token: 0x0602525C RID: 152156 RVA: 0x009B1F91 File Offset: 0x009B0191
		// (set) Token: 0x0602525D RID: 152157 RVA: 0x009B1FA5 File Offset: 0x009B01A5
		public unsafe FLinearColor SkyUpperColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)TimeOfDayData.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)TimeOfDayData.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17004FE9 RID: 20457
		// (get) Token: 0x0602525E RID: 152158 RVA: 0x009B1FBA File Offset: 0x009B01BA
		// (set) Token: 0x0602525F RID: 152159 RVA: 0x009B1FCE File Offset: 0x009B01CE
		public unsafe FLinearColor SkyLowerColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)TimeOfDayData.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)TimeOfDayData.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17004FEA RID: 20458
		// (get) Token: 0x06025260 RID: 152160 RVA: 0x009B1FE3 File Offset: 0x009B01E3
		// (set) Token: 0x06025261 RID: 152161 RVA: 0x009B1FF7 File Offset: 0x009B01F7
		public unsafe FLinearColor CloudsUpperColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)TimeOfDayData.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)TimeOfDayData.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17004FEB RID: 20459
		// (get) Token: 0x06025262 RID: 152162 RVA: 0x009B200C File Offset: 0x009B020C
		// (set) Token: 0x06025263 RID: 152163 RVA: 0x009B2020 File Offset: 0x009B0220
		public unsafe FLinearColor CloudsLowerColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)TimeOfDayData.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)TimeOfDayData.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17004FEC RID: 20460
		// (get) Token: 0x06025264 RID: 152164 RVA: 0x009B2035 File Offset: 0x009B0235
		// (set) Token: 0x06025265 RID: 152165 RVA: 0x009B2049 File Offset: 0x009B0249
		public unsafe FLinearColor CloudsSecondaryColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)TimeOfDayData.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)TimeOfDayData.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17004FED RID: 20461
		// (get) Token: 0x06025266 RID: 152166 RVA: 0x009B205E File Offset: 0x009B025E
		// (set) Token: 0x06025267 RID: 152167 RVA: 0x009B2072 File Offset: 0x009B0272
		public unsafe FLinearColor CloudsBackground
		{
			get
			{
				return *(base.NativePtr + (IntPtr)TimeOfDayData.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)TimeOfDayData.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17004FEE RID: 20462
		// (get) Token: 0x06025268 RID: 152168 RVA: 0x009B2087 File Offset: 0x009B0287
		// (set) Token: 0x06025269 RID: 152169 RVA: 0x009B209B File Offset: 0x009B029B
		public unsafe FLinearColor SunColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)TimeOfDayData.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)TimeOfDayData.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17004FEF RID: 20463
		// (get) Token: 0x0602526A RID: 152170 RVA: 0x009B20B0 File Offset: 0x009B02B0
		// (set) Token: 0x0602526B RID: 152171 RVA: 0x009B20C4 File Offset: 0x009B02C4
		public unsafe FLinearColor MoonColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)TimeOfDayData.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)TimeOfDayData.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17004FF0 RID: 20464
		// (get) Token: 0x0602526C RID: 152172 RVA: 0x009B20D9 File Offset: 0x009B02D9
		// (set) Token: 0x0602526D RID: 152173 RVA: 0x009B20ED File Offset: 0x009B02ED
		public unsafe FLinearColor StarsColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)TimeOfDayData.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)TimeOfDayData.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17004FF1 RID: 20465
		// (get) Token: 0x0602526E RID: 152174 RVA: 0x009B2102 File Offset: 0x009B0302
		// (set) Token: 0x0602526F RID: 152175 RVA: 0x009B2116 File Offset: 0x009B0316
		public unsafe FLinearColor FogColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)TimeOfDayData.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)TimeOfDayData.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x06025270 RID: 152176 RVA: 0x009B212B File Offset: 0x009B032B
		public TimeOfDayData()
		{
		}

		// Token: 0x06025271 RID: 152177 RVA: 0x009B2134 File Offset: 0x009B0334
		public TimeOfDayData(float PresetTimeOfDay, FLinearColor SkyUpperColor, FLinearColor SkyLowerColor, FLinearColor CloudsUpperColor, FLinearColor CloudsLowerColor, FLinearColor CloudsSecondaryColor, FLinearColor CloudsBackground, FLinearColor SunColor, FLinearColor MoonColor, FLinearColor StarsColor, FLinearColor FogColor)
		{
			this.PresetTimeOfDay = PresetTimeOfDay;
			this.SkyUpperColor = SkyUpperColor;
			this.SkyLowerColor = SkyLowerColor;
			this.CloudsUpperColor = CloudsUpperColor;
			this.CloudsLowerColor = CloudsLowerColor;
			this.CloudsSecondaryColor = CloudsSecondaryColor;
			this.CloudsBackground = CloudsBackground;
			this.SunColor = SunColor;
			this.MoonColor = MoonColor;
			this.StarsColor = StarsColor;
			this.FogColor = FogColor;
		}

		// Token: 0x06025272 RID: 152178 RVA: 0x009B219C File Offset: 0x009B039C
		protected override IntPtr GetUStructPtr()
		{
			return TimeOfDayData.StaticStruct();
		}

		// Token: 0x06025273 RID: 152179 RVA: 0x009B21A8 File Offset: 0x009B03A8
		[NullableContext(2)]
		public TimeOfDayData(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06025274 RID: 152180 RVA: 0x009B21B2 File Offset: 0x009B03B2
		public TimeOfDayData(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06025275 RID: 152181 RVA: 0x009B21BD File Offset: 0x009B03BD
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new TimeOfDayData(Pointer, false, true);
		}

		// Token: 0x06025276 RID: 152182 RVA: 0x009B21C7 File Offset: 0x009B03C7
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new TimeOfDayData(Pointer, MemoryOwner);
		}

		// Token: 0x040131F4 RID: 78324
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/Data/TOD/TimeOfDayData.TimeOfDayData";

		// Token: 0x040131F5 RID: 78325
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040131F6 RID: 78326
		internal static int __PropertyOffset_0;

		// Token: 0x040131F7 RID: 78327
		internal static int __PropertyOffset_1;

		// Token: 0x040131F8 RID: 78328
		internal static int __PropertyOffset_2;

		// Token: 0x040131F9 RID: 78329
		internal static int __PropertyOffset_3;

		// Token: 0x040131FA RID: 78330
		internal static int __PropertyOffset_4;

		// Token: 0x040131FB RID: 78331
		internal static int __PropertyOffset_5;

		// Token: 0x040131FC RID: 78332
		internal static int __PropertyOffset_6;

		// Token: 0x040131FD RID: 78333
		internal static int __PropertyOffset_7;

		// Token: 0x040131FE RID: 78334
		internal static int __PropertyOffset_8;

		// Token: 0x040131FF RID: 78335
		internal static int __PropertyOffset_9;

		// Token: 0x04013200 RID: 78336
		internal static int __PropertyOffset_10;
	}
}
