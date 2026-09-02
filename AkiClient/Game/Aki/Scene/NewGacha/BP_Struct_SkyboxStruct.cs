using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Scene.NewGacha
{
	// Token: 0x020039C6 RID: 14790
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Scene/NewGacha/BP_Struct_SkyboxStruct.BP_Struct_SkyboxStruct")]
	[UnrealStructLayout(64, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 64)]
	public class BP_Struct_SkyboxStruct : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0601DE71 RID: 122481 RVA: 0x008E67C0 File Offset: 0x008E49C0
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (BP_Struct_SkyboxStruct._ScriptStructPtr != 0) ? BP_Struct_SkyboxStruct._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Scene/NewGacha/BP_Struct_SkyboxStruct.BP_Struct_SkyboxStruct", ref BP_Struct_SkyboxStruct._ScriptStructPtr);
		}

		// Token: 0x170027B9 RID: 10169
		// (get) Token: 0x0601DE72 RID: 122482 RVA: 0x008E67E4 File Offset: 0x008E49E4
		// (set) Token: 0x0601DE73 RID: 122483 RVA: 0x008E67F8 File Offset: 0x008E49F8
		public unsafe string WeatherDataAsset
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_Struct_SkyboxStruct.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_Struct_SkyboxStruct.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x170027BA RID: 10170
		// (get) Token: 0x0601DE74 RID: 122484 RVA: 0x008E680D File Offset: 0x008E4A0D
		// (set) Token: 0x0601DE75 RID: 122485 RVA: 0x008E6821 File Offset: 0x008E4A21
		public unsafe string PPTODDataAsset
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_Struct_SkyboxStruct.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_Struct_SkyboxStruct.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x170027BB RID: 10171
		// (get) Token: 0x0601DE76 RID: 122486 RVA: 0x008E6836 File Offset: 0x008E4A36
		// (set) Token: 0x0601DE77 RID: 122487 RVA: 0x008E6846 File Offset: 0x008E4A46
		public unsafe int SkyboxSetting
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Struct_SkyboxStruct.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Struct_SkyboxStruct.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170027BC RID: 10172
		// (get) Token: 0x0601DE78 RID: 122488 RVA: 0x008E6857 File Offset: 0x008E4A57
		// (set) Token: 0x0601DE79 RID: 122489 RVA: 0x008E6867 File Offset: 0x008E4A67
		public unsafe float FadeTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Struct_SkyboxStruct.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Struct_SkyboxStruct.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170027BD RID: 10173
		// (get) Token: 0x0601DE7A RID: 122490 RVA: 0x008E6878 File Offset: 0x008E4A78
		// (set) Token: 0x0601DE7B RID: 122491 RVA: 0x008E6888 File Offset: 0x008E4A88
		public unsafe float Priority
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Struct_SkyboxStruct.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Struct_SkyboxStruct.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170027BE RID: 10174
		// (get) Token: 0x0601DE7C RID: 122492 RVA: 0x008E6899 File Offset: 0x008E4A99
		// (set) Token: 0x0601DE7D RID: 122493 RVA: 0x008E68AD File Offset: 0x008E4AAD
		public unsafe string TriggerMode
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_Struct_SkyboxStruct.__PropertyOffset_5)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_Struct_SkyboxStruct.__PropertyOffset_5)), value);
			}
		}

		// Token: 0x0601DE7E RID: 122494 RVA: 0x008E68C2 File Offset: 0x008E4AC2
		public BP_Struct_SkyboxStruct()
		{
		}

		// Token: 0x0601DE7F RID: 122495 RVA: 0x008E68CA File Offset: 0x008E4ACA
		public BP_Struct_SkyboxStruct(string WeatherDataAsset, string PPTODDataAsset, int SkyboxSetting, float FadeTime, float Priority, string TriggerMode)
		{
			this.WeatherDataAsset = WeatherDataAsset;
			this.PPTODDataAsset = PPTODDataAsset;
			this.SkyboxSetting = SkyboxSetting;
			this.FadeTime = FadeTime;
			this.Priority = Priority;
			this.TriggerMode = TriggerMode;
		}

		// Token: 0x0601DE80 RID: 122496 RVA: 0x008E68FF File Offset: 0x008E4AFF
		protected override IntPtr GetUStructPtr()
		{
			return BP_Struct_SkyboxStruct.StaticStruct();
		}

		// Token: 0x0601DE81 RID: 122497 RVA: 0x008E690B File Offset: 0x008E4B0B
		[NullableContext(2)]
		public BP_Struct_SkyboxStruct(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DE82 RID: 122498 RVA: 0x008E6915 File Offset: 0x008E4B15
		public BP_Struct_SkyboxStruct(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DE83 RID: 122499 RVA: 0x008E6920 File Offset: 0x008E4B20
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new BP_Struct_SkyboxStruct(Pointer, false, true);
		}

		// Token: 0x0601DE84 RID: 122500 RVA: 0x008E692A File Offset: 0x008E4B2A
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new BP_Struct_SkyboxStruct(Pointer, MemoryOwner);
		}

		// Token: 0x0400EA7A RID: 60026
		public const string __ObjectPath = "/Game/Aki/Scene/NewGacha/BP_Struct_SkyboxStruct.BP_Struct_SkyboxStruct";

		// Token: 0x0400EA7B RID: 60027
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0400EA7C RID: 60028
		internal static int __PropertyOffset_0;

		// Token: 0x0400EA7D RID: 60029
		internal static int __PropertyOffset_1;

		// Token: 0x0400EA7E RID: 60030
		internal static int __PropertyOffset_2;

		// Token: 0x0400EA7F RID: 60031
		internal static int __PropertyOffset_3;

		// Token: 0x0400EA80 RID: 60032
		internal static int __PropertyOffset_4;

		// Token: 0x0400EA81 RID: 60033
		internal static int __PropertyOffset_5;
	}
}
