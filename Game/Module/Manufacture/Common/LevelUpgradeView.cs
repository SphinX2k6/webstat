using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Manufacture.Compose;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Manufacture.Common
{
	// Token: 0x020059EC RID: 23020
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelUpgradeView : UiViewBase
	{
		// Token: 0x0603A50C RID: 238860 RVA: 0x00EC8ABB File Offset: 0x00EC6CBB
		public LevelUpgradeView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603A50D RID: 238861 RVA: 0x00EC8ACC File Offset: 0x00EC6CCC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 16;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 5;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnLeft));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnRight));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(14, new Action(this.OnClickBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(15, new Action(this.OnClickBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603A50E RID: 238862 RVA: 0x00EC8DD6 File Offset: 0x00EC6FD6
		protected override void OnBeforeDestroy()
		{
			if (this.RewardItemLayout != null)
			{
				this.RewardItemLayout.ClearChildren();
				this.RewardItemLayout = null;
			}
			this.StarLayout.ClearChildren();
		}

		// Token: 0x0603A50F RID: 238863 RVA: 0x00EC8DFD File Offset: 0x00EC6FFD
		protected override void OnBeforeShow()
		{
			this.RefreshConfirmButton();
			IUiPopFrameInterface childPopView = this.ChildPopView;
			if (childPopView == null)
			{
				return;
			}
			CommonPopViewBase popItem = childPopView.PopItem;
			if (popItem == null)
			{
				return;
			}
			popItem.SetTexBgVisible(false);
		}

		// Token: 0x0603A510 RID: 238864 RVA: 0x00EC8E20 File Offset: 0x00EC7020
		protected override void OnStart()
		{
			this.RewardItemLayout = new GenericLayout<LevelRewardItem, IRewardData>(base.GetHorizontalLayout(7), new Func<LevelRewardItem>(this.InitReward), null, false, true);
			this.TmpRewardItem = new List<IRewardData>();
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(12), "ComposeUpgradeButtonText", Array.Empty<object>());
			this.StarLayout = new GenericLayoutNew<StarItem>(base.GetHorizontalLayout(11), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<StarItem>(this.OnCreateStarProxy), null);
			base.GetButton(4).SetCanClickWhenDisable(true);
			Singleton<EventSystem>.Instance.Emit<EViewType>(EEventName.SwitchViewType, EViewType.LevelViewType);
			if (this.IsFirstShow)
			{
				this.IsFirstShow = false;
			}
			Singleton<CommonManager>.Instance.SetSelectedLevel(Singleton<CommonManager>.Instance.GetCurrentRewardLevel().Value);
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.ComposeReagentProduction, base.GetItem(13), null, 0);
			this.Refresh();
		}

		// Token: 0x0603A511 RID: 238865 RVA: 0x00EC8EFC File Offset: 0x00EC70FC
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private ILayoutItem<StarItem> OnCreateStarProxy(object data, UUIItem uiItem, int index)
		{
			if (data is bool)
			{
				bool state = (bool)data;
				StarItem starItem = new StarItem();
				starItem.CreateThenShowByActor(uiItem.GetOwner(), null);
				starItem.SetState(state);
				return new LayoutItem<StarItem>
				{
					Key = index,
					Value = starItem
				};
			}
			return null;
		}

		// Token: 0x0603A512 RID: 238866 RVA: 0x00EC8F4E File Offset: 0x00EC714E
		private LevelRewardItem InitReward()
		{
			return new LevelRewardItem();
		}

		// Token: 0x0603A513 RID: 238867 RVA: 0x00EC8F58 File Offset: 0x00EC7158
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.UpgradeComposeLevel, new Action(this.ShowRewardView));
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OpenView));
			Singleton<EventSystem>.Instance.Add(EEventName.SwitchComposeType, new Action(this.SwitchComposeType));
		}

		// Token: 0x0603A514 RID: 238868 RVA: 0x00EC8FB8 File Offset: 0x00EC71B8
		protected override void OnRemoveEventListener()
		{
			if (!this.IsFirstShow)
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.UpgradeComposeLevel, new Action(this.ShowRewardView));
			}
			Singleton<EventSystem>.Instance.Remove(EEventName.OpenView, new Action<EUiViewName, int>(this.OpenView));
			Singleton<EventSystem>.Instance.Remove(EEventName.SwitchComposeType, new Action(this.SwitchComposeType));
		}

		// Token: 0x0603A515 RID: 238869 RVA: 0x00EC901D File Offset: 0x00EC721D
		private void ShowRewardView()
		{
			if (this.TmpRewardItem.Count == 0)
			{
				return;
			}
			this.Update();
		}

		// Token: 0x0603A516 RID: 238870 RVA: 0x00EC9033 File Offset: 0x00EC7233
		private void OpenView(EUiViewName uiView, int viewId)
		{
			if (uiView == EUiViewName.WorldMapView)
			{
				base.CloseMe(null);
			}
		}

		// Token: 0x0603A517 RID: 238871 RVA: 0x00EC9049 File Offset: 0x00EC7249
		private void SwitchComposeType()
		{
			base.CloseMe(null);
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ItemTipsView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.ItemTipsView, null);
			}
		}

		// Token: 0x0603A518 RID: 238872 RVA: 0x00EC9074 File Offset: 0x00EC7274
		private void Update()
		{
			Singleton<CommonManager>.Instance.SetSelectedLevel(Singleton<CommonManager>.Instance.GetCurrentRewardLevel().Value);
			this.Refresh();
		}

		// Token: 0x0603A519 RID: 238873 RVA: 0x00EC90A4 File Offset: 0x00EC72A4
		private void Refresh()
		{
			this.RefreshTypeIconSprite();
			this.RefreshName();
			this.RefreshInfo();
			this.RefreshLevel();
			this.RefreshSumExp();
			this.RefreshExpBarSprite();
			this.RefreshConfirmButton();
			this.RefreshRewardList();
			this.RefreshLeftAndRightButtonEnable();
			this.RefreshRewardItem();
			this.RefreshRedDotVisible();
		}

		// Token: 0x0603A51A RID: 238874 RVA: 0x00EC90F4 File Offset: 0x00EC72F4
		private void RefreshTypeIconSprite()
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_ComposeType");
			base.SetTextureByPath(resourcePath, base.GetTexture(9), null, null);
		}

		// Token: 0x0603A51B RID: 238875 RVA: 0x00EC912C File Offset: 0x00EC732C
		private void RefreshName()
		{
			SynthesisLevel? composeLevelByLevel = Singleton<CommonManager>.Instance.GetComposeLevelByLevel(Singleton<CommonManager>.Instance.GetSelectedLevel().Value);
			string localText = ConfigBase<ComposeConfig>.Instance.GetLocalText(composeLevelByLevel.Value.Name);
			base.GetText(0).SetText(localText, true);
		}

		// Token: 0x0603A51C RID: 238876 RVA: 0x00EC9180 File Offset: 0x00EC7380
		private void RefreshInfo()
		{
			SynthesisLevel? composeLevelByLevel = Singleton<CommonManager>.Instance.GetComposeLevelByLevel(Singleton<CommonManager>.Instance.GetSelectedLevel().Value);
			string localText = ConfigBase<ComposeConfig>.Instance.GetLocalText(composeLevelByLevel.Value.AttributesDescription);
			base.GetText(1).SetText(localText, true);
		}

		// Token: 0x0603A51D RID: 238877 RVA: 0x00EC91D4 File Offset: 0x00EC73D4
		private void RefreshLevel()
		{
			List<bool> list = new List<bool>(new bool[Singleton<CommonManager>.Instance.GetComposeMaxLevel().Value]);
			for (int i = 0; i < Singleton<CommonManager>.Instance.GetSelectedLevel().Value; i++)
			{
				list[i] = true;
			}
			this.StarLayout.RebuildLayoutByDataNew<bool>(list, null);
		}

		// Token: 0x0603A51E RID: 238878 RVA: 0x00EC9238 File Offset: 0x00EC7438
		private void RefreshSumExp()
		{
			int value = Singleton<CommonManager>.Instance.GetCurrentRewardTotalProficiency().Value;
			string newText;
			if (Singleton<CommonManager>.Instance.GetSelectedLevel().Value == Singleton<CommonManager>.Instance.GetComposeMaxLevel().Value)
			{
				newText = "MAX";
			}
			else
			{
				int? sumExpByLevel = Singleton<CommonManager>.Instance.GetSumExpByLevel(Singleton<CommonManager>.Instance.GetSelectedLevel().Value);
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(value);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int?>(sumExpByLevel);
				newText = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			base.GetText(2).SetText(newText, true);
		}

		// Token: 0x0603A51F RID: 238879 RVA: 0x00EC92E4 File Offset: 0x00EC74E4
		private void RefreshExpBarSprite()
		{
			int value = Singleton<CommonManager>.Instance.GetCurrentRewardTotalProficiency().Value;
			int? sumExpByLevel = Singleton<CommonManager>.Instance.GetSumExpByLevel(Singleton<CommonManager>.Instance.GetSelectedLevel().Value);
			double num = (double)Singleton<MathUtils>.Instance.GetFloatPointFloor((float)value / (float)sumExpByLevel.Value, 3);
			num = ((num > 1.0) ? 1.0 : num);
			base.GetSprite(3).SetFillAmount((float)num);
		}

		// Token: 0x0603A520 RID: 238880 RVA: 0x00EC9360 File Offset: 0x00EC7560
		private void RefreshConfirmButton()
		{
			int value = Singleton<CommonManager>.Instance.GetComposeMaxLevel().Value;
			int value2 = Singleton<CommonManager>.Instance.GetCurrentRewardLevel().Value;
			int value3 = Singleton<CommonManager>.Instance.GetSelectedLevel().Value;
			AUIBaseActor auibaseActor = base.GetButton(4).GetOwner() as AUIBaseActor;
			auibaseActor.GetUIItem().SetUIActive(true);
			if (value2 >= value || value3 >= value || value3 < value2)
			{
				auibaseActor.GetUIItem().SetUIActive(false);
				return;
			}
			int value4 = Singleton<CommonManager>.Instance.GetCurrentRewardTotalProficiency().Value;
			int value5 = Singleton<CommonManager>.Instance.GetSumExpByLevel(Singleton<CommonManager>.Instance.GetSelectedLevel().Value).Value;
			base.GetButton(4).SetSelfInteractive(value4 >= value5 && value2 < value);
		}

		// Token: 0x0603A521 RID: 238881 RVA: 0x00EC9438 File Offset: 0x00EC7638
		private void RefreshRewardList()
		{
			this.TmpRewardItem.Clear();
			int value = Singleton<CommonManager>.Instance.GetDropIdByLevel(Singleton<CommonManager>.Instance.GetSelectedLevel().Value).Value;
			if (value == -1)
			{
				base.GetItem(8).SetUIActive(false);
				return;
			}
			base.GetItem(8).SetUIActive(true);
			DropPackage? dropPackage = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(value);
			if (dropPackage != null)
			{
				for (int i = 0; i < dropPackage.Value.DropPreviewLength; i++)
				{
					DicIntInt? dicIntInt = dropPackage.Value.DropPreview(i);
					if (dicIntInt != null)
					{
						this.TmpRewardItem.Add(new IRewardData
						{
							RewardId = dicIntInt.Value.Key,
							Count = dicIntInt.Value.Value,
							IsGet = (Singleton<CommonManager>.Instance.GetSelectedLevel().Value < Singleton<CommonManager>.Instance.GetCurrentRewardLevel().Value)
						});
					}
				}
			}
			this.RewardItemLayout.RefreshByData(this.TmpRewardItem, null, false);
		}

		// Token: 0x0603A522 RID: 238882 RVA: 0x00EC9564 File Offset: 0x00EC7764
		private void RefreshLeftAndRightButtonEnable()
		{
			((base.GetButton(5).GetOwner() as AUIBaseActor).GetComponentByClass(UUIItem.StaticClass()) as UUIItem).SetUIActive(Singleton<CommonManager>.Instance.GetSelectedLevel().Value != 1);
			((base.GetButton(6).GetOwner() as AUIBaseActor).GetComponentByClass(UUIItem.StaticClass()) as UUIItem).SetUIActive(Singleton<CommonManager>.Instance.GetSelectedLevel().Value != Singleton<CommonManager>.Instance.GetComposeMaxLevel().Value);
		}

		// Token: 0x0603A523 RID: 238883 RVA: 0x00EC9608 File Offset: 0x00EC7808
		private void RefreshRewardItem()
		{
			base.GetItem(10).SetUIActive(Singleton<CommonManager>.Instance.GetSelectedLevel().Value != Singleton<CommonManager>.Instance.GetComposeMaxLevel().Value);
		}

		// Token: 0x0603A524 RID: 238884 RVA: 0x00EC964C File Offset: 0x00EC784C
		private void RefreshRedDotVisible()
		{
			int value = Singleton<CommonManager>.Instance.GetCurrentRewardLevel().Value;
			int value2 = Singleton<CommonManager>.Instance.GetSelectedLevel().Value;
			if (value == value2)
			{
				ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.ComposeReagentProduction, base.GetItem(13), null, 0);
				return;
			}
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.ComposeReagentProduction, base.GetItem(13), 0);
			UUIItem item = base.GetItem(13);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x0603A525 RID: 238885 RVA: 0x00EC96C0 File Offset: 0x00EC78C0
		private void OnClick()
		{
			if (base.GetButton(4).GetSelfInteractive())
			{
				Singleton<CommonManager>.Instance.SendLevelRewardRequest();
				return;
			}
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("ComposeUpgrade", Array.Empty<object>());
		}

		// Token: 0x0603A526 RID: 238886 RVA: 0x00EC96F0 File Offset: 0x00EC78F0
		private void OnLeft()
		{
			Singleton<CommonManager>.Instance.SetSelectedLevel(Singleton<CommonManager>.Instance.GetSelectedLevel().Value - 1);
			this.Refresh();
		}

		// Token: 0x0603A527 RID: 238887 RVA: 0x00EC9724 File Offset: 0x00EC7924
		private void OnRight()
		{
			Singleton<CommonManager>.Instance.SetSelectedLevel(Singleton<CommonManager>.Instance.GetSelectedLevel().Value + 1);
			this.Refresh();
		}

		// Token: 0x0603A528 RID: 238888 RVA: 0x00EC9755 File Offset: 0x00EC7955
		private void OnClickBtn()
		{
			base.CloseMe(null);
		}

		// Token: 0x04021095 RID: 135317
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<LevelRewardItem, IRewardData> RewardItemLayout;

		// Token: 0x04021096 RID: 135318
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<IRewardData> TmpRewardItem;

		// Token: 0x04021097 RID: 135319
		private bool IsFirstShow = true;

		// Token: 0x04021098 RID: 135320
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayoutNew<StarItem> StarLayout;

		// Token: 0x0200B9B9 RID: 47545
		[NullableContext(0)]
		private class ELevelUpgradeDefine
		{
			// Token: 0x04039631 RID: 235057
			public const int NameText = 0;

			// Token: 0x04039632 RID: 235058
			public const int InfoText = 1;

			// Token: 0x04039633 RID: 235059
			public const int SumExpText = 2;

			// Token: 0x04039634 RID: 235060
			public const int ExpBarSprite = 3;

			// Token: 0x04039635 RID: 235061
			public const int ConfirmButton = 4;

			// Token: 0x04039636 RID: 235062
			public const int LeftButton = 5;

			// Token: 0x04039637 RID: 235063
			public const int RightButton = 6;

			// Token: 0x04039638 RID: 235064
			public const int RewardItemHorizontalLayout = 7;

			// Token: 0x04039639 RID: 235065
			public const int RewardLayoutItem = 8;

			// Token: 0x0403963A RID: 235066
			public const int TypeIconTexture = 9;

			// Token: 0x0403963B RID: 235067
			public const int RewardItem = 10;

			// Token: 0x0403963C RID: 235068
			public const int PnlStar = 11;

			// Token: 0x0403963D RID: 235069
			public const int TxtConfirm = 12;

			// Token: 0x0403963E RID: 235070
			public const int RedDot = 13;

			// Token: 0x0403963F RID: 235071
			public const int MaskBtn = 14;

			// Token: 0x04039640 RID: 235072
			public const int BackBtn = 15;
		}
	}
}
