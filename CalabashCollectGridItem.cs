using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020017EE RID: 6126
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CalabashCollectGridItem : GridProxyAbstract<CalabashDevelopRewardData>
{
	// Token: 0x0600AE1D RID: 44573 RVA: 0x002E4BA0 File Offset: 0x002E2DA0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout))
		};
		Action<EToggleState> item = delegate(EToggleState toggleState)
		{
			Action<int> onToggleClick = this.OnToggleClick;
			if (onToggleClick == null)
			{
				return;
			}
			onToggleClick(base.GridIndex);
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, item)
		};
	}

	// Token: 0x0600AE1E RID: 44574 RVA: 0x002E4C4C File Offset: 0x002E2E4C
	protected override UniTask OnBeforeStartAsync()
	{
		CalabashCollectGridItem.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CalabashCollectGridItem.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600AE1F RID: 44575 RVA: 0x002E4C8F File Offset: 0x002E2E8F
	[NullableContext(1)]
	private CalabashCollectStarItem CreateStarItem()
	{
		return new CalabashCollectStarItem();
	}

	// Token: 0x0600AE20 RID: 44576 RVA: 0x002E4C98 File Offset: 0x002E2E98
	[NullableContext(1)]
	public override void Refresh(CalabashDevelopRewardData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		int monsterId = data.DevelopRewardData.MonsterId;
		ICalabashDevelopRewardInfoData[] calabashDevelopRewardInfoData = ModelBase<CalabashModel>.Instance.GetCalabashDevelopRewardInfoData(monsterId);
		List<bool> list = new List<bool>();
		int num = 0;
		ICalabashDevelopRewardInfoData[] array = calabashDevelopRewardInfoData;
		for (int i = 0; i < array.Length; i++)
		{
			bool isUnlock = array[i].IsUnlock;
			list.Add(isUnlock);
			if (isUnlock)
			{
				num++;
			}
		}
		if (data.UnlockData)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), data.SkillName, Array.Empty<object>());
		}
		else
		{
			string monsterNumber = ConfigBase<CalabashConfig>.Instance.GetCalabashDevelopRewardByMonsterId(monsterId).Value.MonsterNumber;
			UUIText text = base.GetText(2);
			if (text != null)
			{
				text.SetText(monsterNumber + "???", true);
			}
		}
		this.MonsterItem.Refresh(new VisionDetailMonsterItemData(data.DevelopRewardData.MonsterId, num, 0), false, 0);
		GenericLayout<CalabashCollectStarItem, bool> starLayout = this.StarLayout;
		if (starLayout != null)
		{
			starLayout.RefreshByData(list, null, false);
		}
		EToggleState state = isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleStateForce(state, false, false, false);
		}
		if (isSelected)
		{
			CalabashModel instance = ModelBase<CalabashModel>.Instance;
			if (instance != null)
			{
				instance.RecordMonsterId(monsterId);
			}
		}
		this.RefreshNewItem();
	}

	// Token: 0x0600AE21 RID: 44577 RVA: 0x002E4DD4 File Offset: 0x002E2FD4
	public override void OnSelected(bool fireEvent)
	{
		int monsterId = this.Data.DevelopRewardData.MonsterId;
		if (this.NewState)
		{
			CalabashModel instance = ModelBase<CalabashModel>.Instance;
			if (instance != null)
			{
				instance.RecordMonsterId(monsterId);
			}
			this.RefreshNewItem();
		}
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x0600AE22 RID: 44578 RVA: 0x002E4E26 File Offset: 0x002E3026
	public override void OnDeselected(bool fireEvent)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0600AE23 RID: 44579 RVA: 0x002E4E40 File Offset: 0x002E3040
	public void RefreshNewItem()
	{
		this.NewState = (this.Data.UnlockData && !ModelBase<CalabashModel>.Instance.CheckMonsterIdInRecord(this.Data.DevelopRewardData.MonsterId));
		base.GetItem(3).SetUIActive(this.NewState);
	}

	// Token: 0x0400526B RID: 21099
	private CalabashDevelopRewardData Data;

	// Token: 0x0400526C RID: 21100
	private VisionDetailMonsterItem MonsterItem;

	// Token: 0x0400526D RID: 21101
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<CalabashCollectStarItem, bool> StarLayout;

	// Token: 0x0400526E RID: 21102
	private bool NewState;

	// Token: 0x0400526F RID: 21103
	public Func<int, bool> CanToggleChange;

	// Token: 0x04005270 RID: 21104
	public Action<int> OnToggleClick;

	// Token: 0x02007B66 RID: 31590
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402A2F4 RID: 172788
		Toggle,
		// Token: 0x0402A2F5 RID: 172789
		MonsterItem,
		// Token: 0x0402A2F6 RID: 172790
		NameText,
		// Token: 0x0402A2F7 RID: 172791
		NewItem,
		// Token: 0x0402A2F8 RID: 172792
		StarLayout
	}
}
