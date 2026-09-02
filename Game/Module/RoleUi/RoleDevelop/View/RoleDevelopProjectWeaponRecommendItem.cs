using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.RoleUi.RoleDevelop.Data;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.View
{
	// Token: 0x020050C5 RID: 20677
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleDevelopProjectWeaponRecommendItem : UiPanelBase
	{
		// Token: 0x06035461 RID: 218209 RVA: 0x00D5CACC File Offset: 0x00D5ACCC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 13;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickSwitch));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(12, new Action(this.OnClickCall));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035462 RID: 218210 RVA: 0x00D5CD08 File Offset: 0x00D5AF08
		protected override UniTask OnBeforeStartAsync()
		{
			RoleDevelopProjectWeaponRecommendItem.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoleDevelopProjectWeaponRecommendItem.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035463 RID: 218211 RVA: 0x00D5CD4C File Offset: 0x00D5AF4C
		private void InitWeaponItemGrid()
		{
			this.WeaponItemGrid = new SmallItemGrid();
			this.WeaponItemGrid.Initialize(base.GetItem(3).GetOwner());
			this.WeaponItemGrid.BindOnExtendToggleClicked(new Action<MediumItemGridExtendCallback>(this.OnClickWeaponItemGrid));
			this.WeaponItemGrid.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.OnCanExecuteWeaponItemGridChange));
		}

		// Token: 0x06035464 RID: 218212 RVA: 0x00D5CDA9 File Offset: 0x00D5AFA9
		private void InitLayout()
		{
			this.ItemLayout = new GenericLayout<RoleDevelopProjectWeaponRecommendListItem, RoleDevelopProjectWeaponRecommendListItemData>(base.GetVerticalLayout(9), new Func<RoleDevelopProjectWeaponRecommendListItem>(this.CreateItem), null, false, true);
		}

		// Token: 0x06035465 RID: 218213 RVA: 0x00D5CDD0 File Offset: 0x00D5AFD0
		private UniTask InitButtonItem()
		{
			RoleDevelopProjectWeaponRecommendItem.<InitButtonItem>d__12 <InitButtonItem>d__;
			<InitButtonItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitButtonItem>d__.<>4__this = this;
			<InitButtonItem>d__.<>1__state = -1;
			<InitButtonItem>d__.<>t__builder.Start<RoleDevelopProjectWeaponRecommendItem.<InitButtonItem>d__12>(ref <InitButtonItem>d__);
			return <InitButtonItem>d__.<>t__builder.Task;
		}

		// Token: 0x06035466 RID: 218214 RVA: 0x00D5CE13 File Offset: 0x00D5B013
		public void RefreshByData(RoleDevelopData data)
		{
			this.Data = data;
			this.RefreshSwitchButton();
			this.RefreshWeaponView();
			this.RefreshLayout();
		}

		// Token: 0x06035467 RID: 218215 RVA: 0x00D5CE30 File Offset: 0x00D5B030
		private void RefreshSwitchButton()
		{
			if (this.Data == null)
			{
				return;
			}
			bool uiactive = false;
			int id = this.Data.GetId();
			if (!ModelBase<RoleModel>.Instance.IsRoleOwned(id))
			{
				if (!RoleDevelopUtil.IsAnyProspectRole(id))
				{
					uiactive = true;
				}
			}
			else
			{
				WeaponInstance weaponInstance = this.Data.GetDevelopRoleData().GetWeaponInstance();
				uiactive = (weaponInstance != null && ModelBase<WeaponModel>.Instance.IsWeaponHighQuality(weaponInstance));
			}
			base.GetItem(11).SetUIActive(uiactive);
		}

		// Token: 0x06035468 RID: 218216 RVA: 0x00D5CEA0 File Offset: 0x00D5B0A0
		private void RefreshWeaponView()
		{
			if (this.Data == null)
			{
				return;
			}
			RoleDevelopRoleBaseData developRoleData = this.Data.GetDevelopRoleData();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), developRoleData.GetWeaponName(), Array.Empty<object>());
			if (!ModelBase<RoleModel>.Instance.IsRoleOwned(this.Data.GetId()))
			{
				int weaponType = this.Data.GetProjectData().GetWeaponType();
				RoleDevWeaponItem? roleDevWeaponItemConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevWeaponItemConfig(weaponType);
				this.WeaponItemGrid.SetIconByPath(roleDevWeaponItemConfig.Value.WeaponTypeIcon);
				this.WeaponItemGrid.SetBottomTextVisible(false);
				this.WeaponItemGrid.SetQuality(null);
				base.GetText(5).SetUIActive(false);
				base.GetItem(6).SetUIActive(false);
				base.GetButton(12).RootUIComp.Get().SetUIActive(false);
			}
			else
			{
				WeaponInstance weaponInstance = developRoleData.GetWeaponInstance();
				int itemId = weaponInstance.GetItemId();
				if (ModelBase<WeaponModel>.Instance.IsWeaponHighQuality(weaponInstance))
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "RoleProject_Tips01", Array.Empty<object>());
				}
				else
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "RoleProject_Tips08", Array.Empty<object>());
				}
				PropSmallItemGrid parameters = new PropSmallItemGrid
				{
					ItemConfigId = new int?(itemId),
					BottomTextId = "Text_LevelShow_Text",
					BottomTextParameter = new object[]
					{
						weaponInstance.GetLevel()
					},
					Data = this.Data
				};
				this.WeaponItemGrid.Apply<PropSmallItemGrid>(parameters);
				base.GetItem(6).SetUIActive(true);
				List<int> hotWeaponGachaIds = RoleDevelopUtil.GetHotWeaponGachaIds(itemId, true);
				base.GetButton(12).RootUIComp.Get().SetUIActive(hotWeaponGachaIds.Count > 0);
			}
			this.BtnJumpItem.SetUiActive(true);
			this.BtnPerfectJumpItem.SetUiActive(false);
		}

		// Token: 0x06035469 RID: 218217 RVA: 0x00D5D094 File Offset: 0x00D5B294
		private void RefreshLayout()
		{
			if (this.Data == null)
			{
				this.ItemLayout.RefreshByData(new List<RoleDevelopProjectWeaponRecommendListItemData>(), null, false);
				return;
			}
			int id = this.Data.GetId();
			int[] weaponRecommendListConfig = ConfigBase<RoleDevConfig>.Instance.GetWeaponRecommendListConfig(id);
			if (weaponRecommendListConfig == null)
			{
				this.ItemLayout.RefreshByData(new List<RoleDevelopProjectWeaponRecommendListItemData>(), null, false);
				return;
			}
			List<RoleDevelopProjectWeaponRecommendListItemData> list = new List<RoleDevelopProjectWeaponRecommendListItemData>();
			for (int i = 0; i < weaponRecommendListConfig.Length; i++)
			{
				int recommendWeaponId = weaponRecommendListConfig[i];
				RoleDevelopProjectWeaponRecommendListItemData roleDevelopProjectWeaponRecommendListItemData = new RoleDevelopProjectWeaponRecommendListItemData
				{
					DevelopRoleId = id,
					RecommendWeaponId = recommendWeaponId
				};
				if (i < this.WeaponRecommendLogSubPageList.Count)
				{
					ERoleDevelopLogSubPage value = this.WeaponRecommendLogSubPageList[i];
					roleDevelopProjectWeaponRecommendListItemData.LogRoleId = new int?(id);
					roleDevelopProjectWeaponRecommendListItemData.LogMainPage = new ERoleDevelopCategoryType?(ERoleDevelopCategoryType.Weapon);
					roleDevelopProjectWeaponRecommendListItemData.LogSubPage = new ERoleDevelopLogSubPage?(value);
				}
				list.Add(roleDevelopProjectWeaponRecommendListItemData);
			}
			this.ItemLayout.RefreshByData(list, null, false);
		}

		// Token: 0x0603546A RID: 218218 RVA: 0x00D5D173 File Offset: 0x00D5B373
		public void SetClickSwitchCallback(Action callback)
		{
			this.OnClickSwitchCallback = callback;
		}

		// Token: 0x0603546B RID: 218219 RVA: 0x00D5D17C File Offset: 0x00D5B37C
		private void OnClickSwitch()
		{
			Action onClickSwitchCallback = this.OnClickSwitchCallback;
			if (onClickSwitchCallback == null)
			{
				return;
			}
			onClickSwitchCallback();
		}

		// Token: 0x0603546C RID: 218220 RVA: 0x00D5D190 File Offset: 0x00D5B390
		private void OnClickCall()
		{
			if (this.Data == null || !ModelBase<RoleModel>.Instance.IsRoleOwned(this.Data.GetId()))
			{
				return;
			}
			WeaponInstance weaponInstance = this.Data.GetDevelopRoleData().GetWeaponInstance();
			if (weaponInstance == null)
			{
				return;
			}
			List<int> hotWeaponGachaIds = RoleDevelopUtil.GetHotWeaponGachaIds(weaponInstance.GetItemId(), true);
			if (hotWeaponGachaIds.Count > 0)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.GachaMainView, hotWeaponGachaIds[0], null);
			}
		}

		// Token: 0x0603546D RID: 218221 RVA: 0x00D5D204 File Offset: 0x00D5B404
		[NullableContext(2)]
		private bool OnCanExecuteWeaponItemGridChange(object data, bool isForceSelected, EToggleState state)
		{
			return false;
		}

		// Token: 0x0603546E RID: 218222 RVA: 0x00D5D208 File Offset: 0x00D5B408
		private void OnClickWeaponItemGrid(MediumItemGridExtendCallback callback)
		{
			if (this.Data == null)
			{
				return;
			}
			WeaponInstance weaponInstance = this.Data.GetDevelopRoleData().GetWeaponInstance();
			if (weaponInstance != null)
			{
				int valueOrDefault = weaponInstance.GetIncId().GetValueOrDefault();
				int itemId = weaponInstance.GetItemId();
				if (valueOrDefault > 0)
				{
					ControllerBase<ItemController>.Instance.OpenItemTipsByItemUid(valueOrDefault, itemId, true, null);
					return;
				}
				ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(itemId, true, null);
			}
		}

		// Token: 0x0603546F RID: 218223 RVA: 0x00D5D268 File Offset: 0x00D5B468
		private void OnClickWeaponJump(int value)
		{
			if (this.Data == null)
			{
				return;
			}
			WeaponInstance weaponInstance = this.Data.GetDevelopRoleData().GetWeaponInstance();
			if (weaponInstance == null)
			{
				return;
			}
			int? incId = weaponInstance.GetIncId();
			RoleDevelopUtil.OpenWeaponReplaceView(this.Data.GetId(), incId.GetValueOrDefault());
			ControllerBase<RoleController>.Instance.LogRoleDevelopClick(this.Data.GetId(), ERoleDevelopCategoryType.Weapon, ERoleDevelopLogSubPage.WeaponDevelopReplace, null);
		}

		// Token: 0x06035470 RID: 218224 RVA: 0x00D5D2D1 File Offset: 0x00D5B4D1
		private RoleDevelopProjectWeaponRecommendListItem CreateItem()
		{
			return new RoleDevelopProjectWeaponRecommendListItem();
		}

		// Token: 0x06035471 RID: 218225 RVA: 0x00D5D2D8 File Offset: 0x00D5B4D8
		public unsafe RoleDevelopProjectWeaponRecommendItem()
		{
			int num = 3;
			List<ERoleDevelopLogSubPage> list = new List<ERoleDevelopLogSubPage>(num);
			CollectionsMarshal.SetCount<ERoleDevelopLogSubPage>(list, num);
			Span<ERoleDevelopLogSubPage> span = CollectionsMarshal.AsSpan<ERoleDevelopLogSubPage>(list);
			int num2 = 0;
			*span[num2] = ERoleDevelopLogSubPage.WeaponDevelopEquip1;
			num2++;
			*span[num2] = ERoleDevelopLogSubPage.WeaponDevelopEquip2;
			num2++;
			*span[num2] = ERoleDevelopLogSubPage.WeaponDevelopEquip3;
			this.WeaponRecommendLogSubPageList = list;
			base..ctor();
		}

		// Token: 0x0401EA5B RID: 125531
		private readonly List<ERoleDevelopLogSubPage> WeaponRecommendLogSubPageList;

		// Token: 0x0401EA5C RID: 125532
		[Nullable(2)]
		private RoleDevelopData Data;

		// Token: 0x0401EA5D RID: 125533
		private SmallItemGrid WeaponItemGrid;

		// Token: 0x0401EA5E RID: 125534
		private ButtonItem BtnJumpItem;

		// Token: 0x0401EA5F RID: 125535
		private ButtonItem BtnPerfectJumpItem;

		// Token: 0x0401EA60 RID: 125536
		private GenericLayout<RoleDevelopProjectWeaponRecommendListItem, RoleDevelopProjectWeaponRecommendListItemData> ItemLayout;

		// Token: 0x0401EA61 RID: 125537
		[Nullable(2)]
		private Action OnClickSwitchCallback;

		// Token: 0x0200B05C RID: 45148
		[NullableContext(0)]
		public static class EComponentType
		{
			// Token: 0x04036B7B RID: 224123
			public const int BtnSwitch = 0;

			// Token: 0x04036B7C RID: 224124
			public const int PanelWeaponType = 1;

			// Token: 0x04036B7D RID: 224125
			public const int IconWeaponType = 2;

			// Token: 0x04036B7E RID: 224126
			public const int WeaponItem = 3;

			// Token: 0x04036B7F RID: 224127
			public const int TxtWeaponName = 4;

			// Token: 0x04036B80 RID: 224128
			public const int TxtGoalLevel = 5;

			// Token: 0x04036B81 RID: 224129
			public const int PanelRight = 6;

			// Token: 0x04036B82 RID: 224130
			public const int BtnJump = 7;

			// Token: 0x04036B83 RID: 224131
			public const int BtnPerfectJump = 8;

			// Token: 0x04036B84 RID: 224132
			public const int PanelSubLayout = 9;

			// Token: 0x04036B85 RID: 224133
			public const int PanelSubItem = 10;

			// Token: 0x04036B86 RID: 224134
			public const int PanelRecommendSwitch = 11;

			// Token: 0x04036B87 RID: 224135
			public const int BtnCall = 12;
		}
	}
}
