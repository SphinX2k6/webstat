using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.AudioVisualization
{
	// Token: 0x02003DA5 RID: 15781
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/AudioVisualization/SGlobalRtpcEntry.SGlobalRtpcEntry")]
	[UnrealStructLayout(32, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 32)]
	public class SGlobalRtpcEntry : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060269F7 RID: 158199 RVA: 0x009DD841 File Offset: 0x009DBA41
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SGlobalRtpcEntry._ScriptStructPtr != 0) ? SGlobalRtpcEntry._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/AudioVisualization/SGlobalRtpcEntry.SGlobalRtpcEntry", ref SGlobalRtpcEntry._ScriptStructPtr);
		}

		// Token: 0x17005862 RID: 22626
		// (get) Token: 0x060269F8 RID: 158200 RVA: 0x009DD865 File Offset: 0x009DBA65
		// (set) Token: 0x060269F9 RID: 158201 RVA: 0x009DD879 File Offset: 0x009DBA79
		[Nullable(2)]
		public unsafe UAkRtpc RtpcFile
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkRtpc>(base.NativePtr / (IntPtr)sizeof(void*) + SGlobalRtpcEntry.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SGlobalRtpcEntry.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17005863 RID: 22627
		// (get) Token: 0x060269FA RID: 158202 RVA: 0x009DD88E File Offset: 0x009DBA8E
		// (set) Token: 0x060269FB RID: 158203 RVA: 0x009DD8A2 File Offset: 0x009DBAA2
		public unsafe string Identifier
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SGlobalRtpcEntry.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SGlobalRtpcEntry.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x17005864 RID: 22628
		// (get) Token: 0x060269FC RID: 158204 RVA: 0x009DD8B7 File Offset: 0x009DBAB7
		// (set) Token: 0x060269FD RID: 158205 RVA: 0x009DD8C7 File Offset: 0x009DBAC7
		public unsafe float Min
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SGlobalRtpcEntry.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SGlobalRtpcEntry.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005865 RID: 22629
		// (get) Token: 0x060269FE RID: 158206 RVA: 0x009DD8D8 File Offset: 0x009DBAD8
		// (set) Token: 0x060269FF RID: 158207 RVA: 0x009DD8E8 File Offset: 0x009DBAE8
		public unsafe float Max
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SGlobalRtpcEntry.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SGlobalRtpcEntry.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x06026A00 RID: 158208 RVA: 0x009DD8F9 File Offset: 0x009DBAF9
		public SGlobalRtpcEntry()
		{
		}

		// Token: 0x06026A01 RID: 158209 RVA: 0x009DD901 File Offset: 0x009DBB01
		public SGlobalRtpcEntry(UAkRtpc RtpcFile, string Identifier, float Min, float Max)
		{
			this.RtpcFile = RtpcFile;
			this.Identifier = Identifier;
			this.Min = Min;
			this.Max = Max;
		}

		// Token: 0x06026A02 RID: 158210 RVA: 0x009DD926 File Offset: 0x009DBB26
		protected override IntPtr GetUStructPtr()
		{
			return SGlobalRtpcEntry.StaticStruct();
		}

		// Token: 0x06026A03 RID: 158211 RVA: 0x009DD932 File Offset: 0x009DBB32
		[NullableContext(2)]
		public SGlobalRtpcEntry(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06026A04 RID: 158212 RVA: 0x009DD93C File Offset: 0x009DBB3C
		public SGlobalRtpcEntry(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06026A05 RID: 158213 RVA: 0x009DD947 File Offset: 0x009DBB47
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SGlobalRtpcEntry(Pointer, false, true);
		}

		// Token: 0x06026A06 RID: 158214 RVA: 0x009DD951 File Offset: 0x009DBB51
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SGlobalRtpcEntry(Pointer, MemoryOwner);
		}

		// Token: 0x04014181 RID: 82305
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/AudioVisualization/SGlobalRtpcEntry.SGlobalRtpcEntry";

		// Token: 0x04014182 RID: 82306
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014183 RID: 82307
		internal static int __PropertyOffset_0;

		// Token: 0x04014184 RID: 82308
		internal static int __PropertyOffset_1;

		// Token: 0x04014185 RID: 82309
		internal static int __PropertyOffset_2;

		// Token: 0x04014186 RID: 82310
		internal static int __PropertyOffset_3;
	}
}
