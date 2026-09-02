using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.RoleUi.RoleDevelop.Data;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.View
{
	// Token: 0x020050D1 RID: 20689
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoleDevelopTabItem : SyncGridProxyAbstract<RoleDevelopTabItemCellData>
	{
		// Token: 0x060354FF RID: 218367 RVA: 0x00D602E0 File Offset: 0x00D5E4E0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 3;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnAddButtonClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnChangeButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035500 RID: 218368 RVA: 0x00D60492 File Offset: 0x00D5E692
		protected override void OnStart()
		{
			this.Toggle = base.GetExtendToggle(0);
			UUIExtendToggle toggle = this.Toggle;
			if (toggle == null)
			{
				return;
			}
			toggle.CanExecuteChange.Bind(new Func<bool>(this.CanToggleExecuteChange));
		}

		// Token: 0x06035501 RID: 218369 RVA: 0x00D604C2 File Offset: 0x00D5E6C2
		public void BindOnToggleFunc(Action<int, UUIExtendToggle> toggleFunc)
		{
			this.ToggleFunc = toggleFunc;
		}

		// Token: 0x06035502 RID: 218370 RVA: 0x00D604CB File Offset: 0x00D5E6CB
		public void BindCanToggleExecuteChange(Func<int, bool> toggle)
		{
			this.OnCanToggleClicked = toggle;
		}

		// Token: 0x06035503 RID: 218371 RVA: 0x00D604D4 File Offset: 0x00D5E6D4
		private bool CanToggleExecuteChange()
		{
			return this.OnCanToggleClicked == null || this.OnCanToggleClicked(this.TypeId);
		}

		// Token: 0x06035504 RID: 218372 RVA: 0x00D604F1 File Offset: 0x00D5E6F1
		public override void Refresh(RoleDevelopTabItemCellData data)
		{
			this.TypeId = data.TypeId;
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			this.RefreshView();
		}

		// Token: 0x06035505 RID: 218373 RVA: 0x00D60518 File Offset: 0x00D5E718
		private void RefreshView()
		{
			int devTargetRoleId = ModelBase<RoleDevelopModel>.Instance.DevTargetRoleId;
			bool flag = devTargetRoleId > 0;
			base.GetTexture(1).SetUIActive(flag);
			base.GetTexture(3).SetUIActive(!flag);
			base.GetButton(6).RootUIComp.Get().SetUIActive(!flag);
			base.GetButton(7).RootUIComp.Get().SetUIActive(flag);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "RoleProject_Target", Array.Empty<object>());
			if (flag)
			{
				RoleDevelopData roleDevelopData = ModelBase<RoleDevelopModel>.Instance.GetRoleDevelopData(devTargetRoleId);
				base.GetText(5).SetText(roleDevelopData.GetDevelopRoleData().GetName(), true);
				this.RefreshDevelopTagItem(roleDevelopData.GetHotRoleTag());
				base.SetRoleIcon(roleDevelopData.GetDevelopRoleData().GetRoleIconPath(), base.GetTexture(1), devTargetRoleId, null, null);
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "RoleProject_NoneTarget", Array.Empty<object>());
			this.RefreshDevelopTagItem(ERoleDevelopHotRoleTag.None);
		}

		// Token: 0x06035506 RID: 218374 RVA: 0x00D60620 File Offset: 0x00D5E820
		private void RefreshDevelopTagItem(ERoleDevelopHotRoleTag roleTagType)
		{
			RoleDevelopTagItem roleDevelopTagItem = new RoleDevelopTagItem();
			this.DevelopTagItem = roleDevelopTagItem;
			this.LoadDevelopTagItemAsync(roleDevelopTagItem, roleTagType).Forget();
		}

		// Token: 0x06035507 RID: 218375 RVA: 0x00D60648 File Offset: 0x00D5E848
		private UniTask LoadDevelopTagItemAsync(RoleDevelopTagItem item, ERoleDevelopHotRoleTag roleTagType)
		{
			RoleDevelopTabItem.<LoadDevelopTagItemAsync>d__14 <LoadDevelopTagItemAsync>d__;
			<LoadDevelopTagItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadDevelopTagItemAsync>d__.<>4__this = this;
			<LoadDevelopTagItemAsync>d__.item = item;
			<LoadDevelopTagItemAsync>d__.roleTagType = roleTagType;
			<LoadDevelopTagItemAsync>d__.<>1__state = -1;
			<LoadDevelopTagItemAsync>d__.<>t__builder.Start<RoleDevelopTabItem.<LoadDevelopTagItemAsync>d__14>(ref <LoadDevelopTagItemAsync>d__);
			return <LoadDevelopTagItemAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035508 RID: 218376 RVA: 0x00D6069B File Offset: 0x00D5E89B
		public void SetSelectToggle(EToggleState state = EToggleState.ETT_Checked)
		{
			base.GetExtendToggle(0).SetToggleStateForce(state, false, false, true);
			this.ToggleFunc(this.TypeId, this.Toggle);
		}

		// Token: 0x06035509 RID: 218377 RVA: 0x00D606C4 File Offset: 0x00D5E8C4
		[NullableContext(2)]
		public UUIItem GetButtonItem()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			TWeakObjectPtr<UUIItem>? tweakObjectPtr = (extendToggle != null) ? new TWeakObjectPtr<UUIItem>?(extendToggle.RootUIComp) : null;
			if (tweakObjectPtr == null)
			{
				return null;
			}
			return tweakObjectPtr.GetValueOrDefault();
		}

		// Token: 0x0603550A RID: 218378 RVA: 0x00D60709 File Offset: 0x00D5E909
		private void OnToggleClick(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				this.ToggleFunc(this.TypeId, this.Toggle);
			}
		}

		// Token: 0x0603550B RID: 218379 RVA: 0x00D60728 File Offset: 0x00D5E928
		private void OnAddButtonClick()
		{
			RoleController.OpenRoleDevelopSelectTargetView(ERoleDevelopUpdateTargetSource.Detection, null);
		}

		// Token: 0x0603550C RID: 218380 RVA: 0x00D60744 File Offset: 0x00D5E944
		private void OnChangeButtonClick()
		{
			RoleController.OpenRoleDevelopSelectTargetView(ERoleDevelopUpdateTargetSource.Detection, new int?(ModelBase<RoleDevelopModel>.Instance.DevTargetRoleId));
		}

		// Token: 0x0401EA98 RID: 125592
		private int TypeId;

		// Token: 0x0401EA99 RID: 125593
		[Nullable(2)]
		private UUIExtendToggle Toggle;

		// Token: 0x0401EA9A RID: 125594
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<int, UUIExtendToggle> ToggleFunc;

		// Token: 0x0401EA9B RID: 125595
		[Nullable(2)]
		private Func<int, bool> OnCanToggleClicked;

		// Token: 0x0401EA9C RID: 125596
		[Nullable(2)]
		private RoleDevelopTagItem DevelopTagItem;

		// Token: 0x0200B06F RID: 45167
		[NullableContext(0)]
		public static class EComponentType
		{
			// Token: 0x04036BF1 RID: 224241
			public const int Toggle = 0;

			// Token: 0x04036BF2 RID: 224242
			public const int RoleTexture = 1;

			// Token: 0x04036BF3 RID: 224243
			public const int DevelopTagItem = 2;

			// Token: 0x04036BF4 RID: 224244
			public const int EmptyTexture = 3;

			// Token: 0x04036BF5 RID: 224245
			public const int TitleText = 4;

			// Token: 0x04036BF6 RID: 224246
			public const int NameText = 5;

			// Token: 0x04036BF7 RID: 224247
			public const int AddButton = 6;

			// Token: 0x04036BF8 RID: 224248
			public const int ChangeButton = 7;
		}
	}
}
