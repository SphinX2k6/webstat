using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200146B RID: 5227
[NullableContext(1)]
[Nullable(0)]
public class ActivityNewPlayerSupportSubView : ActivitySubViewBase
{
	// Token: 0x0600922F RID: 37423 RVA: 0x00268F3B File Offset: 0x0026713B
	protected override void OnSetData()
	{
		this.ActivityData = (this.ActivityBaseData as ActivityNewPlayerSupportData);
	}

	// Token: 0x06009230 RID: 37424 RVA: 0x00268F50 File Offset: 0x00267150
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUITexture)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIText)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIText)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.OnChangeRoleClick))
		};
	}

	// Token: 0x06009231 RID: 37425 RVA: 0x002690F4 File Offset: 0x002672F4
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityNewPlayerSupportSubView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityNewPlayerSupportSubView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009232 RID: 37426 RVA: 0x00269138 File Offset: 0x00267338
	protected override void OnStart()
	{
		this.RemainTimeText = ConfigMultiTextLang.GetLocalTextNew("ActivityRemainingTime", null);
		this.ChosenText = ConfigCommonParamById.GetStringConfig("NewPlayerSupportTrialRoleChosenDesc");
		this.TaskLayout = new GenericLayout<ActivityNewPlayerSupportTaskItem, IActivityNewPlayerSupportTaskItemData>(base.GetHorizontalLayout(9), new Func<ActivityNewPlayerSupportTaskItem>(this.CreateLayoutItem), null, false, true);
		this.TimeTxt = base.GetText(1);
		this.IsRemainTimeActive = (this.ActivityData.EndShowTime != 0L);
		this.TimeTxt.SetUIActive(this.IsRemainTimeActive);
		base.GetText(0).SetText(this.ActivityData.GetTitle(), true);
		base.GetText(2).SetText(this.ActivityData.GetDesc(), true);
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RedDotNewPlayerSupportTrialRoleEntrance, base.GetItem(12), null, 0);
	}

	// Token: 0x06009233 RID: 37427 RVA: 0x00269204 File Offset: 0x00267404
	protected override void OnBeforeDestroy()
	{
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RedDotNewPlayerSupportTrialRoleEntrance, base.GetItem(12), 0);
	}

	// Token: 0x06009234 RID: 37428 RVA: 0x0026921E File Offset: 0x0026741E
	protected override void OnBeforeShow()
	{
		this.RefreshTrailRoleView();
		this.RefreshTaskView();
		Singleton<EventSystem>.Instance.Emit(EEventName.OnActivityNewPlayerSupportEntranceRedDotUpdate);
	}

	// Token: 0x06009235 RID: 37429 RVA: 0x0026923C File Offset: 0x0026743C
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnActivityNewPlayerSupportTaskUpdate, new Action(this.OnTaskUpdate));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnActivityNewPlayerSupportCurTrialRoleChange, new Action<int>(this.OnCurTrialRoleChange));
	}

	// Token: 0x06009236 RID: 37430 RVA: 0x00269276 File Offset: 0x00267476
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivityNewPlayerSupportTaskUpdate, new Action(this.OnTaskUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivityNewPlayerSupportCurTrialRoleChange, new Action<int>(this.OnCurTrialRoleChange));
	}

	// Token: 0x06009237 RID: 37431 RVA: 0x002692B0 File Offset: 0x002674B0
	protected override void OnRefreshView()
	{
		this.RefreshTrailRoleView();
		this.RefreshTaskView();
		Singleton<EventSystem>.Instance.Emit(EEventName.OnActivityNewPlayerSupportEntranceRedDotUpdate);
	}

	// Token: 0x06009238 RID: 37432 RVA: 0x002692CE File Offset: 0x002674CE
	private void SetRemainTimeActive(bool isActive)
	{
		if (this.IsRemainTimeActive == isActive)
		{
			return;
		}
		this.IsRemainTimeActive = isActive;
		this.TimeTxt.SetUIActive(isActive);
	}

	// Token: 0x06009239 RID: 37433 RVA: 0x002692F0 File Offset: 0x002674F0
	private void SetRemainTimeText()
	{
		ValueTuple<bool, string> isInRemainTime = this.GetIsInRemainTime();
		bool item = isInRemainTime.Item1;
		string item2 = isInRemainTime.Item2;
		this.SetRemainTimeActive(item);
		if (item)
		{
			this.TimeTxt.SetText(item2, true);
		}
	}

	// Token: 0x0600923A RID: 37434 RVA: 0x00269328 File Offset: 0x00267528
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private ValueTuple<bool, string> GetIsInRemainTime()
	{
		if (!this.ActivityData.CheckIfInShowTime())
		{
			return new ValueTuple<bool, string>(false, "");
		}
		string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(this.ActivityData.EndShowTime, this.RemainTimeText);
		return new ValueTuple<bool, string>(true, remainTimeText);
	}

	// Token: 0x0600923B RID: 37435 RVA: 0x00269371 File Offset: 0x00267571
	protected override void OnTimer(float gap)
	{
		this.SetRemainTimeText();
	}

	// Token: 0x0600923C RID: 37436 RVA: 0x0026937C File Offset: 0x0026757C
	private void RefreshTrailRoleView()
	{
		TrialRoleGroupData curUseTrialRoleData = this.ActivityData.CurUseTrialRoleData;
		bool flag = curUseTrialRoleData != null;
		UUITexture roleTex = base.GetTexture(4);
		roleTex.SetUIActive(flag);
		UUIText text = base.GetText(11);
		text.SetUIActive(flag);
		UUIText text2 = base.GetText(13);
		text2.SetUIActive(!flag);
		UUIItem item = base.GetItem(14);
		UUIItem item2 = base.GetItem(15);
		if (flag)
		{
			TrialRoleConfig instance = ConfigBase<TrialRoleConfig>.Instance;
			RoleInfo? roleInfo = (instance != null) ? instance.GetRoleConfigByTrialRoleId(curUseTrialRoleData.TrialRoleId) : null;
			string formationRoleCard = roleInfo.Value.FormationRoleCard;
			base.SetTextureByPath(formationRoleCard, roleTex, null, delegate(bool _)
			{
				roleTex.SetSizeFromTexture();
			});
			string str = ConfigMultiTextLang.GetLocalTextNew(roleInfo.Value.Name, null) ?? "";
			string str2 = ConfigMultiTextLang.GetLocalTextNew(this.ChosenText, null) ?? "";
			text.SetText(str + " <color=#e6efff><size=-6>" + str2 + "</size></color>", true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, this.ChosenText, Array.Empty<object>());
			item.SetUIActive(false);
			item2.SetUIActive(false);
			return;
		}
		EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
		item.SetUIActive(playerGender == EPlayerGender.Male);
		item2.SetUIActive(playerGender == EPlayerGender.Female);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, "PrefabTextItem_436156489_Text", Array.Empty<object>());
	}

	// Token: 0x0600923D RID: 37437 RVA: 0x00269504 File Offset: 0x00267704
	private void RefreshTaskView()
	{
		ActivityNewPlayerSupportData activityData = this.ActivityData;
		List<ActivityNewPlayerSupportTaskData> list = (activityData != null) ? activityData.GetTaskDataList() : null;
		if (list == null)
		{
			return;
		}
		int count = list.Count;
		List<IActivityNewPlayerSupportTaskItemData> list2 = new List<IActivityNewPlayerSupportTaskItemData>();
		for (int i = 0; i < count; i++)
		{
			list2.Add(new ActivityNewPlayerSupportTaskItemData
			{
				TaskData = list[i],
				ShowDecoration = (i != count - 1)
			});
		}
		GenericLayout<ActivityNewPlayerSupportTaskItem, IActivityNewPlayerSupportTaskItemData> taskLayout = this.TaskLayout;
		if (taskLayout == null)
		{
			return;
		}
		taskLayout.RefreshByData(list2, null, false);
	}

	// Token: 0x0600923E RID: 37438 RVA: 0x0026957C File Offset: 0x0026777C
	private void OnChangeRoleClick()
	{
		ActivityNewPlayerSupportController instance = ControllerBase<ActivityNewPlayerSupportController>.Instance;
		if (instance == null)
		{
			return;
		}
		instance.OpenTrialRoleView(null);
	}

	// Token: 0x0600923F RID: 37439 RVA: 0x002695A1 File Offset: 0x002677A1
	private ActivityNewPlayerSupportTaskItem CreateLayoutItem()
	{
		return new ActivityNewPlayerSupportTaskItem();
	}

	// Token: 0x06009240 RID: 37440 RVA: 0x002695A8 File Offset: 0x002677A8
	private void OnTaskUpdate()
	{
		this.RefreshTaskView();
	}

	// Token: 0x06009241 RID: 37441 RVA: 0x002695B0 File Offset: 0x002677B0
	private void OnCurTrialRoleChange(int _)
	{
		this.RefreshTrailRoleView();
	}

	// Token: 0x06009242 RID: 37442 RVA: 0x002695B8 File Offset: 0x002677B8
	private void AdventureEntranceFunc()
	{
		IActivityRegressMainViewOpenData activityRegressMainViewOpenData = new IActivityRegressMainViewOpenData
		{
			SubView = EActivityMainSubViewNewType.Adventure,
			OpenType = EActivityRegressMainViewOpenDataType.NewPlayer
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityRegressMainView, activityRegressMainViewOpenData, null);
	}

	// Token: 0x06009243 RID: 37443 RVA: 0x002695F8 File Offset: 0x002677F8
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		string text = configParams[0];
		if (!(text == "NewPlayer_Award") && !text.Contains("NewPlayer_AwardSlot"))
		{
			return null;
		}
		int index = 0;
		GenericLayout<ActivityNewPlayerSupportTaskItem, IActivityNewPlayerSupportTaskItemData> taskLayout = this.TaskLayout;
		ActivityNewPlayerSupportTaskItem activityNewPlayerSupportTaskItem = (taskLayout != null) ? taskLayout.GetLayoutItemByIndex(index) : null;
		UUIItem uuiitem = (activityNewPlayerSupportTaskItem != null) ? activityNewPlayerSupportTaskItem.GetReceiveBtn() : null;
		if (text == "NewPlayer_Award")
		{
			if (uuiitem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem,
				uuiitem
			};
		}
		else
		{
			UUIItem uuiitem2 = (activityNewPlayerSupportTaskItem != null) ? activityNewPlayerSupportTaskItem.GetGuideUiItem("0") : null;
			if (uuiitem2 == null || uuiitem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem,
				uuiitem2
			};
		}
	}

	// Token: 0x040043B6 RID: 17334
	[Nullable(2)]
	private ActivityNewPlayerSupportData ActivityData;

	// Token: 0x040043B7 RID: 17335
	[Nullable(2)]
	private UUIText TimeTxt;

	// Token: 0x040043B8 RID: 17336
	private bool IsRemainTimeActive;

	// Token: 0x040043B9 RID: 17337
	private string RemainTimeText = "";

	// Token: 0x040043BA RID: 17338
	private string ChosenText = "";

	// Token: 0x040043BB RID: 17339
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<ActivityNewPlayerSupportTaskItem, IActivityNewPlayerSupportTaskItemData> TaskLayout;

	// Token: 0x040043BC RID: 17340
	[Nullable(2)]
	private ActivityNewPlayerSupportEntranceItem AdventureEntrance;

	// Token: 0x0200786C RID: 30828
	[NullableContext(0)]
	private static class EComponentType
	{
		// Token: 0x040296A0 RID: 169632
		public const int TitleTxt = 0;

		// Token: 0x040296A1 RID: 169633
		public const int TimeTxt = 1;

		// Token: 0x040296A2 RID: 169634
		public const int DescTxt = 2;

		// Token: 0x040296A3 RID: 169635
		public const int RoleItem = 3;

		// Token: 0x040296A4 RID: 169636
		public const int RoleTex = 4;

		// Token: 0x040296A5 RID: 169637
		public const int RoleLockTex = 5;

		// Token: 0x040296A6 RID: 169638
		public const int EntranceItem1 = 6;

		// Token: 0x040296A7 RID: 169639
		public const int EntranceItem2 = 7;

		// Token: 0x040296A8 RID: 169640
		public const int EntranceItem3 = 8;

		// Token: 0x040296A9 RID: 169641
		public const int TaskLayout = 9;

		// Token: 0x040296AA RID: 169642
		public const int TaskItem = 10;

		// Token: 0x040296AB RID: 169643
		public const int RoleTxt = 11;

		// Token: 0x040296AC RID: 169644
		public const int RedDotItem = 12;

		// Token: 0x040296AD RID: 169645
		public const int TrialTxt = 13;

		// Token: 0x040296AE RID: 169646
		public const int RoleLockItem1 = 14;

		// Token: 0x040296AF RID: 169647
		public const int RoleLockItem2 = 15;
	}
}
