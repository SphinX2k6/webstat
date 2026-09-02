using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Motorcycle.Model;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066F3 RID: 26355
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorFightRoleSelectView : UiViewBase
	{
		// Token: 0x06041C95 RID: 269461 RVA: 0x010E02EF File Offset: 0x010DE4EF
		public MotorFightRoleSelectView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06041C96 RID: 269462 RVA: 0x010E02F8 File Offset: 0x010DE4F8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnConfirmBtnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041C97 RID: 269463 RVA: 0x010E04A8 File Offset: 0x010DE6A8
		protected override UniTask OnBeforeStartAsync()
		{
			MotorFightRoleSelectView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MotorFightRoleSelectView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041C98 RID: 269464 RVA: 0x010E04EC File Offset: 0x010DE6EC
		protected override void OnBeforeShow()
		{
			MotorFightLevelData levelData = this.ViewModel.LevelData;
			base.SetTextureByPath(ConfigBase<MotorFightConfig>.Instance.GetMotorFightLevelType((int)levelData.Type).Value.SelectLevelStateBg, base.GetTexture(0), null, null);
			GenericLayout<MotorFightRoleItem, MotorFightRoleData> roleLayout = this.RoleLayout;
			if (roleLayout != null)
			{
				roleLayout.SelectGridProxyByKey(this.RoleData.Id, false);
			}
			this.RefreshView(this.RoleData);
		}

		// Token: 0x06041C99 RID: 269465 RVA: 0x010E056C File Offset: 0x010DE76C
		private void RefreshView(MotorFightRoleData roleData)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), roleData.RoleName, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), roleData.BuffName, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), roleData.BuffDesc, roleData.BuffDescParams);
			FunctionalPanelConditionLock lockPanel = this.LockPanel;
			if (lockPanel != null)
			{
				lockPanel.SetUiActive(!roleData.IsUnLock);
			}
			if (!roleData.IsUnLock)
			{
				string conditionGroupHintText = LevelGeneralCommons.GetConditionGroupHintText(roleData.ConditionId);
				FunctionalPanelConditionLock lockPanel2 = this.LockPanel;
				if (lockPanel2 != null)
				{
					lockPanel2.SetTextByTextId(conditionGroupHintText, Array.Empty<string>());
				}
			}
			UUIButtonComponent button = base.GetButton(6);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(roleData.IsUnLock);
			}
			bool flag = this.IsSelected(roleData.Id);
			UUIButtonComponent button2 = base.GetButton(6);
			if (button2 != null)
			{
				button2.SetSelfInteractive(!flag);
			}
			string textStringId = flag ? "MotorFightGame_CharacterCondition_04" : "MotorFightGame_CharacterCondition_03";
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), textStringId, Array.Empty<object>());
		}

		// Token: 0x06041C9A RID: 269466 RVA: 0x010E0683 File Offset: 0x010DE883
		private bool IsSelected(int roleId)
		{
			return this.ViewModel.SelectedRoleId == roleId;
		}

		// Token: 0x06041C9B RID: 269467 RVA: 0x010E0694 File Offset: 0x010DE894
		private void OnToggleClickCallback(MotorFightRoleData data)
		{
			this.RoleData = data;
			this.RefreshView(data);
			base.PlayOrReplaySequence("Switch", false, null);
			GenericLayout<MotorFightRoleItem, MotorFightRoleData> roleLayout = this.RoleLayout;
			if (roleLayout != null)
			{
				roleLayout.SelectGridProxyByKey(data.Id, false);
			}
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(data.TrialRoleId, true);
			Singleton<MotorcycleUiModelUtil>.Instance.RefreshRoleInMotor(roleDataById.GetRoleId(), roleDataById.GetRoleSkinId(), data.AnimPath);
		}

		// Token: 0x06041C9C RID: 269468 RVA: 0x010E0710 File Offset: 0x010DE910
		private MotorFightRoleItem CreateRoleItem()
		{
			return new MotorFightRoleItem
			{
				RecommendRoleIds = this.ViewModel.LevelData.RecommendRoleIds,
				OnToggleClickCallback = new Action<MotorFightRoleData>(this.OnToggleClickCallback),
				IsSelected = new Func<int, bool>(this.IsSelected)
			};
		}

		// Token: 0x06041C9D RID: 269469 RVA: 0x010E075C File Offset: 0x010DE95C
		private void OnConfirmBtnClick()
		{
			this.ViewModel.SelectedRoleId = this.RoleData.Id;
			base.CloseMe(null);
		}

		// Token: 0x06041C9E RID: 269470 RVA: 0x010E077B File Offset: 0x010DE97B
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x06041C9F RID: 269471 RVA: 0x010E0784 File Offset: 0x010DE984
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (!(configParams[0] == "sword_role"))
			{
				return null;
			}
			int index = int.Parse(configParams[1]);
			GenericLayout<MotorFightRoleItem, MotorFightRoleData> roleLayout = this.RoleLayout;
			MotorFightRoleItem motorFightRoleItem = (roleLayout != null) ? roleLayout.GetLayoutItemByIndex(index) : null;
			UUIItem uuiitem = (motorFightRoleItem != null) ? motorFightRoleItem.GetRootItem() : null;
			if (uuiitem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem,
				uuiitem
			};
		}

		// Token: 0x04024B32 RID: 150322
		private MotorFightLevelDetailViewModel ViewModel;

		// Token: 0x04024B33 RID: 150323
		private MotorFightRoleData RoleData;

		// Token: 0x04024B34 RID: 150324
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04024B35 RID: 150325
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<MotorFightRoleItem, MotorFightRoleData> RoleLayout;

		// Token: 0x04024B36 RID: 150326
		[Nullable(2)]
		private FunctionalPanelConditionLock LockPanel;

		// Token: 0x0200C73C RID: 51004
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D567 RID: 251239
			public const int TextureBg = 0;

			// Token: 0x0403D568 RID: 251240
			public const int ItemCaption = 1;

			// Token: 0x0403D569 RID: 251241
			public const int LayoutRole = 2;

			// Token: 0x0403D56A RID: 251242
			public const int ItemRole = 3;

			// Token: 0x0403D56B RID: 251243
			public const int TextRoleName = 4;

			// Token: 0x0403D56C RID: 251244
			public const int TextBuffDesc = 5;

			// Token: 0x0403D56D RID: 251245
			public const int BtnConfirm = 6;

			// Token: 0x0403D56E RID: 251246
			public const int ItemLockPanel = 7;

			// Token: 0x0403D56F RID: 251247
			public const int TextBuffName = 8;

			// Token: 0x0403D570 RID: 251248
			public const int TextConfirmBtn = 9;
		}
	}
}
