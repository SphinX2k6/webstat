using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001ACC RID: 6860
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class AbyssDangoItem : GridProxyAbstract<AbyssDangoItemData>
{
	// Token: 0x0600C57A RID: 50554 RVA: 0x00342924 File Offset: 0x00340B24
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(6, new Action<EToggleState>(this.OnSelectToggleClick))
		};
	}

	// Token: 0x0600C57B RID: 50555 RVA: 0x00342A28 File Offset: 0x00340C28
	protected override UniTask OnBeforeStartAsync()
	{
		AbyssDangoItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<AbyssDangoItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C57C RID: 50556 RVA: 0x00342A63 File Offset: 0x00340C63
	private void OnSelectToggleClick(EToggleState toggleState)
	{
		this.CurrentData.OnSelectCallBack(this.CurrentData);
	}

	// Token: 0x0600C57D RID: 50557 RVA: 0x00342A7B File Offset: 0x00340C7B
	protected override void OnBeforeDestroy()
	{
		if (this.RedDotBindState)
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RedDotDangoFormationRole, base.GetItem(8), 0);
		}
	}

	// Token: 0x0600C57E RID: 50558 RVA: 0x00342A9C File Offset: 0x00340C9C
	public override void Refresh(AbyssDangoItemData data, bool isSelected, int gridIndex)
	{
		this.CurrentData = data;
		this.RefreshBelongTexture(data);
		this.RefreshLevelText(data);
		this.RefreshAvatarTexture(data);
		this.RefreshQualitySprite(data);
		this.RefreshToggleState(data);
		this.RefreshLockItem(data);
		this.RefreshLikeItem(data);
		int playerId = data.PlayerId;
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		if (playerId == id.GetValueOrDefault() & id != null)
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RedDotDangoFormationRole, base.GetItem(8), null, data.DangoId);
			this.RedDotBindState = true;
		}
	}

	// Token: 0x0600C57F RID: 50559 RVA: 0x00342B2C File Offset: 0x00340D2C
	private void RefreshLikeItem(AbyssDangoItemData data)
	{
		InstanceDungeon? getCurrentDungeonConfig = ModelBase<EditBattleTeamModel>.Instance.GetCurrentDungeonConfig;
		DangoAbyssActivityData currentOpenAbyssActivityData = ModelBase<DangoAbyssModel>.Instance.GetCurrentOpenAbyssActivityData();
		if (getCurrentDungeonConfig == null || currentOpenAbyssActivityData == null)
		{
			return;
		}
		AbyssChallengeData[] abyssChallengeDataList = currentOpenAbyssActivityData.GetAbyssChallengeDataList();
		int i = 0;
		while (i < abyssChallengeDataList.Length)
		{
			AbyssInst? config = abyssChallengeDataList[i].GetConfig();
			int? num = (config != null) ? new int?(config.GetValueOrDefault().InstId) : null;
			int id = getCurrentDungeonConfig.Value.Id;
			if (num.GetValueOrDefault() == id & num != null)
			{
				bool uiactive = config.Value.RecommendLittleRole().Contains(data.DangoId);
				UUIItem item = base.GetItem(7);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(uiactive);
				return;
			}
			else
			{
				i++;
			}
		}
		UUIItem item2 = base.GetItem(7);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(false);
	}

	// Token: 0x0600C580 RID: 50560 RVA: 0x00342C18 File Offset: 0x00340E18
	private void RefreshToggleState(AbyssDangoItemData data)
	{
		EToggleState state = data.SelectState ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		UUIExtendToggle extendToggle = base.GetExtendToggle(6);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(state, false, false, false);
	}

	// Token: 0x0600C581 RID: 50561 RVA: 0x00342C48 File Offset: 0x00340E48
	private void RefreshQualitySprite(AbyssDangoItemData data)
	{
		this.RefreshQualitySpriteAsync(data);
	}

	// Token: 0x0600C582 RID: 50562 RVA: 0x00342C54 File Offset: 0x00340E54
	private void RefreshQualitySpriteAsync(AbyssDangoItemData data)
	{
		AbyssDangoItem.<>c__DisplayClass13_0 CS$<>8__locals1 = new AbyssDangoItem.<>c__DisplayClass13_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.data = data;
		UiAsyncTask task = new UiAsyncTask("RefreshQualitySpriteAsync", delegate()
		{
			AbyssDangoItem.<>c__DisplayClass13_0.<<RefreshQualitySpriteAsync>b__0>d <<RefreshQualitySpriteAsync>b__0>d;
			<<RefreshQualitySpriteAsync>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<RefreshQualitySpriteAsync>b__0>d.<>4__this = CS$<>8__locals1;
			<<RefreshQualitySpriteAsync>b__0>d.<>1__state = -1;
			<<RefreshQualitySpriteAsync>b__0>d.<>t__builder.Start<AbyssDangoItem.<>c__DisplayClass13_0.<<RefreshQualitySpriteAsync>b__0>d>(ref <<RefreshQualitySpriteAsync>b__0>d);
			return <<RefreshQualitySpriteAsync>b__0>d.<>t__builder.Task;
		}, null);
		base.RunAsyncTask(task);
	}

	// Token: 0x0600C583 RID: 50563 RVA: 0x00342C98 File Offset: 0x00340E98
	private void RefreshAvatarTexture(AbyssDangoItemData data)
	{
		string formationIcon = ModelBase<DangoAbyssModel>.Instance.GetDangoAbyssRoleData(data.DangoId).GetFormationIcon();
		base.SetTextureByPath(formationIcon, base.GetTexture(1), null, null);
	}

	// Token: 0x0600C584 RID: 50564 RVA: 0x00342CD4 File Offset: 0x00340ED4
	private void RefreshLevelText(AbyssDangoItemData data)
	{
		AbyssDangoRoleData dangoAbyssRoleData = ModelBase<DangoAbyssModel>.Instance.GetDangoAbyssRoleData(data.DangoId);
		int level = dangoAbyssRoleData.GetLevel();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "AbyssDango_LV", new <>z__ReadOnlySingleElementList<object>(level.ToString()));
		UUIItem item = base.GetItem(3);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(!dangoAbyssRoleData.GetIfLock());
	}

	// Token: 0x0600C585 RID: 50565 RVA: 0x00342D38 File Offset: 0x00340F38
	private void RefreshBelongTexture(AbyssDangoItemData data)
	{
		int playerId = data.PlayerId;
		if ((playerId == 0 || ModelBase<DangoAbyssModel>.Instance.CheckIsSelf(playerId)) && data.RoleId != 0)
		{
			UUITexture texture = base.GetTexture(2);
			if (texture != null)
			{
				texture.SetUIActive(true);
			}
			base.SetRoleIcon(ConfigBase<RoleConfig>.Instance.GetRoleConfig(data.RoleId).Value.RoleHeadIconCircle, base.GetTexture(2), data.RoleId, null, null);
			return;
		}
		UUITexture texture2 = base.GetTexture(2);
		if (texture2 == null)
		{
			return;
		}
		texture2.SetUIActive(false);
	}

	// Token: 0x0600C586 RID: 50566 RVA: 0x00342DC8 File Offset: 0x00340FC8
	private void RefreshLockItem(AbyssDangoItemData data)
	{
		bool ifLock = ModelBase<DangoAbyssModel>.Instance.GetDangoAbyssRoleData(data.DangoId).GetIfLock();
		UUIItem item = base.GetItem(5);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(ifLock);
	}

	// Token: 0x04005EAA RID: 24234
	private AbyssDangoItemData CurrentData = new AbyssDangoItemData();

	// Token: 0x04005EAB RID: 24235
	[Nullable(2)]
	private AbyssDangoCircleQualityItem DangoCircleQualityItem;

	// Token: 0x04005EAC RID: 24236
	[Nullable(2)]
	private CustomPromise QualityItemPromise;

	// Token: 0x04005EAD RID: 24237
	private bool RedDotBindState;

	// Token: 0x02007D9E RID: 32158
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402AC91 RID: 175249
		QualityItem,
		// Token: 0x0402AC92 RID: 175250
		AvatarTexture,
		// Token: 0x0402AC93 RID: 175251
		BelongTexture,
		// Token: 0x0402AC94 RID: 175252
		AddCountItem,
		// Token: 0x0402AC95 RID: 175253
		LevelText,
		// Token: 0x0402AC96 RID: 175254
		LockItem,
		// Token: 0x0402AC97 RID: 175255
		SelectToggle,
		// Token: 0x0402AC98 RID: 175256
		LikeItem,
		// Token: 0x0402AC99 RID: 175257
		RedDot
	}
}
