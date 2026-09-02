using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066E7 RID: 26343
	public class MotorFightArchiveTip : UiViewBase
	{
		// Token: 0x06041C2D RID: 269357 RVA: 0x010DE2CC File Offset: 0x010DC4CC
		[NullableContext(1)]
		public MotorFightArchiveTip(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06041C2E RID: 269358 RVA: 0x010DE2D8 File Offset: 0x010DC4D8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnContinueBtnClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnStartDirectlyBtnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041C2F RID: 269359 RVA: 0x010DE404 File Offset: 0x010DC604
		protected override void OnBeforeShow()
		{
			this.SelectedLevelId = (int)this.OpenParam;
			this.ActivityData = ControllerBase<MotorFightController>.Instance.GetMotorFightActivityData();
			MotorFightLastSaveData lastSavedLevelData = this.ActivityData.GetLastSavedLevelData();
			if (lastSavedLevelData == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.MotorFightActivity, ELogAuthor.CXJ, "摩托战斗存档数据不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.LastSavedLevelId = lastSavedLevelData.LevelId;
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(this.ActivityData.GetLevelDataById(this.LastSavedLevelId).LevelName, null);
			UUIText text = base.GetText(2);
			if (text != null)
			{
				text.SetText(localTextNew, true);
			}
			long num = Singleton<MathUtils>.Instance.LongToNumber(lastSavedLevelData.CostTime);
			string timeDataFormatWithHour = Singleton<TimeUtil>.Instance.GetTimeDataFormatWithHour((double)num);
			UUIText text2 = base.GetText(3);
			if (text2 != null)
			{
				text2.SetText(timeDataFormatWithHour, true);
			}
			UUIText text3 = base.GetText(4);
			if (text3 == null)
			{
				return;
			}
			text3.SetText(lastSavedLevelData.Score.ToString(), true);
		}

		// Token: 0x06041C30 RID: 269360 RVA: 0x010DE4F4 File Offset: 0x010DC6F4
		private void OnContinueBtnClick()
		{
			MotorFightLevelData levelDataById = this.ActivityData.GetLevelDataById(this.LastSavedLevelId);
			ControllerBase<MotorFightController>.Instance.EnterMotorFightDungeonDirectly(this.LastSavedLevelId, levelDataById.RoleId, true);
		}

		// Token: 0x06041C31 RID: 269361 RVA: 0x010DE52C File Offset: 0x010DC72C
		private void OnStartDirectlyBtnClick()
		{
			ControllerBase<MotorFightController>.Instance.RequestSettlement(false, null);
			MotorFightLevelData levelDataById = this.ActivityData.GetLevelDataById(this.SelectedLevelId);
			MotorFightLevelDetailViewModel param = new MotorFightLevelDetailViewModel(this.ActivityData, levelDataById);
			base.CloseMe(null);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorFightLevelDetailView, param, null);
		}

		// Token: 0x04024B04 RID: 150276
		[Nullable(2)]
		private MotorFightActivityData ActivityData;

		// Token: 0x04024B05 RID: 150277
		private int SelectedLevelId;

		// Token: 0x04024B06 RID: 150278
		private int LastSavedLevelId;

		// Token: 0x0200C720 RID: 50976
		private class EComponent
		{
			// Token: 0x0403D4DA RID: 251098
			public const int BtnContinue = 0;

			// Token: 0x0403D4DB RID: 251099
			public const int BtnStartDirectly = 1;

			// Token: 0x0403D4DC RID: 251100
			public const int TextName = 2;

			// Token: 0x0403D4DD RID: 251101
			public const int TextTime = 3;

			// Token: 0x0403D4DE RID: 251102
			public const int TextScore = 4;
		}
	}
}
