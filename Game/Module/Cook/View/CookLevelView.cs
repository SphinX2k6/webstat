using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Cook.View
{
	// Token: 0x02005E18 RID: 24088
	[NullableContext(1)]
	[Nullable(0)]
	public class CookLevelView : UiViewBase
	{
		// Token: 0x0603C9AB RID: 248235 RVA: 0x00F639E7 File Offset: 0x00F61BE7
		public CookLevelView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603C9AC RID: 248236 RVA: 0x00F63A18 File Offset: 0x00F61C18
		protected unsafe override void OnRegisterComponent()
		{
			int num = 13;
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
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
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
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action(delegate()
			{
				this.OnLeft();
			}));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(delegate()
			{
				this.OnRight();
			}));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603C9AD RID: 248237 RVA: 0x00F63C51 File Offset: 0x00F61E51
		protected override void OnBeforeDestroy()
		{
			this.DisableRedDot();
			if (this.RewardItemLayout != null)
			{
				this.RewardItemLayout.ClearChildren();
				this.RewardItemLayout = null;
			}
			this.StarLayout.ClearChildren();
		}

		// Token: 0x0603C9AE RID: 248238 RVA: 0x00F63C80 File Offset: 0x00F61E80
		protected override UniTask OnBeforeStartAsync()
		{
			CookLevelView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CookLevelView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C9AF RID: 248239 RVA: 0x00F63CC4 File Offset: 0x00F61EC4
		protected override void OnStart()
		{
			this.RewardItemLayout = new GenericLayout<LevelRewardItem, IRewardData>(base.GetHorizontalLayout(7), this.InitReward, null, false, true);
			this.TmpRewardItem = new List<IRewardData>();
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(12), "CookUpgradeButtonText", Array.Empty<object>());
			this.StarLayout = new GenericLayoutNew<StarItem>(base.GetHorizontalLayout(11), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<StarItem>(this.OnCreateStarProxy), null);
			ModelBase<CookModel>.Instance.CurrentCookViewType = ECookDataType.CookLevel;
			ModelBase<CookModel>.Instance.SelectedCookerLevel = ModelBase<CookModel>.Instance.GetCookerInfo().CookingLevel;
			this.Refresh();
			this.OnShowRedDot();
		}

		// Token: 0x0603C9B0 RID: 248240 RVA: 0x00F63D63 File Offset: 0x00F61F63
		protected override void OnBeforeShow()
		{
			IUiPopFrameInterface childPopView = this.ChildPopView;
			if (childPopView != null)
			{
				CommonPopViewBase popItem = childPopView.PopItem;
				if (popItem != null)
				{
					popItem.SetTexBgVisible(false);
				}
			}
			this.RefreshConfirmButton();
		}

		// Token: 0x0603C9B1 RID: 248241 RVA: 0x00F63D88 File Offset: 0x00F61F88
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private ILayoutItem<StarItem> OnCreateStarProxy([Nullable(2)] object data, UUIItem uiItem, int index)
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

		// Token: 0x0603C9B2 RID: 248242 RVA: 0x00F63DDA File Offset: 0x00F61FDA
		private void OnShowRedDot()
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.CookerLevelMain, this.ConfirmItem.GetRedDot(), null, 0);
		}

		// Token: 0x0603C9B3 RID: 248243 RVA: 0x00F63DF5 File Offset: 0x00F61FF5
		public void DisableRedDot()
		{
			ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.CookerLevelMain);
		}

		// Token: 0x0603C9B4 RID: 248244 RVA: 0x00F63E03 File Offset: 0x00F62003
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.UpgradeCookerLevel, new Action(this.ShowRewardView));
		}

		// Token: 0x0603C9B5 RID: 248245 RVA: 0x00F63E21 File Offset: 0x00F62021
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.UpgradeCookerLevel, new Action(this.ShowRewardView));
		}

		// Token: 0x0603C9B6 RID: 248246 RVA: 0x00F63E3F File Offset: 0x00F6203F
		public void ShowView()
		{
			this.SetActive(true);
		}

		// Token: 0x0603C9B7 RID: 248247 RVA: 0x00F63E48 File Offset: 0x00F62048
		private void Update()
		{
			ModelBase<CookModel>.Instance.SelectedCookerLevel = ModelBase<CookModel>.Instance.GetCookerInfo().CookingLevel;
			this.Refresh();
		}

		// Token: 0x0603C9B8 RID: 248248 RVA: 0x00F63E69 File Offset: 0x00F62069
		private void ShowRewardView()
		{
			if (this.TmpRewardItem.Count == 0)
			{
				return;
			}
			this.Update();
		}

		// Token: 0x0603C9B9 RID: 248249 RVA: 0x00F63E7F File Offset: 0x00F6207F
		private void Refresh()
		{
			this.RefreshTypeIconTexture();
			this.RefreshName();
			this.RefreshInfo();
			this.RefreshLevel();
			this.RefreshSumExp();
			this.RefreshExpBarSprite();
			this.RefreshConfirmButton();
			this.RefreshRewardList();
			this.RefreshLeftAndRightButtonEnable();
			this.RefreshRewardItem();
		}

		// Token: 0x0603C9BA RID: 248250 RVA: 0x00F63EC0 File Offset: 0x00F620C0
		private void RefreshTypeIconTexture()
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_CookingType");
			base.SetTextureByPath(resourcePath, base.GetTexture(9), null, null);
		}

		// Token: 0x0603C9BB RID: 248251 RVA: 0x00F63EF8 File Offset: 0x00F620F8
		private void RefreshName()
		{
			CookLevel cookLevelByLevel = ModelBase<CookModel>.Instance.GetCookLevelByLevel(ModelBase<CookModel>.Instance.SelectedCookerLevel);
			string localText = ConfigBase<CookConfig>.Instance.GetLocalText(cookLevelByLevel.Name);
			base.GetText(0).SetText(localText, true);
		}

		// Token: 0x0603C9BC RID: 248252 RVA: 0x00F63F3C File Offset: 0x00F6213C
		private void RefreshInfo()
		{
			CookLevel cookLevelByLevel = ModelBase<CookModel>.Instance.GetCookLevelByLevel(ModelBase<CookModel>.Instance.SelectedCookerLevel);
			string localText = ConfigBase<CookConfig>.Instance.GetLocalText(cookLevelByLevel.AttributesDescription);
			base.GetText(1).SetText(localText, true);
		}

		// Token: 0x0603C9BD RID: 248253 RVA: 0x00F63F80 File Offset: 0x00F62180
		private void RefreshLevel()
		{
			int cookerMaxLevel = ModelBase<CookModel>.Instance.GetCookerMaxLevel();
			List<bool> list = new List<bool>(cookerMaxLevel);
			for (int i = 0; i < ModelBase<CookModel>.Instance.SelectedCookerLevel; i++)
			{
				list.Add(true);
			}
			for (int j = ModelBase<CookModel>.Instance.SelectedCookerLevel; j < cookerMaxLevel; j++)
			{
				list.Add(false);
			}
			this.StarLayout.RebuildLayoutByDataNew<bool>(list, null);
		}

		// Token: 0x0603C9BE RID: 248254 RVA: 0x00F63FF0 File Offset: 0x00F621F0
		private void RefreshSumExp()
		{
			int totalProficiencys = ModelBase<CookModel>.Instance.GetCookerInfo().TotalProficiencys;
			string newText;
			if (ModelBase<CookModel>.Instance.SelectedCookerLevel == ModelBase<CookModel>.Instance.GetCookerMaxLevel())
			{
				newText = "MAX";
			}
			else
			{
				int sumExpByLevel = ModelBase<CookModel>.Instance.GetSumExpByLevel(ModelBase<CookModel>.Instance.SelectedCookerLevel);
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(totalProficiencys);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(sumExpByLevel);
				newText = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			base.GetText(2).SetText(newText, true);
		}

		// Token: 0x0603C9BF RID: 248255 RVA: 0x00F64084 File Offset: 0x00F62284
		private void RefreshExpBarSprite()
		{
			int totalProficiencys = ModelBase<CookModel>.Instance.GetCookerInfo().TotalProficiencys;
			int sumExpByLevel = ModelBase<CookModel>.Instance.GetSumExpByLevel(ModelBase<CookModel>.Instance.SelectedCookerLevel);
			double num = Singleton<MathUtils>.Instance.GetFloatPointFloor((double)totalProficiencys / (double)sumExpByLevel, 3);
			num = ((num > 1.0) ? 1.0 : num);
			base.GetSprite(3).SetFillAmount((float)num);
		}

		// Token: 0x0603C9C0 RID: 248256 RVA: 0x00F640EE File Offset: 0x00F622EE
		private void RefreshConfirmButton()
		{
			this.ConfirmItem.SetEnable();
		}

		// Token: 0x0603C9C1 RID: 248257 RVA: 0x00F640FC File Offset: 0x00F622FC
		private void RefreshRewardList()
		{
			this.TmpRewardItem.Clear();
			int dropIdByLevel = ModelBase<CookModel>.Instance.GetDropIdByLevel(ModelBase<CookModel>.Instance.SelectedCookerLevel);
			if (dropIdByLevel == -1)
			{
				base.GetItem(8).SetUIActive(false);
				return;
			}
			base.GetItem(8).SetUIActive(true);
			DropPackage? dropPackage = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(dropIdByLevel);
			if (dropPackage != null)
			{
				for (int i = 0; i < dropPackage.Value.DropPreviewLength; i++)
				{
					DicIntInt? dicIntInt = dropPackage.Value.DropPreview(i);
					if (dicIntInt != null)
					{
						int selectedCookerLevel = ModelBase<CookModel>.Instance.SelectedCookerLevel;
						int cookingLevel = ModelBase<CookModel>.Instance.GetCookerInfo().CookingLevel;
						this.TmpRewardItem.Add(new RewardData
						{
							RewardId = dicIntInt.Value.Key,
							Count = dicIntInt.Value.Value,
							IsGet = (selectedCookerLevel < cookingLevel)
						});
					}
				}
			}
			this.RewardItemLayout.RefreshByData(this.TmpRewardItem, null, false);
		}

		// Token: 0x0603C9C2 RID: 248258 RVA: 0x00F64214 File Offset: 0x00F62414
		private void RefreshLeftAndRightButtonEnable()
		{
			((base.GetButton(5).GetOwner() as AUIBaseActor).GetComponentByClass(UUIItem.StaticClass()) as UUIItem).SetUIActive(ModelBase<CookModel>.Instance.SelectedCookerLevel != 1);
			((base.GetButton(6).GetOwner() as AUIBaseActor).GetComponentByClass(UUIItem.StaticClass()) as UUIItem).SetUIActive(ModelBase<CookModel>.Instance.SelectedCookerLevel != ModelBase<CookModel>.Instance.GetCookerMaxLevel());
		}

		// Token: 0x0603C9C3 RID: 248259 RVA: 0x00F6429E File Offset: 0x00F6249E
		private void RefreshRewardItem()
		{
			base.GetItem(10).SetUIActive(ModelBase<CookModel>.Instance.SelectedCookerLevel != ModelBase<CookModel>.Instance.GetCookerMaxLevel());
		}

		// Token: 0x0603C9C4 RID: 248260 RVA: 0x00F642C6 File Offset: 0x00F624C6
		private void OnClick()
		{
			ControllerBase<CookController>.Instance.SendCertificateLevelRewardRequest();
		}

		// Token: 0x0603C9C5 RID: 248261 RVA: 0x00F642D2 File Offset: 0x00F624D2
		private void OnLeft()
		{
			ModelBase<CookModel>.Instance.SelectedCookerLevel--;
			this.Refresh();
		}

		// Token: 0x0603C9C6 RID: 248262 RVA: 0x00F642EC File Offset: 0x00F624EC
		private void OnRight()
		{
			ModelBase<CookModel>.Instance.SelectedCookerLevel++;
			this.Refresh();
		}

		// Token: 0x040220EB RID: 139499
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<LevelRewardItem, IRewardData> RewardItemLayout;

		// Token: 0x040220EC RID: 139500
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<IRewardData> TmpRewardItem;

		// Token: 0x040220ED RID: 139501
		[Nullable(2)]
		private ConfirmItem ConfirmItem;

		// Token: 0x040220EE RID: 139502
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayoutNew<StarItem> StarLayout;

		// Token: 0x040220EF RID: 139503
		private readonly Func<LevelRewardItem> InitReward = () => new LevelRewardItem();

		// Token: 0x0200BE4E RID: 48718
		[NullableContext(0)]
		public enum ECookLevelDefine
		{
			// Token: 0x0403A969 RID: 239977
			NameText,
			// Token: 0x0403A96A RID: 239978
			InfoText,
			// Token: 0x0403A96B RID: 239979
			SumExpText,
			// Token: 0x0403A96C RID: 239980
			ExpBarSprite,
			// Token: 0x0403A96D RID: 239981
			ConfirmItem,
			// Token: 0x0403A96E RID: 239982
			LeftButton,
			// Token: 0x0403A96F RID: 239983
			RightButton,
			// Token: 0x0403A970 RID: 239984
			RewardItemHorizontalLayout,
			// Token: 0x0403A971 RID: 239985
			RewardLayoutItem,
			// Token: 0x0403A972 RID: 239986
			TypeIconTexture,
			// Token: 0x0403A973 RID: 239987
			RewardItem,
			// Token: 0x0403A974 RID: 239988
			PnlStar,
			// Token: 0x0403A975 RID: 239989
			TxtConfirm
		}
	}
}
