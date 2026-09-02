using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Server.Struct
{
	// Token: 0x02003E05 RID: 15877
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Server/Struct/SServerInfo.SServerInfo")]
	[UnrealStructLayout(72, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 72)]
	public class SServerInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060271CD RID: 160205 RVA: 0x009EA24B File Offset: 0x009E844B
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SServerInfo._ScriptStructPtr != 0) ? SServerInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Server/Struct/SServerInfo.SServerInfo", ref SServerInfo._ScriptStructPtr);
		}

		// Token: 0x17005B2A RID: 23338
		// (get) Token: 0x060271CE RID: 160206 RVA: 0x009EA26F File Offset: 0x009E846F
		// (set) Token: 0x060271CF RID: 160207 RVA: 0x009EA283 File Offset: 0x009E8483
		public unsafe string IP
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SServerInfo.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SServerInfo.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17005B2B RID: 23339
		// (get) Token: 0x060271D0 RID: 160208 RVA: 0x009EA298 File Offset: 0x009E8498
		// (set) Token: 0x060271D1 RID: 160209 RVA: 0x009EA2AC File Offset: 0x009E84AC
		public unsafe string Port
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SServerInfo.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SServerInfo.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x17005B2C RID: 23340
		// (get) Token: 0x060271D2 RID: 160210 RVA: 0x009EA2C1 File Offset: 0x009E84C1
		// (set) Token: 0x060271D3 RID: 160211 RVA: 0x009EA2D5 File Offset: 0x009E84D5
		public unsafe string Name
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SServerInfo.__PropertyOffset_2)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SServerInfo.__PropertyOffset_2)), value);
			}
		}

		// Token: 0x17005B2D RID: 23341
		// (get) Token: 0x060271D4 RID: 160212 RVA: 0x009EA2EA File Offset: 0x009E84EA
		// (set) Token: 0x060271D5 RID: 160213 RVA: 0x009EA2FE File Offset: 0x009E84FE
		public unsafe string Stream
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SServerInfo.__PropertyOffset_3)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SServerInfo.__PropertyOffset_3)), value);
			}
		}

		// Token: 0x17005B2E RID: 23342
		// (get) Token: 0x060271D6 RID: 160214 RVA: 0x009EA313 File Offset: 0x009E8513
		// (set) Token: 0x060271D7 RID: 160215 RVA: 0x009EA323 File Offset: 0x009E8523
		public unsafe bool Editor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SServerInfo.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SServerInfo.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005B2F RID: 23343
		// (get) Token: 0x060271D8 RID: 160216 RVA: 0x009EA334 File Offset: 0x009E8534
		// (set) Token: 0x060271D9 RID: 160217 RVA: 0x009EA344 File Offset: 0x009E8544
		public unsafe bool Package
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SServerInfo.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SServerInfo.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005B30 RID: 23344
		// (get) Token: 0x060271DA RID: 160218 RVA: 0x009EA355 File Offset: 0x009E8555
		// (set) Token: 0x060271DB RID: 160219 RVA: 0x009EA365 File Offset: 0x009E8565
		public unsafe int Order
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SServerInfo.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SServerInfo.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x060271DC RID: 160220 RVA: 0x009EA376 File Offset: 0x009E8576
		public SServerInfo()
		{
		}

		// Token: 0x060271DD RID: 160221 RVA: 0x009EA37E File Offset: 0x009E857E
		public SServerInfo(string IP, string Port, string Name, string Stream, bool Editor, bool Package, int Order)
		{
			this.IP = IP;
			this.Port = Port;
			this.Name = Name;
			this.Stream = Stream;
			this.Editor = Editor;
			this.Package = Package;
			this.Order = Order;
		}

		// Token: 0x060271DE RID: 160222 RVA: 0x009EA3BB File Offset: 0x009E85BB
		protected override IntPtr GetUStructPtr()
		{
			return SServerInfo.StaticStruct();
		}

		// Token: 0x060271DF RID: 160223 RVA: 0x009EA3C7 File Offset: 0x009E85C7
		[NullableContext(2)]
		public SServerInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060271E0 RID: 160224 RVA: 0x009EA3D1 File Offset: 0x009E85D1
		public SServerInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060271E1 RID: 160225 RVA: 0x009EA3DC File Offset: 0x009E85DC
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SServerInfo(Pointer, false, true);
		}

		// Token: 0x060271E2 RID: 160226 RVA: 0x009EA3E6 File Offset: 0x009E85E6
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SServerInfo(Pointer, MemoryOwner);
		}

		// Token: 0x04014707 RID: 83719
		public const string __ObjectPath = "/Game/Aki/Data/Server/Struct/SServerInfo.SServerInfo";

		// Token: 0x04014708 RID: 83720
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014709 RID: 83721
		internal static int __PropertyOffset_0;

		// Token: 0x0401470A RID: 83722
		internal static int __PropertyOffset_1;

		// Token: 0x0401470B RID: 83723
		internal static int __PropertyOffset_2;

		// Token: 0x0401470C RID: 83724
		internal static int __PropertyOffset_3;

		// Token: 0x0401470D RID: 83725
		internal static int __PropertyOffset_4;

		// Token: 0x0401470E RID: 83726
		internal static int __PropertyOffset_5;

		// Token: 0x0401470F RID: 83727
		internal static int __PropertyOffset_6;
	}
}
