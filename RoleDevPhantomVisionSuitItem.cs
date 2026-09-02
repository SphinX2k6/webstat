using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.RoleDev;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002816 RID: 10262
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RoleDevPhantomVisionSuitItem : GridProxyAbstract<RoleDevPhantomVisionSuitItemData>
{
	// Token: 0x06014414 RID: 82964 RVA: 0x005A3668 File Offset: 0x005A1868
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUISprite)),
			new ValueTuple<int, Type>(5, typeof(UUITexture))
		};
	}

	// Token: 0x06014415 RID: 82965 RVA: 0x005A3704 File Offset: 0x005A1904
	protected override UniTask OnBeforeStartAsync()
	{
		RoleDevPhantomVisionSuitItem.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RoleDevPhantomVisionSuitItem.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06014416 RID: 82966 RVA: 0x005A3747 File Offset: 0x005A1947
	private void InitDetailVerticalLayout()
	{
		this.DetailVerticalLayout = new GenericLayout<RoleDevPhantomVisionSuitDisplayItem, IRoleDevPhantomSuitDisplayItemData>(base.GetHorizontalLayout(1), () => new RoleDevPhantomVisionSuitDisplayItem(), null, false, true);
	}

	// Token: 0x06014417 RID: 82967 RVA: 0x005A3780 File Offset: 0x005A1980
	private UniTask InitButtonConfirm()
	{
		RoleDevPhantomVisionSuitItem.<InitButtonConfirm>d__7 <InitButtonConfirm>d__;
		<InitButtonConfirm>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitButtonConfirm>d__.<>4__this = this;
		<InitButtonConfirm>d__.<>1__state = -1;
		<InitButtonConfirm>d__.<>t__builder.Start<RoleDevPhantomVisionSuitItem.<InitButtonConfirm>d__7>(ref <InitButtonConfirm>d__);
		return <InitButtonConfirm>d__.<>t__builder.Task;
	}

	// Token: 0x06014418 RID: 82968 RVA: 0x005A37C4 File Offset: 0x005A19C4
	public override void Refresh(RoleDevPhantomVisionSuitItemData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		this.ButtonConfirm.SetFunction(new Action<int>(this.OnClickConfirm));
		this.ButtonConfirm.SetLocalTextNew(this.Data.ButtonName, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.Name, Array.Empty<object>());
		if (data.ItemType == EVisionSuitItemType.Dungeon)
		{
			base.GetSprite(4).SetUIActive(false);
			base.GetTexture(5).SetUIActive(true);
			base.SetTextureByPath(data.TypeIcon, base.GetTexture(5), null, null);
		}
		else if (data.ItemType == EVisionSuitItemType.Phantom)
		{
			base.GetSprite(4).SetUIActive(true);
			base.GetTexture(5).SetUIActive(false);
		}
		this.RefreshDisplayContent(data);
	}

	// Token: 0x06014419 RID: 82969 RVA: 0x005A3894 File Offset: 0x005A1A94
	private void RefreshDisplayContent(RoleDevPhantomVisionSuitItemData data)
	{
		List<IRoleDevPhantomSuitDisplayItemData> list = new List<IRoleDevPhantomSuitDisplayItemData>();
		if (data.MonsterDataList != null && data.MonsterDataList.Count > 0)
		{
			foreach (global::IPhantomMonsterItemData monsterData in data.MonsterDataList)
			{
				list.Add(new RoleDevPhantomSuitDisplayItemData
				{
					MonsterData = monsterData
				});
			}
		}
		if (data.RewardDataList != null && data.RewardDataList.Count > 0)
		{
			foreach (global::IDropRewardItemData rewardData in data.RewardDataList)
			{
				list.Add(new RoleDevPhantomSuitDisplayItemData
				{
					RewardData = rewardData
				});
			}
		}
		GenericLayout<RoleDevPhantomVisionSuitDisplayItem, IRoleDevPhantomSuitDisplayItemData> detailVerticalLayout = this.DetailVerticalLayout;
		if (detailVerticalLayout == null)
		{
			return;
		}
		detailVerticalLayout.RefreshByData(list, null, false);
	}

	// Token: 0x0601441A RID: 82970 RVA: 0x005A3988 File Offset: 0x005A1B88
	private void OnClickConfirm(int _)
	{
		if (this.Data == null)
		{
			return;
		}
		if (this.Data.DungeonId > 0)
		{
			this.HandleDungeonJump(this.Data.DungeonId);
			ControllerBase<RoleDevController>.Instance.LogRoleDevSubPageClick(this.Data.RoleId, ERoleDevMainPage.Phantom, ERoleDevSubPageButton.NoSoundZoneGo);
			return;
		}
		if (this.Data.FetterGroupId > 0)
		{
			ControllerBase<RoleDevController>.Instance.LogRoleDevSubPageClick(this.Data.RoleId, ERoleDevMainPage.Phantom, ERoleDevSubPageButton.Cost4Go);
			this.HandleOpenFettersView(this.Data.FetterGroupId, this.Data.RoleId, this.Data.RecommendGroupIds);
		}
	}

	// Token: 0x0601441B RID: 82971 RVA: 0x005A3A24 File Offset: 0x005A1C24
	private void HandleDungeonJump(int dungeonId)
	{
		if (ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("DungeonDetection", Array.Empty<object>());
			return;
		}
		SilentAreaDetectionRecord silentAreaDetectData = ModelBase<AdventureGuideModel>.Instance.GetSilentAreaDetectData(dungeonId);
		if (silentAreaDetectData == null)
		{
			return;
		}
		if (!ControllerBase<AdventureGuideController>.Instance.IsMarkUnlock(silentAreaDetectData.Conf.MarkId))
		{
			return;
		}
		ModelBase<AdventureGuideModel>.Instance.SetFromManualDetect(true);
		ControllerBase<AdventureGuideController>.Instance.RequestForDetection(DetectionType.SilentArea, silentAreaDetectData.Conf.LevelPlayList(), dungeonId);
	}

	// Token: 0x0601441C RID: 82972 RVA: 0x005A3AA4 File Offset: 0x005A1CA4
	private void HandleOpenFettersView(int fetterGroupId, int roleId, List<int> recommendGroupIds)
	{
		bool flag = ModelBase<RoleModel>.Instance.IsRoleOwned(roleId);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomBattleFettersView, new object[]
		{
			fetterGroupId,
			roleId,
			flag,
			recommendGroupIds
		}, null);
	}

	// Token: 0x04009D95 RID: 40341
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<RoleDevPhantomVisionSuitDisplayItem, IRoleDevPhantomSuitDisplayItemData> DetailVerticalLayout;

	// Token: 0x04009D96 RID: 40342
	[Nullable(2)]
	private RoleDevPhantomVisionSuitItemData Data;

	// Token: 0x04009D97 RID: 40343
	[Nullable(2)]
	private ButtonItem ButtonConfirm;

	// Token: 0x02008BA2 RID: 35746
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402F0ED RID: 192749
		TxtName,
		// Token: 0x0402F0EE RID: 192750
		PanelDetailLayout,
		// Token: 0x0402F0EF RID: 192751
		ItemBase,
		// Token: 0x0402F0F0 RID: 192752
		BtnConfirm,
		// Token: 0x0402F0F1 RID: 192753
		IconSprite,
		// Token: 0x0402F0F2 RID: 192754
		IconTexture
	}
}
