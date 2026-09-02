using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004C9A RID: 19610
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleResonancePanelHandle : SpecialPanelHandleBase
	{
		// Token: 0x060331A8 RID: 209320 RVA: 0x00CCC7A4 File Offset: 0x00CCA9A4
		public RoleResonancePanelHandle(string type) : base(type)
		{
		}

		// Token: 0x170087BC RID: 34748
		// (get) Token: 0x060331A9 RID: 209321 RVA: 0x00CCC7D0 File Offset: 0x00CCA9D0
		private IReadOnlyList<TsUiNavigationBehaviorListener> LockList
		{
			get
			{
				if (this.SortLockListDirty)
				{
					this.SortLockListDirty = false;
					this.LockListInternal.Sort(delegate(TsUiNavigationBehaviorListener aListener, TsUiNavigationBehaviorListener bListener)
					{
						int num = aListener.IsValid() ? aListener.RootUIComp.Get().GetFlattenHierarchyIndex() : 0;
						int value2 = bListener.IsValid() ? bListener.RootUIComp.Get().GetFlattenHierarchyIndex() : 0;
						return num.CompareTo(value2);
					});
				}
				return this.LockListInternal;
			}
		}

		// Token: 0x170087BD RID: 34749
		// (get) Token: 0x060331AA RID: 209322 RVA: 0x00CCC81C File Offset: 0x00CCAA1C
		private IReadOnlyList<TsUiNavigationBehaviorListener> UnLockList
		{
			get
			{
				if (this.SortUnLockListDirty)
				{
					this.SortUnLockListDirty = false;
					this.UnLockListInternal.Sort(delegate(TsUiNavigationBehaviorListener aListener, TsUiNavigationBehaviorListener bListener)
					{
						int num = aListener.IsValid() ? aListener.RootUIComp.Get().GetFlattenHierarchyIndex() : 0;
						int value2 = bListener.IsValid() ? bListener.RootUIComp.Get().GetFlattenHierarchyIndex() : 0;
						return num.CompareTo(value2);
					});
				}
				return this.UnLockListInternal;
			}
		}

		// Token: 0x060331AB RID: 209323 RVA: 0x00CCC868 File Offset: 0x00CCAA68
		protected override List<TsUiNavigationBehaviorListener> OnGetSuitableNavigationListenerList(bool isDefault)
		{
			if (this.DefaultListener == null)
			{
				return new List<TsUiNavigationBehaviorListener>();
			}
			if (this.DefaultListener.IsCanFocus())
			{
				return new List<TsUiNavigationBehaviorListener>
				{
					this.DefaultListener
				};
			}
			int num = 6 - this.LockList.Count;
			int num2 = 0;
			for (int i = 0; i < this.LockList.Count; i++)
			{
				if (this.LockList[i] == this.DefaultListener)
				{
					num2 = i;
					break;
				}
			}
			return new List<TsUiNavigationBehaviorListener>
			{
				this.UnLockList[num + num2]
			};
		}

		// Token: 0x060331AC RID: 209324 RVA: 0x00CCC8FC File Offset: 0x00CCAAFC
		public void SetToggleSelectByGroupName(string groupName)
		{
			NavigationGroup navigationGroup = base.GetNavigationGroup(groupName);
			if (navigationGroup == null)
			{
				return;
			}
			this.GroupName = groupName;
			foreach (TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener in navigationGroup.ListenerList)
			{
				UUIExtendToggle uuiextendToggle = tsUiNavigationBehaviorListener.GetBehaviorComponent() as UUIExtendToggle;
				if (uuiextendToggle != null)
				{
					uuiextendToggle.bToggleOnSelect = true;
				}
			}
		}

		// Token: 0x060331AD RID: 209325 RVA: 0x00CCC970 File Offset: 0x00CCAB70
		public void ResetToggleSelect()
		{
			NavigationGroup navigationGroup = base.GetNavigationGroup(this.GroupName);
			if (navigationGroup == null)
			{
				return;
			}
			this.GroupName = "";
			foreach (TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener in navigationGroup.ListenerList)
			{
				UUIExtendToggle uuiextendToggle = tsUiNavigationBehaviorListener.GetBehaviorComponent() as UUIExtendToggle;
				if (uuiextendToggle != null)
				{
					uuiextendToggle.bToggleOnSelect = false;
				}
			}
		}

		// Token: 0x060331AE RID: 209326 RVA: 0x00CCC9EC File Offset: 0x00CCABEC
		[NullableContext(2)]
		public void SetDefaultNavigationListener(TsUiNavigationBehaviorListener listener)
		{
			this.DefaultListener = listener;
		}

		// Token: 0x060331AF RID: 209327 RVA: 0x00CCC9F5 File Offset: 0x00CCABF5
		public void AddLockNavigationListener(TsUiNavigationBehaviorListener listener)
		{
			this.LockListInternal.Add(listener);
			this.SortLockListDirty = true;
		}

		// Token: 0x060331B0 RID: 209328 RVA: 0x00CCCA0A File Offset: 0x00CCAC0A
		public void AddUnLockNavigationListener(TsUiNavigationBehaviorListener listener)
		{
			this.UnLockListInternal.Add(listener);
			this.SortUnLockListDirty = true;
		}

		// Token: 0x0401DB6A RID: 121706
		private const int MAX_NUM = 6;

		// Token: 0x0401DB6B RID: 121707
		public string GroupName = "";

		// Token: 0x0401DB6C RID: 121708
		[Nullable(2)]
		private TsUiNavigationBehaviorListener DefaultListener;

		// Token: 0x0401DB6D RID: 121709
		private readonly List<TsUiNavigationBehaviorListener> LockListInternal = new List<TsUiNavigationBehaviorListener>();

		// Token: 0x0401DB6E RID: 121710
		private bool SortLockListDirty;

		// Token: 0x0401DB6F RID: 121711
		private readonly List<TsUiNavigationBehaviorListener> UnLockListInternal = new List<TsUiNavigationBehaviorListener>();

		// Token: 0x0401DB70 RID: 121712
		private bool SortUnLockListDirty;
	}
}
