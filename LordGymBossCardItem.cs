using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.AutoAttach;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001373 RID: 4979
[NullableContext(1)]
[Nullable(0)]
public class LordGymBossCardItem : AutoAttachItem<int>
{
	// Token: 0x06008877 RID: 34935 RVA: 0x0023FCD0 File Offset: 0x0023DED0
	[NullableContext(2)]
	public LordGymBossCardItem(AActor uiItem = null) : base(uiItem)
	{
	}

	// Token: 0x06008878 RID: 34936 RVA: 0x0023FCE4 File Offset: 0x0023DEE4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06008879 RID: 34937 RVA: 0x0023FDD1 File Offset: 0x0023DFD1
	private LordGymLordStarItem CreateStarItem()
	{
		return new LordGymLordStarItem();
	}

	// Token: 0x0600887A RID: 34938 RVA: 0x0023FDD8 File Offset: 0x0023DFD8
	public void BindOnSelected(Action<int> onSelected)
	{
		this.OnSelectedCallback = onSelected;
	}

	// Token: 0x0600887B RID: 34939 RVA: 0x0023FDE1 File Offset: 0x0023DFE1
	public override void OnSelect()
	{
		if (this.OnSelectedCallback != null)
		{
			this.OnSelectedCallback(base.GetCurrentShowItemIndex());
		}
	}

	// Token: 0x0600887C RID: 34940 RVA: 0x0023FDFC File Offset: 0x0023DFFC
	protected override void OnUnSelect()
	{
	}

	// Token: 0x0600887D RID: 34941 RVA: 0x0023FDFE File Offset: 0x0023DFFE
	protected override void OnMoveItem()
	{
	}

	// Token: 0x0600887E RID: 34942 RVA: 0x0023FE00 File Offset: 0x0023E000
	protected override void OnRefreshItem(int id)
	{
		LordGymEntrance? lordGymEntranceConfig = ConfigBase<LordGymConfig>.Instance.GetLordGymEntranceConfig(id);
		if (lordGymEntranceConfig == null)
		{
			return;
		}
		LordGymEntrance value = lordGymEntranceConfig.Value;
		if (value.LordGymListLength == 0)
		{
			return;
		}
		LordGym? lordGymConfig = ConfigBase<LordGymConfig>.Instance.GetLordGymConfig(value.LordGymList(0));
		if (lordGymConfig == null)
		{
			return;
		}
		LordGym value2 = lordGymConfig.Value;
		if (value2.MonsterListLength == 0)
		{
			return;
		}
		MonsterInfo value3 = ConfigMonsterInfoById.GetConfig(value2.MonsterList(0), true).Value;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), value3.Name, Array.Empty<object>());
		base.SetTextureByPath(value3.BigIcon, base.GetTexture(1), null, null);
		this.StarDataList.Clear();
		for (int i = 0; i < value.LordGymListLength; i++)
		{
			this.StarDataList.Add(ModelBase<LordGymModel>.Instance.GetLordGymIsFinish(value.LordGymList(i)));
		}
		if (this.StarLayout == null)
		{
			this.StarLayout = new GenericLayout<LordGymLordStarItem, bool>(base.GetHorizontalLayout(3), new Func<LordGymLordStarItem>(this.CreateStarItem), null, false, true);
		}
		this.StarLayout.RefreshByData(this.StarDataList, null, false);
	}

	// Token: 0x04004025 RID: 16421
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<LordGymLordStarItem, bool> StarLayout;

	// Token: 0x04004026 RID: 16422
	private List<bool> StarDataList = new List<bool>();

	// Token: 0x04004027 RID: 16423
	[Nullable(2)]
	private Action<int> OnSelectedCallback;

	// Token: 0x02007719 RID: 30489
	[NullableContext(0)]
	private class ECardComponent
	{
		// Token: 0x0402903E RID: 167998
		public const int Btn = 0;

		// Token: 0x0402903F RID: 167999
		public const int Monster = 1;

		// Token: 0x04029040 RID: 168000
		public const int Name = 2;

		// Token: 0x04029041 RID: 168001
		public const int StarLayout = 3;

		// Token: 0x04029042 RID: 168002
		public const int Star = 4;

		// Token: 0x04029043 RID: 168003
		public const int New = 5;
	}
}
