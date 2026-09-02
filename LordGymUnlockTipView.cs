using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002212 RID: 8722
public class LordGymUnlockTipView : UiViewBase
{
	// Token: 0x0601077D RID: 67453 RVA: 0x0047F545 File Offset: 0x0047D745
	[NullableContext(1)]
	public LordGymUnlockTipView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601077E RID: 67454 RVA: 0x0047F54E File Offset: 0x0047D74E
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText))
		};
	}

	// Token: 0x0601077F RID: 67455 RVA: 0x0047F574 File Offset: 0x0047D774
	protected override void OnBeforeShow()
	{
		int lordId = (int)this.OpenParam;
		this.RefreshLord(lordId);
	}

	// Token: 0x06010780 RID: 67456 RVA: 0x0047F594 File Offset: 0x0047D794
	private void RefreshLord(int lordId)
	{
		LordGym? lordGymConfig = ConfigBase<LordGymConfig>.Instance.GetLordGymConfig(lordId);
		if (lordGymConfig == null)
		{
			return;
		}
		LordGym value = lordGymConfig.Value;
		if (value.Version == 2)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "Text_LordGymNewDifficultyUnlock_Text", Array.Empty<object>());
		}
		else if (value.Version == 3)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "Text_LordGymNewDifficultyUnlock_Text", Array.Empty<object>());
		}
		else
		{
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(value.GymTitle, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "LordGymUnLock", new <>z__ReadOnlySingleElementList<object>(localTextNew ?? ""));
		}
		if (!ModelBase<LordGymModel>.Instance.GetLordGymHasRead(lordId))
		{
			ControllerBase<LordGymController>.Instance.ReadLordGym(lordId);
		}
	}

	// Token: 0x06010781 RID: 67457 RVA: 0x0047F659 File Offset: 0x0047D859
	protected override void OnAfterPlayStartSequence()
	{
		base.CloseMe(null);
	}

	// Token: 0x020084F4 RID: 34036
	private class EComponents
	{
		// Token: 0x0402D06B RID: 184427
		public const int UnLockText = 0;
	}
}
