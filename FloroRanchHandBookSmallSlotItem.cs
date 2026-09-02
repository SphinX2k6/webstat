using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001C60 RID: 7264
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class FloroRanchHandBookSmallSlotItem : GridProxyAbstract<FloroRanchUnlockDataBase>
{
	// Token: 0x0600D3FB RID: 54267 RVA: 0x00388444 File Offset: 0x00386644
	protected unsafe override void OnRegisterComponent()
	{
		int num = 17;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D3FC RID: 54268 RVA: 0x003886E4 File Offset: 0x003868E4
	protected override UniTask OnBeforeStartAsync()
	{
		FloroRanchHandBookSmallSlotItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FloroRanchHandBookSmallSlotItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D3FD RID: 54269 RVA: 0x00388728 File Offset: 0x00386928
	protected override void OnStart()
	{
		UUIItem item = base.GetItem(3);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIItem item2 = base.GetItem(5);
		if (item2 != null)
		{
			item2.SetUIActive(false);
		}
		UUISprite sprite = base.GetSprite(7);
		if (sprite != null)
		{
			sprite.SetUIActive(false);
		}
		UUISprite sprite2 = base.GetSprite(9);
		if (sprite2 == null)
		{
			return;
		}
		sprite2.SetUIActive(false);
	}

	// Token: 0x0600D3FE RID: 54270 RVA: 0x00388781 File Offset: 0x00386981
	public void SetActivityDataType(EFloroRanchActivityDataType type)
	{
		this.ActivityDataType = type;
	}

	// Token: 0x0600D3FF RID: 54271 RVA: 0x0038878C File Offset: 0x0038698C
	public override UniTask RefreshAsync(FloroRanchUnlockDataBase data, bool isSelected, int gridIndex)
	{
		FloroRanchHandBookSmallSlotItem.<RefreshAsync>d__9 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.data = data;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<FloroRanchHandBookSmallSlotItem.<RefreshAsync>d__9>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D400 RID: 54272 RVA: 0x003887D8 File Offset: 0x003869D8
	private void OnToggleClick(EToggleState _)
	{
		FloroRanchUnlockCardData floroRanchUnlockCardData = this.Data as FloroRanchUnlockCardData;
		if (floroRanchUnlockCardData != null)
		{
			FloroRanchCardData cardData = floroRanchUnlockCardData.GetCardData();
			if (cardData != null)
			{
				Singleton<AudioSystem>.Instance.PostEvent(cardData.Video);
			}
		}
		Action<FloroRanchHandBookSmallSlotItem> onClickCallback = this.OnClickCallback;
		if (onClickCallback == null)
		{
			return;
		}
		onClickCallback(this);
	}

	// Token: 0x0600D401 RID: 54273 RVA: 0x00388820 File Offset: 0x00386A20
	public void BindClickCallback(Action<FloroRanchHandBookSmallSlotItem> callback)
	{
		this.OnClickCallback = callback;
	}

	// Token: 0x0600D402 RID: 54274 RVA: 0x0038882C File Offset: 0x00386A2C
	public override void OnSelected(bool fireEvent)
	{
		UUIItem item = base.GetItem(13);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
		if (!this.Data.IsUnLock)
		{
			return;
		}
		FloroRanchActivityData activityData = ModelBase<FloroRanchModel>.Instance.GetActivityData(this.ActivityDataType, true);
		if (activityData == null)
		{
			return;
		}
		activityData.MarkUnlockDataAsViewed(this.Data);
	}

	// Token: 0x0600D403 RID: 54275 RVA: 0x0038888C File Offset: 0x00386A8C
	public override void OnDeselected(bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x040064D6 RID: 25814
	public FloroRanchUnlockDataBase Data;

	// Token: 0x040064D7 RID: 25815
	private EFloroRanchActivityDataType ActivityDataType;

	// Token: 0x040064D8 RID: 25816
	private FloroRanchToyLevelItem LevelItem;

	// Token: 0x040064D9 RID: 25817
	private Action<FloroRanchHandBookSmallSlotItem> OnClickCallback = delegate(FloroRanchHandBookSmallSlotItem item)
	{
	};

	// Token: 0x02007F76 RID: 32630
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402B652 RID: 177746
		public const int Toggle = 0;

		// Token: 0x0402B653 RID: 177747
		public const int QualitySprite = 1;

		// Token: 0x0402B654 RID: 177748
		public const int IconTexture = 2;

		// Token: 0x0402B655 RID: 177749
		public const int CountDownPanel = 3;

		// Token: 0x0402B656 RID: 177750
		public const int CountdownText = 4;

		// Token: 0x0402B657 RID: 177751
		public const int NumPanel = 5;

		// Token: 0x0402B658 RID: 177752
		public const int NumText = 6;

		// Token: 0x0402B659 RID: 177753
		public const int LockSprite = 7;

		// Token: 0x0402B65A RID: 177754
		public const int HidePanel = 8;

		// Token: 0x0402B65B RID: 177755
		public const int ItemBgSprite = 9;

		// Token: 0x0402B65C RID: 177756
		public const int IconMaskTexture = 10;

		// Token: 0x0402B65D RID: 177757
		public const int UnknownPanel = 11;

		// Token: 0x0402B65E RID: 177758
		public const int ItemPhantomIcon = 12;

		// Token: 0x0402B65F RID: 177759
		public const int ItemNew = 13;

		// Token: 0x0402B660 RID: 177760
		public const int ToyRaceItem = 14;

		// Token: 0x0402B661 RID: 177761
		public const int ToyRaceIcon = 15;

		// Token: 0x0402B662 RID: 177762
		public const int LevelItem = 16;
	}
}
