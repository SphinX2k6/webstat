using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x02006391 RID: 25489
	[NullableContext(1)]
	[Nullable(0)]
	public class SolarSpeedResultView : UiViewBase
	{
		// Token: 0x06040015 RID: 262165 RVA: 0x01067AEB File Offset: 0x01065CEB
		public SolarSpeedResultView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06040016 RID: 262166 RVA: 0x01067AF4 File Offset: 0x01065CF4
		protected unsafe override void OnRegisterComponent()
		{
			this.Data = (this.OpenParam as ISolarSpeedResultViewData);
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06040017 RID: 262167 RVA: 0x01067BD4 File Offset: 0x01065DD4
		protected override UniTask OnBeforeStartAsync()
		{
			SolarSpeedResultView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SolarSpeedResultView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040018 RID: 262168 RVA: 0x01067C17 File Offset: 0x01065E17
		protected override void OnStart()
		{
			this.RoleLayout.SetActive(false);
			this.RefreshTitle();
		}

		// Token: 0x06040019 RID: 262169 RVA: 0x01067C2B File Offset: 0x01065E2B
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<string>(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.HandleOnActivitySequenceEmitEvent));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.ApplicationSent, new Action<int>(this.HandleApplicationSent));
		}

		// Token: 0x0604001A RID: 262170 RVA: 0x01067C65 File Offset: 0x01065E65
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.HandleOnActivitySequenceEmitEvent));
			Singleton<EventSystem>.Instance.Remove(EEventName.ApplicationSent, new Action<int>(this.HandleApplicationSent));
		}

		// Token: 0x0604001B RID: 262171 RVA: 0x01067C9F File Offset: 0x01065E9F
		private SolarSpeedRolePanelBase BuildSolarSpeedRolePanel()
		{
			return this.Data.PanelType();
		}

		// Token: 0x0604001C RID: 262172 RVA: 0x01067CB1 File Offset: 0x01065EB1
		private void HandleOnClickConfirm(int _)
		{
			Action confirmClick = this.Data.ConfirmClick;
			if (confirmClick != null)
			{
				confirmClick();
			}
			UUIItem item = base.GetItem(3);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x0604001D RID: 262173 RVA: 0x01067CDB File Offset: 0x01065EDB
		private void HandleOnActivitySequenceEmitEvent(string passData)
		{
			this.HandleOnActivitySequenceEmitEventInternalAsync();
		}

		// Token: 0x0604001E RID: 262174 RVA: 0x01067CE4 File Offset: 0x01065EE4
		private void HandleApplicationSent(int playerId)
		{
			foreach (SolarSpeedRolePanelBase solarSpeedRolePanelBase in this.RoleLayout.GetLayoutItemList())
			{
				solarSpeedRolePanelBase.RefreshAddFriendByPlayerIdExternal(playerId);
			}
		}

		// Token: 0x0604001F RID: 262175 RVA: 0x01067D3C File Offset: 0x01065F3C
		private UniTask HandleOnActivitySequenceEmitEventInternalAsync()
		{
			SolarSpeedResultView.<HandleOnActivitySequenceEmitEventInternalAsync>d__15 <HandleOnActivitySequenceEmitEventInternalAsync>d__;
			<HandleOnActivitySequenceEmitEventInternalAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<HandleOnActivitySequenceEmitEventInternalAsync>d__.<>4__this = this;
			<HandleOnActivitySequenceEmitEventInternalAsync>d__.<>1__state = -1;
			<HandleOnActivitySequenceEmitEventInternalAsync>d__.<>t__builder.Start<SolarSpeedResultView.<HandleOnActivitySequenceEmitEventInternalAsync>d__15>(ref <HandleOnActivitySequenceEmitEventInternalAsync>d__);
			return <HandleOnActivitySequenceEmitEventInternalAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040020 RID: 262176 RVA: 0x01067D7F File Offset: 0x01065F7F
		private void RefreshTitle()
		{
			if (!StringUtils.IsEmpty(this.Data.TitleId))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), this.Data.TitleId, Array.Empty<object>());
			}
		}

		// Token: 0x04023F07 RID: 147207
		private GenericLayout<SolarSpeedRolePanelBase, ISolarSpeedRolePanelData> RoleLayout;

		// Token: 0x04023F08 RID: 147208
		private ButtonItem ConfirmItem;

		// Token: 0x04023F09 RID: 147209
		private UUIInturnAnimController RolePlayer;

		// Token: 0x04023F0A RID: 147210
		private ISolarSpeedResultViewData Data;

		// Token: 0x0200C3EA RID: 50154
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403C586 RID: 247174
			public const int RoleLayout = 0;

			// Token: 0x0403C587 RID: 247175
			public const int RoleItem = 1;

			// Token: 0x0403C588 RID: 247176
			public const int ConfirmItem = 2;

			// Token: 0x0403C589 RID: 247177
			public const int ContentRoot = 3;

			// Token: 0x0403C58A RID: 247178
			public const int TitleText = 4;
		}
	}
}
