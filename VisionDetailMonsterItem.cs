using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using UnrealEngine;

// Token: 0x0200248F RID: 9359
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class VisionDetailMonsterItem : LoopScrollSmallItemGrid<VisionDetailMonsterItemData>
{
	// Token: 0x0601229C RID: 74396 RVA: 0x004FEF36 File Offset: 0x004FD136
	protected override void OnStart()
	{
		base.BindOnExtendToggleClicked(new Action<MediumItemGridExtendCallback>(this.OnClickEvent));
		base.SetUseFixedAsync(true);
	}

	// Token: 0x0601229D RID: 74397 RVA: 0x004FEF51 File Offset: 0x004FD151
	private void OnClickEvent(MediumItemGridExtendCallback data)
	{
	}

	// Token: 0x0601229E RID: 74398 RVA: 0x004FEF53 File Offset: 0x004FD153
	protected override void OnExtendToggleClicked()
	{
		this.ClickButton();
	}

	// Token: 0x0601229F RID: 74399 RVA: 0x004FEF5B File Offset: 0x004FD15B
	protected override void OnExtendToggleStateChanged(EToggleState state)
	{
		this.SetSelected(false, false);
	}

	// Token: 0x060122A0 RID: 74400 RVA: 0x004FEF65 File Offset: 0x004FD165
	private void ClickButton()
	{
		ControllerBase<AdventureGuideController>.Instance.TryJumpToTargetViewByMonsterId(this.MonsterId, null);
	}

	// Token: 0x060122A1 RID: 74401 RVA: 0x004FEF78 File Offset: 0x004FD178
	protected override void OnRefresh(VisionDetailMonsterItemData data, bool isSelected, int gridIndex)
	{
		this.Refresh(data, isSelected, gridIndex);
	}

	// Token: 0x060122A2 RID: 74402 RVA: 0x004FEF84 File Offset: 0x004FD184
	public override void Refresh(VisionDetailMonsterItemData data, bool isSelected, int gridIndex)
	{
		this.MonsterId = data.MonsterId;
		HandBookEntry handBookInfo = ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Phantom, this.MonsterId);
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(data.RoleId);
		Dictionary<int, PhantomDataBase> dictionary;
		if (roleInstanceById == null)
		{
			dictionary = null;
		}
		else
		{
			RolePhantomData phantomData = roleInstanceById.GetPhantomData();
			dictionary = ((phantomData != null) ? phantomData.GetDataMap() : null);
		}
		Dictionary<int, PhantomDataBase> dictionary2 = dictionary;
		int? visionRoleHeadInfo = new int?(0);
		if (dictionary2 != null)
		{
			foreach (KeyValuePair<int, PhantomDataBase> keyValuePair in dictionary2)
			{
				PhantomDataBase value = keyValuePair.Value;
				int? num = (value != null) ? new int?(value.GetConfig().MonsterId) : null;
				int monsterId = this.MonsterId;
				if (num.GetValueOrDefault() == monsterId & num != null)
				{
					visionRoleHeadInfo = ((roleInstanceById != null) ? new int?(roleInstanceById.GetRoleId()) : null);
					break;
				}
			}
		}
		CalabashDevelopReward? calabashDevelopRewardByMonsterId = ConfigBase<CalabashConfig>.Instance.GetCalabashDevelopRewardByMonsterId(this.MonsterId);
		if (calabashDevelopRewardByMonsterId == null)
		{
			return;
		}
		bool flag = handBookInfo != null;
		int? itemConfigId = null;
		if (data.QualityId > 0)
		{
			int[] phantomItemIdArrayByMonsterId = ModelBase<PhantomBattleModel>.Instance.GetPhantomItemIdArrayByMonsterId(this.MonsterId);
			itemConfigId = new int?(phantomItemIdArrayByMonsterId[data.QualityId - 1]);
		}
		PhantomSmallItemGrid phantomSmallItemGrid = new PhantomSmallItemGrid
		{
			Data = data,
			ItemConfigId = itemConfigId,
			BottomText = "",
			IsNotFoundVisible = new bool?(!flag),
			MonsterId = new int?(calabashDevelopRewardByMonsterId.Value.MonsterInfoId),
			IconHidden = new bool?(!flag)
		};
		phantomSmallItemGrid.VisionRoleHeadInfo = visionRoleHeadInfo;
		base.Apply<PhantomSmallItemGrid>(phantomSmallItemGrid);
	}

	// Token: 0x04008DC5 RID: 36293
	private int MonsterId;
}
