using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02000FDD RID: 4061
public class AchievementFinishView : UiViewBase
{
	// Token: 0x060068B8 RID: 26808 RVA: 0x001B4A19 File Offset: 0x001B2C19
	[NullableContext(1)]
	public AchievementFinishView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x060068B9 RID: 26809 RVA: 0x001B4A2C File Offset: 0x001B2C2C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060068BA RID: 26810 RVA: 0x001B4A98 File Offset: 0x001B2C98
	protected override void OnBeforeShow()
	{
		int id = ModelBase<AchievementModel>.Instance.CurrentFinishAchievementArray[0];
		ModelBase<AchievementModel>.Instance.CurrentFinishAchievementArray.RemoveAt(0);
		this.AchievementData = ModelBase<AchievementModel>.Instance.GetAchievementData(id);
		this.RefreshTexture();
		this.RefreshDesc();
		this.ClearTimer();
		this.Ticker = Singleton<TickSystem>.Instance.Add(new Action<float>(this.OnTick), "Achievement", ETickingGroup.TG_PrePhysics, true, 0, true).Id;
	}

	// Token: 0x060068BB RID: 26811 RVA: 0x001B4B14 File Offset: 0x001B2D14
	private void RefreshTexture()
	{
		int groupId = this.AchievementData.GetGroupId();
		AchievementGroupData achievementGroupData = ModelBase<AchievementModel>.Instance.GetAchievementGroupData(new int?(groupId));
		if (!StringUtils.IsEmpty(achievementGroupData.GetTexture()))
		{
			base.SetTextureByPath(achievementGroupData.GetTexture(), base.GetTexture(0), null, null);
		}
	}

	// Token: 0x060068BC RID: 26812 RVA: 0x001B4B68 File Offset: 0x001B2D68
	private void RefreshDesc()
	{
		base.GetText(1).SetText(this.AchievementData.GetTitle(), true);
	}

	// Token: 0x060068BD RID: 26813 RVA: 0x001B4B82 File Offset: 0x001B2D82
	private void OnTick(float deltaTime)
	{
		this.CurrentRunningTime += deltaTime;
		if (this.CurrentRunningTime >= 4000f)
		{
			base.CloseMe(null);
			this.ClearTimer();
		}
	}

	// Token: 0x060068BE RID: 26814 RVA: 0x001B4BAC File Offset: 0x001B2DAC
	private void ClearTimer()
	{
		this.CurrentRunningTime = 0f;
		if (this.Ticker != -1)
		{
			Singleton<TickSystem>.Instance.Remove(this.Ticker);
			this.Ticker = -1;
		}
	}

	// Token: 0x060068BF RID: 26815 RVA: 0x001B4BDA File Offset: 0x001B2DDA
	protected override void OnBeforeDestroy()
	{
		this.ClearTimer();
	}

	// Token: 0x040031D3 RID: 12755
	[Nullable(2)]
	private AchievementData AchievementData;

	// Token: 0x040031D4 RID: 12756
	private int Ticker = -1;

	// Token: 0x040031D5 RID: 12757
	private float CurrentRunningTime;

	// Token: 0x020073BC RID: 29628
	private enum EComponents
	{
		// Token: 0x040280BE RID: 164030
		Texture,
		// Token: 0x040280BF RID: 164031
		Desc
	}
}
