using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002BE7 RID: 11239
public class TowerAreaItem : GridProxyAbstract<int>
{
	// Token: 0x060166E5 RID: 91877 RVA: 0x0063AE6C File Offset: 0x0063906C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickTowerBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060166E6 RID: 91878 RVA: 0x0063B01C File Offset: 0x0063921C
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.FinishSequenceEvent), false);
		Singleton<EventSystem>.Instance.Add(EEventName.OnTowerRefresh, new Action(this.OnTowerRefresh));
		base.GetText(1).SetUIActive(false);
	}

	// Token: 0x060166E7 RID: 91879 RVA: 0x0063B07C File Offset: 0x0063927C
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		TowerConfig value = ConfigBase<TowerClimbConfig>.Instance.GetTowerInfo(data).Value;
		this.TowerData = data;
		this.AreaNumber = value.AreaNum;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), value.AreaName, Array.Empty<object>());
		this.RefreshTowerStar(value);
	}

	// Token: 0x060166E8 RID: 91880 RVA: 0x0063B0D8 File Offset: 0x006392D8
	private void RefreshTowerStar(TowerConfig towerInfo)
	{
		int areaAllStars = ModelBase<TowerModel>.Instance.GetAreaAllStars(towerInfo.Difficulty, towerInfo.AreaNum);
		UUIText text = base.GetText(3);
		this.IsLock = ModelBase<TowerModel>.Instance.CurrentTowerLock;
		UUIItem item = base.GetItem(8);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		UUIItem item2 = base.GetItem(9);
		if (item2 != null)
		{
			item2.SetUIActive(false);
		}
		if (this.IsLock)
		{
			base.GetItem(0).SetUIActive(true);
			base.GetItem(5).SetUIActive(false);
			base.GetItem(6).SetUIActive(false);
			text.SetText("0/" + areaAllStars.ToString(), true);
			FColor color = FColor.FromHex("#ADADAD");
			text.SetColor(color);
			base.GetItem(7).SetColor(color);
			return;
		}
		base.GetItem(0).SetUIActive(false);
		int areaStars = ModelBase<TowerModel>.Instance.GetAreaStars(towerInfo.Difficulty, towerInfo.AreaNum, false);
		text.SetText(areaStars.ToString() + "/" + areaAllStars.ToString(), true);
		bool flag = areaAllStars == areaStars;
		base.GetItem(5).SetUIActive(!flag);
		base.GetItem(6).SetUIActive(flag);
		FColor color2 = FColor.FromHex(flag ? "#FFD12F" : "#ECE5D8");
		text.SetColor(color2);
		base.GetItem(7).SetColor(color2);
	}

	// Token: 0x060166E9 RID: 91881 RVA: 0x0063B23C File Offset: 0x0063943C
	private void OnClickTowerBtn()
	{
		if (this.IsLock)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("NeedClearLastDifficulty", Array.Empty<object>());
			return;
		}
		this.LevelSequencePlayer.StopCurrentSequence(false, false);
		this.LevelSequencePlayer.PlaySequencePurely("Click", true, false, null, null, false);
	}

	// Token: 0x060166EA RID: 91882 RVA: 0x0063B290 File Offset: 0x00639490
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnTowerRefresh, new Action(this.OnTowerRefresh));
		this.IsLock = true;
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		this.LevelSequencePlayer = null;
	}

	// Token: 0x060166EB RID: 91883 RVA: 0x0063B2CD File Offset: 0x006394CD
	[NullableContext(1)]
	private void FinishSequenceEvent(string name)
	{
		if (name == "Click")
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TowerFloorView, this.AreaNumber, null);
		}
	}

	// Token: 0x060166EC RID: 91884 RVA: 0x0063B2F8 File Offset: 0x006394F8
	private void OnTowerRefresh()
	{
		TowerConfig value = ConfigBase<TowerClimbConfig>.Instance.GetTowerInfo(this.TowerData).Value;
		this.RefreshTowerStar(value);
	}

	// Token: 0x0400ADB5 RID: 44469
	private bool IsLock = true;

	// Token: 0x0400ADB6 RID: 44470
	private int AreaNumber = -1;

	// Token: 0x0400ADB7 RID: 44471
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0400ADB8 RID: 44472
	private int TowerData = -1;

	// Token: 0x02008EDD RID: 36573
	private enum EChildType
	{
		// Token: 0x0402FFE2 RID: 196578
		LockItem,
		// Token: 0x0402FFE3 RID: 196579
		AreaNumberText,
		// Token: 0x0402FFE4 RID: 196580
		AreaNameText,
		// Token: 0x0402FFE5 RID: 196581
		StarText,
		// Token: 0x0402FFE6 RID: 196582
		TowerBtn,
		// Token: 0x0402FFE7 RID: 196583
		UnLockItem,
		// Token: 0x0402FFE8 RID: 196584
		FinishItem,
		// Token: 0x0402FFE9 RID: 196585
		StarItem,
		// Token: 0x0402FFEA RID: 196586
		NormalEffectItem,
		// Token: 0x0402FFEB RID: 196587
		DarkEffectItem
	}
}
