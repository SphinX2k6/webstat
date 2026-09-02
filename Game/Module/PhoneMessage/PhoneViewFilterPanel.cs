using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhoneMessage
{
	// Token: 0x02005457 RID: 21591
	[NullableContext(1)]
	[Nullable(0)]
	internal class PhoneViewFilterPanel : UiViewBase
	{
		// Token: 0x06037024 RID: 225316 RVA: 0x00DF65C4 File Offset: 0x00DF47C4
		public PhoneViewFilterPanel(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06037025 RID: 225317 RVA: 0x00DF65D8 File Offset: 0x00DF47D8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnBtnResetClick)),
				new ValueTuple<int, Delegate>(1, new Action(this.OnBtnConfirmClick))
			};
		}

		// Token: 0x06037026 RID: 225318 RVA: 0x00DF669C File Offset: 0x00DF489C
		protected override void OnStart()
		{
			this.TempSelectedFilterIdSet = new HashSet<int>();
			foreach (int item in ModelBase<PhoneMsgModel>.Instance.SelectedFilterIdSet)
			{
				this.TempSelectedFilterIdSet.Add(item);
			}
			UUIVerticalLayout verticalLayout = base.GetVerticalLayout(2);
			if (verticalLayout != null)
			{
				this.FilterLayout = new GenericLayout<PanelFilter, int>(verticalLayout, new Func<PanelFilter>(this.CreateFilterItem), null, false, true);
			}
			IEnumerable<ChatFilterType> allChatFilterTypeConfigList = ConfigBase<PhoneMsgConfig>.Instance.GetAllChatFilterTypeConfigList();
			if (allChatFilterTypeConfigList == null)
			{
				return;
			}
			List<int> list = new List<int>();
			foreach (ChatFilterType chatFilterType in allChatFilterTypeConfigList)
			{
				list.Add(chatFilterType.Id);
			}
			GenericLayout<PanelFilter, int> filterLayout = this.FilterLayout;
			if (filterLayout == null)
			{
				return;
			}
			filterLayout.RefreshByDataAsync(list, false, null);
		}

		// Token: 0x06037027 RID: 225319 RVA: 0x00DF67A4 File Offset: 0x00DF49A4
		private PanelFilter CreateFilterItem()
		{
			PanelFilter panelFilter = new PanelFilter();
			panelFilter.SetOnFilterTogItemClick(new Action<int, bool>(this.OnFilterTogItemClick));
			panelFilter.SetIsFilterSelected(new Func<int, bool>(this.CheckIsTempFilterSelected));
			return panelFilter;
		}

		// Token: 0x06037028 RID: 225320 RVA: 0x00DF67CF File Offset: 0x00DF49CF
		private bool CheckIsTempFilterSelected(int filterId)
		{
			return this.TempSelectedFilterIdSet.Contains(filterId);
		}

		// Token: 0x06037029 RID: 225321 RVA: 0x00DF67E0 File Offset: 0x00DF49E0
		private void OnBtnResetClick()
		{
			this.TempSelectedFilterIdSet.Clear();
			ModelBase<PhoneMsgModel>.Instance.ClearSelectedFilterIdSet();
			IEnumerable<ChatFilterType> allChatFilterTypeConfigList = ConfigBase<PhoneMsgConfig>.Instance.GetAllChatFilterTypeConfigList();
			if (allChatFilterTypeConfigList == null)
			{
				return;
			}
			List<int> list = new List<int>();
			foreach (ChatFilterType chatFilterType in allChatFilterTypeConfigList)
			{
				list.Add(chatFilterType.Id);
			}
			GenericLayout<PanelFilter, int> filterLayout = this.FilterLayout;
			if (filterLayout == null)
			{
				return;
			}
			filterLayout.RefreshByDataAsync(list, false, null);
		}

		// Token: 0x0603702A RID: 225322 RVA: 0x00DF6878 File Offset: 0x00DF4A78
		private void OnBtnConfirmClick()
		{
			ModelBase<PhoneMsgModel>.Instance.SetSelectedFilterIdSet(this.TempSelectedFilterIdSet);
			base.CloseMe(null);
		}

		// Token: 0x0603702B RID: 225323 RVA: 0x00DF6891 File Offset: 0x00DF4A91
		private void OnFilterTogItemClick(int filterId, bool isSelected)
		{
			if (isSelected)
			{
				this.TempSelectedFilterIdSet.Add(filterId);
				return;
			}
			this.TempSelectedFilterIdSet.Remove(filterId);
		}

		// Token: 0x0401FA5C RID: 129628
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<PanelFilter, int> FilterLayout;

		// Token: 0x0401FA5D RID: 129629
		private HashSet<int> TempSelectedFilterIdSet = new HashSet<int>();
	}
}
