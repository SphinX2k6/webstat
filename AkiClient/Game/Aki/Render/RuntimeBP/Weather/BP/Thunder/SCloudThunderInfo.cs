using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Weather.BP.Thunder
{
	// Token: 0x02003A06 RID: 14854
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Weather/BP/Thunder/SCloudThunderInfo.SCloudThunderInfo")]
	[UnrealStructLayout(80, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 80)]
	public class SCloudThunderInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0601E47E RID: 124030 RVA: 0x008F1A6C File Offset: 0x008EFC6C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCloudThunderInfo._ScriptStructPtr != 0) ? SCloudThunderInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Weather/BP/Thunder/SCloudThunderInfo.SCloudThunderInfo", ref SCloudThunderInfo._ScriptStructPtr);
		}

		// Token: 0x1700295D RID: 10589
		// (get) Token: 0x0601E47F RID: 124031 RVA: 0x008F1A90 File Offset: 0x008EFC90
		// (set) Token: 0x0601E480 RID: 124032 RVA: 0x008F1AA4 File Offset: 0x008EFCA4
		public unsafe FLinearColor ChannelMask
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCloudThunderInfo.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCloudThunderInfo.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x1700295E RID: 10590
		// (get) Token: 0x0601E481 RID: 124033 RVA: 0x008F1AB9 File Offset: 0x008EFCB9
		// (set) Token: 0x0601E482 RID: 124034 RVA: 0x008F1ACD File Offset: 0x008EFCCD
		public unsafe FLinearColor VClamp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCloudThunderInfo.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCloudThunderInfo.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x1700295F RID: 10591
		// (get) Token: 0x0601E483 RID: 124035 RVA: 0x008F1AE2 File Offset: 0x008EFCE2
		// (set) Token: 0x0601E484 RID: 124036 RVA: 0x008F1AF6 File Offset: 0x008EFCF6
		public unsafe FLinearColor UVScaleBias
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCloudThunderInfo.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCloudThunderInfo.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17002960 RID: 10592
		// (get) Token: 0x0601E485 RID: 124037 RVA: 0x008F1B0B File Offset: 0x008EFD0B
		// (set) Token: 0x0601E486 RID: 124038 RVA: 0x008F1B1F File Offset: 0x008EFD1F
		public unsafe FVector2D CloudUV
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCloudThunderInfo.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCloudThunderInfo.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17002961 RID: 10593
		// (get) Token: 0x0601E487 RID: 124039 RVA: 0x008F1B34 File Offset: 0x008EFD34
		// (set) Token: 0x0601E488 RID: 124040 RVA: 0x008F1B44 File Offset: 0x008EFD44
		public unsafe float Emission
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCloudThunderInfo.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCloudThunderInfo.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17002962 RID: 10594
		// (get) Token: 0x0601E489 RID: 124041 RVA: 0x008F1B55 File Offset: 0x008EFD55
		// (set) Token: 0x0601E48A RID: 124042 RVA: 0x008F1B65 File Offset: 0x008EFD65
		public unsafe float PlaySpeedScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCloudThunderInfo.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCloudThunderInfo.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17002963 RID: 10595
		// (get) Token: 0x0601E48B RID: 124043 RVA: 0x008F1B76 File Offset: 0x008EFD76
		// (set) Token: 0x0601E48C RID: 124044 RVA: 0x008F1B86 File Offset: 0x008EFD86
		public unsafe float Radius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCloudThunderInfo.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCloudThunderInfo.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17002964 RID: 10596
		// (get) Token: 0x0601E48D RID: 124045 RVA: 0x008F1B97 File Offset: 0x008EFD97
		// (set) Token: 0x0601E48E RID: 124046 RVA: 0x008F1BA7 File Offset: 0x008EFDA7
		public unsafe float Power
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCloudThunderInfo.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCloudThunderInfo.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17002965 RID: 10597
		// (get) Token: 0x0601E48F RID: 124047 RVA: 0x008F1BB8 File Offset: 0x008EFDB8
		// (set) Token: 0x0601E490 RID: 124048 RVA: 0x008F1BC8 File Offset: 0x008EFDC8
		public unsafe float BrightnessLightening
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCloudThunderInfo.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCloudThunderInfo.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17002966 RID: 10598
		// (get) Token: 0x0601E491 RID: 124049 RVA: 0x008F1BD9 File Offset: 0x008EFDD9
		// (set) Token: 0x0601E492 RID: 124050 RVA: 0x008F1BE9 File Offset: 0x008EFDE9
		public unsafe float BrightnessCloudLight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCloudThunderInfo.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCloudThunderInfo.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x0601E493 RID: 124051 RVA: 0x008F1BFA File Offset: 0x008EFDFA
		public SCloudThunderInfo()
		{
		}

		// Token: 0x0601E494 RID: 124052 RVA: 0x008F1C04 File Offset: 0x008EFE04
		public SCloudThunderInfo(FLinearColor ChannelMask, FLinearColor VClamp, FLinearColor UVScaleBias, FVector2D CloudUV, float Emission, float PlaySpeedScale, float Radius, float Power, float BrightnessLightening, float BrightnessCloudLight)
		{
			this.ChannelMask = ChannelMask;
			this.VClamp = VClamp;
			this.UVScaleBias = UVScaleBias;
			this.CloudUV = CloudUV;
			this.Emission = Emission;
			this.PlaySpeedScale = PlaySpeedScale;
			this.Radius = Radius;
			this.Power = Power;
			this.BrightnessLightening = BrightnessLightening;
			this.BrightnessCloudLight = BrightnessCloudLight;
		}

		// Token: 0x0601E495 RID: 124053 RVA: 0x008F1C64 File Offset: 0x008EFE64
		protected override IntPtr GetUStructPtr()
		{
			return SCloudThunderInfo.StaticStruct();
		}

		// Token: 0x0601E496 RID: 124054 RVA: 0x008F1C70 File Offset: 0x008EFE70
		[NullableContext(2)]
		public SCloudThunderInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601E497 RID: 124055 RVA: 0x008F1C7A File Offset: 0x008EFE7A
		public SCloudThunderInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601E498 RID: 124056 RVA: 0x008F1C85 File Offset: 0x008EFE85
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCloudThunderInfo(Pointer, false, true);
		}

		// Token: 0x0601E499 RID: 124057 RVA: 0x008F1C8F File Offset: 0x008EFE8F
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCloudThunderInfo(Pointer, MemoryOwner);
		}

		// Token: 0x0400EE45 RID: 60997
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Weather/BP/Thunder/SCloudThunderInfo.SCloudThunderInfo";

		// Token: 0x0400EE46 RID: 60998
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0400EE47 RID: 60999
		internal static int __PropertyOffset_0;

		// Token: 0x0400EE48 RID: 61000
		internal static int __PropertyOffset_1;

		// Token: 0x0400EE49 RID: 61001
		internal static int __PropertyOffset_2;

		// Token: 0x0400EE4A RID: 61002
		internal static int __PropertyOffset_3;

		// Token: 0x0400EE4B RID: 61003
		internal static int __PropertyOffset_4;

		// Token: 0x0400EE4C RID: 61004
		internal static int __PropertyOffset_5;

		// Token: 0x0400EE4D RID: 61005
		internal static int __PropertyOffset_6;

		// Token: 0x0400EE4E RID: 61006
		internal static int __PropertyOffset_7;

		// Token: 0x0400EE4F RID: 61007
		internal static int __PropertyOffset_8;

		// Token: 0x0400EE50 RID: 61008
		internal static int __PropertyOffset_9;
	}
}
