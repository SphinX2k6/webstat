using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Views;
using CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch
{
	// Token: 0x020068C7 RID: 26823
	[NullableContext(1)]
	[Nullable(0)]
	public class DropCatchRoleDetailView : UiViewBase
	{
		// Token: 0x06042B51 RID: 273233 RVA: 0x0111EE3D File Offset: 0x0111D03D
		public DropCatchRoleDetailView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06042B52 RID: 273234 RVA: 0x0111EE48 File Offset: 0x0111D048
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIGridLayout)),
				new ValueTuple<int, Type>(2, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(3, typeof(UUISprite)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUITexture)),
				new ValueTuple<int, Type>(12, typeof(UUIText))
			};
		}

		// Token: 0x06042B53 RID: 273235 RVA: 0x0111EF84 File Offset: 0x0111D184
		protected override UniTask OnBeforeStartAsync()
		{
			DropCatchRoleDetailView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DropCatchRoleDetailView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06042B54 RID: 273236 RVA: 0x0111EFC8 File Offset: 0x0111D1C8
		protected override void OnBeforeShow()
		{
			DropCatchRoleDetailViewParams dropCatchRoleDetailViewParams = this.OpenParam as DropCatchRoleDetailViewParams;
			IReadOnlyList<DropCatchRoleBook> dropCatchRoleBookAll = ConfigBase<DropCatchConfig>.Instance.GetDropCatchRoleBookAll();
			this.CurBookConfigId = 0;
			if (dropCatchRoleBookAll != null && dropCatchRoleDetailViewParams != null)
			{
				foreach (DropCatchRoleBook dropCatchRoleBook in dropCatchRoleBookAll)
				{
					if (dropCatchRoleBook.RoleId == dropCatchRoleDetailViewParams.OpenRoleConfigId)
					{
						this.CurBookConfigId = dropCatchRoleBook.Id;
						break;
					}
				}
			}
			this.UpdateRoleLayout();
			this.SetCurrentSelectedRoleDetail();
		}

		// Token: 0x06042B55 RID: 273237 RVA: 0x0111F058 File Offset: 0x0111D258
		protected override void OnBeforeHide()
		{
			this.ClearCountdownTimer();
		}

		// Token: 0x06042B56 RID: 273238 RVA: 0x0111F060 File Offset: 0x0111D260
		private DropCatchRoleBook? GetCurBookConfig()
		{
			return ConfigBase<DropCatchConfig>.Instance.GetDropCatchRoleBookById(this.CurBookConfigId);
		}

		// Token: 0x06042B57 RID: 273239 RVA: 0x0111F074 File Offset: 0x0111D274
		private DropCatchRole? GetCurRoleConfig()
		{
			DropCatchRoleBook? curBookConfig = this.GetCurBookConfig();
			if (curBookConfig == null)
			{
				return null;
			}
			return ConfigBase<DropCatchConfig>.Instance.GetDropCatchRoleById((curBookConfig != null) ? curBookConfig.GetValueOrDefault().RoleId : 0);
		}

		// Token: 0x06042B58 RID: 273240 RVA: 0x0111F0C0 File Offset: 0x0111D2C0
		private DropCatchRoleItem InitRoleItem()
		{
			DropCatchRoleItem dropCatchRoleItem = new DropCatchRoleItem();
			dropCatchRoleItem.SetClickCallback(new Action<int, int>(this.OnRoleItemClick));
			return dropCatchRoleItem;
		}

		// Token: 0x06042B59 RID: 273241 RVA: 0x0111F0D9 File Offset: 0x0111D2D9
		private DropCatchRoleInfoItem InitRoleInfoItem()
		{
			return new DropCatchRoleInfoItem();
		}

		// Token: 0x06042B5A RID: 273242 RVA: 0x0111F0E0 File Offset: 0x0111D2E0
		private void OnRoleItemClick(int configId, int index)
		{
			this.CurBookConfigId = configId;
			this.RoleLayout.SelectGridProxy(index, false);
			this.SetCurrentSelectedRoleDetail();
			this.SequencePlayer.PlayLevelSequenceByName("Switch", false, null, false);
		}

		// Token: 0x06042B5B RID: 273243 RVA: 0x0111F124 File Offset: 0x0111D324
		private void UpdateRoleLayout()
		{
			IReadOnlyList<DropCatchRoleBook> dropCatchRoleBookAll = ConfigBase<DropCatchConfig>.Instance.GetDropCatchRoleBookAll();
			List<IDropCatchRoleItemData> list = new List<IDropCatchRoleItemData>();
			int curIndex = 0;
			if (dropCatchRoleBookAll != null)
			{
				DropCatchActivityData dropCatchActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(ControllerBase<DropCatchActivityController>.Instance.ActivityId) as DropCatchActivityData;
				for (int i = 0; i < dropCatchRoleBookAll.Count; i++)
				{
					DropCatchRoleBook dropCatchRoleBook = dropCatchRoleBookAll[i];
					if (this.CurBookConfigId == 0)
					{
						this.CurBookConfigId = dropCatchRoleBook.Id;
					}
					if (dropCatchRoleBook.Id == this.CurBookConfigId)
					{
						curIndex = i;
					}
					bool isUnlock = false;
					DropCatchGameplay? targetRoleLevelInfo = ConfigBase<DropCatchConfig>.Instance.GetTargetRoleLevelInfo(dropCatchActivityData.Id, dropCatchRoleBook.RoleId);
					DropCatchLevelData levelData = dropCatchActivityData.GetLevelData(targetRoleLevelInfo.Value.Id);
					if (levelData != null && levelData.IsUnlock)
					{
						if (i > 0)
						{
							DropCatchLevelData lastLevelData = dropCatchActivityData.GetLastLevelData(targetRoleLevelInfo.Value.Id);
							if (lastLevelData != null && lastLevelData.HasAnyStar)
							{
								isUnlock = true;
							}
						}
						else
						{
							isUnlock = true;
						}
					}
					DropCatchRoleItemData item = new DropCatchRoleItemData
					{
						BookCfgId = dropCatchRoleBook.Id,
						RoleCfgId = dropCatchRoleBook.RoleId,
						IsUnlock = isUnlock
					};
					list.Add(item);
				}
			}
			this.RoleLayout.RefreshByData(list, delegate
			{
				this.RoleLayout.SelectGridProxy(curIndex, false);
				if (!this.AlreadyPlayedListAnim)
				{
					UUIInturnAnimController animationController = this.AnimationController;
					if (animationController != null)
					{
						animationController.Play("Start", -1, false);
					}
					this.AlreadyPlayedListAnim = true;
				}
			}, false);
		}

		// Token: 0x06042B5C RID: 273244 RVA: 0x0111F284 File Offset: 0x0111D484
		private void SetCurrentSelectedRoleDetail()
		{
			this.ClearCountdownTimer();
			IReadOnlyList<IDropCatchRoleItemData> datas = this.RoleLayout.GetDatas();
			IDropCatchRoleItemData dropCatchRoleItemData = null;
			if (datas != null)
			{
				foreach (IDropCatchRoleItemData dropCatchRoleItemData2 in datas)
				{
					if (dropCatchRoleItemData2.BookCfgId == this.CurBookConfigId)
					{
						dropCatchRoleItemData = dropCatchRoleItemData2;
						break;
					}
				}
			}
			if (dropCatchRoleItemData == null)
			{
				return;
			}
			bool isUnlock = dropCatchRoleItemData.IsUnlock;
			if (isUnlock)
			{
				ControllerBase<DropCatchActivityController>.Instance.SetNewRoleClicked(dropCatchRoleItemData.RoleCfgId);
			}
			UUIItem item = base.GetItem(10);
			if (item != null)
			{
				item.SetUIActive(!isUnlock);
			}
			UUIItem item2 = base.GetItem(8);
			if (item2 != null)
			{
				item2.SetUIActive(isUnlock);
			}
			UUIItem uuiitem = base.GetVerticalLayout(6).RootUIComp.Get();
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(isUnlock);
			}
			DropCatchRoleBook? curBookConfig = this.GetCurBookConfig();
			if (curBookConfig != null)
			{
				string text = curBookConfig.Value.Id.ToString();
				this.SetSpriteByPath(StringUtils.Format("/Game/Aki/UI/UIResources/Common/Atlas/Num/Roman/RomanB/SP_RomanA0{0}.SP_RomanA0{1}", new string[]
				{
					text,
					text
				}), base.GetSprite(3), false, null, null);
			}
			if (isUnlock)
			{
				this.ShowUnlockDetail();
				return;
			}
			this.RefreshLockTips();
			this.ShowLockDetail();
		}

		// Token: 0x06042B5D RID: 273245 RVA: 0x0111F3D4 File Offset: 0x0111D5D4
		private void ShowUnlockDetail()
		{
			DropCatchRole? curRoleConfig = this.GetCurRoleConfig();
			if (curRoleConfig == null)
			{
				return;
			}
			UUIText text = base.GetText(4);
			if (text != null)
			{
				text.ShowTextNew(curRoleConfig.Value.Name);
			}
			this.UpdateRoleInfo().Forget();
			UUIText text2 = base.GetText(5);
			if (text2 != null)
			{
				text2.ShowTextNew(curRoleConfig.Value.Desc);
			}
			List<float> list = new List<float>();
			if (curRoleConfig.Value.GuideMoveSpeed > 0f)
			{
				list.Add(curRoleConfig.Value.GuideMoveSpeed);
			}
			if (curRoleConfig.Value.ReceiveRange != 0f)
			{
				list.Add(curRoleConfig.Value.ReceiveRange);
			}
			if (curRoleConfig.Value.GuideEnergyGetRate != 0f)
			{
				list.Add(curRoleConfig.Value.GuideEnergyGetRate);
			}
			this.RoleInfoLayout.RefreshByData(list, null, false);
		}

		// Token: 0x06042B5E RID: 273246 RVA: 0x0111F4D4 File Offset: 0x0111D6D4
		private void ShowLockDetail()
		{
			DropCatchRole? curRoleConfig = this.GetCurRoleConfig();
			if (curRoleConfig != null)
			{
				base.SetTextureByPath(curRoleConfig.Value.SilhouettePath, base.GetTexture(11), null, null);
			}
			UUIText text = base.GetText(4);
			if (text != null)
			{
				text.ShowTextNew("CoinCatch_Character_UnlockName");
			}
			UUIText text2 = base.GetText(5);
			if (text2 == null)
			{
				return;
			}
			text2.ShowTextNew("CoinCatch_Character_UnlockInfo");
		}

		// Token: 0x06042B5F RID: 273247 RVA: 0x0111F548 File Offset: 0x0111D748
		private void RefreshLockTips()
		{
			DropCatchActivityData dropCatchActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(ControllerBase<DropCatchActivityController>.Instance.ActivityId) as DropCatchActivityData;
			if (dropCatchActivityData == null)
			{
				return;
			}
			DropCatchRole? curRoleConfig = this.GetCurRoleConfig();
			if (curRoleConfig == null)
			{
				return;
			}
			DropCatchGameplay? levelConfig = ConfigBase<DropCatchConfig>.Instance.GetTargetRoleLevelInfo(dropCatchActivityData.Id, curRoleConfig.Value.Id);
			if (levelConfig == null)
			{
				return;
			}
			DropCatchLevelData dropCatchLevelData = (dropCatchActivityData != null) ? dropCatchActivityData.GetLevelData(levelConfig.Value.Id) : null;
			if (dropCatchLevelData == null)
			{
				return;
			}
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			double num = dropCatchLevelData.UnlockTime - serverTime;
			this.UpdateUnlockText(levelConfig.Value.Id);
			if (num > 0.0)
			{
				this.CountdownTimerHandle = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
				{
					this.UpdateUnlockText(levelConfig.Value.Id);
				}, 1000f, 1f, null, null, true);
			}
		}

		// Token: 0x06042B60 RID: 273248 RVA: 0x0111F650 File Offset: 0x0111D850
		private void UpdateUnlockText(int configId)
		{
			string levelUnlockHintText = (ModelBase<ActivityModel>.Instance.GetActivityById(ControllerBase<DropCatchActivityController>.Instance.ActivityId) as DropCatchActivityData).GetLevelUnlockHintText(configId);
			if (levelUnlockHintText != null)
			{
				base.GetText(12).SetText(levelUnlockHintText, true);
			}
		}

		// Token: 0x06042B61 RID: 273249 RVA: 0x0111F68F File Offset: 0x0111D88F
		private void ClearCountdownTimer()
		{
			if (TimerSystem.GameplayTimeInstance.Has(this.CountdownTimerHandle))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.CountdownTimerHandle);
			}
			this.CountdownTimerHandle = null;
		}

		// Token: 0x06042B62 RID: 273250 RVA: 0x0111F6BC File Offset: 0x0111D8BC
		private UniTask UpdateRoleInfo()
		{
			DropCatchRoleDetailView.<UpdateRoleInfo>d__26 <UpdateRoleInfo>d__;
			<UpdateRoleInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UpdateRoleInfo>d__.<>4__this = this;
			<UpdateRoleInfo>d__.<>1__state = -1;
			<UpdateRoleInfo>d__.<>t__builder.Start<DropCatchRoleDetailView.<UpdateRoleInfo>d__26>(ref <UpdateRoleInfo>d__);
			return <UpdateRoleInfo>d__.<>t__builder.Task;
		}

		// Token: 0x040252BC RID: 152252
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x040252BD RID: 152253
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<DropCatchRoleItem, IDropCatchRoleItemData> RoleLayout;

		// Token: 0x040252BE RID: 152254
		private GenericLayout<DropCatchRoleInfoItem, float> RoleInfoLayout;

		// Token: 0x040252BF RID: 152255
		[Nullable(2)]
		private TimerHandle CountdownTimerHandle;

		// Token: 0x040252C0 RID: 152256
		[Nullable(2)]
		private UUIInturnAnimController AnimationController;

		// Token: 0x040252C1 RID: 152257
		[Nullable(2)]
		private LevelSequencePlayer SequencePlayer;

		// Token: 0x040252C2 RID: 152258
		private int CurBookConfigId;

		// Token: 0x040252C3 RID: 152259
		[Nullable(2)]
		private DropCatchGameplayRoleView RoleView;

		// Token: 0x040252C4 RID: 152260
		private bool AlreadyPlayedListAnim;

		// Token: 0x040252C5 RID: 152261
		private const string ROME_ICON_PATH = "/Game/Aki/UI/UIResources/Common/Atlas/Num/Roman/RomanB/SP_RomanA0{0}.SP_RomanA0{1}";
	}
}
