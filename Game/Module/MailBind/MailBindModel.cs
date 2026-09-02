using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;

namespace CSharpScript.Game.Module.MailBind
{
	// Token: 0x020059FA RID: 23034
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class MailBindModel : ModelBase<MailBindModel>
	{
		// Token: 0x0603A5A9 RID: 239017 RVA: 0x00ECBC61 File Offset: 0x00EC9E61
		[NullableContext(1)]
		public void UpdateByProtoMailBindInfo(MailBindInfo mainBindInfo)
		{
			this.IsBind = mainBindInfo.IsBind;
			this.IsReward = mainBindInfo.IsReward;
			this.CloseTime = (float)mainBindInfo.CloseTime / 1000f;
		}

		// Token: 0x0603A5AA RID: 239018 RVA: 0x00ECBC8E File Offset: 0x00EC9E8E
		public bool GetIsBind()
		{
			return this.IsBind;
		}

		// Token: 0x0603A5AB RID: 239019 RVA: 0x00ECBC96 File Offset: 0x00EC9E96
		public bool GetIsReward()
		{
			return this.IsReward;
		}

		// Token: 0x0603A5AC RID: 239020 RVA: 0x00ECBC9E File Offset: 0x00EC9E9E
		public double GetCloseTime()
		{
			return (double)this.CloseTime;
		}

		// Token: 0x0603A5AD RID: 239021 RVA: 0x00ECBCA7 File Offset: 0x00EC9EA7
		public EMailBindState GetState()
		{
			if (this.IsReward)
			{
				return EMailBindState.HasReward;
			}
			if (this.IsBind)
			{
				return EMailBindState.CanReward;
			}
			return EMailBindState.NotBind;
		}

		// Token: 0x0603A5AE RID: 239022 RVA: 0x00ECBCC0 File Offset: 0x00EC9EC0
		[NullableContext(2)]
		public string GetRemainTimeText(double endTime)
		{
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			double num = Math.Max(endTime - serverTime, 1.0);
			ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType> timeTypeData = this.GetTimeTypeData(num);
			if (timeTypeData.Item1 == CommonDefine.ETimeType.Second)
			{
				return ConfigBase<TextConfig>.Instance.GetTextById("NotEnoughOneHour");
			}
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew("ActivityRemainingTime", null);
			if (localTextNew == null)
			{
				return null;
			}
			CommonDefine.ICountDown countDownDataFormat = Singleton<TimeUtil>.Instance.GetCountDownDataFormat2(num, new CommonDefine.ETimeType?(timeTypeData.Item1), new CommonDefine.ETimeType?(timeTypeData.Item2));
			string text = ((countDownDataFormat != null) ? countDownDataFormat.CountDownText : null) ?? "";
			return StringUtils.Format(localTextNew, new string[]
			{
				text
			});
		}

		// Token: 0x0603A5AF RID: 239023 RVA: 0x00ECBD69 File Offset: 0x00EC9F69
		public ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType> GetTimeTypeData(Number remainTime)
		{
			if (remainTime > 86400)
			{
				return new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Day, CommonDefine.ETimeType.Hour);
			}
			if (remainTime > 3600)
			{
				return new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Hour, CommonDefine.ETimeType.Hour);
			}
			return new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Second, CommonDefine.ETimeType.Second);
		}

		// Token: 0x0603A5B0 RID: 239024 RVA: 0x00ECBDA8 File Offset: 0x00EC9FA8
		public bool CheckMailBindRedDot()
		{
			if (this.GetIsReward())
			{
				return false;
			}
			if (this.GetIsBind())
			{
				return true;
			}
			long? nextShowRedDotTime = this.GetNextShowRedDotTime();
			return nextShowRedDotTime == null || Singleton<TimeUtil>.Instance.GetServerTimeStamp() >= (double)nextShowRedDotTime.Value;
		}

		// Token: 0x0603A5B1 RID: 239025 RVA: 0x00ECBDF2 File Offset: 0x00EC9FF2
		public bool CheckGlobalMailBindOpen()
		{
			return ControllerBase<KuroSdkController>.Instance.GetIfGlobalSdk() && !FeatureRestrictionTemplate.TemplateForPioneerClient.Check() && (!this.GetIsReward() || Singleton<TimeUtil>.Instance.GetServerTime() <= this.GetCloseTime());
		}

		// Token: 0x0603A5B2 RID: 239026 RVA: 0x00ECBE2D File Offset: 0x00ECA02D
		public void SetNextShowRedDotTime(long nextTime)
		{
			(ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.MailBindNextShowRedDotTime) as ServerStorageLong).Set(new long?(nextTime));
		}

		// Token: 0x0603A5B3 RID: 239027 RVA: 0x00ECBE4B File Offset: 0x00ECA04B
		public long? GetNextShowRedDotTime()
		{
			ServerStorageUtil.OverrideLocalNumberToServerLong(ELocalStoragePlayerKey.MailBindNextShowRedDotTime, EClientStorageSystemIdType.MailBindNextShowRedDotTime);
			return (ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.MailBindNextShowRedDotTime) as ServerStorageLong).Get();
		}

		// Token: 0x040210B3 RID: 135347
		private bool IsBind;

		// Token: 0x040210B4 RID: 135348
		private bool IsReward;

		// Token: 0x040210B5 RID: 135349
		private float CloseTime;
	}
}
