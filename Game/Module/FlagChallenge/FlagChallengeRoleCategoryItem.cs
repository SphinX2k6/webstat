using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D72 RID: 23922
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class FlagChallengeRoleCategoryItem : GridProxyAbstract<FlagChallengeRoleCategoryItemData>
	{
		// Token: 0x0603C422 RID: 246818 RVA: 0x00F49C0C File Offset: 0x00F47E0C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIGridLayout)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x0603C423 RID: 246819 RVA: 0x00F49C68 File Offset: 0x00F47E68
		protected override void OnStart()
		{
			UUIGridLayout gridLayout = base.GetGridLayout(1);
			this.RoleLayout = new GenericLayout<FlagChallengeRoleMediumGridItem, RoleDataBase>(gridLayout, new Func<FlagChallengeRoleMediumGridItem>(this.CreateRoleItem), null, false, true);
			this.AnimationController = (gridLayout.GetOwner().GetComponentByClass(UUIInturnAnimController.StaticClass()) as UUIInturnAnimController);
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnFlagChallengeRoleSelectCategoryUpdate, new Action<int>(this.OnFlagChallengeRoleSelectCategoryUpdate));
		}

		// Token: 0x0603C424 RID: 246820 RVA: 0x00F49CD4 File Offset: 0x00F47ED4
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnFlagChallengeRoleSelectCategoryUpdate, new Action<int>(this.OnFlagChallengeRoleSelectCategoryUpdate));
		}

		// Token: 0x0603C425 RID: 246821 RVA: 0x00F49CF4 File Offset: 0x00F47EF4
		public override void Refresh(FlagChallengeRoleCategoryItemData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			UUIText text = base.GetText(0);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.TitleKey, Array.Empty<object>());
			this.RoleLayout.RefreshByData(data.RoleList ?? new List<RoleDataBase>(), null, false);
			UUIInturnAnimController animationController = this.AnimationController;
			if (animationController == null)
			{
				return;
			}
			animationController.Play("", -1, false);
		}

		// Token: 0x0603C426 RID: 246822 RVA: 0x00F49D59 File Offset: 0x00F47F59
		private FlagChallengeRoleMediumGridItem CreateRoleItem()
		{
			FlagChallengeRoleMediumGridItem flagChallengeRoleMediumGridItem = new FlagChallengeRoleMediumGridItem();
			flagChallengeRoleMediumGridItem.SetOnSelectRole(new Action<int, EToggleState>(this.OnSelectRole));
			flagChallengeRoleMediumGridItem.SetCanSelectRole(new Func<int, EToggleState, bool>(this.CanSelectRole));
			return flagChallengeRoleMediumGridItem;
		}

		// Token: 0x0603C427 RID: 246823 RVA: 0x00F49D84 File Offset: 0x00F47F84
		private bool CanSelectRole(int roleId, EToggleState state)
		{
			return this.Data == null || this.Data.CanSelectRole == null || this.Data.CanSelectRole(roleId, state);
		}

		// Token: 0x0603C428 RID: 246824 RVA: 0x00F49DAF File Offset: 0x00F47FAF
		private void OnSelectRole(int roleId, EToggleState state)
		{
			if (this.Data != null && this.Data.OnSelectRole != null)
			{
				this.Data.OnSelectRole(roleId, state);
			}
			this.RoleLayout.RefreshWithoutDataSync();
		}

		// Token: 0x0603C429 RID: 246825 RVA: 0x00F49DE4 File Offset: 0x00F47FE4
		private void OnFlagChallengeRoleSelectCategoryUpdate(int roleId)
		{
			if (this.Data == null || this.Data.RoleList == null)
			{
				return;
			}
			bool flag = false;
			using (List<RoleDataBase>.Enumerator enumerator = this.Data.RoleList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.GetDataId() == roleId)
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				this.RoleLayout.RefreshWithoutDataSync();
			}
		}

		// Token: 0x0603C42A RID: 246826 RVA: 0x00F49E68 File Offset: 0x00F48068
		public override object GetKey(FlagChallengeRoleCategoryItemData data, int displayIndex)
		{
			return (int)data.CategoryType;
		}

		// Token: 0x04021E08 RID: 138760
		[Nullable(2)]
		private FlagChallengeRoleCategoryItemData Data;

		// Token: 0x04021E09 RID: 138761
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<FlagChallengeRoleMediumGridItem, RoleDataBase> RoleLayout;

		// Token: 0x04021E0A RID: 138762
		[Nullable(2)]
		private UUIInturnAnimController AnimationController;
	}
}
