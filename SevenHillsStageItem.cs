using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001360 RID: 4960
[NullableContext(2)]
[Nullable(0)]
public class SevenHillsStageItem : GridProxyAbstract<int>
{
	// Token: 0x060087E8 RID: 34792 RVA: 0x0023D8F0 File Offset: 0x0023BAF0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 12;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickStageBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(9, new Action(this.OnClickGotoBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060087E9 RID: 34793 RVA: 0x0023DB08 File Offset: 0x0023BD08
	protected override void OnBeforeShow()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshStageState));
		this.AddTimer();
	}

	// Token: 0x060087EA RID: 34794 RVA: 0x0023DB2C File Offset: 0x0023BD2C
	private void AddTimer()
	{
		this.TimerHandle = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
		{
			this.OnRefreshTimer();
		}, 1000f, 1f, null, null, true);
	}

	// Token: 0x060087EB RID: 34795 RVA: 0x0023DB58 File Offset: 0x0023BD58
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.StageId = data;
		LongShanStage value = ConfigLongShanStageById.GetConfig(this.StageId, true).Value;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), value.Title, Array.Empty<object>());
		base.SetTextureByPath(value.Picture, base.GetTexture(1), null, null);
		this.SetSpriteByPath(value.RomeNumSprite, base.GetSprite(2), false, null, null);
		this.RefreshStageState();
		this.RefreshLockText();
	}

	// Token: 0x060087EC RID: 34796 RVA: 0x0023DBE8 File Offset: 0x0023BDE8
	private void RefreshStageState()
	{
		bool flag = !this.ActivityData.IsStageUnlock(this.StageId);
		UUIItem item = base.GetItem(8);
		if (item != null)
		{
			item.SetUIActive(flag);
		}
		bool flag2 = this.ActivityData.IsStageReachOpenTime(this.StageId);
		UUIButtonComponent button = base.GetButton(9);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(flag && flag2);
		}
		UUIItem item2 = base.GetItem(11);
		if (item2 != null)
		{
			item2.SetUIActive(flag && !flag2);
		}
		int progress = this.ActivityData.GetProgress(this.StageId);
		bool flag3 = progress == 100;
		UUIText text = base.GetText(7);
		if (text != null)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(progress);
			defaultInterpolatedStringHandler.AppendLiteral("%");
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}
		UUIItem item3 = base.GetItem(3);
		if (item3 != null)
		{
			item3.SetUIActive(flag3);
		}
		bool useChangeColor = flag || flag3;
		base.GetText(6).useChangeColor = useChangeColor;
		base.GetText(7).useChangeColor = useChangeColor;
		base.GetSprite(5).useChangeColor = useChangeColor;
		UUIItem item4 = base.GetItem(4);
		if (item4 == null)
		{
			return;
		}
		item4.SetUIActive(this.ActivityData.CheckStageRed(this.StageId));
	}

	// Token: 0x060087ED RID: 34797 RVA: 0x0023DD24 File Offset: 0x0023BF24
	private void RefreshLockText()
	{
		if (this.ActivityData.IsStageUnlock(this.StageId))
		{
			this.RefreshStageState();
			this.RemoveTimer();
			return;
		}
		if (this.ActivityData.IsStageReachOpenTime(this.StageId))
		{
			string conditionGroupHintText = LevelGeneralCommons.GetConditionGroupHintText(ConfigLongShanStageById.GetConfig(this.StageId, true).Value.OpenConditionId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), conditionGroupHintText, Array.Empty<object>());
			return;
		}
		ActivityLongShanData activityData = this.ActivityData;
		long endTime = ((activityData != null) ? activityData.GetStageInfoByIdIncludeLock(this.StageId) : null).BeginOpenTime / 1000L;
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew("QiqiuTheme_UnlockTime", null);
		string newText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(endTime, localTextNew) ?? "";
		UUIText text = base.GetText(10);
		if (text == null)
		{
			return;
		}
		text.SetText(newText, true);
	}

	// Token: 0x060087EE RID: 34798 RVA: 0x0023DE03 File Offset: 0x0023C003
	private void OnRefreshTimer()
	{
		this.RefreshLockText();
	}

	// Token: 0x060087EF RID: 34799 RVA: 0x0023DE0C File Offset: 0x0023C00C
	private void OnRefreshStageState(int activityId)
	{
		ActivityLongShanData activityData = this.ActivityData;
		int? num = (activityData != null) ? new int?(activityData.Id) : null;
		if (activityId == num.GetValueOrDefault() & num != null)
		{
			this.RefreshStageState();
		}
	}

	// Token: 0x060087F0 RID: 34800 RVA: 0x0023DE53 File Offset: 0x0023C053
	protected override void OnBeforeHide()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshStageState));
		this.RemoveTimer();
	}

	// Token: 0x060087F1 RID: 34801 RVA: 0x0023DE77 File Offset: 0x0023C077
	private void RemoveTimer()
	{
		if (this.TimerHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
	}

	// Token: 0x060087F2 RID: 34802 RVA: 0x0023DE9C File Offset: 0x0023C09C
	private void OnClickGotoBtn()
	{
		ActivityLongShanData activityData = this.ActivityData;
		bool? flag = (activityData != null) ? new bool?(activityData.IsStageReachOpenTime(this.StageId)) : null;
		if (flag != null)
		{
			bool? flag2 = flag;
			bool flag3 = false;
			if (!(flag2.GetValueOrDefault() == flag3 & flag2 != null))
			{
				SkipTaskManager.RunByConfigId(ConfigLongShanStageById.GetConfig(this.StageId, true).Value.JumpId, null);
				return;
			}
		}
	}

	// Token: 0x060087F3 RID: 34803 RVA: 0x0023DF14 File Offset: 0x0023C114
	private void OnClickStageBtn()
	{
		if (!this.ActivityData.IsStageUnlock(this.StageId))
		{
			return;
		}
		Action<int> onClickStageItem = this.OnClickStageItem;
		if (onClickStageItem == null)
		{
			return;
		}
		onClickStageItem(this.StageId);
	}

	// Token: 0x04003FF4 RID: 16372
	private int StageId;

	// Token: 0x04003FF5 RID: 16373
	public ActivityLongShanData ActivityData;

	// Token: 0x04003FF6 RID: 16374
	private TimerHandle TimerHandle;

	// Token: 0x04003FF7 RID: 16375
	public Action<int> OnClickStageItem;

	// Token: 0x0200770C RID: 30476
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04028FF5 RID: 167925
		public const int BtnRoot = 0;

		// Token: 0x04028FF6 RID: 167926
		public const int TextureImage = 1;

		// Token: 0x04028FF7 RID: 167927
		public const int SpriteRomeNum = 2;

		// Token: 0x04028FF8 RID: 167928
		public const int ItemFinish = 3;

		// Token: 0x04028FF9 RID: 167929
		public const int ItemRedDot = 4;

		// Token: 0x04028FFA RID: 167930
		public const int SpriteLine = 5;

		// Token: 0x04028FFB RID: 167931
		public const int TextStageName = 6;

		// Token: 0x04028FFC RID: 167932
		public const int TextProgress = 7;

		// Token: 0x04028FFD RID: 167933
		public const int ItemLock = 8;

		// Token: 0x04028FFE RID: 167934
		public const int BtnGoto = 9;

		// Token: 0x04028FFF RID: 167935
		public const int TextLock = 10;

		// Token: 0x04029000 RID: 167936
		public const int ItemTimeLock = 11;
	}
}
