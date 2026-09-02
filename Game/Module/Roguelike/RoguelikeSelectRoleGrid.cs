using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005197 RID: 20887
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeSelectRoleGrid : UiPanelBase, IDynamicScrollItem<RoguelikeSelectRoleData>
	{
		// Token: 0x06035B9D RID: 220061 RVA: 0x00D809BC File Offset: 0x00D7EBBC
		public RoguelikeSelectRoleGrid(RoguelikeSelectRoleData data)
		{
			this.Data = data;
		}

		// Token: 0x06035B9E RID: 220062 RVA: 0x00D809D6 File Offset: 0x00D7EBD6
		public void BindSelectRoleCallBack(Action<RoleDataBase, int> selectCallback)
		{
			this.SelectRoleCallBack = selectCallback;
		}

		// Token: 0x06035B9F RID: 220063 RVA: 0x00D809DF File Offset: 0x00D7EBDF
		public AUIBaseActor GetUsingItem(RoguelikeSelectRoleData data)
		{
			return base.GetRootItem().GetOwner() as AUIBaseActor;
		}

		// Token: 0x06035BA0 RID: 220064 RVA: 0x00D809F1 File Offset: 0x00D7EBF1
		public void Update(RoguelikeSelectRoleData data, int index)
		{
			this.Data = data;
			this.RefreshData().AsTask();
		}

		// Token: 0x06035BA1 RID: 220065 RVA: 0x00D80A08 File Offset: 0x00D7EC08
		public UniTask Init(UUIItem actor)
		{
			RoguelikeSelectRoleGrid.<Init>d__9 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<RoguelikeSelectRoleGrid.<Init>d__9>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06035BA2 RID: 220066 RVA: 0x00D80A54 File Offset: 0x00D7EC54
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035BA3 RID: 220067 RVA: 0x00D80AE0 File Offset: 0x00D7ECE0
		public UniTask RefreshData()
		{
			RoguelikeSelectRoleGrid.<RefreshData>d__12 <RefreshData>d__;
			<RefreshData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshData>d__.<>4__this = this;
			<RefreshData>d__.<>1__state = -1;
			<RefreshData>d__.<>t__builder.Start<RoguelikeSelectRoleGrid.<RefreshData>d__12>(ref <RefreshData>d__);
			return <RefreshData>d__.<>t__builder.Task;
		}

		// Token: 0x06035BA4 RID: 220068 RVA: 0x00D80B24 File Offset: 0x00D7ED24
		private void SelectRole(MediumItemGridExtendCallback callbackParameter)
		{
			if (callbackParameter.State == EToggleState.ETT_UnChecked)
			{
				RoleDataBase roleDataBase = callbackParameter.Data as RoleDataBase;
				if (roleDataBase.IsTrialRole())
				{
					ModelBase<RoguelikeModel>.Instance.EditFormationRoleList = new List<int>
					{
						roleDataBase.GetDataId()
					};
				}
				else
				{
					ModelBase<RoguelikeModel>.Instance.EditFormationRoleList = new List<int>
					{
						roleDataBase.GetRoleId()
					};
				}
				if (RoguelikeSelectRoleGrid.CurSelectRoleItem != null)
				{
					RoguelikeSelectRoleGrid.CurSelectRoleItem.SetSelected(false, false);
				}
				RoguelikeSelectRoleGrid.CurSelectRoleItem = (callbackParameter.MediumItemGrid as RogueRoleSelectionItemGrid);
				RoguelikeSelectRoleGrid.CurSelectRoleId = roleDataBase.GetDataId();
				ControllerBase<RoleController>.Instance.OnSelectedRoleChangeByConfig(roleDataBase.GetDataId(), roleDataBase.GetRoleSkinId(), null);
				if (this.SelectRoleCallBack != null)
				{
					this.SelectRoleCallBack(roleDataBase, (int)this.Data.Type);
				}
			}
		}

		// Token: 0x06035BA5 RID: 220069 RVA: 0x00D80BEC File Offset: 0x00D7EDEC
		public void ClearItem()
		{
			base.Destroy(null);
		}

		// Token: 0x06035BA7 RID: 220071 RVA: 0x00D80C00 File Offset: 0x00D7EE00
		[CompilerGenerated]
		private void <RefreshData>g__UpdateFunc|12_0(RogueRoleSelectionItemGrid item, RoleDataBase data)
		{
			bool flag = (this.Data.LimitRoleList.Count > 0 && !this.Data.LimitRoleList.Contains(data.GetRoleId())) || data.GetLevelData().GetLevel() == 0;
			bool flag2 = ModelBase<RoleModel>.Instance.GetRoleInstanceById(data.GetDataId()) != null;
			bool flag3 = this.Data.LimitRoleList.Contains(data.GetDataId());
			bool flag4 = (flag2 ? ModelBase<WeaponModel>.Instance.GetWeaponDataByRoleDataId(data.GetDataId(), true).GetLevel() : 0) < this.Data.AddWeaponLevel && !data.IsTrialRole() && flag2 && flag3;
			bool flag5 = data.GetLevelData().GetLevel() < this.Data.AddRoleLevel && !data.IsTrialRole() && flag2 && flag3;
			CharacterMediumItemGrid parameters = new CharacterMediumItemGrid
			{
				Data = data,
				ItemConfigId = new int?(data.GetRoleId()),
				SkinId = data.GetRoleSkinId(),
				BottomTextId = (((flag5 || flag4) && !flag && !data.IsTrialRole()) ? "" : ((data.GetLevelData().GetLevel() != 0) ? "Text_LevelShow_Text" : "Text_Role_Not_Have")),
				BottomTextParameter = new object[]
				{
					data.GetLevelData().GetLevel()
				},
				ElementId = new int?(data.GetRoleConfig().ElementId),
				IsTrialRoleVisible = new bool?(data.IsTrialRole()),
				IsNewVisible = new bool?(false),
				IsDisable = new bool?(flag),
				IsRecommendVisible = new bool?(this.Data.RecommendedRoleList.Contains(data.GetRoleId()))
			};
			item.Apply<CharacterMediumItemGrid>(parameters);
			item.BindOnExtendToggleClicked(new Action<MediumItemGridExtendCallback>(this.SelectRole));
			item.SetSelected(RoguelikeSelectRoleGrid.CurSelectRoleId == data.GetDataId(), false);
			if (item != null)
			{
				item.SetAddLevelComponent(this.Data.AddRoleLevel, this.Data.MaxLevel, flag5 || flag4);
			}
		}

		// Token: 0x0401ED4F RID: 126287
		public List<RogueRoleSelectionItemGrid> RoleItemList = new List<RogueRoleSelectionItemGrid>();

		// Token: 0x0401ED50 RID: 126288
		[StaticVariableRuleIgnore]
		public static RogueRoleSelectionItemGrid CurSelectRoleItem;

		// Token: 0x0401ED51 RID: 126289
		[StaticVariableRuleIgnore]
		public static int CurSelectRoleId;

		// Token: 0x0401ED52 RID: 126290
		public RoguelikeSelectRoleData Data;

		// Token: 0x0401ED53 RID: 126291
		private Action<RoleDataBase, int> SelectRoleCallBack;

		// Token: 0x0200B15E RID: 45406
		[NullableContext(0)]
		private class ERoguelikeSelectRoleGridDefine
		{
			// Token: 0x0403700A RID: 225290
			public const int TxtTitle = 0;

			// Token: 0x0403700B RID: 225291
			public const int ItemContainer = 1;

			// Token: 0x0403700C RID: 225292
			public const int RoleItem = 2;
		}
	}
}
