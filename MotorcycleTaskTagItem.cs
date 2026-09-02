using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002293 RID: 8851
public class MotorcycleTaskTagItem : UiPanelBase
{
	// Token: 0x06010BBC RID: 68540 RVA: 0x00495D2C File Offset: 0x00493F2C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText))
		};
	}

	// Token: 0x06010BBD RID: 68541 RVA: 0x00495D9C File Offset: 0x00493F9C
	[NullableContext(1)]
	public void Refresh(MotorTechTaskNode node)
	{
		base.GetItem(1).SetUIActive(node.Type == EMotorTechTaskType.Loop);
		base.GetItem(2).SetUIActive(node.Type == EMotorTechTaskType.Limited);
		if (node.Type == EMotorTechTaskType.Limited)
		{
			double endTime = (double)node.EndTime;
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			double num = Math.Max(endTime - serverTime, 1.0);
			CommonDefine.ETimeType[] timeTypeData = this.GetTimeTypeData(num);
			string text = Singleton<TimeUtil>.Instance.GetCountDownDataFormat2(num, new CommonDefine.ETimeType?(timeTypeData[0]), new CommonDefine.ETimeType?(timeTypeData[1])).CountDownText ?? "";
			base.GetText(3).SetText(StringUtils.Format("{0}", new string[]
			{
				text
			}), true);
		}
		else if (node.Type == EMotorTechTaskType.Loop)
		{
			int num2 = node.RewardInfo.WaitRewardCount + node.RewardInfo.RewardedCount;
			int maxRewardCount = node.RewardInfo.MaxRewardCount;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "MotorBike_TechCube_RepeatStatus", new <>z__ReadOnlyArray<object>(new object[]
			{
				num2,
				maxRewardCount
			}));
		}
		UUISprite sprite = base.GetSprite(0);
		UUIItem uuiitem = sprite;
		bool bUseChangeColor = node.Type == EMotorTechTaskType.Loop;
		FColor? fcolor = new FColor?(sprite.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
	}

	// Token: 0x06010BBE RID: 68542 RVA: 0x00495EE0 File Offset: 0x004940E0
	[NullableContext(1)]
	private CommonDefine.ETimeType[] GetTimeTypeData(double remainTime)
	{
		if (remainTime > 86400.0)
		{
			return new CommonDefine.ETimeType[]
			{
				CommonDefine.ETimeType.Day,
				CommonDefine.ETimeType.Hour
			};
		}
		if (remainTime > 3600.0)
		{
			return new CommonDefine.ETimeType[]
			{
				CommonDefine.ETimeType.Hour,
				CommonDefine.ETimeType.Minute
			};
		}
		if (remainTime > 60.0)
		{
			CommonDefine.ETimeType[] array = new CommonDefine.ETimeType[2];
			array[0] = CommonDefine.ETimeType.Minute;
			return array;
		}
		return new CommonDefine.ETimeType[2];
	}

	// Token: 0x0200855E RID: 34142
	private class EMotorTaskTabItemComponent
	{
		// Token: 0x0402D222 RID: 184866
		public const int SprTagBg = 0;

		// Token: 0x0402D223 RID: 184867
		public const int RepeatItem = 1;

		// Token: 0x0402D224 RID: 184868
		public const int TimeItem = 2;

		// Token: 0x0402D225 RID: 184869
		public const int TxtTag = 3;
	}
}
