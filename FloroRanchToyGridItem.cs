using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001C74 RID: 7284
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchToyGridItem : UiPanelBase
{
	// Token: 0x0600D495 RID: 54421 RVA: 0x0038BE68 File Offset: 0x0038A068
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

	// Token: 0x0600D496 RID: 54422 RVA: 0x0038C106 File Offset: 0x0038A306
	protected override void OnBeforeCreate()
	{
		this.UiLevelSequence = new UiBehaviorLevelSequence(this);
		base.AddUiBehavior(this.UiLevelSequence);
	}

	// Token: 0x0600D497 RID: 54423 RVA: 0x0038C120 File Offset: 0x0038A320
	protected override UniTask OnBeforeStartAsync()
	{
		FloroRanchToyGridItem.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FloroRanchToyGridItem.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D498 RID: 54424 RVA: 0x0038C163 File Offset: 0x0038A363
	protected override void OnStart()
	{
		this.SetInfoPanelActive(false);
		base.GetExtendToggle(0).SetSelfInteractive(false);
	}

	// Token: 0x0600D499 RID: 54425 RVA: 0x0038C17C File Offset: 0x0038A37C
	private void OnToggleClick(EToggleState toggleState)
	{
		FloroRanchEntityBase entity = this.Entity;
		FloroRanchEntityDataComponent floroRanchEntityDataComponent = (entity != null) ? entity.CheckGetComponent<FloroRanchEntityDataComponent>() : null;
		int obj = (floroRanchEntityDataComponent != null) ? floroRanchEntityDataComponent.Point : -1;
		Action<int> onClickCallback = this.OnClickCallback;
		if (onClickCallback == null)
		{
			return;
		}
		onClickCallback(obj);
	}

	// Token: 0x0600D49A RID: 54426 RVA: 0x0038C1B9 File Offset: 0x0038A3B9
	public void BindClickCallback(Action<int> callback)
	{
		this.OnClickCallback = callback;
	}

	// Token: 0x0600D49B RID: 54427 RVA: 0x0038C1C4 File Offset: 0x0038A3C4
	public void RefreshItemGrid(FloroRanchEntityBase entity)
	{
		if (entity == null)
		{
			this.SetInfoPanelActive(false);
			return;
		}
		this.Entity = entity;
		FloroRanchEntityDataComponent floroRanchEntityDataComponent = entity.CheckGetComponent<FloroRanchEntityDataComponent>();
		FloroRanchToyDataComponent floroRanchToyDataComponent = entity.CheckGetComponent<FloroRanchToyDataComponent>();
		FloroRanchToyData floroRanchToyData = (floroRanchToyDataComponent != null) ? floroRanchToyDataComponent.ToyData : null;
		base.GetItem(3).SetUIActive(false);
		FloroRanchRarityData toyQualityData = floroRanchToyData.GetToyQualityData();
		if (toyQualityData != null)
		{
			this.SetSpriteByPath(toyQualityData.GetRaritySmallBg(), base.GetSprite(1), true, null, null);
		}
		bool isUnique = floroRanchToyData.GetIsUnique();
		int num = (floroRanchEntityDataComponent != null) ? floroRanchEntityDataComponent.Count : 1;
		if (!isUnique)
		{
			base.GetText(6).SetText(num.ToString(), true);
		}
		base.GetItem(5).SetUIActive(!isUnique && num > 1);
		base.SetTextureByPath(floroRanchToyData.GetIcon(), base.GetTexture(2), null, null);
		FloroRanchActivityData currentActivityData = ModelBase<FloroRanchGamePlayModel>.Instance.GetCurrentActivityData();
		bool flag = currentActivityData == null || currentActivityData.IsToyUnlocked(floroRanchToyData.Id);
		base.GetSprite(7).SetUIActive(!flag);
		this.SetInfoPanelActive(true);
		base.GetExtendToggle(0).SetSelfInteractive(true);
		FloroRanchRaceData toyRaceData = floroRanchToyData.GetToyRaceData();
		if (toyRaceData != null)
		{
			UUIItem item = base.GetItem(14);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			base.SetTextureShowUntilLoaded(toyRaceData.SmallIcon, base.GetTexture(15), null);
		}
		else
		{
			UUIItem item2 = base.GetItem(14);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
		}
		int level = floroRanchToyDataComponent.Level;
		if (level > 0)
		{
			this.ToyLevelItem.Refresh(level);
			this.ToyLevelItem.SetActive(true);
			return;
		}
		this.ToyLevelItem.SetActive(false);
	}

	// Token: 0x0600D49C RID: 54428 RVA: 0x0038C356 File Offset: 0x0038A556
	public void SetInfoPanelActive(bool isActive)
	{
		base.GetItem(8).SetUIActive(isActive);
		base.GetExtendToggle(0).SetSelfInteractive(isActive);
	}

	// Token: 0x0600D49D RID: 54429 RVA: 0x0038C374 File Offset: 0x0038A574
	public void PlayShowAnim(FloroRanchEntityBase entity)
	{
		this.RefreshItemGrid(entity);
		if (this.UiLevelSequence.IsInSequence())
		{
			this.UiLevelSequence.StopPrevSequence(false, true);
		}
		this.UiLevelSequence.PlaySequence("Start", false, new float?((float)ModelBase<FloroRanchGamePlayModel>.Instance.GetTimeDilation()));
	}

	// Token: 0x0600D49E RID: 54430 RVA: 0x0038C3C3 File Offset: 0x0038A5C3
	public void SetSelectState(bool isSelect)
	{
		base.GetExtendToggle(0).SetToggleState(isSelect ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0400651E RID: 25886
	private FloroRanchEntityBase Entity;

	// Token: 0x0400651F RID: 25887
	public UiBehaviorLevelSequence UiLevelSequence;

	// Token: 0x04006520 RID: 25888
	public FloroRanchToyLevelItem ToyLevelItem;

	// Token: 0x04006521 RID: 25889
	private Action<int> OnClickCallback = delegate(int point)
	{
	};

	// Token: 0x02007FA2 RID: 32674
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402B730 RID: 177968
		public const int Toggle = 0;

		// Token: 0x0402B731 RID: 177969
		public const int QualitySprite = 1;

		// Token: 0x0402B732 RID: 177970
		public const int IconTexture = 2;

		// Token: 0x0402B733 RID: 177971
		public const int CountDownPanel = 3;

		// Token: 0x0402B734 RID: 177972
		public const int CountdownText = 4;

		// Token: 0x0402B735 RID: 177973
		public const int NumPanel = 5;

		// Token: 0x0402B736 RID: 177974
		public const int NumText = 6;

		// Token: 0x0402B737 RID: 177975
		public const int LockSprite = 7;

		// Token: 0x0402B738 RID: 177976
		public const int InfoPanel = 8;

		// Token: 0x0402B739 RID: 177977
		public const int BgSprite = 9;

		// Token: 0x0402B73A RID: 177978
		public const int IconMaskTexture = 10;

		// Token: 0x0402B73B RID: 177979
		public const int UnknownPanel = 11;

		// Token: 0x0402B73C RID: 177980
		public const int ItemPhantomIcon = 12;

		// Token: 0x0402B73D RID: 177981
		public const int ItemNew = 13;

		// Token: 0x0402B73E RID: 177982
		public const int ToyRaceItem = 14;

		// Token: 0x0402B73F RID: 177983
		public const int ToyRaceIcon = 15;

		// Token: 0x0402B740 RID: 177984
		public const int ToyLevelItem = 16;
	}
}
