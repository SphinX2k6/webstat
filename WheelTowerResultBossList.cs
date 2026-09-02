using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200165F RID: 5727
[NullableContext(1)]
[Nullable(0)]
public class WheelTowerResultBossList : UiPanelBase
{
	// Token: 0x0600A07F RID: 41087 RVA: 0x002A06D4 File Offset: 0x0029E8D4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIGridLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A080 RID: 41088 RVA: 0x002A0760 File Offset: 0x0029E960
	protected override void OnStart()
	{
		UUIGridLayout gridLayout = base.GetGridLayout(1);
		if (gridLayout != null)
		{
			this.GridLayout = new GenericLayout<WheelTowerResultBossList.BossSmallItem, IBossItemData>(gridLayout, new Func<WheelTowerResultBossList.BossSmallItem>(this.CreateBossSmallItem), null, false, true);
		}
		this.Player = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x0600A081 RID: 41089 RVA: 0x002A07A4 File Offset: 0x0029E9A4
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer player = this.Player;
		if (player == null)
		{
			return;
		}
		player.Clear();
	}

	// Token: 0x0600A082 RID: 41090 RVA: 0x002A07B6 File Offset: 0x0029E9B6
	private WheelTowerResultBossList.BossSmallItem CreateBossSmallItem()
	{
		return new WheelTowerResultBossList.BossSmallItem();
	}

	// Token: 0x0600A083 RID: 41091 RVA: 0x002A07C0 File Offset: 0x0029E9C0
	public void Refresh(List<IBossItemData> bossList)
	{
		base.SetUiActive(true);
		GenericLayout<WheelTowerResultBossList.BossSmallItem, IBossItemData> gridLayout = this.GridLayout;
		if (gridLayout != null)
		{
			gridLayout.RefreshByData(bossList, null, false);
		}
		LevelSequencePlayer player = this.Player;
		if (player == null)
		{
			return;
		}
		player.PlaySequencePurely("Start", false, false, null, null, false);
	}

	// Token: 0x04004A22 RID: 18978
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<WheelTowerResultBossList.BossSmallItem, IBossItemData> GridLayout;

	// Token: 0x04004A23 RID: 18979
	[Nullable(2)]
	private LevelSequencePlayer Player;

	// Token: 0x020079F7 RID: 31223
	[Nullable(new byte[]
	{
		0,
		1
	})]
	private class BossSmallItem : GridProxyAbstract<IBossItemData>
	{
		// Token: 0x06047814 RID: 292884 RVA: 0x0130E4C4 File Offset: 0x0130C6C4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06047815 RID: 292885 RVA: 0x0130E550 File Offset: 0x0130C750
		protected override UniTask OnBeforeStartAsync()
		{
			WheelTowerResultBossList.BossSmallItem.<OnBeforeStartAsync>d__2 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<WheelTowerResultBossList.BossSmallItem.<OnBeforeStartAsync>d__2>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06047816 RID: 292886 RVA: 0x0130E593 File Offset: 0x0130C793
		public override void Refresh(IBossItemData data, bool isSelected, int gridIndex)
		{
			WheelTowerBossItem bossItem = this.BossItem;
			if (bossItem != null)
			{
				bossItem.Refresh(data, isSelected, gridIndex);
			}
			WheelTowerBossItem bossItem2 = this.BossItem;
			if (bossItem2 == null)
			{
				return;
			}
			bossItem2.SetTagVisible(false);
		}

		// Token: 0x04029DDB RID: 171483
		[Nullable(2)]
		private WheelTowerBossItem BossItem;
	}
}
