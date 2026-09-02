using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BossPiling.View
{
	// Token: 0x02005EFA RID: 24314
	[NullableContext(1)]
	[Nullable(0)]
	public class BossPilingSettleView : UiViewBase
	{
		// Token: 0x0603D151 RID: 250193 RVA: 0x00F83422 File Offset: 0x00F81622
		public BossPilingSettleView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603D152 RID: 250194 RVA: 0x00F8344C File Offset: 0x00F8164C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D153 RID: 250195 RVA: 0x00F8355C File Offset: 0x00F8175C
		protected override UniTask OnBeforeStartAsync()
		{
			BossPilingSettleView.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BossPilingSettleView.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D154 RID: 250196 RVA: 0x00F8359F File Offset: 0x00F8179F
		protected override void OnBeforeShow()
		{
			this.RefreshTitle();
			this.CurTeam = ControllerBase<BossPilingController>.Instance.CurTeamRole;
			this.CurTag = ControllerBase<BossPilingController>.Instance.CurTeamTag;
		}

		// Token: 0x0603D155 RID: 250197 RVA: 0x00F835C8 File Offset: 0x00F817C8
		private UniTask NewStateToggle()
		{
			BossPilingSettleView.<NewStateToggle>d__17 <NewStateToggle>d__;
			<NewStateToggle>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewStateToggle>d__.<>4__this = this;
			<NewStateToggle>d__.<>1__state = -1;
			<NewStateToggle>d__.<>t__builder.Start<BossPilingSettleView.<NewStateToggle>d__17>(ref <NewStateToggle>d__);
			return <NewStateToggle>d__.<>t__builder.Task;
		}

		// Token: 0x0603D156 RID: 250198 RVA: 0x00F8360C File Offset: 0x00F8180C
		private UniTask InitButtonAsync()
		{
			BossPilingSettleView.<InitButtonAsync>d__18 <InitButtonAsync>d__;
			<InitButtonAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitButtonAsync>d__.<>4__this = this;
			<InitButtonAsync>d__.<>1__state = -1;
			<InitButtonAsync>d__.<>t__builder.Start<BossPilingSettleView.<InitButtonAsync>d__18>(ref <InitButtonAsync>d__);
			return <InitButtonAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D157 RID: 250199 RVA: 0x00F83650 File Offset: 0x00F81850
		private UniTask CreateButton(int buttonIndex, Action clickFunction)
		{
			BossPilingSettleView.<CreateButton>d__19 <CreateButton>d__;
			<CreateButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateButton>d__.<>4__this = this;
			<CreateButton>d__.buttonIndex = buttonIndex;
			<CreateButton>d__.clickFunction = clickFunction;
			<CreateButton>d__.<>1__state = -1;
			<CreateButton>d__.<>t__builder.Start<BossPilingSettleView.<CreateButton>d__19>(ref <CreateButton>d__);
			return <CreateButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603D158 RID: 250200 RVA: 0x00F836A4 File Offset: 0x00F818A4
		private UniTask InitLevelPanelAsync()
		{
			BossPilingSettleView.<InitLevelPanelAsync>d__20 <InitLevelPanelAsync>d__;
			<InitLevelPanelAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitLevelPanelAsync>d__.<>4__this = this;
			<InitLevelPanelAsync>d__.<>1__state = -1;
			<InitLevelPanelAsync>d__.<>t__builder.Start<BossPilingSettleView.<InitLevelPanelAsync>d__20>(ref <InitLevelPanelAsync>d__);
			return <InitLevelPanelAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D159 RID: 250201 RVA: 0x00F836E8 File Offset: 0x00F818E8
		private void RefreshTitle()
		{
			UUIText text = base.GetText(1);
			UUIEffectOutline uuieffectOutline = text.GetOwner().GetComponentByClass(UUIEffectOutline.StaticClass()) as UUIEffectOutline;
			string hexStr = this.IsSuccess ? "C48B29FF" : "B33100FF";
			string key = this.IsSuccess ? "BossPilingActivity_Dungeon13" : "BossPilingActivity_Dungeon09";
			string hexStr2 = this.IsSuccess ? "8C754D7F" : "6e363f";
			string hexStr3 = this.IsSuccess ? "f2efd5" : "F08086FF";
			string sequenceName = this.IsSuccess ? "Success" : "Fail";
			text.SetColor(FColor.FromHex(hexStr));
			text.ShowTextNew(key);
			text.outlineColor = FColor.FromHex(hexStr);
			base.GetTexture(2).SetColor(FColor.FromHex(hexStr2));
			uuieffectOutline.SetOutlineColor(FColor.FromHex(hexStr));
			text.SetColor(FColor.FromHex(hexStr3));
			base.PlaySequence(sequenceName, null, false);
		}

		// Token: 0x0603D15A RID: 250202 RVA: 0x00F837D8 File Offset: 0x00F819D8
		private MultiTeamRoleSelectData GetSelectViewData()
		{
			RoleInstance[] roleList = ModelBase<RoleModel>.Instance.GetRoleList();
			List<MultiTeamRoleGridData> list = new List<MultiTeamRoleGridData>();
			BossPilingLevels value = ConfigBase<BossPilingConfig>.Instance.GetLevelInfo(this.LevelId).Value;
			int fightFormationId = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(value.InstIds()[0]).Value.FightFormationId;
			FightFormation value2 = ConfigBase<EditBattleTeamConfig>.Instance.GetFightFormationConfig(fightFormationId).Value;
			foreach (RoleInstance roleInstance in roleList)
			{
				if (roleInstance.GetRoleId() != 0)
				{
					MultiTeamRoleGridData item = MultiTeamRoleGridData.Phrase(roleInstance, false, value2.RecommendFormation().Contains(roleInstance.GetRoleId()), false, false);
					list.Add(item);
				}
			}
			EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
			IEnumerable<MainRoleConfig> mainRoleByGender = ConfigBase<RoleConfig>.Instance.GetMainRoleByGender((playerGender == EPlayerGender.Male) ? LoginDefine.ELoginSex.Boy : LoginDefine.ELoginSex.Girl);
			List<int> list2 = new List<int>();
			foreach (MainRoleConfig mainRoleConfig in mainRoleByGender)
			{
				list2.Add(mainRoleConfig.Id);
			}
			List<MultiTeamRoleGridData> list3 = new List<MultiTeamRoleGridData>();
			foreach (int id in value2.TrialRoleIter())
			{
				TrialRoleInfo value3 = ConfigBase<RoleConfig>.Instance.GetTrialRoleConfigByGroupId(id).Value;
				if (!ModelBase<RoleModel>.Instance.IsMainRole(value3.ParentId) || list2.Contains(value3.ParentId))
				{
					RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(value3.Id, true);
					if (roleDataById != null)
					{
						list3.Add(MultiTeamRoleGridData.Phrase(roleDataById, false, false, false, false));
					}
				}
			}
			MultiTeamRoleData item2 = MultiTeamRoleData.Phrase("BossRushNormalRole", list);
			List<MultiTeamRoleData> list4 = new List<MultiTeamRoleData>();
			if (list3.Count > 0)
			{
				MultiTeamRoleData item3 = MultiTeamRoleData.Phrase("BossRushTrailRole", list3);
				list4.Add(item3);
			}
			list4.Add(item2);
			MultiTeamRoleSelectData multiTeamRoleSelectData = MultiTeamRoleSelectData.Phrase(new EFilterSortGroupId?(EFilterSortGroupId.EditFormation), 3, this.CurTeam.ToArray(), null, null, delegate(int[] idList, int[] tagConfigId)
			{
				for (int j = 0; j < idList.Length; j++)
				{
					int value4 = idList[j];
					this.CurTeam[j] = value4;
					this.CurTag[j] = tagConfigId[j];
				}
				ControllerBase<BossPilingController>.Instance.RequestChallenge(this.LevelId, idList.ToList<int>(), tagConfigId.ToList<int>(), false);
			}, null, list4, null, "");
			multiTeamRoleSelectData.IfCanSelectCheck = new Func<int, int[], bool>(this.IfCanSelectCheck);
			MultiTeamTagDataItem multiTeamTagData = MultiTeamTagDataItem.Phrase(this.CurTag.ToArray(), ESkillBranchCacheType.BossPiling);
			multiTeamRoleSelectData.SetMultiTeamTagData(multiTeamTagData);
			return multiTeamRoleSelectData;
		}

		// Token: 0x0603D15B RID: 250203 RVA: 0x00F83A44 File Offset: 0x00F81C44
		private bool IfCanSelectCheck(int roleConfigId, int[] selectedRoleList)
		{
			RoleConfig instance = ConfigBase<RoleConfig>.Instance;
			int? num = (instance != null) ? new int?(instance.GetBaseRoleId(roleConfigId)) : null;
			foreach (int num2 in selectedRoleList)
			{
				if (num2 != 0)
				{
					RoleConfig instance2 = ConfigBase<RoleConfig>.Instance;
					int? num3 = (instance2 != null) ? new int?(instance2.GetBaseRoleId(num2)) : null;
					int? num4 = num;
					if ((num3.GetValueOrDefault() == num4.GetValueOrDefault() & num3 != null == (num4 != null)) && roleConfigId != num2)
					{
						ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("BossRushSameFormation", Array.Empty<object>());
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x0603D15C RID: 250204 RVA: 0x00F83AED File Offset: 0x00F81CED
		private void OnClickedLeft()
		{
			if (!this.IsSuccess)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.BossPilingMainView, null, null);
				return;
			}
			ControllerBase<InstanceDungeonController>.Instance.SingleInstReChallengeRequest();
		}

		// Token: 0x0603D15D RID: 250205 RVA: 0x00F83B14 File Offset: 0x00F81D14
		private void OnClickedRight()
		{
			if (this.IsSuccess)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.BossPilingMainView, null, null);
				return;
			}
			EToggleState? toggleState = this.RewardExploreToggle.GetToggleState();
			EToggleState etoggleState = EToggleState.ETT_Checked;
			if (toggleState.GetValueOrDefault() == etoggleState & toggleState != null)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.MultiTeamRoleSelectView, this.GetSelectViewData(), null);
				return;
			}
			ControllerBase<BossPilingController>.Instance.RequestChallenge(this.LevelId, this.CurTeam, this.CurTag, false);
		}

		// Token: 0x0402242F RID: 140335
		private const string SUCCESS_OUTLINE_COLOR = "C48B29FF";

		// Token: 0x04022430 RID: 140336
		private const string SUCCESS_TEXT_COLOR = "f2efd5";

		// Token: 0x04022431 RID: 140337
		private const string FAIL_OUTLINE_COLOR = "B33100FF";

		// Token: 0x04022432 RID: 140338
		private const string FAIL_TEXT_COLOR = "F08086FF";

		// Token: 0x04022433 RID: 140339
		protected Dictionary<int, BossPilingSettleButton> ButtonMap = new Dictionary<int, BossPilingSettleButton>();

		// Token: 0x04022434 RID: 140340
		[Nullable(2)]
		protected BossPilingSettlePanel LevelPanel;

		// Token: 0x04022435 RID: 140341
		protected bool IsSuccess;

		// Token: 0x04022436 RID: 140342
		protected int LevelId;

		// Token: 0x04022437 RID: 140343
		protected List<int> CurTeam = new List<int>();

		// Token: 0x04022438 RID: 140344
		protected List<int> CurTag = new List<int>();

		// Token: 0x04022439 RID: 140345
		private RewardExploreToggle RewardExploreToggle;

		// Token: 0x0200BEF4 RID: 48884
		[NullableContext(0)]
		private enum EButtons
		{
			// Token: 0x0403AC52 RID: 240722
			LeftButton,
			// Token: 0x0403AC53 RID: 240723
			RightButton
		}

		// Token: 0x0200BEF5 RID: 48885
		[NullableContext(0)]
		private enum EDefine
		{
			// Token: 0x0403AC55 RID: 240725
			TitleItem,
			// Token: 0x0403AC56 RID: 240726
			TitleText,
			// Token: 0x0403AC57 RID: 240727
			TitleTexture,
			// Token: 0x0403AC58 RID: 240728
			ButtonHorizontalItem = 4,
			// Token: 0x0403AC59 RID: 240729
			ButtonItem,
			// Token: 0x0403AC5A RID: 240730
			ToggleItem,
			// Token: 0x0403AC5B RID: 240731
			ContentItem = 20
		}
	}
}
