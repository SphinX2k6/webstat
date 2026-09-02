using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Qte
{
	// Token: 0x02003E4B RID: 15947
	[UnrealObjectPath("/Game/Aki/Data/Qte/SCommonQte_SelectOption.SCommonQte_SelectOption")]
	[UnrealStructLayout(88, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 88)]
	public class SCommonQte_SelectOption : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027557 RID: 161111 RVA: 0x009EF5DC File Offset: 0x009ED7DC
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCommonQte_SelectOption._ScriptStructPtr != 0) ? SCommonQte_SelectOption._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Qte/SCommonQte_SelectOption.SCommonQte_SelectOption", ref SCommonQte_SelectOption._ScriptStructPtr);
		}

		// Token: 0x17005C48 RID: 23624
		// (get) Token: 0x06027558 RID: 161112 RVA: 0x009EF600 File Offset: 0x009ED800
		// (set) Token: 0x06027559 RID: 161113 RVA: 0x009EF614 File Offset: 0x009ED814
		public unsafe TEnumAsByte<ECommonQteViewType_SelectOption> ViewType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_SelectOption.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_SelectOption.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005C49 RID: 23625
		// (get) Token: 0x0602755A RID: 161114 RVA: 0x009EF62C File Offset: 0x009ED82C
		// (set) Token: 0x0602755B RID: 161115 RVA: 0x009EF66F File Offset: 0x009ED86F
		[Nullable(1)]
		public TArray<SCommonQteButton> UIConfigList
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<SCommonQteButton> result;
				if ((result = this._UIConfigList) == null)
				{
					result = (this._UIConfigList = new TArray<SCommonQteButton>(base.NativePtr + (IntPtr)SCommonQte_SelectOption.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.UIConfigList.CopyAssign(value);
			}
		}

		// Token: 0x17005C4A RID: 23626
		// (get) Token: 0x0602755C RID: 161116 RVA: 0x009EF67D File Offset: 0x009ED87D
		// (set) Token: 0x0602755D RID: 161117 RVA: 0x009EF68D File Offset: 0x009ED88D
		public unsafe int DefaultOption
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_SelectOption.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_SelectOption.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005C4B RID: 23627
		// (get) Token: 0x0602755E RID: 161118 RVA: 0x009EF69E File Offset: 0x009ED89E
		// (set) Token: 0x0602755F RID: 161119 RVA: 0x009EF6AE File Offset: 0x009ED8AE
		public unsafe bool IsAttachToActor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_SelectOption.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_SelectOption.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005C4C RID: 23628
		// (get) Token: 0x06027560 RID: 161120 RVA: 0x009EF6BF File Offset: 0x009ED8BF
		// (set) Token: 0x06027561 RID: 161121 RVA: 0x009EF6D3 File Offset: 0x009ED8D3
		public unsafe SCommonQte_Attach AttachConfig
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_SelectOption.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_SelectOption.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x06027562 RID: 161122 RVA: 0x009EF6E8 File Offset: 0x009ED8E8
		public SCommonQte_SelectOption()
		{
		}

		// Token: 0x06027563 RID: 161123 RVA: 0x009EF6F0 File Offset: 0x009ED8F0
		public SCommonQte_SelectOption(TEnumAsByte<ECommonQteViewType_SelectOption> ViewType, [Nullable(1)] TArray<SCommonQteButton> UIConfigList, int DefaultOption, bool IsAttachToActor, SCommonQte_Attach AttachConfig)
		{
			this.ViewType = ViewType;
			this.UIConfigList = UIConfigList;
			this.DefaultOption = DefaultOption;
			this.IsAttachToActor = IsAttachToActor;
			this.AttachConfig = AttachConfig;
		}

		// Token: 0x06027564 RID: 161124 RVA: 0x009EF71D File Offset: 0x009ED91D
		protected override IntPtr GetUStructPtr()
		{
			return SCommonQte_SelectOption.StaticStruct();
		}

		// Token: 0x06027565 RID: 161125 RVA: 0x009EF729 File Offset: 0x009ED929
		[NullableContext(2)]
		public SCommonQte_SelectOption(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027566 RID: 161126 RVA: 0x009EF733 File Offset: 0x009ED933
		public SCommonQte_SelectOption(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027567 RID: 161127 RVA: 0x009EF73E File Offset: 0x009ED93E
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCommonQte_SelectOption(Pointer, false, true);
		}

		// Token: 0x06027568 RID: 161128 RVA: 0x009EF748 File Offset: 0x009ED948
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCommonQte_SelectOption(Pointer, MemoryOwner);
		}

		// Token: 0x04014979 RID: 84345
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Data/Qte/SCommonQte_SelectOption.SCommonQte_SelectOption";

		// Token: 0x0401497A RID: 84346
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401497B RID: 84347
		internal static int __PropertyOffset_0;

		// Token: 0x0401497C RID: 84348
		internal static int __PropertyOffset_1;

		// Token: 0x0401497D RID: 84349
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SCommonQteButton> _UIConfigList;

		// Token: 0x0401497E RID: 84350
		internal static int __PropertyOffset_2;

		// Token: 0x0401497F RID: 84351
		internal static int __PropertyOffset_3;

		// Token: 0x04014980 RID: 84352
		internal static int __PropertyOffset_4;
	}
}
