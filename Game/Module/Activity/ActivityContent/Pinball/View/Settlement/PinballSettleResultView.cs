using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Settlement
{
	// Token: 0x020065BC RID: 26044
	[NullableContext(2)]
	[Nullable(0)]
	public class PinballSettleResultView : UiViewBase, IPinballSettleResultViewContext
	{
		// Token: 0x06041135 RID: 266549 RVA: 0x010B2460 File Offset: 0x010B0660
		[NullableContext(1)]
		public PinballSettleResultView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x17009EDE RID: 40670
		// (get) Token: 0x06041136 RID: 266550 RVA: 0x010B2469 File Offset: 0x010B0669
		public new IPinballSettleResultViewParam OpenParam
		{
			get
			{
				return this.OpenParam as IPinballSettleResultViewParam;
			}
		}

		// Token: 0x06041137 RID: 266551 RVA: 0x010B2478 File Offset: 0x010B0678
		protected unsafe override void OnRegisterComponent()
		{
			int num = 22;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(USpineSkeletonAnimationComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(USpineSkeletonAnimationComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickBtnShop));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickBtnRole));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041138 RID: 266552 RVA: 0x010B27E4 File Offset: 0x010B09E4
		protected override void OnBeforeCreate()
		{
			switch (this.OpenParam.LevelType)
			{
			case EPinballLevelShowType.Normal:
				this.Strategy = new PinballSettleResultNormalStrategy();
				break;
			case EPinballLevelShowType.Cow:
				this.Strategy = new PinballSettleResultBonusStrategy();
				break;
			case EPinballLevelShowType.Tower:
				this.Strategy = new PinballSettleResultTowerStrategy();
				break;
			case EPinballLevelShowType.Daily:
				this.Strategy = new PinballSettleResultDailyStrategy();
				break;
			}
			this.Strategy.Context = this;
		}

		// Token: 0x06041139 RID: 266553 RVA: 0x010B2858 File Offset: 0x010B0A58
		protected override UniTask OnBeforeStartAsync()
		{
			PinballSettleResultView.<OnBeforeStartAsync>d__16 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PinballSettleResultView.<OnBeforeStartAsync>d__16>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0604113A RID: 266554 RVA: 0x010B289C File Offset: 0x010B0A9C
		private UniTask InitButtons()
		{
			PinballSettleResultView.<InitButtons>d__17 <InitButtons>d__;
			<InitButtons>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitButtons>d__.<>4__this = this;
			<InitButtons>d__.<>1__state = -1;
			<InitButtons>d__.<>t__builder.Start<PinballSettleResultView.<InitButtons>d__17>(ref <InitButtons>d__);
			return <InitButtons>d__.<>t__builder.Task;
		}

		// Token: 0x0604113B RID: 266555 RVA: 0x010B28E0 File Offset: 0x010B0AE0
		private UniTask InitRewardView()
		{
			PinballSettleResultView.<InitRewardView>d__18 <InitRewardView>d__;
			<InitRewardView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitRewardView>d__.<>4__this = this;
			<InitRewardView>d__.<>1__state = -1;
			<InitRewardView>d__.<>t__builder.Start<PinballSettleResultView.<InitRewardView>d__18>(ref <InitRewardView>d__);
			return <InitRewardView>d__.<>t__builder.Task;
		}

		// Token: 0x0604113C RID: 266556 RVA: 0x010B2924 File Offset: 0x010B0B24
		private UniTask InitProgressRewardView()
		{
			PinballSettleResultView.<InitProgressRewardView>d__19 <InitProgressRewardView>d__;
			<InitProgressRewardView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitProgressRewardView>d__.<>4__this = this;
			<InitProgressRewardView>d__.<>1__state = -1;
			<InitProgressRewardView>d__.<>t__builder.Start<PinballSettleResultView.<InitProgressRewardView>d__19>(ref <InitProgressRewardView>d__);
			return <InitProgressRewardView>d__.<>t__builder.Task;
		}

		// Token: 0x0604113D RID: 266557 RVA: 0x010B2968 File Offset: 0x010B0B68
		private UniTask InitDialogView()
		{
			PinballSettleResultView.<InitDialogView>d__20 <InitDialogView>d__;
			<InitDialogView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitDialogView>d__.<>4__this = this;
			<InitDialogView>d__.<>1__state = -1;
			<InitDialogView>d__.<>t__builder.Start<PinballSettleResultView.<InitDialogView>d__20>(ref <InitDialogView>d__);
			return <InitDialogView>d__.<>t__builder.Task;
		}

		// Token: 0x0604113E RID: 266558 RVA: 0x010B29AC File Offset: 0x010B0BAC
		private UniTask InitFailTipsView()
		{
			PinballSettleResultView.<InitFailTipsView>d__21 <InitFailTipsView>d__;
			<InitFailTipsView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitFailTipsView>d__.<>4__this = this;
			<InitFailTipsView>d__.<>1__state = -1;
			<InitFailTipsView>d__.<>t__builder.Start<PinballSettleResultView.<InitFailTipsView>d__21>(ref <InitFailTipsView>d__);
			return <InitFailTipsView>d__.<>t__builder.Task;
		}

		// Token: 0x0604113F RID: 266559 RVA: 0x010B29F0 File Offset: 0x010B0BF0
		private UniTask InitUnlockTipsView()
		{
			PinballSettleResultView.<InitUnlockTipsView>d__22 <InitUnlockTipsView>d__;
			<InitUnlockTipsView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitUnlockTipsView>d__.<>4__this = this;
			<InitUnlockTipsView>d__.<>1__state = -1;
			<InitUnlockTipsView>d__.<>t__builder.Start<PinballSettleResultView.<InitUnlockTipsView>d__22>(ref <InitUnlockTipsView>d__);
			return <InitUnlockTipsView>d__.<>t__builder.Task;
		}

		// Token: 0x06041140 RID: 266560 RVA: 0x010B2A34 File Offset: 0x010B0C34
		protected override void OnStart()
		{
			this.UiViewSequence.StartSequenceName = (this.OpenParam.IsWin ? "Victory_In" : "Failure_In");
			this.UiViewSequence.ShowSequenceName = (this.OpenParam.IsWin ? "Victory_ShowView" : "Failure_ShowView");
			this.BindRedDot();
			this.InitStarLayout();
			this.RefreshViewState();
			Singleton<AudioSystem>.Instance.PostEvent("stop_dungeon_huodong_danzhu_battle");
			Singleton<AudioSystem>.Instance.PostEvent("stop_dungeon_huodong_danzhu_boss");
		}

		// Token: 0x06041141 RID: 266561 RVA: 0x010B2ABB File Offset: 0x010B0CBB
		protected override void OnDestroy()
		{
			this.UnBindRedDot();
		}

		// Token: 0x06041142 RID: 266562 RVA: 0x010B2AC4 File Offset: 0x010B0CC4
		protected void RefreshTitle()
		{
			PinballSettleResultStrategyBase pinballSettleResultStrategyBase = this.Strategy as PinballSettleResultStrategyBase;
			if (pinballSettleResultStrategyBase != null && pinballSettleResultStrategyBase.HasCustomRefreshTitle)
			{
				this.Strategy.RefreshTitle();
				return;
			}
			if (this.OpenParam.IsWin)
			{
				Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(19), "Pinball_BattleSettlement_Success", Array.Empty<object>());
			}
			UUIItem item = base.GetItem(16);
			if (item != null)
			{
				item.SetUIActive(this.OpenParam.IsWin);
			}
			UUIItem item2 = base.GetItem(17);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(!this.OpenParam.IsWin);
		}

		// Token: 0x06041143 RID: 266563 RVA: 0x010B2B5C File Offset: 0x010B0D5C
		private void InitStarLayout()
		{
			this.StarLayout = new GenericLayout<PinballStarItemView, bool>(base.GetHorizontalLayout(6), () => new PinballStarItemView(), null, false, true);
			UUIItem item = base.GetItem(6);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x06041144 RID: 266564 RVA: 0x010B2BAF File Offset: 0x010B0DAF
		protected void RefreshStarLayout()
		{
			IPinballSettleResultStrategy strategy = this.Strategy;
			if (strategy == null)
			{
				return;
			}
			strategy.RefreshStarLayout();
		}

		// Token: 0x06041145 RID: 266565 RVA: 0x010B2BC4 File Offset: 0x010B0DC4
		protected void RefreshDamageLayout()
		{
			this.DamageLayout = new GenericLayout<DamageLayoutItemView, IDamageLayoutItemData>(base.GetVerticalLayout(8), () => new DamageLayoutItemView(), null, false, true);
			List<IDamageLayoutItemData> list = new List<IDamageLayoutItemData>();
			foreach (KeyValuePair<int, float> keyValuePair in this.OpenParam.Roles)
			{
				int num;
				float num2;
				keyValuePair.Deconstruct(out num, out num2);
				int roleId = num;
				float damage = num2;
				list.Add(new DamageLayoutItemData
				{
					RoleId = roleId,
					Damage = damage,
					IsWin = this.OpenParam.IsWin
				});
			}
			list.Sort((IDamageLayoutItemData a, IDamageLayoutItemData b) => b.Damage.CompareTo(a.Damage));
			this.DamageLayout.RefreshByData(list, null, false);
		}

		// Token: 0x06041146 RID: 266566 RVA: 0x010B2CC0 File Offset: 0x010B0EC0
		protected UniTask RefreshRole()
		{
			PinballSettleResultView.<RefreshRole>d__29 <RefreshRole>d__;
			<RefreshRole>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshRole>d__.<>4__this = this;
			<RefreshRole>d__.<>1__state = -1;
			<RefreshRole>d__.<>t__builder.Start<PinballSettleResultView.<RefreshRole>d__29>(ref <RefreshRole>d__);
			return <RefreshRole>d__.<>t__builder.Task;
		}

		// Token: 0x06041147 RID: 266567 RVA: 0x010B2D03 File Offset: 0x010B0F03
		private void RefreshViewState()
		{
			this.RefreshTitle();
			this.RefreshStarLayout();
			this.RefreshDamageLayout();
			this.RefreshButtons();
			this.RefreshRewards();
			this.RefreshProgressRewards();
			this.RefreshFailTips();
			this.RefreshUnlockTips();
			this.RefreshDialog();
			this.RefreshFormationToggle();
		}

		// Token: 0x06041148 RID: 266568 RVA: 0x010B2D44 File Offset: 0x010B0F44
		private void RefreshFormationToggle()
		{
			if (this.OpenParam.IsWin)
			{
				UUIItem item = base.GetItem(4);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(false);
				return;
			}
			else
			{
				PinballLevelConfig? pinballLevelConfigById = ConfigBase<PinballConfig>.Instance.GetPinballLevelConfigById(this.OpenParam.LevelId);
				bool flag = pinballLevelConfigById != null && pinballLevelConfigById.Value.TrailRoleLength > 0;
				UUIItem item2 = base.GetItem(4);
				if (item2 != null)
				{
					item2.SetUIActive(!flag);
				}
				UUIExtendToggle extendToggle = base.GetExtendToggle(18);
				if (extendToggle == null)
				{
					return;
				}
				extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
				return;
			}
		}

		// Token: 0x06041149 RID: 266569 RVA: 0x010B2DD4 File Offset: 0x010B0FD4
		protected void RefreshButtons()
		{
			IPinballSettleResultStrategy strategy = this.Strategy;
			if (strategy != null)
			{
				strategy.RefreshButtons();
			}
			UUIButtonComponent button = base.GetButton(2);
			if (button != null)
			{
				UUIItem uuiitem = button.RootUIComp.Get();
				if (uuiitem != null)
				{
					uuiitem.SetUIActive(this.ShouldShowFunctionBtn(EFunctionType.PinballShop));
				}
			}
			UUIButtonComponent button2 = base.GetButton(3);
			if (button2 == null)
			{
				return;
			}
			UUIItem uuiitem2 = button2.RootUIComp.Get();
			if (uuiitem2 == null)
			{
				return;
			}
			uuiitem2.SetUIActive(this.ShouldShowFunctionBtn(EFunctionType.PinballRole));
		}

		// Token: 0x0604114A RID: 266570 RVA: 0x010B2E50 File Offset: 0x010B1050
		private bool ShouldShowFunctionBtn(EFunctionType functionType)
		{
			if (!ModelBase<FunctionModel>.Instance.IsOpen(functionType))
			{
				return false;
			}
			FunctionCondition? functionCondition = ConfigBase<FunctionConfig>.Instance.GetFunctionCondition((int)functionType);
			if (functionCondition == null)
			{
				return false;
			}
			ConditionGroup? conditionGroupConfig = ConfigBase<ConditionConfig>.Instance.GetConditionGroupConfig(functionCondition.Value.OpenConditionId);
			if (conditionGroupConfig == null || conditionGroupConfig.Value.GroupIdLength == 0 || conditionGroupConfig.Value.GroupIdLength > 1)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PinballBattle;
				ELogAuthor author = ELogAuthor.CB;
				string message = "检查弹射物语功能解锁条件组配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ConditionGroupId", functionCondition.Value.OpenConditionId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			int num = conditionGroupConfig.Value.GroupId(0);
			Condition? conditionConfig = ConfigBase<ConditionConfig>.Instance.GetConditionConfig(num);
			if (conditionConfig == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.PinballBattle;
				ELogAuthor author2 = ELogAuthor.CB;
				string message2 = "弹射物语功能解锁条件配置不存在";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("conditionId", num);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return false;
			}
			string text;
			conditionConfig.Value.LimitParams().TryGetValue("SubInsId", out text);
			int num2 = (text != null) ? int.Parse(text) : 0;
			if (num2 <= 0)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.PinballBattle;
				ELogAuthor author3 = ELogAuthor.CB;
				string message3 = "弹射物语功能解锁条件配置解锁关卡ID不存在";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("conditionId", num);
				instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				return true;
			}
			return this.OpenParam.LevelId != num2 || !this.OpenParam.IsFirstPass;
		}

		// Token: 0x0604114B RID: 266571 RVA: 0x010B2FE6 File Offset: 0x010B11E6
		protected void RefreshRewards()
		{
			IPinballSettleResultStrategy strategy = this.Strategy;
			if (strategy == null)
			{
				return;
			}
			strategy.RefreshRewards();
		}

		// Token: 0x0604114C RID: 266572 RVA: 0x010B2FF8 File Offset: 0x010B11F8
		protected void RefreshProgressRewards()
		{
			IPinballSettleResultStrategy strategy = this.Strategy;
			if (strategy == null)
			{
				return;
			}
			strategy.RefreshProgressRewards();
		}

		// Token: 0x0604114D RID: 266573 RVA: 0x010B300C File Offset: 0x010B120C
		protected void RefreshFailTips()
		{
			IPinballSettleResultStrategy strategy = this.Strategy;
			if (strategy == null || !strategy.GetIsNeedFailTipsView())
			{
				return;
			}
			PinballSettleResultStrategyBase pinballSettleResultStrategyBase = this.Strategy as PinballSettleResultStrategyBase;
			if (pinballSettleResultStrategyBase != null && pinballSettleResultStrategyBase.HasCustomRefreshFailTips)
			{
				this.Strategy.RefreshFailTips();
				return;
			}
			PinballLevelConfig? pinballLevelConfigById = ConfigBase<PinballConfig>.Instance.GetPinballLevelConfigById(this.OpenParam.LevelId);
			if (pinballLevelConfigById == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PinballBattle;
				ELogAuthor author = ELogAuthor.CB;
				string message = "星弹奇游关卡配置不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("RoleId", this.OpenParam.LevelId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			PinballSettleFailTipsView failTipsView = this.FailTipsView;
			if (failTipsView != null)
			{
				failTipsView.ShowTxt(pinballLevelConfigById.Value.FailTipsTxt);
			}
			PinballSettleFailTipsView failTipsView2 = this.FailTipsView;
			if (failTipsView2 == null)
			{
				return;
			}
			failTipsView2.SetUiActive(true);
		}

		// Token: 0x0604114E RID: 266574 RVA: 0x010B30E0 File Offset: 0x010B12E0
		protected void RefreshDialog()
		{
			IPinballSettleResultStrategy strategy = this.Strategy;
			if (strategy == null || !strategy.GetIsNeedDialogView())
			{
				return;
			}
			PinballSettleResultStrategyBase pinballSettleResultStrategyBase = this.Strategy as PinballSettleResultStrategyBase;
			if (pinballSettleResultStrategyBase != null && pinballSettleResultStrategyBase.HasCustomRefreshDialog)
			{
				this.Strategy.RefreshDialog();
				return;
			}
			PinballRoleConfig? pinballRoleConfigById = ConfigBase<PinballConfig>.Instance.GetPinballRoleConfigById(this.OpenParam.MostValuablePlayerRoleId);
			if (pinballRoleConfigById == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PinballBattle;
				ELogAuthor author = ELogAuthor.CB;
				string message = "星弹奇游角色配置不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("RoleId", this.OpenParam.MostValuablePlayerRoleId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			List<string> list = new List<string>();
			for (int i = 0; i < pinballRoleConfigById.Value.FailBubbleTxtsLength; i++)
			{
				string text = pinballRoleConfigById.Value.FailBubbleTxts(i);
				if (text != null)
				{
					list.Add(text);
				}
			}
			string randomItem = Singleton<MathUtils>.Instance.GetRandomItem<string>(list);
			if (randomItem == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.PinballBattle;
				ELogAuthor author2 = ELogAuthor.CB;
				string message2 = "星弹奇游角色配置失败气泡文本不存在";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("RoleId", this.OpenParam.MostValuablePlayerRoleId);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			PinballSettleDialogView dialogView = this.DialogView;
			if (dialogView != null)
			{
				dialogView.ShowTxt(randomItem);
			}
			PinballSettleDialogView dialogView2 = this.DialogView;
			if (dialogView2 == null)
			{
				return;
			}
			dialogView2.SetUiActive(true);
		}

		// Token: 0x0604114F RID: 266575 RVA: 0x010B3232 File Offset: 0x010B1432
		protected void RefreshUnlockTips()
		{
			IPinballSettleResultStrategy strategy = this.Strategy;
			if (strategy == null)
			{
				return;
			}
			strategy.RefreshUnlockTips();
		}

		// Token: 0x06041150 RID: 266576 RVA: 0x010B3244 File Offset: 0x010B1444
		private void BindRedDot()
		{
			UUIItem item = base.GetItem(20);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RedDotPinballRoleFunction, base.GetItem(21), null, 0);
		}

		// Token: 0x06041151 RID: 266577 RVA: 0x010B3273 File Offset: 0x010B1473
		private void UnBindRedDot()
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RedDotPinballRoleFunction, base.GetItem(21), 0);
		}

		// Token: 0x06041152 RID: 266578 RVA: 0x010B328D File Offset: 0x010B148D
		private void OnClickBtnShop()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PinballShopView, null, null);
		}

		// Token: 0x06041153 RID: 266579 RVA: 0x010B32A0 File Offset: 0x010B14A0
		private void OnClickBtnRole()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PinballRoleView, null, null);
		}

		// Token: 0x06041154 RID: 266580 RVA: 0x010B32B3 File Offset: 0x010B14B3
		public void BindRestartButton()
		{
			ButtonItem btnLeft = this.BtnLeft;
			if (btnLeft != null)
			{
				btnLeft.SetLocalTextNew("Pinball_BattleSettlement_Button01", Array.Empty<object>());
			}
			ButtonItem btnLeft2 = this.BtnLeft;
			if (btnLeft2 == null)
			{
				return;
			}
			btnLeft2.SetFunction(delegate(int _)
			{
				this.OnClickBtnRestart();
			});
		}

		// Token: 0x06041155 RID: 266581 RVA: 0x010B32EC File Offset: 0x010B14EC
		public void BindNextButton()
		{
			ButtonItem btnRight = this.BtnRight;
			if (btnRight != null)
			{
				btnRight.SetLocalTextNew("Pinball_BattleSettlement_Button02", Array.Empty<object>());
			}
			ButtonItem btnRight2 = this.BtnRight;
			if (btnRight2 == null)
			{
				return;
			}
			btnRight2.SetFunction(delegate(int _)
			{
				this.OnClickBtnNext();
			});
		}

		// Token: 0x06041156 RID: 266582 RVA: 0x010B3325 File Offset: 0x010B1525
		public void BindBackButton()
		{
			ButtonItem btnRight = this.BtnRight;
			if (btnRight != null)
			{
				btnRight.SetLocalTextNew("Pinball_BattleSettlement_Button03", Array.Empty<object>());
			}
			ButtonItem btnRight2 = this.BtnRight;
			if (btnRight2 == null)
			{
				return;
			}
			btnRight2.SetFunction(delegate(int _)
			{
				this.OnClickBtnBack();
			});
		}

		// Token: 0x06041157 RID: 266583 RVA: 0x010B335E File Offset: 0x010B155E
		private void OnClickBtnRestart()
		{
			IPinballSettleResultStrategy strategy = this.Strategy;
			if (strategy == null)
			{
				return;
			}
			strategy.OnClickBtnRestart(delegate
			{
				base.CloseMe(null);
			});
		}

		// Token: 0x06041158 RID: 266584 RVA: 0x010B337C File Offset: 0x010B157C
		private void OnClickBtnNext()
		{
			IPinballSettleResultStrategy strategy = this.Strategy;
			if (strategy == null)
			{
				return;
			}
			strategy.OnClickBtnNext(delegate
			{
				base.CloseMe(null);
			});
		}

		// Token: 0x06041159 RID: 266585 RVA: 0x010B339A File Offset: 0x010B159A
		private void OnClickBtnBack()
		{
			IPinballSettleResultStrategy strategy = this.Strategy;
			if (strategy == null)
			{
				return;
			}
			strategy.OnClickBtnBack(delegate
			{
				base.CloseMe(null);
			});
		}

		// Token: 0x0604115A RID: 266586 RVA: 0x010B33B8 File Offset: 0x010B15B8
		[NullableContext(1)]
		public void ShowStarLayout(bool[] starInfo)
		{
			UUIItem item = base.GetItem(6);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			GenericLayout<PinballStarItemView, bool> starLayout = this.StarLayout;
			if (starLayout == null)
			{
				return;
			}
			starLayout.RefreshByData(starInfo, null, false);
		}

		// Token: 0x0604115B RID: 266587 RVA: 0x010B33E0 File Offset: 0x010B15E0
		public bool GetNeedAdjustFormation()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(18);
			return extendToggle != null && extendToggle.GetToggleState() == EToggleState.ETT_Checked;
		}

		// Token: 0x0604115C RID: 266588 RVA: 0x010B33F8 File Offset: 0x010B15F8
		[NullableContext(1)]
		public void ShowRewards(List<TItem> rewardList)
		{
			PinballSettleRewardView rewardView = this.RewardView;
			if (rewardView != null)
			{
				rewardView.SetUiActive(true);
			}
			PinballSettleRewardView rewardView2 = this.RewardView;
			if (rewardView2 == null)
			{
				return;
			}
			rewardView2.ShowRewardList(rewardList);
		}

		// Token: 0x0604115D RID: 266589 RVA: 0x010B341D File Offset: 0x010B161D
		public void ShowRewardsGot()
		{
			PinballSettleRewardView rewardView = this.RewardView;
			if (rewardView != null)
			{
				rewardView.SetUiActive(true);
			}
			PinballSettleRewardView rewardView2 = this.RewardView;
			if (rewardView2 == null)
			{
				return;
			}
			rewardView2.ShowRewardGot();
		}

		// Token: 0x0604115E RID: 266590 RVA: 0x010B3441 File Offset: 0x010B1641
		[NullableContext(1)]
		public void ShowProgressRewardList(int score, int[] scoreLevel, int[] scoreLevelDropId)
		{
			PinballSettleProgressRewardView progressRewardView = this.ProgressRewardView;
			if (progressRewardView != null)
			{
				progressRewardView.SetUiActive(true);
			}
			PinballSettleProgressRewardView progressRewardView2 = this.ProgressRewardView;
			if (progressRewardView2 == null)
			{
				return;
			}
			progressRewardView2.ShowProgressRewardList(score, scoreLevel, scoreLevelDropId);
		}

		// Token: 0x0604115F RID: 266591 RVA: 0x010B3468 File Offset: 0x010B1668
		[NullableContext(1)]
		public void ShowSuccessTips(string successTitle)
		{
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(19), successTitle, Array.Empty<object>());
			UUIItem item = base.GetItem(16);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIItem item2 = base.GetItem(17);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(false);
		}

		// Token: 0x06041160 RID: 266592 RVA: 0x010B34B4 File Offset: 0x010B16B4
		[NullableContext(1)]
		public IPinballSettleResultViewParam GetOpenParam()
		{
			return this.OpenParam;
		}

		// Token: 0x0402476E RID: 149358
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected GenericLayout<PinballStarItemView, bool> StarLayout;

		// Token: 0x0402476F RID: 149359
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected GenericLayout<DamageLayoutItemView, IDamageLayoutItemData> DamageLayout;

		// Token: 0x04024770 RID: 149360
		protected ButtonItem BtnLeft;

		// Token: 0x04024771 RID: 149361
		protected ButtonItem BtnRight;

		// Token: 0x04024772 RID: 149362
		protected PinballSettleDialogView DialogView;

		// Token: 0x04024773 RID: 149363
		protected PinballSettleRewardView RewardView;

		// Token: 0x04024774 RID: 149364
		protected PinballSettleProgressRewardView ProgressRewardView;

		// Token: 0x04024775 RID: 149365
		protected PinballSettleFailTipsView FailTipsView;

		// Token: 0x04024776 RID: 149366
		protected PinballSettleUnlockTipsView UnlockTipsView;

		// Token: 0x04024777 RID: 149367
		protected IPinballSettleResultStrategy Strategy;

		// Token: 0x0200C5B9 RID: 50617
		[NullableContext(0)]
		private enum EPinballSettleResultComponent
		{
			// Token: 0x0403CDB0 RID: 249264
			SpineRole,
			// Token: 0x0403CDB1 RID: 249265
			SpineRoleShadow,
			// Token: 0x0403CDB2 RID: 249266
			BtnShop,
			// Token: 0x0403CDB3 RID: 249267
			BtnRole,
			// Token: 0x0403CDB4 RID: 249268
			FormationToggleItem,
			// Token: 0x0403CDB5 RID: 249269
			PnlDialog,
			// Token: 0x0403CDB6 RID: 249270
			StarLayout,
			// Token: 0x0403CDB7 RID: 249271
			StarLayoutItem,
			// Token: 0x0403CDB8 RID: 249272
			DamageLayout,
			// Token: 0x0403CDB9 RID: 249273
			DamageLayoutItem,
			// Token: 0x0403CDBA RID: 249274
			PnlReward,
			// Token: 0x0403CDBB RID: 249275
			PnlProgressRward,
			// Token: 0x0403CDBC RID: 249276
			PnlTips,
			// Token: 0x0403CDBD RID: 249277
			PnlUnlockTips,
			// Token: 0x0403CDBE RID: 249278
			BtnLeft,
			// Token: 0x0403CDBF RID: 249279
			BtnRight,
			// Token: 0x0403CDC0 RID: 249280
			TitleSuccess,
			// Token: 0x0403CDC1 RID: 249281
			TitleFail,
			// Token: 0x0403CDC2 RID: 249282
			FormationToggle,
			// Token: 0x0403CDC3 RID: 249283
			TitleSuccessText,
			// Token: 0x0403CDC4 RID: 249284
			BtnShopRedDot,
			// Token: 0x0403CDC5 RID: 249285
			BtnRoleRedDot
		}
	}
}
