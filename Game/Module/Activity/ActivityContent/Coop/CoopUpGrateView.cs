using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Coop
{
	// Token: 0x020069A8 RID: 27048
	[NullableContext(2)]
	[Nullable(0)]
	public class CoopUpGrateView : UiViewBase
	{
		// Token: 0x06043155 RID: 274773 RVA: 0x0113ABDA File Offset: 0x01138DDA
		[NullableContext(1)]
		public CoopUpGrateView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06043156 RID: 274774 RVA: 0x0113ABF0 File Offset: 0x01138DF0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIText)),
				new ValueTuple<int, Type>(8, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(1, new Action(this.OnClickGoBtn))
			};
		}

		// Token: 0x06043157 RID: 274775 RVA: 0x0113ACF4 File Offset: 0x01138EF4
		protected override UniTask OnBeforeStartAsync()
		{
			CoopUpGrateView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CoopUpGrateView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06043158 RID: 274776 RVA: 0x0113AD38 File Offset: 0x01138F38
		protected override void OnStart()
		{
			CoopUpGrateViewParams coopUpGrateViewParams = this.OpenParam as CoopUpGrateViewParams;
			this.ActivityData = coopUpGrateViewParams.ActivityData;
			this.RoleId = new int?(coopUpGrateViewParams.RoleId);
			if (this.RoleId != null && this.RoleId.Value != 0)
			{
				CoopRole? coopRoleConfigByRoleId = ConfigBase<CoopConfig>.Instance.GetCoopRoleConfigByRoleId(this.RoleId.Value);
				if (!string.IsNullOrEmpty((coopRoleConfigByRoleId != null) ? coopRoleConfigByRoleId.GetValueOrDefault().LevelUpRolePortrait : null))
				{
					base.SetTextureByPath(coopRoleConfigByRoleId.Value.LevelUpRolePortrait, base.GetTexture(0), null, null);
				}
				CoopActivityData activityData = this.ActivityData;
				int? num = (activityData != null) ? new int?(activityData.GetRoleCurCoopLevelId(this.RoleId.Value)) : null;
				if (num != null)
				{
					int? num2 = num;
					int num3 = 0;
					if (!(num2.GetValueOrDefault() == num3 & num2 != null))
					{
						CoopRoleLevel? coopConfigById = ConfigBase<CoopConfig>.Instance.GetCoopConfigById(num.Value);
						if (!string.IsNullOrEmpty((coopConfigById != null) ? coopConfigById.GetValueOrDefault().LevelUpText : null))
						{
							Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), coopConfigById.Value.LevelUpText, Array.Empty<object>());
						}
						if (!string.IsNullOrEmpty((coopConfigById != null) ? coopConfigById.GetValueOrDefault().LevelUpTitleText : null))
						{
							Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), coopConfigById.Value.LevelUpTitleText, Array.Empty<object>());
							goto IL_19F;
						}
						goto IL_19F;
					}
				}
				return;
			}
			IL_19F:
			this.RefreshLevelTogItemList();
		}

		// Token: 0x06043159 RID: 274777 RVA: 0x0113AEEC File Offset: 0x011390EC
		private void RefreshLevelTogItemList()
		{
			if (this.RoleId == null || this.RoleId.Value == 0)
			{
				return;
			}
			CoopActivityData activityData = this.ActivityData;
			CoopRoleData coopRoleData = (activityData != null) ? activityData.GetRoleData(this.RoleId.Value) : null;
			if (coopRoleData == null)
			{
				return;
			}
			ECoopLvUpShowType levelUpViewShowType = coopRoleData.LevelUpViewShowType;
			List<CoopLevelData> coopLevelDataList = coopRoleData.GetCoopLevelDataList();
			if (levelUpViewShowType == ECoopLvUpShowType.OneLevel)
			{
				this.RefreshOneLevelTogItem(coopLevelDataList);
				return;
			}
			if (levelUpViewShowType != ECoopLvUpShowType.FiveLevel)
			{
				return;
			}
			this.RefreshFiveLevelTogItem(coopLevelDataList);
		}

		// Token: 0x0604315A RID: 274778 RVA: 0x0113AF5C File Offset: 0x0113915C
		[NullableContext(1)]
		private void RefreshOneLevelTogItem(List<CoopLevelData> levelDataList)
		{
			base.GetItem(2).SetUIActive(false);
			base.GetItem(3).SetUIActive(false);
			base.GetItem(4).SetUIActive(true);
			base.GetItem(5).SetUIActive(false);
			base.GetItem(6).SetUIActive(false);
			if (levelDataList.Count > 0)
			{
				this.LevelTogItem3.RefreshView(levelDataList[0]);
			}
		}

		// Token: 0x0604315B RID: 274779 RVA: 0x0113AFC8 File Offset: 0x011391C8
		[NullableContext(1)]
		private void RefreshFiveLevelTogItem(List<CoopLevelData> levelDataList)
		{
			base.GetItem(2).SetUIActive(true);
			base.GetItem(3).SetUIActive(true);
			base.GetItem(4).SetUIActive(true);
			base.GetItem(5).SetUIActive(true);
			base.GetItem(6).SetUIActive(true);
			for (int i = 0; i < levelDataList.Count; i++)
			{
				CoopLevelData levelData = levelDataList[i];
				this.LevelTogItemList[i].RefreshView(levelData);
			}
		}

		// Token: 0x0604315C RID: 274780 RVA: 0x0113B044 File Offset: 0x01139244
		protected void OnClickGoBtn()
		{
			CoopActivityData activityData = this.ActivityData;
			int? num = (activityData != null) ? new int?(activityData.GetRoleCurCoopLevel(this.RoleId.Value)) : null;
			CoopActivityData activityData2 = this.ActivityData;
			int? num2 = (activityData2 != null) ? new int?(activityData2.GetRoleCurCoopLevelId(this.RoleId.Value)) : null;
			CoopRoleSelectViewParams param = new CoopRoleSelectViewParams
			{
				ActivityData = this.ActivityData,
				Index = this.ActivityData.GetRoleIndexByRoleId(this.RoleId.Value),
				Level = num.Value,
				LevelId = num2.Value,
				IsOpenByUpGradeView = true
			};
			base.CloseMe(null);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CoopRoleSelectView, param, null);
		}

		// Token: 0x0402562A RID: 153130
		private CoopActivityData ActivityData;

		// Token: 0x0402562B RID: 153131
		private int? RoleId;

		// Token: 0x0402562C RID: 153132
		private CoopUpLevelTogItem LevelTogItem1;

		// Token: 0x0402562D RID: 153133
		private CoopUpLevelTogItem LevelTogItem2;

		// Token: 0x0402562E RID: 153134
		private CoopUpLevelTogItem LevelTogItem3;

		// Token: 0x0402562F RID: 153135
		private CoopUpLevelTogItem LevelTogItem4;

		// Token: 0x04025630 RID: 153136
		private CoopUpLevelTogItem LevelTogItem5;

		// Token: 0x04025631 RID: 153137
		[Nullable(1)]
		private List<CoopUpLevelTogItem> LevelTogItemList = new List<CoopUpLevelTogItem>();
	}
}
