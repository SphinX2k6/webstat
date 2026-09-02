using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020015E8 RID: 5608
public class ActivityTurntableGrid : UiPanelBase
{
	// Token: 0x06009E0B RID: 40459 RVA: 0x00296008 File Offset: 0x00294208
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.ButtonClicked));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06009E0C RID: 40460 RVA: 0x00296134 File Offset: 0x00294334
	[NullableContext(1)]
	public UniTask Refresh(ITurntableReward reward)
	{
		ActivityTurntableGrid.<Refresh>d__7 <Refresh>d__;
		<Refresh>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Refresh>d__.<>4__this = this;
		<Refresh>d__.reward = reward;
		<Refresh>d__.<>1__state = -1;
		<Refresh>d__.<>t__builder.Start<ActivityTurntableGrid.<Refresh>d__7>(ref <Refresh>d__);
		return <Refresh>d__.<>t__builder.Task;
	}

	// Token: 0x06009E0D RID: 40461 RVA: 0x0029617F File Offset: 0x0029437F
	public void SetRewardClaimed(bool isClaimed)
	{
		base.GetTexture(0).SetUIActive(!isClaimed);
		base.GetItem(3).SetUIActive(isClaimed);
		base.GetItem(4).SetUIActive(!isClaimed);
	}

	// Token: 0x06009E0E RID: 40462 RVA: 0x002961B0 File Offset: 0x002943B0
	public void Rotate(float changeAngle)
	{
		float inYaw = base.GetItem(4).RelativeRotation.Yaw + changeAngle;
		UUIItem item = base.GetItem(4);
		FRotator frotator = new FRotator(0f, inYaw, 0f);
		item.SetUIRelativeRotation(frotator);
	}

	// Token: 0x06009E0F RID: 40463 RVA: 0x002961F0 File Offset: 0x002943F0
	private void ButtonClicked()
	{
		if (this.ItemId > 0)
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.ItemId, true, null);
		}
	}

	// Token: 0x040048BD RID: 18621
	public int RewardId;

	// Token: 0x040048BE RID: 18622
	public bool IsGoldenQuality;

	// Token: 0x040048BF RID: 18623
	public bool IsSpecial;

	// Token: 0x040048C0 RID: 18624
	private int ItemId;

	// Token: 0x040048C1 RID: 18625
	private const int REFRESH_LOADING_COUNT = 2;

	// Token: 0x020079AE RID: 31150
	private class EGridComponents
	{
		// Token: 0x04029C9B RID: 171163
		public const int Icon = 0;

		// Token: 0x04029C9C RID: 171164
		public const int SpriteQuality = 1;

		// Token: 0x04029C9D RID: 171165
		public const int TxtCount = 2;

		// Token: 0x04029C9E RID: 171166
		public const int PanelReward = 3;

		// Token: 0x04029C9F RID: 171167
		public const int PanelCount = 4;

		// Token: 0x04029CA0 RID: 171168
		public const int Button = 5;
	}
}
