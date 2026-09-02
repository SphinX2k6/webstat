using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Activity
{
	// Token: 0x02005ADD RID: 23261
	internal class TabItem : GridProxyAbstract<KurotatoRewardTab>
	{
		// Token: 0x0603ACF5 RID: 240885 RVA: 0x00EEA0B4 File Offset: 0x00EE82B4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnClickToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603ACF6 RID: 240886 RVA: 0x00EEA17B File Offset: 0x00EE837B
		protected override void OnBeforeShow()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshKurotatoLimitRewardData, new Action(this.RefreshTabNameText));
		}

		// Token: 0x0603ACF7 RID: 240887 RVA: 0x00EEA199 File Offset: 0x00EE8399
		protected override void OnBeforeHide()
		{
			this.UnBindRedDot();
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshKurotatoLimitRewardData, new Action(this.RefreshTabNameText));
		}

		// Token: 0x0603ACF8 RID: 240888 RVA: 0x00EEA1C0 File Offset: 0x00EE83C0
		public override void Refresh(KurotatoRewardTab data, bool isSelected, int gridIndex)
		{
			this.TabIndex = data.Id;
			ValueTuple<int, int> limitedTimeTabRewardProgress = ControllerBase<KurotatoActivityController>.Instance.GetActivityData().GetLimitedTimeTabRewardProgress(this.TabIndex);
			int item = limitedTimeTabRewardProgress.Item1;
			int item2 = limitedTimeTabRewardProgress.Item2;
			string multiText = ConfigBase<TextConfig>.Instance.GetMultiText(data.Name, Array.Empty<string>());
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 3);
			defaultInterpolatedStringHandler.AppendFormatted(multiText);
			defaultInterpolatedStringHandler.AppendLiteral("（");
			defaultInterpolatedStringHandler.AppendFormatted<int>(item);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(item2);
			defaultInterpolatedStringHandler.AppendLiteral("）");
			string newText = defaultInterpolatedStringHandler.ToStringAndClear();
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.SetText(newText, true);
			}
			this.BindRedDot(ERedDotName.RedDotKurotatoLimitRewardTabItem, this.TabIndex);
		}

		// Token: 0x0603ACF9 RID: 240889 RVA: 0x00EEA288 File Offset: 0x00EE8488
		private void RefreshTabNameText()
		{
			ValueTuple<int, int> limitedTimeTabRewardProgress = ControllerBase<KurotatoActivityController>.Instance.GetActivityData().GetLimitedTimeTabRewardProgress(this.TabIndex);
			int item = limitedTimeTabRewardProgress.Item1;
			int item2 = limitedTimeTabRewardProgress.Item2;
			KurotatoRewardTab? rewardTabConfigById = ConfigBase<KurotatoConfig>.Instance.GetRewardTabConfigById(this.TabIndex);
			if (rewardTabConfigById == null)
			{
				return;
			}
			string multiText = ConfigBase<TextConfig>.Instance.GetMultiText(rewardTabConfigById.Value.Name, Array.Empty<string>());
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 3);
			defaultInterpolatedStringHandler.AppendFormatted(multiText);
			defaultInterpolatedStringHandler.AppendLiteral("（");
			defaultInterpolatedStringHandler.AppendFormatted<int>(item);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(item2);
			defaultInterpolatedStringHandler.AppendLiteral("）");
			string newText = defaultInterpolatedStringHandler.ToStringAndClear();
			UUIText text = base.GetText(0);
			if (text == null)
			{
				return;
			}
			text.SetText(newText, true);
		}

		// Token: 0x0603ACFA RID: 240890 RVA: 0x00EEA354 File Offset: 0x00EE8554
		public void BindRedDot(ERedDotName redDotName, int uId)
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(redDotName, base.GetItem(2), null, uId);
		}

		// Token: 0x0603ACFB RID: 240891 RVA: 0x00EEA36A File Offset: 0x00EE856A
		public void UnBindRedDot()
		{
			ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.RedDotKurotatoLimitRewardTabItem);
		}

		// Token: 0x0603ACFC RID: 240892 RVA: 0x00EEA37B File Offset: 0x00EE857B
		private void OnClickToggle(EToggleState state)
		{
			Action<int> onTabClickCallBack = this.OnTabClickCallBack;
			if (onTabClickCallBack == null)
			{
				return;
			}
			onTabClickCallBack(this.TabIndex);
		}

		// Token: 0x0603ACFD RID: 240893 RVA: 0x00EEA393 File Offset: 0x00EE8593
		[NullableContext(1)]
		public void SetTabClickCallback(Action<int> callback)
		{
			this.OnTabClickCallBack = callback;
		}

		// Token: 0x0603ACFE RID: 240894 RVA: 0x00EEA39C File Offset: 0x00EE859C
		public override void OnDeselected(bool fireEvent)
		{
			this.SetToggleSelect(false, false);
		}

		// Token: 0x0603ACFF RID: 240895 RVA: 0x00EEA3A6 File Offset: 0x00EE85A6
		public void SetToggleSelect(bool isSelected, bool fireEvent)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleStateForce(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, fireEvent, false, false);
		}

		// Token: 0x040213BE RID: 136126
		private int TabIndex = -1;

		// Token: 0x040213BF RID: 136127
		[Nullable(2)]
		private Action<int> OnTabClickCallBack;

		// Token: 0x0200BB0E RID: 47886
		private enum ETab
		{
			// Token: 0x04039BBD RID: 236477
			Name,
			// Token: 0x04039BBE RID: 236478
			Toggle,
			// Token: 0x04039BBF RID: 236479
			RedPoint
		}
	}
}
