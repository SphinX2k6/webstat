using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Birthday.View
{
	// Token: 0x02005F16 RID: 24342
	public class BirthdaySelectConfirmView : UiViewBase, IUiViewResource
	{
		// Token: 0x0603D212 RID: 250386 RVA: 0x00F88345 File Offset: 0x00F86545
		[NullableContext(1)]
		public BirthdaySelectConfirmView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603D213 RID: 250387 RVA: 0x00F88350 File Offset: 0x00F86550
		[NullableContext(1)]
		public string GetExtraResourceId([Nullable(2)] object param = null)
		{
			BirthdayInfo birthdayInfo = param as BirthdayInfo;
			if (birthdayInfo == null)
			{
				return "";
			}
			return ModelBase<BirthdayModel>.Instance.GetSelectConfirmViewResource(birthdayInfo.Year);
		}

		// Token: 0x0603D214 RID: 250388 RVA: 0x00F88380 File Offset: 0x00F86580
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnReturnBtnClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickGotoButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603D215 RID: 250389 RVA: 0x00F884AC File Offset: 0x00F866AC
		protected override void OnBeforeShow()
		{
			this.BirthdayInfo = (this.OpenParam as BirthdayInfo);
			int value = this.BirthdayInfo.RoleId.Value;
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(value, true);
			int? num = (roleDataById != null) ? new int?(roleDataById.GetRoleSkinId()) : null;
			if (num == null)
			{
				num = new int?(ConfigRoleInfoById.GetConfig(value, true).Value.SkinId);
			}
			RoleSkin? roleSkin;
			string text = (ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(num.Value) != null) ? roleSkin.GetValueOrDefault().FormationRoleCard : null;
			if (text != null)
			{
				base.SetTextureByPath(text, base.GetTexture(0), null, null);
			}
			DateTime birthdayDate = ModelBase<BirthdayModel>.Instance.GetBirthdayDate(this.BirthdayInfo.Year);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "BirthdayConfirmText", new <>z__ReadOnlyArray<object>(new object[]
			{
				this.BirthdayInfo.Year,
				birthdayDate.Month,
				birthdayDate.Day
			}));
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(ConfigRoleInfoById.GetConfig(value, true).Value.Name, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "BirthdaySelected_GO", new <>z__ReadOnlySingleElementList<object>(localTextNew));
		}

		// Token: 0x0603D216 RID: 250390 RVA: 0x00F88620 File Offset: 0x00F86820
		private void RecordBirthdaySelectRole()
		{
			int value = this.BirthdayInfo.RoleId.Value;
			BirthdaySelectRoleEvent birthdaySelectRoleEvent = new BirthdaySelectRoleEvent();
			birthdaySelectRoleEvent.i_role_id = value;
			bool b_if_selected_role = ModelBase<BirthdayModel>.Instance.IsRoleSelected(value);
			birthdaySelectRoleEvent.b_if_selected_role = b_if_selected_role;
			int birthdayCount = ModelBase<BirthdayModel>.Instance.GetBirthdayCount();
			birthdaySelectRoleEvent.i_birthday_count = birthdayCount + 1;
			birthdaySelectRoleEvent.i_trigger_type = 1;
			birthdaySelectRoleEvent.bird_round_id = ConfigBirthDayByYear.GetConfig(this.BirthdayInfo.Year, true).Value.Id;
			ControllerBase<LogReportController>.Instance.LogReport(birthdaySelectRoleEvent);
		}

		// Token: 0x0603D217 RID: 250391 RVA: 0x00F886AD File Offset: 0x00F868AD
		private void OnReturnBtnClick()
		{
			if (!this.IsClickBtn)
			{
				base.CloseMe(null);
				this.IsClickBtn = true;
			}
		}

		// Token: 0x0603D218 RID: 250392 RVA: 0x00F886C8 File Offset: 0x00F868C8
		private void OnClickGotoButton()
		{
			if (!this.IsClickBtn)
			{
				this.RecordBirthdaySelectRole();
				Singleton<UiManager>.Instance.CloseAndOpenView(this.ViewInfo.Name, EUiViewName.BirthdayLetterView, this.BirthdayInfo, delegate(bool _)
				{
					Singleton<UiManager>.Instance.CloseView(EUiViewName.BirthdayRoleSelectView, null);
				}, true);
				this.IsClickBtn = true;
			}
		}

		// Token: 0x04022480 RID: 140416
		[Nullable(2)]
		private BirthdayInfo BirthdayInfo;

		// Token: 0x04022481 RID: 140417
		private bool IsClickBtn;

		// Token: 0x0200BF1A RID: 48922
		private class EComponents
		{
			// Token: 0x0403AD25 RID: 240933
			public const int TextureRole = 0;

			// Token: 0x0403AD26 RID: 240934
			public const int ButtonReturn = 1;

			// Token: 0x0403AD27 RID: 240935
			public const int ButtonGoto = 2;

			// Token: 0x0403AD28 RID: 240936
			public const int TextConfirm = 3;

			// Token: 0x0403AD29 RID: 240937
			public const int TextGo = 4;
		}
	}
}
