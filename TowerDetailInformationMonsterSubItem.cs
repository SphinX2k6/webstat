using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002BF0 RID: 11248
public class TowerDetailInformationMonsterSubItem : UiPanelBase
{
	// Token: 0x0601671E RID: 91934 RVA: 0x0063BE9F File Offset: 0x0063A09F
	[NullableContext(1)]
	public TowerDetailInformationMonsterSubItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0601671F RID: 91935 RVA: 0x0063BEB4 File Offset: 0x0063A0B4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06016720 RID: 91936 RVA: 0x0063BF5F File Offset: 0x0063A15F
	protected override void OnStart()
	{
	}

	// Token: 0x06016721 RID: 91937 RVA: 0x0063BF61 File Offset: 0x0063A161
	public void Update(int data, int level)
	{
		this.MonsterInfoId = data;
		this.ShowLevel = level;
		this.RefreshView();
	}

	// Token: 0x06016722 RID: 91938 RVA: 0x0063BF78 File Offset: 0x0063A178
	private void RefreshView()
	{
		string monsterName = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterName(this.MonsterInfoId);
		base.GetText(0).SetText(monsterName, true);
		string newText = this.ShowLevel.ToString();
		base.GetText(1).SetText(newText, true);
		string monsterIcon = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterIcon(this.MonsterInfoId);
		base.SetTextureByPath(monsterIcon, base.GetTexture(2), null, null);
	}

	// Token: 0x0400ADC7 RID: 44487
	private int MonsterInfoId;

	// Token: 0x0400ADC8 RID: 44488
	private int ShowLevel;

	// Token: 0x02008EE5 RID: 36581
	private enum EChildType
	{
		// Token: 0x04030006 RID: 196614
		NameText,
		// Token: 0x04030007 RID: 196615
		LevelText,
		// Token: 0x04030008 RID: 196616
		MonsterIcon,
		// Token: 0x04030009 RID: 196617
		RoleItem
	}
}
