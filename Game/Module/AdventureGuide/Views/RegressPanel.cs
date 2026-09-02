using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.AdventureGuide.Views
{
	// Token: 0x020061AB RID: 25003
	[NullableContext(1)]
	[Nullable(0)]
	public class RegressPanel : UiPanelBase
	{
		// Token: 0x0603F227 RID: 258599 RVA: 0x01031E9C File Offset: 0x0103009C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickJumpBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603F228 RID: 258600 RVA: 0x01031F84 File Offset: 0x01030184
		protected override void OnStart()
		{
			this.RemainTimeText = ConfigMultiTextLang.GetLocalTextNew("RegressPanelRemainTime", null);
			this.RoleLayout = new GenericLayout<RoleItem, int>(base.GetHorizontalLayout(1), new Func<RoleItem>(this.InitRoleItem), null, false, true);
			List<int> gachaPoolUpRole = ModelBase<ActivityRegressModel>.Instance.GetGachaPoolUpRole();
			this.RoleLayout.RefreshByData(gachaPoolUpRole, null, false);
			this.ActivityData = (ModelBase<ActivityRegressModel>.Instance.CheckIfInShowTime ? ModelBase<ActivityRegressModel>.Instance.ActivityData : ControllerBase<ActivityNewPlayerSupportController>.Instance.ActivityData);
			this.RefreshTimer = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.OnTimerRefresh), (float)Singleton<TimeUtil>.Instance.InverseMillisecond, 1f, null, null, true);
			this.OnTimerRefresh(0f);
		}

		// Token: 0x0603F229 RID: 258601 RVA: 0x01032040 File Offset: 0x01030240
		private void OnTimerRefresh(float _)
		{
			if (this.ActivityData == null || !this.ActivityData.CheckIfInShowTime())
			{
				return;
			}
			string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(this.ActivityData.EndShowTime, this.RemainTimeText);
			base.GetText(0).SetText(remainTimeText, true);
		}

		// Token: 0x0603F22A RID: 258602 RVA: 0x0103208D File Offset: 0x0103028D
		private void ClearTimer()
		{
			if (TimerSystem.GameplayTimeInstance.Has(this.RefreshTimer))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.RefreshTimer);
				this.RefreshTimer = null;
			}
		}

		// Token: 0x0603F22B RID: 258603 RVA: 0x010320B9 File Offset: 0x010302B9
		private RoleItem InitRoleItem()
		{
			return new RoleItem();
		}

		// Token: 0x0603F22C RID: 258604 RVA: 0x010320C0 File Offset: 0x010302C0
		private void OnClickJumpBtn()
		{
			bool checkIfInShowTime = ModelBase<ActivityRegressModel>.Instance.CheckIfInShowTime;
			IActivityRegressMainViewOpenData activityRegressMainViewOpenData = new IActivityRegressMainViewOpenData
			{
				SubView = EActivityMainSubViewNewType.Adventure,
				OpenType = (checkIfInShowTime ? EActivityRegressMainViewOpenDataType.Regress : EActivityRegressMainViewOpenDataType.NewPlayer)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityRegressMainView, activityRegressMainViewOpenData, null);
		}

		// Token: 0x0603F22D RID: 258605 RVA: 0x0103210E File Offset: 0x0103030E
		protected override void OnBeforeDestroy()
		{
			this.ClearTimer();
		}

		// Token: 0x04023710 RID: 145168
		private string RemainTimeText = "";

		// Token: 0x04023711 RID: 145169
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<RoleItem, int> RoleLayout;

		// Token: 0x04023712 RID: 145170
		[Nullable(2)]
		private TimerHandle RefreshTimer;

		// Token: 0x04023713 RID: 145171
		[Nullable(2)]
		private ActivityBaseData ActivityData;
	}
}
