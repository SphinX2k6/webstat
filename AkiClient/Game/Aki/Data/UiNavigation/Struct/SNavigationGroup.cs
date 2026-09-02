using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.UiNavigation.Struct
{
	// Token: 0x02003DF7 RID: 15863
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/UiNavigation/Struct/SNavigationGroup.SNavigationGroup")]
	[UnrealStructLayout(184, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 179)]
	public class SNavigationGroup : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602705F RID: 159839 RVA: 0x009E837A File Offset: 0x009E657A
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SNavigationGroup._ScriptStructPtr != 0) ? SNavigationGroup._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/UiNavigation/Struct/SNavigationGroup.SNavigationGroup", ref SNavigationGroup._ScriptStructPtr);
		}

		// Token: 0x17005A8F RID: 23183
		// (get) Token: 0x06027060 RID: 159840 RVA: 0x009E839E File Offset: 0x009E659E
		// (set) Token: 0x06027061 RID: 159841 RVA: 0x009E83B2 File Offset: 0x009E65B2
		public unsafe string GroupName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SNavigationGroup.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SNavigationGroup.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17005A90 RID: 23184
		// (get) Token: 0x06027062 RID: 159842 RVA: 0x009E83C7 File Offset: 0x009E65C7
		// (set) Token: 0x06027063 RID: 159843 RVA: 0x009E83D7 File Offset: 0x009E65D7
		public unsafe int GroupType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SNavigationGroup.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SNavigationGroup.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005A91 RID: 23185
		// (get) Token: 0x06027064 RID: 159844 RVA: 0x009E83E8 File Offset: 0x009E65E8
		// (set) Token: 0x06027065 RID: 159845 RVA: 0x009E83FC File Offset: 0x009E65FC
		public unsafe string PrevGroupName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SNavigationGroup.__PropertyOffset_2)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SNavigationGroup.__PropertyOffset_2)), value);
			}
		}

		// Token: 0x17005A92 RID: 23186
		// (get) Token: 0x06027066 RID: 159846 RVA: 0x009E8411 File Offset: 0x009E6611
		// (set) Token: 0x06027067 RID: 159847 RVA: 0x009E8425 File Offset: 0x009E6625
		public unsafe string NextGroupName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SNavigationGroup.__PropertyOffset_3)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SNavigationGroup.__PropertyOffset_3)), value);
			}
		}

		// Token: 0x17005A93 RID: 23187
		// (get) Token: 0x06027068 RID: 159848 RVA: 0x009E843A File Offset: 0x009E663A
		// (set) Token: 0x06027069 RID: 159849 RVA: 0x009E844E File Offset: 0x009E664E
		public unsafe string InsideGroupName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SNavigationGroup.__PropertyOffset_4)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SNavigationGroup.__PropertyOffset_4)), value);
			}
		}

		// Token: 0x17005A94 RID: 23188
		// (get) Token: 0x0602706A RID: 159850 RVA: 0x009E8464 File Offset: 0x009E6664
		// (set) Token: 0x0602706B RID: 159851 RVA: 0x009E84A7 File Offset: 0x009E66A7
		public TArray<string> ExtraInsideGroupNameList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._ExtraInsideGroupNameList) == null)
				{
					result = (this._ExtraInsideGroupNameList = new TArray<string>(base.NativePtr + (IntPtr)SNavigationGroup.__PropertyOffset_5, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ExtraInsideGroupNameList.CopyAssign(value);
			}
		}

		// Token: 0x17005A95 RID: 23189
		// (get) Token: 0x0602706C RID: 159852 RVA: 0x009E84B8 File Offset: 0x009E66B8
		// (set) Token: 0x0602706D RID: 159853 RVA: 0x009E84FB File Offset: 0x009E66FB
		public TMap<string, string> GroupNameMap
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, string> result;
				if ((result = this._GroupNameMap) == null)
				{
					result = (this._GroupNameMap = new TMap<string, string>(base.NativePtr + (IntPtr)SNavigationGroup.__PropertyOffset_6, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.GroupNameMap.CopyAssign(value);
			}
		}

		// Token: 0x17005A96 RID: 23190
		// (get) Token: 0x0602706E RID: 159854 RVA: 0x009E8509 File Offset: 0x009E6709
		// (set) Token: 0x0602706F RID: 159855 RVA: 0x009E8519 File Offset: 0x009E6719
		public unsafe UINavigationWrapMode HorizontalWrapMode
		{
			get
			{
				return (UINavigationWrapMode)(*(base.NativePtr + (IntPtr)SNavigationGroup.__PropertyOffset_7));
			}
			set
			{
				*(base.NativePtr + (IntPtr)SNavigationGroup.__PropertyOffset_7) = (byte)value;
			}
		}

		// Token: 0x17005A97 RID: 23191
		// (get) Token: 0x06027070 RID: 159856 RVA: 0x009E852A File Offset: 0x009E672A
		// (set) Token: 0x06027071 RID: 159857 RVA: 0x009E853A File Offset: 0x009E673A
		public unsafe UINavigationPriorityMode HorizontalPriorityMode
		{
			get
			{
				return (UINavigationPriorityMode)(*(base.NativePtr + (IntPtr)SNavigationGroup.__PropertyOffset_8));
			}
			set
			{
				*(base.NativePtr + (IntPtr)SNavigationGroup.__PropertyOffset_8) = (byte)value;
			}
		}

		// Token: 0x17005A98 RID: 23192
		// (get) Token: 0x06027072 RID: 159858 RVA: 0x009E854B File Offset: 0x009E674B
		// (set) Token: 0x06027073 RID: 159859 RVA: 0x009E855B File Offset: 0x009E675B
		public unsafe UINavigationWrapMode VerticalWrapMode
		{
			get
			{
				return (UINavigationWrapMode)(*(base.NativePtr + (IntPtr)SNavigationGroup.__PropertyOffset_9));
			}
			set
			{
				*(base.NativePtr + (IntPtr)SNavigationGroup.__PropertyOffset_9) = (byte)value;
			}
		}

		// Token: 0x17005A99 RID: 23193
		// (get) Token: 0x06027074 RID: 159860 RVA: 0x009E856C File Offset: 0x009E676C
		// (set) Token: 0x06027075 RID: 159861 RVA: 0x009E857C File Offset: 0x009E677C
		public unsafe UINavigationPriorityMode VerticalPriorityMode
		{
			get
			{
				return (UINavigationPriorityMode)(*(base.NativePtr + (IntPtr)SNavigationGroup.__PropertyOffset_10));
			}
			set
			{
				*(base.NativePtr + (IntPtr)SNavigationGroup.__PropertyOffset_10) = (byte)value;
			}
		}

		// Token: 0x17005A9A RID: 23194
		// (get) Token: 0x06027076 RID: 159862 RVA: 0x009E858D File Offset: 0x009E678D
		// (set) Token: 0x06027077 RID: 159863 RVA: 0x009E859D File Offset: 0x009E679D
		public unsafe bool SelectableMemory
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SNavigationGroup.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SNavigationGroup.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005A9B RID: 23195
		// (get) Token: 0x06027078 RID: 159864 RVA: 0x009E85AE File Offset: 0x009E67AE
		// (set) Token: 0x06027079 RID: 159865 RVA: 0x009E85BE File Offset: 0x009E67BE
		public unsafe bool AllowNavigationInSelfDynamic
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SNavigationGroup.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SNavigationGroup.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005A9C RID: 23196
		// (get) Token: 0x0602707A RID: 159866 RVA: 0x009E85CF File Offset: 0x009E67CF
		// (set) Token: 0x0602707B RID: 159867 RVA: 0x009E85DF File Offset: 0x009E67DF
		public unsafe bool RefreshNavigation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SNavigationGroup.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SNavigationGroup.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005A9D RID: 23197
		// (get) Token: 0x0602707C RID: 159868 RVA: 0x009E85F0 File Offset: 0x009E67F0
		// (set) Token: 0x0602707D RID: 159869 RVA: 0x009E8600 File Offset: 0x009E6800
		public unsafe bool SuitableListenerByNoDynamic
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SNavigationGroup.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SNavigationGroup.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005A9E RID: 23198
		// (get) Token: 0x0602707E RID: 159870 RVA: 0x009E8611 File Offset: 0x009E6811
		// (set) Token: 0x0602707F RID: 159871 RVA: 0x009E8621 File Offset: 0x009E6821
		public unsafe bool SlideToLeftOrTop
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SNavigationGroup.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SNavigationGroup.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005A9F RID: 23199
		// (get) Token: 0x06027080 RID: 159872 RVA: 0x009E8632 File Offset: 0x009E6832
		// (set) Token: 0x06027081 RID: 159873 RVA: 0x009E8642 File Offset: 0x009E6842
		public unsafe bool SlideToRightOrDown
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SNavigationGroup.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SNavigationGroup.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005AA0 RID: 23200
		// (get) Token: 0x06027082 RID: 159874 RVA: 0x009E8653 File Offset: 0x009E6853
		// (set) Token: 0x06027083 RID: 159875 RVA: 0x009E8663 File Offset: 0x009E6863
		public unsafe bool WaitScrollAnimation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SNavigationGroup.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SNavigationGroup.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x06027084 RID: 159876 RVA: 0x009E8674 File Offset: 0x009E6874
		public SNavigationGroup()
		{
		}

		// Token: 0x06027085 RID: 159877 RVA: 0x009E867C File Offset: 0x009E687C
		public SNavigationGroup(string GroupName, int GroupType, string PrevGroupName, string NextGroupName, string InsideGroupName, TArray<string> ExtraInsideGroupNameList, TMap<string, string> GroupNameMap, UINavigationWrapMode HorizontalWrapMode, UINavigationPriorityMode HorizontalPriorityMode, UINavigationWrapMode VerticalWrapMode, UINavigationPriorityMode VerticalPriorityMode, bool SelectableMemory, bool AllowNavigationInSelfDynamic, bool RefreshNavigation, bool SuitableListenerByNoDynamic, bool SlideToLeftOrTop, bool SlideToRightOrDown, bool WaitScrollAnimation)
		{
			this.GroupName = GroupName;
			this.GroupType = GroupType;
			this.PrevGroupName = PrevGroupName;
			this.NextGroupName = NextGroupName;
			this.InsideGroupName = InsideGroupName;
			this.ExtraInsideGroupNameList = ExtraInsideGroupNameList;
			this.GroupNameMap = GroupNameMap;
			this.HorizontalWrapMode = HorizontalWrapMode;
			this.HorizontalPriorityMode = HorizontalPriorityMode;
			this.VerticalWrapMode = VerticalWrapMode;
			this.VerticalPriorityMode = VerticalPriorityMode;
			this.SelectableMemory = SelectableMemory;
			this.AllowNavigationInSelfDynamic = AllowNavigationInSelfDynamic;
			this.RefreshNavigation = RefreshNavigation;
			this.SuitableListenerByNoDynamic = SuitableListenerByNoDynamic;
			this.SlideToLeftOrTop = SlideToLeftOrTop;
			this.SlideToRightOrDown = SlideToRightOrDown;
			this.WaitScrollAnimation = WaitScrollAnimation;
		}

		// Token: 0x06027086 RID: 159878 RVA: 0x009E871C File Offset: 0x009E691C
		protected override IntPtr GetUStructPtr()
		{
			return SNavigationGroup.StaticStruct();
		}

		// Token: 0x06027087 RID: 159879 RVA: 0x009E8728 File Offset: 0x009E6928
		[NullableContext(2)]
		public SNavigationGroup(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027088 RID: 159880 RVA: 0x009E8732 File Offset: 0x009E6932
		public SNavigationGroup(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027089 RID: 159881 RVA: 0x009E873D File Offset: 0x009E693D
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SNavigationGroup(Pointer, false, true);
		}

		// Token: 0x0602708A RID: 159882 RVA: 0x009E8747 File Offset: 0x009E6947
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SNavigationGroup(Pointer, MemoryOwner);
		}

		// Token: 0x04014621 RID: 83489
		public const string __ObjectPath = "/Game/Aki/Data/UiNavigation/Struct/SNavigationGroup.SNavigationGroup";

		// Token: 0x04014622 RID: 83490
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014623 RID: 83491
		internal static int __PropertyOffset_0;

		// Token: 0x04014624 RID: 83492
		internal static int __PropertyOffset_1;

		// Token: 0x04014625 RID: 83493
		internal static int __PropertyOffset_2;

		// Token: 0x04014626 RID: 83494
		internal static int __PropertyOffset_3;

		// Token: 0x04014627 RID: 83495
		internal static int __PropertyOffset_4;

		// Token: 0x04014628 RID: 83496
		internal static int __PropertyOffset_5;

		// Token: 0x04014629 RID: 83497
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _ExtraInsideGroupNameList;

		// Token: 0x0401462A RID: 83498
		internal static int __PropertyOffset_6;

		// Token: 0x0401462B RID: 83499
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TMap<string, string> _GroupNameMap;

		// Token: 0x0401462C RID: 83500
		internal static int __PropertyOffset_7;

		// Token: 0x0401462D RID: 83501
		internal static int __PropertyOffset_8;

		// Token: 0x0401462E RID: 83502
		internal static int __PropertyOffset_9;

		// Token: 0x0401462F RID: 83503
		internal static int __PropertyOffset_10;

		// Token: 0x04014630 RID: 83504
		internal static int __PropertyOffset_11;

		// Token: 0x04014631 RID: 83505
		internal static int __PropertyOffset_12;

		// Token: 0x04014632 RID: 83506
		internal static int __PropertyOffset_13;

		// Token: 0x04014633 RID: 83507
		internal static int __PropertyOffset_14;

		// Token: 0x04014634 RID: 83508
		internal static int __PropertyOffset_15;

		// Token: 0x04014635 RID: 83509
		internal static int __PropertyOffset_16;

		// Token: 0x04014636 RID: 83510
		internal static int __PropertyOffset_17;
	}
}
