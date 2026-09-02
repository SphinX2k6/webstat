using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001C66 RID: 7270
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class FloroRanchRaceCardItem : GridProxyAbstract<FloroRanchRaceData>
{
	// Token: 0x0600D43B RID: 54331 RVA: 0x00389A88 File Offset: 0x00387C88
	protected unsafe override void OnRegisterComponent()
	{
		int num = 11;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(9, new Action<EToggleState>(this.OnClickToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D43C RID: 54332 RVA: 0x00389C5C File Offset: 0x00387E5C
	[NullableContext(1)]
	public override void Refresh(FloroRanchRaceData data, bool isSelected, int gridIndex)
	{
		this.RaceData = data;
		base.SetTextureByPath(data.Icon, base.GetTexture(3), null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), data.GetRaceName(), Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), data.GetDesc(), Array.Empty<object>());
		base.GetText(5).bBestFit = false;
		FloroRanchActivityData activityData = ModelBase<FloroRanchModel>.Instance.GetActivityData(this.ActivityDataType, true);
		bool flag = this.IsFixedRace(data.Id);
		bool flag2 = !activityData.IsRaceUnlocked(data.Id);
		base.GetItem(1).SetUIActive(flag);
		base.GetItem(6).SetUIActive(!flag && flag2);
		base.GetItem(10).SetUIActive(false);
		if (flag)
		{
			this.SetToggleState(true);
		}
		base.GetItem(8).SetUIActive(false);
		if (flag2)
		{
			string conditionGroupHintText = LevelGeneralCommons.GetConditionGroupHintText(activityData.GetRaceConditionId(data.Id));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), conditionGroupHintText, Array.Empty<object>());
			return;
		}
		if (this.ActivityDataType == EFloroRanchActivityDataType.Normal && !(LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.FloroRanchRaceRedDot, null) ?? new HashSet<int>()).Contains(data.Id))
		{
			base.GetItem(8).SetUIActive(true);
		}
	}

	// Token: 0x0600D43D RID: 54333 RVA: 0x00389DB0 File Offset: 0x00387FB0
	private void OnClickToggle(EToggleState _)
	{
		FloroRanchActivityData activityData = ModelBase<FloroRanchModel>.Instance.GetActivityData(this.ActivityDataType, true);
		if (this.ActivityDataType == EFloroRanchActivityDataType.Normal)
		{
			HashSet<int> hashSet = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.FloroRanchRaceRedDot, null) ?? new HashSet<int>();
			if (activityData.IsRaceUnlocked(this.RaceData.Id) && !hashSet.Contains(this.RaceData.Id))
			{
				hashSet.Add(this.RaceData.Id);
				LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.FloroRanchRaceRedDot, hashSet);
			}
		}
		base.GetItem(8).SetUIActive(false);
		Func<int, bool> isFixedRace = this.IsFixedRace;
		if (isFixedRace != null && isFixedRace(this.RaceData.Id))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("FarmCannotBeModified", Array.Empty<object>());
			this.SetToggleState(true);
			return;
		}
		if (!activityData.IsRaceUnlocked(this.RaceData.Id))
		{
			this.SetToggleState(false);
			return;
		}
		if (this.OnToggleCallBack != null)
		{
			this.OnToggleCallBack(this.RaceData.Id);
		}
	}

	// Token: 0x0600D43E RID: 54334 RVA: 0x00389EB1 File Offset: 0x003880B1
	[NullableContext(1)]
	public override object GetKey(FloroRanchRaceData data, int displayIndex)
	{
		return data.Id;
	}

	// Token: 0x0600D43F RID: 54335 RVA: 0x00389EC0 File Offset: 0x003880C0
	public void SetToggleState(bool state)
	{
		EToggleState state2 = state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(9).SetToggleState(state2, false, false, false);
	}

	// Token: 0x0600D440 RID: 54336 RVA: 0x00389EE7 File Offset: 0x003880E7
	public void SetEquippedPanelVisible(bool isShow)
	{
		UUIItem item = base.GetItem(10);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(isShow);
	}

	// Token: 0x040064FC RID: 25852
	private FloroRanchRaceData RaceData;

	// Token: 0x040064FD RID: 25853
	public EFloroRanchActivityDataType ActivityDataType;

	// Token: 0x040064FE RID: 25854
	public Func<int, bool> IsFixedRace;

	// Token: 0x040064FF RID: 25855
	public Action<int> OnToggleCallBack;

	// Token: 0x02007F8F RID: 32655
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402B6D4 RID: 177876
		public const int SpriteSelected = 0;

		// Token: 0x0402B6D5 RID: 177877
		public const int ItemFixedPanel = 1;

		// Token: 0x0402B6D6 RID: 177878
		public const int ItemOptionPanel = 2;

		// Token: 0x0402B6D7 RID: 177879
		public const int TextureIcon = 3;

		// Token: 0x0402B6D8 RID: 177880
		public const int TextName = 4;

		// Token: 0x0402B6D9 RID: 177881
		public const int TextDescription = 5;

		// Token: 0x0402B6DA RID: 177882
		public const int ItemLockPanel = 6;

		// Token: 0x0402B6DB RID: 177883
		public const int TextLock = 7;

		// Token: 0x0402B6DC RID: 177884
		public const int ItemRedDot = 8;

		// Token: 0x0402B6DD RID: 177885
		public const int ToggleRoot = 9;

		// Token: 0x0402B6DE RID: 177886
		public const int ItemEquippedPanel = 10;
	}
}
