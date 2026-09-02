using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200171D RID: 5917
[NullableContext(1)]
[Nullable(0)]
public class WuWuLogisticsPackItem : GridProxyAbstract<int>
{
	// Token: 0x0600A47D RID: 42109 RVA: 0x002B7EE4 File Offset: 0x002B60E4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUISprite)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUISprite)),
			new ValueTuple<int, Type>(8, typeof(UUITexture)),
			new ValueTuple<int, Type>(9, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClicked))
		};
	}

	// Token: 0x0600A47E RID: 42110 RVA: 0x002B7FFC File Offset: 0x002B61FC
	protected override void OnStart()
	{
		this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x0600A47F RID: 42111 RVA: 0x002B800F File Offset: 0x002B620F
	public void SetClickCallback(Action<int> callback)
	{
		this.ClickCallback = callback;
	}

	// Token: 0x0600A480 RID: 42112 RVA: 0x002B8018 File Offset: 0x002B6218
	public void SetPackToggleInteractive(bool interactive)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetSelfInteractive(interactive);
	}

	// Token: 0x0600A481 RID: 42113 RVA: 0x002B802C File Offset: 0x002B622C
	public override void Refresh(int cfgId, bool isSelected, int gridIndex)
	{
		this.CfgId = cfgId;
		this.SetToggleSelect(isSelected);
		WuWuTaskPackage? taskPackageById = ConfigBase<WuWuLogisticsConfig>.Instance.GetTaskPackageById(this.CfgId);
		if (taskPackageById != null)
		{
			UUIText text = base.GetText(5);
			if (text != null)
			{
				text.ShowTextNew(taskPackageById.Value.Title);
			}
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 1);
		defaultInterpolatedStringHandler.AppendLiteral("SP_TurntableNormal_Index0");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.CfgId);
		string resourceId = defaultInterpolatedStringHandler.ToStringAndClear();
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		this.SetSpriteByPath(resourcePath, base.GetSprite(4), false, null, null);
		this.RefreshStateInfo();
		this.PlaySequencePurely();
		WuWuLogisticsActivityData activityData = ControllerBase<WuWuLogisticsActivityController>.Instance.GetActivityData();
		bool uiactive = (activityData != null && activityData.TargetPackChildTaskHasReceiveReward(this.CfgId)) || (activityData != null && activityData.TargetPackHasReceiveReward(this.CfgId));
		UUIItem item = base.GetItem(9);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(uiactive);
	}

	// Token: 0x0600A482 RID: 42114 RVA: 0x002B8128 File Offset: 0x002B6328
	private void RefreshStateInfo()
	{
		UUIItem item = base.GetItem(1);
		UUIItem item2 = base.GetItem(2);
		UUIItem item3 = base.GetItem(3);
		UUITexture texture = base.GetTexture(8);
		UUISprite sprite = base.GetSprite(7);
		UUIItem item4 = base.GetItem(6);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		if (item2 != null)
		{
			item2.SetUIActive(false);
		}
		if (item3 != null)
		{
			item3.SetUIActive(false);
		}
		if (texture != null)
		{
			texture.SetUIActive(false);
		}
		if (sprite != null)
		{
			sprite.SetUIActive(false);
		}
		if (item4 != null)
		{
			item4.SetUIActive(false);
		}
		int activityId = ControllerBase<WuWuLogisticsActivityController>.Instance.ActivityId;
		WuWuLogisticsActivityData wuWuLogisticsActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as WuWuLogisticsActivityData;
		if (wuWuLogisticsActivityData == null)
		{
			return;
		}
		if (wuWuLogisticsActivityData.GetTaskPackById(this.CfgId) == null)
		{
			return;
		}
		if (wuWuLogisticsActivityData.TargetPackIsFullyRewarded(this.CfgId))
		{
			if (item3 != null)
			{
				item3.SetUIActive(true);
			}
			if (item4 != null)
			{
				item4.SetUIActive(true);
			}
			if (sprite != null)
			{
				sprite.SetUIActive(true);
			}
			return;
		}
		if (!wuWuLogisticsActivityData.IsPackUnlocked(this.CfgId))
		{
			if (item4 != null)
			{
				item4.SetUIActive(true);
			}
			if (item != null)
			{
				item.SetUIActive(true);
			}
			if (texture != null)
			{
				texture.SetUIActive(true);
			}
			return;
		}
		if (item2 != null)
		{
			item2.SetUIActive(true);
		}
		if (item4 != null)
		{
			item4.SetUIActive(false);
		}
	}

	// Token: 0x0600A483 RID: 42115 RVA: 0x002B8253 File Offset: 0x002B6453
	private void OnClicked(EToggleState state)
	{
		Action<int> clickCallback = this.ClickCallback;
		if (clickCallback == null)
		{
			return;
		}
		clickCallback(this.CfgId);
	}

	// Token: 0x0600A484 RID: 42116 RVA: 0x002B826B File Offset: 0x002B646B
	public override void OnSelected(bool fireEvent)
	{
		this.SetToggleSelect(true);
	}

	// Token: 0x0600A485 RID: 42117 RVA: 0x002B8274 File Offset: 0x002B6474
	public override void OnDeselected(bool fireEvent)
	{
		this.SetToggleSelect(false);
	}

	// Token: 0x0600A486 RID: 42118 RVA: 0x002B8280 File Offset: 0x002B6480
	public void SetToggleSelect(bool select)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleStateForce(select ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}
		UUISprite sprite = base.GetSprite(4);
		FColor changeColor = sprite.changeColor;
		FColor? fcolor = new FColor?(changeColor);
		sprite.SetChangeColor(select, fcolor);
	}

	// Token: 0x0600A487 RID: 42119 RVA: 0x002B82C8 File Offset: 0x002B64C8
	public void PlaySequencePurely()
	{
		if (this.SeqPlayer != null && this.SeqPlayer.IsPlayingSequence("Loop"))
		{
			return;
		}
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer == null)
		{
			return;
		}
		seqPlayer.PlayLevelSequenceByName("Loop", false, null, false);
	}

	// Token: 0x04004E2C RID: 20012
	private int CfgId;

	// Token: 0x04004E2D RID: 20013
	private Action<int> ClickCallback = delegate(int _)
	{
	};

	// Token: 0x04004E2E RID: 20014
	[Nullable(2)]
	private LevelSequencePlayer SeqPlayer;
}
