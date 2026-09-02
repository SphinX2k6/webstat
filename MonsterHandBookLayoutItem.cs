using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001E9A RID: 7834
[NullableContext(1)]
[Nullable(0)]
internal class MonsterHandBookLayoutItem : UiPanelBase
{
	// Token: 0x0600E792 RID: 59282 RVA: 0x003E87F4 File Offset: 0x003E69F4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIGridLayout))
		};
	}

	// Token: 0x0600E793 RID: 59283 RVA: 0x003E8817 File Offset: 0x003E6A17
	protected override void OnStart()
	{
		this.GridLayout = new GenericLayout<MonsterHandBookMonsterItem, int>(base.GetGridLayout(0), new Func<MonsterHandBookMonsterItem>(this.InitItem), null, false, true);
	}

	// Token: 0x0600E794 RID: 59284 RVA: 0x003E883A File Offset: 0x003E6A3A
	private MonsterHandBookMonsterItem InitItem()
	{
		return new MonsterHandBookMonsterItem
		{
			OnClickCallBack = this.OnClickCallBack
		};
	}

	// Token: 0x0600E795 RID: 59285 RVA: 0x003E884D File Offset: 0x003E6A4D
	public void Update(int[] dataList)
	{
		if (this.GridLayout != null)
		{
			this.GridLayout.RefreshByData(new List<int>(dataList), delegate
			{
				GenericLayout<MonsterHandBookMonsterItem, int> gridLayout = this.GridLayout;
				foreach (MonsterHandBookMonsterItem monsterHandBookMonsterItem in (((gridLayout != null) ? gridLayout.GetLayoutItemList() : null) ?? new List<MonsterHandBookMonsterItem>()))
				{
					if (monsterHandBookMonsterItem.HandBookId == ModelBase<HandBookModel>.Instance.CurrentSelectMonsterHandBookId)
					{
						monsterHandBookMonsterItem.OnSelected(true);
						break;
					}
				}
			}, false);
		}
	}

	// Token: 0x04006FA0 RID: 28576
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<UUIExtendToggle, int, bool> OnClickCallBack;

	// Token: 0x04006FA1 RID: 28577
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<MonsterHandBookMonsterItem, int> GridLayout;
}
