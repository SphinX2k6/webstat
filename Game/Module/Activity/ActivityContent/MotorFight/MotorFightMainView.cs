using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066EF RID: 26351
	[NullableContext(2)]
	[Nullable(0)]
	public class MotorFightMainView : UiViewBase
	{
		// Token: 0x06041C69 RID: 269417 RVA: 0x010DF715 File Offset: 0x010DD915
		[NullableContext(1)]
		public MotorFightMainView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06041C6A RID: 269418 RVA: 0x010DF720 File Offset: 0x010DD920
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041C6B RID: 269419 RVA: 0x010DF894 File Offset: 0x010DDA94
		protected override UniTask OnBeforeStartAsync()
		{
			MotorFightMainView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MotorFightMainView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041C6C RID: 269420 RVA: 0x010DF8D8 File Offset: 0x010DDAD8
		protected override void OnBeforeShow()
		{
			List<List<MotorFightLevelData>> levelTreeList = this.MotorFightActivityData.GetLevelTreeList();
			GenericScrollViewNew<MotorFightLevelListPanel, List<MotorFightLevelData>> scrollView = this.ScrollView;
			if (scrollView != null)
			{
				scrollView.RefreshByData(levelTreeList, null, false);
			}
			ButtonItem handBookBtn = this.HandBookBtn;
			if (handBookBtn != null)
			{
				handBookBtn.SetRedDotVisible(this.MotorFightActivityData.IsHandBookHasRedDot());
			}
			ButtonItem talentTreeBtn = this.TalentTreeBtn;
			if (talentTreeBtn != null)
			{
				talentTreeBtn.SetRedDotVisible(this.MotorFightActivityData.IsTalentTreeHasRedDot());
			}
			ButtonItem rewardBtn = this.RewardBtn;
			if (rewardBtn != null)
			{
				rewardBtn.SetRedDotVisible(this.MotorFightActivityData.IsTaskHasRedDot());
			}
			ButtonItem rewardBtn2 = this.RewardBtn;
			if (rewardBtn2 != null)
			{
				rewardBtn2.SetLocalTextNew("PrefabTextItem_391372407_Text", new object[]
				{
					this.MotorFightActivityData.GetFinishedTaskNum(),
					this.MotorFightActivityData.GetTotalTaskNum()
				});
			}
			ButtonItem rankBtn = this.RankBtn;
			if (rankBtn != null)
			{
				rankBtn.SetUiActive(this.MotorFightActivityData.IsEndlessLevelUnlock());
			}
			ButtonItem rankBtn2 = this.RankBtn;
			if (rankBtn2 != null)
			{
				rankBtn2.SetRedDotVisible(false);
			}
			UUIButtonComponent button = base.GetButton(7);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(this.MotorFightActivityData.HasLastSavedLevelData());
			}
			UUIItem item = base.GetItem(8);
			if (item != null)
			{
				item.SetUIActive(!this.MotorFightActivityData.HasLastSavedLevelData());
			}
			UUIItem item2 = base.GetItem(9);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(this.MotorFightActivityData.HasLastSavedLevelData());
		}

		// Token: 0x06041C6D RID: 269421 RVA: 0x010DFA30 File Offset: 0x010DDC30
		[NullableContext(1)]
		private MotorFightLevelListPanel CreateLevelListPanel()
		{
			return new MotorFightLevelListPanel();
		}

		// Token: 0x06041C6E RID: 269422 RVA: 0x010DFA37 File Offset: 0x010DDC37
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x06041C6F RID: 269423 RVA: 0x010DFA40 File Offset: 0x010DDC40
		private void OnHandBookBtnClick(int _)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorFightHandBookView, this.MotorFightActivityData, null);
		}

		// Token: 0x06041C70 RID: 269424 RVA: 0x010DFA58 File Offset: 0x010DDC58
		private void OnTalentBtnClick(int _)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorFightTalentTreeView, this.MotorFightActivityData, null);
		}

		// Token: 0x06041C71 RID: 269425 RVA: 0x010DFA70 File Offset: 0x010DDC70
		private void OnRankBtnClick(int _)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorFightRankView, this.MotorFightActivityData, null);
		}

		// Token: 0x06041C72 RID: 269426 RVA: 0x010DFA88 File Offset: 0x010DDC88
		private void OnRewardBtnClick(int _)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorFightRewardView, this.MotorFightActivityData, null);
		}

		// Token: 0x06041C73 RID: 269427 RVA: 0x010DFAA0 File Offset: 0x010DDCA0
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (!(configParams[0] == "sword_first"))
			{
				return null;
			}
			GenericScrollViewNew<MotorFightLevelListPanel, List<MotorFightLevelData>> scrollView = this.ScrollView;
			object obj;
			if (scrollView == null)
			{
				obj = null;
			}
			else
			{
				GenericLayout<MotorFightLevelListPanel, List<MotorFightLevelData>> genericLayout = scrollView.GetGenericLayout();
				obj = ((genericLayout != null) ? genericLayout.GetLayoutItemByIndex(0) : null);
			}
			object obj2 = obj;
			UUIItem uuiitem = (obj2 != null) ? obj2.GuideGetLevelItem(0) : null;
			if (uuiitem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem,
				uuiitem
			};
		}

		// Token: 0x04024B1F RID: 150303
		private MotorFightActivityData MotorFightActivityData;

		// Token: 0x04024B20 RID: 150304
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		public GenericScrollViewNew<MotorFightLevelListPanel, List<MotorFightLevelData>> ScrollView;

		// Token: 0x04024B21 RID: 150305
		private PopupCaptionItem CaptionItem;

		// Token: 0x04024B22 RID: 150306
		private ButtonItem HandBookBtn;

		// Token: 0x04024B23 RID: 150307
		private ButtonItem TalentTreeBtn;

		// Token: 0x04024B24 RID: 150308
		private ButtonItem RankBtn;

		// Token: 0x04024B25 RID: 150309
		private ButtonItem RewardBtn;

		// Token: 0x0200C730 RID: 50992
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403D52B RID: 251179
			public const int ItemCaption = 0;

			// Token: 0x0403D52C RID: 251180
			public const int LevelScroll = 1;

			// Token: 0x0403D52D RID: 251181
			public const int ItemLevelList = 2;

			// Token: 0x0403D52E RID: 251182
			public const int ItemHandBookBtn = 3;

			// Token: 0x0403D52F RID: 251183
			public const int ItemTalentTreeBtn = 4;

			// Token: 0x0403D530 RID: 251184
			public const int ItemRewardBtn = 5;

			// Token: 0x0403D531 RID: 251185
			public const int ItemRankBtn = 6;

			// Token: 0x0403D532 RID: 251186
			public const int BtnArchive = 7;

			// Token: 0x0403D533 RID: 251187
			public const int ItemArchive = 8;

			// Token: 0x0403D534 RID: 251188
			public const int ItemArchived = 9;
		}
	}
}
