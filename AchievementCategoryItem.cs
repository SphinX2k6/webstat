using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02000FD7 RID: 4055
[Nullable(new byte[]
{
	0,
	1
})]
public class AchievementCategoryItem : GridProxyAbstract<AchievementCategoryData>
{
	// Token: 0x0600686E RID: 26734 RVA: 0x001B36D4 File Offset: 0x001B18D4
	protected unsafe override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
		int num = 1;
		List<ValueTuple<int, Delegate>> list = new List<ValueTuple<int, Delegate>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list, num);
		Span<ValueTuple<int, Delegate>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickItem));
		this.BtnBindInfo = list;
	}

	// Token: 0x0600686F RID: 26735 RVA: 0x001B3797 File Offset: 0x001B1997
	protected override void OnStart()
	{
		this.AddEventListener();
	}

	// Token: 0x06006870 RID: 26736 RVA: 0x001B379F File Offset: 0x001B199F
	protected void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnAchievementDataNotify, new Action(this.OnAchievementDataNotify));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnAchievementGroupDataNotify, new Action<int>(this.OnAchievementGroupDataNotify));
	}

	// Token: 0x06006871 RID: 26737 RVA: 0x001B37D9 File Offset: 0x001B19D9
	protected void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAchievementDataNotify, new Action(this.OnAchievementDataNotify));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAchievementGroupDataNotify, new Action<int>(this.OnAchievementGroupDataNotify));
	}

	// Token: 0x06006872 RID: 26738 RVA: 0x001B3813 File Offset: 0x001B1A13
	private void OnAchievementGroupDataNotify(int groupId)
	{
		this.RefreshRedPointState();
	}

	// Token: 0x06006873 RID: 26739 RVA: 0x001B381B File Offset: 0x001B1A1B
	private void OnAchievementDataNotify()
	{
		this.RefreshRedPointState();
	}

	// Token: 0x06006874 RID: 26740 RVA: 0x001B3824 File Offset: 0x001B1A24
	private void OnClickItem()
	{
		ModelBase<AchievementModel>.Instance.CurrentSelectCategory = this.CategoryData;
		List<AchievementGroupData> achievementCategoryGroups = ModelBase<AchievementModel>.Instance.GetAchievementCategoryGroups(this.CategoryData.GetId(), true);
		if (achievementCategoryGroups.Count > 0)
		{
			ModelBase<AchievementModel>.Instance.CurrentSelectGroup = achievementCategoryGroups[0];
			ControllerBase<AchievementController>.Instance.OpenAchievementDetailView(this.CategoryData.GetId(), new int?(achievementCategoryGroups[0].GetId()), -1);
			return;
		}
		ModelBase<AchievementModel>.Instance.CurrentSelectGroup = null;
		ControllerBase<AchievementController>.Instance.OpenAchievementDetailView(this.CategoryData.GetId(), null, -1);
	}

	// Token: 0x06006875 RID: 26741 RVA: 0x001B38C4 File Offset: 0x001B1AC4
	[NullableContext(1)]
	public override void Refresh(AchievementCategoryData data, bool isSelected, int gridIndex)
	{
		this.CategoryData = data;
		this.RefreshRedPointState();
		this.RefreshNameText();
		this.RefreshIcon();
		this.RefreshProgressText();
	}

	// Token: 0x06006876 RID: 26742 RVA: 0x001B38E5 File Offset: 0x001B1AE5
	private void RefreshRedPointState()
	{
		base.GetItem(4).SetUIActive(ModelBase<AchievementModel>.Instance.GetCategoryRedPointState(this.CategoryData.GetId()));
	}

	// Token: 0x06006877 RID: 26743 RVA: 0x001B3908 File Offset: 0x001B1B08
	private void RefreshNameText()
	{
		base.GetText(2).SetText(this.CategoryData.GetTitle(), true);
	}

	// Token: 0x06006878 RID: 26744 RVA: 0x001B3922 File Offset: 0x001B1B22
	private void RefreshProgressText()
	{
		base.GetText(3).SetText(this.CategoryData.GetAchievementCategoryProgress(), true);
	}

	// Token: 0x06006879 RID: 26745 RVA: 0x001B393C File Offset: 0x001B1B3C
	private void RefreshIcon()
	{
		if (!StringUtils.IsEmpty(this.CategoryData.GetTexture()))
		{
			base.SetTextureByPath(this.CategoryData.GetTexture(), base.GetTexture(1), null, null);
		}
	}

	// Token: 0x0600687A RID: 26746 RVA: 0x001B397D File Offset: 0x001B1B7D
	protected override void OnBeforeDestroy()
	{
		this.RemoveEventListener();
	}

	// Token: 0x040031BC RID: 12732
	[Nullable(2)]
	private AchievementCategoryData CategoryData;

	// Token: 0x020073B2 RID: 29618
	private enum EChildType
	{
		// Token: 0x04028087 RID: 163975
		Button,
		// Token: 0x04028088 RID: 163976
		Texture,
		// Token: 0x04028089 RID: 163977
		NameText,
		// Token: 0x0402808A RID: 163978
		ProgressText,
		// Token: 0x0402808B RID: 163979
		RedPoint
	}
}
