using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001F77 RID: 8055
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class MascotCollectBookStageToggle : GridProxyAbstract<HonamiStoryAreaData>
{
	// Token: 0x0600F16C RID: 61804 RVA: 0x0041FA69 File Offset: 0x0041DC69
	protected override void OnBeforeCreateImplement()
	{
		this.LevelPlaySequence = new UiBehaviorLevelSequence(this);
		base.AddUiBehavior(this.LevelPlaySequence);
	}

	// Token: 0x0600F16D RID: 61805 RVA: 0x0041FA84 File Offset: 0x0041DC84
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUISprite)),
			new ValueTuple<int, Type>(5, typeof(UUISprite)),
			new ValueTuple<int, Type>(6, typeof(UUISprite)),
			new ValueTuple<int, Type>(7, typeof(UUISprite)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUITexture))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggle))
		};
	}

	// Token: 0x0600F16E RID: 61806 RVA: 0x0041FBE1 File Offset: 0x0041DDE1
	protected override void OnStart()
	{
		if (this.ActivityData == null)
		{
			this.ActivityData = ModelBase<HonamiStoryModel>.Instance.GetActivityData(true);
		}
		base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x1700126C RID: 4716
	// (get) Token: 0x0600F16F RID: 61807 RVA: 0x0041FC0C File Offset: 0x0041DE0C
	public HonamiStoryAreaData Data
	{
		get
		{
			return this.AreaData;
		}
	}

	// Token: 0x0600F170 RID: 61808 RVA: 0x0041FC14 File Offset: 0x0041DE14
	public override void Refresh(HonamiStoryAreaData areaData, bool isSelected, int gridIndex)
	{
		this.AreaData = areaData;
		this.RefreshItem();
		if (areaData.IsSecretFinished)
		{
			UiBehaviorLevelSequence levelPlaySequence = this.LevelPlaySequence;
			if (levelPlaySequence == null)
			{
				return;
			}
			levelPlaySequence.PlaySequence("Unlock", false, null);
		}
	}

	// Token: 0x0600F171 RID: 61809 RVA: 0x0041FC58 File Offset: 0x0041DE58
	private void RefreshItem()
	{
		bool isAreaUnlock = this.AreaData.IsAreaUnlock;
		base.GetItem(9).SetUIActive(!isAreaUnlock);
		base.GetItem(10).SetUIActive(isAreaUnlock);
		base.GetItem(11).SetUIActive(isAreaUnlock);
		base.GetExtendToggle(0).SetSelfInteractive(isAreaUnlock);
		UUIText text = base.GetText(8);
		if (text != null)
		{
			text.ShowTextNew(this.AreaData.Name);
		}
		if (isAreaUnlock)
		{
			EHonamiStoryCollectState collectMascotState = this.AreaData.CollectMascotState;
			UUISprite sprite = base.GetSprite(4);
			if (sprite != null)
			{
				sprite.SetUIActive(collectMascotState == EHonamiStoryCollectState.Finished);
			}
			UUITexture texture = base.GetTexture(3);
			if (texture != null)
			{
				texture.SetUIActive(collectMascotState == EHonamiStoryCollectState.Unfinished);
			}
			UUITexture texture2 = base.GetTexture(1);
			if (collectMascotState != EHonamiStoryCollectState.Unfinished)
			{
				base.SetTextureShowUntilLoaded(this.AreaData.Config.Value.ToggleBgPath, texture2, null);
			}
			texture2.SetUIActive(collectMascotState > EHonamiStoryCollectState.Unfinished);
			List<HonamiStoryMascotData> honamiStoryMascotDataListByAreaId = this.ActivityData.GetHonamiStoryMascotDataListByAreaId(this.AreaData.Id);
			int num = 5;
			using (List<HonamiStoryMascotData>.Enumerator enumerator = honamiStoryMascotDataListByAreaId.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					HonamiStoryMascotData honamiStoryMascotData = enumerator.Current;
					UUISprite sprite2 = base.GetSprite(num);
					if (sprite2 != null)
					{
						sprite2.SetUIActive(honamiStoryMascotData.State > EHonamiStoryCollectState.Unfinished);
					}
					num++;
				}
				goto IL_155;
			}
		}
		UUIText text2 = base.GetText(8);
		if (text2 != null)
		{
			text2.ShowTextNew("HonamiStory_UnknownAreaName");
		}
		IL_155:
		base.SetTextureShowUntilLoaded(this.AreaData.Config.Value.ToggleBgPath, base.GetTexture(12), null);
	}

	// Token: 0x0600F172 RID: 61810 RVA: 0x0041FDF8 File Offset: 0x0041DFF8
	public void BindStageToggleClick(Action<MascotCollectBookStageToggle> callback)
	{
		this.StageToggleClick = callback;
	}

	// Token: 0x0600F173 RID: 61811 RVA: 0x0041FE01 File Offset: 0x0041E001
	private void OnToggle(EToggleState toggleState)
	{
		Action<MascotCollectBookStageToggle> stageToggleClick = this.StageToggleClick;
		if (stageToggleClick == null)
		{
			return;
		}
		stageToggleClick(this);
	}

	// Token: 0x0600F174 RID: 61812 RVA: 0x0041FE14 File Offset: 0x0041E014
	public override void OnSelected(bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x0600F175 RID: 61813 RVA: 0x0041FE26 File Offset: 0x0041E026
	public override void OnDeselected(bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x040073ED RID: 29677
	private HonamiStoryActivityData ActivityData;

	// Token: 0x040073EE RID: 29678
	private HonamiStoryAreaData AreaData;

	// Token: 0x040073EF RID: 29679
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<MascotCollectBookStageToggle> StageToggleClick;

	// Token: 0x040073F0 RID: 29680
	[Nullable(2)]
	private UiBehaviorLevelSequence LevelPlaySequence;

	// Token: 0x02008318 RID: 33560
	[NullableContext(0)]
	private enum EMascotCollectBookStageToggleComponent
	{
		// Token: 0x0402C732 RID: 182066
		Toggle,
		// Token: 0x0402C733 RID: 182067
		BgTexture,
		// Token: 0x0402C734 RID: 182068
		DescTexture,
		// Token: 0x0402C735 RID: 182069
		LockTexture,
		// Token: 0x0402C736 RID: 182070
		GiftSprite,
		// Token: 0x0402C737 RID: 182071
		FindOneSprite,
		// Token: 0x0402C738 RID: 182072
		FindTwoSprite,
		// Token: 0x0402C739 RID: 182073
		FindThreeSprite,
		// Token: 0x0402C73A RID: 182074
		NameText,
		// Token: 0x0402C73B RID: 182075
		EmptyPanel,
		// Token: 0x0402C73C RID: 182076
		InfoPanel,
		// Token: 0x0402C73D RID: 182077
		MascotStatePanel,
		// Token: 0x0402C73E RID: 182078
		GrayBgTexture
	}
}
