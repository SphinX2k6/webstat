using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002B79 RID: 11129
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class SurvivorsRogueWeaponStateGrid : GridProxyAbstract<ISurvivorsWeaponGridData>
{
	// Token: 0x0601628A RID: 90762 RVA: 0x0062605C File Offset: 0x0062425C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUISprite)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtn))
		};
	}

	// Token: 0x0601628B RID: 90763 RVA: 0x006261E7 File Offset: 0x006243E7
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
	}

	// Token: 0x0601628C RID: 90764 RVA: 0x006261FC File Offset: 0x006243FC
	private void OnClickBtn()
	{
		if (this.Data.IsDisable)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("SurvivorsCombat_WeaponNoUsed", Array.Empty<object>());
			return;
		}
		if (this.Data.IsLock)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("SurvivorsWeaponAttribute_WaveUnlockTips", new object[]
			{
				this.Data.UnlockBatch.GetValueOrDefault()
			});
			return;
		}
		SurvivorsTabMainViewData survivorsTabMainViewData = new SurvivorsTabMainViewData();
		survivorsTabMainViewData.SkipTabType = new ETabType?(ETabType.Weapon);
		SurvivorsWeaponGainData weaponData = this.Data.WeaponData;
		survivorsTabMainViewData.SkipWeaponId = ((weaponData != null) ? new int?(weaponData.ConfigId) : null);
		SurvivorsTabMainViewData param = survivorsTabMainViewData;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SurvivorsTabMainView, param, null);
	}

	// Token: 0x0601628D RID: 90765 RVA: 0x006262B6 File Offset: 0x006244B6
	public override void Refresh(ISurvivorsWeaponGridData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		this.SetSelectOn(false);
		if (data.IsDisable)
		{
			this.SetStateDisable();
			return;
		}
		if (data.IsLock)
		{
			this.SetStateLock();
			return;
		}
		this.SetStateNormal();
	}

	// Token: 0x0601628E RID: 90766 RVA: 0x006262EC File Offset: 0x006244EC
	private void SetStateDisable()
	{
		base.GetItem(13).SetUIActive(true);
		base.GetItem(12).SetUIActive(false);
		base.GetText(4).SetUIActive(false);
		base.GetTexture(2).SetUIActive(false);
		FColor changeColor = base.GetSprite(1).changeColor;
		UUIItem sprite = base.GetSprite(1);
		bool bUseChangeColor = true;
		FColor? fcolor = new FColor?(changeColor);
		sprite.SetChangeColor(bUseChangeColor, fcolor);
		base.GetSprite(5).SetUIActive(false);
		base.GetText(4).SetUIActive(false);
		base.GetItem(14).SetUIActive(false);
	}

	// Token: 0x0601628F RID: 90767 RVA: 0x0062637C File Offset: 0x0062457C
	private void SetStateLock()
	{
		base.GetItem(13).SetUIActive(false);
		base.GetItem(12).SetUIActive(true);
		base.GetText(4).SetUIActive(false);
		base.GetTexture(2).SetUIActive(false);
		FColor changeColor = base.GetSprite(1).changeColor;
		UUIItem sprite = base.GetSprite(1);
		bool bUseChangeColor = true;
		FColor? fcolor = new FColor?(changeColor);
		sprite.SetChangeColor(bUseChangeColor, fcolor);
		base.GetSprite(5).SetUIActive(false);
		UUIText text = base.GetText(4);
		ISurvivorsWeaponGridData data = this.Data;
		if (data != null && data.UnlockBatch != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "SurvivorsWeaponAttribute_WaveUnlockButton", new <>z__ReadOnlySingleElementList<object>(this.Data.UnlockBatch.Value));
		}
		UUIItem item = base.GetItem(14);
		ISurvivorsWeaponGridData data2 = this.Data;
		item.SetUIActive(data2 != null && data2.UnlockBatch != null);
		UUIItem uuiitem = text;
		ISurvivorsWeaponGridData data3 = this.Data;
		uuiitem.SetUIActive(data3 != null && data3.UnlockBatch != null);
	}

	// Token: 0x06016290 RID: 90768 RVA: 0x00626488 File Offset: 0x00624688
	private void SetStateNormal()
	{
		base.GetItem(13).SetUIActive(false);
		base.GetItem(12).SetUIActive(false);
		SurvivorsWeaponGainData weaponData = this.Data.WeaponData;
		if (weaponData == null)
		{
			return;
		}
		SurvivorsWeapon? survivorsWeapon = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsWeapon(weaponData.ConfigId);
		SurvivorsWeaponEvolve? survivorsWeaponEvolve = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsWeaponEvolve(weaponData.GetCurrentEvolveId());
		if (survivorsWeapon == null || survivorsWeaponEvolve == null)
		{
			return;
		}
		SurvivorsQuality? qualityConfig = ConfigBase<SurvivorsRogueConfig>.Instance.GetQualityConfig(survivorsWeaponEvolve.Value.Quality);
		if (qualityConfig == null)
		{
			return;
		}
		UUIText text = base.GetText(4);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "SurvivorsCombat_Lv", new <>z__ReadOnlySingleElementList<object>(weaponData.Data.Level));
		text.SetUIActive(true);
		base.GetItem(14).SetUIActive(true);
		base.SetTextureShowUntilLoaded(survivorsWeapon.Value.Icon, base.GetTexture(2), null);
		FColor value = FColor.FromHex(qualityConfig.Value.WeaponColor);
		FColor changeColor = base.GetSprite(1).changeColor;
		UUIItem sprite = base.GetSprite(1);
		bool bUseChangeColor = false;
		FColor? fcolor = new FColor?(changeColor);
		sprite.SetChangeColor(bUseChangeColor, fcolor);
		UUIItem sprite2 = base.GetSprite(5);
		bool bUseChangeColor2 = true;
		fcolor = new FColor?(value);
		sprite2.SetChangeColor(bUseChangeColor2, fcolor);
		base.GetSprite(5).SetUIActive(true);
		if (this.Data.BondPosition.GetValueOrDefault() == -1)
		{
			this.SetConnected(true, 0);
			return;
		}
		if (this.Data.BondPosition.GetValueOrDefault() == 1)
		{
			this.SetConnected(false, 0);
			return;
		}
		this.SetDisConnected();
	}

	// Token: 0x06016291 RID: 90769 RVA: 0x00626628 File Offset: 0x00624828
	public void SetSelectOn(bool bUp)
	{
		base.GetItem(3).SetUIActive(bUp);
		if (bUp)
		{
			this.LevelSequencePlayer.PlayOrReplaySequenceByName("PreArm", false, null);
			return;
		}
		this.LevelSequencePlayer.StopSequenceByKey("PreArm", false, true);
	}

	// Token: 0x06016292 RID: 90770 RVA: 0x00626674 File Offset: 0x00624874
	public void SetLevelUp()
	{
		this.LevelSequencePlayer.StopSequenceByKey("PreArm", false, true);
		this.LevelSequencePlayer.PlayOrReplaySequenceByName("LevelUp", false, null);
	}

	// Token: 0x06016293 RID: 90771 RVA: 0x006266B0 File Offset: 0x006248B0
	public void SetSingleAnim(string seqName)
	{
		this.LevelSequencePlayer.StopCurrentSequence(false, true);
		this.LevelSequencePlayer.PlayOrReplaySequenceByName(seqName, false, null);
	}

	// Token: 0x06016294 RID: 90772 RVA: 0x006266E0 File Offset: 0x006248E0
	public void SetConnected(bool directionLeft, int distance)
	{
		this.SetDisConnected();
		int[] array = new int[]
		{
			7,
			9,
			11
		};
		int[] array2 = new int[]
		{
			6,
			8,
			10
		};
		int[] array3 = directionLeft ? array : array2;
		this.ConnectedComponentIndex = array3[distance];
		UUIItem item = base.GetItem(this.ConnectedComponentIndex);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		this.LevelSequencePlayer.PlayOrReplaySequenceByName("Connect", false, null);
	}

	// Token: 0x06016295 RID: 90773 RVA: 0x0062675C File Offset: 0x0062495C
	public void SetDisConnected()
	{
		if (this.ConnectedComponentIndex >= 0)
		{
			UUIItem item = base.GetItem(this.ConnectedComponentIndex);
			if (item != null)
			{
				item.SetUIActive(false);
			}
		}
		this.ConnectedComponentIndex = -1;
	}

	// Token: 0x06016296 RID: 90774 RVA: 0x00626790 File Offset: 0x00624990
	public void SetQualityById(int qualityId)
	{
		SurvivorsQuality? qualityConfig = ConfigBase<SurvivorsRogueConfig>.Instance.GetQualityConfig(qualityId);
		if (qualityConfig == null)
		{
			return;
		}
		FColor value = FColor.FromHex(qualityConfig.Value.WeaponColor);
		UUIItem sprite = base.GetSprite(5);
		bool bUseChangeColor = true;
		FColor? fcolor = new FColor?(value);
		sprite.SetChangeColor(bUseChangeColor, fcolor);
	}

	// Token: 0x06016297 RID: 90775 RVA: 0x006267DE File Offset: 0x006249DE
	public override object GetKey(ISurvivorsWeaponGridData data, int displayIndex)
	{
		SurvivorsWeaponGainData weaponData = data.WeaponData;
		return (weaponData != null) ? weaponData.ConfigId : 0;
	}

	// Token: 0x06016298 RID: 90776 RVA: 0x006267F8 File Offset: 0x006249F8
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		UUIButtonComponent button = base.GetButton(0);
		UUIItem uuiitem = (button != null) ? button.GetRootComponent() : null;
		if (uuiitem == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			uuiitem,
			uuiitem
		};
	}

	// Token: 0x0400AB6E RID: 43886
	private const string SURVIVORS_LV_KEY = "SurvivorsCombat_Lv";

	// Token: 0x0400AB6F RID: 43887
	private const string SEQ_PRE_SELECT = "PreArm";

	// Token: 0x0400AB70 RID: 43888
	private const string SEQ_LEVEL_UP = "LevelUp";

	// Token: 0x0400AB71 RID: 43889
	private const string SEQ_CONNECT = "Connect";

	// Token: 0x0400AB72 RID: 43890
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0400AB73 RID: 43891
	protected ISurvivorsWeaponGridData Data;

	// Token: 0x0400AB74 RID: 43892
	private int ConnectedComponentIndex = -1;
}
