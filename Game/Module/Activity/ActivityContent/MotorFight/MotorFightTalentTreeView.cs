using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066F5 RID: 26357
	[NullableContext(2)]
	[Nullable(0)]
	public class MotorFightTalentTreeView : UiViewBase
	{
		// Token: 0x06041CA6 RID: 269478 RVA: 0x010E0A66 File Offset: 0x010DEC66
		[NullableContext(1)]
		public MotorFightTalentTreeView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06041CA7 RID: 269479 RVA: 0x010E0A7C File Offset: 0x010DEC7C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 11;
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
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041CA8 RID: 269480 RVA: 0x010E0C14 File Offset: 0x010DEE14
		protected override UniTask OnBeforeStartAsync()
		{
			MotorFightTalentTreeView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MotorFightTalentTreeView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041CA9 RID: 269481 RVA: 0x010E0C58 File Offset: 0x010DEE58
		private void RefreshDetailPanel()
		{
			this.SetSpriteByPath(this.TalentData.Icon, base.GetSprite(3), false, null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), this.TalentData.Name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), this.TalentData.Desc, this.TalentData.DescParams);
			bool flag = this.ActivityData.GetTalentCoinNum() >= this.TalentData.Cost;
			UUIText text = base.GetText(6);
			text.SetText(this.TalentData.Cost.ToString(), true);
			UUIItem uuiitem = text;
			bool bUseChangeColor = !flag;
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			bool flag2 = this.ActivityData.IsPreNodeAllUnlock(this.TalentData) && this.TalentData.IsFinishPreCondition;
			ButtonItem confirmBtn = this.ConfirmBtn;
			if (confirmBtn != null)
			{
				confirmBtn.SetUiActive(flag2 && !this.TalentData.IsUnLock);
			}
			FunctionalPanelConditionLock lockPanel = this.LockPanel;
			if (lockPanel != null)
			{
				lockPanel.SetUiActive(!flag2 && !this.TalentData.IsUnLock);
			}
			UUIItem item = base.GetItem(9);
			if (item != null)
			{
				item.SetUIActive(this.TalentData.IsUnLock);
			}
			string textId = this.TalentData.IsFinishPreCondition ? "MotorFightGame_TechTree_01" : LevelGeneralCommons.GetConditionGroupHintText(this.TalentData.ConditionId);
			FunctionalPanelConditionLock lockPanel2 = this.LockPanel;
			if (lockPanel2 == null)
			{
				return;
			}
			lockPanel2.SetTextByTextId(textId, Array.Empty<string>());
		}

		// Token: 0x06041CAA RID: 269482 RVA: 0x010E0DF0 File Offset: 0x010DEFF0
		[NullableContext(1)]
		private void OnSelectTalentNode(MotorFightTalentNodeItem talentNode)
		{
			if (this.CurSelectNode != null)
			{
				this.CurSelectNode.SetToggleState(EToggleState.ETT_UnChecked);
			}
			this.CurSelectNode = talentNode;
			this.CurSelectNode.SetToggleState(EToggleState.ETT_Checked);
			this.TalentData = talentNode.Data;
			this.ActivityData.SelectedTalentNodeId = this.TalentData.Id;
			this.RefreshDetailPanel();
			base.PlayOrReplaySequence("Switch", false, null);
		}

		// Token: 0x06041CAB RID: 269483 RVA: 0x010E0E61 File Offset: 0x010DF061
		[NullableContext(1)]
		private MotorFightTalentGridPanel CreateTalentGridPanel()
		{
			return new MotorFightTalentGridPanel
			{
				OnSelectTalentNode = new Action<MotorFightTalentNodeItem>(this.OnSelectTalentNode)
			};
		}

		// Token: 0x06041CAC RID: 269484 RVA: 0x010E0E7C File Offset: 0x010DF07C
		private void OnConfirmBtnClick(int _)
		{
			if (this.ActivityData.GetTalentCoinNum() < this.CurSelectNode.Data.Cost)
			{
				string localTextNew = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<InventoryConfig>.Instance.GetItemConfigData(this.ActivityData.TalentTreeItemId).Name, null);
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ItemConsumption_Talent", new object[]
				{
					localTextNew
				});
				return;
			}
			ControllerBase<MotorFightController>.Instance.RequestUnlockTalentNode(this.CurSelectNode.Data.Id, delegate
			{
				this.RefreshDetailPanel();
				GenericScrollViewNew<MotorFightTalentGridPanel, List<MotorFightTalentData>> scrollView = this.ScrollView;
				if (scrollView != null)
				{
					scrollView.RefreshByData(this.TalentTreeList, null, false);
				}
				LevelUpSuccessEffectData levelUpSuccessEffectData = new LevelUpSuccessEffectData();
				levelUpSuccessEffectData.Title = "MotorFightGame_TechTreeUnlock_01";
				List<SingleText> list = new List<SingleText>();
				SingleText singleText = new SingleText();
				singleText.TextId = this.TalentData.Desc;
				singleText.Params = (from x in this.TalentData.DescParams
				select x.ToString()).ToArray<string>();
				list.Add(singleText);
				levelUpSuccessEffectData.TextList = list;
				LevelUpSuccessEffectData data = levelUpSuccessEffectData;
				ControllerBase<RoleLevelUpSuccessController>.Instance.OpenSuccessEffectView(data, null);
			});
		}

		// Token: 0x06041CAD RID: 269485 RVA: 0x010E0F07 File Offset: 0x010DF107
		private void OnCloseBtnClick()
		{
			this.ActivityData.SelectedTalentNodeId = 0;
			base.CloseMe(null);
		}

		// Token: 0x04024B38 RID: 150328
		private MotorFightActivityData ActivityData;

		// Token: 0x04024B39 RID: 150329
		private MotorFightTalentData TalentData;

		// Token: 0x04024B3A RID: 150330
		[Nullable(1)]
		private List<List<MotorFightTalentData>> TalentTreeList = new List<List<MotorFightTalentData>>();

		// Token: 0x04024B3B RID: 150331
		private PopupCaptionItem CaptionItem;

		// Token: 0x04024B3C RID: 150332
		private ButtonItem ConfirmBtn;

		// Token: 0x04024B3D RID: 150333
		private FunctionalPanelConditionLock LockPanel;

		// Token: 0x04024B3E RID: 150334
		public MotorFightTalentNodeItem CurSelectNode;

		// Token: 0x04024B3F RID: 150335
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		public GenericScrollViewNew<MotorFightTalentGridPanel, List<MotorFightTalentData>> ScrollView;

		// Token: 0x0200C740 RID: 51008
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D586 RID: 251270
			public const int ItemCaption = 0;

			// Token: 0x0403D587 RID: 251271
			public const int ScrollViewLayout = 1;

			// Token: 0x0403D588 RID: 251272
			public const int ItemTalentNode = 2;

			// Token: 0x0403D589 RID: 251273
			public const int SpriteIcon = 3;

			// Token: 0x0403D58A RID: 251274
			public const int TextDesc = 4;

			// Token: 0x0403D58B RID: 251275
			public const int ItemConfirmBtn = 5;

			// Token: 0x0403D58C RID: 251276
			public const int TextCostNum = 6;

			// Token: 0x0403D58D RID: 251277
			public const int TextureCostIcon = 7;

			// Token: 0x0403D58E RID: 251278
			public const int ItemLockPanel = 8;

			// Token: 0x0403D58F RID: 251279
			public const int ItemUnlockPanel = 9;

			// Token: 0x0403D590 RID: 251280
			public const int TextTalentName = 10;
		}
	}
}
