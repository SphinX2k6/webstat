using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02000FD9 RID: 4057
[NullableContext(1)]
[Nullable(0)]
public class AchievementCompleteTipsView : UiTickViewBase
{
	// Token: 0x0600687F RID: 26751 RVA: 0x001B39CC File Offset: 0x001B1BCC
	public AchievementCompleteTipsView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06006880 RID: 26752 RVA: 0x001B39F4 File Offset: 0x001B1BF4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x06006881 RID: 26753 RVA: 0x001B3A64 File Offset: 0x001B1C64
	protected override void OnStart()
	{
		AchievementData achievementData = this.OpenParam as AchievementData;
		if (achievementData == null)
		{
			return;
		}
		this.StarLayout = new GenericLayout<AchievementCompleteTipsStarItem, bool>(base.GetHorizontalLayout(2), new Func<AchievementCompleteTipsStarItem>(this.CreateStarItem), null, false, true);
		int groupId = achievementData.GetGroupId();
		AchievementGroupData achievementGroupData = ModelBase<AchievementModel>.Instance.GetAchievementGroupData(new int?(groupId));
		if (!StringUtils.IsEmpty(achievementGroupData.GetTexture()))
		{
			base.SetTextureByPath(achievementGroupData.GetTexture(), base.GetTexture(0), null, null);
		}
		base.GetText(1).SetText(achievementData.GetTitle(), true);
		this.RefreshStarLayout(achievementData);
	}

	// Token: 0x06006882 RID: 26754 RVA: 0x001B3B00 File Offset: 0x001B1D00
	protected override void OnBeforeShow()
	{
		if (this.CloseTimerDown < this.TimeLessClose && !this.IsShowFirst)
		{
			this.CloseTimerDown = 0f;
			this.UiViewSequence.PlaySequence("Start", false, null);
		}
		this.IsShowFirst = false;
	}

	// Token: 0x06006883 RID: 26755 RVA: 0x001B3B4F File Offset: 0x001B1D4F
	protected override void OnTick(float delta)
	{
		if (this.HaveClosed)
		{
			return;
		}
		this.CloseTimerDown += delta;
		if (this.CloseTimerDown >= this.TimeToClose)
		{
			this.HaveClosed = true;
			base.CloseMe(null);
		}
	}

	// Token: 0x06006884 RID: 26756 RVA: 0x001B3B84 File Offset: 0x001B1D84
	private void RefreshStarLayout(AchievementData achievementData)
	{
		List<bool> list = new List<bool>();
		int maxStar = achievementData.GetMaxStar();
		int achievementConfigStar = achievementData.GetAchievementConfigStar();
		for (int i = 0; i < maxStar; i++)
		{
			bool item = achievementConfigStar > i;
			list.Add(item);
		}
		this.StarLayout.RefreshByData(list, null, false);
	}

	// Token: 0x06006885 RID: 26757 RVA: 0x001B3BCD File Offset: 0x001B1DCD
	private AchievementCompleteTipsStarItem CreateStarItem()
	{
		return new AchievementCompleteTipsStarItem();
	}

	// Token: 0x040031BD RID: 12733
	private readonly float TimeToClose = 4000f;

	// Token: 0x040031BE RID: 12734
	private readonly float TimeLessClose = 1500f;

	// Token: 0x040031BF RID: 12735
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<AchievementCompleteTipsStarItem, bool> StarLayout;

	// Token: 0x040031C0 RID: 12736
	private float CloseTimerDown;

	// Token: 0x040031C1 RID: 12737
	private bool IsShowFirst = true;

	// Token: 0x040031C2 RID: 12738
	private bool HaveClosed;

	// Token: 0x020073B4 RID: 29620
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402808F RID: 163983
		AchievementIcon,
		// Token: 0x04028090 RID: 163984
		AchievementName,
		// Token: 0x04028091 RID: 163985
		LayoutRoot,
		// Token: 0x04028092 RID: 163986
		AchievementStarObj
	}
}
