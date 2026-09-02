using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Cook.View
{
	// Token: 0x02005E21 RID: 24097
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CookRoleItem : GridProxyAbstract<ICookRoleItemData>
	{
		// Token: 0x0603CA08 RID: 248328 RVA: 0x00F656B8 File Offset: 0x00F638B8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603CA09 RID: 248329 RVA: 0x00F657A0 File Offset: 0x00F639A0
		protected override void OnStart()
		{
			this.ItemGrid = new SmallItemGrid();
			this.ItemGrid.Initialize(base.GetItem(3).GetOwner());
		}

		// Token: 0x0603CA0A RID: 248330 RVA: 0x00F657C4 File Offset: 0x00F639C4
		[NullableContext(1)]
		public override void Refresh(ICookRoleItemData data, bool isSelected, int gridIndex)
		{
			this.ItemData = data;
			CharacterSmallItemGrid parameters = new CharacterSmallItemGrid
			{
				Data = data,
				ItemConfigId = new int?(data.RoleId),
				IsCookUp = new bool?(data.IsBuff)
			};
			this.ItemGrid.Apply<CharacterSmallItemGrid>(parameters);
			this.SetName();
			this.SetCookInfoText();
			this.Selected(isSelected, false);
			base.GetText(2).OnSelfLanguageChange.Bind(new Action(this.OnLanguageChange));
		}

		// Token: 0x0603CA0B RID: 248331 RVA: 0x00F65844 File Offset: 0x00F63A44
		public override void Clear()
		{
			base.GetText(2).OnSelfLanguageChange.Unbind();
		}

		// Token: 0x0603CA0C RID: 248332 RVA: 0x00F65857 File Offset: 0x00F63A57
		protected override void OnBeforeDestroy()
		{
			this.ItemGrid.Destroy(null);
			this.ItemGrid = null;
		}

		// Token: 0x0603CA0D RID: 248333 RVA: 0x00F6586C File Offset: 0x00F63A6C
		private void SetCookInfoText()
		{
			if (ControllerBase<CookController>.Instance.CheckIsBuff(this.ItemData.RoleId, this.ItemData.ItemId))
			{
				string cookInfoText = ControllerBase<CookController>.Instance.GetCookInfoText(this.ItemData.RoleId);
				base.GetText(2).SetText(cookInfoText, true);
				return;
			}
			string textById = ConfigBase<TextConfig>.Instance.GetTextById("DefaultHelperText");
			base.GetText(2).SetText(textById, true);
		}

		// Token: 0x0603CA0E RID: 248334 RVA: 0x00F658DE File Offset: 0x00F63ADE
		private void SetName()
		{
			base.GetText(1).SetText(this.ItemData.RoleName, true);
		}

		// Token: 0x0603CA0F RID: 248335 RVA: 0x00F658F8 File Offset: 0x00F63AF8
		private void OnLanguageChange()
		{
			this.SetCookInfoText();
		}

		// Token: 0x0603CA10 RID: 248336 RVA: 0x00F65900 File Offset: 0x00F63B00
		[NullableContext(1)]
		public void BindOnClickedCallback(Action<int> onItemButtonClicked)
		{
			this.OnClickedCallback = onItemButtonClicked;
		}

		// Token: 0x0603CA11 RID: 248337 RVA: 0x00F65909 File Offset: 0x00F63B09
		public override void OnSelected(bool fireEvent)
		{
			this.Selected(true, true);
		}

		// Token: 0x0603CA12 RID: 248338 RVA: 0x00F65913 File Offset: 0x00F63B13
		public override void OnDeselected(bool fireEvent)
		{
			this.Selected(false, true);
		}

		// Token: 0x0603CA13 RID: 248339 RVA: 0x00F65920 File Offset: 0x00F63B20
		private void Selected(bool bSelected, bool fire = true)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (bSelected)
			{
				extendToggle.SetToggleState(EToggleState.ETT_Checked, fire, false, false);
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0603CA14 RID: 248340 RVA: 0x00F6594F File Offset: 0x00F63B4F
		private void OnClick(EToggleState state)
		{
			if (this.OnClickedCallback != null)
			{
				this.OnClickedCallback(this.ItemData.RoleId);
			}
		}

		// Token: 0x04022101 RID: 139521
		private ICookRoleItemData ItemData;

		// Token: 0x04022102 RID: 139522
		private Action<int> OnClickedCallback;

		// Token: 0x04022103 RID: 139523
		private SmallItemGrid ItemGrid;

		// Token: 0x0200BE55 RID: 48725
		[NullableContext(0)]
		public enum ECookRoleItemDefine
		{
			// Token: 0x0403A997 RID: 240023
			CookRoleExtendToggle,
			// Token: 0x0403A998 RID: 240024
			RoleNameText,
			// Token: 0x0403A999 RID: 240025
			CookInfoText,
			// Token: 0x0403A99A RID: 240026
			ItemGridItem
		}
	}
}
