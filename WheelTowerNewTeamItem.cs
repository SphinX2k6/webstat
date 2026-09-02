using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001673 RID: 5747
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	2
})]
public class WheelTowerNewTeamItem : GridProxyAbstract<TeamChallengeInfo>
{
	// Token: 0x17000D82 RID: 3458
	// (get) Token: 0x0600A0BB RID: 41147 RVA: 0x002A195B File Offset: 0x0029FB5B
	// (set) Token: 0x0600A0BC RID: 41148 RVA: 0x002A1963 File Offset: 0x0029FB63
	public Action<int> OnToggleCallback { get; set; }

	// Token: 0x0600A0BD RID: 41149 RVA: 0x002A196C File Offset: 0x0029FB6C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 14;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(7, new Action<EToggleState>(this.OnToggleClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A0BE RID: 41150 RVA: 0x002A1BA4 File Offset: 0x0029FDA4
	protected override void OnStart()
	{
		base.GetExtendToggle(7).bLockStateOnSelect = true;
		this.RoleIconLayout = new GenericLayout<WheelTowerRoleItem, RoleDataWithBranch>(base.GetHorizontalLayout(1), new Func<WheelTowerRoleItem>(this.CreateRoleItem), null, false, true);
	}

	// Token: 0x0600A0BF RID: 41151 RVA: 0x002A1BD4 File Offset: 0x0029FDD4
	public override void Refresh(TeamChallengeInfo data, bool isSelected, int gridIndex)
	{
		this.Round = gridIndex;
		int num = gridIndex + 1;
		this.NumberFirst = num / 10;
		this.NumberSecond = num % 10;
		if (this.NumberFirst == 0)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "WheelTower_Team_Number", new <>z__ReadOnlyArray<object>(new object[]
			{
				this.NumberFirst,
				this.NumberSecond
			}));
		}
		else
		{
			UUIText text = base.GetText(0);
			if (text != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 2);
				defaultInterpolatedStringHandler.AppendLiteral("<color=#ffffff>");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.NumberFirst);
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.NumberSecond);
				defaultInterpolatedStringHandler.AppendLiteral("</color>");
				text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
		}
		bool flag = data != null;
		UUIItem item = base.GetItem(10);
		if (item != null)
		{
			item.SetUIActive(!flag);
		}
		UUIItem item2 = base.GetItem(11);
		if (item2 != null)
		{
			item2.SetUIActive(flag);
		}
		UUIItem item3 = base.GetItem(12);
		if (item3 != null)
		{
			item3.SetUIActive(!flag);
		}
		UUIItem item4 = base.GetItem(13);
		if (item4 != null)
		{
			item4.SetUIActive(flag);
		}
		UUIItem item5 = base.GetItem(8);
		if (item5 != null)
		{
			item5.SetUIActive(!flag);
		}
		UUIItem item6 = base.GetItem(9);
		if (item6 != null)
		{
			item6.SetUIActive(flag);
		}
		List<RoleDataWithBranch> list = new List<RoleDataWithBranch>();
		if (data != null)
		{
			bool endlessMode = ModelBase<WheelTowerModel>.Instance.EndlessMode;
			UUIText text2 = base.GetText(4);
			if (text2 != null)
			{
				text2.SetUIActive(endlessMode);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "WheelTower_BossProgress_Endless", new <>z__ReadOnlySingleElementList<object>(data.LastMonsterInfoPreview.Round));
			ValueTuple<int, int> bossProgress = ModelBase<WheelTowerModel>.Instance.GetBossProgress(this.Round, null);
			UUIText text3 = base.GetText(5);
			if (text3 != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(47, 2);
				defaultInterpolatedStringHandler.AppendLiteral("<color=#ffffff>");
				defaultInterpolatedStringHandler.AppendFormatted<int>(bossProgress.Item1);
				defaultInterpolatedStringHandler.AppendLiteral("</color>/<color=#a0a0a0>");
				defaultInterpolatedStringHandler.AppendFormatted<int>(bossProgress.Item2);
				defaultInterpolatedStringHandler.AppendLiteral("</color>");
				text3.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			if (data.BuffIds.Count > 0)
			{
				NewTowerBuff? buffConfigById = ConfigBase<WheelTowerConfig>.Instance.GetBuffConfigById(data.BuffIds[0]);
				if (buffConfigById != null)
				{
					base.SetTextureByPath(buffConfigById.Value.Icon, base.GetTexture(3), null, null);
				}
			}
			UUIText text4 = base.GetText(6);
			if (text4 != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendLiteral("+");
				defaultInterpolatedStringHandler.AppendFormatted<int>(data.TeamScore);
				text4.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			foreach (RoleSaveInfo roleSaveInfo in data.RoleSaveInfos)
			{
				list.Add(new RoleDataWithBranch(roleSaveInfo.RoleId, roleSaveInfo.SkillBranchId));
			}
		}
		int teamMaxRoleCount = ModelBase<WheelTowerModel>.Instance.GetTeamMaxRoleCount();
		while (list.Count < teamMaxRoleCount)
		{
			list.Add(new RoleDataWithBranch(0, 0));
		}
		GenericLayout<WheelTowerRoleItem, RoleDataWithBranch> roleIconLayout = this.RoleIconLayout;
		if (roleIconLayout == null)
		{
			return;
		}
		roleIconLayout.RefreshByData(list, null, false);
	}

	// Token: 0x0600A0C0 RID: 41152 RVA: 0x002A1F1C File Offset: 0x002A011C
	public void SetToggleState(bool state)
	{
		EToggleState state2 = state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(7).SetToggleState(state2, false, false, false);
	}

	// Token: 0x0600A0C1 RID: 41153 RVA: 0x002A1F44 File Offset: 0x002A0144
	public override void OnSelected(bool fireEvent)
	{
		this.SetToggleState(true);
		UUIText text = base.GetText(0);
		if (text == null)
		{
			return;
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.NumberFirst);
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.NumberSecond);
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
	}

	// Token: 0x0600A0C2 RID: 41154 RVA: 0x002A1F94 File Offset: 0x002A0194
	public override void OnDeselected(bool fireEvent)
	{
		this.SetToggleState(false);
		if (this.NumberFirst == 0)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "WheelTower_Team_Number", new <>z__ReadOnlyArray<object>(new object[]
			{
				this.NumberFirst,
				this.NumberSecond
			}));
			return;
		}
		UUIText text = base.GetText(0);
		if (text == null)
		{
			return;
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 2);
		defaultInterpolatedStringHandler.AppendLiteral("<color=#ffffff>");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.NumberFirst);
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.NumberSecond);
		defaultInterpolatedStringHandler.AppendLiteral("</color>");
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
	}

	// Token: 0x0600A0C3 RID: 41155 RVA: 0x002A2043 File Offset: 0x002A0243
	private void OnToggleClick(EToggleState state)
	{
		Action<int> onToggleCallback = this.OnToggleCallback;
		if (onToggleCallback == null)
		{
			return;
		}
		onToggleCallback(this.Round);
	}

	// Token: 0x0600A0C4 RID: 41156 RVA: 0x002A205B File Offset: 0x002A025B
	[NullableContext(1)]
	private WheelTowerRoleItem CreateRoleItem()
	{
		return new WheelTowerRoleItem
		{
			IsOnlyShowIcon = true,
			CanClick = false
		};
	}

	// Token: 0x04004A75 RID: 19061
	private int Round;

	// Token: 0x04004A76 RID: 19062
	private int NumberFirst;

	// Token: 0x04004A77 RID: 19063
	private int NumberSecond;

	// Token: 0x04004A78 RID: 19064
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<WheelTowerRoleItem, RoleDataWithBranch> RoleIconLayout;
}
