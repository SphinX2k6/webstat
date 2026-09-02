using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002201 RID: 8705
public class LordGymLordEntranceItem : GridProxyAbstract<int>
{
	// Token: 0x060106D6 RID: 67286 RVA: 0x0047D1E4 File Offset: 0x0047B3E4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIExtendToggle))
		};
		if (this.OnToggleClick != null)
		{
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(3, new Action<EToggleState>(this.<OnRegisterComponent>g__CallBack|5_0))
			};
		}
	}

	// Token: 0x060106D7 RID: 67287 RVA: 0x0047D280 File Offset: 0x0047B480
	protected override void OnStart()
	{
		if (this.CanExecuteChangeCallBack != null)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(3);
			if (extendToggle != null)
			{
				extendToggle.CanExecuteChange.Bind(delegate()
				{
					Func<int, bool> canExecuteChangeCallBack = this.CanExecuteChangeCallBack;
					return canExecuteChangeCallBack == null || canExecuteChangeCallBack(base.GridIndex);
				});
			}
		}
		this.StarLayout = new GenericLayout<LordGymLordStarItem, bool>(base.GetHorizontalLayout(1), new Func<LordGymLordStarItem>(this.CreateStarItem), null, false, true);
	}

	// Token: 0x060106D8 RID: 67288 RVA: 0x0047D2DC File Offset: 0x0047B4DC
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.LordEntranceId = data;
		LordGymEntrance? lordGymEntranceConfig = ConfigBase<LordGymConfig>.Instance.GetLordGymEntranceConfig(this.LordEntranceId);
		if (lordGymEntranceConfig == null)
		{
			return;
		}
		int[] array = lordGymEntranceConfig.Value.LordGymList();
		if (array.Length == 0)
		{
			return;
		}
		LordGym? lordGymConfig = ConfigBase<LordGymConfig>.Instance.GetLordGymConfig(array[0]);
		if (lordGymConfig == null)
		{
			return;
		}
		LordGym value = lordGymConfig.Value;
		if (value.MonsterListLength == 0)
		{
			return;
		}
		MonsterInfo? config = ConfigMonsterInfoById.GetConfig(value.MonsterList(0), true);
		if (config == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), config.Value.Name, Array.Empty<object>());
		base.SetTextureByPath(config.Value.BigIcon, base.GetTexture(2), null, null);
		List<bool> list = new List<bool>(array.Length);
		for (int i = 0; i < array.Length; i++)
		{
			list.Add(ModelBase<LordGymModel>.Instance.GetLordGymIsFinish(array[i]));
		}
		GenericLayout<LordGymLordStarItem, bool> starLayout = this.StarLayout;
		if (starLayout != null)
		{
			starLayout.RefreshByData(list, null, false);
		}
		EToggleState state = isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		UUIExtendToggle extendToggle = base.GetExtendToggle(3);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(state, false, false, false);
	}

	// Token: 0x060106D9 RID: 67289 RVA: 0x0047D419 File Offset: 0x0047B619
	public override void OnSelected(bool fireEvent)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(3);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x060106DA RID: 67290 RVA: 0x0047D431 File Offset: 0x0047B631
	public override void OnDeselected(bool fireEvent)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(3);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x060106DB RID: 67291 RVA: 0x0047D449 File Offset: 0x0047B649
	[NullableContext(1)]
	private LordGymLordStarItem CreateStarItem()
	{
		return new LordGymLordStarItem();
	}

	// Token: 0x060106DC RID: 67292 RVA: 0x0047D450 File Offset: 0x0047B650
	public int GetLordEntranceId()
	{
		return this.LordEntranceId;
	}

	// Token: 0x060106DE RID: 67294 RVA: 0x0047D460 File Offset: 0x0047B660
	[CompilerGenerated]
	private void <OnRegisterComponent>g__CallBack|5_0(EToggleState state)
	{
		Action<int> onToggleClick = this.OnToggleClick;
		if (onToggleClick == null)
		{
			return;
		}
		onToggleClick(base.GridIndex);
	}

	// Token: 0x0400816C RID: 33132
	private int LordEntranceId;

	// Token: 0x0400816D RID: 33133
	[Nullable(2)]
	public Action<int> OnToggleClick;

	// Token: 0x0400816E RID: 33134
	[Nullable(2)]
	public Func<int, bool> CanExecuteChangeCallBack;

	// Token: 0x0400816F RID: 33135
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<LordGymLordStarItem, bool> StarLayout;

	// Token: 0x020084D1 RID: 34001
	private class EComponent
	{
		// Token: 0x0402CFF5 RID: 184309
		public const int NameText = 0;

		// Token: 0x0402CFF6 RID: 184310
		public const int StarLayout = 1;

		// Token: 0x0402CFF7 RID: 184311
		public const int LordTexture = 2;

		// Token: 0x0402CFF8 RID: 184312
		public const int ItemToggle = 3;
	}
}
