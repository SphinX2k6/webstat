using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.TrainingDegree;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.DeadRevive
{
	// Token: 0x02005DCD RID: 24013
	[NullableContext(2)]
	[Nullable(0)]
	public class ReviveView : UiTickViewBase
	{
		// Token: 0x0603C72C RID: 247596 RVA: 0x00F59A9C File Offset: 0x00F57C9C
		[NullableContext(1)]
		public ReviveView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603C72D RID: 247597 RVA: 0x00F59AAC File Offset: 0x00F57CAC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 13;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 3;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickRevive));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickGiveUp));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnClickReviveAtLocation));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603C72E RID: 247598 RVA: 0x00F59D08 File Offset: 0x00F57F08
		protected override void OnStart()
		{
			this.CountDown = base.GetText(4);
			this.AutoReviveCountDown = base.GetText(9);
			this.IsMorale = ModelBase<MoraleBattleModel>.Instance.IsMoraleActive();
			UUIItem item = base.GetItem(0);
			UUIItem item2 = base.GetItem(1);
			UUIButtonComponent button = base.GetButton(3);
			UUIButtonComponent button2 = base.GetButton(2);
			this.ReviveBtnInteraction = (button2.GetOwner().GetComponentByClass(UUIInteractionGroup.StaticClass()) as UUIInteractionGroup);
			this.IsInInstance = ControllerBase<GameModeController>.Instance.IsInInstance();
			if (!this.IsInInstance)
			{
				button2.GetRootComponent().SetAnchorOffset(button.GetRootComponent().GetAnchorOffset());
				button.GetRootComponent().SetUIActive(false);
				this.InitItemInfo();
			}
			else if (ModelBase<GameModeModel>.Instance.IsMulti)
			{
				base.GetButton(2).GetRootComponent().SetUIActive(false);
				Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(12), "ExitInstance", Array.Empty<object>());
				Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(6), "MatchInstanceDead", Array.Empty<object>());
			}
			Revive? reviveConfig = ModelBase<DeadReviveModel>.Instance.ReviveConfig;
			if (reviveConfig != null)
			{
				this.ReviveNumber = reviveConfig.Value.ReviveTimes;
			}
			item2.SetUIActive(true);
			item.SetUIActive(false);
			this.CountNumber = (int)ModelBase<DeadReviveModel>.Instance.ReviveLimitTime;
			this.CanRevive = false;
			bool uiactive = true;
			if (this.CountNumber > 0)
			{
				this.CountDown.SetText(this.CountNumber.ToString() + "s", true);
				this.ReviveBtnInteraction.SetInteractable(false);
			}
			else if (this.CountNumber <= 0)
			{
				uiactive = false;
				this.CanRevive = true;
				this.AutoReviveCountDownTime = 60;
				if (!ControllerBase<GameModeController>.Instance.IsInInstance())
				{
					this.AutoReviveCountDown.SetUIActive(true);
				}
				Singleton<LguiUtil>.Instance.SetLocalText(this.AutoReviveCountDown, "ReviveItemTips", new <>z__ReadOnlySingleElementList<object>(this.AutoReviveCountDownTime));
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalText(this.CountDown, "ReachReviveCount", Array.Empty<object>());
				this.ReviveBtnInteraction.SetInteractable(false);
			}
			this.CountDown.SetUIActive(uiactive);
			UUIText text = base.GetText(5);
			DeadReviveModel instance = ModelBase<DeadReviveModel>.Instance;
			text.ShowTextNew(((instance.ReviveConfig != null) ? instance.ReviveConfig.GetValueOrDefault().ReviveTitle : null) ?? "");
			UUIText text2 = base.GetText(6);
			if (!ControllerBase<GameModeController>.Instance.IsInInstance() && !ModelBase<GameModeModel>.Instance.IsMulti)
			{
				text2.ShowTextNew(this.GetReviveContent());
			}
			this.TrainingView = new TrainingView();
			this.TrainingView.Show(base.GetHorizontalLayout(7), this.GetTrainingDataList());
		}

		// Token: 0x0603C72F RID: 247599 RVA: 0x00F59FB2 File Offset: 0x00F581B2
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private List<TrainingData> GetTrainingDataList()
		{
			if (this.IsMorale)
			{
				return ModelBase<MoraleModel>.Instance.GetMoraleBuffDataList();
			}
			return null;
		}

		// Token: 0x0603C730 RID: 247600 RVA: 0x00F59FC8 File Offset: 0x00F581C8
		[NullableContext(1)]
		private string GetReviveContent()
		{
			if (this.IsMorale)
			{
				return "Morale_title_29";
			}
			DeadReviveModel instance = ModelBase<DeadReviveModel>.Instance;
			return ((instance.ReviveConfig != null) ? instance.ReviveConfig.GetValueOrDefault().ReviveContent : null) ?? "";
		}

		// Token: 0x0603C731 RID: 247601 RVA: 0x00F5A010 File Offset: 0x00F58210
		private void InitItemInfo()
		{
			int num = -1;
			Revive? reviveConfig = ModelBase<DeadReviveModel>.Instance.ReviveConfig;
			if (reviveConfig != null)
			{
				num = reviveConfig.Value.UseItemId;
			}
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(num, 0);
			if (itemCountByConfigId <= 0)
			{
				return;
			}
			UUIButtonComponent button = base.GetButton(8);
			button.GetRootComponent().SetUIActive(true);
			UUITexture texture = base.GetTexture(10);
			UUIText text = base.GetText(11);
			BuffItemModel instance = ModelBase<BuffItemModel>.Instance;
			base.SetItemIcon(texture, num, null, null);
			this.ItemName = ConfigBase<ItemConfig>.Instance.GetItemName(num);
			int buffItemTotalCdTime = ConfigBase<BuffItemConfig>.Instance.GetBuffItemTotalCdTime(num);
			if ((double)buffItemTotalCdTime < Singleton<TimeUtil>.Instance.Minute)
			{
				this.ItemCd = buffItemTotalCdTime.ToString() + ConfigBase<TextConfig>.Instance.GetTextById("Second");
			}
			else
			{
				this.ItemCd = Math.Floor((double)buffItemTotalCdTime / Singleton<TimeUtil>.Instance.Minute).ToString() + ConfigBase<TextConfig>.Instance.GetTextById("MinuteText");
				double num2 = (double)buffItemTotalCdTime % Singleton<TimeUtil>.Instance.Minute;
				if (num2 > 0.0)
				{
					this.ItemCd = this.ItemCd + num2.ToString() + ConfigBase<TextConfig>.Instance.GetTextById("Second");
				}
			}
			if (instance.GetBuffItemRemainCdTime(num) > 0.0)
			{
				Singleton<LguiUtil>.Instance.SetLocalText(text, "ReviveItemCd", Array.Empty<object>());
				(button.GetOwner().GetComponentByClass(UUIInteractionGroup.StaticClass()) as UUIInteractionGroup).SetInteractable(false);
				return;
			}
			text.SetText(itemCountByConfigId.ToString(), true);
		}

		// Token: 0x0603C732 RID: 247602 RVA: 0x00F5A1B8 File Offset: 0x00F583B8
		private void OnClickRevive()
		{
			if (this.ReviveNumber == 0)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("CannotRevive", Array.Empty<object>());
				return;
			}
			if (this.CanRevive)
			{
				ControllerBase<DeadReviveController>.Instance.ReviveRequest(false, new Action<bool>(this.ReviveFinish), null);
				return;
			}
			Singleton<Log>.Instance.Info(ELogModule.Battle, ELogAuthor.YZ, "Time Or Times Limit!!!", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x0603C733 RID: 247603 RVA: 0x00F5A226 File Offset: 0x00F58426
		private void ReviveFinish(bool result)
		{
			if (!result)
			{
				return;
			}
			if (this.IsMorale)
			{
				ControllerBase<MoraleBattleController>.Instance.SetReviveFromMoraleBattle(true);
			}
		}

		// Token: 0x0603C734 RID: 247604 RVA: 0x00F5A23F File Offset: 0x00F5843F
		private void OnClickGiveUp()
		{
			base.CloseMe(null);
			if (ModelBase<DeadReviveModel>.Instance.HandleOnClickGiveUpExternal != null)
			{
				ModelBase<DeadReviveModel>.Instance.HandleOnClickGiveUpExternal();
				return;
			}
			ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon().Forget<bool>();
		}

		// Token: 0x0603C735 RID: 247605 RVA: 0x00F5A274 File Offset: 0x00F58474
		private void OnClickReviveAtLocation()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.UsingItemRevive);
			confirmBoxDataNew.SetTextArgs(new string[]
			{
				this.ItemName,
				this.ItemCd
			});
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				if (this.CanRevive)
				{
					ControllerBase<DeadReviveController>.Instance.ReviveRequest(true, null, null);
					return;
				}
				Singleton<Log>.Instance.Info(ELogModule.Battle, ELogAuthor.YZ, "Time Or Times Limit!!!", default(ReadOnlySpan<ValueTuple<string, object>>));
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0603C736 RID: 247606 RVA: 0x00F5A2CC File Offset: 0x00F584CC
		protected override void OnTick(float delta)
		{
			if ((this.CanRevive || this.CountNumber < 0) && this.IsAutoRevived)
			{
				return;
			}
			this.TimeCount += delta;
			if (this.TimeCount >= 1000f)
			{
				this.TimeCount = 0f;
				this.AutoReviveOnTick();
				this.CanReviveOnTick();
			}
		}

		// Token: 0x0603C737 RID: 247607 RVA: 0x00F5A328 File Offset: 0x00F58528
		private void AutoReviveOnTick()
		{
			if (this.IsInInstance)
			{
				return;
			}
			if (this.IsAutoRevived)
			{
				return;
			}
			if (this.AutoReviveCountDownTime <= 0)
			{
				this.IsAutoRevived = true;
				ControllerBase<ConfirmBoxController>.Instance.CloseConfirmBoxView();
				this.OnClickRevive();
				return;
			}
			this.AutoReviveCountDownTime--;
			Singleton<LguiUtil>.Instance.SetLocalText(this.AutoReviveCountDown, "ReviveItemTips", new <>z__ReadOnlySingleElementList<object>(this.AutoReviveCountDownTime));
		}

		// Token: 0x0603C738 RID: 247608 RVA: 0x00F5A39C File Offset: 0x00F5859C
		private void CanReviveOnTick()
		{
			if (this.CountNumber <= 0)
			{
				this.CanRevive = true;
				this.CountDown.SetUIActive(false);
				this.ReviveBtnInteraction.SetInteractable(true);
				return;
			}
			this.CountNumber--;
			this.CountDown.SetText(this.CountNumber.ToString() + "s", true);
		}

		// Token: 0x0603C739 RID: 247609 RVA: 0x00F5A404 File Offset: 0x00F58604
		protected override void OnBeforeDestroy()
		{
			if (this.TrainingView != null)
			{
				this.TrainingView.Clear();
			}
			this.TrainingView = null;
			this.CountDown = null;
			this.AutoReviveCountDown = null;
			this.ReviveBtnInteraction = null;
			this.ItemName = null;
			this.ItemCd = null;
			this.ReviveNumber = -1;
			this.TimeCount = 0f;
			this.CountNumber = 0;
			this.AutoReviveCountDownTime = 0;
			this.CanRevive = false;
			this.IsInInstance = false;
			this.IsAutoRevived = false;
			ModelBase<DeadReviveModel>.Instance.ClearExternalHandles();
		}

		// Token: 0x04021FC5 RID: 139205
		private const int TIME_SECOND = 1000;

		// Token: 0x04021FC6 RID: 139206
		private const int AUTO_REVIVE_TIME = 60;

		// Token: 0x04021FC7 RID: 139207
		private float TimeCount;

		// Token: 0x04021FC8 RID: 139208
		private int CountNumber;

		// Token: 0x04021FC9 RID: 139209
		private int ReviveNumber = -1;

		// Token: 0x04021FCA RID: 139210
		private int AutoReviveCountDownTime;

		// Token: 0x04021FCB RID: 139211
		private bool IsAutoRevived;

		// Token: 0x04021FCC RID: 139212
		private UUIText CountDown;

		// Token: 0x04021FCD RID: 139213
		private UUIText AutoReviveCountDown;

		// Token: 0x04021FCE RID: 139214
		private UUIInteractionGroup ReviveBtnInteraction;

		// Token: 0x04021FCF RID: 139215
		private string ItemName;

		// Token: 0x04021FD0 RID: 139216
		private string ItemCd;

		// Token: 0x04021FD1 RID: 139217
		private bool CanRevive;

		// Token: 0x04021FD2 RID: 139218
		private TrainingView TrainingView;

		// Token: 0x04021FD3 RID: 139219
		private bool IsInInstance;

		// Token: 0x04021FD4 RID: 139220
		private bool IsMorale;

		// Token: 0x0200BE1A RID: 48666
		[NullableContext(0)]
		private class EReviveViewComponent
		{
			// Token: 0x0403A871 RID: 239729
			public const int Revive = 0;

			// Token: 0x0403A872 RID: 239730
			public const int Fail = 1;

			// Token: 0x0403A873 RID: 239731
			public const int ReviveBtn = 2;

			// Token: 0x0403A874 RID: 239732
			public const int GiveUpBtn = 3;

			// Token: 0x0403A875 RID: 239733
			public const int WaitTime = 4;

			// Token: 0x0403A876 RID: 239734
			public const int ReviveTitle = 5;

			// Token: 0x0403A877 RID: 239735
			public const int ReviveContent = 6;

			// Token: 0x0403A878 RID: 239736
			public const int RoleTrainingLayout = 7;

			// Token: 0x0403A879 RID: 239737
			public const int ReviveAtLocationBtn = 8;

			// Token: 0x0403A87A RID: 239738
			public const int AutoReviveCountDownText = 9;

			// Token: 0x0403A87B RID: 239739
			public const int ItemTexture = 10;

			// Token: 0x0403A87C RID: 239740
			public const int ItemText = 11;

			// Token: 0x0403A87D RID: 239741
			public const int GiveUpBtnText = 12;
		}
	}
}
