using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.RoleUi.RoleDevelop.Data;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.View
{
	// Token: 0x020050BC RID: 20668
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleDevelopProjectPhantomPanel : RoleDevelopProjectBasePanel
	{
		// Token: 0x060353FD RID: 218109 RVA: 0x00D59844 File Offset: 0x00D57A44
		protected unsafe override void OnRegisterComponent()
		{
			int num = 11;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnClickSwitchButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060353FE RID: 218110 RVA: 0x00D59A18 File Offset: 0x00D57C18
		protected override UniTask OnBeforeStartAsync()
		{
			RoleDevelopProjectPhantomPanel.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoleDevelopProjectPhantomPanel.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060353FF RID: 218111 RVA: 0x00D59A5C File Offset: 0x00D57C5C
		private UniTask InitPhantomItems()
		{
			RoleDevelopProjectPhantomPanel.<InitPhantomItems>d__9 <InitPhantomItems>d__;
			<InitPhantomItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitPhantomItems>d__.<>4__this = this;
			<InitPhantomItems>d__.<>1__state = -1;
			<InitPhantomItems>d__.<>t__builder.Start<RoleDevelopProjectPhantomPanel.<InitPhantomItems>d__9>(ref <InitPhantomItems>d__);
			return <InitPhantomItems>d__.<>t__builder.Task;
		}

		// Token: 0x06035400 RID: 218112 RVA: 0x00D59AA0 File Offset: 0x00D57CA0
		private UniTask InitButtonItem()
		{
			RoleDevelopProjectPhantomPanel.<InitButtonItem>d__10 <InitButtonItem>d__;
			<InitButtonItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitButtonItem>d__.<>4__this = this;
			<InitButtonItem>d__.<>1__state = -1;
			<InitButtonItem>d__.<>t__builder.Start<RoleDevelopProjectPhantomPanel.<InitButtonItem>d__10>(ref <InitButtonItem>d__);
			return <InitButtonItem>d__.<>t__builder.Task;
		}

		// Token: 0x06035401 RID: 218113 RVA: 0x00D59AE3 File Offset: 0x00D57CE3
		private void InitLayout()
		{
			this.PhantomSuitLayout = new GenericLayout<RoleDevelopProjectPhantomSuitItem, RoleDevelopPhantomSuitData>(base.GetVerticalLayout(9), new Func<RoleDevelopProjectPhantomSuitItem>(this.CreatePhantomSuitItem), null, false, true);
		}

		// Token: 0x06035402 RID: 218114 RVA: 0x00D59B08 File Offset: 0x00D57D08
		protected override void OnRefreshView(bool forceRefresh)
		{
			if (RoleDevelopUtil.IsAnyProspectRole(this.Data.GetId()))
			{
				this.RootItem.SetUIActive(false);
				return;
			}
			this.RootItem.SetUIActive(true);
			RoleDevelopRoleBaseData developRoleData = this.Data.GetDevelopRoleData();
			int id = this.Data.GetId();
			if (this.FetterInitRoleId != id)
			{
				this.SelectPlanId = developRoleData.GetRecommendPlanId();
				this.SelectFirstVisionMonsterId = new int?(developRoleData.GetRecommendFirstVisionMonsterId());
				this.FetterInitRoleId = id;
			}
			UUIItem item = base.GetItem(0);
			this.RefreshPhantomSuitList(forceRefresh);
			if (!developRoleData.CanDevelopPhantom())
			{
				item.SetUIActive(false);
				return;
			}
			item.SetUIActive(true);
			base.GetItem(2).SetUIActive(false);
			this.RefreshPhantomItems();
		}

		// Token: 0x06035403 RID: 218115 RVA: 0x00D59BC0 File Offset: 0x00D57DC0
		private void RefreshPhantomSuitList(bool forceRefresh)
		{
			if (!forceRefresh && this.PhantomSuitLayout.GetDisplayGridNum() > 0)
			{
				this.PhantomSuitLayout.RefreshWithoutDataSync();
				return;
			}
			List<RoleDevelopPhantomSuitData> recommendPhantomSuits = this.Data.GetDevelopRoleData().GetRecommendPhantomSuits(new int?(this.SelectPlanId), this.SelectFirstVisionMonsterId);
			if (recommendPhantomSuits.Count > 0)
			{
				recommendPhantomSuits[0].IsNeedFetterButton = new bool?(true);
			}
			this.PhantomSuitLayout.RefreshByData(recommendPhantomSuits, null, false);
		}

		// Token: 0x06035404 RID: 218116 RVA: 0x00D59C38 File Offset: 0x00D57E38
		private void RefreshPhantomItems()
		{
			RoleDevelopData data = this.Data;
			List<int> phantomIdList = data.GetDevelopRoleData().GetPhantomIdList();
			for (int i = 0; i < this.PhantomItems.Count; i++)
			{
				this.PhantomItems[i].Refresh(data, (i < phantomIdList.Count) ? phantomIdList[i] : 0, i);
			}
		}

		// Token: 0x06035405 RID: 218117 RVA: 0x00D59C94 File Offset: 0x00D57E94
		private void OnClickSwitchButton()
		{
			if (this.Data == null)
			{
				return;
			}
			VisionRecommendViewOpenParam param = new VisionRecommendViewOpenParam
			{
				RoleId = this.Data.GetId(),
				IsFromRoleDev = true,
				SuccessCallBack = new Action<int, int, int?>(this.OnChangeFetterGroupSuccessCallBack),
				GetSelectedPlanIdCallBack = new Func<int, int>(this.OnGetSelectedPlanIdCallBack),
				GetSelectedFirstVisionMonsterIdCallBack = new Func<int, int>(this.OnGetSelectedFirstVisionMonsterIdCallBack)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.VisionNewRecommendView, param, null);
			ControllerBase<RoleController>.Instance.LogRoleDevelopClick(this.Data.GetId(), ERoleDevelopCategoryType.Phantom, ERoleDevelopLogSubPage.PhantomDevelopSwitchSuit, null);
		}

		// Token: 0x06035406 RID: 218118 RVA: 0x00D59D30 File Offset: 0x00D57F30
		private void OnClickDevelop(int value)
		{
			if (this.Data == null)
			{
				return;
			}
			int id = this.Data.GetId();
			int num = 0;
			ModelBase<PhantomBattleModel>.Instance.CurrentEquipmentSelectIndex = num;
			int equipByIndex = ControllerBase<PhantomBattleController>.Instance.GetEquipByIndex(id, num);
			ModelBase<PhantomBattleModel>.Instance.CurrentSelectUniqueId = equipByIndex;
			PhantomUtil.OpenVisionEquipmentView(id, num, null);
			ControllerBase<RoleController>.Instance.LogRoleDevelopClick(id, ERoleDevelopCategoryType.Phantom, ERoleDevelopLogSubPage.PhantomDevelopJump, null);
		}

		// Token: 0x06035407 RID: 218119 RVA: 0x00D59D9F File Offset: 0x00D57F9F
		private RoleDevelopProjectPhantomSuitItem CreatePhantomSuitItem()
		{
			return new RoleDevelopProjectPhantomSuitItem();
		}

		// Token: 0x06035408 RID: 218120 RVA: 0x00D59DA6 File Offset: 0x00D57FA6
		private void OnChangeFetterGroupSuccessCallBack(int roleId, int planId, int? firstVisionMonsterId)
		{
			this.SelectPlanId = planId;
			this.SelectFirstVisionMonsterId = firstVisionMonsterId;
			this.RefreshPhantomSuitList(true);
			if (ModelBase<RoleDevelopModel>.Instance.DevTargetRoleId == roleId)
			{
				ControllerBase<RoleController>.Instance.RequestUpdateDevelopTarget(roleId, ERoleDevelopUpdateTargetSource.RoleDevelop, new int?(planId), firstVisionMonsterId);
			}
		}

		// Token: 0x06035409 RID: 218121 RVA: 0x00D59DDD File Offset: 0x00D57FDD
		private int OnGetSelectedPlanIdCallBack(int roleId)
		{
			return this.SelectPlanId;
		}

		// Token: 0x0603540A RID: 218122 RVA: 0x00D59DE5 File Offset: 0x00D57FE5
		private int OnGetSelectedFirstVisionMonsterIdCallBack(int roleId)
		{
			return this.SelectFirstVisionMonsterId.GetValueOrDefault();
		}

		// Token: 0x0401EA38 RID: 125496
		private List<RoleDevelopProjectPhantomItem> PhantomItems = new List<RoleDevelopProjectPhantomItem>();

		// Token: 0x0401EA39 RID: 125497
		private ButtonItem ButtonDevelop;

		// Token: 0x0401EA3A RID: 125498
		public int SelectPlanId;

		// Token: 0x0401EA3B RID: 125499
		public int? SelectFirstVisionMonsterId = new int?(0);

		// Token: 0x0401EA3C RID: 125500
		private int FetterInitRoleId;

		// Token: 0x0401EA3D RID: 125501
		private GenericLayout<RoleDevelopProjectPhantomSuitItem, RoleDevelopPhantomSuitData> PhantomSuitLayout;

		// Token: 0x0200B046 RID: 45126
		[NullableContext(0)]
		public static class EComponentType
		{
			// Token: 0x04036AF8 RID: 223992
			public const int PanelPhantomDev = 0;

			// Token: 0x04036AF9 RID: 223993
			public const int BtnDevelop = 1;

			// Token: 0x04036AFA RID: 223994
			public const int BtnPerfectDevelop = 2;

			// Token: 0x04036AFB RID: 223995
			public const int SubPhantomCircle1 = 3;

			// Token: 0x04036AFC RID: 223996
			public const int SubPhantomCircle2 = 4;

			// Token: 0x04036AFD RID: 223997
			public const int SubPhantomCircle3 = 5;

			// Token: 0x04036AFE RID: 223998
			public const int SubPhantomCircle4 = 6;

			// Token: 0x04036AFF RID: 223999
			public const int SubPhantomCircle5 = 7;

			// Token: 0x04036B00 RID: 224000
			public const int BtnSwitch = 8;

			// Token: 0x04036B01 RID: 224001
			public const int PanelSuitLayout = 9;

			// Token: 0x04036B02 RID: 224002
			public const int PanelSuit = 10;
		}
	}
}
