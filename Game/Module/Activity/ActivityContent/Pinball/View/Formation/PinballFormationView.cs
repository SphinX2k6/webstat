using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.KuroSimpleCombat.PB;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Formation
{
	// Token: 0x02006634 RID: 26164
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballFormationView : UiViewBase
	{
		// Token: 0x060415A4 RID: 267684 RVA: 0x010C2D55 File Offset: 0x010C0F55
		public PinballFormationView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x060415A5 RID: 267685 RVA: 0x010C2D6C File Offset: 0x010C0F6C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 17;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 4;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickStartBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickLeaderSkillBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(9, new Action(this.OnClickLeaderHeadTipsMaskBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(15, new Action(this.OnClickMonsterBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060415A6 RID: 267686 RVA: 0x010C3078 File Offset: 0x010C1278
		protected override UniTask OnBeforeStartAsync()
		{
			PinballFormationView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PinballFormationView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060415A7 RID: 267687 RVA: 0x010C30BC File Offset: 0x010C12BC
		protected override void OnStart()
		{
			IPinballFormationViewData pinballFormationViewData = this.OpenParam as IPinballFormationViewData;
			this.LevelId = pinballFormationViewData.LevelId;
			this.InitRoleInFormation();
			this.InitLevelInfo();
			base.GetItem(8).SetUIActive(false);
			base.GetSprite(13).SetUIActive(false);
		}

		// Token: 0x060415A8 RID: 267688 RVA: 0x010C3108 File Offset: 0x010C1308
		protected override void OnBeforeShow()
		{
			this.RefreshFormationList(this.InFormationRoleList);
		}

		// Token: 0x060415A9 RID: 267689 RVA: 0x010C3118 File Offset: 0x010C1318
		private void InitRoleInFormation()
		{
			PinballLevelConfig? pinballLevelConfigById = ConfigBase<PinballConfig>.Instance.GetPinballLevelConfigById(this.LevelId);
			if (pinballLevelConfigById == null || pinballLevelConfigById.Value.TrailRoleLength <= 0)
			{
				this.InFormationRoleList = ModelBase<PinballModel>.Instance.GetPinballLevelLastSelectedRoleList((pinballLevelConfigById != null) ? pinballLevelConfigById.GetValueOrDefault().FormationGroup : 0);
				return;
			}
			this.IsTrailLevel = true;
			int trailRoleLength = pinballLevelConfigById.Value.TrailRoleLength;
			this.InFormationRoleList = new List<int>();
			for (int i = 0; i < trailRoleLength; i++)
			{
				this.InFormationRoleList.Add(pinballLevelConfigById.Value.TrailRole(i));
			}
		}

		// Token: 0x060415AA RID: 267690 RVA: 0x010C31C8 File Offset: 0x010C13C8
		private void InitLevelInfo()
		{
			PinballLevelConfig? pinballLevelConfigById = ConfigBase<PinballConfig>.Instance.GetPinballLevelConfigById(this.LevelId);
			if (pinballLevelConfigById == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), "Pinball_Character_Team_reclevel", new <>z__ReadOnlySingleElementList<object>(pinballLevelConfigById.Value.RecommendLevel));
			PopupCaptionItem captionItem = this.CaptionItem;
			if (captionItem == null)
			{
				return;
			}
			captionItem.SetTitleLocalText(pinballLevelConfigById.Value.Name);
		}

		// Token: 0x060415AB RID: 267691 RVA: 0x010C3240 File Offset: 0x010C1440
		private void OnClickStartBtn()
		{
			if ((this.OpenParam as IPinballFormationViewData).IsRestart.GetValueOrDefault())
			{
				(ControllerBase<KuroSimpleCombatController>.Instance.CurSubController as PinballBattleSubController).Restart(this.InFormationRoleList).Forget();
				return;
			}
			PinballBattleSubController.RequestEnterInst(this.LevelId, this.IsTrailLevel ? new List<int>() : this.InFormationRoleList);
		}

		// Token: 0x060415AC RID: 267692 RVA: 0x010C32A7 File Offset: 0x010C14A7
		private void OnClickLeaderSkillBtn()
		{
			base.GetItem(8).SetUIActive(true);
		}

		// Token: 0x060415AD RID: 267693 RVA: 0x010C32B6 File Offset: 0x010C14B6
		private void OnClickLeaderHeadTipsMaskBtn()
		{
			base.GetItem(8).SetUIActive(false);
		}

		// Token: 0x060415AE RID: 267694 RVA: 0x010C32C8 File Offset: 0x010C14C8
		private void OnClickMonsterBtn()
		{
			int levelId = this.LevelId;
			if (ConfigBase<PinballConfig>.Instance.GetPinballLevelConfigById(this.LevelId).Value.Type == 4)
			{
				levelId = ModelBase<PinballModel>.Instance.ActivityData.GetDailyRandomLevelId();
			}
			ControllerBase<PinballController>.Instance.OpenMonsterDetailView(levelId).Forget<bool>();
		}

		// Token: 0x060415AF RID: 267695 RVA: 0x010C3320 File Offset: 0x010C1520
		private void OnClickFormationItemCallBack(int roleId)
		{
			if (this.IsTrailLevel)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PinballFilterTrailClickTips", Array.Empty<object>());
				return;
			}
			ModelBase<PinballModel>.Instance.SelectRoleHandleList.AddRange(this.InFormationRoleList);
			IPinballFormationSelectRoleViewData openFormationSelectRoleViewData = this.GetOpenFormationSelectRoleViewData(roleId);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PinballFormationSelectRoleView, openFormationSelectRoleViewData, null);
		}

		// Token: 0x060415B0 RID: 267696 RVA: 0x010C3378 File Offset: 0x010C1578
		private IPinballFormationSelectRoleViewData GetOpenFormationSelectRoleViewData(int roleId)
		{
			PinballLevelConfig? pinballLevelConfigById = ConfigBase<PinballConfig>.Instance.GetPinballLevelConfigById(this.LevelId);
			List<int> list;
			if (pinballLevelConfigById != null)
			{
				int recommendRoleLength = pinballLevelConfigById.Value.RecommendRoleLength;
				list = new List<int>();
				for (int i = 0; i < recommendRoleLength; i++)
				{
					list.Add(pinballLevelConfigById.Value.RecommendRole(i));
				}
			}
			else
			{
				list = new List<int>();
			}
			return new PinballFormationSelectRoleViewData
			{
				RoleList = ModelBase<PinballModel>.Instance.GetPinballCanSelectRoleList(),
				RecommendRoleList = list,
				OnConfirm = new Action<List<int>>(this.OnPinballFormationSelectRoleViewConfirm),
				OpenRole = new int?(roleId)
			};
		}

		// Token: 0x060415B1 RID: 267697 RVA: 0x010C341E File Offset: 0x010C161E
		private void OnPinballFormationSelectRoleViewConfirm(List<int> roleIdList)
		{
			this.RefreshFormationList(roleIdList);
		}

		// Token: 0x060415B2 RID: 267698 RVA: 0x010C3428 File Offset: 0x010C1628
		private void RefreshFormationList(List<int> roleIdList)
		{
			this.InFormationRoleList = roleIdList;
			this.CurrentLeadRole = ((roleIdList.Count > 0) ? roleIdList[0] : 0);
			for (int i = 0; i < this.FormationItemList.Count; i++)
			{
				PinballFormationItem pinballFormationItem = this.FormationItemList[i];
				if (i >= roleIdList.Count)
				{
					pinballFormationItem.RefreshItem(0);
				}
				else
				{
					pinballFormationItem.RefreshItem(roleIdList[i]);
				}
			}
			base.GetButton(3).SetSelfInteractive(this.InFormationRoleList.Count > 0);
			this.RefreshLowLevelTips();
			this.RefreshWarnClassTips();
			this.RefreshLeaderSkill();
		}

		// Token: 0x060415B3 RID: 267699 RVA: 0x010C34C4 File Offset: 0x010C16C4
		private void RefreshLowLevelTips()
		{
			int pinballSelectRoleLevelAverage = ModelBase<PinballModel>.Instance.GetPinballSelectRoleLevelAverage(this.InFormationRoleList);
			PinballLevelConfig? pinballLevelConfigById = ConfigBase<PinballConfig>.Instance.GetPinballLevelConfigById(this.LevelId);
			if (pinballLevelConfigById == null || pinballSelectRoleLevelAverage == 0)
			{
				base.GetItem(4).SetUIActive(false);
				return;
			}
			int num = (this.InFormationRoleList.Count > 0) ? ModelBase<PinballModel>.Instance.GetRoleLevel(this.InFormationRoleList[0]) : 0;
			base.GetItem(4).SetUIActive(pinballSelectRoleLevelAverage < pinballLevelConfigById.Value.RecommendLevel);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), (num > 0 && num >= pinballLevelConfigById.Value.RecommendLevel) ? "Pinball_Character_Team_AvgLevelLow" : "Pinball_Character_Team_LeaderLevelLow", Array.Empty<object>());
		}

		// Token: 0x060415B4 RID: 267700 RVA: 0x010C358C File Offset: 0x010C178C
		private void RefreshWarnClassTips()
		{
			bool flag = false;
			foreach (int id in this.InFormationRoleList)
			{
				PinballRoleConfig? pinballRoleConfigById = ConfigBase<PinballConfig>.Instance.GetPinballRoleConfigById(id);
				int pinballClassLength = pinballRoleConfigById.Value.PinballClassLength;
				for (int i = 0; i < pinballClassLength; i++)
				{
					if (pinballRoleConfigById.Value.PinballClass(i) == 3)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					break;
				}
			}
			base.GetItem(16).SetUIActive(!flag);
		}

		// Token: 0x060415B5 RID: 267701 RVA: 0x010C3638 File Offset: 0x010C1838
		private void RefreshLeaderSkill()
		{
			if (this.CurrentLeadRole == 0)
			{
				base.GetButton(6).RootUIComp.Get().SetUIActive(false);
				return;
			}
			PinballRoleConfig? pinballRoleConfigById = ConfigBase<PinballConfig>.Instance.GetPinballRoleConfigById(this.CurrentLeadRole);
			if (pinballRoleConfigById == null)
			{
				return;
			}
			PinballSkillDisplayConfig? pinballSkillDisplayConfigById = ConfigBase<PinballConfig>.Instance.GetPinballSkillDisplayConfigById(pinballRoleConfigById.Value.SkillDisplayList(0));
			if (pinballSkillDisplayConfigById == null)
			{
				return;
			}
			base.GetButton(6).RootUIComp.Get().SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), pinballSkillDisplayConfigById.Value.Name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), pinballSkillDisplayConfigById.Value.Desc, pinballSkillDisplayConfigById.Value.ValueList());
			base.SetTextureByPath(pinballRoleConfigById.Value.BigIcon, base.GetTexture(7), null, null);
		}

		// Token: 0x060415B6 RID: 267702 RVA: 0x010C3744 File Offset: 0x010C1944
		[NullableContext(0)]
		public override UniTask<bool> CloseMeAsync()
		{
			PinballFormationView.<CloseMeAsync>d__25 <CloseMeAsync>d__;
			<CloseMeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<CloseMeAsync>d__.<>4__this = this;
			<CloseMeAsync>d__.<>1__state = -1;
			<CloseMeAsync>d__.<>t__builder.Start<PinballFormationView.<CloseMeAsync>d__25>(ref <CloseMeAsync>d__);
			return <CloseMeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x040248D8 RID: 149720
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x040248D9 RID: 149721
		private readonly List<PinballFormationItem> FormationItemList = new List<PinballFormationItem>();

		// Token: 0x040248DA RID: 149722
		private int LevelId;

		// Token: 0x040248DB RID: 149723
		private List<int> InFormationRoleList;

		// Token: 0x040248DC RID: 149724
		private bool IsTrailLevel;

		// Token: 0x040248DD RID: 149725
		private int CurrentLeadRole;

		// Token: 0x0200C658 RID: 50776
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403D0E3 RID: 250083
			FormationItem1,
			// Token: 0x0403D0E4 RID: 250084
			FormationItem2,
			// Token: 0x0403D0E5 RID: 250085
			FormationItem3,
			// Token: 0x0403D0E6 RID: 250086
			StartBtn,
			// Token: 0x0403D0E7 RID: 250087
			LowLevelTipsItem,
			// Token: 0x0403D0E8 RID: 250088
			LowLevelTipsText,
			// Token: 0x0403D0E9 RID: 250089
			LeaderSkillBtn,
			// Token: 0x0403D0EA RID: 250090
			LeaderHeadTexture,
			// Token: 0x0403D0EB RID: 250091
			LeaderHeadTipsItem,
			// Token: 0x0403D0EC RID: 250092
			LeaderHeadTipsMaskBtn,
			// Token: 0x0403D0ED RID: 250093
			LeaderHeadTipsNameText,
			// Token: 0x0403D0EE RID: 250094
			LeaderHeadTipsDesText,
			// Token: 0x0403D0EF RID: 250095
			LevelNameText,
			// Token: 0x0403D0F0 RID: 250096
			LevelIconSprite,
			// Token: 0x0403D0F1 RID: 250097
			CaptionItem,
			// Token: 0x0403D0F2 RID: 250098
			MonsterBtn,
			// Token: 0x0403D0F3 RID: 250099
			WarnClassTipsItem
		}
	}
}
