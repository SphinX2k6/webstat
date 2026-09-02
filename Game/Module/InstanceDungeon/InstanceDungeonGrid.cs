using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.InstanceDungeon.Define;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BC0 RID: 23488
	[NullableContext(1)]
	[Nullable(0)]
	public class InstanceDungeonGrid : UiPanelBase
	{
		// Token: 0x0603B764 RID: 243556 RVA: 0x00F12C70 File Offset: 0x00F10E70
		public InstanceDungeonGrid(int id, UUIItem uiItem)
		{
			this.InstanceId = id;
		}

		// Token: 0x1700977B RID: 38779
		// (get) Token: 0x0603B765 RID: 243557 RVA: 0x00F12C7F File Offset: 0x00F10E7F
		// (set) Token: 0x0603B766 RID: 243558 RVA: 0x00F12C87 File Offset: 0x00F10E87
		public Action<int> ClickCallback
		{
			get
			{
				return this.ClickCallbackInternal;
			}
			set
			{
				this.ClickCallbackInternal = value;
			}
		}

		// Token: 0x0603B767 RID: 243559 RVA: 0x00F12C90 File Offset: 0x00F10E90
		protected unsafe override void OnRegisterComponent()
		{
			int num = 11;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.OnClickToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603B768 RID: 243560 RVA: 0x00F12E62 File Offset: 0x00F11062
		private void OnClickToggle(EToggleState toState)
		{
			if (toState == EToggleState.ETT_Checked)
			{
				this.ClickCallbackInternal(this.InstanceId);
			}
		}

		// Token: 0x0603B769 RID: 243561 RVA: 0x00F12E7C File Offset: 0x00F1107C
		protected override void OnStart()
		{
			base.GetItem(4).SetUIActive(false);
			UUIText text = base.GetText(1);
			UUIItem item = base.GetItem(10);
			if (!ModelBase<InstanceDungeonEntranceModel>.Instance.CheckInstanceCanChallenge(this.InstanceId))
			{
				text.SetUIActive(false);
				item.SetUIActive(true);
				return;
			}
			text.SetUIActive(true);
			item.SetUIActive(false);
		}

		// Token: 0x0603B76A RID: 243562 RVA: 0x00F12ED6 File Offset: 0x00F110D6
		protected override void OnBeforeDestroy()
		{
		}

		// Token: 0x0603B76B RID: 243563 RVA: 0x00F12ED8 File Offset: 0x00F110D8
		public void ShowTitle(int titleId)
		{
			base.GetItem(4).SetUIActive(true);
			InstanceDungeonTitle? titleConfig = ConfigBase<InstanceDungeonConfig>.Instance.GetTitleConfig(titleId);
			if (titleConfig != null)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), titleConfig.Value.CommonText, Array.Empty<object>());
			}
			int enterControlId = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(this.InstanceId).Value.EnterControlId;
			InstanceDungeonData instanceData = ModelBase<InstanceDungeonEntranceModel>.Instance.GetInstanceData(enterControlId);
			if (instanceData != null)
			{
				int limitChallengedTimes = instanceData.LimitChallengedTimes;
				base.GetItem(6).SetUIActive(true);
				base.GetText(8).SetUIActive(true);
				base.GetText(8).SetText(instanceData.LeftChallengedTimes.ToString() + "/" + instanceData.LimitChallengedTimes.ToString(), true);
			}
			else
			{
				base.GetItem(6).SetUIActive(false);
				base.GetText(8).SetUIActive(false);
			}
			long num = ModelBase<InstanceDungeonEntranceModel>.Instance.GetInstanceResetTime(this.InstanceId).GetValueOrDefault();
			if (num <= 0L)
			{
				num = ModelBase<InstanceDungeonEntranceModel>.Instance.EntranceEndTime;
			}
			double num2 = (double)num - Singleton<TimeUtil>.Instance.GetServerTime();
			if (num > 0L && num2 > 0.0)
			{
				base.GetItem(7).SetUIActive(true);
				CommonDefine.IRemainTime remainTime = Singleton<TimeUtil>.Instance.CalculateRemainingTime(num2, CommonDefine.ETimeType.Minute);
				Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(9), remainTime.TextId, new <>z__ReadOnlySingleElementList<object>(remainTime.TimeValue));
				return;
			}
			base.GetItem(7).SetUIActive(false);
		}

		// Token: 0x0603B76C RID: 243564 RVA: 0x00F13074 File Offset: 0x00F11274
		public void SetSelected(bool value, bool ignoreAnim = false)
		{
			if (!ignoreAnim)
			{
				base.GetExtendToggle(2).SetToggleState(value ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
				return;
			}
			base.GetExtendToggle(2).SetToggleStateForce(value ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, true, false);
		}

		// Token: 0x0603B76D RID: 243565 RVA: 0x00F130A7 File Offset: 0x00F112A7
		public void OnDeselected(bool fireEvent)
		{
			this.SetSelected(false, fireEvent);
		}

		// Token: 0x0603B76E RID: 243566 RVA: 0x00F130B1 File Offset: 0x00F112B1
		public void Refresh()
		{
			this.UpdateView(this.InstanceId);
		}

		// Token: 0x0603B76F RID: 243567 RVA: 0x00F130C0 File Offset: 0x00F112C0
		public void UpdateView(int instanceId)
		{
			if (instanceId == 0)
			{
				Singleton<Log>.Instance.Error(ELogModule.InstanceDungeon, ELogAuthor.TL, "副本格子视图刷新失败，instanceId非法", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			base.GetText(0).ShowTextNew(ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId).Value.MapName);
			int recommendLevel = ConfigBase<InstanceDungeonConfig>.Instance.GetRecommendLevel(instanceId, ModelBase<WorldLevelModel>.Instance.CurWorldLevel);
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "InstanceDungeonRecommendLevel", new <>z__ReadOnlySingleElementList<object>(recommendLevel));
			base.GetItem(3).SetUIActive(!ModelBase<InstanceDungeonEntranceModel>.Instance.CheckInstanceUnlock(instanceId));
		}

		// Token: 0x04021803 RID: 137219
		private readonly int InstanceId;

		// Token: 0x04021804 RID: 137220
		private Action<int> ClickCallbackInternal;

		// Token: 0x0200BC2B RID: 48171
		[NullableContext(0)]
		private static class EChildCom
		{
			// Token: 0x0403A0A1 RID: 237729
			public const int TextName = 0;

			// Token: 0x0403A0A2 RID: 237730
			public const int TextRecommendLevel = 1;

			// Token: 0x0403A0A3 RID: 237731
			public const int ToggleClick = 2;

			// Token: 0x0403A0A4 RID: 237732
			public const int UIItemLock = 3;

			// Token: 0x0403A0A5 RID: 237733
			public const int UIItemTitle = 4;

			// Token: 0x0403A0A6 RID: 237734
			public const int TextTitle = 5;

			// Token: 0x0403A0A7 RID: 237735
			public const int UIItemFrequency = 6;

			// Token: 0x0403A0A8 RID: 237736
			public const int UIItemTime = 7;

			// Token: 0x0403A0A9 RID: 237737
			public const int TextFrequency = 8;

			// Token: 0x0403A0AA RID: 237738
			public const int TextTime = 9;

			// Token: 0x0403A0AB RID: 237739
			public const int UIItemFinish = 10;
		}
	}
}
