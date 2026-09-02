using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020028C2 RID: 10434
public class RoleSkillInputPanel : UiPanelBase
{
	// Token: 0x06014B33 RID: 84787 RVA: 0x005BB4A0 File Offset: 0x005B96A0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 14;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(9, new Action(this.OnClickTrailBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06014B34 RID: 84788 RVA: 0x005BB6D9 File Offset: 0x005B98D9
	protected override void OnStart()
	{
		this.FeatureDescLayout = new GenericLayout<RoleSkillInputDescItem, string>(base.GetVerticalLayout(1), new Func<RoleSkillInputDescItem>(this.InitSkillDescItem), null, false, true);
		this.BaseEmptyHeight = base.GetItem(13).Height;
	}

	// Token: 0x06014B35 RID: 84789 RVA: 0x005BB70F File Offset: 0x005B990F
	[NullableContext(1)]
	private RoleSkillInputDescItem InitSkillDescItem()
	{
		return new RoleSkillInputDescItem();
	}

	// Token: 0x06014B36 RID: 84790 RVA: 0x005BB718 File Offset: 0x005B9918
	private void OnClickTrailBtn()
	{
		if (ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("RoleGuideNotice01", Array.Empty<object>());
			return;
		}
		if (ControllerBase<FormationDataController>.Instance.GlobalIsInFight)
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("RoleGuideNotice06", Array.Empty<object>());
			return;
		}
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("RoleGuideNotice05", Array.Empty<object>());
			return;
		}
		RoleInfo value = ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.RoleId).Value;
		string roleName = ConfigBase<RoleConfig>.Instance.GetRoleName(value.Name);
		int dungeonId = value.RoleGuide;
		if (dungeonId == 0)
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("RoleGuideNotice02", new object[]
			{
				roleName
			});
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RoleTeachTip);
		confirmBoxDataNew.SetTextArgs(new string[]
		{
			roleName
		});
		confirmBoxDataNew.FunctionMap.Add(2, delegate
		{
			int fightFormationId = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(dungeonId).Value.FightFormationId;
			Aki.Config.FightFormation? fightFormation;
			int[] array = (ConfigBase<EditBattleTeamConfig>.Instance.GetFightFormationConfig(fightFormationId) != null) ? fightFormation.GetValueOrDefault().AutoRole() : null;
			if (((array != null) ? array.Length : 0) > 0)
			{
				List<int> list = new List<int>();
				foreach (int id in array)
				{
					list.Add(ConfigBase<RoleConfig>.Instance.GetTrialRoleIdConfigByGroupId(id));
				}
				RoleTeachEnterCtx roleTeachEnterCtx = RoleTeachEnterCtx.Create();
				roleTeachEnterCtx.RoleId = this.RoleId;
				ModelBase<InstanceDungeonModel>.Instance.InstanceEnterContentText.RoleTeachCtx = roleTeachEnterCtx;
				ControllerBase<InstanceDungeonController>.Instance.PrewarTeamFightRequest(dungeonId, list, 0, 0, null, null).Forget<bool>();
				return;
			}
			Singleton<Log>.Instance.Error(ELogModule.Role, ELogAuthor.LZK, "未配置出战人物", default(ReadOnlySpan<ValueTuple<string, object>>));
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06014B37 RID: 84791 RVA: 0x005BB82C File Offset: 0x005B9A2C
	public void Refresh(int roleId, bool isTrial, bool showSkipButton = false)
	{
		RoleSkillInputPanel.<>c__DisplayClass9_0 CS$<>8__locals1 = new RoleSkillInputPanel.<>c__DisplayClass9_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.roleId = roleId;
		CS$<>8__locals1.isTrial = isTrial;
		CS$<>8__locals1.showSkipButton = showSkipButton;
		UiAsyncTask task = new UiAsyncTask("Refresh", delegate()
		{
			RoleSkillInputPanel.<>c__DisplayClass9_0.<<Refresh>b__0>d <<Refresh>b__0>d;
			<<Refresh>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<Refresh>b__0>d.<>4__this = CS$<>8__locals1;
			<<Refresh>b__0>d.<>1__state = -1;
			<<Refresh>b__0>d.<>t__builder.Start<RoleSkillInputPanel.<>c__DisplayClass9_0.<<Refresh>b__0>d>(ref <<Refresh>b__0>d);
			return <<Refresh>b__0>d.<>t__builder.Task;
		}, null);
		base.RunAsyncTask(task);
	}

	// Token: 0x06014B38 RID: 84792 RVA: 0x005BB87C File Offset: 0x005B9A7C
	public UniTask RefreshUiAsync(int roleId, bool isTrial, bool showSkipButton = false)
	{
		RoleSkillInputPanel.<RefreshUiAsync>d__10 <RefreshUiAsync>d__;
		<RefreshUiAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshUiAsync>d__.<>4__this = this;
		<RefreshUiAsync>d__.roleId = roleId;
		<RefreshUiAsync>d__.isTrial = isTrial;
		<RefreshUiAsync>d__.showSkipButton = showSkipButton;
		<RefreshUiAsync>d__.<>1__state = -1;
		<RefreshUiAsync>d__.<>t__builder.Start<RoleSkillInputPanel.<RefreshUiAsync>d__10>(ref <RefreshUiAsync>d__);
		return <RefreshUiAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06014B39 RID: 84793 RVA: 0x005BB8D7 File Offset: 0x005B9AD7
	public void SetFeatureActive(bool isShow)
	{
		base.GetItem(0).SetUIActive(isShow);
		base.GetItem(10).SetUIActive(isShow);
	}

	// Token: 0x06014B3A RID: 84794 RVA: 0x005BB8F4 File Offset: 0x005B9AF4
	public void SetTrickActive(bool isShow)
	{
		base.GetItem(12).SetUIActive(isShow);
		base.GetVerticalLayout(2).RootUIComp.Get().SetUIActive(isShow);
	}

	// Token: 0x06014B3B RID: 84795 RVA: 0x005BB929 File Offset: 0x005B9B29
	public void SetEmptyActive(bool isShow)
	{
		if (isShow)
		{
			this.FeatureDescLayout.BindLateUpdate(delegate(float _)
			{
				float height = base.GetRootItem().Height;
				float height2 = base.GetItem(0).Height;
				float height3 = base.GetVerticalLayout(1).RootUIComp.Get().Height;
				float num = height - height2 - height3;
				if (num < this.BaseEmptyHeight)
				{
					base.GetItem(13).SetUIActive(false);
					return;
				}
				base.GetItem(13).SetHeight(num);
				this.FeatureDescLayout.UnBindLateUpdate();
			});
		}
		base.GetItem(13).SetUIActive(isShow);
	}

	// Token: 0x04009F9D RID: 40861
	private int RoleId;

	// Token: 0x04009F9E RID: 40862
	private float BaseEmptyHeight;

	// Token: 0x04009F9F RID: 40863
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<RoleSkillInputDescItem, string> FeatureDescLayout;

	// Token: 0x04009FA0 RID: 40864
	private bool HasRefresh;

	// Token: 0x02008C07 RID: 35847
	private enum EComponent
	{
		// Token: 0x0402F2AC RID: 193196
		FeatureTitleItem,
		// Token: 0x0402F2AD RID: 193197
		FeatureDescLayout,
		// Token: 0x0402F2AE RID: 193198
		TrickLayout,
		// Token: 0x0402F2AF RID: 193199
		TrickSmallTitleItem,
		// Token: 0x0402F2B0 RID: 193200
		TrickSkillTexItem,
		// Token: 0x0402F2B1 RID: 193201
		TrickSkillDescItem,
		// Token: 0x0402F2B2 RID: 193202
		TrickSkillInputItem,
		// Token: 0x0402F2B3 RID: 193203
		TrickLineItem,
		// Token: 0x0402F2B4 RID: 193204
		TrailItem,
		// Token: 0x0402F2B5 RID: 193205
		TrailBtn,
		// Token: 0x0402F2B6 RID: 193206
		FeatureDescItem,
		// Token: 0x0402F2B7 RID: 193207
		TrickItem,
		// Token: 0x0402F2B8 RID: 193208
		TrickTitleItem,
		// Token: 0x0402F2B9 RID: 193209
		EmptyItem
	}
}
