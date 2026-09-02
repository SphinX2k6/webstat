using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.FunPlay
{
	// Token: 0x02006778 RID: 26488
	[NullableContext(1)]
	[Nullable(0)]
	public class ActivityFunPlayTabItem : UiPanelBase, IGridProxy<ActivityFunPlayChallengeData>
	{
		// Token: 0x1700A0CE RID: 41166
		// (get) Token: 0x0604206D RID: 270445 RVA: 0x010F0C77 File Offset: 0x010EEE77
		// (set) Token: 0x0604206E RID: 270446 RVA: 0x010F0C7F File Offset: 0x010EEE7F
		public IScrollViewDelegate<IGridProxy<ActivityFunPlayChallengeData>, ActivityFunPlayChallengeData> ScrollViewDelegate { get; set; }

		// Token: 0x1700A0CF RID: 41167
		// (get) Token: 0x0604206F RID: 270447 RVA: 0x010F0C88 File Offset: 0x010EEE88
		// (set) Token: 0x06042070 RID: 270448 RVA: 0x010F0C90 File Offset: 0x010EEE90
		public int GridIndex { get; set; }

		// Token: 0x1700A0D0 RID: 41168
		// (get) Token: 0x06042071 RID: 270449 RVA: 0x010F0C99 File Offset: 0x010EEE99
		// (set) Token: 0x06042072 RID: 270450 RVA: 0x010F0CA1 File Offset: 0x010EEEA1
		public int DisplayIndex { get; set; }

		// Token: 0x06042073 RID: 270451 RVA: 0x010F0CAC File Offset: 0x010EEEAC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 12;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickItem));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06042074 RID: 270452 RVA: 0x010F0EA0 File Offset: 0x010EF0A0
		public void TryBindRedDot()
		{
			if (this.IsRedDotBind || this.ChallengeData == null)
			{
				return;
			}
			this.IsRedDotBind = true;
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.ActivityFunPlay, base.GetItem(10), null, this.ChallengeData.GetChallengeId());
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.ActivityFunPlay, base.GetItem(6), null, this.ChallengeData.GetChallengeId());
		}

		// Token: 0x06042075 RID: 270453 RVA: 0x010F0F0A File Offset: 0x010EF10A
		private void OnClickItem(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				IScrollViewDelegate<IGridProxy<ActivityFunPlayChallengeData>, ActivityFunPlayChallengeData> scrollViewDelegate = this.ScrollViewDelegate;
				if (scrollViewDelegate == null)
				{
					return;
				}
				scrollViewDelegate.SelectGridProxy(this.GridIndex, this.DisplayIndex, true);
			}
		}

		// Token: 0x06042076 RID: 270454 RVA: 0x010F0F2D File Offset: 0x010EF12D
		protected override void OnStart()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x06042077 RID: 270455 RVA: 0x010F0F48 File Offset: 0x010EF148
		protected override void OnBeforeDestroy()
		{
			if (this.ChallengeData == null)
			{
				return;
			}
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.ActivityFunPlay, base.GetItem(10), this.ChallengeData.GetChallengeId());
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.ActivityFunPlay, base.GetItem(6), this.ChallengeData.GetChallengeId());
		}

		// Token: 0x06042078 RID: 270456 RVA: 0x010F0FA1 File Offset: 0x010EF1A1
		private void RefreshView()
		{
			this.RefreshBg();
			this.RefreshTitle();
			this.RefreshFinishedItem();
			this.RefreshLockItem();
		}

		// Token: 0x06042079 RID: 270457 RVA: 0x010F0FBC File Offset: 0x010EF1BC
		private void RefreshBg()
		{
			if (this.ChallengeData == null)
			{
				return;
			}
			base.SetTextureByPath(this.ChallengeData.GetBackgroundTexturePath(), base.GetTexture(11), null, null);
		}

		// Token: 0x0604207A RID: 270458 RVA: 0x010F0FF5 File Offset: 0x010EF1F5
		private void RefreshTitle()
		{
			if (this.ChallengeData == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), this.ChallengeData.GetTabTitle(), Array.Empty<object>());
		}

		// Token: 0x0604207B RID: 270459 RVA: 0x010F1024 File Offset: 0x010EF224
		private void RefreshFinishedItem()
		{
			if (this.ChallengeData == null)
			{
				return;
			}
			bool uiactive = this.ChallengeData.CheckRewardStatus(FunPlayChallengeRewardStatus.FunPlayRewarded);
			UUISprite sprite = base.GetSprite(3);
			if (sprite != null)
			{
				sprite.SetUIActive(uiactive);
			}
			UUISprite sprite2 = base.GetSprite(8);
			if (sprite2 != null)
			{
				sprite2.SetUIActive(uiactive);
			}
			UUISprite sprite3 = base.GetSprite(2);
			if (sprite3 != null)
			{
				sprite3.SetUIActive(false);
			}
			string text = (this.GridIndex + 1).ToString();
			this.SetSpriteByPath(StringUtils.Format("/Game/Aki/UI/UIResources/Common/Atlas/SP_ComRomeText_0{0}.SP_ComRomeText_0{1}", new string[]
			{
				text,
				text
			}), base.GetSprite(7), false, null, null);
		}

		// Token: 0x0604207C RID: 270460 RVA: 0x010F10C4 File Offset: 0x010EF2C4
		private void RefreshLockItem()
		{
			if (this.ChallengeData == null)
			{
				return;
			}
			UUIItem item = base.GetItem(9);
			if (item != null)
			{
				item.SetUIActive(!this.ChallengeData.GetIsUnlock());
			}
			UUIItem item2 = base.GetItem(5);
			if (item2 != null)
			{
				item2.SetUIActive(!this.ChallengeData.GetIsUnlock());
			}
			UUIItem item3 = base.GetItem(4);
			if (item3 == null)
			{
				return;
			}
			item3.SetUIActive(!this.ChallengeData.GetIsUnlock());
		}

		// Token: 0x0604207D RID: 270461 RVA: 0x010F113A File Offset: 0x010EF33A
		public void Refresh(ActivityFunPlayChallengeData data, bool isSelected, int gridIndex)
		{
			this.ChallengeData = data;
			this.TryBindRedDot();
			this.RefreshView();
		}

		// Token: 0x0604207E RID: 270462 RVA: 0x010F114F File Offset: 0x010EF34F
		public void Clear()
		{
		}

		// Token: 0x0604207F RID: 270463 RVA: 0x010F1154 File Offset: 0x010EF354
		public void OnSelected(bool fireEvent)
		{
			if (this.ChallengeData == null)
			{
				return;
			}
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(EToggleState.ETT_Checked, fireEvent, false, false);
			}
			ModelBase<ActivityFunPlayModel>.Instance.SetCurrentChallengeData(this.ChallengeData.GetChallengeId());
			Singleton<EventSystem>.Instance.Emit(EEventName.OnSelectActivityFunPlayChallengeItem);
			this.ChallengeData.RefreshUnlockRedDot();
		}

		// Token: 0x06042080 RID: 270464 RVA: 0x010F11B1 File Offset: 0x010EF3B1
		public void OnDeselected(bool fireEvent)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, fireEvent, false, false);
		}

		// Token: 0x06042081 RID: 270465 RVA: 0x010F11C9 File Offset: 0x010EF3C9
		public object GetKey(ActivityFunPlayChallengeData data, int gridIndex)
		{
			return this.GridIndex;
		}

		// Token: 0x04024D12 RID: 150802
		private const string ROME_ICON_PATH = "/Game/Aki/UI/UIResources/Common/Atlas/SP_ComRomeText_0{0}.SP_ComRomeText_0{1}";

		// Token: 0x04024D16 RID: 150806
		[Nullable(2)]
		private ActivityFunPlayChallengeData ChallengeData;

		// Token: 0x04024D17 RID: 150807
		private bool IsRedDotBind;

		// Token: 0x0200C795 RID: 51093
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D719 RID: 251673
			public const int Toggle = 0;

			// Token: 0x0403D71A RID: 251674
			public const int Title = 1;

			// Token: 0x0403D71B RID: 251675
			public const int SprRome = 2;

			// Token: 0x0403D71C RID: 251676
			public const int SprDone = 3;

			// Token: 0x0403D71D RID: 251677
			public const int LockItemSelected = 4;

			// Token: 0x0403D71E RID: 251678
			public const int LockMask = 5;

			// Token: 0x0403D71F RID: 251679
			public const int RedPointSelected = 6;

			// Token: 0x0403D720 RID: 251680
			public const int SprRomeIcon = 7;

			// Token: 0x0403D721 RID: 251681
			public const int SprDoneSelected = 8;

			// Token: 0x0403D722 RID: 251682
			public const int LockItem = 9;

			// Token: 0x0403D723 RID: 251683
			public const int RedPoint = 10;

			// Token: 0x0403D724 RID: 251684
			public const int TexBg = 11;
		}
	}
}
