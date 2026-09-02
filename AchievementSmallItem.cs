using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02000FF0 RID: 4080
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class AchievementSmallItem : GridProxyAbstract<AchievementData>
{
	// Token: 0x06006966 RID: 26982 RVA: 0x001B7564 File Offset: 0x001B5764
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITextureTransitionComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06006967 RID: 26983 RVA: 0x001B76D0 File Offset: 0x001B58D0
	protected override void OnStart()
	{
		this.AddEventListener();
	}

	// Token: 0x06006968 RID: 26984 RVA: 0x001B76D8 File Offset: 0x001B58D8
	protected void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnAchievementDataWithIdNotify, new Action<int>(this.OnAchievementDataWithIdNotify));
	}

	// Token: 0x06006969 RID: 26985 RVA: 0x001B76F6 File Offset: 0x001B58F6
	protected void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAchievementDataWithIdNotify, new Action<int>(this.OnAchievementDataWithIdNotify));
	}

	// Token: 0x0600696A RID: 26986 RVA: 0x001B7714 File Offset: 0x001B5914
	public override void Refresh(AchievementData data, bool isSelected, int gridIndex)
	{
		this.AchievementData = data;
		base.GridIndex = gridIndex;
		this.RefreshUi(data);
	}

	// Token: 0x0600696B RID: 26987 RVA: 0x001B772C File Offset: 0x001B592C
	private void RefreshUi(AchievementData data)
	{
		EAchievementStateEnum finishState = data.GetFinishState();
		base.GetText(0).SetText(data.GetTitle(), true);
		base.GetItem(3).SetUIActive(data.RedPoint());
		base.GetItem(2).SetUIActive(finishState == EAchievementStateEnum.CanGetReward);
		base.GetItem(4).SetUIActive(finishState == EAchievementStateEnum.CanGetReward);
		base.GetItem(5).SetUIActive(finishState == EAchievementStateEnum.HaveGetReward);
		AchievementGroupData achievementGroupData = ModelBase<AchievementModel>.Instance.GetAchievementGroupData(new int?(this.AchievementData.GetGroupId()));
		if (!StringUtils.IsEmpty(achievementGroupData.GetSmallIcon()))
		{
			base.SetTextureByPath(achievementGroupData.GetSmallIcon(), base.GetTexture(1), null, delegate(bool _)
			{
				base.GetUiTextureTransitionComponent(7).SetAllStateTexture(base.GetTexture(1).GetTexture());
			});
		}
	}

	// Token: 0x0600696C RID: 26988 RVA: 0x001B77E8 File Offset: 0x001B59E8
	private void OnAchievementDataWithIdNotify(int id)
	{
		AchievementData achievementData = this.AchievementData;
		int? num = (achievementData != null) ? new int?(achievementData.GetId()) : null;
		if (id == num.GetValueOrDefault() & num != null)
		{
			this.RefreshUi(this.AchievementData);
		}
	}

	// Token: 0x0600696D RID: 26989 RVA: 0x001B7838 File Offset: 0x001B5A38
	private void OnClickButton()
	{
		Action<int> onClickButtonCallback = this.OnClickButtonCallback;
		if (onClickButtonCallback != null)
		{
			onClickButtonCallback(base.GridIndex);
		}
		if (this.AchievementData != null)
		{
			AchievementGroupData achievementGroupData = ModelBase<AchievementModel>.Instance.GetAchievementGroupData(new int?(this.AchievementData.GetGroupId()));
			AchievementCategoryData category = ModelBase<AchievementModel>.Instance.GetCategory(achievementGroupData.GetCategory());
			ControllerBase<AchievementController>.Instance.OpenAchievementDetailView(category.GetId(), new int?(this.AchievementData.GetGroupId()), this.AchievementData.GetId());
		}
	}

	// Token: 0x0600696E RID: 26990 RVA: 0x001B78BB File Offset: 0x001B5ABB
	protected override void OnBeforeDestroy()
	{
		this.RemoveEventListener();
	}

	// Token: 0x04003211 RID: 12817
	[Nullable(2)]
	private AchievementData AchievementData;

	// Token: 0x04003212 RID: 12818
	[Nullable(2)]
	public Action<int> OnClickButtonCallback;

	// Token: 0x020073D3 RID: 29651
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x04028123 RID: 164131
		Desc,
		// Token: 0x04028124 RID: 164132
		Icon,
		// Token: 0x04028125 RID: 164133
		ReceiveFrameObj,
		// Token: 0x04028126 RID: 164134
		RedPoint,
		// Token: 0x04028127 RID: 164135
		ArrowObj,
		// Token: 0x04028128 RID: 164136
		ReceivedObj,
		// Token: 0x04028129 RID: 164137
		ConfirmButton,
		// Token: 0x0402812A RID: 164138
		IconTransition
	}
}
