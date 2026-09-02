using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02000FE7 RID: 4071
[NullableContext(1)]
[Nullable(0)]
public class AchievementProgressItem : UiPanelBase
{
	// Token: 0x0600690D RID: 26893 RVA: 0x001B618C File Offset: 0x001B438C
	public AchievementProgressItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600690E RID: 26894 RVA: 0x001B61A4 File Offset: 0x001B43A4
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

	// Token: 0x0600690F RID: 26895 RVA: 0x001B6230 File Offset: 0x001B4430
	public void RefreshGroupState(AchievementGroupData data)
	{
		base.GetItem(0).SetUIActive(false);
		base.GetItem(1).SetUIActive(false);
		base.GetText(2).SetUIActive(false);
		if (data.GetFinishState() == EAchievementStateEnum.HaveGetReward)
		{
			base.GetItem(0).SetUIActive(true);
			base.GetText(2).SetUIActive(true);
			base.GetText(2).SetText(Singleton<TimeUtil>.Instance.DateFormat4(new DateTime((data.GetFinishTime() * (long)Singleton<TimeUtil>.Instance.InverseMillisecond).Value)), true);
			return;
		}
		if (data.GetFinishState() == EAchievementStateEnum.UnFinished)
		{
			base.GetItem(1).SetUIActive(true);
		}
	}

	// Token: 0x06006910 RID: 26896 RVA: 0x001B62F8 File Offset: 0x001B44F8
	public void RefreshState(AchievementData data)
	{
		base.GetItem(0).SetUIActive(false);
		base.GetItem(1).SetUIActive(false);
		base.GetText(2).SetUIActive(false);
		if (data.GetFinishState() == EAchievementStateEnum.HaveGetReward)
		{
			base.GetItem(0).SetUIActive(true);
			base.GetText(2).SetUIActive(true);
			return;
		}
		if (data.GetFinishState() == EAchievementStateEnum.UnFinished)
		{
			base.GetItem(1).SetUIActive(true);
		}
	}

	// Token: 0x020073C5 RID: 29637
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x040280EA RID: 164074
		FinishIcon,
		// Token: 0x040280EB RID: 164075
		ProgressingText,
		// Token: 0x040280EC RID: 164076
		FinishText
	}
}
