using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Cook;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Manufacture.Common
{
	// Token: 0x020059E9 RID: 23017
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class HelpRoleItem : GridProxyAbstract<ICommonRoleItemData>
	{
		// Token: 0x0603A4F8 RID: 238840 RVA: 0x00EC8694 File Offset: 0x00EC6894
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

		// Token: 0x0603A4F9 RID: 238841 RVA: 0x00EC877C File Offset: 0x00EC697C
		protected override void OnStart()
		{
			this.ItemGrid = new SmallItemGrid();
			this.ItemGrid.Initialize(base.GetItem(3).GetOwner());
		}

		// Token: 0x0603A4FA RID: 238842 RVA: 0x00EC87A0 File Offset: 0x00EC69A0
		[NullableContext(1)]
		public override void Refresh(ICommonRoleItemData data, bool isSelected, int gridIndex)
		{
			this.ItemData = data;
			CharacterSmallItemGrid characterSmallItemGrid = new CharacterSmallItemGrid();
			characterSmallItemGrid.Data = data;
			characterSmallItemGrid.ItemConfigId = new int?(data.RoleId);
			characterSmallItemGrid.BottomText = data.RoleName;
			characterSmallItemGrid.IsCookUp = new bool?(data.IsBuff);
			int? currentCookRoleId = ModelBase<CookModel>.Instance.CurrentCookRoleId;
			int roleId = data.RoleId;
			characterSmallItemGrid.IsReceivedVisible = new bool?(currentCookRoleId.GetValueOrDefault() == roleId & currentCookRoleId != null);
			CharacterSmallItemGrid parameters = characterSmallItemGrid;
			this.ItemGrid.Apply<CharacterSmallItemGrid>(parameters);
			this.SetName();
			this.SetInfoText();
			this.Selected(isSelected, false);
			base.GetText(2).OnSelfLanguageChange.Bind(new Action(this.SetInfoText));
		}

		// Token: 0x0603A4FB RID: 238843 RVA: 0x00EC885B File Offset: 0x00EC6A5B
		public override void Clear()
		{
			base.GetText(2).OnSelfLanguageChange.Unbind();
		}

		// Token: 0x0603A4FC RID: 238844 RVA: 0x00EC886E File Offset: 0x00EC6A6E
		protected override void OnBeforeDestroy()
		{
			this.ItemGrid.Destroy(null);
			this.ItemGrid = null;
		}

		// Token: 0x0603A4FD RID: 238845 RVA: 0x00EC8883 File Offset: 0x00EC6A83
		private void SetName()
		{
			base.GetText(1).SetText(this.ItemData.RoleName, true);
		}

		// Token: 0x0603A4FE RID: 238846 RVA: 0x00EC88A0 File Offset: 0x00EC6AA0
		private void SetInfoText()
		{
			if (Singleton<CommonManager>.Instance.CheckIsBuff(this.ItemData.RoleId, this.ItemData.ItemId))
			{
				string infoText = Singleton<CommonManager>.Instance.GetInfoText(this.ItemData.RoleId);
				base.GetText(2).SetText(infoText, true);
				return;
			}
			string textById = ConfigBase<TextConfig>.Instance.GetTextById(Singleton<CommonManager>.Instance.GetDefaultRoleText());
			base.GetText(2).SetText(textById, true);
		}

		// Token: 0x0603A4FF RID: 238847 RVA: 0x00EC8917 File Offset: 0x00EC6B17
		[NullableContext(1)]
		public void BindOnClickedCallback(Action<int> onItemButtonClicked)
		{
			this.OnClickedCallback = onItemButtonClicked;
		}

		// Token: 0x0603A500 RID: 238848 RVA: 0x00EC8920 File Offset: 0x00EC6B20
		public override void OnSelected(bool fireEvent)
		{
			this.Selected(true, true);
		}

		// Token: 0x0603A501 RID: 238849 RVA: 0x00EC892A File Offset: 0x00EC6B2A
		public override void OnDeselected(bool fireEvent)
		{
			this.Selected(false, true);
		}

		// Token: 0x0603A502 RID: 238850 RVA: 0x00EC8934 File Offset: 0x00EC6B34
		private void Selected(bool bSelected, bool fireEvent = true)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (bSelected)
			{
				extendToggle.SetToggleState(EToggleState.ETT_Checked, fireEvent, false, false);
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0603A503 RID: 238851 RVA: 0x00EC8963 File Offset: 0x00EC6B63
		private void OnClick(EToggleState state)
		{
			if (this.OnClickedCallback != null)
			{
				this.OnClickedCallback(this.ItemData.RoleId);
			}
		}

		// Token: 0x04021092 RID: 135314
		private ICommonRoleItemData ItemData;

		// Token: 0x04021093 RID: 135315
		private SmallItemGrid ItemGrid;

		// Token: 0x04021094 RID: 135316
		private Action<int> OnClickedCallback;

		// Token: 0x0200B9B7 RID: 47543
		[NullableContext(0)]
		private class EHelpRoleItemDefine
		{
			// Token: 0x0403962C RID: 235052
			public const int HelpRoleExtendToggle = 0;

			// Token: 0x0403962D RID: 235053
			public const int RoleNameText = 1;

			// Token: 0x0403962E RID: 235054
			public const int CommonInfoText = 2;

			// Token: 0x0403962F RID: 235055
			public const int ItemGridItem = 3;
		}
	}
}
