using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001443 RID: 5187
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
internal class MowingTowerRewardTabItem : GridProxyAbstract<MowingTowerLevelDetailInfo>
{
	// Token: 0x0600905B RID: 36955 RVA: 0x0025F1FC File Offset: 0x0025D3FC
	public void SetClickCallBack(Action<MowingTowerRewardTabItem> callback)
	{
		this.ClickCallBack = callback;
	}

	// Token: 0x0600905C RID: 36956 RVA: 0x0025F208 File Offset: 0x0025D408
	protected unsafe override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
		int num = 1;
		List<ValueTuple<int, Delegate>> list = new List<ValueTuple<int, Delegate>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list, num);
		Span<ValueTuple<int, Delegate>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
		this.BtnBindInfo = list;
	}

	// Token: 0x0600905D RID: 36957 RVA: 0x0025F2B8 File Offset: 0x0025D4B8
	public override void Refresh(MowingTowerLevelDetailInfo data, bool isSelected, int gridIndex)
	{
		this.LevelData = data;
		if (gridIndex == 0)
		{
			Action<MowingTowerRewardTabItem> clickCallBack = this.ClickCallBack;
			if (clickCallBack != null)
			{
				clickCallBack(this);
			}
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, false, false, false);
		}
		else
		{
			this.SetToggleUnCheck();
		}
		MowTowerLevelsRe? config = data.GetConfig();
		if (config == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), config.Value.RewardName, Array.Empty<object>());
		base.SetTextureByPath(config.Value.RewardTexture, base.GetTexture(2), null, null);
	}

	// Token: 0x0600905E RID: 36958 RVA: 0x0025F356 File Offset: 0x0025D556
	private void OnClickToggle(EToggleState toggleState)
	{
		Action<MowingTowerRewardTabItem> clickCallBack = this.ClickCallBack;
		if (clickCallBack == null)
		{
			return;
		}
		clickCallBack(this);
	}

	// Token: 0x0600905F RID: 36959 RVA: 0x0025F369 File Offset: 0x0025D569
	public void SetToggleUnCheck()
	{
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x06009060 RID: 36960 RVA: 0x0025F37C File Offset: 0x0025D57C
	public int? GetLevelId()
	{
		MowingTowerLevelDetailInfo levelData = this.LevelData;
		if (levelData == null)
		{
			return null;
		}
		return new int?(levelData.GetId());
	}

	// Token: 0x06009061 RID: 36961 RVA: 0x0025F3A7 File Offset: 0x0025D5A7
	public void SetRedDotActive(bool isShow)
	{
		UUIItem item = base.GetItem(3);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(isShow);
	}

	// Token: 0x04004304 RID: 17156
	[Nullable(2)]
	private MowingTowerLevelDetailInfo LevelData;

	// Token: 0x04004305 RID: 17157
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<MowingTowerRewardTabItem> ClickCallBack;
}
