using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Fight.UI
{
	// Token: 0x02003EBF RID: 16063
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Fight/UI/SPanelQteAction.SPanelQteAction")]
	[UnrealStructLayout(72, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 72)]
	public class SPanelQteAction : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027E37 RID: 163383 RVA: 0x009FD26C File Offset: 0x009FB46C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SPanelQteAction._ScriptStructPtr != 0) ? SPanelQteAction._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/UI/SPanelQteAction.SPanelQteAction", ref SPanelQteAction._ScriptStructPtr);
		}

		// Token: 0x17005F5E RID: 24414
		// (get) Token: 0x06027E38 RID: 163384 RVA: 0x009FD290 File Offset: 0x009FB490
		// (set) Token: 0x06027E39 RID: 163385 RVA: 0x009FD2A0 File Offset: 0x009FB4A0
		public unsafe int Target
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPanelQteAction.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPanelQteAction.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005F5F RID: 24415
		// (get) Token: 0x06027E3A RID: 163386 RVA: 0x009FD2B4 File Offset: 0x009FB4B4
		// (set) Token: 0x06027E3B RID: 163387 RVA: 0x009FD2F7 File Offset: 0x009FB4F7
		public TArray<FGameplayTag> AddTags
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FGameplayTag> result;
				if ((result = this._AddTags) == null)
				{
					result = (this._AddTags = new TArray<FGameplayTag>(base.NativePtr + (IntPtr)SPanelQteAction.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.AddTags.CopyAssign(value);
			}
		}

		// Token: 0x17005F60 RID: 24416
		// (get) Token: 0x06027E3C RID: 163388 RVA: 0x009FD308 File Offset: 0x009FB508
		// (set) Token: 0x06027E3D RID: 163389 RVA: 0x009FD34B File Offset: 0x009FB54B
		public TArray<FGameplayTag> RemoveTags
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FGameplayTag> result;
				if ((result = this._RemoveTags) == null)
				{
					result = (this._RemoveTags = new TArray<FGameplayTag>(base.NativePtr + (IntPtr)SPanelQteAction.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.RemoveTags.CopyAssign(value);
			}
		}

		// Token: 0x17005F61 RID: 24417
		// (get) Token: 0x06027E3E RID: 163390 RVA: 0x009FD35C File Offset: 0x009FB55C
		// (set) Token: 0x06027E3F RID: 163391 RVA: 0x009FD39F File Offset: 0x009FB59F
		public TArray<long> AddBuffs
		{
			get
			{
				base.FastCheckIsValid();
				TArray<long> result;
				if ((result = this._AddBuffs) == null)
				{
					result = (this._AddBuffs = new TArray<long>(base.NativePtr + (IntPtr)SPanelQteAction.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.AddBuffs.CopyAssign(value);
			}
		}

		// Token: 0x17005F62 RID: 24418
		// (get) Token: 0x06027E40 RID: 163392 RVA: 0x009FD3B0 File Offset: 0x009FB5B0
		// (set) Token: 0x06027E41 RID: 163393 RVA: 0x009FD3F3 File Offset: 0x009FB5F3
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TArray<TEnumAsByte<EPanelQteCustomAction>> CustomActions
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TArray<TEnumAsByte<EPanelQteCustomAction>> result;
				if ((result = this._CustomActions) == null)
				{
					result = (this._CustomActions = new TArray<TEnumAsByte<EPanelQteCustomAction>>(base.NativePtr + (IntPtr)SPanelQteAction.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.CustomActions.CopyAssign(value);
			}
		}

		// Token: 0x06027E42 RID: 163394 RVA: 0x009FD401 File Offset: 0x009FB601
		public SPanelQteAction()
		{
		}

		// Token: 0x06027E43 RID: 163395 RVA: 0x009FD409 File Offset: 0x009FB609
		public SPanelQteAction(int Target, TArray<FGameplayTag> AddTags, TArray<FGameplayTag> RemoveTags, TArray<long> AddBuffs, [Nullable(new byte[]
		{
			1,
			0
		})] TArray<TEnumAsByte<EPanelQteCustomAction>> CustomActions)
		{
			this.Target = Target;
			this.AddTags = AddTags;
			this.RemoveTags = RemoveTags;
			this.AddBuffs = AddBuffs;
			this.CustomActions = CustomActions;
		}

		// Token: 0x06027E44 RID: 163396 RVA: 0x009FD436 File Offset: 0x009FB636
		protected override IntPtr GetUStructPtr()
		{
			return SPanelQteAction.StaticStruct();
		}

		// Token: 0x06027E45 RID: 163397 RVA: 0x009FD442 File Offset: 0x009FB642
		[NullableContext(2)]
		public SPanelQteAction(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027E46 RID: 163398 RVA: 0x009FD44C File Offset: 0x009FB64C
		public SPanelQteAction(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027E47 RID: 163399 RVA: 0x009FD457 File Offset: 0x009FB657
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SPanelQteAction(Pointer, false, true);
		}

		// Token: 0x06027E48 RID: 163400 RVA: 0x009FD461 File Offset: 0x009FB661
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SPanelQteAction(Pointer, MemoryOwner);
		}

		// Token: 0x04014F09 RID: 85769
		public const string __ObjectPath = "/Game/Aki/Data/Fight/UI/SPanelQteAction.SPanelQteAction";

		// Token: 0x04014F0A RID: 85770
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014F0B RID: 85771
		internal static int __PropertyOffset_0;

		// Token: 0x04014F0C RID: 85772
		internal static int __PropertyOffset_1;

		// Token: 0x04014F0D RID: 85773
		[Nullable(2)]
		private TArray<FGameplayTag> _AddTags;

		// Token: 0x04014F0E RID: 85774
		internal static int __PropertyOffset_2;

		// Token: 0x04014F0F RID: 85775
		[Nullable(2)]
		private TArray<FGameplayTag> _RemoveTags;

		// Token: 0x04014F10 RID: 85776
		internal static int __PropertyOffset_3;

		// Token: 0x04014F11 RID: 85777
		[Nullable(2)]
		private TArray<long> _AddBuffs;

		// Token: 0x04014F12 RID: 85778
		internal static int __PropertyOffset_4;

		// Token: 0x04014F13 RID: 85779
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TArray<TEnumAsByte<EPanelQteCustomAction>> _CustomActions;
	}
}
