using System;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;

// Token: 0x02003309 RID: 13065
public class RedDotBattleViewGachaButton : RedDotBase
{
	// Token: 0x0601B5AE RID: 112046 RVA: 0x00834F54 File Offset: 0x00833154
	protected override bool OnCheck(int uId = 0)
	{
		bool flag = ModelBase<GachaModel>.Instance.CheckNewGachaPool();
		bool flag2 = this.CheckNeedShowWeaponSelectRedDot();
		bool flag3 = this.CheckGachaAccumulateRedDot();
		return flag || flag2 || flag3;
	}

	// Token: 0x0601B5AF RID: 112047 RVA: 0x00834F80 File Offset: 0x00833180
	private bool CheckNeedShowWeaponSelectRedDot()
	{
		ProtoGachaInfo[] gachaInfoArray = ModelBase<GachaModel>.Instance.GachaInfoArray;
		if (gachaInfoArray == null)
		{
			return false;
		}
		foreach (ProtoGachaInfo protoGachaInfo in gachaInfoArray)
		{
			ProtoGachaPoolInfo firstValidPool = protoGachaInfo.GetFirstValidPool();
			if (firstValidPool != null && firstValidPool.UiType == 5)
			{
				bool flag = protoGachaInfo.UsePoolId == 0;
				bool player = LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.FirstOpenCommonWeaponSelect, false);
				if (flag && !player)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0601B5B0 RID: 112048 RVA: 0x00834FE8 File Offset: 0x008331E8
	private bool CheckGachaAccumulateRedDot()
	{
		ProtoGachaInfo[] gachaInfoArray = ModelBase<GachaModel>.Instance.GachaInfoArray;
		if (gachaInfoArray == null)
		{
			return false;
		}
		foreach (ProtoGachaInfo protoGachaInfo in gachaInfoArray)
		{
			if (protoGachaInfo.GachaAccumulateId > 0)
			{
				GachaAccumulateData accumulateData = ModelBase<GachaAccumulateModel>.Instance.GetAccumulateData(protoGachaInfo.GachaAccumulateId);
				if (accumulateData != null && accumulateData.GetUnTakeRewardNum() > 0)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0601B5B1 RID: 112049 RVA: 0x00835048 File Offset: 0x00833248
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnOpenGachaChanged, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.OnOpenCommonWeaponSelect, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.GachaAccumulateRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B5B2 RID: 112050 RVA: 0x008350AC File Offset: 0x008332AC
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnOpenGachaChanged, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnOpenCommonWeaponSelect, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.GachaAccumulateRedDot, new Action(base.EventCheck));
	}
}
