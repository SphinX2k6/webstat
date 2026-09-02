using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Birthday.View
{
	// Token: 0x02005F15 RID: 24341
	public class BirthdayRoleSelectView : UiViewBase, IUiViewResource
	{
		// Token: 0x0603D208 RID: 250376 RVA: 0x00F87FBC File Offset: 0x00F861BC
		[NullableContext(1)]
		public BirthdayRoleSelectView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603D209 RID: 250377 RVA: 0x00F87FC8 File Offset: 0x00F861C8
		[NullableContext(1)]
		public string GetExtraResourceId([Nullable(2)] object param = null)
		{
			BirthdayInfo birthdayInfo = param as BirthdayInfo;
			if (birthdayInfo == null)
			{
				return "";
			}
			return ModelBase<BirthdayModel>.Instance.GetRoleSelectViewResource(birthdayInfo.Year);
		}

		// Token: 0x0603D20A RID: 250378 RVA: 0x00F87FF8 File Offset: 0x00F861F8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickGotoButton));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickCloseButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603D20B RID: 250379 RVA: 0x00F88168 File Offset: 0x00F86368
		protected override UniTask OnBeforeStartAsync()
		{
			BirthdayRoleSelectView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BirthdayRoleSelectView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D20C RID: 250380 RVA: 0x00F881AB File Offset: 0x00F863AB
		protected override void OnStart()
		{
			if (this.TriggerType == BirthdayDefine.ETriggerType.ReSelect)
			{
				this.UiViewSequence.StartSequenceName = "ShowView";
			}
		}

		// Token: 0x0603D20D RID: 250381 RVA: 0x00F881C8 File Offset: 0x00F863C8
		private void SetButtonText()
		{
			string item = "";
			if (this.SelectedRoleId != null)
			{
				item = ConfigMultiTextLang.GetLocalTextNew(ConfigRoleInfoById.GetConfig(this.SelectedRoleId.Value, true).Value.Name, null);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "BirthdaySelected_Invite", new <>z__ReadOnlySingleElementList<object>(item));
		}

		// Token: 0x0603D20E RID: 250382 RVA: 0x00F8822C File Offset: 0x00F8642C
		[NullableContext(1)]
		private BirthdayRoleHeadItem CreateItem()
		{
			return new BirthdayRoleHeadItem
			{
				OnToggleClickCallBack = new Action<int, int>(this.OnToggleClickCallBack)
			};
		}

		// Token: 0x0603D20F RID: 250383 RVA: 0x00F88248 File Offset: 0x00F86448
		private void OnToggleClickCallBack(int index, int roleId)
		{
			int? selectedRoleId = this.SelectedRoleId;
			if (selectedRoleId.GetValueOrDefault() == roleId & selectedRoleId != null)
			{
				this.SelectedRoleId = null;
				this.SetButtonText();
				this.RoleHeadScrollView.DeselectCurrentGridProxy(false);
				return;
			}
			this.SelectedRoleId = new int?(roleId);
			this.SetButtonText();
			this.RoleHeadScrollView.SelectGridProxy(index, false);
		}

		// Token: 0x0603D210 RID: 250384 RVA: 0x00F882B0 File Offset: 0x00F864B0
		private void OnClickGotoButton()
		{
			if (this.SelectedRoleId == null)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("BirthdayUnSelectedRole", Array.Empty<object>());
				return;
			}
			if (this.TriggerType == BirthdayDefine.ETriggerType.ReSelect)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnBirthRoleChange, this.SelectedRoleId.Value);
				base.CloseMe(null);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.BirthdaySelectConfirmView, new BirthdayInfo(this.TriggerType, this.Year, new int?(this.SelectedRoleId.Value)), null);
		}

		// Token: 0x0603D211 RID: 250385 RVA: 0x00F8833C File Offset: 0x00F8653C
		private void OnClickCloseButton()
		{
			base.CloseMe(null);
		}

		// Token: 0x0402247C RID: 140412
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private LoopScrollView<BirthdayRoleHeadItem, int> RoleHeadScrollView;

		// Token: 0x0402247D RID: 140413
		private int? SelectedRoleId;

		// Token: 0x0402247E RID: 140414
		private int Year;

		// Token: 0x0402247F RID: 140415
		private BirthdayDefine.ETriggerType TriggerType;

		// Token: 0x0200BF18 RID: 48920
		private class EComponents
		{
			// Token: 0x0403AD19 RID: 240921
			public const int TextTip = 0;

			// Token: 0x0403AD1A RID: 240922
			public const int LoopScrollViewRoleHead = 1;

			// Token: 0x0403AD1B RID: 240923
			public const int ItemRoleHead = 2;

			// Token: 0x0403AD1C RID: 240924
			public const int ButtonGoto = 3;

			// Token: 0x0403AD1D RID: 240925
			public const int TextInvite = 4;

			// Token: 0x0403AD1E RID: 240926
			public const int TxtTitle = 5;

			// Token: 0x0403AD1F RID: 240927
			public const int BtnClose = 6;
		}
	}
}
