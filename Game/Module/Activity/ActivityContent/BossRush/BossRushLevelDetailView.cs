using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.BossRush
{
	// Token: 0x020069BF RID: 27071
	[NullableContext(2)]
	[Nullable(0)]
	public class BossRushLevelDetailView : UiTabViewBase
	{
		// Token: 0x060431DB RID: 274907 RVA: 0x0113D4E0 File Offset: 0x0113B6E0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(8, typeof(UUIText)),
				new ValueTuple<int, Type>(9, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(1, new Action(this.OnClickHelpBtn)),
				new ValueTuple<int, Delegate>(7, new Action(this.OnClickConfirmButton))
			};
		}

		// Token: 0x060431DC RID: 274908 RVA: 0x0113D610 File Offset: 0x0113B810
		private void OnClickHelpBtn()
		{
			if (this.CurrentTeamInfo == null || this.CurrentTeamInfo.GetCurrentSelectLevel() == null)
			{
				return;
			}
			int instanceDungeonId = this.CurrentTeamInfo.GetCurrentSelectLevel().GetInstanceDungeonId();
			ModelBase<InstanceDungeonEntranceModel>.Instance.SelectInstanceId = instanceDungeonId;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.InstanceDungeonMonsterPreView, new InstanceDungeonMonsterView.InstanceDungeonMonsterViewOpenParam
			{
				InstanceId = instanceDungeonId,
				InfoType = null
			}, null);
		}

		// Token: 0x060431DD RID: 274909 RVA: 0x0113D67C File Offset: 0x0113B87C
		private void OnClickConfirmButton()
		{
			if (this.CurrentTeamInfo == null || this.CurrentTeamInfo.LevelInfo == null)
			{
				return;
			}
			int instanceDungeonFormationNumb = this.CurrentTeamInfo.LevelInfo.GetInstanceDungeonFormationNumb();
			int num = 0;
			if (this.CurrentTeamInfo != null)
			{
				int[] currentTeamMembers = this.CurrentTeamInfo.GetCurrentTeamMembers();
				for (int i = 0; i < currentTeamMembers.Length; i++)
				{
					if (currentTeamMembers[i] != 0)
					{
						num++;
					}
				}
			}
			if (num == 0)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("BossRushAtlestOneRole", Array.Empty<object>());
				return;
			}
			int num2 = 0;
			using (List<BuffEntry>.Enumerator enumerator = this.BuffEntryItemArray.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.HaveBuff())
					{
						num2++;
					}
				}
			}
			if (num2 < 2)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("BossRushBuffCountTips", Array.Empty<object>());
				return;
			}
			if (instanceDungeonFormationNumb > num)
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.BossRushRoleLess);
				Action value = delegate()
				{
					if (this.CurrentTeamInfo != null)
					{
						ControllerBase<BossRushController>.Instance.RequestStartBossRushByTeamData(this.CurrentTeamInfo);
					}
				};
				confirmBoxDataNew.FunctionMap.Add(2, value);
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			if (this.CurrentTeamInfo != null)
			{
				ControllerBase<BossRushController>.Instance.RequestStartBossRushByTeamData(this.CurrentTeamInfo);
			}
		}

		// Token: 0x060431DE RID: 274910 RVA: 0x0113D7B4 File Offset: 0x0113B9B4
		protected override UniTask OnBeforeStartAsync()
		{
			BossRushLevelDetailView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BossRushLevelDetailView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060431DF RID: 274911 RVA: 0x0113D7F8 File Offset: 0x0113B9F8
		private void TryShowAnimation()
		{
			string sequenceName = "Start";
			if (ModelBase<BossRushModel>.Instance.PlayBackAnimation)
			{
				sequenceName = "ShowView";
			}
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlaySequencePurely(sequenceName, false, false, null, null, false);
			}
			ModelBase<BossRushModel>.Instance.PlayBackAnimation = false;
		}

		// Token: 0x060431E0 RID: 274912 RVA: 0x0113D847 File Offset: 0x0113BA47
		private void OnSelectBuff()
		{
			this.RefreshBuffEntry();
		}

		// Token: 0x060431E1 RID: 274913 RVA: 0x0113D84F File Offset: 0x0113BA4F
		protected override void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnChangeBossRushBuff, new Action(this.OnSelectBuff));
			Singleton<EventSystem>.Instance.Add(EEventName.OnRoleChangeEnd, new Action(this.OnRoleChangeEnd));
		}

		// Token: 0x060431E2 RID: 274914 RVA: 0x0113D889 File Offset: 0x0113BA89
		protected override void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnChangeBossRushBuff, new Action(this.OnSelectBuff));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRoleChangeEnd, new Action(this.OnRoleChangeEnd));
		}

		// Token: 0x060431E3 RID: 274915 RVA: 0x0113D8C4 File Offset: 0x0113BAC4
		private void OnRoleChangeEnd()
		{
			RoleModel instance = ModelBase<RoleModel>.Instance;
			if (this.CurrentTeamInfo == null)
			{
				return;
			}
			int[] currentTeamMembers = this.CurrentTeamInfo.GetCurrentTeamMembers();
			for (int i = 0; i < currentTeamMembers.Length; i++)
			{
				int id = currentTeamMembers[i];
				RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(id, true);
				int roleId = (roleDataById != null) ? roleDataById.GetRoleId() : 0;
				if (instance.IsMainRole(roleId))
				{
					this.CurrentTeamInfo.SetIndexTeamMembers(i, 0);
				}
			}
			this.OnSelectTeamRole();
		}

		// Token: 0x060431E4 RID: 274916 RVA: 0x0113D938 File Offset: 0x0113BB38
		protected override void OnBeforeShow()
		{
			this.CurrentTeamInfo = ModelBase<BossRushModel>.Instance.CurrentTeamInfo;
			if (this.CurrentTeamInfo == null)
			{
				return;
			}
			foreach (int num in this.CurrentTeamInfo.GetCurrentTeamMembers())
			{
				if (ModelBase<RoleModel>.Instance.IsMainRole(num) && ModelBase<RoleModel>.Instance.GetRoleInstanceById(num) == null)
				{
					this.CurrentTeamInfo.ClearTeamInfo();
					break;
				}
			}
			this.TryShowAnimation();
			this.RefreshMonsterInfo();
			this.RefreshLevelBossNumText();
			this.RefreshScore();
			this.RefreshLowLevelTips();
			this.RefreshTeamItem();
			this.RefreshBuffEntry();
		}

		// Token: 0x060431E5 RID: 274917 RVA: 0x0113D9CD File Offset: 0x0113BBCD
		private void OnSelectTeamRole()
		{
			this.RefreshLowLevelTips();
			this.RefreshTeamRole();
		}

		// Token: 0x060431E6 RID: 274918 RVA: 0x0113D9DC File Offset: 0x0113BBDC
		private void RefreshLowLevelTips()
		{
			if (this.CurrentTeamInfo == null)
			{
				return;
			}
			bool ifLevelTooLow = this.CurrentTeamInfo.GetIfLevelTooLow();
			base.GetText(6).SetUIActive(ifLevelTooLow);
		}

		// Token: 0x060431E7 RID: 274919 RVA: 0x0113DA0C File Offset: 0x0113BC0C
		private void RefreshMonsterInfo()
		{
			if (this.CurrentTeamInfo == null || this.CurrentTeamInfo.GetCurrentSelectLevel() == null)
			{
				return;
			}
			BossRushLevelDetailInfo currentSelectLevel = this.CurrentTeamInfo.GetCurrentSelectLevel();
			base.SetTextureByPath(currentSelectLevel.GetBigMonsterTexturePath(), base.GetTexture(0), new EUiViewName?(EUiViewName.BossRushMainView), null);
		}

		// Token: 0x060431E8 RID: 274920 RVA: 0x0113DA5C File Offset: 0x0113BC5C
		private void RefreshLevelBossNumText()
		{
			BossRushTeamInfo currentTeamInfo = this.CurrentTeamInfo;
			bool flag;
			if (currentTeamInfo == null)
			{
				flag = true;
			}
			else
			{
				BossRushLevelDetailInfo currentSelectLevel = currentTeamInfo.GetCurrentSelectLevel();
				if (currentSelectLevel == null)
				{
					flag = true;
				}
				else
				{
					BossRushActivity? config = currentSelectLevel.GetConfig();
					flag = (config == null);
				}
			}
			if (flag)
			{
				return;
			}
			BossRushTeamInfo currentTeamInfo2 = this.CurrentTeamInfo;
			int? num;
			if (currentTeamInfo2 == null)
			{
				num = null;
			}
			else
			{
				BossRushLevelDetailInfo currentSelectLevel2 = currentTeamInfo2.GetCurrentSelectLevel();
				if (currentSelectLevel2 == null)
				{
					num = null;
				}
				else
				{
					BossRushActivity? config = currentSelectLevel2.GetConfig();
					num = ((config != null) ? new int?(config.GetValueOrDefault().BossCount) : null);
				}
			}
			int? num2 = num;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "BossRushNumTips", new <>z__ReadOnlySingleElementList<object>(num2));
		}

		// Token: 0x060431E9 RID: 274921 RVA: 0x0113DB10 File Offset: 0x0113BD10
		private void RefreshScore()
		{
			BossRushData bossRushData = ModelBase<ActivityModel>.Instance.GetActivityById(ModelBase<BossRushModel>.Instance.CurrentSelectActivityId) as BossRushData;
			if (bossRushData == null || this.CurrentTeamInfo == null || this.CurrentTeamInfo.GetCurrentSelectLevel() == null)
			{
				return;
			}
			BossRushLevelDetailInfo bossRushLevelDetailInfoById = bossRushData.GetBossRushLevelDetailInfoById(this.CurrentTeamInfo.GetCurrentSelectLevel().GetInstanceDungeonId());
			int? num = (bossRushLevelDetailInfoById != null) ? new int?(bossRushLevelDetailInfoById.GetScore()) : null;
			UUIText text = base.GetText(8);
			if (num != null)
			{
				int? num2 = num;
				int num3 = 0;
				if (num2.GetValueOrDefault() > num3 & num2 != null)
				{
					if (text != null)
					{
						text.SetUIActive(true);
					}
					if (text != null)
					{
						UUIText uuitext = text;
						num2 = num;
						uuitext.SetText(num2.ToString() ?? "", true);
					}
					UUIItem item = base.GetItem(9);
					if (item == null)
					{
						return;
					}
					item.SetUIActive(false);
					return;
				}
			}
			if (text != null)
			{
				text.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(9);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(true);
		}

		// Token: 0x060431EA RID: 274922 RVA: 0x0113DC08 File Offset: 0x0113BE08
		private void RefreshTeamItem()
		{
			if (this.TeamItem != null && this.CurrentTeamInfo != null)
			{
				this.TeamItem.Refresh(this.CurrentTeamInfo);
			}
		}

		// Token: 0x060431EB RID: 274923 RVA: 0x0113DC2B File Offset: 0x0113BE2B
		private void RefreshTeamRole()
		{
			if (this.TeamItem != null && this.CurrentTeamInfo != null)
			{
				this.TeamItem.RefreshTeamRole(this.CurrentTeamInfo);
			}
		}

		// Token: 0x060431EC RID: 274924 RVA: 0x0113DC50 File Offset: 0x0113BE50
		private void RefreshBuffEntry()
		{
			if (this.CurrentTeamInfo == null)
			{
				return;
			}
			List<BossRushBuffInfo> list = (ModelBase<BossRushModel>.Instance.CurrentSelectBuffTabName == EBuffTabName.Normal) ? this.CurrentTeamInfo.GetPrepareSelectBuff() : this.CurrentTeamInfo.GetPrepareSelectScoreBuff();
			for (int i = 0; i < list.Count; i++)
			{
				if (i < this.BuffEntryItemArray.Count)
				{
					this.BuffEntryItemArray[i].Refresh(list[i]);
				}
			}
		}

		// Token: 0x0402566A RID: 153194
		private BossRushTeamInfo CurrentTeamInfo;

		// Token: 0x0402566B RID: 153195
		private TeamItem TeamItem;

		// Token: 0x0402566C RID: 153196
		private BuffEntry BuffEntryItem1;

		// Token: 0x0402566D RID: 153197
		private BuffEntry BuffEntryItem2;

		// Token: 0x0402566E RID: 153198
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0402566F RID: 153199
		[Nullable(1)]
		private readonly List<BuffEntry> BuffEntryItemArray = new List<BuffEntry>();

		// Token: 0x0200C947 RID: 51527
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403DE77 RID: 253559
			MonsterTexture,
			// Token: 0x0403DE78 RID: 253560
			HelpBtn,
			// Token: 0x0403DE79 RID: 253561
			LevelTipsText,
			// Token: 0x0403DE7A RID: 253562
			BuffEntryItem1,
			// Token: 0x0403DE7B RID: 253563
			BuffEntryItem2,
			// Token: 0x0403DE7C RID: 253564
			TeamItem,
			// Token: 0x0403DE7D RID: 253565
			LowLevelTipsText,
			// Token: 0x0403DE7E RID: 253566
			ConfirmButton,
			// Token: 0x0403DE7F RID: 253567
			ScoreText,
			// Token: 0x0403DE80 RID: 253568
			UnFinishItem
		}
	}
}
