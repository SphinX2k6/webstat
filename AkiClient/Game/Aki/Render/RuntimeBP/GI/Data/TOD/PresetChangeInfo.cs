using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.Data.TOD
{
	// Token: 0x02003CD4 RID: 15572
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/Data/TOD/PresetChangeInfo.PresetChangeInfo")]
	[UnrealStructLayout(24, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class PresetChangeInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06025229 RID: 152105 RVA: 0x009B1B85 File Offset: 0x009AFD85
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (PresetChangeInfo._ScriptStructPtr != 0) ? PresetChangeInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/GI/Data/TOD/PresetChangeInfo.PresetChangeInfo", ref PresetChangeInfo._ScriptStructPtr);
		}

		// Token: 0x17004FD7 RID: 20439
		// (get) Token: 0x0602522A RID: 152106 RVA: 0x009B1BA9 File Offset: 0x009AFDA9
		// (set) Token: 0x0602522B RID: 152107 RVA: 0x009B1BB9 File Offset: 0x009AFDB9
		public unsafe bool ReloadSelected
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PresetChangeInfo.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PresetChangeInfo.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004FD8 RID: 20440
		// (get) Token: 0x0602522C RID: 152108 RVA: 0x009B1BCA File Offset: 0x009AFDCA
		// (set) Token: 0x0602522D RID: 152109 RVA: 0x009B1BDA File Offset: 0x009AFDDA
		public unsafe int Selected
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PresetChangeInfo.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PresetChangeInfo.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17004FD9 RID: 20441
		// (get) Token: 0x0602522E RID: 152110 RVA: 0x009B1BEB File Offset: 0x009AFDEB
		// (set) Token: 0x0602522F RID: 152111 RVA: 0x009B1BFF File Offset: 0x009AFDFF
		public unsafe TEnumAsByte<PresetSelection> Mode
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PresetChangeInfo.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PresetChangeInfo.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17004FDA RID: 20442
		// (get) Token: 0x06025230 RID: 152112 RVA: 0x009B1C14 File Offset: 0x009AFE14
		// (set) Token: 0x06025231 RID: 152113 RVA: 0x009B1C24 File Offset: 0x009AFE24
		public unsafe float TransitionDuration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PresetChangeInfo.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PresetChangeInfo.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17004FDB RID: 20443
		// (get) Token: 0x06025232 RID: 152114 RVA: 0x009B1C35 File Offset: 0x009AFE35
		// (set) Token: 0x06025233 RID: 152115 RVA: 0x009B1C49 File Offset: 0x009AFE49
		public unsafe TEnumAsByte<EEasingFunc> TransitionFunc
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PresetChangeInfo.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PresetChangeInfo.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17004FDC RID: 20444
		// (get) Token: 0x06025234 RID: 152116 RVA: 0x009B1C5E File Offset: 0x009AFE5E
		// (set) Token: 0x06025235 RID: 152117 RVA: 0x009B1C6E File Offset: 0x009AFE6E
		public unsafe float ChangeAfterTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PresetChangeInfo.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PresetChangeInfo.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x06025236 RID: 152118 RVA: 0x009B1C7F File Offset: 0x009AFE7F
		public PresetChangeInfo()
		{
		}

		// Token: 0x06025237 RID: 152119 RVA: 0x009B1C87 File Offset: 0x009AFE87
		public PresetChangeInfo(bool ReloadSelected, int Selected, TEnumAsByte<PresetSelection> Mode, float TransitionDuration, TEnumAsByte<EEasingFunc> TransitionFunc, float ChangeAfterTime)
		{
			this.ReloadSelected = ReloadSelected;
			this.Selected = Selected;
			this.Mode = Mode;
			this.TransitionDuration = TransitionDuration;
			this.TransitionFunc = TransitionFunc;
			this.ChangeAfterTime = ChangeAfterTime;
		}

		// Token: 0x06025238 RID: 152120 RVA: 0x009B1CBC File Offset: 0x009AFEBC
		protected override IntPtr GetUStructPtr()
		{
			return PresetChangeInfo.StaticStruct();
		}

		// Token: 0x06025239 RID: 152121 RVA: 0x009B1CC8 File Offset: 0x009AFEC8
		[NullableContext(2)]
		public PresetChangeInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602523A RID: 152122 RVA: 0x009B1CD2 File Offset: 0x009AFED2
		public PresetChangeInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602523B RID: 152123 RVA: 0x009B1CDD File Offset: 0x009AFEDD
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new PresetChangeInfo(Pointer, false, true);
		}

		// Token: 0x0602523C RID: 152124 RVA: 0x009B1CE7 File Offset: 0x009AFEE7
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new PresetChangeInfo(Pointer, MemoryOwner);
		}

		// Token: 0x040131D9 RID: 78297
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/Data/TOD/PresetChangeInfo.PresetChangeInfo";

		// Token: 0x040131DA RID: 78298
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040131DB RID: 78299
		internal static int __PropertyOffset_0;

		// Token: 0x040131DC RID: 78300
		internal static int __PropertyOffset_1;

		// Token: 0x040131DD RID: 78301
		internal static int __PropertyOffset_2;

		// Token: 0x040131DE RID: 78302
		internal static int __PropertyOffset_3;

		// Token: 0x040131DF RID: 78303
		internal static int __PropertyOffset_4;

		// Token: 0x040131E0 RID: 78304
		internal static int __PropertyOffset_5;
	}
}
