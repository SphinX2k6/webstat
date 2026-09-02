using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk
{
	// Token: 0x02006964 RID: 26980
	[NullableContext(1)]
	[Nullable(0)]
	public class AdamFormationRoleContainer : UiPanelBase, IDynamicScrollItem<AdamFormationRoleGroupInfo>
	{
		// Token: 0x06042F11 RID: 274193 RVA: 0x0112F684 File Offset: 0x0112D884
		public UniTask Init(UUIItem actor)
		{
			AdamFormationRoleContainer.<Init>d__5 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<AdamFormationRoleContainer.<Init>d__5>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06042F12 RID: 274194 RVA: 0x0112F6CF File Offset: 0x0112D8CF
		public void ClearItem()
		{
		}

		// Token: 0x06042F13 RID: 274195 RVA: 0x0112F6D1 File Offset: 0x0112D8D1
		[return: Nullable(2)]
		public AUIBaseActor GetUsingItem(AdamFormationRoleGroupInfo data)
		{
			if (data.IsTitleType)
			{
				UUIItem item = base.GetItem(2);
				return ((item != null) ? item.GetOwner() : null) as AUIBaseActor;
			}
			UUIGridLayout gridLayout = base.GetGridLayout(0);
			return ((gridLayout != null) ? gridLayout.GetOwner() : null) as AUIBaseActor;
		}

		// Token: 0x06042F14 RID: 274196 RVA: 0x0112F70C File Offset: 0x0112D90C
		public void Update(AdamFormationRoleGroupInfo data, int index)
		{
			this.Data = data;
			if (data.IsTitleType)
			{
				this.RefreshTitle();
				return;
			}
			this.RefreshRoleList();
		}

		// Token: 0x06042F15 RID: 274197 RVA: 0x0112F72A File Offset: 0x0112D92A
		public void InitData(AdamFormationRoleGroupInfo data)
		{
			this.Data = data;
		}

		// Token: 0x06042F16 RID: 274198 RVA: 0x0112F733 File Offset: 0x0112D933
		public void Refresh()
		{
			if (this.Data.IsTitleType)
			{
				this.RefreshTitle();
				return;
			}
			GenericLayout<WeeklyRogueRoleGridItem, RoleDataBase> roleLayout = this.RoleLayout;
			if (roleLayout == null)
			{
				return;
			}
			roleLayout.RefreshWithoutDataSync();
		}

		// Token: 0x06042F17 RID: 274199 RVA: 0x0112F75C File Offset: 0x0112D95C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIGridLayout)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIItem))
			};
		}

		// Token: 0x06042F18 RID: 274200 RVA: 0x0112F7E4 File Offset: 0x0112D9E4
		protected override void OnStart()
		{
			base.GetItem(2).SetUIActive(false);
			base.GetGridLayout(0).RootUIComp.Get().SetUIActive(false);
		}

		// Token: 0x06042F19 RID: 274201 RVA: 0x0112F818 File Offset: 0x0112DA18
		private void RefreshTitle()
		{
			base.GetGridLayout(0).RootUIComp.Get().SetUIActive(false);
			AdamFormationRoleGroupTitleInfo titleInfo = this.Data.TitleInfo;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), titleInfo.TitleTextId, Array.Empty<object>());
			base.GetItem(4).SetUIActive(titleInfo.IsEmpty);
			base.GetItem(2).SetUIActive(true);
		}

		// Token: 0x06042F1A RID: 274202 RVA: 0x0112F888 File Offset: 0x0112DA88
		private void RefreshRoleList()
		{
			base.GetItem(2).SetUIActive(false);
			if (this.RoleLayout == null)
			{
				this.RoleLayout = new GenericLayout<WeeklyRogueRoleGridItem, RoleDataBase>(base.GetGridLayout(0), new Func<WeeklyRogueRoleGridItem>(this.OnCreateRole), null, false, true);
			}
			RoleDataBase[] newDataList = this.Data.DataList ?? Array.Empty<RoleDataBase>();
			Action callBack = delegate()
			{
				Dictionary<int, RoleDataBase> roleIndexMap = ModelBase<RoleSelectModel>.Instance.RoleIndexMap;
				foreach (RoleDataBase roleDataBase in roleIndexMap.Values)
				{
					int num = Array.IndexOf<RoleDataBase>(this.RoleDataList, roleDataBase);
					int num2 = Array.IndexOf<RoleDataBase>(newDataList, roleDataBase);
					if (num != num2)
					{
						ModelBase<RoleSelectModel>.Instance.SelectedRoleSet.Remove(roleDataBase.GetDataId());
						WeeklyRogueRoleGridItem layoutItemByKey = this.RoleLayout.GetLayoutItemByKey(roleDataBase.GetDataId());
						if (layoutItemByKey != null)
						{
							layoutItemByKey.OnDeselected(false);
						}
					}
				}
				foreach (RoleDataBase roleDataBase2 in roleIndexMap.Values)
				{
					ModelBase<RoleSelectModel>.Instance.SelectedRoleSet.Add(roleDataBase2.GetDataId());
					WeeklyRogueRoleGridItem layoutItemByKey2 = this.RoleLayout.GetLayoutItemByKey(roleDataBase2.GetDataId());
					if (layoutItemByKey2 != null)
					{
						layoutItemByKey2.OnForceSelected(true);
					}
				}
				this.RoleDataList = newDataList;
			};
			bool flag = newDataList.Length != 0;
			this.RoleLayout.GetRootUiItem().SetUIActive(flag);
			if (flag)
			{
				this.RoleLayout.RefreshByData(new List<RoleDataBase>(newDataList), callBack, true);
			}
		}

		// Token: 0x06042F1B RID: 274203 RVA: 0x0112F936 File Offset: 0x0112DB36
		private AdamFormationRoleGridItem OnCreateRole()
		{
			AdamFormationRoleGridItem adamFormationRoleGridItem = new AdamFormationRoleGridItem();
			adamFormationRoleGridItem.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.ToggleFunction));
			adamFormationRoleGridItem.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.CanExecuteChangeFunction));
			adamFormationRoleGridItem.RecommendedRoleIdSet = this.RecommendedRoleIdSet;
			return adamFormationRoleGridItem;
		}

		// Token: 0x06042F1C RID: 274204 RVA: 0x0112F970 File Offset: 0x0112DB70
		protected void ToggleFunction(MediumItemGridExtendCallback param)
		{
			Dictionary<int, RoleDataBase> roleIndexMap = ModelBase<RoleSelectModel>.Instance.RoleIndexMap;
			HashSet<int> selectedRoleSet = ModelBase<RoleSelectModel>.Instance.SelectedRoleSet;
			RoleDataBase roleDataBase = param.Data as RoleDataBase;
			if (roleDataBase == null)
			{
				return;
			}
			if (param.State == EToggleState.ETT_UnChecked)
			{
				using (Dictionary<int, RoleDataBase>.Enumerator enumerator = roleIndexMap.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						KeyValuePair<int, RoleDataBase> keyValuePair = enumerator.Current;
						if (keyValuePair.Value == roleDataBase)
						{
							roleIndexMap.Remove(keyValuePair.Key);
							selectedRoleSet.Remove(roleDataBase.GetDataId());
							break;
						}
					}
					goto IL_BB;
				}
			}
			if (param.State == EToggleState.ETT_Checked)
			{
				for (int i = 1; i <= 3; i++)
				{
					if (!roleIndexMap.ContainsKey(i))
					{
						roleIndexMap[i] = roleDataBase;
						selectedRoleSet.Add(roleDataBase.GetDataId());
						break;
					}
				}
			}
			IL_BB:
			GenericLayout<WeeklyRogueRoleGridItem, RoleDataBase> roleLayout = this.RoleLayout;
			if (roleLayout != null)
			{
				roleLayout.RefreshWithoutDataSync();
			}
			Action<RoleDataBase> refreshRole = this.RefreshRole;
			if (refreshRole == null)
			{
				return;
			}
			refreshRole(roleDataBase);
		}

		// Token: 0x06042F1D RID: 274205 RVA: 0x0112FA6C File Offset: 0x0112DC6C
		[NullableContext(2)]
		protected bool CanExecuteChangeFunction(object data, bool isForceSelected, EToggleState state)
		{
			if (state != EToggleState.ETT_UnChecked)
			{
				return true;
			}
			if (ModelBase<RoleSelectModel>.Instance.RoleIndexMap.Count >= 3)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditBattleTeamRoleFull", Array.Empty<object>());
				return false;
			}
			RoleDataBase roleDataBase = data as RoleDataBase;
			if (roleDataBase == null)
			{
				return true;
			}
			int roleId = roleDataBase.GetRoleId();
			using (Dictionary<int, RoleDataBase>.ValueCollection.Enumerator enumerator = ModelBase<RoleSelectModel>.Instance.RoleIndexMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.GetRoleId() == roleId)
					{
						ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Text_SameRole_Text", Array.Empty<object>());
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x040254BA RID: 152762
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<RoleDataBase> RefreshRole;

		// Token: 0x040254BB RID: 152763
		[Nullable(2)]
		public IReadOnlySet<int> RecommendedRoleIdSet;

		// Token: 0x040254BC RID: 152764
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<WeeklyRogueRoleGridItem, RoleDataBase> RoleLayout;

		// Token: 0x040254BD RID: 152765
		private AdamFormationRoleGroupInfo Data;

		// Token: 0x040254BE RID: 152766
		private RoleDataBase[] RoleDataList = Array.Empty<RoleDataBase>();
	}
}
